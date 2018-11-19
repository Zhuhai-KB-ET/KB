//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 15:57:06
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
	/// 数据访问层   DATA0001DAL
	/// </summary>
	public  partial class DATA0001DAL
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
		public 	DATA0001DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0001DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0001DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	DATA0001DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	DATA0001DAL(DBHelper DB)
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
		/// <param name="DATA0001">data0001对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(DATA0001 data0001)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_DATA0001_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@CURR_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@CURR_NAME",SqlDbType.VarChar,20),
			new SqlParameter("@EXCH_RATE",SqlDbType.Decimal,13),
			new SqlParameter("@TDATE",SqlDbType.DateTime,8),
			new SqlParameter("@TREADONLY",SqlDbType.Decimal,5),
			new SqlParameter("@BASE_TO_OTHER",SqlDbType.Decimal,13),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=data0001.RKEY;
			       parameters[3].Value=data0001.CURR_CODE;
			       parameters[4].Value=data0001.CURR_NAME;
			       parameters[5].Value=data0001.EXCH_RATE;
					if (data0001.TDATE == DateTime.Parse("1900-1-1") || data0001.TDATE == DateTime.Parse("0001-1-1"))
						parameters[6].Value = null;
					else
						parameters[6].Value=data0001.TDATE;				    
			       parameters[7].Value=data0001.TREADONLY;
			       parameters[8].Value=data0001.BASE_TO_OTHER;
			       parameters[9].Value=data0001.ACTIVE_FLAG;
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				data0001.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0001,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0001 data0001)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0001(");
			strSql.Append("CURR_CODE,CURR_NAME,EXCH_RATE,TDATE,TREADONLY,BASE_TO_OTHER,ACTIVE_FLAG");
			strSql.Append(" ) values (");
			strSql.Append("@CURR_CODE,@CURR_NAME,@EXCH_RATE,@TDATE,@TREADONLY,@BASE_TO_OTHER,@ACTIVE_FLAG");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@CURR_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@CURR_NAME",SqlDbType.VarChar,20),
			new SqlParameter("@EXCH_RATE",SqlDbType.Decimal,13),
			new SqlParameter("@TDATE",SqlDbType.DateTime,8),
			new SqlParameter("@TREADONLY",SqlDbType.Decimal,5),
			new SqlParameter("@BASE_TO_OTHER",SqlDbType.Decimal,13),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9)
			};
			
			       parameters[0].Value=data0001.CURR_CODE;
			       parameters[1].Value=data0001.CURR_NAME;
			       parameters[2].Value=data0001.EXCH_RATE;
					if (data0001.TDATE == DateTime.Parse("1900-1-1") || data0001.TDATE == DateTime.Parse("0001-1-1"))
						parameters[3].Value = null;
					else
						parameters[3].Value=data0001.TDATE;				    
			       parameters[4].Value=data0001.TREADONLY;
			       parameters[5].Value=data0001.BASE_TO_OTHER;
			       parameters[6].Value=data0001.ACTIVE_FLAG;
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
		/// <param name="DATA0001">data0001对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(DATA0001 data0001)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_DATA0001_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@CURR_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@CURR_NAME",SqlDbType.VarChar,20),
			new SqlParameter("@EXCH_RATE",SqlDbType.Decimal,13),
			new SqlParameter("@TDATE",SqlDbType.DateTime,8),
			new SqlParameter("@TREADONLY",SqlDbType.Decimal,5),
			new SqlParameter("@BASE_TO_OTHER",SqlDbType.Decimal,13),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0001.RKEY;
			  		parameters[3].Value=data0001.CURR_CODE;
			  		parameters[4].Value=data0001.CURR_NAME;
			  		parameters[5].Value=data0001.EXCH_RATE;
					if (data0001.TDATE == DateTime.Parse("1900-1-1") || data0001.TDATE == DateTime.Parse("0001-1-1"))
						parameters[6].Value = null;
					else
						parameters[6].Value=data0001.TDATE;				    
			  		parameters[7].Value=data0001.TREADONLY;
			  		parameters[8].Value=data0001.BASE_TO_OTHER;
			  		parameters[9].Value=data0001.ACTIVE_FLAG;
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0001,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0001 data0001)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update DATA0001 set "); 
			strSql.Append("CURR_CODE=@CURR_CODE,");
			strSql.Append("CURR_NAME=@CURR_NAME,");
			strSql.Append("EXCH_RATE=@EXCH_RATE,");
			strSql.Append("TDATE=@TDATE,");
			strSql.Append("TREADONLY=@TREADONLY,");
			strSql.Append("BASE_TO_OTHER=@BASE_TO_OTHER,");
			strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@CURR_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@CURR_NAME",SqlDbType.VarChar,20),
			new SqlParameter("@EXCH_RATE",SqlDbType.Decimal,13),
			new SqlParameter("@TDATE",SqlDbType.DateTime,8),
			new SqlParameter("@TREADONLY",SqlDbType.Decimal,5),
			new SqlParameter("@BASE_TO_OTHER",SqlDbType.Decimal,13),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9)
			};
			
			parameters[0].Value = data0001.RKEY;
			       parameters[1].Value=data0001.CURR_CODE;
			       parameters[2].Value=data0001.CURR_NAME;
			       parameters[3].Value=data0001.EXCH_RATE;
					if (data0001.TDATE == DateTime.Parse("1900-1-1") || data0001.TDATE == DateTime.Parse("0001-1-1"))
						parameters[4].Value = null;
					else
						parameters[4].Value=data0001.TDATE;				    
			       parameters[5].Value=data0001.TREADONLY;
			       parameters[6].Value=data0001.BASE_TO_OTHER;
			       parameters[7].Value=data0001.ACTIVE_FLAG;
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
		/// <param name="data0001">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(DATA0001 data0001)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_DATA0001_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0001.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0001,delete successful");
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
		/// <param name="data0001">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.DATA0001 where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0001,delete successful");
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
			strSql.Append("delete from data0001 ");
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
		///<returns>DATA0001对象</returns>		
		public DATA0001 getDATA0001ByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(curr_code,'') as curr_code
				,
				isNull(curr_name,'') as curr_name
				,
				isNull(exch_rate,0) as exch_rate
				,
				isNull(tdate,'1900-1-1') as tdate
				,
				isNull(treadonly,0) as treadonly
				,
				isNull(base_to_other,0) as base_to_other
				,
				isNull(active_flag,0) as active_flag
				
			from DATA0001 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			DATA0001  data0001=null;
			
			#region 数据库操作
            try
            {
				 data0001=new DATA0001();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    data0001.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
								   data0001.CURR_CODE =row["CURR_CODE"].ToString();
								   data0001.CURR_NAME =row["CURR_NAME"].ToString();
							  	        data0001.EXCH_RATE =decimal.Parse(row["EXCH_RATE"].ToString());
							  	        data0001.TDATE =DateTime.Parse(row["TDATE"].ToString());
							  	        data0001.TREADONLY =decimal.Parse(row["TREADONLY"].ToString());
							  	        data0001.BASE_TO_OTHER =decimal.Parse(row["BASE_TO_OTHER"].ToString());
							  	        data0001.ACTIVE_FLAG =decimal.Parse(row["ACTIVE_FLAG"].ToString());
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return data0001;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< DATA0001 >  FindAllDATA0001()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<DATA0001>数据集合</returns>		
		public IList< DATA0001> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(curr_code,'') as curr_code
				,
				isNull(curr_name,'') as curr_name
				,
				isNull(exch_rate,0) as exch_rate
				,
				isNull(tdate,'1900-1-1') as tdate
				,
				isNull(treadonly,0) as treadonly
				,
				isNull(base_to_other,0) as base_to_other
				,
				isNull(active_flag,0) as active_flag
				
			from DATA0001 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<DATA0001> resultList=new List<DATA0001>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							DATA0001  data0001 =new DATA0001();
							
								data0001.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
							      data0001.CURR_CODE =row["CURR_CODE"].ToString();
							      data0001.CURR_NAME =row["CURR_NAME"].ToString();
								  	data0001.EXCH_RATE =decimal.Parse(row["EXCH_RATE"].ToString()) ;
								  	data0001.TDATE =DateTime.Parse(row["TDATE"].ToString()) ;
								  	data0001.TREADONLY =decimal.Parse(row["TREADONLY"].ToString()) ;
								  	data0001.BASE_TO_OTHER =decimal.Parse(row["BASE_TO_OTHER"].ToString()) ;
								  	data0001.ACTIVE_FLAG =decimal.Parse(row["ACTIVE_FLAG"].ToString()) ;
		
							resultList.Add(data0001);
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

