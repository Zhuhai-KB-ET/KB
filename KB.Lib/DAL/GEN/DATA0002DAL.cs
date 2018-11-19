//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 15:57:07
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
	/// 数据访问层   DATA0002DAL
	/// </summary>
	public  partial class DATA0002DAL
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
		public 	DATA0002DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0002DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0002DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	DATA0002DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	DATA0002DAL(DBHelper DB)
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
		/// <param name="DATA0002">data0002对象</param>
		/// <returns>新插入记录的编号</returns>
        public int Add(DATA0002 model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0002(");
            strSql.Append("UNIT_CODE,UNIT_NAME,PROD,PURCH,STOCK,QUOTE,SELL,UNIT_BASE,DERIVED,INT_CHECK,EXPRESSION,MIN_UNIT_VALUE,MAX_UNIT_VALUE,UNIT_TYPE,POT_OUTER_LAYER,POT_INNER_LAYER,ACTIVE_FLAG,ECN_FLAG)");
            strSql.Append(" values (");
            strSql.Append("@UNIT_CODE,@UNIT_NAME,@PROD,@PURCH,@STOCK,@QUOTE,@SELL,@UNIT_BASE,@DERIVED,@INT_CHECK,@EXPRESSION,@MIN_UNIT_VALUE,@MAX_UNIT_VALUE,@UNIT_TYPE,@POT_OUTER_LAYER,@POT_INNER_LAYER,@ACTIVE_FLAG,@ECN_FLAG)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,5),
					new SqlParameter("@UNIT_NAME", SqlDbType.VarChar,20),
					new SqlParameter("@PROD", SqlDbType.Char,1),
					new SqlParameter("@PURCH", SqlDbType.Char,1),
					new SqlParameter("@STOCK", SqlDbType.Char,1),
					new SqlParameter("@QUOTE", SqlDbType.Char,1),
					new SqlParameter("@SELL", SqlDbType.Char,1),
					new SqlParameter("@UNIT_BASE", SqlDbType.Char,1),
					new SqlParameter("@DERIVED", SqlDbType.Char,1),
					new SqlParameter("@INT_CHECK", SqlDbType.Char,1),
					new SqlParameter("@EXPRESSION", SqlDbType.VarChar,50),
					new SqlParameter("@MIN_UNIT_VALUE", SqlDbType.Decimal,13),
					new SqlParameter("@MAX_UNIT_VALUE", SqlDbType.Decimal,13),
					new SqlParameter("@UNIT_TYPE", SqlDbType.Char,1),
					new SqlParameter("@POT_OUTER_LAYER", SqlDbType.Decimal,5),
					new SqlParameter("@POT_INNER_LAYER", SqlDbType.Decimal,5),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Decimal,9),
					new SqlParameter("@ECN_FLAG", SqlDbType.VarChar,1)};
            parameters[0].Value = model.UNIT_CODE;
            parameters[1].Value = model.UNIT_NAME;
            parameters[2].Value = model.PROD;
            parameters[3].Value = model.PURCH;
            parameters[4].Value = model.STOCK;
            parameters[5].Value = model.QUOTE;
            parameters[6].Value = model.SELL;
            parameters[7].Value = model.UNIT_BASE;
            parameters[8].Value = model.DERIVED;
            parameters[9].Value = model.INT_CHECK;
            parameters[10].Value = model.EXPRESSION;
            parameters[11].Value = model.MIN_UNIT_VALUE;
            parameters[12].Value = model.MAX_UNIT_VALUE;
            parameters[13].Value = model.UNIT_TYPE;
            parameters[14].Value = model.POT_OUTER_LAYER;
            parameters[15].Value = model.POT_INNER_LAYER;
            parameters[16].Value = model.ACTIVE_FLAG;
            parameters[17].Value = model.ECN_FLAG;

            object obj = dbHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
		}
        public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0002 model)
		{	
			#region 创建SQL语法
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0002(");
            strSql.Append("UNIT_CODE,UNIT_NAME,PROD,PURCH,STOCK,QUOTE,SELL,UNIT_BASE,DERIVED,INT_CHECK,EXPRESSION,MIN_UNIT_VALUE,MAX_UNIT_VALUE,UNIT_TYPE,POT_OUTER_LAYER,POT_INNER_LAYER,ACTIVE_FLAG,ECN_FLAG)");
            strSql.Append(" values (");
            strSql.Append("@UNIT_CODE,@UNIT_NAME,@PROD,@PURCH,@STOCK,@QUOTE,@SELL,@UNIT_BASE,@DERIVED,@INT_CHECK,@EXPRESSION,@MIN_UNIT_VALUE,@MAX_UNIT_VALUE,@UNIT_TYPE,@POT_OUTER_LAYER,@POT_INNER_LAYER,@ACTIVE_FLAG,@ECN_FLAG)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,5),
					new SqlParameter("@UNIT_NAME", SqlDbType.VarChar,20),
					new SqlParameter("@PROD", SqlDbType.Char,1),
					new SqlParameter("@PURCH", SqlDbType.Char,1),
					new SqlParameter("@STOCK", SqlDbType.Char,1),
					new SqlParameter("@QUOTE", SqlDbType.Char,1),
					new SqlParameter("@SELL", SqlDbType.Char,1),
					new SqlParameter("@UNIT_BASE", SqlDbType.Char,1),
					new SqlParameter("@DERIVED", SqlDbType.Char,1),
					new SqlParameter("@INT_CHECK", SqlDbType.Char,1),
					new SqlParameter("@EXPRESSION", SqlDbType.VarChar,50),
					new SqlParameter("@MIN_UNIT_VALUE", SqlDbType.Decimal,13),
					new SqlParameter("@MAX_UNIT_VALUE", SqlDbType.Decimal,13),
					new SqlParameter("@UNIT_TYPE", SqlDbType.Char,1),
					new SqlParameter("@POT_OUTER_LAYER", SqlDbType.Decimal,5),
					new SqlParameter("@POT_INNER_LAYER", SqlDbType.Decimal,5),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Decimal,9),
					new SqlParameter("@ECN_FLAG", SqlDbType.VarChar,1)};
            parameters[0].Value = model.UNIT_CODE;
            parameters[1].Value = model.UNIT_NAME;
            parameters[2].Value = model.PROD;
            parameters[3].Value = model.PURCH;
            parameters[4].Value = model.STOCK;
            parameters[5].Value = model.QUOTE;
            parameters[6].Value = model.SELL;
            parameters[7].Value = model.UNIT_BASE;
            parameters[8].Value = model.DERIVED;
            parameters[9].Value = model.INT_CHECK;
            parameters[10].Value = model.EXPRESSION;
            parameters[11].Value = model.MIN_UNIT_VALUE;
            parameters[12].Value = model.MAX_UNIT_VALUE;
            parameters[13].Value = model.UNIT_TYPE;
            parameters[14].Value = model.POT_OUTER_LAYER;
            parameters[15].Value = model.POT_INNER_LAYER;
            parameters[16].Value = model.ACTIVE_FLAG;
            parameters[17].Value = model.ECN_FLAG;
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
        /// <param name="DATA0002">model对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
        public int Update(DATA0002 model)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DATA0002 set ");
            strSql.Append("UNIT_CODE=@UNIT_CODE,");
            strSql.Append("UNIT_NAME=@UNIT_NAME,");
            strSql.Append("PROD=@PROD,");
            strSql.Append("PURCH=@PURCH,");
            strSql.Append("STOCK=@STOCK,");
            strSql.Append("QUOTE=@QUOTE,");
            strSql.Append("SELL=@SELL,");
            strSql.Append("UNIT_BASE=@UNIT_BASE,");
            strSql.Append("DERIVED=@DERIVED,");
            strSql.Append("INT_CHECK=@INT_CHECK,");
            strSql.Append("EXPRESSION=@EXPRESSION,");
            strSql.Append("MIN_UNIT_VALUE=@MIN_UNIT_VALUE,");
            strSql.Append("MAX_UNIT_VALUE=@MAX_UNIT_VALUE,");
            strSql.Append("UNIT_TYPE=@UNIT_TYPE,");
            strSql.Append("POT_OUTER_LAYER=@POT_OUTER_LAYER,");
            strSql.Append("POT_INNER_LAYER=@POT_INNER_LAYER,");
            strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG,");
            strSql.Append("ECN_FLAG=@ECN_FLAG");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Decimal,9),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,5),
					new SqlParameter("@UNIT_NAME", SqlDbType.VarChar,20),
					new SqlParameter("@PROD", SqlDbType.Char,1),
					new SqlParameter("@PURCH", SqlDbType.Char,1),
					new SqlParameter("@STOCK", SqlDbType.Char,1),
					new SqlParameter("@QUOTE", SqlDbType.Char,1),
					new SqlParameter("@SELL", SqlDbType.Char,1),
					new SqlParameter("@UNIT_BASE", SqlDbType.Char,1),
					new SqlParameter("@DERIVED", SqlDbType.Char,1),
					new SqlParameter("@INT_CHECK", SqlDbType.Char,1),
					new SqlParameter("@EXPRESSION", SqlDbType.VarChar,50),
					new SqlParameter("@MIN_UNIT_VALUE", SqlDbType.Decimal,13),
					new SqlParameter("@MAX_UNIT_VALUE", SqlDbType.Decimal,13),
					new SqlParameter("@UNIT_TYPE", SqlDbType.Char,1),
					new SqlParameter("@POT_OUTER_LAYER", SqlDbType.Decimal,5),
					new SqlParameter("@POT_INNER_LAYER", SqlDbType.Decimal,5),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Decimal,9),
					new SqlParameter("@ECN_FLAG", SqlDbType.VarChar,1)};
            parameters[0].Value = model.RKEY;
            parameters[1].Value = model.UNIT_CODE;
            parameters[2].Value = model.UNIT_NAME;
            parameters[3].Value = model.PROD;
            parameters[4].Value = model.PURCH;
            parameters[5].Value = model.STOCK;
            parameters[6].Value = model.QUOTE;
            parameters[7].Value = model.SELL;
            parameters[8].Value = model.UNIT_BASE;
            parameters[9].Value = model.DERIVED;
            parameters[10].Value = model.INT_CHECK;
            parameters[11].Value = model.EXPRESSION;
            parameters[12].Value = model.MIN_UNIT_VALUE;
            parameters[13].Value = model.MAX_UNIT_VALUE;
            parameters[14].Value = model.UNIT_TYPE;
            parameters[15].Value = model.POT_OUTER_LAYER;
            parameters[16].Value = model.POT_INNER_LAYER;
            parameters[17].Value = model.ACTIVE_FLAG;
            parameters[18].Value = model.ECN_FLAG;

            return dbHelper.ExecuteNonQuery(strSql.ToString(), parameters);
			
				
		}
        public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0002 model)
		{
			#region 创建语法
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DATA0002 set ");
            strSql.Append("UNIT_CODE=@UNIT_CODE,");
            strSql.Append("UNIT_NAME=@UNIT_NAME,");
            strSql.Append("PROD=@PROD,");
            strSql.Append("PURCH=@PURCH,");
            strSql.Append("STOCK=@STOCK,");
            strSql.Append("QUOTE=@QUOTE,");
            strSql.Append("SELL=@SELL,");
            strSql.Append("UNIT_BASE=@UNIT_BASE,");
            strSql.Append("DERIVED=@DERIVED,");
            strSql.Append("INT_CHECK=@INT_CHECK,");
            strSql.Append("EXPRESSION=@EXPRESSION,");
            strSql.Append("MIN_UNIT_VALUE=@MIN_UNIT_VALUE,");
            strSql.Append("MAX_UNIT_VALUE=@MAX_UNIT_VALUE,");
            strSql.Append("UNIT_TYPE=@UNIT_TYPE,");
            strSql.Append("POT_OUTER_LAYER=@POT_OUTER_LAYER,");
            strSql.Append("POT_INNER_LAYER=@POT_INNER_LAYER,");
            strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG,");
            strSql.Append("ECN_FLAG=@ECN_FLAG");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Decimal,9),
					new SqlParameter("@UNIT_CODE", SqlDbType.VarChar,5),
					new SqlParameter("@UNIT_NAME", SqlDbType.VarChar,20),
					new SqlParameter("@PROD", SqlDbType.Char,1),
					new SqlParameter("@PURCH", SqlDbType.Char,1),
					new SqlParameter("@STOCK", SqlDbType.Char,1),
					new SqlParameter("@QUOTE", SqlDbType.Char,1),
					new SqlParameter("@SELL", SqlDbType.Char,1),
					new SqlParameter("@UNIT_BASE", SqlDbType.Char,1),
					new SqlParameter("@DERIVED", SqlDbType.Char,1),
					new SqlParameter("@INT_CHECK", SqlDbType.Char,1),
					new SqlParameter("@EXPRESSION", SqlDbType.VarChar,50),
					new SqlParameter("@MIN_UNIT_VALUE", SqlDbType.Decimal,13),
					new SqlParameter("@MAX_UNIT_VALUE", SqlDbType.Decimal,13),
					new SqlParameter("@UNIT_TYPE", SqlDbType.Char,1),
					new SqlParameter("@POT_OUTER_LAYER", SqlDbType.Decimal,5),
					new SqlParameter("@POT_INNER_LAYER", SqlDbType.Decimal,5),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Decimal,9),
					new SqlParameter("@ECN_FLAG", SqlDbType.VarChar,1)};
            parameters[0].Value = model.RKEY;
            parameters[1].Value = model.UNIT_CODE;
            parameters[2].Value = model.UNIT_NAME;
            parameters[3].Value = model.PROD;
            parameters[4].Value = model.PURCH;
            parameters[5].Value = model.STOCK;
            parameters[6].Value = model.QUOTE;
            parameters[7].Value = model.SELL;
            parameters[8].Value = model.UNIT_BASE;
            parameters[9].Value = model.DERIVED;
            parameters[10].Value = model.INT_CHECK;
            parameters[11].Value = model.EXPRESSION;
            parameters[12].Value = model.MIN_UNIT_VALUE;
            parameters[13].Value = model.MAX_UNIT_VALUE;
            parameters[14].Value = model.UNIT_TYPE;
            parameters[15].Value = model.POT_OUTER_LAYER;
            parameters[16].Value = model.POT_INNER_LAYER;
            parameters[17].Value = model.ACTIVE_FLAG;
            parameters[18].Value = model.ECN_FLAG;
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
		/// <param name="data0002">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(DATA0002 data0002)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_DATA0002_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0002.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0002,delete successful");
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
		/// <param name="data0002">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
        public int DeleteByRKEY(decimal RKEY)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DATA0002 ");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Decimal)};
            parameters[0].Value = RKEY;

            return dbHelper.ExecuteNonQuery(strSql.ToString(), parameters);			
							
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rkey)
		{
			#region 创建语法
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from data0002 ");
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
		///<returns>DATA0002对象</returns>		
		public DATA0002 getDATA0002ByRKEY(decimal rkey)
		{
			#region SQL
			string sql= @"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(unit_code,'') as unit_code
				,
				isNull(unit_name,'') as unit_name
				,
				isNull(prod,'') as prod
				,
				isNull(purch,'') as purch
				,
				isNull(stock,'') as stock
				,
				isNull(quote,'') as quote
				,
				isNull(sell,'') as sell
				,
				isNull(unit_base,'') as unit_base
				,
				isNull(derived,'') as derived
				,
				isNull(int_check,'') as int_check
				,
				isNull(expression,'') as expression
				,
				isNull(min_unit_value,0) as min_unit_value
				,
				isNull(max_unit_value,0) as max_unit_value
				,
				isNull(unit_type,'') as unit_type
				,
				isNull(pot_outer_layer,0) as pot_outer_layer
				,
				isNull(pot_inner_layer,0) as pot_inner_layer
				,
				isNull(active_flag,0) as active_flag
                ,
				isNull(ecn_flag,'') as ecn_flag
				
			from DATA0002 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			DATA0002  data0002=null;
			
			#region 数据库操作
            try
            {
				 data0002=new DATA0002();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    data0002.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
								   data0002.UNIT_CODE =row["UNIT_CODE"].ToString();
								   data0002.UNIT_NAME =row["UNIT_NAME"].ToString();
								   data0002.PROD =row["PROD"].ToString();
								   data0002.PURCH =row["PURCH"].ToString();
								   data0002.STOCK =row["STOCK"].ToString();
								   data0002.QUOTE =row["QUOTE"].ToString();
								   data0002.SELL =row["SELL"].ToString();
								   data0002.UNIT_BASE =row["UNIT_BASE"].ToString();
								   data0002.DERIVED =row["DERIVED"].ToString();
								   data0002.INT_CHECK =row["INT_CHECK"].ToString();
								   data0002.EXPRESSION =row["EXPRESSION"].ToString();
							  	        data0002.MIN_UNIT_VALUE =decimal.Parse(row["MIN_UNIT_VALUE"].ToString());
							  	        data0002.MAX_UNIT_VALUE =decimal.Parse(row["MAX_UNIT_VALUE"].ToString());
								   data0002.UNIT_TYPE =row["UNIT_TYPE"].ToString();
							  	        data0002.POT_OUTER_LAYER =decimal.Parse(row["POT_OUTER_LAYER"].ToString());
							  	        data0002.POT_INNER_LAYER =decimal.Parse(row["POT_INNER_LAYER"].ToString());
							  	        data0002.ACTIVE_FLAG =decimal.Parse(row["ACTIVE_FLAG"].ToString());
                                        data0002.ECN_FLAG = row["ECN_FLAG"].ToString();
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return data0002;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< DATA0002 >  FindAllDATA0002()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<DATA0002>数据集合</returns>		
		public IList< DATA0002> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql= @"select 
				isNull(rkey,0) as rkey
				,
				isNull(unit_code,'') as unit_code
				,
				isNull(unit_name,'') as unit_name
				,
				isNull(prod,'') as prod
				,
				isNull(purch,'') as purch
				,
				isNull(stock,'') as stock
				,
				isNull(quote,'') as quote
				,
				isNull(sell,'') as sell
				,
				isNull(unit_base,'') as unit_base
				,
				isNull(derived,'') as derived
				,
				isNull(int_check,'') as int_check
				,
				isNull(expression,'') as expression
				,
				isNull(min_unit_value,0) as min_unit_value
				,
				isNull(max_unit_value,0) as max_unit_value
				,
				isNull(unit_type,'') as unit_type
				,
				isNull(pot_outer_layer,0) as pot_outer_layer
				,
				isNull(pot_inner_layer,0) as pot_inner_layer
				,
				isNull(active_flag,0) as active_flag
                ,
				isNull(ecn_flag,'') as ecn_flag
				
			from DATA0002 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<DATA0002> resultList=new List<DATA0002>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							DATA0002  data0002 =new DATA0002();
							
								data0002.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
							      data0002.UNIT_CODE =row["UNIT_CODE"].ToString();
							      data0002.UNIT_NAME =row["UNIT_NAME"].ToString();
							      data0002.PROD =row["PROD"].ToString();
							      data0002.PURCH =row["PURCH"].ToString();
							      data0002.STOCK =row["STOCK"].ToString();
							      data0002.QUOTE =row["QUOTE"].ToString();
							      data0002.SELL =row["SELL"].ToString();
							      data0002.UNIT_BASE =row["UNIT_BASE"].ToString();
							      data0002.DERIVED =row["DERIVED"].ToString();
							      data0002.INT_CHECK =row["INT_CHECK"].ToString();
							      data0002.EXPRESSION =row["EXPRESSION"].ToString();
								  	data0002.MIN_UNIT_VALUE =decimal.Parse(row["MIN_UNIT_VALUE"].ToString()) ;
								  	data0002.MAX_UNIT_VALUE =decimal.Parse(row["MAX_UNIT_VALUE"].ToString()) ;
							      data0002.UNIT_TYPE =row["UNIT_TYPE"].ToString();
								  	data0002.POT_OUTER_LAYER =decimal.Parse(row["POT_OUTER_LAYER"].ToString()) ;
								  	data0002.POT_INNER_LAYER =decimal.Parse(row["POT_INNER_LAYER"].ToString()) ;
								  	data0002.ACTIVE_FLAG =decimal.Parse(row["ACTIVE_FLAG"].ToString()) ;
                                    data0002.ECN_FLAG = row["ECN_FLAG"].ToString();
		
							resultList.Add(data0002);
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

