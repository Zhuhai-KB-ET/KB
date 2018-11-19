//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 15:57:08
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
	/// 数据访问层   DATA0005DAL
	/// </summary>
	public  partial class DATA0005DAL
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
		public 	DATA0005DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0005DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0005DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	DATA0005DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	DATA0005DAL(DBHelper DB)
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
		/// <param name="DATA0005">data0005对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(DATA0005 data0005)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_DATA0005_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@EMPL_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@EMPLOYEE_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@EMPLOYEE_ID",SqlDbType.VarChar,15),
			new SqlParameter("@ADDRESS_LINE_1",SqlDbType.VarChar,30),
			new SqlParameter("@ADDRESS_LINE_2",SqlDbType.VarChar,30),
			new SqlParameter("@ADDRESS_LINE_3",SqlDbType.VarChar,30),
			new SqlParameter("@STATE",SqlDbType.VarChar,3),
			new SqlParameter("@ZIP",SqlDbType.VarChar,10),
			new SqlParameter("@PHONE",SqlDbType.VarChar,30),
			new SqlParameter("@NOTE_PAD_POINTER",SqlDbType.Decimal,9),
			new SqlParameter("@PAY_RATE_1",SqlDbType.Decimal,13),
			new SqlParameter("@PAY_RATE_2",SqlDbType.Decimal,13),
			new SqlParameter("@PAY_RATE_3",SqlDbType.Decimal,13),
			new SqlParameter("@START_TIME_1",SqlDbType.Decimal,9),
			new SqlParameter("@START_TIME_2",SqlDbType.Decimal,9),
			new SqlParameter("@START_TIME_3",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BUYER_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@INACTIVE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@TPOSTION",SqlDbType.VarChar,40),
			new SqlParameter("@EMAIL",SqlDbType.VarChar,40),
			new SqlParameter("@EMPL_PASSWORD",SqlDbType.Binary,12)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=data0005.RKEY;
			       parameters[3].Value=data0005.EMPL_CODE;
			       parameters[4].Value=data0005.EMPLOYEE_NAME;
			       parameters[5].Value=data0005.ABBR_NAME;
			       parameters[6].Value=data0005.EMPLOYEE_ID;
			       parameters[7].Value=data0005.ADDRESS_LINE_1;
			       parameters[8].Value=data0005.ADDRESS_LINE_2;
			       parameters[9].Value=data0005.ADDRESS_LINE_3;
			       parameters[10].Value=data0005.STATE;
			       parameters[11].Value=data0005.ZIP;
			       parameters[12].Value=data0005.PHONE;
			       parameters[13].Value=data0005.NOTE_PAD_POINTER;
			       parameters[14].Value=data0005.PAY_RATE_1;
			       parameters[15].Value=data0005.PAY_RATE_2;
			       parameters[16].Value=data0005.PAY_RATE_3;
			       parameters[17].Value=data0005.START_TIME_1;
			       parameters[18].Value=data0005.START_TIME_2;
			       parameters[19].Value=data0005.START_TIME_3;
			       parameters[20].Value=data0005.ACTIVE_FLAG;
			       parameters[21].Value=data0005.BUYER_FLAG;
					if (data0005.INACTIVE_DATE == DateTime.Parse("1900-1-1") || data0005.INACTIVE_DATE == DateTime.Parse("0001-1-1"))
						parameters[22].Value = null;
					else
						parameters[22].Value=data0005.INACTIVE_DATE;				    
			       parameters[23].Value=data0005.TPOSTION;
			       parameters[24].Value=data0005.EMAIL;
			       parameters[25].Value=data0005.EMPL_PASSWORD;
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				data0005.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0005,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0005 data0005)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0005(");
			strSql.Append("EMPL_CODE,EMPLOYEE_NAME,ABBR_NAME,EMPLOYEE_ID,ADDRESS_LINE_1,ADDRESS_LINE_2,ADDRESS_LINE_3,STATE,ZIP,PHONE,NOTE_PAD_POINTER,PAY_RATE_1,PAY_RATE_2,PAY_RATE_3,START_TIME_1,START_TIME_2,START_TIME_3,ACTIVE_FLAG,BUYER_FLAG,INACTIVE_DATE,TPOSTION,EMAIL,EMPL_PASSWORD");
			strSql.Append(" ) values (");
			strSql.Append("@EMPL_CODE,@EMPLOYEE_NAME,@ABBR_NAME,@EMPLOYEE_ID,@ADDRESS_LINE_1,@ADDRESS_LINE_2,@ADDRESS_LINE_3,@STATE,@ZIP,@PHONE,@NOTE_PAD_POINTER,@PAY_RATE_1,@PAY_RATE_2,@PAY_RATE_3,@START_TIME_1,@START_TIME_2,@START_TIME_3,@ACTIVE_FLAG,@BUYER_FLAG,@INACTIVE_DATE,@TPOSTION,@EMAIL,@EMPL_PASSWORD");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@EMPL_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@EMPLOYEE_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@EMPLOYEE_ID",SqlDbType.VarChar,15),
			new SqlParameter("@ADDRESS_LINE_1",SqlDbType.VarChar,30),
			new SqlParameter("@ADDRESS_LINE_2",SqlDbType.VarChar,30),
			new SqlParameter("@ADDRESS_LINE_3",SqlDbType.VarChar,30),
			new SqlParameter("@STATE",SqlDbType.VarChar,3),
			new SqlParameter("@ZIP",SqlDbType.VarChar,10),
			new SqlParameter("@PHONE",SqlDbType.VarChar,30),
			new SqlParameter("@NOTE_PAD_POINTER",SqlDbType.Decimal,9),
			new SqlParameter("@PAY_RATE_1",SqlDbType.Decimal,13),
			new SqlParameter("@PAY_RATE_2",SqlDbType.Decimal,13),
			new SqlParameter("@PAY_RATE_3",SqlDbType.Decimal,13),
			new SqlParameter("@START_TIME_1",SqlDbType.Decimal,9),
			new SqlParameter("@START_TIME_2",SqlDbType.Decimal,9),
			new SqlParameter("@START_TIME_3",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BUYER_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@INACTIVE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@TPOSTION",SqlDbType.VarChar,40),
			new SqlParameter("@EMAIL",SqlDbType.VarChar,40),
			new SqlParameter("@EMPL_PASSWORD",SqlDbType.Binary,12)
			};
			
			       parameters[0].Value=data0005.EMPL_CODE;
			       parameters[1].Value=data0005.EMPLOYEE_NAME;
			       parameters[2].Value=data0005.ABBR_NAME;
			       parameters[3].Value=data0005.EMPLOYEE_ID;
			       parameters[4].Value=data0005.ADDRESS_LINE_1;
			       parameters[5].Value=data0005.ADDRESS_LINE_2;
			       parameters[6].Value=data0005.ADDRESS_LINE_3;
			       parameters[7].Value=data0005.STATE;
			       parameters[8].Value=data0005.ZIP;
			       parameters[9].Value=data0005.PHONE;
			       parameters[10].Value=data0005.NOTE_PAD_POINTER;
			       parameters[11].Value=data0005.PAY_RATE_1;
			       parameters[12].Value=data0005.PAY_RATE_2;
			       parameters[13].Value=data0005.PAY_RATE_3;
			       parameters[14].Value=data0005.START_TIME_1;
			       parameters[15].Value=data0005.START_TIME_2;
			       parameters[16].Value=data0005.START_TIME_3;
			       parameters[17].Value=data0005.ACTIVE_FLAG;
			       parameters[18].Value=data0005.BUYER_FLAG;
					if (data0005.INACTIVE_DATE == DateTime.Parse("1900-1-1") || data0005.INACTIVE_DATE == DateTime.Parse("0001-1-1"))
						parameters[19].Value = null;
					else
						parameters[19].Value=data0005.INACTIVE_DATE;				    
			       parameters[20].Value=data0005.TPOSTION;
			       parameters[21].Value=data0005.EMAIL;
			       parameters[22].Value=data0005.EMPL_PASSWORD;
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
		/// <param name="DATA0005">data0005对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(DATA0005 data0005)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_DATA0005_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@EMPL_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@EMPLOYEE_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@EMPLOYEE_ID",SqlDbType.VarChar,15),
			new SqlParameter("@ADDRESS_LINE_1",SqlDbType.VarChar,30),
			new SqlParameter("@ADDRESS_LINE_2",SqlDbType.VarChar,30),
			new SqlParameter("@ADDRESS_LINE_3",SqlDbType.VarChar,30),
			new SqlParameter("@STATE",SqlDbType.VarChar,3),
			new SqlParameter("@ZIP",SqlDbType.VarChar,10),
			new SqlParameter("@PHONE",SqlDbType.VarChar,30),
			new SqlParameter("@NOTE_PAD_POINTER",SqlDbType.Decimal,9),
			new SqlParameter("@PAY_RATE_1",SqlDbType.Decimal,13),
			new SqlParameter("@PAY_RATE_2",SqlDbType.Decimal,13),
			new SqlParameter("@PAY_RATE_3",SqlDbType.Decimal,13),
			new SqlParameter("@START_TIME_1",SqlDbType.Decimal,9),
			new SqlParameter("@START_TIME_2",SqlDbType.Decimal,9),
			new SqlParameter("@START_TIME_3",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BUYER_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@INACTIVE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@TPOSTION",SqlDbType.VarChar,40),
			new SqlParameter("@EMAIL",SqlDbType.VarChar,40),
			new SqlParameter("@EMPL_PASSWORD",SqlDbType.Binary,12)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0005.RKEY;
			  		parameters[3].Value=data0005.EMPL_CODE;
			  		parameters[4].Value=data0005.EMPLOYEE_NAME;
			  		parameters[5].Value=data0005.ABBR_NAME;
			  		parameters[6].Value=data0005.EMPLOYEE_ID;
			  		parameters[7].Value=data0005.ADDRESS_LINE_1;
			  		parameters[8].Value=data0005.ADDRESS_LINE_2;
			  		parameters[9].Value=data0005.ADDRESS_LINE_3;
			  		parameters[10].Value=data0005.STATE;
			  		parameters[11].Value=data0005.ZIP;
			  		parameters[12].Value=data0005.PHONE;
			  		parameters[13].Value=data0005.NOTE_PAD_POINTER;
			  		parameters[14].Value=data0005.PAY_RATE_1;
			  		parameters[15].Value=data0005.PAY_RATE_2;
			  		parameters[16].Value=data0005.PAY_RATE_3;
			  		parameters[17].Value=data0005.START_TIME_1;
			  		parameters[18].Value=data0005.START_TIME_2;
			  		parameters[19].Value=data0005.START_TIME_3;
			  		parameters[20].Value=data0005.ACTIVE_FLAG;
			  		parameters[21].Value=data0005.BUYER_FLAG;
					if (data0005.INACTIVE_DATE == DateTime.Parse("1900-1-1") || data0005.INACTIVE_DATE == DateTime.Parse("0001-1-1"))
						parameters[22].Value = null;
					else
						parameters[22].Value=data0005.INACTIVE_DATE;				    
			  		parameters[23].Value=data0005.TPOSTION;
			  		parameters[24].Value=data0005.EMAIL;
			  		parameters[25].Value=data0005.EMPL_PASSWORD;
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0005,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0005 data0005)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update DATA0005 set "); 
			strSql.Append("EMPL_CODE=@EMPL_CODE,");
			strSql.Append("EMPLOYEE_NAME=@EMPLOYEE_NAME,");
			strSql.Append("ABBR_NAME=@ABBR_NAME,");
			strSql.Append("EMPLOYEE_ID=@EMPLOYEE_ID,");
			strSql.Append("ADDRESS_LINE_1=@ADDRESS_LINE_1,");
			strSql.Append("ADDRESS_LINE_2=@ADDRESS_LINE_2,");
			strSql.Append("ADDRESS_LINE_3=@ADDRESS_LINE_3,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("ZIP=@ZIP,");
			strSql.Append("PHONE=@PHONE,");
			strSql.Append("NOTE_PAD_POINTER=@NOTE_PAD_POINTER,");
			strSql.Append("PAY_RATE_1=@PAY_RATE_1,");
			strSql.Append("PAY_RATE_2=@PAY_RATE_2,");
			strSql.Append("PAY_RATE_3=@PAY_RATE_3,");
			strSql.Append("START_TIME_1=@START_TIME_1,");
			strSql.Append("START_TIME_2=@START_TIME_2,");
			strSql.Append("START_TIME_3=@START_TIME_3,");
			strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG,");
			strSql.Append("BUYER_FLAG=@BUYER_FLAG,");
			strSql.Append("INACTIVE_DATE=@INACTIVE_DATE,");
			strSql.Append("TPOSTION=@TPOSTION,");
			strSql.Append("EMAIL=@EMAIL,");
			strSql.Append("EMPL_PASSWORD=@EMPL_PASSWORD");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@EMPL_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@EMPLOYEE_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@EMPLOYEE_ID",SqlDbType.VarChar,15),
			new SqlParameter("@ADDRESS_LINE_1",SqlDbType.VarChar,30),
			new SqlParameter("@ADDRESS_LINE_2",SqlDbType.VarChar,30),
			new SqlParameter("@ADDRESS_LINE_3",SqlDbType.VarChar,30),
			new SqlParameter("@STATE",SqlDbType.VarChar,3),
			new SqlParameter("@ZIP",SqlDbType.VarChar,10),
			new SqlParameter("@PHONE",SqlDbType.VarChar,30),
			new SqlParameter("@NOTE_PAD_POINTER",SqlDbType.Decimal,9),
			new SqlParameter("@PAY_RATE_1",SqlDbType.Decimal,13),
			new SqlParameter("@PAY_RATE_2",SqlDbType.Decimal,13),
			new SqlParameter("@PAY_RATE_3",SqlDbType.Decimal,13),
			new SqlParameter("@START_TIME_1",SqlDbType.Decimal,9),
			new SqlParameter("@START_TIME_2",SqlDbType.Decimal,9),
			new SqlParameter("@START_TIME_3",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BUYER_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@INACTIVE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@TPOSTION",SqlDbType.VarChar,40),
			new SqlParameter("@EMAIL",SqlDbType.VarChar,40),
			new SqlParameter("@EMPL_PASSWORD",SqlDbType.Binary,12)
			};
			
			parameters[0].Value = data0005.RKEY;
			       parameters[1].Value=data0005.EMPL_CODE;
			       parameters[2].Value=data0005.EMPLOYEE_NAME;
			       parameters[3].Value=data0005.ABBR_NAME;
			       parameters[4].Value=data0005.EMPLOYEE_ID;
			       parameters[5].Value=data0005.ADDRESS_LINE_1;
			       parameters[6].Value=data0005.ADDRESS_LINE_2;
			       parameters[7].Value=data0005.ADDRESS_LINE_3;
			       parameters[8].Value=data0005.STATE;
			       parameters[9].Value=data0005.ZIP;
			       parameters[10].Value=data0005.PHONE;
			       parameters[11].Value=data0005.NOTE_PAD_POINTER;
			       parameters[12].Value=data0005.PAY_RATE_1;
			       parameters[13].Value=data0005.PAY_RATE_2;
			       parameters[14].Value=data0005.PAY_RATE_3;
			       parameters[15].Value=data0005.START_TIME_1;
			       parameters[16].Value=data0005.START_TIME_2;
			       parameters[17].Value=data0005.START_TIME_3;
			       parameters[18].Value=data0005.ACTIVE_FLAG;
			       parameters[19].Value=data0005.BUYER_FLAG;
					if (data0005.INACTIVE_DATE == DateTime.Parse("1900-1-1") || data0005.INACTIVE_DATE == DateTime.Parse("0001-1-1"))
						parameters[20].Value = null;
					else
						parameters[20].Value=data0005.INACTIVE_DATE;				    
			       parameters[21].Value=data0005.TPOSTION;
			       parameters[22].Value=data0005.EMAIL;
			       parameters[23].Value=data0005.EMPL_PASSWORD;
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
		/// <param name="data0005">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(DATA0005 data0005)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_DATA0005_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0005.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0005,delete successful");
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
		/// <param name="data0005">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.DATA0005 where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0005,delete successful");
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
			strSql.Append("delete from data0005 ");
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
		///<returns>DATA0005对象</returns>		
		public DATA0005 getDATA0005ByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(empl_code,'') as empl_code
				,
				isNull(employee_name,'') as employee_name
				,
				isNull(abbr_name,'') as abbr_name
				,
				isNull(employee_id,'') as employee_id
				,
				isNull(address_line_1,'') as address_line_1
				,
				isNull(address_line_2,'') as address_line_2
				,
				isNull(address_line_3,'') as address_line_3
				,
				isNull(state,'') as state
				,
				isNull(zip,'') as zip
				,
				isNull(phone,'') as phone
				,
				isNull(note_pad_pointer,0) as note_pad_pointer
				,
				isNull(pay_rate_1,0) as pay_rate_1
				,
				isNull(pay_rate_2,0) as pay_rate_2
				,
				isNull(pay_rate_3,0) as pay_rate_3
				,
				isNull(start_time_1,0) as start_time_1
				,
				isNull(start_time_2,0) as start_time_2
				,
				isNull(start_time_3,0) as start_time_3
				,
				isNull(active_flag,'') as active_flag
				,
				isNull(buyer_flag,'') as buyer_flag
				,
				isNull(inactive_date,'1900-1-1') as inactive_date
				,
				isNull(tpostion,'') as tpostion
				,
				isNull(email,'') as email
				,
				isNull(empl_password,0) as empl_password
				
			from DATA0005 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			DATA0005  data0005=null;
			
			#region 数据库操作
            try
            {
				 data0005=new DATA0005();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    data0005.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
								   data0005.EMPL_CODE =row["EMPL_CODE"].ToString();
								   data0005.EMPLOYEE_NAME =row["EMPLOYEE_NAME"].ToString();
								   data0005.ABBR_NAME =row["ABBR_NAME"].ToString();
								   data0005.EMPLOYEE_ID =row["EMPLOYEE_ID"].ToString();
								   data0005.ADDRESS_LINE_1 =row["ADDRESS_LINE_1"].ToString();
								   data0005.ADDRESS_LINE_2 =row["ADDRESS_LINE_2"].ToString();
								   data0005.ADDRESS_LINE_3 =row["ADDRESS_LINE_3"].ToString();
								   data0005.STATE =row["STATE"].ToString();
								   data0005.ZIP =row["ZIP"].ToString();
								   data0005.PHONE =row["PHONE"].ToString();
							  	        data0005.NOTE_PAD_POINTER =decimal.Parse(row["NOTE_PAD_POINTER"].ToString());
							  	        data0005.PAY_RATE_1 =decimal.Parse(row["PAY_RATE_1"].ToString());
							  	        data0005.PAY_RATE_2 =decimal.Parse(row["PAY_RATE_2"].ToString());
							  	        data0005.PAY_RATE_3 =decimal.Parse(row["PAY_RATE_3"].ToString());
							  	        data0005.START_TIME_1 =decimal.Parse(row["START_TIME_1"].ToString());
							  	        data0005.START_TIME_2 =decimal.Parse(row["START_TIME_2"].ToString());
							  	        data0005.START_TIME_3 =decimal.Parse(row["START_TIME_3"].ToString());
								   data0005.ACTIVE_FLAG =row["ACTIVE_FLAG"].ToString();
								   data0005.BUYER_FLAG =row["BUYER_FLAG"].ToString();
							  	        data0005.INACTIVE_DATE =DateTime.Parse(row["INACTIVE_DATE"].ToString());
								   data0005.TPOSTION =row["TPOSTION"].ToString();
								   data0005.EMAIL =row["EMAIL"].ToString();
									   data0005.EMPL_PASSWORD =(Byte[])(row["EMPL_PASSWORD"]);									
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return data0005;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< DATA0005 >  FindAllDATA0005()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<DATA0005>数据集合</returns>		
		public IList< DATA0005> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(empl_code,'') as empl_code
				,
				isNull(employee_name,'') as employee_name
				,
				isNull(abbr_name,'') as abbr_name
				,
				isNull(employee_id,'') as employee_id
				,
				isNull(address_line_1,'') as address_line_1
				,
				isNull(address_line_2,'') as address_line_2
				,
				isNull(address_line_3,'') as address_line_3
				,
				isNull(state,'') as state
				,
				isNull(zip,'') as zip
				,
				isNull(phone,'') as phone
				,
				isNull(note_pad_pointer,0) as note_pad_pointer
				,
				isNull(pay_rate_1,0) as pay_rate_1
				,
				isNull(pay_rate_2,0) as pay_rate_2
				,
				isNull(pay_rate_3,0) as pay_rate_3
				,
				isNull(start_time_1,0) as start_time_1
				,
				isNull(start_time_2,0) as start_time_2
				,
				isNull(start_time_3,0) as start_time_3
				,
				isNull(active_flag,'') as active_flag
				,
				isNull(buyer_flag,'') as buyer_flag
				,
				isNull(inactive_date,'1900-1-1') as inactive_date
				,
				isNull(tpostion,'') as tpostion
				,
				isNull(email,'') as email
				,
				isNull(empl_password,0) as empl_password
				
			from DATA0005 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<DATA0005> resultList=new List<DATA0005>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							DATA0005  data0005 =new DATA0005();
							
								data0005.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
							      data0005.EMPL_CODE =row["EMPL_CODE"].ToString();
							      data0005.EMPLOYEE_NAME =row["EMPLOYEE_NAME"].ToString();
							      data0005.ABBR_NAME =row["ABBR_NAME"].ToString();
							      data0005.EMPLOYEE_ID =row["EMPLOYEE_ID"].ToString();
							      data0005.ADDRESS_LINE_1 =row["ADDRESS_LINE_1"].ToString();
							      data0005.ADDRESS_LINE_2 =row["ADDRESS_LINE_2"].ToString();
							      data0005.ADDRESS_LINE_3 =row["ADDRESS_LINE_3"].ToString();
							      data0005.STATE =row["STATE"].ToString();
							      data0005.ZIP =row["ZIP"].ToString();
							      data0005.PHONE =row["PHONE"].ToString();
								  	data0005.NOTE_PAD_POINTER =decimal.Parse(row["NOTE_PAD_POINTER"].ToString()) ;
								  	data0005.PAY_RATE_1 =decimal.Parse(row["PAY_RATE_1"].ToString()) ;
								  	data0005.PAY_RATE_2 =decimal.Parse(row["PAY_RATE_2"].ToString()) ;
								  	data0005.PAY_RATE_3 =decimal.Parse(row["PAY_RATE_3"].ToString()) ;
								  	data0005.START_TIME_1 =decimal.Parse(row["START_TIME_1"].ToString()) ;
								  	data0005.START_TIME_2 =decimal.Parse(row["START_TIME_2"].ToString()) ;
								  	data0005.START_TIME_3 =decimal.Parse(row["START_TIME_3"].ToString()) ;
							      data0005.ACTIVE_FLAG =row["ACTIVE_FLAG"].ToString();
							      data0005.BUYER_FLAG =row["BUYER_FLAG"].ToString();
								  	data0005.INACTIVE_DATE =DateTime.Parse(row["INACTIVE_DATE"].ToString()) ;
							      data0005.TPOSTION =row["TPOSTION"].ToString();
							      data0005.EMAIL =row["EMAIL"].ToString();
                                  data0005.EMPL_PASSWORD = (Byte[])(row["EMPL_PASSWORD"]);								
		
							resultList.Add(data0005);
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

