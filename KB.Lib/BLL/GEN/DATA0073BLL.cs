//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:59
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
    /// 业务层  DATA0073BLL
    /// </summary>
    public partial class DATA0073BLL
    {	
		DATA0073DAL data0073Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0073BLL(Form frm)
		{
			 data0073Dal=new DATA0073DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0073BLL(Form frm, int factoryID)
		{
			 data0073Dal=new DATA0073DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0073BLL(int Thread, int factoryID)
		{
			 data0073Dal=new DATA0073DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0073BLL(int Thread)
		{
			 data0073Dal=new DATA0073DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0073BLL(DBHelper DB)
		{
			 data0073Dal=new DATA0073DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0073">data0073对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0073 data0073)
		{
			// Validate input
			if (data0073 == null)
				return 0;
			
			return data0073Dal.Add(data0073);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0073 data0073)
		{
			// Validate input
			if (data0073 == null)
				return 0;
			
			return data0073Dal.Add(cmd, conn, trans, data0073); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0073更新一条记录。
		/// </summary>
		/// <param name="oDATA0073Info">DATA0073</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0073 data0073)
		{
            // Validate input
			if (data0073==null)
				return 0;
			
			return data0073Dal.Update(data0073);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0073 data0073)
		{
			// Validate input
			if (data0073==null)
				return ;
			
			data0073Dal.Update(cmd, conn, trans, data0073);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0073中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0073Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0073 data0073)
		{
			// Validate input
			if (data0073==null)
				return 0;
				
			return data0073Dal.Delete(data0073);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0073Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0073 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0073 数据实体</returns>
		public DATA0073 getDATA0073ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0073Dal.getDATA0073ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表DATA0073所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0073>FindAllDATA0073()
		{
			// Use the dal to get all records 
			
			return data0073Dal.FindAllDATA0073();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0073> FindBySql(string sqlWhere)
		{ 
			return data0073Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0073Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0073Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

