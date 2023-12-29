using Oracle.ManagedDataAccess.Client;
using Pharmaceutical_MES.ProcessMGR.ProcessMgr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using MessageBox = System.Windows.Forms.MessageBox;
using SystemColors = System.Drawing.SystemColors;

namespace Pharmaceutical_MES.ProcessMGR.BOMMGR
{
    public partial class BOMMGR : Form
    {
        private string selectedPRODID;
        private string selectedPROCID;
        private DataGridViewRow selectedRow;

        public BOMMGR()
        {
            InitializeComponent();
        }

        private void BOMMGR_Load(object sender, EventArgs e)
        {
            // 콤보 박스 요소
            List<string> Product_TYPE_List = new List<string>()
            {
                "RAW",
                "MIX",
                "SEMI",
                "GOOD"
            };

            List<string> DEL_YN_List = new List<string>()
            {
                "Y",
                "N"
            };

            // 콤보박스 값 초기화
            LoadCombo(Product_TYPE_List, cbPROD_TYPE);
            LoadCombo(DEL_YN_List, cbPROD_DEL_YN);

            // 텍스트 박스 값 초기화
            TextBoxHint(tbPROD_ID, "품목코드");
            TextBoxHint(tbPROD_NAME, "품목명");

            // 텍스트 박스 힌트 이벤트 등록
            tbPROD_ID.Leave += tbPROD_ID_Leave;
            tbPROD_ID.Enter += tbPROD_ID_Enter;
            tbPROD_NAME.Leave += tbPROD_NAME_Leave;
            tbPROD_NAME.Enter += tbPROD_NAME_Enter;

            // 셀 클릭 이벤트 등록
            gvPRODUCT.CellClick += GridView_BOM_Search;
            gvBOM.CellClick += GridView_BOM_Get_SelectedCell;

            DataSearch();
        }


        private void btnPROD_INSERT_Click(object sender, EventArgs e)
        {
            BOM_INSERT bomInsert = new BOM_INSERT(selectedPROCID, selectedPRODID);
            if (bomInsert.ShowDialog() == DialogResult.Yes)
            {
                DataSearch();
            }
        }

        private void btnPROD_SEARCH_Click(object sender, EventArgs e)
        {
            DataSearch();
        }

        // 조회
        private void DataSearch()
        {
            // 품목: Product + Material
            string prodSearchQuery = $@"SELECT   TP.TPID             품목코드
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
                                                1 = 1
                                        ";

            List<string> itemList = new List<string>();

            // 품목유형에 따른 조회 조건
            if (cbPROD_TYPE.SelectedIndex != -1)
            {
                string selectedItem = cbPROD_TYPE.SelectedItem.ToString();
                string addCondition = $" AND TP.TPTYPE LIKE '{selectedItem}' \n";
                prodSearchQuery += addCondition;
            }
            
            // 제품코드, 명에 따른 조회 조건 추가
            if (!string.IsNullOrEmpty(tbPROD_ID.Text) && tbPROD_ID.ForeColor != SystemColors.GrayText)
            {
                string PRODID = tbPROD_ID.Text;
                prodSearchQuery += $" AND TP.TPID LIKE '%{PRODID.ToUpper()}%' \n";
            }
            if (!string.IsNullOrEmpty(tbPROD_NAME.Text) && tbPROD_NAME.ForeColor != SystemColors.GrayText)
            {
                string PRODNAME = tbPROD_NAME.Text;
                prodSearchQuery += $" AND TP.TPNAME LIKE '%{PRODNAME}' \n";
            }

            // 삭제여부에 따른 조회 조건 추가
            //if (cbPROD_DEL_YN.SelectedIndex != -1)
            //{
            //    string selectedItem = cbPROD_DEL_YN.SelectedItem.ToString();
            //    string addCondition = $" AND TP.TPDEL_YN LIKE '%{selectedItem}%' \n";
            //    CBInsertCondition(itemList, cbPROD_DEL_YN, prodSearchQuery, addCondition);
            //}
            prodSearchQuery += $@" ORDER BY TP.TPID, TP.TPNAME, TP.TPTYPE";


            DatabaseManager.DB_Inquiry(prodSearchQuery, gvPRODUCT);

            // GridView 칼럼명 설정 (, "삭제여부" 미포함) 
            string[] HeaderName = new string[] { "품목코드", "품목명", "품목유형", "단위", "단가"};


            if (gvPRODUCT.Rows.Count > 0)
            {
                for (int i = 0; i < HeaderName.Length; i++)
                {
                    gvPRODUCT.Columns[i].HeaderText = $"{HeaderName[i]}";
                    gvPRODUCT.Columns[i].ReadOnly = true;
                    gvPRODUCT.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                gvPRODUCT.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                gvPRODUCT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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



        // 품목셀 선택시 해당 품목 BOM 정보 조회(클릭 이벤트)
        private void GridView_BOM_Search(object sender, DataGridViewCellEventArgs e)
        {
            selectedPRODID = gvPRODUCT.Rows[e.RowIndex].Cells[0].Value.ToString(); // 품목코드 단위로
             


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
                                   
                                    START WITH BM.MTRLID = '{selectedPRODID}'                        
                                    CONNECT BY PRIOR BM.MTRLID = BM.MTRLID_P
                                    ORDER SIBLINGS BY BM.PRODID";


            DatabaseManager.DB_Inquiry(DB_BOM_Query, gvBOM);

            string[] HeaderName = new string[] { "    공정코드", "    공정순서", "    공정명", "    품목코드", "     품목명", "     비율" };

            if (gvBOM.Rows.Count > 0)
            {
                for (int i = 0; i < HeaderName.Length; i++)
                {
                    gvBOM.Columns[i].HeaderText = $"{HeaderName[i]}";
                    gvBOM.Columns[i].ReadOnly = true;
                    gvBOM.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }   

                // 빈 레코드 표시 안함
                gvBOM.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                gvBOM.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
        }

        private void GridView_BOM_Get_SelectedCell(object sender, DataGridViewCellEventArgs e)
        {
            selectedPROCID = gvBOM.Rows[e.RowIndex].Cells[0].Value.ToString();
            selectedRow = gvBOM.Rows[e.RowIndex];
        }

    }
}
