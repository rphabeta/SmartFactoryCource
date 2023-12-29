using Pharmaceutical_MES.ProcessMGR.ProcessMgr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.ProcessMGR.ProcessMGR
{
    public partial class ProcessMgr : Form
    {
        public ProcessMgr()
        {
            InitializeComponent();
        }

        

        private void ProcessMgr_Load(object sender, EventArgs e)
        {
            // 텍스트 박스 값 초기화
            TextBoxHint(txtPROC_ID, "공정코드");
            TextBoxHint(txtPROC_NAME, "공정명");
            TextBoxHint(txtPROD_ID, "제품코드");
            TextBoxHint(txtPROD_NAME, "제품명");

            // 텍스트 박스 힌트 이벤트 등록
            txtPROC_ID.Leave += txtPROC_ID_Leave;
            txtPROC_ID.Enter += txtPROC_ID_Enter;
            txtPROC_NAME.Leave += txtPROC_NAME_Leave;
            txtPROC_NAME.Enter += txtPROC_NAME_Enter;

            txtPROD_ID.Leave += txtPROD_ID_Leave;
            txtPROD_ID.Enter += txtPROD_ID_Enter;
            txtPROD_NAME.Leave += txtPROD_NAME_Leave;
            txtPROD_NAME.Enter += txtPROD_NAME_Enter;

            DataSearch();
        }

        // ------------------------ 텍스트 힌트 ------------------------
        private void TextBoxHint(TextBox textBox, string hint)
        {
            textBox.Text = hint;
            textBox.ForeColor = SystemColors.GrayText;
        }

        // txtPROC_ID
        private void txtPROC_ID_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지웁니다.
            if (txtPROC_ID.Text == "공정코드")
            {
                txtPROC_ID.Text = "";
                txtPROC_ID.ForeColor = Color.Black; // 힌트 텍스트와 구분하기 위해 폰트 색상을 변경합니다.
            }
        }

        private void txtPROC_ID_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(txtPROC_ID.Text))
            {
                txtPROC_ID.Text = "공정코드";
                txtPROC_ID.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }


        // txtPROC_NAME
        private void txtPROC_NAME_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지웁니다.
            if (txtPROC_NAME.Text == "공정명")
            {
                txtPROC_NAME.Text = "";
                txtPROC_NAME.ForeColor = Color.Black; // 힌트 텍스트와 구분하기 위해 폰트 색상을 변경합니다.
            }
        }

        private void txtPROC_NAME_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(txtPROC_NAME.Text))
            {
                txtPROC_NAME.Text = "공정명";
                txtPROC_NAME.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }


        // txtPROD_ID
        private void txtPROD_ID_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지웁니다.
            if (txtPROD_ID.Text == "제품코드")
            {
                txtPROD_ID.Text = "";
                txtPROD_ID.ForeColor = Color.Black; // 힌트 텍스트와 구분하기 위해 폰트 색상을 변경합니다.
            }
        }

        private void txtPROD_ID_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(txtPROD_ID.Text))
            {
                txtPROD_ID.Text = "제품코드";
                txtPROD_ID.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }

        // txtPROD_NAME
        private void txtPROD_NAME_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지웁니다.
            if (txtPROD_NAME.Text == "제품명")
            {
                txtPROD_NAME.Text = "";
                txtPROD_NAME.ForeColor = Color.Black; // 힌트 텍스트와 구분하기 위해 폰트 색상을 변경합니다.
            }
        }

        private void txtPROD_NAME_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(txtPROD_NAME.Text))
            {
                txtPROD_NAME.Text = "제품명";
                txtPROD_NAME.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }
        // ---------------------------------------------------


        private void DataSearch()
        {
            string productQuery = $@"SELECT PROCID, 
                                            PROCNAME, 
                                            PROCID_SEQ, 
                                            DEL_YN 
                                     FROM PROCESS
                                     WHERE 1 = 1
                                     ";
            if (!string.IsNullOrEmpty(txtPROC_ID.Text) && txtPROC_ID.ForeColor != SystemColors.GrayText)
            {
                string PROCID = txtPROC_ID.Text;
                productQuery += $" AND PROCID LIKE '%{PROCID.ToUpper()}%' \n";
            }

            if (!string.IsNullOrEmpty(txtPROC_NAME.Text) && txtPROC_NAME.ForeColor != SystemColors.GrayText)
            {
                string PROCNAME = txtPROC_NAME.Text;
                productQuery += $" AND PROCNAME LIKE '%{PROCNAME}%' \n";
            }

            if (!string.IsNullOrEmpty(txtPROC_SEQ.Text))
            {
                if (decimal.TryParse(txtPROC_SEQ.Text, out decimal PROC_SEQ))
                {
                    productQuery += $" AND PROCID_SEQ LIKE '%{PROC_SEQ}%' \n";
                }
                else
                {
                    // 숫자로 변환할 수 없는 경우에 대한 처리
                    MessageBox.Show("공정순서에 들어간 값이 올바른 숫자 형식이 아닙니다.");
                }
            }


            productQuery += $@" ORDER BY PROCID_SEQ";

             string prodBOMQuery = $@"SELECT    BM_SUB.PRODID           AS 최종완제품코드
                                             , BM_SUB.PRODNAME         AS 최종완제품
                                             , PC.PROCID_SEQ           AS 공정순서
                                             , PC.PROCID               AS 공정코드
                                             , PC.PROCNAME             AS 공정명
                                             
                                             
                                     FROM (
                                             SELECT 
                                                 BM.MTRLID          AS MTRLID
                                                 , BM.MTRLID_P      AS MTRLID_P
                                                 , BM.ORDERS        AS ORDERS
                                                 , BM.RATE          AS RATE
                                                 , BM.PRODID        AS PRODID
                                                 , PD.PRODNAME      AS PRODNAME
                                                 , MT.MTRLNAME      AS MTRLNAME
                                                 , CASE
                                                     WHEN BM.MTRLID LIKE 'TBLT%' THEN 3 
                                                     WHEN BM.MTRLID LIKE 'MX%'   THEN 2 
                                                     WHEN BM.MTRLID LIKE 'M%'    THEN 1
                                                     WHEN BM.MTRLID LIKE 'P%'    THEN null
                                                     ELSE                             null
                                                 END AS PROCID_SEQ
                                             FROM BOM BM
                                             LEFT JOIN MATERIAL MT ON BM.MTRLID = MT.MTRLID
                                             LEFT JOIN PRODUCT  PD ON BM.PRODID = PD.PRODID
                                             ) BM_SUB
                                         LEFT JOIN PROCESS  PC ON BM_SUB.PROCID_SEQ = PC.PROCID_SEQ
                                     GROUP BY PC.PROCID, PC.PROCNAME, PC.PROCID_SEQ, BM_SUB.PRODID, BM_SUB.PRODNAME
                                     HAVING 1 = 1 ";

            if (!string.IsNullOrEmpty(txtPROC_ID.Text) && txtPROC_ID.ForeColor != SystemColors.GrayText)
            {
                string PROCID = txtPROC_ID.Text;
                prodBOMQuery += $" AND PC.PROCID LIKE '%{PROCID.ToUpper()}%' \n";
            }

            if (!string.IsNullOrEmpty(txtPROC_NAME.Text) && txtPROC_NAME.ForeColor != SystemColors.GrayText)
            {
                string PROCNAME = txtPROC_NAME.Text;
                prodBOMQuery += $" AND PC.PROCNAME LIKE '%{PROCNAME}%' \n";
            }

            if (!string.IsNullOrEmpty(txtPROD_ID.Text) && txtPROD_ID.ForeColor != SystemColors.GrayText)
            {
                string PRODID = txtPROD_ID.Text;
                prodBOMQuery += $" AND BM_SUB.PRODID LIKE '%{PRODID.ToUpper()}%' \n";
            }

            if (!string.IsNullOrEmpty(txtPROD_NAME.Text) && txtPROD_NAME.ForeColor != SystemColors.GrayText)
            {
                string PRODNAME = txtPROD_NAME.Text;
                prodBOMQuery += $" AND BM_SUB.PRODNAME LIKE '%{PRODNAME}%' \n";
            }

            if (!string.IsNullOrEmpty(txtPROC_SEQ.Text))
            {
                if (decimal.TryParse(txtPROC_SEQ.Text, out decimal PROC_SEQ))
                {
                    prodBOMQuery += $" AND PC.PROCID_SEQ LIKE '%{PROC_SEQ}%' \n";
                }
                else
                {
                    // 숫자로 변환할 수 없는 경우에 대한 처리
                    MessageBox.Show("공정순서에 들어간 값이 올바른 숫자 형식이 아닙니다.");
                }
            }
            prodBOMQuery += $"ORDER BY BM_SUB.PRODID, PC.PROCID_SEQ  ";


            DatabaseManager.DB_Inquiry(productQuery, gvPROCESS);
            DatabaseManager.DB_Inquiry(prodBOMQuery, gvPROD_PROCESS);
            string[] ProductHeaderName = new string[] { "공정코드", "공정명", "공정순서", "삭제여부" };
            string[] ProductBOMHeadName = new string[] { "완제품코드", "완제품명", "공정순서", "공정코드", "공정명"   };

            GridViewHeaderSetter(gvPROCESS, ProductHeaderName, "false");
            GridViewHeaderSetter(gvPROD_PROCESS, ProductBOMHeadName, "true");
            gvPROCESS.Columns["DEL_YN"].ReadOnly = true;

        }

        // 헤더 설정 및 초기화
        private void GridViewHeaderSetter(DataGridView dataGridView, string[] header, string readOnly)
        {
            if (dataGridView.Rows.Count > 0)
            {
                if(readOnly == "true")
                {
                    for (int i = 0; i < header.Length; i++)
                    {
                        dataGridView.Columns[i].HeaderText = $"{header[i]}";
                        dataGridView.Columns[i].ReadOnly = true;
                        dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }

                else
                {
                    for (int i = 0; i < header.Length; i++)
                    {
                        dataGridView.Columns[i].HeaderText = $"{header[i]}";
                        dataGridView.Columns[i].ReadOnly = false;
                        dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }

                // 빈 레코드 표시 안함
                dataGridView.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }



        // 공정등록
        private void btnPROCESS_INSERT_Click(object sender, EventArgs e)
        {
            ProcessInsert procInsert = new ProcessInsert();
            if (procInsert.ShowDialog() == DialogResult.Yes)
            {
                DataSearch();
            }
        }

        // 공정 조회 
        private void btnPROC_SEARCH_Click(object sender, EventArgs e)
        {
            DataSearch();
        }

        private void btnPROC_INSERT_Click(object sender, EventArgs e)
        {
            ProcessInsert procInsert = new ProcessInsert();
            if (procInsert.ShowDialog() == DialogResult.Yes)
            {
                DataSearch();
            }
        }

        // 공정GridView 수정 내용 저장
        private void btnPROC_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPROCESS.RowCount == 0) return;

                // GetChanges 함수 = 값 변경
                DataTable dtChanges = new DataTable();
                DataTable PROCESS = (DataTable)gvPROCESS.DataSource;
                dtChanges = PROCESS.GetChanges(DataRowState.Modified);

                // 변경이 없으면 return
                if (dtChanges == null) return;

                string DBupdate = string.Empty;

                // 수정 쿼리문
                if (dtChanges != null)
                {
                    for (int i = 0; i < dtChanges.Rows.Count; i++)
                    {
                        DBupdate = $@"UPDATE PROCESS SET         
                                          PROCID       =   ':PROC_ID' 
                                          ,PROCNAME    =   ':PROCNAME' 
                                          ,PROCID_SEQ  =   ':PROCID_SEQ'
                                          ,DEL_YN      =   ':DEL_YN'  
                                      WHERE PROCID = ':PROCID_OR'";

                        // update_query에서 PRODNAME 을 #PRODNAME 으로 Replace
                        DBupdate = DBupdate.Replace(":PROC_ID", dtChanges.Rows[i]["PROCID"].ToString());
                        DBupdate = DBupdate.Replace(":PROCNAME", dtChanges.Rows[i]["PROCNAME"].ToString());
                        string sample = dtChanges.Rows[i]["PROCID_SEQ"].ToString();
                        DBupdate = DBupdate.Replace(":PROCID_SEQ", dtChanges.Rows[i]["PROCID_SEQ"].ToString()); // excuting~~~
                        DBupdate = DBupdate.Replace(":DEL_YN", dtChanges.Rows[i]["DEL_YN"].ToString());
                        DBupdate = DBupdate.Replace(":PROCID_OR", dtChanges.Rows[i]["PROCID"].ToString());

                        DatabaseManager.DB_Modify(DBupdate);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DataSearch();
        }

        // 삭제
        private void btnPROC_DELETE_Click(object sender, EventArgs e)
        {
            string DBdelete = string.Empty;

            try
            {
                if (gvPROCESS.RowCount == 0) return;

                ProcessDelete procDelete = new ProcessDelete();

                if (procDelete.ShowDialog() == DialogResult.Yes)
                {

                    //-------

                    DataGridViewRow selectedRow = gvPROCESS.CurrentRow;

                    if (selectedRow != null)
                    {
                        string deleteProdId = selectedRow.Cells["PROCID"].Value.ToString();
                        string deleteQuery = $@"UPDATE PROCESS
                                                SET DEL_YN = 'Y'
                                                WHERE PROCID = '{deleteProdId}'";
                        string inquiryQuery = $@"SELECT PROCID 
                                                       ,PROCNAME
                                                       ,PROCID_SEQ
                                                       ,NVL(DEL_YN, 'N') AS ""삭제여부""
                                                 FROM PROCESS 
                                                 WHERE 1=1 ";

                        // 선택 제품삭제
                        DatabaseManager.DB_Modify(deleteQuery);

                        // 제품 재검색
                        DataSearch();

                        MessageBox.Show("선택한 공정이 삭제되었습니다.");
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


        private void btnPROC_DELETE_Click_(object sender, EventArgs e)
        {
            string DBdelete = string.Empty;

            try
            {
                if (gvPROCESS.RowCount == 0) return;

                ProcessDelete procdelete = new ProcessDelete();

                if (procdelete.ShowDialog() == DialogResult.Yes)
                {
                    // 수정 쿼리문                        
                    DBdelete = $@"UPDATE PROCESS SET 
                                         DEL_YN =     'Y'  
                                  WHERE PROCID = '{gvPROCESS.CurrentRow.Cells["PROCID"].Value.ToString()}'";

                    DatabaseManager.DB_Modify(DBdelete);
                    DataSearch();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
