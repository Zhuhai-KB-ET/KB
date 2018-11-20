//============================================================
// 项目名称:	    格力凯邦   ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2018,格力凯邦 All Rights Reserved 版权所有
// 编写日期: 	2018/11/20 16:05:05
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
    /// 业务层  GREEKB_LOGIN_LOGBLL
    /// </summary>
    public partial class GREEKB_LOGIN_LOGBLL
    {	
		GREEKB_LOGIN_LOGDAL GREEKB_login_logDal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public GREEKB_LOGIN_LOGBLL(Form frm)
		{
			 GREEKB_login_logDal=new GREEKB_LOGIN_LOGDAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public GREEKB_LOGIN_LOGBLL(Form frm, int factoryID)
		{
			 GREEKB_login_logDal=new GREEKB_LOGIN_LOGDAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public GREEKB_LOGIN_LOGBLL(int Thread, int factoryID)
		{
			 GREEKB_login_logDal=new GREEKB_LOGIN_LOGDAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public GREEKB_LOGIN_LOGBLL(int Thread)
		{
			 GREEKB_login_logDal=new GREEKB_LOGIN_LOGDAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public GREEKB_LOGIN_LOGBLL(DBHelper DB)
		{
			 GREEKB_login_logDal=new GREEKB_LOGIN_LOGDAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="GREEKB_LOGIN_LOG">GREEKB_login_log对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(GREEKB_LOGIN_LOG GREEKB_login_log)
		{
			// Validate input
			if (GREEKB_login_log == null)
				return 0;
			
			return GREEKB_login_logDal.Add(GREEKB_login_log);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, GREEKB_LOGIN_LOG GREEKB_login_log)
		{
			// Validate input
			if (GREEKB_login_log == null)
				return 0;
			
			return GREEKB_login_logDal.Add(cmd, conn, trans, GREEKB_login_log); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表GREEKB_LOGIN_LOG更新一条记录。
		/// </summary>
		/// <param name="oGREEKB_LOGIN_LOGInfo">GREEKB_LOGIN_LOG</param>
		/// <returns>影响的行数</returns>
		public int Update(GREEKB_LOGIN_LOG GREEKB_login_log)
		{
            // Validate input
			if (GREEKB_login_log==null)
				return 0;
			
			return GREEKB_login_logDal.Update(GREEKB_login_log);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, GREEKB_LOGIN_LOG GREEKB_login_log)
		{
			// Validate input
			if (GREEKB_login_log==null)
				return ;
			
			GREEKB_login_logDal.Update(cmd, conn, trans, GREEKB_login_log);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表GREEKB_LOGIN_LOG中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return GREEKB_login_logDal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(GREEKB_LOGIN_LOG GREEKB_login_log)
		{
			// Validate input
			if (GREEKB_login_log==null)
				return 0;
				
			return GREEKB_login_logDal.Delete(GREEKB_login_log);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			GREEKB_login_logDal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 GREEKB_login_log 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>GREEKB_login_log 数据实体</returns>
		public GREEKB_LOGIN_LOG getGREEKB_LOGIN_LOGByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return GREEKB_login_logDal.getGREEKB_LOGIN_LOGByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表GREEKB_LOGIN_LOG所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< GREEKB_LOGIN_LOG>FindAllGREEKB_LOGIN_LOG()
		{
			// Use the dal to get all records 
			
			return GREEKB_login_logDal.FindAllGREEKB_LOGIN_LOG();
		} 
		///<summary>
		///
		///</summary> 
		public IList< GREEKB_LOGIN_LOG> FindBySql(string sqlWhere)
		{ 
			return GREEKB_login_logDal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return GREEKB_login_logDal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            GREEKB_login_logDal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

