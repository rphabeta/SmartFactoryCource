using Pharmaceutical_MES.ProcessMGR.ProcessMgr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.ProcessMGR.BOMMGR
{
    public partial class BOM_INSERT : Form
    {
        private string selectedPRODID;
        private DataGridViewRow selectedRow;
        private string gvBOM_selectedMTRLID;

        public BOM_INSERT()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1799, 1000);
        }

        public BOM_INSERT(string PRODID, string PRODNAME)
        {
            InitializeComponent();
            
            // BOM 페이지 선택된 셀 정보 
            tbPROD_ID.Text= PRODID;
            tbPROD_NAME.Text = PRODNAME;
            selectedPRODID = PRODID;
            tbPROD_ID.ReadOnly = true;
            tbPROD_NAME.ReadOnly = true;
            
            this.Size = new System.Drawing.Size(1799, 1000);
        }


        private void BOM_INSERT_Load(object sender, EventArgs e)
        {
            // 선택된 계층에서의 BOM 설정, PROCESS는 고정
            //txtPROC_ID.Text = DatabaseManager.DB_GetColumnValue("PROCID", "PROCESS", BOM_ProcID);

            // 텍스트박스 힌트 초기화
            tbMTRL_ID.Text = "품목코드";
            tbMTRL_NAME.Text = "품목명";
            tbMTRL_P_ID.Text = "품목코드";
            tbMTRL_P_NAME.Text = "품목명";
            tbMTRL_ID.ForeColor = SystemColors.GrayText;
            tbMTRL_NAME.ForeColor = SystemColors.GrayText;
            tbMTRL_P_ID.ForeColor = SystemColors.GrayText;
            tbMTRL_P_NAME.ForeColor = SystemColors.GrayText;

            // 텍스트박스 힌트 이벤트 등록
            tbMTRL_ID.Enter += tbMTRL_ID_Enter;
            tbMTRL_ID.Leave += tbMTRL_ID_Leave;
            tbMTRL_NAME.Enter += tbMTRL_NAME_Enter;
            tbMTRL_NAME.Leave += tbMTRL_NAME_Leave;

            tbMTRL_P_ID.Enter += tbMTRL_P_ID_Enter;
            tbMTRL_P_ID.Leave += tbMTRL_P_ID_Leave;
            tbMTRL_P_NAME.Enter += tbMTRL_P_NAME_Enter;
            tbMTRL_P_NAME.Leave += tbMTRL_P_NAME_Leave;

            // 이벤트 등록
            //gvPRODUCT.CellClick += GridView_PRODUCT_Get_SelectedCell;
            gvBOM.CellClick += gvBOM_CellClick;

            // GridView 초기화
            DataSearch();
        }

        // ------------------- BOM 관련 -------------------
        
        // 그리드뷰 채우기
        private void DataSearch()
        {
            string selectedPRODID = tbPROD_ID.Text;
            //string selectedPRODNAME = tbPROD_NAME.Text;
            string DB_BOM_Query = String.Empty;
            
            if (!String.IsNullOrEmpty(selectedPRODID))
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
                GridViewHeaderSetter(gvBOM, BOM_HeaderName);
            }
            // 위 제품 BOM 정보 조회 쿼리
            else
            {
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
                                            , BM.DEL_YN        AS DEL_YN
                                        FROM BOM BM
                                        LEFT JOIN MATERIAL MT ON BM.MTRLID = MT.MTRLID
                                        LEFT JOIN PRODUCT  PD ON BM.PRODID = PD.PRODID
                                        ) BM_SUB
                                    LEFT JOIN PROCESS  PC ON BM_SUB.PROCID_SEQ = PC.PROCID_SEQ
                                ORDER BY PC.PROCID_SEQ";
                DatabaseManager.DB_Inquiry(DB_BOM_Query, gvBOM);
                string[] BOM_HeaderName = new string[] { "공정코드", "공정순서", "공정명", "품목코드", "품목명", "최종완제품코드", "최종완제품", "비율", "삭제여부" };
                GridViewHeaderSetter(gvBOM, BOM_HeaderName);
            }
        }

        // BOM 등록 

        private void DataInsert()
        {
            // 미등록 원재료 투입불가
            if (materialCheck(tbMTRL_ID.Text))
            {
                if(!existBOMCheck(tbMTRL_ID.Text, tbMTRL_P_ID.Text))
                {
                    if ((!string.IsNullOrEmpty(tbMTRL_ID.Text) && !string.IsNullOrEmpty(tbMTRL_P_ID.Text)
                        && !string.IsNullOrEmpty(tbBOM_ORDERS.Text) && !string.IsNullOrEmpty(tbBOM_RATE.Text)))
                    {
                        string DB_BOM_Query = $@"INSERT INTO BOM(MTRLID, MTRLID_P, ORDERS, RATE, PRODID, DEL_YN)
                                                        VALUES ('{tbMTRL_ID.Text}'
                                                            , '{tbMTRL_P_ID.Text}'
                                                            , '{int.Parse(tbBOM_ORDERS.Text)}'
                                                            , '{Double.Parse(tbBOM_RATE.Text)}'
                                                            , '{selectedPRODID}'
                                                            , 'N' )";
                        DatabaseManager.DB_Modify(DB_BOM_Query);
                        MessageBox.Show("등록완료");
                    }
                    else
                    {
                        MessageBox.Show("등록에 필요한 값을 전부 작성해주세요.");
                    }
                }
                else
                {
                    MessageBox.Show("이미 BOM에 등록된 재료입니다.");
                }
            }
            else
            {
                MessageBox.Show("등록되지 않은 MATERIAL입니다.");
            }
            DataSearch();
        }
       

        // <------------------ 공용 컨트롤러 ------------------->

        // ------------------- 텍스트 박스 힌트 이벤트 -------------------


        // txtPROD_ID 힌트 설정
        private void tbMTRL_ID_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(tbMTRL_ID.Text))
            {
                tbMTRL_ID.Text = "품목코드";
                tbMTRL_ID.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }

        // tbPROD_NAME 힌트 설정
        private void tbMTRL_NAME_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(tbMTRL_NAME.Text))
            {
                tbMTRL_NAME.Text = "품목명";
                tbMTRL_NAME.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }

        private void tbMTRL_P_ID_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(tbMTRL_P_ID.Text))
            {
                tbMTRL_P_ID.Text = "품목코드";
                tbMTRL_P_ID.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }

        private void tbMTRL_P_NAME_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(tbMTRL_P_NAME.Text))
            {
                tbMTRL_P_NAME.Text = "품목명";
                tbMTRL_P_NAME.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }


        // tbPROD_ID 힌트 제거
        private void tbMTRL_ID_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지웁니다.
            if (tbMTRL_ID.Text == "품목코드")
            {
                tbMTRL_ID.Text = "";
                tbMTRL_ID.ForeColor = Color.Black; // 힌트 텍스트와 구분하기 위해 폰트 색상을 변경합니다.
            }
        }

        //txtPROD_NAME 힌트 제거
        private void tbMTRL_NAME_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지움
            if (tbMTRL_NAME.Text == "품목명")
            {
                tbMTRL_NAME.Text = "";
                tbMTRL_NAME.ForeColor = Color.Black; // 폰트 색상을 변경
            }
        }

        // txtPROD_MTRL_P 힌트 제거
        private void tbMTRL_P_ID_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지웁니다.
            if (tbMTRL_P_ID.Text == "품목코드")
            {
                tbMTRL_P_ID.Text = "";
                tbMTRL_P_ID.ForeColor = Color.Black; // 힌트 텍스트와 구분하기 위해 폰트 색상을 변경합니다.
            }
        }

        private void tbMTRL_P_NAME_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지움
            if (tbMTRL_P_NAME.Text == "품목명")
            {
                tbMTRL_P_NAME.Text = "";
                tbMTRL_P_NAME.ForeColor = Color.Black; // 폰트 색상을 변경
            }
        }

        //----------------------------------------------------------------------------

        // 헤더 설정 및 초기화
        private void GridViewHeaderSetter(DataGridView dataGridView, string[] header)
        {
            if (dataGridView.Rows.Count > 0)
            {
                for (int i = 0; i < header.Length; i++)
                {
                    dataGridView.Columns[i].HeaderText = $"{header[i]}";
                    dataGridView.Columns[i].ReadOnly = true;
                    dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                dataGridView.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }


        // ------------------- 버튼 이벤트 ------------------- 
        private void btnEXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBOM_INSERT_Click(object sender, EventArgs e)
        {
            DataInsert();
        }


        private bool materialCheck(string MTRLID)
        {
            string materialCheck = $@"SELECT MTRLID FROM MATERIAL WHERE MTRLID = '{MTRLID}'";
            
            string resultMTRLID = "";

            using (Oracle.ManagedDataAccess.Client.OracleConnection conn = DatabaseManager.GetConnection())
            {

                using (Oracle.ManagedDataAccess.Client.OracleCommand command = new Oracle.ManagedDataAccess.Client.OracleCommand(materialCheck, conn))
                {
                    using (Oracle.ManagedDataAccess.Client.OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 쿼리 결과가 있다면 reader["컬럼이름"] 형태로 값을 가져올 수 있습니다.
                            resultMTRLID = reader["MTRLID"].ToString();
                        }
                    }
                }
            }
            if (resultMTRLID == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private bool existBOMCheck(string MTRLID, string MTRLID_P)
        {
            string existBOM_MTTLID = $@"SELECT COUNT(*)
                                        FROM   BOM 
                                        WHERE  MTRLID = '{MTRLID}' 
                                           AND MTRLID_P = '{MTRLID_P}'";
            DataTable dataTable =  DatabaseManager.DB_Inquiry(existBOM_MTTLID);
            
            if(dataTable.Rows.Count == 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }






        //// 셀 단위 수정 후 SAVE 버튼을 눌렀을때, 저장
        //private void btnBOM_MODIFY_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (gvPRODUCT.RowCount == 0) return;

        //        // GetChanges 함수 = 수정된 데이터
        //        DataTable dtChanges = new DataTable();
        //        DataTable PRODUCT = (DataTable)gvPRODUCT.DataSource;
        //        dtChanges = PRODUCT.GetChanges(DataRowState.Modified);

        //        // 변경이 없으면 return
        //        if (dtChanges == null) return;

        //        string DBupdate = string.Empty;

        //        // 수정 쿼리문(RATE만 바꿀 수 있음.)
        //        if (dtChanges != null)
        //        {
        //            for (int i = 0; i < dtChanges.Rows.Count; i++)
        //            {
        //                DBupdate = $@"UPDATE BOM 
        //                            SET 
        //                                RATE = :RATE";

        //                // update_query에서 PRODNAME 을 #PRODNAME 으로 Replace
        //                DBupdate = DBupdate.Replace(":RATE", dtChanges.Rows[i]["RATE"].ToString());

        //                DatabaseManager.DB_Modify(DBupdate);
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    DataSearch();
        //}



        private void gvBOM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = gvBOM.Rows[e.RowIndex];

                // 선택된 행에 대한 작업 수행
                gvBOM_selectedMTRLID = selectedRow.Cells["품목코드"].Value.ToString();
            }
        }

        private void btnBOM_DELETE_Click(object sender, EventArgs e)
        {
            string DBdelete = string.Empty;

            try
            {
                if (gvBOM.RowCount == 0) return;

                BOM_DELETE bomDelete = new BOM_DELETE();

                if (bomDelete.ShowDialog() == DialogResult.Yes)
                {

                    DataGridViewRow selectedRow = gvBOM.CurrentRow;

                    if (selectedRow != null)
                    {
                        string deleteMTRLId = selectedRow.Cells["품목코드"].Value.ToString();
                        string deletePRODId = selectedRow.Cells["최종완제품코드"].Value.ToString();
                       
                        string deleteQuery = $@"UPDATE BOM
                                                SET DEL_YN = 'Y'
                                                WHERE MTRLID = '{deleteMTRLId}' AND
                                                      PRODID = '{deletePRODId}'";

                        // 선택 제품삭제
                        DatabaseManager.DB_Modify(deleteQuery);

                        // 제품 재검색
                        DataSearch();

                        MessageBox.Show("삭제되었습니다.");
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
