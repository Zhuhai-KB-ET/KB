using System;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using KB.Models;
using KB.DAL;
using KB.BLL;

namespace KB.FUNC /* 命名空间 */
{
   
    public class log
    {
        #region 变量
        
        #endregion
        #region Log
        public log()
        {            
        }
        #endregion

        #region 显示 PrintInfo
        public static void PrintInfo(Exception e1)
        {
            log.Error("FID=" + GlobalVal.UserInfo.FactoryID.ToString() + "，UserName=" + GlobalVal.UserInfo.LoginName + "，" + ";" + e1.Message, e1);
            MessageBox.Show(e1.Message.Replace("'", "").Replace("\r\n", ""), "系统出错！"); 
        } 
        #endregion

        #region 记录 RecordInfo
        public static void RecordInfo(Exception e1)
        {
            log.Error("FID=" + GlobalVal.UserInfo.FactoryID.ToString() + "，UserName=" + GlobalVal.UserInfo.LoginName + "，" + ";" + e1.Message, e1);
        }
        #endregion

        #region WriteFile
        private static void WriteFile(string s_msg, string s_mode, Exception ex)
        {
            DBHelper dbhelper = new DBHelper(0);
            FOUNDERPCB_OPERATION_LOG loginfo = new FOUNDERPCB_OPERATION_LOG();
            FOUNDERPCB_OPERATION_LOGBLL logbll = new FOUNDERPCB_OPERATION_LOGBLL(dbhelper);

            string s_proc_name1 = "", s_proc_name2 = "", s_proc_name3 = "", s_proc_name4 = "";
            string s_proc_dll_name1 = "", s_proc_dll_name2 = "", s_proc_dll_name3 = "", s_proc_dll_name4 = "";
            string s_user = ""; 
            string s_write = "";

           

                try
                {
                    if (s_msg.IndexOf("COMMIT TRANSACTION 请求没有对应的 BEGIN TRANSACTION") >= 0) return;
                    if (s_msg.IndexOf("SQL 语法：COMMIT TRAN") > 0) return;

                    s_proc_dll_name1 = (new StackTrace()).GetFrame(2).GetMethod().ReflectedType.FullName;//类名
                    s_proc_name1 = (new StackTrace()).GetFrame(2).GetMethod().Name;//方法
                    s_proc_dll_name2 = (new StackTrace()).GetFrame(3).GetMethod().ReflectedType.FullName;//类名
                    s_proc_name2 = (new StackTrace()).GetFrame(3).GetMethod().Name;//方法
                    s_proc_dll_name3 = (new StackTrace()).GetFrame(4).GetMethod().ReflectedType.FullName;//类名
                    s_proc_name3 = (new StackTrace()).GetFrame(4).GetMethod().Name;//方法
                    s_proc_dll_name4 = (new StackTrace()).GetFrame(5).GetMethod().ReflectedType.FullName;//类名
                    s_proc_name4 = (new StackTrace()).GetFrame(5).GetMethod().Name;//方法
                    s_user = GlobalVal.UserInfo.LoginName;

                }
                catch { }
                if (ex != null)
                {
                    //获得字节数组             
                    s_write = s_write + "域 帐 号：" + s_user+GlobalVal.UserInfo.IP + "\r\n";
                    s_write = s_write + "日志类名：" + s_proc_dll_name1 + "中的" + s_proc_name1 + "\r\n";
                    s_write = s_write + "          " + s_proc_dll_name2 + "中的" + s_proc_name2 + "\r\n";
                    s_write = s_write + "          " + s_proc_dll_name3 + "中的" + s_proc_name3 + "\r\n";
                    s_write = s_write + "          " + s_proc_dll_name4 + "中的" + s_proc_name4 + "\r\n";
                    s_write = s_write + "日志级别：" + s_mode + "\r\n";
                    if (ex == null)
                        s_write = s_write + "日 志 类：\r\n";
                    else
                        s_write = s_write + "日 志 类：" + ex.StackTrace.ToString().Trim() + "\r\n";
                    s_write = s_write + "返回信息：" + s_msg;
                }
                else
                {                    
                    s_write = "返回信息：" + s_msg;
                }

            loginfo.PRO_RKEY = 0;
            loginfo.MODULE_ID = "";
            loginfo.MODULE_NAME = "";
            loginfo.ACTION = s_proc_name1;
            loginfo.MEMO = s_write;
            loginfo.DO_DATE = Func.GetNowDate();

            logbll.Add(loginfo);
            
        }
        #endregion

        #region Info
        public static void Info(string s_msg)
        {
            WriteFile("UserName=" + GlobalVal.UserInfo.LoginName + GlobalVal.UserInfo.IP + ";" + s_msg, "信息", null);
        }
        public static void Info(string s_msg, Exception ex)
        {
            WriteFile(s_msg, "信息", ex);
        }
        #endregion 

        #region Error
        public static void Error(string s_msg)
        {
            WriteFile("UserName=" + GlobalVal.UserInfo.LoginName + GlobalVal.UserInfo.IP + ";" + s_msg, "出错", null);
        }
        public static void Error(string s_msg, Exception ex)
        {
            WriteFile(s_msg, "出错", ex);
        }
        #endregion 

        #region Warning
        public static void Warning(string s_msg)
        {
            WriteFile("UserName=" + GlobalVal.UserInfo.LoginName + GlobalVal.UserInfo.IP + ";" + s_msg, "警告", null);
        }
        public static void Warning(string s_msg, Exception ex)
        {
            WriteFile(s_msg, "警告", ex);
        }
        #endregion
    }
}