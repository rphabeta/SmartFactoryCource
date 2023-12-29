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

namespace Pharmaceutical_MES
{
    // ID: tbId, 이름: tbName, 비밀번호: tbPW, 권한: tbRole, 등록: btnRegist, 취소: btnCancel
    public partial class UserModify : Form
    {
        DatabaseManager databaseManager = new DatabaseManager();
        public UserModify()
        {
            InitializeComponent();
        }

        // ID: tbId, 이름: tbName, 비밀번호: tbPW, 등록: btnRegist, 취소: btnCancel
        public UserModify(DataGridViewRow selectedRow)
        {
            InitializeComponent();
            // ID는 변경될 수 없음
            tbId.ReadOnly = true;
            tbName.ReadOnly = true;

            // 선택된 행의 값 초기 세팅
            tbId.Text = selectedRow.Cells["USERID"].Value.ToString();
            tbName.Text = selectedRow.Cells["USERNAME"].Value.ToString();
            //tbPW.Text = selectedRow.Cells["PASSWD"].Value.ToString();
            tbRole.Text = selectedRow.Cells["ROLE"].Value.ToString();

            // 선택된 사용자의 비밀번호 가져오기
            string userID = selectedRow.Cells["USERID"].Value.ToString();
            string query = $"SELECT PASSWD FROM USERS WHERE USERID = '{userID}'";

            //try
            //{
            //    using (OracleCommand command = new OracleCommand(query))
            //    {
            //        object result = command.ExecuteScalar();

            //        if (result != null)
            //        {
            //            // 비밀번호가 null이 아닌 경우 텍스트박스에 설정
            //            //tbPW.Text = result.ToString();
            //            string password = result.ToString();
            //            tbPW.Text = password;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"비밀번호 조회 중 오류 발생: {ex.Message}");
            //}



            //object result = DatabaseManager.DB_Inquiry(query);

            //tbPW.Text = result.ToString();

            //try
            //{
            //    //OracleCommand result = new OracleCommand(query);
            //    object result = DatabaseManager.DB_Scalar(query);

            //    if (result != null)
            //    {
            //        // 비밀번호가 null이 아닌 경우 텍스트박스에 설정
            //        tbPW.Text = result.ToString();
            //    }
            //    else
            //    {
            //        // 비밀번호가 null인 경우 또는 사용자를 찾을 수 없는 경우 처리
            //        tbPW.Text = string.Empty;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"비밀번호 조회 중 오류 발생: {ex.Message}");
            //}



            //try
            //{
            //    tbPW.Text = selectedRow.Cells["PASSWD"].Value.ToString();
            //}
            //catch (Exception ex)
            //{
            //    // PASSWD 컬럼이 없을 때의 예외 처리
            //    tbPW.Text = string.Empty;
            //}

            //// tbPW 텍스트박스에 PasswordValue 설정
            //tbPW.Text = tbPW.Text;

        }

        // 선택된 셀에서의 사용자 정보 수정


        private void btnModify_Click(object sender, EventArgs e)
        {
            //tbPW.Text = dgvUserData.CurrentRow.Cells["USERID"].Value.ToString();

            string userIDToUpdate = tbId.Text;  // 수정할 레코드의 USERID
            string name = tbName.Text;
            string pwd = tbPW.Text;
            string role = tbRole.Text;

            // SQL 쿼리 작성
            try
            {
                if (string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("빈칸이 있습니다.");
                }
                else
                {
                    string query = $@"UPDATE USERS SET 
                                         USERNAME = '{name}'
                                         , PASSWD = '{pwd}'
                                         , ROLE = '{role}'
                                  WHERE USERID = '{userIDToUpdate}'";
                    DatabaseManager.DB_Modify(query);
                    DialogResult = DialogResult.Yes;
                    MessageBox.Show("수정을 완료했습니다.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("올바른 값을 입력해주세요!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
