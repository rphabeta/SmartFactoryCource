using Final_FUI;
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
    public partial class BOM : Form
    {
        // WOID와 PRODID 값을 저장할 필드
        private string woid;
        private string prodid;
        private string userid;

        public BOM(string woid, string prodid)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
            this.woid = woid;
            this.prodid = prodid;

            // 데이터베이스에서 제품 이름 가져오기
            string productName = GetProductName(prodid);

            textBox5.Text = productName;
            //textBox1.Text = "";
            textBox2.Text = prodid;
            textBox4.Text = woid;


        }

        private DataTable ExecuteSQL(string sql)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var conn = DatabaseManager.GetConnection())
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        using (var rdr = cmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                dataTable.Load(rdr);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 오류 발생 시 예외를 출력
                Console.WriteLine($"Error executing SQL: {ex.Message}");
            }

            return dataTable;
        }


        private void BOM_Load(object sender, EventArgs e) // 작업 지시에 대해 가장 최근 생성된 LOT에 대한 BOM 실적
        {
            string woker_query = $@"SELECT l.lotid, l.workerid
                                    FROM lot l
                                    WHERE l.woid = '{this.woid}'
                                    AND l.lotid = (SELECT MAX(lotid) FROM lot WHERE woid = '{this.woid}')";
            string workerid = null;

            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = woker_query;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            workerid = reader["WORKERID"].ToString();
                        }
                    }
                }
            }

            if (workerid != null)
            {
                textBox1.Text = workerid;
            }
            string query1 = $@"
                            SELECT 
                            ML.MTRLID
                         , MT.MTRLNAME
                         , ML.ACTDATE
                         , ml.c_qty
                          , LT.LOTID
                         , ML.MLOTID
                         , WO.WOID
                      FROM LOT              LT
                     INNER JOIN WORKORDER   WO  ON LT.WOID = WO.WOID
                     INNER JOIN LOTMATERIAL LM  ON LT.LOTID = LM.LOTID
                     INNER JOIN MATERIALLOT ML  ON LM.MLOTID = ML.MLOTID    
                     INNER JOIN MATERIAL    MT  ON ML.MTRLID = MT.MTRLID  
                    WHERE WO.WOID = '{woid}'      
                      AND LT.LOTID = (SELECT MAX(A.LOTID) 
                                        FROM LOT A 
                                       INNER JOIN LOTMATERIAL B ON A.LOTID = B.LOTID
                                       WHERE WOID = '{woid}')
                    AND ML.MTRLID LIKE 'M___'
                    ORDER BY ML.ACTDATE, ML.MTRLID";
            Grid_Date.ColumnHeadersHeight = 90;
            Grid_Date.RowTemplate.Height = 70;
            LoadData2(query1);

        }

        private void LoadData2(string sql)
        {
            DataTable dataTable = ExecuteSQL(sql);

            if (dataTable.Rows.Count > 0)
            {
                Grid_Date.DataSource = dataTable;

                // 컬럼명을 한글로 변경
                string[] header = new string[] {
                                    "투입자재ID",
                                    "원재료명",
                                    "투입시간",
                                    "투입량",
                                    "LOTID",
                                    "MLOTID",
                                    "작업지시ID"
                };

                for (int i = 0; i < header.Length && i < Grid_Date.Columns.Count; i++)
                {
                    Grid_Date.Columns[i].HeaderText = header[i];
                }
            }
        }
        private string GetProductName(string prodid)
        {
            string productName = "";

            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT PRODNAME FROM PRODUCT WHERE PRODID = '{prodid}'";
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        productName = result.ToString();
                    }
                }
            }

            return productName;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
