using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KB.Models;
namespace KB.DAL
{
	/// <summary>
	/// 数据访问类Approval_Mode_3DAL。
	/// </summary>
	public partial class Approval_Mode_3DAL
	{
		
		#region   字段 and 属性
		DBHelper dbHelper = null;
		///<sumary>
		///字段 用于指定目标数据库
		///</sumary>
		private int factoryid = 0;

		///<sumary>
		///属性 用于指定目标数据库
		///</sumary>
		public int FactoryID
		{
				get
				{
						return this.factoryid;
				}
				set
				{
						this.factoryid = value;
				}
		}
		#endregion

		#region 构造方法
		public Approval_Mode_3DAL(DBHelper DB)
		{
				this.FactoryID =  DB.FactoryID;
				this.dbHelper = DB;
		}
		public Approval_Mode_3DAL(int factoryID)
		{
				this.FactoryID = factoryID;
				this.dbHelper = new DBHelper(factoryID);
		}
		#endregion 构造方法

		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return dbHelper.GetMaxID("RKEY", "Approval_Mode_3"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RKEY)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Approval_Mode_3 with(nolock) ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			return dbHelper.Exists(strSql.ToString(),parameters);
		}


		#region 增加
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Approval_Mode_3Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Approval_Mode_3(");
			strSql.Append("FILE_POINTER,SOURCE_TYPE,APPROVAL_STEP_NO,APPROVAL_STEP_DESC)");
			strSql.Append(" values (");
			strSql.Append("@FILE_POINTER,@SOURCE_TYPE,@APPROVAL_STEP_NO,@APPROVAL_STEP_DESC)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FILE_POINTER", SqlDbType.Int,4),
					new SqlParameter("@SOURCE_TYPE", SqlDbType.Int,4),
					new SqlParameter("@APPROVAL_STEP_NO", SqlDbType.Int,4),
					new SqlParameter("@APPROVAL_STEP_DESC", SqlDbType.VarChar,50)};
			parameters[0].Value = model.FILE_POINTER;
			parameters[1].Value = model.SOURCE_TYPE;
			parameters[2].Value = model.APPROVAL_STEP_NO;
			parameters[3].Value = model.APPROVAL_STEP_DESC;

			object obj = dbHelper.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,Approval_Mode_3Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Approval_Mode_3(");
			strSql.Append("FILE_POINTER,SOURCE_TYPE,APPROVAL_STEP_NO,APPROVAL_STEP_DESC)");
			strSql.Append(" values (");
			strSql.Append("@FILE_POINTER,@SOURCE_TYPE,@APPROVAL_STEP_NO,@APPROVAL_STEP_DESC)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FILE_POINTER", SqlDbType.Int,4),
					new SqlParameter("@SOURCE_TYPE", SqlDbType.Int,4),
					new SqlParameter("@APPROVAL_STEP_NO", SqlDbType.Int,4),
					new SqlParameter("@APPROVAL_STEP_DESC", SqlDbType.VarChar,50)};
			parameters[0].Value = model.FILE_POINTER;
			parameters[1].Value = model.SOURCE_TYPE;
			parameters[2].Value = model.APPROVAL_STEP_NO;
			parameters[3].Value = model.APPROVAL_STEP_DESC;

			return dbHelper.ExecuteTranByID(cmd,conn,trans,strSql.ToString(),parameters);
		}
		#endregion 增加

		#region 更新
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Approval_Mode_3Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Approval_Mode_3 set ");
			strSql.Append("FILE_POINTER=@FILE_POINTER,");
			strSql.Append("SOURCE_TYPE=@SOURCE_TYPE,");
			strSql.Append("APPROVAL_STEP_NO=@APPROVAL_STEP_NO,");
			strSql.Append("APPROVAL_STEP_DESC=@APPROVAL_STEP_DESC");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@FILE_POINTER", SqlDbType.Int,4),
					new SqlParameter("@SOURCE_TYPE", SqlDbType.Int,4),
					new SqlParameter("@APPROVAL_STEP_NO", SqlDbType.Int,4),
					new SqlParameter("@APPROVAL_STEP_DESC", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.FILE_POINTER;
			parameters[2].Value = model.SOURCE_TYPE;
			parameters[3].Value = model.APPROVAL_STEP_NO;
			parameters[4].Value = model.APPROVAL_STEP_DESC;

			dbHelper.ExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,Approval_Mode_3Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Approval_Mode_3 set ");
			strSql.Append("FILE_POINTER=@FILE_POINTER,");
			strSql.Append("SOURCE_TYPE=@SOURCE_TYPE,");
			strSql.Append("APPROVAL_STEP_NO=@APPROVAL_STEP_NO,");
			strSql.Append("APPROVAL_STEP_DESC=@APPROVAL_STEP_DESC");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@FILE_POINTER", SqlDbType.Int,4),
					new SqlParameter("@SOURCE_TYPE", SqlDbType.Int,4),
					new SqlParameter("@APPROVAL_STEP_NO", SqlDbType.Int,4),
					new SqlParameter("@APPROVAL_STEP_DESC", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.FILE_POINTER;
			parameters[2].Value = model.SOURCE_TYPE;
			parameters[3].Value = model.APPROVAL_STEP_NO;
			parameters[4].Value = model.APPROVAL_STEP_DESC;

			dbHelper.ExecuteTranByNone(cmd,conn,trans,strSql.ToString(),parameters);
		}

		#endregion 更新

		#region 删除
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Approval_Mode_3 ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			dbHelper.ExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Approval_Mode_3 ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			dbHelper.ExecuteTranByNone(cmd,conn,trans,strSql.ToString(),parameters);
		}

		#endregion 删除


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Approval_Mode_3Info GetModel(int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RKEY,FILE_POINTER,SOURCE_TYPE,APPROVAL_STEP_NO,APPROVAL_STEP_DESC from Approval_Mode_3 with(nolock)  ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			Approval_Mode_3Info model=new Approval_Mode_3Info();
			DataSet ds=dbHelper.GetDataSet2(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RKEY"].ToString()!="")
				{
					model.RKEY=int.Parse(ds.Tables[0].Rows[0]["RKEY"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FILE_POINTER"].ToString()!="")
				{
					model.FILE_POINTER=int.Parse(ds.Tables[0].Rows[0]["FILE_POINTER"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SOURCE_TYPE"].ToString()!="")
				{
					model.SOURCE_TYPE=int.Parse(ds.Tables[0].Rows[0]["SOURCE_TYPE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["APPROVAL_STEP_NO"].ToString()!="")
				{
					model.APPROVAL_STEP_NO=int.Parse(ds.Tables[0].Rows[0]["APPROVAL_STEP_NO"].ToString());
				}
				model.APPROVAL_STEP_DESC=ds.Tables[0].Rows[0]["APPROVAL_STEP_DESC"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RKEY,FILE_POINTER,SOURCE_TYPE,APPROVAL_STEP_NO,APPROVAL_STEP_DESC ");
			strSql.Append(" FROM Approval_Mode_3 with(nolock)  ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbHelper.GetDataSet2(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" RKEY,FILE_POINTER,SOURCE_TYPE,APPROVAL_STEP_NO,APPROVAL_STEP_DESC ");
			strSql.Append(" FROM Approval_Mode_3 with(nolock) ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return dbHelper.GetDataSet2(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Approval_Mode_3";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

