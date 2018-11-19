using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace KB.DAL
{
    public class AccessDBHelper
    {
        public string ConnString
        {
            get;
            set;
        }

        public AccessDBHelper(string connString)
        {
            ConnString = connString;
        }

        public DataTable GetData(string sql)
        {
            OleDbConnection conn = new OleDbConnection(ConnString);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, conn);
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
            finally
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public int Add(string sql)
        {
            OleDbConnection conn = new OleDbConnection(ConnString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            try
            {
                conn.Open();
                OleDbTransaction transaction = null;
                transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select @@identity";
                    object o = cmd.ExecuteScalar();
                    transaction.Commit();

                    return Convert.ToInt32(o.ToString());
                }
                catch (Exception exx)
                {
                    transaction.Rollback();
                    throw exx;
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

        public int ExecuteCommand(string sql)
        {
            OleDbConnection conn = new OleDbConnection(ConnString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;

            try
            {
                conn.Open();
                cmd.CommandText = sql;
                return (int)cmd.ExecuteNonQuery();
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
