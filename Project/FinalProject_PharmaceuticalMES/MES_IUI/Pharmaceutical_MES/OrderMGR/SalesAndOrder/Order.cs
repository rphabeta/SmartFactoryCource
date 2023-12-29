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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }
        public Order(string selectedMTRLValue)
        {
            InitializeComponent();
            tbMaterialName.ReadOnly = true;
            tbMaterialName.Text = selectedMTRLValue;
        }

        // 발주코드: tbOrderId, 원재료명: tbMaterialName, 발주수량: tbOrderQTY
        private void btnOrder_Click(object sender, EventArgs e)
        {
            int orderCode = Convert.ToInt32(tbOrderId.Text);
            string MTRLName = tbMaterialName.Text; 
            int OrderQTY = Convert.ToInt32(tbOrderQTY.Text);
            
            // order에대한 정보 받아서 데이터베이스에 업데이트 하면 되겠네.
            try
            {
                using(var conn = DatabaseManager.GetConnection()) 
                {
                    string query = $@"
                                INSERT INTO PORDER (PORDID, MTRLID, PORDQTY)
                                VALUES (
                                          :orderCode,
                                          :MTRLName,
                                          :orderQTY
                                        )";

                    using (var cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter(":orderCode", OracleDbType.Int32)).Value = orderCode;
                        cmd.Parameters.Add(new OracleParameter(":MTRLName", OracleDbType.Varchar2)).Value = MTRLName;
                        cmd.Parameters.Add(new OracleParameter(":orderQTY", OracleDbType.Int32)).Value = OrderQTY;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("새로운 제품 추가 성공");
                        }
                        else
                        {
                            MessageBox.Show("새로운 제품 추가 실패");
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                // 에러 처리
                MessageBox.Show("새로운 제품 추가 실패: " + ex.Message);
            }
        }

                                

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
