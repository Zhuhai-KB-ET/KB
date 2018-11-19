//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:36
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
    /// 业务层  DATA0006BLL
    /// </summary>
    public partial class DATA0006BLL
    {	
		DATA0006DAL data0006Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0006BLL(Form frm)
		{
			 data0006Dal=new DATA0006DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0006BLL(Form frm, int factoryID)
		{
			 data0006Dal=new DATA0006DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0006BLL(int Thread, int factoryID)
		{
			 data0006Dal=new DATA0006DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0006BLL(int Thread)
		{
			 data0006Dal=new DATA0006DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0006BLL(DBHelper DB)
		{
			 data0006Dal=new DATA0006DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0006">data0006对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0006 data0006)
		{
			// Validate input
			if (data0006 == null)
				return 0;
			
			return data0006Dal.Add(data0006);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0006 data0006)
		{
			// Validate input
			if (data0006 == null)
				return 0;
			
			return data0006Dal.Add(cmd, conn, trans, data0006); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0006更新一条记录。
		/// </summary>
		/// <param name="oDATA0006Info">DATA0006</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0006 data0006)
		{
            // Validate input
			if (data0006==null)
				return 0;
			
			return data0006Dal.Update(data0006);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0006 data0006)
		{
			// Validate input
			if (data0006==null)
				return ;
			
			data0006Dal.Update(cmd, conn, trans, data0006);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0006中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0006Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0006 data0006)
		{
			// Validate input
			if (data0006==null)
				return 0;
				
			return data0006Dal.Delete(data0006);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0006Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0006 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0006 数据实体</returns>
		public DATA0006 getDATA0006ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0006Dal.getDATA0006ByRKEY(rKEY);
		} 
        /// <summary>
        /// 通过父ID找子Rkey
        /// </summary>
        /// <returns></returns>
        public List<decimal> getRKEYByParent(decimal parent_id)
        {
            return data0006Dal.getRKEYByParent(parent_id);
        }
		/// <summary>
		/// 得到数据表DATA0006所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0006>FindAllDATA0006()
		{
			// Use the dal to get all records 
			
			return data0006Dal.FindAllDATA0006();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0006> FindBySql(string sqlWhere)
		{ 
			return data0006Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0006Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0006Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

