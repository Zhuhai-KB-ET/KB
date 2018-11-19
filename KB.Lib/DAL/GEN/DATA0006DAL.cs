//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 15:57:09
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
	/// 数据访问层   DATA0006DAL
	/// </summary>
	public  partial class DATA0006DAL
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
		public 	DATA0006DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0006DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0006DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	DATA0006DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	DATA0006DAL(DBHelper DB)
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
		/// <param name="DATA0006">data0006对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(DATA0006 data0006)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_DATA0006_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@WORK_ORDER_NUMBER",SqlDbType.VarChar,16),
			new SqlParameter("@INVENTORY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CUST_PART_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ROOT_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@WHOUSE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_RTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PROD_RTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CSI_USER_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMPLOYEE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@BOM_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@SUB_LEVELS",SqlDbType.Decimal,9),
			new SqlParameter("@PRIORITY_CODE",SqlDbType.VarChar,1),
			new SqlParameter("@ENGG_STATUS",SqlDbType.Decimal,9),
			new SqlParameter("@PROD_STATUS",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_PROD_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_RTE_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@PROD_RTE_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BOM_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@QUAN_SCH",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_REJ",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_PROD",SqlDbType.Decimal,13),
			new SqlParameter("@ENT_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@ENT_TIME",SqlDbType.Decimal,9),
			new SqlParameter("@SCH_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@PROJ_START_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@PROJ_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@CANCEL_HOLD_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@ACT_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@CUST_PART_REV_NO",SqlDbType.VarChar,5),
			new SqlParameter("@BOM_REV_NO",SqlDbType.VarChar,10),
			new SqlParameter("@TAG_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DT_PTRAV_PRN",SqlDbType.DateTime,8),
			new SqlParameter("@DT_ETRAV_PRN",SqlDbType.DateTime,8),
			new SqlParameter("@SCRAP_RATE",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_BAL",SqlDbType.Decimal,13),
			new SqlParameter("@BASE_WO",SqlDbType.VarChar,6),
			new SqlParameter("@PARENT_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@RMA_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@JOB_COST_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@LOCATION_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DIRECT_COST",SqlDbType.Decimal,13),
			new SqlParameter("@PARTS_PER_PANEL",SqlDbType.Decimal,13),
			new SqlParameter("@PRODUCTION_COST",SqlDbType.Decimal,13),
			new SqlParameter("@MATERIAL_COST",SqlDbType.Decimal,13),
			new SqlParameter("@OVERHEAD_COST",SqlDbType.Decimal,13),
			new SqlParameter("@EDITED_BY",SqlDbType.Decimal,9),
			new SqlParameter("@PLANNED_QTY",SqlDbType.Decimal,13),
			new SqlParameter("@RELEASE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@TRAV_PRINTED_BY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@LOT_NUMBER_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@HOLD_STEP_NO",SqlDbType.Decimal,9),
			new SqlParameter("@HARD_LINK_TO_PARENT",SqlDbType.VarChar,1),
			new SqlParameter("@ANALYSIS_CODE_1",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_2",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_3",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_4",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_5",SqlDbType.VarChar,20)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=data0006.RKEY;
			       parameters[3].Value=data0006.WORK_ORDER_NUMBER;
			       parameters[4].Value=data0006.INVENTORY_PTR;
			       parameters[5].Value=data0006.CUST_PART_PTR;
			       parameters[6].Value=data0006.ROOT_PTR;
			       parameters[7].Value=data0006.WHOUSE_PTR;
			       parameters[8].Value=data0006.ENGG_RTE_PTR;
			       parameters[9].Value=data0006.PROD_RTE_PTR;
			       parameters[10].Value=data0006.CSI_USER_PTR;
			       parameters[11].Value=data0006.EMPLOYEE_PTR;
			       parameters[12].Value=data0006.BOM_PTR;
			       parameters[13].Value=data0006.SUB_LEVELS;
			       parameters[14].Value=data0006.PRIORITY_CODE;
			       parameters[15].Value=data0006.ENGG_STATUS;
			       parameters[16].Value=data0006.PROD_STATUS;
			       parameters[17].Value=data0006.ENGG_PROD_FLAG;
			       parameters[18].Value=data0006.ENGG_RTE_MOD_FLAG;
			       parameters[19].Value=data0006.PROD_RTE_MOD_FLAG;
			       parameters[20].Value=data0006.BOM_MOD_FLAG;
			       parameters[21].Value=data0006.QUAN_SCH;
			       parameters[22].Value=data0006.QUAN_REJ;
			       parameters[23].Value=data0006.QUAN_PROD;
					if (data0006.ENT_DATE == DateTime.Parse("1900-1-1") || data0006.ENT_DATE == DateTime.Parse("0001-1-1"))
						parameters[24].Value = null;
					else
						parameters[24].Value=data0006.ENT_DATE;				    
			       parameters[25].Value=data0006.ENT_TIME;
					if (data0006.SCH_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.SCH_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[26].Value = null;
					else
						parameters[26].Value=data0006.SCH_COMPL_DATE;				    
					if (data0006.PROJ_START_DATE == DateTime.Parse("1900-1-1") || data0006.PROJ_START_DATE == DateTime.Parse("0001-1-1"))
						parameters[27].Value = null;
					else
						parameters[27].Value=data0006.PROJ_START_DATE;				    
					if (data0006.PROJ_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.PROJ_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[28].Value = null;
					else
						parameters[28].Value=data0006.PROJ_COMPL_DATE;				    
					if (data0006.CANCEL_HOLD_DATE == DateTime.Parse("1900-1-1") || data0006.CANCEL_HOLD_DATE == DateTime.Parse("0001-1-1"))
						parameters[29].Value = null;
					else
						parameters[29].Value=data0006.CANCEL_HOLD_DATE;				    
					if (data0006.ACT_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.ACT_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[30].Value = null;
					else
						parameters[30].Value=data0006.ACT_COMPL_DATE;				    
			       parameters[31].Value=data0006.CUST_PART_REV_NO;
			       parameters[32].Value=data0006.BOM_REV_NO;
			       parameters[33].Value=data0006.TAG_PTR;
					if (data0006.DT_PTRAV_PRN == DateTime.Parse("1900-1-1") || data0006.DT_PTRAV_PRN == DateTime.Parse("0001-1-1"))
						parameters[34].Value = null;
					else
						parameters[34].Value=data0006.DT_PTRAV_PRN;				    
					if (data0006.DT_ETRAV_PRN == DateTime.Parse("1900-1-1") || data0006.DT_ETRAV_PRN == DateTime.Parse("0001-1-1"))
						parameters[35].Value = null;
					else
						parameters[35].Value=data0006.DT_ETRAV_PRN;				    
			       parameters[36].Value=data0006.SCRAP_RATE;
			       parameters[37].Value=data0006.QUAN_BAL;
			       parameters[38].Value=data0006.BASE_WO;
			       parameters[39].Value=data0006.PARENT_PTR;
			       parameters[40].Value=data0006.RMA_PTR;
			       parameters[41].Value=data0006.JOB_COST_FLAG;
			       parameters[42].Value=data0006.LOCATION_PTR;
			       parameters[43].Value=data0006.DIRECT_COST;
			       parameters[44].Value=data0006.PARTS_PER_PANEL;
			       parameters[45].Value=data0006.PRODUCTION_COST;
			       parameters[46].Value=data0006.MATERIAL_COST;
			       parameters[47].Value=data0006.OVERHEAD_COST;
			       parameters[48].Value=data0006.EDITED_BY;
			       parameters[49].Value=data0006.PLANNED_QTY;
					if (data0006.RELEASE_DATE == DateTime.Parse("1900-1-1") || data0006.RELEASE_DATE == DateTime.Parse("0001-1-1"))
						parameters[50].Value = null;
					else
						parameters[50].Value=data0006.RELEASE_DATE;				    
			       parameters[51].Value=data0006.TRAV_PRINTED_BY_PTR;
			       parameters[52].Value=data0006.LOT_NUMBER_COUNT;
			       parameters[53].Value=data0006.HOLD_STEP_NO;
			       parameters[54].Value=data0006.HARD_LINK_TO_PARENT;
			       parameters[55].Value=data0006.ANALYSIS_CODE_1;
			       parameters[56].Value=data0006.ANALYSIS_CODE_2;
			       parameters[57].Value=data0006.ANALYSIS_CODE_3;
			       parameters[58].Value=data0006.ANALYSIS_CODE_4;
			       parameters[59].Value=data0006.ANALYSIS_CODE_5;
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				data0006.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0006,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0006 data0006)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0006(");
			strSql.Append("WORK_ORDER_NUMBER,INVENTORY_PTR,CUST_PART_PTR,ROOT_PTR,WHOUSE_PTR,ENGG_RTE_PTR,PROD_RTE_PTR,CSI_USER_PTR,EMPLOYEE_PTR,BOM_PTR,SUB_LEVELS,PRIORITY_CODE,ENGG_STATUS,PROD_STATUS,ENGG_PROD_FLAG,ENGG_RTE_MOD_FLAG,PROD_RTE_MOD_FLAG,BOM_MOD_FLAG,QUAN_SCH,QUAN_REJ,QUAN_PROD,ENT_DATE,ENT_TIME,SCH_COMPL_DATE,PROJ_START_DATE,PROJ_COMPL_DATE,CANCEL_HOLD_DATE,ACT_COMPL_DATE,CUST_PART_REV_NO,BOM_REV_NO,TAG_PTR,DT_PTRAV_PRN,DT_ETRAV_PRN,SCRAP_RATE,QUAN_BAL,BASE_WO,PARENT_PTR,RMA_PTR,JOB_COST_FLAG,LOCATION_PTR,DIRECT_COST,PARTS_PER_PANEL,PRODUCTION_COST,MATERIAL_COST,OVERHEAD_COST,EDITED_BY,PLANNED_QTY,RELEASE_DATE,TRAV_PRINTED_BY_PTR,LOT_NUMBER_COUNT,HOLD_STEP_NO,HARD_LINK_TO_PARENT,ANALYSIS_CODE_1,ANALYSIS_CODE_2,ANALYSIS_CODE_3,ANALYSIS_CODE_4,ANALYSIS_CODE_5");
			strSql.Append(" ) values (");
			strSql.Append("@WORK_ORDER_NUMBER,@INVENTORY_PTR,@CUST_PART_PTR,@ROOT_PTR,@WHOUSE_PTR,@ENGG_RTE_PTR,@PROD_RTE_PTR,@CSI_USER_PTR,@EMPLOYEE_PTR,@BOM_PTR,@SUB_LEVELS,@PRIORITY_CODE,@ENGG_STATUS,@PROD_STATUS,@ENGG_PROD_FLAG,@ENGG_RTE_MOD_FLAG,@PROD_RTE_MOD_FLAG,@BOM_MOD_FLAG,@QUAN_SCH,@QUAN_REJ,@QUAN_PROD,@ENT_DATE,@ENT_TIME,@SCH_COMPL_DATE,@PROJ_START_DATE,@PROJ_COMPL_DATE,@CANCEL_HOLD_DATE,@ACT_COMPL_DATE,@CUST_PART_REV_NO,@BOM_REV_NO,@TAG_PTR,@DT_PTRAV_PRN,@DT_ETRAV_PRN,@SCRAP_RATE,@QUAN_BAL,@BASE_WO,@PARENT_PTR,@RMA_PTR,@JOB_COST_FLAG,@LOCATION_PTR,@DIRECT_COST,@PARTS_PER_PANEL,@PRODUCTION_COST,@MATERIAL_COST,@OVERHEAD_COST,@EDITED_BY,@PLANNED_QTY,@RELEASE_DATE,@TRAV_PRINTED_BY_PTR,@LOT_NUMBER_COUNT,@HOLD_STEP_NO,@HARD_LINK_TO_PARENT,@ANALYSIS_CODE_1,@ANALYSIS_CODE_2,@ANALYSIS_CODE_3,@ANALYSIS_CODE_4,@ANALYSIS_CODE_5");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@WORK_ORDER_NUMBER",SqlDbType.VarChar,16),
			new SqlParameter("@INVENTORY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CUST_PART_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ROOT_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@WHOUSE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_RTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PROD_RTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CSI_USER_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMPLOYEE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@BOM_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@SUB_LEVELS",SqlDbType.Decimal,9),
			new SqlParameter("@PRIORITY_CODE",SqlDbType.VarChar,1),
			new SqlParameter("@ENGG_STATUS",SqlDbType.Decimal,9),
			new SqlParameter("@PROD_STATUS",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_PROD_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_RTE_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@PROD_RTE_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BOM_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@QUAN_SCH",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_REJ",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_PROD",SqlDbType.Decimal,13),
			new SqlParameter("@ENT_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@ENT_TIME",SqlDbType.Decimal,9),
			new SqlParameter("@SCH_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@PROJ_START_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@PROJ_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@CANCEL_HOLD_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@ACT_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@CUST_PART_REV_NO",SqlDbType.VarChar,5),
			new SqlParameter("@BOM_REV_NO",SqlDbType.VarChar,10),
			new SqlParameter("@TAG_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DT_PTRAV_PRN",SqlDbType.DateTime,8),
			new SqlParameter("@DT_ETRAV_PRN",SqlDbType.DateTime,8),
			new SqlParameter("@SCRAP_RATE",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_BAL",SqlDbType.Decimal,13),
			new SqlParameter("@BASE_WO",SqlDbType.VarChar,6),
			new SqlParameter("@PARENT_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@RMA_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@JOB_COST_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@LOCATION_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DIRECT_COST",SqlDbType.Decimal,13),
			new SqlParameter("@PARTS_PER_PANEL",SqlDbType.Decimal,13),
			new SqlParameter("@PRODUCTION_COST",SqlDbType.Decimal,13),
			new SqlParameter("@MATERIAL_COST",SqlDbType.Decimal,13),
			new SqlParameter("@OVERHEAD_COST",SqlDbType.Decimal,13),
			new SqlParameter("@EDITED_BY",SqlDbType.Decimal,9),
			new SqlParameter("@PLANNED_QTY",SqlDbType.Decimal,13),
			new SqlParameter("@RELEASE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@TRAV_PRINTED_BY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@LOT_NUMBER_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@HOLD_STEP_NO",SqlDbType.Decimal,9),
			new SqlParameter("@HARD_LINK_TO_PARENT",SqlDbType.VarChar,1),
			new SqlParameter("@ANALYSIS_CODE_1",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_2",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_3",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_4",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_5",SqlDbType.VarChar,20)
			};
			
			       parameters[0].Value=data0006.WORK_ORDER_NUMBER;
			       parameters[1].Value=data0006.INVENTORY_PTR;
			       parameters[2].Value=data0006.CUST_PART_PTR;
			       parameters[3].Value=data0006.ROOT_PTR;
			       parameters[4].Value=data0006.WHOUSE_PTR;
			       parameters[5].Value=data0006.ENGG_RTE_PTR;
			       parameters[6].Value=data0006.PROD_RTE_PTR;
			       parameters[7].Value=data0006.CSI_USER_PTR;
			       parameters[8].Value=data0006.EMPLOYEE_PTR;
			       parameters[9].Value=data0006.BOM_PTR;
			       parameters[10].Value=data0006.SUB_LEVELS;
			       parameters[11].Value=data0006.PRIORITY_CODE;
			       parameters[12].Value=data0006.ENGG_STATUS;
			       parameters[13].Value=data0006.PROD_STATUS;
			       parameters[14].Value=data0006.ENGG_PROD_FLAG;
			       parameters[15].Value=data0006.ENGG_RTE_MOD_FLAG;
			       parameters[16].Value=data0006.PROD_RTE_MOD_FLAG;
			       parameters[17].Value=data0006.BOM_MOD_FLAG;
			       parameters[18].Value=data0006.QUAN_SCH;
			       parameters[19].Value=data0006.QUAN_REJ;
			       parameters[20].Value=data0006.QUAN_PROD;
					if (data0006.ENT_DATE == DateTime.Parse("1900-1-1") || data0006.ENT_DATE == DateTime.Parse("0001-1-1"))
						parameters[21].Value = null;
					else
						parameters[21].Value=data0006.ENT_DATE;				    
			       parameters[22].Value=data0006.ENT_TIME;
					if (data0006.SCH_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.SCH_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[23].Value = null;
					else
						parameters[23].Value=data0006.SCH_COMPL_DATE;				    
					if (data0006.PROJ_START_DATE == DateTime.Parse("1900-1-1") || data0006.PROJ_START_DATE == DateTime.Parse("0001-1-1"))
						parameters[24].Value = null;
					else
						parameters[24].Value=data0006.PROJ_START_DATE;				    
					if (data0006.PROJ_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.PROJ_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[25].Value = null;
					else
						parameters[25].Value=data0006.PROJ_COMPL_DATE;				    
					if (data0006.CANCEL_HOLD_DATE == DateTime.Parse("1900-1-1") || data0006.CANCEL_HOLD_DATE == DateTime.Parse("0001-1-1"))
						parameters[26].Value = null;
					else
						parameters[26].Value=data0006.CANCEL_HOLD_DATE;				    
					if (data0006.ACT_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.ACT_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[27].Value = null;
					else
						parameters[27].Value=data0006.ACT_COMPL_DATE;				    
			       parameters[28].Value=data0006.CUST_PART_REV_NO;
			       parameters[29].Value=data0006.BOM_REV_NO;
			       parameters[30].Value=data0006.TAG_PTR;
					if (data0006.DT_PTRAV_PRN == DateTime.Parse("1900-1-1") || data0006.DT_PTRAV_PRN == DateTime.Parse("0001-1-1"))
						parameters[31].Value = null;
					else
						parameters[31].Value=data0006.DT_PTRAV_PRN;				    
					if (data0006.DT_ETRAV_PRN == DateTime.Parse("1900-1-1") || data0006.DT_ETRAV_PRN == DateTime.Parse("0001-1-1"))
						parameters[32].Value = null;
					else
						parameters[32].Value=data0006.DT_ETRAV_PRN;				    
			       parameters[33].Value=data0006.SCRAP_RATE;
			       parameters[34].Value=data0006.QUAN_BAL;
			       parameters[35].Value=data0006.BASE_WO;
			       parameters[36].Value=data0006.PARENT_PTR;
			       parameters[37].Value=data0006.RMA_PTR;
			       parameters[38].Value=data0006.JOB_COST_FLAG;
			       parameters[39].Value=data0006.LOCATION_PTR;
			       parameters[40].Value=data0006.DIRECT_COST;
			       parameters[41].Value=data0006.PARTS_PER_PANEL;
			       parameters[42].Value=data0006.PRODUCTION_COST;
			       parameters[43].Value=data0006.MATERIAL_COST;
			       parameters[44].Value=data0006.OVERHEAD_COST;
			       parameters[45].Value=data0006.EDITED_BY;
			       parameters[46].Value=data0006.PLANNED_QTY;
					if (data0006.RELEASE_DATE == DateTime.Parse("1900-1-1") || data0006.RELEASE_DATE == DateTime.Parse("0001-1-1"))
						parameters[47].Value = null;
					else
						parameters[47].Value=data0006.RELEASE_DATE;				    
			       parameters[48].Value=data0006.TRAV_PRINTED_BY_PTR;
			       parameters[49].Value=data0006.LOT_NUMBER_COUNT;
			       parameters[50].Value=data0006.HOLD_STEP_NO;
			       parameters[51].Value=data0006.HARD_LINK_TO_PARENT;
			       parameters[52].Value=data0006.ANALYSIS_CODE_1;
			       parameters[53].Value=data0006.ANALYSIS_CODE_2;
			       parameters[54].Value=data0006.ANALYSIS_CODE_3;
			       parameters[55].Value=data0006.ANALYSIS_CODE_4;
			       parameters[56].Value=data0006.ANALYSIS_CODE_5;
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
		/// <param name="DATA0006">data0006对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(DATA0006 data0006)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_DATA0006_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@WORK_ORDER_NUMBER",SqlDbType.VarChar,16),
			new SqlParameter("@INVENTORY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CUST_PART_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ROOT_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@WHOUSE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_RTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PROD_RTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CSI_USER_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMPLOYEE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@BOM_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@SUB_LEVELS",SqlDbType.Decimal,9),
			new SqlParameter("@PRIORITY_CODE",SqlDbType.VarChar,1),
			new SqlParameter("@ENGG_STATUS",SqlDbType.Decimal,9),
			new SqlParameter("@PROD_STATUS",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_PROD_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_RTE_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@PROD_RTE_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BOM_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@QUAN_SCH",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_REJ",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_PROD",SqlDbType.Decimal,13),
			new SqlParameter("@ENT_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@ENT_TIME",SqlDbType.Decimal,9),
			new SqlParameter("@SCH_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@PROJ_START_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@PROJ_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@CANCEL_HOLD_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@ACT_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@CUST_PART_REV_NO",SqlDbType.VarChar,5),
			new SqlParameter("@BOM_REV_NO",SqlDbType.VarChar,10),
			new SqlParameter("@TAG_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DT_PTRAV_PRN",SqlDbType.DateTime,8),
			new SqlParameter("@DT_ETRAV_PRN",SqlDbType.DateTime,8),
			new SqlParameter("@SCRAP_RATE",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_BAL",SqlDbType.Decimal,13),
			new SqlParameter("@BASE_WO",SqlDbType.VarChar,6),
			new SqlParameter("@PARENT_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@RMA_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@JOB_COST_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@LOCATION_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DIRECT_COST",SqlDbType.Decimal,13),
			new SqlParameter("@PARTS_PER_PANEL",SqlDbType.Decimal,13),
			new SqlParameter("@PRODUCTION_COST",SqlDbType.Decimal,13),
			new SqlParameter("@MATERIAL_COST",SqlDbType.Decimal,13),
			new SqlParameter("@OVERHEAD_COST",SqlDbType.Decimal,13),
			new SqlParameter("@EDITED_BY",SqlDbType.Decimal,9),
			new SqlParameter("@PLANNED_QTY",SqlDbType.Decimal,13),
			new SqlParameter("@RELEASE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@TRAV_PRINTED_BY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@LOT_NUMBER_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@HOLD_STEP_NO",SqlDbType.Decimal,9),
			new SqlParameter("@HARD_LINK_TO_PARENT",SqlDbType.VarChar,1),
			new SqlParameter("@ANALYSIS_CODE_1",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_2",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_3",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_4",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_5",SqlDbType.VarChar,20)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0006.RKEY;
			  		parameters[3].Value=data0006.WORK_ORDER_NUMBER;
			  		parameters[4].Value=data0006.INVENTORY_PTR;
			  		parameters[5].Value=data0006.CUST_PART_PTR;
			  		parameters[6].Value=data0006.ROOT_PTR;
			  		parameters[7].Value=data0006.WHOUSE_PTR;
			  		parameters[8].Value=data0006.ENGG_RTE_PTR;
			  		parameters[9].Value=data0006.PROD_RTE_PTR;
			  		parameters[10].Value=data0006.CSI_USER_PTR;
			  		parameters[11].Value=data0006.EMPLOYEE_PTR;
			  		parameters[12].Value=data0006.BOM_PTR;
			  		parameters[13].Value=data0006.SUB_LEVELS;
			  		parameters[14].Value=data0006.PRIORITY_CODE;
			  		parameters[15].Value=data0006.ENGG_STATUS;
			  		parameters[16].Value=data0006.PROD_STATUS;
			  		parameters[17].Value=data0006.ENGG_PROD_FLAG;
			  		parameters[18].Value=data0006.ENGG_RTE_MOD_FLAG;
			  		parameters[19].Value=data0006.PROD_RTE_MOD_FLAG;
			  		parameters[20].Value=data0006.BOM_MOD_FLAG;
			  		parameters[21].Value=data0006.QUAN_SCH;
			  		parameters[22].Value=data0006.QUAN_REJ;
			  		parameters[23].Value=data0006.QUAN_PROD;
					if (data0006.ENT_DATE == DateTime.Parse("1900-1-1") || data0006.ENT_DATE == DateTime.Parse("0001-1-1"))
						parameters[24].Value = null;
					else
						parameters[24].Value=data0006.ENT_DATE;				    
			  		parameters[25].Value=data0006.ENT_TIME;
					if (data0006.SCH_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.SCH_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[26].Value = null;
					else
						parameters[26].Value=data0006.SCH_COMPL_DATE;				    
					if (data0006.PROJ_START_DATE == DateTime.Parse("1900-1-1") || data0006.PROJ_START_DATE == DateTime.Parse("0001-1-1"))
						parameters[27].Value = null;
					else
						parameters[27].Value=data0006.PROJ_START_DATE;				    
					if (data0006.PROJ_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.PROJ_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[28].Value = null;
					else
						parameters[28].Value=data0006.PROJ_COMPL_DATE;				    
					if (data0006.CANCEL_HOLD_DATE == DateTime.Parse("1900-1-1") || data0006.CANCEL_HOLD_DATE == DateTime.Parse("0001-1-1"))
						parameters[29].Value = null;
					else
						parameters[29].Value=data0006.CANCEL_HOLD_DATE;				    
					if (data0006.ACT_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.ACT_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[30].Value = null;
					else
						parameters[30].Value=data0006.ACT_COMPL_DATE;				    
			  		parameters[31].Value=data0006.CUST_PART_REV_NO;
			  		parameters[32].Value=data0006.BOM_REV_NO;
			  		parameters[33].Value=data0006.TAG_PTR;
					if (data0006.DT_PTRAV_PRN == DateTime.Parse("1900-1-1") || data0006.DT_PTRAV_PRN == DateTime.Parse("0001-1-1"))
						parameters[34].Value = null;
					else
						parameters[34].Value=data0006.DT_PTRAV_PRN;				    
					if (data0006.DT_ETRAV_PRN == DateTime.Parse("1900-1-1") || data0006.DT_ETRAV_PRN == DateTime.Parse("0001-1-1"))
						parameters[35].Value = null;
					else
						parameters[35].Value=data0006.DT_ETRAV_PRN;				    
			  		parameters[36].Value=data0006.SCRAP_RATE;
			  		parameters[37].Value=data0006.QUAN_BAL;
			  		parameters[38].Value=data0006.BASE_WO;
			  		parameters[39].Value=data0006.PARENT_PTR;
			  		parameters[40].Value=data0006.RMA_PTR;
			  		parameters[41].Value=data0006.JOB_COST_FLAG;
			  		parameters[42].Value=data0006.LOCATION_PTR;
			  		parameters[43].Value=data0006.DIRECT_COST;
			  		parameters[44].Value=data0006.PARTS_PER_PANEL;
			  		parameters[45].Value=data0006.PRODUCTION_COST;
			  		parameters[46].Value=data0006.MATERIAL_COST;
			  		parameters[47].Value=data0006.OVERHEAD_COST;
			  		parameters[48].Value=data0006.EDITED_BY;
			  		parameters[49].Value=data0006.PLANNED_QTY;
					if (data0006.RELEASE_DATE == DateTime.Parse("1900-1-1") || data0006.RELEASE_DATE == DateTime.Parse("0001-1-1"))
						parameters[50].Value = null;
					else
						parameters[50].Value=data0006.RELEASE_DATE;				    
			  		parameters[51].Value=data0006.TRAV_PRINTED_BY_PTR;
			  		parameters[52].Value=data0006.LOT_NUMBER_COUNT;
			  		parameters[53].Value=data0006.HOLD_STEP_NO;
			  		parameters[54].Value=data0006.HARD_LINK_TO_PARENT;
			  		parameters[55].Value=data0006.ANALYSIS_CODE_1;
			  		parameters[56].Value=data0006.ANALYSIS_CODE_2;
			  		parameters[57].Value=data0006.ANALYSIS_CODE_3;
			  		parameters[58].Value=data0006.ANALYSIS_CODE_4;
			  		parameters[59].Value=data0006.ANALYSIS_CODE_5;
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0006,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0006 data0006)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update DATA0006 set "); 
			strSql.Append("WORK_ORDER_NUMBER=@WORK_ORDER_NUMBER,");
			strSql.Append("INVENTORY_PTR=@INVENTORY_PTR,");
			strSql.Append("CUST_PART_PTR=@CUST_PART_PTR,");
			strSql.Append("ROOT_PTR=@ROOT_PTR,");
			strSql.Append("WHOUSE_PTR=@WHOUSE_PTR,");
			strSql.Append("ENGG_RTE_PTR=@ENGG_RTE_PTR,");
			strSql.Append("PROD_RTE_PTR=@PROD_RTE_PTR,");
			strSql.Append("CSI_USER_PTR=@CSI_USER_PTR,");
			strSql.Append("EMPLOYEE_PTR=@EMPLOYEE_PTR,");
			strSql.Append("BOM_PTR=@BOM_PTR,");
			strSql.Append("SUB_LEVELS=@SUB_LEVELS,");
			strSql.Append("PRIORITY_CODE=@PRIORITY_CODE,");
			strSql.Append("ENGG_STATUS=@ENGG_STATUS,");
			strSql.Append("PROD_STATUS=@PROD_STATUS,");
			strSql.Append("ENGG_PROD_FLAG=@ENGG_PROD_FLAG,");
			strSql.Append("ENGG_RTE_MOD_FLAG=@ENGG_RTE_MOD_FLAG,");
			strSql.Append("PROD_RTE_MOD_FLAG=@PROD_RTE_MOD_FLAG,");
			strSql.Append("BOM_MOD_FLAG=@BOM_MOD_FLAG,");
			strSql.Append("QUAN_SCH=@QUAN_SCH,");
			strSql.Append("QUAN_REJ=@QUAN_REJ,");
			strSql.Append("QUAN_PROD=@QUAN_PROD,");
			strSql.Append("ENT_DATE=@ENT_DATE,");
			strSql.Append("ENT_TIME=@ENT_TIME,");
			strSql.Append("SCH_COMPL_DATE=@SCH_COMPL_DATE,");
			strSql.Append("PROJ_START_DATE=@PROJ_START_DATE,");
			strSql.Append("PROJ_COMPL_DATE=@PROJ_COMPL_DATE,");
			strSql.Append("CANCEL_HOLD_DATE=@CANCEL_HOLD_DATE,");
			strSql.Append("ACT_COMPL_DATE=@ACT_COMPL_DATE,");
			strSql.Append("CUST_PART_REV_NO=@CUST_PART_REV_NO,");
			strSql.Append("BOM_REV_NO=@BOM_REV_NO,");
			strSql.Append("TAG_PTR=@TAG_PTR,");
			strSql.Append("DT_PTRAV_PRN=@DT_PTRAV_PRN,");
			strSql.Append("DT_ETRAV_PRN=@DT_ETRAV_PRN,");
			strSql.Append("SCRAP_RATE=@SCRAP_RATE,");
			strSql.Append("QUAN_BAL=@QUAN_BAL,");
			strSql.Append("BASE_WO=@BASE_WO,");
			strSql.Append("PARENT_PTR=@PARENT_PTR,");
			strSql.Append("RMA_PTR=@RMA_PTR,");
			strSql.Append("JOB_COST_FLAG=@JOB_COST_FLAG,");
			strSql.Append("LOCATION_PTR=@LOCATION_PTR,");
			strSql.Append("DIRECT_COST=@DIRECT_COST,");
			strSql.Append("PARTS_PER_PANEL=@PARTS_PER_PANEL,");
			strSql.Append("PRODUCTION_COST=@PRODUCTION_COST,");
			strSql.Append("MATERIAL_COST=@MATERIAL_COST,");
			strSql.Append("OVERHEAD_COST=@OVERHEAD_COST,");
			strSql.Append("EDITED_BY=@EDITED_BY,");
			strSql.Append("PLANNED_QTY=@PLANNED_QTY,");
			strSql.Append("RELEASE_DATE=@RELEASE_DATE,");
			strSql.Append("TRAV_PRINTED_BY_PTR=@TRAV_PRINTED_BY_PTR,");
			strSql.Append("LOT_NUMBER_COUNT=@LOT_NUMBER_COUNT,");
			strSql.Append("HOLD_STEP_NO=@HOLD_STEP_NO,");
			strSql.Append("HARD_LINK_TO_PARENT=@HARD_LINK_TO_PARENT,");
			strSql.Append("ANALYSIS_CODE_1=@ANALYSIS_CODE_1,");
			strSql.Append("ANALYSIS_CODE_2=@ANALYSIS_CODE_2,");
			strSql.Append("ANALYSIS_CODE_3=@ANALYSIS_CODE_3,");
			strSql.Append("ANALYSIS_CODE_4=@ANALYSIS_CODE_4,");
			strSql.Append("ANALYSIS_CODE_5=@ANALYSIS_CODE_5");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@WORK_ORDER_NUMBER",SqlDbType.VarChar,16),
			new SqlParameter("@INVENTORY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CUST_PART_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ROOT_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@WHOUSE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_RTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PROD_RTE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CSI_USER_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMPLOYEE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@BOM_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@SUB_LEVELS",SqlDbType.Decimal,9),
			new SqlParameter("@PRIORITY_CODE",SqlDbType.VarChar,1),
			new SqlParameter("@ENGG_STATUS",SqlDbType.Decimal,9),
			new SqlParameter("@PROD_STATUS",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_PROD_FLAG",SqlDbType.Decimal,9),
			new SqlParameter("@ENGG_RTE_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@PROD_RTE_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BOM_MOD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@QUAN_SCH",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_REJ",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_PROD",SqlDbType.Decimal,13),
			new SqlParameter("@ENT_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@ENT_TIME",SqlDbType.Decimal,9),
			new SqlParameter("@SCH_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@PROJ_START_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@PROJ_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@CANCEL_HOLD_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@ACT_COMPL_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@CUST_PART_REV_NO",SqlDbType.VarChar,5),
			new SqlParameter("@BOM_REV_NO",SqlDbType.VarChar,10),
			new SqlParameter("@TAG_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DT_PTRAV_PRN",SqlDbType.DateTime,8),
			new SqlParameter("@DT_ETRAV_PRN",SqlDbType.DateTime,8),
			new SqlParameter("@SCRAP_RATE",SqlDbType.Decimal,13),
			new SqlParameter("@QUAN_BAL",SqlDbType.Decimal,13),
			new SqlParameter("@BASE_WO",SqlDbType.VarChar,6),
			new SqlParameter("@PARENT_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@RMA_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@JOB_COST_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@LOCATION_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@DIRECT_COST",SqlDbType.Decimal,13),
			new SqlParameter("@PARTS_PER_PANEL",SqlDbType.Decimal,13),
			new SqlParameter("@PRODUCTION_COST",SqlDbType.Decimal,13),
			new SqlParameter("@MATERIAL_COST",SqlDbType.Decimal,13),
			new SqlParameter("@OVERHEAD_COST",SqlDbType.Decimal,13),
			new SqlParameter("@EDITED_BY",SqlDbType.Decimal,9),
			new SqlParameter("@PLANNED_QTY",SqlDbType.Decimal,13),
			new SqlParameter("@RELEASE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@TRAV_PRINTED_BY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@LOT_NUMBER_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@HOLD_STEP_NO",SqlDbType.Decimal,9),
			new SqlParameter("@HARD_LINK_TO_PARENT",SqlDbType.VarChar,1),
			new SqlParameter("@ANALYSIS_CODE_1",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_2",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_3",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_4",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE_5",SqlDbType.VarChar,20)
			};
			
			parameters[0].Value = data0006.RKEY;
			       parameters[1].Value=data0006.WORK_ORDER_NUMBER;
			       parameters[2].Value=data0006.INVENTORY_PTR;
			       parameters[3].Value=data0006.CUST_PART_PTR;
			       parameters[4].Value=data0006.ROOT_PTR;
			       parameters[5].Value=data0006.WHOUSE_PTR;
			       parameters[6].Value=data0006.ENGG_RTE_PTR;
			       parameters[7].Value=data0006.PROD_RTE_PTR;
			       parameters[8].Value=data0006.CSI_USER_PTR;
			       parameters[9].Value=data0006.EMPLOYEE_PTR;
			       parameters[10].Value=data0006.BOM_PTR;
			       parameters[11].Value=data0006.SUB_LEVELS;
			       parameters[12].Value=data0006.PRIORITY_CODE;
			       parameters[13].Value=data0006.ENGG_STATUS;
			       parameters[14].Value=data0006.PROD_STATUS;
			       parameters[15].Value=data0006.ENGG_PROD_FLAG;
			       parameters[16].Value=data0006.ENGG_RTE_MOD_FLAG;
			       parameters[17].Value=data0006.PROD_RTE_MOD_FLAG;
			       parameters[18].Value=data0006.BOM_MOD_FLAG;
			       parameters[19].Value=data0006.QUAN_SCH;
			       parameters[20].Value=data0006.QUAN_REJ;
			       parameters[21].Value=data0006.QUAN_PROD;
					if (data0006.ENT_DATE == DateTime.Parse("1900-1-1") || data0006.ENT_DATE == DateTime.Parse("0001-1-1"))
						parameters[22].Value = null;
					else
						parameters[22].Value=data0006.ENT_DATE;				    
			       parameters[23].Value=data0006.ENT_TIME;
					if (data0006.SCH_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.SCH_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[24].Value = null;
					else
						parameters[24].Value=data0006.SCH_COMPL_DATE;				    
					if (data0006.PROJ_START_DATE == DateTime.Parse("1900-1-1") || data0006.PROJ_START_DATE == DateTime.Parse("0001-1-1"))
						parameters[25].Value = null;
					else
						parameters[25].Value=data0006.PROJ_START_DATE;				    
					if (data0006.PROJ_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.PROJ_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[26].Value = null;
					else
						parameters[26].Value=data0006.PROJ_COMPL_DATE;				    
					if (data0006.CANCEL_HOLD_DATE == DateTime.Parse("1900-1-1") || data0006.CANCEL_HOLD_DATE == DateTime.Parse("0001-1-1"))
						parameters[27].Value = null;
					else
						parameters[27].Value=data0006.CANCEL_HOLD_DATE;				    
					if (data0006.ACT_COMPL_DATE == DateTime.Parse("1900-1-1") || data0006.ACT_COMPL_DATE == DateTime.Parse("0001-1-1"))
						parameters[28].Value = null;
					else
						parameters[28].Value=data0006.ACT_COMPL_DATE;				    
			       parameters[29].Value=data0006.CUST_PART_REV_NO;
			       parameters[30].Value=data0006.BOM_REV_NO;
			       parameters[31].Value=data0006.TAG_PTR;
					if (data0006.DT_PTRAV_PRN == DateTime.Parse("1900-1-1") || data0006.DT_PTRAV_PRN == DateTime.Parse("0001-1-1"))
						parameters[32].Value = null;
					else
						parameters[32].Value=data0006.DT_PTRAV_PRN;				    
					if (data0006.DT_ETRAV_PRN == DateTime.Parse("1900-1-1") || data0006.DT_ETRAV_PRN == DateTime.Parse("0001-1-1"))
						parameters[33].Value = null;
					else
						parameters[33].Value=data0006.DT_ETRAV_PRN;				    
			       parameters[34].Value=data0006.SCRAP_RATE;
			       parameters[35].Value=data0006.QUAN_BAL;
			       parameters[36].Value=data0006.BASE_WO;
			       parameters[37].Value=data0006.PARENT_PTR;
			       parameters[38].Value=data0006.RMA_PTR;
			       parameters[39].Value=data0006.JOB_COST_FLAG;
			       parameters[40].Value=data0006.LOCATION_PTR;
			       parameters[41].Value=data0006.DIRECT_COST;
			       parameters[42].Value=data0006.PARTS_PER_PANEL;
			       parameters[43].Value=data0006.PRODUCTION_COST;
			       parameters[44].Value=data0006.MATERIAL_COST;
			       parameters[45].Value=data0006.OVERHEAD_COST;
			       parameters[46].Value=data0006.EDITED_BY;
			       parameters[47].Value=data0006.PLANNED_QTY;
					if (data0006.RELEASE_DATE == DateTime.Parse("1900-1-1") || data0006.RELEASE_DATE == DateTime.Parse("0001-1-1"))
						parameters[48].Value = null;
					else
						parameters[48].Value=data0006.RELEASE_DATE;				    
			       parameters[49].Value=data0006.TRAV_PRINTED_BY_PTR;
			       parameters[50].Value=data0006.LOT_NUMBER_COUNT;
			       parameters[51].Value=data0006.HOLD_STEP_NO;
			       parameters[52].Value=data0006.HARD_LINK_TO_PARENT;
			       parameters[53].Value=data0006.ANALYSIS_CODE_1;
			       parameters[54].Value=data0006.ANALYSIS_CODE_2;
			       parameters[55].Value=data0006.ANALYSIS_CODE_3;
			       parameters[56].Value=data0006.ANALYSIS_CODE_4;
			       parameters[57].Value=data0006.ANALYSIS_CODE_5;
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
		/// <param name="data0006">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(DATA0006 data0006)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_DATA0006_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0006.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0006,delete successful");
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
		/// <param name="data0006">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.DATA0006 where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0006,delete successful");
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
			strSql.Append("delete from data0006 ");
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
		///<returns>DATA0006对象</returns>		
		public DATA0006 getDATA0006ByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(work_order_number,'') as work_order_number
				,
				isNull(inventory_ptr,0) as inventory_ptr
				,
				isNull(cust_part_ptr,0) as cust_part_ptr
				,
				isNull(root_ptr,0) as root_ptr
				,
				isNull(whouse_ptr,0) as whouse_ptr
				,
				isNull(engg_rte_ptr,0) as engg_rte_ptr
				,
				isNull(prod_rte_ptr,0) as prod_rte_ptr
				,
				isNull(csi_user_ptr,0) as csi_user_ptr
				,
				isNull(employee_ptr,0) as employee_ptr
				,
				isNull(bom_ptr,0) as bom_ptr
				,
				isNull(sub_levels,0) as sub_levels
				,
				isNull(priority_code,'') as priority_code
				,
				isNull(engg_status,0) as engg_status
				,
				isNull(prod_status,0) as prod_status
				,
				isNull(engg_prod_flag,0) as engg_prod_flag
				,
				isNull(engg_rte_mod_flag,'') as engg_rte_mod_flag
				,
				isNull(prod_rte_mod_flag,'') as prod_rte_mod_flag
				,
				isNull(bom_mod_flag,'') as bom_mod_flag
				,
				isNull(quan_sch,0) as quan_sch
				,
				isNull(quan_rej,0) as quan_rej
				,
				isNull(quan_prod,0) as quan_prod
				,
				isNull(ent_date,'1900-1-1') as ent_date
				,
				isNull(ent_time,0) as ent_time
				,
				isNull(sch_compl_date,'1900-1-1') as sch_compl_date
				,
				isNull(proj_start_date,'1900-1-1') as proj_start_date
				,
				isNull(proj_compl_date,'1900-1-1') as proj_compl_date
				,
				isNull(cancel_hold_date,'1900-1-1') as cancel_hold_date
				,
				isNull(act_compl_date,'1900-1-1') as act_compl_date
				,
				isNull(cust_part_rev_no,'') as cust_part_rev_no
				,
				isNull(bom_rev_no,'') as bom_rev_no
				,
				isNull(tag_ptr,0) as tag_ptr
				,
				isNull(dt_ptrav_prn,'1900-1-1') as dt_ptrav_prn
				,
				isNull(dt_etrav_prn,'1900-1-1') as dt_etrav_prn
				,
				isNull(scrap_rate,0) as scrap_rate
				,
				isNull(quan_bal,0) as quan_bal
				,
				isNull(base_wo,'') as base_wo
				,
				isNull(parent_ptr,0) as parent_ptr
				,
				isNull(rma_ptr,0) as rma_ptr
				,
				isNull(job_cost_flag,'') as job_cost_flag
				,
				isNull(location_ptr,0) as location_ptr
				,
				isNull(direct_cost,0) as direct_cost
				,
				isNull(parts_per_panel,0) as parts_per_panel
				,
				isNull(production_cost,0) as production_cost
				,
				isNull(material_cost,0) as material_cost
				,
				isNull(overhead_cost,0) as overhead_cost
				,
				isNull(edited_by,0) as edited_by
				,
				isNull(planned_qty,0) as planned_qty
				,
				isNull(release_date,'1900-1-1') as release_date
				,
				isNull(trav_printed_by_ptr,0) as trav_printed_by_ptr
				,
				isNull(lot_number_count,0) as lot_number_count
				,
				isNull(hold_step_no,0) as hold_step_no
				,
				isNull(hard_link_to_parent,'') as hard_link_to_parent
				,
				isNull(analysis_code_1,'') as analysis_code_1
				,
				isNull(analysis_code_2,'') as analysis_code_2
				,
				isNull(analysis_code_3,'') as analysis_code_3
				,
				isNull(analysis_code_4,'') as analysis_code_4
				,
				isNull(analysis_code_5,'') as analysis_code_5
				
			from DATA0006 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			DATA0006  data0006=null;
			
			#region 数据库操作
            try
            {
				 data0006=new DATA0006();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    data0006.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
								   data0006.WORK_ORDER_NUMBER =row["WORK_ORDER_NUMBER"].ToString();
							  	        data0006.INVENTORY_PTR =decimal.Parse(row["INVENTORY_PTR"].ToString());
							  	        data0006.CUST_PART_PTR =decimal.Parse(row["CUST_PART_PTR"].ToString());
							  	        data0006.ROOT_PTR =decimal.Parse(row["ROOT_PTR"].ToString());
							  	        data0006.WHOUSE_PTR =decimal.Parse(row["WHOUSE_PTR"].ToString());
							  	        data0006.ENGG_RTE_PTR =decimal.Parse(row["ENGG_RTE_PTR"].ToString());
							  	        data0006.PROD_RTE_PTR =decimal.Parse(row["PROD_RTE_PTR"].ToString());
							  	        data0006.CSI_USER_PTR =decimal.Parse(row["CSI_USER_PTR"].ToString());
							  	        data0006.EMPLOYEE_PTR =decimal.Parse(row["EMPLOYEE_PTR"].ToString());
							  	        data0006.BOM_PTR =decimal.Parse(row["BOM_PTR"].ToString());
							  	        data0006.SUB_LEVELS =decimal.Parse(row["SUB_LEVELS"].ToString());
								   data0006.PRIORITY_CODE =row["PRIORITY_CODE"].ToString();
							  	        data0006.ENGG_STATUS =decimal.Parse(row["ENGG_STATUS"].ToString());
							  	        data0006.PROD_STATUS =decimal.Parse(row["PROD_STATUS"].ToString());
							  	        data0006.ENGG_PROD_FLAG =decimal.Parse(row["ENGG_PROD_FLAG"].ToString());
								   data0006.ENGG_RTE_MOD_FLAG =row["ENGG_RTE_MOD_FLAG"].ToString();
								   data0006.PROD_RTE_MOD_FLAG =row["PROD_RTE_MOD_FLAG"].ToString();
								   data0006.BOM_MOD_FLAG =row["BOM_MOD_FLAG"].ToString();
							  	        data0006.QUAN_SCH =decimal.Parse(row["QUAN_SCH"].ToString());
							  	        data0006.QUAN_REJ =decimal.Parse(row["QUAN_REJ"].ToString());
							  	        data0006.QUAN_PROD =decimal.Parse(row["QUAN_PROD"].ToString());
							  	        data0006.ENT_DATE =DateTime.Parse(row["ENT_DATE"].ToString());
							  	        data0006.ENT_TIME =decimal.Parse(row["ENT_TIME"].ToString());
							  	        data0006.SCH_COMPL_DATE =DateTime.Parse(row["SCH_COMPL_DATE"].ToString());
							  	        data0006.PROJ_START_DATE =DateTime.Parse(row["PROJ_START_DATE"].ToString());
							  	        data0006.PROJ_COMPL_DATE =DateTime.Parse(row["PROJ_COMPL_DATE"].ToString());
							  	        data0006.CANCEL_HOLD_DATE =DateTime.Parse(row["CANCEL_HOLD_DATE"].ToString());
							  	        data0006.ACT_COMPL_DATE =DateTime.Parse(row["ACT_COMPL_DATE"].ToString());
								   data0006.CUST_PART_REV_NO =row["CUST_PART_REV_NO"].ToString();
								   data0006.BOM_REV_NO =row["BOM_REV_NO"].ToString();
							  	        data0006.TAG_PTR =decimal.Parse(row["TAG_PTR"].ToString());
							  	        data0006.DT_PTRAV_PRN =DateTime.Parse(row["DT_PTRAV_PRN"].ToString());
							  	        data0006.DT_ETRAV_PRN =DateTime.Parse(row["DT_ETRAV_PRN"].ToString());
							  	        data0006.SCRAP_RATE =decimal.Parse(row["SCRAP_RATE"].ToString());
							  	        data0006.QUAN_BAL =decimal.Parse(row["QUAN_BAL"].ToString());
								   data0006.BASE_WO =row["BASE_WO"].ToString();
							  	        data0006.PARENT_PTR =decimal.Parse(row["PARENT_PTR"].ToString());
							  	        data0006.RMA_PTR =decimal.Parse(row["RMA_PTR"].ToString());
								   data0006.JOB_COST_FLAG =row["JOB_COST_FLAG"].ToString();
							  	        data0006.LOCATION_PTR =decimal.Parse(row["LOCATION_PTR"].ToString());
							  	        data0006.DIRECT_COST =decimal.Parse(row["DIRECT_COST"].ToString());
							  	        data0006.PARTS_PER_PANEL =decimal.Parse(row["PARTS_PER_PANEL"].ToString());
							  	        data0006.PRODUCTION_COST =decimal.Parse(row["PRODUCTION_COST"].ToString());
							  	        data0006.MATERIAL_COST =decimal.Parse(row["MATERIAL_COST"].ToString());
							  	        data0006.OVERHEAD_COST =decimal.Parse(row["OVERHEAD_COST"].ToString());
							  	        data0006.EDITED_BY =decimal.Parse(row["EDITED_BY"].ToString());
							  	        data0006.PLANNED_QTY =decimal.Parse(row["PLANNED_QTY"].ToString());
							  	        data0006.RELEASE_DATE =DateTime.Parse(row["RELEASE_DATE"].ToString());
							  	        data0006.TRAV_PRINTED_BY_PTR =decimal.Parse(row["TRAV_PRINTED_BY_PTR"].ToString());
							  	        data0006.LOT_NUMBER_COUNT =decimal.Parse(row["LOT_NUMBER_COUNT"].ToString());
							  	        data0006.HOLD_STEP_NO =decimal.Parse(row["HOLD_STEP_NO"].ToString());
								   data0006.HARD_LINK_TO_PARENT =row["HARD_LINK_TO_PARENT"].ToString();
								   data0006.ANALYSIS_CODE_1 =row["ANALYSIS_CODE_1"].ToString();
								   data0006.ANALYSIS_CODE_2 =row["ANALYSIS_CODE_2"].ToString();
								   data0006.ANALYSIS_CODE_3 =row["ANALYSIS_CODE_3"].ToString();
								   data0006.ANALYSIS_CODE_4 =row["ANALYSIS_CODE_4"].ToString();
								   data0006.ANALYSIS_CODE_5 =row["ANALYSIS_CODE_5"].ToString();
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return data0006;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< DATA0006 >  FindAllDATA0006()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<DATA0006>数据集合</returns>		
		public IList< DATA0006> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(work_order_number,'') as work_order_number
				,
				isNull(inventory_ptr,0) as inventory_ptr
				,
				isNull(cust_part_ptr,0) as cust_part_ptr
				,
				isNull(root_ptr,0) as root_ptr
				,
				isNull(whouse_ptr,0) as whouse_ptr
				,
				isNull(engg_rte_ptr,0) as engg_rte_ptr
				,
				isNull(prod_rte_ptr,0) as prod_rte_ptr
				,
				isNull(csi_user_ptr,0) as csi_user_ptr
				,
				isNull(employee_ptr,0) as employee_ptr
				,
				isNull(bom_ptr,0) as bom_ptr
				,
				isNull(sub_levels,0) as sub_levels
				,
				isNull(priority_code,'') as priority_code
				,
				isNull(engg_status,0) as engg_status
				,
				isNull(prod_status,0) as prod_status
				,
				isNull(engg_prod_flag,0) as engg_prod_flag
				,
				isNull(engg_rte_mod_flag,'') as engg_rte_mod_flag
				,
				isNull(prod_rte_mod_flag,'') as prod_rte_mod_flag
				,
				isNull(bom_mod_flag,'') as bom_mod_flag
				,
				isNull(quan_sch,0) as quan_sch
				,
				isNull(quan_rej,0) as quan_rej
				,
				isNull(quan_prod,0) as quan_prod
				,
				isNull(ent_date,'1900-1-1') as ent_date
				,
				isNull(ent_time,0) as ent_time
				,
				isNull(sch_compl_date,'1900-1-1') as sch_compl_date
				,
				isNull(proj_start_date,'1900-1-1') as proj_start_date
				,
				isNull(proj_compl_date,'1900-1-1') as proj_compl_date
				,
				isNull(cancel_hold_date,'1900-1-1') as cancel_hold_date
				,
				isNull(act_compl_date,'1900-1-1') as act_compl_date
				,
				isNull(cust_part_rev_no,'') as cust_part_rev_no
				,
				isNull(bom_rev_no,'') as bom_rev_no
				,
				isNull(tag_ptr,0) as tag_ptr
				,
				isNull(dt_ptrav_prn,'1900-1-1') as dt_ptrav_prn
				,
				isNull(dt_etrav_prn,'1900-1-1') as dt_etrav_prn
				,
				isNull(scrap_rate,0) as scrap_rate
				,
				isNull(quan_bal,0) as quan_bal
				,
				isNull(base_wo,'') as base_wo
				,
				isNull(parent_ptr,0) as parent_ptr
				,
				isNull(rma_ptr,0) as rma_ptr
				,
				isNull(job_cost_flag,'') as job_cost_flag
				,
				isNull(location_ptr,0) as location_ptr
				,
				isNull(direct_cost,0) as direct_cost
				,
				isNull(parts_per_panel,0) as parts_per_panel
				,
				isNull(production_cost,0) as production_cost
				,
				isNull(material_cost,0) as material_cost
				,
				isNull(overhead_cost,0) as overhead_cost
				,
				isNull(edited_by,0) as edited_by
				,
				isNull(planned_qty,0) as planned_qty
				,
				isNull(release_date,'1900-1-1') as release_date
				,
				isNull(trav_printed_by_ptr,0) as trav_printed_by_ptr
				,
				isNull(lot_number_count,0) as lot_number_count
				,
				isNull(hold_step_no,0) as hold_step_no
				,
				isNull(hard_link_to_parent,'') as hard_link_to_parent
				,
				isNull(analysis_code_1,'') as analysis_code_1
				,
				isNull(analysis_code_2,'') as analysis_code_2
				,
				isNull(analysis_code_3,'') as analysis_code_3
				,
				isNull(analysis_code_4,'') as analysis_code_4
				,
				isNull(analysis_code_5,'') as analysis_code_5
				
			from DATA0006 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<DATA0006> resultList=new List<DATA0006>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							DATA0006  data0006 =new DATA0006();
							
								data0006.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
							      data0006.WORK_ORDER_NUMBER =row["WORK_ORDER_NUMBER"].ToString();
								  	data0006.INVENTORY_PTR =decimal.Parse(row["INVENTORY_PTR"].ToString()) ;
								  	data0006.CUST_PART_PTR =decimal.Parse(row["CUST_PART_PTR"].ToString()) ;
								  	data0006.ROOT_PTR =decimal.Parse(row["ROOT_PTR"].ToString()) ;
								  	data0006.WHOUSE_PTR =decimal.Parse(row["WHOUSE_PTR"].ToString()) ;
								  	data0006.ENGG_RTE_PTR =decimal.Parse(row["ENGG_RTE_PTR"].ToString()) ;
								  	data0006.PROD_RTE_PTR =decimal.Parse(row["PROD_RTE_PTR"].ToString()) ;
								  	data0006.CSI_USER_PTR =decimal.Parse(row["CSI_USER_PTR"].ToString()) ;
								  	data0006.EMPLOYEE_PTR =decimal.Parse(row["EMPLOYEE_PTR"].ToString()) ;
								  	data0006.BOM_PTR =decimal.Parse(row["BOM_PTR"].ToString()) ;
								  	data0006.SUB_LEVELS =decimal.Parse(row["SUB_LEVELS"].ToString()) ;
							      data0006.PRIORITY_CODE =row["PRIORITY_CODE"].ToString();
								  	data0006.ENGG_STATUS =decimal.Parse(row["ENGG_STATUS"].ToString()) ;
								  	data0006.PROD_STATUS =decimal.Parse(row["PROD_STATUS"].ToString()) ;
								  	data0006.ENGG_PROD_FLAG =decimal.Parse(row["ENGG_PROD_FLAG"].ToString()) ;
							      data0006.ENGG_RTE_MOD_FLAG =row["ENGG_RTE_MOD_FLAG"].ToString();
							      data0006.PROD_RTE_MOD_FLAG =row["PROD_RTE_MOD_FLAG"].ToString();
							      data0006.BOM_MOD_FLAG =row["BOM_MOD_FLAG"].ToString();
								  	data0006.QUAN_SCH =decimal.Parse(row["QUAN_SCH"].ToString()) ;
								  	data0006.QUAN_REJ =decimal.Parse(row["QUAN_REJ"].ToString()) ;
								  	data0006.QUAN_PROD =decimal.Parse(row["QUAN_PROD"].ToString()) ;
								  	data0006.ENT_DATE =DateTime.Parse(row["ENT_DATE"].ToString()) ;
								  	data0006.ENT_TIME =decimal.Parse(row["ENT_TIME"].ToString()) ;
								  	data0006.SCH_COMPL_DATE =DateTime.Parse(row["SCH_COMPL_DATE"].ToString()) ;
								  	data0006.PROJ_START_DATE =DateTime.Parse(row["PROJ_START_DATE"].ToString()) ;
								  	data0006.PROJ_COMPL_DATE =DateTime.Parse(row["PROJ_COMPL_DATE"].ToString()) ;
								  	data0006.CANCEL_HOLD_DATE =DateTime.Parse(row["CANCEL_HOLD_DATE"].ToString()) ;
								  	data0006.ACT_COMPL_DATE =DateTime.Parse(row["ACT_COMPL_DATE"].ToString()) ;
							      data0006.CUST_PART_REV_NO =row["CUST_PART_REV_NO"].ToString();
							      data0006.BOM_REV_NO =row["BOM_REV_NO"].ToString();
								  	data0006.TAG_PTR =decimal.Parse(row["TAG_PTR"].ToString()) ;
								  	data0006.DT_PTRAV_PRN =DateTime.Parse(row["DT_PTRAV_PRN"].ToString()) ;
								  	data0006.DT_ETRAV_PRN =DateTime.Parse(row["DT_ETRAV_PRN"].ToString()) ;
								  	data0006.SCRAP_RATE =decimal.Parse(row["SCRAP_RATE"].ToString()) ;
								  	data0006.QUAN_BAL =decimal.Parse(row["QUAN_BAL"].ToString()) ;
							      data0006.BASE_WO =row["BASE_WO"].ToString();
								  	data0006.PARENT_PTR =decimal.Parse(row["PARENT_PTR"].ToString()) ;
								  	data0006.RMA_PTR =decimal.Parse(row["RMA_PTR"].ToString()) ;
							      data0006.JOB_COST_FLAG =row["JOB_COST_FLAG"].ToString();
								  	data0006.LOCATION_PTR =decimal.Parse(row["LOCATION_PTR"].ToString()) ;
								  	data0006.DIRECT_COST =decimal.Parse(row["DIRECT_COST"].ToString()) ;
								  	data0006.PARTS_PER_PANEL =decimal.Parse(row["PARTS_PER_PANEL"].ToString()) ;
								  	data0006.PRODUCTION_COST =decimal.Parse(row["PRODUCTION_COST"].ToString()) ;
								  	data0006.MATERIAL_COST =decimal.Parse(row["MATERIAL_COST"].ToString()) ;
								  	data0006.OVERHEAD_COST =decimal.Parse(row["OVERHEAD_COST"].ToString()) ;
								  	data0006.EDITED_BY =decimal.Parse(row["EDITED_BY"].ToString()) ;
								  	data0006.PLANNED_QTY =decimal.Parse(row["PLANNED_QTY"].ToString()) ;
								  	data0006.RELEASE_DATE =DateTime.Parse(row["RELEASE_DATE"].ToString()) ;
								  	data0006.TRAV_PRINTED_BY_PTR =decimal.Parse(row["TRAV_PRINTED_BY_PTR"].ToString()) ;
								  	data0006.LOT_NUMBER_COUNT =decimal.Parse(row["LOT_NUMBER_COUNT"].ToString()) ;
								  	data0006.HOLD_STEP_NO =decimal.Parse(row["HOLD_STEP_NO"].ToString()) ;
							      data0006.HARD_LINK_TO_PARENT =row["HARD_LINK_TO_PARENT"].ToString();
							      data0006.ANALYSIS_CODE_1 =row["ANALYSIS_CODE_1"].ToString();
							      data0006.ANALYSIS_CODE_2 =row["ANALYSIS_CODE_2"].ToString();
							      data0006.ANALYSIS_CODE_3 =row["ANALYSIS_CODE_3"].ToString();
							      data0006.ANALYSIS_CODE_4 =row["ANALYSIS_CODE_4"].ToString();
							      data0006.ANALYSIS_CODE_5 =row["ANALYSIS_CODE_5"].ToString();
		
							resultList.Add(data0006);
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
        /// <summary>
        /// 通过父ID找子Rkey
        /// </summary>
        /// <returns></returns>
        public List<decimal> getRKEYByParent(decimal parent_id)
        {
            List<decimal> rkeyList = new List<decimal>();
            string sql = "select RKEY from data0006 where PARENT_PTR=" + parent_id;
            using (SqlDataReader read = dbHelper.GetReader(sql))
            {
                while (read.Read())
                {
                    rkeyList.Add(Convert.ToDecimal(read["RKEY"]));
                }
            }
            return rkeyList;
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

