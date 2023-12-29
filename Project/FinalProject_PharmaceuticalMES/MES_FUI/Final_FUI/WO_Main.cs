using Bunifu.UI.WinForms;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Final_FUI
{
    public partial class WO_Main : Form
    {
        private Production_Status productionStatus;
        public static string Selected_woid { get; set; }
        public static string Selected_procid { get; set; }
        public static string Selected_prodid { get; set; }
        public static string Selected_procidP { get; set; }
        public static string procid_name;
        public string[] WO_HEADER = new string[] {
                               "작업지시ID",
                                "제품코드",
                                "제품명",
                                "공정ID",
                                "공정명",
                                "계획수량",
                                "작업시작일",
                                "작업완료일",
                                "생산수량",
                                "양품수량",
                                "불량수량",
                                "양품비율",
                                "불량비율",
                                "작업상태"
                             };
        private bool isUserIDSet = false;
        private string state = string.Empty;
        public WO_Main()
        {
            InitializeComponent();
        }

        private void CheckButtonStatus() // 칭량버튼조절 나중에 생산수량에 따라 조건추가..?
        {
            // 현재 선택된 행 가져오기
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;

            if (selectedRow != null)
            {
                // 선택된 행에서 작업지시ID와 공정ID 가져오기
                Selected_woid = selectedRow.Cells["WOID"].Value.ToString();
                Selected_procid = selectedRow.Cells["PROCID"].Value.ToString();

                using (var conn = DatabaseManager.GetConnection())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        string query = $"SELECT PROCID FROM WORKORDER WHERE woid = '{Selected_woid}' AND procid = 'PC001' AND WOSTAT = 'S'";
                        cmd.CommandText = query;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            bool isPC001 = reader.HasRows;

                            // 버튼 활성화 여부 설정
                            btnWeight.Enabled = isPC001;
                        }
                    }
                }
            }
        }

        public void SetUserID(string userID)                // 작업자 ID 가져오기 
        {
            if (!isUserIDSet)
            {
                Console.WriteLine("SetUserID method called with userID: " + userID);
                txtUser.Text = userID;         // 텍스트 박스 2에 로그인 한 유저 아이디 작성 
                isUserIDSet = true;
            }
        }

        private void WO_Main_Load(object sender, EventArgs e) // 메인화면 로드
        {
            comboBox1.SelectedIndex = 0;
            // 폼로드시 날짜 초기화
            dateTimePicker1.Value = DateTime.Now.AddMonths(-2);
            dateTimePicker2.Value = DateTime.Now.AddMonths(-1);
            //dataGridView1.CellPainting += dataGridView1_CellPainting; // 헤더 정렬
            dataGridView1.CellFormatting += dataGridView1_CellFormatting; // 셀 포맷
            SetHeaderStyle();
            ReLoad();
        }

        public void ReLoad()
        {
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
            panel1.Hide();
            CheckButtonStatus();
            SetNumericColumnAlignment(dataGridView1);
            btnSearh_Click(null, null);
            //SearchWO(); // LoadToGridView() 호출
        }
        // 숫자 컬럼을 오른쪽 정렬
        private void SetNumericColumnAlignment(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.ValueType == typeof(int) || column.ValueType == typeof(decimal) || column.ValueType == typeof(double))
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

                if (columnName == "WOSTAT" && e.Value != null)
                {
                    string status = e.Value.ToString();

                    Color backgroundColor;
                    FontStyle fontStyle = FontStyle.Regular;

                    switch (status)
                    {
                        case "대기":
                            backgroundColor = Color.Yellow;   // "대기" 선택 시 노란색
                            break;
                        case "진행중":
                            backgroundColor = Color.SkyBlue;     // "시작" 선택 시 파란색
                            break;
                        case "완료":
                            backgroundColor = Color.Red;   // "완료" 선택 시 초록색
                            break;
                        default:
                            backgroundColor = Color.White; // 기본 배경색 설정
                            break;
                    }

                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                    cellStyle.BackColor = backgroundColor;
                    cellStyle.Font = new Font("Noto Sans KR", 14, fontStyle, GraphicsUnit.Point, ((byte)(129)));

                    // 현재 선택된 행인 경우에만 글꼴을 Bold로 설정
                    if (e.RowIndex == dataGridView1.CurrentRow.Index)
                    {
                        cellStyle.Font = new Font("Noto Sans KR", 14, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
                    }

                    e.CellStyle = cellStyle;

                    // 선택된 셀의 색상 설정
                    if (dataGridView1.SelectedCells.Contains(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex]))
                    {
                        switch (status)
                        {
                            case "대기":
                                cellStyle.SelectionBackColor = Color.Yellow;
                                break;
                            case "진행중":
                                cellStyle.SelectionBackColor = Color.SkyBlue;
                                break;
                            case "완료":
                                cellStyle.SelectionBackColor = Color.Red;
                                break;
                            default:
                                cellStyle.SelectionBackColor = Color.White;
                                break;
                        }
                        cellStyle.SelectionForeColor = SystemColors.HighlightText;
                    }

                }
            }

        }

        public void LoadDataToGridView(string sql, DataGridView dataGridView, string[] headers, bool main) // 그리드뷰 로드
        {
            if (dataGridView == null || headers == null || headers.Length == 0)
            {
                // DataGridView 또는 헤더 배열이 유효하지 않은 경우 처리
                return;
            }

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

                            // 컬럼명을 설정
                            for (int i = 0; i < headers.Length && i < dataGridView.Columns.Count; i++)
                            {
                                dataGridView.Columns[i].HeaderText = headers[i];
                                dataGridView.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // 헤더 가운데 정렬
                            }

                            if (main)
                            {
                                SetColumnWidth(dataGridView, "WOID", 140);
                                SetColumnWidth(dataGridView, "PROD_NAME", 90);
                                SetColumnWidth(dataGridView, "PROC_NAME", 90);
                                SetColumnWidth(dataGridView, "PLANQTY", 100);
                                SetColumnWidth(dataGridView, "WOSTDTTM", 180);
                                SetColumnWidth(dataGridView, "WOEDDTTM", 180);
                                SetColumnWidth(dataGridView, "PRODQTY", 100);
                                SetColumnWidth(dataGridView, "SUM_LOTQTY", 100);
                                SetColumnWidth(dataGridView, "SUM_DEFECTQTY", 100);
                                SetColumnWidth(dataGridView, "SUCCESSPER", 100);
                                SetColumnWidth(dataGridView, "DEFECTPER", 100);
                                SetColumnWidth(dataGridView, "WOSTAT", 100);
                            }
                            else
                            {
                                SetColumnWidth(dataGridView, "WOID", 95);
                                SetColumnWidth(dataGridView, "WOSTAT", 50);
                                SetColumnWidth(dataGridView, "PLANDATE", 70);
                                SetColumnWidth(dataGridView, "WOSTDTTM", 120);
                                SetColumnWidth(dataGridView, "WOEDDTTM", 120);
                                SetColumnWidth(dataGridView, "PROD_NAME", 60);
                                SetColumnWidth(dataGridView, "PLANQTY", 50);
                                SetColumnWidth(dataGridView, "PRODQTY", 50);
                                SetColumnWidth(dataGridView, "PROC_NAME", 60);
                                SetColumnWidth(dataGridView, "INSUSER", 70);
                                SetColumnWidth(dataGridView, "INSDTTM", 120);
                                SetColumnWidth(dataGridView, "SOID", 90);

                            }

                            // 열의 가시성 설정 (예시)
                            SetColumnVisibility(dataGridView, "PRODID", false);
                            SetColumnVisibility(dataGridView, "PROCID", false);
                        }
                        dataGridView.ColumnHeadersHeight = 80;
                        dataGridView.RowTemplate.Height = 70;
                        
                    }

                }
            }
            dataGridView.ReadOnly = true;
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                using (StringFormat sf = new StringFormat())
                {
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    // 폰트를 명시적으로 설정
                    Font headerFont = new Font("Noto Sans KR", 15, FontStyle.Bold);

                    e.Graphics.DrawString(
                        e.Value?.ToString(),
                        headerFont,
                        Brushes.Black,
                        e.CellBounds,
                        sf
                    );

                    e.Handled = true;
                }
            }
        }

        private void SetHeaderStyle()
        {
            //foreach (DataGridViewColumn column in dataGridView1.Columns)
            //{
            //    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Noto Sans KR", 15.5f, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        public static void SetColumnWidth(DataGridView dataGridView, string columnName, int width)
        {
            if (dataGridView.Columns.Contains(columnName))
                dataGridView.Columns[columnName].Width = width;
        }

        public static void SetColumnVisibility(DataGridView dataGridView, string columnName, bool visible)
        {
            if (dataGridView.Columns.Contains(columnName))
                dataGridView.Columns[columnName].Visible = visible;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) // 과립, 타정, 포장 콤보박스 선택
        {
            if (comboBox1.SelectedIndex >= 0) // 선택된 인덱스가 있는 경우에만 처리
            {
                SearchWO(); // 작업 지시 조회 메서드 호출

                if (panel1.Visible) // 패널이 보이는 경우에만 생산 현황 그리드 갱신
                {
                    Production_Status productionStatus = (Production_Status)panel1.Controls[0];
                    productionStatus?.SearchPS();
                }
            }

        }
        private void btnSearh_Click(object sender, EventArgs e) // 조회 버튼 클릭
        {
            SearchWO();
            if (panel1.Visible) // 패널이 보이는 경우에만 생산 현황 그리드 갱신
            {
                Production_Status productionStatus = (Production_Status)panel1.Controls[0];
                productionStatus?.SearchPS();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)  // 시작일 변경
        {
            //SearchWO();
            if (productionStatus != null)
            {
                productionStatus.SearchPS();
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e) // 종료일 변경
        {
            //SearchWO();
            if (productionStatus != null)
            {
                productionStatus.SearchPS();
            }
        }
        // 칭량 버튼 
        private void btnWeight_Click(object sender, EventArgs e) // 칭량 버튼
        {
            Selected_woid = dataGridView1.CurrentRow.Cells["WOID"].Value.ToString();
            Selected_procid = dataGridView1.CurrentRow.Cells["PROCID"].Value.ToString();
            string prodid = dataGridView1.CurrentRow.Cells["PRODID"].Value.ToString(); // 현재 선택된 작업의 제품ID
            원재료조회 원재료조회 = new 원재료조회(null, prodid, "", Selected_woid);
            원재료조회.Show();

            //원재료추가.Selected_woid = dataGridView1.CurrentRow.Cells["WOID"].Value.ToString(); // 이거 왜했지?
        }

        public void SearchWO() // 메인 작업 지시 리로드
        {
            dataGridView1.DataSource = null; // 이전 데이터 지우기
            dataGridView1.Rows.Clear();
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            // 종료일을 다음날로 늘림
            date2 = date2.AddDays(1);

            string sql1 = $@"SELECT * FROM (
    SELECT
        WO.WOID,
        WO.PRODID,
        CASE WO.PRODID
            WHEN 'P0001' THEN '타이레놀' 
            WHEN 'P0002' THEN '아모디핀'
            WHEN 'P0003' THEN '써스펜8'
            WHEN 'P0004' THEN '스피드펜'
        END AS PROD_NAME,
        WO.PROCID,
        CASE WO.PROCID
            WHEN 'PC001' THEN '과립'
            WHEN 'PC002' THEN '타정'
            WHEN 'PC003' THEN '포장'
        END AS PROC_NAME,
        WO.PLANQTY,
        WO.WOSTDTTM,
        WO.WOEDDTTM,
        SUM(LT.LOTQTY) + NVL(SUM(DL.DEFECT_QTY), 0) AS PRODQTY, -- 생산량
        SUM(LT.LOTQTY) AS SUM_LOTQTY,
        NVL(SUM(DL.DEFECT_QTY), 0) AS SUM_DEFECTQTY,
        NVL2(
            ROUND(SUM(LT.LOTQTY) / NULLIF(SUM(LT.LOTQTY) + NVL(SUM(DL.DEFECT_QTY), 0), 0) * 100, 2),
            ROUND(SUM(LT.LOTQTY) / NULLIF(SUM(LT.LOTQTY) + NVL(SUM(DL.DEFECT_QTY), 0), 0) * 100, 2) || '%',
            '0%'
        ) AS SUCCESSPER,
        NVL2(
            ROUND(NVL(SUM(DL.DEFECT_QTY), 0) / NULLIF(SUM(LT.LOTQTY) + NVL(SUM(DL.DEFECT_QTY), 0), 0) * 100, 2),
            ROUND(NVL(SUM(DL.DEFECT_QTY), 0) / NULLIF(SUM(LT.LOTQTY) + NVL(SUM(DL.DEFECT_QTY), 0), 0) * 100, 2) || '%',
            '0%'
        ) AS DEFECTPER,
        CASE WO.WOSTAT
            WHEN 'P' THEN '대기'
            WHEN 'S' THEN '진행중'
            WHEN 'E' THEN '완료'
        END AS WOSTAT
    FROM
        WORKORDER WO
        LEFT JOIN LOT LT ON WO.WOID = LT.WOID AND LT.LOTSTAT != 'D'
        LEFT JOIN DEFECTLOT DL ON LT.LOTID = DL.DEFECT_LOTID
    WHERE 
        (TO_DATE(TO_CHAR(WO.PLANDTTM, 'YYYY-MM-DD HH24:MI:SS'), 'YYYY-MM-DD HH24:MI:SS') >= TO_DATE('{date1:yyyy-MM-dd}', 'YYYY-MM-DD') AND 
        TO_DATE(TO_CHAR(WO.PLANDTTM, 'YYYY-MM-DD HH24:MI:SS'), 'YYYY-MM-DD HH24:MI:SS') < TO_DATE('{date2:yyyy-MM-dd}', 'YYYY-MM-DD HH24:MI:SS')";

            if (comboBox1.SelectedIndex == 0) // 전체
            {
                sql1 += $" AND (WO.PROCID IN ('PC001','PC002','PC003')) ";
            }
            else if (comboBox1.SelectedIndex == 1) // 과립
            {
                sql1 += $" AND WO.PROCID = 'PC001' ";
            }
            else if (comboBox1.SelectedIndex == 2) // 타정
            {
                sql1 += $" AND WO.PROCID = 'PC002' ";
            }
            else if (comboBox1.SelectedIndex == 3) // 포장
            {
                sql1 += $" AND WO.PROCID = 'PC003' ";
            }

            sql1 += @") 
                    GROUP BY 
                        WO.WOID,
                        WO.PRODID,
                        WO.PROCID,
                        WO.WOSTAT,
                        WO.PLANQTY,
                        WO.WOSTAT,
                        WO.WOSTDTTM,
                        WO.WOEDDTTM
                    ORDER BY 
                        CASE WO.WOSTAT 
                            WHEN 'S' THEN 1
                            WHEN 'P' THEN 2
                            WHEN 'E' THEN 3
                            ELSE 4 
                        END, 
                        CASE 
                            WHEN WO.WOSTAT = 'E' THEN WO.WOEDDTTM END DESC,
                        CASE 
                            WHEN WO.WOSTAT = 'S' THEN WO.WOSTDTTM END DESC
                    ) WHERE ROWNUM <= 100";

            LoadDataToGridView(sql1, dataGridView1, WO_HEADER, true);

        }


        private void btn_main_Click(object sender, EventArgs e) // 메인버튼 클릭
        {
            panel1.Hide();
            comboBox1.SelectedIndex = 0; // 콤보박스를 전체로 초기화
            dateTimePicker1.Value = DateTime.Now.AddMonths(-2); // 시작일을 두달 전으로 초기화
            dateTimePicker2.Value = DateTime.Now.AddMonths(1); // 종료일을 다음달로 초기화
            SearchWO();
        }
        private void btnStart_Click(object sender, EventArgs e) // 상세정보
        {
            Selected_woid = dataGridView1.CurrentRow.Cells["WOID"].Value.ToString(); // 현재 선택된 작업의 작업지시ID
            Selected_procid = dataGridView1.CurrentRow.Cells["PROCID"].Value.ToString(); // 현재 선택된 작업의 공정ID 

            과립 과립;
            과립 = new 과립(Selected_woid, Selected_procid);
            int tabidx = 0;
            switch (Selected_procid)
            {
                case "PC001":
                    tabidx = 0;
                    break;
                case "PC002":
                    tabidx = 1;
                    break;
                case "PC003":
                    tabidx = 2;
                    break;
            }
            과립.tabControl1.SelectedIndex = tabidx;
            과립.Show();
        }
        private void btn_Product_status_Click(object sender, EventArgs e)  // 생산현황 버튼 
        {
            panel1.Show();
            panel1.Size = dataGridView1.Size; // panel1의 크기를 dataGridView1의 크기로 설정
            panel1.Location = dataGridView1.Location; // panel1의 위치를 dataGridView1의 위치로 설정
            panel1.Controls.Clear(); // 패널 내부 컨트롤 초기화

            Production_Status productionStatusForm = new Production_Status();
            productionStatusForm.Dock = DockStyle.Fill;
            productionStatusForm.Size = dataGridView1.Size;
            productionStatusForm.ParentWoMain = this; // 메인 폼 전달
            panel1.Controls.Add(productionStatusForm); // Production_Status를 패널에 추가
        }

        private void btn_Date_Click(object sender, EventArgs e) // 생산일지
        {
            
            생산일지 생산일지 = new 생산일지();
            생산일지.WindowState = FormWindowState.Maximized; // 최대화 상태로 설정           
            생산일지.Show();
        }

        private void btn_BOM_Show_Click(object sender, EventArgs e) // BOM 버튼
        {

            // 현재 선택된 WOID와 PRODID 가져오기
            string selectedWOID = dataGridView1.CurrentRow.Cells["WOID"].Value.ToString();
            string selectedPRODID = dataGridView1.CurrentRow.Cells["PRODID"].Value.ToString();

            // BOM 폼을 생성하면서 WOID와 PRODID 값을 전달
            BOM bom = new BOM(selectedWOID, selectedPRODID);
            bom.WindowState = FormWindowState.Maximized; // 최대화 상태로 설정        
            bom.Show();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnWOStart_Click(object sender, EventArgs e) // 작업시작
        {
            // 작업지시 시작 시간 (현재시간) 업데이트
            state = dataGridView1.CurrentRow.Cells["WOSTAT"].Value.ToString();
            if (state == "대기")
            {
                SetWO("S", "WOSTDTTM");
                WO_Main_Start_Notification wO_Main_Start = new WO_Main_Start_Notification();
                wO_Main_Start.ShowDialog();
            }
            else if (state == "진행중")
            {
                WO_Main_Start_Notification_1 wO_Main_Start_1 = new WO_Main_Start_Notification_1();
                wO_Main_Start_1.ShowDialog();
            }
            else
            {
                WO_Main_Start_Notification_2 wO_Main_Start_2 = new WO_Main_Start_Notification_2();
                wO_Main_Start_2.ShowDialog();
            }
        }
        private void btnWOEnd_Click(object sender, EventArgs e) // 작업완료
        {
            state = dataGridView1.CurrentRow.Cells["WOSTAT"].Value.ToString();
            if (state == "진행중")
            {
                SetWO("E", "WOEDDTTM");
                WO_Main_Completion_Notification wO_Main_Completion = new WO_Main_Completion_Notification();
                wO_Main_Completion.ShowDialog();
            }
            else if (state == "대기")
            {
                WO_Main_Completion_Notification_1 wO_Main_Completion_1 = new WO_Main_Completion_Notification_1();
                wO_Main_Completion_1.ShowDialog();
            }
            else
            {
                wO_Main_Completion_2 wO_Main_Completion_2 = new wO_Main_Completion_2();
                wO_Main_Completion_2.ShowDialog();

            }
        }
        public void SetWO(string WOSTAT, string DTTM) // 작업시작, 완료 시간 업데이트
        {
            // 작업지시 시작, 완료 시간 (현재시간) 업데이트
            UpdateWOInDatabase(WOSTAT, DTTM);
            SearchWO();
        }
        private void UpdateWOInDatabase(string WOSTAT, string DTTM)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {
                    string updateQuery = $@"UPDATE WORKORDER SET WOSTAT = '{WOSTAT}' , {DTTM} = SYSDATE WHERE WOID = '{Selected_woid}'";

                    using (var cmd = conn.CreateCommand())
                    {
                        // 데이터베이스 업데이트 쿼리 실행
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();
                        updateQuery = string.Empty;
                    }
                    // 변경사항 커밋
                    transaction.Commit();
                }
            }
        }
        private void btnEnd_Click(object sender, EventArgs e) // 작업 종료
        {
            this.Close(); 
        }
        private void btnExit_Click(object sender, EventArgs e) // 나가기
        {
            this.Close();
            로그인 loginform = new 로그인();
            loginform.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            WO_Main.Selected_woid = dataGridView1.CurrentRow.Cells["WOID"].Value.ToString();
           
            CheckButtonStatus();
        }

        private void btn_Move_Click(object sender, EventArgs e)
        {
            this.Hide();

            User__performance user__Performance = new User__performance();
            user__Performance.ShowDialog();

            this.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}