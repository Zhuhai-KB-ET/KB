using System;
using System.Collections.Generic;
using System.Text;

namespace KB.FUNC
{
    public class TimeParser
    {

        /// <summary>
        /// 把秒转换成分钟
        /// </summary>
        /// <returns></returns>
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }

        #region 返回某年某月最后一天
        /// <summary>
        /// 返回某年某月最后一天
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="month">月份</param>
        /// <returns>日</returns>
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        #endregion

        #region 返回时间差
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                //TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                //TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                //TimeSpan ts = ts1.Subtract(ts2).Duration();
                TimeSpan ts = DateTime2 - DateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小时前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分钟前";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }
        #endregion

        #region 将时间转换为Decimal类型
        /// <summary>
        /// 将当前时间转换为Decimal类型
        /// </summary>
        /// <returns></returns>
        public static decimal MinuteToDecimal()
        {
            decimal d = 0;
            string[] args = DateTime.Now.ToLongTimeString().Split(':');
            string StrTime = "";
            StrTime += args[0].ToString() + args[1].ToString() + args[2].ToString();
            try
            {
                d = decimal.Parse(StrTime);
            }
            catch
            {
                d = 0;
            }
            return d;
        }
        /// <summary>
        /// 将指定时间转换为Decimal类型
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static decimal MinuteToDecimal(DateTime datetime)
        {
            decimal d = 0;
            string[] args = datetime.ToLongTimeString().Split(':');
            string StrTime = "";
            StrTime += args[0].ToString() + args[1].ToString() + args[2].ToString();
            try
            {
                d = decimal.Parse(StrTime);
            }
            catch
            {
                d = 0;
            }
            return d;
        }
        #endregion

        #region 将Decimal类型转时间字符串
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num">Decimal类型</param>
        /// <param name="hasff">是否带毫秒</param>
        /// <returns></returns>
        public static string DecimalToMinute(decimal num,bool hasff)
        {
            string Number = num.ToString();
            int len = Number.Length;
            string Minute ="";
            if(hasff)
            {
               Minute= "00:00:00:00";
               if (num == 0) return Minute;               
            }
            else
            {
                Minute="00:00:00";
                if (num == 0) return Minute;               
            }
            switch (len)
            {
                case 1:
                    if (hasff)
                    {
                        Minute = "00:00:00:0" + Number;
                    }
                    else
                    {
                        Minute = "00:00:0" + Number;
                    }
                    break;
                case 2:
                    if (hasff)
                    {
                        Minute = "00:00:00:" + Number;
                    }
                    else
                    {
                        Minute = "00:00:" + Number;
                    }
                    break;
                case 3:
                    if (hasff)
                    {
                        Minute = "00:00:0" + Number.Substring(0, 1) + ":" + Number.Substring(1);
                    }
                    else
                    {
                        Minute = "00:0" + Number.Substring(0, 1) + ":" + Number.Substring(1);
                    }
                    break;
                case 4:
                    if (hasff)
                    {
                        Minute = "00:00:" + Number.Substring(0, 2) + ":" + Number.Substring(2);
                    }
                    else
                    {
                        Minute = "00:" + Number.Substring(0, 2) + ":" + Number.Substring(2);
                    }
                    break;
                case 5:
                    if (hasff)
                    {
                        Minute = "00:0" + Number.Substring(0, 1) + ":" + Number.Substring(1, 2) + ":" + Number.Substring(3);
                    }
                    else
                    {
                        Minute = "0" + Number.Substring(0, 1) + ":" + Number.Substring(1, 2) + ":" + Number.Substring(3);
                    }
                    break;
                case 6:
                    if (hasff)
                    {
                        Minute = "00:" + Number.Substring(0, 2) + ":" + Number.Substring(2, 2) + ":" + Number.Substring(4);
                    }
                    else
                    {
                        Minute = Number.Substring(0, 2) + ":" + Number.Substring(2, 2) + ":" + Number.Substring(4);
                    }
                    break;
            }
            if (len == 7) Minute = "0" + Number.Substring(0, 1) + ":" + Number.Substring(1, 2) + ":" + Number.Substring(3, 2) + ":" + Number.Substring(5);
            if (len == 8) Minute = Number.Substring(0, 2) + ":" + Number.Substring(2, 2) + ":" + Number.Substring(4, 2) + ":" + Number.Substring(6);           
            return Minute;
        }
        #endregion
    }
}
