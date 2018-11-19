using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using KB.Models;
using KB.DAL;
namespace KB.BLL
{
	/// <summary>
	/// 业务逻辑类RPT_SETPARMBLL 的摘要说明。
	/// </summary>
	public class RPT_SETPARMBLL
	{
		private RPT_SETPARMDAL dal=null;
		#region 构造方法
		public RPT_SETPARMBLL(DBHelper DB)
		{
				dal=new RPT_SETPARMDAL(DB);
		}
		public RPT_SETPARMBLL(int factoryID)
		{
				dal=new RPT_SETPARMDAL(factoryID);
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
		public int  Add(RPT_SETPARM model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_SETPARM model)
		{
			return dal.Add(cmd,conn,trans,model);
		}


		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(RPT_SETPARM model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_SETPARM model)
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
		public RPT_SETPARM GetModel(int RKEY)
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
		public List<RPT_SETPARM> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RPT_SETPARM> DataTableToList(DataTable dt)
		{
			List<RPT_SETPARM> modelList = new List<RPT_SETPARM>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RPT_SETPARM model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RPT_SETPARM();
					if(dt.Rows[n]["RKEY"].ToString()!="")
					{
						model.RKEY=int.Parse(dt.Rows[n]["RKEY"].ToString());
					}
					if(dt.Rows[n]["SERVER_PTR"].ToString()!="")
					{
						model.SERVER_PTR=int.Parse(dt.Rows[n]["SERVER_PTR"].ToString());
					}
					if(dt.Rows[n]["MODUL_PTR"].ToString()!="")
					{
						model.MODUL_PTR=int.Parse(dt.Rows[n]["MODUL_PTR"].ToString());
					}
					model.TTYPE=dt.Rows[n]["TTYPE"].ToString();
					model.REPORT_PATH=dt.Rows[n]["REPORT_PATH"].ToString();
					model.REPORT_NAME=dt.Rows[n]["REPORT_NAME"].ToString();
					model.DISPLAY_NAME=dt.Rows[n]["DISPLAY_NAME"].ToString();
					model.REPORT_CODE=dt.Rows[n]["REPORT_CODE"].ToString();
					model.REPORT_PARM=dt.Rows[n]["REPORT_PARM"].ToString();
					if(dt.Rows[n]["QUICK_PRINT"].ToString()!="")
					{
						model.QUICK_PRINT=int.Parse(dt.Rows[n]["QUICK_PRINT"].ToString());
					}
					if(dt.Rows[n]["CHOOSE_PAYE"].ToString()!="")
					{
						model.CHOOSE_PAYE=int.Parse(dt.Rows[n]["CHOOSE_PAYE"].ToString());
					}
					if(dt.Rows[n]["MARGINS_TOP"].ToString()!="")
					{
						model.MARGINS_TOP=int.Parse(dt.Rows[n]["MARGINS_TOP"].ToString());
					}
					if(dt.Rows[n]["MARGINS_BUTTOM"].ToString()!="")
					{
						model.MARGINS_BUTTOM=int.Parse(dt.Rows[n]["MARGINS_BUTTOM"].ToString());
					}
					if(dt.Rows[n]["MARGINS_LEFT"].ToString()!="")
					{
						model.MARGINS_LEFT=int.Parse(dt.Rows[n]["MARGINS_LEFT"].ToString());
					}
					if(dt.Rows[n]["MARGINS_RIGHT"].ToString()!="")
					{
						model.MARGINS_RIGHT=int.Parse(dt.Rows[n]["MARGINS_RIGHT"].ToString());
					}
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

