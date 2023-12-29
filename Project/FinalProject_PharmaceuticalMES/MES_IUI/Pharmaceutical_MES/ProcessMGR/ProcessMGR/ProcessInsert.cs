using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.ProcessMGR.ProcessMGR
{
    public partial class ProcessInsert : Form
    {
        public ProcessInsert()
        {
            InitializeComponent();
        }

        private void ProcessInsert_Load(object sender, EventArgs e)
        {

        }

       


        private bool checkInsertProcess()
        {
            // 제품코드, 공정코드, 공정순서, 원재료명이 같을 경우 에러 발생.
            string sel_insert_qry = $@"SELECT COUNT(*)
                                       FROM PROCESS   
                                       WHERE  PROCID = '{txtPROC_ID.Text.ToString()}'";


            // select_ID로 조회된 결과를 data_Table에 return값을 저장
            DataTable data_Table = DatabaseManager.DB_Inquiry(sel_insert_qry);

            if (data_Table.Rows[0][0].ToString() == "1")
            {
                return false;
            }

            return true;
        }



     
        private void btnPROC_INSERT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPROC_ID.Text))

            {
                MessageBox.Show("공정코드를 입력해 주세요!");
                txtPROC_ID.Focus();
                return;
            }

            if (!checkInsertProcess())
            {
                MessageBox.Show("이미 존재하는 공정정보입니다.");
                return;
            }

            int SEQ = int.Parse(txtPROCID_SEQ.Text); // 순서
            string PROC_ID = txtPROC_ID.Text; // 공정ID
            string PROC_NAME = txtPROC_NAME.Text; // 공정명


            string processInsert = $@"
                                INSERT INTO PROCESS(PROCID,
                                        PROCNAME,
                                        PROCID_SEQ,
                                        DEL_YN
                                        )
                                VALUES(
                                        '{PROC_ID}'
                                        , '{PROC_NAME}'
                                        , '{SEQ}'
                                        , 'N'
                                        )";


            DatabaseManager.DB_Modify(processInsert);
            DialogResult = DialogResult.Yes;
            MessageBox.Show("공정이 등록 되었습니다.");
            Close();
        }

        private void btnPRO_INSERT_CANCEL_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
