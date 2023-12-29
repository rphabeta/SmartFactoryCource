using Pharmaceutical_MES.ProcessMGR.ProcessMgr;
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

namespace Pharmaceutical_MES
{
    public partial class ProudctMgr : Form
    {
        private List<string> PROD_DEL_elements = new List<string>()
        {
            "ALL",
            "Y",
            "N"
        };

        public ProudctMgr()
        {
            InitializeComponent();
        }

        private void ProudctMgr_Load(object sender, EventArgs e)
        {
            LoadCombo(PROD_DEL_elements, cbPROD_DELETE);
            cbPROD_DELETE.SelectedIndex = 0;
            //GridDesign1.SetGridDesign(GridView_PRODUCT);

            // 텍스트 박스 값 초기화
            TextBoxHint(tbPROD_ID, "품목코드");
            TextBoxHint(tbPROD_NAME, "품목명");

            // 텍스트 박스 힌트 이벤트 등록
            tbPROD_ID.Leave += tbPROD_ID_Leave;
            tbPROD_ID.Enter += tbPROD_ID_Enter;
            tbPROD_NAME.Leave += tbPROD_NAME_Leave;
            tbPROD_NAME.Enter += tbPROD_NAME_Enter;

            //// 텍스트 박스 힌트 초기화
            //tbPROD_ID.Text = "품목코드";
            //tbPROD_NAME.Text = "품목명";
            //tbPROD_ID.ForeColor = SystemColors.GrayText;
            //tbPROD_NAME.ForeColor = SystemColors.GrayText;

            DataSearch();
        }


        

        private void DataSearch()
        {
            string DBproduct = $@"SELECT PRODID 
                                        ,PRODNAME 
                                        ,PRODUNIT 
                                        ,PRODCOST
                                        ,PRODTYPE 
                                        ,PRODWEIGHT 
                                        ,NVL(DEL_YN, 'N')
                                  FROM PRODUCT 
                                  WHERE 1=1 ";

            if (!string.IsNullOrEmpty(tbPROD_ID.Text) && tbPROD_ID.ForeColor != SystemColors.GrayText)
            {
                string PRODID = tbPROD_ID.Text;
                DBproduct += $" AND PRODID LIKE '%{PRODID.ToUpper()}%' \n";
            }

            if (!string.IsNullOrEmpty(tbPROD_NAME.Text) && tbPROD_NAME.ForeColor != SystemColors.GrayText)
            {
                string PRODNAME = tbPROD_NAME.Text;
                DBproduct += $" AND PRODNAME LIKE '%{PRODNAME}%' \n";
            }

            if (cbPROD_DELETE.SelectedItem.ToString() != "ALL")
            {
                DBproduct += $" AND NVL(DEL_YN, 'N') = '{cbPROD_DELETE.SelectedItem.ToString()}'";
            }

            DBproduct += $@"ORDER BY PRODID";

            DatabaseManager.DB_Inquiry(DBproduct, gvPRODUCT);

            string[] HeaderName = new string[] { "제품코드", "제품명", "단위", "단가", "타입", "개수", "삭제여부" };

            

            if (gvPRODUCT.Rows.Count > 0)
            {
                for (int i = 0; i < HeaderName.Length; i++)
                {
                    gvPRODUCT.Columns[i].HeaderText = $"{HeaderName[i]}";
                    gvPRODUCT.Columns[i].ReadOnly = false;
                    gvPRODUCT.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                gvPRODUCT.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                gvPRODUCT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            gvPRODUCT.Columns["PRODID"].ReadOnly = true;
        }



        // ------------------------ 텍스트 힌트 ------------------------
        private void TextBoxHint(TextBox textBox, string hint)
        {
            textBox.Text = hint;
            textBox.ForeColor = SystemColors.GrayText;
        }

        private void tbPROD_ID_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지웁니다.
            if (tbPROD_ID.Text == "품목코드")
            {
                tbPROD_ID.Text = "";
                tbPROD_ID.ForeColor = Color.Black; // 힌트 텍스트와 구분하기 위해 폰트 색상을 변경합니다.
            }
        }

        // tbPROD_ID 힌트 설정
        private void tbPROD_ID_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(tbPROD_ID.Text))
            {
                tbPROD_ID.Text = "품목코드";
                tbPROD_ID.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }

        private void tbPROD_NAME_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지움
            if (tbPROD_NAME.Text == "품목명")
            {
                tbPROD_NAME.Text = "";
                tbPROD_NAME.ForeColor = Color.Black; // 폰트 색상을 변경
            }
        }

        private void tbPROD_NAME_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트를 설정
            if (string.IsNullOrWhiteSpace(tbPROD_NAME.Text))
            {
                tbPROD_NAME.Text = "품목명";
                tbPROD_NAME.ForeColor = SystemColors.GrayText; // 힌트 텍스트의 폰트 색상을 변경
            }
        }
        // ---------------------------------------------------



        // PRODUCT 데이터 추가
        private void btnPROD_ADD_Click(object sender, EventArgs e)
        {
            ProductInsert prodinsert = new ProductInsert();
            if (prodinsert.ShowDialog() == DialogResult.Yes)
            {
                DataSearch();
            }
        }

      
       

        // PRODUCT 조회
        private void btnPROD_SEARCH_Click(object sender, EventArgs e)
        {
            DataSearch();
        }

        // 데이터 삭제
        private void btnPROD_DELETE_Click(object sender, EventArgs e)
        {
            string DBdelete = string.Empty;

            try
            {
                if (gvPRODUCT.RowCount == 0) return;

                ProductDelete proddelete = new ProductDelete();

                if (proddelete.ShowDialog() == DialogResult.Yes)
                {

                    //-------

                    DataGridViewRow selectedRow = gvPRODUCT.CurrentRow;

                    if (selectedRow != null)
                    {
                        string deleteProdId = selectedRow.Cells["PRODID"].Value.ToString();
                        string deleteQuery = $@"UPDATE PRODUCT
                                                SET DEL_YN = 'Y'
                                                WHERE PRODID = '{deleteProdId}'";
                        string inquiryQuery = $@"SELECT PRODID 
                                                       ,PRODNAME 
                                                       ,PRODUNIT
                                                       ,PRODCOST
                                                       ,PRODTYPE 
                                                       ,PRODWEIGHT 
                                                       ,NVL(DEL_YN, 'N')
                                                 FROM PRODUCT 
                                                 WHERE 1=1 ";

                        // 선택 제품삭제
                        DatabaseManager.DB_Modify(deleteQuery);

                        // 제품 재검색
                        DatabaseManager.DB_Inquiry(inquiryQuery, gvPRODUCT);

                        MessageBox.Show("선택한 제품이 삭제되었습니다.");
                    }
                    else
                    {
                        MessageBox.Show("선택된 행이 없습니다.");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void btnPROD_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPRODUCT.RowCount == 0) return;

                // GetChanges 함수 = 값 변경
                DataTable dtChanges = new DataTable();
                DataTable PRODUCT = (DataTable)gvPRODUCT.DataSource;
                dtChanges = PRODUCT.GetChanges(DataRowState.Modified);

                // 변경이 없으면 return
                if (dtChanges == null) return;

                string DBupdate = string.Empty;

                // 수정 쿼리문
                if (dtChanges != null)
                {
                    for (int i = 0; i < dtChanges.Rows.Count; i++)
                    {
                        DBupdate = $@"UPDATE PRODUCT SET         
                                          PRODNAME    =   ':PRODNAME' 
                                          ,PRODUNIT   =   ':PRODUNIT' 
                                          ,PRODCOST   =   ':PRODCOST'
                                          ,PRODTYPE   =   ':PRODTYPE'  
                                          ,PRODWEIGHT =   ':PRODWEIGHT' 
                                      WHERE PRODID = ':PRODID'";

                        // update_query에서 PRODNAME 을 #PRODNAME 으로 Replace
                        DBupdate = DBupdate.Replace(":PRODNAME", dtChanges.Rows[i]["PRODNAME"].ToString());
                        DBupdate = DBupdate.Replace(":PRODUNIT", dtChanges.Rows[i]["PRODUNIT"].ToString());
                        DBupdate = DBupdate.Replace(":PRODCOST", dtChanges.Rows[i]["PRODCOST"].ToString());
                        DBupdate = DBupdate.Replace(":PRODTYPE", dtChanges.Rows[i]["PRODTYPE"].ToString());
                        DBupdate = DBupdate.Replace(":PRODWEIGHT", dtChanges.Rows[i]["PRODWEIGHT"].ToString());
                        DBupdate = DBupdate.Replace(":PRODID", dtChanges.Rows[i]["PRODID"].ToString());

                        DatabaseManager.DB_Modify(DBupdate);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DataSearch();

            // 확인 폼 따로 공통 폼 만들어서 사용할 수 있게.
            //WorkOrder.Update product_update = new WorkOrder.Update();
            //product_update.ShowDialog();
        }
    }

}
