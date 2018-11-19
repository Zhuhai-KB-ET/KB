//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 15:58:06
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
	/// 数据访问层   DATA0073DAL
	/// </summary>
	public  partial class DATA0073DAL
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
		public 	DATA0073DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0073DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0073DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	DATA0073DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	DATA0073DAL(DBHelper DB)
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
		/// <param name="DATA0073">data0073对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(DATA0073 data0073)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_DATA0073_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@USER_ID",SqlDbType.VarChar,5),
			new SqlParameter("@USER_FULL_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@USER_LOGIN_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@USER_PASSWORD",SqlDbType.Binary,12),
			new SqlParameter("@USER_STATION",SqlDbType.Decimal,9),
			new SqlParameter("@USER_GROUP_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@LANGUAGE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@GROUP_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DEF_PRINTER_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMPLOYEE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@NETWORK_ID",SqlDbType.VarChar,8),
			new SqlParameter("@NODE_ID",SqlDbType.VarChar,12),
			new SqlParameter("@SESSION_ID",SqlDbType.Decimal,9)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=data0073.RKEY;
			       parameters[3].Value=data0073.USER_ID;
			       parameters[4].Value=data0073.USER_FULL_NAME;
			       parameters[5].Value=data0073.USER_LOGIN_NAME;
			       parameters[6].Value=data0073.USER_PASSWORD;
			       parameters[7].Value=data0073.USER_STATION;
			       parameters[8].Value=data0073.USER_GROUP_FLAG;
			       parameters[9].Value=data0073.LANGUAGE_FLAG;
			       parameters[10].Value=data0073.GROUP_PTR;
			       parameters[11].Value=data0073.DEF_PRINTER_PTR;
			       parameters[12].Value=data0073.EMPLOYEE_PTR;
			       parameters[13].Value=data0073.NETWORK_ID;
			       parameters[14].Value=data0073.NODE_ID;
			       parameters[15].Value=data0073.SESSION_ID;
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				data0073.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0073,save successful");
            } 
            catch (Exception e)
            {
				///message ID
				result=2;
				log.Error("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e); 
            } 
			#endregion
			
			return result;
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0073 data0073)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0073(");
			strSql.Append("USER_ID,USER_FULL_NAME,USER_LOGIN_NAME,USER_PASSWORD,USER_STATION,USER_GROUP_FLAG,LANGUAGE_FLAG,GROUP_PTR,DEF_PRINTER_PTR,EMPLOYEE_PTR,NETWORK_ID,NODE_ID,SESSION_ID");
			strSql.Append(" ) values (");
			strSql.Append("@USER_ID,@USER_FULL_NAME,@USER_LOGIN_NAME,@USER_PASSWORD,@USER_STATION,@USER_GROUP_FLAG,@LANGUAGE_FLAG,@GROUP_PTR,@DEF_PRINTER_PTR,@EMPLOYEE_PTR,@NETWORK_ID,@NODE_ID,@SESSION_ID");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@USER_ID",SqlDbType.VarChar,5),
			new SqlParameter("@USER_FULL_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@USER_LOGIN_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@USER_PASSWORD",SqlDbType.Binary,12),
			new SqlParameter("@USER_STATION",SqlDbType.Decimal,9),
			new SqlParameter("@USER_GROUP_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@LANGUAGE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@GROUP_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DEF_PRINTER_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMPLOYEE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@NETWORK_ID",SqlDbType.VarChar,8),
			new SqlParameter("@NODE_ID",SqlDbType.VarChar,12),
			new SqlParameter("@SESSION_ID",SqlDbType.Decimal,9)
			};
			
			       parameters[0].Value=data0073.USER_ID;
			       parameters[1].Value=data0073.USER_FULL_NAME;
			       parameters[2].Value=data0073.USER_LOGIN_NAME;
			       parameters[3].Value=data0073.USER_PASSWORD;
			       parameters[4].Value=data0073.USER_STATION;
			       parameters[5].Value=data0073.USER_GROUP_FLAG;
			       parameters[6].Value=data0073.LANGUAGE_FLAG;
			       parameters[7].Value=data0073.GROUP_PTR;
			       parameters[8].Value=data0073.DEF_PRINTER_PTR;
			       parameters[9].Value=data0073.EMPLOYEE_PTR;
			       parameters[10].Value=data0073.NETWORK_ID;
			       parameters[11].Value=data0073.NODE_ID;
			       parameters[12].Value=data0073.SESSION_ID;
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
		/// <param name="DATA0073">data0073对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(DATA0073 data0073)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_DATA0073_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@USER_ID",SqlDbType.VarChar,5),
			new SqlParameter("@USER_FULL_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@USER_LOGIN_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@USER_PASSWORD",SqlDbType.Binary,12),
			new SqlParameter("@USER_STATION",SqlDbType.Decimal,9),
			new SqlParameter("@USER_GROUP_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@LANGUAGE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@GROUP_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DEF_PRINTER_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMPLOYEE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@NETWORK_ID",SqlDbType.VarChar,8),
			new SqlParameter("@NODE_ID",SqlDbType.VarChar,12),
			new SqlParameter("@SESSION_ID",SqlDbType.Decimal,9)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0073.RKEY;
			  		parameters[3].Value=data0073.USER_ID;
			  		parameters[4].Value=data0073.USER_FULL_NAME;
			  		parameters[5].Value=data0073.USER_LOGIN_NAME;
			  		parameters[6].Value=data0073.USER_PASSWORD;
			  		parameters[7].Value=data0073.USER_STATION;
			  		parameters[8].Value=data0073.USER_GROUP_FLAG;
			  		parameters[9].Value=data0073.LANGUAGE_FLAG;
			  		parameters[10].Value=data0073.GROUP_PTR;
			  		parameters[11].Value=data0073.DEF_PRINTER_PTR;
			  		parameters[12].Value=data0073.EMPLOYEE_PTR;
			  		parameters[13].Value=data0073.NETWORK_ID;
			  		parameters[14].Value=data0073.NODE_ID;
			  		parameters[15].Value=data0073.SESSION_ID;
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0073,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0073 data0073)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update DATA0073 set "); 
			strSql.Append("USER_ID=@USER_ID,");
			strSql.Append("USER_FULL_NAME=@USER_FULL_NAME,");
			strSql.Append("USER_LOGIN_NAME=@USER_LOGIN_NAME,");
			strSql.Append("USER_PASSWORD=@USER_PASSWORD,");
			strSql.Append("USER_STATION=@USER_STATION,");
			strSql.Append("USER_GROUP_FLAG=@USER_GROUP_FLAG,");
			strSql.Append("LANGUAGE_FLAG=@LANGUAGE_FLAG,");
			strSql.Append("GROUP_PTR=@GROUP_PTR,");
			strSql.Append("DEF_PRINTER_PTR=@DEF_PRINTER_PTR,");
			strSql.Append("EMPLOYEE_PTR=@EMPLOYEE_PTR,");
			strSql.Append("NETWORK_ID=@NETWORK_ID,");
			strSql.Append("NODE_ID=@NODE_ID,");
			strSql.Append("SESSION_ID=@SESSION_ID");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@USER_ID",SqlDbType.VarChar,5),
			new SqlParameter("@USER_FULL_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@USER_LOGIN_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@USER_PASSWORD",SqlDbType.Binary,12),
			new SqlParameter("@USER_STATION",SqlDbType.Decimal,9),
			new SqlParameter("@USER_GROUP_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@LANGUAGE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@GROUP_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DEF_PRINTER_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMPLOYEE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@NETWORK_ID",SqlDbType.VarChar,8),
			new SqlParameter("@NODE_ID",SqlDbType.VarChar,12),
			new SqlParameter("@SESSION_ID",SqlDbType.Decimal,9)
			};
			
			parameters[0].Value = data0073.RKEY;
			       parameters[1].Value=data0073.USER_ID;
			       parameters[2].Value=data0073.USER_FULL_NAME;
			       parameters[3].Value=data0073.USER_LOGIN_NAME;
			       parameters[4].Value=data0073.USER_PASSWORD;
			       parameters[5].Value=data0073.USER_STATION;
			       parameters[6].Value=data0073.USER_GROUP_FLAG;
			       parameters[7].Value=data0073.LANGUAGE_FLAG;
			       parameters[8].Value=data0073.GROUP_PTR;
			       parameters[9].Value=data0073.DEF_PRINTER_PTR;
			       parameters[10].Value=data0073.EMPLOYEE_PTR;
			       parameters[11].Value=data0073.NETWORK_ID;
			       parameters[12].Value=data0073.NODE_ID;
			       parameters[13].Value=data0073.SESSION_ID;
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
		/// <param name="data0073">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(DATA0073 data0073)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_DATA0073_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0073.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0073,delete successful");
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
		/// <param name="data0073">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.DATA0073 where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0073,delete successful");
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
			strSql.Append("delete from data0073 ");
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
		///<returns>DATA0073对象</returns>		
		public DATA0073 getDATA0073ByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(user_id,'') as user_id
				,
				isNull(user_full_name,'') as user_full_name
				,
				isNull(user_login_name,'') as user_login_name
				,
				isNull(user_password,0) as user_password
				,
				isNull(user_station,0) as user_station
				,
				isNull(user_group_flag,0) as user_group_flag
				,
				isNull(language_flag,'') as language_flag
				,
				isNull(group_ptr,0) as group_ptr
				,
				isNull(def_printer_ptr,0) as def_printer_ptr
				,
				isNull(employee_ptr,0) as employee_ptr
				,
				isNull(network_id,'') as network_id
				,
				isNull(node_id,'') as node_id
				,
				isNull(session_id,0) as session_id
				
			from DATA0073 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			DATA0073  data0073=null;
			
			#region 数据库操作
            try
            {
				 data0073=new DATA0073();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    data0073.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
								   data0073.USER_ID =row["USER_ID"].ToString();
								   data0073.USER_FULL_NAME =row["USER_FULL_NAME"].ToString();
								   data0073.USER_LOGIN_NAME =row["USER_LOGIN_NAME"].ToString();
                                   data0073.USER_PASSWORD = (Byte[])(row["USER_PASSWORD"]);									
							  	        data0073.USER_STATION =decimal.Parse(row["USER_STATION"].ToString());
							  	        data0073.USER_GROUP_FLAG =decimal.Parse(row["USER_GROUP_FLAG"].ToString());
								   data0073.LANGUAGE_FLAG =row["LANGUAGE_FLAG"].ToString();
							  	        data0073.GROUP_PTR =decimal.Parse(row["GROUP_PTR"].ToString());
							  	        data0073.DEF_PRINTER_PTR =decimal.Parse(row["DEF_PRINTER_PTR"].ToString());
							  	        data0073.EMPLOYEE_PTR =decimal.Parse(row["EMPLOYEE_PTR"].ToString());
								   data0073.NETWORK_ID =row["NETWORK_ID"].ToString();
								   data0073.NODE_ID =row["NODE_ID"].ToString();
							  	        data0073.SESSION_ID =decimal.Parse(row["SESSION_ID"].ToString());
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return data0073;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< DATA0073 >  FindAllDATA0073()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<DATA0073>数据集合</returns>		
		public IList< DATA0073> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(user_id,'') as user_id
				,
				isNull(user_full_name,'') as user_full_name
				,
				isNull(user_login_name,'') as user_login_name
				,
				isNull(user_password,0) as user_password
				,
				isNull(user_station,0) as user_station
				,
				isNull(user_group_flag,0) as user_group_flag
				,
				isNull(language_flag,'') as language_flag
				,
				isNull(group_ptr,0) as group_ptr
				,
				isNull(def_printer_ptr,0) as def_printer_ptr
				,
				isNull(employee_ptr,0) as employee_ptr
				,
				isNull(network_id,'') as network_id
				,
				isNull(node_id,'') as node_id
				,
				isNull(session_id,0) as session_id
				
			from DATA0073 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<DATA0073> resultList=new List<DATA0073>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							DATA0073  data0073 =new DATA0073();
							
								data0073.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
							      data0073.USER_ID =row["USER_ID"].ToString();
							      data0073.USER_FULL_NAME =row["USER_FULL_NAME"].ToString();
							      data0073.USER_LOGIN_NAME =row["USER_LOGIN_NAME"].ToString();
                                  data0073.USER_PASSWORD = (Byte[])(row["USER_PASSWORD"]);								
								  	data0073.USER_STATION =decimal.Parse(row["USER_STATION"].ToString()) ;
								  	data0073.USER_GROUP_FLAG =decimal.Parse(row["USER_GROUP_FLAG"].ToString()) ;
							      data0073.LANGUAGE_FLAG =row["LANGUAGE_FLAG"].ToString();
								  	data0073.GROUP_PTR =decimal.Parse(row["GROUP_PTR"].ToString()) ;
								  	data0073.DEF_PRINTER_PTR =decimal.Parse(row["DEF_PRINTER_PTR"].ToString()) ;
								  	data0073.EMPLOYEE_PTR =decimal.Parse(row["EMPLOYEE_PTR"].ToString()) ;
							      data0073.NETWORK_ID =row["NETWORK_ID"].ToString();
							      data0073.NODE_ID =row["NODE_ID"].ToString();
								  	data0073.SESSION_ID =decimal.Parse(row["SESSION_ID"].ToString()) ;
		
							resultList.Add(data0073);
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

