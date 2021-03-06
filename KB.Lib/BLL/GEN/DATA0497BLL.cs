﻿//============================================================
// 项目名称:	    格力凯邦   ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2018,格力凯邦 All Rights Reserved 版权所有
// 编写日期: 	2018/11/20 16:04:20
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
    /// 业务层  DATA0497BLL
    /// </summary>
    public partial class DATA0497BLL
    {	
		DATA0497DAL data0497Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0497BLL(Form frm)
		{
			 data0497Dal=new DATA0497DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0497BLL(Form frm, int factoryID)
		{
			 data0497Dal=new DATA0497DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0497BLL(int Thread, int factoryID)
		{
			 data0497Dal=new DATA0497DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0497BLL(int Thread)
		{
			 data0497Dal=new DATA0497DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0497BLL(DBHelper DB)
		{
			 data0497Dal=new DATA0497DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0497">data0497对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0497 data0497)
		{
			// Validate input
			if (data0497 == null)
				return 0;
			
			return data0497Dal.Add(data0497);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0497 data0497)
		{
			// Validate input
			if (data0497 == null)
				return 0;
			
			return data0497Dal.Add(cmd, conn, trans, data0497); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0497更新一条记录。
		/// </summary>
		/// <param name="oDATA0497Info">DATA0497</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0497 data0497)
		{
            // Validate input
			if (data0497==null)
				return 0;
			
			return data0497Dal.Update(data0497);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0497 data0497)
		{
			// Validate input
			if (data0497==null)
				return ;
			
			data0497Dal.Update(cmd, conn, trans, data0497);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0497中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0497Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0497 data0497)
		{
			// Validate input
			if (data0497==null)
				return 0;
				
			return data0497Dal.Delete(data0497);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0497Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0497 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0497 数据实体</returns>
		public DATA0497 getDATA0497ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0497Dal.getDATA0497ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表DATA0497所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0497>FindAllDATA0497()
		{
			// Use the dal to get all records 
			
			return data0497Dal.FindAllDATA0497();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0497> FindBySql(string sqlWhere)
		{ 
			return data0497Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0497Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0497Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

