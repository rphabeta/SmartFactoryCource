using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_FUI  
{
    public partial class 불량조회 : Form
    {
        private static string woid { get; set; }
        string[] def_Search_Colums =
        {
            "불량LOT",
            "불량수량",
            "불량발생시간",
            "등록자",
            "불량요인ID"
        };

        public 불량조회(string WOID)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            불량조회.woid = WOID;
        }

        private void 불량조회_Load(object sender, EventArgs e)
        {
            LoadData($@"SELECT DEFECT_LOTID, DEFECT_QTY, DEFECT_DTTM, DEFECT_INSPECTOR, DEFECTID
                        FROM defectlot
                        WHERE DEFECT_LOTID IN (SELECT LOTID FROM LOT WHERE WOID = '{불량조회.woid}')
                        ", def_Search_Colums, DEF_Search_Grid);
        }

        private void LoadData(string sql, string[] header, DataGridView dataGridView)           // LoadData 데이터 불러오기 
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
                            DataTable dataTable = new DataTable();
                            dataTable.Load(rdr);
                            dataGridView.DataSource = dataTable;

                            for (int i = 0; i < header.Length && i < dataGridView.Columns.Count; i++)
                            {
                                dataGridView.Columns[i].HeaderText = header[i];
                            }
                        }
                    }
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)   //나가기 버튼 
        {
            this.Close();
        }


    }
}