using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using KB.Model;
using KB.DAL;
namespace KB.BLL
{
	/// <summary>
	/// 业务逻辑类FOUNDERPCB_ANALYSISBLL 的摘要说明。
	/// </summary>
	public class FOUNDERPCB_ANALYSISBLL
	{
		private FOUNDERPCB_ANALYSISDAL dal=null;
		#region 构造方法
		public FOUNDERPCB_ANALYSISBLL(DBHelper DB)
		{
				dal=new FOUNDERPCB_ANALYSISDAL(DB);
		}
		public FOUNDERPCB_ANALYSISBLL(int factoryID)
		{
				dal=new FOUNDERPCB_ANALYSISDAL(factoryID);
		}
		#endregion
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RKEY)
		{
			return dal.Exists(RKEY);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(FOUNDERPCB_ANALYSIS model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,FOUNDERPCB_ANALYSIS model)
		{
			return dal.Add(cmd,conn,trans,model);
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(FOUNDERPCB_ANALYSIS model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,FOUNDERPCB_ANALYSIS model)
		{
			dal.Update(cmd,conn,trans,model);
		}


		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int RKEY)
		{
			
			dal.Delete(RKEY);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,int RKEY)
		{
			
			dal.Delete(cmd,conn,trans,RKEY);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FOUNDERPCB_ANALYSIS GetModel(int RKEY)
		{
			
			return dal.GetModel(RKEY);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FOUNDERPCB_ANALYSIS> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FOUNDERPCB_ANALYSIS> DataTableToList(DataTable dt)
		{
			List<FOUNDERPCB_ANALYSIS> modelList = new List<FOUNDERPCB_ANALYSIS>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FOUNDERPCB_ANALYSIS model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new FOUNDERPCB_ANALYSIS();
					if(dt.Rows[n]["RKEY"].ToString()!="")
					{
						model.RKEY=int.Parse(dt.Rows[n]["RKEY"].ToString());
					}
					model.SOURCE_CODE=dt.Rows[n]["SOURCE_CODE"].ToString();
					if(dt.Rows[n]["ID_KEY"].ToString()!="")
					{
						model.ID_KEY=int.Parse(dt.Rows[n]["ID_KEY"].ToString());
					}
					model.ANS_NAME=dt.Rows[n]["ANS_NAME"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

