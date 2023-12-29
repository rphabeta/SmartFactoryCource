using LiveCharts.Wpf;
using LiveCharts;
using System;
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
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using System.Data.Odbc;
using LiveCharts.Wpf.Charts.Base;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using System.Windows;


//DChartTDayDefect
namespace Pharmaceutical_MES.MainPage
{
    public partial class MainPage : Form
    {

        public DataTable data_Table;
        private bool isUserIDSet = false;

        public MainPage()
        {
            InitializeComponent();

            // 주기 콤보 박스 값 설정
            LoadCombo(cbPeriodList, cbProduction_Period);
            LoadCombo(cbPROCList, cbDefect);


            // 초기세팅
            cbProduction_Period.SelectedIndex = 0;
            cbDefect.SelectedIndex = 0;

            // dateTimePicker 시작지점 설정
            dtpProductionStart.Value = DateTime.Today.AddDays(-7);
        


            DrawProductionChart();
         
            Today();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            

            // 실시간 추적 타이머 설정
            Timer t = new Timer();
            t.Tick += new EventHandler(timer1_Tick);
            t.Start();

        }


        // 콤보박스 아이템 목록: 일간, 주간, 월간
        List<string> cbPeriodList = new List<string>()
        {
            "일별"
            , "월별"
            , "연별"
        };

        List<string> cbPROCList = new List<string>()
        {
            "과립",
            "타정",
            "포장"
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

        // 작업자 아이디 설정
        public void SetUserID(string userID)                // 작업자 ID 가져오기 
        {
            if (!isUserIDSet)
            {
                Console.WriteLine("SetUserID method called with userID: " + userID);
                //txtUser.Text = userID;         // 텍스트 박스 2에 로그인 한 유저 아이디 작성 
                isUserIDSet = true;
            }
        }

        // 오류 TOP3 라벨 지정
        public void TOP3DefectSearch()
        {
            string SumDefect = string.Empty;


            
            SumDefect = $@"SELECT *
                            FROM 
                                (
                                        SELECT SUM(DL.DEFECT_QTY) DEFECT_QTY 
                                            , DT.DEFECTID
                                        FROM DEFECT DT
                                        INNER JOIN DEFECTLOT DL ON (
                                            DT.DEFECTID = DL.DEFECTID
                                            AND DL.DEFECT_DTTM >= TO_DATE('{dtpProductionStart.Value.Year}/{dtpProductionStart.Value.Month}/{dtpProductionStart.Value.Day}')
                                            AND DL.DEFECT_DTTM <= TO_DATE('{dtpProductionEnd.Value.Year}/{dtpProductionEnd.Value.Month}/{dtpProductionEnd.Value.Day}') + 1
                                        )
                                        GROUP BY DT.DEFECTID
                                        ORDER BY DEFECT_QTY DESC
                                ) 
                            WHERE ROWNUM <= 3";


            DataTable SumDefectTable = DatabaseManager.DB_Inquiry(SumDefect);

            if(SumDefectTable.Rows.Count >= 3)
            {
                lbDFT_TOP1.Text = SumDefectTable.Rows[0]["DEFECT_QTY"].ToString() + " 개";
                lbDFT_TOP2.Text = SumDefectTable.Rows[1]["DEFECT_QTY"].ToString() + " 개";
                lbDFT_TOP3.Text = SumDefectTable.Rows[2]["DEFECT_QTY"].ToString() + " 개";

            }
            else if(SumDefectTable.Rows.Count == 2)
            {
                lbDFT_TOP1.Text = SumDefectTable.Rows[0]["DEFECT_QTY"].ToString();
                lbDFT_TOP2.Text = SumDefectTable.Rows[1]["DEFECT_QTY"].ToString();
                lbDFT_TOP3.Text = "0 개";
            }
            else if (SumDefectTable.Rows.Count == 1)
            {
                lbDFT_TOP1.Text = SumDefectTable.Rows[0]["DEFECT_QTY"].ToString();
                lbDFT_TOP2.Text = "0 개";
                lbDFT_TOP3.Text = "0 개";
            }
            else
            {
                lbDFT_TOP1.Text = "0 개";
                lbDFT_TOP2.Text = "0 개";
                lbDFT_TOP3.Text = "0 개";
            }
        }


        //생산 그래프
        public void DrawProductionChart()
        {
            string MAKE_CHART = string.Empty;

            // 일별
            if (cbProduction_Period.SelectedItem.ToString() == "일별")
            {
                MAKE_CHART = $@"SELECT to_char(LT.LOTSTDTTM, 'YYYY-MM-DD')                                                                    불량발생시간
                                        ,NVL(SUM(LT.LOTQTY), 0)                                                                               LOT수량
                                        ,NVL(SUM(DL.DEFECT_QTY), 0)                                                                           불량LOT수량
                                        ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) / NVL(SUM(LT.LOTQTY), 0), 3))  불량율
                                FROM LOT LT
                                LEFT JOIN DEFECTLOT DL
                                    ON(LT.LOTID = DL.DEFECT_LOTID)
                                WHERE LT.LOTSTDTTM >= to_date('{dtpProductionStart.Value.Year}/{dtpProductionStart.Value.Month}/{dtpProductionStart.Value.Day}') 
                                    AND LT.LOTSTDTTM <= to_date('{dtpProductionEnd.Value.Year}/{dtpProductionEnd.Value.Month}/{dtpProductionEnd.Value.Day}') + 1
                                GROUP BY TO_CHAR(LT.LOTSTDTTM, 'YYYY-MM-DD')
                                ORDER BY TO_CHAR(LT.LOTSTDTTM, 'YYYY-MM-DD')";
            }


            // 월별
            else if (cbProduction_Period.SelectedItem.ToString() == "월별")
            {
                MAKE_CHART = $@"SELECT to_char(LT.LOTSTDTTM, 'YYYY-MM')                                                                        불량발생시간
                                    ,NVL(SUM(LT.LOTQTY), 0)                                                                                    LOT수량
                                    ,NVL(SUM(DL.DEFECT_QTY), 0)                                                                                불량LOT수량
                                    ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) / NVL(SUM(LT.LOTQTY), 0), 3))       불량율
                                FROM LOT LT
                                LEFT JOIN DEFECTLOT DL
                                    ON(LT.LOTID = DL.DEFECT_LOTID)
                                WHERE LT.LOTSTDTTM >= ('{dtpProductionStart.Value.Year}/{dtpProductionStart.Value.Month}/{dtpProductionStart.Value.Day}')
                                    AND LT.LOTSTDTTM <= to_date('{dtpProductionEnd.Value.Year}/{dtpProductionEnd.Value.Month}/{dtpProductionEnd.Value.Day}') + 1
                                GROUP BY TO_CHAR(LT.LOTSTDTTM, 'YYYY-MM')
                                ORDER BY to_char(LT.LOTSTDTTM, 'YYYY-MM')";
            }

            // 연별
            else
            {
                MAKE_CHART = $@"SELECT to_char(LT.LOTSTDTTM, 'YYYY')                                                                           불량발생시간
                                    ,NVL(SUM(LT.LOTQTY), 0)                                                                                    LOT수량
                                    ,NVL(SUM(DL.DEFECT_QTY), 0)                                                                                불량LOT수량
                                    ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) / NVL(SUM(LT.LOTQTY), 0), 3))       불량율
                                FROM LOT LT
                                LEFT JOIN DEFECTLOT DL
                                    ON(LT.LOTID = DL.DEFECT_LOTID)
                                WHERE LT.LOTSTDTTM >= ('{dtpProductionStart.Value.Year}/{dtpProductionStart.Value.Month}/{dtpProductionStart.Value.Day}')
                                    AND LT.LOTSTDTTM <= to_date('{dtpProductionEnd.Value.Year}/{dtpProductionEnd.Value.Month}/{dtpProductionEnd.Value.Day}') + 1
                                GROUP BY TO_CHAR(LT.LOTSTDTTM, 'YYYY')
                                ORDER BY to_char(LT.LOTSTDTTM, 'YYYY')";
            }


            DataTable make_chart = DatabaseManager.DB_Inquiry(MAKE_CHART);



            string[] Date = new string[make_chart.Rows.Count];
            double[] LOT_QTY = new double[make_chart.Rows.Count];
            double[] DEFET_QTY = new double[make_chart.Rows.Count];
            double[] DEFECT_PER = new double[make_chart.Rows.Count];

            double Sum_LOT_QTY = 0.0;
            double Sum_DEFET_QTY = 0.0;
            double Sum_DEFECT_PER = 0.0;

            for (int i = 0; i < make_chart.Rows.Count; i++)
            {
                Date[i] = make_chart.Rows[i]["불량발생시간"].ToString();
                LOT_QTY[i] = Convert.ToDouble(make_chart.Rows[i]["LOT수량"].ToString());
                DEFET_QTY[i] = Convert.ToDouble(make_chart.Rows[i]["불량LOT수량"].ToString());
                DEFECT_PER[i] = Convert.ToDouble(make_chart.Rows[i]["불량율"].ToString());
                Sum_LOT_QTY = LOT_QTY.Sum();
                Sum_DEFET_QTY = DEFET_QTY.Sum();
                Sum_DEFECT_PER = DEFECT_PER.Sum();
            }
            Sum_DEFECT_PER = Math.Round((Sum_DEFET_QTY / Sum_LOT_QTY) * 100, 1);

            lbTotalLOT.Text = Sum_LOT_QTY + "개";
            lbTotalDefect.Text = Sum_DEFET_QTY + "개";
            lbPerDefect.Text = Sum_DEFECT_PER + "%";

            // PC003_PER_DEFTLOT
            //----------- 일별 월별 연별 도넛 차트 --------------

            // 차트 옵션 설정
            DChartTDayDefect.Series.Clear();
            DChartTDayDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            DChartTDayDefect.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // 데이터 추가 및 색깔 설정 
            Series series_TD = new Series("DChartTDayDefect_Series");
            series_TD.ChartType = SeriesChartType.Doughnut;

            DataPoint dataPoint1_TD = new DataPoint();
            dataPoint1_TD.YValues = new double[] { Sum_LOT_QTY };
            dataPoint1_TD.Color = System.Drawing.Color.FromArgb(255, 62, 73, 104); // 총 LOT 수량: 잿빛 남색 (62, 73, 104)

            DataPoint dataPoint2_TD = new DataPoint();
            dataPoint2_TD.YValues = new double[] { Sum_DEFET_QTY };
            dataPoint2_TD.Color = System.Drawing.Color.FromArgb(255, 73, 163, 156); // 총 불량 수량: 초록 (73, 163, 156)


            // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
            series_TD.Points.Add(dataPoint1_TD);
            series_TD.Points.Add(dataPoint2_TD);


            // 차트에 시리즈 추가
            DChartTDayDefect.Series.Add(series_TD);

            InitializeChart(make_chart, chartProduction_1, "불량율");

        }



        // 공정별 금일 불량 정보
        public void Today()
        {
            string SYS_INFO = $@"SELECT LT.EQPTID                                                                                         
                                        ,NVL(SUM(LT.LOTQTY), 0)                                                     LOT수량                                                                    
                                        ,NVL(SUM(DL.DEFECT_QTY), 0)                                                 불량LOT수량                                                            
                                        ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) 
                                                / NVL(SUM(LT.LOTQTY), 0), 3)*100)                                   불량율
                                FROM LOT LT                                                                                                
                                LEFT JOIN DEFECTLOT DL                                                                                     
                                ON(LT.LOTID = DL.DEFECT_LOTID)                                                                           
                                WHERE LT.LOTSTDTTM >= TO_DATE(SYSDATE) - 6                                                                     
                                    AND LT.LOTSTDTTM <= TO_DATE(SYSDATE) + 1                                                              
                                    AND LT.EQPTID LIKE '%GR%'                                                   -- 과립기                                                                 
                                GROUP BY LT.EQPTID                                                              
                                ORDER BY EQPTID";


            string SYS_INFO2 = $@"SELECT LT.EQPTID                                                                                         
                                        ,NVL(SUM(LT.LOTQTY), 0)                                                     LOT수량                                                                    
                                        ,NVL(SUM(DL.DEFECT_QTY), 0)                                                 불량LOT수량                                                            
                                        ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) 
                                                / NVL(SUM(LT.LOTQTY), 0), 3)*100)                                   불량율
                                  FROM LOT LT                                                                                                
                                  LEFT JOIN DEFECTLOT DL                                                                                     
                                  ON(LT.LOTID = DL.DEFECT_LOTID)                                                                           
                                  WHERE LT.LOTSTDTTM >= TO_DATE(SYSDATE) - 6                                                                     
                                      AND LT.LOTSTDTTM <= TO_DATE(SYSDATE) + 1                                                              
                                      AND LT.EQPTID LIKE '%CP%'                                                   -- 과립기                                                                 
                                  GROUP BY LT.EQPTID                                                              
                                  ORDER BY EQPTID";

            string SYS_INFO3 = $@"SELECT LT.EQPTID                                                                                         
                                        ,NVL(SUM(LT.LOTQTY), 0)                                                     LOT수량                                                                    
                                        ,NVL(SUM(DL.DEFECT_QTY), 0)                                                 불량LOT수량                                                            
                                        ,DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) 
                                                / NVL(SUM(LT.LOTQTY), 0), 3)*100)                                   불량율
                                   FROM LOT LT                                                                                                
                                   LEFT JOIN DEFECTLOT DL                                                                                     
                                   ON(LT.LOTID = DL.DEFECT_LOTID)                                                                           
                                   WHERE LT.LOTSTDTTM >= TO_DATE(SYSDATE) - 6                                                                     
                                       AND LT.LOTSTDTTM <= TO_DATE(SYSDATE) + 1                                                              
                                       AND LT.EQPTID LIKE '%BX%'                                                   -- 과립기                                                                 
                                   GROUP BY LT.EQPTID                                                              
                                   ORDER BY EQPTID";




            DataTable sys_infomation = DatabaseManager.DB_Inquiry(SYS_INFO);
            DataTable sys2_infomation = DatabaseManager.DB_Inquiry(SYS_INFO2);
            DataTable sys3_infomation = DatabaseManager.DB_Inquiry(SYS_INFO3);


            double PC001_LOT = 0;
            double PC002_LOT = 0; 
            double PC003_LOT = 0;
            double PC001_DEFTLOT = 0;
            double PC002_DEFTLOT = 0;
            double PC003_DEFTLOT = 0;
            double PC001_PER_DEFTLOT = 0;
            double PC002_PER_DEFTLOT = 0;
            double PC003_PER_DEFTLOT = 0;


            if (sys_infomation.Rows.Count > 0)
            {
                lbSYS_PROD_1.Text = sys_infomation.Rows[0]["LOT수량"].ToString() + " 개";
                lbSYS_Defect_1.Text = sys_infomation.Rows[0]["불량LOT수량"].ToString() + " 개";
                lbSYS_DEFECTPER_1.Text = sys_infomation.Rows[0]["불량율"].ToString() + "%";
                // donut 차트를 위한 값
                PC001_LOT = double.Parse(sys_infomation.Rows[0]["LOT수량"].ToString());
                PC001_DEFTLOT = double.Parse(sys_infomation.Rows[0]["불량LOT수량"].ToString());
                PC001_PER_DEFTLOT = double.Parse(sys_infomation.Rows[0]["불량율"].ToString());
            }
            if (sys2_infomation.Rows.Count > 0)
            {
                lbSYS_PROD_2.Text = sys2_infomation.Rows[0]["LOT수량"].ToString() + " 개";
                lbSYS_Defect_2.Text = sys2_infomation.Rows[0]["불량LOT수량"].ToString() + " 개";
                lbSYS_DEFECTPER_2.Text = sys2_infomation.Rows[0]["불량율"].ToString() + "%";
                // donut 차트를 위한 값
                PC002_LOT = double.Parse(sys2_infomation.Rows[0]["LOT수량"].ToString());
                PC002_DEFTLOT = double.Parse(sys2_infomation.Rows[0]["불량LOT수량"].ToString());
                PC002_PER_DEFTLOT = double.Parse(sys2_infomation.Rows[0]["불량율"].ToString());
            }
            if (sys3_infomation.Rows.Count > 0)
            {
                lbSYS_PROD_3.Text = sys3_infomation.Rows[0]["LOT수량"].ToString() + " 개";
                lbSYS_Defect_3.Text = sys3_infomation.Rows[0]["불량LOT수량"].ToString() + " 개";
                lbSYS_DEFECTPER_3.Text = sys3_infomation.Rows[0]["불량율"].ToString() + "%";
                // donut 차트를 위한 값
                PC003_LOT = double.Parse(sys3_infomation.Rows[0]["LOT수량"].ToString());
                PC003_DEFTLOT = double.Parse(sys3_infomation.Rows[0]["불량LOT수량"].ToString());
                PC003_PER_DEFTLOT = double.Parse(sys3_infomation.Rows[0]["불량율"].ToString());
            }

            // 금일 생산수량 Donut 차트

            // 차트 옵션 설정
            donut_SYS_Production.Series.Clear();
            donut_SYS_Production.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            donut_SYS_Production.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // 데이터 추가 및 색깔 설정 
            Series series = new Series("PROD_LOT_Series");
            series.ChartType = SeriesChartType.Doughnut;

            DataPoint dataPoint1 = new DataPoint();
            dataPoint1.YValues = new double[] { PC001_LOT };
            dataPoint1.Color = System.Drawing.Color.FromArgb(255, 62, 73, 104); // 과립: 잿빛 남색 (62, 73, 104)

            DataPoint dataPoint2 = new DataPoint();
            dataPoint2.YValues = new double[] { PC002_LOT };
            dataPoint2.Color = System.Drawing.Color.FromArgb(255, 73, 163, 156); // 타정: 초록 (73, 163, 156)

            DataPoint dataPoint3 = new DataPoint();
            dataPoint3.YValues = new double[] { PC003_LOT };
            dataPoint3.Color = System.Drawing.Color.FromArgb(255, 248, 204, 124); // 포장: 노랑 (248, 204, 124)


            // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
            series.Points.Add(dataPoint1);
            series.Points.Add(dataPoint2);
            series.Points.Add(dataPoint3);

            // 차트에 시리즈 추가
            donut_SYS_Production.Series.Add(series);

            //---------------------------------------------------------------------------------------------------------

            // 금일 불량 LOT수량 Donut 차트
            donut_SYS_DEFTLOT.Series.Clear();
            donut_SYS_DEFTLOT.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            donut_SYS_DEFTLOT.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // 데이터 추가 및 색깔 설정 
            Series series_DF = new Series("PROD_DEFT_LOT_Series");
            series_DF.ChartType = SeriesChartType.Doughnut;

            DataPoint dataPoint1_DF = new DataPoint();
            dataPoint1_DF.YValues = new double[] { PC001_DEFTLOT };
            dataPoint1_DF.Color = System.Drawing.Color.FromArgb(255, 62, 73, 104); // 과립: 잿빛 남색 (62, 73, 104)

            DataPoint dataPoint2_DF = new DataPoint();
            dataPoint2_DF.YValues = new double[] { PC002_DEFTLOT };
            dataPoint2_DF.Color = System.Drawing.Color.FromArgb(255, 73, 163, 156); // 타정: 초록 (73, 163, 156)

            DataPoint dataPoint3_DF = new DataPoint();
            dataPoint3_DF.YValues = new double[] { PC003_DEFTLOT };
            dataPoint3_DF.Color = System.Drawing.Color.FromArgb(255, 248, 204, 124); // 포장: 노랑 (248, 204, 124)


            // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
            series_DF.Points.Add(dataPoint1_DF);
            series_DF.Points.Add(dataPoint2_DF);
            series_DF.Points.Add(dataPoint3_DF);

            // 차트에 시리즈 추가
            donut_SYS_DEFTLOT.Series.Add(series_DF);


            //-------------------------------------------------
            // 불량율 시각화 
            pbPC001_DEFLOT.Value = Convert.ToInt32(Math.Round(PC001_PER_DEFTLOT)) * 10;
            pbPC002_DEFLOT.Value = Convert.ToInt32(Math.Round(PC002_PER_DEFTLOT)) * 10;
            pbPC003_DEFLOT.Value = Convert.ToInt32(Math.Round(PC003_PER_DEFTLOT)) * 10;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //현재 시간 출력
            DateTime dt = DateTime.Now;
            string datePart = dt.ToString("HH:mm:ss");
            lbSYS_Time.Text = datePart;

            //Today();
        }

        //공정별 불량 내역 조회
        private void SearchMakeQty()
        {
            string DEFECT_CHART = $@"SELECT
                                     to_char(LT.LOTSTDTTM, 'yyyy/mm/dd')                                        불량발생시간
                                    ,NVL(SUM(LT.LOTQTY), 0)                                                     수량
                                    ,NVL(SUM(DL.DEFECT_QTY), 0)                                                 불량LOT수량
                                    , DECODE(NVL(SUM(LT.LOTQTY), 0), 0, 0, TRUNC(NVL(SUM(DL.DEFECT_QTY), 0) 
                                                / NVL(SUM(LT.LOTQTY), 0), 3) * 100)                             불량율 
                                    FROM                   LOT LT 
                                    INNER JOIN  WORKORDER   WO 
                                        ON LT.WOID = WO.WOID 
                                    LEFT  JOIN  DEFECTLOT   DL 
                                        ON LT.LOTID = DL.DEFECT_LOTID 
                                    WHERE LT.LOTSTDTTM >= '{dtpProductionStart.Value.Year}/{dtpProductionStart.Value.Month}/{dtpProductionStart.Value.Day}' 
                                    AND LT.LOTSTDTTM <= to_date('{dtpProductionEnd.Value.Year}/{dtpProductionEnd.Value.Month}/{dtpProductionEnd.Value.Day}')+1 ";


            if (cbDefect.SelectedItem.ToString() == "과립")
            {
                DEFECT_CHART += $" AND WO.PROCID = 'PC001' \n";
            }
            if (cbDefect.SelectedItem.ToString() == "타정")
            {
                DEFECT_CHART += $" AND WO.PROCID = 'PC002' \n";
            }
            if (cbDefect.SelectedItem.ToString() == "포장")
            {
                DEFECT_CHART += $" AND WO.PROCID = 'PC003' \n";
            }


            DEFECT_CHART += $"GROUP BY to_char(LT.LOTSTDTTM, 'yyyy/mm/dd') \n"
                                    + $"HAVING to_char(LT.LOTSTDTTM, 'yyyy/mm/dd') != 'NULL' \n"
                                    + $"ORDER BY to_char(LT.LOTSTDTTM, 'yyyy/mm/dd')";

            DatabaseManager.DB_Inquiry(DEFECT_CHART, gvDEFECT);
            data_Table = DatabaseManager.DB_Inquiry(DEFECT_CHART);

            string[] HeaderName = new string[] { "일자", "LOT수량", "불량 LOT수량", "불량율" };

            if (gvDEFECT.Rows.Count > 0)
            {
                for (int i = 0; i < HeaderName.Length; i++)
                {
                    gvDEFECT.Columns[i].HeaderText = $"{HeaderName[i]}";
                    gvDEFECT.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                gvDEFECT.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                gvDEFECT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (data_Table.Rows.Count > 0)
            {
                double[] LOT_QTY = new double[data_Table.Rows.Count];
                double[] DEFECT_QTY = new double[data_Table.Rows.Count];
                double[] DEFECT_PER = new double[data_Table.Rows.Count];
                double Sum_LOT_QTY = 0.0;
                double Sum_DEFECT_QTY = 0.0;
                //double Sum_DEFECT_PER = 0.0;
                for (int i = 0; i < data_Table.Rows.Count; i++)
                {
                    LOT_QTY[i] = Convert.ToDouble(data_Table.Rows[i][1].ToString());
                    DEFECT_QTY[i] = Convert.ToDouble(data_Table.Rows[i][2].ToString());
                    DEFECT_PER[i] = Convert.ToDouble(data_Table.Rows[i][3].ToString()) * 100;
                    Sum_LOT_QTY = LOT_QTY.Sum();
                    Sum_DEFECT_QTY = DEFECT_QTY.Sum();
                    //Sum_DEFECT_PER = DEFECT_PER.Sum();
                }
                //Sum_DEFECT_PER = Math.Round((Sum_DEFECT_QTY/ Sum_LOT_QTY) * 100, 1);

                //조회해서 그리드에 넣어준다
                Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            }

        }



        //불량내역 조회함수
        private void SearchDefectQty()
        {
            {
                string DEFECT_SELECT = $@"SELECT DEFECT_DTTM         발생일자
                                                 , SUM(DF001)        이물질 
                                                 , SUM(DF002)        깨짐
                                                 , SUM(DF003)        형상 
                                                 , SUM(DF004)        혼배합
                                                 , SUM(DF005)        고중량
                                                 , SUM(DF006)        저중량
                                           FROM 
                                                 (SELECT 
                                                          TO_CHAR(DL.DEFECT_DTTM, 'YYYY/MM/DD') DEFECT_DTTM 
                                                         , DECODE(DT.DEFECTID, 'DF001', NVL(DL.DEFECT_QTY, 0), 0) DF001 
                                                         , DECODE(DT.DEFECTID, 'DF002', NVL(DL.DEFECT_QTY, 0), 0) DF002 
                                                         , DECODE(DT.DEFECTID, 'DF003', NVL(DL.DEFECT_QTY, 0), 0) DF003 
                                                         , DECODE(DT.DEFECTID, 'DF004', NVL(DL.DEFECT_QTY, 0), 0) DF004 
                                                         , DECODE(DT.DEFECTID, 'DF005', NVL(DL.DEFECT_QTY, 0), 0) DF005
                                                         , DECODE(DT.DEFECTID, 'DF006', NVL(DL.DEFECT_QTY, 0), 0) DF006 
                                                  FROM       DEFECT    DT 
                                                  LEFT JOIN  DEFECTLOT DL 
                                                     ON(DT.DEFECTID = DL.DEFECTID 
                                                         AND DL.DEFECT_DTTM >= '{dtpProductionStart.Value.Year}/{dtpProductionStart.Value.Month}/{dtpProductionStart.Value.Day}' 
                                                         AND DL.DEFECT_DTTM <= TO_DATE('{dtpProductionEnd.Value.Year}/{dtpProductionEnd.Value.Month}/{dtpProductionEnd.Value.Day}') + 1)) 
                                           WHERE DEFECT_DTTM IS NOT NULL 
                                           GROUP BY DEFECT_DTTM 
                                           ORDER BY DEFECT_DTTM ";

                DatabaseManager.DB_Inquiry(DEFECT_SELECT, gvCaseByDEFECT);
                DataTable data_Table2 = DatabaseManager.DB_Inquiry(DEFECT_SELECT);

                string[] HeaderName = new string[] { "발생일자", "이물질", "깨짐", "형상", "혼배합", "고중량", "저중량" };


                if (gvCaseByDEFECT.Rows.Count > 0)
                {
                    for (int i = 0; i < HeaderName.Length; i++)
                    {
                        gvCaseByDEFECT.Columns[i].HeaderText = $"{HeaderName[i]}";
                        gvCaseByDEFECT.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // 빈 레코드 표시 안함
                    gvCaseByDEFECT.AllowUserToAddRows = false;

                    // 헤더 위치 정렬(가운데)
                    gvCaseByDEFECT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }


                // 시각화
                if (data_Table2.Rows.Count > 0)
                {
                    double[] DF001 = new double[data_Table2.Rows.Count];
                    double[] DF002 = new double[data_Table2.Rows.Count];
                    double[] DF003 = new double[data_Table2.Rows.Count];
                    double[] DF004 = new double[data_Table2.Rows.Count];
                    double[] DF005 = new double[data_Table2.Rows.Count];
                    double[] DF006 = new double[data_Table2.Rows.Count];

                    double Sum_DF001 = 0.0;
                    double Sum_DF002 = 0.0;
                    double Sum_DF003 = 0.0;
                    double Sum_DF004 = 0.0;
                    double Sum_DF005 = 0.0;
                    double Sum_DF006 = 0.0;

                    for (int i = 0; i < data_Table2.Rows.Count; i++)
                    {
                        DF001[i] = Convert.ToDouble(data_Table2.Rows[i][1].ToString());
                        DF002[i] = Convert.ToDouble(data_Table2.Rows[i][2].ToString());
                        DF003[i] = Convert.ToDouble(data_Table2.Rows[i][3].ToString());
                        DF004[i] = Convert.ToDouble(data_Table2.Rows[i][4].ToString());
                        DF005[i] = Convert.ToDouble(data_Table2.Rows[i][5].ToString());
                        DF006[i] = Convert.ToDouble(data_Table2.Rows[i][6].ToString());

                        Sum_DF001 = DF001.Sum();
                        Sum_DF002 = DF002.Sum();
                        Sum_DF003 = DF003.Sum();
                        Sum_DF004 = DF004.Sum();
                        Sum_DF005 = DF005.Sum();
                        Sum_DF006 = DF006.Sum();
                    }

                    // 차트 옵션 설정
                    DonutDefect.Series.Clear();
                    DonutDefect.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    DonutDefect.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

                    // 데이터 추가 및 색깔 설정 
                    Series series = new Series("DonutSeries");
                    series.ChartType = SeriesChartType.Doughnut;

                    DataPoint dataPoint1 = new DataPoint();
                    dataPoint1.YValues = new double[] { Sum_DF001 };
                    dataPoint1.Color = System.Drawing.Color.FromArgb(255, 126, 133, 154); // 잿빛 파랑 (126, 133, 154)

                    DataPoint dataPoint2 = new DataPoint();
                    dataPoint2.YValues = new double[] { Sum_DF002 };
                    dataPoint2.Color = System.Drawing.Color.FromArgb(255, 248, 204, 124); // 노랑 (248, 204, 124)

                    DataPoint dataPoint3 = new DataPoint();
                    dataPoint3.YValues = new double[] { Sum_DF003 };
                    dataPoint3.Color = System.Drawing.Color.FromArgb(255, 73, 163, 156); // 녹색 (73, 163, 156)

                    DataPoint dataPoint4 = new DataPoint();
                    dataPoint4.YValues = new double[] { Sum_DF004 };
                    dataPoint4.Color = System.Drawing.Color.FromArgb(255, 9, 24, 71); // 남색 (9, 24, 71)

                    DataPoint dataPoint5 = new DataPoint();
                    dataPoint5.YValues = new double[] { Sum_DF005 };
                    dataPoint5.Color = System.Drawing.Color.FromArgb(255, 230, 230, 235); // 연보라 (230, 230, 235)

                    DataPoint dataPoint6 = new DataPoint();
                    dataPoint6.YValues = new double[] { Sum_DF006 };
                    dataPoint6.Color = System.Drawing.Color.FromArgb(255, 103, 85, 87); // 탁한 갈색 (103, 85, 87)


                    // 도넛 차트의 각 부분에 해당하는 데이터 포인트 추가
                    series.Points.Add(dataPoint1);
                    series.Points.Add(dataPoint2);
                    series.Points.Add(dataPoint3);
                    series.Points.Add(dataPoint4);
                    series.Points.Add(dataPoint5);
                    series.Points.Add(dataPoint6);


                    // 차트에 시리즈 추가
                    DonutDefect.Series.Add(series);


                }
            }
        }


        private void InitializeChart(DataTable dataTable, Chart chart, string excludeColumns)
        {
            // Chart 초기화
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            // "Default" 레전드가 없을 경우에만 추가
            if (!ChartLegendExists(chart, "Default"))
            {
                chart.Legends.Add(new Legend("Default"));

                // 레전드 폰트 속성 설정 예제
                chart.Legends["Default"].Font = new Font("Noto Sans KR", 10, System.Drawing.FontStyle.Bold); // 폰트 설정
                chart.Legends["Default"].ForeColor = Color.FromArgb(51, 51, 51); // 텍스트 색상 설정
            }

            chart.ChartAreas.Add(new ChartArea("Default"));

            // DataTable의 로우를 Y축 값으로 추가
            foreach (DataRow row in dataTable.Rows)
            {
                // 0번째 칼럼을 X축 값으로 사용
                string xAxisValue = row[0].ToString();

                // 나머지 칼럼의 값을 시리즈에 추가
                for (int i = 1; i < dataTable.Columns.Count; i++)
                {
                    DataColumn column = dataTable.Columns[i];

                    if (column.ColumnName != excludeColumns) // excludeColumns 컬럼은 X축에 추가하지 않음
                    {
                        string seriesName = column.ColumnName;

                        // 시리즈가 없으면 추가
                        if (!ChartSeriesExists(chart, seriesName))
                        {
                            Series newSeries = new Series(seriesName);
                            newSeries.ChartType = SeriesChartType.Spline;
                            newSeries.Legend = "Default"; // 레전드 추가
                            chart.Series.Add(newSeries);
                        }

                        // 해당 로우의 값을 가져오고, 값이 null이 아니라면 double로 변환
                        object columnValue = row[column.ColumnName];
                        double value;

                        if (columnValue != DBNull.Value && double.TryParse(columnValue.ToString(), out value))
                        {
                            // columnValue를 부동 소수점으로 변환할 수 있는 경우
                            // value 변수에 변환된 값이 저장
                        }
                        else
                        {
                            // 부동 소수점으로 변환할 수 없는 경우 또는 DBNull.Value인 경우
                            // value 변수에 double.NaN이 저장
                            value = double.NaN;
                        }

                        chart.Series[seriesName].Points.AddXY(xAxisValue, value);
                    }
                }
            }
        }

        // 시리즈 존재하는지 확인
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

        // 레전드 존재하는지 확인
        private bool ChartLegendExists(Chart chart, string legendName)
        {
            foreach (Legend legend in chart.Legends)
            {
                if (legend.Name == legendName)
                {
                    return true;
                }
            }
            return false;
        }





        private void btnPROD_Search_Click(object sender, EventArgs e)
        {
            DrawProductionChart();
            SearchDefectQty();
            SearchMakeQty();
            // 오류 검출 TOP3 라벨 지정
            TOP3DefectSearch();
        }


        private void dtpProductionStart_ValueChanged(object sender, EventArgs e)
        {
            DrawProductionChart();
        }

        private void dtpProductionEnd_ValueChanged(object sender, EventArgs e)
        {
            DrawProductionChart();
        }

        private void lbSYS_Defect_1_TextChanged(object sender, EventArgs e)
        {
            DrawProductionChart();
        }

      
    }
}
