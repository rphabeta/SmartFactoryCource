using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Final_FUI
{
    public partial class 과립 : Form
    {
        private WO_Main mainForm;
        public static 과립 CurrentInstance; // 현재 공정폼
        public static string Selected_woid = ""; // 현재 선택된 작업지시 id
        public static string Selected_procid = ""; // 현재 선택된 공정 id
        public string Select_lot = ""; // lot 조회 sql
        public static string hp_id;
        public static string eqpt_id = "";
        private static int tab_index;
        private string wostat = "";
        private string lotstat = "";
        string[] workorderColumns = new string[] {
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
            "작업하달일",
            "등록자ID",

        };
        string[] lotColumns = {
            "LOTID",
            "상태",
            "생성시간",
            "수량",
            "불량수량",
            "설비"
        };
        public 과립(string WOID = "", string PROCID = "")
        {
            InitializeComponent();
            this.mainForm = Application.OpenForms.OfType<WO_Main>().FirstOrDefault();
            과립.Selected_woid = WOID;
            과립.Selected_procid = PROCID;

            this.Text = "공정";
            CurrentInstance = this; 
            tabControl1.TabPages[0].Text = "";
            tabControl1.TabPages[1].Text = "";
            tabControl1.TabPages[2].Text = "";
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Multiline = true;
            tabControl1.SizeMode = TabSizeMode.Fixed;
            grid_WO.RowTemplate.Height = 50;
            grid_WO.ColumnHeadersHeight = 70;
            grid_LOT.RowTemplate.Height = 50;
            grid_LOT.ColumnHeadersHeight = 70;
            grid_TX.RowTemplate.Height = 50;
            grid_TX.ColumnHeadersHeight = 70;
            grid_BX.RowTemplate.Height = 50;
            grid_BX.ColumnHeadersHeight = 70;
        }

        private void CheckButtonStatus() //LOT추가버튼 활성화
        {
            // 현재 선택된 행 가져오기
            DataGridViewRow selectedRow = grid_WO.CurrentRow;
            bool wo_stat = false;
            DataGridViewRow selectedRow2 = grid_LOT.CurrentRow;
            bool lot_stat = false;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    selectedRow2 = grid_LOT.CurrentRow;
                    break;
                case 1:
                    selectedRow2 = grid_TX.CurrentRow;
                    break;
                case 2:
                    selectedRow2 = grid_BX.CurrentRow;
                    break;
            }

            if (selectedRow != null)
            {
                // 선택된 행에서 작업지시ID와 공정ID 가져오기
                Selected_woid = selectedRow.Cells["WOID"].Value.ToString();
                Selected_procid = selectedRow.Cells["PROCID"].Value.ToString();
                wostat = selectedRow.Cells["WOSTAT"].Value.ToString();

                // 버튼 활성화 여부 설정
                btn_LOT_Add.Enabled = (wostat == "진행중");
                wo_stat = (wostat == "진행중");
                btn_defect_Add.Enabled = (wostat == "진행중");
            }
            if (selectedRow2 != null)
            {
                lotstat = selectedRow2.Cells["LOTSTAT"].Value.ToString();
                lot_stat = (lotstat != "D");
                // 버튼 활성화 여부 설정
            }
            //btn_LOT_Delete.Enabled = (wo_stat && lot_stat);
        }

        //private void SetColumnWidth(DataGridView dataGridView, string columnName, int width)
        //{
        //    if (dataGridView.Columns.Contains(columnName))
        //    {
        //        dataGridView.Columns[columnName].Width = width;
        //    }
        //}

        public void 과립_Load(object sender, EventArgs e)
        {
            grid_LOT.ReadOnly = true;
            grid_TX.ReadOnly = true;
            grid_BX.ReadOnly = true;

            RefreshAllGridViews();
            CheckButtonStatus();
            SetButtonStates(true, true, false, false, false, false);
            SetButtonStatesTj(true, true, false, false, false, false);
            SetButtonStatesPj(true, false, false, true);
            SetButtonStates_LED(true, false);
            SetButtonStates_LED1(true, false);
            SetButtonStates_LED_CP1(true, false);
            SetButtonStates_LED_CP2(true, false);
            SetButtonStates_LED_BX1(true, false);

            grid_LOT.CellMouseClick += new DataGridViewCellMouseEventHandler(grid_LOT_CellMouseClick);
        }

        private void SetButtonStates_LED(bool state1, bool state2)   //과립 1호기
        {
            Pic_Red.Visible = state1;
            Pic_Green.Visible = state2;

        }

        private void SetButtonStates_LED1(bool state1, bool state2)  //과립 2호기 
        {
            Pic_Red_1.Visible = state1;
            Pic_Green_1.Visible = state2;

        }
        private void SetButtonStates_LED_CP1(bool state1, bool state2)  // 타정 1호기
        {
            Pic_Red3.Visible = state1;
            Pic_Green3.Visible = state2;

        }
        private void SetButtonStates_LED_CP2(bool state1, bool state2)   // 타정 2호기
        {
            pic_Red4.Visible = state1;
            Pic_Green4.Visible = state2;

        }
        private void SetButtonStates_LED_BX1(bool state1, bool state2)   // 타정 2호기
        {
            Pic_Red5.Visible = state1;
            Pic_Green5.Visible = state2;

        }


        private void SetButtonStates(bool state1, bool state2, bool state3, bool state4, bool state5, bool state6)
        {
            Pic_Gr001_Start.Visible = state1;
            Pic_Gr002_Start.Visible = state2;
            Pic_Gr001_End.Visible = state3;
            Pic_Gr002_End.Visible = state4;
            Pic_Gr001_ing.Visible = state5;
            Pic_Gr002_ing.Visible = state6;
        }
        private void SetButtonStatesTj(bool state1, bool state2, bool state3, bool state4, bool state5, bool state6)
        {
            Pic_TJ001_Start.Visible = state1;
            Pic_TJ002_Start.Visible = state2;
            Pic_TJ001_End.Visible = state3;
            Pic_TJ002_End.Visible = state4;
            Pic_TJ001_ing.Visible = state5;
            Pic_TJ002_ing.Visible = state6;
        }

        private void SetButtonStatesPj(bool state1, bool state2, bool state3, bool state4)
        {
            Pic_PJ001_Start.Visible = state1;
            Pic_PJ001_ing1.Visible = state2;
            Pic_PJ001_ing2.Visible = state3;
            Pic_PJ002_End.Visible = state4;

        }
        public void LoadData(string sql, string[] header, DataGridView dataGridView, bool wo)
        {
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
        public void RefreshAllGridViews()
        {
            LoadData($@"SELECT W.WOID, 
                               CASE W.WOSTAT
                                    WHEN 'P' THEN '대기'
                                    WHEN 'S' THEN '진행중'
                                    WHEN 'E' THEN '완료'
                               END AS WOSTAT,
                               TO_CHAR(W.PLANDTTM, 'YYYY-MM-DD') AS PLANDTTM, W.WOSTDTTM, W.WOEDDTTM, 
                               W.PRODID, D.PRODNAME, W.PLANQTY, W.PRODQTY, W.PROCID, C.PROCNAME, W.PLANDTTM AS HADAL, W.INSUSER 
                        FROM WORKORDER W JOIN PRODUCT D ON W.PRODID = D.PRODID
                                         JOIN PROCESS C ON W.PROCID = C.PROCID
                        WHERE W.WOID = '{Selected_woid}'", workorderColumns, grid_WO, true);
            WO_Main.SetColumnVisibility(grid_WO, "PRODID", false);
            WO_Main.SetColumnVisibility(grid_WO, "PROCID", false);
            grid_WO.Columns["WOID"].Width = 140;
            grid_WO.Columns["WOSTAT"].Width = 70;
            grid_WO.Columns["PLANDTTM"].Width = 100;
            grid_WO.Columns["WOSTDTTM"].Width = 160;
            grid_WO.Columns["WOEDDTTM"].Width = 160;

            grid_WO.Columns["PRODID"].Width = 0;
            grid_WO.Columns["PRODNAME"].Width = 80;
            grid_WO.Columns["PLANQTY"].Width = 55;
            grid_WO.Columns["PRODQTY"].Width = 55;

            grid_WO.Columns["PROCID"].Width = 0;
            grid_WO.Columns["PROCNAME"].Width = 90;
            grid_WO.Columns["HADAL"].Width = 140;
            grid_WO.Columns["INSUSER"].Width = 110;

            List<string> eqptGridValues = new List<string> { "GR000", "CP000", "BX000" };

            foreach (string eqptGridValue in eqptGridValues)
            {
                string selectLotByEqptGrid = $@"
                        SELECT L.LOTID, L.LOTSTAT, L.LOTCRDTTM, L.LOTQTY, COALESCE(D.DEFECT_QTY, 0) AS DEFECT_QTY, L.EQPTID
                        FROM LOT L
                             LEFT JOIN DEFECTLOT D ON L.LOTID = D.DEFECT_LOTID
                        WHERE L.EQPTID IN (SELECT EQPTID FROM EQUIPMENT WHERE EQPTGRID = '{eqptGridValue}') AND WOID = '{Selected_woid}'
                        ORDER BY 
                            CASE L.LOTSTAT
                                WHEN 'E' THEN 1
                                WHEN 'D' THEN 2
                                ELSE 3
                            END,
                            L.LOTCRDTTM DESC";

                // 각 EQPTGRID에 해당하는 DataGridView에 데이터 로드
                if (eqptGridValue == "GR000")
                {
                    LoadData(selectLotByEqptGrid, lotColumns, grid_LOT, false);
                }
                else if (eqptGridValue == "CP000")
                {
                    LoadData(selectLotByEqptGrid, lotColumns, grid_TX, false);
                }
                else if (eqptGridValue == "BX000")
                {
                    LoadData(selectLotByEqptGrid, lotColumns, grid_BX, false);
                }
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckButtonStatus();
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckButtonStatus();
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CheckButtonStatus();
        }
        private void UpdateWOEDDTTMInDatabase(string formattedTime, string WOSTAT)
        {
            Selected_woid = grid_WO.CurrentRow.Cells["WOID"].Value.ToString();
            using (var conn = DatabaseManager.GetConnection())
            {
                string updateQuery = $"UPDATE WORKORDER SET WOEDDTTM = TO_DATE('{formattedTime}', 'YYYY-MM-DD HH24:MI:SS'),WOSTAT = '{WOSTAT}' WHERE WOID='{Selected_woid}'";
                using (var cmd = conn.CreateCommand())
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            string state = grid_WO.CurrentRow.Cells["WOSTAT"].Value.ToString();
            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (state == "S")
            {
                UpdateWOEDDTTMInDatabase(formattedTime, "E");
                this.Close();
                MessageBox.Show("완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainForm.SearchWO();
                mainForm.SetWO("E", "WOEDDTTM");
            }
            else if (state == "E")
            {
                MessageBox.Show("이미 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_defect_Add_Click(object sender, EventArgs e)
        {
            int selectedTabIndex = tabControl1.SelectedIndex;
            불량등록 defect_add = new 불량등록(selectedTabIndex, 과립.Selected_woid);
            defect_add.Show();

        }

        private void btn_DEF_Search_Click(object sender, EventArgs e)
        {
            불량조회 def_search = new 불량조회(grid_WO.CurrentRow.Cells["WOID"].Value.ToString());
            def_search.Show();
        }

        private void btn_LOT_Delete_Click(object sender, EventArgs e)
        {
            DataGridView under = new DataGridView();
            switch (과립.Selected_procid)
            {
                case "PC001":
                    under = grid_LOT;
                    break;
                case "PC002":
                    under = grid_TX;
                    break;
                case "PC003":
                    under = grid_BX;
                    break;

            }
            string stat = under.CurrentRow.Cells["LOTSTAT"].Value.ToString();

            if (stat != "D")
            {
                LOT_삭제 lot_delete = new LOT_삭제();

                if (과립.Selected_procid == "PC001")
                    LOT_삭제.lotid = grid_LOT.CurrentRow.Cells["LOTID"].Value.ToString();
                if (과립.Selected_procid == "PC002")
                    LOT_삭제.lotid = grid_TX.CurrentRow.Cells["LOTID"].Value.ToString();
                if (과립.Selected_procid == "PC003")
                    LOT_삭제.lotid = grid_BX.CurrentRow.Cells["LOTID"].Value.ToString();
                if (lot_delete.ShowDialog() == DialogResult.OK)
                {
                    RefreshAllGridViews();
                };
            }
            else
            {
                LOT_D lot_d = new LOT_D();
                lot_d.Show();
            }
        }
        private void RunDown(string eqptid, string runStat)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                string updateQuery = $"UPDATE EQUIPMENT SET EQPTSTATS = '{runStat}' WHERE EQPTID = '{eqptid}'";
                using (var cmd = conn.CreateCommand())
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
        }

        private async void btn_Gr001_Start_Click(object sender, EventArgs e) //과립 1호기 시작
        {
            eqpt_id = "GR001";
            lotAdd(eqpt_id); // lot 추가 (원재료 조회 폼 띄움)
        }
        private async void btn_Gr002_Start_Click(object sender, EventArgs e) //과립 2호기 시작
        {
            eqpt_id = "GR002";
            lotAdd(eqpt_id);
        }
        private async void btn_Tj1_start_Click(object sender, EventArgs e)
        {
            eqpt_id = "CP001";
            lotAdd(eqpt_id);
        }

        private async void btn_Tj2_start_Click(object sender, EventArgs e)
        {
            eqpt_id = "CP002";
            lotAdd(eqpt_id);
        }
        private async void btn_PJ001_start_Click(object sender, EventArgs e)
        {
            eqpt_id = "BX001";
            lotAdd(eqpt_id);
        }
        public async Task Eqpt_Start(string eqptid)
        {
            RunDown(eqptid, "RUN"); // 설비 run 업데이트           
            switch (eqptid)
            {
                case "GR001":
                    await Task.Delay(3000);
                    SetButtonStates(false, true, false, false, true, false);
                    SetButtonStates_LED(false, true);
                    await Task.Delay(6000);
                    SetButtonStates(false, true, true, false, false, false);
                    SetButtonStates_LED(false, false);
                    SetButtonStates_LED(true, false);
                    break;

                case "GR002":
                    await Task.Delay(3000);
                    SetButtonStates(true, false, false, false, false, true);
                    SetButtonStates_LED1(false, true);
                    await Task.Delay(6000);
                    SetButtonStates(true, false, false, true, false, false);
                    SetButtonStates_LED1(true, false);
                    SetButtonStates_LED1(true, false);
                    break;

                case "CP001":
                    await Task.Delay(3000);
                    SetButtonStatesTj(false, true, false, false, true, false);
                    SetButtonStates_LED_CP1(false, true);
                    await Task.Delay(7000);
                    SetButtonStatesTj(false, true, true, false, false, false);
                    SetButtonStates_LED_CP1(true, false);
                    SetButtonStates_LED_CP1(true, false);
                    break;

                case "CP002":
                    await Task.Delay(3000);
                    SetButtonStatesTj(true, false, false, false, false, true);
                    SetButtonStates_LED_CP2(false, true);
                    await Task.Delay(7000);
                    SetButtonStatesTj(true, false, false, true, false, false);
                    SetButtonStates_LED_CP2(true, false);
                    SetButtonStates_LED_CP2(true, false);
                    break;

                case "BX001":
                    //SetButtonStatesPj(true, false, false);
                    await Task.Delay(3000);
                    SetButtonStatesPj(false, true, false, true);
                    SetButtonStates_LED_BX1(false, true);
                    await Task.Delay(4000);
                    SetButtonStatesPj(true, false, true, false);   
                    await Task.Delay(4000);
                    SetButtonStatesPj(true, false, false, true);
                    await Task.Delay(4000);
                    SetButtonStates_LED_BX1(true, false);
                    SetButtonStates_LED_BX1(true, false);
                    break;
            }
            RunDown(eqptid, "DOWN"); // 설비 down 업데이트
            //RefreshAllGridViews();
        }

        private void lotAdd(string EQPTID)
        {
            string prodid = grid_WO.CurrentRow.Cells["PRODID"].Value.ToString();
           
            원재료조회 조회 = new 원재료조회(EQPTID, prodid, 과립.Selected_procid, 과립.Selected_woid);
            조회.Show();
        }
        private void btn_LOT_Add_Click(object sender, EventArgs e) // LOT 추가
        {
            string procid = grid_WO.CurrentRow.Cells["PROCID"].Value.ToString();
            string prodid = grid_WO.CurrentRow.Cells["PRODID"].Value.ToString();
            eqpt_id = "";
            
            원재료조회 조회 = new 원재료조회(eqpt_id, prodid, procid, 과립.Selected_woid);
            조회.Show();
        }
        private void Update_eqptid(string eqptid)
        {
            Selected_woid = grid_WO.CurrentRow.Cells["WOID"].Value.ToString();
            using (var conn = DatabaseManager.GetConnection())
            {
                string updateqptid = $"UPDATE STORE_STORAGE SET EQPTID = '{eqptid}' WHERE STORID = '{hp_id}'";

                using (var cmd = conn.CreateCommand())
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        cmd.CommandText = updateqptid;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void grid_LOT_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                CheckButtonStatus();
            }
        }
    }
}