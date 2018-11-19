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
    /// 业务层  DATA0011BLL
    /// </summary>
    public partial class DATA0011BLL
    {	
		DATA0011DAL data0011Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0011BLL(Form frm)
		{
			 data0011Dal=new DATA0011DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0011BLL(Form frm, int factoryID)
		{
			 data0011Dal=new DATA0011DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0011BLL(int Thread, int factoryID)
		{
			 data0011Dal=new DATA0011DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0011BLL(int Thread)
		{
			 data0011Dal=new DATA0011DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0011BLL(DBHelper DB)
		{
			 data0011Dal=new DATA0011DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0011">data0011对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0011 data0011)
		{
			// Validate input
			if (data0011 == null)
				return 0;
			
			return data0011Dal.Add(data0011);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0011 data0011)
		{
			// Validate input
			if (data0011 == null)
				return 0;
			
			return data0011Dal.Add(cmd, conn, trans, data0011); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0011更新一条记录。
		/// </summary>
		/// <param name="oDATA0011Info">DATA0011</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0011 data0011)
		{
            // Validate input
			if (data0011==null)
				return 0;
			
			return data0011Dal.Update(data0011);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0011 data0011)
		{
			// Validate input
			if (data0011==null)
				return ;
			
			data0011Dal.Update(cmd, conn, trans, data0011);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0011中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0011Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0011 data0011)
		{
			// Validate input
			if (data0011==null)
				return 0;
				
			return data0011Dal.Delete(data0011);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0011Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0011 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0011 数据实体</returns>
		public DATA0011 getDATA0011ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0011Dal.getDATA0011ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表DATA0011所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0011>FindAllDATA0011()
		{
			// Use the dal to get all records 
			
			return data0011Dal.FindAllDATA0011();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0011> FindBySql(string sqlWhere)
		{ 
			return data0011Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0011Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0011Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

