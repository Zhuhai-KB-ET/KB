//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 16:02:28
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
	/// 数据访问层   DATA0498DAL
	/// </summary>
	public  partial class DATA0498DAL
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
		public 	DATA0498DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0498DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0498DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	DATA0498DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	DATA0498DAL(DBHelper DB)
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
		/// <param name="DATA0498">data0498对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(DATA0498 data0498)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_DATA0498_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@APPROVAL_ROUTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_STEP_NO",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_STEP_DESC",SqlDbType.VarChar,30)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=data0498.RKEY;
			       parameters[3].Value=data0498.APPROVAL_ROUTE_PTR;
			       parameters[4].Value=data0498.APPROVAL_STEP_NO;
			       parameters[5].Value=data0498.APPROVAL_STEP_DESC;
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				data0498.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0498,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0498 data0498)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0498(");
			strSql.Append("APPROVAL_ROUTE_PTR,APPROVAL_STEP_NO,APPROVAL_STEP_DESC");
			strSql.Append(" ) values (");
			strSql.Append("@APPROVAL_ROUTE_PTR,@APPROVAL_STEP_NO,@APPROVAL_STEP_DESC");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@APPROVAL_ROUTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_STEP_NO",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_STEP_DESC",SqlDbType.VarChar,30)
			};
			
			       parameters[0].Value=data0498.APPROVAL_ROUTE_PTR;
			       parameters[1].Value=data0498.APPROVAL_STEP_NO;
			       parameters[2].Value=data0498.APPROVAL_STEP_DESC;
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
		/// <param name="DATA0498">data0498对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(DATA0498 data0498)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_DATA0498_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_ROUTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_STEP_NO",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_STEP_DESC",SqlDbType.VarChar,30)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0498.RKEY;
			  		parameters[3].Value=data0498.APPROVAL_ROUTE_PTR;
			  		parameters[4].Value=data0498.APPROVAL_STEP_NO;
			  		parameters[5].Value=data0498.APPROVAL_STEP_DESC;
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0498,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0498 data0498)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update DATA0498 set "); 
			strSql.Append("APPROVAL_ROUTE_PTR=@APPROVAL_ROUTE_PTR,");
			strSql.Append("APPROVAL_STEP_NO=@APPROVAL_STEP_NO,");
			strSql.Append("APPROVAL_STEP_DESC=@APPROVAL_STEP_DESC");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_ROUTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_STEP_NO",SqlDbType.Decimal,9),
			new SqlParameter("@APPROVAL_STEP_DESC",SqlDbType.VarChar,30)
			};
			
			parameters[0].Value = data0498.RKEY;
			       parameters[1].Value=data0498.APPROVAL_ROUTE_PTR;
			       parameters[2].Value=data0498.APPROVAL_STEP_NO;
			       parameters[3].Value=data0498.APPROVAL_STEP_DESC;
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
		/// <param name="data0498">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(DATA0498 data0498)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_DATA0498_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0498.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0498,delete successful");
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
		/// <param name="data0498">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.DATA0498 where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0498,delete successful");
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
			strSql.Append("delete from data0498 ");
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
		///<returns>DATA0498对象</returns>		
		public DATA0498 getDATA0498ByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(approval_route_ptr,0) as approval_route_ptr
				,
				isNull(approval_step_no,0) as approval_step_no
				,
				isNull(approval_step_desc,'') as approval_step_desc
				
			from DATA0498 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			DATA0498  data0498=null;
			
			#region 数据库操作
            try
            {
				 data0498=new DATA0498();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    data0498.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							  	        data0498.APPROVAL_ROUTE_PTR =decimal.Parse(row["APPROVAL_ROUTE_PTR"].ToString());
							  	        data0498.APPROVAL_STEP_NO =decimal.Parse(row["APPROVAL_STEP_NO"].ToString());
								   data0498.APPROVAL_STEP_DESC =row["APPROVAL_STEP_DESC"].ToString();
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return data0498;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< DATA0498 >  FindAllDATA0498()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<DATA0498>数据集合</returns>		
		public IList< DATA0498> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(approval_route_ptr,0) as approval_route_ptr
				,
				isNull(approval_step_no,0) as approval_step_no
				,
				isNull(approval_step_desc,'') as approval_step_desc
				
			from DATA0498 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<DATA0498> resultList=new List<DATA0498>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							DATA0498  data0498 =new DATA0498();
							
								data0498.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
								  	data0498.APPROVAL_ROUTE_PTR =decimal.Parse(row["APPROVAL_ROUTE_PTR"].ToString()) ;
								  	data0498.APPROVAL_STEP_NO =decimal.Parse(row["APPROVAL_STEP_NO"].ToString()) ;
							      data0498.APPROVAL_STEP_DESC =row["APPROVAL_STEP_DESC"].ToString();
		
							resultList.Add(data0498);
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

