//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2012-3-16 9:21:11
//============================================================

using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using KB.Models;
using KB.DAL;

namespace KB.BLL
{
    /// <summary>
    /// 业务层  FOUNDERPCB_MENU_EXTBLL
    /// </summary>
    public partial class FOUNDERPCB_MENU_EXTBLL
    {
        FOUNDERPCB_MENU_EXTDAL founderpcb_menu_extDal = null;

        #region ----------构造函数----------
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="frm">窗口</param> 
        public FOUNDERPCB_MENU_EXTBLL(Form frm)
        {
            founderpcb_menu_extDal = new FOUNDERPCB_MENU_EXTDAL(frm);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="frm">窗口</param> 
        /// <param name="factoryID">操作厂别</param>
        public FOUNDERPCB_MENU_EXTBLL(Form frm, int factoryID)
        {
            founderpcb_menu_extDal = new FOUNDERPCB_MENU_EXTDAL(frm, factoryID);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Thread">数据库连接指针，0是保留，最大99</param>
        /// <param name="factoryID">操作厂别</param>
        public FOUNDERPCB_MENU_EXTBLL(int Thread, int factoryID)
        {
            founderpcb_menu_extDal = new FOUNDERPCB_MENU_EXTDAL(Thread, factoryID);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
        public FOUNDERPCB_MENU_EXTBLL(int Thread)
        {
            founderpcb_menu_extDal = new FOUNDERPCB_MENU_EXTDAL(Thread);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="DB">DBHelper的实例</param> 
        public FOUNDERPCB_MENU_EXTBLL(DBHelper DB)
        {
            founderpcb_menu_extDal = new FOUNDERPCB_MENU_EXTDAL(DB);
        }
        #endregion

        #region ----------函数定义----------

        #region 添加更新删除

        #region 添加
        /// <summary>
        /// 向数据库中插入一条新记录。
        /// </summary>
        /// <param name="FOUNDERPCB_MENU_EXT">founderpcb_menu_ext对象</param>
        /// <returns>新插入记录的编号</returns>
        public int add(FOUNDERPCB_MENU_EXT founderpcb_menu_ext)
        {
            // Validate input
            if (founderpcb_menu_ext == null)
                return 0;

            return founderpcb_menu_extDal.Add(founderpcb_menu_ext);
        }
        public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_MENU_EXT founderpcb_menu_ext)
        {
            // Validate input
            if (founderpcb_menu_ext == null)
                return 0;

            return founderpcb_menu_extDal.Add(cmd, conn, trans, founderpcb_menu_ext);
        }
        #endregion

        #region 更新
        /// <summary>
        /// 向数据表FOUNDERPCB_MENU_EXT更新一条记录。
        /// </summary>
        /// <param name="oFOUNDERPCB_MENU_EXTInfo">FOUNDERPCB_MENU_EXT</param>
        /// <returns>影响的行数</returns>
        public int Update(FOUNDERPCB_MENU_EXT founderpcb_menu_ext)
        {
            // Validate input
            if (founderpcb_menu_ext == null)
                return 0;

            return founderpcb_menu_extDal.Update(founderpcb_menu_ext);
        }
        public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_MENU_EXT founderpcb_menu_ext)
        {
            // Validate input
            if (founderpcb_menu_ext == null)
                return;

            founderpcb_menu_extDal.Update(cmd, conn, trans, founderpcb_menu_ext);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除数据表FOUNDERPCB_MENU_EXT中的一条记录
        /// </summary>
        /// <param name="rKEY">rKEY</param>
        /// <returns>影响的行数</returns>
        public int DeleteByRKEY(decimal rKEY)
        {
            // Validate input
            if (rKEY < 0)
                return 0;

            return founderpcb_menu_extDal.DeleteByRKEY(rKEY);
        }
        public int Delete(FOUNDERPCB_MENU_EXT founderpcb_menu_ext)
        {
            // Validate input
            if (founderpcb_menu_ext == null)
                return 0;

            return founderpcb_menu_extDal.Delete(founderpcb_menu_ext);
        }
        public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
        {
            // Validate input
            if (rKEY < 0)
                return;

            founderpcb_menu_extDal.Delete(cmd, conn, trans, rKEY);
        }
        #endregion

        #endregion

        #region 查询
        /// <summary>
        /// 得到 founderpcb_menu_ext 数据实体
        /// </summary>
        /// <param name="rKEY">rKEY</param>
        /// <returns>founderpcb_menu_ext 数据实体</returns>
        public FOUNDERPCB_MENU_EXT getFOUNDERPCB_MENU_EXTByRKEY(decimal rKEY)
        {
            // Validate input
            if (rKEY < 0)
                return null;

            // Use the dal to get a record 

            return founderpcb_menu_extDal.getFOUNDERPCB_MENU_EXTByRKEY(rKEY);
        }
        /// <summary>
        /// 得到数据表FOUNDERPCB_MENU_EXT所有记录
        /// </summary>
        /// <returns>实体集</returns>
        public IList<FOUNDERPCB_MENU_EXT> FindAllFOUNDERPCB_MENU_EXT()
        {
            // Use the dal to get all records 

            return founderpcb_menu_extDal.FindAllFOUNDERPCB_MENU_EXT();
        }
        ///<summary>
        ///
        ///</summary> 
        public IList<FOUNDERPCB_MENU_EXT> FindBySql(string sqlWhere)
        {
            return founderpcb_menu_extDal.FindBySql(sqlWhere);
        }

        public DataTable getDataSet(string sql)
        {
            return founderpcb_menu_extDal.getDataSet(sql);
        }
        #endregion

        #region 关闭
        public void CloseConnection()
        {
            founderpcb_menu_extDal.CloseConnection();
        }
        #endregion

        #endregion
    }
}

