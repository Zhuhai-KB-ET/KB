//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:05
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
    /// 业务层  FOUNDERPCB_LOGIN_LOGBLL
    /// </summary>
    public partial class FOUNDERPCB_LOGIN_LOGBLL
    {	
		FOUNDERPCB_LOGIN_LOGDAL founderpcb_login_logDal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public FOUNDERPCB_LOGIN_LOGBLL(Form frm)
		{
			 founderpcb_login_logDal=new FOUNDERPCB_LOGIN_LOGDAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_LOGIN_LOGBLL(Form frm, int factoryID)
		{
			 founderpcb_login_logDal=new FOUNDERPCB_LOGIN_LOGDAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_LOGIN_LOGBLL(int Thread, int factoryID)
		{
			 founderpcb_login_logDal=new FOUNDERPCB_LOGIN_LOGDAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public FOUNDERPCB_LOGIN_LOGBLL(int Thread)
		{
			 founderpcb_login_logDal=new FOUNDERPCB_LOGIN_LOGDAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public FOUNDERPCB_LOGIN_LOGBLL(DBHelper DB)
		{
			 founderpcb_login_logDal=new FOUNDERPCB_LOGIN_LOGDAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_LOGIN_LOG">founderpcb_login_log对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{
			// Validate input
			if (founderpcb_login_log == null)
				return 0;
			
			return founderpcb_login_logDal.Add(founderpcb_login_log);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{
			// Validate input
			if (founderpcb_login_log == null)
				return 0;
			
			return founderpcb_login_logDal.Add(cmd, conn, trans, founderpcb_login_log); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表FOUNDERPCB_LOGIN_LOG更新一条记录。
		/// </summary>
		/// <param name="oFOUNDERPCB_LOGIN_LOGInfo">FOUNDERPCB_LOGIN_LOG</param>
		/// <returns>影响的行数</returns>
		public int Update(FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{
            // Validate input
			if (founderpcb_login_log==null)
				return 0;
			
			return founderpcb_login_logDal.Update(founderpcb_login_log);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{
			// Validate input
			if (founderpcb_login_log==null)
				return ;
			
			founderpcb_login_logDal.Update(cmd, conn, trans, founderpcb_login_log);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表FOUNDERPCB_LOGIN_LOG中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return founderpcb_login_logDal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{
			// Validate input
			if (founderpcb_login_log==null)
				return 0;
				
			return founderpcb_login_logDal.Delete(founderpcb_login_log);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			founderpcb_login_logDal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 founderpcb_login_log 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>founderpcb_login_log 数据实体</returns>
		public FOUNDERPCB_LOGIN_LOG getFOUNDERPCB_LOGIN_LOGByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return founderpcb_login_logDal.getFOUNDERPCB_LOGIN_LOGByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表FOUNDERPCB_LOGIN_LOG所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< FOUNDERPCB_LOGIN_LOG>FindAllFOUNDERPCB_LOGIN_LOG()
		{
			// Use the dal to get all records 
			
			return founderpcb_login_logDal.FindAllFOUNDERPCB_LOGIN_LOG();
		} 
		///<summary>
		///
		///</summary> 
		public IList< FOUNDERPCB_LOGIN_LOG> FindBySql(string sqlWhere)
		{ 
			return founderpcb_login_logDal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return founderpcb_login_logDal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            founderpcb_login_logDal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

