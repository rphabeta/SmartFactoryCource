using Pharmaceutical_MES;
using Pharmaceutical_MES.ProcessMGR.ProcessMGR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewPage.작업관리;

namespace ViewPage
{
    public partial class 작업지시 : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();

        public 작업지시()
        {
            InitializeComponent();
        }

        public void SELECT()
        {
            string DBWorkOrder = $@"
                   SELECT  WO.WOID, 
                           WO.PLANDTTM, 
                           WO.PRODQTY, 
                           WO.PLANQTY, 
                           DECODE(WO.WOSTAT, 'P', '대기', 'S', '시작', 'E', '종료', 'D', '삭제') AS WOSTAT, 
                           WO.PRODID, 
                           PD.PRODNAME, 
                           WO.PROCID, 
                           PC.PROCNAME, 
                           TO_CHAR(WO.WOSTDTTM, 'YYYY-MM-DD HH24:MI') AS WOSTDTTM, 
                           WO.INSUSER 
                   FROM WORKORDER WO
                       INNER JOIN PRODUCT PD ON (WO.PRODID = PD.PRODID)
                       INNER JOIN PROCESS PC ON (WO.PROCID = PC.PROCID)
                   WHERE 1=1
                       AND WO.PLANDTTM >= '{dateTimePicker1.Value.Year}/{dateTimePicker1.Value.Month}/{dateTimePicker1.Value.Day}'
                       AND WO.PLANDTTM <= to_date('{dateTimePicker2.Value.Year}/{dateTimePicker2.Value.Month}/{dateTimePicker2.Value.Day}') + 1
                       AND WO.DEL_YN = 'N'";

            try
            {
                WorkGrid.DataSource = databaseManager;

                if (!string.IsNullOrEmpty(tbProductID.Text))
                {
                    string PRODID = tbProductID.Text;
                    DBWorkOrder += $" AND WO.PRODID LIKE '%{PRODID.ToUpper()}%' \n";
                }
                if (!string.IsNullOrEmpty(tbWorkID.Text))
                {
                    string WOID = tbWorkID.Text;
                    DBWorkOrder += $" AND WO.WOID LIKE '%{WOID.ToUpper()}%' \n";
                }
                if (!string.IsNullOrEmpty(tbProductName.Text))
                {
                    string PRODNAME = tbProductName.Text;
                    DBWorkOrder += $"AND PD.PRODNAME LIKE '%{PRODNAME}%' \n";
                }
                if (cbProcess.Text == "과립")
                {
                    DBWorkOrder += $" AND PC.PROCID = 'PC001' \n";
                }
                if (cbProcess.Text == "타정")
                {
                    DBWorkOrder += $" AND PC.PROCID = 'PC002' \n";
                }
                if (cbProcess.Text == "포장")
                {
                    DBWorkOrder += $" AND PC.PROCID = 'PC003' \n";
                }

                DBWorkOrder += $"ORDER BY WO.PLANDTTM DESC \n";

                //DBWorkOrder += $" GROUP BY WO.WOID \n" +
                //               "  , WO.PRODID \n" +
                //               "  , PD.PRODNAME \n" +
                //               "  , PC.PROCNAME \n";

                //DatabaseManager.OracleConnection(DBWorkOrder, GridView_WorkOrder);
                //databaseManager.stdSearchData(DBWorkOrder, dataGridView1);

                DatabaseManager.DB_Inquiry(DBWorkOrder, WorkGrid);

                // GridView 칼럼명
                string[] HeaderName = new string[] { "작업코드", "계획일자", "생산수량", "계획수량", "작업상태", "제품코드",
                                                     "제품명", "공정코드", "공정명", "작업시작일", "등록자" };


                if (WorkGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < HeaderName.Length; i++)
                    {
                        WorkGrid.Columns[i].HeaderText = $"{HeaderName[i]}";
                        WorkGrid.Columns[i].ReadOnly = true;
                        WorkGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // 빈 레코드 표시 안함
                    WorkGrid.AllowUserToAddRows = false;

                    // 헤더 위치 정렬(가운데)
                    WorkGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SELECT();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbProductID.Text = string.Empty;
            tbProductName.Text = string.Empty;
            tbWorkID.Text = string.Empty;
            cbProcess.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(30);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            WorkInsert workInsert = new WorkInsert();
            if (workInsert.ShowDialog() == DialogResult.Yes)
            {
                SELECT();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //GetChanges 함수 = 값을바꾼다
            //    DataTable DBChanges = new DataTable();
            //    DataTable WORKORDER = (DataTable)WorkGrid.DataSource;
            //    DBChanges = WORKORDER.GetChanges(DataRowState.Modified);

            //    string update_query = string.Empty;

            //    //수정쿼리문
            //    if (DBChanges != null)
            //    {
            //        for (int i = 0; i < DBChanges.Rows.Count; i++)
            //        {
            //            update_query = $"UPDATE WORKORDER SET          \n" +
            //                          $"PRODQTY =      #PRODQTY \n" +
            //                          $",PLANQTY =     #PLANQTY \n" +
            //                          $",PRODID =    '#PRODID' \n" +
            //                          $",PROCID =    '#PROCID' \n" +
            //                          $",INSUSER =    '#INSUSER' \n" +
            //                          $" WHERE WOID = '#WOID'";

            //            //update_query에서 PRODNAME 을 #PRODNAME 으로 Replace한다
            //            update_query = update_query.Replace("#PRODQTY", DBChanges.Rows[i]["PRODQTY"].ToString() == "" ? "NVL(null, PRODQTY)" : DBChanges.Rows[i]["PRODQTY"].ToString());
            //            update_query = update_query.Replace("#PLANQTY", DBChanges.Rows[i]["PLANQTY"].ToString() == "" ? "NVL(null, PLANQTY)" : DBChanges.Rows[i]["PLANQTY"].ToString());
            //            update_query = update_query.Replace("#PRODID", DBChanges.Rows[i]["PRODID"].ToString());
            //            update_query = update_query.Replace("#PROCID", DBChanges.Rows[i]["PROCID"].ToString());
            //            update_query = update_query.Replace("#INSUSER", DBChanges.Rows[i]["INSUSER"].ToString());
            //            update_query = update_query.Replace("#WOID", DBChanges.Rows[i]["WOID"].ToString());

            //            //DBconnection.DB_Connection1(update_query);
            //            databaseManager.stdSearchData(update_query, WorkGrid);

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //SELECT();

            ////Update update = new Update();
            ////update.ShowDialog();

            //DialogResult result = MessageBox.Show("완료되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            WorkDelete workdelete = new WorkDelete();

            try
            {
                if (workdelete.ShowDialog() == DialogResult.Yes)
                {
                    string woID = WorkGrid.CurrentRow.Cells["WOID"].Value.ToString();
                    string delete_query = string.Empty;

                    //수정쿼리문
                    delete_query = $@"UPDATE WORKORDER SET
                                             WOSTAT = 'E'
                                             , DEL_YN = 'Y'
                                       WHERE WOID = '{woID}'
                                      ";

                    //DBconnection.DB_Connection1(delete_query);
                    databaseManager.stdSearchData(delete_query, WorkGrid);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SELECT();
        }

        private void 작업지시_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddDays(30);

            SELECT();

            List<string> Product_TYPE_List = new List<string>()
            {
                "과립",
                "타정",
                "포장"
            };

            // 콤보박스 값 초기화
            LoadCombo(Product_TYPE_List, cbProcess);
        }


        //테이블에서 특정 칼럼 데이터를 가져와 콤보박스에 설정
        private void LoadCombo(List<string> list, ComboBox comboBox)
        {
            if (list.Count >= 0)
            {
                foreach (string item in list)
                {
                    comboBox.Items.Add(item);
                }
            }
            else MessageBox.Show($"비어있는 리스트입니다.");
        }
    }
}
