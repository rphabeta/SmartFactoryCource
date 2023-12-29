using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.StatusMGR.MaterialStatus
{
    public partial class InventoryInsert : Form
    {
        public InventoryInsert()
        {
            InitializeComponent();
        }

        private void InventoryInsert_Load(object sender, EventArgs e)
        {
            // cbStorage_Add 리스트
            List<string> Storage_List = new List<string>()
            {
                "이동식 호퍼 #1",
                "이동식 호퍼 #2",
                "이동식 호퍼 #3",
                "이동식 호퍼 #4",
                "이동식 호퍼 #5",
                "이동식 호퍼 #6",
                "이동식 호퍼 #7",
                "이동식 호퍼 #8"
            };

            // cbProcuct_Add 리스트
            List<string> Product_List = new List<string>()
            {
                "타이레놀",
                "아모디핀",
                "써스펜8",
                "스피드펜"
            };

            // comboBox 초기화
            LoadCombo(Storage_List, cbStorage_Add);
            LoadCombo(Product_List, cbProcuct_Add);
        }

        private void LoadCombo(List<string> list, ComboBox comboBox)
        {
            if (list.Count >= 0)
            {
                foreach (string item in list)
                {
                    comboBox.Items.Add(item);
                }
            }
            else MessageBox.Show($"비어있는 리스트입니다.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string StorageID = string.Empty;
            string ProdID = string.Empty;

            try
            {
                // STORAGE
                string storname = cbStorage_Add.Text;

                switch (storname)
                {
                    case "이동식 호퍼 #1":
                        StorageID = "HP001";
                        break;
                    case "이동식 호퍼 #2":
                        StorageID = "HP002";
                        break;
                    case "이동식 호퍼 #3":
                        StorageID = "HP003";
                        break;
                    case "이동식 호퍼 #4":
                        StorageID = "HP004";
                        break;
                    case "이동식 호퍼 #5":
                        StorageID = "HP005";
                        break;
                    case "이동식 호퍼 #6":
                        StorageID = "HP006";
                        break;
                    case "이동식 호퍼 #7":
                        StorageID = "HP007";
                        break;
                    case "이동식 호퍼 #8":
                        StorageID = "HP008";
                        break;
                    default:
                        break;
                }


                // PRODUCT
                string prodname = cbProcuct_Add.Text;

                switch (prodname)
                {
                    case "타이레놀":
                        ProdID = "P0001";
                        break;
                    case "아모디핀":
                        ProdID = "P0002";
                        break;
                    case "써스펜8":
                        ProdID = "P0003";
                        break;
                    case "스피드펜":
                        ProdID = "P0004";
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrEmpty(cbStorage_Add.Text) ||
                    string.IsNullOrEmpty(cbProcuct_Add.Text) ||
                    string.IsNullOrEmpty(tbProdqty_Add.Text))
                {
                    MessageBox.Show("모든 값을 입력해주세요");
                    return;
                }

                int QTY = int.Parse(tbProdqty_Add.Text); // 재고수량

                string InvInsert = $@" INSERT INTO STORAGEPRODUCT
                                       (
                                           STORID,
                                           PRODID,
                                           PRODQTY
                                       )
                                       VALUES
                                       (
                                           '{StorageID}',
                                           '{ProdID}',
                                           {QTY}
                                       )";



                DatabaseManager.DB_Modify(InvInsert);
                DialogResult = DialogResult.Yes;
                MessageBox.Show("등록 되었습니다.");
                Close();



                //if (proddelete.ShowDialog() == DialogResult.Yes)
                //{
                //    DBdelete = $@"DELETE FROM STORAGEPRODUCT
                //                  WHERE STORID = '{StorageID}'
                //                    AND PRODID = '{ProdID}'";

                //    DatabaseManager.DB_Modify(DBdelete);
                //    DataSearch();
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
