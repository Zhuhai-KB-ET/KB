using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace KB.FUNC
{
    public class Mail
    {
        /// <summary>
        /// 发送邮件(msdb.dbo.sp_send_dbmail)
        /// </summary>
        /// <param name="recipients">收件人地址</param>
        /// <param name="title">标题</param>
        /// <param name="mailBody">内容</param>
        public static void SendMail(string recipients, string title, string mailBody)
        {
            string sql = "msdb.dbo.sp_send_dbmail";
            SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@profile_name",SqlDbType.NVarChar),
                    new SqlParameter("@recipients",SqlDbType.VarChar),
                    new SqlParameter("@body",SqlDbType.NVarChar),
                    new SqlParameter("@subject",SqlDbType.NVarChar),
                    new SqlParameter("@body_format",SqlDbType.VarChar)
                };
            parameters[0].Value = "DBA SQL";
            parameters[1].Value = recipients;
            parameters[2].Value = mailBody;
            parameters[3].Value = title;
            parameters[4].Value = "HTML";

            SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID));
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (SqlParameter para in parameters)
            {
                cmd.Parameters.Add(para);
            }
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
