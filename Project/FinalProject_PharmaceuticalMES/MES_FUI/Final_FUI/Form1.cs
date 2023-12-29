using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Final_FUI
{
    public partial class Form1 : Form
    {
        public static string Selected_woid { get; set; }
        public static string Selected_procid { get; set; }
        public static string Selected_prodid { get; set; }
        public static string Selected_procidP { get; set; }



        private bool isUserIDSet = false;
        public Form1()
        {
            InitializeComponent();
        }

        public void SetUserID(string userID)                // 작업자 ID 가져오기 
        {
            if (!isUserIDSet)
            {
                Console.WriteLine("SetUserID method called with userID: " + userID);
                textBox2.Text = userID;         // 텍스트 박스 2에 로그인 한 유저 아이디 작성 
                isUserIDSet = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 폼로드시 날짜 초기화
            dateTimePicker1.Value = DateTime.Now.AddMonths(-2);
            panel1.Hide();
            comboBox1.SelectedIndex = 0;     // 콤보박스 '전체'로 초기화       
        }
        private void LoadData(string sql)
        {
            dataGridView1.DataSource = null; // 이전 데이터 지우기

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
                            dataGridView1.DataSource = dataTable;

                            // 컬럼명을 한글로 변경
                            string[] header = new string[] {
                        "작업지시ID",
                        "제품코드",
                        "계획수량",
                        "생산수량",
                        "불량수량",
                        "완료수량",
                        "작업하달일",
                        "공정ID",
                        "작업상태"
                    };

                            for (int i = 0; i < header.Length; i++)
                            {
                                dataGridView1.Columns[i].HeaderText = header[i];
                            }
                        }
                    }
                }
            }
        }



        private string GetSelectedValue(string query)    // 행 개수가 하나인 단일값 가져오기 
        {
            string selectedValue = "";

            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // 결과가 있다면
                        {
                            selectedValue = reader[0].ToString(); // 첫 번째 컬럼
                        }
                    }
                }
            }
            return selectedValue;
        }

        private string GetSelectedProcidP(string woidP)    // 다음 작업 공정 ID 
        {
            string selectedProcidP = "";

            using (var conn = DatabaseManager.GetConnection())
            {
                string query = $"SELECT PROCID FROM WORKORDER WHERE WOID = :WoidP";

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Parameters.Add(":WoidP", woidP);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // 결과가 있다면
                        {
                            selectedProcidP = reader["PROCID"].ToString();
                        }
                    }
                }
            }
            return selectedProcidP;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchWO();
        }

        // 칭량 버튼 
        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Selected_prodid = dataGridView1.CurrentRow.Cells["PRODID"].Value.ToString(); // 현재 선택된 작업의 작업지시ID
            원재료조회 원재료조회 = new 원재료조회();
            원재료조회.Show();
            //this.Hide();
            //BOM BOM = new BOM();
            //BOM.Show();
        }

        // 작업종료
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearh_Click(object sender, EventArgs e) // 날짜조회
        {
            SearchWO();
            //SearchWO if문 쓸때 사용해야할 듯 
        }
        private void SearchWO()
        {
            dataGridView1.DataSource = null; // 이전 데이터 지우기
            dataGridView1.Rows.Clear();
            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            // 종료일을 다음날로 늘림
            date2 = date2.AddDays(1);

            string sql1 = $@"SELECT W.WOID,
                           W.PRODID,
                           W.PLANQTY,
                           W.PRODQTY,
                           NVL(SUM((SELECT NVL(SUM(DL.DEFECT_QTY), 0) FROM DEFECTLOT DL WHERE L.LOTID = DL.DEFECT_LOTID)), 0) AS SUM_DEFECT_QTY,
                           NVL(SUM((SELECT NVL(SUM(LT.LOTQTY), 0) FROM LOT LT WHERE W.WOID = LT.WOID)), 0) AS SUM_LOTQTY,
                           W.PLANDTTM,
                           W.PROCID,
                           CASE W.WOSTAT
                               WHEN 'P' THEN '진행중'
                               WHEN 'S' THEN '중지'
                               WHEN 'E' THEN '완료'
                               WHEN 'D' THEN '삭제'
                           END AS WOSTAT
                     FROM WORKORDER W
                     LEFT JOIN LOT L ON W.WOID = L.WOID
                     LEFT JOIN DEFECTLOT DL ON L.LOTID = DL.DEFECT_LOTID
                     WHERE ";

            if (comboBox1.SelectedIndex == 0) // 전체
            {
                sql1 += $"(W.PLANDTTM >= TO_DATE('{date1:yyyy-MM-dd}', 'YYYY-MM-DD') AND W.PLANDTTM < TO_DATE('{date2:yyyy-MM-dd}', 'YYYY-MM-DD') AND (W.PROCID IN ('PC001','PC002','PC003'))) ";
            }
            else if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2) // 칭량 또는 과립
            {
                sql1 += $"(W.PLANDTTM >= TO_DATE('{date1:yyyy-MM-dd}', 'YYYY-MM-DD') AND W.PLANDTTM < TO_DATE('{date2:yyyy-MM-dd}', 'YYYY-MM-DD') AND W.PROCID = 'PC001') ";
            }
            else if (comboBox1.SelectedIndex == 3) // 타정
            {
                sql1 += $"(W.PLANDTTM >= TO_DATE('{date1:yyyy-MM-dd}', 'YYYY-MM-DD') AND W.PLANDTTM < TO_DATE('{date2:yyyy-MM-dd}', 'YYYY-MM-DD') AND W.PROCID = 'PC002') ";
            }
            sql1 += "GROUP BY W.WOID, W.PRODID, W.PLANQTY, W.PRODQTY, W.PLANDTTM, W.PROCID, W.WOSTAT ORDER BY W.WOID";
            LoadData(sql1);
        }


        private void btn_main_Click(object sender, EventArgs e)
        {

            panel1.Hide();
            comboBox1.SelectedIndex = 0; // 콤보박스를 전체로 초기화
            dateTimePicker1.Value = DateTime.Now.Date; // 시작일을 오늘로 초기화
            dateTimePicker2.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1); // 종료일을 내일의 마지막 시간으로 초기화

        }
        private void UpdateWOSTDTTMInDatabase(string formattedTime)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                string updateQuery = $"UPDATE WORKORDER SET WOSTDTTM = TO_TIMESTAMP('{formattedTime}', 'YYYY-MM-DD HH24:MI:SS') WHERE WOID = '{Selected_woid}'";

                using (var cmd = conn.CreateCommand())
                {
                    // 데이터베이스 업데이트 쿼리 실행
                    cmd.CommandText = updateQuery;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Selected_woid = dataGridView1.CurrentRow.Cells["WOID"].Value.ToString(); // 현재 선택된 작업의 작업지시ID
            Selected_procid = dataGridView1.CurrentRow.Cells["PROCID"].Value.ToString(); // 현재 선택된 작업의 공정ID 

            DateTime currentTime = DateTime.Now;
            string formattedTime = currentTime.ToString("yyyy-MM-dd HH:mm:ss");

            // 작업시작 시간 (현재시간) 업데이트
            UpdateWOSTDTTMInDatabase(formattedTime);

            if (Selected_procid == "PC001") // 현재 작업 공정이 칭량 또는 과립인 경우
            {
                string query = $"SELECT PROCID FROM WORKORDER WHERE WOID IN (SELECT WOID_P FROM WORKORDER)"; // 다음 작업지시의 공정ID
                if (GetSelectedValue(query) == "PC001") // 칭량인 경우 (다음 작업 공정이 과립(PCOO1)인 경우)
                {
                    // 원재료 추가 폼을 보여줌
                    과립 과립 = new 과립();
                    과립.Selected_woid = Selected_woid;
                    과립.Show();
                }
                else // 과립인 경우 (다음 작업 공정이 타정(PCOO2)인 경우)
                {
                    과립 form2 = new 과립();
                    form2.Show();
                }
            }
            else if (Selected_procid == "PC002")
            {
                타정 form3 = new 타정();
                form3.Show();
            }
        }

        private void btn_Product_status_Click(object sender, EventArgs e)  // 생산현황 버튼 
        {
            // 판넬 보이기
            panel1.Show();

            // Production_Status 폼 인스턴스 생성
            Production_Status productionStatusForm = new Production_Status();

            productionStatusForm.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            생산일지 생산일지 = new 생산일지();
            생산일지.Show();
            this.Close();
        }
    }
}