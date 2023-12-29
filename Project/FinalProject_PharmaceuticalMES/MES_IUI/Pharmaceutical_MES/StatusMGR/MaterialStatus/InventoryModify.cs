using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Pharmaceutical_MES.StatusMGR.MaterialStatus
{
    public partial class InventoryModify : Form
    {
        // 수정 전의 값을 가진 변수
        string OR_storname = string.Empty;
        string OR_prodname = string.Empty;

        public InventoryModify(DataGridViewRow selectedRow)
        {
            InitializeComponent();

            // 폼 열리자마자 각 박스 안에 선택한 셀의 값 자동으로 들어가게 설정
            cbStorage_Add.Text = selectedRow.Cells["STORNAME"].Value.ToString();
            cbProcuct_Add.Text = selectedRow.Cells["PRODNAME"].Value.ToString();
            tbProdqty_Add.Text = selectedRow.Cells["PRODQTY"].Value.ToString();

            // 수정 전
            OR_storname = selectedRow.Cells["STORNAME"].Value.ToString();
            OR_prodname = selectedRow.Cells["PRODNAME"].Value.ToString();
        }

        private string MapStorageNameToID(string storageName)
        {
            switch (storageName)
            {
                case "이동식 호퍼 #1":
                    return "HP001";
                case "이동식 호퍼 #2":
                    return "HP002";
                case "이동식 호퍼 #3":
                    return "HP003";
                case "이동식 호퍼 #4":
                    return "HP004";
                case "이동식 호퍼 #5":
                    return "HP005";
                case "이동식 호퍼 #6":
                    return "HP006";
                case "이동식 호퍼 #7":
                    return "HP007";
                case "이동식 호퍼 #8":
                    return "HP008";
                default:
                    return string.Empty;
            }
        }

        private string MapProductNameToID(string productName)
        {
            switch (productName)
            {
                case "타이레놀":
                    return "P0001";
                case "아모디핀":
                    return "P0002";
                case "써스펜8":
                    return "P0003";
                case "스피드펜":
                    return "P0004";
                default:
                    return string.Empty;
            }
        }

        private void InventoryModify_Load(object sender, EventArgs e)
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

        private void btnModify_Click(object sender, EventArgs e)
        {
            // 수정 쿼리 추가
            string StorageID = string.Empty;
            string ProdID = string.Empty;
            string QTY = tbProdqty_Add.Text;

            string OR_storid = string.Empty;
            string OR_prodid = string.Empty;

            // SQL 쿼리 작성
            try
            {
                StorageID = MapStorageNameToID(cbStorage_Add.Text);
                ProdID = MapProductNameToID(cbProcuct_Add.Text);

                OR_storid = MapStorageNameToID(OR_storname);
                OR_prodid = MapProductNameToID(OR_prodname);

                if (string.IsNullOrEmpty(cbStorage_Add.Text) ||
                    string.IsNullOrEmpty(cbProcuct_Add.Text) ||
                    string.IsNullOrEmpty(QTY))
                {
                    MessageBox.Show("빈칸이 있습니다.");
                }
                else
                {
                    string query = $@"UPDATE STORAGEPRODUCT
                                      SET
                                          STORID = '{StorageID}',
                                          PRODID = '{ProdID}',
                                          PRODQTY = {QTY}
                                      WHERE
                                          STORID = '{OR_storid}'
                                          AND PRODID = '{OR_prodid}'
                                      ";

                    DatabaseManager.DB_Modify(query);

                    DialogResult = DialogResult.Yes;
                    MessageBox.Show("수정을 완료했습니다.");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("올바른 값을 입력해주세요!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
