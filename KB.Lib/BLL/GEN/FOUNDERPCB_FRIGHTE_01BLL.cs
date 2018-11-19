//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:03
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
    /// 业务层  FOUNDERPCB_FRIGHTE_01BLL
    /// </summary>
    public partial class FOUNDERPCB_FRIGHTE_01BLL
    {	
		FOUNDERPCB_FRIGHTE_01DAL founderpcb_frighte_01Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public FOUNDERPCB_FRIGHTE_01BLL(Form frm)
		{
			 founderpcb_frighte_01Dal=new FOUNDERPCB_FRIGHTE_01DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_FRIGHTE_01BLL(Form frm, int factoryID)
		{
			 founderpcb_frighte_01Dal=new FOUNDERPCB_FRIGHTE_01DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_FRIGHTE_01BLL(int Thread, int factoryID)
		{
			 founderpcb_frighte_01Dal=new FOUNDERPCB_FRIGHTE_01DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public FOUNDERPCB_FRIGHTE_01BLL(int Thread)
		{
			 founderpcb_frighte_01Dal=new FOUNDERPCB_FRIGHTE_01DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public FOUNDERPCB_FRIGHTE_01BLL(DBHelper DB)
		{
			 founderpcb_frighte_01Dal=new FOUNDERPCB_FRIGHTE_01DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_FRIGHTE_01">founderpcb_frighte_01对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(FOUNDERPCB_FRIGHTE_01 founderpcb_frighte_01)
		{
			// Validate input
			if (founderpcb_frighte_01 == null)
				return 0;
			
			return founderpcb_frighte_01Dal.Add(founderpcb_frighte_01);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_FRIGHTE_01 founderpcb_frighte_01)
		{
			// Validate input
			if (founderpcb_frighte_01 == null)
				return 0;
			
			return founderpcb_frighte_01Dal.Add(cmd, conn, trans, founderpcb_frighte_01); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表FOUNDERPCB_FRIGHTE_01更新一条记录。
		/// </summary>
		/// <param name="oFOUNDERPCB_FRIGHTE_01Info">FOUNDERPCB_FRIGHTE_01</param>
		/// <returns>影响的行数</returns>
		public int Update(FOUNDERPCB_FRIGHTE_01 founderpcb_frighte_01)
		{
            // Validate input
			if (founderpcb_frighte_01==null)
				return 0;
			
			return founderpcb_frighte_01Dal.Update(founderpcb_frighte_01);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_FRIGHTE_01 founderpcb_frighte_01)
		{
			// Validate input
			if (founderpcb_frighte_01==null)
				return ;
			
			founderpcb_frighte_01Dal.Update(cmd, conn, trans, founderpcb_frighte_01);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表FOUNDERPCB_FRIGHTE_01中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return founderpcb_frighte_01Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(FOUNDERPCB_FRIGHTE_01 founderpcb_frighte_01)
		{
			// Validate input
			if (founderpcb_frighte_01==null)
				return 0;
				
			return founderpcb_frighte_01Dal.Delete(founderpcb_frighte_01);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			founderpcb_frighte_01Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 founderpcb_frighte_01 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>founderpcb_frighte_01 数据实体</returns>
		public FOUNDERPCB_FRIGHTE_01 getFOUNDERPCB_FRIGHTE_01ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return founderpcb_frighte_01Dal.getFOUNDERPCB_FRIGHTE_01ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表FOUNDERPCB_FRIGHTE_01所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< FOUNDERPCB_FRIGHTE_01>FindAllFOUNDERPCB_FRIGHTE_01()
		{
			// Use the dal to get all records 
			
			return founderpcb_frighte_01Dal.FindAllFOUNDERPCB_FRIGHTE_01();
		} 
		///<summary>
		///
		///</summary> 
		public IList< FOUNDERPCB_FRIGHTE_01> FindBySql(string sqlWhere)
		{ 
			return founderpcb_frighte_01Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return founderpcb_frighte_01Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            founderpcb_frighte_01Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

