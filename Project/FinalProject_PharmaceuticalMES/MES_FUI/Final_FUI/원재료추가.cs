
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace Final_FUI
{
    public partial class 원재료추가 : Form
    {
        public static string WOID;
        public static string HPID;
        public static string PRODID;
        public static string materialName;
        public static string materialId;
        public static double rate;
        public static string eqpt_id; //설비 아이디
        public static string hp_name;  //이동식호퍼 이름 가져오기.
        public static List<(string mtrId, double mtrQty)> mtrList;
        public static string Selected_woid { get; set; }

        public 원재료추가(string hpid = "", string prodid = "", string woid = "")
        {
            InitializeComponent();
            원재료추가.HPID = hpid;
            원재료추가.PRODID = prodid;
            원재료추가.WOID = woid;  
            this.StartPosition = FormStartPosition.CenterScreen;
            mtrList = new List<(string mtrId, double mtrQty)>(); 
        }
        private void Hp_Update()
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var transaction = conn.BeginTransaction()) // 트랜잭션 시작
                {
                    string updateSql = $"UPDATE STORE_STORAGE SET CURRQTY = {int.Parse(textBox13.Text)} WHERE STORID = '{원재료추가.HPID}'";

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = transaction; // 커맨드에 트랜잭션 설정

                        // 데이터베이스 업데이트 쿼리 실행
                        cmd.CommandText = updateSql;
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit(); // 변경사항 커밋
                }
            }
        }
    
        private void LoadBOMData(int qty)
        {
            double mtrlQty = 0;
            using (var conn = DatabaseManager.GetConnection())
            {
                string select = $@"
            SELECT M.MTRLID, M.MTRLNAME, B.RATE
            FROM MATERIAL M
            JOIN BOM B ON M.MTRLID = B.MTRLID
            WHERE B.PRODID = '{원재료추가.PRODID}' AND B.RATE < 1";

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = select;

                    using (var reader = cmd.ExecuteReader())
                    {
                        Label[] labels = this.Controls.OfType<Label>()
                                                .Where(lbl => lbl.Name.StartsWith("label"))
                                                .OrderBy(lbl => int.Parse(lbl.Name.Substring(5)))
                                                .ToArray();

                        // textBox 배열에 폼에 있는 textBox 컨트롤을 찾아 할당
                        TextBox[] textBoxes = this.Controls.OfType<TextBox>()
                                                      .Where(tb => tb.Name.StartsWith("textBox"))
                                                      .OrderBy(tb => int.Parse(tb.Name.Substring(7)))
                                                      .ToArray();
                        while (reader.Read())
                        {
                            materialId = reader["MTRLID"].ToString();
                            materialName = reader["MTRLNAME"].ToString();
                            rate = Convert.ToDouble(reader["RATE"]);
                            mtrlQty = rate * qty;
                            mtrList.Add((materialId, mtrlQty));

                            // materialName 값과 일치하는 label을 찾아서 값을 할당
                            Label matchedLabel = labels.FirstOrDefault(lbl => lbl.Text == materialName);
                            if (matchedLabel != null)
                            {
                                int labelNumber = int.Parse(matchedLabel.Name.Substring(5)); // label의 숫자 부분 추출
                                TextBox matchedTextBox = this.Controls.Find($"textBox{labelNumber}", true).FirstOrDefault() as TextBox;

                                if (matchedTextBox != null)
                                {
                                    matchedTextBox.Text = mtrlQty.ToString(); // textBox의 Text를 rate로 설정
                                }
                            }
                        }
                    }
                }
            }
        }

        private void 원재료추가_Load(object sender, EventArgs e)
        {
            // 폼 로드 시 수행할 작업 추가
            textBox13.Text = "";
        }

        //추가 버튼

        private void button1_Click(object sender, EventArgs e)
        {
            Hp_Update();

            this.Close(); 
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is 원재료조회)
                {
                    openForm.Close();
                    break; // 원재료조회 폼이 여러 개 열려있지 않도록 하려면 break를 사용합니다.
                }
            }

            원재료조회 원재료조회 = new 원재료조회(null, 원재료추가.PRODID, "", 원재료추가.WOID);
            원재료조회.label_update();
            원재료조회.Show();
        }

 

       

        private void button2_Click(object sender, EventArgs e)
        {
            int qty = int.Parse(textBox13.Text);
            LoadBOMData(qty);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}