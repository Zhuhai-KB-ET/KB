using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KB.BLL;
using KB.Models;
using KB.DAL;

namespace KB.FUNC
{
    /// <summary>
    /// 通用审批类，包含建立审批，发送审批，审批等功能。
    /// </summary>
    public class ApprovalMode
    {
        #region 私有成员
        /// <summary>
        /// 获取总的审批步骤
        /// </summary>
        /// <param name="APPROVAL_ROUTE_PTR"></param>
        /// <returns></returns>
        private static int GetTotalSteps(int APPROVAL_ROUTE_PTR,int FID)
        {
            string sql_d498 = @"select distinct data0498rkey,
                           count(*) as total_steps,
                           approval_step_no,
                           approval_step_desc
                    from view_base_appoval_type 
        where approval_route_ptr={0} group by data0498rkey,approval_step_no,approval_step_desc,approval_route_ptr";

            DBHelper dbhelper = new DBHelper(FID);
            DataTable dt = dbhelper.GetDataSet(string.Format(sql_d498, APPROVAL_ROUTE_PTR));
            return int.Parse(dt.Rows.Count.ToString());
        }
        #endregion

        #region 公共成员
        #region 创建/发启一个审批流        StartApprovalFlow
        /// <summary>
        /// 创建/发启一个审批流,审批流程改变
        /// </summary>
        /// <param name="FID">厂别</param>
        /// <param name="FILE_POINTER">外键指针</param>
        /// <param name="SOURCE_TYPE">类型</param>
        /// <param name="APPROVAL_ROUTE_PTR">流程指针</param>
        /// <param name="IsSend">true发启，false不发启</param>
        /// <param name="note">审批备注</param>
        /// <param name="UserAd">域帐户(yangwm)</param>
        public static void StartApprovalFlow(int FID, int FILE_POINTER, int SOURCE_TYPE, int APPROVAL_ROUTE_PTR, bool IsSend, string note,string UserAd)
        {
            DBHelper dbhelper = new DBHelper(FID);
            Approval_Mode_1BLL bll1 = new Approval_Mode_1BLL(FID);
            Approval_Mode_2BLL bll2 = new Approval_Mode_2BLL(FID);
            Approval_Mode_3BLL bll3 = new Approval_Mode_3BLL(FID);
            Approval_Mode_4BLL bll4 = new Approval_Mode_4BLL(FID);
            Approval_Mode_NoteBLL notebll = new Approval_Mode_NoteBLL(FID);
            DATA0498BLL d498bll = new DATA0498BLL(FID);
            DATA0499BLL d499bll = new DATA0499BLL(FID);
            Approval_Mode_1Info info1 = new Approval_Mode_1Info();
            Approval_Mode_2Info info2 = new Approval_Mode_2Info();
            Approval_Mode_3Info info3 = new Approval_Mode_3Info();
            Approval_Mode_4Info info4 = new Approval_Mode_4Info();
            IList<DATA0498> d498list = new List<DATA0498>();
            IList<DATA0499> d499list = new List<DATA0499>();
            Approval_Mode_NoteInfo noteinfo = new Approval_Mode_NoteInfo();

            int data0073rkey;
            string sql_data0073 = @"select data0073.rkey from data0073 with(nolock)  
                                   left outer join data0005 with(nolock)  on data0005.rkey=data0073.EMPLOYEE_PTR 
                                   where rtrim(data0005.address_line_1)='KB\";
            sql_data0073 += UserAd + "'";
            object obj = dbhelper.GetSingle(sql_data0073).ToString();
            try
            {
                data0073rkey = int.Parse(obj.ToString());
            }
            catch
            {
                data0073rkey = 0;
            }

            info1.FILE_POINTER = FILE_POINTER;
            info1.SOURCE_TYPE = SOURCE_TYPE;
            info1.FROM_STEP_NO = 0;
            info1.TO_STEP_NO = 0;
            info1.TRANS_TYPE = 1;
            info1.TRANS_DESCRIPTION = "生成";
            info1.TRANS_DATE_TIME = DateTime.Now;
            info1.USER_PTR = data0073rkey;

            info2.FILE_POINTER = FILE_POINTER;
            info2.SOURCE_TYPE = SOURCE_TYPE;
            info2.APPROVAL_ROUTE_PTR = APPROVAL_ROUTE_PTR;
            info2.APPROVAL_STATUS = IsSend ? 1 : 0;
            info2.APPROVAL_STEP_NO = 1;
            info2.TOTAL_STEPS = GetTotalSteps(APPROVAL_ROUTE_PTR,FID);

            d498list = d498bll.FindBySql("APPROVAL_ROUTE_PTR=" + APPROVAL_ROUTE_PTR);

            string delapp4 = @"delete from Approval_Mode_4 where Approval_Mode_4.ROUTE_STEP_PTR in (
select RKEY from Approval_Mode_3 where FILE_POINTER={0} and SOURCE_TYPE={1})";
            string delapp3 = @"delete from Approval_Mode_3 where  FILE_POINTER={0} and SOURCE_TYPE={1}";

            if (note.Length > 0)
            {
                noteinfo.SOURCE_TYPE = 1;
                noteinfo.NOTES = note;
            }


            using (SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID)))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandTimeout = 120;
                    try
                    {
                        IList<Approval_Mode_1Info> app1list = bll1.GetModelList("FILE_POINTER=" + FILE_POINTER
                            + " and SOURCE_TYPE=" + SOURCE_TYPE + " and TRANS_DESCRIPTION = '生成'");
                        if (app1list.Count == 0)
                        {
                            info1.RKEY = bll1.Add(cmd, conn, trans, info1);
                        }
                        if (IsSend)
                        {
                            info2.APPROVAL_STATUS = 1;
                            info2.APPROVAL_STEP_NO= 1;
                            info1.TO_STEP_NO = 1;
                            info1.TRANS_TYPE = 1;
                            info1.TRANS_DESCRIPTION = "提交审批";
                            bll1.Add(cmd, conn, trans, info1);
                        }
                        List<Approval_Mode_2Info> app2list = bll2.GetModelList("FILE_POINTER=" + FILE_POINTER
                            + " and SOURCE_TYPE=" + SOURCE_TYPE);
                        if (app2list.Count > 0)
                        {
                            if (app2list[0].APPROVAL_ROUTE_PTR != APPROVAL_ROUTE_PTR)
                            {
                                //审批流程改变
                                info1.TO_STEP_NO = 1;
                                info1.TRANS_TYPE = 1;
                                info1.TRANS_DESCRIPTION = "审批流程改变";
                                bll1.Add(cmd, conn, trans, info1);
                            }
                            if (IsSend)
                            {
                                app2list[0].APPROVAL_STATUS = 1;
                                app2list[0].APPROVAL_STEP_NO = 1;
                            }
                            app2list[0].APPROVAL_ROUTE_PTR = APPROVAL_ROUTE_PTR;
                            bll2.Update(cmd, conn, trans, app2list[0]);
                        }
                        else
                        {
                            bll2.Add(cmd, conn, trans, info2);
                        }

                        dbhelper.ExecuteSqlTran(cmd, conn, trans, string.Format(delapp4, FILE_POINTER, SOURCE_TYPE));
                        dbhelper.ExecuteSqlTran(cmd, conn, trans, string.Format(delapp3, FILE_POINTER, SOURCE_TYPE));


                        foreach (DATA0498 d498info in d498list)
                        {
                            info3 = new Approval_Mode_3Info();
                            info3.FILE_POINTER = FILE_POINTER;
                            info3.SOURCE_TYPE = SOURCE_TYPE;
                            info3.APPROVAL_STEP_NO = (int)d498info.APPROVAL_STEP_NO;
                            info3.APPROVAL_STEP_DESC = d498info.APPROVAL_STEP_DESC;
                            info3.RKEY = bll3.Add(cmd, conn, trans, info3);

                            d499list = d499bll.FindBySql("APPROVAL_ROUTE_STEP_PTR=" + d498info.RKEY);
                            foreach (DATA0499 d499info in d499list)
                            {
                                info4.ROUTE_STEP_PTR = info3.RKEY;
                                info4.USER_PTR = (int)d499info.USER_PTR;
                                bll4.Add(cmd, conn, trans, info4);
                            }

                        }

                        if (note.Length > 0)
                        {
                            noteinfo.FILE_POINTER = info1.RKEY;
                            notebll.Add(cmd, conn, trans, noteinfo);
                        }
                        trans.Commit();
                    }
                    catch (Exception ee)
                    {
                        trans.Rollback();//异常回滚
                        throw ee;
                    }
                }
            }
        }
        #endregion

        #region 审批通过或至下一步       RunApprovalPass
        /// <summary>
        /// 审批通过或至下一步
        /// </summary>
        /// <param name="FID">厂别</param>
        /// <param name="FILE_POINTER">外键指针</param>
        /// <param name="SOURCE_TYPE">类型</param>
        /// <param name="note">审批备注</param>
        /// <param name="UserAd">域帐户(yangwm)</param>
        public static void RunApprovalPass(int FID, int FILE_POINTER, int SOURCE_TYPE, string note,string UserAd)
        {
            DBHelper dbhelper = new DBHelper(FID);
            Approval_Mode_1BLL bll1 = new Approval_Mode_1BLL(FID);
            Approval_Mode_2BLL bll2 = new Approval_Mode_2BLL(FID);
            Approval_Mode_NoteBLL notebll = new Approval_Mode_NoteBLL(FID);
            Approval_Mode_1Info info1 = new Approval_Mode_1Info();
            Approval_Mode_NoteInfo noteinfo = new Approval_Mode_NoteInfo();
            int data0073rkey;
            string sql_data0073 = @"select data0073.rkey from data0073 with(nolock)  
                                   left outer join data0005 with(nolock)  on data0005.rkey=data0073.EMPLOYEE_PTR 
                                   where rtrim(data0005.address_line_1)='KB\";
            sql_data0073 += UserAd + "'";
            object obj = dbhelper.GetSingle(sql_data0073).ToString();
            try
            {
                data0073rkey = int.Parse(obj.ToString());
            }
            catch
            {
                data0073rkey = 0;
            }

            List<Approval_Mode_2Info> list2 = bll2.GetModelList("FILE_POINTER=" + FILE_POINTER + " and SOURCE_TYPE=" + SOURCE_TYPE);
            if (list2.Count > 0)
            {
                if (list2[0].APPROVAL_STATUS == 1)
                {
                    if (list2[0].APPROVAL_STEP_NO < list2[0].TOTAL_STEPS)
                    {
                        //未到最后一步

                        info1.FILE_POINTER = FILE_POINTER;
                        info1.SOURCE_TYPE = SOURCE_TYPE;
                        info1.FROM_STEP_NO = list2[0].APPROVAL_STEP_NO;
                        info1.TO_STEP_NO = list2[0].APPROVAL_STEP_NO + 1;
                        info1.TRANS_TYPE = 6;
                        info1.USER_PTR = data0073rkey;
                        info1.TRANS_DESCRIPTION = "已审批";
                        info1.TRANS_DATE_TIME = DateTime.Now;
                        list2[0].APPROVAL_STEP_NO = list2[0].APPROVAL_STEP_NO + 1;

                    }
                    else if (list2[0].APPROVAL_STEP_NO == list2[0].TOTAL_STEPS)
                    {
                        //最后一步审批
                        info1.FILE_POINTER = FILE_POINTER;
                        info1.SOURCE_TYPE = SOURCE_TYPE;
                        info1.FROM_STEP_NO = list2[0].APPROVAL_STEP_NO;
                        info1.TO_STEP_NO = list2[0].TOTAL_STEPS;
                        info1.TRANS_TYPE = 6;
                        info1.USER_PTR = data0073rkey;
                        info1.TRANS_DESCRIPTION = "已审批";
                        info1.TRANS_DATE_TIME = DateTime.Now;

                        list2[0].APPROVAL_STATUS = 2;
                        list2[0].APPROVAL_STEP_NO = 0;
                    }

                    if (note.Length > 0)
                    {
                        noteinfo.SOURCE_TYPE = 1;
                        noteinfo.NOTES = note;
                    }

                    using (SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID)))
                    {
                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            SqlCommand cmd = new SqlCommand();
                            cmd.CommandTimeout = 120;
                            try
                            {
                                info1.RKEY = bll1.Add(cmd, conn, trans, info1);
                                bll2.Update(cmd, conn, trans, list2[0]);
                                if (note.Length > 0)
                                {
                                    noteinfo.FILE_POINTER = info1.RKEY;
                                    notebll.Add(cmd, conn, trans, noteinfo);
                                }
                                trans.Commit();
                            }
                            catch (Exception ee)
                            {
                                trans.Rollback();//异常回滚
                                throw ee;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 审批拒绝        RunApprovalRefuse
        /// <summary>
        /// 审批拒绝 RunApprovalRefuse
        /// </summary>
        /// <param name="FID">厂别</param>
        /// <param name="FILE_POINTER">外键指针</param>
        /// <param name="SOURCE_TYPE">类型</param>
        /// <param name="note">备注</param>
        /// <param name="UserAd">域帐户(yangwm)</param>
        public static void RunApprovalRefuse(int FID, int FILE_POINTER, int SOURCE_TYPE, string note, string UserAd)
        {
            DBHelper dbhelper = new DBHelper(FID);
            Approval_Mode_1BLL bll1 = new Approval_Mode_1BLL(FID);
            Approval_Mode_2BLL bll2 = new Approval_Mode_2BLL(FID);
            Approval_Mode_NoteBLL notebll = new Approval_Mode_NoteBLL(FID);
            Approval_Mode_1Info info1 = new Approval_Mode_1Info();
            Approval_Mode_NoteInfo noteinfo = new Approval_Mode_NoteInfo();
            int data0073rkey;
            string sql_data0073 = @"select data0073.rkey from data0073 with(nolock)  
                                   left outer join data0005 with(nolock)  on data0005.rkey=data0073.EMPLOYEE_PTR 
                                   where rtrim(data0005.address_line_1)='KB\";
            sql_data0073 += UserAd + "'";
            object obj = dbhelper.GetSingle(sql_data0073).ToString();
            try
            {
                data0073rkey = int.Parse(obj.ToString());
            }
            catch
            {
                data0073rkey = 0;
            }

            List<Approval_Mode_2Info> list2 = bll2.GetModelList("FILE_POINTER=" + FILE_POINTER + " and SOURCE_TYPE=" + SOURCE_TYPE);
            if (list2.Count > 0)
            {

                info1.FILE_POINTER = FILE_POINTER;
                info1.SOURCE_TYPE = SOURCE_TYPE;
                info1.FROM_STEP_NO = list2[0].APPROVAL_STEP_NO;
                info1.TO_STEP_NO = 0;
                info1.TRANS_TYPE = 7;
                info1.USER_PTR = data0073rkey;
                info1.TRANS_DESCRIPTION = "报废";
                info1.TRANS_DATE_TIME = DateTime.Now;
                list2[0].APPROVAL_STATUS = 3;
                list2[0].APPROVAL_STEP_NO = 0;

                if (note.Length > 0)
                {
                    noteinfo.SOURCE_TYPE = 1;
                    noteinfo.NOTES = note;
                }

                using (SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID)))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 120;
                        try
                        {
                            info1.RKEY = bll1.Add(cmd, conn, trans, info1);
                            bll2.Update(cmd, conn, trans, list2[0]);
                            if (note.Length > 0)
                            {
                                noteinfo.FILE_POINTER = info1.RKEY;
                                notebll.Add(cmd, conn, trans, noteinfo);
                            }
                            trans.Commit();
                        }
                        catch (Exception ee)
                        {
                            trans.Rollback();//异常回滚
                            throw ee;
                        }
                    }
                }

            }
        }
        #endregion

        #region 返回审批记录 GetDataTableApprovalLog
        /// <summary>
        /// 返回审批记录
        /// </summary>
        /// <param name="FID">厂别</param>
        /// <param name="FILE_POINTER">指针</param>
        /// <param name="SOURCE_TYPE">类别ID</param>
        /// <returns></returns>
        public static DataTable GetDataTableApprovalLog(int FID, int FILE_POINTER, int SOURCE_TYPE)
        {
            string sql = @"SELECT  Approval_Mode_1.RKEY, 
                        Approval_Mode_1.FILE_POINTER, 
                        Approval_Mode_1.FROM_STEP_NO, 
                        DATA0073.USER_FULL_NAME,   
                        Approval_Mode_Note.NOTES,
                         Approval_Mode_1.TRANS_DATE_TIME      
                        FROM  Approval_Mode_1
                         INNER JOIN DATA0073 ON Approval_Mode_1.USER_PTR = DATA0073.RKEY 
                         INNER JOIN Approval_Mode_Note ON Approval_Mode_1.RKEY = Approval_Mode_Note.FILE_POINTER
                        AND Approval_Mode_Note.SOURCE_TYPE = 1
                        WHERE Approval_Mode_1.FILE_POINTER={0} and Approval_Mode_1.SOURCE_TYPE={1}";
            DataTable dt = new DataTable();
            DBHelper dbhelper = new DBHelper(FID);
            dt = dbhelper.GetDataSet(string.Format(sql, FILE_POINTER, SOURCE_TYPE));
            return dt;
        }
        #endregion

        #region 邮件提醒，通知下一步审批人员 SendMail
        /// <summary>
        /// 邮件提醒，通知下一步审批人员
        /// </summary>
        /// <param name="FID">厂别</param>
        /// <param name="FILE_POINTER">指针</param>
        /// <param name="SOURCE_TYPE">类别ID</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="appUrl">超链接地址</param>
        public static void SendMail(int FID, int FILE_POINTER, int SOURCE_TYPE, string subject, string body, string appUrl)
        {
            DBHelper dbhelper = new DBHelper(FID);
            KB.FUNC.Func fun = new Func();

            DataTable dt = GetDataTableApprovalList(FID, FILE_POINTER, SOURCE_TYPE);
            body += "<br />";
            body += "链接地址：<a href='" + appUrl + "' >" + appUrl + "</a>";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string recipient = "";
                    string userID = dr["userAD"].ToString().Replace(@"KB\", "");
                    if (!string.IsNullOrEmpty(userID))
                    {
                        AD ad = new AD();
                      List<ADUserInfo>  UserInfo= ad.getADUserInfo(userID);
                      try
                      {
                          recipient = UserInfo[0].Mail;
                          fun.SendDbMail("DBA SQL", recipient, subject, body, "HTML");
                      }
                      catch (Exception e1)
                      {
                          throw e1;
                      }                        
                    }
                }
            }
        }        
        #endregion

        #region 返回待审批列表      GetDataTableApprovalList
        /// <summary>
        /// 返回待审批列表
        /// </summary>
        /// <param name="FID">厂别</param>
        /// <param name="FILE_POINTER">指针</param>
        /// <param name="SOURCE_TYPE">类别ID</param>
        /// <returns></returns>
        public static DataTable GetDataTableApprovalList(int FID, int FILE_POINTER, int SOURCE_TYPE)
        {
            string sql = @"select distinct
                          Approval_Mode_2.*,
                          Approval_Mode_4.USER_PTR,
                          data0005.address_line_1 as userAD  
                          from 
                          Approval_Mode_2 with(nolock)
                          left join Approval_Mode_3 with(nolock) 
                            on Approval_Mode_2.FILE_POINTER=Approval_Mode_3.FILE_POINTER
                               and Approval_Mode_2.SOURCE_TYPE=Approval_Mode_3.SOURCE_TYPE
                          left join Approval_Mode_4 with(nolock) on Approval_Mode_3.rkey=Approval_Mode_4.ROUTE_STEP_PTR
                          left join data0073 with(nolock) on Approval_Mode_4.USER_PTR=data0073.rkey
                          inner join data0005 with(nolock) on data0073.employee_ptr=data0005.rkey  
                          where Approval_Mode_2.APPROVAL_STEP_NO=Approval_Mode_3.APPROVAL_STEP_NO
                           and Approval_Mode_2.APPROVAL_STATUS=1 {0}";
            
            DataTable dt = new DataTable();
            DBHelper dbhelper = new DBHelper(FID);
            dt = dbhelper.GetDataSet(string.Format(sql," and Approval_Mode_2.FILE_POINTER=" 
                + FILE_POINTER + " and Approval_Mode_2.SOURCE_TYPE=" + SOURCE_TYPE));
            return dt;
        }
        #endregion

        #region 判断当前是否是某用户审批 ChkNowStepHasApproval
        /// <summary>
        /// 判断当前是否是某用户审批
        /// </summary>
        /// <param name="FID">厂别</param>
        /// <param name="FILE_POINTER">指针</param>
        /// <param name="SOURCE_TYPE">类别ID</param>
        /// <param name="UserAd">域帐户</param>
        /// <returns></returns>
        public static bool ChkNowStepHasApproval(int FID, int FILE_POINTER, int SOURCE_TYPE, string UserAd)
        {
            bool b = false;
            string sql = @"select distinct
                          Approval_Mode_2.*,
                          Approval_Mode_4.USER_PTR,
                          data0005.address_line_1 as userAD  
                          from 
                          Approval_Mode_2 with(nolock)
                          left join Approval_Mode_3 with(nolock) 
                            on Approval_Mode_2.FILE_POINTER=Approval_Mode_3.FILE_POINTER
                               and Approval_Mode_2.SOURCE_TYPE=Approval_Mode_3.SOURCE_TYPE
                          left join Approval_Mode_4 with(nolock) on Approval_Mode_3.rkey=Approval_Mode_4.ROUTE_STEP_PTR
                          left join data0073 with(nolock) on Approval_Mode_4.USER_PTR=data0073.rkey
                          inner join data0005 with(nolock) on data0073.employee_ptr=data0005.rkey  
                          where Approval_Mode_2.APPROVAL_STEP_NO=Approval_Mode_3.APPROVAL_STEP_NO
                           and Approval_Mode_2.APPROVAL_STATUS=1 {0}";

            DataTable dt = new DataTable();
            DBHelper dbhelper = new DBHelper(FID);
            dt = dbhelper.GetDataSet(string.Format(sql, 
                " and Approval_Mode_2.FILE_POINTER=" + FILE_POINTER + " and Approval_Mode_2.SOURCE_TYPE=" 
                + SOURCE_TYPE + "and data0005.address_line_1='KB\\" + UserAd + "'"));            
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        #endregion

        #region 撤销申请/召回
        /// <summary>
        /// 撤销申请        RunApprovalCancel
        /// </summary>
        /// <param name="FID">厂别</param>
        /// <param name="FILE_POINTER">外键指针</param>
        /// <param name="SOURCE_TYPE">类型</param>
        /// <param name="note">备注</param>
        /// <param name="UserAd">域帐户(yangwm)</param>
        public static void RunApprovalCancel(int FID, int FILE_POINTER, int SOURCE_TYPE, string UserAd)
        {
            DBHelper dbhelper = new DBHelper(FID);
            Approval_Mode_2BLL bll2 = new Approval_Mode_2BLL(FID);
            List<Approval_Mode_2Info> list2 = new List<Approval_Mode_2Info>();
            int data0073rkey;
            string sql_data0073 = @"select data0073.rkey from data0073 with(nolock)  
                                   left outer join data0005 with(nolock)  on data0005.rkey=data0073.EMPLOYEE_PTR 
                                   where rtrim(data0005.address_line_1)='KB\";
            sql_data0073 += UserAd + "'";
            object obj = dbhelper.GetSingle(sql_data0073).ToString();
            try
            {
                data0073rkey = int.Parse(obj.ToString());
            }
            catch
            {
                data0073rkey = 0;
            }
            
            list2 = bll2.GetModelList("FILE_POINTER=" + FILE_POINTER + " AND SOURCE_TYPE=" + SOURCE_TYPE);
            if (list2.Count > 0)
            {
                list2[0].APPROVAL_STATUS = 0;

                using (SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID)))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 120;
                        try
                        {
                            bll2.Update(cmd, conn, trans, list2[0]);
                            trans.Commit();
                        }
                        catch (Exception ee)
                        {
                            trans.Rollback();//异常回滚
                            throw ee;
                        }
                    }
                }

            }
        }
        #endregion
        #endregion
    }
}
