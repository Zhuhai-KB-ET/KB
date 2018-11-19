using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace KB.DAL.SQLHelper
{
    public class SqliteDBHelper
    {
        public string ConnectionString
        {
            get;
            set;
        }

        private string password;

        public SqliteDBHelper(string connectionString,string pwd)
        {
            ConnectionString = connectionString;
            password = pwd;
        }

        public DataTable GetData(string sql)
        { 
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            conn.SetPassword(password);
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql,conn);
            try
            {
                da.Fill(ds, "Table1");
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
                else
                {
                    throw new Exception("没有数据");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}
