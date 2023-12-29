using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_FUI
{
    public static class DatabaseManager
    { 
        private static OracleConnection conn;
        private static string connectionString = "Data Source=(DESCRIPTION=" +
               "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
               "(HOST=220.122.234.15)(PORT=1521)))" +
               "(CONNECT_DATA=(SERVER=DEDICATED)" +
               "(SERVICE_NAME=xe)));" +
               "User Id=system;Password=1234;";

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


        public static void Disconnect()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
