using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES.OrderMGR.ORDER_MGR
{
    public partial class ORDER_MGR : Form
    {
        List<string> StatusList = new List<string>() { "P", "S", "E" };

        public ORDER_MGR()
        {
            InitializeComponent();
        }

        private void ORDER_MGR_Load(object sender, EventArgs e)
        {
            // 텍스트박스 힌트 초기화
            tbMTRL_ID.Text = "품목코드";
            tbMTRL_NAME.Text = "품목명";
            tbMTRL_ID.ForeColor = SystemColors.GrayText;
            tbMTRL_NAME.ForeColor = SystemColors.GrayText;

            // 텍스트박스 힌트 이벤트 등록
            tbMTRL_ID.Enter += tbPROD_ID_Enter;
            tbMTRL_ID.Leave += tbPROD_ID_Leave;
            tbMTRL_NAME.Enter += tbPROD_NAME_Enter;
            tbMTRL_NAME.Leave += tbPROD_NAME_Leave;

            // 콤보 박스 초기화 이건 보류
            LoadCombo(StatusList, cbPORD_STATUS);

            // 수주 시작일 조건 초기화
            dtpORDER_END.Value = DateTime.Today.AddDays(+120);

            // GridView 초기화
            InitDataSearch();
        }

        // txtPROD_ID 힌트 제거
        private void tbPROD_ID_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지움.
            if (tbMTRL_ID.Text == "품목코드")
            {
                tbMTRL_ID.Text = "";
                tbMTRL_ID.ForeColor = Color.Black; // 폰트 색상을 변경
            }
        }

        // txtPROD_ID 힌트 설정
        private void tbPROD_ID_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(tbMTRL_ID.Text))
            {
                tbMTRL_ID.Text = "품목코드";
                tbMTRL_ID.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
            }
        }

        //txtPROD_NAME 힌트 제거
        private void tbPROD_NAME_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지움
            if (tbMTRL_NAME.Text == "품목명")
            {
                tbMTRL_NAME.Text = "";
                tbMTRL_NAME.ForeColor = Color.Black; // 폰트 색상을 변경
            }
        }

        // tbPROD_ID 힌트 설정
        private void tbPROD_NAME_Leave(object sender, EventArgs e)
        {
            // 텍스트 박스에서 포커스가 나갔을 때, 내용이 비어있으면 다시 힌트 설정
            if (string.IsNullOrWhiteSpace(tbMTRL_NAME.Text))
            {
                tbMTRL_NAME.Text = "품목코드";
                tbMTRL_NAME.ForeColor = SystemColors.GrayText; // 힌트 폰트 색상 변경.
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


        private void InitDataSearch()
        {
            // BOM 폼에서 선택된 제품 정보 조회 쿼리
            string DB_PORDER_Query = $@"
                                      SELECT PO.PORDSTAT                                발주상태             --P, S, E
                                             , PO.PORDID                                발주코드
                                             , PO.PORDFIRM                              발주처
                                             , PO.MTRLID                                발주품목코드
                                             , MT.MTRLNAME                              발주품목명
                                             , PO.PORDQTY                               발주수량
                                             , MT.MTRLCOST                              단가
                                             , (MT.MTRLCOST * 0.1)                      부가세
                                             , (MT.MTRLCOST * PO.PORDQTY * 1.1)         총액
                                      FROM PORDER PO
                                        LEFT JOIN MATERIAL  MT ON PO.MTRLID = MT.MTRLID
                                      WHERE  
                                             1 = 1";
            DatabaseManager.DB_Inquiry(DB_PORDER_Query, gvSALES);
        }
        private void DataSearch()
        {
            // BOM 폼에서 선택된 제품 정보 조회 쿼리
            string DB_PORDER_Query = $@"
                                      SELECT PO.PORDSTAT                                발주상태             --P, S, E
                                             , PO.PORDID                                발주코드
                                             , PO.PORDFIRM                              발주처
                                             , PO.MTRLID                                발주품목코드
                                             , MT.MTRLNAME                              발주품목명
                                             , PO.PORDQTY                               발주수량
                                             , MT.MTRLCOST                              단가
                                             , (MT.MTRLCOST * 0.1)                      부가세
                                             , (MT.MTRLCOST * PO.PORDQTY * 1.1)         총액
                                      FROM PORDER PO
                                        LEFT JOIN MATERIAL  MT ON PO.MTRLID = MT.MTRLID
                                      WHERE  
                                             1 = 1 AND
                                             PO.PORDDUEDATE >= '{dtpORDER_START.Value.Year}/{dtpORDER_START.Value.Month}/{dtpORDER_START.Value.Day}' 
                                             AND PO.PORDDUEDATE <= to_date('{dtpORDER_END.Value.Year}/{dtpORDER_END.Value.Month}/{dtpORDER_END.Value.Day}')+1 ";



            // 제품코드, 명에 따른 조회 조건 추가
            if (!string.IsNullOrEmpty(tbMTRL_ID.Text) && tbMTRL_ID.ForeColor != SystemColors.GrayText)
            {
                string MTRLID = tbMTRL_ID.Text;
                DB_PORDER_Query += $" AND PO.MTRLID LIKE '%{MTRLID.ToUpper()}%' \n";
            }
            if (!string.IsNullOrEmpty(tbMTRL_NAME.Text) && tbMTRL_NAME.ForeColor != SystemColors.GrayText)
            {
                string MTRLNAME = tbMTRL_NAME.Text;
                DB_PORDER_Query += $" AND MT.MTRLNAME LIKE '%{MTRLNAME}' \n";
            }

            // 수주처에 따른 조회 조건 추가
            if (!string.IsNullOrEmpty(tbPODFIRM.Text))
            {
                string PORD_Firm = tbPODFIRM.Text;
                DB_PORDER_Query += $" AND PO.PORDFIRM LIKE '%{PORD_Firm}%' \n";
            }

            // 수주코드에 따른 조회 조건 추가
            if (!string.IsNullOrEmpty(tbPORD_ID.Text))
            {
                string PORD_ID = tbPORD_ID.Text;
                DB_PORDER_Query += $" AND PO.PORDID LIKE '%{PORD_ID}%' \n";
            }

            // 수주상태에 다른 조회 조건 추가
            if (cbPORD_STATUS.SelectedIndex != -1)
            {
                string selectedItem = cbPORD_STATUS.SelectedItem.ToString();
                DB_PORDER_Query += $" AND PO.PORDSTAT LIKE '{selectedItem}' \n";
            }

            DB_PORDER_Query += $@"ORDER BY CASE 
                                                   WHEN PO.PORDSTAT = 'S' THEN 1
                                                   WHEN PO.PORDSTAT = 'P' THEN 2
                                                   WHEN PO.PORDSTAT = 'E' THEN 3
                                                   ELSE 4 -- 다른 값들에 대한 기본적인 정렬
                                               END,
                                               PO.PORDID ";

            // GridView 적용
            DatabaseManager.DB_Inquiry(DB_PORDER_Query, gvSALES);

            // GridView 칼럼명 설정 
            string[] PORDER_HeaderName = new string[] { "발주상태", "발주코드", "발주처", "발주품목코드", "발주품목명",
                                                        "발주수량", "단가", "부가세", "총액"};

            GridViewHeaderSetter(gvSALES, PORDER_HeaderName);

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

        private void btnPORDER_SEARCH_Click(object sender, EventArgs e)
        {
            DataSearch();
        }
    }
}
