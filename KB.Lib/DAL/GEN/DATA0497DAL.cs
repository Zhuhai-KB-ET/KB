//============================================================
// 项目名称:	    格力凯邦   ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2018,格力凯邦 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 16:02:27
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
	/// 数据访问层   DATA0497DAL
	/// </summary>
	public  partial class DATA0497DAL
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
		public 	DATA0497DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0497DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0497DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	DATA0497DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	DATA0497DAL(DBHelper DB)
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
		/// <param name="DATA0497">data0497对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(DATA0497 data0497)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_DATA0497_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@APPROVAL_ROUTE_CODE",SqlDbType.VarChar,10),
			new SqlParameter("@APPROVAL_ROUTE_DESC",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@APPROVAL_TYPE",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@FROM_VALUE",SqlDbType.Decimal,13),
			new SqlParameter("@TO_VALUE",SqlDbType.Decimal,13)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=data0497.RKEY;
			       parameters[3].Value=data0497.APPROVAL_ROUTE_CODE;
			       parameters[4].Value=data0497.APPROVAL_ROUTE_DESC;
			       parameters[5].Value=data0497.ABBR_NAME;
			       parameters[6].Value=data0497.APPROVAL_TYPE;
			       parameters[7].Value=data0497.ACTIVE_FLAG;
			       parameters[8].Value=data0497.FROM_VALUE;
			       parameters[9].Value=data0497.TO_VALUE;
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				data0497.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0497,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0497 data0497)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0497(");
			strSql.Append("APPROVAL_ROUTE_CODE,APPROVAL_ROUTE_DESC,ABBR_NAME,APPROVAL_TYPE,ACTIVE_FLAG,FROM_VALUE,TO_VALUE");
			strSql.Append(" ) values (");
			strSql.Append("@APPROVAL_ROUTE_CODE,@APPROVAL_ROUTE_DESC,@ABBR_NAME,@APPROVAL_TYPE,@ACTIVE_FLAG,@FROM_VALUE,@TO_VALUE");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@APPROVAL_ROUTE_CODE",SqlDbType.VarChar,10),
			new SqlParameter("@APPROVAL_ROUTE_DESC",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@APPROVAL_TYPE",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@FROM_VALUE",SqlDbType.Decimal,13),
			new SqlParameter("@TO_VALUE",SqlDbType.Decimal,13)
			};
			
			       parameters[0].Value=data0497.APPROVAL_ROUTE_CODE;
			       parameters[1].Value=data0497.APPROVAL_ROUTE_DESC;
			       parameters[2].Value=data0497.ABBR_NAME;
			       parameters[3].Value=data0497.APPROVAL_TYPE;
			       parameters[4].Value=data0497.ACTIVE_FLAG;
			       parameters[5].Value=data0497.FROM_VALUE;
			       parameters[6].Value=data0497.TO_VALUE;
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
		/// <param name="DATA0497">data0497对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(DATA0497 data0497)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_DATA0497_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_ROUTE_CODE",SqlDbType.VarChar,10),
			new SqlParameter("@APPROVAL_ROUTE_DESC",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@APPROVAL_TYPE",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@FROM_VALUE",SqlDbType.Decimal,13),
			new SqlParameter("@TO_VALUE",SqlDbType.Decimal,13)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0497.RKEY;
			  		parameters[3].Value=data0497.APPROVAL_ROUTE_CODE;
			  		parameters[4].Value=data0497.APPROVAL_ROUTE_DESC;
			  		parameters[5].Value=data0497.ABBR_NAME;
			  		parameters[6].Value=data0497.APPROVAL_TYPE;
			  		parameters[7].Value=data0497.ACTIVE_FLAG;
			  		parameters[8].Value=data0497.FROM_VALUE;
			  		parameters[9].Value=data0497.TO_VALUE;
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0497,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0497 data0497)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update DATA0497 set "); 
			strSql.Append("APPROVAL_ROUTE_CODE=@APPROVAL_ROUTE_CODE,");
			strSql.Append("APPROVAL_ROUTE_DESC=@APPROVAL_ROUTE_DESC,");
			strSql.Append("ABBR_NAME=@ABBR_NAME,");
			strSql.Append("APPROVAL_TYPE=@APPROVAL_TYPE,");
			strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG,");
			strSql.Append("FROM_VALUE=@FROM_VALUE,");
			strSql.Append("TO_VALUE=@TO_VALUE");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_ROUTE_CODE",SqlDbType.VarChar,10),
			new SqlParameter("@APPROVAL_ROUTE_DESC",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@APPROVAL_TYPE",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@FROM_VALUE",SqlDbType.Decimal,13),
			new SqlParameter("@TO_VALUE",SqlDbType.Decimal,13)
			};
			
			parameters[0].Value = data0497.RKEY;
			       parameters[1].Value=data0497.APPROVAL_ROUTE_CODE;
			       parameters[2].Value=data0497.APPROVAL_ROUTE_DESC;
			       parameters[3].Value=data0497.ABBR_NAME;
			       parameters[4].Value=data0497.APPROVAL_TYPE;
			       parameters[5].Value=data0497.ACTIVE_FLAG;
			       parameters[6].Value=data0497.FROM_VALUE;
			       parameters[7].Value=data0497.TO_VALUE;
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
		/// <param name="data0497">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(DATA0497 data0497)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_DATA0497_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0497.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0497,delete successful");
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
		/// <param name="data0497">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.DATA0497 where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0497,delete successful");
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
			strSql.Append("delete from data0497 ");
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
		///<returns>DATA0497对象</returns>		
		public DATA0497 getDATA0497ByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(approval_route_code,'') as approval_route_code
				,
				isNull(approval_route_desc,'') as approval_route_desc
				,
				isNull(abbr_name,'') as abbr_name
				,
				isNull(approval_type,0) as approval_type
				,
				isNull(active_flag,0) as active_flag
				,
				isNull(from_value,0) as from_value
				,
				isNull(to_value,0) as to_value
				
			from DATA0497 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			DATA0497  data0497=null;
			
			#region 数据库操作
            try
            {
				 data0497=new DATA0497();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    data0497.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
								   data0497.APPROVAL_ROUTE_CODE =row["APPROVAL_ROUTE_CODE"].ToString();
								   data0497.APPROVAL_ROUTE_DESC =row["APPROVAL_ROUTE_DESC"].ToString();
								   data0497.ABBR_NAME =row["ABBR_NAME"].ToString();
							  	        data0497.APPROVAL_TYPE =decimal.Parse(row["APPROVAL_TYPE"].ToString());
							  	        data0497.ACTIVE_FLAG =decimal.Parse(row["ACTIVE_FLAG"].ToString());
							  	        data0497.FROM_VALUE =decimal.Parse(row["FROM_VALUE"].ToString());
							  	        data0497.TO_VALUE =decimal.Parse(row["TO_VALUE"].ToString());
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return data0497;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< DATA0497 >  FindAllDATA0497()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<DATA0497>数据集合</returns>		
		public IList< DATA0497> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(approval_route_code,'') as approval_route_code
				,
				isNull(approval_route_desc,'') as approval_route_desc
				,
				isNull(abbr_name,'') as abbr_name
				,
				isNull(approval_type,0) as approval_type
				,
				isNull(active_flag,0) as active_flag
				,
				isNull(from_value,0) as from_value
				,
				isNull(to_value,0) as to_value
				
			from DATA0497 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<DATA0497> resultList=new List<DATA0497>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							DATA0497  data0497 =new DATA0497();
							
								data0497.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
							      data0497.APPROVAL_ROUTE_CODE =row["APPROVAL_ROUTE_CODE"].ToString();
							      data0497.APPROVAL_ROUTE_DESC =row["APPROVAL_ROUTE_DESC"].ToString();
							      data0497.ABBR_NAME =row["ABBR_NAME"].ToString();
								  	data0497.APPROVAL_TYPE =decimal.Parse(row["APPROVAL_TYPE"].ToString()) ;
								  	data0497.ACTIVE_FLAG =decimal.Parse(row["ACTIVE_FLAG"].ToString()) ;
								  	data0497.FROM_VALUE =decimal.Parse(row["FROM_VALUE"].ToString()) ;
								  	data0497.TO_VALUE =decimal.Parse(row["TO_VALUE"].ToString()) ;
		
							resultList.Add(data0497);
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

