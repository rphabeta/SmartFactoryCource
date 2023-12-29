using Pharmaceutical_MES.ProcessMGR.ProcessMgr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewPage.작업관리;

namespace Pharmaceutical_MES.StatusMGR.MaterialStatus
{
    public partial class InventoryStatus : Form
    {
        //DatabaseManager databaseManager = new DatabaseManager();

        string query = $@"SELECT STORID, PRODID, PRODQTY FROM STORAGEPRODUCT";

        public InventoryStatus()
        {
            InitializeComponent();
        }

        private void DataSearch()
        {
            string query = $@"SELECT ST.STORNAME
                                     , PD.PRODNAME
                                     , STP.PRODQTY
                              FROM STORAGEPRODUCT STP
                                LEFT JOIN PRODUCT PD ON STP.PRODID = PD.PRODID
                                LEFT JOIN STORE_STORAGE ST ON STP.STORID = ST.STORID
                              WHERE 1=1";

            // 수주 테이블 JOIN한 버전
            //string query = $@"SELECT ST.STORNAME
            //                         , PD.PRODNAME
            //                         , STP.PRODQTY
            //                         , SA.SOQTY
            //                  FROM STORAGEPRODUCT STP
            //                    LEFT JOIN PRODUCT PD ON STP.PRODID = PD.PRODID
            //                    LEFT JOIN STORE_STORAGE ST ON STP.STORID = ST.STORID
            //                    LEFT JOIN SALES SA ON STP.PRODID = SA.PRODID
            //                  WHERE 1=1";

            try
            {
                //if (cbPROD_TYPE.SelectedIndex != -1)
                //{
                //    string selectedItem = cbPROD_TYPE.SelectedItem.ToString();
                //    string addCondition = $" AND TP.TPTYPE LIKE '{selectedItem}' \n";
                //    prodSearchQuery += addCondition;
                //}

                if (!string.IsNullOrEmpty(cbStorage.Text))
                {
                    string STRName = cbStorage.Text;
                    query += $" AND ST.STORNAME LIKE '%{STRName}%' \n";
                }
                if (!string.IsNullOrEmpty(cbProduct.Text))
                {
                    string PRDName = cbProduct.Text;
                    query += $" AND PD.PRODNAME LIKE '%{PRDName}%' \n";
                }

                DatabaseManager.DB_Inquiry(query, StorageGrid);

                string[] HeaderName = new string[] { "창고명", "제품", "제품 수량" };

                //string[] HeaderName = new string[] { "창고명", "제품", "제품 수량", "출하 수량" };

                if (StorageGrid.Rows.Count > 0)
                {
                    for (int i = 0; i < HeaderName.Length; i++)
                    {
                        StorageGrid.Columns[i].HeaderText = $"{HeaderName[i]}";
                        StorageGrid.Columns[i].ReadOnly = true;
                        StorageGrid.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    // 빈 레코드 표시 안함
                    StorageGrid.AllowUserToAddRows = false;

                    // 헤더 위치 정렬(가운데)
                    StorageGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void InventoryStatus_Load(object sender, EventArgs e)
        {
            //DatabaseManager.DB_Inquiry(query, StorageGrid);
            DataSearch();

            // cbProduct 리스트
            List<string> Product_List = new List<string>()
            {
                "타이레놀",
                "아모디핀",
                "써스펜8",
                "스피드펜"
            };


            // cbStorage 리스트
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

            // comboBox 초기화
            LoadCombo(Product_List, cbProduct);
            LoadCombo(Storage_List, cbStorage);
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
            InventoryInsert inventoryInsert = new InventoryInsert();

            if (inventoryInsert.ShowDialog() == DialogResult.Yes)
            {
                DataSearch();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = StorageGrid.CurrentRow;

            //InventoryModify inventoryModify = new InventoryModify(selectedRow);

            if (selectedRow != null)
            {
                // 팝업 폼 열기
                using (InventoryModify inventoryModify = new InventoryModify(selectedRow))
                {
                    inventoryModify.ShowDialog(); // Modal 창
                }
            }

            DataSearch();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string DBdelete = string.Empty;
            string StorageID = string.Empty;
            string ProdID = string.Empty;

            try
            {
                if (StorageGrid.RowCount == 0) return;

                ProductDelete proddelete = new ProductDelete();

                // STORAGE
                string storname = StorageGrid.CurrentRow.Cells["STORNAME"].Value.ToString();

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
                string prodname = StorageGrid.CurrentRow.Cells["PRODNAME"].Value.ToString();

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

                if (proddelete.ShowDialog() == DialogResult.Yes)
                {
                    DBdelete = $@"DELETE FROM STORAGEPRODUCT
                                  WHERE STORID = '{StorageID}'
                                    AND PRODID = '{ProdID}'";
                    DatabaseManager.DB_Modify(DBdelete);
                    DataSearch();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSearch();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbProduct.Text = string.Empty;
            cbStorage.Text = string.Empty;
        }
    }
}
