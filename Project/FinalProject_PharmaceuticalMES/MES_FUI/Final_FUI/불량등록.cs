using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Final_FUI
{
    public partial class 불량등록 : Form
    {
        public static string woid = "";
        private static DataTable datagrid_right = new DataTable();
        public int DataGridViewRow { get; private set; }
        public static string lotid { get; set; }
        private int selectedTabIndex; // 새로운 멤버 변수 추가

        public 불량등록(int selectedTabIndex, string WOID = "")
        {
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
            InitializeComponent();
            this.selectedTabIndex = selectedTabIndex;
            불량등록.woid = WOID;
        }
        string[] lotColumns = {
         "LOTID",
         "LOT수량",

     };
        string[] DeflotColumns = {
         "불량LOT",
         "불량코드",
         "불량원인",
         "불량수량"
     };

        private void 불량등록_Load(object sender, EventArgs e)
        {

            // Lot_Data_Grid_Left의 행 높이 설정
            Lot_Data_Grid_Left.RowTemplate.Height = 60; 

            // Lot_Data_Grid_Left의 열 머리글 높이 설정
            Lot_Data_Grid_Left.ColumnHeadersHeight = 60;

            // DEF_LOT_Data_Grid_Right의 행 높이 설정
            DEF_LOT_Data_Grid_Right.RowTemplate.Height = 60;

            // DEF_LOT_Data_Grid_Right의 열 머리글 높이 설정
            DEF_LOT_Data_Grid_Right.ColumnHeadersHeight = 60; 


            // 페이지에 따라 다른 데이터를 가져오도록 수정
            if (selectedTabIndex == 0)
            {
                // 과립데이터 정보 
                LoadData($"SELECT LOTID, LOTQTY FROM LOT LEFT JOIN DEFECTLOT ON LOT.LOTID = DEFECTLOT.DEFECT_LOTID WHERE LOT.LOTQTY IS NOT NULL AND DEFECTLOT.DEFECT_LOTID IS NULL AND LOT.WOID='{불량등록.woid}' AND LOT.LOTSTAT != 'D' and LOT.eqptid IN ('GR001','GR002')", lotColumns, Lot_Data_Grid_Left);
            }
            else if (selectedTabIndex == 1)
            {
                // 칭량 
                LoadData($"SELECT LOTID, LOTQTY FROM LOT LEFT JOIN DEFECTLOT ON LOT.LOTID = DEFECTLOT.DEFECT_LOTID WHERE LOT.LOTQTY IS NOT NULL AND DEFECTLOT.DEFECT_LOTID IS NULL AND LOT.WOID='{불량등록.woid}' AND LOT.LOTSTAT != 'D'  and LOT.eqptid IN ('CP001','CP002')", lotColumns, Lot_Data_Grid_Left);
            }
            else if (selectedTabIndex == 2)
            {
                //포장 데이터 정보
                LoadData($"SELECT LOTID, LOTQTY FROM LOT LEFT JOIN DEFECTLOT ON LOT.LOTID = DEFECTLOT.DEFECT_LOTID WHERE LOT.LOTQTY IS NOT NULL AND DEFECTLOT.DEFECT_LOTID IS NULL AND LOT.WOID='{불량등록.woid}' AND LOT.LOTSTAT != 'D' and LOT.eqptid = 'BX001'", lotColumns, Lot_Data_Grid_Left);
            }
            
            //Lot_Data_Grid_Left.Columns["LOTID"].Width = 60;
            //Lot_Data_Grid_Left.Columns["LOTQTY"].Width = 30;

            if (datagrid_right.Columns.Count == 0)
            {
                datagrid_right.Columns.Add("불량LOT", typeof(string));
                datagrid_right.Columns.Add("불량코드", typeof(string));
                datagrid_right.Columns.Add("불량원인", typeof(string));
                datagrid_right.Columns.Add("불량수량", typeof(decimal));
            }

            DEF_LOT_Data_Grid_Right.DataSource = datagrid_right;
            DEF_LOT_Data_Grid_Right.Columns["불량LOT"].Width = 120;
            DEF_LOT_Data_Grid_Right.Columns["불량코드"].Width = 80;
            DEF_LOT_Data_Grid_Right.Columns["불량원인"].Width = 80;
            DEF_LOT_Data_Grid_Right.Columns["불량수량"].Width = 80;
        }

        private void LoadData(string sql, string[] header, DataGridView dataGridView)           // LoadData 데이터 불러오기 
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

        private void InsertRGrid(object sender, EventArgs e)
        {
            string DEFECT_CD = string.Empty;
            string DEFECTNAME = string.Empty;

            if (Lot_Data_Grid_Left.Rows.Count == 0)
                return;

            if ((Button)sender == btn_DEF_Crack)
            {
                DEFECT_CD = "DF001";
                DEFECTNAME = "이물질";
            }
            else if ((Button)sender == btn_DEF_Break)
            {
                DEFECT_CD = "DF002";
                DEFECTNAME = "깨짐";
            }
            else if ((Button)sender == btn_DEF_Shape)
            {
                DEFECT_CD = "DF003";
                DEFECTNAME = "형상";
            }
            else if ((Button)sender == btn_DEF_Mix)
            {
                DEFECT_CD = "DF004";
                DEFECTNAME = "혼배합";
            }
            else if ((Button)sender == btn_DEF_High_weight)
            {
                DEFECT_CD = "DF005";
                DEFECTNAME = "고중량";
            }
            else if ((Button)sender == btn_DEF_Low_weight)
            {
                DEFECT_CD = "DF006";
                DEFECTNAME = "저중량";
            }

            DataRow row = datagrid_right.NewRow();

            row["불량LOT"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTID"].Value;
            row["불량코드"] = DEFECT_CD;
            row["불량원인"] = DEFECTNAME;
            row["불량수량"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTQTY"].Value;

            DEF_LOT_Data_Grid_Right.Rows.Add(row);

            Lot_Data_Grid_Left.Rows.RemoveAt(Lot_Data_Grid_Left.CurrentRow.Index);

        }

        private void btn_exit_Click(object sender, EventArgs e)  // 나가기 버튼 
        {
            datagrid_right.Rows.Clear();   // 오른쪽 그리드 내용 삭제 

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)  // 되돌리기 버튼 
        {
            if (DEF_LOT_Data_Grid_Right.Rows.Count == 1)     // 오른쪽 그리드에 데이터가 없으면 실행 하지않고 돌아간다. 
            {
                MessageBox.Show("불량 등록을 취소할 LOT이 존재하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataTable dt = new DataTable();
            dt = (DataTable)Lot_Data_Grid_Left.DataSource;

            DataRow row = dt.NewRow();
            if (DEF_LOT_Data_Grid_Right.CurrentRow != null)
            {
                row["LOTID"] = DEF_LOT_Data_Grid_Right.CurrentRow.Cells["불량LOT"].Value;    // 왼쪽 LOTID에 오른쪽 DEFECT_LOTID 다시 넣기 
                row["LOTQTY"] = DEF_LOT_Data_Grid_Right.CurrentRow.Cells["불량수량"].Value;     // 왼쪽 LOTQTY에 오른쪽 DEFECT_QTY 넣기 

                dt.Rows.Add(row);

                DEF_LOT_Data_Grid_Right.Rows.RemoveAt(DEF_LOT_Data_Grid_Right.CurrentRow.Index); //오른쪽 그리드에서 선택한 현재 행을 제거
            }
        }
        private void btn_DEF_Crack_Click(object sender, EventArgs e)  //이물질 버튼 
        {
            string DEFECT_CD = string.Empty;
            string DEFECTNAME = string.Empty;

            if ((Button)sender == btn_DEF_Crack)
            {
                DEFECT_CD = "DF001";
                DEFECTNAME = "이물질";
            }

            DataRow row = datagrid_right.NewRow();

            row["불량LOT"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTID"].Value;
            row["불량코드"] = DEFECT_CD;
            row["불량원인"] = DEFECTNAME;
            row["불량수량"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTQTY"].Value;

            datagrid_right.Rows.Add(row);

            Lot_Data_Grid_Left.Rows.RemoveAt(Lot_Data_Grid_Left.CurrentRow.Index);

        }

        private void btn_DEF_Break_Click(object sender, EventArgs e)  //깨짐 버튼 
        {
            string DEFECT_CD = string.Empty;
            string DEFECTNAME = string.Empty;

            if ((Button)sender == btn_DEF_Break)
            {
                DEFECT_CD = "DF002";
                DEFECTNAME = "깨짐";
            }

            DataRow row = datagrid_right.NewRow();

            row["불량LOT"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTID"].Value;
            row["불량코드"] = DEFECT_CD;
            row["불량원인"] = DEFECTNAME;
            row["불량수량"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTQTY"].Value;

            datagrid_right.Rows.Add(row);

            Lot_Data_Grid_Left.Rows.RemoveAt(Lot_Data_Grid_Left.CurrentRow.Index);
        }

        private void btn_DEF_Shape_Click(object sender, EventArgs e)   // 형상 버튼 
        {
            string DEFECT_CD = string.Empty;
            string DEFECTNAME = string.Empty;

            if ((Button)sender == btn_DEF_Shape)
            {
                DEFECT_CD = "DF003";
                DEFECTNAME = "형상";
            }

            DataRow row = datagrid_right.NewRow();

            row["불량LOT"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTID"].Value;
            row["불량코드"] = DEFECT_CD;
            row["불량원인"] = DEFECTNAME;
            row["불량수량"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTQTY"].Value;

            datagrid_right.Rows.Add(row);

            Lot_Data_Grid_Left.Rows.RemoveAt(Lot_Data_Grid_Left.CurrentRow.Index);
        }

        private void btn_DEF_Mix_Click(object sender, EventArgs e)     // 혼배합 버튼 
        {
            string DEFECT_CD = string.Empty;
            string DEFECTNAME = string.Empty;

            if ((Button)sender == btn_DEF_Mix)
            {
                DEFECT_CD = "DF004";
                DEFECTNAME = "혼배합";
            }

            DataRow row = datagrid_right.NewRow();

            row["불량LOT"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTID"].Value;
            row["불량코드"] = DEFECT_CD;
            row["불량원인"] = DEFECTNAME;
            row["불량수량"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTQTY"].Value;

            datagrid_right.Rows.Add(row);

            Lot_Data_Grid_Left.Rows.RemoveAt(Lot_Data_Grid_Left.CurrentRow.Index);
        }

        private void btn_DEF_High_weight_Click(object sender, EventArgs e)      // 고중량 버튼 
        {
            string DEFECT_CD = string.Empty;
            string DEFECTNAME = string.Empty;

            if ((Button)sender == btn_DEF_High_weight)
            {
                DEFECT_CD = "DF005";
                DEFECTNAME = "고중량";
            }

            DataRow row = datagrid_right.NewRow();

            row["불량LOT"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTID"].Value;
            row["불량코드"] = DEFECT_CD;
            row["불량원인"] = DEFECTNAME;
            row["불량수량"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTQTY"].Value;

            datagrid_right.Rows.Add(row);

            Lot_Data_Grid_Left.Rows.RemoveAt(Lot_Data_Grid_Left.CurrentRow.Index);

        }

        private void btn_DEF_Low_weight_Click(object sender, EventArgs e)       // 저중량 버튼 
        {
            string DEFECT_CD = string.Empty;
            string DEFECTNAME = string.Empty;

            if ((Button)sender == btn_DEF_Low_weight)
            {
                DEFECT_CD = "DF006";
                DEFECTNAME = "저중량";
            }

            DataRow row = datagrid_right.NewRow();

            row["불량LOT"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTID"].Value;
            row["불량코드"] = DEFECT_CD;
            row["불량원인"] = DEFECTNAME;
            row["불량수량"] = Lot_Data_Grid_Left.CurrentRow.Cells["LOTQTY"].Value;

            datagrid_right.Rows.Add(row);

            Lot_Data_Grid_Left.Rows.RemoveAt(Lot_Data_Grid_Left.CurrentRow.Index);
        }

        private void btn_Save_Click(object sender, EventArgs e)   // 저장 버튼 
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var transaction = conn.BeginTransaction())
                {

                    DataTable LOT = (DataTable)DEF_LOT_Data_Grid_Right.DataSource;

                    // insert 쿼리문
                    if (LOT != null && LOT.Rows.Count > 0)
                    {
                        for (int i = 0; i < LOT.Rows.Count; i++)
                        {
                            string defect_lotid = LOT.Rows[i]["불량LOT"].ToString();
                            int defect_qty = Convert.ToInt32(LOT.Rows[i]["불량수량"]);
                            string defect_id = LOT.Rows[i]["불량코드"].ToString();
                            string Insert_query = $@"
                            INSERT INTO DEFECTLOT (DEFECT_LOTID, DEFECT_QTY, DEFECT_DTTM, DEFECT_INSPECTOR, DEFECTID) 
                            VALUES
                            ('{defect_lotid}', {defect_qty}, TO_TIMESTAMP('{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', 'YYYY-MM-DD HH24:MI:SS'), '{로그인.userid}', '{defect_id}')";
                            string update_query = $@"UPDATE LOT L SET L.LOTQTY = 0  WHERE L.LOTID = '{defect_lotid}'";
                            string hp_query = $@"update STORE_STORAGE 
                                                set currqty = 0, eqptid = null
                                                 WHERE EQPTID = (SELECT EQPTID 
                                                                      FROM LOT WHERE LOTID = '{defect_lotid}')";
                            using (var cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = Insert_query;
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = update_query;
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = hp_query;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        Defect_Completion defect_Completion = new Defect_Completion();
                        defect_Completion.ShowDialog();

                        // 작업 완료 후 추가 동작 수행
                        datagrid_right.Rows.Clear();
                        transaction.Commit();
                        if (과립.CurrentInstance != null)
                        {
                            과립.CurrentInstance.RefreshAllGridViews();
                        }
                        CallWO_MainLoad();
                        this.Close();
                    }

                    else
                    {
                        DialogResult result = MessageBox.Show("불량 등록할 LOT이 없습니까?", "알림", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                        {
                            this.Close(); // 불량 등록 폼 닫기
                        }
                    }
                }
            }
        }
        private void CallWO_MainLoad()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is WO_Main)
                {
                    if (form != null && !form.IsDisposed)
                    {
                        ((WO_Main)form).ReLoad();
                        break;
                    }
                }
            }
        }

  
    }


}
