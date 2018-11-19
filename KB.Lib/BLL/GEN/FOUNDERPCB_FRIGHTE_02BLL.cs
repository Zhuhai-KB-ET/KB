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
    /// 业务层  FOUNDERPCB_FRIGHTE_02BLL
    /// </summary>
    public partial class FOUNDERPCB_FRIGHTE_02BLL
    {	
		FOUNDERPCB_FRIGHTE_02DAL founderpcb_frighte_02Dal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public FOUNDERPCB_FRIGHTE_02BLL(Form frm)
		{
			 founderpcb_frighte_02Dal=new FOUNDERPCB_FRIGHTE_02DAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_FRIGHTE_02BLL(Form frm, int factoryID)
		{
			 founderpcb_frighte_02Dal=new FOUNDERPCB_FRIGHTE_02DAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_FRIGHTE_02BLL(int Thread, int factoryID)
		{
			 founderpcb_frighte_02Dal=new FOUNDERPCB_FRIGHTE_02DAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public FOUNDERPCB_FRIGHTE_02BLL(int Thread)
		{
			 founderpcb_frighte_02Dal=new FOUNDERPCB_FRIGHTE_02DAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public FOUNDERPCB_FRIGHTE_02BLL(DBHelper DB)
		{
			 founderpcb_frighte_02Dal=new FOUNDERPCB_FRIGHTE_02DAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_FRIGHTE_02">founderpcb_frighte_02对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{
			// Validate input
			if (founderpcb_frighte_02 == null)
				return 0;
			
			return founderpcb_frighte_02Dal.Add(founderpcb_frighte_02);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{
			// Validate input
			if (founderpcb_frighte_02 == null)
				return 0;
			
			return founderpcb_frighte_02Dal.Add(cmd, conn, trans, founderpcb_frighte_02); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表FOUNDERPCB_FRIGHTE_02更新一条记录。
		/// </summary>
		/// <param name="oFOUNDERPCB_FRIGHTE_02Info">FOUNDERPCB_FRIGHTE_02</param>
		/// <returns>影响的行数</returns>
		public int Update(FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{
            // Validate input
			if (founderpcb_frighte_02==null)
				return 0;
			
			return founderpcb_frighte_02Dal.Update(founderpcb_frighte_02);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{
			// Validate input
			if (founderpcb_frighte_02==null)
				return ;
			
			founderpcb_frighte_02Dal.Update(cmd, conn, trans, founderpcb_frighte_02);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表FOUNDERPCB_FRIGHTE_02中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return founderpcb_frighte_02Dal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{
			// Validate input
			if (founderpcb_frighte_02==null)
				return 0;
				
			return founderpcb_frighte_02Dal.Delete(founderpcb_frighte_02);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			founderpcb_frighte_02Dal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 founderpcb_frighte_02 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>founderpcb_frighte_02 数据实体</returns>
		public FOUNDERPCB_FRIGHTE_02 getFOUNDERPCB_FRIGHTE_02ByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return founderpcb_frighte_02Dal.getFOUNDERPCB_FRIGHTE_02ByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表FOUNDERPCB_FRIGHTE_02所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< FOUNDERPCB_FRIGHTE_02>FindAllFOUNDERPCB_FRIGHTE_02()
		{
			// Use the dal to get all records 
			
			return founderpcb_frighte_02Dal.FindAllFOUNDERPCB_FRIGHTE_02();
		} 
		///<summary>
		///
		///</summary> 
		public IList< FOUNDERPCB_FRIGHTE_02> FindBySql(string sqlWhere)
		{ 
			return founderpcb_frighte_02Dal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return founderpcb_frighte_02Dal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            founderpcb_frighte_02Dal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

