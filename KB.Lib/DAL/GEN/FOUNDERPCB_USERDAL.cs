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
	/// 数据访问层   FOUNDERPCB_USERDAL
	/// </summary>
	public  partial class FOUNDERPCB_USERDAL
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
		public 	FOUNDERPCB_USERDAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_USERDAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_USERDAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	FOUNDERPCB_USERDAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	FOUNDERPCB_USERDAL(DBHelper DB)
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
		/// <param name="FOUNDERPCB_USER">founderpcb_user对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(FOUNDERPCB_USER founderpcb_user)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_FOUNDERPCB_USER_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@LOGIN_ID",SqlDbType.VarChar,30),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@NAME",SqlDbType.VarChar,20),
			new SqlParameter("@DEPT",SqlDbType.VarChar,100),
			new SqlParameter("@POSITION",SqlDbType.VarChar,30),
			new SqlParameter("@TEL_NUMBER",SqlDbType.VarChar,30),
			new SqlParameter("@MOBILE",SqlDbType.VarChar,30),
			new SqlParameter("@ADDR",SqlDbType.VarChar,200),
			new SqlParameter("@DATA0073RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@ROLE",SqlDbType.Int,4),
			new SqlParameter("@SYS_VERSION",SqlDbType.VarChar,20),
			new SqlParameter("@CREATE_DATE",SqlDbType.DateTime,8)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=founderpcb_user.RKEY;
			       parameters[3].Value=founderpcb_user.LOGIN_ID;
			       parameters[4].Value=founderpcb_user.PRO_RKEY;
			       parameters[5].Value=founderpcb_user.NAME;
			       parameters[6].Value=founderpcb_user.DEPT;
			       parameters[7].Value=founderpcb_user.POSITION;
			       parameters[8].Value=founderpcb_user.TEL_NUMBER;
			       parameters[9].Value=founderpcb_user.MOBILE;
			       parameters[10].Value=founderpcb_user.ADDR;
			       parameters[11].Value=founderpcb_user.DATA0073RKEY;
			       parameters[12].Value=founderpcb_user.ROLE;
			       parameters[13].Value=founderpcb_user.SYS_VERSION;
					if (founderpcb_user.CREATE_DATE == DateTime.Parse("1900-1-1") || founderpcb_user.CREATE_DATE == DateTime.Parse("0001-1-1"))
						parameters[14].Value = null;
					else
						parameters[14].Value=founderpcb_user.CREATE_DATE;				    
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				founderpcb_user.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_USER,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_USER founderpcb_user)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FOUNDERPCB_USER(");
			strSql.Append("LOGIN_ID,PRO_RKEY,NAME,DEPT,POSITION,TEL_NUMBER,MOBILE,ADDR,DATA0073RKEY,ROLE,SYS_VERSION,CREATE_DATE");
			strSql.Append(" ) values (");
			strSql.Append("@LOGIN_ID,@PRO_RKEY,@NAME,@DEPT,@POSITION,@TEL_NUMBER,@MOBILE,@ADDR,@DATA0073RKEY,@ROLE,@SYS_VERSION,@CREATE_DATE");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@LOGIN_ID",SqlDbType.VarChar,30),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@NAME",SqlDbType.VarChar,20),
			new SqlParameter("@DEPT",SqlDbType.VarChar,100),
			new SqlParameter("@POSITION",SqlDbType.VarChar,30),
			new SqlParameter("@TEL_NUMBER",SqlDbType.VarChar,30),
			new SqlParameter("@MOBILE",SqlDbType.VarChar,30),
			new SqlParameter("@ADDR",SqlDbType.VarChar,200),
			new SqlParameter("@DATA0073RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@ROLE",SqlDbType.Int,4),
			new SqlParameter("@SYS_VERSION",SqlDbType.VarChar,20),
			new SqlParameter("@CREATE_DATE",SqlDbType.DateTime,8)
			};
			
			       parameters[0].Value=founderpcb_user.LOGIN_ID;
			       parameters[1].Value=founderpcb_user.PRO_RKEY;
			       parameters[2].Value=founderpcb_user.NAME;
			       parameters[3].Value=founderpcb_user.DEPT;
			       parameters[4].Value=founderpcb_user.POSITION;
			       parameters[5].Value=founderpcb_user.TEL_NUMBER;
			       parameters[6].Value=founderpcb_user.MOBILE;
			       parameters[7].Value=founderpcb_user.ADDR;
			       parameters[8].Value=founderpcb_user.DATA0073RKEY;
			       parameters[9].Value=founderpcb_user.ROLE;
			       parameters[10].Value=founderpcb_user.SYS_VERSION;
					if (founderpcb_user.CREATE_DATE == DateTime.Parse("1900-1-1") || founderpcb_user.CREATE_DATE == DateTime.Parse("0001-1-1"))
						parameters[11].Value = null;
					else
						parameters[11].Value=founderpcb_user.CREATE_DATE;				    
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
		/// <param name="FOUNDERPCB_USER">founderpcb_user对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(FOUNDERPCB_USER founderpcb_user)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_FOUNDERPCB_USER_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@LOGIN_ID",SqlDbType.VarChar,30),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@NAME",SqlDbType.VarChar,20),
			new SqlParameter("@DEPT",SqlDbType.VarChar,100),
			new SqlParameter("@POSITION",SqlDbType.VarChar,30),
			new SqlParameter("@TEL_NUMBER",SqlDbType.VarChar,30),
			new SqlParameter("@MOBILE",SqlDbType.VarChar,30),
			new SqlParameter("@ADDR",SqlDbType.VarChar,200),
			new SqlParameter("@DATA0073RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@ROLE",SqlDbType.Int,4),
			new SqlParameter("@SYS_VERSION",SqlDbType.VarChar,20),
			new SqlParameter("@CREATE_DATE",SqlDbType.DateTime,8)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_user.RKEY;
			  		parameters[3].Value=founderpcb_user.LOGIN_ID;
			  		parameters[4].Value=founderpcb_user.PRO_RKEY;
			  		parameters[5].Value=founderpcb_user.NAME;
			  		parameters[6].Value=founderpcb_user.DEPT;
			  		parameters[7].Value=founderpcb_user.POSITION;
			  		parameters[8].Value=founderpcb_user.TEL_NUMBER;
			  		parameters[9].Value=founderpcb_user.MOBILE;
			  		parameters[10].Value=founderpcb_user.ADDR;
			  		parameters[11].Value=founderpcb_user.DATA0073RKEY;
			  		parameters[12].Value=founderpcb_user.ROLE;
			  		parameters[13].Value=founderpcb_user.SYS_VERSION;
					if (founderpcb_user.CREATE_DATE == DateTime.Parse("1900-1-1") || founderpcb_user.CREATE_DATE == DateTime.Parse("0001-1-1"))
						parameters[14].Value = null;
					else
						parameters[14].Value=founderpcb_user.CREATE_DATE;				    
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_USER,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_USER founderpcb_user)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update FOUNDERPCB_USER set "); 
			strSql.Append("LOGIN_ID=@LOGIN_ID,");
			strSql.Append("PRO_RKEY=@PRO_RKEY,");
			strSql.Append("NAME=@NAME,");
			strSql.Append("DEPT=@DEPT,");
			strSql.Append("POSITION=@POSITION,");
			strSql.Append("TEL_NUMBER=@TEL_NUMBER,");
			strSql.Append("MOBILE=@MOBILE,");
			strSql.Append("ADDR=@ADDR,");
			strSql.Append("DATA0073RKEY=@DATA0073RKEY,");
			strSql.Append("ROLE=@ROLE,");
			strSql.Append("SYS_VERSION=@SYS_VERSION,");
			strSql.Append("CREATE_DATE=@CREATE_DATE");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@LOGIN_ID",SqlDbType.VarChar,30),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@NAME",SqlDbType.VarChar,20),
			new SqlParameter("@DEPT",SqlDbType.VarChar,100),
			new SqlParameter("@POSITION",SqlDbType.VarChar,30),
			new SqlParameter("@TEL_NUMBER",SqlDbType.VarChar,30),
			new SqlParameter("@MOBILE",SqlDbType.VarChar,30),
			new SqlParameter("@ADDR",SqlDbType.VarChar,200),
			new SqlParameter("@DATA0073RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@ROLE",SqlDbType.Int,4),
			new SqlParameter("@SYS_VERSION",SqlDbType.VarChar,20),
			new SqlParameter("@CREATE_DATE",SqlDbType.DateTime,8)
			};
			
			parameters[0].Value = founderpcb_user.RKEY;
			       parameters[1].Value=founderpcb_user.LOGIN_ID;
			       parameters[2].Value=founderpcb_user.PRO_RKEY;
			       parameters[3].Value=founderpcb_user.NAME;
			       parameters[4].Value=founderpcb_user.DEPT;
			       parameters[5].Value=founderpcb_user.POSITION;
			       parameters[6].Value=founderpcb_user.TEL_NUMBER;
			       parameters[7].Value=founderpcb_user.MOBILE;
			       parameters[8].Value=founderpcb_user.ADDR;
			       parameters[9].Value=founderpcb_user.DATA0073RKEY;
			       parameters[10].Value=founderpcb_user.ROLE;
			       parameters[11].Value=founderpcb_user.SYS_VERSION;
					if (founderpcb_user.CREATE_DATE == DateTime.Parse("1900-1-1") || founderpcb_user.CREATE_DATE == DateTime.Parse("0001-1-1"))
						parameters[12].Value = null;
					else
						parameters[12].Value=founderpcb_user.CREATE_DATE;				    
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
		/// <param name="founderpcb_user">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(FOUNDERPCB_USER founderpcb_user)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_FOUNDERPCB_USER_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_user.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_USER,delete successful");
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
		/// <param name="founderpcb_user">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.FOUNDERPCB_USER where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_USER,delete successful");
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
			strSql.Append("delete from founderpcb_user ");
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
		///<returns>FOUNDERPCB_USER对象</returns>		
		public FOUNDERPCB_USER getFOUNDERPCB_USERByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(login_id,'') as login_id
				,
				isNull(pro_rkey,0) as pro_rkey
				,
				isNull(name,'') as name
				,
				isNull(dept,'') as dept
				,
				isNull(position,'') as position
				,
				isNull(tel_number,'') as tel_number
				,
				isNull(mobile,'') as mobile
				,
				isNull(addr,'') as addr
				,
				isNull(data0073rkey,0) as data0073rkey
				,
				isNull(role,0) as role
				,
				isNull(sys_version,'') as sys_version
				,
				isNull(create_date,'1900-1-1') as create_date
				
			from FOUNDERPCB_USER with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			FOUNDERPCB_USER  founderpcb_user=null;
			
			#region 数据库操作
            try
            {
				 founderpcb_user=new FOUNDERPCB_USER();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    founderpcb_user.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
								   founderpcb_user.LOGIN_ID =row["LOGIN_ID"].ToString();
							  	        founderpcb_user.PRO_RKEY =decimal.Parse(row["PRO_RKEY"].ToString());
								   founderpcb_user.NAME =row["NAME"].ToString();
								   founderpcb_user.DEPT =row["DEPT"].ToString();
								   founderpcb_user.POSITION =row["POSITION"].ToString();
								   founderpcb_user.TEL_NUMBER =row["TEL_NUMBER"].ToString();
								   founderpcb_user.MOBILE =row["MOBILE"].ToString();
								   founderpcb_user.ADDR =row["ADDR"].ToString();
							  	        founderpcb_user.DATA0073RKEY =decimal.Parse(row["DATA0073RKEY"].ToString());
							  	        founderpcb_user.ROLE =int.Parse(row["ROLE"].ToString());
								   founderpcb_user.SYS_VERSION =row["SYS_VERSION"].ToString();
							  	        founderpcb_user.CREATE_DATE =DateTime.Parse(row["CREATE_DATE"].ToString());
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return founderpcb_user;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< FOUNDERPCB_USER >  FindAllFOUNDERPCB_USER()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<FOUNDERPCB_USER>数据集合</returns>		
		public IList< FOUNDERPCB_USER> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(login_id,'') as login_id
				,
				isNull(pro_rkey,0) as pro_rkey
				,
				isNull(name,'') as name
				,
				isNull(dept,'') as dept
				,
				isNull(position,'') as position
				,
				isNull(tel_number,'') as tel_number
				,
				isNull(mobile,'') as mobile
				,
				isNull(addr,'') as addr
				,
				isNull(data0073rkey,0) as data0073rkey
				,
				isNull(role,0) as role
				,
				isNull(sys_version,'') as sys_version
				,
				isNull(create_date,'1900-1-1') as create_date
				
			from FOUNDERPCB_USER with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<FOUNDERPCB_USER> resultList=new List<FOUNDERPCB_USER>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							FOUNDERPCB_USER  founderpcb_user =new FOUNDERPCB_USER();
							
								founderpcb_user.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
							      founderpcb_user.LOGIN_ID =row["LOGIN_ID"].ToString();
								  	founderpcb_user.PRO_RKEY =decimal.Parse(row["PRO_RKEY"].ToString()) ;
							      founderpcb_user.NAME =row["NAME"].ToString();
							      founderpcb_user.DEPT =row["DEPT"].ToString();
							      founderpcb_user.POSITION =row["POSITION"].ToString();
							      founderpcb_user.TEL_NUMBER =row["TEL_NUMBER"].ToString();
							      founderpcb_user.MOBILE =row["MOBILE"].ToString();
							      founderpcb_user.ADDR =row["ADDR"].ToString();
								  	founderpcb_user.DATA0073RKEY =decimal.Parse(row["DATA0073RKEY"].ToString()) ;
								  	founderpcb_user.ROLE =int.Parse(row["ROLE"].ToString()) ;
							      founderpcb_user.SYS_VERSION =row["SYS_VERSION"].ToString();
								  	founderpcb_user.CREATE_DATE =DateTime.Parse(row["CREATE_DATE"].ToString()) ;
		
							resultList.Add(founderpcb_user);
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

