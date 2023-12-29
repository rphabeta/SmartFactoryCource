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
    public partial class LOT_삭제 : Form
    {
      
        public static string lotid ="";
        
        public LOT_삭제()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; //중간에 오게! 
        }
   
        private void Lot_Delete()
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                string updateQuery = $"UPDATE LOT SET LOTSTAT= 'D' WHERE LOTID = '{lotid}'";
                string hp_query = $@"update STORE_STORAGE 
                                                set currqty = 0, eqptid = null
                                                 WHERE EQPTID = (SELECT EQPTID 
                                                                      FROM LOT WHERE LOTID = '{lotid}')";
                using (var cmd = conn.CreateCommand())
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = hp_query;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)   //삭제
        {
            Lot_Delete();
            DialogResult = DialogResult.OK;
            this.Close();


            Deletion_completed deletion_Completed = new Deletion_completed();  //"삭제가 완료되었습니다"
            deletion_Completed.ShowDialog();
        }

      
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void LOT_삭제_Load(object sender, EventArgs e)
        {
             

        }

    }
}
