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
    /// 业务层  FOUNDERPCB_GROUP_DBLL
    /// </summary>
    public partial class FOUNDERPCB_GROUP_DBLL
    {	
		FOUNDERPCB_GROUP_DDAL founderpcb_group_dDal=null;
		
		#region ----------构造函数---------- 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		public FOUNDERPCB_GROUP_DBLL(Form frm)
		{
			 founderpcb_group_dDal=new FOUNDERPCB_GROUP_DDAL(frm); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="frm">窗口</param> 
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_GROUP_DBLL(Form frm, int factoryID)
		{
			 founderpcb_group_dDal=new FOUNDERPCB_GROUP_DDAL(frm, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param>
		/// <param name="factoryID">操作厂别</param>
		public FOUNDERPCB_GROUP_DBLL(int Thread, int factoryID)
		{
			 founderpcb_group_dDal=new FOUNDERPCB_GROUP_DDAL(Thread, factoryID); 
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="Thread">数据库连接指针，0是保留，最大99</param> 
		public FOUNDERPCB_GROUP_DBLL(int Thread)
		{
			 founderpcb_group_dDal=new FOUNDERPCB_GROUP_DDAL(Thread); 
		} 
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="DB">DBHelper的实例</param> 
		public FOUNDERPCB_GROUP_DBLL(DBHelper DB)
		{
			 founderpcb_group_dDal=new FOUNDERPCB_GROUP_DDAL(DB); 
		}		
		#endregion

        #region ----------函数定义----------
		
		#region 添加更新删除
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_GROUP_D">founderpcb_group_d对象</param>
		/// <returns>新插入记录的编号</returns>
		public  int Add(FOUNDERPCB_GROUP_D founderpcb_group_d)
		{
			// Validate input
			if (founderpcb_group_d == null)
				return 0;
			
			return founderpcb_group_dDal.Add(founderpcb_group_d);
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_GROUP_D founderpcb_group_d)
		{
			// Validate input
			if (founderpcb_group_d == null)
				return 0;
			
			return founderpcb_group_dDal.Add(cmd, conn, trans, founderpcb_group_d); 			
		}	
		#endregion
		
		#region 更新
		/// <summary>
		/// 向数据表FOUNDERPCB_GROUP_D更新一条记录。
		/// </summary>
		/// <param name="oFOUNDERPCB_GROUP_DInfo">FOUNDERPCB_GROUP_D</param>
		/// <returns>影响的行数</returns>
		public int Update(FOUNDERPCB_GROUP_D founderpcb_group_d)
		{
            // Validate input
			if (founderpcb_group_d==null)
				return 0;
			
			return founderpcb_group_dDal.Update(founderpcb_group_d);
		} 
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_GROUP_D founderpcb_group_d)
		{
			// Validate input
			if (founderpcb_group_d==null)
				return ;
			
			founderpcb_group_dDal.Update(cmd, conn, trans, founderpcb_group_d);			
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除数据表FOUNDERPCB_GROUP_D中的一条记录
		/// </summary>
	    /// <param name="rKEY">rKEY</param>
		/// <returns>影响的行数</returns>
		public  int DeleteByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return 0;

			return founderpcb_group_dDal.DeleteByRKEY(rKEY);
		} 
		public  int Delete(FOUNDERPCB_GROUP_D founderpcb_group_d)
		{
			// Validate input
			if (founderpcb_group_d==null)
				return 0;
				
			return founderpcb_group_dDal.Delete(founderpcb_group_d);
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return ;
				
			founderpcb_group_dDal.Delete(cmd, conn, trans, rKEY);
		}
		#endregion
		
		#endregion
		
		#region 查询
        /// <summary>
		/// 得到 founderpcb_group_d 数据实体
		/// </summary>
		/// <param name="rKEY">rKEY</param>
		/// <returns>founderpcb_group_d 数据实体</returns>
		public FOUNDERPCB_GROUP_D getFOUNDERPCB_GROUP_DByRKEY(decimal rKEY)
		{
			// Validate input
			if(rKEY<0)
				return null;

			// Use the dal to get a record 
			
			return founderpcb_group_dDal.getFOUNDERPCB_GROUP_DByRKEY(rKEY);
		} 
		/// <summary>
		/// 得到数据表FOUNDERPCB_GROUP_D所有记录
		/// </summary>
		/// <returns>实体集</returns>
		public IList< FOUNDERPCB_GROUP_D>FindAllFOUNDERPCB_GROUP_D()
		{
			// Use the dal to get all records 
			
			return founderpcb_group_dDal.FindAllFOUNDERPCB_GROUP_D();
		} 
		///<summary>
		///
		///</summary> 
		public IList< FOUNDERPCB_GROUP_D> FindBySql(string sqlWhere)
		{ 
			return founderpcb_group_dDal.FindBySql(sqlWhere);
		}
		
		public DataTable getDataSet(string sql)
		{ 
			return founderpcb_group_dDal.getDataSet(sql);
		} 
        #endregion
		
		#region 关闭
        public void CloseConnection()
        {
            founderpcb_group_dDal.CloseConnection();
        }
        #endregion
		
		#endregion
    }
}

