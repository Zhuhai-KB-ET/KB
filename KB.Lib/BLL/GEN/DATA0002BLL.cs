//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:35
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
    /// 业务层  DATA0002BLL
    /// </summary>
    public partial class DATA0002BLL
    {	
		DATA0002DAL data0002Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0002BLL(Form frm)
		{
			 data0002Dal=new DATA0002DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0002BLL(Form frm, int factoryID)
		{
			 data0002Dal=new DATA0002DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0002BLL(int Thread, int factoryID)
		{
			 data0002Dal=new DATA0002DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0002BLL(int Thread)
		{
			 data0002Dal=new DATA0002DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0002BLL(DBHelper DB)
		{
			 data0002Dal=new DATA0002DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0002">data0002对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0002 data0002)
		{
			// Validate input
			if (data0002 == null)
				return 0;
			
			return data0002Dal.Add(data0002);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0002 data0002)
		{
			// Validate input
			if (data0002 == null)
				return 0;
			
			return data0002Dal.Add(cmd, conn, trans, data0002); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0002更新一条记录。
		/// </summary>
		/// <param name="oDATA0002Info">DATA0002</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0002 data0002)
		{
            // Validate input
			if (data0002==null)
				return 0;
			
			return data0002Dal.Update(data0002);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0002 data0002)
		{
			// Validate input
			if (data0002==null)
				return ;
			
			data0002Dal.Update(cmd, conn, trans, data0002);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0002中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0002Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0002 data0002)
		{
			// Validate input
			if (data0002==null)
				return 0;
				
			return data0002Dal.Delete(data0002);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0002Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0002 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0002 数据实体</returns>
		public DATA0002 getDATA0002ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0002Dal.getDATA0002ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表DATA0002所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0002>FindAllDATA0002()
		{
			// Use the dal to get all records 
			
			return data0002Dal.FindAllDATA0002();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0002> FindBySql(string sqlWhere)
		{ 
			return data0002Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0002Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0002Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

