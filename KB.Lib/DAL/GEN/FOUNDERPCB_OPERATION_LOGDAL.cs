﻿//============================================================
// 项目名称:	    格力凯邦   ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2018,格力凯邦 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 16:03:31
//============================================================


using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using KB.Models;
using KB.FUNC;
using System.Configuration;

namespace KB.DAL
{
	/// <summary>
	/// 数据访问层   FOUNDERPCB_OPERATION_LOGDAL
	/// </summary>
	public  partial class FOUNDERPCB_OPERATION_LOGDAL
	{ 
		#region   字段 and 属性
		DBHelper  dbHelper=null;  
		private int factoryID=0; 
		private string userAD=String.Empty; 
		public int FactoryID{
			get{
				return this.factoryID;
			}	
			set{
				this.factoryID=value;	
			}
		} 
		public string UserAD{
			get{
				return this.userAD;
			}	
			set{
				this.userAD=value;	
			}
		}
	    #endregion
		
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary> 
		public 	FOUNDERPCB_OPERATION_LOGDAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_OPERATION_LOGDAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_OPERATION_LOGDAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	FOUNDERPCB_OPERATION_LOGDAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	FOUNDERPCB_OPERATION_LOGDAL(DBHelper DB)
        {
            this.FactoryID = DB.FactoryID;
            this.UserAD    = GlobalVal.UserInfo.LoginName;
            this.dbHelper  = DB;
        } 
		#endregion
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_OPERATION_LOG">founderpcb_operation_log对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(FOUNDERPCB_OPERATION_LOG founderpcb_operation_log)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_FOUNDERPCB_OPERATION_LOG_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@MODULE_ID",SqlDbType.VarChar,10),
			new SqlParameter("@MODULE_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ACTION",SqlDbType.VarChar,30),
			new SqlParameter("@MEMO",SqlDbType.VarChar,1000),
			new SqlParameter("@DO_DATE",SqlDbType.DateTime,8)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=founderpcb_operation_log.RKEY;
			       parameters[3].Value=founderpcb_operation_log.PRO_RKEY;
			       parameters[4].Value=founderpcb_operation_log.MODULE_ID;
			       parameters[5].Value=founderpcb_operation_log.MODULE_NAME;
			       parameters[6].Value=founderpcb_operation_log.ACTION;
			       parameters[7].Value=founderpcb_operation_log.MEMO;
					if (founderpcb_operation_log.DO_DATE == DateTime.Parse("1900-1-1") || founderpcb_operation_log.DO_DATE == DateTime.Parse("0001-1-1"))
						parameters[8].Value = null;
					else
						parameters[8].Value=founderpcb_operation_log.DO_DATE;				    
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				founderpcb_operation_log.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
				//log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_OPERATION_LOG,save successful");
            } 
            catch (Exception e)
            {
				///message ID
				result=2;
			//	log.Error("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e); 
            } 
			#endregion
			
			return result;
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_OPERATION_LOG founderpcb_operation_log)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FOUNDERPCB_OPERATION_LOG(");
			strSql.Append("PRO_RKEY,MODULE_ID,MODULE_NAME,ACTION,MEMO,DO_DATE");
			strSql.Append(" ) values (");
			strSql.Append("@PRO_RKEY,@MODULE_ID,@MODULE_NAME,@ACTION,@MEMO,@DO_DATE");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@MODULE_ID",SqlDbType.VarChar,10),
			new SqlParameter("@MODULE_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ACTION",SqlDbType.VarChar,30),
			new SqlParameter("@MEMO",SqlDbType.VarChar,1000),
			new SqlParameter("@DO_DATE",SqlDbType.DateTime,8)
			};
			
			       parameters[0].Value=founderpcb_operation_log.PRO_RKEY;
			       parameters[1].Value=founderpcb_operation_log.MODULE_ID;
			       parameters[2].Value=founderpcb_operation_log.MODULE_NAME;
			       parameters[3].Value=founderpcb_operation_log.ACTION;
			       parameters[4].Value=founderpcb_operation_log.MEMO;
					if (founderpcb_operation_log.DO_DATE == DateTime.Parse("1900-1-1") || founderpcb_operation_log.DO_DATE == DateTime.Parse("0001-1-1"))
						parameters[5].Value = null;
					else
						parameters[5].Value=founderpcb_operation_log.DO_DATE;				    
			#endregion
			
			#region 操作
			if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = strSql.ToString();
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            int indentity = 0;
            object obj = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                indentity = 0;
            }
            else
            {
                indentity = int.Parse(obj.ToString());
            }
			#endregion
			
            return indentity;
		}
		#endregion
		
		#region 修改
		///<sumary>
		///修改  
		///</sumary>
		/// <param name="FOUNDERPCB_OPERATION_LOG">founderpcb_operation_log对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(FOUNDERPCB_OPERATION_LOG founderpcb_operation_log)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_FOUNDERPCB_OPERATION_LOG_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@MODULE_ID",SqlDbType.VarChar,10),
			new SqlParameter("@MODULE_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ACTION",SqlDbType.VarChar,30),
			new SqlParameter("@MEMO",SqlDbType.VarChar,1000),
			new SqlParameter("@DO_DATE",SqlDbType.DateTime,8)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_operation_log.RKEY;
			  		parameters[3].Value=founderpcb_operation_log.PRO_RKEY;
			  		parameters[4].Value=founderpcb_operation_log.MODULE_ID;
			  		parameters[5].Value=founderpcb_operation_log.MODULE_NAME;
			  		parameters[6].Value=founderpcb_operation_log.ACTION;
			  		parameters[7].Value=founderpcb_operation_log.MEMO;
					if (founderpcb_operation_log.DO_DATE == DateTime.Parse("1900-1-1") || founderpcb_operation_log.DO_DATE == DateTime.Parse("0001-1-1"))
						parameters[8].Value = null;
					else
						parameters[8].Value=founderpcb_operation_log.DO_DATE;				    
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_OPERATION_LOG,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_OPERATION_LOG founderpcb_operation_log)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update FOUNDERPCB_OPERATION_LOG set "); 
			strSql.Append("PRO_RKEY=@PRO_RKEY,");
			strSql.Append("MODULE_ID=@MODULE_ID,");
			strSql.Append("MODULE_NAME=@MODULE_NAME,");
			strSql.Append("ACTION=@ACTION,");
			strSql.Append("MEMO=@MEMO,");
			strSql.Append("DO_DATE=@DO_DATE");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@MODULE_ID",SqlDbType.VarChar,10),
			new SqlParameter("@MODULE_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ACTION",SqlDbType.VarChar,30),
			new SqlParameter("@MEMO",SqlDbType.VarChar,1000),
			new SqlParameter("@DO_DATE",SqlDbType.DateTime,8)
			};
			
			parameters[0].Value = founderpcb_operation_log.RKEY;
			       parameters[1].Value=founderpcb_operation_log.PRO_RKEY;
			       parameters[2].Value=founderpcb_operation_log.MODULE_ID;
			       parameters[3].Value=founderpcb_operation_log.MODULE_NAME;
			       parameters[4].Value=founderpcb_operation_log.ACTION;
			       parameters[5].Value=founderpcb_operation_log.MEMO;
					if (founderpcb_operation_log.DO_DATE == DateTime.Parse("1900-1-1") || founderpcb_operation_log.DO_DATE == DateTime.Parse("0001-1-1"))
						parameters[6].Value = null;
					else
						parameters[6].Value=founderpcb_operation_log.DO_DATE;				    
			#endregion
			
			#region 操作
			 if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = strSql.ToString();
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            cmd.ExecuteNonQuery();            
            cmd.Parameters.Clear();    
			#endregion
			
		} 
		#endregion
		
		#region 删除
		///<sumary>
		/// 删除  
		///</sumary>
		/// <param name="founderpcb_operation_log">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(FOUNDERPCB_OPERATION_LOG founderpcb_operation_log)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_FOUNDERPCB_OPERATION_LOG_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_operation_log.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_OPERATION_LOG,delete successful");
            }
            catch (Exception e)
            {
				result=2;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
            } 
			#endregion
			
			return result;							
		} 
		///<sumary>
		/// 删除  
		///</sumary>
		/// <param name="founderpcb_operation_log">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.FOUNDERPCB_OPERATION_LOG where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_OPERATION_LOG,delete successful");
            }
            catch (Exception e)
            {
                result=2;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				throw e;
            } 
			#endregion
			
			return result;							
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rkey)
		{
			#region 创建语法
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from founderpcb_operation_log ");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters = {new SqlParameter("@RKEY",SqlDbType.Decimal,9)};				
			parameters[0].Value=rkey;
			#endregion
			
			#region 操作
			if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = strSql.ToString();
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
			#endregion			
		}
		#endregion
		
		#region 查
		///<sumary>
		///	通过主键获取数据对象
		///</sumary>
		/// <param name="RKEY">rkey</param>
		///<returns>FOUNDERPCB_OPERATION_LOG对象</returns>		
		public FOUNDERPCB_OPERATION_LOG getFOUNDERPCB_OPERATION_LOGByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(pro_rkey,0) as pro_rkey
				,
				isNull(module_id,'') as module_id
				,
				isNull(module_name,'') as module_name
				,
				isNull(action,'') as action
				,
				isNull(memo,'') as memo
				,
				isNull(do_date,'1900-1-1') as do_date
				
			from FOUNDERPCB_OPERATION_LOG with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			FOUNDERPCB_OPERATION_LOG  founderpcb_operation_log=null;
			
			#region 数据库操作
            try
            {
				 founderpcb_operation_log=new FOUNDERPCB_OPERATION_LOG();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    founderpcb_operation_log.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							  	        founderpcb_operation_log.PRO_RKEY =decimal.Parse(row["PRO_RKEY"].ToString());
								   founderpcb_operation_log.MODULE_ID =row["MODULE_ID"].ToString();
								   founderpcb_operation_log.MODULE_NAME =row["MODULE_NAME"].ToString();
								   founderpcb_operation_log.ACTION =row["ACTION"].ToString();
								   founderpcb_operation_log.MEMO =row["MEMO"].ToString();
							  	        founderpcb_operation_log.DO_DATE =DateTime.Parse(row["DO_DATE"].ToString());
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return founderpcb_operation_log;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< FOUNDERPCB_OPERATION_LOG >  FindAllFOUNDERPCB_OPERATION_LOG()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<FOUNDERPCB_OPERATION_LOG>数据集合</returns>		
		public IList< FOUNDERPCB_OPERATION_LOG> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(pro_rkey,0) as pro_rkey
				,
				isNull(module_id,'') as module_id
				,
				isNull(module_name,'') as module_name
				,
				isNull(action,'') as action
				,
				isNull(memo,'') as memo
				,
				isNull(do_date,'1900-1-1') as do_date
				
			from FOUNDERPCB_OPERATION_LOG with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<FOUNDERPCB_OPERATION_LOG> resultList=new List<FOUNDERPCB_OPERATION_LOG>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							FOUNDERPCB_OPERATION_LOG  founderpcb_operation_log =new FOUNDERPCB_OPERATION_LOG();
							
								founderpcb_operation_log.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
								  	founderpcb_operation_log.PRO_RKEY =decimal.Parse(row["PRO_RKEY"].ToString()) ;
							      founderpcb_operation_log.MODULE_ID =row["MODULE_ID"].ToString();
							      founderpcb_operation_log.MODULE_NAME =row["MODULE_NAME"].ToString();
							      founderpcb_operation_log.ACTION =row["ACTION"].ToString();
							      founderpcb_operation_log.MEMO =row["MEMO"].ToString();
								  	founderpcb_operation_log.DO_DATE =DateTime.Parse(row["DO_DATE"].ToString()) ;
		
							resultList.Add(founderpcb_operation_log);
					}
				}
            }
            catch (Exception e)
            { 
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FindBySql function:"+e.Message,e);
				throw e;
            } 
			#endregion
			
			return resultList;			
		} 
		///<sumary>
		///	通过SQL语句获取数据
		///</sumary>
		/// <param name="sql">sql语句</param>
		///<returns>DataTable</returns> 
		public  DataTable getDataSet(string sql)
		{
			DataTable dt=null;
			try{
			dt=dbHelper.GetDataSet(sql);
			}catch(Exception e)
			{
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";getDataSet function:"+e.Message,e);
				throw e;
			} 
			return dt; 
		} 
		#endregion
		
		#region 关闭
        public void CloseConnection()
        {
            this.dbHelper.CloseConnection();
        }
        #endregion
    } 
} 

