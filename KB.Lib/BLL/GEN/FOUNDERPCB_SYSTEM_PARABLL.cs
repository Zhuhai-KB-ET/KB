//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:06
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
    /// 业务层  FOUNDERPCB_SYSTEM_PARABLL
    /// </summary>
    public partial class FOUNDERPCB_SYSTEM_PARABLL
    {	
		FOUNDERPCB_SYSTEM_PARADAL founderpcb_system_paraDal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public FOUNDERPCB_SYSTEM_PARABLL(Form frm)
		{
			 founderpcb_system_paraDal=new FOUNDERPCB_SYSTEM_PARADAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_SYSTEM_PARABLL(Form frm, int factoryID)
		{
			 founderpcb_system_paraDal=new FOUNDERPCB_SYSTEM_PARADAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_SYSTEM_PARABLL(int Thread, int factoryID)
		{
			 founderpcb_system_paraDal=new FOUNDERPCB_SYSTEM_PARADAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public FOUNDERPCB_SYSTEM_PARABLL(int Thread)
		{
			 founderpcb_system_paraDal=new FOUNDERPCB_SYSTEM_PARADAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public FOUNDERPCB_SYSTEM_PARABLL(DBHelper DB)
		{
			 founderpcb_system_paraDal=new FOUNDERPCB_SYSTEM_PARADAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_SYSTEM_PARA">founderpcb_system_para对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{
			// Validate input
			if (founderpcb_system_para == null)
				return 0;
			
			return founderpcb_system_paraDal.Add(founderpcb_system_para);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{
			// Validate input
			if (founderpcb_system_para == null)
				return 0;
			
			return founderpcb_system_paraDal.Add(cmd, conn, trans, founderpcb_system_para); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表FOUNDERPCB_SYSTEM_PARA更新一条记录。
		/// </summary>
		/// <param name="oFOUNDERPCB_SYSTEM_PARAInfo">FOUNDERPCB_SYSTEM_PARA</param>
		/// <returns>影响的行数</returns>
		public int Update(FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{
            // Validate input
			if (founderpcb_system_para==null)
				return 0;
			
			return founderpcb_system_paraDal.Update(founderpcb_system_para);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{
			// Validate input
			if (founderpcb_system_para==null)
				return ;
			
			founderpcb_system_paraDal.Update(cmd, conn, trans, founderpcb_system_para);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表FOUNDERPCB_SYSTEM_PARA中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return founderpcb_system_paraDal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{
			// Validate input
			if (founderpcb_system_para==null)
				return 0;
				
			return founderpcb_system_paraDal.Delete(founderpcb_system_para);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			founderpcb_system_paraDal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 founderpcb_system_para 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>founderpcb_system_para 数据实体</returns>
		public FOUNDERPCB_SYSTEM_PARA getFOUNDERPCB_SYSTEM_PARAByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return founderpcb_system_paraDal.getFOUNDERPCB_SYSTEM_PARAByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表FOUNDERPCB_SYSTEM_PARA所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< FOUNDERPCB_SYSTEM_PARA>FindAllFOUNDERPCB_SYSTEM_PARA()
		{
			// Use the dal to get all records 
			
			return founderpcb_system_paraDal.FindAllFOUNDERPCB_SYSTEM_PARA();
		} 
		///<summary>
		///
		///</summary> 
		public IList< FOUNDERPCB_SYSTEM_PARA> FindBySql(string sqlWhere)
		{ 
			return founderpcb_system_paraDal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return founderpcb_system_paraDal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            founderpcb_system_paraDal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

