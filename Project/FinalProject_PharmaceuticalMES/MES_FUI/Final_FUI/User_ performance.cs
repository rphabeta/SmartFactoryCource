using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Final_FUI
{
    public partial class User__performance : Form
    {
        string userid = 로그인.userid;
        public static string Selected_woid = "";
        string woid = "";

        public User__performance()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; // 콤보박스 선택 변경 이벤트 핸들러 추가
            btnSearh.Click += btnSearh_Click; // 버튼 클릭 이벤트 핸들러 추가

            txtWorkerInfo.Text = "";
            txtWorkerInfo.Visible = false;
        }

        private void User__performance_Load(object sender, EventArgs e)
        {
            woid = WO_Main.Selected_woid;
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Today.AddMonths(-2);
            dateTimePicker2.Value = DateTime.Today;
            //LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(); // 콤보박스 선택이 변경될 때마다 데이터를 새로 로드합니다.
        }

        private void LoadData()
        {
            WOID_LOT_Grid.DataSource = null; // 이전 데이터 지우기

            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    string selectedQuery = "";
                    DateTime date1 = dateTimePicker1.Value;
                    DateTime date2 = dateTimePicker2.Value;

                    // 종료일을 다음날로 늘림
                    date2 = date2.AddDays(1);

                    // 일별
                    if (comboBox1.SelectedIndex == 0)
                    {
                        selectedQuery = $@"
                            SELECT LOTCRDTTM, WORKERID, LOTQTY, DEFECT_QTY FROM 
                            (
                                SELECT 'A' ORD
                                     , TO_CHAR(LT.LOTCRDTTM, 'YYYYMMDD') LOTCRDTTM
                                     , LT.WORKERID
                                     , SUM(LT.LOTQTY) LOTQTY
                                     , SUM(DL.DEFECT_QTY) DEFECT_QTY
                                  FROM LOT LT
                                  LEFT JOIN DEFECTLOT DL ON LT.LOTID = DL.DEFECT_LOTID 
                                  WHERE LT.WORKERID = '{userid}' AND LT.LOTCRDTTM BETWEEN '{date1.ToString("yyyy-MM-dd")}' AND '{date2.ToString("yyyy-MM-dd")}'
                                  GROUP BY TO_CHAR(LT.LOTCRDTTM, 'YYYYMMDD'), LT.WORKERID

                                  UNION ALL

                                  SELECT 'B'
                                     , TO_CHAR(LT.LOTCRDTTM, 'YYYYMMDD') LOTCRDTTM
                                     , '전체'
                                     , ROUND(SUM(LT.LOTQTY) / COUNT(DISTINCT LT.WORKERID)) LOTQTY
                                     , ROUND(SUM(DL.DEFECT_QTY) / COUNT(DISTINCT LT.WORKERID)) DEFECT_QTY
                                  FROM LOT LT
                                  LEFT JOIN DEFECTLOT DL ON LT.LOTID = DL.DEFECT_LOTID
                                  WHERE LT.LOTCRDTTM BETWEEN '{date1.ToString("yyyy-MM-dd")}' AND '{date2.ToString("yyyy-MM-dd")}'
                                  GROUP BY TO_CHAR(LT.LOTCRDTTM, 'YYYYMMDD')
                            )  
                            ORDER BY ORD, LOTCRDTTM";
                    }
                    // 월별
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        selectedQuery = $@"
                                        SELECT LOTCRDTTM, WORKERID, LOTQTY, DEFECT_QTY FROM 
                                        (
                                            SELECT 'A' ORD
                                                 , TO_CHAR(LT.LOTCRDTTM, 'YYYYMM') LOTCRDTTM 
                                                 , LT.WORKERID
                                                 , SUM(LT.LOTQTY) LOTQTY
                                                 , SUM(DL.DEFECT_QTY) DEFECT_QTY
                                              FROM LOT LT
                                              LEFT JOIN DEFECTLOT DL ON LT.LOTID = DL.DEFECT_LOTID 
                                              WHERE LT.WORKERID = '{userid}' AND LT.LOTCRDTTM BETWEEN '{date1.ToString("yyyy-MM-dd")}' AND '{date2.ToString("yyyy-MM-dd")}'
                                              GROUP BY TO_CHAR(LT.LOTCRDTTM, 'YYYYMM'), LT.WORKERID

                                              UNION ALL

                                              SELECT 'B'
                                                 , TO_CHAR(LT.LOTCRDTTM, 'YYYYMM') LOTCRDTTM
                                                 , '전체'
                                                 , ROUND(SUM(LT.LOTQTY) / COUNT(DISTINCT LT.WORKERID)) LOTQTY
                                                 , ROUND(SUM(DL.DEFECT_QTY) / COUNT(DISTINCT LT.WORKERID)) DEFECT_QTY
                                              FROM LOT LT
                                              LEFT JOIN DEFECTLOT DL ON LT.LOTID = DL.DEFECT_LOTID
                                              WHERE LT.LOTCRDTTM BETWEEN '{date1.ToString("yyyy-MM-dd")}' AND '{date2.ToString("yyyy-MM-dd")}'
                                              GROUP BY TO_CHAR(LT.LOTCRDTTM, 'YYYYMM')
                                        )  
                                        ORDER BY ORD, LOTCRDTTM";
                    }

                    cmd.CommandText = selectedQuery;

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(rdr);
                            WOID_LOT_Grid.DataSource = dataTable;

                            ChangeColumnHeaders();
                            AdjustGridRowHeight();
                            bool isDaily = comboBox1.SelectedIndex == 0;

                            if (dataTable.Rows.Count > 0)
                            {
                                SetChartData(dataTable, isDaily);
                            }
                        }
                    }

                    selectedQuery = $@"
                        SELECT USERNAME || '님 '
                                 || (SELECT DECODE(SUM(QTY2), 0 , '실적이 없습니다',
                                         '전월 동기간 대비 생산실적이 '
                                         || TO_CHAR(ROUND(SUM(QTY1) / SUM(QTY2) * 100) - 100)
                                         || CASE WHEN SUM(QTY1) > SUM(QTY2) THEN  '% 증가하였습니다'
                                                 ELSE  '% 감소하였습니다' END
                                         )
                                    FROM
                                          (SELECT SUM(LOTQTY) QTY1
                                               , 0 QTY2
                                            FROM LOT
                                           WHERE WORKERID = '{userid}'
                                             AND LOTEDDTTM BETWEEN TO_DATE(TO_CHAR(SYSDATE,'YYYYMM') || '01') AND TO_DATE(SYSDATE + 1)
                                          UNION ALL
                                          SELECT 0 QTY1
                                               , SUM(LOTQTY) QTY2
                                            FROM LOT
                                           WHERE WORKERID = '{userid}'
                                             AND LOTEDDTTM BETWEEN ADD_MONTHS(TO_CHAR(SYSDATE,'YYYYMM') || '01' , -1) AND TO_DATE(ADD_MONTHS(SYSDATE, -1)) + 1
                                          )
                                  )
                              FROM 
                             USERS WHERE USERID = '{userid}'  

                    ";

                    cmd.CommandText = selectedQuery;

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(rdr);
                            if (dataTable.Rows.Count > 0)
                            {
                                txtWorkerInfo.Visible = true;
                                txtWorkerInfo.Text = dataTable.Rows[0][0].ToString();
                            }
                            else
                            {
                                txtWorkerInfo.Text = "";
                                txtWorkerInfo.Visible = false;
                            }
                        }
                    }

                }
            }
        }

        private void AdjustGridRowHeight()
        {
            // 셀 높이 조절
            WOID_LOT_Grid.RowTemplate.Height = 50; // 원하는 높이로 조절

            // 열 머리글 높이 조절
            WOID_LOT_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            WOID_LOT_Grid.ColumnHeadersHeight = 50; // 원하는 높이로 조절
        }
        private void ChangeColumnHeaders()
        {
            if (WOID_LOT_Grid.Columns.Count > 0)
            {
                WOID_LOT_Grid.Columns["LOTCRDTTM"].HeaderText = "날짜";
                WOID_LOT_Grid.Columns["WORKERID"].HeaderText = "작업자명";
                WOID_LOT_Grid.Columns["LOTQTY"].HeaderText = "총생성수량";
                WOID_LOT_Grid.Columns["DEFECT_QTY"].HeaderText = "불량수량";
            }
        }


        private void SetChartData(DataTable dataTable, bool isDaily)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();

            if (dataTable.Rows.Count == 0)
            {
                return;
            }

            chart1.ChartAreas.Add("ChartArea1");
            chart1.ChartAreas["ChartArea1"].AxisX.Minimum = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.Title = isDaily ? "일" : "월";
            chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Noto Sans KR", 16, FontStyle.Bold); // X 축 제목의 글꼴 및 크기 설정
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Font = new Font("Noto Sans KR", 14);
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1; // 원하는 간격으로 설정

            // 추가적으로, X축 레이블 각도를 조절하여 텍스트가 잘 보이도록 설정할 수 있습니다.
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = -45;

            chart1.ChartAreas["ChartArea1"].AxisY.Title = "총생성수량";
            chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Noto Sans KR", 16, FontStyle.Bold); // Y 축 제목의 글꼴 및 크기 설정
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Font = new Font("Noto Sans KR", 16);
            // SetChartData 메서드 내에 있는 레이블 및 범례 스타일 업데이트 부분
            foreach (Series series in chart1.Series)
            {
                series.Font = new Font("Noto Sans KR", 12); // 시리즈 레이블의 글꼴 및 크기 설정
                series.LabelForeColor = Color.Black; // 레이블 텍스트 색상 설정
            }

            chart1.Legends[0].Font = new Font("Noto Sans KR", 14); // 범례 폰트 및 크기 설정
            chart1.Legends[0].TitleFont = new Font("Noto Sans KR", 16, FontStyle.Bold); // 범례 제목 폰트 및 크기, 굵기 설정
            chart1.Legends[0].BackColor = Color.White; // 범례 배경색 설정
            chart1.Legends[0].BorderColor = Color.DarkGray; // 범례 테두리 색상 설정
            chart1.Legends[0].BorderWidth = 1; // 범례 테두리 굵기 설정

            int fixedPoints = 10; // 고정된 X 축에 보여줄 날짜 수

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value.AddDays(1);
            TimeSpan span = endDate - startDate;

            int totalDays = isDaily ? (int)Math.Ceiling(span.TotalDays) : (int)Math.Ceiling(span.TotalDays / 30);

            int interval = totalDays > fixedPoints ? totalDays / fixedPoints : 1;

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = interval;

            foreach (DataRow row in dataTable.Rows)
            {
                string date = row["LOTCRDTTM"].ToString();
                DateTime currentDateTime = isDaily
                    ? DateTime.ParseExact(date.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture)
                    : DateTime.ParseExact(date.Substring(0, 6), "yyyyMM", CultureInfo.InvariantCulture);

                string currentPeriodValue = isDaily ? currentDateTime.ToString("MM/dd") : currentDateTime.ToString("MM");
                double currentLotQty = Convert.ToDouble(row["LOTQTY"]);
                string currentWorkerID = row["WORKERID"].ToString();

                Series workerSeries = chart1.Series.FindByName(currentWorkerID);
                if (workerSeries == null)
                {
                    workerSeries = chart1.Series.Add(currentWorkerID);
                    workerSeries.ChartType = SeriesChartType.Spline;
                    workerSeries.BorderWidth = 2; // 선 굵기 설정
                }
                workerSeries.Points.AddXY(currentPeriodValue, currentLotQty);
            }

            // Legend의 LabelStyle에 대한 폰트 설정
            chart1.Legends[0].TitleFont = new Font("Noto Sans KR", 14);
        }
   


        private void btnSearh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
