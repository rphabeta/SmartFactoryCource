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
        string query = $@"SELECT b.PRODNAME 제품명, 
                                 c.PROCNAME 공정명, 
                                 d.EQPTNAME 설비명, 
                                 a.PLANQTY 지시수량, 
                                 e.WORKERID 작업자ID, 
                                 a.WOID 지시번호, 
                                 a.WOSTDTTM 지시일정, 
                                 e.LOTID LOT_ID, 
                                 a.INSUSER 작업지시자, 
                                 a.WOSTAT 처리상태 
                        FROM WORKORDER a 
                        JOIN PRODUCT b               
                               ON a.PRODID = b.PRODID
                        JOIN PROCESS c               
                               ON a.PROCID = c.PROCID
                        JOIN EQUIPMENT d             
                               ON a.PROCID = d.PROCID
                        LEFT JOIN LOT e              
                               ON d.EQPTID = e.EQPTID";

        DatabaseManager databaseManager = new DatabaseManager();

        public 작업지시()
        {
            InitializeComponent();

            //databaseManager.stdSearchData(query, dataGridView1);
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
                       AND WO.PLANDTTM <= to_date('{dateTimePicker2.Value.Year}/{dateTimePicker2.Value.Month}/{dateTimePicker2.Value.Day}') + 1";


            try
            {
                dataGridView1.DataSource = databaseManager;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    string PRODID = textBox1.Text;
                    DBWorkOrder += $" AND WO.PRODID LIKE '%{PRODID.ToUpper()}%' \n";
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    string WOID = textBox3.Text;
                    DBWorkOrder += $" AND WO.WOID LIKE '%{WOID.ToUpper()}%' \n";
                }
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    string PRODNAME = textBox2.Text;
                    DBWorkOrder += $"AND PD.PRODNAME LIKE '%{PRODNAME}%' \n";
                }
                if (comboBox1.SelectedItem.ToString() == "1차분쇄")
                {
                    DBWorkOrder += $" AND PC.PROCID = 'C1' \n";
                }
                if (comboBox1.SelectedItem.ToString() == "2차분쇄")
                {
                    DBWorkOrder += $" AND PC.PROCID = 'C2' \n";
                }

                DBWorkOrder += $"ORDER BY WO.PLANDTTM DESC \n";

                //DBWorkOrder += $" GROUP BY WO.WOID \n" +
                //               "  , WO.PRODID \n" +
                //               "  , PD.PRODNAME \n" +
                //               "  , PC.PROCNAME \n";

                //DatabaseManager.OracleConnection(DBWorkOrder, GridView_WorkOrder);
                databaseManager.stdSearchData(query, dataGridView1);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SELECT();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            comboBox1.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkInsert workInsert = new WorkInsert();
            if (workInsert.ShowDialog() == DialogResult.Yes)
            {
                SELECT();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //GetChanges 함수 = 값을바꾼다
                DataTable DBChanges = new DataTable();
                DataTable WORKORDER = (DataTable)dataGridView1.DataSource;
                DBChanges = WORKORDER.GetChanges(DataRowState.Modified);

                string update_query = string.Empty;

                //수정쿼리문
                if (DBChanges != null)
                {
                    for (int i = 0; i < DBChanges.Rows.Count; i++)
                    {
                        update_query = $"UPDATE WORKORDER SET          \n" +
                                      $"PRODQTY =      #PRODQTY \n" +
                                      $",PLANQTY =     #PLANQTY \n" +
                                      $",PRODID =    '#PRODID' \n" +
                                      $",PROCID =    '#PROCID' \n" +
                                      $",INSUSER =    '#INSUSER' \n" +
                                      $" WHERE WOID = '#WOID'";

                        //update_query에서 PRODNAME 을 #PRODNAME 으로 Replace한다
                        update_query = update_query.Replace("#PRODQTY", DBChanges.Rows[i]["PRODQTY"].ToString() == "" ? "NVL(null, PRODQTY)" : DBChanges.Rows[i]["PRODQTY"].ToString());
                        update_query = update_query.Replace("#PLANQTY", DBChanges.Rows[i]["PLANQTY"].ToString() == "" ? "NVL(null, PLANQTY)" : DBChanges.Rows[i]["PLANQTY"].ToString());
                        update_query = update_query.Replace("#PRODID", DBChanges.Rows[i]["PRODID"].ToString());
                        update_query = update_query.Replace("#PROCID", DBChanges.Rows[i]["PROCID"].ToString());
                        update_query = update_query.Replace("#INSUSER", DBChanges.Rows[i]["INSUSER"].ToString());
                        update_query = update_query.Replace("#WOID", DBChanges.Rows[i]["WOID"].ToString());

                        //DBconnection.DB_Connection1(update_query);
                        databaseManager.stdSearchData(query, dataGridView1);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SELECT();

            //Update update = new Update();
            //update.ShowDialog();

            DialogResult result = MessageBox.Show("완료되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string delete_query = string.Empty;

                //수정쿼리문                        
                delete_query = $"UPDATE WORKORDER SET          \n" +
                                      $"WOSTAT= 'E'\n" +
                                      $"WHERE WOID = '" + dataGridView1.CurrentRow.Cells["WOID"].Value.ToString() + "'";

                //DBconnection.DB_Connection1(delete_query);
                databaseManager.stdSearchData(query, dataGridView1);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            WorkDelete workdelete = new WorkDelete();
            workdelete.ShowDialog();

            SELECT();
        }
    }
}
