using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using KB.Models;
using KB.DAL;
namespace KB.BLL
{
	/// <summary>
	/// 业务逻辑类RPT_MODULBLL 的摘要说明。
	/// </summary>
	public class RPT_MODULBLL
	{
		private RPT_MODULDAL dal=null;
		#region 构造方法
		public RPT_MODULBLL(DBHelper DB)
		{
				dal=new RPT_MODULDAL(DB);
		}
		public RPT_MODULBLL(int factoryID)
		{
				dal=new RPT_MODULDAL(factoryID);
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
		public int  Add(RPT_MODUL model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_MODUL model)
		{
			return dal.Add(cmd,conn,trans,model);
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RPT_MODUL model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_MODUL model)
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
		public RPT_MODUL GetModel(int RKEY)
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
		public List<RPT_MODUL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RPT_MODUL> DataTableToList(DataTable dt)
		{
			List<RPT_MODUL> modelList = new List<RPT_MODUL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RPT_MODUL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RPT_MODUL();
					if(dt.Rows[n]["RKEY"].ToString()!="")
					{
						model.RKEY=int.Parse(dt.Rows[n]["RKEY"].ToString());
					}
					model.MODUL_NAME=dt.Rows[n]["MODUL_NAME"].ToString();
					if(dt.Rows[n]["ACTIVE_FLAG"].ToString()!="")
					{
						model.ACTIVE_FLAG=int.Parse(dt.Rows[n]["ACTIVE_FLAG"].ToString());
					}
					if(dt.Rows[n]["EMP_PTR"].ToString()!="")
					{
						model.EMP_PTR=int.Parse(dt.Rows[n]["EMP_PTR"].ToString());
					}
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

