//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 16:03:30
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
	/// 数据访问层   FOUNDERPCB_LOGIN_LOGDAL
	/// </summary>
	public  partial class FOUNDERPCB_LOGIN_LOGDAL
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
		public 	FOUNDERPCB_LOGIN_LOGDAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_LOGIN_LOGDAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_LOGIN_LOGDAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	FOUNDERPCB_LOGIN_LOGDAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	FOUNDERPCB_LOGIN_LOGDAL(DBHelper DB)
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
		/// <param name="FOUNDERPCB_LOGIN_LOG">founderpcb_login_log对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_FOUNDERPCB_LOGIN_LOG_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@LOGIN_ID",SqlDbType.VarChar,30),
			new SqlParameter("@LOGIN_NAME",SqlDbType.VarChar,20),
			new SqlParameter("@LOGIN_IP",SqlDbType.VarChar,20),
			new SqlParameter("@LOGIN_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@LOGIN_OUT",SqlDbType.DateTime,8)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=founderpcb_login_log.RKEY;
			       parameters[3].Value=founderpcb_login_log.PRO_RKEY;
			       parameters[4].Value=founderpcb_login_log.LOGIN_ID;
			       parameters[5].Value=founderpcb_login_log.LOGIN_NAME;
			       parameters[6].Value=founderpcb_login_log.LOGIN_IP;
					if (founderpcb_login_log.LOGIN_DATE == DateTime.Parse("1900-1-1") || founderpcb_login_log.LOGIN_DATE == DateTime.Parse("0001-1-1"))
						parameters[7].Value = null;
					else
						parameters[7].Value=founderpcb_login_log.LOGIN_DATE;				    
					if (founderpcb_login_log.LOGIN_OUT == DateTime.Parse("1900-1-1") || founderpcb_login_log.LOGIN_OUT == DateTime.Parse("0001-1-1"))
						parameters[8].Value = null;
					else
						parameters[8].Value=founderpcb_login_log.LOGIN_OUT;				    
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				founderpcb_login_log.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_LOGIN_LOG,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FOUNDERPCB_LOGIN_LOG(");
			strSql.Append("PRO_RKEY,LOGIN_ID,LOGIN_NAME,LOGIN_IP,LOGIN_DATE,LOGIN_OUT");
			strSql.Append(" ) values (");
			strSql.Append("@PRO_RKEY,@LOGIN_ID,@LOGIN_NAME,@LOGIN_IP,@LOGIN_DATE,@LOGIN_OUT");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@LOGIN_ID",SqlDbType.VarChar,30),
			new SqlParameter("@LOGIN_NAME",SqlDbType.VarChar,20),
			new SqlParameter("@LOGIN_IP",SqlDbType.VarChar,20),
			new SqlParameter("@LOGIN_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@LOGIN_OUT",SqlDbType.DateTime,8)
			};
			
			       parameters[0].Value=founderpcb_login_log.PRO_RKEY;
			       parameters[1].Value=founderpcb_login_log.LOGIN_ID;
			       parameters[2].Value=founderpcb_login_log.LOGIN_NAME;
			       parameters[3].Value=founderpcb_login_log.LOGIN_IP;
					if (founderpcb_login_log.LOGIN_DATE == DateTime.Parse("1900-1-1") || founderpcb_login_log.LOGIN_DATE == DateTime.Parse("0001-1-1"))
						parameters[4].Value = null;
					else
						parameters[4].Value=founderpcb_login_log.LOGIN_DATE;				    
					if (founderpcb_login_log.LOGIN_OUT == DateTime.Parse("1900-1-1") || founderpcb_login_log.LOGIN_OUT == DateTime.Parse("0001-1-1"))
						parameters[5].Value = null;
					else
						parameters[5].Value=founderpcb_login_log.LOGIN_OUT;				    
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
		/// <param name="FOUNDERPCB_LOGIN_LOG">founderpcb_login_log对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_FOUNDERPCB_LOGIN_LOG_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@LOGIN_ID",SqlDbType.VarChar,30),
			new SqlParameter("@LOGIN_NAME",SqlDbType.VarChar,20),
			new SqlParameter("@LOGIN_IP",SqlDbType.VarChar,20),
			new SqlParameter("@LOGIN_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@LOGIN_OUT",SqlDbType.DateTime,8)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_login_log.RKEY;
			  		parameters[3].Value=founderpcb_login_log.PRO_RKEY;
			  		parameters[4].Value=founderpcb_login_log.LOGIN_ID;
			  		parameters[5].Value=founderpcb_login_log.LOGIN_NAME;
			  		parameters[6].Value=founderpcb_login_log.LOGIN_IP;
					if (founderpcb_login_log.LOGIN_DATE == DateTime.Parse("1900-1-1") || founderpcb_login_log.LOGIN_DATE == DateTime.Parse("0001-1-1"))
						parameters[7].Value = null;
					else
						parameters[7].Value=founderpcb_login_log.LOGIN_DATE;				    
					if (founderpcb_login_log.LOGIN_OUT == DateTime.Parse("1900-1-1") || founderpcb_login_log.LOGIN_OUT == DateTime.Parse("0001-1-1"))
						parameters[8].Value = null;
					else
						parameters[8].Value=founderpcb_login_log.LOGIN_OUT;				    
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_LOGIN_LOG,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update FOUNDERPCB_LOGIN_LOG set "); 
			strSql.Append("PRO_RKEY=@PRO_RKEY,");
			strSql.Append("LOGIN_ID=@LOGIN_ID,");
			strSql.Append("LOGIN_NAME=@LOGIN_NAME,");
			strSql.Append("LOGIN_IP=@LOGIN_IP,");
			strSql.Append("LOGIN_DATE=@LOGIN_DATE,");
			strSql.Append("LOGIN_OUT=@LOGIN_OUT");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@LOGIN_ID",SqlDbType.VarChar,30),
			new SqlParameter("@LOGIN_NAME",SqlDbType.VarChar,20),
			new SqlParameter("@LOGIN_IP",SqlDbType.VarChar,20),
			new SqlParameter("@LOGIN_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@LOGIN_OUT",SqlDbType.DateTime,8)
			};
			
			parameters[0].Value = founderpcb_login_log.RKEY;
			       parameters[1].Value=founderpcb_login_log.PRO_RKEY;
			       parameters[2].Value=founderpcb_login_log.LOGIN_ID;
			       parameters[3].Value=founderpcb_login_log.LOGIN_NAME;
			       parameters[4].Value=founderpcb_login_log.LOGIN_IP;
					if (founderpcb_login_log.LOGIN_DATE == DateTime.Parse("1900-1-1") || founderpcb_login_log.LOGIN_DATE == DateTime.Parse("0001-1-1"))
						parameters[5].Value = null;
					else
						parameters[5].Value=founderpcb_login_log.LOGIN_DATE;				    
					if (founderpcb_login_log.LOGIN_OUT == DateTime.Parse("1900-1-1") || founderpcb_login_log.LOGIN_OUT == DateTime.Parse("0001-1-1"))
						parameters[6].Value = null;
					else
						parameters[6].Value=founderpcb_login_log.LOGIN_OUT;				    
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
		/// <param name="founderpcb_login_log">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(FOUNDERPCB_LOGIN_LOG founderpcb_login_log)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_FOUNDERPCB_LOGIN_LOG_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_login_log.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_LOGIN_LOG,delete successful");
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
		/// <param name="founderpcb_login_log">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.FOUNDERPCB_LOGIN_LOG where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_LOGIN_LOG,delete successful");
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
			strSql.Append("delete from founderpcb_login_log ");
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
		///<returns>FOUNDERPCB_LOGIN_LOG对象</returns>		
		public FOUNDERPCB_LOGIN_LOG getFOUNDERPCB_LOGIN_LOGByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(pro_rkey,0) as pro_rkey
				,
				isNull(login_id,'') as login_id
				,
				isNull(login_name,'') as login_name
				,
				isNull(login_ip,'') as login_ip
				,
				isNull(login_date,'1900-1-1') as login_date
				,
				isNull(login_out,'1900-1-1') as login_out
				
			from FOUNDERPCB_LOGIN_LOG with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			FOUNDERPCB_LOGIN_LOG  founderpcb_login_log=null;
			
			#region 数据库操作
            try
            {
				 founderpcb_login_log=new FOUNDERPCB_LOGIN_LOG();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    founderpcb_login_log.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							  	        founderpcb_login_log.PRO_RKEY =decimal.Parse(row["PRO_RKEY"].ToString());
								   founderpcb_login_log.LOGIN_ID =row["LOGIN_ID"].ToString();
								   founderpcb_login_log.LOGIN_NAME =row["LOGIN_NAME"].ToString();
								   founderpcb_login_log.LOGIN_IP =row["LOGIN_IP"].ToString();
							  	        founderpcb_login_log.LOGIN_DATE =DateTime.Parse(row["LOGIN_DATE"].ToString());
							  	        founderpcb_login_log.LOGIN_OUT =DateTime.Parse(row["LOGIN_OUT"].ToString());
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return founderpcb_login_log;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< FOUNDERPCB_LOGIN_LOG >  FindAllFOUNDERPCB_LOGIN_LOG()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<FOUNDERPCB_LOGIN_LOG>数据集合</returns>		
		public IList< FOUNDERPCB_LOGIN_LOG> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(pro_rkey,0) as pro_rkey
				,
				isNull(login_id,'') as login_id
				,
				isNull(login_name,'') as login_name
				,
				isNull(login_ip,'') as login_ip
				,
				isNull(login_date,'1900-1-1') as login_date
				,
				isNull(login_out,'1900-1-1') as login_out
				
			from FOUNDERPCB_LOGIN_LOG with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<FOUNDERPCB_LOGIN_LOG> resultList=new List<FOUNDERPCB_LOGIN_LOG>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							FOUNDERPCB_LOGIN_LOG  founderpcb_login_log =new FOUNDERPCB_LOGIN_LOG();
							
								founderpcb_login_log.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
								  	founderpcb_login_log.PRO_RKEY =decimal.Parse(row["PRO_RKEY"].ToString()) ;
							      founderpcb_login_log.LOGIN_ID =row["LOGIN_ID"].ToString();
							      founderpcb_login_log.LOGIN_NAME =row["LOGIN_NAME"].ToString();
							      founderpcb_login_log.LOGIN_IP =row["LOGIN_IP"].ToString();
								  	founderpcb_login_log.LOGIN_DATE =DateTime.Parse(row["LOGIN_DATE"].ToString()) ;
								  	founderpcb_login_log.LOGIN_OUT =DateTime.Parse(row["LOGIN_OUT"].ToString()) ;
		
							resultList.Add(founderpcb_login_log);
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

