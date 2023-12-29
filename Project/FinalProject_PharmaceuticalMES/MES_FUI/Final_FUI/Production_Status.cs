using System;
using System.Drawing;
using System.Windows.Forms;

namespace Final_FUI
{
    public partial class Production_Status : UserControl
    {
        private WO_Main parentWoMain;
        public string[] PS_HEADER = new string[] {
            "작업지시ID",
            "상태",
            "계획일자",
            "작업지시 시작일",
            "작업지시 종료일",
            "제품코드",
            "제품명",
            "계획수량",
            "생산수량",
            "공정ID",
            "공정명",
            "등록자ID",
            "등록일",
            "수주ID"
            
        };

        public Production_Status()
        {
            InitializeComponent();
            Dock = DockStyle.Fill; // UserControl 전체를 꽉 채우도록 설정
        }

        // 메인 폼을 설정하는 속성
        public WO_Main ParentWoMain
        {
            get { return parentWoMain; }
            set
            {
                parentWoMain = value;
                SearchPS(); // 메인 폼이 설정되면 자동으로 데이터 로드
            }
        }

        public void SearchPS() // 메인 작업 지시 리로드
        {
            RefreshDataGridView();
        }

        public void RefreshDataGridView()
        {
            if (parentWoMain != null)
            {
                dt_prost.DataSource = null; // 이전 데이터 지우기
                dt_prost.Rows.Clear();
                DateTime date1 = parentWoMain.dateTimePicker1.Value;
                DateTime date2 = parentWoMain.dateTimePicker2.Value;

                // 종료일을 다음날로 늘림
                date2 = date2.AddDays(1);

                string sql1 = $@"SELECT * FROM WORKORDER";
                string search_ps = $@"SELECT 
                            W.WOID, 
                            CASE W.WOSTAT
                                                               WHEN 'P' THEN '대기'
                                                               WHEN 'S' THEN '진행중'
                                                               WHEN 'E' THEN '완료'
                                                             
                                                           END AS WOSTAT, 
                            TO_CHAR(W.PLANDTTM, 'YYYY-MM-DD') AS PLANDATE, 
                            W.WOSTDTTM, 
                            W.WOEDDTTM,  
                            W.PRODID,  -- 기존 제품코드
                            CASE W.PRODID
                                WHEN 'P0001' THEN '타이레놀' 
                                WHEN 'P0002' THEN '아모디핀'
                                WHEN 'P0003' THEN '써스펜8'
                                WHEN 'P0004' THEN '스피드펜'
                            END AS PROD_NAME,
                         
                            W.PLANQTY, 
                            SUM(LT.LOTQTY) + SUM(DL.DEFECT_QTY) AS PRODQTY, 
                            W.PROCID,
                            CASE W.PROCID
                                 WHEN 'PC001' THEN '과립'
                                 WHEN 'PC002' THEN '타정'
                                 WHEN 'PC003' THEN '포장'
                                END AS PROC_NAME,
                            W.INSUSER,
                            W.INSDTTM, 
                            W.SOID
                       FROM WORKORDER W
                       LEFT JOIN LOT LT ON W.WOID = LT.WOID AND LT.LOTSTAT != 'D'
                       LEFT JOIN DEFECTLOT DL ON LT.LOTID = DL.DEFECT_LOTID
                       WHERE (W.PLANDTTM >= TO_DATE('{date1:yyyy-MM-dd}', 'YYYY-MM-DD') AND W.PLANDTTM < TO_DATE('{date2:yyyy-MM-dd}', 'YYYY-MM-DD') AND ";
                if (parentWoMain.comboBox1.SelectedIndex == 0) // 전체
                {
                    search_ps += $"(W.PROCID IN ('PC001','PC002','PC003'))) ";
                }
                else if (parentWoMain.comboBox1.SelectedIndex == 1) // 과립
                {
                    search_ps += $"W.PROCID = 'PC001') ";
                }
                else if (parentWoMain.comboBox1.SelectedIndex == 2) // 타정
                {
                    search_ps += $"W.PROCID = 'PC002') ";
                }
                else if (parentWoMain.comboBox1.SelectedIndex == 3) // 포장
                {
                    search_ps += $"W.PROCID = 'PC003') ";
                }
                search_ps += @"GROUP BY W.WOID, W.WOSTAT, W.PLANDTTM, W.WOSTDTTM, W.WOEDDTTM, W.PRODID, W.PLANQTY, W.PROCID, 
                                               W.INSUSER,W.INSDTTM, W.SOID ";
                search_ps += $"ORDER BY CASE W.WOSTAT WHEN 'S' THEN 1  WHEN 'P' THEN 2  WHEN 'E' THEN 3   ELSE 4 END, W.WOSTDTTM";
                parentWoMain.LoadDataToGridView(search_ps, dt_prost, PS_HEADER, false);
                // DataGridView 위치와 크기 조정하여 겹치도록 설정
                
                dt_prost.Location = new Point(0, 0);
                dt_prost.Size = new Size(this.Width, this.Height); // UserControl의 크기로 설정

            }
        }
        private void Production_Status_Load(object sender, EventArgs e)
        {
            // 로드 시 아무 작업도 하지 않음
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 필요한 작업 수행
        }

        private void dt_prost_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
