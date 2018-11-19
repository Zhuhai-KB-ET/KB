using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using KB.DAL;

namespace KB.FUNC
{
    /// <summary>
    /// 全局信息
    /// </summary>
    public class GlobalVal
    {
        #region 系统参数 System Parameter
        /// <summary>
        /// 系统名称
        /// </summary>
        public static string SystemName = "FOUNDERPCB ERP";
        /// <summary>
        /// 系统最新版本号
        /// </summary>
        public static string SystemVersion;
        /// <summary>
        /// 系统启用时间，由数据库控制
        /// </summary>
        public static DateTime UseSystemDateTime;
        /// <summary>
        /// 是否可以使用本系统，由数据库控制
        /// </summary>
        public static Boolean UseSystem = true;
        /// <summary>
        /// 是否为测试平台，由数据库控制
        /// </summary>
        public static Boolean TestPlatform = true;
        /// <summary>
        /// 当前登陆系统失败次数
        /// </summary>
        public static int FailureNumber = 0;
        /// <summary>
        /// 最大许可登陆系统失败次数
        /// </summary>
        public static int MaxFailureNumber = 3;
        /// <summary>
        /// 升级维护时间
        /// </summary>
        public static DateTime UpgradeDateTime = DateTime.Parse("1900-1-1");
        /// <summary>
        /// 升级维护时间中在运行的用户，多少秒后T掉 约2-3分钟
        /// </summary>
        public static int UpgradeDateTimeTimeOut = 60;
        /// <summary>
        /// 工厂内对应数据库的索引
        /// </summary>
        public static int ConnIndex = 0;
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string[,] DBConnectionString;
        /// <summary>
        /// 子模块退出时，是否显示退出信息，用于强制关闭时
        /// </summary>
        public static Boolean ShowCloseMessage = true;
        /// <summary>
        /// 用于协调子窗口与父窗口这间的信息提示
        /// </summary>
        public static Boolean ShowCloseChildMessageEd = false;
        #endregion

        #region 初始化用户所佣有的权限 InitPermission

        #region 新类型 sModel
        /// <summary>
        /// 新类型
        /// </summary>
        public class sModel
        {
            public string UP_ID;
            public string ID = "";
            public int SORT = 0;//类别 1是模块，2是功能，3是字段
            public string UP_ENGLISH = "";
            public string ENGLISH = "";
            public string NAME = "";
            public string DESC = "";
            public string PERMISSION = "";//权限 第一位显示，第二位为访问
        }
        #endregion

        #region 初始化 InitPermission
        private static sModel[] permission = new sModel[800];
        public static sModel[] Permission
        {
            get { return permission; }
            set { permission = value; }
        }
        public static void InitPermission()
        {
            try
            {
                #region 初始
                for (int i = 0; i < permission.GetUpperBound(0); i++)
                {
                    permission[i] = new sModel();
                }
                #endregion
                DataTable tb;
                string s_SQL;
                DBHelper DB = new DBHelper(0);
                //   string s_temp1, s_temp2, s_temp3, s_temp4;

                #region 说明
                // 窗口主体的AccessibleName   为模块ID
                // 主体中的控件AccessibleName 为功能英文名称
                //
                //
                #endregion

                #region 获取

                #region SQL语法
                //s_SQL = @" 
                //select * 
                //  from (
                //        select '用户'             as Category,
                //               tf1.UP_MODULE_ID   as UP_ID,
                //               tf1.MODULE_ID      as ID, 
                //               t1.sort            as sort,
                //               ''                 as UP_ENGLISH,
                //               tf1.MODULE_ENGLISH as ENGLISH,
                //               tf1.MODULE_NAME    as [NAME],
                //               tf1.MODULE_DESC    as [DESC],
                //               t1.PERMISSION      as PERMISSION
                //          from FOUNDERPCB_USER t with (nolock)
                //                inner join FOUNDERPCB_USER_PERMISSION t1  with (nolock) on t.rkey   = t1.PRO_RKEY
                //                inner join FOUNDERPCB_FRIGHTE_01      tf1 with (nolock) on tf1.rkey = t1.SRCE_PTR
                //         where t1.SORT = 1
                //           and t.LOGIN_ID = '" + GlobalVal.UserInfo.LoginName.Trim() + @"'
                //
                //        union all 
                //
                //        select '用户'                as Category,
                //               tf1.MODULE_ID         as UP_ID,
                //               tf1.MODULE_ID         as ID, 
                //               t1.sort               as sort,
                //               ''                    as UP_ENGLISH,
                //               tf2.OPERATION_ENGLISH as ENGLISH,
                //               tf2.OPERATION_NAME    as [NAME],
                //               tf2.OPERATION_DESC    as [DESC],
                //               t1.PERMISSION         as PERMISSION 
                //          from FOUNDERPCB_USER t with (nolock)
                //                inner join FOUNDERPCB_USER_PERMISSION t1  with (nolock) on t.rkey   = t1.PRO_RKEY
                //                inner join FOUNDERPCB_FRIGHTE_02 tf2      with (nolock) on tf2.rkey = t1.SRCE_PTR
                //                inner join FOUNDERPCB_FRIGHTE_01 tf1      with (nolock) on tf1.rkey = tf2.PRO_RKEY
                //         where t1.SORT = 2
                //           and t.LOGIN_ID = '" + GlobalVal.UserInfo.LoginName.Trim() + @"'
                //
                //        union all
                //
                //        select '用户'                as Category,
                //               tf1.MODULE_ID         as UP_ID,
                //               tf1.MODULE_ID         as ID, 
                //               t1.sort               as sort,
                //               tf2.OPERATION_ENGLISH as UP_ENGLISH, 
                //               tf3.FIELD_ENGLISH     as ENGLISH,
                //               tf3.FIELD_NAME        as [NAME],
                //               tf3.FIELD_DESC        as [DESC],
                //               t1.PERMISSION         as PERMISSION 
                //          from FOUNDERPCB_USER t with (nolock)
                //                inner join FOUNDERPCB_USER_PERMISSION t1  with (nolock) on t.rkey = t1.PRO_RKEY
                //                inner join FOUNDERPCB_FRIGHTE_03 tf3 with (nolock) on tf3.rkey    = t1.SRCE_PTR
                //                inner join FOUNDERPCB_FRIGHTE_02 tf2 with (nolock) on tf2.rkey    = tf3.PRO2_RKEY
                //                inner join FOUNDERPCB_FRIGHTE_01 tf1 with (nolock) on tf1.rkey    = tf2.PRO_RKEY
                //         where t1.SORT = 3
                //           and t.LOGIN_ID = '" + GlobalVal.UserInfo.LoginName.Trim() + @"' 
                //       ) mx
                //order by UP_ID, ID, sort
                //";
                //使用权限组，关联
                s_SQL = @"with tb_role as (
select max(aa.sort) sort,
                                   MAX(aa.srce_ptr) srce_ptr,
                                   aa.permission
                            from (
                                    select 
				                            isNull(a.rkey,0) as rkey,
				                            isNull(a.pro_rkey,0) as pro_rkey,
				                            isNull(a.sort,0) as sort,
				                            isNull(a.srce_ptr,'') as srce_ptr,
				                            isNull(a.permission,'') as permission
		                            from FOUNDERPCB_USER_PERMISSION a with(nolock)
		                            where a.PERMISSION!='00' and  PRO_RKEY={0}
                            union all
                                    select  
                                            isNull(a.rkey,0) as rkey,
				                            isNull(a.pro_rkey,0) as pro_rkey,
				                            isNull(a.sort,0) as sort,
				                            isNull(a.srce_ptr,'') as srce_ptr,
				                            isNull(a.permission,'') as permission
                                    from FOUNDERPCB_GROUP_D a with(nolock)
		                            left join FOUNDERPCB_GROUP_M with(nolock) on a.PRO_RKEY=FOUNDERPCB_GROUP_M.RKEY
		                            left join FOUNDERPCB_USER with(nolock) on FOUNDERPCB_USER.PRO_RKEY=FOUNDERPCB_GROUP_M.RKEY
		                            where a.PERMISSION!='00' and  FOUNDERPCB_USER.RKEY={0}
                            ) aa
                            group by aa.sort,aa.srce_ptr,aa.permission ) 
 

select '用户'             as Category,
               tf1.UP_MODULE_ID   as UP_ID,
               tf1.MODULE_ID      as ID, 
               t.sort            as sort,
               ''                 as UP_ENGLISH,
               tf1.MODULE_ENGLISH as ENGLISH,
               tf1.MODULE_NAME    as [NAME],
               tf1.MODULE_DESC    as [DESC],
               t.PERMISSION      as PERMISSION 
          from tb_role t                            
                inner join FOUNDERPCB_FRIGHTE_01  tf1 with (nolock) on tf1.rkey = t.SRCE_PTR  and t.sort=1              
      
  union all 

        select '用户'                as Category,
               tf1.MODULE_ID         as UP_ID,
               tf1.MODULE_ID         as ID, 
               t.sort               as sort,
               ''                    as UP_ENGLISH,
               tf2.OPERATION_ENGLISH as ENGLISH,
               tf2.OPERATION_NAME    as [NAME],
               tf2.OPERATION_DESC    as [DESC],
               t.PERMISSION         as PERMISSION 
          from tb_role t
                inner join FOUNDERPCB_FRIGHTE_02 tf2      with (nolock) on tf2.rkey = t.SRCE_PTR and t.SORT = 2
                inner join FOUNDERPCB_FRIGHTE_01 tf1      with (nolock) on tf1.rkey = tf2.PRO_RKEY
      
        union all

        select '用户'                as Category,
               tf1.MODULE_ID         as UP_ID,
               tf1.MODULE_ID         as ID, 
               t.sort               as sort,
               tf2.OPERATION_ENGLISH as UP_ENGLISH, 
               tf3.FIELD_ENGLISH     as ENGLISH,
               tf3.FIELD_NAME        as [NAME],
               tf3.FIELD_DESC        as [DESC],
               t.PERMISSION         as PERMISSION
          from tb_role t
                inner join FOUNDERPCB_FRIGHTE_03 tf3 with (nolock) on tf3.rkey    = t.SRCE_PTR and t.SORT = 3
                inner join FOUNDERPCB_FRIGHTE_02 tf2 with (nolock) on tf2.rkey    = tf3.PRO2_RKEY
                inner join FOUNDERPCB_FRIGHTE_01 tf1 with (nolock) on tf1.rkey    = tf2.PRO_RKEY
";
                #endregion

                tb = DB.GetDataSet(string.Format(s_SQL, GlobalVal.UserInfo.UserRkey));
                //用户大于组
                //s_temp1 = ""; s_temp2 = ""; s_temp3 = ""; s_temp4 = ""; 
                //for (int i = 0; i < tb.Rows.Count; i++)
                //{
                //    if (s_temp1 != tb.Rows[i]["Category"].ToString().Trim() && s_temp2 == tb.Rows[i]["UP_ID"].ToString().Trim() && s_temp3 == tb.Rows[i]["ID"].ToString().Trim() && s_temp4 == tb.Rows[i]["UP_ENGLISH"].ToString().Trim())
                //    {
                //        if (tb.Rows[i]["Category"].ToString().Trim() == "组")
                //        {
                //            tb.Rows.RemoveAt(i);
                //            i--;
                //        }
                //        if (s_temp1 == "组")
                //        {
                //            tb.Rows.RemoveAt(i - 1);
                //            i--;
                //        }
                //    }

                //    s_temp1 = tb.Rows[i]["Category"].ToString().Trim();
                //    s_temp2 = tb.Rows[i]["UP_ID"].ToString().Trim();
                //    s_temp3 = tb.Rows[i]["ID"].ToString().Trim();
                //    s_temp4 = tb.Rows[i]["UP_ENGLISH"].ToString().Trim();
                //}
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    permission[i].UP_ID = tb.Rows[i]["UP_ID"].ToString().Trim();
                    permission[i].ID = tb.Rows[i]["ID"].ToString().Trim();
                    permission[i].NAME = tb.Rows[i]["NAME"].ToString().Trim();
                    permission[i].UP_ENGLISH = tb.Rows[i]["UP_ENGLISH"].ToString().Trim();
                    permission[i].ENGLISH = tb.Rows[i]["ENGLISH"].ToString().Trim();
                    permission[i].DESC = tb.Rows[i]["DESC"].ToString().Trim();
                    permission[i].PERMISSION = tb.Rows[i]["PERMISSION"].ToString().Trim();
                    permission[i].SORT = int.Parse(tb.Rows[i]["SORT"].ToString().Trim());
                }
                #endregion

                DB.CloseConnection();
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                System.Environment.Exit(0);
            }
        }
        #endregion

        #endregion

        #region 初始化数据连接库池 InitConnection
        public static void InitConnection()
        {
            try
            {
                UserInfo.Connection = new SqlConnection[300];
                //下标1为厂别，下标2为数据库（1Live 2Samp 3Test 4Demo）
                DBConnectionString = new string[100, 20];

                try
                {
                    SQLiteSource.InitConnection(DBConnectionString);
                }
                catch
                {
                    MessageBox.Show("警告:SQLite数据库信息读取失败");
                    #region 1富山
                    DBConnectionString[1, 1] = "Data Source=erpdb01;Initial Catalog=live;User ID=FOUNDER;Password=FOUNDER";
                    DBConnectionString[1, 2] = "Data Source=erpdb01;Initial Catalog=samp;User ID=FOUNDER;Password=FOUNDER";
                    DBConnectionString[1, 3] = "Data Source=erpdb01;Initial Catalog=test;User ID=reportAdmin;Password=reportAdmin#";
                    // DBConnectionString[1, 3] = "Data Source=pcbit-live01;Initial Catalog=test;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[1, 4] = @"Data Source=pcbdevelop02\sqlserver;Initial Catalog=F3_TEST;User ID=reportAdmin;Password=reportAdmin#";// "Data Source=erpdb01;Initial Catalog=demo;User ID=FOUNDER;Password=FOUNDER";
                    #endregion

                    #region 8多层
                    DBConnectionString[8, 1] = "Data Source=dcerp03;Initial Catalog=dcv36Live;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[8, 2] = "Data Source=dcerp03;Initial Catalog=DCV36Samp;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[8, 3] = "Data Source=dcerp03;Initial Catalog=dcv36test;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[8, 4] = @"Data Source=pcbdevelop02\sqlserver;Initial Catalog=F1_TEST;User ID=reportAdmin;Password=reportAdmin#";// "Data Source=dcerp03;Initial Catalog=dcv36demo;User ID=reportAdmin;Password=reportAdmin#";
                    #endregion

                    #region 3越亚
                    DBConnectionString[3, 1] = "Data Source=erpdb02;Initial Catalog=live;User ID=developer;Password=system";
                    DBConnectionString[3, 2] = "Data Source=erpdb02;Initial Catalog=samp;User ID=developer;Password=system";
                    DBConnectionString[3, 3] = "Data Source=erpdb02;Initial Catalog=test;User ID=developer;Password=system";
                    DBConnectionString[3, 4] = @"Data Source=pcbdevelop02\sqlserver;Initial Catalog=F4_TEST;User ID=reportAdmin;Password=reportAdmin#";// "Data Source=erpdb02;Initial Catalog=demo;User ID=developer;Password=system";
                    #endregion

                    #region 4速能
                    DBConnectionString[4, 1] = "Data Source=snerp02;Initial Catalog=live;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[4, 2] = "Data Source=snerp02;Initial Catalog=sample;User ID=dbtest;Password=liqiang@";
                    DBConnectionString[4, 3] = "Data Source=snerp01;Initial Catalog=test;User ID=dbtest;Password=lilinfeng";
                    DBConnectionString[4, 4] = @"Data Source=pcbdevelop02\sqlserver;Initial Catalog=F2_TEST;User ID=reportAdmin;Password=reportAdmin#";// "Data Source=snerp01;Initial Catalog=demo;User ID=dbtest;Password=lilinfeng";
                    #endregion

                    #region 5重庆
                    DBConnectionString[5, 1] = "Data Source=cqerp04;Initial Catalog=live;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[5, 2] = "Data Source=cqerp04;Initial Catalog=sample;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[5, 3] = "Data Source=cqerp04;Initial Catalog=demo;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[5, 4] = @"Data Source=pcbdevelop02\sqlserver;Initial Catalog=F6_TEST;User ID=reportAdmin;Password=reportAdmin#";// "Data Source=cqerp04;Initial Catalog=demo;User ID=reportAdmin;Password=reportAdmin#";
                    //  DBConnectionString[5, 4] = @"Data Source=cqk201;Initial Catalog=INPLAN;User ID=cqinplantest;Password=cqinplantest#";
                    #endregion

                    #region 6高密
                    DBConnectionString[6, 1] = "Data Source=pcberp01;Initial Catalog=KBLIVE;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[6, 2] = "Data Source=pcberp01;Initial Catalog=KBDemo;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[6, 3] = "Data Source=pcberp01;Initial Catalog=KBTEST;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[6, 4] = @"Data Source=pcbdevelop02\sqlserver;Initial Catalog=F5_TEST;User ID=reportAdmin;Password=reportAdmin#";// "Data Source=pcberp01;Initial Catalog=KBTEST;User ID=reportAdmin;Password=reportAdmin#";
                    #endregion

                    #region 7外包厂
                    DBConnectionString[7, 1] = "Data Source=pcberp01;Initial Catalog=KBDEMO;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[7, 2] = "Data Source=pcberp01;Initial Catalog=KDO;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[7, 3] = "Data Source=pcberp01;Initial Catalog=KDO;User ID=reportAdmin;Password=reportAdmin#";
                    DBConnectionString[7, 4] = "Data Source=pcberp01;Initial Catalog=KDO;User ID=reportAdmin;Password=reportAdmin#";
                    #endregion
                }
                //#region 18测试环境
                //DBConnectionString[18, 1] = @"Data Source=[pcbdevelop02\sqlserver];Initial Catalog=F1-TEST;User ID=reportAdmin;Password=reportAdmin#";
                //DBConnectionString[18, 2] = @"Data Source=[pcbdevelop02\sqlserver];Initial Catalog=F2-TEST;User ID=reportAdmin;Password=reportAdmin#";
                //DBConnectionString[18, 3] = @"Data Source=[pcbdevelop02\sqlserver];Initial Catalog=F3-TEST;User ID=reportAdmin;Password=reportAdmin#";
                //DBConnectionString[18, 4] = @"Data Source=[pcbdevelop02\sqlserver];Initial Catalog=F4-TEST;User ID=reportAdmin;Password=reportAdmin#";
                //DBConnectionString[18, 5] = @"Data Source=[pcbdevelop02\sqlserver];Initial Catalog=F5-TEST;User ID=reportAdmin;Password=reportAdmin#";
                //DBConnectionString[18, 6] = @"Data Source=[pcbdevelop02\sqlserver];Initial Catalog=F6-TEST;User ID=reportAdmin;Password=reportAdmin#";
                //#endregion
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                System.Environment.Exit(0);
            }
        }
        #endregion

        #region 数据库连接信息 ConnectionString
        /// <summary>
        /// 数据库连接信息
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        public static string ConnectionString(int fid)
        {
            try
            {
                //保护功能，防止测试状态下使用正式库                
                if (TestPlatform && (GlobalVal.ConnIndex <= 1) || (GlobalVal.ConnIndex == 2 && GlobalVal.UserInfo.FactoryID == 1))  //
                {
                    Func.ShowWarning("系统并没正式运作，不能连接正式库！");
                    System.Environment.Exit(0);
                    return "";
                }
                return DBConnectionString[fid, GlobalVal.ConnIndex].Trim();
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 获取厂别信息 GetFactory
        /// <summary>
        /// 获取厂别信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFactory()
        {
            try
            {
                DataRow row;
                DataTable tb = new DataTable();
                tb.Columns.Add("text");
                tb.Columns.Add("value");

                row = tb.NewRow();
                row["text"] = "富山厂";
                row["value"] = "1";
                tb.Rows.Add(row);

                row = tb.NewRow();
                row["text"] = "多层厂";
                row["value"] = "8";
                tb.Rows.Add(row);

                row = tb.NewRow();
                row["text"] = "越亚厂";
                row["value"] = "3";
                tb.Rows.Add(row);

                row = tb.NewRow();
                row["text"] = "速能厂";
                row["value"] = "4";
                tb.Rows.Add(row);

                row = tb.NewRow();
                row["text"] = "重庆厂";
                row["value"] = "5";
                tb.Rows.Add(row);

                row = tb.NewRow();
                row["text"] = "高密厂";
                row["value"] = "6";
                tb.Rows.Add(row);

                row = tb.NewRow();
                row["text"] = "外包厂";
                row["value"] = "7";
                tb.Rows.Add(row);

                return tb;
            }
            catch
            {
                return new DataTable();
            }
        }
        /// <summary>
        /// 获取厂别信息
        /// </summary>
        /// <param name="i_para">厂别ID</param>
        /// <returns></returns>
        public static DataTable GetFactory(int i_para)
        {
            try
            {
                DataRow row;
                DataTable tb_ret;
                DataTable tb = GetFactory();
                tb_ret = new DataTable();
                tb_ret.Columns.Add("text");
                tb_ret.Columns.Add("value");
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (i_para == int.Parse(tb.Rows[i]["value"].ToString().Trim()))
                    {
                        row = tb_ret.NewRow();
                        row["text"] = tb.Rows[i]["text"].ToString().Trim();
                        row["value"] = tb.Rows[i]["value"].ToString().Trim();
                        tb_ret.Rows.Add(row);
                    }
                }
                return tb_ret;
            }
            catch
            {
                return new DataTable();
            }
        }
        #endregion

        #region 用户登陆信息 UserInfo
        /// <summary>
        /// 用户登陆信息
        /// </summary>
        public static class UserInfo
        {
            #region 登陆名 LoginName
            private static string loginName = "";
            /// <summary>
            /// 登陆名
            /// </summary>
            public static string LoginName
            {
                get { return loginName; }
                set { loginName = value; }
            }
            #endregion

            #region IP
            private static string ip = "";
            /// <summary>
            /// 电脑IP
            /// </summary>
            public static string IP
            {
                get { return ip; }
                set { ip = value; }
            }
            #endregion

            #region HostName
            private static string hostname = "";
            /// <summary>
            /// 计算机名字
            /// </summary>
            public static string HostName
            {
                get { return hostname; }
                set { hostname = value; }
            }
            #endregion

            #region DeptName
            private static string deptname = "";
            /// <summary>
            /// 部门全称
            /// </summary>
            public static string DeptName
            {
                get { return deptname; }
                set { deptname = value; }
            }
            #endregion

            #region 登陆时间 LoginDate
            private static DateTime loginDate;
            /// <summary>
            /// 登陆时间
            /// </summary>
            public static DateTime LoginDate
            {
                get { return loginDate; }
                set { loginDate = value; }
            }
            #endregion

            #region 厂别 FactoryID
            private static int factoryID = 0;
            /// <summary>
            /// 部门
            /// </summary>
            public static int FactoryID
            {
                get { return factoryID; }
                set { factoryID = value; }
            }
            #endregion

            #region 帐号级别 RAID
            private static int raid = 0;
            /// <summary>
            /// 帐号级别
            /// 0 是暂时
            /// 1 超级管理员
            /// 2 管理员
            /// 3 用户
            /// </summary>
            public static int RAID
            {
                get { return raid; }
                set { raid = value; }
            }
            #endregion

            #region DATA0073RKEY
            private static Decimal Data0073Rkey = 0;
            /// <summary>
            /// DATA0073RKEY
            /// </summary>
            public static Decimal DATA0073RKEY
            {
                get { return Data0073Rkey; }
                set { Data0073Rkey = value; }
            }
            #endregion

            #region DATA0005RKEY
            private static Decimal Data0005Rkey = 0;
            /// <summary>
            /// DATA0005RKEY
            /// </summary>
            public static Decimal DATA0005RKEY
            {
                get { return Data0005Rkey; }
                set { Data0005Rkey = value; }
            }
            #endregion

            #region FOUNDERPCB_LOGIN_LOG
            private static Decimal LogRkey = 0;
            /// <summary>
            /// LogRkey
            /// </summary>
            public static Decimal LOGRKEY
            {
                get { return LogRkey; }
                set { LogRkey = value; }
            }
            #endregion

            #region 域信息
            private static ADUserInfo ad;
            /// <summary>
            /// 域信息
            /// </summary>
            public static ADUserInfo AD
            {
                get { return ad; }
                set { ad = value; }
            }
            #endregion

            #region 线程数据连接库 Connection
            private static SqlConnection[] connection;
            /// <summary>
            /// 线程数据连接库
            /// </summary>
            public static SqlConnection[] Connection
            {
                get { return connection; }
                set { connection = value; }
            }
            #endregion

            #region FOUNDERPCB_USER
            private static Decimal userrkey = 0;
            /// <summary>
            /// UserRkey
            /// </summary>
            public static Decimal UserRkey
            {
                get { return userrkey; }
                set { userrkey = value; }
            }
            #endregion
        }
        #endregion

        #region 获取帐号级别说明 GetRaidName
        /// <summary>
        /// 获取帐号级别说明
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static string GetRaidName(int para)
        {
            try
            {
                if (para == 0) return "临时用户";
                if (para == 1) return "超级管理员";
                if (para == 2) return "管理员";
                if (para == 3) return "一般用户";

                return "";
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 检查系统状态 CheckSystemState
        /// <summary>
        /// 检查系统状态 CheckSystemState
        /// </summary>
        /// <returns>返回true为维护模式</returns>
        public static Boolean CheckSystemState()
        {
            DBHelper DB = new DBHelper(0);
            try
            {
                DataTable tb;
                string s_SQL;

                s_SQL = "select * from FOUNDERPCB_SYSTEM_PARA with (nolock) where PARA_ID = 3";
                tb = DB.GetDataSet(s_SQL);
                if (tb.Rows.Count > 0)
                {
                    if (Func.IsDateTime(tb.Rows[0]["PARAMETER_VALUES"].ToString().Trim()))
                    {
                        GlobalVal.UpgradeDateTime = DateTime.Parse(tb.Rows[0]["PARAMETER_VALUES"].ToString().Trim());
                        // if (DateTime.Now >= GlobalVal.UpgradeDateTime)
                        DateTime nowdate = Func.GetNowDate();
                        TimeSpan th = nowdate - GlobalVal.UpgradeDateTime;
                        if (th.TotalMinutes < 15)
                        {
                            return true;//设定时间小于15分钟，进入维护模式
                        }
                        else
                        {
                            return false;//设定时间大于15分钟，系统自动解锁
                        }
                    }
                    else
                        GlobalVal.UpgradeDateTime = DateTime.Parse("1900-1-1");
                }
                else
                    GlobalVal.UpgradeDateTime = DateTime.Parse("1900-1-1");

                tb.Dispose();
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                DB.CloseConnection();
            }
        }
        #endregion

        /// <summary>
        /// 根据厂别ID获取厂别代码
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getFactoryCodeByID(int ID)
        {
            string Code = "";
            switch (ID)
            {
                case 1:
                    Code = "F3";
                    break;
                case 8:
                    Code = "F1";
                    break;
                case 4:
                    Code = "F2";
                    break;
                case 5:
                    Code = "F6";
                    break;
                case 6:
                    Code = "F5";
                    break;
            }

            return Code;
        }

        /// <summary>
        /// 根据厂别ID获取厂别名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static string getFactoryNameByID(int ID)
        {
            string Code = "";
            switch (ID)
            {
                case 1:
                    Code = "珠海方正科技高密电子有限公司";
                    break;
                case 8:
                    Code = "珠海方正科技多层电路板有限公司";
                    break;
                case 4:
                    Code = "杭州方正速能科技有限公司";
                    break;
                case 5:
                    Code = "重庆方正高密电子有限公司";
                    break;
                case 6:
                    Code = "珠海方正科技高密电子有限公司";
                    break;
            }

            return Code;
        }
    }
}
