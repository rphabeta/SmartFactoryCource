using Oracle.ManagedDataAccess.Client;
using Pharmaceutical_MES.Defect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pharmaceutical_MES.DefectStatus
{
    public partial class Defect_Status : Form
    {
        public Defect_Status()
        {
            InitializeComponent();
        }

        private void DefectStatus_Load(object sender, EventArgs e)
        {
   
            
            // 콤보박스 채움
            LoadCombo(productStats, cbPRODSTATS);
            LoadCombo(groupOption, cbGroupOption);
            cbPRODSTATS.SelectedIndex = 0;
            cbGroupOption.SelectedIndex = 0;

            DataSearch();
            
        }

        //  구분1 (1 : 양품 , 2 : 불량, 3 불량율, 콤보 박스로 넣으시면 될듯)
        List<string> productStats = new List<string>()
        {
            "양품",
            "불량",
            "불량율"
        };

        // 구분2 (A : 설비별 집계, B: 작업자별 집계, C: 제품코드별 집계)
        List<string> groupOption = new List<string>()
        {
            "설비별",
            "작업자별",
            "제품코드별"
        };

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



        // 설비별,작업자별, 제품코드별 -> 일별 양품/불량양, 불량율 조회
        
        private void DataSearch()
        {
            string DBdefect = $@"SELECT * 
                                 FROM 
                                     (
                                     SELECT DECODE( ':productStats_' 
                                                     , '양품' 
                                                     , SUM(LT.LOTQTY)
                                                     , '불량'
                                                     , SUM(DL.DEFECT_QTY)
                                                     , '불량율'
                                                     , ROUND(SUM(DL.DEFECT_QTY) / ( SUM(LT.LOTQTY)  + NVL(SUM(DL.DEFECT_QTY), 0)) * 100, 2)
                                                     ) QTY
                                             , NVL(TO_CHAR(LT.LOTCRDTTM, 'DD'), 0) DD
                                             , DECODE(':groupOption_' 
                                                 , '설비별', LT.EQPTID
                                                 , '작업자별', LT.WORKERID
                                                 , '제품코드별', WO.PRODID) CODE
                                         FROM LOT                LT
                                         LEFT JOIN DEFECTLOT     DL   ON LT.LOTID = DL.DEFECT_LOTID
                                         INNER JOIN WORKORDER     WO   ON LT.WOID = WO.WOID
                                         WHERE LT.LOTCRDTTM >= SYSDATE - 30 -- 조회기간 from
                                         AND LT.LOTCRDTTM <= SYSDATE  --  조회기간 to
                                         GROUP BY TO_CHAR(LT.LOTCRDTTM, 'DD')
                                             , DECODE(':groupOption_' 
                                                     , '설비별', LT.EQPTID
                                                     , '작업자별', LT.WORKERID
                                                     , '제품코드별', WO.PRODID)
                                     )
                                 PIVOT ( 
                                         SUM(QTY) FOR DD IN ('01' AS D1, '02' AS D2, '03' AS D3, '04' AS D4, '05' AS D5, '06' AS D6, '07' AS D7, '08' AS D8, '09' AS D9, '10' AS D10
                                                             , '11' AS D11, '12' AS D12, '13' AS D13, '14' AS D14, '15' AS D15, '16' AS D16, '17' AS D17, '18' AS D18, '19' AS D19, '20' AS D20
                                                             , '21' AS D21, '22' AS D22, '23' AS D23, '24' AS D24, '25' AS D25, '26' AS D26, '27' AS D27, '28' AS D28, '29' AS D29, '30' AS D30, '31' AS D31
                                                             ) 
                                     ) ";

            if (!string.IsNullOrEmpty(cbPRODSTATS.Text))
            {
                string prodStats = cbPRODSTATS.Text;
                DBdefect = DBdefect.Replace(":productStats_", prodStats);
            }
            if (!string.IsNullOrEmpty(cbGroupOption.Text))
            {
                string GroupOption = cbGroupOption.Text;
                DBdefect = DBdefect.Replace(":groupOption_", GroupOption);
            }

            
            DatabaseManager.DB_Inquiry(DBdefect, gvDefect);
            gvDefect.Columns["CODE"].HeaderText = "분류코드";
            DataTable dataTable = new DataTable();
            DatabaseManager.DB_InquiryForChart(DBdefect, dataTable);


            InitializeChart(dataTable);

            if (gvDefect.Rows.Count > 0)
            {
                for (int i = 0; i < gvDefect.Columns.Count; i++)
                {
                    gvDefect.Columns[i].ReadOnly = true;
                    gvDefect.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                gvDefect.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                gvDefect.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void InitializeChart(DataTable dataTable)
        {
            // Chart 초기화
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea("Default"));

            // DataTable의 로우를 X축 값으로 추가
            foreach (DataRow row in dataTable.Rows)
            {
                string seriesName = row["CODE"].ToString();

                // "CODE" 칼럼을 제외한 각 칼럼의 값을 시리즈에 추가
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.ColumnName != "CODE") // "CODE" 칼럼은 X축에 추가하지 않음
                    {
                        // 시리즈가 없으면 추가
                        if (!ChartSeriesExists(chart1, seriesName))
                        {
                            Series newSeries = new Series(seriesName);
                            newSeries.ChartType = SeriesChartType.Spline;
                            chart1.Series.Add(newSeries);
                        }

                        // 해당 로우의 값을 가져오고, 값이 null이 아니라면 double로 변환
                        object columnValue = row[column.ColumnName];
                        double value = (columnValue != DBNull.Value) ? Convert.ToDouble(columnValue) : double.NaN;

                        chart1.Series[seriesName].Points.AddXY(column.ColumnName, value);
                    }
                }
            }
        }

        // 시리즈가 존재하는지 확인하는 도우미 메서드
        private bool ChartSeriesExists(Chart chart, string seriesName)
        {
            foreach (Series series in chart.Series)
            {
                if (series.Name == seriesName)
                {
                    return true;
                }
            }
            return false;
        }


        // 결함 조회
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSearch();
        }
    }
}
