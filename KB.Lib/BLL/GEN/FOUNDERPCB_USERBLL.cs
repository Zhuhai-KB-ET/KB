//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:06
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
    /// 业务层  FOUNDERPCB_USERBLL
    /// </summary>
    public partial class FOUNDERPCB_USERBLL
    {	
		FOUNDERPCB_USERDAL founderpcb_userDal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public FOUNDERPCB_USERBLL(Form frm)
		{
			 founderpcb_userDal=new FOUNDERPCB_USERDAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_USERBLL(Form frm, int factoryID)
		{
			 founderpcb_userDal=new FOUNDERPCB_USERDAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_USERBLL(int Thread, int factoryID)
		{
			 founderpcb_userDal=new FOUNDERPCB_USERDAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public FOUNDERPCB_USERBLL(int Thread)
		{
			 founderpcb_userDal=new FOUNDERPCB_USERDAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public FOUNDERPCB_USERBLL(DBHelper DB)
		{
			 founderpcb_userDal=new FOUNDERPCB_USERDAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_USER">founderpcb_user对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(FOUNDERPCB_USER founderpcb_user)
		{
			// Validate input
			if (founderpcb_user == null)
				return 0;
			
			return founderpcb_userDal.Add(founderpcb_user);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_USER founderpcb_user)
		{
			// Validate input
			if (founderpcb_user == null)
				return 0;
			
			return founderpcb_userDal.Add(cmd, conn, trans, founderpcb_user); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表FOUNDERPCB_USER更新一条记录。
		/// </summary>
		/// <param name="oFOUNDERPCB_USERInfo">FOUNDERPCB_USER</param>
		/// <returns>影响的行数</returns>
		public int Update(FOUNDERPCB_USER founderpcb_user)
		{
            // Validate input
			if (founderpcb_user==null)
				return 0;
			
			return founderpcb_userDal.Update(founderpcb_user);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_USER founderpcb_user)
		{
			// Validate input
			if (founderpcb_user==null)
				return ;
			
			founderpcb_userDal.Update(cmd, conn, trans, founderpcb_user);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表FOUNDERPCB_USER中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return founderpcb_userDal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(FOUNDERPCB_USER founderpcb_user)
		{
			// Validate input
			if (founderpcb_user==null)
				return 0;
				
			return founderpcb_userDal.Delete(founderpcb_user);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			founderpcb_userDal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 founderpcb_user 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>founderpcb_user 数据实体</returns>
		public FOUNDERPCB_USER getFOUNDERPCB_USERByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return founderpcb_userDal.getFOUNDERPCB_USERByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表FOUNDERPCB_USER所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< FOUNDERPCB_USER>FindAllFOUNDERPCB_USER()
		{
			// Use the dal to get all records 
			
			return founderpcb_userDal.FindAllFOUNDERPCB_USER();
		} 
		///<summary>
		///
		///</summary> 
		public IList< FOUNDERPCB_USER> FindBySql(string sqlWhere)
		{ 
			return founderpcb_userDal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return founderpcb_userDal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            founderpcb_userDal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

