//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 15:57:12
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
	/// 数据访问层   DATA0010DAL
	/// </summary>
	public  partial class DATA0010DAL
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
		public 	DATA0010DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0010DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	DATA0010DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	DATA0010DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	DATA0010DAL(DBHelper DB)
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
		/// <param name="DATA0010">data0010对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(DATA0010 data0010)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_DATA0010_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@CUST_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@CUSTOMER_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@BILLING_ADDRESS_1",SqlDbType.VarChar,30),
			new SqlParameter("@BILLING_ADDRESS_2",SqlDbType.VarChar,30),
			new SqlParameter("@BILLING_ADDRESS_3",SqlDbType.VarChar,30),
			new SqlParameter("@STATE",SqlDbType.VarChar,3),
			new SqlParameter("@ZIP",SqlDbType.VarChar,10),
			new SqlParameter("@PHONE",SqlDbType.VarChar,30),
			new SqlParameter("@FAX",SqlDbType.VarChar,30),
			new SqlParameter("@TELEX",SqlDbType.VarChar,30),
			new SqlParameter("@SALES_REP_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CURRENCY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@QUOTE_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@INVOICE_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PACKSLP_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ORDRACK_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CRDTMEM_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@STATMNT_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@OPENORD_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CONTACT_NAME_1",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_2",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_3",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_4",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_5",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_6",SqlDbType.VarChar,20),
			new SqlParameter("@CONT_PHONE_1",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_2",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_3",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_4",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_5",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_6",SqlDbType.VarChar,30),
			new SqlParameter("@FED_TAX_ID_NO",SqlDbType.VarChar,15),
			new SqlParameter("@COFC_FILENAME",SqlDbType.VarChar,15),
			new SqlParameter("@COD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@REG_TAX_FIXED_UNUSED",SqlDbType.VarChar,1),
			new SqlParameter("@DISCOUNT_PCT",SqlDbType.Decimal,13),
			new SqlParameter("@HIGH_BALANCE",SqlDbType.Decimal,13),
			new SqlParameter("@CREDIT_LIMIT",SqlDbType.Decimal,13),
			new SqlParameter("@CREDIT_RATING",SqlDbType.VarChar,1),
			new SqlParameter("@BALANCE_DUE",SqlDbType.Decimal,13),
			new SqlParameter("@OUTSTANDING_CREDIT",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_BILLINGS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_RETURNS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_DISCOUNT",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_BILLINGS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_RETURNS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_DISCOUNT",SqlDbType.Decimal,13),
			new SqlParameter("@DISCOUNT_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@CURRENT_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@NET_PAY",SqlDbType.Decimal,9),
			new SqlParameter("@LAST_ACTIVE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@LANGUAGE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BILLING_ADDRESS_4",SqlDbType.VarChar,30),
			new SqlParameter("@COUNTRY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@INTERNAL_ECN_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@EXTERNAL_ECN_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@OUTGOING_FORM_NAME",SqlDbType.VarChar,60),
			new SqlParameter("@OUTGOING_FORM_ADDR1",SqlDbType.VarChar,45),
			new SqlParameter("@OUTGOING_FORM_ADDR2",SqlDbType.VarChar,45),
			new SqlParameter("@OUTGOING_FORM_ADDR3",SqlDbType.VarChar,45),
			new SqlParameter("@ANALYSIS_CODE1",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE2",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE3",SqlDbType.VarChar,20),
			new SqlParameter("@CUST_ENT_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@EDI_ID",SqlDbType.VarChar,50),
			new SqlParameter("@EDI_FLAG_FOR_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_FLAG_FOR_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_FLAG_CREDIT_MEMO",SqlDbType.Decimal,9),
			new SqlParameter("@GEN_EMAIL_ADDRESS",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT1",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT2",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT3",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT4",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT5",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT6",SqlDbType.VarChar,50),
			new SqlParameter("@ACC_REC_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CONSUME_FORECASTS",SqlDbType.Decimal,9),
			new SqlParameter("@BACKWARD_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@FORWARD_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@PLANNING_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@RAW_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@VISIBILITY_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@DAYS_EARLY_SCHEDULE",SqlDbType.Decimal,9),
			new SqlParameter("@APPLY_IN_TRANSIT",SqlDbType.Decimal,9),
			new SqlParameter("@CUSTOMER_TYPE",SqlDbType.Decimal,9),
			new SqlParameter("@DO_SMOOTHING",SqlDbType.Decimal,9),
			new SqlParameter("@SMOOTHING_THRESHOLD",SqlDbType.Decimal,9),
			new SqlParameter("@ANALYSIS_CODE4",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE5",SqlDbType.VarChar,20),
			new SqlParameter("@EDI_OUT_FOR_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_CRMEMO",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_PACKSL",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_CRMEMO",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_FORCST_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_FORCST_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SONEW_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SONEW_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SOCHG_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SOCHG_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_PACKSL",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_LOGGING",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_ADD_CUSTPART",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_PROD_CODE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_ROUTECODE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ORD_TYPE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMAILCPACKSLIP",SqlDbType.Decimal,9),
			new SqlParameter("@EMAILSOACK",SqlDbType.Decimal,9),
			new SqlParameter("@PAYTERM_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PRIORITY",SqlDbType.VarChar,1),
			new SqlParameter("@EDI_IN_FGI_RECEIPTS",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_ARCH_FGIRECEIPTS",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=data0010.RKEY;
			       parameters[3].Value=data0010.CUST_CODE;
			       parameters[4].Value=data0010.CUSTOMER_NAME;
			       parameters[5].Value=data0010.ABBR_NAME;
			       parameters[6].Value=data0010.BILLING_ADDRESS_1;
			       parameters[7].Value=data0010.BILLING_ADDRESS_2;
			       parameters[8].Value=data0010.BILLING_ADDRESS_3;
			       parameters[9].Value=data0010.STATE;
			       parameters[10].Value=data0010.ZIP;
			       parameters[11].Value=data0010.PHONE;
			       parameters[12].Value=data0010.FAX;
			       parameters[13].Value=data0010.TELEX;
			       parameters[14].Value=data0010.SALES_REP_PTR;
			       parameters[15].Value=data0010.CURRENCY_PTR;
			       parameters[16].Value=data0010.QUOTE_NOTE_PAD_PTR;
			       parameters[17].Value=data0010.INVOICE_NOTE_PAD_PTR;
			       parameters[18].Value=data0010.PACKSLP_NOTE_PAD_PTR;
			       parameters[19].Value=data0010.ORDRACK_NOTE_PAD_PTR;
			       parameters[20].Value=data0010.CRDTMEM_NOTE_PAD_PTR;
			       parameters[21].Value=data0010.STATMNT_NOTE_PAD_PTR;
			       parameters[22].Value=data0010.OPENORD_NOTE_PAD_PTR;
			       parameters[23].Value=data0010.CONTACT_NAME_1;
			       parameters[24].Value=data0010.CONTACT_NAME_2;
			       parameters[25].Value=data0010.CONTACT_NAME_3;
			       parameters[26].Value=data0010.CONTACT_NAME_4;
			       parameters[27].Value=data0010.CONTACT_NAME_5;
			       parameters[28].Value=data0010.CONTACT_NAME_6;
			       parameters[29].Value=data0010.CONT_PHONE_1;
			       parameters[30].Value=data0010.CONT_PHONE_2;
			       parameters[31].Value=data0010.CONT_PHONE_3;
			       parameters[32].Value=data0010.CONT_PHONE_4;
			       parameters[33].Value=data0010.CONT_PHONE_5;
			       parameters[34].Value=data0010.CONT_PHONE_6;
			       parameters[35].Value=data0010.FED_TAX_ID_NO;
			       parameters[36].Value=data0010.COFC_FILENAME;
			       parameters[37].Value=data0010.COD_FLAG;
			       parameters[38].Value=data0010.REG_TAX_FIXED_UNUSED;
			       parameters[39].Value=data0010.DISCOUNT_PCT;
			       parameters[40].Value=data0010.HIGH_BALANCE;
			       parameters[41].Value=data0010.CREDIT_LIMIT;
			       parameters[42].Value=data0010.CREDIT_RATING;
			       parameters[43].Value=data0010.BALANCE_DUE;
			       parameters[44].Value=data0010.OUTSTANDING_CREDIT;
			       parameters[45].Value=data0010.YTD_BOOKINGS;
			       parameters[46].Value=data0010.YTD_BILLINGS;
			       parameters[47].Value=data0010.YTD_RETURNS;
			       parameters[48].Value=data0010.YTD_DISCOUNT;
			       parameters[49].Value=data0010.LYR_BOOKINGS;
			       parameters[50].Value=data0010.LYR_BILLINGS;
			       parameters[51].Value=data0010.LYR_RETURNS;
			       parameters[52].Value=data0010.LYR_DISCOUNT;
			       parameters[53].Value=data0010.DISCOUNT_DAYS;
			       parameters[54].Value=data0010.CURRENT_BOOKINGS;
			       parameters[55].Value=data0010.NET_PAY;
					if (data0010.LAST_ACTIVE_DATE == DateTime.Parse("1900-1-1") || data0010.LAST_ACTIVE_DATE == DateTime.Parse("0001-1-1"))
						parameters[56].Value = null;
					else
						parameters[56].Value=data0010.LAST_ACTIVE_DATE;				    
			       parameters[57].Value=data0010.LANGUAGE_FLAG;
			       parameters[58].Value=data0010.BILLING_ADDRESS_4;
			       parameters[59].Value=data0010.COUNTRY_PTR;
			       parameters[60].Value=data0010.INTERNAL_ECN_COUNT;
			       parameters[61].Value=data0010.EXTERNAL_ECN_COUNT;
			       parameters[62].Value=data0010.OUTGOING_FORM_NAME;
			       parameters[63].Value=data0010.OUTGOING_FORM_ADDR1;
			       parameters[64].Value=data0010.OUTGOING_FORM_ADDR2;
			       parameters[65].Value=data0010.OUTGOING_FORM_ADDR3;
			       parameters[66].Value=data0010.ANALYSIS_CODE1;
			       parameters[67].Value=data0010.ANALYSIS_CODE2;
			       parameters[68].Value=data0010.ANALYSIS_CODE3;
					if (data0010.CUST_ENT_DATE == DateTime.Parse("1900-1-1") || data0010.CUST_ENT_DATE == DateTime.Parse("0001-1-1"))
						parameters[69].Value = null;
					else
						parameters[69].Value=data0010.CUST_ENT_DATE;				    
			       parameters[70].Value=data0010.EDI_ID;
			       parameters[71].Value=data0010.EDI_FLAG_FOR_SOACK;
			       parameters[72].Value=data0010.EDI_FLAG_FOR_INVOICE;
			       parameters[73].Value=data0010.EDI_FLAG_CREDIT_MEMO;
			       parameters[74].Value=data0010.GEN_EMAIL_ADDRESS;
			       parameters[75].Value=data0010.EMAIL_FOR_CONTACT1;
			       parameters[76].Value=data0010.EMAIL_FOR_CONTACT2;
			       parameters[77].Value=data0010.EMAIL_FOR_CONTACT3;
			       parameters[78].Value=data0010.EMAIL_FOR_CONTACT4;
			       parameters[79].Value=data0010.EMAIL_FOR_CONTACT5;
			       parameters[80].Value=data0010.EMAIL_FOR_CONTACT6;
			       parameters[81].Value=data0010.ACC_REC_PTR;
			       parameters[82].Value=data0010.CONSUME_FORECASTS;
			       parameters[83].Value=data0010.BACKWARD_DAYS;
			       parameters[84].Value=data0010.FORWARD_DAYS;
			       parameters[85].Value=data0010.PLANNING_HORIZON;
			       parameters[86].Value=data0010.RAW_HORIZON;
			       parameters[87].Value=data0010.VISIBILITY_HORIZON;
			       parameters[88].Value=data0010.DAYS_EARLY_SCHEDULE;
			       parameters[89].Value=data0010.APPLY_IN_TRANSIT;
			       parameters[90].Value=data0010.CUSTOMER_TYPE;
			       parameters[91].Value=data0010.DO_SMOOTHING;
			       parameters[92].Value=data0010.SMOOTHING_THRESHOLD;
			       parameters[93].Value=data0010.ANALYSIS_CODE4;
			       parameters[94].Value=data0010.ANALYSIS_CODE5;
			       parameters[95].Value=data0010.EDI_OUT_FOR_SOACK;
			       parameters[96].Value=data0010.EDI_OUT_FOR_INVOICE;
			       parameters[97].Value=data0010.EDI_OUT_FOR_CRMEMO;
			       parameters[98].Value=data0010.EDI_OUT_PRT_SOACK;
			       parameters[99].Value=data0010.EDI_OUT_FOR_PACKSL;
			       parameters[100].Value=data0010.EDI_OUT_PRT_INVOICE;
			       parameters[101].Value=data0010.EDI_OUT_PRT_CRMEMO;
			       parameters[102].Value=data0010.EDI_IN_FORCST_MAN;
			       parameters[103].Value=data0010.EDI_IN_FORCST_AUT;
			       parameters[104].Value=data0010.EDI_IN_SONEW_MAN;
			       parameters[105].Value=data0010.EDI_IN_SONEW_AUT;
			       parameters[106].Value=data0010.EDI_IN_SOCHG_MAN;
			       parameters[107].Value=data0010.EDI_IN_SOCHG_AUT;
			       parameters[108].Value=data0010.EDI_OUT_PRT_PACKSL;
			       parameters[109].Value=data0010.EDI_IN_LOGGING;
			       parameters[110].Value=data0010.EDI_IN_ADD_CUSTPART;
			       parameters[111].Value=data0010.EDI_IN_PROD_CODE_PTR;
			       parameters[112].Value=data0010.EDI_IN_ROUTECODE_PTR;
			       parameters[113].Value=data0010.ORD_TYPE_PTR;
			       parameters[114].Value=data0010.EMAILCPACKSLIP;
			       parameters[115].Value=data0010.EMAILSOACK;
			       parameters[116].Value=data0010.PAYTERM_PTR;
			       parameters[117].Value=data0010.PRIORITY;
			       parameters[118].Value=data0010.EDI_IN_FGI_RECEIPTS;
			       parameters[119].Value=data0010.EDI_ARCH_FGIRECEIPTS;
			       parameters[120].Value=data0010.ACTIVE_FLAG;
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				data0010.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0010,save successful");
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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0010 data0010)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0010(");
			strSql.Append("CUST_CODE,CUSTOMER_NAME,ABBR_NAME,BILLING_ADDRESS_1,BILLING_ADDRESS_2,BILLING_ADDRESS_3,STATE,ZIP,PHONE,FAX,TELEX,SALES_REP_PTR,CURRENCY_PTR,QUOTE_NOTE_PAD_PTR,INVOICE_NOTE_PAD_PTR,PACKSLP_NOTE_PAD_PTR,ORDRACK_NOTE_PAD_PTR,CRDTMEM_NOTE_PAD_PTR,STATMNT_NOTE_PAD_PTR,OPENORD_NOTE_PAD_PTR,CONTACT_NAME_1,CONTACT_NAME_2,CONTACT_NAME_3,CONTACT_NAME_4,CONTACT_NAME_5,CONTACT_NAME_6,CONT_PHONE_1,CONT_PHONE_2,CONT_PHONE_3,CONT_PHONE_4,CONT_PHONE_5,CONT_PHONE_6,FED_TAX_ID_NO,COFC_FILENAME,COD_FLAG,REG_TAX_FIXED_UNUSED,DISCOUNT_PCT,HIGH_BALANCE,CREDIT_LIMIT,CREDIT_RATING,BALANCE_DUE,OUTSTANDING_CREDIT,YTD_BOOKINGS,YTD_BILLINGS,YTD_RETURNS,YTD_DISCOUNT,LYR_BOOKINGS,LYR_BILLINGS,LYR_RETURNS,LYR_DISCOUNT,DISCOUNT_DAYS,CURRENT_BOOKINGS,NET_PAY,LAST_ACTIVE_DATE,LANGUAGE_FLAG,BILLING_ADDRESS_4,COUNTRY_PTR,INTERNAL_ECN_COUNT,EXTERNAL_ECN_COUNT,OUTGOING_FORM_NAME,OUTGOING_FORM_ADDR1,OUTGOING_FORM_ADDR2,OUTGOING_FORM_ADDR3,ANALYSIS_CODE1,ANALYSIS_CODE2,ANALYSIS_CODE3,CUST_ENT_DATE,EDI_ID,EDI_FLAG_FOR_SOACK,EDI_FLAG_FOR_INVOICE,EDI_FLAG_CREDIT_MEMO,GEN_EMAIL_ADDRESS,EMAIL_FOR_CONTACT1,EMAIL_FOR_CONTACT2,EMAIL_FOR_CONTACT3,EMAIL_FOR_CONTACT4,EMAIL_FOR_CONTACT5,EMAIL_FOR_CONTACT6,ACC_REC_PTR,CONSUME_FORECASTS,BACKWARD_DAYS,FORWARD_DAYS,PLANNING_HORIZON,RAW_HORIZON,VISIBILITY_HORIZON,DAYS_EARLY_SCHEDULE,APPLY_IN_TRANSIT,CUSTOMER_TYPE,DO_SMOOTHING,SMOOTHING_THRESHOLD,ANALYSIS_CODE4,ANALYSIS_CODE5,EDI_OUT_FOR_SOACK,EDI_OUT_FOR_INVOICE,EDI_OUT_FOR_CRMEMO,EDI_OUT_PRT_SOACK,EDI_OUT_FOR_PACKSL,EDI_OUT_PRT_INVOICE,EDI_OUT_PRT_CRMEMO,EDI_IN_FORCST_MAN,EDI_IN_FORCST_AUT,EDI_IN_SONEW_MAN,EDI_IN_SONEW_AUT,EDI_IN_SOCHG_MAN,EDI_IN_SOCHG_AUT,EDI_OUT_PRT_PACKSL,EDI_IN_LOGGING,EDI_IN_ADD_CUSTPART,EDI_IN_PROD_CODE_PTR,EDI_IN_ROUTECODE_PTR,ORD_TYPE_PTR,EMAILCPACKSLIP,EMAILSOACK,PAYTERM_PTR,PRIORITY,EDI_IN_FGI_RECEIPTS,EDI_ARCH_FGIRECEIPTS,ACTIVE_FLAG");
			strSql.Append(" ) values (");
			strSql.Append("@CUST_CODE,@CUSTOMER_NAME,@ABBR_NAME,@BILLING_ADDRESS_1,@BILLING_ADDRESS_2,@BILLING_ADDRESS_3,@STATE,@ZIP,@PHONE,@FAX,@TELEX,@SALES_REP_PTR,@CURRENCY_PTR,@QUOTE_NOTE_PAD_PTR,@INVOICE_NOTE_PAD_PTR,@PACKSLP_NOTE_PAD_PTR,@ORDRACK_NOTE_PAD_PTR,@CRDTMEM_NOTE_PAD_PTR,@STATMNT_NOTE_PAD_PTR,@OPENORD_NOTE_PAD_PTR,@CONTACT_NAME_1,@CONTACT_NAME_2,@CONTACT_NAME_3,@CONTACT_NAME_4,@CONTACT_NAME_5,@CONTACT_NAME_6,@CONT_PHONE_1,@CONT_PHONE_2,@CONT_PHONE_3,@CONT_PHONE_4,@CONT_PHONE_5,@CONT_PHONE_6,@FED_TAX_ID_NO,@COFC_FILENAME,@COD_FLAG,@REG_TAX_FIXED_UNUSED,@DISCOUNT_PCT,@HIGH_BALANCE,@CREDIT_LIMIT,@CREDIT_RATING,@BALANCE_DUE,@OUTSTANDING_CREDIT,@YTD_BOOKINGS,@YTD_BILLINGS,@YTD_RETURNS,@YTD_DISCOUNT,@LYR_BOOKINGS,@LYR_BILLINGS,@LYR_RETURNS,@LYR_DISCOUNT,@DISCOUNT_DAYS,@CURRENT_BOOKINGS,@NET_PAY,@LAST_ACTIVE_DATE,@LANGUAGE_FLAG,@BILLING_ADDRESS_4,@COUNTRY_PTR,@INTERNAL_ECN_COUNT,@EXTERNAL_ECN_COUNT,@OUTGOING_FORM_NAME,@OUTGOING_FORM_ADDR1,@OUTGOING_FORM_ADDR2,@OUTGOING_FORM_ADDR3,@ANALYSIS_CODE1,@ANALYSIS_CODE2,@ANALYSIS_CODE3,@CUST_ENT_DATE,@EDI_ID,@EDI_FLAG_FOR_SOACK,@EDI_FLAG_FOR_INVOICE,@EDI_FLAG_CREDIT_MEMO,@GEN_EMAIL_ADDRESS,@EMAIL_FOR_CONTACT1,@EMAIL_FOR_CONTACT2,@EMAIL_FOR_CONTACT3,@EMAIL_FOR_CONTACT4,@EMAIL_FOR_CONTACT5,@EMAIL_FOR_CONTACT6,@ACC_REC_PTR,@CONSUME_FORECASTS,@BACKWARD_DAYS,@FORWARD_DAYS,@PLANNING_HORIZON,@RAW_HORIZON,@VISIBILITY_HORIZON,@DAYS_EARLY_SCHEDULE,@APPLY_IN_TRANSIT,@CUSTOMER_TYPE,@DO_SMOOTHING,@SMOOTHING_THRESHOLD,@ANALYSIS_CODE4,@ANALYSIS_CODE5,@EDI_OUT_FOR_SOACK,@EDI_OUT_FOR_INVOICE,@EDI_OUT_FOR_CRMEMO,@EDI_OUT_PRT_SOACK,@EDI_OUT_FOR_PACKSL,@EDI_OUT_PRT_INVOICE,@EDI_OUT_PRT_CRMEMO,@EDI_IN_FORCST_MAN,@EDI_IN_FORCST_AUT,@EDI_IN_SONEW_MAN,@EDI_IN_SONEW_AUT,@EDI_IN_SOCHG_MAN,@EDI_IN_SOCHG_AUT,@EDI_OUT_PRT_PACKSL,@EDI_IN_LOGGING,@EDI_IN_ADD_CUSTPART,@EDI_IN_PROD_CODE_PTR,@EDI_IN_ROUTECODE_PTR,@ORD_TYPE_PTR,@EMAILCPACKSLIP,@EMAILSOACK,@PAYTERM_PTR,@PRIORITY,@EDI_IN_FGI_RECEIPTS,@EDI_ARCH_FGIRECEIPTS,@ACTIVE_FLAG");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@CUST_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@CUSTOMER_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@BILLING_ADDRESS_1",SqlDbType.VarChar,30),
			new SqlParameter("@BILLING_ADDRESS_2",SqlDbType.VarChar,30),
			new SqlParameter("@BILLING_ADDRESS_3",SqlDbType.VarChar,30),
			new SqlParameter("@STATE",SqlDbType.VarChar,3),
			new SqlParameter("@ZIP",SqlDbType.VarChar,10),
			new SqlParameter("@PHONE",SqlDbType.VarChar,30),
			new SqlParameter("@FAX",SqlDbType.VarChar,30),
			new SqlParameter("@TELEX",SqlDbType.VarChar,30),
			new SqlParameter("@SALES_REP_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CURRENCY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@QUOTE_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@INVOICE_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PACKSLP_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ORDRACK_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CRDTMEM_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@STATMNT_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@OPENORD_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CONTACT_NAME_1",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_2",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_3",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_4",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_5",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_6",SqlDbType.VarChar,20),
			new SqlParameter("@CONT_PHONE_1",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_2",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_3",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_4",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_5",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_6",SqlDbType.VarChar,30),
			new SqlParameter("@FED_TAX_ID_NO",SqlDbType.VarChar,15),
			new SqlParameter("@COFC_FILENAME",SqlDbType.VarChar,15),
			new SqlParameter("@COD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@REG_TAX_FIXED_UNUSED",SqlDbType.VarChar,1),
			new SqlParameter("@DISCOUNT_PCT",SqlDbType.Decimal,13),
			new SqlParameter("@HIGH_BALANCE",SqlDbType.Decimal,13),
			new SqlParameter("@CREDIT_LIMIT",SqlDbType.Decimal,13),
			new SqlParameter("@CREDIT_RATING",SqlDbType.VarChar,1),
			new SqlParameter("@BALANCE_DUE",SqlDbType.Decimal,13),
			new SqlParameter("@OUTSTANDING_CREDIT",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_BILLINGS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_RETURNS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_DISCOUNT",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_BILLINGS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_RETURNS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_DISCOUNT",SqlDbType.Decimal,13),
			new SqlParameter("@DISCOUNT_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@CURRENT_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@NET_PAY",SqlDbType.Decimal,9),
			new SqlParameter("@LAST_ACTIVE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@LANGUAGE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BILLING_ADDRESS_4",SqlDbType.VarChar,30),
			new SqlParameter("@COUNTRY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@INTERNAL_ECN_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@EXTERNAL_ECN_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@OUTGOING_FORM_NAME",SqlDbType.VarChar,60),
			new SqlParameter("@OUTGOING_FORM_ADDR1",SqlDbType.VarChar,45),
			new SqlParameter("@OUTGOING_FORM_ADDR2",SqlDbType.VarChar,45),
			new SqlParameter("@OUTGOING_FORM_ADDR3",SqlDbType.VarChar,45),
			new SqlParameter("@ANALYSIS_CODE1",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE2",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE3",SqlDbType.VarChar,20),
			new SqlParameter("@CUST_ENT_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@EDI_ID",SqlDbType.VarChar,50),
			new SqlParameter("@EDI_FLAG_FOR_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_FLAG_FOR_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_FLAG_CREDIT_MEMO",SqlDbType.Decimal,9),
			new SqlParameter("@GEN_EMAIL_ADDRESS",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT1",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT2",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT3",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT4",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT5",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT6",SqlDbType.VarChar,50),
			new SqlParameter("@ACC_REC_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CONSUME_FORECASTS",SqlDbType.Decimal,9),
			new SqlParameter("@BACKWARD_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@FORWARD_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@PLANNING_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@RAW_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@VISIBILITY_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@DAYS_EARLY_SCHEDULE",SqlDbType.Decimal,9),
			new SqlParameter("@APPLY_IN_TRANSIT",SqlDbType.Decimal,9),
			new SqlParameter("@CUSTOMER_TYPE",SqlDbType.Decimal,9),
			new SqlParameter("@DO_SMOOTHING",SqlDbType.Decimal,9),
			new SqlParameter("@SMOOTHING_THRESHOLD",SqlDbType.Decimal,9),
			new SqlParameter("@ANALYSIS_CODE4",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE5",SqlDbType.VarChar,20),
			new SqlParameter("@EDI_OUT_FOR_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_CRMEMO",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_PACKSL",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_CRMEMO",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_FORCST_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_FORCST_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SONEW_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SONEW_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SOCHG_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SOCHG_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_PACKSL",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_LOGGING",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_ADD_CUSTPART",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_PROD_CODE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_ROUTECODE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ORD_TYPE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMAILCPACKSLIP",SqlDbType.Decimal,9),
			new SqlParameter("@EMAILSOACK",SqlDbType.Decimal,9),
			new SqlParameter("@PAYTERM_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PRIORITY",SqlDbType.VarChar,1),
			new SqlParameter("@EDI_IN_FGI_RECEIPTS",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_ARCH_FGIRECEIPTS",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9)
			};
			
			       parameters[0].Value=data0010.CUST_CODE;
			       parameters[1].Value=data0010.CUSTOMER_NAME;
			       parameters[2].Value=data0010.ABBR_NAME;
			       parameters[3].Value=data0010.BILLING_ADDRESS_1;
			       parameters[4].Value=data0010.BILLING_ADDRESS_2;
			       parameters[5].Value=data0010.BILLING_ADDRESS_3;
			       parameters[6].Value=data0010.STATE;
			       parameters[7].Value=data0010.ZIP;
			       parameters[8].Value=data0010.PHONE;
			       parameters[9].Value=data0010.FAX;
			       parameters[10].Value=data0010.TELEX;
			       parameters[11].Value=data0010.SALES_REP_PTR;
			       parameters[12].Value=data0010.CURRENCY_PTR;
			       parameters[13].Value=data0010.QUOTE_NOTE_PAD_PTR;
			       parameters[14].Value=data0010.INVOICE_NOTE_PAD_PTR;
			       parameters[15].Value=data0010.PACKSLP_NOTE_PAD_PTR;
			       parameters[16].Value=data0010.ORDRACK_NOTE_PAD_PTR;
			       parameters[17].Value=data0010.CRDTMEM_NOTE_PAD_PTR;
			       parameters[18].Value=data0010.STATMNT_NOTE_PAD_PTR;
			       parameters[19].Value=data0010.OPENORD_NOTE_PAD_PTR;
			       parameters[20].Value=data0010.CONTACT_NAME_1;
			       parameters[21].Value=data0010.CONTACT_NAME_2;
			       parameters[22].Value=data0010.CONTACT_NAME_3;
			       parameters[23].Value=data0010.CONTACT_NAME_4;
			       parameters[24].Value=data0010.CONTACT_NAME_5;
			       parameters[25].Value=data0010.CONTACT_NAME_6;
			       parameters[26].Value=data0010.CONT_PHONE_1;
			       parameters[27].Value=data0010.CONT_PHONE_2;
			       parameters[28].Value=data0010.CONT_PHONE_3;
			       parameters[29].Value=data0010.CONT_PHONE_4;
			       parameters[30].Value=data0010.CONT_PHONE_5;
			       parameters[31].Value=data0010.CONT_PHONE_6;
			       parameters[32].Value=data0010.FED_TAX_ID_NO;
			       parameters[33].Value=data0010.COFC_FILENAME;
			       parameters[34].Value=data0010.COD_FLAG;
			       parameters[35].Value=data0010.REG_TAX_FIXED_UNUSED;
			       parameters[36].Value=data0010.DISCOUNT_PCT;
			       parameters[37].Value=data0010.HIGH_BALANCE;
			       parameters[38].Value=data0010.CREDIT_LIMIT;
			       parameters[39].Value=data0010.CREDIT_RATING;
			       parameters[40].Value=data0010.BALANCE_DUE;
			       parameters[41].Value=data0010.OUTSTANDING_CREDIT;
			       parameters[42].Value=data0010.YTD_BOOKINGS;
			       parameters[43].Value=data0010.YTD_BILLINGS;
			       parameters[44].Value=data0010.YTD_RETURNS;
			       parameters[45].Value=data0010.YTD_DISCOUNT;
			       parameters[46].Value=data0010.LYR_BOOKINGS;
			       parameters[47].Value=data0010.LYR_BILLINGS;
			       parameters[48].Value=data0010.LYR_RETURNS;
			       parameters[49].Value=data0010.LYR_DISCOUNT;
			       parameters[50].Value=data0010.DISCOUNT_DAYS;
			       parameters[51].Value=data0010.CURRENT_BOOKINGS;
			       parameters[52].Value=data0010.NET_PAY;
					if (data0010.LAST_ACTIVE_DATE == DateTime.Parse("1900-1-1") || data0010.LAST_ACTIVE_DATE == DateTime.Parse("0001-1-1"))
						parameters[53].Value = null;
					else
						parameters[53].Value=data0010.LAST_ACTIVE_DATE;				    
			       parameters[54].Value=data0010.LANGUAGE_FLAG;
			       parameters[55].Value=data0010.BILLING_ADDRESS_4;
			       parameters[56].Value=data0010.COUNTRY_PTR;
			       parameters[57].Value=data0010.INTERNAL_ECN_COUNT;
			       parameters[58].Value=data0010.EXTERNAL_ECN_COUNT;
			       parameters[59].Value=data0010.OUTGOING_FORM_NAME;
			       parameters[60].Value=data0010.OUTGOING_FORM_ADDR1;
			       parameters[61].Value=data0010.OUTGOING_FORM_ADDR2;
			       parameters[62].Value=data0010.OUTGOING_FORM_ADDR3;
			       parameters[63].Value=data0010.ANALYSIS_CODE1;
			       parameters[64].Value=data0010.ANALYSIS_CODE2;
			       parameters[65].Value=data0010.ANALYSIS_CODE3;
					if (data0010.CUST_ENT_DATE == DateTime.Parse("1900-1-1") || data0010.CUST_ENT_DATE == DateTime.Parse("0001-1-1"))
						parameters[66].Value = null;
					else
						parameters[66].Value=data0010.CUST_ENT_DATE;				    
			       parameters[67].Value=data0010.EDI_ID;
			       parameters[68].Value=data0010.EDI_FLAG_FOR_SOACK;
			       parameters[69].Value=data0010.EDI_FLAG_FOR_INVOICE;
			       parameters[70].Value=data0010.EDI_FLAG_CREDIT_MEMO;
			       parameters[71].Value=data0010.GEN_EMAIL_ADDRESS;
			       parameters[72].Value=data0010.EMAIL_FOR_CONTACT1;
			       parameters[73].Value=data0010.EMAIL_FOR_CONTACT2;
			       parameters[74].Value=data0010.EMAIL_FOR_CONTACT3;
			       parameters[75].Value=data0010.EMAIL_FOR_CONTACT4;
			       parameters[76].Value=data0010.EMAIL_FOR_CONTACT5;
			       parameters[77].Value=data0010.EMAIL_FOR_CONTACT6;
			       parameters[78].Value=data0010.ACC_REC_PTR;
			       parameters[79].Value=data0010.CONSUME_FORECASTS;
			       parameters[80].Value=data0010.BACKWARD_DAYS;
			       parameters[81].Value=data0010.FORWARD_DAYS;
			       parameters[82].Value=data0010.PLANNING_HORIZON;
			       parameters[83].Value=data0010.RAW_HORIZON;
			       parameters[84].Value=data0010.VISIBILITY_HORIZON;
			       parameters[85].Value=data0010.DAYS_EARLY_SCHEDULE;
			       parameters[86].Value=data0010.APPLY_IN_TRANSIT;
			       parameters[87].Value=data0010.CUSTOMER_TYPE;
			       parameters[88].Value=data0010.DO_SMOOTHING;
			       parameters[89].Value=data0010.SMOOTHING_THRESHOLD;
			       parameters[90].Value=data0010.ANALYSIS_CODE4;
			       parameters[91].Value=data0010.ANALYSIS_CODE5;
			       parameters[92].Value=data0010.EDI_OUT_FOR_SOACK;
			       parameters[93].Value=data0010.EDI_OUT_FOR_INVOICE;
			       parameters[94].Value=data0010.EDI_OUT_FOR_CRMEMO;
			       parameters[95].Value=data0010.EDI_OUT_PRT_SOACK;
			       parameters[96].Value=data0010.EDI_OUT_FOR_PACKSL;
			       parameters[97].Value=data0010.EDI_OUT_PRT_INVOICE;
			       parameters[98].Value=data0010.EDI_OUT_PRT_CRMEMO;
			       parameters[99].Value=data0010.EDI_IN_FORCST_MAN;
			       parameters[100].Value=data0010.EDI_IN_FORCST_AUT;
			       parameters[101].Value=data0010.EDI_IN_SONEW_MAN;
			       parameters[102].Value=data0010.EDI_IN_SONEW_AUT;
			       parameters[103].Value=data0010.EDI_IN_SOCHG_MAN;
			       parameters[104].Value=data0010.EDI_IN_SOCHG_AUT;
			       parameters[105].Value=data0010.EDI_OUT_PRT_PACKSL;
			       parameters[106].Value=data0010.EDI_IN_LOGGING;
			       parameters[107].Value=data0010.EDI_IN_ADD_CUSTPART;
			       parameters[108].Value=data0010.EDI_IN_PROD_CODE_PTR;
			       parameters[109].Value=data0010.EDI_IN_ROUTECODE_PTR;
			       parameters[110].Value=data0010.ORD_TYPE_PTR;
			       parameters[111].Value=data0010.EMAILCPACKSLIP;
			       parameters[112].Value=data0010.EMAILSOACK;
			       parameters[113].Value=data0010.PAYTERM_PTR;
			       parameters[114].Value=data0010.PRIORITY;
			       parameters[115].Value=data0010.EDI_IN_FGI_RECEIPTS;
			       parameters[116].Value=data0010.EDI_ARCH_FGIRECEIPTS;
			       parameters[117].Value=data0010.ACTIVE_FLAG;
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
		/// <param name="DATA0010">data0010对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(DATA0010 data0010)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_DATA0010_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@CUST_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@CUSTOMER_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@BILLING_ADDRESS_1",SqlDbType.VarChar,30),
			new SqlParameter("@BILLING_ADDRESS_2",SqlDbType.VarChar,30),
			new SqlParameter("@BILLING_ADDRESS_3",SqlDbType.VarChar,30),
			new SqlParameter("@STATE",SqlDbType.VarChar,3),
			new SqlParameter("@ZIP",SqlDbType.VarChar,10),
			new SqlParameter("@PHONE",SqlDbType.VarChar,30),
			new SqlParameter("@FAX",SqlDbType.VarChar,30),
			new SqlParameter("@TELEX",SqlDbType.VarChar,30),
			new SqlParameter("@SALES_REP_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CURRENCY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@QUOTE_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@INVOICE_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PACKSLP_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ORDRACK_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CRDTMEM_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@STATMNT_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@OPENORD_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CONTACT_NAME_1",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_2",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_3",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_4",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_5",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_6",SqlDbType.VarChar,20),
			new SqlParameter("@CONT_PHONE_1",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_2",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_3",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_4",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_5",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_6",SqlDbType.VarChar,30),
			new SqlParameter("@FED_TAX_ID_NO",SqlDbType.VarChar,15),
			new SqlParameter("@COFC_FILENAME",SqlDbType.VarChar,15),
			new SqlParameter("@COD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@REG_TAX_FIXED_UNUSED",SqlDbType.VarChar,1),
			new SqlParameter("@DISCOUNT_PCT",SqlDbType.Decimal,13),
			new SqlParameter("@HIGH_BALANCE",SqlDbType.Decimal,13),
			new SqlParameter("@CREDIT_LIMIT",SqlDbType.Decimal,13),
			new SqlParameter("@CREDIT_RATING",SqlDbType.VarChar,1),
			new SqlParameter("@BALANCE_DUE",SqlDbType.Decimal,13),
			new SqlParameter("@OUTSTANDING_CREDIT",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_BILLINGS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_RETURNS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_DISCOUNT",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_BILLINGS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_RETURNS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_DISCOUNT",SqlDbType.Decimal,13),
			new SqlParameter("@DISCOUNT_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@CURRENT_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@NET_PAY",SqlDbType.Decimal,9),
			new SqlParameter("@LAST_ACTIVE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@LANGUAGE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BILLING_ADDRESS_4",SqlDbType.VarChar,30),
			new SqlParameter("@COUNTRY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@INTERNAL_ECN_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@EXTERNAL_ECN_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@OUTGOING_FORM_NAME",SqlDbType.VarChar,60),
			new SqlParameter("@OUTGOING_FORM_ADDR1",SqlDbType.VarChar,45),
			new SqlParameter("@OUTGOING_FORM_ADDR2",SqlDbType.VarChar,45),
			new SqlParameter("@OUTGOING_FORM_ADDR3",SqlDbType.VarChar,45),
			new SqlParameter("@ANALYSIS_CODE1",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE2",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE3",SqlDbType.VarChar,20),
			new SqlParameter("@CUST_ENT_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@EDI_ID",SqlDbType.VarChar,50),
			new SqlParameter("@EDI_FLAG_FOR_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_FLAG_FOR_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_FLAG_CREDIT_MEMO",SqlDbType.Decimal,9),
			new SqlParameter("@GEN_EMAIL_ADDRESS",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT1",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT2",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT3",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT4",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT5",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT6",SqlDbType.VarChar,50),
			new SqlParameter("@ACC_REC_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CONSUME_FORECASTS",SqlDbType.Decimal,9),
			new SqlParameter("@BACKWARD_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@FORWARD_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@PLANNING_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@RAW_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@VISIBILITY_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@DAYS_EARLY_SCHEDULE",SqlDbType.Decimal,9),
			new SqlParameter("@APPLY_IN_TRANSIT",SqlDbType.Decimal,9),
			new SqlParameter("@CUSTOMER_TYPE",SqlDbType.Decimal,9),
			new SqlParameter("@DO_SMOOTHING",SqlDbType.Decimal,9),
			new SqlParameter("@SMOOTHING_THRESHOLD",SqlDbType.Decimal,9),
			new SqlParameter("@ANALYSIS_CODE4",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE5",SqlDbType.VarChar,20),
			new SqlParameter("@EDI_OUT_FOR_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_CRMEMO",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_PACKSL",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_CRMEMO",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_FORCST_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_FORCST_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SONEW_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SONEW_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SOCHG_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SOCHG_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_PACKSL",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_LOGGING",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_ADD_CUSTPART",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_PROD_CODE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_ROUTECODE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ORD_TYPE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMAILCPACKSLIP",SqlDbType.Decimal,9),
			new SqlParameter("@EMAILSOACK",SqlDbType.Decimal,9),
			new SqlParameter("@PAYTERM_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PRIORITY",SqlDbType.VarChar,1),
			new SqlParameter("@EDI_IN_FGI_RECEIPTS",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_ARCH_FGIRECEIPTS",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0010.RKEY;
			  		parameters[3].Value=data0010.CUST_CODE;
			  		parameters[4].Value=data0010.CUSTOMER_NAME;
			  		parameters[5].Value=data0010.ABBR_NAME;
			  		parameters[6].Value=data0010.BILLING_ADDRESS_1;
			  		parameters[7].Value=data0010.BILLING_ADDRESS_2;
			  		parameters[8].Value=data0010.BILLING_ADDRESS_3;
			  		parameters[9].Value=data0010.STATE;
			  		parameters[10].Value=data0010.ZIP;
			  		parameters[11].Value=data0010.PHONE;
			  		parameters[12].Value=data0010.FAX;
			  		parameters[13].Value=data0010.TELEX;
			  		parameters[14].Value=data0010.SALES_REP_PTR;
			  		parameters[15].Value=data0010.CURRENCY_PTR;
			  		parameters[16].Value=data0010.QUOTE_NOTE_PAD_PTR;
			  		parameters[17].Value=data0010.INVOICE_NOTE_PAD_PTR;
			  		parameters[18].Value=data0010.PACKSLP_NOTE_PAD_PTR;
			  		parameters[19].Value=data0010.ORDRACK_NOTE_PAD_PTR;
			  		parameters[20].Value=data0010.CRDTMEM_NOTE_PAD_PTR;
			  		parameters[21].Value=data0010.STATMNT_NOTE_PAD_PTR;
			  		parameters[22].Value=data0010.OPENORD_NOTE_PAD_PTR;
			  		parameters[23].Value=data0010.CONTACT_NAME_1;
			  		parameters[24].Value=data0010.CONTACT_NAME_2;
			  		parameters[25].Value=data0010.CONTACT_NAME_3;
			  		parameters[26].Value=data0010.CONTACT_NAME_4;
			  		parameters[27].Value=data0010.CONTACT_NAME_5;
			  		parameters[28].Value=data0010.CONTACT_NAME_6;
			  		parameters[29].Value=data0010.CONT_PHONE_1;
			  		parameters[30].Value=data0010.CONT_PHONE_2;
			  		parameters[31].Value=data0010.CONT_PHONE_3;
			  		parameters[32].Value=data0010.CONT_PHONE_4;
			  		parameters[33].Value=data0010.CONT_PHONE_5;
			  		parameters[34].Value=data0010.CONT_PHONE_6;
			  		parameters[35].Value=data0010.FED_TAX_ID_NO;
			  		parameters[36].Value=data0010.COFC_FILENAME;
			  		parameters[37].Value=data0010.COD_FLAG;
			  		parameters[38].Value=data0010.REG_TAX_FIXED_UNUSED;
			  		parameters[39].Value=data0010.DISCOUNT_PCT;
			  		parameters[40].Value=data0010.HIGH_BALANCE;
			  		parameters[41].Value=data0010.CREDIT_LIMIT;
			  		parameters[42].Value=data0010.CREDIT_RATING;
			  		parameters[43].Value=data0010.BALANCE_DUE;
			  		parameters[44].Value=data0010.OUTSTANDING_CREDIT;
			  		parameters[45].Value=data0010.YTD_BOOKINGS;
			  		parameters[46].Value=data0010.YTD_BILLINGS;
			  		parameters[47].Value=data0010.YTD_RETURNS;
			  		parameters[48].Value=data0010.YTD_DISCOUNT;
			  		parameters[49].Value=data0010.LYR_BOOKINGS;
			  		parameters[50].Value=data0010.LYR_BILLINGS;
			  		parameters[51].Value=data0010.LYR_RETURNS;
			  		parameters[52].Value=data0010.LYR_DISCOUNT;
			  		parameters[53].Value=data0010.DISCOUNT_DAYS;
			  		parameters[54].Value=data0010.CURRENT_BOOKINGS;
			  		parameters[55].Value=data0010.NET_PAY;
					if (data0010.LAST_ACTIVE_DATE == DateTime.Parse("1900-1-1") || data0010.LAST_ACTIVE_DATE == DateTime.Parse("0001-1-1"))
						parameters[56].Value = null;
					else
						parameters[56].Value=data0010.LAST_ACTIVE_DATE;				    
			  		parameters[57].Value=data0010.LANGUAGE_FLAG;
			  		parameters[58].Value=data0010.BILLING_ADDRESS_4;
			  		parameters[59].Value=data0010.COUNTRY_PTR;
			  		parameters[60].Value=data0010.INTERNAL_ECN_COUNT;
			  		parameters[61].Value=data0010.EXTERNAL_ECN_COUNT;
			  		parameters[62].Value=data0010.OUTGOING_FORM_NAME;
			  		parameters[63].Value=data0010.OUTGOING_FORM_ADDR1;
			  		parameters[64].Value=data0010.OUTGOING_FORM_ADDR2;
			  		parameters[65].Value=data0010.OUTGOING_FORM_ADDR3;
			  		parameters[66].Value=data0010.ANALYSIS_CODE1;
			  		parameters[67].Value=data0010.ANALYSIS_CODE2;
			  		parameters[68].Value=data0010.ANALYSIS_CODE3;
					if (data0010.CUST_ENT_DATE == DateTime.Parse("1900-1-1") || data0010.CUST_ENT_DATE == DateTime.Parse("0001-1-1"))
						parameters[69].Value = null;
					else
						parameters[69].Value=data0010.CUST_ENT_DATE;				    
			  		parameters[70].Value=data0010.EDI_ID;
			  		parameters[71].Value=data0010.EDI_FLAG_FOR_SOACK;
			  		parameters[72].Value=data0010.EDI_FLAG_FOR_INVOICE;
			  		parameters[73].Value=data0010.EDI_FLAG_CREDIT_MEMO;
			  		parameters[74].Value=data0010.GEN_EMAIL_ADDRESS;
			  		parameters[75].Value=data0010.EMAIL_FOR_CONTACT1;
			  		parameters[76].Value=data0010.EMAIL_FOR_CONTACT2;
			  		parameters[77].Value=data0010.EMAIL_FOR_CONTACT3;
			  		parameters[78].Value=data0010.EMAIL_FOR_CONTACT4;
			  		parameters[79].Value=data0010.EMAIL_FOR_CONTACT5;
			  		parameters[80].Value=data0010.EMAIL_FOR_CONTACT6;
			  		parameters[81].Value=data0010.ACC_REC_PTR;
			  		parameters[82].Value=data0010.CONSUME_FORECASTS;
			  		parameters[83].Value=data0010.BACKWARD_DAYS;
			  		parameters[84].Value=data0010.FORWARD_DAYS;
			  		parameters[85].Value=data0010.PLANNING_HORIZON;
			  		parameters[86].Value=data0010.RAW_HORIZON;
			  		parameters[87].Value=data0010.VISIBILITY_HORIZON;
			  		parameters[88].Value=data0010.DAYS_EARLY_SCHEDULE;
			  		parameters[89].Value=data0010.APPLY_IN_TRANSIT;
			  		parameters[90].Value=data0010.CUSTOMER_TYPE;
			  		parameters[91].Value=data0010.DO_SMOOTHING;
			  		parameters[92].Value=data0010.SMOOTHING_THRESHOLD;
			  		parameters[93].Value=data0010.ANALYSIS_CODE4;
			  		parameters[94].Value=data0010.ANALYSIS_CODE5;
			  		parameters[95].Value=data0010.EDI_OUT_FOR_SOACK;
			  		parameters[96].Value=data0010.EDI_OUT_FOR_INVOICE;
			  		parameters[97].Value=data0010.EDI_OUT_FOR_CRMEMO;
			  		parameters[98].Value=data0010.EDI_OUT_PRT_SOACK;
			  		parameters[99].Value=data0010.EDI_OUT_FOR_PACKSL;
			  		parameters[100].Value=data0010.EDI_OUT_PRT_INVOICE;
			  		parameters[101].Value=data0010.EDI_OUT_PRT_CRMEMO;
			  		parameters[102].Value=data0010.EDI_IN_FORCST_MAN;
			  		parameters[103].Value=data0010.EDI_IN_FORCST_AUT;
			  		parameters[104].Value=data0010.EDI_IN_SONEW_MAN;
			  		parameters[105].Value=data0010.EDI_IN_SONEW_AUT;
			  		parameters[106].Value=data0010.EDI_IN_SOCHG_MAN;
			  		parameters[107].Value=data0010.EDI_IN_SOCHG_AUT;
			  		parameters[108].Value=data0010.EDI_OUT_PRT_PACKSL;
			  		parameters[109].Value=data0010.EDI_IN_LOGGING;
			  		parameters[110].Value=data0010.EDI_IN_ADD_CUSTPART;
			  		parameters[111].Value=data0010.EDI_IN_PROD_CODE_PTR;
			  		parameters[112].Value=data0010.EDI_IN_ROUTECODE_PTR;
			  		parameters[113].Value=data0010.ORD_TYPE_PTR;
			  		parameters[114].Value=data0010.EMAILCPACKSLIP;
			  		parameters[115].Value=data0010.EMAILSOACK;
			  		parameters[116].Value=data0010.PAYTERM_PTR;
			  		parameters[117].Value=data0010.PRIORITY;
			  		parameters[118].Value=data0010.EDI_IN_FGI_RECEIPTS;
			  		parameters[119].Value=data0010.EDI_ARCH_FGIRECEIPTS;
			  		parameters[120].Value=data0010.ACTIVE_FLAG;
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0010,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0010 data0010)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update DATA0010 set "); 
			strSql.Append("CUST_CODE=@CUST_CODE,");
			strSql.Append("CUSTOMER_NAME=@CUSTOMER_NAME,");
			strSql.Append("ABBR_NAME=@ABBR_NAME,");
			strSql.Append("BILLING_ADDRESS_1=@BILLING_ADDRESS_1,");
			strSql.Append("BILLING_ADDRESS_2=@BILLING_ADDRESS_2,");
			strSql.Append("BILLING_ADDRESS_3=@BILLING_ADDRESS_3,");
			strSql.Append("STATE=@STATE,");
			strSql.Append("ZIP=@ZIP,");
			strSql.Append("PHONE=@PHONE,");
			strSql.Append("FAX=@FAX,");
			strSql.Append("TELEX=@TELEX,");
			strSql.Append("SALES_REP_PTR=@SALES_REP_PTR,");
			strSql.Append("CURRENCY_PTR=@CURRENCY_PTR,");
			strSql.Append("QUOTE_NOTE_PAD_PTR=@QUOTE_NOTE_PAD_PTR,");
			strSql.Append("INVOICE_NOTE_PAD_PTR=@INVOICE_NOTE_PAD_PTR,");
			strSql.Append("PACKSLP_NOTE_PAD_PTR=@PACKSLP_NOTE_PAD_PTR,");
			strSql.Append("ORDRACK_NOTE_PAD_PTR=@ORDRACK_NOTE_PAD_PTR,");
			strSql.Append("CRDTMEM_NOTE_PAD_PTR=@CRDTMEM_NOTE_PAD_PTR,");
			strSql.Append("STATMNT_NOTE_PAD_PTR=@STATMNT_NOTE_PAD_PTR,");
			strSql.Append("OPENORD_NOTE_PAD_PTR=@OPENORD_NOTE_PAD_PTR,");
			strSql.Append("CONTACT_NAME_1=@CONTACT_NAME_1,");
			strSql.Append("CONTACT_NAME_2=@CONTACT_NAME_2,");
			strSql.Append("CONTACT_NAME_3=@CONTACT_NAME_3,");
			strSql.Append("CONTACT_NAME_4=@CONTACT_NAME_4,");
			strSql.Append("CONTACT_NAME_5=@CONTACT_NAME_5,");
			strSql.Append("CONTACT_NAME_6=@CONTACT_NAME_6,");
			strSql.Append("CONT_PHONE_1=@CONT_PHONE_1,");
			strSql.Append("CONT_PHONE_2=@CONT_PHONE_2,");
			strSql.Append("CONT_PHONE_3=@CONT_PHONE_3,");
			strSql.Append("CONT_PHONE_4=@CONT_PHONE_4,");
			strSql.Append("CONT_PHONE_5=@CONT_PHONE_5,");
			strSql.Append("CONT_PHONE_6=@CONT_PHONE_6,");
			strSql.Append("FED_TAX_ID_NO=@FED_TAX_ID_NO,");
			strSql.Append("COFC_FILENAME=@COFC_FILENAME,");
			strSql.Append("COD_FLAG=@COD_FLAG,");
			strSql.Append("REG_TAX_FIXED_UNUSED=@REG_TAX_FIXED_UNUSED,");
			strSql.Append("DISCOUNT_PCT=@DISCOUNT_PCT,");
			strSql.Append("HIGH_BALANCE=@HIGH_BALANCE,");
			strSql.Append("CREDIT_LIMIT=@CREDIT_LIMIT,");
			strSql.Append("CREDIT_RATING=@CREDIT_RATING,");
			strSql.Append("BALANCE_DUE=@BALANCE_DUE,");
			strSql.Append("OUTSTANDING_CREDIT=@OUTSTANDING_CREDIT,");
			strSql.Append("YTD_BOOKINGS=@YTD_BOOKINGS,");
			strSql.Append("YTD_BILLINGS=@YTD_BILLINGS,");
			strSql.Append("YTD_RETURNS=@YTD_RETURNS,");
			strSql.Append("YTD_DISCOUNT=@YTD_DISCOUNT,");
			strSql.Append("LYR_BOOKINGS=@LYR_BOOKINGS,");
			strSql.Append("LYR_BILLINGS=@LYR_BILLINGS,");
			strSql.Append("LYR_RETURNS=@LYR_RETURNS,");
			strSql.Append("LYR_DISCOUNT=@LYR_DISCOUNT,");
			strSql.Append("DISCOUNT_DAYS=@DISCOUNT_DAYS,");
			strSql.Append("CURRENT_BOOKINGS=@CURRENT_BOOKINGS,");
			strSql.Append("NET_PAY=@NET_PAY,");
			strSql.Append("LAST_ACTIVE_DATE=@LAST_ACTIVE_DATE,");
			strSql.Append("LANGUAGE_FLAG=@LANGUAGE_FLAG,");
			strSql.Append("BILLING_ADDRESS_4=@BILLING_ADDRESS_4,");
			strSql.Append("COUNTRY_PTR=@COUNTRY_PTR,");
			strSql.Append("INTERNAL_ECN_COUNT=@INTERNAL_ECN_COUNT,");
			strSql.Append("EXTERNAL_ECN_COUNT=@EXTERNAL_ECN_COUNT,");
			strSql.Append("OUTGOING_FORM_NAME=@OUTGOING_FORM_NAME,");
			strSql.Append("OUTGOING_FORM_ADDR1=@OUTGOING_FORM_ADDR1,");
			strSql.Append("OUTGOING_FORM_ADDR2=@OUTGOING_FORM_ADDR2,");
			strSql.Append("OUTGOING_FORM_ADDR3=@OUTGOING_FORM_ADDR3,");
			strSql.Append("ANALYSIS_CODE1=@ANALYSIS_CODE1,");
			strSql.Append("ANALYSIS_CODE2=@ANALYSIS_CODE2,");
			strSql.Append("ANALYSIS_CODE3=@ANALYSIS_CODE3,");
			strSql.Append("CUST_ENT_DATE=@CUST_ENT_DATE,");
			strSql.Append("EDI_ID=@EDI_ID,");
			strSql.Append("EDI_FLAG_FOR_SOACK=@EDI_FLAG_FOR_SOACK,");
			strSql.Append("EDI_FLAG_FOR_INVOICE=@EDI_FLAG_FOR_INVOICE,");
			strSql.Append("EDI_FLAG_CREDIT_MEMO=@EDI_FLAG_CREDIT_MEMO,");
			strSql.Append("GEN_EMAIL_ADDRESS=@GEN_EMAIL_ADDRESS,");
			strSql.Append("EMAIL_FOR_CONTACT1=@EMAIL_FOR_CONTACT1,");
			strSql.Append("EMAIL_FOR_CONTACT2=@EMAIL_FOR_CONTACT2,");
			strSql.Append("EMAIL_FOR_CONTACT3=@EMAIL_FOR_CONTACT3,");
			strSql.Append("EMAIL_FOR_CONTACT4=@EMAIL_FOR_CONTACT4,");
			strSql.Append("EMAIL_FOR_CONTACT5=@EMAIL_FOR_CONTACT5,");
			strSql.Append("EMAIL_FOR_CONTACT6=@EMAIL_FOR_CONTACT6,");
			strSql.Append("ACC_REC_PTR=@ACC_REC_PTR,");
			strSql.Append("CONSUME_FORECASTS=@CONSUME_FORECASTS,");
			strSql.Append("BACKWARD_DAYS=@BACKWARD_DAYS,");
			strSql.Append("FORWARD_DAYS=@FORWARD_DAYS,");
			strSql.Append("PLANNING_HORIZON=@PLANNING_HORIZON,");
			strSql.Append("RAW_HORIZON=@RAW_HORIZON,");
			strSql.Append("VISIBILITY_HORIZON=@VISIBILITY_HORIZON,");
			strSql.Append("DAYS_EARLY_SCHEDULE=@DAYS_EARLY_SCHEDULE,");
			strSql.Append("APPLY_IN_TRANSIT=@APPLY_IN_TRANSIT,");
			strSql.Append("CUSTOMER_TYPE=@CUSTOMER_TYPE,");
			strSql.Append("DO_SMOOTHING=@DO_SMOOTHING,");
			strSql.Append("SMOOTHING_THRESHOLD=@SMOOTHING_THRESHOLD,");
			strSql.Append("ANALYSIS_CODE4=@ANALYSIS_CODE4,");
			strSql.Append("ANALYSIS_CODE5=@ANALYSIS_CODE5,");
			strSql.Append("EDI_OUT_FOR_SOACK=@EDI_OUT_FOR_SOACK,");
			strSql.Append("EDI_OUT_FOR_INVOICE=@EDI_OUT_FOR_INVOICE,");
			strSql.Append("EDI_OUT_FOR_CRMEMO=@EDI_OUT_FOR_CRMEMO,");
			strSql.Append("EDI_OUT_PRT_SOACK=@EDI_OUT_PRT_SOACK,");
			strSql.Append("EDI_OUT_FOR_PACKSL=@EDI_OUT_FOR_PACKSL,");
			strSql.Append("EDI_OUT_PRT_INVOICE=@EDI_OUT_PRT_INVOICE,");
			strSql.Append("EDI_OUT_PRT_CRMEMO=@EDI_OUT_PRT_CRMEMO,");
			strSql.Append("EDI_IN_FORCST_MAN=@EDI_IN_FORCST_MAN,");
			strSql.Append("EDI_IN_FORCST_AUT=@EDI_IN_FORCST_AUT,");
			strSql.Append("EDI_IN_SONEW_MAN=@EDI_IN_SONEW_MAN,");
			strSql.Append("EDI_IN_SONEW_AUT=@EDI_IN_SONEW_AUT,");
			strSql.Append("EDI_IN_SOCHG_MAN=@EDI_IN_SOCHG_MAN,");
			strSql.Append("EDI_IN_SOCHG_AUT=@EDI_IN_SOCHG_AUT,");
			strSql.Append("EDI_OUT_PRT_PACKSL=@EDI_OUT_PRT_PACKSL,");
			strSql.Append("EDI_IN_LOGGING=@EDI_IN_LOGGING,");
			strSql.Append("EDI_IN_ADD_CUSTPART=@EDI_IN_ADD_CUSTPART,");
			strSql.Append("EDI_IN_PROD_CODE_PTR=@EDI_IN_PROD_CODE_PTR,");
			strSql.Append("EDI_IN_ROUTECODE_PTR=@EDI_IN_ROUTECODE_PTR,");
			strSql.Append("ORD_TYPE_PTR=@ORD_TYPE_PTR,");
			strSql.Append("EMAILCPACKSLIP=@EMAILCPACKSLIP,");
			strSql.Append("EMAILSOACK=@EMAILSOACK,");
			strSql.Append("PAYTERM_PTR=@PAYTERM_PTR,");
			strSql.Append("PRIORITY=@PRIORITY,");
			strSql.Append("EDI_IN_FGI_RECEIPTS=@EDI_IN_FGI_RECEIPTS,");
			strSql.Append("EDI_ARCH_FGIRECEIPTS=@EDI_ARCH_FGIRECEIPTS,");
			strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@CUST_CODE",SqlDbType.VarChar,5),
			new SqlParameter("@CUSTOMER_NAME",SqlDbType.VarChar,30),
			new SqlParameter("@ABBR_NAME",SqlDbType.VarChar,10),
			new SqlParameter("@BILLING_ADDRESS_1",SqlDbType.VarChar,30),
			new SqlParameter("@BILLING_ADDRESS_2",SqlDbType.VarChar,30),
			new SqlParameter("@BILLING_ADDRESS_3",SqlDbType.VarChar,30),
			new SqlParameter("@STATE",SqlDbType.VarChar,3),
			new SqlParameter("@ZIP",SqlDbType.VarChar,10),
			new SqlParameter("@PHONE",SqlDbType.VarChar,30),
			new SqlParameter("@FAX",SqlDbType.VarChar,30),
			new SqlParameter("@TELEX",SqlDbType.VarChar,30),
			new SqlParameter("@SALES_REP_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CURRENCY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@QUOTE_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@INVOICE_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PACKSLP_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ORDRACK_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CRDTMEM_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@STATMNT_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@OPENORD_NOTE_PAD_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CONTACT_NAME_1",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_2",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_3",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_4",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_5",SqlDbType.VarChar,20),
			new SqlParameter("@CONTACT_NAME_6",SqlDbType.VarChar,20),
			new SqlParameter("@CONT_PHONE_1",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_2",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_3",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_4",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_5",SqlDbType.VarChar,30),
			new SqlParameter("@CONT_PHONE_6",SqlDbType.VarChar,30),
			new SqlParameter("@FED_TAX_ID_NO",SqlDbType.VarChar,15),
			new SqlParameter("@COFC_FILENAME",SqlDbType.VarChar,15),
			new SqlParameter("@COD_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@REG_TAX_FIXED_UNUSED",SqlDbType.VarChar,1),
			new SqlParameter("@DISCOUNT_PCT",SqlDbType.Decimal,13),
			new SqlParameter("@HIGH_BALANCE",SqlDbType.Decimal,13),
			new SqlParameter("@CREDIT_LIMIT",SqlDbType.Decimal,13),
			new SqlParameter("@CREDIT_RATING",SqlDbType.VarChar,1),
			new SqlParameter("@BALANCE_DUE",SqlDbType.Decimal,13),
			new SqlParameter("@OUTSTANDING_CREDIT",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_BILLINGS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_RETURNS",SqlDbType.Decimal,13),
			new SqlParameter("@YTD_DISCOUNT",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_BILLINGS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_RETURNS",SqlDbType.Decimal,13),
			new SqlParameter("@LYR_DISCOUNT",SqlDbType.Decimal,13),
			new SqlParameter("@DISCOUNT_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@CURRENT_BOOKINGS",SqlDbType.Decimal,13),
			new SqlParameter("@NET_PAY",SqlDbType.Decimal,9),
			new SqlParameter("@LAST_ACTIVE_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@LANGUAGE_FLAG",SqlDbType.VarChar,1),
			new SqlParameter("@BILLING_ADDRESS_4",SqlDbType.VarChar,30),
			new SqlParameter("@COUNTRY_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@INTERNAL_ECN_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@EXTERNAL_ECN_COUNT",SqlDbType.Decimal,9),
			new SqlParameter("@OUTGOING_FORM_NAME",SqlDbType.VarChar,60),
			new SqlParameter("@OUTGOING_FORM_ADDR1",SqlDbType.VarChar,45),
			new SqlParameter("@OUTGOING_FORM_ADDR2",SqlDbType.VarChar,45),
			new SqlParameter("@OUTGOING_FORM_ADDR3",SqlDbType.VarChar,45),
			new SqlParameter("@ANALYSIS_CODE1",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE2",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE3",SqlDbType.VarChar,20),
			new SqlParameter("@CUST_ENT_DATE",SqlDbType.DateTime,8),
			new SqlParameter("@EDI_ID",SqlDbType.VarChar,50),
			new SqlParameter("@EDI_FLAG_FOR_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_FLAG_FOR_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_FLAG_CREDIT_MEMO",SqlDbType.Decimal,9),
			new SqlParameter("@GEN_EMAIL_ADDRESS",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT1",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT2",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT3",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT4",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT5",SqlDbType.VarChar,50),
			new SqlParameter("@EMAIL_FOR_CONTACT6",SqlDbType.VarChar,50),
			new SqlParameter("@ACC_REC_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@CONSUME_FORECASTS",SqlDbType.Decimal,9),
			new SqlParameter("@BACKWARD_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@FORWARD_DAYS",SqlDbType.Decimal,9),
			new SqlParameter("@PLANNING_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@RAW_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@VISIBILITY_HORIZON",SqlDbType.Decimal,9),
			new SqlParameter("@DAYS_EARLY_SCHEDULE",SqlDbType.Decimal,9),
			new SqlParameter("@APPLY_IN_TRANSIT",SqlDbType.Decimal,9),
			new SqlParameter("@CUSTOMER_TYPE",SqlDbType.Decimal,9),
			new SqlParameter("@DO_SMOOTHING",SqlDbType.Decimal,9),
			new SqlParameter("@SMOOTHING_THRESHOLD",SqlDbType.Decimal,9),
			new SqlParameter("@ANALYSIS_CODE4",SqlDbType.VarChar,20),
			new SqlParameter("@ANALYSIS_CODE5",SqlDbType.VarChar,20),
			new SqlParameter("@EDI_OUT_FOR_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_CRMEMO",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_SOACK",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_FOR_PACKSL",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_INVOICE",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_CRMEMO",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_FORCST_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_FORCST_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SONEW_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SONEW_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SOCHG_MAN",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_SOCHG_AUT",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_OUT_PRT_PACKSL",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_LOGGING",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_ADD_CUSTPART",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_PROD_CODE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_IN_ROUTECODE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@ORD_TYPE_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@EMAILCPACKSLIP",SqlDbType.Decimal,9),
			new SqlParameter("@EMAILSOACK",SqlDbType.Decimal,9),
			new SqlParameter("@PAYTERM_PTR",SqlDbType.Decimal,9),
			new SqlParameter("@PRIORITY",SqlDbType.VarChar,1),
			new SqlParameter("@EDI_IN_FGI_RECEIPTS",SqlDbType.Decimal,9),
			new SqlParameter("@EDI_ARCH_FGIRECEIPTS",SqlDbType.Decimal,9),
			new SqlParameter("@ACTIVE_FLAG",SqlDbType.Decimal,9)
			};
			
			parameters[0].Value = data0010.RKEY;
			       parameters[1].Value=data0010.CUST_CODE;
			       parameters[2].Value=data0010.CUSTOMER_NAME;
			       parameters[3].Value=data0010.ABBR_NAME;
			       parameters[4].Value=data0010.BILLING_ADDRESS_1;
			       parameters[5].Value=data0010.BILLING_ADDRESS_2;
			       parameters[6].Value=data0010.BILLING_ADDRESS_3;
			       parameters[7].Value=data0010.STATE;
			       parameters[8].Value=data0010.ZIP;
			       parameters[9].Value=data0010.PHONE;
			       parameters[10].Value=data0010.FAX;
			       parameters[11].Value=data0010.TELEX;
			       parameters[12].Value=data0010.SALES_REP_PTR;
			       parameters[13].Value=data0010.CURRENCY_PTR;
			       parameters[14].Value=data0010.QUOTE_NOTE_PAD_PTR;
			       parameters[15].Value=data0010.INVOICE_NOTE_PAD_PTR;
			       parameters[16].Value=data0010.PACKSLP_NOTE_PAD_PTR;
			       parameters[17].Value=data0010.ORDRACK_NOTE_PAD_PTR;
			       parameters[18].Value=data0010.CRDTMEM_NOTE_PAD_PTR;
			       parameters[19].Value=data0010.STATMNT_NOTE_PAD_PTR;
			       parameters[20].Value=data0010.OPENORD_NOTE_PAD_PTR;
			       parameters[21].Value=data0010.CONTACT_NAME_1;
			       parameters[22].Value=data0010.CONTACT_NAME_2;
			       parameters[23].Value=data0010.CONTACT_NAME_3;
			       parameters[24].Value=data0010.CONTACT_NAME_4;
			       parameters[25].Value=data0010.CONTACT_NAME_5;
			       parameters[26].Value=data0010.CONTACT_NAME_6;
			       parameters[27].Value=data0010.CONT_PHONE_1;
			       parameters[28].Value=data0010.CONT_PHONE_2;
			       parameters[29].Value=data0010.CONT_PHONE_3;
			       parameters[30].Value=data0010.CONT_PHONE_4;
			       parameters[31].Value=data0010.CONT_PHONE_5;
			       parameters[32].Value=data0010.CONT_PHONE_6;
			       parameters[33].Value=data0010.FED_TAX_ID_NO;
			       parameters[34].Value=data0010.COFC_FILENAME;
			       parameters[35].Value=data0010.COD_FLAG;
			       parameters[36].Value=data0010.REG_TAX_FIXED_UNUSED;
			       parameters[37].Value=data0010.DISCOUNT_PCT;
			       parameters[38].Value=data0010.HIGH_BALANCE;
			       parameters[39].Value=data0010.CREDIT_LIMIT;
			       parameters[40].Value=data0010.CREDIT_RATING;
			       parameters[41].Value=data0010.BALANCE_DUE;
			       parameters[42].Value=data0010.OUTSTANDING_CREDIT;
			       parameters[43].Value=data0010.YTD_BOOKINGS;
			       parameters[44].Value=data0010.YTD_BILLINGS;
			       parameters[45].Value=data0010.YTD_RETURNS;
			       parameters[46].Value=data0010.YTD_DISCOUNT;
			       parameters[47].Value=data0010.LYR_BOOKINGS;
			       parameters[48].Value=data0010.LYR_BILLINGS;
			       parameters[49].Value=data0010.LYR_RETURNS;
			       parameters[50].Value=data0010.LYR_DISCOUNT;
			       parameters[51].Value=data0010.DISCOUNT_DAYS;
			       parameters[52].Value=data0010.CURRENT_BOOKINGS;
			       parameters[53].Value=data0010.NET_PAY;
					if (data0010.LAST_ACTIVE_DATE == DateTime.Parse("1900-1-1") || data0010.LAST_ACTIVE_DATE == DateTime.Parse("0001-1-1"))
						parameters[54].Value = null;
					else
						parameters[54].Value=data0010.LAST_ACTIVE_DATE;				    
			       parameters[55].Value=data0010.LANGUAGE_FLAG;
			       parameters[56].Value=data0010.BILLING_ADDRESS_4;
			       parameters[57].Value=data0010.COUNTRY_PTR;
			       parameters[58].Value=data0010.INTERNAL_ECN_COUNT;
			       parameters[59].Value=data0010.EXTERNAL_ECN_COUNT;
			       parameters[60].Value=data0010.OUTGOING_FORM_NAME;
			       parameters[61].Value=data0010.OUTGOING_FORM_ADDR1;
			       parameters[62].Value=data0010.OUTGOING_FORM_ADDR2;
			       parameters[63].Value=data0010.OUTGOING_FORM_ADDR3;
			       parameters[64].Value=data0010.ANALYSIS_CODE1;
			       parameters[65].Value=data0010.ANALYSIS_CODE2;
			       parameters[66].Value=data0010.ANALYSIS_CODE3;
					if (data0010.CUST_ENT_DATE == DateTime.Parse("1900-1-1") || data0010.CUST_ENT_DATE == DateTime.Parse("0001-1-1"))
						parameters[67].Value = null;
					else
						parameters[67].Value=data0010.CUST_ENT_DATE;				    
			       parameters[68].Value=data0010.EDI_ID;
			       parameters[69].Value=data0010.EDI_FLAG_FOR_SOACK;
			       parameters[70].Value=data0010.EDI_FLAG_FOR_INVOICE;
			       parameters[71].Value=data0010.EDI_FLAG_CREDIT_MEMO;
			       parameters[72].Value=data0010.GEN_EMAIL_ADDRESS;
			       parameters[73].Value=data0010.EMAIL_FOR_CONTACT1;
			       parameters[74].Value=data0010.EMAIL_FOR_CONTACT2;
			       parameters[75].Value=data0010.EMAIL_FOR_CONTACT3;
			       parameters[76].Value=data0010.EMAIL_FOR_CONTACT4;
			       parameters[77].Value=data0010.EMAIL_FOR_CONTACT5;
			       parameters[78].Value=data0010.EMAIL_FOR_CONTACT6;
			       parameters[79].Value=data0010.ACC_REC_PTR;
			       parameters[80].Value=data0010.CONSUME_FORECASTS;
			       parameters[81].Value=data0010.BACKWARD_DAYS;
			       parameters[82].Value=data0010.FORWARD_DAYS;
			       parameters[83].Value=data0010.PLANNING_HORIZON;
			       parameters[84].Value=data0010.RAW_HORIZON;
			       parameters[85].Value=data0010.VISIBILITY_HORIZON;
			       parameters[86].Value=data0010.DAYS_EARLY_SCHEDULE;
			       parameters[87].Value=data0010.APPLY_IN_TRANSIT;
			       parameters[88].Value=data0010.CUSTOMER_TYPE;
			       parameters[89].Value=data0010.DO_SMOOTHING;
			       parameters[90].Value=data0010.SMOOTHING_THRESHOLD;
			       parameters[91].Value=data0010.ANALYSIS_CODE4;
			       parameters[92].Value=data0010.ANALYSIS_CODE5;
			       parameters[93].Value=data0010.EDI_OUT_FOR_SOACK;
			       parameters[94].Value=data0010.EDI_OUT_FOR_INVOICE;
			       parameters[95].Value=data0010.EDI_OUT_FOR_CRMEMO;
			       parameters[96].Value=data0010.EDI_OUT_PRT_SOACK;
			       parameters[97].Value=data0010.EDI_OUT_FOR_PACKSL;
			       parameters[98].Value=data0010.EDI_OUT_PRT_INVOICE;
			       parameters[99].Value=data0010.EDI_OUT_PRT_CRMEMO;
			       parameters[100].Value=data0010.EDI_IN_FORCST_MAN;
			       parameters[101].Value=data0010.EDI_IN_FORCST_AUT;
			       parameters[102].Value=data0010.EDI_IN_SONEW_MAN;
			       parameters[103].Value=data0010.EDI_IN_SONEW_AUT;
			       parameters[104].Value=data0010.EDI_IN_SOCHG_MAN;
			       parameters[105].Value=data0010.EDI_IN_SOCHG_AUT;
			       parameters[106].Value=data0010.EDI_OUT_PRT_PACKSL;
			       parameters[107].Value=data0010.EDI_IN_LOGGING;
			       parameters[108].Value=data0010.EDI_IN_ADD_CUSTPART;
			       parameters[109].Value=data0010.EDI_IN_PROD_CODE_PTR;
			       parameters[110].Value=data0010.EDI_IN_ROUTECODE_PTR;
			       parameters[111].Value=data0010.ORD_TYPE_PTR;
			       parameters[112].Value=data0010.EMAILCPACKSLIP;
			       parameters[113].Value=data0010.EMAILSOACK;
			       parameters[114].Value=data0010.PAYTERM_PTR;
			       parameters[115].Value=data0010.PRIORITY;
			       parameters[116].Value=data0010.EDI_IN_FGI_RECEIPTS;
			       parameters[117].Value=data0010.EDI_ARCH_FGIRECEIPTS;
			       parameters[118].Value=data0010.ACTIVE_FLAG;
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
		/// <param name="data0010">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(DATA0010 data0010)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_DATA0010_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=data0010.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0010,delete successful");
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
		/// <param name="data0010">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.DATA0010 where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";DATA0010,delete successful");
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
			strSql.Append("delete from data0010 ");
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
		///<returns>DATA0010对象</returns>		
		public DATA0010 getDATA0010ByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(cust_code,'') as cust_code
				,
				isNull(customer_name,'') as customer_name
				,
				isNull(abbr_name,'') as abbr_name
				,
				isNull(billing_address_1,'') as billing_address_1
				,
				isNull(billing_address_2,'') as billing_address_2
				,
				isNull(billing_address_3,'') as billing_address_3
				,
				isNull(state,'') as state
				,
				isNull(zip,'') as zip
				,
				isNull(phone,'') as phone
				,
				isNull(fax,'') as fax
				,
				isNull(telex,'') as telex
				,
				isNull(sales_rep_ptr,0) as sales_rep_ptr
				,
				isNull(currency_ptr,0) as currency_ptr
				,
				isNull(quote_note_pad_ptr,0) as quote_note_pad_ptr
				,
				isNull(invoice_note_pad_ptr,0) as invoice_note_pad_ptr
				,
				isNull(packslp_note_pad_ptr,0) as packslp_note_pad_ptr
				,
				isNull(ordrack_note_pad_ptr,0) as ordrack_note_pad_ptr
				,
				isNull(crdtmem_note_pad_ptr,0) as crdtmem_note_pad_ptr
				,
				isNull(statmnt_note_pad_ptr,0) as statmnt_note_pad_ptr
				,
				isNull(openord_note_pad_ptr,0) as openord_note_pad_ptr
				,
				isNull(contact_name_1,'') as contact_name_1
				,
				isNull(contact_name_2,'') as contact_name_2
				,
				isNull(contact_name_3,'') as contact_name_3
				,
				isNull(contact_name_4,'') as contact_name_4
				,
				isNull(contact_name_5,'') as contact_name_5
				,
				isNull(contact_name_6,'') as contact_name_6
				,
				isNull(cont_phone_1,'') as cont_phone_1
				,
				isNull(cont_phone_2,'') as cont_phone_2
				,
				isNull(cont_phone_3,'') as cont_phone_3
				,
				isNull(cont_phone_4,'') as cont_phone_4
				,
				isNull(cont_phone_5,'') as cont_phone_5
				,
				isNull(cont_phone_6,'') as cont_phone_6
				,
				isNull(fed_tax_id_no,'') as fed_tax_id_no
				,
				isNull(cofc_filename,'') as cofc_filename
				,
				isNull(cod_flag,'') as cod_flag
				,
				isNull(reg_tax_fixed_unused,'') as reg_tax_fixed_unused
				,
				isNull(discount_pct,0) as discount_pct
				,
				isNull(high_balance,0) as high_balance
				,
				isNull(credit_limit,0) as credit_limit
				,
				isNull(credit_rating,'') as credit_rating
				,
				isNull(balance_due,0) as balance_due
				,
				isNull(outstanding_credit,0) as outstanding_credit
				,
				isNull(ytd_bookings,0) as ytd_bookings
				,
				isNull(ytd_billings,0) as ytd_billings
				,
				isNull(ytd_returns,0) as ytd_returns
				,
				isNull(ytd_discount,0) as ytd_discount
				,
				isNull(lyr_bookings,0) as lyr_bookings
				,
				isNull(lyr_billings,0) as lyr_billings
				,
				isNull(lyr_returns,0) as lyr_returns
				,
				isNull(lyr_discount,0) as lyr_discount
				,
				isNull(discount_days,0) as discount_days
				,
				isNull(current_bookings,0) as current_bookings
				,
				isNull(net_pay,0) as net_pay
				,
				isNull(last_active_date,'1900-1-1') as last_active_date
				,
				isNull(language_flag,'') as language_flag
				,
				isNull(billing_address_4,'') as billing_address_4
				,
				isNull(country_ptr,0) as country_ptr
				,
				isNull(internal_ecn_count,0) as internal_ecn_count
				,
				isNull(external_ecn_count,0) as external_ecn_count
				,
				isNull(outgoing_form_name,'') as outgoing_form_name
				,
				isNull(outgoing_form_addr1,'') as outgoing_form_addr1
				,
				isNull(outgoing_form_addr2,'') as outgoing_form_addr2
				,
				isNull(outgoing_form_addr3,'') as outgoing_form_addr3
				,
				isNull(analysis_code1,'') as analysis_code1
				,
				isNull(analysis_code2,'') as analysis_code2
				,
				isNull(analysis_code3,'') as analysis_code3
				,
				isNull(cust_ent_date,'1900-1-1') as cust_ent_date
				,
				isNull(edi_id,'') as edi_id
				,
				isNull(edi_flag_for_soack,0) as edi_flag_for_soack
				,
				isNull(edi_flag_for_invoice,0) as edi_flag_for_invoice
				,
				isNull(edi_flag_credit_memo,0) as edi_flag_credit_memo
				,
				isNull(gen_email_address,'') as gen_email_address
				,
				isNull(email_for_contact1,'') as email_for_contact1
				,
				isNull(email_for_contact2,'') as email_for_contact2
				,
				isNull(email_for_contact3,'') as email_for_contact3
				,
				isNull(email_for_contact4,'') as email_for_contact4
				,
				isNull(email_for_contact5,'') as email_for_contact5
				,
				isNull(email_for_contact6,'') as email_for_contact6
				,
				isNull(acc_rec_ptr,0) as acc_rec_ptr
				,
				isNull(consume_forecasts,0) as consume_forecasts
				,
				isNull(backward_days,0) as backward_days
				,
				isNull(forward_days,0) as forward_days
				,
				isNull(planning_horizon,0) as planning_horizon
				,
				isNull(raw_horizon,0) as raw_horizon
				,
				isNull(visibility_horizon,0) as visibility_horizon
				,
				isNull(days_early_schedule,0) as days_early_schedule
				,
				isNull(apply_in_transit,0) as apply_in_transit
				,
				isNull(customer_type,0) as customer_type
				,
				isNull(do_smoothing,0) as do_smoothing
				,
				isNull(smoothing_threshold,0) as smoothing_threshold
				,
				isNull(analysis_code4,'') as analysis_code4
				,
				isNull(analysis_code5,'') as analysis_code5
				,
				isNull(edi_out_for_soack,0) as edi_out_for_soack
				,
				isNull(edi_out_for_invoice,0) as edi_out_for_invoice
				,
				isNull(edi_out_for_crmemo,0) as edi_out_for_crmemo
				,
				isNull(edi_out_prt_soack,0) as edi_out_prt_soack
				,
				isNull(edi_out_for_packsl,0) as edi_out_for_packsl
				,
				isNull(edi_out_prt_invoice,0) as edi_out_prt_invoice
				,
				isNull(edi_out_prt_crmemo,0) as edi_out_prt_crmemo
				,
				isNull(edi_in_forcst_man,0) as edi_in_forcst_man
				,
				isNull(edi_in_forcst_aut,0) as edi_in_forcst_aut
				,
				isNull(edi_in_sonew_man,0) as edi_in_sonew_man
				,
				isNull(edi_in_sonew_aut,0) as edi_in_sonew_aut
				,
				isNull(edi_in_sochg_man,0) as edi_in_sochg_man
				,
				isNull(edi_in_sochg_aut,0) as edi_in_sochg_aut
				,
				isNull(edi_out_prt_packsl,0) as edi_out_prt_packsl
				,
				isNull(edi_in_logging,0) as edi_in_logging
				,
				isNull(edi_in_add_custpart,0) as edi_in_add_custpart
				,
				isNull(edi_in_prod_code_ptr,0) as edi_in_prod_code_ptr
				,
				isNull(edi_in_routecode_ptr,0) as edi_in_routecode_ptr
				,
				isNull(ord_type_ptr,0) as ord_type_ptr
				,
				isNull(emailcpackslip,0) as emailcpackslip
				,
				isNull(emailsoack,0) as emailsoack
				,
				isNull(payterm_ptr,0) as payterm_ptr
				,
				isNull(priority,'') as priority
				,
				isNull(edi_in_fgi_receipts,0) as edi_in_fgi_receipts
				,
				isNull(edi_arch_fgireceipts,0) as edi_arch_fgireceipts
				,
				isNull(active_flag,0) as active_flag
				
			from DATA0010 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			DATA0010  data0010=null;
			
			#region 数据库操作
            try
            {
				 data0010=new DATA0010();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    data0010.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
								   data0010.CUST_CODE =row["CUST_CODE"].ToString();
								   data0010.CUSTOMER_NAME =row["CUSTOMER_NAME"].ToString();
								   data0010.ABBR_NAME =row["ABBR_NAME"].ToString();
								   data0010.BILLING_ADDRESS_1 =row["BILLING_ADDRESS_1"].ToString();
								   data0010.BILLING_ADDRESS_2 =row["BILLING_ADDRESS_2"].ToString();
								   data0010.BILLING_ADDRESS_3 =row["BILLING_ADDRESS_3"].ToString();
								   data0010.STATE =row["STATE"].ToString();
								   data0010.ZIP =row["ZIP"].ToString();
								   data0010.PHONE =row["PHONE"].ToString();
								   data0010.FAX =row["FAX"].ToString();
								   data0010.TELEX =row["TELEX"].ToString();
							  	        data0010.SALES_REP_PTR =decimal.Parse(row["SALES_REP_PTR"].ToString());
							  	        data0010.CURRENCY_PTR =decimal.Parse(row["CURRENCY_PTR"].ToString());
							  	        data0010.QUOTE_NOTE_PAD_PTR =decimal.Parse(row["QUOTE_NOTE_PAD_PTR"].ToString());
							  	        data0010.INVOICE_NOTE_PAD_PTR =decimal.Parse(row["INVOICE_NOTE_PAD_PTR"].ToString());
							  	        data0010.PACKSLP_NOTE_PAD_PTR =decimal.Parse(row["PACKSLP_NOTE_PAD_PTR"].ToString());
							  	        data0010.ORDRACK_NOTE_PAD_PTR =decimal.Parse(row["ORDRACK_NOTE_PAD_PTR"].ToString());
							  	        data0010.CRDTMEM_NOTE_PAD_PTR =decimal.Parse(row["CRDTMEM_NOTE_PAD_PTR"].ToString());
							  	        data0010.STATMNT_NOTE_PAD_PTR =decimal.Parse(row["STATMNT_NOTE_PAD_PTR"].ToString());
							  	        data0010.OPENORD_NOTE_PAD_PTR =decimal.Parse(row["OPENORD_NOTE_PAD_PTR"].ToString());
								   data0010.CONTACT_NAME_1 =row["CONTACT_NAME_1"].ToString();
								   data0010.CONTACT_NAME_2 =row["CONTACT_NAME_2"].ToString();
								   data0010.CONTACT_NAME_3 =row["CONTACT_NAME_3"].ToString();
								   data0010.CONTACT_NAME_4 =row["CONTACT_NAME_4"].ToString();
								   data0010.CONTACT_NAME_5 =row["CONTACT_NAME_5"].ToString();
								   data0010.CONTACT_NAME_6 =row["CONTACT_NAME_6"].ToString();
								   data0010.CONT_PHONE_1 =row["CONT_PHONE_1"].ToString();
								   data0010.CONT_PHONE_2 =row["CONT_PHONE_2"].ToString();
								   data0010.CONT_PHONE_3 =row["CONT_PHONE_3"].ToString();
								   data0010.CONT_PHONE_4 =row["CONT_PHONE_4"].ToString();
								   data0010.CONT_PHONE_5 =row["CONT_PHONE_5"].ToString();
								   data0010.CONT_PHONE_6 =row["CONT_PHONE_6"].ToString();
								   data0010.FED_TAX_ID_NO =row["FED_TAX_ID_NO"].ToString();
								   data0010.COFC_FILENAME =row["COFC_FILENAME"].ToString();
								   data0010.COD_FLAG =row["COD_FLAG"].ToString();
								   data0010.REG_TAX_FIXED_UNUSED =row["REG_TAX_FIXED_UNUSED"].ToString();
							  	        data0010.DISCOUNT_PCT =decimal.Parse(row["DISCOUNT_PCT"].ToString());
							  	        data0010.HIGH_BALANCE =decimal.Parse(row["HIGH_BALANCE"].ToString());
							  	        data0010.CREDIT_LIMIT =decimal.Parse(row["CREDIT_LIMIT"].ToString());
								   data0010.CREDIT_RATING =row["CREDIT_RATING"].ToString();
							  	        data0010.BALANCE_DUE =decimal.Parse(row["BALANCE_DUE"].ToString());
							  	        data0010.OUTSTANDING_CREDIT =decimal.Parse(row["OUTSTANDING_CREDIT"].ToString());
							  	        data0010.YTD_BOOKINGS =decimal.Parse(row["YTD_BOOKINGS"].ToString());
							  	        data0010.YTD_BILLINGS =decimal.Parse(row["YTD_BILLINGS"].ToString());
							  	        data0010.YTD_RETURNS =decimal.Parse(row["YTD_RETURNS"].ToString());
							  	        data0010.YTD_DISCOUNT =decimal.Parse(row["YTD_DISCOUNT"].ToString());
							  	        data0010.LYR_BOOKINGS =decimal.Parse(row["LYR_BOOKINGS"].ToString());
							  	        data0010.LYR_BILLINGS =decimal.Parse(row["LYR_BILLINGS"].ToString());
							  	        data0010.LYR_RETURNS =decimal.Parse(row["LYR_RETURNS"].ToString());
							  	        data0010.LYR_DISCOUNT =decimal.Parse(row["LYR_DISCOUNT"].ToString());
							  	        data0010.DISCOUNT_DAYS =decimal.Parse(row["DISCOUNT_DAYS"].ToString());
							  	        data0010.CURRENT_BOOKINGS =decimal.Parse(row["CURRENT_BOOKINGS"].ToString());
							  	        data0010.NET_PAY =decimal.Parse(row["NET_PAY"].ToString());
							  	        data0010.LAST_ACTIVE_DATE =DateTime.Parse(row["LAST_ACTIVE_DATE"].ToString());
								   data0010.LANGUAGE_FLAG =row["LANGUAGE_FLAG"].ToString();
								   data0010.BILLING_ADDRESS_4 =row["BILLING_ADDRESS_4"].ToString();
							  	        data0010.COUNTRY_PTR =decimal.Parse(row["COUNTRY_PTR"].ToString());
							  	        data0010.INTERNAL_ECN_COUNT =decimal.Parse(row["INTERNAL_ECN_COUNT"].ToString());
							  	        data0010.EXTERNAL_ECN_COUNT =decimal.Parse(row["EXTERNAL_ECN_COUNT"].ToString());
								   data0010.OUTGOING_FORM_NAME =row["OUTGOING_FORM_NAME"].ToString();
								   data0010.OUTGOING_FORM_ADDR1 =row["OUTGOING_FORM_ADDR1"].ToString();
								   data0010.OUTGOING_FORM_ADDR2 =row["OUTGOING_FORM_ADDR2"].ToString();
								   data0010.OUTGOING_FORM_ADDR3 =row["OUTGOING_FORM_ADDR3"].ToString();
								   data0010.ANALYSIS_CODE1 =row["ANALYSIS_CODE1"].ToString();
								   data0010.ANALYSIS_CODE2 =row["ANALYSIS_CODE2"].ToString();
								   data0010.ANALYSIS_CODE3 =row["ANALYSIS_CODE3"].ToString();
							  	        data0010.CUST_ENT_DATE =DateTime.Parse(row["CUST_ENT_DATE"].ToString());
								   data0010.EDI_ID =row["EDI_ID"].ToString();
							  	        data0010.EDI_FLAG_FOR_SOACK =decimal.Parse(row["EDI_FLAG_FOR_SOACK"].ToString());
							  	        data0010.EDI_FLAG_FOR_INVOICE =decimal.Parse(row["EDI_FLAG_FOR_INVOICE"].ToString());
							  	        data0010.EDI_FLAG_CREDIT_MEMO =decimal.Parse(row["EDI_FLAG_CREDIT_MEMO"].ToString());
								   data0010.GEN_EMAIL_ADDRESS =row["GEN_EMAIL_ADDRESS"].ToString();
								   data0010.EMAIL_FOR_CONTACT1 =row["EMAIL_FOR_CONTACT1"].ToString();
								   data0010.EMAIL_FOR_CONTACT2 =row["EMAIL_FOR_CONTACT2"].ToString();
								   data0010.EMAIL_FOR_CONTACT3 =row["EMAIL_FOR_CONTACT3"].ToString();
								   data0010.EMAIL_FOR_CONTACT4 =row["EMAIL_FOR_CONTACT4"].ToString();
								   data0010.EMAIL_FOR_CONTACT5 =row["EMAIL_FOR_CONTACT5"].ToString();
								   data0010.EMAIL_FOR_CONTACT6 =row["EMAIL_FOR_CONTACT6"].ToString();
							  	        data0010.ACC_REC_PTR =decimal.Parse(row["ACC_REC_PTR"].ToString());
							  	        data0010.CONSUME_FORECASTS =decimal.Parse(row["CONSUME_FORECASTS"].ToString());
							  	        data0010.BACKWARD_DAYS =decimal.Parse(row["BACKWARD_DAYS"].ToString());
							  	        data0010.FORWARD_DAYS =decimal.Parse(row["FORWARD_DAYS"].ToString());
							  	        data0010.PLANNING_HORIZON =decimal.Parse(row["PLANNING_HORIZON"].ToString());
							  	        data0010.RAW_HORIZON =decimal.Parse(row["RAW_HORIZON"].ToString());
							  	        data0010.VISIBILITY_HORIZON =decimal.Parse(row["VISIBILITY_HORIZON"].ToString());
							  	        data0010.DAYS_EARLY_SCHEDULE =decimal.Parse(row["DAYS_EARLY_SCHEDULE"].ToString());
							  	        data0010.APPLY_IN_TRANSIT =decimal.Parse(row["APPLY_IN_TRANSIT"].ToString());
							  	        data0010.CUSTOMER_TYPE =decimal.Parse(row["CUSTOMER_TYPE"].ToString());
							  	        data0010.DO_SMOOTHING =decimal.Parse(row["DO_SMOOTHING"].ToString());
							  	        data0010.SMOOTHING_THRESHOLD =decimal.Parse(row["SMOOTHING_THRESHOLD"].ToString());
								   data0010.ANALYSIS_CODE4 =row["ANALYSIS_CODE4"].ToString();
								   data0010.ANALYSIS_CODE5 =row["ANALYSIS_CODE5"].ToString();
							  	        data0010.EDI_OUT_FOR_SOACK =decimal.Parse(row["EDI_OUT_FOR_SOACK"].ToString());
							  	        data0010.EDI_OUT_FOR_INVOICE =decimal.Parse(row["EDI_OUT_FOR_INVOICE"].ToString());
							  	        data0010.EDI_OUT_FOR_CRMEMO =decimal.Parse(row["EDI_OUT_FOR_CRMEMO"].ToString());
							  	        data0010.EDI_OUT_PRT_SOACK =decimal.Parse(row["EDI_OUT_PRT_SOACK"].ToString());
							  	        data0010.EDI_OUT_FOR_PACKSL =decimal.Parse(row["EDI_OUT_FOR_PACKSL"].ToString());
							  	        data0010.EDI_OUT_PRT_INVOICE =decimal.Parse(row["EDI_OUT_PRT_INVOICE"].ToString());
							  	        data0010.EDI_OUT_PRT_CRMEMO =decimal.Parse(row["EDI_OUT_PRT_CRMEMO"].ToString());
							  	        data0010.EDI_IN_FORCST_MAN =decimal.Parse(row["EDI_IN_FORCST_MAN"].ToString());
							  	        data0010.EDI_IN_FORCST_AUT =decimal.Parse(row["EDI_IN_FORCST_AUT"].ToString());
							  	        data0010.EDI_IN_SONEW_MAN =decimal.Parse(row["EDI_IN_SONEW_MAN"].ToString());
							  	        data0010.EDI_IN_SONEW_AUT =decimal.Parse(row["EDI_IN_SONEW_AUT"].ToString());
							  	        data0010.EDI_IN_SOCHG_MAN =decimal.Parse(row["EDI_IN_SOCHG_MAN"].ToString());
							  	        data0010.EDI_IN_SOCHG_AUT =decimal.Parse(row["EDI_IN_SOCHG_AUT"].ToString());
							  	        data0010.EDI_OUT_PRT_PACKSL =decimal.Parse(row["EDI_OUT_PRT_PACKSL"].ToString());
							  	        data0010.EDI_IN_LOGGING =decimal.Parse(row["EDI_IN_LOGGING"].ToString());
							  	        data0010.EDI_IN_ADD_CUSTPART =decimal.Parse(row["EDI_IN_ADD_CUSTPART"].ToString());
							  	        data0010.EDI_IN_PROD_CODE_PTR =decimal.Parse(row["EDI_IN_PROD_CODE_PTR"].ToString());
							  	        data0010.EDI_IN_ROUTECODE_PTR =decimal.Parse(row["EDI_IN_ROUTECODE_PTR"].ToString());
							  	        data0010.ORD_TYPE_PTR =decimal.Parse(row["ORD_TYPE_PTR"].ToString());
							  	        data0010.EMAILCPACKSLIP =decimal.Parse(row["EMAILCPACKSLIP"].ToString());
							  	        data0010.EMAILSOACK =decimal.Parse(row["EMAILSOACK"].ToString());
							  	        data0010.PAYTERM_PTR =decimal.Parse(row["PAYTERM_PTR"].ToString());
								   data0010.PRIORITY =row["PRIORITY"].ToString();
							  	        data0010.EDI_IN_FGI_RECEIPTS =decimal.Parse(row["EDI_IN_FGI_RECEIPTS"].ToString());
							  	        data0010.EDI_ARCH_FGIRECEIPTS =decimal.Parse(row["EDI_ARCH_FGIRECEIPTS"].ToString());
							  	        data0010.ACTIVE_FLAG =decimal.Parse(row["ACTIVE_FLAG"].ToString());
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return data0010;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< DATA0010 >  FindAllDATA0010()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<DATA0010>数据集合</returns>		
		public IList< DATA0010> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(cust_code,'') as cust_code
				,
				isNull(customer_name,'') as customer_name
				,
				isNull(abbr_name,'') as abbr_name
				,
				isNull(billing_address_1,'') as billing_address_1
				,
				isNull(billing_address_2,'') as billing_address_2
				,
				isNull(billing_address_3,'') as billing_address_3
				,
				isNull(state,'') as state
				,
				isNull(zip,'') as zip
				,
				isNull(phone,'') as phone
				,
				isNull(fax,'') as fax
				,
				isNull(telex,'') as telex
				,
				isNull(sales_rep_ptr,0) as sales_rep_ptr
				,
				isNull(currency_ptr,0) as currency_ptr
				,
				isNull(quote_note_pad_ptr,0) as quote_note_pad_ptr
				,
				isNull(invoice_note_pad_ptr,0) as invoice_note_pad_ptr
				,
				isNull(packslp_note_pad_ptr,0) as packslp_note_pad_ptr
				,
				isNull(ordrack_note_pad_ptr,0) as ordrack_note_pad_ptr
				,
				isNull(crdtmem_note_pad_ptr,0) as crdtmem_note_pad_ptr
				,
				isNull(statmnt_note_pad_ptr,0) as statmnt_note_pad_ptr
				,
				isNull(openord_note_pad_ptr,0) as openord_note_pad_ptr
				,
				isNull(contact_name_1,'') as contact_name_1
				,
				isNull(contact_name_2,'') as contact_name_2
				,
				isNull(contact_name_3,'') as contact_name_3
				,
				isNull(contact_name_4,'') as contact_name_4
				,
				isNull(contact_name_5,'') as contact_name_5
				,
				isNull(contact_name_6,'') as contact_name_6
				,
				isNull(cont_phone_1,'') as cont_phone_1
				,
				isNull(cont_phone_2,'') as cont_phone_2
				,
				isNull(cont_phone_3,'') as cont_phone_3
				,
				isNull(cont_phone_4,'') as cont_phone_4
				,
				isNull(cont_phone_5,'') as cont_phone_5
				,
				isNull(cont_phone_6,'') as cont_phone_6
				,
				isNull(fed_tax_id_no,'') as fed_tax_id_no
				,
				isNull(cofc_filename,'') as cofc_filename
				,
				isNull(cod_flag,'') as cod_flag
				,
				isNull(reg_tax_fixed_unused,'') as reg_tax_fixed_unused
				,
				isNull(discount_pct,0) as discount_pct
				,
				isNull(high_balance,0) as high_balance
				,
				isNull(credit_limit,0) as credit_limit
				,
				isNull(credit_rating,'') as credit_rating
				,
				isNull(balance_due,0) as balance_due
				,
				isNull(outstanding_credit,0) as outstanding_credit
				,
				isNull(ytd_bookings,0) as ytd_bookings
				,
				isNull(ytd_billings,0) as ytd_billings
				,
				isNull(ytd_returns,0) as ytd_returns
				,
				isNull(ytd_discount,0) as ytd_discount
				,
				isNull(lyr_bookings,0) as lyr_bookings
				,
				isNull(lyr_billings,0) as lyr_billings
				,
				isNull(lyr_returns,0) as lyr_returns
				,
				isNull(lyr_discount,0) as lyr_discount
				,
				isNull(discount_days,0) as discount_days
				,
				isNull(current_bookings,0) as current_bookings
				,
				isNull(net_pay,0) as net_pay
				,
				isNull(last_active_date,'1900-1-1') as last_active_date
				,
				isNull(language_flag,'') as language_flag
				,
				isNull(billing_address_4,'') as billing_address_4
				,
				isNull(country_ptr,0) as country_ptr
				,
				isNull(internal_ecn_count,0) as internal_ecn_count
				,
				isNull(external_ecn_count,0) as external_ecn_count
				,
				isNull(outgoing_form_name,'') as outgoing_form_name
				,
				isNull(outgoing_form_addr1,'') as outgoing_form_addr1
				,
				isNull(outgoing_form_addr2,'') as outgoing_form_addr2
				,
				isNull(outgoing_form_addr3,'') as outgoing_form_addr3
				,
				isNull(analysis_code1,'') as analysis_code1
				,
				isNull(analysis_code2,'') as analysis_code2
				,
				isNull(analysis_code3,'') as analysis_code3
				,
				isNull(cust_ent_date,'1900-1-1') as cust_ent_date
				,
				isNull(edi_id,'') as edi_id
				,
				isNull(edi_flag_for_soack,0) as edi_flag_for_soack
				,
				isNull(edi_flag_for_invoice,0) as edi_flag_for_invoice
				,
				isNull(edi_flag_credit_memo,0) as edi_flag_credit_memo
				,
				isNull(gen_email_address,'') as gen_email_address
				,
				isNull(email_for_contact1,'') as email_for_contact1
				,
				isNull(email_for_contact2,'') as email_for_contact2
				,
				isNull(email_for_contact3,'') as email_for_contact3
				,
				isNull(email_for_contact4,'') as email_for_contact4
				,
				isNull(email_for_contact5,'') as email_for_contact5
				,
				isNull(email_for_contact6,'') as email_for_contact6
				,
				isNull(acc_rec_ptr,0) as acc_rec_ptr
				,
				isNull(consume_forecasts,0) as consume_forecasts
				,
				isNull(backward_days,0) as backward_days
				,
				isNull(forward_days,0) as forward_days
				,
				isNull(planning_horizon,0) as planning_horizon
				,
				isNull(raw_horizon,0) as raw_horizon
				,
				isNull(visibility_horizon,0) as visibility_horizon
				,
				isNull(days_early_schedule,0) as days_early_schedule
				,
				isNull(apply_in_transit,0) as apply_in_transit
				,
				isNull(customer_type,0) as customer_type
				,
				isNull(do_smoothing,0) as do_smoothing
				,
				isNull(smoothing_threshold,0) as smoothing_threshold
				,
				isNull(analysis_code4,'') as analysis_code4
				,
				isNull(analysis_code5,'') as analysis_code5
				,
				isNull(edi_out_for_soack,0) as edi_out_for_soack
				,
				isNull(edi_out_for_invoice,0) as edi_out_for_invoice
				,
				isNull(edi_out_for_crmemo,0) as edi_out_for_crmemo
				,
				isNull(edi_out_prt_soack,0) as edi_out_prt_soack
				,
				isNull(edi_out_for_packsl,0) as edi_out_for_packsl
				,
				isNull(edi_out_prt_invoice,0) as edi_out_prt_invoice
				,
				isNull(edi_out_prt_crmemo,0) as edi_out_prt_crmemo
				,
				isNull(edi_in_forcst_man,0) as edi_in_forcst_man
				,
				isNull(edi_in_forcst_aut,0) as edi_in_forcst_aut
				,
				isNull(edi_in_sonew_man,0) as edi_in_sonew_man
				,
				isNull(edi_in_sonew_aut,0) as edi_in_sonew_aut
				,
				isNull(edi_in_sochg_man,0) as edi_in_sochg_man
				,
				isNull(edi_in_sochg_aut,0) as edi_in_sochg_aut
				,
				isNull(edi_out_prt_packsl,0) as edi_out_prt_packsl
				,
				isNull(edi_in_logging,0) as edi_in_logging
				,
				isNull(edi_in_add_custpart,0) as edi_in_add_custpart
				,
				isNull(edi_in_prod_code_ptr,0) as edi_in_prod_code_ptr
				,
				isNull(edi_in_routecode_ptr,0) as edi_in_routecode_ptr
				,
				isNull(ord_type_ptr,0) as ord_type_ptr
				,
				isNull(emailcpackslip,0) as emailcpackslip
				,
				isNull(emailsoack,0) as emailsoack
				,
				isNull(payterm_ptr,0) as payterm_ptr
				,
				isNull(priority,'') as priority
				,
				isNull(edi_in_fgi_receipts,0) as edi_in_fgi_receipts
				,
				isNull(edi_arch_fgireceipts,0) as edi_arch_fgireceipts
				,
				isNull(active_flag,0) as active_flag
				
			from DATA0010 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<DATA0010> resultList=new List<DATA0010>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							DATA0010  data0010 =new DATA0010();
							
								data0010.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
							      data0010.CUST_CODE =row["CUST_CODE"].ToString();
							      data0010.CUSTOMER_NAME =row["CUSTOMER_NAME"].ToString();
							      data0010.ABBR_NAME =row["ABBR_NAME"].ToString();
							      data0010.BILLING_ADDRESS_1 =row["BILLING_ADDRESS_1"].ToString();
							      data0010.BILLING_ADDRESS_2 =row["BILLING_ADDRESS_2"].ToString();
							      data0010.BILLING_ADDRESS_3 =row["BILLING_ADDRESS_3"].ToString();
							      data0010.STATE =row["STATE"].ToString();
							      data0010.ZIP =row["ZIP"].ToString();
							      data0010.PHONE =row["PHONE"].ToString();
							      data0010.FAX =row["FAX"].ToString();
							      data0010.TELEX =row["TELEX"].ToString();
								  	data0010.SALES_REP_PTR =decimal.Parse(row["SALES_REP_PTR"].ToString()) ;
								  	data0010.CURRENCY_PTR =decimal.Parse(row["CURRENCY_PTR"].ToString()) ;
								  	data0010.QUOTE_NOTE_PAD_PTR =decimal.Parse(row["QUOTE_NOTE_PAD_PTR"].ToString()) ;
								  	data0010.INVOICE_NOTE_PAD_PTR =decimal.Parse(row["INVOICE_NOTE_PAD_PTR"].ToString()) ;
								  	data0010.PACKSLP_NOTE_PAD_PTR =decimal.Parse(row["PACKSLP_NOTE_PAD_PTR"].ToString()) ;
								  	data0010.ORDRACK_NOTE_PAD_PTR =decimal.Parse(row["ORDRACK_NOTE_PAD_PTR"].ToString()) ;
								  	data0010.CRDTMEM_NOTE_PAD_PTR =decimal.Parse(row["CRDTMEM_NOTE_PAD_PTR"].ToString()) ;
								  	data0010.STATMNT_NOTE_PAD_PTR =decimal.Parse(row["STATMNT_NOTE_PAD_PTR"].ToString()) ;
								  	data0010.OPENORD_NOTE_PAD_PTR =decimal.Parse(row["OPENORD_NOTE_PAD_PTR"].ToString()) ;
							      data0010.CONTACT_NAME_1 =row["CONTACT_NAME_1"].ToString();
							      data0010.CONTACT_NAME_2 =row["CONTACT_NAME_2"].ToString();
							      data0010.CONTACT_NAME_3 =row["CONTACT_NAME_3"].ToString();
							      data0010.CONTACT_NAME_4 =row["CONTACT_NAME_4"].ToString();
							      data0010.CONTACT_NAME_5 =row["CONTACT_NAME_5"].ToString();
							      data0010.CONTACT_NAME_6 =row["CONTACT_NAME_6"].ToString();
							      data0010.CONT_PHONE_1 =row["CONT_PHONE_1"].ToString();
							      data0010.CONT_PHONE_2 =row["CONT_PHONE_2"].ToString();
							      data0010.CONT_PHONE_3 =row["CONT_PHONE_3"].ToString();
							      data0010.CONT_PHONE_4 =row["CONT_PHONE_4"].ToString();
							      data0010.CONT_PHONE_5 =row["CONT_PHONE_5"].ToString();
							      data0010.CONT_PHONE_6 =row["CONT_PHONE_6"].ToString();
							      data0010.FED_TAX_ID_NO =row["FED_TAX_ID_NO"].ToString();
							      data0010.COFC_FILENAME =row["COFC_FILENAME"].ToString();
							      data0010.COD_FLAG =row["COD_FLAG"].ToString();
							      data0010.REG_TAX_FIXED_UNUSED =row["REG_TAX_FIXED_UNUSED"].ToString();
								  	data0010.DISCOUNT_PCT =decimal.Parse(row["DISCOUNT_PCT"].ToString()) ;
								  	data0010.HIGH_BALANCE =decimal.Parse(row["HIGH_BALANCE"].ToString()) ;
								  	data0010.CREDIT_LIMIT =decimal.Parse(row["CREDIT_LIMIT"].ToString()) ;
							      data0010.CREDIT_RATING =row["CREDIT_RATING"].ToString();
								  	data0010.BALANCE_DUE =decimal.Parse(row["BALANCE_DUE"].ToString()) ;
								  	data0010.OUTSTANDING_CREDIT =decimal.Parse(row["OUTSTANDING_CREDIT"].ToString()) ;
								  	data0010.YTD_BOOKINGS =decimal.Parse(row["YTD_BOOKINGS"].ToString()) ;
								  	data0010.YTD_BILLINGS =decimal.Parse(row["YTD_BILLINGS"].ToString()) ;
								  	data0010.YTD_RETURNS =decimal.Parse(row["YTD_RETURNS"].ToString()) ;
								  	data0010.YTD_DISCOUNT =decimal.Parse(row["YTD_DISCOUNT"].ToString()) ;
								  	data0010.LYR_BOOKINGS =decimal.Parse(row["LYR_BOOKINGS"].ToString()) ;
								  	data0010.LYR_BILLINGS =decimal.Parse(row["LYR_BILLINGS"].ToString()) ;
								  	data0010.LYR_RETURNS =decimal.Parse(row["LYR_RETURNS"].ToString()) ;
								  	data0010.LYR_DISCOUNT =decimal.Parse(row["LYR_DISCOUNT"].ToString()) ;
								  	data0010.DISCOUNT_DAYS =decimal.Parse(row["DISCOUNT_DAYS"].ToString()) ;
								  	data0010.CURRENT_BOOKINGS =decimal.Parse(row["CURRENT_BOOKINGS"].ToString()) ;
								  	data0010.NET_PAY =decimal.Parse(row["NET_PAY"].ToString()) ;
								  	data0010.LAST_ACTIVE_DATE =DateTime.Parse(row["LAST_ACTIVE_DATE"].ToString()) ;
							      data0010.LANGUAGE_FLAG =row["LANGUAGE_FLAG"].ToString();
							      data0010.BILLING_ADDRESS_4 =row["BILLING_ADDRESS_4"].ToString();
								  	data0010.COUNTRY_PTR =decimal.Parse(row["COUNTRY_PTR"].ToString()) ;
								  	data0010.INTERNAL_ECN_COUNT =decimal.Parse(row["INTERNAL_ECN_COUNT"].ToString()) ;
								  	data0010.EXTERNAL_ECN_COUNT =decimal.Parse(row["EXTERNAL_ECN_COUNT"].ToString()) ;
							      data0010.OUTGOING_FORM_NAME =row["OUTGOING_FORM_NAME"].ToString();
							      data0010.OUTGOING_FORM_ADDR1 =row["OUTGOING_FORM_ADDR1"].ToString();
							      data0010.OUTGOING_FORM_ADDR2 =row["OUTGOING_FORM_ADDR2"].ToString();
							      data0010.OUTGOING_FORM_ADDR3 =row["OUTGOING_FORM_ADDR3"].ToString();
							      data0010.ANALYSIS_CODE1 =row["ANALYSIS_CODE1"].ToString();
							      data0010.ANALYSIS_CODE2 =row["ANALYSIS_CODE2"].ToString();
							      data0010.ANALYSIS_CODE3 =row["ANALYSIS_CODE3"].ToString();
								  	data0010.CUST_ENT_DATE =DateTime.Parse(row["CUST_ENT_DATE"].ToString()) ;
							      data0010.EDI_ID =row["EDI_ID"].ToString();
								  	data0010.EDI_FLAG_FOR_SOACK =decimal.Parse(row["EDI_FLAG_FOR_SOACK"].ToString()) ;
								  	data0010.EDI_FLAG_FOR_INVOICE =decimal.Parse(row["EDI_FLAG_FOR_INVOICE"].ToString()) ;
								  	data0010.EDI_FLAG_CREDIT_MEMO =decimal.Parse(row["EDI_FLAG_CREDIT_MEMO"].ToString()) ;
							      data0010.GEN_EMAIL_ADDRESS =row["GEN_EMAIL_ADDRESS"].ToString();
							      data0010.EMAIL_FOR_CONTACT1 =row["EMAIL_FOR_CONTACT1"].ToString();
							      data0010.EMAIL_FOR_CONTACT2 =row["EMAIL_FOR_CONTACT2"].ToString();
							      data0010.EMAIL_FOR_CONTACT3 =row["EMAIL_FOR_CONTACT3"].ToString();
							      data0010.EMAIL_FOR_CONTACT4 =row["EMAIL_FOR_CONTACT4"].ToString();
							      data0010.EMAIL_FOR_CONTACT5 =row["EMAIL_FOR_CONTACT5"].ToString();
							      data0010.EMAIL_FOR_CONTACT6 =row["EMAIL_FOR_CONTACT6"].ToString();
								  	data0010.ACC_REC_PTR =decimal.Parse(row["ACC_REC_PTR"].ToString()) ;
								  	data0010.CONSUME_FORECASTS =decimal.Parse(row["CONSUME_FORECASTS"].ToString()) ;
								  	data0010.BACKWARD_DAYS =decimal.Parse(row["BACKWARD_DAYS"].ToString()) ;
								  	data0010.FORWARD_DAYS =decimal.Parse(row["FORWARD_DAYS"].ToString()) ;
								  	data0010.PLANNING_HORIZON =decimal.Parse(row["PLANNING_HORIZON"].ToString()) ;
								  	data0010.RAW_HORIZON =decimal.Parse(row["RAW_HORIZON"].ToString()) ;
								  	data0010.VISIBILITY_HORIZON =decimal.Parse(row["VISIBILITY_HORIZON"].ToString()) ;
								  	data0010.DAYS_EARLY_SCHEDULE =decimal.Parse(row["DAYS_EARLY_SCHEDULE"].ToString()) ;
								  	data0010.APPLY_IN_TRANSIT =decimal.Parse(row["APPLY_IN_TRANSIT"].ToString()) ;
								  	data0010.CUSTOMER_TYPE =decimal.Parse(row["CUSTOMER_TYPE"].ToString()) ;
								  	data0010.DO_SMOOTHING =decimal.Parse(row["DO_SMOOTHING"].ToString()) ;
								  	data0010.SMOOTHING_THRESHOLD =decimal.Parse(row["SMOOTHING_THRESHOLD"].ToString()) ;
							      data0010.ANALYSIS_CODE4 =row["ANALYSIS_CODE4"].ToString();
							      data0010.ANALYSIS_CODE5 =row["ANALYSIS_CODE5"].ToString();
								  	data0010.EDI_OUT_FOR_SOACK =decimal.Parse(row["EDI_OUT_FOR_SOACK"].ToString()) ;
								  	data0010.EDI_OUT_FOR_INVOICE =decimal.Parse(row["EDI_OUT_FOR_INVOICE"].ToString()) ;
								  	data0010.EDI_OUT_FOR_CRMEMO =decimal.Parse(row["EDI_OUT_FOR_CRMEMO"].ToString()) ;
								  	data0010.EDI_OUT_PRT_SOACK =decimal.Parse(row["EDI_OUT_PRT_SOACK"].ToString()) ;
								  	data0010.EDI_OUT_FOR_PACKSL =decimal.Parse(row["EDI_OUT_FOR_PACKSL"].ToString()) ;
								  	data0010.EDI_OUT_PRT_INVOICE =decimal.Parse(row["EDI_OUT_PRT_INVOICE"].ToString()) ;
								  	data0010.EDI_OUT_PRT_CRMEMO =decimal.Parse(row["EDI_OUT_PRT_CRMEMO"].ToString()) ;
								  	data0010.EDI_IN_FORCST_MAN =decimal.Parse(row["EDI_IN_FORCST_MAN"].ToString()) ;
								  	data0010.EDI_IN_FORCST_AUT =decimal.Parse(row["EDI_IN_FORCST_AUT"].ToString()) ;
								  	data0010.EDI_IN_SONEW_MAN =decimal.Parse(row["EDI_IN_SONEW_MAN"].ToString()) ;
								  	data0010.EDI_IN_SONEW_AUT =decimal.Parse(row["EDI_IN_SONEW_AUT"].ToString()) ;
								  	data0010.EDI_IN_SOCHG_MAN =decimal.Parse(row["EDI_IN_SOCHG_MAN"].ToString()) ;
								  	data0010.EDI_IN_SOCHG_AUT =decimal.Parse(row["EDI_IN_SOCHG_AUT"].ToString()) ;
								  	data0010.EDI_OUT_PRT_PACKSL =decimal.Parse(row["EDI_OUT_PRT_PACKSL"].ToString()) ;
								  	data0010.EDI_IN_LOGGING =decimal.Parse(row["EDI_IN_LOGGING"].ToString()) ;
								  	data0010.EDI_IN_ADD_CUSTPART =decimal.Parse(row["EDI_IN_ADD_CUSTPART"].ToString()) ;
								  	data0010.EDI_IN_PROD_CODE_PTR =decimal.Parse(row["EDI_IN_PROD_CODE_PTR"].ToString()) ;
								  	data0010.EDI_IN_ROUTECODE_PTR =decimal.Parse(row["EDI_IN_ROUTECODE_PTR"].ToString()) ;
								  	data0010.ORD_TYPE_PTR =decimal.Parse(row["ORD_TYPE_PTR"].ToString()) ;
								  	data0010.EMAILCPACKSLIP =decimal.Parse(row["EMAILCPACKSLIP"].ToString()) ;
								  	data0010.EMAILSOACK =decimal.Parse(row["EMAILSOACK"].ToString()) ;
								  	data0010.PAYTERM_PTR =decimal.Parse(row["PAYTERM_PTR"].ToString()) ;
							      data0010.PRIORITY =row["PRIORITY"].ToString();
								  	data0010.EDI_IN_FGI_RECEIPTS =decimal.Parse(row["EDI_IN_FGI_RECEIPTS"].ToString()) ;
								  	data0010.EDI_ARCH_FGIRECEIPTS =decimal.Parse(row["EDI_ARCH_FGIRECEIPTS"].ToString()) ;
								  	data0010.ACTIVE_FLAG =decimal.Parse(row["ACTIVE_FLAG"].ToString()) ;
		
							resultList.Add(data0010);
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

