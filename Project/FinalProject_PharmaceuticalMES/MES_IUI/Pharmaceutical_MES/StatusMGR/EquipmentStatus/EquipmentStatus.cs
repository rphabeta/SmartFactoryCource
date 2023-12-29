using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.StatusMGR.EquipmentStatus
{
    public partial class EquipmentStatus : Form
    {
        string selectedEQPTID = string.Empty;
        List<string> durationList = new List<string>()
        {
            "일별",
            "주별",
            "월별"
        };
        
        public EquipmentStatus()
        {
            InitializeComponent();
        }

        // 조회
        private void EquipmentSearch()
        {
            string DB_EQPT_Query = $@"SELECT EQPTID                            -- 설비코드
                                           , EQPTNAME                          -- 설비명
                                           , PROCID                            -- 공정코드
                                           , DECODE(EQPTSTATS,
                                                    'DOWN', '정지',
                                                    'RUN',  '작동')            -- 설비가동
                                      FROM EQUIPMENT
                                     ";

            // GridView 적용
            DatabaseManager.DB_Inquiry(DB_EQPT_Query, gvEQUIPMENT);


            // GridView 칼럼명 설정 
            string[] EQPT_HeaderName = new string[] { "설비코드", "설비명", "공정코드", "설비가동여부"};
            GridViewHeaderSetter(gvEQUIPMENT, EQPT_HeaderName, "true");

        }

        private void EQPT_TotalSearch()
        {
            string Total_EQPT_Search = $@"SELECT LT.EQPTID                                                                 /* 설비 ID */
                                                 , EQ.EQPTNAME                                                              /* 설비명 */
                                                 , WO.PRODID                                                                /* 설비가 마지막에 생산한 제품코드 */
                                                 , PD.PRODNAME                                                              /* 설비가 마지막에 생상한 제품명 */
                                                 , LT.LOTEDDTTM                                                             /* 설비가 마지막에 생산한 LOT 종료 시간 */
                                                 , DECODE(EQ.EQPTSTATS, 'RUN', '가동', 'DOWN', '비가동') EQPTSTATS               /* 설비 현재 상태 */
                                                 , T1.LOTQTY                                                                /* 설비의 일별/ 주별/ 월별 양품량 */
                                                 , T1.DEFECT_QTY                                                            /* 설비의 일별/ 주별/ 월별 불량량 */
                                                 , ROUND(T1.DEFECT_QTY / (T1.LOTQTY + T1.DEFECT_QTY) * 100, 2) DEFECT_RATE  /* 설비의 일별/ 주별/ 월별 불량율 */
                                                 , LT.WORKERID                                                              /* 설비의 최종 작업자 */      
                                                 , ROUND(TO_DATE(TO_CHAR(T1.MAX_LOTEDDTTM, 'YYYY-MM-DD HH24:MI:SS'), 'YYYY-MM-DD HH24:MI:SS') 
                                                       - TO_DATE(TO_CHAR(T1.MIN_LOTCRDTTM, 'YYYY-MM-DD HH24:MI:SS'), 'YYYY-MM-DD HH24:MI:SS'), 2 ) * 24 AS hh /* 설비의 일별/ 주별/ 월별 가동시간 합계 */
                                                 , (SELECT COUNT(DISTINCT TO_CHAR(LOTCRDTTM, 'YYYYMMDD') )
                                                     FROM LOT A
                                                    WHERE A.LOTEDDTTM >= SYSDATE - DECODE(':duration_',
                                                                                          '일별', 1,
                                                                                          '주별', 6,
                                                                                          '월별', 30) -- 조회조건 : 당일이면 1, 주별이면 6, 월별이면 30    
                                                      AND A.EQPTID = LT.EQPTID
                                                   GROUP BY A.EQPTID
                                                   ) RUNCNT /* 설비별 주별/월별 가동 횟수 */
                 
                                              FROM EQUIPMENT         EQ     
                                              LEFT JOIN LOT          LT     ON LT.EQPTID = EQ.EQPTID
                                              LEFT JOIN WORKORDER    WO     ON LT.WOID = WO.WOID
                                              LEFT JOIN PRODUCT      PD     ON WO.PRODID = PD.PRODID
                                              LEFT JOIN ( SELECT SUM(LT.LOTQTY) LOTQTY
                                                               , NVL(SUM(DL.DEFECT_QTY), 0) DEFECT_QTY    
                                                               , MIN(LT.LOTCRDTTM)          MIN_LOTCRDTTM
                                                               , MAX(LT.LOTEDDTTM)          MAX_LOTEDDTTM
                                                               , LT.EQPTID
                                                            FROM LOT             LT
                                                            LEFT JOIN DEFECTLOT  DL   ON LT.LOTID = DL.DEFECT_LOTID
                                                           WHERE LT.LOTCRDTTM >= SYSDATE - DECODE(':duration_',
                                                                                          '일별', 1,
                                                                                          '주별', 6,
                                                                                          '월별', 30) -- 조회조건 : 당일이면 1, 주별이면 6, 월별이면 30    
                                                             AND LT.LOTEDDTTM <= SYSDATE
                                                             AND LT.LOTSTAT != 'D'
                                                            GROUP BY LT.EQPTID
                                              ) T1 ON EQ.EQPTID = T1.EQPTID
                                             WHERE LT.LOTID IN (SELECT MAX(LOTID) FROM LOT GROUP BY EQPTID)   
                                        ";
            string duration = cbDuration.Text;

            Total_EQPT_Search = Total_EQPT_Search.Replace(":duration_", duration);
            DatabaseManager.DB_Inquiry(Total_EQPT_Search, gvTotalEQPT);
            string[] Total_EQPT_HeaderName = new string[] { "설비코드", "설비명", "제품코드", "제품명", "LOT생성일", "설비가동여부", "양품수", "불량수", "불량률", "최종작업자", "총 가동시간", "가동횟수" };
            GridViewHeaderSetter(gvTotalEQPT, Total_EQPT_HeaderName, "true");

        }

        // 설비테이블 선택 셀 가져옴
        private void gvEQUIPMENT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = gvEQUIPMENT.Rows[e.RowIndex];

                // 선택된 행에 대한 작업 수행
                selectedEQPTID = selectedRow.Cells["EQPTID"].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("선택된 셀이 없습니다.");
            }
        }

        private void btnSearchEQPT_Total_Click(object sender, EventArgs e)
        {
            EQPT_TotalSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EQPT_DFT_Search();
        }


        // 완제품 선택 후 버튼 클릭시 BOM 조회
        private void EQPT_DFT_Search()
        {
            string EQPT_DFT_Query;
            if (selectedEQPTID != null)
            {
                // 위 제품 BOM 정보 조회 쿼리
                EQPT_DFT_Query = $@"SELECT EQPTID
                                           , COLLECTDAY
                                           , SUM(DECODE(ITM1CNT + ITM2CNT + ITM3CNT + ITM4CNT + ITM5CNT + ITM6CNT, 1, 0 , 0 , 1)) DEFECTCNT
                                           , SUM(1) CNT
                                           , ROUND(SUM(DECODE(ITM1CNT + ITM2CNT + ITM3CNT + ITM4CNT + ITM5CNT + ITM6CNT, 1, 0 , 0 , 1)) / SUM(1) * 100, 2) DEFECTRATE
                                       FROM 
                                   (
                                       SELECT LT.EQPTID
                                           , EQDC.EQPTITEMID
                                           , TO_CHAR(EQDC.EQPTITEMDTTM, 'YYYYMMDD') COLLECTDAY
                                           , DECODE( EQDC.EQPTITEMID, 'ITM001', L_ITM1, 'ITM002', L_ITM2, 'ITM003', L_ITM3, 'ITM004', L_ITM4, 'ITM005', L_ITM5, 'ITM006', L_ITM6)  LOWLEVEL
                                           , EQDC.EQPTITEMVALUE
                                           , DECODE( EQDC.EQPTITEMID, 'ITM001', H_ITM1, 'ITM002', H_ITM2, 'ITM003', H_ITM3, 'ITM004', H_ITM4, 'ITM005', H_ITM5, 'ITM006', H_ITM6)  HIGHLEVEL
                                           , CASE WHEN EQDC.EQPTITEMID = 'ITM001' AND T1.L_ITM1 <= EQDC.EQPTITEMVALUE 
                                                                                   AND EQDC.EQPTITEMVALUE <= T1.H_ITM1 THEN 1 ELSE 0 END ITM1CNT -- 정상범위 인지 체크
                                           , CASE WHEN EQDC.EQPTITEMID = 'ITM002' AND T1.L_ITM2 <= EQDC.EQPTITEMVALUE 
                                                                                   AND EQDC.EQPTITEMVALUE <= T1.H_ITM2 THEN 1 ELSE 0 END ITM2CNT -- 정상범위 인지 체크                        
                                           , CASE WHEN EQDC.EQPTITEMID = 'ITM003' AND T1.L_ITM3 <= EQDC.EQPTITEMVALUE 
                                                                                   AND EQDC.EQPTITEMVALUE <= T1.H_ITM3 THEN 1 ELSE 0 END ITM3CNT -- 정상범위 인지 체크                                                                             
                                           , CASE WHEN EQDC.EQPTITEMID = 'ITM004' AND T1.L_ITM4 <= EQDC.EQPTITEMVALUE 
                                                                                   AND EQDC.EQPTITEMVALUE <= T1.H_ITM4 THEN 1 ELSE 0 END ITM4CNT -- 정상범위 인지 체크
                                           , CASE WHEN EQDC.EQPTITEMID = 'ITM005' AND T1.L_ITM5 <= EQDC.EQPTITEMVALUE 
                                                                                   AND EQDC.EQPTITEMVALUE <= T1.H_ITM5 THEN 1 ELSE 0 END ITM5CNT -- 정상범위 인지 체크                                                                             
                                           , CASE WHEN EQDC.EQPTITEMID = 'ITM006' AND T1.L_ITM6 <= EQDC.EQPTITEMVALUE 
                                                                                   AND EQDC.EQPTITEMVALUE <= T1.H_ITM6 THEN 1 ELSE 0 END ITM6CNT -- 정상범위 인지 체크                                                                                                                                                                                                                                                                                               
                                       FROM EQPTDATACOLLECT EQDC
                                       INNER JOIN LOT       LT     ON EQDC.LOTID = LT.LOTID
                                       INNER JOIN (SELECT /*한달치 정상범위를 산출하는 쿼리*/
                                                           ROUND(AVG(ITM1) - AVG(ITM1) * 5/100 , 2) L_ITM1  --  - 5% 정상 범위
                                                           , ROUND(AVG(ITM1) + AVG(ITM1) * 5/100 , 2) H_ITM1  --  + 5% 정상 범위
                                                           , ROUND(AVG(ITM2) - AVG(ITM2) * 5/100 , 2) L_ITM2
                                                           , ROUND(AVG(ITM2) + AVG(ITM2) * 5/100 , 2) H_ITM2   
                                                           , ROUND(AVG(ITM3) - AVG(ITM3) * 5/100 , 2) L_ITM3
                                                           , ROUND(AVG(ITM3) + AVG(ITM3) * 5/100 , 2) H_ITM3    
                                                           , ROUND(AVG(ITM4) - AVG(ITM4) * 5/100 , 2) L_ITM4
                                                           , ROUND(AVG(ITM4) + AVG(ITM4) * 5/100 , 2) H_ITM4           
                                                           , ROUND(AVG(ITM5) - AVG(ITM5) * 5/100 , 2) L_ITM5
                                                           , ROUND(AVG(ITM5) + AVG(ITM5) * 5/100 , 2) H_ITM5           
                                                           , ROUND(AVG(ITM6) - AVG(ITM6) * 5/100 , 2) L_ITM6
                                                           , ROUND(AVG(ITM6) + AVG(ITM6) * 5/100 , 2) H_ITM6       
                                                       FROM 
                                                           (
                                                           SELECT DECODE(EQDC.EQPTITEMID, 'ITM001', EQDC.EQPTITEMVALUE) ITM1
                                                               , DECODE(EQDC.EQPTITEMID, 'ITM002', EQDC.EQPTITEMVALUE) ITM2
                                                               , DECODE(EQDC.EQPTITEMID, 'ITM003', EQDC.EQPTITEMVALUE) ITM3
                                                               , DECODE(EQDC.EQPTITEMID, 'ITM004', EQDC.EQPTITEMVALUE) ITM4
                                                               , DECODE(EQDC.EQPTITEMID, 'ITM005', EQDC.EQPTITEMVALUE) ITM5
                                                               , DECODE(EQDC.EQPTITEMID, 'ITM006', EQDC.EQPTITEMVALUE) ITM6
                                                           FROM EQPTDATACOLLECT EQDC
                                                               WHERE EQDC.EQPTITEMDTTM >= SYSDATE - 30 -- 한달치 범위를 조회
                                                           ) 
                                       )     T1    ON 1=1
                                       WHERE EQDC.EQPTITEMDTTM >= to_date('{dtpEQPTDFTStart.Value.Year}/{dtpEQPTDFTStart.Value.Month}/{dtpEQPTDFTStart.Value.Day}')  -- 조회조건 FROM
                                          AND EQDC.EQPTITEMDTTM <= to_date('{dtpEQPTDFTEnd.Value.Year}/{dtpEQPTDFTEnd.Value.Month}/{dtpEQPTDFTEnd.Value.Day}')  - 1 -- 조회조건 TO 
                                          AND LT.EQPTID = ':EQPTID_'
                                    )         
                                    GROUP BY EQPTID
                                           , COLLECTDAY
                                    ORDER BY EQPTID, DEFECTRATE DESC
                                    ";

                EQPT_DFT_Query = EQPT_DFT_Query.Replace(":EQPTID_", selectedEQPTID);
                DatabaseManager.DB_Inquiry(EQPT_DFT_Query, gvEQPT_DFT);
                string[] EQPT_DFT_HeaderName = new string[] { "공정코드", "날짜", "이상감지 횟수", "설비가동 횟수", "설비 이상률"};
                GridViewHeaderSetter(gvEQPT_DFT, EQPT_DFT_HeaderName, "true");
            }
        }

        private void GridViewHeaderSetter(DataGridView dataGridView, string[] header, string readOnly)
        {
            if (dataGridView.Rows.Count > 0)
            {
                if (readOnly == "true")
                {
                    for (int i = 0; i < header.Length; i++)
                    {
                        dataGridView.Columns[i].HeaderText = $"{header[i]}";
                        dataGridView.Columns[i].ReadOnly = true;
                        dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                else
                {
                    for (int i = 0; i < header.Length; i++)
                    {
                        dataGridView.Columns[i].HeaderText = $"{header[i]}";
                        dataGridView.Columns[i].ReadOnly = false;
                        dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                // 빈 레코드 표시 안함
                dataGridView.AllowUserToAddRows = false;
                // 헤더 위치 정렬(가운데)
                dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        // 콤보 박스  채우기
        private void LoadCombo(List<string> list, ComboBox comboBox)
        {
            if (list.Count >= 0)
            {
                foreach (string item in list)
                {
                    comboBox.Items.Add(item);
                }
            }
            else System.Windows.Forms.MessageBox.Show($"비어있는 리스트입니다.");
        }

        private void EquipmentStatus_Load(object sender, EventArgs e)
        {
            dtpEQPTDFTStart.Value = DateTime.Now.AddDays(-30);
            dtpEQPTDFTEnd.Value = DateTime.Now;

            LoadCombo(durationList, cbDuration);
            cbDuration.SelectedIndex = 0;

            EquipmentSearch();
            EQPT_TotalSearch();
        }
    }
}
