using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.StandardInfoMGR.UserSTD
{
    public partial class UserInsert : Form
    {
        public UserInsert()
        {
            InitializeComponent();
        }

        private bool CHECK_ID()
        {
            // select_query에 쿼리문을 저장
            string check_ID = $"SELECT COUNT(*) FROM USERS WHERE USERID = '"
                + tbID.Text.ToString() + "'";


            // select_ID로 조회된 결과를 data_Table에 return값을 저장
            DataTable data_Table = DatabaseManager.DB_Inquiry(check_ID);

            if (data_Table.Rows[0][0].ToString() == "1")
            {
                return false;
            }

            return true;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbID.Text))
            {
                MessageBox.Show("ID를 입력해 주세요!");
                tbID.Focus();
                return;
            }

            if (!CHECK_ID())
            {
                MessageBox.Show("이미 존재하는 ID입니다.");
                return;
            }

            string uscode = tbID.Text; // ID
            string usname = tbName.Text; // 이름
            string uspw = tbPW.Text; // PW
            string usrole = tbRole.Text; // Role

            string sql = $@"INSERT INTO USERS(USERID,
                                    USERNAME,
                                    PASSWD,
                                    ROLE)
                             VALUES('{uscode}', 
                                    '{usname}',
                                    '{uspw}',
                                    '{usrole}')";

            DatabaseManager.DB_Modify(sql);
            DialogResult = DialogResult.Yes;
            MessageBox.Show("사용자가 등록 되었습니다.");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
