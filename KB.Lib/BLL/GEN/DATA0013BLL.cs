//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:38
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
    /// 业务层  DATA0013BLL
    /// </summary>
    public partial class DATA0013BLL
    {	
		DATA0013DAL data0013Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0013BLL(Form frm)
		{
			 data0013Dal=new DATA0013DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0013BLL(Form frm, int factoryID)
		{
			 data0013Dal=new DATA0013DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0013BLL(int Thread, int factoryID)
		{
			 data0013Dal=new DATA0013DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0013BLL(int Thread)
		{
			 data0013Dal=new DATA0013DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0013BLL(DBHelper DB)
		{
			 data0013Dal=new DATA0013DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0013">data0013对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0013 data0013)
		{
			// Validate input
			if (data0013 == null)
				return 0;
			
			return data0013Dal.Add(data0013);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0013 data0013)
		{
			// Validate input
			if (data0013 == null)
				return 0;
			
			return data0013Dal.Add(cmd, conn, trans, data0013); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0013更新一条记录。
		/// </summary>
		/// <param name="oDATA0013Info">DATA0013</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0013 data0013)
		{
            // Validate input
			if (data0013==null)
				return 0;
			
			return data0013Dal.Update(data0013);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0013 data0013)
		{
			// Validate input
			if (data0013==null)
				return ;
			
			data0013Dal.Update(cmd, conn, trans, data0013);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0013中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0013Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0013 data0013)
		{
			// Validate input
			if (data0013==null)
				return 0;
				
			return data0013Dal.Delete(data0013);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0013Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0013 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0013 数据实体</returns>
		public DATA0013 getDATA0013ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0013Dal.getDATA0013ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表DATA0013所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0013>FindAllDATA0013()
		{
			// Use the dal to get all records 
			
			return data0013Dal.FindAllDATA0013();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0013> FindBySql(string sqlWhere)
		{ 
			return data0013Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0013Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0013Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

