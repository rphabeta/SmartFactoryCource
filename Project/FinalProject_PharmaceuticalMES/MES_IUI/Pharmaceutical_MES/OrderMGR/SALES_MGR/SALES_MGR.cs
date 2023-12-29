using Final_FUI;
using Oracle.ManagedDataAccess.Client;
using Pharmaceutical_MES.ProcessMGR.BOMMGR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewPage.작업관리;

namespace Pharmaceutical_MES.OrderMGR.SALES_MGR
{
    public partial class SALES_MGR : Form
    {
        List<string> StatusList = new List<string>() { "W", "E", "M" };

        public SALES_MGR()
        {
            InitializeComponent();
        }

        private void SALES_MGR_Load(object sender, EventArgs e)
        {
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

            // 콤보 박스 초기화
            LoadCombo(StatusList, cbSALES_STATUS);

           
            // GridView 초기화
            DataSearch();
        }

        // txtPROD_ID 힌트 제거
        private void txtPROD_ID_Enter(object sender, EventArgs e)
        {
            // 텍스트 박스에 포커스가 들어왔을 때, 힌트 텍스트가 아닌 경우에만 내용을 지움.
            if (txtPROD_ID.Text == "품목코드")
            {
                txtPROD_ID.Text = "";
                txtPROD_ID.ForeColor = Color.Black; // 폰트 색상을 변경
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
            string DB_SALES_Query = $@"SELECT --SO.STDATE                       수주일자
                                                SO.SOSTAT                       진행상태
                                               , SO.SOID                        수주번호
                                               , SO.SOFIRM                      거래처
                                               , SO.INSUSER                     등록자
                                               , SO.PRODID                      품목코드
                                               , PD.PRODNAME                    품목명
                                               , SO.SOQTY                       수주수량
                                               , PD.PRODUNIT                    단위
                                               , PD.PRODCOST                    단가
                                               , (PD.PRODCOST * 0.1)            부가세
                                               , (PD.PRODCOST * 1.1 * SO.SOQTY) 총액
                                               , SO.SODUEDATE                   납품예정일
                                               , SO.INSDTTM                     등록일
                                               , WO.UPDDTTM                     수정일
                                               , WO.UPDUSER                     수정자
                                               , SO.DEL_YN                      삭제여부
                                      FROM SALES SO
                                          LEFT JOIN WORKORDER  WO ON SO.SOID   = WO.SOID     
                                          INNER JOIN PRODUCT   PD ON SO.PRODID = PD.PRODID  
                                      WHERE  
                                             1 = 1 
                                      ";



            // 제품코드, 명에 따른 조회 조건 추가
            if (!string.IsNullOrEmpty(txtPROD_ID.Text) && txtPROD_ID.ForeColor != SystemColors.GrayText)
            {
                string PRODID = txtPROD_ID.Text;
                DB_SALES_Query += $" AND SO.PRODID LIKE '%{PRODID.ToUpper()}%' \n";
            }
            if (!string.IsNullOrEmpty(txtPROD_NAME.Text) && txtPROD_NAME.ForeColor != SystemColors.GrayText)
            {
                string PRODNAME = txtPROD_NAME.Text;
                DB_SALES_Query += $" AND PD.PRODNAME LIKE '%{PRODNAME}' \n";
            }

            // 수주처에 따른 조회 조건 추가
            if (!string.IsNullOrEmpty(txtSALES_SOFIRM.Text))
            {
                string SO_Firm = txtSALES_SOFIRM.Text;
                DB_SALES_Query += $" AND SO.SOFIRM LIKE '%{SO_Firm}%' \n";
            }

            // 수주코드에 따른 조회 조건 추가
            if (!string.IsNullOrEmpty(txtSALES_SOID.Text))
            {
                string SO_ID = txtSALES_SOID.Text;
                DB_SALES_Query += $" AND SO.SOID LIKE '%{SO_ID}%' \n";
            }

            // 수주상태에 다른 조회 조건 추가
            if (cbSALES_STATUS.SelectedIndex != -1)
            {
                string selectedItem = cbSALES_STATUS.SelectedItem.ToString();
                DB_SALES_Query += $" AND SO.SOSTAT LIKE '{selectedItem}' \n";
            }


            DB_SALES_Query += $@" AND SODUEDATE >= SYSDATE
                                  ORDER BY SODUEDATE ";


            // GridView 적용
            DatabaseManager.DB_Inquiry(DB_SALES_Query, gvSALES);

            // GridView 칼럼명 설정 
            string[] SALES_HeaderName = new string[] { "진행상태", "수주번호", "거래처", "등록자", "품목코드", "품목명" , "수주수량",
                                                       "단위", "단가", "부가세", "총액", "납품예정일", "등록일", "수정일", "수정자", "삭제여부"};

            GridViewHeaderSetter(gvSALES, SALES_HeaderName);


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

        

        


        // 수주 등록
        private void btnWO_STANDBY_REGIST_Click(object sender, EventArgs e)
        {
            if (gvSALES.SelectedRows.Count > 0)
            {
                // 선택된 행의 첫 번째 셀에 있는 값.
                string selectedSO_STAT = gvSALES.SelectedRows[0].Cells["진행상태"].Value.ToString();
                string selectedSO_ID = gvSALES.SelectedRows[0].Cells["수주번호"].Value.ToString();
                string selectedSO_INSUSER = gvSALES.SelectedRows[0].Cells["등록자"].Value.ToString();
                string selectedSO_PRODID = gvSALES.SelectedRows[0].Cells["품목코드"].Value.ToString();
                int selectedSO_SOQTY = Convert.ToInt32(gvSALES.SelectedRows[0].Cells["수주수량"].Value);
                string selectedSO_SODUEDATE = gvSALES.SelectedRows[0].Cells["납품예정일"].Value.ToString();
                string selectedSO_INSDTTM = gvSALES.SelectedRows[0].Cells["등록일"].Value.ToString();
                

                // 공백을 기준으로 날짜와 시간을 분리
                string[] parts = selectedSO_SODUEDATE.Split(' ');

                if (parts.Length == 3)
                {
                    string datePart = parts[0];
                    string timePart = parts[2];

                    // 오후인 경우 시간을 조정
                    if (parts[1] == "오후")
                    {
                        // 시간을 문자열에서 추출하고 12를 더해줌
                        int hours = int.Parse(timePart.Split(':')[0]) + 12;
                        timePart = hours.ToString() + timePart.Substring(timePart.IndexOf(':'));
                    }

                    // 최종 문자열 조합
                    selectedSO_SODUEDATE = $"{datePart} {timePart}";
                }


                // W 상태(작업지시) 체크
                string checkRegitWO_Query = $@"
                                               SELECT * COUNT(*)
                                               FROM SALES
                                               WHERE SOID = '{selectedSO_ID}'";

                // 수주 상태 대기 상태로 변환
                string updateSALES_Query = $@"UPDATE SALES 
                                            SET SOSTAT = 'W' 
                                            WHERE 
                                                SOID = '{selectedSO_ID}'";

                // WORKORDER에 등록
                string insertWO = $@"INSERT INTO WORKORDER(WOID
                                                           , WOSTAT
                                                           , PLANDTTM
                                                           , PRODID
                                                           , PLANQTY
                                                           , PROCID
                                                           , INSUSER
                                                           , INSDTTM
                                                           , SOID)
                                                    SELECT ('W' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(workorder_seq.NEXTVAL, 3, '0'))
                                                         , 'P'
                                                         , '{selectedSO_SODUEDATE}' 
                                                         , '{selectedSO_PRODID}'
                                                         , '{selectedSO_SOQTY}'
                                                         , PROCID
                                                         , '{selectedSO_INSUSER}'
                                                         , TO_CHAR(SYSDATE, 'YYYYMMDD HH24:MI:SS')
                                                         , '{selectedSO_ID}'
                                                      FROM PROCESS
                                                     WHERE PROCID IN ('PC001', 'PC002', 'PC003')
                                                   ";

                DataTable dataTable = DatabaseManager.DB_Inquiry(updateSALES_Query);
                if(dataTable.Rows.Count == 0)
                {
                    // 트랜잭션 단위 실행
                    using (var conn = DatabaseManager.GetConnection())
                    {
                        // 트랜잭션 시작
                        using (OracleTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                using (OracleCommand updateCommand = new OracleCommand(updateSALES_Query, conn))
                                {
                                    updateCommand.Transaction = transaction;
                                    updateCommand.ExecuteNonQuery();
                                }

                                using (OracleCommand updateCommand = new OracleCommand(insertWO, conn))
                                {
                                    updateCommand.Transaction = transaction;
                                    updateCommand.ExecuteNonQuery();
                                }

                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error: " + ex);
                            }
                        }
                    }
                }
            }
        }

        // 수주 조회
        private void btnSALES_SEARCH_Click(object sender, EventArgs e)
        {
            DataSearch();
        }

        private void btnPORDER_INSERT_Click(object sender, EventArgs e)
        {
            SALES_INSERT bomInsert = new SALES_INSERT();
            if (bomInsert.ShowDialog() == DialogResult.Yes)
            {
                DataSearch();
            }
        }

        private void btnPRORDER_DELETE_Click(object sender, EventArgs e)
        {
            WorkDelete delete = new WorkDelete();
            if (delete.ShowDialog() == DialogResult.Yes)
            {
                string SOID = gvSALES.CurrentRow.Cells["수주번호"].Value.ToString();
                string delete_query = string.Empty;

                //수정쿼리문
                delete_query = $@"UPDATE SALES SET
                                             DEL_YN = 'Y'
                                       WHERE SOID = '{SOID}'
                                      ";

                

                // WORKORDER에 등록
                string delete_query2 = $@"UPDATE WORKORDER
                                            SET UPDUSER = '{로그인.userid}',
                                                UPDDTTM = SYSTIMESTAMP
                                            WHERE SOID = '{SOID}' 
                                                   ";

                DataTable dataTable = DatabaseManager.DB_Inquiry(delete_query);
                if(dataTable.Rows.Count == 0)
                {
                    // 트랜잭션 단위 실행
                    using (var conn = DatabaseManager.GetConnection())
                    {
                        // 트랜잭션 시작
                        using (OracleTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                using (OracleCommand updateCommand = new OracleCommand(delete_query, conn))
                                {
                                    updateCommand.Transaction = transaction;
                                    updateCommand.ExecuteNonQuery();
                                }

                                using (OracleCommand updateCommand = new OracleCommand(delete_query2, conn))
                                {
                                    updateCommand.Transaction = transaction;
                                    updateCommand.ExecuteNonQuery();
                                }

                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error: " + ex);
                            }
                        }
                    }
                }


                DatabaseManager.DB_Inquiry(delete_query);
            }
        }
    }
}
