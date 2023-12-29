using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES
{
    class DatabaseManager
    {
        private static OracleConnection conn;
        private static string connectionString = "Data Source=(DESCRIPTION=" +
               "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
               //"(HOST=192.168.111.138)(PORT=1521)))" +
               "(HOST=220.122.234.15)(PORT=1521)))" +
               "(CONNECT_DATA=(SERVER=DEDICATED)" +
               "(SERVICE_NAME=xe)));" +
               "User Id=system;Password=1234;";

        // DB 연결
        public static OracleConnection GetConnection()
        {
            if (conn == null || conn.State == ConnectionState.Closed)
            {
                conn = new OracleConnection(connectionString);
                conn.Open();
            }
            else if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }

            return conn;
        }


        // DB 연결 해제
        public static void Disconnect()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public static void DB_InquiryForChart(string selectQuery, DataTable dataTable)
        {
            OracleDataAdapter adapter = new OracleDataAdapter(selectQuery, GetConnection());
            adapter.Fill(dataTable);
        }


        // Select문을 통한 GridView 적용
        public static void DB_Inquiry(string selectQuery, DataGridView dataGridView)
        {
            OracleDataAdapter adapter = new OracleDataAdapter(selectQuery, GetConnection());
            DataTable data_table = new DataTable();
            adapter.Fill(data_table);
            dataGridView.DataSource = data_table;
        }

        // SELECT문을 통한 DB테이블 반환
        public static DataTable DB_Inquiry(string selectQuery)
        {
            OracleDataAdapter adapter = new OracleDataAdapter(selectQuery, GetConnection());
            DataTable data_table = new DataTable();
            adapter.Fill(data_table);
            return data_table;
        }

        // Update, Delete문을 DB에 적용
        public static void DB_Modify(string query)
        {
            OracleCommand cmd = new OracleCommand(query, GetConnection());
            cmd.ExecuteNonQuery();
        }

        // 지정 열 값 반환
        public static string DB_GetColumnValue(string columnName, string tableName, string condition)
        {
            string result = null;

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT {columnName} FROM {tableName} WHERE {condition}";
                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                object columnValue = reader[columnName];
                                if (columnValue != DBNull.Value)
                                {
                                    result = columnValue.ToString();
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // 예외 처리
                    MessageBox.Show("에러: " + ex);
                }
            }

            return result;
        }


        //----------------------------------------------------------------------------------------------------

        //  DB Tables Columns과 표시할 columns명
        static Dictionary<string, string> columnMappingDic = new Dictionary<string, string>()
        {
            {"key1", "작업지시ID"},
            {"key2", "작업지시상태"},
            {"key3", "계획일자" },
            {"key4", "작업지시 시작일"},
            {"key5", "작업지시 종료일"},
            {"key6", "제품코드"},
            {"key7", "계획수량"},
            {"key8", "생산수량"},
            {"key9", "공정ID"},
            {"key10", "등록자ID"},
            {"key11", "등록일"},
            {"key12", "수정자ID"},
            {"key13", "수정일"},
            {"key14", "다음 작업지시ID"},
            {"key15", "최종 작업지시ID"},
        };



        // DB tables columns 표시할 columns 매핑
        public static List<string> mappingValue(OracleDataReader rdr)
        {
            List<string> colsList = new List<string>();

            for (int i = 0; i < rdr.FieldCount; i++)
            {
                if (columnMappingDic.ContainsKey(rdr.GetName(i)))
                {
                    string mappingValue = columnMappingDic[rdr.GetName(i)];
                    colsList.Add(mappingValue);
                }
                else continue;
            }
            return colsList;
        }


        // 단일 쿼리를 통한 데이터 조회
        public void stdSearchData(string query, DataGridView dataGridView)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            List<string> colsList = mappingValue(rdr);

                            DataTable dataTable = new DataTable();
                            dataTable.Load(rdr);
                            dataGridView.DataSource = dataTable;


                            for (int i = 0; i < colsList.Count; i++)
                            {
                                dataGridView.Columns[i].HeaderText = colsList[i];
                            }
                        }
                    }
                }
            }
        }

        // ver2) transaction에 사용될 조회 메소드 폼
        void tStdSearchData(OracleConnection connection, string query, DataGridView dataGridView)
        {
            using (OracleCommand cmd = new OracleCommand(query, connection))
            {
                using (OracleDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        List<string> colsList = mappingValue(rdr);

                        DataTable dataTable = new DataTable();
                        dataTable.Load(rdr);
                        dataGridView.DataSource = dataTable;


                        for (int i = 0; i < colsList.Count; i++)
                        {
                            dataGridView.Columns[i].HeaderText = colsList[i];
                        }
                    }
                }
            }
        }

        // 삭제, 업데이트 위한 트랜잭션 메소드 폼
        void tStdModifyData(OracleConnection connection, string deleteQuery)
        {
            using (OracleCommand deleteCmd = new OracleCommand(deleteQuery, connection))
            {
                // 삭제 쿼리 실행
                deleteCmd.ExecuteNonQuery();
            }
        }

        void tStdModifyData(OracleCommand command)
        {
            using (OracleConnection connection = command.Connection)
            {
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // 쿼리버전
        void StdModifyData(string query)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (OracleCommand command = new OracleCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // 일반적인 트랜잭션을 위한 폼
        public void stdTransaction()
        {
            // 연결
            using (var conn = DatabaseManager.GetConnection())
            {
                // 트랜잭션 시작
                using (OracleTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 트랜잭션을 위한 구간으로 어떤 작업에 대해서 작성해둔 것을 써놓으면 됨.

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        //MessageBox 
                    }
                }
            }
        }



        // 검색을 통한 데이터 조회
        public void SearchProduct(DataGridView dataGridView)
        {
            using (var conn = DatabaseManager.GetConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    string query = "SELECT * FROM ~~~ WHERE ProductCode = :prouctCode AND ProductName = :productName";

                    cmd.Parameters.Add(new OracleParameter(":prouctCode", "{productCode}"));
                    cmd.Parameters.Add(new OracleParameter(":productName", "{productName}"));

                    cmd.CommandText += query;
                    using (OracleDataReader rdr = cmd.ExecuteReader())
                    {
                        List<string> colsList = mappingValue(rdr);

                        DataTable dataTable = new DataTable();
                        dataTable.Load(rdr);
                        dataGridView.DataSource = dataTable;


                        for (int i = 0; i < colsList.Count; i++)
                        {
                            dataGridView.Columns[i].HeaderText = colsList[i];
                        }
                    }
                }
            }
        }


        // 특정 테이블의 열 이름을 가져오는 메소드
        List<string> GetColumnNames(OracleConnection connection, string tableName)
        {
            List<string> columnNames = new List<string>();

            using (OracleCommand command = new OracleCommand($"SELECT * FROM {tableName} WHERE ROWNUM = 1", connection))
            {
                using (OracleDataReader reader = command.ExecuteReader())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        columnNames.Add(reader.GetName(i));
                    }
                }
            }
            return columnNames;
        }



        // 동적 업데이트
        void UpdateData(OracleConnection connection, string updateQuery, DataGridView dataGridView, string tableName)
        {
            try
            {
                if (dataGridView.RowCount == 0) return;

                DataTable dtChanges = new DataTable();
                DataTable dataSource = (DataTable)dataGridView.DataSource;
                dtChanges = dataSource.GetChanges(DataRowState.Modified);

                if (dtChanges == null) return;

                List<string> columnNames = GetColumnNames(connection, tableName);

                for (int i = 0; i < dtChanges.Rows.Count; i++)
                {
                    string updateTemplate = $"UPDATE {tableName} SET ";

                    foreach (var columnName in columnNames)
                    {
                        updateTemplate += $"{columnName} = :{columnName}, ";
                    }

                    updateTemplate = updateTemplate.TrimEnd(',');

                    updateTemplate += $" WHERE {columnNames[0]} = :{columnNames[0]}";

                    // 동적으로 열 값을 삽입
                    OracleCommand updateCommand = new OracleCommand(updateTemplate, connection);

                    for (int j = 0; j < columnNames.Count; j++)
                    {
                        updateCommand.Parameters.Add($":{columnNames[j]}", OracleDbType.Varchar2).Value = dtChanges.Rows[i][columnNames[j]];
                    }

                    // 실제 업데이트 실행
                    tStdModifyData(updateCommand);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        // 데이터 추가

        // 데이터 등록




        // 데이터 삭제(삭제 후 조회)
        public void Delete(DataGridView dataGridView, string deleteQuery, string searchQuery)
        {
            string DBdelete = string.Empty;

            try
            {
                if (dataGridView.RowCount == 0) return;

                Check check = new Check();

                if (check.ShowDialog() == DialogResult.Yes)
                {

                    // 트랜잭션
                    using (var conn = DatabaseManager.GetConnection())
                    {
                        using (OracleTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                tStdModifyData(conn, deleteQuery);
                                tStdSearchData(conn, searchQuery, dataGridView);
                                transaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static object DB_Scalar(string query)
        {
            using (OracleConnection connection = GetConnection())
            {
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

    }
}
