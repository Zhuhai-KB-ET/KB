using System;
using System.Xml;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web; 
using System.IO; 
using System.Text;
using KB.DAL;

/* 计算DATA0050，DATA0017的CIMNET_KEY值 */
namespace KB.FUNC /* 命名空间 */
{
    /// <summary>
    /// DATA0050表，因子为 50 
    /// DATA0017表，因子为 83
    /// DATA0025表，因子为 75
    /// DATA0026表，因子为 74
    /// DATA0038表，因子为 62
    /// </summary>
    public class CIMNET_KEY
    { 
        #region 定义CIMNET_KEY
        public CIMNET_KEY() { }
        #endregion 

        #region 获取Cimnet_key
        //d_TabNum为表的数据代码，d_rkey为表的RKEY
        public static string Get_CIMNET_KEY(int d_TabNum, decimal d_rkey)
        {
            try
            {
                #region 因子
                decimal d_factor = 0;
                if (d_TabNum == 50) d_factor = 50;
                else
                    if (d_TabNum == 17) d_factor = 83;
                    else
                        if (d_TabNum == 25) d_factor = 75;
                        else
                            if (d_TabNum == 26) d_factor = 74;
                            else
                                if (d_TabNum == 38) d_factor = 62;
                                else
                        return "";
                #endregion 

                #region 判断
                if (d_rkey <= 0 || d_rkey > (9999999900 + d_factor - 1))
                    return "";
                #endregion

                #region 密码对表
                string[,] s_pwd2 = new string[,]{  
                                               {"0","0",  "0",  "0",   "0",    "0",     "0",      "0",       "0",        "0"},//因子范围
                                               {"1","-80","100","1900","19900","199900","1999900","19999900","199999900","1999999900"},
                                               {"0","-70","200","2900","29900","299900","2999900","29999900","299999900","2999999900"},
                                               {"7","-60","300","3900","39900","399900","3999900","39999900","399999900","3999999900"},
                                               {"6","-50","400","4900","49900","499900","4999900","49999900","499999900","4999999900"},
                                               {"5","-40","500","5900","59900","599900","5999900","59999900","599999900","5999999900"},
                                               {"4","-30","600","6900","69900","699900","6999900","69999900","699999900","6999999900"},
                                               {"B","-20","700","7900","79900","799900","7999900","79999900","799999900","7999999900"},
                                               {"A","-10","800","8900","89900","899900","8999900","89999900","899999900","8999999900"},
                                               {"2","-90",  "0", "900", "9900", "99900","999900", "9999900", "99999900", "999999900"}
                                                };

                //添加因子范围
                s_pwd2[0, 1] = (d_factor - 1).ToString();
                s_pwd2[0, 2] = (decimal.Parse(s_pwd2[0, 1]) + 900).ToString();
                s_pwd2[0, 3] = (decimal.Parse(s_pwd2[0, 2]) + 9000).ToString();
                s_pwd2[0, 4] = (decimal.Parse(s_pwd2[0, 3]) + 90000).ToString();
                s_pwd2[0, 5] = (decimal.Parse(s_pwd2[0, 4]) + 900000).ToString();
                s_pwd2[0, 6] = (decimal.Parse(s_pwd2[0, 5]) + 9000000).ToString();
                s_pwd2[0, 7] = (decimal.Parse(s_pwd2[0, 6]) + 90000000).ToString();
                s_pwd2[0, 8] = (decimal.Parse(s_pwd2[0, 7]) + 900000000).ToString();
                s_pwd2[0, 9] = (decimal.Parse(s_pwd2[0, 8]) + 9000000000).ToString();

                string[,] s_pwd4 = new string[,]{{"9","0"},
                                                 {"8","1"},
                                                 {"B","2"},
                                                 {"A","3"},
                                                 {"D","4"},
                                                 {"C","5"},
                                                 {"F","6"},
                                                 {"E","7"},
                                                 {"1","8"},
                                                 {"0","9"}};
                string[,] s_pwd6 = new string[,]{{"D","0"},
                                                 {"C","1"},
                                                 {"F","2"},
                                                 {"E","3"},
                                                 {"9","4"},
                                                 {"8","5"},
                                                 {"B","6"},
                                                 {"A","7"},
                                                 {"5","8"},
                                                 {"4","9"}};
                string[,] s_pwd8 = new string[,]{
                                                {"E","0"},
                                                {"F","1"},
                                                {"C","2"},
                                                {"D","3"},
                                                {"A","4"},
                                                {"B","5"},
                                                {"8","6"},
                                                {"9","7"},
                                                {"6","8"},
                                                {"7","9"}};
                string[,] s_pwd10 = new string[,]{
                                                {"5","0"},
                                                {"4","1"},
                                                {"7","2"},
                                                {"6","3"},
                                                {"1","4"},
                                                {"0","5"},
                                                {"3","6"},
                                                {"2","7"},
                                                {"D","8"},
                                                {"C","9"}};
                string[,] s_pwd12 = new string[,]{ 
                                                {"4","0"},
                                                {"5","1"},
                                                {"6","2"},
                                                {"7","3"},
                                                {"0","4"},
                                                {"1","5"},
                                                {"2","6"},
                                                {"3","7"},
                                                {"C","8"},
                                                {"D","9"}};
                string[,] s_pwd14 = new string[,]{  
                                                {"3","0"},
                                                {"2","1"},
                                                {"1","2"},
                                                {"0","3"},
                                                {"7","4"},
                                                {"6","5"},
                                                {"5","6"},
                                                {"4","7"},
                                                {"B","8"},
                                                {"A","9"}};
                string[,] s_pwd16 = new string[,]{  
                                                {"9","0"},
                                                {"8","1"},
                                                {"B","2"},
                                                {"A","3"},
                                                {"D","4"},
                                                {"C","5"},
                                                {"F","6"},
                                                {"E","7"},
                                                {"1","8"},
                                                {"0","9"}};
                string[,] s_pwd18 = new string[,]{  
                                                {"3","0"},
                                                {"2","1"},
                                                {"1","2"},
                                                {"0","3"},
                                                {"7","4"},
                                                {"6","5"},
                                                {"5","6"},
                                                {"4","7"},
                                                {"B","8"},
                                                {"A","9"}};
                string[,] s_pwd20 = new string[,]{ 
                                                {"4","0"},
                                                {"5","1"},
                                                {"6","2"},
                                                {"7","3"},
                                                {"0","4"},
                                                {"1","5"},
                                                {"2","6"},
                                                {"3","7"},
                                                {"C","8"},
                                                {"D","9"}};
                //分界
                string[,] s_pwd5 = new string[,]  { { "4", "49" },        { "5", "50" } };
                string[,] s_pwd7 = new string[,]  { { "4", "949" },       { "5", "950" } };
                string[,] s_pwd9 = new string[,]  { { "4", "9949" },      { "5", "9950" } };
                string[,] s_pwd11 = new string[,] { { "5", "99949" },     { "4", "99950" } };
                string[,] s_pwd13 = new string[,] { { "7", "999949" },    { "6", "999950" } };
                string[,] s_pwd15 = new string[,] { { "5", "9999949" },   { "4", "9999950" } };
                string[,] s_pwd17 = new string[,] { { "5", "99999949" },  { "4", "99999950" } };
                string[,] s_pwd19 = new string[,] { { "5", "999999949" }, { "4", "999999950" } };

                //添加因子范围
                s_pwd5[0, 1] = s_pwd2[0, 1];
                s_pwd5[1, 1] = (decimal.Parse(s_pwd2[0, 1]) + 1).ToString();

                s_pwd7[0, 1] = s_pwd2[0, 2];
                s_pwd7[1, 1] = (decimal.Parse(s_pwd2[0, 2]) + 1).ToString();

                s_pwd9[0, 1] = s_pwd2[0, 3];
                s_pwd9[1, 1] = (decimal.Parse(s_pwd2[0, 3]) + 1).ToString();

                s_pwd11[0, 1] = s_pwd2[0, 4];
                s_pwd11[1, 1] = (decimal.Parse(s_pwd2[0, 4]) + 1).ToString();

                s_pwd13[0, 1] = s_pwd2[0, 5];
                s_pwd13[1, 1] = (decimal.Parse(s_pwd2[0, 5]) + 1).ToString();

                s_pwd15[0, 1] = s_pwd2[0, 6];
                s_pwd15[1, 1] = (decimal.Parse(s_pwd2[0, 6]) + 1).ToString();

                s_pwd17[0, 1] = s_pwd2[0, 7];
                s_pwd17[1, 1] = (decimal.Parse(s_pwd2[0, 7]) + 1).ToString();

                s_pwd19[0, 1] = s_pwd2[0, 8];
                s_pwd19[1, 1] = (decimal.Parse(s_pwd2[0, 8]) + 1).ToString();
                #endregion

                #region 计算
                int i_point = 0;
                string s_ret = "";
                decimal d_center_rkey = 0;

                //开始 0x76584D4E4554735953540000
                s_ret = "0x7";

                #region 1 至49        (2位+因子) + 4位
                if (d_rkey > decimal.Parse(s_pwd2[0, 0]) && d_rkey <= decimal.Parse(s_pwd2[0, 1])) 
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 1]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 1]) + d_factor + 9 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 1]) + d_factor);
                    #endregion

                    #region 4，5位
                    if (d_center_rkey < 10)
                        s_ret += s_pwd4[int.Parse(d_center_rkey.ToString()), 0] + s_pwd5[0, 0];
                    else
                        s_ret += s_pwd4[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd5[0, 0];
                    #endregion

                    //s_ret += "D4E4554735953540000";
                    s_ret += s_pwd6[0, 0]  + s_pwd7[0, 0]  + s_pwd8[0, 0]  + s_pwd9[0, 0]  + s_pwd10[0, 0] +
                             s_pwd11[0, 0] + s_pwd12[0, 0] + s_pwd13[0, 0] + s_pwd14[0, 0] + s_pwd15[0, 0] +
                             s_pwd16[0, 0] + s_pwd17[0, 0] + s_pwd18[0, 0] + s_pwd19[0, 0] + s_pwd20[0, 0] + "0000";
                }
                #endregion

                #region 50至949       (2位+因子) + 4位*10     + 6位
                if (d_rkey > decimal.Parse(s_pwd2[0, 1]) && d_rkey <= decimal.Parse(s_pwd2[0, 2])) 
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 2]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 2]) + d_factor + 99 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 2]) + d_factor);
                    #endregion

                    #region 4，5，6，7位
                    if (d_center_rkey >= 10)
                    {
                        s_ret += s_pwd4[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd7[0, 0];
                    }
                    else
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd7[0, 0];
                    }
                    #endregion

                    //s_ret += "E4554735953540000";
                    s_ret += s_pwd8[0, 0]  + s_pwd9[0, 0]  + s_pwd10[0, 0] +
                             s_pwd11[0, 0] + s_pwd12[0, 0] + s_pwd13[0, 0] + s_pwd14[0, 0] + s_pwd15[0, 0] +
                             s_pwd16[0, 0] + s_pwd17[0, 0] + s_pwd18[0, 0] + s_pwd19[0, 0] + s_pwd20[0, 0] + "0000";
                }
                #endregion

                #region 950至9949     (2位+因子) + 4位*100    + 6位*10    + 8位
                if (d_rkey > decimal.Parse(s_pwd2[0, 2]) && d_rkey <= decimal.Parse(s_pwd2[0, 3])) 
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 3]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 3]) + d_factor + 999 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 3]) + d_factor);
                    #endregion

                    #region 4，5，6，7，8，9位
                    if (d_center_rkey >= 100)
                    {
                        s_ret += s_pwd4[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd9[0, 0];
                    }
                    else
                    if (d_center_rkey >= 10)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd9[0, 0];
                    }
                    else
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd9[0, 0];
                    }
                    #endregion

                    //s_ret += "554735953540000";
                    s_ret += s_pwd10[0, 0] +
                             s_pwd11[0, 0] + s_pwd12[0, 0] + s_pwd13[0, 0] + s_pwd14[0, 0] + s_pwd15[0, 0] +
                             s_pwd16[0, 0] + s_pwd17[0, 0] + s_pwd18[0, 0] + s_pwd19[0, 0] + s_pwd20[0, 0] + "0000";
                }
                #endregion

                #region 9950至99949   (2位+因子) + 4位*1000   + 6位*100   + 8位*10   + 10位
                if (d_rkey > decimal.Parse(s_pwd2[0, 3]) && d_rkey <= decimal.Parse(s_pwd2[0, 4])) 
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 4]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 4]) + d_factor + 9999 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 4]) + d_factor);
                    #endregion

                    #region 4，5，6，7，8，9，10，11位
                    if (d_center_rkey >= 1000)
                    {
                        s_ret +=  s_pwd4[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd11[0, 0];
                    }
                    else
                    if (d_center_rkey >= 100)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd11[0, 0];
                    }
                    else
                    if (d_center_rkey >= 10)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd11[0, 0];
                    }
                    else
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd11[0, 0];
                    }
                    #endregion

                    //s_ret += "4735953540000";
                    s_ret += s_pwd12[0, 0] + s_pwd13[0, 0] + s_pwd14[0, 0] + s_pwd15[0, 0] +
                             s_pwd16[0, 0] + s_pwd17[0, 0] + s_pwd18[0, 0] + s_pwd19[0, 0] + s_pwd20[0, 0] + "0000";
                }
                #endregion

                #region 99950至999949 (2位+因子) + 4位*10000  + 6位*1000  + 8位*100  + 10位*10  + 12位
                if (d_rkey > decimal.Parse(s_pwd2[0, 4]) && d_rkey <= decimal.Parse(s_pwd2[0, 5])) 
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 5]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 5]) + d_factor + 99999 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 5]) + d_factor);
                    #endregion

                    #region 4，5，6，7，8，9，10，11，12，13位
                    if (d_center_rkey >= 10000)
                    {
                        s_ret +=  s_pwd4[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd13[0, 0];
                    }
                    else
                    if (d_center_rkey >= 1000)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd13[0, 0];
                    }
                    else
                    if (d_center_rkey >= 100)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd13[0, 0];
                    }
                    else
                    if (d_center_rkey >= 10)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd13[0, 0];
                    }
                    else
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd13[0, 0];
                    }
                    #endregion

                    //s_ret += "35953540000";
                    s_ret += s_pwd14[0, 0] + s_pwd15[0, 0] +
                             s_pwd16[0, 0] + s_pwd17[0, 0] + s_pwd18[0, 0] + s_pwd19[0, 0] + s_pwd20[0, 0] + "0000";
                }
                #endregion

                #region 999950以后    (2位+因子) + 4位*100000 + 6位*10000 + 8位*1000 + 10位*100 + 12位*10 + 14位
                if (d_rkey > decimal.Parse(s_pwd2[0, 5]) && d_rkey <= decimal.Parse(s_pwd2[0, 6])) 
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 6]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 6]) + d_factor + 999999 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 6]) + d_factor);
                    #endregion

                    #region 4，5，6，7，8，9，10，11，12，13，14，15位
                    if (d_center_rkey >= 100000)
                    {
                        s_ret +=  s_pwd4[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0] + s_pwd15[0, 0];
                    }
                    else
                    if (d_center_rkey >= 10000)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd15[0, 0];
                    }
                    else
                    if (d_center_rkey >= 1000)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd15[0, 0];
                    }
                    else
                    if (d_center_rkey >= 100)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd15[0, 0];
                    }
                    else
                    if (d_center_rkey >= 10)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd15[0, 0];
                    }
                    else
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd15[0, 0];
                    }
                    #endregion

                    //s_ret += "953540000";
                    s_ret += s_pwd16[0, 0] + s_pwd17[0, 0] + s_pwd18[0, 0] + s_pwd19[0, 0] + s_pwd20[0, 0] + "0000";
                }
                #endregion

                #region 9999950以后    (2位+因子) + 4位*1000000 + 6位*100000 + 8位*10000 + 10位*1000 + 12位*100 + 14位*10 + 16位
                if (d_rkey > decimal.Parse(s_pwd2[0, 6]) && d_rkey <= decimal.Parse(s_pwd2[0, 7]))
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 7]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 7]) + d_factor + 9999999 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 7]) + d_factor);
                    #endregion

                    #region 4，5，6，7，8，9，10，11，12，13，14，15，16位
                    if (d_center_rkey >= 1000000)
                    {
                        s_ret +=  s_pwd4[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(6, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 100000)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 10000)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 1000)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 100)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 10)
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0];
                    }
                    else
                    {
                        s_ret +=  s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret +=  s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret +=  s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[0, 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0];
                    }
                    #endregion

                    //s_ret += "53540000";
                    s_ret += s_pwd17[0, 0] + s_pwd18[0, 0] + s_pwd19[0, 0] + s_pwd20[0, 0] + "0000";
                }
                #endregion

                #region 99999950以后    (2位+因子) + 4位*10000000 + 6位*1000000 + 8位*100000 + 10位*10000 + 12位*1000 + 14位*100 + 16位*10 + 18位
                if (d_rkey > decimal.Parse(s_pwd2[0, 7]) && d_rkey <= decimal.Parse(s_pwd2[0, 8]))
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 8]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 8]) + d_factor + 99999999 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 8]) + d_factor);
                    #endregion

                    #region 4，5，6，7，8，9，10，11，12，13，14，15，16，17，18位
                    if (d_center_rkey >= 10000000)
                    {
                        s_ret += s_pwd4[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(6, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(7, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 1000000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(6, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 100000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 10000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 1000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 100)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 10)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[0, 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0];
                    }
                    else
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[0, 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[0, 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0];
                    }
                    #endregion

                    //s_ret += "540000";
                    s_ret += s_pwd19[0, 0] + s_pwd20[0, 0] + "0000";
                }
                #endregion

                #region 999999950以后    (2位+因子) + 4位*100000000 + 6位*10000000 + 8位*1000000 + 10位*100000 + 12位*10000 + 14位*1000 + 16位*100 + 18位*10 + 20位
                if (d_rkey > decimal.Parse(s_pwd2[0, 8]) && d_rkey <= decimal.Parse(s_pwd2[0, 9]))
                {
                    #region 2，3位
                    i_point = 0;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (decimal.Parse(s_pwd2[i, 9]) + d_factor <= d_rkey && decimal.Parse(s_pwd2[i, 9]) + d_factor + 999999999 >= d_rkey)
                        {
                            i_point = i;
                            break;
                        }
                    }
                    if (i_point > 0)
                        s_ret += s_pwd2[i_point, 0] + "5";
                    else
                        return "";

                    d_center_rkey = d_rkey - (decimal.Parse(s_pwd2[i_point, 9]) + d_factor);
                    #endregion

                    #region 4，5，6，7，8，9，10，11，12，13，14，16，17，18，19，20位
                    if (d_center_rkey >= 100000000)
                    {
                        s_ret += s_pwd4[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(6, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(7, 1)), 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(8, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 10000000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(6, 1)), 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(7, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 1000000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(6, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 100000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(5, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 10000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(4, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 1000)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(3, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 100)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[0, 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(2, 1)), 0];
                    }
                    else
                    if (d_center_rkey >= 10)
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[0, 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[0, 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(1, 1)), 0];
                    }
                    else
                    {
                        s_ret += s_pwd4[0, 0] + s_pwd5[1, 0];
                        s_ret += s_pwd6[0, 0] + s_pwd7[1, 0];
                        s_ret += s_pwd8[0, 0] + s_pwd9[1, 0];
                        s_ret += s_pwd10[0, 0] + s_pwd11[1, 0];
                        s_ret += s_pwd12[0, 0] + s_pwd13[1, 0];
                        s_ret += s_pwd14[0, 0] + s_pwd15[1, 0];
                        s_ret += s_pwd16[0, 0] + s_pwd17[1, 0];
                        s_ret += s_pwd18[0, 0] + s_pwd19[1, 0];
                        s_ret += s_pwd20[int.Parse(d_center_rkey.ToString().Substring(0, 1)), 0];
                    }
                    #endregion

                    //s_ret += "540000";
                    s_ret += "0000";
                }
                #endregion
                #endregion

                return s_ret;
            }
            catch (Exception e1)
            {
                log.Error(e1.Message, e1);
                return "";
            }
        }
        #endregion

        #region HexToByte
        public static byte[] HexToByte(string ps_Cimnet_Key)
        {
            try
            {
                byte[] b_ret = new byte[12];

                b_ret[0] = Convert.ToByte(ps_Cimnet_Key.Substring(2, 2), 16);
                b_ret[1] = Convert.ToByte(ps_Cimnet_Key.Substring(4, 2), 16);
                b_ret[2] = Convert.ToByte(ps_Cimnet_Key.Substring(6, 2), 16);
                b_ret[3] = Convert.ToByte(ps_Cimnet_Key.Substring(8, 2), 16);
                b_ret[4] = Convert.ToByte(ps_Cimnet_Key.Substring(10, 2), 16);
                b_ret[5] = Convert.ToByte(ps_Cimnet_Key.Substring(12, 2), 16);
                b_ret[6] = Convert.ToByte(ps_Cimnet_Key.Substring(14, 2), 16);
                b_ret[7] = Convert.ToByte(ps_Cimnet_Key.Substring(16, 2), 16);
                b_ret[8] = Convert.ToByte(ps_Cimnet_Key.Substring(18, 2), 16);
                b_ret[9] = Convert.ToByte(ps_Cimnet_Key.Substring(20, 2), 16);
                b_ret[10] = Convert.ToByte(ps_Cimnet_Key.Substring(22, 2), 16);
                b_ret[11] = Convert.ToByte(ps_Cimnet_Key.Substring(24, 2), 16); 

                return b_ret;
            }
            catch
            {
                return null;
            } 
        } 
        #endregion

        #region D73D05PASS
        /// <summary>
        /// 破解DATA0073与DATA0005
        /// </summary>
        /// <param name="TABLENAME">DATA0073/DATA0005</param>
        /// <param name="PASS">密码/明文</param>
        /// <param name="Mode">1为转为密码,2为转为明文</param>
        /// <returns></returns>
        public static string D73D05PASS(string TABLENAME, string PASS, int Mode)
        {
            try
            {
                DBHelper db = new DBHelper(0);

                return db.GetDataSet("select dbo.F_D73D05_PASSWORD('" + TABLENAME + "','" + PASS + "'," + Mode.ToString() + ") as pass").Rows[0]["pass"].ToString().Trim();
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return "";
            }
        }
        #endregion
    } 
}