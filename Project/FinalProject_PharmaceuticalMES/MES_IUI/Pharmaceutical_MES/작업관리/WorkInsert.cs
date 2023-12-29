using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewPage.작업관리
{
    public partial class WorkInsert : Form
    {
        public string PROCESSID { get; set; }
        public string WOID { get; set; }

        DatabaseManager databaseManager = new DatabaseManager();
        public WorkInsert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //조회 버튼
        {
            string ProductName = textBox1.Text;
            string DB_Product = $"select PRODID, PRODNAME from product where prodname like '%{ProductName}%'";
            databaseManager.stdSearchData(DB_Product, dataGridView2);
        }

        private void button2_Click(object sender, EventArgs e) //추가 버튼
        {
            string sel_product_qry = $"select count(*) from  product " +
                $"where PRODNAME = '" + textBox5.Text + "' and PRODID='" + textBox2.Text + "'";

            DataTable select_Table = new DataTable();
            databaseManager.stdSearchData(sel_product_qry, dataGridView1);

            if (select_Table.Rows.Count > 0)
            {
                if (
                string.IsNullOrEmpty(textBox4.Text) || //ProductName2_txt
                string.IsNullOrEmpty(textBox2.Text) || //ProductID_txt
                string.IsNullOrEmpty(dateTimePicker1.Text) || //dateTimePicker1
                string.IsNullOrEmpty(textBox3.Text) || //QTY_txt
                string.IsNullOrEmpty(textBox5.Text) || //INSUSER_txt
                string.IsNullOrEmpty(comboBox1.SelectedItem.ToString()) || //PROC_Combo
                string.IsNullOrEmpty(dateTimePicker1.Value.ToString())) //dateTimePicker1
                {
                    MessageBox.Show("필수 값이 누락 되었습니다.");
                    return;
                }

                //string[] row0 = { "ProductName2_txt.Text.", "ProductID_txt.Text"," "}; 함수로 써서 넣어도댐
                dataGridView1.Rows.Add(textBox4.Text //ProductName2_txt
                                   , textBox2.Text //ProductID_txt
                                   , dateTimePicker1.Text //dateTimePicker1
                                   , textBox3.Text //QTY_txt
                                   , comboBox1.SelectedItem.ToString() //PROC_Combo
                                   , textBox5.Text //INSUSER_txt
                                    , dateTimePicker1.Value.Year.ToString() + "/" + dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString());

            }

            else
            {
                MessageBox.Show("제품명, 제품코드가 다릅니다.");
                textBox4.Text = string.Empty; //ProductName2_txt
                textBox2.Text = string.Empty; //ProductID_txt
            }
        }

        private void button3_Click(object sender, EventArgs e) //등록 버튼
        {
            try
            {
                // 그리드가 가지는 행의 개수 COUNT
                // MessageBox.Show(WOPRODGRID2.Rows.Count.ToString());
                string insert_query = string.Empty;
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (comboBox1.SelectedItem.ToString() == "1차 분쇄") //PROC_Combo
                        {
                            PROCESSID = "'C1'";
                            WOID = "'WC1'||ZBF_GET_WM('now')";
                        }
                        else if (comboBox1.SelectedItem.ToString() == "2차 분쇄")
                        {
                            PROCESSID = "'C2'";
                            WOID = "'WC2'||ZBF_GET_WI('now')";
                        }


                        insert_query = $"INSERT INTO WORKORDER(" +
                                            $"WOID          " +
                                            $",WOSTAT       " +
                                            $",PLANDTTM     " +
                                            $",PRODID       " +
                                            $",PLANQTY      " +
                                            $",INSUSER      " +
                                            $",PROCID       " +
                                            $")             " +

                                       $"VALUES( \n         " +
                                            $" " + WOID + "\n" +
                                            $",'P'  \n" +
                                            $",SYSDATE    \n" +
                                            $",'#PRODID' \n" +
                                            $", '#PLANQTY' \n" +
                                            $",'#INSUSER' \n" +
                                            $"," + PROCESSID + " \n" +
                                            $")";

                        if (dataGridView1.Rows[i].Cells["PRODID"].Value == null) { continue; }
                        insert_query = insert_query.Replace("#PRODID", dataGridView1.Rows[i].Cells["PRODID"].Value.ToString());
                        insert_query = insert_query.Replace("#PLANQTY", dataGridView1.Rows[i].Cells["PLANQTY"].Value.ToString());
                        insert_query = insert_query.Replace("#INSUSER", dataGridView1.Rows[i].Cells["INSUSER"].Value.ToString());

                        //DBconnection.DB_Connection1(insert_query);
                        databaseManager.stdSearchData(insert_query, dataGridView1);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DialogResult = DialogResult.Yes;


            //Update save = new Update();
            //save.ShowDialog();

            //메세지 창 팝업
            DialogResult result = MessageBox.Show("완료되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Close();
            }

            Close();
        }

        private void button4_Click(object sender, EventArgs e) //취소 버튼
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
