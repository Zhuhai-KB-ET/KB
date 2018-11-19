using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace KB.FUNC
{
    #region ADUserInfo 用户属性  [objectClass=user                 查询条件是所有的用户（USER）]
    public class ADUserInfo
    {
        #region 国家 co
        private string co;
        /// <summary>
        /// 国家
        /// </summary>
        public string Co
        {
            get { return co; }
            set { co = value; }
        }
        #endregion

        #region 省 st
        private string st;
        /// <summary>
        /// 省
        /// </summary>
        public string St
        {
            get { return st; }
            set { st = value; }
        }
        #endregion

        #region 市 l
        private string l;
        /// <summary>
        /// 市
        /// </summary>
        public string L
        {
            get { return l; }
            set { l = value; }
        }
        #endregion

        #region 公司 company
        private string company;
        /// <summary>
        /// 公司
        /// </summary>
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
        #endregion

        #region 部门 departMent
        private string departMent;
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartMent
        {
            get { return departMent; }
            set { departMent = value; }
        }
        #endregion

        #region 办公室 physicaldeliveryofficename
        private string physicaldeliveryofficename;
        /// <summary>
        /// 办公室
        /// </summary>
        public string Physicaldeliveryofficename
        {
            get { return physicaldeliveryofficename; }
            set { physicaldeliveryofficename = value; }
        }
        #endregion

        #region 地址 streetaddress
        private string streetaddress;
        /// <summary>
        /// 地址
        /// </summary>
        public string Streetaddress
        {
            get { return streetaddress; }
            set { streetaddress = value; }
        }
        #endregion

        #region 邮编 postalcode
        private string postalcode;
        /// <summary>
        /// 邮编
        /// </summary>
        public string Postalcode
        {
            get { return postalcode; }
            set { postalcode = value; }
        }
        #endregion

        #region 中文名 cn
        private string cn;
        /// <summary>
        /// 用户名称
        /// </summary>
        public string Cn
        {
            get { return cn; }
            set { cn = value; }
        }
        #endregion

        #region 显示名 displayname
        private string displayname;
        /// <summary>
        /// 显示名
        /// </summary>
        public string Displayname
        {
            get { return displayname; }
            set { displayname = value; }
        }
        #endregion

        #region 别名 sAMAccountName
        private string sAMAccountName;
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string SAMAccountName
        {
            get { return sAMAccountName; }
            set { sAMAccountName = value; }
        }
        #endregion

        #region 姓 sn
        private string sn;
        /// <summary>
        /// 姓
        /// </summary>
        public string Sn
        {
            get { return sn; }
            set { sn = value; }
        }
        #endregion

        #region 名 givenname
        private string givenname;
        /// <summary>
        /// 名
        /// </summary>
        public string Givenname
        {
            get { return givenname; }
            set { givenname = value; }
        }
        #endregion

        #region 职务 title
        private string title;
        /// <summary>
        /// 职务
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        #endregion

        #region 邮箱 mail
        private string mail;
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        #endregion

        #region 电话 telephoneNumber
        private string telephoneNumber;
        /// <summary>
        /// 办公电话
        /// </summary>
        public string TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }
        #endregion

        #region 手机 Mobile
        private string mobile;
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        #endregion

        #region 传真 facsimiletelephonenumber
        private string facsimiletelephonenumber;
        /// <summary>
        /// 传真
        /// </summary>
        public string Facsimiletelephonenumber
        {
            get { return facsimiletelephonenumber; }
            set { facsimiletelephonenumber = value; }
        }
        #endregion

        #region 单元的结构 distinguishedname
        private string distinguishedname;
        /// <summary>
        /// 单元的结构
        ///   例：
        ///     "OU=富山分公司,OU=PCB事业部,DC=KB,DC=com"
        ///     "OU=销售管理,OU=发展公司,OU=PCB事业部,DC=KB,DC=com"
        /// </summary>
        public string Distinguishedname
        {
            get { return distinguishedname; }
            set { distinguishedname = value; }
        }
        #endregion
    }
    #endregion

    #region ADGroupInfo 群组属性 [objectClass=group                查询条件是所有的用户（GROUP）]
    public class ADGroupInfo
    {
        #region 显示名 displayname
        private string displayname;
        /// <summary>
        /// 显示名
        /// </summary>
        public string Displayname
        {
            get { return displayname; }
            set { displayname = value; }
        }
        #endregion

        #region 别名 mailnickname
        private string mailnickname;
        /// <summary>
        /// 别名
        /// </summary>
        public string Mailnickname
        {
            get { return mailnickname; }
            set { mailnickname = value; }
        }
        #endregion

        #region 电子邮件地址（服务器类） proxyaddresses
        private string[] proxyaddresses;
        /// <summary>
        /// 电子邮件地址（服务器类）
        /// </summary>
        public string[] Proxyaddresses
        {
            get { return proxyaddresses; }
            set { proxyaddresses = value; }
        }
        #endregion

        #region 成员属于 memberof
        private string memberof;
        /// <summary>
        /// 成员属于
        /// </summary>
        public string Memberof
        {
            get { return memberof; }
            set { memberof = value; }
        }
        #endregion

        #region 邮箱 mail
        private string mail;
        /// <summary>
        /// 成员属于
        /// </summary>
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }
        #endregion

        #region 成员 member
        private string[] member;
        /// <summary>
        /// 成员
        /// </summary>
        public string[] Member
        {
            get { return member; }
            set { member = value; }
        }
        #endregion

        #region 成员名单 member_User
        private List<ADUserInfo> member_User;
        /// <summary>
        /// 成员
        /// </summary>
        public List<ADUserInfo> Member_User
        {
            get { return member_User; }
            set { member_User = value; }
        }
        #endregion
    }
    #endregion

    #region ADUnitInfo 组织单元  [objectClass=organizationalUnit   查询条件是组织单元（UNIT）]
    public class ADUnitInfo
    {
        #region 单元的主名 name
        private string name;
        /// <summary>
        /// 单元的
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion

        #region 单元的结构 distinguishedname
        private string distinguishedname;
        /// <summary>
        /// 单元的结构
        ///   例：
        ///     "OU=富山分公司,OU=PCB事业部,DC=KB,DC=com"
        ///     "OU=销售管理,OU=发展公司,OU=PCB事业部,DC=KB,DC=com"
        /// </summary>
        public string Distinguishedname
        {
            get { return distinguishedname; }
            set { distinguishedname = value; }
        }
        #endregion

        #region 单元的英文结构 objectcategory
        private string objectcategory;
        /// <summary>
        /// 单元的英文结构
        /// </summary>
        public string Objectcategory
        {
            get { return objectcategory; }
            set { objectcategory = value; }
        }
        #endregion

        #region 单元的创建时间 whencreated
        private DateTime whencreated;
        /// <summary>
        /// 单元的创建时间
        /// </summary>
        public DateTime Whencreated
        {
            get { return whencreated; }
            set { whencreated = value; }
        }
        #endregion

        #region 单元的修改时间 whenchanged
        private DateTime whenchanged;
        /// <summary>
        /// 单元的修改时间
        /// </summary>
        public DateTime Whenchanged
        {
            get { return whenchanged; }
            set { whenchanged = value; }
        }
        #endregion

        #region 本级用户 NextUnit
        private List<ADUserInfo> aDUserInfo;
        /// <summary>
        /// 本级用户
        /// </summary>
        public List<ADUserInfo> ADUserInfo
        {
            get { return aDUserInfo; }
            set { aDUserInfo = value; }
        }
        #endregion

        #region 下级名单 NextUnit
        private List<ADUnitInfo> nextunit;
        /// <summary>
        /// 成员
        /// </summary>
        public List<ADUnitInfo> NextUnit
        {
            get { return nextunit; }
            set { nextunit = value; }
        }
        #endregion
    }
    #endregion

    /// <summary>
    /// AD帐号验证
    /// </summary>
    public class AD
    {
        #region 帐号
        private string path = "LDAP://KB.com/DC=KB,DC=com";
        private string Userid = "k2service";
        private string Password = "bianli";
        #endregion 

        #region 验证域帐号 IsAuthenticated
        /// <summary>
        /// 验证域帐号
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>真为验证通过</returns>
        public bool IsAuthenticated(string username, string pwd)
        {

            bool tag = false;
            try
            {
                string domain = "KB";
                string domainAndUsername = domain + @"\" + username;
                DirectoryEntry entry = new DirectoryEntry("LDAP://KB.com/DC=KB,DC=com",domainAndUsername, pwd);
                // 连接到 AdsObject以强制进行验证
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return tag;
                }
                //获取信息 
                tag = true;
                entry.Close();
            }
            catch (Exception ex)
            {
                //throw new Exception("验证帐号和密码时发生错误。" + ex.Message);
                System.Console.Write(ex.Message); 
            }
            return tag;
        }
        #endregion

        #region getADUserInfo
        /// <summary>
        /// 使用名称或邮箱查询
        /// </summary> 
        /// <param name="find"> 姓名或邮箱 </param> 
        /// <returns>用户帐号列表集合</returns>
        public List<ADUserInfo> getADUserInfo(string find)
        {
            DirectoryEntry de = new DirectoryEntry(path, Userid, Password);
            DirectorySearcher ds = new DirectorySearcher(de);

            ds.Filter = "(&(objectClass=user)(|(Cn=" + find.Trim() + ")(Mail=" + find.Trim() + "@pcbmail.KB.com)(SAMAccountName=" + find.Trim() + ")))";
            List<ADUserInfo> ls_ADUserInfo = new List<ADUserInfo>();

            try
            {
                foreach (System.DirectoryServices.SearchResult resEnt in ds.FindAll())
                {
                    DirectoryEntry user = resEnt.GetDirectoryEntry();
                    if (user.Properties["Cn"].Value.ToString() != "")
                    {
                        ADUserInfo aduser = new ADUserInfo();
                        aduser.Co = user.Properties["Co"].Value != null ? user.Properties["Co"].Value.ToString() : "";
                        aduser.St = user.Properties["St"].Value != null ? user.Properties["St"].Value.ToString() : "";
                        aduser.L = user.Properties["L"].Value != null ? user.Properties["L"].Value.ToString() : "";
                        aduser.Company = user.Properties["Company"].Value != null ? user.Properties["Company"].Value.ToString() : "";
                        aduser.DepartMent = user.Properties["DepartMent"].Value != null ? user.Properties["DepartMent"].Value.ToString() : "";
                        aduser.Physicaldeliveryofficename = user.Properties["Physicaldeliveryofficename"].Value != null ? user.Properties["Physicaldeliveryofficename"].Value.ToString() : "";
                        aduser.Streetaddress = user.Properties["Streetaddress"].Value != null ? user.Properties["Streetaddress"].Value.ToString() : "";
                        aduser.Postalcode = user.Properties["Postalcode"].Value != null ? user.Properties["Postalcode"].Value.ToString() : "";

                        aduser.Cn = user.Properties["Cn"].Value != null ? user.Properties["Cn"].Value.ToString() : "";
                        aduser.Displayname = user.Properties["Displayname"].Value != null ? user.Properties["Displayname"].Value.ToString() : "";
                        aduser.SAMAccountName = user.Properties["SAMAccountName"].Value != null ? user.Properties["SAMAccountName"].Value.ToString() : "";
                        aduser.Sn = user.Properties["Sn"].Value != null ? user.Properties["Sn"].Value.ToString() : "";
                        aduser.Givenname = user.Properties["Givenname"].Value != null ? user.Properties["Givenname"].Value.ToString() : "";
                        aduser.Title = user.Properties["Title"].Value != null ? user.Properties["Title"].Value.ToString() : "";
                        aduser.Mail = user.Properties["Mail"].Value != null ? user.Properties["Mail"].Value.ToString() : "";
                        aduser.TelephoneNumber = user.Properties["TelephoneNumber"].Value != null ? user.Properties["TelephoneNumber"].Value.ToString() : "";
                        aduser.Mobile = user.Properties["Mobile"].Value != null ? user.Properties["Mobile"].Value.ToString() : "";
                        aduser.Facsimiletelephonenumber = user.Properties["Facsimiletelephonenumber"].Value != null ? user.Properties["Facsimiletelephonenumber"].Value.ToString() : "";

                        aduser.Distinguishedname = user.Properties["Distinguishedname"].Value != null ? user.Properties["Distinguishedname"].Value.ToString() : "";

                        ls_ADUserInfo.Add(aduser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
                de.Dispose();
            }
            return ls_ADUserInfo;
        }
        public List<ADUserInfo> getADUserInfo2(string find)
        {
            DirectoryEntry de = new DirectoryEntry(path, Userid, Password);
            DirectorySearcher ds = new DirectorySearcher(de);

            ds.Filter = "(&(objectClass=user)(|(SAMAccountName=" + find.Trim() + ")))";
            List<ADUserInfo> ls_ADUserInfo = new List<ADUserInfo>();

            try
            {
                foreach (System.DirectoryServices.SearchResult resEnt in ds.FindAll())
                {
                    DirectoryEntry user = resEnt.GetDirectoryEntry();
                    if (user.Properties["Cn"].Value.ToString() != "")
                    {
                        ADUserInfo aduser = new ADUserInfo();
                        aduser.Co = user.Properties["Co"].Value != null ? user.Properties["Co"].Value.ToString() : "";
                        aduser.St = user.Properties["St"].Value != null ? user.Properties["St"].Value.ToString() : "";
                        aduser.L = user.Properties["L"].Value != null ? user.Properties["L"].Value.ToString() : "";
                        aduser.Company = user.Properties["Company"].Value != null ? user.Properties["Company"].Value.ToString() : "";
                        aduser.DepartMent = user.Properties["DepartMent"].Value != null ? user.Properties["DepartMent"].Value.ToString() : "";
                        aduser.Physicaldeliveryofficename = user.Properties["Physicaldeliveryofficename"].Value != null ? user.Properties["Physicaldeliveryofficename"].Value.ToString() : "";
                        aduser.Streetaddress = user.Properties["Streetaddress"].Value != null ? user.Properties["Streetaddress"].Value.ToString() : "";
                        aduser.Postalcode = user.Properties["Postalcode"].Value != null ? user.Properties["Postalcode"].Value.ToString() : "";

                        aduser.Cn = user.Properties["Cn"].Value != null ? user.Properties["Cn"].Value.ToString() : "";
                        aduser.Displayname = user.Properties["Displayname"].Value != null ? user.Properties["Displayname"].Value.ToString() : "";
                        aduser.SAMAccountName = user.Properties["SAMAccountName"].Value != null ? user.Properties["SAMAccountName"].Value.ToString() : "";
                        aduser.Sn = user.Properties["Sn"].Value != null ? user.Properties["Sn"].Value.ToString() : "";
                        aduser.Givenname = user.Properties["Givenname"].Value != null ? user.Properties["Givenname"].Value.ToString() : "";
                        aduser.Title = user.Properties["Title"].Value != null ? user.Properties["Title"].Value.ToString() : "";
                        aduser.Mail = user.Properties["Mail"].Value != null ? user.Properties["Mail"].Value.ToString() : "";
                        aduser.TelephoneNumber = user.Properties["TelephoneNumber"].Value != null ? user.Properties["TelephoneNumber"].Value.ToString() : "";
                        aduser.Mobile = user.Properties["Mobile"].Value != null ? user.Properties["Mobile"].Value.ToString() : "";
                        aduser.Facsimiletelephonenumber = user.Properties["Facsimiletelephonenumber"].Value != null ? user.Properties["Facsimiletelephonenumber"].Value.ToString() : "";

                        aduser.Distinguishedname = user.Properties["Distinguishedname"].Value != null ? user.Properties["Distinguishedname"].Value.ToString() : "";

                        ls_ADUserInfo.Add(aduser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
                de.Dispose();
            }
            return ls_ADUserInfo;
        }

        /// <summary>
        /// 使用详细信息查询
        /// </summary>
        /// <param name="find"></param>
        /// <returns></returns>
        public List<ADUserInfo> getADUserInfo_Distinguishedname(string find)
        {
            DirectoryEntry de = new DirectoryEntry(path, Userid, Password);
            DirectorySearcher ds = new DirectorySearcher(de);

            ds.Filter = "(&(objectClass=user)(Distinguishedname=" + find.Trim() + "))";
            List<ADUserInfo> ls_ADUserInfo = new List<ADUserInfo>();

            try
            {
                foreach (System.DirectoryServices.SearchResult resEnt in ds.FindAll())
                {
                    DirectoryEntry user = resEnt.GetDirectoryEntry();
                    if (user.Properties["Cn"].Value.ToString() != "")
                    {
                        ADUserInfo aduser = new ADUserInfo();
                        aduser.Co = user.Properties["Co"].Value != null ? user.Properties["Co"].Value.ToString() : "";
                        aduser.St = user.Properties["St"].Value != null ? user.Properties["St"].Value.ToString() : "";
                        aduser.L = user.Properties["L"].Value != null ? user.Properties["L"].Value.ToString() : "";
                        aduser.Company = user.Properties["Company"].Value != null ? user.Properties["Company"].Value.ToString() : "";
                        aduser.DepartMent = user.Properties["DepartMent"].Value != null ? user.Properties["DepartMent"].Value.ToString() : "";
                        aduser.Physicaldeliveryofficename = user.Properties["Physicaldeliveryofficename"].Value != null ? user.Properties["Physicaldeliveryofficename"].Value.ToString() : "";
                        aduser.Streetaddress = user.Properties["Streetaddress"].Value != null ? user.Properties["Streetaddress"].Value.ToString() : "";
                        aduser.Postalcode = user.Properties["Postalcode"].Value != null ? user.Properties["Postalcode"].Value.ToString() : "";

                        aduser.Cn = user.Properties["Cn"].Value != null ? user.Properties["Cn"].Value.ToString() : "";
                        aduser.Displayname = user.Properties["Displayname"].Value != null ? user.Properties["Displayname"].Value.ToString() : "";
                        aduser.SAMAccountName = user.Properties["SAMAccountName"].Value != null ? user.Properties["SAMAccountName"].Value.ToString() : "";
                        aduser.Sn = user.Properties["Sn"].Value != null ? user.Properties["Sn"].Value.ToString() : "";
                        aduser.Givenname = user.Properties["Givenname"].Value != null ? user.Properties["Givenname"].Value.ToString() : "";
                        aduser.Title = user.Properties["Title"].Value != null ? user.Properties["Title"].Value.ToString() : "";
                        aduser.Mail = user.Properties["Mail"].Value != null ? user.Properties["Mail"].Value.ToString() : "";
                        aduser.TelephoneNumber = user.Properties["TelephoneNumber"].Value != null ? user.Properties["TelephoneNumber"].Value.ToString() : "";
                        aduser.Mobile = user.Properties["Mobile"].Value != null ? user.Properties["Mobile"].Value.ToString() : "";
                        aduser.Facsimiletelephonenumber = user.Properties["Facsimiletelephonenumber"].Value != null ? user.Properties["Facsimiletelephonenumber"].Value.ToString() : "";

                        aduser.Distinguishedname = user.Properties["Distinguishedname"].Value != null ? user.Properties["Distinguishedname"].Value.ToString() : "";

                        ls_ADUserInfo.Add(aduser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
                de.Dispose();
            }
            return ls_ADUserInfo;
        }
        #endregion

        #region getADUserInfo_Unit
        /// <summary>
        /// 获取用户帐号列表
        /// </summary> 
        /// <param name="find"> 部门 </param> 
        /// <returns>用户帐号列表集合</returns>
        public List<ADUserInfo> getADUserInfo_Unit(string find)
        {
            DirectoryEntry de = new DirectoryEntry(path, Userid, Password);
            DirectorySearcher ds = new DirectorySearcher(de);

            ds.Filter = "(&(objectClass=user))";
            List<ADUserInfo> ls_ADUserInfo = new List<ADUserInfo>();

            try
            {
                foreach (System.DirectoryServices.SearchResult resEnt in ds.FindAll())
                {
                    DirectoryEntry user = resEnt.GetDirectoryEntry();
                    if (user.Properties["Distinguishedname"].Value.ToString().IndexOf(find.Trim()) >= 0)
                    {
                        ADUserInfo aduser = new ADUserInfo();
                        aduser.Co = user.Properties["Co"].Value != null ? user.Properties["Co"].Value.ToString() : "";
                        aduser.St = user.Properties["St"].Value != null ? user.Properties["St"].Value.ToString() : "";
                        aduser.L = user.Properties["L"].Value != null ? user.Properties["L"].Value.ToString() : "";
                        aduser.Company = user.Properties["Company"].Value != null ? user.Properties["Company"].Value.ToString() : "";
                        aduser.DepartMent = user.Properties["DepartMent"].Value != null ? user.Properties["DepartMent"].Value.ToString() : "";
                        aduser.Physicaldeliveryofficename = user.Properties["Physicaldeliveryofficename"].Value != null ? user.Properties["Physicaldeliveryofficename"].Value.ToString() : "";
                        aduser.Streetaddress = user.Properties["Streetaddress"].Value != null ? user.Properties["Streetaddress"].Value.ToString() : "";
                        aduser.Postalcode = user.Properties["Postalcode"].Value != null ? user.Properties["Postalcode"].Value.ToString() : "";

                        aduser.Cn = user.Properties["Cn"].Value != null ? user.Properties["Cn"].Value.ToString() : "";
                        aduser.Displayname = user.Properties["Displayname"].Value != null ? user.Properties["Displayname"].Value.ToString() : "";
                        aduser.SAMAccountName = user.Properties["SAMAccountName"].Value != null ? user.Properties["SAMAccountName"].Value.ToString() : "";
                        aduser.Sn = user.Properties["Sn"].Value != null ? user.Properties["Sn"].Value.ToString() : "";
                        aduser.Givenname = user.Properties["Givenname"].Value != null ? user.Properties["Givenname"].Value.ToString() : "";
                        aduser.Title = user.Properties["Title"].Value != null ? user.Properties["Title"].Value.ToString() : "";
                        aduser.Mail = user.Properties["Mail"].Value != null ? user.Properties["Mail"].Value.ToString() : "";
                        aduser.TelephoneNumber = user.Properties["TelephoneNumber"].Value != null ? user.Properties["TelephoneNumber"].Value.ToString() : "";
                        aduser.Mobile = user.Properties["Mobile"].Value != null ? user.Properties["Mobile"].Value.ToString() : "";
                        aduser.Facsimiletelephonenumber = user.Properties["Facsimiletelephonenumber"].Value != null ? user.Properties["Facsimiletelephonenumber"].Value.ToString() : "";

                        aduser.Distinguishedname = user.Properties["Distinguishedname"].Value != null ? user.Properties["Distinguishedname"].Value.ToString() : "";

                        ls_ADUserInfo.Add(aduser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
                de.Dispose();
            }
            return ls_ADUserInfo;
        }
        #endregion

        #region getADGroupInfo
        /// <summary>
        /// 获取群组列表
        /// </summary> 
        /// <param name="find"> 值 </param> 
        /// <returns>群组用户帐号列表集合</returns>
        public List<ADGroupInfo> getADGroupInfo(string find)
        {
            DirectoryEntry de = new DirectoryEntry(path, Userid, Password);
            DirectorySearcher ds = new DirectorySearcher(de);

            ds.Filter = "(&(objectClass=group)(Displayname=" + find.Trim() + "))";

            List<ADGroupInfo> ls_ADGroupInfo = new List<ADGroupInfo>();
            List<ADUserInfo> ls_ADUserInfo = new List<ADUserInfo>();
            try
            {
                foreach (System.DirectoryServices.SearchResult resEnt in ds.FindAll())
                {
                    DirectoryEntry user = resEnt.GetDirectoryEntry();
                    if (user.Properties["Displayname"].Value.ToString() != "")
                    {
                        ADGroupInfo aduser = new ADGroupInfo();
                        aduser.Displayname = user.Properties["Displayname"].Value != null ? user.Properties["Displayname"].Value.ToString() : "";
                        aduser.Mailnickname = user.Properties["Mailnickname"].Value != null ? user.Properties["Mailnickname"].Value.ToString() : "";

                        if (user.Properties["Proxyaddresses"].Count > 0)
                        {
                            aduser.Proxyaddresses = new string[user.Properties["Proxyaddresses"].Count];
                            user.Properties["Proxyaddresses"].CopyTo(aduser.Proxyaddresses, 0);
                        }
                        else
                            aduser.Proxyaddresses = null;

                        aduser.Memberof = user.Properties["Memberof"].Value != null ? user.Properties["Memberof"].Value.ToString() : "";
                        aduser.Mail = user.Properties["Mail"].Value != null ? user.Properties["Mail"].Value.ToString() : "";

                        aduser.Member_User = new List<ADUserInfo>();
                        if (user.Properties["Member"].Count > 0)
                        {
                            aduser.Member = new string[user.Properties["Member"].Count];
                            user.Properties["Member"].CopyTo(aduser.Member, 0);

                            for (int i = 0; i < aduser.Member.Length; i++)
                            {
                                ls_ADUserInfo = getADUserInfo_Distinguishedname(aduser.Member[i].ToString().Trim());
                                if (ls_ADUserInfo.Count > 0)
                                    aduser.Member_User.Add(ls_ADUserInfo[0]);
                                else
                                {
                                    ls_ADUserInfo = getADUserInfo(aduser.Member[i].ToString().Split(',')[0].Substring(3));
                                    if (ls_ADUserInfo.Count > 0) aduser.Member_User.Add(ls_ADUserInfo[0]);
                                }
                            }
                        }
                        else
                            aduser.Member = null;

                        ls_ADGroupInfo.Add(aduser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
                de.Dispose();
            }
            return ls_ADGroupInfo;
        }
        #endregion

        #region getADUnitInfo
        /// <summary>
        /// 获取组织架构列表
        /// </summary> 
        /// <param name="find"> 值 </param> 
        /// <param name="mode"> 参数 </param> 
        /// <returns>组织架构列表集合</returns>
        public List<ADUnitInfo> getADUnitInfo(string find)
        {
            DirectoryEntry de = new DirectoryEntry(path, Userid, Password);
            DirectorySearcher ds = new DirectorySearcher(de);

            ds.Filter = "(&(objectClass=organizationalUnit)(Name=*" + find.Trim() + "*))";

            List<ADUnitInfo> ls_ADUnitInfo = new List<ADUnitInfo>();
            List<ADUnitInfo> ls_ADUnitInfo2 = new List<ADUnitInfo>();
            List<ADUserInfo> ls_ADUserInfo = new List<ADUserInfo>();
            try
            {
                foreach (System.DirectoryServices.SearchResult resEnt in ds.FindAll())
                {
                    DirectoryEntry user = resEnt.GetDirectoryEntry();
                    if (user.Properties["Name"].Value.ToString() != "")
                    {
                        ADUnitInfo aduser = new ADUnitInfo();
                        aduser.Name = user.Properties["Name"].Value != null ? user.Properties["Name"].Value.ToString() : "";
                        aduser.Distinguishedname = user.Properties["Distinguishedname"].Value != null ? user.Properties["Distinguishedname"].Value.ToString() : "";
                        aduser.Objectcategory = user.Properties["Objectcategory"].Value != null ? user.Properties["Objectcategory"].Value.ToString() : "";
                        aduser.Whencreated = DateTime.Parse(user.Properties["Whencreated"].Value.ToString());
                        aduser.Whenchanged = DateTime.Parse(user.Properties["Whenchanged"].Value.ToString());

                        aduser.ADUserInfo = new List<ADUserInfo>();
                        ADUserInfo aduser3 = new ADUserInfo();
                        ls_ADUserInfo = getADUserInfo_Unit(aduser.Distinguishedname.ToString());
                        for (int i = 0; i < ls_ADUserInfo.Count; i++)
                        {
                            aduser3 = ls_ADUserInfo[i];
                            aduser.ADUserInfo.Add(aduser3);
                        }

                        aduser.NextUnit = new List<ADUnitInfo>();
                        ADUnitInfo aduser2 = new ADUnitInfo();
                        ls_ADUnitInfo2 = getADUnitInfo_Next(aduser.Distinguishedname.ToString());
                        for (int i = 0; i < ls_ADUnitInfo2.Count; i++)
                        {
                            aduser2 = ls_ADUnitInfo2[i];
                            aduser.NextUnit.Add(aduser2);
                        }

                        ls_ADUnitInfo.Add(aduser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
                de.Dispose();
            }
            return ls_ADUnitInfo;
        }
        #endregion

        #region getADUnitInfo_Next
        /// <summary>
        /// 获取组织架构列表
        /// </summary> 
        /// <param name="find"> 值 </param> 
        /// <param name="mode"> 参数 </param> 
        /// <returns>组织架构列表集合</returns>
        public List<ADUnitInfo> getADUnitInfo_Next(string find)
        {
            DirectoryEntry de = new DirectoryEntry(path, Userid, Password);
            DirectorySearcher ds = new DirectorySearcher(de);

            ds.Filter = "(objectClass=organizationalUnit)";

            List<ADUnitInfo> ls_ADUnitInfo = new List<ADUnitInfo>();
            List<ADUserInfo> ls_ADUserInfo = new List<ADUserInfo>();

            try
            {
                foreach (System.DirectoryServices.SearchResult resEnt in ds.FindAll())
                {
                    DirectoryEntry user = resEnt.GetDirectoryEntry();
                    if (user.Properties["Distinguishedname"].Value.ToString().IndexOf(find) >= 0)
                    {
                        ADUnitInfo aduser = new ADUnitInfo();
                        aduser.Name = user.Properties["Name"].Value != null ? user.Properties["Name"].Value.ToString() : "";
                        aduser.Distinguishedname = user.Properties["Distinguishedname"].Value != null ? user.Properties["Distinguishedname"].Value.ToString() : "";
                        aduser.Objectcategory = user.Properties["Objectcategory"].Value != null ? user.Properties["Objectcategory"].Value.ToString() : "";
                        aduser.Whencreated = DateTime.Parse(user.Properties["Whencreated"].Value.ToString());
                        aduser.Whenchanged = DateTime.Parse(user.Properties["Whenchanged"].Value.ToString());

                        aduser.ADUserInfo = new List<ADUserInfo>();
                        ADUserInfo aduser3 = new ADUserInfo();
                        ls_ADUserInfo = getADUserInfo_Unit(aduser.Distinguishedname.ToString());
                        for (int i = 0; i < ls_ADUserInfo.Count; i++)
                        {
                            aduser3 = ls_ADUserInfo[i];
                            aduser.ADUserInfo.Add(aduser3);
                        }

                        aduser.NextUnit = new List<ADUnitInfo>();

                        ls_ADUnitInfo.Add(aduser);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
                de.Dispose();
            }
            return ls_ADUnitInfo;
        }
        #endregion
    }
}
