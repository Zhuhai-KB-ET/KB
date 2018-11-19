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
    /// 业务层  FOUNDERPCB_USER_PERMISSIONBLL
    /// </summary>
    public partial class FOUNDERPCB_USER_PERMISSIONBLL
    {	
		FOUNDERPCB_USER_PERMISSIONDAL founderpcb_user_permissionDal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public FOUNDERPCB_USER_PERMISSIONBLL(Form frm)
		{
			 founderpcb_user_permissionDal=new FOUNDERPCB_USER_PERMISSIONDAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_USER_PERMISSIONBLL(Form frm, int factoryID)
		{
			 founderpcb_user_permissionDal=new FOUNDERPCB_USER_PERMISSIONDAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_USER_PERMISSIONBLL(int Thread, int factoryID)
		{
			 founderpcb_user_permissionDal=new FOUNDERPCB_USER_PERMISSIONDAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public FOUNDERPCB_USER_PERMISSIONBLL(int Thread)
		{
			 founderpcb_user_permissionDal=new FOUNDERPCB_USER_PERMISSIONDAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public FOUNDERPCB_USER_PERMISSIONBLL(DBHelper DB)
		{
			 founderpcb_user_permissionDal=new FOUNDERPCB_USER_PERMISSIONDAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_USER_PERMISSION">founderpcb_user_permission对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(FOUNDERPCB_USER_PERMISSION founderpcb_user_permission)
		{
			// Validate input
			if (founderpcb_user_permission == null)
				return 0;
			
			return founderpcb_user_permissionDal.Add(founderpcb_user_permission);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_USER_PERMISSION founderpcb_user_permission)
		{
			// Validate input
			if (founderpcb_user_permission == null)
				return 0;
			
			return founderpcb_user_permissionDal.Add(cmd, conn, trans, founderpcb_user_permission); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表FOUNDERPCB_USER_PERMISSION更新一条记录。
		/// </summary>
		/// <param name="oFOUNDERPCB_USER_PERMISSIONInfo">FOUNDERPCB_USER_PERMISSION</param>
		/// <returns>影响的行数</returns>
		public int Update(FOUNDERPCB_USER_PERMISSION founderpcb_user_permission)
		{
            // Validate input
			if (founderpcb_user_permission==null)
				return 0;
			
			return founderpcb_user_permissionDal.Update(founderpcb_user_permission);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_USER_PERMISSION founderpcb_user_permission)
		{
			// Validate input
			if (founderpcb_user_permission==null)
				return ;
			
			founderpcb_user_permissionDal.Update(cmd, conn, trans, founderpcb_user_permission);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表FOUNDERPCB_USER_PERMISSION中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return founderpcb_user_permissionDal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(FOUNDERPCB_USER_PERMISSION founderpcb_user_permission)
		{
			// Validate input
			if (founderpcb_user_permission==null)
				return 0;
				
			return founderpcb_user_permissionDal.Delete(founderpcb_user_permission);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			founderpcb_user_permissionDal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 founderpcb_user_permission 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>founderpcb_user_permission 数据实体</returns>
		public FOUNDERPCB_USER_PERMISSION getFOUNDERPCB_USER_PERMISSIONByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return founderpcb_user_permissionDal.getFOUNDERPCB_USER_PERMISSIONByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表FOUNDERPCB_USER_PERMISSION所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< FOUNDERPCB_USER_PERMISSION>FindAllFOUNDERPCB_USER_PERMISSION()
		{
			// Use the dal to get all records 
			
			return founderpcb_user_permissionDal.FindAllFOUNDERPCB_USER_PERMISSION();
		} 
		///<summary>
		///
		///</summary> 
		public IList< FOUNDERPCB_USER_PERMISSION> FindBySql(string sqlWhere)
		{ 
			return founderpcb_user_permissionDal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return founderpcb_user_permissionDal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            founderpcb_user_permissionDal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

