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
    /// 业务层  DATA0498BLL
    /// </summary>
    public partial class DATA0498BLL
    {	
		DATA0498DAL data0498Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0498BLL(Form frm)
		{
			 data0498Dal=new DATA0498DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0498BLL(Form frm, int factoryID)
		{
			 data0498Dal=new DATA0498DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0498BLL(int Thread, int factoryID)
		{
			 data0498Dal=new DATA0498DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0498BLL(int Thread)
		{
			 data0498Dal=new DATA0498DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0498BLL(DBHelper DB)
		{
			 data0498Dal=new DATA0498DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0498">data0498对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0498 data0498)
		{
			// Validate input
			if (data0498 == null)
				return 0;
			
			return data0498Dal.Add(data0498);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0498 data0498)
		{
			// Validate input
			if (data0498 == null)
				return 0;
			
			return data0498Dal.Add(cmd, conn, trans, data0498); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0498更新一条记录。
		/// </summary>
		/// <param name="oDATA0498Info">DATA0498</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0498 data0498)
		{
            // Validate input
			if (data0498==null)
				return 0;
			
			return data0498Dal.Update(data0498);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0498 data0498)
		{
			// Validate input
			if (data0498==null)
				return ;
			
			data0498Dal.Update(cmd, conn, trans, data0498);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0498中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0498Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0498 data0498)
		{
			// Validate input
			if (data0498==null)
				return 0;
				
			return data0498Dal.Delete(data0498);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0498Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0498 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0498 数据实体</returns>
		public DATA0498 getDATA0498ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0498Dal.getDATA0498ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表DATA0498所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0498>FindAllDATA0498()
		{
			// Use the dal to get all records 
			
			return data0498Dal.FindAllDATA0498();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0498> FindBySql(string sqlWhere)
		{ 
			return data0498Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0498Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0498Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

