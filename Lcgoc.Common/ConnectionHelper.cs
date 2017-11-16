using System;
using System.Data;
using System.Data.SqlClient;

namespace Lcgoc.Common
{
    public class ConnectionHelper
    {
        public static string connectionStr { get { return ConfigHelper.ConnectionString("ConnectionString"); } }

        public IDbConnection connectionGetAndOpen(string connStr = "")
        {
            string _connStr = string.Empty;
            if (string.IsNullOrEmpty(connStr))
            {
                _connStr = ConnectionHelper.connectionStr;
            }
            else
            {
                _connStr = connStr;
            }
            IDbConnection connSQL = null;
            try
            {
                connSQL = new SqlConnection(_connStr);
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
