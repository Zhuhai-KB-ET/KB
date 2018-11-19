using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using System.Text;
using System.Net;
using System.Management;
using System.Windows.Forms;
using System.Data;
using KB.DAL;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Data.OleDb;
using KB.BLL;
using System.Data.SqlClient;

namespace KB.FUNC
{
    /// <summary>
    /// 常用函数
    /// </summary>
    public class Func
    {
        #region 公共值DateInterval
        public enum DateInterval
        {
            Second, Minute, Hour, Day, Week, Month, Quarter, Year
        }
        #endregion

        DBHelper dbhelper = null;

        
        #region Func
        public Func()
        {
            dbhelper = new DBHelper(0);
        }
        #endregion

        #region 判断是否为数字 IsNumberic
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="oText"></param>
        /// <returns></returns>
        public static bool IsNumberic(string oText)
        {
            try
            {
                if (oText == null) return false;
                decimal var1 = Convert.ToDecimal(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 判断是否为日期 IsDateTime
        /// <summary>
        /// 判断是否为日期
        /// </summary>
        /// <param name="oText"></param>
        /// <returns></returns>
        public static bool IsDateTime(string oText)
        {
            try
            {
                if (oText == null) return false;
                DateTime var1 = Convert.ToDateTime(oText);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 比较日期 DateDiff
        /// <summary>
        /// 比较日期
        /// </summary>
        /// <param name="Interval">DateInterval类，如：Day返回日差异</param>
        /// <param name="StartDate">开始日期</param>
        /// <param name="EndDate">终止日期</param>
        /// <returns></returns>
        public static long DateDiff(DateInterval Interval, System.DateTime StartDate, System.DateTime EndDate)
        {
            long lngDateDiffValue = 0;
            System.TimeSpan TS = new System.TimeSpan(EndDate.Ticks - StartDate.Ticks);
            switch (Interval)
            {
                case DateInterval.Second:
                    lngDateDiffValue = (long)TS.TotalSeconds;
                    break;
                case DateInterval.Minute:
                    lngDateDiffValue = (long)TS.TotalMinutes;
                    break;
                case DateInterval.Hour:
                    lngDateDiffValue = (long)TS.TotalHours;
                    break;
                case DateInterval.Day:
                    lngDateDiffValue = (long)TS.Days;
                    break;
                case DateInterval.Week:
                    lngDateDiffValue = (long)(TS.Days / 7);
                    break;
                case DateInterval.Month:
                    lngDateDiffValue = (long)(TS.Days / 30);
                    break;
                case DateInterval.Quarter:
                    lngDateDiffValue = (long)((TS.Days / 30) / 3);
                    break;
                case DateInterval.Year:
                    lngDateDiffValue = (long)(TS.Days / 365);
                    break;
            }
            return (lngDateDiffValue);
        }
        #endregion

        #region 获取IP 获取主机名 getIP
        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public static string getIP() //获取IP
        {
            string strHostName = getHostName();  //得到本机的主机名
            IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
            string strAddr = ipEntry.AddressList[0].ToString(); //假设本地主机为单网卡

            return strAddr;
        }
        /// <summary>
        /// 获取主机名
        /// </summary>
        /// <returns></returns>
        public static string getHostName() //获取主机名
        { 
            return Dns.GetHostName();
        } 
        #endregion

        #region 显示提示信息 Show
        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowInformation(string msg)
        {
            MessageBox.Show("\n\r" + msg + "\n\r", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        /// <summary>
        /// 警告信息
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowWarning(string msg)
        {
            MessageBox.Show("\n\r" + msg + "\n\r", "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowError(string msg)
        {
            MessageBox.Show("\n\r" + msg + "\n\r", "错误信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        /// <summary>
        /// 询问信息
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowQuestion(string msg)
        {
            MessageBox.Show("\n\r" + msg + "\n\r", "询问信息", MessageBoxButtons.OK, MessageBoxIcon.Question);
            return;
        }
        #endregion

        #region 提问信息 Input
        /// <summary>
        /// 提问信息
        /// </summary>
        /// <param name="msg"></param>
        public static DialogResult InputInformation(string msg)
        {
            return MessageBox.Show(msg, "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        }
        public static DialogResult InputQuestion(string msg)
        {
            return MessageBox.Show(msg, "询问信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        } 
        #endregion

        #region 中文字符串截取 Substring
        private static System.Text.Encoding enc = System.Text.Encoding.UTF8;
        #region Length检查长度，字母数字为1，中文为2
        public static int Length(string source)
        {
            int i_length = 0;

            System.Text.UTF8Encoding ascii = new System.Text.UTF8Encoding();

            for (int i = 0; i < source.Length; i++)
            {
                string str = source.Substring(i, 1);
                Byte[] encodedBytes = ascii.GetBytes(str);
                string s_temp = encodedBytes[0].ToString();
                int j = encodedBytes.Length;

                if (j > 1)   //１位的才是ASCII码
                    i_length = i_length + 2;
                else
                    i_length++;
            }
            return i_length;
        }
        #endregion

        #region IndexOf(string source,string find, int start)
        /// <summary>
        /// 查找字符串所在位置
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="find">需查找的字符串</param>
        /// <param name="start">开始位置（以字节为单位）</param>
        /// <returns></returns>
        public static int IndexOf(string source, string find, int start)
        {
            int i_ret = 0;
            int i_start = 0;
            int i_length = -1;
            Boolean b_find = false;

            System.Text.UTF8Encoding ascii = new System.Text.UTF8Encoding();

            #region 查找位置
            for (int i = 0; i < source.Length; i++)
            {
                string str = source.Substring(i, 1);
                Byte[] encodedBytes = ascii.GetBytes(str);
                int j = encodedBytes.Length;

                if (j > 1)   //１位的才是ASCII码 
                {
                    i_length = i_length + 2;
                    if (i_length - 1 >= start)
                    {
                        i_start = i;
                        b_find = true;
                        break;
                    }
                }
                else
                {
                    i_length++;
                    if (i_length >= start)
                    {
                        i_start = i;
                        b_find = true;
                        break;
                    }
                }
            }

            if (!b_find)//没找到 
                return -1;
            #endregion

            int i_result = source.IndexOf(find, i_start);

            i_length = -1;
            if (i_result <= 0)
                i_ret = 0;
            else
            {
                for (int i = 0; i < source.Length; i++)
                {
                    string str = source.Substring(i, 1);
                    Byte[] encodedBytes = ascii.GetBytes(str);
                    int j = encodedBytes.Length;

                    if (j > 1)   //１位的才是ASCII码 
                        i_length = i_length + 2;
                    else
                        i_length++;

                    if (i >= i_result)
                    {
                        if (j > 1)
                            i_ret = i_length - 1;
                        else
                            i_ret = i_length;
                        break;
                    }
                }
            }
            return i_ret;
        }
        #endregion

        #region IndexOf(string source, string find)
        public static int IndexOf(string source, string find)
        {
            return IndexOf(source, find, 0);
        }
        #endregion

        #region Substring 截取字符串
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="source">字符串</param>
        /// <param name="start">起始位(0开始)</param>
        /// <param name="count">长度</param>
        /// <returns></returns> 
        public static string Substring(string source, int start, int count)
        {
            string s_ret = "";
            int i_length = -1;
            int i_step = 0;

            System.Text.UTF8Encoding ascii = new System.Text.UTF8Encoding();

            for (int i = 0; i < source.Length; i++)
            {
                string str = source.Substring(i, 1);
                Byte[] encodedBytes = ascii.GetBytes(str);
                int j = encodedBytes.Length;

                if (j > 1)   //１位的才是ASCII码
                {
                    i_length = i_length + 2;
                    i_step = 2;
                }
                else
                {
                    i_length++;
                    i_step = 1;
                }

                if (i_length == start && i_step > 1)
                {
                    start = start - 1;
                    count = count + 1;
                }
                if (i_length - (i_step - 1) >= start && i_length <= start + count - 1)
                    s_ret = s_ret + str;
                else
                    if (i_length > start + count - 1)
                        break;
            }

            return s_ret;
        }
        #endregion       
        #endregion

        #region 按字符串字节长度分成子串 比如将长字符串分解存入data0011号表
        /// <summary>
        ///按字符串字节长度分成子串
        ///可解决中英文截取的问题，比如将长字符串分解存入data0011号表。2010.01.16
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static List<string> StrTokenizer(string str, int len)
        {
            List<string> list = new List<string>();
            int strlen = Length(str);//原字符串字节长度
            if (strlen <= len)
            {
                list.Add(str);
            }
            else
            {
                string tmpstr = str;
                for (int i = 0; i <= strlen / len; i++)
                {
                    string s = Substring(tmpstr, 0, len);
                    list.Add(s);
                    tmpstr = Substring(tmpstr, Length(s), Length(tmpstr) - Length(s));
                }
            }

            return list;
        }
        #endregion

        #region 数字转时间 ChangeIntToTime
        /// <summary>
        /// 数字转时间
        /// </summary>
        /// <param name="ITime">12345</param>
        public static string ChangeIntToTime(string ITime)
        {
            try
            {
                string s_ret = "";

                if (ITime.Trim().Length <= 0) return "00:00:00";

                if (ITime.Trim().Length == 1) return "00:00:0" + ITime.Trim();

                if (ITime.Trim().Length == 2) return "00:00:" + ITime.Trim();

                if (ITime.Trim().Length == 3) return "00:0" + ITime.Trim().Substring(0, 1) + ":" + ITime.Trim().Substring(1, 2);

                if (ITime.Trim().Length == 4) return "00:" + ITime.Trim().Substring(0, 2) + ":" + ITime.Trim().Substring(2, 2);
                    
                if (ITime.Trim().Length == 5) return "0" + ITime.Trim().Substring(0, 1) + ":" + ITime.Trim().Substring(1, 2) + ":" + ITime.Trim().Substring(3, 2);

                if (ITime.Trim().Length >= 6) return ITime.Trim().Substring(0, 2) + ":" + ITime.Trim().Substring(2, 2) + ":" + ITime.Trim().Substring(4, 2);

                return s_ret;
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return "";
            }
        }
        #endregion

        #region GetNowDate --yangwm
        public static DateTime GetNowDate()
        {            
            DBHelper DB = new DBHelper(0);  
            try
            {
                DateTime dt_ret_date = System.DateTime.Now; 
                DataTable tb = null;
                tb = DB.GetDataSet(@"select 
                                        CONVERT(varchar,getdate(),120) d1,
                                        CONVERT(varchar(12),getdate(),23) d2,
                                        CONVERT(varchar(12),getdate(),108) t1,
                                        DATENAME(yy,getdate()) yy,
                                        DATENAME(mm,getdate()) mm,
                                        DATENAME(dd,getdate()) dd,
                                        datename(hh,getdate()) h,
                                        datename(mi,getdate()) n,
                                        DATENAME(ss,getdate()) s,
                                        DATENAME(ms,getdate()) ms");
                if (tb.Rows.Count > 0)
                {
                    dt_ret_date = DateTime.Parse(DateTime.Parse(tb.Rows[0]["d1"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                    if(Math.Abs((decimal)(dt_ret_date.Hour-int.Parse(tb.Rows[0]["h"].ToString())))==12)
                    {
                       // MessageBox.Show("时间异常。当前电脑时间格式异常，请调整为24小时制式。");
                        log.Info("客户端时间格式异常：IP：" + GlobalVal.UserInfo.IP);
                      //  Application.Exit();
                    }
                }
                if (dt_ret_date == null || dt_ret_date == System.DateTime.Parse("1900-1-1"))
                {
                  //  MessageBox.Show("时间异常。当前电脑时间格式异常，请调整为24小时制式。");
                    log.Info("客户端时间格式异常：IP：" + GlobalVal.UserInfo.IP);
                 //   Application.Exit();
                }
                return DateTime.Parse(dt_ret_date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch
            {
               // MessageBox.Show("时间异常。当前电脑时间格式异常，请调整为24小时制式。");
                log.Info("客户端时间格式异常：IP：" + GlobalVal.UserInfo.IP);
               // Application.Exit();
                //return System.DateTime.Now;

                return DateTime.Parse(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            finally
            {
                DB.CloseConnection();
            }
        }
        #endregion

        #region Space
        /// <summary>
        /// 产生空格
        /// </summary>
        /// <param name="pi_len">长度</param>
        /// <returns></returns>
        public static string Space(int pi_len)
        {
            string str = "";
            for (int i = 0; i < pi_len; i++)
                str = str + " ";

            return str;
        }
        #endregion

        #region ImageToByteArray 
        /// <summary>
        /// 图片转二进制
        /// </summary>
        /// <param name="imageIn"></param>
        /// <returns></returns>
        public static byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        #endregion

        #region PathExists
        public static Boolean PathExists(string pathname)
        { 
            if (System.IO.Directory.Exists(pathname))
                return true;
            else
                return false;
        }
        #endregion

        #region 自动消失的对话框
        /// <summary>
        /// 自动消失的对话框-yangwm
        /// </summary>
        public class MessageBoxTimeout
        {
            [DllImport("kernel32.dll")]
            private static extern uint GetCurrentThreadId();

            private delegate int EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

            [DllImport("user32.dll")]
            private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

            [DllImport("user32.dll")]
            private static extern int GetClassName(IntPtr hWnd, [Out] StringBuilder lpClassName, int nMaxCount);

            [DllImport("user32.dll")]
            private static extern bool IsWindowEnabled(IntPtr hWnd);

            [DllImport("user32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

            private class TimerThread
            {
                private readonly DateTime timeoutTime;
                private readonly uint currentThreadId;
                private bool terminateFlag;
                private readonly Thread thread;

                public TimerThread(int timeoutMillisec)
                {
                    timeoutTime = DateTime.Now.AddMilliseconds(timeoutMillisec);
                    currentThreadId = GetCurrentThreadId();
                    terminateFlag = false;
                    thread = new Thread(ThreadProc);
                    thread.Start();
                }

                private void ThreadProc()
                {
                    while (!terminateFlag)
                    {
                        Thread.Sleep(100);
                        if (DateTime.Now > timeoutTime)
                        {
                            EnumWindows(EnumWindowsProc, new IntPtr(0));
                            return;
                        }
                    }
                }

                private int EnumWindowsProc(IntPtr hWnd, IntPtr lParam)
                {
                    uint processId;
                    uint threadId;
                    threadId = GetWindowThreadProcessId(hWnd, out processId);
                    if (threadId == currentThreadId)
                    {
                        StringBuilder className = new StringBuilder("", 256);
                        GetClassName(hWnd, className, 256);
                        if (className.ToString() == "#32770" && IsWindowEnabled(hWnd))
                        {
                            const int WM_COMMAND = 0x111;
                            PostMessage(hWnd, WM_COMMAND, new IntPtr(2), new IntPtr(0));
                            return 0;
                        }
                    }
                    return 1;
                }

                public void Terminate()
                {
                    terminateFlag = true;
                    thread.Join();
                }
            }

            public static DialogResult Show(string text, int timeoutMillsec)
            {
                TimerThread tt = new TimerThread(timeoutMillsec);
                try
                {
                    return MessageBox.Show(text);
                }
                finally
                {
                    tt.Terminate();
                }
            }

            public static DialogResult Show(string text, string caption, int timeoutMillsec)
            {
                TimerThread tt = new TimerThread(timeoutMillsec);
                try
                {
                    return MessageBox.Show(text, caption);
                }
                finally
                {
                    tt.Terminate();
                }
            }

            public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, int timeoutMillsec)
            {
                TimerThread tt = new TimerThread(timeoutMillsec);
                try
                {
                    return MessageBox.Show(text, caption, buttons);
                }
                finally
                {
                    tt.Terminate();
                }
            }

            public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, int timeoutMillsec)
    {
        TimerThread tt = new TimerThread(timeoutMillsec);
        try
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }
        finally
        {
            tt.Terminate();
        }
            }

            public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, int timeoutMillsec)
            {
                TimerThread tt = new TimerThread(timeoutMillsec);
                try
                {
                    return MessageBox.Show(text, caption, buttons, icon, defaultButton);
                }
                finally
                {
                    tt.Terminate();
                }
            }

            public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options, int timeoutMillsec)
            {
                TimerThread tt = new TimerThread(timeoutMillsec);
                try
                {
                    return MessageBox.Show(text, caption, buttons, icon, defaultButton, options);
                }
                finally
                {
                    tt.Terminate();
                }
            }
        }
        #endregion

        #region 判断系统开关
        /// <summary>
        /// 判断系统开关-yangwm
        /// </summary>
        /// <param name="fun_id">ID</param>
        /// <returns></returns>
        public static bool HasSwitch(int fun_id)
        {
            bool b = false;
            string sql = "select RIGHTE from FOUNDERPCB_FSWITH  where function_id={0}";
            DBHelper db = new DBHelper(0);
            object obj = db.GetSingle(string.Format(sql, fun_id));
            if (obj != null)
            {
                if ("1" == obj.ToString()) b = true;
            }
            return b;
        }       

        /// <summary>
        /// 成品异常板锁判断 ,返回真表示已经锁定
        /// </summary>
        /// <param name="DATA0050_PTR"></param>
        /// <param name="RoleType">0锁出货，1锁厂内</param>
        /// <returns></returns>
        public static bool HasSwitchFP(decimal DATA0050_PTR, int RoleType)
        {
           return HasSwitchFP(DATA0050_PTR,null,RoleType);
        }
       
        /// <summary>
        /// 成品异常板锁判断 ,返回真表示已经锁定
        /// </summary>
        /// <param name="DATA0050_PTR"></param>
        /// <param name="DCODE">周期</param>
        /// <param name="RoleType">0锁出货，1锁厂内</param>
        /// <returns></returns>
        public static bool HasSwitchFP(decimal DATA0050_PTR, string DCODE, int RoleType)
        {
            return HasSwitchFP(DATA0050_PTR,DCODE, null, RoleType);
        }

        /// <summary>
        /// 成品异常板锁判断 ,返回真表示已经锁定
        /// </summary>
        /// <param name="DATA0050_PTR"></param>
        /// <param name="DCODE">周期</param>
        /// <param name="LOT">LOT</param>
        /// <param name="RoleType">0锁出货，1锁厂内</param>
        /// <returns></returns>
        public static bool HasSwitchFP(decimal DATA0050_PTR, string DCODE, string LOT, int RoleType)
        {
            bool b = false;
            DBHelper db = new DBHelper(0);
            DataTable dt = null;
            string sql = "select LOCK_1,LOCK_2 from FOUNDERPCB_FP_LOCK with(nolock) where (1=1) {0}";
            string iswhere = "";
            #region 判断是否按客户锁定
            iswhere = " and DATA0010_PTR=(select CUSTOMER_PTR from DATA0050 WHERE rkey=" + DATA0050_PTR + ") and DATA0050_PTR=0";
            dt = db.GetDataSet(string.Format(sql, iswhere));
            if (dt.Rows.Count > 0)
            {
                if (RoleType == 0)
                {
                    if (dt.Rows[0]["LOCK_1"].ToString() == "1") return true;
                }
                if (RoleType == 1)
                {
                    if (dt.Rows[0]["LOCK_2"].ToString() == "1") return true;
                }
            }
            #endregion
            #region 判断是否按料号锁定
            iswhere = "  and (DCODE='' or DCODE IS NULL) AND DATA0050_PTR=" + DATA0050_PTR;

            dt = db.GetDataSet(string.Format(sql, iswhere));
            if (dt.Rows.Count > 0)
            {
                if (RoleType == 0)
                {
                    if (dt.Rows[0]["LOCK_1"].ToString() == "1") return true;
                }
                if (RoleType == 1)
                {
                    if (dt.Rows[0]["LOCK_2"].ToString() == "1") return true;
                }
            }
            #endregion

            //2013-5-8修改 and (lot='' or lot IS NULL)
            iswhere = "  and  DATA0050_PTR=" + DATA0050_PTR + " and (lot='' or lot IS NULL) ";
            if (DCODE != null)
            {
                iswhere += " and DCODE='" + DCODE + "'";
            }
            else
            {
                iswhere += " and (DCODE='' or DCODE IS NULL)";
            }
            dt = db.GetDataSet(string.Format(sql, iswhere));
            if (dt.Rows.Count > 0)
            {
                if (RoleType == 0)
                {
                    if (dt.Rows[0]["LOCK_1"].ToString() == "1") b = true;
                }
                if (RoleType == 1)
                {
                    if (dt.Rows[0]["LOCK_2"].ToString() == "1") b = true;
                }
            }


            iswhere = "  and  DATA0050_PTR=" + DATA0050_PTR;
            if (DCODE != null)
            {
                iswhere += " and DCODE='" + DCODE + "'";
            }
            else
            {
                iswhere += " and (DCODE='' or DCODE IS NULL)";
            }

            if (LOT != null)
            {
                iswhere += " and lot='" + LOT + "'";
            }
            else
            {
                iswhere += " and (lot='' or lot IS NULL)";
            }
            dt = db.GetDataSet(string.Format(sql, iswhere));
            if (dt.Rows.Count > 0)
            {
                if (RoleType == 0)
                {
                    if (dt.Rows[0]["LOCK_1"].ToString() == "1") b = true;
                }
                if (RoleType == 1)
                {
                    if (dt.Rows[0]["LOCK_2"].ToString() == "1") b = true;
                }
            }
            return b;
        }

        
        #endregion

        #region Excel 导入导出
        //导入
        public static DataTable ExcelIntoDatagridView(DataGridView dgv)
        {
            System.Data.DataTable excelDt = new System.Data.DataTable();
            //打开一个文件选择框  
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Excel文件";
            openFile.FileName = "";
            openFile.Filter = "Excel 2003(*.xls)|*.xls|Excel 2007(*.xlsx)|*.xlsx"; 

            try
            {

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string connStr = null;
                    string filename = openFile.FileName;
                    int index = filename.LastIndexOf("\\");//截取文件的名字
                    filename = filename.Substring(index + 1);
                    int suffix_index = filename.LastIndexOf(".");
                    string suffixName = filename.Substring(suffix_index + 1);

                    Version ver = System.Environment.OSVersion.Version;
                    string strClient = "";
                    if (ver.Major == 5 && ver.Minor == 1)
                    {
                        strClient = "Win XP";
                    }
                    else if (ver.Major == 6 && ver.Minor == 0)
                    {
                        strClient = "Win Vista";
                    }
                    else if (ver.Major == 6 && ver.Minor == 1)
                    {
                        strClient = "Win 7";
                    }
                    else if (ver.Major == 5 && ver.Minor == 0)
                    {
                        strClient = "Win 2000";
                    }
                    else
                    {
                        strClient = "其他";
                    }
                   
                    if (strClient != "Win 7")
                    {
                        if (suffixName == "xls")
                        {
                            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
                                + "Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\";"
                                + "Data Source=" + filename;
                        }
                        else if (suffixName == "xlsx")
                        {
                            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;"
                               + "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;\";"
                               + "Data Source=" + filename;
                        }
                        else
                        {
                            MessageBox.Show("格式错误");
                            return excelDt;
                        }
                    }
                    else
                    {
                        if (suffixName == "xls")
                        {
                            connStr = "Provider=Microsoft.Jet.OLEDB.4.0;"
                                + "Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\";"
                                + "Data Source=" + openFile.FileName;
                        }
                        else if (suffixName == "xlsx")
                        {
                            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;"
                               + "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1;\";"
                               + "Data Source=" + openFile.FileName;
                        }
                        else
                        {
                            MessageBox.Show("格式错误");
                            return excelDt;
                        }
                    }
                    OleDbConnection objConn = null;
                    objConn = new OleDbConnection(connStr);
                    objConn.Open();
                    System.Data.DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = "";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        sheetName = dt.Rows[0]["TABLE_NAME"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("数据为空");
                        return excelDt;
                    }

                    string sql = string.Format("SELECT * FROM [{0}]", sheetName);

                    
                    OleDbDataAdapter da = new OleDbDataAdapter(sql, objConn);
                    da.Fill(excelDt);
                    objConn.Close();

                    dgv.DataSource = excelDt;
                    //if (excelDt != null)
                    //{
                    //    int count = excelDt.Rows.Count;
                    //    for (int i = 0; i < count; i++)
                    //    {
                    //        int cellCount = tabName.Rows[i].Cells.Count;
                    //        for (int j = 1; j < cellCount; j++)
                    //        {
                    //            tabName.Rows[i].Cells[j].Value = excelDt.Rows[i][j].ToString();
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("导入文件时出错,文件可能正被打开" + ee.Message, "提示");
            }
            return excelDt;
        }

        //导出execl
        public static bool DataGridviewShowToExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
                return false;

            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "导出Excel (*.xls)|*.xls";
            //saveFileDialog.FilterIndex = 0;
            //saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.CreatePrompt = true;
            //saveFileDialog.Title = "导出文件保存路径";
            //saveFileDialog.ShowDialog();
            //string strName = saveFileDialog.FileName;
            //if (strName.Length != 0)
            //{

             //   System.Reflection.Missing miss = System.Reflection.Missing.Value;

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                //Microsoft.Office.Interop.Excel.ApplicationClass excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
                excel.Application.Workbooks.Add(true); ;
                excel.Visible = false;//若是true，则在导出的时候会显示EXcel界面。
                if (excel == null)
                {
                    MessageBox.Show("EXCEL无法启动！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Microsoft.Office.Interop.Excel.Workbooks books = (Microsoft.Office.Interop.Excel.Workbooks)excel.Workbooks;
                //Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook)(books.Add(miss));
                //Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
               // sheet.Name = "Sheet1";
                // 生成字段名称  
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }

                //填充数据  
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {

                        if (dgv[j, i].ValueType == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "'" + dgv[j, i].Value == null ? "" : dgv[j, i].Value.ToString();
                        }
                        else
                        {
                            if (dgv.Columns[j].HeaderText == "物料编码")
                            {
                                excel.Cells[i + 2, j + 1] = "'" + dgv[j, i].Value == null ? "" : dgv[j, i].Value.ToString();
                            }
                            else
                            {
                                excel.Cells[i + 2, j + 1] = dgv[j, i].Value == null ? "" : dgv[j, i].Value.ToString();
                            }
                        }
                    }

                }

                excel.Visible = true;

              //  excel.DisplayAlerts = false; 
                //sheet.SaveAs(strName, miss, miss, miss, miss, miss, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, miss, miss, miss);
                //book.Close(false, miss, miss);
                //books.Close();
                //excel.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

                //GC.Collect();
              //  MessageBox.Show("数据已经成功导出!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

              //  System.Diagnostics.Process.Start(strName);
                
          //  }

            return true;
        }


        #endregion

        /// <summary>
        /// 快速打印接口
        /// 返回值说明：-1出现异常
        ///             0 报表不存在
        ///             1 启动打印成功
        ///             2 报表停用
        /// </summary>
        /// <param name="formName">窗口代码</param>
        /// <param name="reportCode">报表代码</param>
        /// <param name="reportDesc">报表描述，用于设置选择</param>
        /// <param name="parm">传入参数值</param>
        /// <returns></returns>
        public int QuickPrint(string formName,string reportCode,string reportDesc,string parm)
        {
            return 0;
            //try
            //{
            //    DBHelper db = new DBHelper();
            //    KB.Models.RPT_SETPARM info = new KB.Models.RPT_SETPARM();
            //   // KB.BLL. bll = new KB.Models.RPT_SETPARM(db);
            //    KB.BLL.RPT_SETPARMBLL bll = new RPT_SETPARMBLL(db);
            //    KB.Models.RPT_SERVERPATH info1 = new KB.Models.RPT_SERVERPATH();
            //    KB.BLL.RPT_SERVERPATHBLL bll1 = new RPT_SERVERPATHBLL(db);

            //    string sql;
            //    sql = string.Format(@"select rkey,REPORT_PTR from RPT_QUICKREPORT_LINK where FROM_NAME='{0}' AND REPORT_NAME='{1}'", formName, reportCode);
            //    DataTable dt = new DataTable();
            //    dt = db.GetDataSet(sql);
            //    if (dt.Rows.Count == 0)
            //    {
            //        sql = string.Format(@"INSERT INTO RPT_QUICKREPORT_LINK (FROM_NAME,REPORT_NAME,REPORT_DESC,REPORT_PTR,EMP_PTR) VALUES('{0}','{1}','{2}',0,0)", formName, reportCode, reportDesc);  
            //        db.ExecuteNonQuery(sql);
            //        return 0;
            //    }
            //    else
            //    {
            //        int serverPtr = 0;
            //        int rkey = int.Parse(dt.Rows[0]["REPORT_PTR"].ToString());
            //        if (rkey > 0)
            //        {
            //            info = bll.GetModel(rkey);
            //            if (info.ACTIVE_FLAG == 1)
            //            {
            //                serverPtr = (int)info.SERVER_PTR;
            //                info1 = bll1.GetModel(serverPtr);

            //                KB.Module.Remote.FrmPrintView fm = new KB.Module.Remote.FrmPrintView();
            //                fm.reportServerURL = info1.SERVER_PATH;
            //                fm.reportPath = info.REPORT_PATH.Trim() + "/" + info.REPORT_NAME.Trim() + "";
            //                fm.reportName = info.REPORT_NAME;
            //                fm.top = info.MARGINS_TOP * 4;
            //                fm.buttom = info.MARGINS_BUTTOM * 4;
            //                fm.left = info.MARGINS_LEFT * 4;
            //                fm.right = info.MARGINS_RIGHT * 4;
            //                if (info.CHOOSE_PAYE == 0)
            //                {
            //                    fm.printSet = true;
            //                }
            //                else
            //                {

            //                    fm.printSet = false;
            //                }
            //                fm.quickPrint = true;
            //                fm.parmName = info.REPORT_PARM.Trim();
            //                fm.parmValue = parm;
            //                fm.WindowState = FormWindowState.Maximized;
            //                fm.Show();
            //                fm.Activate();
            //                return 1;
            //            }
            //            else
            //            {
            //                return 2;
            //            }
            //        }
            //        else
            //        {
            //            return 0;
            //        }
                   
            //    }

               

            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message.ToString());
            //    return -1;
            //}
        
        }


        #region 发送SQL Server DB 邮件 SendDbMail

        #region 发送DB邮件 21个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "", "", "", "", "", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        /// <param name="queryAttachmentFilename">指定查询结果集附件使用的文件名。当 attach_query_result 为 0 时，忽略此参数。当 attach_query_result 为 1 且此参数为 NULL 时，数据库邮件会创建任意文件名。</param>
        /// <param name="queryResultHeader">指定查询结果是否包含列标题。query_result_header 值的数据类型为 bit。如果该值为 1，则查询结果包含列标题。如果该值为 0，则查询结果不包含列标题。该参数的默认值为 1。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultWidth">用于设置查询结果的格式的线条宽度（字符）。query_result_width 的数据类型为 int，默认值为 256。提供的值必须介于 10 和 32767 之间。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultSeparator">用于分隔查询输出中的列的字符。分隔符的类型为 char(1)。默认为“ ”（空格）。</param>
        /// <param name="excludeQueryOutput">指定是否使用电子邮件返回查询执行的输出。参数为 0 时，sp_send_dbmail 存储过程的执行将在控制台上打印作为查询执行结果而返回的消息。当此参数为 1 时，sp_send_dbmail 存储过程的执行不会在控制台上打印任何查询执行消息。</param>
        /// <param name="appendQueryError">指定是否在 @DataSetGetDataFromSQL 参数指定的查询返回错误时发送电子邮件。append_query_error 的数据类型为 bit，默认值为 0。为 1，则数据库邮件会发送电子邮件，并在电子邮件的正文中包括查询错误消息。为 0，则数据库邮件不发送电子邮件，sp_send_dbmail 在结束时会返回代码 1，指示失败。</param>
        /// <param name="queryNoTruncate">指定是否使用可避免截断大型可变长度数据类型（varchar(max)、nvarchar(max)、varbinary(max)、xml、text、ntext、image 和用户定义类型）的选项执行查询。设置该选项后，查询结果将不包含列标题。数据类型为 bit。为 0 或未指定时，查询中的列将截断为 256 个字符。为 1 时，不截断查询中的列。此参数的默认值为 0。</param>
        /// <param name="mailitemId">可选输出参数将返回消息的 mailitem_id。mailitem_id 的类型为 int。返回代码 0 表示成功。任何其他值表示失败。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile,
                string queryAttachmentFilename,
                string queryResultHeader,
                string queryResultWidth,
                string queryResultSeparator,
                string excludeQueryOutput,
                string appendQueryError,
                string queryNoTruncate,
                string mailitemId
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar), 
                new SqlParameter("@query_attachment_filename",SqlDbType.VarChar),
                new SqlParameter("@query_result_header",SqlDbType.VarChar), 
                new SqlParameter("@query_result_width",SqlDbType.VarChar),
                new SqlParameter("@query_result_separator",SqlDbType.VarChar), 
                new SqlParameter("@exclude_query_output",SqlDbType.VarChar),
                new SqlParameter("@append_query_error",SqlDbType.VarChar),
                new SqlParameter("@query_no_truncate",SqlDbType.VarChar), 
                new SqlParameter("@mailitem_id",SqlDbType.VarChar)           
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;
                parameters[13].Value = queryAttachmentFilename;
                parameters[14].Value = queryResultHeader;
                parameters[15].Value = queryResultWidth;
                parameters[16].Value = queryResultSeparator;
                parameters[17].Value = excludeQueryOutput;
                parameters[18].Value = appendQueryError;
                parameters[19].Value = queryNoTruncate;
                parameters[20].Value = mailitemId;

               dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 20个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "", "", "", "", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        /// <param name="queryAttachmentFilename">指定查询结果集附件使用的文件名。当 attach_query_result 为 0 时，忽略此参数。当 attach_query_result 为 1 且此参数为 NULL 时，数据库邮件会创建任意文件名。</param>
        /// <param name="queryResultHeader">指定查询结果是否包含列标题。query_result_header 值的数据类型为 bit。如果该值为 1，则查询结果包含列标题。如果该值为 0，则查询结果不包含列标题。该参数的默认值为 1。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultWidth">用于设置查询结果的格式的线条宽度（字符）。query_result_width 的数据类型为 int，默认值为 256。提供的值必须介于 10 和 32767 之间。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultSeparator">用于分隔查询输出中的列的字符。分隔符的类型为 char(1)。默认为“ ”（空格）。</param>
        /// <param name="excludeQueryOutput">指定是否使用电子邮件返回查询执行的输出。参数为 0 时，sp_send_dbmail 存储过程的执行将在控制台上打印作为查询执行结果而返回的消息。当此参数为 1 时，sp_send_dbmail 存储过程的执行不会在控制台上打印任何查询执行消息。</param>
        /// <param name="appendQueryError">指定是否在 @DataSetGetDataFromSQL 参数指定的查询返回错误时发送电子邮件。append_query_error 的数据类型为 bit，默认值为 0。为 1，则数据库邮件会发送电子邮件，并在电子邮件的正文中包括查询错误消息。为 0，则数据库邮件不发送电子邮件，sp_send_dbmail 在结束时会返回代码 1，指示失败。</param>
        /// <param name="queryNoTruncate">指定是否使用可避免截断大型可变长度数据类型（varchar(max)、nvarchar(max)、varbinary(max)、xml、text、ntext、image 和用户定义类型）的选项执行查询。设置该选项后，查询结果将不包含列标题。数据类型为 bit。为 0 或未指定时，查询中的列将截断为 256 个字符。为 1 时，不截断查询中的列。此参数的默认值为 0。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile,
                string queryAttachmentFilename,
                string queryResultHeader,
                string queryResultWidth,
                string queryResultSeparator,
                string excludeQueryOutput,
                string appendQueryError,
                string queryNoTruncate
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar), 
                new SqlParameter("@query_attachment_filename",SqlDbType.VarChar),
                new SqlParameter("@query_result_header",SqlDbType.VarChar), 
                new SqlParameter("@query_result_width",SqlDbType.VarChar),
                new SqlParameter("@query_result_separator",SqlDbType.VarChar), 
                new SqlParameter("@exclude_query_output",SqlDbType.VarChar),
                new SqlParameter("@append_query_error",SqlDbType.VarChar),
                new SqlParameter("@query_no_truncate",SqlDbType.VarChar)     
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;
                parameters[13].Value = queryAttachmentFilename;
                parameters[14].Value = queryResultHeader;
                parameters[15].Value = queryResultWidth;
                parameters[16].Value = queryResultSeparator;
                parameters[17].Value = excludeQueryOutput;
                parameters[18].Value = appendQueryError;
                parameters[19].Value = queryNoTruncate;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 19个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "", "", "", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        /// <param name="queryAttachmentFilename">指定查询结果集附件使用的文件名。当 attach_query_result 为 0 时，忽略此参数。当 attach_query_result 为 1 且此参数为 NULL 时，数据库邮件会创建任意文件名。</param>
        /// <param name="queryResultHeader">指定查询结果是否包含列标题。query_result_header 值的数据类型为 bit。如果该值为 1，则查询结果包含列标题。如果该值为 0，则查询结果不包含列标题。该参数的默认值为 1。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultWidth">用于设置查询结果的格式的线条宽度（字符）。query_result_width 的数据类型为 int，默认值为 256。提供的值必须介于 10 和 32767 之间。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultSeparator">用于分隔查询输出中的列的字符。分隔符的类型为 char(1)。默认为“ ”（空格）。</param>
        /// <param name="excludeQueryOutput">指定是否使用电子邮件返回查询执行的输出。参数为 0 时，sp_send_dbmail 存储过程的执行将在控制台上打印作为查询执行结果而返回的消息。当此参数为 1 时，sp_send_dbmail 存储过程的执行不会在控制台上打印任何查询执行消息。</param>
        /// <param name="appendQueryError">指定是否在 @DataSetGetDataFromSQL 参数指定的查询返回错误时发送电子邮件。append_query_error 的数据类型为 bit，默认值为 0。为 1，则数据库邮件会发送电子邮件，并在电子邮件的正文中包括查询错误消息。为 0，则数据库邮件不发送电子邮件，sp_send_dbmail 在结束时会返回代码 1，指示失败。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile,
                string queryAttachmentFilename,
                string queryResultHeader,
                string queryResultWidth,
                string queryResultSeparator,
                string excludeQueryOutput,
                string appendQueryError
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar), 
                new SqlParameter("@query_attachment_filename",SqlDbType.VarChar),
                new SqlParameter("@query_result_header",SqlDbType.VarChar), 
                new SqlParameter("@query_result_width",SqlDbType.VarChar),
                new SqlParameter("@query_result_separator",SqlDbType.VarChar), 
                new SqlParameter("@exclude_query_output",SqlDbType.VarChar),
                new SqlParameter("@append_query_error",SqlDbType.VarChar)   
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;
                parameters[13].Value = queryAttachmentFilename;
                parameters[14].Value = queryResultHeader;
                parameters[15].Value = queryResultWidth;
                parameters[16].Value = queryResultSeparator;
                parameters[17].Value = excludeQueryOutput;
                parameters[18].Value = appendQueryError;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 18个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "", "", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        /// <param name="queryAttachmentFilename">指定查询结果集附件使用的文件名。当 attach_query_result 为 0 时，忽略此参数。当 attach_query_result 为 1 且此参数为 NULL 时，数据库邮件会创建任意文件名。</param>
        /// <param name="queryResultHeader">指定查询结果是否包含列标题。query_result_header 值的数据类型为 bit。如果该值为 1，则查询结果包含列标题。如果该值为 0，则查询结果不包含列标题。该参数的默认值为 1。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultWidth">用于设置查询结果的格式的线条宽度（字符）。query_result_width 的数据类型为 int，默认值为 256。提供的值必须介于 10 和 32767 之间。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultSeparator">用于分隔查询输出中的列的字符。分隔符的类型为 char(1)。默认为“ ”（空格）。</param>
        /// <param name="excludeQueryOutput">指定是否使用电子邮件返回查询执行的输出。参数为 0 时，sp_send_dbmail 存储过程的执行将在控制台上打印作为查询执行结果而返回的消息。当此参数为 1 时，sp_send_dbmail 存储过程的执行不会在控制台上打印任何查询执行消息。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile,
                string queryAttachmentFilename,
                string queryResultHeader,
                string queryResultWidth,
                string queryResultSeparator,
                string excludeQueryOutput
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar), 
                new SqlParameter("@query_attachment_filename",SqlDbType.VarChar),
                new SqlParameter("@query_result_header",SqlDbType.VarChar), 
                new SqlParameter("@query_result_width",SqlDbType.VarChar),
                new SqlParameter("@query_result_separator",SqlDbType.VarChar), 
                new SqlParameter("@exclude_query_output",SqlDbType.VarChar) 
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;
                parameters[13].Value = queryAttachmentFilename;
                parameters[14].Value = queryResultHeader;
                parameters[15].Value = queryResultWidth;
                parameters[16].Value = queryResultSeparator;
                parameters[17].Value = excludeQueryOutput;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 17个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        /// <param name="queryAttachmentFilename">指定查询结果集附件使用的文件名。当 attach_query_result 为 0 时，忽略此参数。当 attach_query_result 为 1 且此参数为 NULL 时，数据库邮件会创建任意文件名。</param>
        /// <param name="queryResultHeader">指定查询结果是否包含列标题。query_result_header 值的数据类型为 bit。如果该值为 1，则查询结果包含列标题。如果该值为 0，则查询结果不包含列标题。该参数的默认值为 1。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultWidth">用于设置查询结果的格式的线条宽度（字符）。query_result_width 的数据类型为 int，默认值为 256。提供的值必须介于 10 和 32767 之间。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultSeparator">用于分隔查询输出中的列的字符。分隔符的类型为 char(1)。默认为“ ”（空格）。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile,
                string queryAttachmentFilename,
                string queryResultHeader,
                string queryResultWidth,
                string queryResultSeparator
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar), 
                new SqlParameter("@query_attachment_filename",SqlDbType.VarChar),
                new SqlParameter("@query_result_header",SqlDbType.VarChar), 
                new SqlParameter("@query_result_width",SqlDbType.VarChar),
                new SqlParameter("@query_result_separator",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;
                parameters[13].Value = queryAttachmentFilename;
                parameters[14].Value = queryResultHeader;
                parameters[15].Value = queryResultWidth;
                parameters[16].Value = queryResultSeparator;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 16个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        /// <param name="queryAttachmentFilename">指定查询结果集附件使用的文件名。当 attach_query_result 为 0 时，忽略此参数。当 attach_query_result 为 1 且此参数为 NULL 时，数据库邮件会创建任意文件名。</param>
        /// <param name="queryResultHeader">指定查询结果是否包含列标题。query_result_header 值的数据类型为 bit。如果该值为 1，则查询结果包含列标题。如果该值为 0，则查询结果不包含列标题。该参数的默认值为 1。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="queryResultWidth">用于设置查询结果的格式的线条宽度（字符）。query_result_width 的数据类型为 int，默认值为 256。提供的值必须介于 10 和 32767 之间。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile,
                string queryAttachmentFilename,
                string queryResultHeader,
                string queryResultWidth
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar), 
                new SqlParameter("@query_attachment_filename",SqlDbType.VarChar),
                new SqlParameter("@query_result_header",SqlDbType.VarChar), 
                new SqlParameter("@query_result_width",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;
                parameters[13].Value = queryAttachmentFilename;
                parameters[14].Value = queryResultHeader;
                parameters[15].Value = queryResultWidth; ;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 15个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        /// <param name="queryAttachmentFilename">指定查询结果集附件使用的文件名。当 attach_query_result 为 0 时，忽略此参数。当 attach_query_result 为 1 且此参数为 NULL 时，数据库邮件会创建任意文件名。</param>
        /// <param name="queryResultHeader">指定查询结果是否包含列标题。query_result_header 值的数据类型为 bit。如果该值为 1，则查询结果包含列标题。如果该值为 0，则查询结果不包含列标题。该参数的默认值为 1。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile,
                string queryAttachmentFilename,
                string queryResultHeader
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar), 
                new SqlParameter("@query_attachment_filename",SqlDbType.VarChar),
                new SqlParameter("@query_result_header",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;
                parameters[13].Value = queryAttachmentFilename;
                parameters[14].Value = queryResultHeader;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 14个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        /// <param name="queryAttachmentFilename">指定查询结果集附件使用的文件名。当 attach_query_result 为 0 时，忽略此参数。当 attach_query_result 为 1 且此参数为 NULL 时，数据库邮件会创建任意文件名。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile,
                string queryAttachmentFilename
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar), 
                new SqlParameter("@query_attachment_filename",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;
                parameters[13].Value = queryAttachmentFilename;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 13个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        /// <param name="attachQueryResultAsFile">指定查询结果集是否作为附件返回。attach_query_result_as_file 的数据类型为 bit，默认值为 0。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase,
                string attachQueryResultAsFile
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar),
                new SqlParameter("@attach_query_result_as_file",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;
                parameters[12].Value = attachQueryResultAsFile;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 12个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        /// <param name="executeQueryDatabase">存储过程在其中运行查询的数据库上下文。该参数的类型为 sysname，默认为当前数据库。只有在指定 @DataSetGetDataFromSQL 时，此参数才适用。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL,
                string executeQueryDatabase
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar), 
                new SqlParameter("@execute_query_database",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;
                parameters[11].Value = executeQueryDatabase;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 11个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        /// <param name="DataSetGetDataFromSQL">要执行的查询。查询结果可以作为文件附加，或包含在电子邮件的正文中,调用 sp_send_dbmail 的脚本中的局部变量不可用于查询。</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments,
                string DataSetGetDataFromSQL
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar),
                new SqlParameter("@DataSetGetDataFromSQL",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;
                parameters[10].Value = DataSetGetDataFromSQL;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 10个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL", "");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        /// <param name="fileAttachments">电子邮件附件的文件名列表，以分号分隔。必须使用绝对路径指定列表中的文件。默认情况下，数据库邮件会将文件附件限制在每个文件 1 MB 大小</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity,
                string fileAttachments
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar),
                new SqlParameter("@file_attachments",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;
                parameters[9].Value = fileAttachments;

                dbhelper.RunProcedure("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 9个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL", "NORMAL");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        /// <param name="sensitivity">邮件的敏感度:Normal(默认)、Personal、Private、Confidential</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance,
                string sensitivity
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar),
                new SqlParameter("@sensitivity",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;
                parameters[8].Value = sensitivity;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 8个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML", "NORMAL");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        /// <param name="importance">邮件的重要性:Low、Normal(默认)、High</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat,
                string importance
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar),
                new SqlParameter("@importance",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;
                parameters[7].Value = importance;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 7个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "", "邮件主题", "邮件正文", "HTML");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="blindCopyRecipients">要向其密件抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string blindCopyRecipients,
                string subject,
                string body,
                string bodyFormat
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@blind_copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = blindCopyRecipients;
                parameters[4].Value = subject;
                parameters[5].Value = body;
                parameters[6].Value = bodyFormat;

                //不调用Excute方法，sp_send_dbmail不含returnID参数 陈玉冰 2012/10/30
                dbhelper.RunProcedure("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 6个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "", "邮件主题", "邮件正文", "HTML");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="copyRecipients">要向其抄送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string copyRecipients,
                string subject,
                string body,
                string bodyFormat
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar), 
                new SqlParameter("@copy_recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar)
                                           };

                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = copyRecipients;
                parameters[3].Value = subject;
                parameters[4].Value = body;
                parameters[5].Value = bodyFormat;

                dbhelper.ExecuteCommandProc("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region 发送DB邮件 5个参数 SendDbMail
        /// <summary>
        /// <para>功能：通过SQL服务器定义的数据库邮件配置名发送邮件</para>
        /// <example>
        /// <para>例子：</para>
        /// <para>FounderPCBWeb.DBC myDBC = new FounderPCBWeb.DBC(98);</para>
        /// <para>myDBC.SendDbMail("DBA SQL", "niejianxin@KB.com", "邮件主题", "邮件正文", "HTML");</para>
        /// </example>
        /// </summary>
        /// <param name="profileName">发送邮件的配置文件的名称</param>
        /// <param name="recipients">要向其发送邮件的电子邮件地址列表，以分号分隔</param>
        /// <param name="subject">电子邮件的主题</param>
        /// <param name="body">电子邮件的正文</param>
        /// <param name="bodyFormat">邮件正文的格式:TEXT（默认）或HTML</param>
        public void SendDbMail(
                string profileName,
                string recipients,
                string subject,
                string body,
                string bodyFormat
            )
        {
            try
            {
                SqlParameter[] parameters ={
                new SqlParameter("@profile_name",SqlDbType.VarChar),
                new SqlParameter("@recipients",SqlDbType.VarChar),
                new SqlParameter("@subject",SqlDbType.VarChar),
                new SqlParameter("@body",SqlDbType.VarChar), 
                new SqlParameter("@body_format",SqlDbType.VarChar)
                                           };
                parameters[0].Value = profileName;
                parameters[1].Value = recipients;
                parameters[2].Value = subject;
                parameters[3].Value = body;
                parameters[4].Value = bodyFormat;

                //不调用Excute方法，sp_send_dbmail不含returnID参数 陈玉冰 2012/10/30
                dbhelper.RunProcedure("msdb.dbo.sp_send_dbmail", parameters);

            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #endregion
    }
}
