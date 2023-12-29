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

namespace Final_FUI
{
    public partial class 로그인 : Form
    {
        public static string userid {  get; set; }
        public 로그인()
        {
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
            InitializeComponent();
            txtPW.PasswordChar = '*'; // 비밀번호를 '*' 문자로 마스킹
        }

        private void 로그인_Load(object sender, EventArgs e)
        {  

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            // sel_login_qry에 쿼리문을 저장
            string sel_login_qry = "SELECT COUNT(*) FROM USERS " +
                "WHERE USERID = :userId AND PASSWD = :password";

            // 데이터베이스 연결 가져오기
            using (var conn = DatabaseManager.GetConnection())
            {
                // 쿼리 실행
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sel_login_qry;
                    // 매개변수 추가
                    cmd.Parameters.Add(":userId", OracleDbType.Varchar2).Value = txtID.Text;
                    cmd.Parameters.Add(":password", OracleDbType.Varchar2).Value = txtPW.Text;

                    // select_ID로 조회된 결과를 data_Table에 return값을 저장함
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        this.Hide();
                        WO_Main main_form = new WO_Main();
                        userid = txtID.Text;
                        main_form.SetUserID(userid); // 사용자 ID를 설정
                        main_form.Show();
                    }
                    else
                    {
                        MessageBox.Show("로그인 정보가 일치하지 않습니다.");
                        txtID.Text = string.Empty;
                        txtPW.Text = string.Empty;
                    }
                }
            }
        }

       

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                // CheckBox의 체크 여부에 따라 PasswordChar 속성을 변경
                if (checkBox1.Checked)
                {
                    txtPW.PasswordChar = '\0'; // '\0'은 마스킹 없음을 나타냄
                }
                else
                {
                    txtPW.PasswordChar = '*'; // '*' 문자로 마스킹
                }
            }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
