using Final_FUI;
using Oracle.ManagedDataAccess.Client;
using Pharmaceutical_MES;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewPage.작업관리
{
    public partial class WorkInsert : Form
    {
        public string PROCESSID { get; set; }
        public string WOID { get; set; }

        DatabaseManager databaseManager = new DatabaseManager();

        string PRD_query = $@"SELECT PRODID, PRODNAME FROM PRODUCT";

        public WorkInsert()
        {
            InitializeComponent();
        }


        //테이블에서 특정 칼럼 데이터를 가져와 콤보박스에 설정
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

        private void WorkInsert_Load(object sender, EventArgs e)
        {
            //databaseManager.stdSearchData(IST_query, dataGridView1);
            databaseManager.stdSearchData(PRD_query, ProductGrid);

            List<string> Product_TYPE_List = new List<string>()
            {
                "과립",
                "타정",
                "포장"
            };

            // 콤보박스 값 초기화
            LoadCombo(Product_TYPE_List, cbProcess);

            if (InsertGrid.Columns.Count == 0)
            {
                // DataGridView에 열 추가
                InsertGrid.Columns.Add("PRODID", "제품코드");
                InsertGrid.Columns.Add("PRODNAME", "제품명");
                InsertGrid.Columns.Add("PLANDTTM", "계획일자");
                InsertGrid.Columns.Add("PLANQTY", "수량");
                InsertGrid.Columns.Add("PROCID", "공정");
                InsertGrid.Columns.Add("INSUSER", "등록자");

                string[] HeaderName = new string[] { "제품코드", "제품명", "계획일자", "수량", "공정", "등록자" };

                GridViewHeaderSetter(InsertGrid, HeaderName);
            }

            string[] PROD_H = new string[] { "제품코드", "제품명" };
            GridViewHeaderSetter(ProductGrid, PROD_H);

            // tbCount 텍스트박스에 필요수량 자동 입력

            // tbInsuser 텍스트박스에 로그인한 ID 자동 입력
            tbInsuser.Text = 로그인.userid;
        }

        private void ProductGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            tbProductName.Text = this.ProductGrid.CurrentRow.Cells["PRODNAME"].Value.ToString();
            tbProductID.Text = this.ProductGrid.CurrentRow.Cells["PRODID"].Value.ToString();

            //if (tbProductID.Text == "MS001" || tbProductName.Text == "SCRAPPED")
            //{
            //    cbProcess.SelectedIndex = 0; //과립
            //}

            //if (tbProductID.Text == "P0001" ||
            //    tbProductID.Text == "P0002" ||
            //    tbProductName.Text == "PVC Scr 100" ||
            //    tbProductName.Text == "PVC Scr 50")
            //{
            //    cbProcess.SelectedIndex = 1; //포장
            //}
        }

        private void GridViewHeaderSetter(DataGridView dataGridView, string[] header)
        {
            if (dataGridView.Rows.Count > 0)
            {
                for (int i = 0; i < header.Length; i++)
                {
                    dataGridView.Columns[i].HeaderText = $"{header[i]}";
                    //dataGridView.Columns[i].ReadOnly = true;
                    dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // 빈 레코드 표시 안함
                dataGridView.AllowUserToAddRows = false;

                // 헤더 위치 정렬(가운데)
                dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        // 제품명에 따른 조회
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ProductName = tbProductName_Search.Text;
            string DB_Product = $@"SELECT PRODID, PRODNAME 
                                   FROM PRODUCT 
                                   WHERE PRODNAME LIKE '%{ProductName}%'";
            databaseManager.stdSearchData(DB_Product, ProductGrid);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sel_product_qry = $@"SELECT COUNT(*) 
                                        FROM PRODUCT
                                        WHERE PRODNAME = '{tbProductName.Text}'
                                          AND PRODID = '{tbProductID.Text}'";

            DataTable select_Table = DatabaseManager.DB_Inquiry(sel_product_qry);

            // GridView 칼럼명
            string[] HeaderName = new string[] { "제품코드", "제품명", "계획일자", "수량", "공정", "등록자" };

            GridViewHeaderSetter(InsertGrid, HeaderName);

            if (select_Table.Rows[0][0].ToString() == "1")
            {
                if (
                    string.IsNullOrEmpty(tbProductID.Text) ||
                    string.IsNullOrEmpty(tbProductName.Text) ||
                    string.IsNullOrEmpty(dateTimePicker1.Value.ToString()) ||
                    string.IsNullOrEmpty(tbCount.Text) ||
                    string.IsNullOrEmpty(tbInsuser.Text) ||
                    string.IsNullOrEmpty(cbProcess.SelectedItem.ToString()))
                {
                    MessageBox.Show("필수 값이 누락 되었습니다.");
                    return;
                }

                InsertGrid.Rows.Add(tbProductID.Text
                                       , tbProductName.Text
                                       , dateTimePicker1.Value.Year.ToString() + "/" + dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Day.ToString()
                                       , tbCount.Text
                                       , cbProcess.SelectedItem.ToString()
                                       , tbInsuser.Text);
            }

            else
            {
                MessageBox.Show("제품명, 제품코드가 다릅니다.");
                //tbProductName.Text = string.Empty; //ProductName2_txt
                //tbProductID.Text = string.Empty; //ProductID_txt
            }
        }

        private void btnAdd_Work_Click(object sender, EventArgs e)
        {
            // 연결
            using (var conn = DatabaseManager.GetConnection())
            {
                string searchQuery = $@"SELECT * FROM WORKORDER";
                if (cbProcess.SelectedItem.ToString() == "과립")
                {

                    // 트랜잭션 시작
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 트랜잭션을 위한 구간

                            string insertWO_st = $@"INSERT INTO WORKORDER(WOID, WOSTAT, PLANDTTM, PRODID, PLANQTY, PROCID, INSUSER, INSDTTM, DEL_YN)
                                    VALUES (
                                                ('W' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(workorder_seq.NEXTVAL, 3, '0'))     -- 작업지시ID 
                                                , 'P'                                                                            -- 작업상태  ('P' 고정)                               
                                                , '{dateTimePicker1.Value.Year.ToString() + "/"
                                                        + dateTimePicker1.Value.Month.ToString() + "/"
                                                        + dateTimePicker1.Value.Day.ToString()
                                                        + dateTimePicker1.Value.ToString("HH:mm:ss")}'                                 -- 계획일자 (컨트롤러로부터 받아옴)
                                                , '{tbProductID.Text}'                                                           -- 제품코드 (컨트롤러)
                                                , '{int.Parse(tbCount.Text)}'                                              　    -- 제품양 (컨트롤러)
                                                , 'PC001'                                          　                            -- 공정 코드 ()
                                                , '{tbInsuser.Text}'                                             　              -- 현재 접속 유저코드
                                                , TO_CHAR(SYSDATE, 'YYYYMMDD HH24:MI:SS')       　                               -- 입력일자(현재 일자)
                                                , 'N'                                                                            -- 삭제여부(N)
                                           )";
                            using (OracleCommand updateCommand = new OracleCommand(insertWO_st, conn))
                            {
                                updateCommand.Transaction = transaction; // 트랜잭션 설정
                                updateCommand.ExecuteNonQuery();
                            }

                            // 동시에 다른 테이블에서 작업 수행 (예시)
                            string insertWO_nd = $@"INSERT INTO WORKORDER(WOID, WOSTAT, PLANDTTM, PRODID, PLANQTY, PROCID, INSUSER, INSDTTM, DEL_YN)
                                   VALUES (
                                                ('W' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(workorder_seq.NEXTVAL, 3, '0'))     -- 작업지시ID 
                                                , 'P'                                                                            -- 작업상태  ('P' 고정)                               
                                                , '{dateTimePicker1.Value.Year.ToString() + "/"
                                                        + dateTimePicker1.Value.Month.ToString() + "/"
                                                        + dateTimePicker1.Value.Day.ToString()
                                                        + dateTimePicker1.Value.ToString("HH:mm:ss")}'                                 -- 계획일자 (컨트롤러로부터 받아옴)
                                                , '{tbProductID.Text}'                                                           -- 제품코드 (컨트롤러)
                                                , '{int.Parse(tbCount.Text)}'                                              　    -- 제품양 (컨트롤러)
                                                , 'PC002'                                          　                            -- 공정 코드 ()
                                                , '{tbInsuser.Text}'                                             　              -- 현재 접속 유저코드
                                                , TO_CHAR(SYSDATE, 'YYYYMMDD HH24:MI:SS')       　                               -- 입력일자(현재 일자)
                                                , 'N'                                                                            -- 삭제여부(N)
                                           )";
                            using (OracleCommand updateCommand = new OracleCommand(insertWO_nd, conn))
                            {
                                updateCommand.Transaction = transaction; // 트랜잭션 설정
                                updateCommand.ExecuteNonQuery();
                            }

                            string insertWO_rd = $@"INSERT INTO WORKORDER(WOID, WOSTAT, PLANDTTM, PRODID, PLANQTY, PROCID, INSUSER, INSDTTM, DEL_YN)
                                   VALUES (
                                                ('W' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(workorder_seq.NEXTVAL, 3, '0'))     -- 작업지시ID 
                                                , 'P'                                                                            -- 작업상태  ('P' 고정)                               
                                                , '{dateTimePicker1.Value.Year.ToString() + "/"
                                                        + dateTimePicker1.Value.Month.ToString() + "/"
                                                        + dateTimePicker1.Value.Day.ToString()
                                                        + dateTimePicker1.Value.ToString("HH:mm:ss")}'                                 -- 계획일자 (컨트롤러로부터 받아옴)
                                                , '{tbProductID.Text}'                                                           -- 제품코드 (컨트롤러)
                                                , '{int.Parse(tbCount.Text)}'                                              　    -- 제품양 (컨트롤러)
                                                , 'PC003'                                          　                            -- 공정 코드 
                                                , '{tbInsuser.Text}'                                             　              -- 현재 접속 유저코드
                                                , TO_CHAR(SYSDATE, 'YYYYMMDD HH24:MI:SS')       　                               -- 입력일자(현재 일자)
                                                , 'N'                                                                            -- 삭제여부(N)
                                           )";
                            using (OracleCommand updateCommand = new OracleCommand(insertWO_rd, conn))
                            {
                                updateCommand.Transaction = transaction; // 트랜잭션 설정
                                updateCommand.ExecuteNonQuery();
                            }

                            using (OracleCommand InquiryCommand = new OracleCommand(searchQuery, conn))
                            {
                                InquiryCommand.Transaction = transaction;
                                InquiryCommand.ExecuteReader();
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

                if (cbProcess.SelectedItem.ToString() == "타정")
                {

                    // 트랜잭션 시작
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 트랜잭션을 위한 구간

                            string insertWO_st = $@"INSERT INTO WORKORDER(WOID, WOSTAT, PLANDTTM, PRODID, PLANQTY, PROCID, INSUSER, INSDTTM, DEL_YN)
                                    VALUES (
                                                ('W' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(workorder_seq.NEXTVAL, 3, '0'))     -- 작업지시ID 
                                                , 'P'                                                                            -- 작업상태  ('P' 고정)                               
                                                , '{dateTimePicker1.Value.Year.ToString() + "/"
                                                        + dateTimePicker1.Value.Month.ToString() + "/"
                                                        + dateTimePicker1.Value.Day.ToString()
                                                        + dateTimePicker1.Value.ToString("HH:mm:ss")}'                                 -- 계획일자 (컨트롤러로부터 받아옴)
                                                , '{tbProductID.Text}'                                                           -- 제품코드 (컨트롤러)
                                                , '{int.Parse(tbCount.Text)}'                                              　    -- 제품양 (컨트롤러)
                                                , 'PC002'                                          　                            -- 공정 코드 ()
                                                , '{tbInsuser.Text}'                                             　              -- 현재 접속 유저코드
                                                , TO_CHAR(SYSDATE, 'YYYYMMDD HH24:MI:SS')       　                               -- 입력일자(현재 일자)
                                                , 'N'                                                                            -- 삭제여부(N)
                                           )";
                            using (OracleCommand updateCommand = new OracleCommand(insertWO_st, conn))
                            {
                                updateCommand.Transaction = transaction; // 트랜잭션 설정
                                updateCommand.ExecuteNonQuery();
                            }

                            // 동시에 다른 테이블에서 작업 수행 (예시)
                            string insertWO_nd = $@"INSERT INTO WORKORDER(WOID, WOSTAT, PLANDTTM, PRODID, PLANQTY, PROCID, INSUSER, INSDTTM, DEL_YN)
                                   VALUES (
                                                ('W' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(workorder_seq.NEXTVAL, 3, '0'))     -- 작업지시ID 
                                                , 'P'                                                                            -- 작업상태  ('P' 고정)                               
                                                , '{dateTimePicker1.Value.Year.ToString() + "/"
                                                        + dateTimePicker1.Value.Month.ToString() + "/"
                                                        + dateTimePicker1.Value.Day.ToString()
                                                        + dateTimePicker1.Value.ToString("HH:mm:ss")}'                                 -- 계획일자 (컨트롤러로부터 받아옴)
                                                , '{tbProductID.Text}'                                                           -- 제품코드 (컨트롤러)
                                                , '{int.Parse(tbCount.Text)}'                                              　    -- 제품양 (컨트롤러)
                                                , 'PC003'                                          　                            -- 공정 코드 ()
                                                , '{tbInsuser.Text}'                                             　              -- 현재 접속 유저코드
                                                , TO_CHAR(SYSDATE, 'YYYYMMDD HH24:MI:SS')       　                               -- 입력일자(현재 일자)
                                                , 'N'                                                                            -- 삭제여부(N)
                                           )";
                            using (OracleCommand updateCommand = new OracleCommand(insertWO_nd, conn))
                            {
                                updateCommand.Transaction = transaction; // 트랜잭션 설정
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


                if (cbProcess.SelectedItem.ToString() == "포장")
                {
                    // 트랜잭션 시작
                    using (OracleTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 트랜잭션을 위한 구간

                            string insertWO_st = $@"INSERT INTO WORKORDER(WOID, WOSTAT, PLANDTTM, PRODID, PLANQTY, PROCID, INSUSER, INSDTTM, DEL_YN)
                                    VALUES (
                                                ('W' || TO_CHAR(SYSDATE, 'YYYYMMDD') || LPAD(workorder_seq.NEXTVAL, 3, '0'))     -- 작업지시ID 
                                                , 'P'                                                                            -- 작업상태  ('P' 고정)                               
                                                , '{dateTimePicker1.Value.Year.ToString() + "/"
                                                        + dateTimePicker1.Value.Month.ToString() + "/"
                                                        + dateTimePicker1.Value.Day.ToString()
                                                        + dateTimePicker1.Value.ToString("HH:mm:ss")}'                                 -- 계획일자 (컨트롤러로부터 받아옴)
                                                , '{tbProductID.Text}'                                                           -- 제품코드 (컨트롤러)
                                                , '{int.Parse(tbCount.Text)}'                                              　    -- 제품양 (컨트롤러)
                                                , 'PC003'                                          　                            -- 공정 코드 ()
                                                , '{tbInsuser.Text}'                                             　              -- 현재 접속 유저코드
                                                , TO_CHAR(SYSDATE, 'YYYYMMDD HH24:MI:SS')       　                               -- 입력일자(현재 일자)
                                                , 'N'                                                                            -- 삭제여부(N)
                                           )";
                            using (OracleCommand updateCommand = new OracleCommand(insertWO_st, conn))
                            {
                                updateCommand.Transaction = transaction; // 트랜잭션 설정
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

            DialogResult = DialogResult.Yes;


            //Update save = new Update();
            //save.ShowDialog();

            //메세지 창 팝업
            DialogResult result = MessageBox.Show("완료되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Close();
            }

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
