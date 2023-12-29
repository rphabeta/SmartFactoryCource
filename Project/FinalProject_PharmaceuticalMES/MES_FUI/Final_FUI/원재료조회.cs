using Bunifu.UI.WinForms.BunifuButton;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Final_FUI
{
    public partial class 원재료조회 : Form
    {
        public string currqty;
        public static string woid;
        public static string procid;
        public static string prodid;
        public static BunifuButton2 clickedButton;
        public static string eqptid = "";

        public 원재료조회(string EQPTID = "", string PRODID = "", string PROCID = "", string WOID = "")
        {
            InitializeComponent();
            원재료조회.eqptid = EQPTID;
            원재료조회.prodid = PRODID;
            원재료조회.procid = PROCID;
            원재료조회.woid = WOID;
            this.StartPosition = FormStartPosition.CenterScreen; // 폼의 시작 위치를 화면 중앙으로 설정
        }

        private void 원재료조회_Load(object sender, EventArgs e)
        {
            Store_Check(); // 데이터베이스 조회 메서드 호출
        }

        public void Store_Check()
        {
            //string sql = "select * from store_storage where CURRQTY = 0 and eqptid is null";
            string sql = "select * from store_storage ";


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
                                    SetLabel(label1, storId);
                                    break;
                                case "HP002":
                                    SetSilo(solidGauge2, currQty, maxValue, minValue);
                                    SetLabel(label2, storId);
                                    break;
                                case "HP003":
                                    SetSilo(solidGauge3, currQty, maxValue, minValue);
                                    SetLabel(label3, storId);
                                    break;
                                case "HP004":
                                    SetSilo(solidGauge4, currQty, maxValue, minValue);
                                    SetLabel(label4, storId);
                                    break;
                                case "HP005":
                                    SetSilo(solidGauge5, currQty, maxValue, minValue);
                                    SetLabel(label5, storId);
                                    break;
                                case "HP006":
                                    SetSilo(solidGauge6, currQty, maxValue, minValue);
                                    SetLabel(label6, storId);
                                    break;
                                case "HP007":
                                    SetSilo(solidGauge7, currQty, maxValue, minValue);
                                    SetLabel(label7, storId);
                                    break;
                                case "HP008":
                                    SetSilo(solidGauge8, currQty, maxValue, minValue);
                                    SetLabel(label8, storId);
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

        private void SetSilo(LiveCharts.WinForms.SolidGauge SGSilo, string CURRQTY, int MAXLEVEL, int MINLEVEL)
        {
            SGSilo.From = Convert.ToInt32(MINLEVEL);
            SGSilo.To = Convert.ToInt32(MAXLEVEL);
            SGSilo.Value = Convert.ToInt32(CURRQTY);
        }
        private void DisableButtons() // 칭량
        {
            string hp_enable_query = $@"SELECT STORID 
                                        , CASE WHEN NVL(CURRQTY, 0) = 0 AND NVL(EQPTID, ' ' ) = ' ' THEN NULL 
                                               WHEN NVL(CURRQTY, 0) > 0 AND EQPTID IS NULL THEN 'PC001'
                                               WHEN NVL(CURRQTY, 0) > 0 AND EQPTID IN 
                                                       (SELECT EQPTID FROM EQUIPMENT WHERE EQPTGRID = 'GR000') THEN 'PC002'
                                               WHEN NVL(CURRQTY, 0) > 0 AND EQPTID IN 
                                                       (SELECT EQPTID FROM EQUIPMENT WHERE EQPTGRID = 'CP000') THEN 'PC003' 
                                               END AS PROCID
                                  FROM STORE_STORAGE ORDER BY STORID";

            using (OracleConnection connection = DatabaseManager.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(hp_enable_query, connection))
                {
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt_storage = new DataTable();
                        adapter.Fill(dt_storage);

                        Bunifu.UI.WinForms.BunifuButton.BunifuButton2[] buttons = { button1 ,button2, button3, button4, button5, button6, button7, button8};
                        int index = 0;
                        foreach (DataRow row in dt_storage.Rows)
                        {
                            // 각 열의 데이터를 변수에 저장
                            string procid = row["PROCID"].ToString();
                            string storid = row["STORID"].ToString();

                            buttons[index].Enabled = false;

                            buttons[index].Enabled = (procid == 원재료조회.procid);
                            

                            index++;
                            
                        }
                    }
                }
            }
            
        }

        private void SetLabel(Label label, string storId)
        {
            // 호퍼에 해당하는 eqptid, currqty 조회
            string eqptidQuery = $"SELECT EQPTID, CURRQTY FROM STORE_STORAGE WHERE STORID = '{storId}'";

            using (OracleConnection connection = DatabaseManager.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(eqptidQuery, connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string eqptid = reader["EQPTID"].ToString();
                            double currqty = Convert.ToDouble(reader["CURRQTY"]);
                            if (eqptid != "")
                            {
                                if (eqptid.StartsWith("CP"))
                                {
                                    label.Text = "타정 완료";
                                }
                                else if (eqptid.StartsWith("GR"))
                                {
                                    label.Text = "과립 완료";
                                }
                            }
                            else
                            {
                                if (currqty > 0)
                                {
                                    label.Text = "칭량 완료";
                                }
                            }
                        }
                    }
                }
            }
        }
        public void label_update()
        {
            char lastCharacter = clickedButton.Text.Last();
            string labelName = "label" + lastCharacter;
            Label targetLabel = Controls.Find(labelName, true).FirstOrDefault() as Label;

            // 라벨이 존재하면 작업 수행
            if (targetLabel != null)
            {
                targetLabel.Visible = true;
                targetLabel.Text = 원재료조회.procid;
            }
        }

        private void Mtr_Show(object sender, EventArgs e)
        {
            string hp_id = "";
            string currqty = "";
            clickedButton = sender as BunifuButton2;
            if (clickedButton != null)
            {
                string hp_name = clickedButton.Text;

                switch (hp_name)     // storId에 따라 SetSilo 메서드 호출
                {
                    case "이동식 호퍼 #1":
                        hp_id = "HP001";
                        break;
                    case "이동식 호퍼 #2":
                        hp_id = "HP002";
                        break;
                    case "이동식 호퍼 #3":
                        hp_id = "HP003";
                        break;
                    case "이동식 호퍼 #4":
                        hp_id = "HP004";
                        break;
                    case "이동식 호퍼 #5":
                        hp_id = "HP005";
                        break;
                    case "이동식 호퍼 #6":
                        hp_id = "HP006";
                        break;
                    case "이동식 호퍼 #7":
                        hp_id = "HP007";
                        break;
                    case "이동식 호퍼 #8":
                        hp_id = "HP008";
                        break;
                    default:
                        break;
                }
            }
           
            //this.Close();
            //설비ID가 있으면 공정애니메니션 => 설비선택 안하고 LOT추가
            if (!string.IsNullOrEmpty(원재료조회.eqptid))
            {
                LOT호퍼추가 LOT호퍼추가 = new LOT호퍼추가(hp_id, 원재료조회.eqptid, 원재료조회.procid, 원재료조회.prodid, 원재료조회.woid, true);
                LOT호퍼추가.Show();
            }
            else // 설비ID가 없으면 설비선택 하고 LOT추가
            {
                //공정 ID가 없으면 칭량
                if (string.IsNullOrEmpty(원재료조회.procid))
                {
                    
                    원재료추가 원재료추가 = new 원재료추가(hp_id, 원재료조회.prodid, 원재료조회.woid);
                    원재료추가.Show();
                }
                else //공정 ID가 있으면 과립, 타정, 포장 => LOT 추가
                {
                    // 새로운 Lot추가 폼을 생성하고 보여줌
                    LOT추가 lotForm = new LOT추가(원재료조회.eqptid, 원재료조회.procid, 원재료조회.prodid, hp_id, 원재료조회.woid);
                    lotForm.Show();
                    Store_Check();
                }
               
            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기 버튼 클릭 시 폼을 닫음
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}