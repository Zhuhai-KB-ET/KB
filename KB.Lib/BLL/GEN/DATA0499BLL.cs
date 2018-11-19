//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:04:21
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
    /// 业务层  DATA0499BLL
    /// </summary>
    public partial class DATA0499BLL
    {	
		DATA0499DAL data0499Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0499BLL(Form frm)
		{
			 data0499Dal=new DATA0499DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0499BLL(Form frm, int factoryID)
		{
			 data0499Dal=new DATA0499DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0499BLL(int Thread, int factoryID)
		{
			 data0499Dal=new DATA0499DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0499BLL(int Thread)
		{
			 data0499Dal=new DATA0499DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0499BLL(DBHelper DB)
		{
			 data0499Dal=new DATA0499DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0499">data0499对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0499 data0499)
		{
			// Validate input
			if (data0499 == null)
				return 0;
			
			return data0499Dal.Add(data0499);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0499 data0499)
		{
			// Validate input
			if (data0499 == null)
				return 0;
			
			return data0499Dal.Add(cmd, conn, trans, data0499); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0499更新一条记录。
		/// </summary>
		/// <param name="oDATA0499Info">DATA0499</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0499 data0499)
		{
            // Validate input
			if (data0499==null)
				return 0;
			
			return data0499Dal.Update(data0499);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0499 data0499)
		{
			// Validate input
			if (data0499==null)
				return ;
			
			data0499Dal.Update(cmd, conn, trans, data0499);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0499中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0499Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0499 data0499)
		{
			// Validate input
			if (data0499==null)
				return 0;
				
			return data0499Dal.Delete(data0499);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0499Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0499 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0499 数据实体</returns>
		public DATA0499 getDATA0499ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0499Dal.getDATA0499ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表DATA0499所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0499>FindAllDATA0499()
		{
			// Use the dal to get all records 
			
			return data0499Dal.FindAllDATA0499();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0499> FindBySql(string sqlWhere)
		{ 
			return data0499Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0499Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0499Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

