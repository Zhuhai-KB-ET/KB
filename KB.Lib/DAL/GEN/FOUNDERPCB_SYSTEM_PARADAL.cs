//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
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
	/// 数据访问层   FOUNDERPCB_SYSTEM_PARADAL
	/// </summary>
	public  partial class FOUNDERPCB_SYSTEM_PARADAL
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
		public 	FOUNDERPCB_SYSTEM_PARADAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_SYSTEM_PARADAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_SYSTEM_PARADAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	FOUNDERPCB_SYSTEM_PARADAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	FOUNDERPCB_SYSTEM_PARADAL(DBHelper DB)
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
		/// <param name="FOUNDERPCB_SYSTEM_PARA">founderpcb_system_para对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_FOUNDERPCB_SYSTEM_PARA_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@PARA_ID",SqlDbType.Int,4),
			new SqlParameter("@DESCRIPTION",SqlDbType.VarChar,30),
			new SqlParameter("@PARAMETER_VALUES",SqlDbType.VarChar,200),
			new SqlParameter("@CREATE_DATE",SqlDbType.DateTime,8)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=founderpcb_system_para.RKEY;
			       parameters[3].Value=founderpcb_system_para.PARA_ID;
			       parameters[4].Value=founderpcb_system_para.DESCRIPTION;
			       parameters[5].Value=founderpcb_system_para.PARAMETER_VALUES;
					if (founderpcb_system_para.CREATE_DATE == DateTime.Parse("1900-1-1") || founderpcb_system_para.CREATE_DATE == DateTime.Parse("0001-1-1"))
						parameters[6].Value = null;
					else
						parameters[6].Value=founderpcb_system_para.CREATE_DATE;				    
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				founderpcb_system_para.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_SYSTEM_PARA,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FOUNDERPCB_SYSTEM_PARA(");
			strSql.Append("PARA_ID,DESCRIPTION,PARAMETER_VALUES,CREATE_DATE");
			strSql.Append(" ) values (");
			strSql.Append("@PARA_ID,@DESCRIPTION,@PARAMETER_VALUES,@CREATE_DATE");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@PARA_ID",SqlDbType.Int,4),
			new SqlParameter("@DESCRIPTION",SqlDbType.VarChar,30),
			new SqlParameter("@PARAMETER_VALUES",SqlDbType.VarChar,200),
			new SqlParameter("@CREATE_DATE",SqlDbType.DateTime,8)
			};
			
			       parameters[0].Value=founderpcb_system_para.PARA_ID;
			       parameters[1].Value=founderpcb_system_para.DESCRIPTION;
			       parameters[2].Value=founderpcb_system_para.PARAMETER_VALUES;
					if (founderpcb_system_para.CREATE_DATE == DateTime.Parse("1900-1-1") || founderpcb_system_para.CREATE_DATE == DateTime.Parse("0001-1-1"))
						parameters[3].Value = null;
					else
						parameters[3].Value=founderpcb_system_para.CREATE_DATE;				    
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
		/// <param name="FOUNDERPCB_SYSTEM_PARA">founderpcb_system_para对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_FOUNDERPCB_SYSTEM_PARA_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@PARA_ID",SqlDbType.Int,4),
			new SqlParameter("@DESCRIPTION",SqlDbType.VarChar,30),
			new SqlParameter("@PARAMETER_VALUES",SqlDbType.VarChar,200),
			new SqlParameter("@CREATE_DATE",SqlDbType.DateTime,8)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_system_para.RKEY;
			  		parameters[3].Value=founderpcb_system_para.PARA_ID;
			  		parameters[4].Value=founderpcb_system_para.DESCRIPTION;
			  		parameters[5].Value=founderpcb_system_para.PARAMETER_VALUES;
					if (founderpcb_system_para.CREATE_DATE == DateTime.Parse("1900-1-1") || founderpcb_system_para.CREATE_DATE == DateTime.Parse("0001-1-1"))
						parameters[6].Value = null;
					else
						parameters[6].Value=founderpcb_system_para.CREATE_DATE;				    
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_SYSTEM_PARA,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update FOUNDERPCB_SYSTEM_PARA set "); 
			strSql.Append("PARA_ID=@PARA_ID,");
			strSql.Append("DESCRIPTION=@DESCRIPTION,");
			strSql.Append("PARAMETER_VALUES=@PARAMETER_VALUES,");
			strSql.Append("CREATE_DATE=@CREATE_DATE");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@PARA_ID",SqlDbType.Int,4),
			new SqlParameter("@DESCRIPTION",SqlDbType.VarChar,30),
			new SqlParameter("@PARAMETER_VALUES",SqlDbType.VarChar,200),
			new SqlParameter("@CREATE_DATE",SqlDbType.DateTime,8)
			};
			
			parameters[0].Value = founderpcb_system_para.RKEY;
			       parameters[1].Value=founderpcb_system_para.PARA_ID;
			       parameters[2].Value=founderpcb_system_para.DESCRIPTION;
			       parameters[3].Value=founderpcb_system_para.PARAMETER_VALUES;
					if (founderpcb_system_para.CREATE_DATE == DateTime.Parse("1900-1-1") || founderpcb_system_para.CREATE_DATE == DateTime.Parse("0001-1-1"))
						parameters[4].Value = null;
					else
						parameters[4].Value=founderpcb_system_para.CREATE_DATE;				    
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
		/// <param name="founderpcb_system_para">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(FOUNDERPCB_SYSTEM_PARA founderpcb_system_para)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_FOUNDERPCB_SYSTEM_PARA_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_system_para.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_SYSTEM_PARA,delete successful");
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
		/// <param name="founderpcb_system_para">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.FOUNDERPCB_SYSTEM_PARA where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_SYSTEM_PARA,delete successful");
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
			strSql.Append("delete from founderpcb_system_para ");
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
		///<returns>FOUNDERPCB_SYSTEM_PARA对象</returns>		
		public FOUNDERPCB_SYSTEM_PARA getFOUNDERPCB_SYSTEM_PARAByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(para_id,0) as para_id
				,
				isNull(description,'') as description
				,
				isNull(parameter_values,'') as parameter_values
				,
				isNull(create_date,'1900-1-1') as create_date
				
			from FOUNDERPCB_SYSTEM_PARA with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			FOUNDERPCB_SYSTEM_PARA  founderpcb_system_para=null;
			
			#region 数据库操作
            try
            {
				 founderpcb_system_para=new FOUNDERPCB_SYSTEM_PARA();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    founderpcb_system_para.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							  	        founderpcb_system_para.PARA_ID =int.Parse(row["PARA_ID"].ToString());
								   founderpcb_system_para.DESCRIPTION =row["DESCRIPTION"].ToString();
								   founderpcb_system_para.PARAMETER_VALUES =row["PARAMETER_VALUES"].ToString();
							  	        founderpcb_system_para.CREATE_DATE =DateTime.Parse(row["CREATE_DATE"].ToString());
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return founderpcb_system_para;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< FOUNDERPCB_SYSTEM_PARA >  FindAllFOUNDERPCB_SYSTEM_PARA()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<FOUNDERPCB_SYSTEM_PARA>数据集合</returns>		
		public IList< FOUNDERPCB_SYSTEM_PARA> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(para_id,0) as para_id
				,
				isNull(description,'') as description
				,
				isNull(parameter_values,'') as parameter_values
				,
				isNull(create_date,'1900-1-1') as create_date
				
			from FOUNDERPCB_SYSTEM_PARA with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<FOUNDERPCB_SYSTEM_PARA> resultList=new List<FOUNDERPCB_SYSTEM_PARA>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							FOUNDERPCB_SYSTEM_PARA  founderpcb_system_para =new FOUNDERPCB_SYSTEM_PARA();
							
								founderpcb_system_para.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
								  	founderpcb_system_para.PARA_ID =int.Parse(row["PARA_ID"].ToString()) ;
							      founderpcb_system_para.DESCRIPTION =row["DESCRIPTION"].ToString();
							      founderpcb_system_para.PARAMETER_VALUES =row["PARAMETER_VALUES"].ToString();
								  	founderpcb_system_para.CREATE_DATE =DateTime.Parse(row["CREATE_DATE"].ToString()) ;
		
							resultList.Add(founderpcb_system_para);
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

