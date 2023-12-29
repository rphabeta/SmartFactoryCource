using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.ProcessMGR.ProcessMgr
{

    public partial class ProductInsert : Form
    {
        private List<string> PROD_UNIT_Element = new List<string>()
        {
            "BOX",
            "Kg"
        };

        private List<string> PROD_TYPE_element = new List<string>
        {
            "GOOD"
        };

        public ProductInsert()
        {
            InitializeComponent();
        }

        private bool CHECK_INSERT_PRODUCT()
        {
            // select_query에 쿼리문을 저장
            string sel_insert_qry = $"select count(*) from PRODUCT where PRODID = '"
                + txtINSERT_PRODID.Text.ToString() + "'";


            // select_ID로 조회된 결과를 data_Table에 return값을 저장
            DataTable data_Table = DatabaseManager.DB_Inquiry(sel_insert_qry);

            if (data_Table.Rows[0][0].ToString() == "1")
            {
                return false;
            }

            return true;
        }


        // PRODUCT 데이터 추가 등록
        private void btnPRO_INSERT_SAVE_Click_01(object sender, EventArgs e)
        {
            
        }


        private void ProductInsert_Load(object sender, EventArgs e)
        {
            LoadCombo(PROD_UNIT_Element, cbINSERT_PRODUNIT);
            LoadCombo(PROD_TYPE_element, cbINSERT_PRODTYPE);
            cbINSERT_PRODTYPE.SelectedIndex = 0;
            cbINSERT_PRODUNIT.SelectedIndex = 0;
        }

        // 테이블에서 특정 칼럼 데이터를 가져와 콤보박스에 설정
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

        private void btnPRO_INSERT_SAVE_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtINSERT_PRONAME.Text))
            {
                MessageBox.Show("제품명을 입력해 주세요!");
                txtINSERT_PRONAME.Focus();
                return;
            }

            if (!CHECK_INSERT_PRODUCT())
            {
                MessageBox.Show("이미 존재하는 제품코드입니다.");
                return;
            }

            string pdcode = txtINSERT_PRODID.Text; // 제품코드
            string pdname = txtINSERT_PRONAME.Text; // 제품명
            string pdunit = cbINSERT_PRODUNIT.Text; // 단위
            string pdcost = txtINSERT_PRODCOST.Text; // 단가
            string pdtype = cbINSERT_PRODTYPE.Text; // 타입
            string pdweight = txtINSERT_PRODWEIGHT.Text; // 중량

            string sql = $@"INSERT INTO PRODUCT(PRODID,
                                                PRODNAME,
                                                PRODUNIT,
                                                PRODTYPE,
                                                PRODCOST,
                                                PRODWEIGHT) 
                                         VALUES('{pdcode}', 
                                                '{pdname}', 
                                                '{pdunit}', 
                                                '{pdtype}', 
                                                '{pdcost}', 
                                                '{pdweight}')";

            DatabaseManager.DB_Modify(sql);
            DialogResult = DialogResult.Yes;
            MessageBox.Show("제품이 등록 되었습니다.");
            Close();
        }

        private void btnPRO_INSERT_CANCEL_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
