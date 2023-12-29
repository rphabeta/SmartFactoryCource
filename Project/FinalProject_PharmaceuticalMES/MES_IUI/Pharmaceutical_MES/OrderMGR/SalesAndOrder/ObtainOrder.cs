using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OracleCommand = Oracle.ManagedDataAccess.Client.OracleCommand;
using OracleConnection = Oracle.ManagedDataAccess.Client.OracleConnection;
using OracleDataReader = Oracle.ManagedDataAccess.Client.OracleDataReader;
using OracleParameter = Oracle.ManagedDataAccess.Client.OracleParameter;

namespace Pharmaceutical_MES
{
    public partial class ObtainOrder : Form
    {
        // 수주번호: cbOrderCode, 수주일자: dtpOrderStart, dtpOrderEnd, 제품명:tbProductName  
        // 수주정보 확인: btnEnquire, 수주정보 미조건부 확인: btnReset, 
        // 수주정보 목록: dgvOrderInfo
        // 작업지시 목록 추가: btnInstructionAdd, 제품명: cbProductName, 현재재고: tbProductQTY, 수주번호: tbSaleCode, 납기일자: dtpSaleDeadLine,
        // 수주량: tbSaleQty, 수주처: tbSoFirm, LOTNO: tbLotNo, 작업시 등록 수량: tbRegistOrderQTY
        // 발주등록: btnOrder 원재료정보: dgvMaterialRegist
        
        DatabaseManager databaseManager = new DatabaseManager();
        public ObtainOrder()
        {
            InitializeComponent();
            LoadCombo("SELECT PRODNAME FROM PRODUCT", cbProductName); // 제품 콤보박스 최신화
            LoadCombo("SELECT SOID FROM SALES", cbOrderCode);         // 수주 콤보박스 최신화
        }


        // 수주 정보 조회
        private void btnEnquire_Click(object sender, EventArgs e)
        {

            DateTime startDate = dtpOrderStart.Value;  // 시작 날짜
            DateTime endDate = dtpOrderEnd.Value;      // 종료 날짜
            var selectedOrderNum = cbOrderCode.SelectedItem;
            string productName = tbProductName.Text;
            string query = $@"
                                SELECT ~~
                            ";                      // 조건부 조회 쿼리
            try
            {
                // 전체 조건 입력 -> 조건부 조회
                if (selectedOrderNum != null && productName != null)
                {
                    databaseManager.stdSearchData(query, dgvOrderInfo);
                }
                else
                {
                    MessageBox.Show("조건검색을 위해서 모든 조건을 입력하십시오.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("조건을 올바른 값으로 바꿔주십시오.");
            }
        }

        // 수주 조건 컨트롤 값 초기화
        private void btnReset_Click(object sender, EventArgs e)
        {
            dtpOrderStart.Value = DateTime.Now;
            dtpOrderEnd.Value = DateTime.Now;
            cbOrderCode.SelectedItem = null;
            tbProductName.Text = null;
        }

        // 조건부 X -> 전체 조회
        private void btnEnquireAll_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpOrderStart.Value;  // 시작 날짜
            DateTime endDate = dtpOrderEnd.Value;      // 종료 날짜
            var selectedOrderNum = cbOrderCode.SelectedItem;
            string productName = tbProductName.Text;
            string query = $@"
                                SELECT ~~
                                
                            ";                      // 전체 조회 쿼리
            databaseManager.stdSearchData(query, dgvOrderInfo);
        }


        // 수주 작업 지시 등록
        private void btnInstructionAdd_Click(object sender, EventArgs e)
        {
            // order에대한 정보 받아서 데이터베이스에 업데이트 하면 되겠네.
            try
            {
                using (var conn = DatabaseManager.GetConnection())
                {
                    // 여기 쿼리문 바꿔야함.
                    string query = $@"
                                INSERT INTO PORDER (PORDID, MTRLID, PORDQTY)
                                VALUES (
                                          :orderCode,
                                          :MTRLName,
                                          :orderQTY
                                        )";

                    using (var cmd = new OracleCommand(query, conn))
                    {
                        //cmd.Parameters.Add(new OracleParameter(":orderCode", OracleDbType.Int32)).Value = orderCode;
                        //cmd.Parameters.Add(new OracleParameter(":MTRLName", OracleDbType.Varchar2)).Value = MTRLName;
                        //cmd.Parameters.Add(new OracleParameter(":orderQTY", OracleDbType.Int32)).Value = OrderQTY;

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("새로운 작업지시 목록 추가 성공");
                        }
                        else
                        {
                            MessageBox.Show("새로운 작업지시 목록 추가 실패");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // 에러 처리
                MessageBox.Show("새로운 작업지시 목록 추가 실패: " + ex.Message);
            }
        }

        // 발주 등록
        private void btnOrder_Click(object sender, EventArgs e)
        {
            // 선택된 행에 원재료 이름 가져옴
            string selectedMTRLValue = (string)dgvMaterialRegist.CurrentRow.Cells["MTRLNAME"].Value;

            if (selectedMTRLValue != null)
            {
                // 팝업 폼 열기
                using (Order order = new Order(selectedMTRLValue))
                {
                    order.ShowDialog(); // Modal 창
                }
            }
        }

        


        // 콤보박스의 요소가 선택되었을 때 일어나야할 기능들
        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {

            // 선택된 제품에 대한 데이터 조회
            string selectedProduct = cbProductName.SelectedItem.ToString();
            // 선택된 제품에대한 현재 수량 표기
            LoadDataForCurrentQTY(selectedProduct);
            // 발주를 위한 원재료 정보 조회
            LoadDataForSelectedProduct(selectedProduct, dgvMaterialRegist);
        }
        //---------------------------------------------------------------


        // 선택된 제품에대한 현재 수량 표기
        private void LoadDataForCurrentQTY(string selectedProduct)
        {
            // 수주 관련 테이블
            string query_SALES = $@"
                                    SELECT SALES.SOID, SALES.SOSAT, SALES.SOFIRM, SALES.SOQTY, SALES.SODUEDATE, SALES.PRODID, 
                                            PRODUCT.PRODNAME,
                                            STORAGEPRODUCT.PRODQTY 
                                    FROM SALES
                                    JOIN PRODUCT ON SALES.PRODID = PRODUCT.PRODID
                                    JOIN STORAGEPRODUCT ON SALES.PRODID = STORAGEPRODUCT.PRODID
                                    WHERE PRODUCT.PRODNAME = :productName";

            using (OracleConnection conn = DatabaseManager.GetConnection())
            {
                using (OracleCommand cmd = new OracleCommand(query_SALES, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("productName", selectedProduct));
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            // STORAGEPRODUCT.PRODQTY 컬럼의 값을 텍스트박스에 표시
                            tbProductQTY.Text = rdr["PRODQTY"].ToString();
                        }
                        else
                        {
                            // 선택된 제품에 대한 정보가 없을 경우 처리
                            MessageBox.Show("선택된 제품에 대한 정보가 없습니다.");
                        }
                    }
                }
            }
        }




        // 선택된 제품에 대한 원재료 데이터 조회 및 표시
        private void LoadDataForSelectedProduct(string selectedProduct, DataGridView dataGridView)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    // 쿼리 멘토님과 리뷰 통해서 수정
                    string query = $@"
                    SELECT 
                        MATERIAL.MTRLID,
                        MATERIAL.MTRLNAME,
                        ((SALES.SQTY - STORAGEPRODUCT.MTRLQTY) * BOM.RATE) AS NEEDEDQTY,
                        STORAGEPRODUCT.MTRLQTY AS CURRENTQTY,
                        (SALES.SQTY - STORAGEPRODUCT.MTRLQTY * BOM.RATE - STORAGEPRODUCT.MTRLQTY) AS SHORTAGEQTY
                    FROM
                        MATERIAL
                            JOIN을 어떻게 구성할지 감이 잘 안잡힘.
                    WHERE
                        PRODUCT.NAME = :productName";

                    cmd.Parameters.Add(new OracleParameter(":productName", OracleDbType.Varchar2)).Value = selectedProduct;
                    cmd.CommandText = query;

                    databaseManager.stdSearchData(query, dataGridView);
                }
            }
        }



        // 콤보박스 element 세팅
        private void LoadCombo(string query, ComboBox comboBox)
        {
            try
            {
                OracleConnection conn = DatabaseManager.GetConnection();
                
                //string query = "SELECT PRODNAME FROM PRODUCT";
                using (OracleCommand command = new OracleCommand(query, conn))
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox.Items.Add(reader["PRODNAME"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"에러 발생: {ex.Message}");
            }
        }

        
    }
}

