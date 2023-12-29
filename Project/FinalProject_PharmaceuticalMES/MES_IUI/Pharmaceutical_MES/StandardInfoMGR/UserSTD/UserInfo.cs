using Pharmaceutical_MES.StandardInfoMGR.UserSTD;
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
    public partial class UserInfo : Form
    {
        // 입사일: dtpStartEmp, dtpEndEmp
        // 이름: tbName, 조회: btnEnquire, 리셋: btnReset
        // 그리드 뷰: dgvUserData
        // 수정: btnModify, 삭제: btnNewUser

        string query = $@"SELECT USERID, USERNAME, ROLE
                          FROM USERS ";
        DatabaseManager databaseManager = new DatabaseManager();

        public UserInfo()
        {
            InitializeComponent();
            query += $@"ORDER BY USERID";
            databaseManager.stdSearchData(query, dgvUserData); // 초기 전체 정보 조회


            string[] HeaderName = new string[] { "사용자 ID", "사용자 이름", "역할" };

            if (dgvUserData.Rows.Count > 0)
            {
                for (int i = 0; i < HeaderName.Length; i++)
                {
                    dgvUserData.Columns[i].HeaderText = $"{HeaderName[i]}";
                    dgvUserData.Columns[i].ReadOnly = true;
                    dgvUserData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                dgvUserData.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                dgvUserData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        // 사용자 조회 리셋
        //private void btnReset_Click(object sender, EventArgs e)
        //{
        //    query = "SELECT USERID, USERNAME, ROLE " +
        //               "FROM USERS;";
        //    databaseManager.stdSearchData(query, dgvUserData);
        //}

        // 전체조회 
        //private void btnSearchAll_Click(object sender, EventArgs e)
        //{

        //}

        // 추가
        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserInsert userinsert = new UserInsert();
            userinsert.ShowDialog();
            databaseManager.stdSearchData(query, dgvUserData);
        }

        // 삭제
        private void btnDel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string delete_user = dgvUserData.CurrentRow.Cells["USERID"].Value.ToString();

            //    using (SqlCommand command = new SqlCommand())
            //    {
            //        command.Connection = connection;
            //        command.CommandText = $@"DELETE FROM USERS
            //                            WHERE USERID = '{delete_user}'";

            //        // DELETE 쿼리 실행
            //        int rowsAffected = command.ExecuteNonQuery();

            //        // rowsAffected 값으로 성공적으로 삭제되었는지 확인 가능
            //        if (rowsAffected > 0)
            //        {
            //            MessageBox.Show("사용자가 성공적으로 삭제되었습니다.");
            //        }
            //        else
            //        {
            //            MessageBox.Show("삭제에 실패했습니다.");
            //        }
            //    }
            //    databaseManager.stdSearchData(delete_user, dgvUserData);
            //}
            try
            {
                DataGridViewRow selectedRow = dgvUserData.CurrentRow;

                if (selectedRow != null)
                {
                    string deleteUserId = selectedRow.Cells["USERID"].Value.ToString();
                    string deleteQuery = $@"DELETE FROM USERS
                                            WHERE USERID = '{deleteUserId}'";

                    // Assuming DatabaseManager has a method ExecuteQuery or similar
                    DatabaseManager.DB_Modify(deleteQuery);

                    // Refresh the DataGridView to reflect the changes
                    databaseManager.stdSearchData(deleteQuery, dgvUserData);

                    MessageBox.Show("사용자가 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("선택된 행이 없습니다.");
                }

                //dgvUserData.Focus();
                //string delete = dgvUserData.CurrentRow.Cells["USERID"].Value.ToString();
                //string delete_user = $@"DELETE FROM USERS
                //                        WHERE USERID = '{delete}'";

                //// 이미 생성된 databaseManager를 통해 직접 DELETE 쿼리 실행
                ////databaseManager.ExecuteQuery(delete_user);
                //databaseManager.stdSearchData(delete_user, dgvUserData);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            databaseManager.stdSearchData(query, dgvUserData);
        }

        // 사용자 정보 수정
        private void btnModify_Click(object sender, EventArgs e)
        {
            // 선택된 행을 가져옴
            DataGridViewRow selectedRow = dgvUserData.CurrentRow;

            if (selectedRow != null)
            {
                // 팝업 폼 열기
                using (UserModify userModify = new UserModify(selectedRow))
                {
                    userModify.ShowDialog(); // Modal 창
                }
            }
            databaseManager.stdSearchData(query, dgvUserData);
        }


        // 조건 검색
        private void btnEnquire_Click(object sender, EventArgs e)
        {
            string userinfo = $@"SELECT USERID, USERNAME, ROLE 
                                    FROM USERS
                                    WHERE 1=1";
            try
            {
                if (!string.IsNullOrEmpty(txtUSER_ID.Text))
                {
                    string USERID = txtUSER_ID.Text;
                    userinfo += $" AND USERID LIKE '%{USERID}%' \n";
                }
                else if (!string.IsNullOrEmpty(txtUSER_NAME.Text))
                {
                    string USERNAME = txtUSER_NAME.Text;
                    userinfo += $" AND USERNAME LIKE '%{USERNAME}%' \n";
                }
                // 이름 + ID 미입력
                //if (string.IsNullOrEmpty(txtUSER_ID.Text) && string.IsNullOrEmpty(txtUSER_NAME.Text))
                //{
                //    databaseManager.stdSearchData(userinfo, dgvUserData);
                //}
                userinfo += $@"ORDER BY USERID";
                databaseManager.stdSearchData(userinfo, dgvUserData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        // 리셋
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUSER_NAME.Text = string.Empty;
            txtUSER_ID.Text = string.Empty;
        }
    }
}