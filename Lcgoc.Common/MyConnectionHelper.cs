using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Lcgoc.Common
{
    public class MyConnectionHelper
    {
        public static string connectionStr { get { return ConfigHelper.ConnectionString("MysqlConnectionString"); } }

        public IDbConnection connectionGetAndOpen(string connStr = "")
        {
            string _connStr = string.Empty;
            if (string.IsNullOrEmpty(connStr))
            {
                _connStr = MyConnectionHelper.connectionStr;
            }
            else
            {
                _connStr = connStr;
            }
            IDbConnection connSQL = null;
            try
            {
                connSQL = new MySqlConnection(_connStr);
                connSQL.Open();
                return connSQL;
            }
            catch (Exception exp)
            {
                throw new Exception("Create SQLConn Failed:" + exp.Message);
            }
        }
    }
}
