using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace KB.FUNC
{
    public class SQLiteSource
    {
        private static string connString = @"Data Source=" + System.IO.Directory.GetCurrentDirectory() + "\\Resources\\db.dll";
        private static string password = "KB";
        /// <summary>
        /// 从SQLite数据库中读取ERP数据库的链接信息
        /// </summary>
        /// <param name="dbConnectionString"></param>
        public static void InitConnection(string[,] dbConnectionString)
        {
            try
            {
                var dsConnection = GetDataSet(connString, "select * from DBConnection");
                if (dsConnection.Tables.Count == 0 || dsConnection.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("查询数据库信息失败");
                }
                var tbConn = dsConnection.Tables[0];
                for (int i = 0; i < tbConn.Rows.Count; i++)
                {
                    DataRow row = tbConn.Rows[i];
                    dbConnectionString[Convert.ToInt32(row["FactoryIndex"]), Convert.ToInt32(row["DBIndex"])] = row["ConnectionString"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SQLite数据库异常:" + ex.Message);
            }
        }

        public static int GetParameterValue(string parameterName)
        {
            var ds = GetDataSet(connString, string.Format("select * from SystemParameter where ParameterName='{0}'", parameterName));
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int returnValue = 0;
                try
                {
                    returnValue = Convert.ToInt32(ds.Tables[0].Rows[0]["ParameterValue"]);
                }
                catch
                {
                    throw new Exception("SQLite查询系统参数[" + parameterName + "]异常");
                }
                return returnValue;
            }
            else
            {
                throw new Exception("SQLite查询系统参数[" + parameterName + "]异常");
            }
        }

        public static DataSet GetDataSet(string sqlString)
        {
            return GetDataSet(connString, sqlString);
        }

        private static DataSet GetDataSet(string connString, string sqlString)
        {
            SQLiteConnection conn = null;
            try
            {
                conn = new SQLiteConnection(connString);
                conn.SetPassword(password);
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = sqlString;
                cmd.CommandType = CommandType.Text;

                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}
