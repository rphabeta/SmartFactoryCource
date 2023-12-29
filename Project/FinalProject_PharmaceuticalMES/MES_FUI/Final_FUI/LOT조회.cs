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
    public partial class LOT조회 : Form
    {
        public LOT조회()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // 폼의 시작 위치를 화면 중앙으로 설정

        }

        private void LOT조회_Load(object sender, EventArgs e)
        {
            Store_Check(); // 데이터베이스 조회 메서드 호출

        }
        public void Store_Check()
        {
            string sql = "SELECT * FROM STORE_STORAGE";

            // DatabaseConnection의 GetConnection 메서드를 사용
            using (OracleConnection connection = DatabaseManager.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(sql, connection))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable store_chart = new DataTable();
                        adapter.Fill(store_chart);

                        foreach (DataRow row in store_chart.Rows)
                        {
                            // 각 열의 데이터를 변수에 저장
                            string storId = row["STORID"].ToString();
                            string currQty = row["CURRQTY"] == DBNull.Value ? "0" : row["CURRQTY"].ToString();
                            int maxValue = row["MAXLEVEL"] == DBNull.Value ? 0 : Convert.ToInt32(row["MAXLEVEL"]);
                            int minValue = row["MINLEVEL"] == DBNull.Value ? 0 : Convert.ToInt32(row["MINLEVEL"]);

                            switch (storId)     // storId에 따라 SetSilo 메서드 호출
                            {
                                case "HP001":
                                    SetSilo(solidGauge1, currQty, maxValue, minValue);
                                    break;
                                case "HP002":
                                    SetSilo(solidGauge2, currQty, maxValue, minValue);
                                    break;
                                case "HP003":
                                    SetSilo(solidGauge3, currQty, maxValue, minValue);
                                    break;
                                case "HP004":
                                    SetSilo(solidGauge4, currQty, maxValue, minValue);
                                    break;
                                case "HP005":
                                    SetSilo(solidGauge5, currQty, maxValue, minValue);
                                    break;
                                case "HP006":
                                    SetSilo(solidGauge6, currQty, maxValue, minValue);
                                    break;
                                case "HP007":
                                    SetSilo(solidGauge7, currQty, maxValue, minValue);
                                    break;
                                case "HP008":
                                    SetSilo(solidGauge8, currQty, maxValue, minValue);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            DisableButtons();
        }
        private void DisableButtons()
        {
            if (solidGauge1.Value > 0)
            {
                button1.Enabled = false;
            }
            if (solidGauge2.Value > 0)
            {
                button2.Enabled = false;
            }
            if (solidGauge3.Value > 0)
            {
                button3.Enabled = false;
            }
            if (solidGauge4.Value > 0)
            {
                button4.Enabled = false;
            }
            if (solidGauge5.Value > 0)
            {
                button5.Enabled = false;
            }
            if (solidGauge6.Value > 0)
            {
                button6.Enabled = false;
            }
            if (solidGauge7.Value > 0)
            {
                button7.Enabled = false;
            }
            if (solidGauge8.Value > 0)
            {
                button8.Enabled = false;
            }
        }
        private void SetSilo(LiveCharts.WinForms.SolidGauge SGSilo, string CURRQTY, int MAXLEVEL, int MINLEVEL)
        {
            Console.WriteLine($"CURRQTY: {CURRQTY}, MAXLEVEL: {MAXLEVEL}, MINLEVEL: {MINLEVEL}");
            SGSilo.From = Convert.ToInt32(MINLEVEL);
            SGSilo.To = Convert.ToInt32(MAXLEVEL);
            SGSilo.Value = Convert.ToInt32(CURRQTY);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기 버튼 클릭 시 폼을 닫음
        }



        private void Mtr_Show(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                string buttonName = clickedButton.Text;

                // 전달할 폼을 생성하고 버튼의 이름을 전달
                LOT호퍼추가 HopperAdd = new LOT호퍼추가();
                HopperAdd.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
