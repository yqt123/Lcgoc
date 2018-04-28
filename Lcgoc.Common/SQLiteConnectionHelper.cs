using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace Lcgoc.Common
{
    public class SQLiteConnectionHelper
    {
        public static string connectionStr { get { return string.Format(ConfigHelper.ConnectionString("SQLiteConnectionString"), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigHelper.ConnectionString("SQLiteConnectionFileName"))); } }

        public IDbConnection connectionGetAndOpen(string connStr = "")
        {
            string _connStr = string.Empty;
            if (string.IsNullOrEmpty(connStr))
            {
                _connStr = SQLiteConnectionHelper.connectionStr;
            }
            else
            {
                _connStr = connStr;
            }
            IDbConnection connSQL = null;
            try
            {
                connSQL = new SQLiteConnection(_connStr);
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
