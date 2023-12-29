using Oracle.ManagedDataAccess.Client;
using Pharmaceutical_MES.ProcessMGR.ProcessMgr;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using ViewPage.작업관리;
using MessageBox = System.Windows.Forms.MessageBox;
using SystemColors = System.Drawing.SystemColors;

namespace Pharmaceutical_MES.ProcessMGR.BOMMGR
{
    public partial class BOMMGR : Form
    {
        private string selectedPRODID;
        private string selectedPRODNAME;

        private string selectedPRODID_B;
        private string selectedMTRLID;
        private DataGridViewRow selectedRow;

        public BOMMGR()
        {
            InitializeComponent();
        }

        // 폼 로드 초기화
        private void BOMMGR_Load(object sender, EventArgs e)
        {
            // 콤보 박스 요소
         

            List<string> DEL_YN_List = new List<string>()
            {
                "ALL",
                "Y",
                "N"
            };

            // 콤보박스 값 초기화
            LoadCombo(DEL_YN_List, cbPROD_DEL_YN);
            cbPROD_DEL_YN.SelectedIndex = 2;

            // 텍스트 박스 값 초기화
            TextBoxHint(tbPROD_ID, "품목코드");
            TextBoxHint(tbPROD_NAME, "품목명");

            // 텍스트 박스 힌트 이벤트 등록
            tbPROD_ID.Leave += tbPROD_ID_Leave;
            tbPROD_ID.Enter += tbPROD_ID_Enter;
            tbPROD_NAME.Leave += tbPROD_NAME_Leave;
            tbPROD_NAME.Enter += tbPROD_NAME_Enter;

            // 텍스트 박스 힌트 초기화
            tbPROD_ID.Text = "품목코드";
            tbPROD_NAME.Text = "품목명";
            tbPROD_ID.ForeColor = SystemColors.GrayText; 
            tbPROD_NAME.ForeColor = SystemColors.GrayText; 

            // 셀 클릭 이벤트 등록

            //gvPRODUCT.CellClick += GridView_PRODUCT_Get_SelectedCell;

            // 완제품 검색
            ProductDataSearch();
        }

        // -------------------완제품 관련 코드-------------------

        // 완제품 그리드뷰
        private void ProductDataSearch()
        {
            string DB_PROD_Query = $@"SELECT PRODID       품목코드
                                             , PRODNAME   품목명  
                                             , PRODTYPE   품목유형  
                                             , PRODUNIT   단위  
                                             , PRODCOST   단가 
                                             , DEL_YN     삭제여부
                                       FROM  PRODUCT
                                       WHERE 
                                             1 = 1
                                     ";

            if (!string.IsNullOrEmpty(tbPROD_ID.Text) && tbPROD_ID.ForeColor != SystemColors.GrayText)
            {
                string PROD_ID = tbPROD_ID.Text;
                DB_PROD_Query += $" AND PRODID LIKE '%{PROD_ID.ToUpper()}%' \n";
            }

            if (!string.IsNullOrEmpty(tbPROD_NAME.Text) && tbPROD_NAME.ForeColor != SystemColors.GrayText)
            {
                string PROD_NAME = tbPROD_NAME.Text;
                DB_PROD_Query += $" AND PRODNAME LIKE '%{PROD_NAME.ToUpper()}%' \n";
            }

            if (cbPROD_DEL_YN.SelectedItem.ToString() != "ALL")
            {
                DB_PROD_Query += $" AND NVL(DEL_YN, 'N') = '{cbPROD_DEL_YN.SelectedItem.ToString()}'";
            }

            DB_PROD_Query += $@"ORDER BY PRODID";

            // GridView 적용
            DatabaseManager.DB_Inquiry(DB_PROD_Query, gvPRODUCT);


            // GridView 칼럼명 설정 
            string[] PROD_HeaderName = new string[] { "품목코드", "품목명", "품목유형", "단위", "단가", "삭제여부" };

            GridViewHeaderSetter(gvPRODUCT, PROD_HeaderName, "true");

                
        }

        // 완제품 선택 셀 가져옴
        private void gvPRODUCT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = gvPRODUCT.Rows[e.RowIndex];

                // 선택된 행에 대한 작업 수행
                selectedPRODID = selectedRow.Cells["품목코드"].Value.ToString();
                selectedPRODNAME = selectedRow.Cells["품목명"].Value.ToString();
            }
            else
            {
                // 여기에 선택된 셀이 없습니다. 팝업창.
            }
        }

        // BOM 등록페이지 이동 (PROD 선택 셀 정보 -> BOM 등록 화면 이동)
        private void btnBOM_INSERT_Click(object sender, EventArgs e)
        {
            BOM_INSERT bomInsert = new BOM_INSERT(selectedPRODID, selectedPRODNAME);
            if (bomInsert.ShowDialog() == DialogResult.Yes)
            {
                ProductDataSearch();
            }
        }


        // 완제품 선택 후 버튼 클릭시 BOM 조회
        private void BOMSearch()
        {
            string DB_BOM_Query;
            if (selectedPRODID != null)
            {
                // 위 제품 BOM 정보 조회 쿼리
                DB_BOM_Query = $@"SELECT                                   
                                          PC.PROCID                 AS 공정코드
                                          , PC.PROCID_SEQ           AS 공정순서
                                          , PC.PROCNAME             AS 공정명
                                          , BM_SUB.MTRLID           AS 품목코드
                                          , BM_SUB.MTRLNAME         AS 품목명
                                          , BM_SUB.PRODID           AS 최종완제품코드
                                          , BM_SUB.PRODNAME         AS 최종완제품
                                          , BM_SUB.RATE             AS 비율
                                          , BM_SUB.DEL_YN           AS 삭제여부 
                                  FROM (
                                          SELECT 
                                              BM.MTRLID        AS MTRLID
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
                                             , BM.DEL_YN         AS DEL_YN
                                          FROM BOM BM
                                          LEFT JOIN MATERIAL MT ON BM.MTRLID = MT.MTRLID
                                          LEFT JOIN PRODUCT  PD ON BM.PRODID = PD.PRODID
                                          ) BM_SUB
                                      LEFT JOIN PROCESS  PC ON BM_SUB.PROCID_SEQ = PC.PROCID_SEQ
                                  WHERE BM_SUB.PRODID = '{selectedPRODID}' 
                                  ORDER BY PC.PROCID_SEQ";


                DatabaseManager.DB_Inquiry(DB_BOM_Query, gvBOM);
                string[] BOM_HeaderName = new string[] { "공정코드", "공정순서", "공정명", "품목코드", "품목명", "최종완제품코드", "최종완제품", "비율", "삭제여부" };
                GridViewHeaderSetter(gvBOM, BOM_HeaderName, "true");
                
                gvBOM.Columns["비율"].ReadOnly  = false; // 비율 외, 투입 원재료 변경 시 BOM추가.
                
            }
        }

        // PROD 검색
        private void btnPROD_SEARCH_Click(object sender, EventArgs e)
        {
            ProductDataSearch();
        }


        // -------------------BOM 관련 코드 -------------------
        // BOM 검색
        private void btnBOM_SEARCH_Click(object sender, EventArgs e)
        {
            BOMSearch();
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



        private string GetPRODNAME(string PRODID)
        {
            string query = $@"SELECT PRODNAME FROM PRODUCT WHERE PRODID = '{PRODID}'";
            string prodName = "";
            OracleConnection conn = DatabaseManager.GetConnection();


            using (OracleCommand command = new OracleCommand(query, conn))
            {

                // 쿼리 실행 및 결과 가져오기
                object result = command.ExecuteScalar();

                // 결과가 null이 아니면 변수에 저장
                if (result != null)
                {
                    prodName = result.ToString();
                }
                else
                {
                    MessageBox.Show("해당 PRODID에 대한 결과가 없습니다.");
                }
            }
            return prodName;
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


        // BOM 삭제
        private void btnBOM_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvBOM.RowCount == 0) return;

                BOM_DELETE BOM_Delete = new BOM_DELETE();

                if (BOM_Delete.ShowDialog() == DialogResult.Yes)
                {

                    //-------"공정코드", "공정순서", "공정명", "품목코드", "품목명", "최종완제품코드", "최종완제품", "비율", "삭제여부"

                    DataGridViewRow selectedRow = gvBOM.CurrentRow;

                    if (selectedRow != null)
                    {
                        string selectedMTRLID = selectedRow.Cells["품목코드"].Value.ToString();
                        string selectedPRODID = selectedRow.Cells["최종완제품코드"].Value.ToString();

                        string deleteQuery = $@"UPDATE BOM BM SET
                                                  BM.DEL_YN = ':DEL_YN'
                                                WHERE BM.MTRLID = ':MTRLID' 
                                                  AND BM.PRODID = ':PRODID'
                                               ";

                        deleteQuery = deleteQuery.Replace(":DEL_YN", "Y");
                        deleteQuery = deleteQuery.Replace(":MTRLID", selectedMTRLID);
                        deleteQuery = deleteQuery.Replace(":PRODID", selectedPRODID);


                        // 선택 제품삭제
                        DatabaseManager.DB_Modify(deleteQuery);
                        MessageBox.Show("선택한 BOM이 삭제되었습니다.");

                        BOMSearch();
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



        // BOM 수정
        private void btnBOM_MODIFY_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvBOM.RowCount == 0) return;

                BOM_MODIFY BOM_Melete = new BOM_MODIFY();

                if (BOM_Melete.ShowDialog() == DialogResult.Yes)
                {
                    // GetChanges 함수 = 값 변경
                    DataTable dtChanges = new DataTable();
                    DataTable BOMTable = (DataTable)gvBOM.DataSource;
                    dtChanges = BOMTable.GetChanges(DataRowState.Modified);

                    // 변경이 없으면 return
                    if (dtChanges == null) return;

                    string DBupdate = string.Empty;

                    // 수정 쿼리문
                    if (dtChanges != null)
                    {
                        // "공정코드", "공정순서", "공정명", "품목코드", "품목명", "최종완제품코드", "최종완제품", "비율", "삭제여부"
                        // BOM, MATERIAL, PRODUCT, PROCESS
                        for (int i = 0; i < dtChanges.Rows.Count; i++)
                        {
                            DBupdate = $@"UPDATE BOM BM SET
                                            BM.RATE = ':RATE'
                                          WHERE BM.MTRLID = ':MTRLID' 
                                                AND BM.PRODID = ':PRODID'
                                         ";


                            // update_query에서 PRODNAME 을 #PRODNAME 으로 Replace
                            DBupdate = DBupdate.Replace(":RATE", dtChanges.Rows[i]["비율"].ToString());
                            DBupdate = DBupdate.Replace(":MTRLID", dtChanges.Rows[i]["품목코드"].ToString());
                            DBupdate = DBupdate.Replace(":PRODID", dtChanges.Rows[i]["최종완제품코드"].ToString());

                            DatabaseManager.DB_Modify(DBupdate);

                            MessageBox.Show("선택한 BOM이 수정되었습니다.");
                        }
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
    }
}
