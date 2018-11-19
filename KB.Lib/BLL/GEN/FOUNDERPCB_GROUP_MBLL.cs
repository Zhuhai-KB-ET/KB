//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:04
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
    /// 业务层  FOUNDERPCB_GROUP_MBLL
    /// </summary>
    public partial class FOUNDERPCB_GROUP_MBLL
    {	
		FOUNDERPCB_GROUP_MDAL founderpcb_group_mDal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public FOUNDERPCB_GROUP_MBLL(Form frm)
		{
			 founderpcb_group_mDal=new FOUNDERPCB_GROUP_MDAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_GROUP_MBLL(Form frm, int factoryID)
		{
			 founderpcb_group_mDal=new FOUNDERPCB_GROUP_MDAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_GROUP_MBLL(int Thread, int factoryID)
		{
			 founderpcb_group_mDal=new FOUNDERPCB_GROUP_MDAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public FOUNDERPCB_GROUP_MBLL(int Thread)
		{
			 founderpcb_group_mDal=new FOUNDERPCB_GROUP_MDAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public FOUNDERPCB_GROUP_MBLL(DBHelper DB)
		{
			 founderpcb_group_mDal=new FOUNDERPCB_GROUP_MDAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_GROUP_M">founderpcb_group_m对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(FOUNDERPCB_GROUP_M founderpcb_group_m)
		{
			// Validate input
			if (founderpcb_group_m == null)
				return 0;
			
			return founderpcb_group_mDal.Add(founderpcb_group_m);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_GROUP_M founderpcb_group_m)
		{
			// Validate input
			if (founderpcb_group_m == null)
				return 0;
			
			return founderpcb_group_mDal.Add(cmd, conn, trans, founderpcb_group_m); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表FOUNDERPCB_GROUP_M更新一条记录。
		/// </summary>
		/// <param name="oFOUNDERPCB_GROUP_MInfo">FOUNDERPCB_GROUP_M</param>
		/// <returns>影响的行数</returns>
		public int Update(FOUNDERPCB_GROUP_M founderpcb_group_m)
		{
            // Validate input
			if (founderpcb_group_m==null)
				return 0;
			
			return founderpcb_group_mDal.Update(founderpcb_group_m);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_GROUP_M founderpcb_group_m)
		{
			// Validate input
			if (founderpcb_group_m==null)
				return ;
			
			founderpcb_group_mDal.Update(cmd, conn, trans, founderpcb_group_m);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表FOUNDERPCB_GROUP_M中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return founderpcb_group_mDal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(FOUNDERPCB_GROUP_M founderpcb_group_m)
		{
			// Validate input
			if (founderpcb_group_m==null)
				return 0;
				
			return founderpcb_group_mDal.Delete(founderpcb_group_m);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			founderpcb_group_mDal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 founderpcb_group_m 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>founderpcb_group_m 数据实体</returns>
		public FOUNDERPCB_GROUP_M getFOUNDERPCB_GROUP_MByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return founderpcb_group_mDal.getFOUNDERPCB_GROUP_MByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表FOUNDERPCB_GROUP_M所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< FOUNDERPCB_GROUP_M>FindAllFOUNDERPCB_GROUP_M()
		{
			// Use the dal to get all records 
			
			return founderpcb_group_mDal.FindAllFOUNDERPCB_GROUP_M();
		} 
		///<summary>
		///
		///</summary> 
		public IList< FOUNDERPCB_GROUP_M> FindBySql(string sqlWhere)
		{ 
			return founderpcb_group_mDal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return founderpcb_group_mDal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            founderpcb_group_mDal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

