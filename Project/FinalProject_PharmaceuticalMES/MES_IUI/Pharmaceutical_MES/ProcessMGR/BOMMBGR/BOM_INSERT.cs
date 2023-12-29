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
        private string BOM_ProdID;
        private string BOM_ProcID;

        public BOM_INSERT()
        {
            InitializeComponent();
        }

        public BOM_INSERT(string SelectedCell, string SelectedCell2)
        {
            InitializeComponent();
            BOM_ProdID = SelectedCell2;
            BOM_ProcID = SelectedCell;
            
        }

        private void BOM_INSERT_Load(object sender, EventArgs e)
        {
            // 선택된 계층에서의 BOM 설정, PROCESS는 고정
            txtPROC_ID.Text = DatabaseManager.DB_GetColumnValue("PROCID", "PROCESS", BOM_ProcID);
            txtPROC_SEQ.Text = DatabaseManager.DB_GetColumnValue("PROCID_SEQ", "PROCESS", BOM_ProcID);
            txtPROC_NAME.Text = DatabaseManager.DB_GetColumnValue("PROCNAME", "PROCESS", BOM_ProcID);

            // 선택된 계층에서의 BOM 설정 PROCESS는 고정
            txtPROC_ID.ReadOnly = true;
            txtPROC_SEQ.ReadOnly = true;
            txtPROC_NAME.ReadOnly = true;

            // 텍스트박스 힌트 초기화
            txtPROD_ID.Text = "품목코드";
            txtPROD_NAME.Text = "품목명";
            txtPROD_ID.ForeColor = SystemColors.GrayText;
            txtPROD_NAME.ForeColor = SystemColors.GrayText;

            // 텍스트박스 힌트 이벤트 등록
            txtPROD_ID.Enter += txtPROD_ID_Enter;
            txtPROD_ID.Leave += txtPROD_ID_Leave;
            txtPROD_NAME.Enter += txtPROD_NAME_Enter;
            txtPROD_NAME.Leave += txtPROD_NAME_Leave;

            // GridView 초기화
            DataSearch();
        }

        // txtPROD_ID 힌트 제거
        private void txtPROD_ID_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지웁니다.
            if (txtPROD_ID.Text == "품목코드")
            {
                txtPROD_ID.Text = "";
                txtPROD_ID.ForeColor = Color.Black; // 힌트 텍스트와 구분하기 위해 폰트 색상을 변경합니다.
            }
        }

        // txtPROD_ID 힌트 설정
        private void txtPROD_ID_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(txtPROD_ID.Text))
            {
                txtPROD_ID.Text = "품목코드";
                txtPROD_ID.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }

        //txtPROD_NAME 힌트 제거
        private void txtPROD_NAME_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지움
            if (txtPROD_NAME.Text == "품목명")
            {
                txtPROD_NAME.Text = "";
                txtPROD_NAME.ForeColor = Color.Black; // 폰트 색상을 변경
            }
        }

        // tbPROD_ID 힌트 설정
        private void txtPROD_NAME_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(txtPROD_NAME.Text))
            {
                txtPROD_NAME.Text = "품목코드";
                txtPROD_NAME.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }


        private void DataSearch()
        {
            // BOM 폼에서 선택된 제품 정보 조회 쿼리
            string DB_PROC_Query = $@"SELECT    TP.TPID             품목코드
                                              , TP.TPNAME           품목명
                                              , TP.TPTYPE           품목유형
                                              , TP.TPUNIT           단위
                                              , TP.TPCOST           단가
                                                 
                                      FROM (SELECT   MT.MTRLID     TPID
                                                      , MT.MTRLNAME   TPNAME
                                                      , MT.MTRLTYPE   TPTYPE
                                                      , MT.MTRLUNIT   TPUNIT
                                                      , MT.MTRLCOST   TPCOST
                                                       
                                              FROM MATERIAL MT
                                              UNION ALL
                                              SELECT   PD.PRODID    TPID
                                                      , PD.PRODNAME  TPNAME
                                                      , PD.PRODTYPE  TPTYPE
                                                      , PD.PRODUNIT  TPUNIT
                                                      , PD.PRODCOST  TPCOST
                                                         
                                              FROM PRODUCT PD) TP
                                      WHERE
                                              TP.TPID = BOM_ProdID";

            // 위 제품 BOM 정보 조회 쿼리
            string DB_BOM_Query = $@"SELECT                                   -- 현재 조회가 안되는거 그거 PROCID _SEQ가 입력이 안되있어서 연결이 안되는거임.
                                        PC.PROCID                공정코드
                                       , PC.PROCID_SEQ           공정순서
                                       , PC.PROCNAME             공정명
                                       , BM_SUB.MTRLID           품목코드
                                       , BM_SUB.MTRLNAME         품목명
                                       , BM_SUB.RATE             비율
                                    FROM (
                                          SELECT 
	                                             BM.MTRLID        MTRLID
                                               , BM.MTRLID_P      MTRLID_P
                                               , BM.ORDERS        ORDERS
                                               , BM.RATE          RATE
                                               , BM.PRODID        PRODID
                                               , MT.MTRLNAME      MTRLNAME
                                               , CASE
                                                   WHEN BM.MTRLID LIKE 'SM%' THEN 3 
                                                   WHEN BM.MTRLID LIKE 'MX%' THEN 2 
                                                   WHEN BM.MTRLID LIKE 'M%'  THEN 1
                                                   WHEN BM.MTRLID LIKE 'P%'  THEN null
                                                   ELSE                           null
                                               END PROCID_SEQ
                                           FROM BOM BM
                                             LEFT JOIN MATERIAL MT ON BM.MTRLID = MT.MTRLID
                                          )     BM_SUB
                                      LEFT JOIN PROCESS  PC ON BM_SUB.PROCID_SEQ = PC.PROCID_SEQ
                                    WHERE PC.PROCID = '{txtPROC_ID.Text}' 
                                        AND PC.PROCNAME = '{txtPROC_NAME.Text}'
                                        AND PC.PROCID_SEQ = '{txtPROC_SEQ.Text}'

                                    ORDER BY BM_SUB.ORDERS";

            // GridView 적용
            DatabaseManager.DB_Inquiry(DB_PROC_Query, gvPRODUCT);
            DatabaseManager.DB_Inquiry(DB_BOM_Query, gvBOM);

            // GridView 칼럼명 설정 
            string[] PROD_HeaderName = new string[] { "품목코드", "품목명", "품목유형", "단위", "단가" };
            string[] BOM_HeaderName  = new string[] { "공정코드", "공정순서", "공정명", "품목코드", "품목명", "비율" };

            GridViewHeaderSetter(gvPRODUCT, PROD_HeaderName);
            GridViewHeaderSetter(gvBOM, BOM_HeaderName);

            
            // ReadOnly 값 세팅
            int[] PROD_HeaderIDX = GetHeaderIndexes(PROD_HeaderName);
            int[] BOM_HeaderIDX = GetHeaderIndexes(BOM_HeaderName, new string[] { "비율" });
            GridViewReadOnlySet(gvBOM, BOM_HeaderIDX );
            GridViewReadOnlySet(gvPRODUCT, PROD_HeaderIDX);
        }

        // 헤더 인덱스 배열 추출 
        private int[] GetHeaderIndexes(string[] headerNames, string[] targetHeader)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < headerNames.Length; i++)
            {
                for(int j = 0; j < targetHeader.Length; j++)
                {
                    if (!headerNames[i].Equals(targetHeader[j], StringComparison.OrdinalIgnoreCase))
                    {
                        indexes.Add(i);
                    }
                }
            }

            return indexes.ToArray();
        }

        // 헤더 인덱스 배열 추출 
        private int[] GetHeaderIndexes(string[] headerNames)
        {
            List<int> indexes = new List<int>();

            for (int i = 0; i < headerNames.Length; i++)
            {
                indexes.Add(i);
            }

            return indexes.ToArray();
        }

        // ReadOnly 설정
        private void GridViewReadOnlySet(DataGridView dataGridView, int[] indexes)
        {
            if (dataGridView.Columns.Count > 0)
            {
                foreach(int index in indexes)
                {
                    dataGridView.Columns[index].ReadOnly = true;
                }
            }
        }

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


        // 셀 단위 수정 후 SAVE 버튼을 눌렀을때, 저장
        private void btnBOM_MODIFY_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPRODUCT.RowCount == 0) return;

                // GetChanges 함수 = 수정된 데이터
                DataTable dtChanges = new DataTable();
                DataTable PRODUCT = (DataTable)gvPRODUCT.DataSource;
                dtChanges = PRODUCT.GetChanges(DataRowState.Modified);

                // 변경이 없으면 return
                if (dtChanges == null) return;

                string DBupdate = string.Empty;

                // 수정 쿼리문(RATE만 바꿀 수 있음.)
                if (dtChanges != null)
                {
                    for (int i = 0; i < dtChanges.Rows.Count; i++)
                    {
                        DBupdate = $@"UPDATE BOM 
                                    SET 
                                        RATE = :RATE";

                        // update_query에서 PRODNAME 을 #PRODNAME 으로 Replace
                        DBupdate = DBupdate.Replace(":RATE", dtChanges.Rows[i]["RATE"].ToString());

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

        private void btnBOM_DELETE_Click(object sender, EventArgs e)
        {
            if (gvBOM.SelectedRows.Count > 0)
            {
                // 선택된 행의 첫 번째 셀에 있는 값.
                string selectedMTRLID = gvBOM.SelectedRows[0].Cells["MTRLID"].Value.ToString(); 

                string deleteQuery = $@"DELETE FROM BOM WHERE MTRLID = '{selectedMTRLID}'";

                // DB에서 선택된 행을 삭제하는 함수를 호출
                DatabaseManager.DB_Modify(deleteQuery);

                DataSearch();
            }
        }
    }
}
