using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_FUI
{
    public partial class 생산일지 : Form
    {

        string woid = "";

        public static string Selected_lotid { get; set; }

        public 생산일지()
        {
            //this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
            InitializeComponent();
        }

        string[] WorkorderColumns = 
            {
                            "작업지시ID",
                            "제품코드",
                            "제품명",
                            "계획수량",
                            "생산수량",
                            "불량수량",
                            "작업하달일",
                            "작업시작일",
                            "작업종료일",
                            "작업상태"
        };

        string[] DEF_Lot_Colums =
        {
                            "LOTID",
                            "시작시간",
                            "종료시간",
                            "LOT 수량",
                            "불량수량",
                            "불량여부"
    
        };

        private void btn_Main_Click(object sender, EventArgs e)   //메인화면으로 돌아가기 
        {

            this.Close();
            WO_Main WO_Main = new WO_Main();
            WO_Main.Show();
        }


        private void 생산일지_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, 11, 1);
            woid = WO_Main.Selected_woid;
            WO_Grid.ColumnHeadersHeight = 80;
            WO_Grid.RowTemplate.Height = 70;
            DEF_LOT_Grid.ColumnHeadersHeight = 80;
            DEF_LOT_Grid.RowTemplate.Height = 70;
            FilterData();
            DEF_LOT_Grid.CellFormatting += DEF_LOT_Grid_CellFormatting;
        }

        private void LoadData(string sql, string[] header, DataGridView dataGridView)           // LoadData 데이터 불러오기 
        {

            dataGridView.DataSource = null; // 이전 데이터 지우기
            dataGridView.Rows.Clear();

            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(rdr);
                            dataGridView.DataSource = dataTable;

                            for (int i = 0; i < header.Length && i < dataGridView.Columns.Count; i++)
                            {
                                dataGridView.Columns[i].HeaderText = header[i];
                            }  
                        }
                    }    
                }
            }
        }
    

        private void DEF_LOT_Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          
        }



        private void FilterData()
        {
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;
            date2 = date2.AddDays(1);

            // 필터링된 SQL 쿼리 생성
            string sql = $@"
                    SELECT 
                        W.WOID,
                        W.PRODID,
                        P.PRODNAME,
                        W.PLANQTY,
                        NVL(SUM((SELECT NVL(SUM(LT.LOTQTY), 0) FROM LOT LT WHERE W.WOID = LT.WOID)), 0) AS SUM_LOTQTY,
                        NVL(SUM((SELECT NVL(SUM(DL.DEFECT_QTY), 0) FROM DEFECTLOT DL WHERE L.LOTID = DL.DEFECT_LOTID)), 0) AS SUM_DEFECT_QTY,
                        W.WOSTDTTM,
                        W.PLANDTTM,
                        W.WOEDDTTM,
                        CASE W.WOSTAT 
                            WHEN 'P' THEN '진행중'
                            WHEN 'S' THEN '중지'
                            WHEN 'E' THEN '완료'
                            WHEN 'D' THEN '삭제'
                        END AS WOSTAT 
                    FROM 
                        WORKORDER W 
                    LEFT JOIN 
                        LOT L ON W.WOID = L.WOID 
                    LEFT JOIN 
                        DEFECTLOT DL ON L.LOTID = DL.DEFECT_LOTID 
                    LEFT JOIN 
                        PRODUCT P ON W.PRODID = P.PRODID
                    WHERE 
                        W.PLANDTTM >= TO_DATE('{date1:yyyy-MM-dd}', 'YYYY-MM-DD') AND 
                        W.PLANDTTM < TO_DATE('{date2:yyyy-MM-dd}', 'YYYY-MM-DD')
                    GROUP BY 
                        W.WOID,
                        W.PRODID,
                        P.PRODNAME,
                        W.PLANQTY,
                        W.WOSTDTTM,
                        W.PLANDTTM,
                        W.WOEDDTTM,
                        W.WOSTAT";

            // 필터링된 데이터 로드
            LoadData(sql, WorkorderColumns, WO_Grid);
            
        }
        
        private void Search_WO_Grid_Click(object sender, EventArgs e)   //조회버튼 누를 시 
        {
            FilterData();
        }

        private void WO_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selectedColumnName = WO_Grid.Columns["WOID"].Name;

            if (selectedColumnName == "WOID")
            {
                string sql = $"SELECT L.LOTID, " +
                             $" \r\n L.LOTSTDTTM, " +
                             $" \r\n L.LOTEDDTTM, " +
                             $" \r\n L.LOTQTY, " +
                             $" \r\n DL.DEFECT_QTY, " +
                             $" \r\n CASE WHEN DL.DEFECT_QTY > 0 THEN 'Y' ELSE 'N' END AS DEFECTIVE " +
                             $" \r\n FROM LOT L " +
                             $" \r\n LEFT JOIN DEFECTLOT DL ON L.LOTID = DL.DEFECT_LOTID " +
                             $" \r\n WHERE L.LOTEDDTTM IS NOT NULL AND WOID = '{WO_Grid.CurrentRow.Cells["WOID"].Value.ToString()}' " +
                             $" \r\n ORDER BY DEFECTIVE DESC, DL.DEFECT_DTTM DESC";

                LoadData(sql, DEF_Lot_Colums, DEF_LOT_Grid);
                
                // 예시: 해당 열의 정보를 메시지 박스로 표시
                //MessageBox.Show($"You clicked WOID");
            }
        }

        private void DEF_LOT_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DEF_LOT_Grid.Columns["DEFECTIVE"].Index && e.Value != null)
            {
                string defectiveValue = e.Value.ToString();

                // 값이 'Y'인지 확인하고 배경 색상을 빨간색으로 설정
                if (defectiveValue.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White; // 선택 사항: 텍스트 색상을 더 잘 보이게 하려면 흰색으로 설정

                    // 선택된 셀의 색상 설정
                    if (DEF_LOT_Grid.SelectedCells.Contains(DEF_LOT_Grid.Rows[e.RowIndex].Cells[e.ColumnIndex]))
                    {
                        e.CellStyle.SelectionBackColor = Color.Red; // 선택된 경우 배경 색상을 빨간색으로 설정
                        e.CellStyle.SelectionForeColor = Color.White; // 선택된 경우 텍스트 색상을 흰색으로 설정
                    }
                }
            }
        }

    }
}
