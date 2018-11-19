//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:34
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
    /// 业务层  DATA0001BLL
    /// </summary>
    public partial class DATA0001BLL
    {	
		DATA0001DAL data0001Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public DATA0001BLL(Form frm)
		{
			 data0001Dal=new DATA0001DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public DATA0001BLL(Form frm, int factoryID)
		{
			 data0001Dal=new DATA0001DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public DATA0001BLL(int Thread, int factoryID)
		{
			 data0001Dal=new DATA0001DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public DATA0001BLL(int Thread)
		{
			 data0001Dal=new DATA0001DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public DATA0001BLL(DBHelper DB)
		{
			 data0001Dal=new DATA0001DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="DATA0001">data0001对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(DATA0001 data0001)
		{
			// Validate input
			if (data0001 == null)
				return 0;
			
			return data0001Dal.Add(data0001);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0001 data0001)
		{
			// Validate input
			if (data0001 == null)
				return 0;
			
			return data0001Dal.Add(cmd, conn, trans, data0001); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表DATA0001更新一条记录。
		/// </summary>
		/// <param name="oDATA0001Info">DATA0001</param>
		/// <returns>影响的行数</returns>
		public int Update(DATA0001 data0001)
		{
            // Validate input
			if (data0001==null)
				return 0;
			
			return data0001Dal.Update(data0001);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0001 data0001)
		{
			// Validate input
			if (data0001==null)
				return ;
			
			data0001Dal.Update(cmd, conn, trans, data0001);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表DATA0001中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return data0001Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(DATA0001 data0001)
		{
			// Validate input
			if (data0001==null)
				return 0;
				
			return data0001Dal.Delete(data0001);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			data0001Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 data0001 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>data0001 数据实体</returns>
		public DATA0001 getDATA0001ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return data0001Dal.getDATA0001ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表DATA0001所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< DATA0001>FindAllDATA0001()
		{
			// Use the dal to get all records 
			
			return data0001Dal.FindAllDATA0001();
		} 
		///<summary>
		///
		///</summary> 
		public IList< DATA0001> FindBySql(string sqlWhere)
		{ 
			return data0001Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return data0001Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            data0001Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

