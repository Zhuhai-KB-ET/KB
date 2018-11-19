//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:37
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace KB.Models
{
	///<summary>
	///数据实体 [表名("DATA0010")]
	/// </summary>
	[Serializable()]
	public class DATA0010 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string cust_code = String.Empty;
		private string customer_name = String.Empty;
		private string abbr_name = String.Empty;
		private string billing_address_1 = String.Empty;
		private string billing_address_2 = String.Empty;
		private string billing_address_3 = String.Empty;
		private string state = String.Empty;
		private string zip = String.Empty;
		private string phone = String.Empty;
		private string fax = String.Empty;
		private string telex = String.Empty;
		private decimal sales_rep_ptr;
		private decimal currency_ptr;
		private decimal quote_note_pad_ptr;
		private decimal invoice_note_pad_ptr;
		private decimal packslp_note_pad_ptr;
		private decimal ordrack_note_pad_ptr;
		private decimal crdtmem_note_pad_ptr;
		private decimal statmnt_note_pad_ptr;
		private decimal openord_note_pad_ptr;
		private string contact_name_1 = String.Empty;
		private string contact_name_2 = String.Empty;
		private string contact_name_3 = String.Empty;
		private string contact_name_4 = String.Empty;
		private string contact_name_5 = String.Empty;
		private string contact_name_6 = String.Empty;
		private string cont_phone_1 = String.Empty;
		private string cont_phone_2 = String.Empty;
		private string cont_phone_3 = String.Empty;
		private string cont_phone_4 = String.Empty;
		private string cont_phone_5 = String.Empty;
		private string cont_phone_6 = String.Empty;
		private string fed_tax_id_no = String.Empty;
		private string cofc_filename = String.Empty;
		private string cod_flag = String.Empty;
		private string reg_tax_fixed_unused = String.Empty;
		private decimal discount_pct;
		private decimal high_balance;
		private decimal credit_limit;
		private string credit_rating = String.Empty;
		private decimal balance_due;
		private decimal outstanding_credit;
		private decimal ytd_bookings;
		private decimal ytd_billings;
		private decimal ytd_returns;
		private decimal ytd_discount;
		private decimal lyr_bookings;
		private decimal lyr_billings;
		private decimal lyr_returns;
		private decimal lyr_discount;
		private decimal discount_days;
		private decimal current_bookings;
		private decimal net_pay;
		private DateTime last_active_date;
		private string language_flag = String.Empty;
		private string billing_address_4 = String.Empty;
		private decimal country_ptr;
		private decimal internal_ecn_count;
		private decimal external_ecn_count;
		private string outgoing_form_name = String.Empty;
		private string outgoing_form_addr1 = String.Empty;
		private string outgoing_form_addr2 = String.Empty;
		private string outgoing_form_addr3 = String.Empty;
		private string analysis_code1 = String.Empty;
		private string analysis_code2 = String.Empty;
		private string analysis_code3 = String.Empty;
		private DateTime cust_ent_date;
		private string edi_id = String.Empty;
		private decimal edi_flag_for_soack;
		private decimal edi_flag_for_invoice;
		private decimal edi_flag_credit_memo;
		private string gen_email_address = String.Empty;
		private string email_for_contact1 = String.Empty;
		private string email_for_contact2 = String.Empty;
		private string email_for_contact3 = String.Empty;
		private string email_for_contact4 = String.Empty;
		private string email_for_contact5 = String.Empty;
		private string email_for_contact6 = String.Empty;
		private decimal acc_rec_ptr;
		private decimal consume_forecasts;
		private decimal backward_days;
		private decimal forward_days;
		private decimal planning_horizon;
		private decimal raw_horizon;
		private decimal visibility_horizon;
		private decimal days_early_schedule;
		private decimal apply_in_transit;
		private decimal customer_type;
		private decimal do_smoothing;
		private decimal smoothing_threshold;
		private string analysis_code4 = String.Empty;
		private string analysis_code5 = String.Empty;
		private decimal edi_out_for_soack;
		private decimal edi_out_for_invoice;
		private decimal edi_out_for_crmemo;
		private decimal edi_out_prt_soack;
		private decimal edi_out_for_packsl;
		private decimal edi_out_prt_invoice;
		private decimal edi_out_prt_crmemo;
		private decimal edi_in_forcst_man;
		private decimal edi_in_forcst_aut;
		private decimal edi_in_sonew_man;
		private decimal edi_in_sonew_aut;
		private decimal edi_in_sochg_man;
		private decimal edi_in_sochg_aut;
		private decimal edi_out_prt_packsl;
		private decimal edi_in_logging;
		private decimal edi_in_add_custpart;
		private decimal edi_in_prod_code_ptr;
		private decimal edi_in_routecode_ptr;
		private decimal ord_type_ptr;
		private decimal emailcpackslip;
		private decimal emailsoack;
		private decimal payterm_ptr;
		private string priority = String.Empty;
		private decimal edi_in_fgi_receipts;
		private decimal edi_arch_fgireceipts;
		private decimal active_flag;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0010() { } 
		
		///<summary>
		///主键 [字段("RKEY")]
		///数据库类型:numeric(10, 0)
		///</summary> 
		public decimal RKEY
		{
			get { return this.rkey; }
			set { this.rkey = value; }
		} 
		
		
		
		///<summary>
		///属性 [("CUST_CODE")]
		///数据库类型:char(5)
		///</summary>
		public string CUST_CODE
		{
			get { return this.cust_code; }
			set { this.cust_code = value; }
		}
		
		///<summary>
		///属性 [("CUSTOMER_NAME")]
		///数据库类型:char(30)
		///</summary>
		public string CUSTOMER_NAME
		{
			get { return this.customer_name; }
			set { this.customer_name = value; }
		}
		
		///<summary>
		///属性 [("ABBR_NAME")]
		///数据库类型:char(10)
		///</summary>
		public string ABBR_NAME
		{
			get { return this.abbr_name; }
			set { this.abbr_name = value; }
		}
		
		///<summary>
		///属性 [("BILLING_ADDRESS_1")]
		///数据库类型:char(30)
		///</summary>
		public string BILLING_ADDRESS_1
		{
			get { return this.billing_address_1; }
			set { this.billing_address_1 = value; }
		}
		
		///<summary>
		///属性 [("BILLING_ADDRESS_2")]
		///数据库类型:char(30)
		///</summary>
		public string BILLING_ADDRESS_2
		{
			get { return this.billing_address_2; }
			set { this.billing_address_2 = value; }
		}
		
		///<summary>
		///属性 [("BILLING_ADDRESS_3")]
		///数据库类型:char(30)
		///</summary>
		public string BILLING_ADDRESS_3
		{
			get { return this.billing_address_3; }
			set { this.billing_address_3 = value; }
		}
		
		///<summary>
		///属性 [("STATE")]
		///数据库类型:char(3)
		///</summary>
		public string STATE
		{
			get { return this.state; }
			set { this.state = value; }
		}
		
		///<summary>
		///属性 [("ZIP")]
		///数据库类型:char(10)
		///</summary>
		public string ZIP
		{
			get { return this.zip; }
			set { this.zip = value; }
		}
		
		///<summary>
		///属性 [("PHONE")]
		///数据库类型:char(30)
		///</summary>
		public string PHONE
		{
			get { return this.phone; }
			set { this.phone = value; }
		}
		
		///<summary>
		///属性 [("FAX")]
		///数据库类型:char(30)
		///</summary>
		public string FAX
		{
			get { return this.fax; }
			set { this.fax = value; }
		}
		
		///<summary>
		///属性 [("TELEX")]
		///数据库类型:char(30)
		///</summary>
		public string TELEX
		{
			get { return this.telex; }
			set { this.telex = value; }
		}
		
		///<summary>
		///属性 [("SALES_REP_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal SALES_REP_PTR
		{
			get { return this.sales_rep_ptr; }
			set { this.sales_rep_ptr = value; }
		}
		
		///<summary>
		///属性 [("CURRENCY_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal CURRENCY_PTR
		{
			get { return this.currency_ptr; }
			set { this.currency_ptr = value; }
		}
		
		///<summary>
		///属性 [("QUOTE_NOTE_PAD_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal QUOTE_NOTE_PAD_PTR
		{
			get { return this.quote_note_pad_ptr; }
			set { this.quote_note_pad_ptr = value; }
		}
		
		///<summary>
		///属性 [("INVOICE_NOTE_PAD_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal INVOICE_NOTE_PAD_PTR
		{
			get { return this.invoice_note_pad_ptr; }
			set { this.invoice_note_pad_ptr = value; }
		}
		
		///<summary>
		///属性 [("PACKSLP_NOTE_PAD_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal PACKSLP_NOTE_PAD_PTR
		{
			get { return this.packslp_note_pad_ptr; }
			set { this.packslp_note_pad_ptr = value; }
		}
		
		///<summary>
		///属性 [("ORDRACK_NOTE_PAD_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal ORDRACK_NOTE_PAD_PTR
		{
			get { return this.ordrack_note_pad_ptr; }
			set { this.ordrack_note_pad_ptr = value; }
		}
		
		///<summary>
		///属性 [("CRDTMEM_NOTE_PAD_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal CRDTMEM_NOTE_PAD_PTR
		{
			get { return this.crdtmem_note_pad_ptr; }
			set { this.crdtmem_note_pad_ptr = value; }
		}
		
		///<summary>
		///属性 [("STATMNT_NOTE_PAD_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal STATMNT_NOTE_PAD_PTR
		{
			get { return this.statmnt_note_pad_ptr; }
			set { this.statmnt_note_pad_ptr = value; }
		}
		
		///<summary>
		///属性 [("OPENORD_NOTE_PAD_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal OPENORD_NOTE_PAD_PTR
		{
			get { return this.openord_note_pad_ptr; }
			set { this.openord_note_pad_ptr = value; }
		}
		
		///<summary>
		///属性 [("CONTACT_NAME_1")]
		///数据库类型:char(20)
		///</summary>
		public string CONTACT_NAME_1
		{
			get { return this.contact_name_1; }
			set { this.contact_name_1 = value; }
		}
		
		///<summary>
		///属性 [("CONTACT_NAME_2")]
		///数据库类型:char(20)
		///</summary>
		public string CONTACT_NAME_2
		{
			get { return this.contact_name_2; }
			set { this.contact_name_2 = value; }
		}
		
		///<summary>
		///属性 [("CONTACT_NAME_3")]
		///数据库类型:char(20)
		///</summary>
		public string CONTACT_NAME_3
		{
			get { return this.contact_name_3; }
			set { this.contact_name_3 = value; }
		}
		
		///<summary>
		///属性 [("CONTACT_NAME_4")]
		///数据库类型:char(20)
		///</summary>
		public string CONTACT_NAME_4
		{
			get { return this.contact_name_4; }
			set { this.contact_name_4 = value; }
		}
		
		///<summary>
		///属性 [("CONTACT_NAME_5")]
		///数据库类型:char(20)
		///</summary>
		public string CONTACT_NAME_5
		{
			get { return this.contact_name_5; }
			set { this.contact_name_5 = value; }
		}
		
		///<summary>
		///属性 [("CONTACT_NAME_6")]
		///数据库类型:char(20)
		///</summary>
		public string CONTACT_NAME_6
		{
			get { return this.contact_name_6; }
			set { this.contact_name_6 = value; }
		}
		
		///<summary>
		///属性 [("CONT_PHONE_1")]
		///数据库类型:char(30)
		///</summary>
		public string CONT_PHONE_1
		{
			get { return this.cont_phone_1; }
			set { this.cont_phone_1 = value; }
		}
		
		///<summary>
		///属性 [("CONT_PHONE_2")]
		///数据库类型:char(30)
		///</summary>
		public string CONT_PHONE_2
		{
			get { return this.cont_phone_2; }
			set { this.cont_phone_2 = value; }
		}
		
		///<summary>
		///属性 [("CONT_PHONE_3")]
		///数据库类型:char(30)
		///</summary>
		public string CONT_PHONE_3
		{
			get { return this.cont_phone_3; }
			set { this.cont_phone_3 = value; }
		}
		
		///<summary>
		///属性 [("CONT_PHONE_4")]
		///数据库类型:char(30)
		///</summary>
		public string CONT_PHONE_4
		{
			get { return this.cont_phone_4; }
			set { this.cont_phone_4 = value; }
		}
		
		///<summary>
		///属性 [("CONT_PHONE_5")]
		///数据库类型:char(30)
		///</summary>
		public string CONT_PHONE_5
		{
			get { return this.cont_phone_5; }
			set { this.cont_phone_5 = value; }
		}
		
		///<summary>
		///属性 [("CONT_PHONE_6")]
		///数据库类型:char(30)
		///</summary>
		public string CONT_PHONE_6
		{
			get { return this.cont_phone_6; }
			set { this.cont_phone_6 = value; }
		}
		
		///<summary>
		///属性 [("FED_TAX_ID_NO")]
		///数据库类型:char(15)
		///</summary>
		public string FED_TAX_ID_NO
		{
			get { return this.fed_tax_id_no; }
			set { this.fed_tax_id_no = value; }
		}
		
		///<summary>
		///属性 [("COFC_FILENAME")]
		///数据库类型:char(15)
		///</summary>
		public string COFC_FILENAME
		{
			get { return this.cofc_filename; }
			set { this.cofc_filename = value; }
		}
		
		///<summary>
		///属性 [("COD_FLAG")]
		///数据库类型:char(1)
		///</summary>
		public string COD_FLAG
		{
			get { return this.cod_flag; }
			set { this.cod_flag = value; }
		}
		
		///<summary>
		///属性 [("REG_TAX_FIXED_UNUSED")]
		///数据库类型:char(1)
		///</summary>
		public string REG_TAX_FIXED_UNUSED
		{
			get { return this.reg_tax_fixed_unused; }
			set { this.reg_tax_fixed_unused = value; }
		}
		
		///<summary>
		///属性 [("DISCOUNT_PCT")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal DISCOUNT_PCT
		{
			get { return this.discount_pct; }
			set { this.discount_pct = value; }
		}
		
		///<summary>
		///属性 [("HIGH_BALANCE")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal HIGH_BALANCE
		{
			get { return this.high_balance; }
			set { this.high_balance = value; }
		}
		
		///<summary>
		///属性 [("CREDIT_LIMIT")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal CREDIT_LIMIT
		{
			get { return this.credit_limit; }
			set { this.credit_limit = value; }
		}
		
		///<summary>
		///属性 [("CREDIT_RATING")]
		///数据库类型:char(1)
		///</summary>
		public string CREDIT_RATING
		{
			get { return this.credit_rating; }
			set { this.credit_rating = value; }
		}
		
		///<summary>
		///属性 [("BALANCE_DUE")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal BALANCE_DUE
		{
			get { return this.balance_due; }
			set { this.balance_due = value; }
		}
		
		///<summary>
		///属性 [("OUTSTANDING_CREDIT")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal OUTSTANDING_CREDIT
		{
			get { return this.outstanding_credit; }
			set { this.outstanding_credit = value; }
		}
		
		///<summary>
		///属性 [("YTD_BOOKINGS")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal YTD_BOOKINGS
		{
			get { return this.ytd_bookings; }
			set { this.ytd_bookings = value; }
		}
		
		///<summary>
		///属性 [("YTD_BILLINGS")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal YTD_BILLINGS
		{
			get { return this.ytd_billings; }
			set { this.ytd_billings = value; }
		}
		
		///<summary>
		///属性 [("YTD_RETURNS")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal YTD_RETURNS
		{
			get { return this.ytd_returns; }
			set { this.ytd_returns = value; }
		}
		
		///<summary>
		///属性 [("YTD_DISCOUNT")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal YTD_DISCOUNT
		{
			get { return this.ytd_discount; }
			set { this.ytd_discount = value; }
		}
		
		///<summary>
		///属性 [("LYR_BOOKINGS")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal LYR_BOOKINGS
		{
			get { return this.lyr_bookings; }
			set { this.lyr_bookings = value; }
		}
		
		///<summary>
		///属性 [("LYR_BILLINGS")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal LYR_BILLINGS
		{
			get { return this.lyr_billings; }
			set { this.lyr_billings = value; }
		}
		
		///<summary>
		///属性 [("LYR_RETURNS")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal LYR_RETURNS
		{
			get { return this.lyr_returns; }
			set { this.lyr_returns = value; }
		}
		
		///<summary>
		///属性 [("LYR_DISCOUNT")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal LYR_DISCOUNT
		{
			get { return this.lyr_discount; }
			set { this.lyr_discount = value; }
		}
		
		///<summary>
		///属性 [("DISCOUNT_DAYS")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal DISCOUNT_DAYS
		{
			get { return this.discount_days; }
			set { this.discount_days = value; }
		}
		
		///<summary>
		///属性 [("CURRENT_BOOKINGS")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal CURRENT_BOOKINGS
		{
			get { return this.current_bookings; }
			set { this.current_bookings = value; }
		}
		
		///<summary>
		///属性 [("NET_PAY")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal NET_PAY
		{
			get { return this.net_pay; }
			set { this.net_pay = value; }
		}
		
		///<summary>
		///属性 [("LAST_ACTIVE_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime LAST_ACTIVE_DATE
		{
			get { return this.last_active_date; }
			set { this.last_active_date = value; }
		}
		
		///<summary>
		///属性 [("LANGUAGE_FLAG")]
		///数据库类型:char(1)
		///</summary>
		public string LANGUAGE_FLAG
		{
			get { return this.language_flag; }
			set { this.language_flag = value; }
		}
		
		///<summary>
		///属性 [("BILLING_ADDRESS_4")]
		///数据库类型:char(30)
		///</summary>
		public string BILLING_ADDRESS_4
		{
			get { return this.billing_address_4; }
			set { this.billing_address_4 = value; }
		}
		
		///<summary>
		///属性 [("COUNTRY_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal COUNTRY_PTR
		{
			get { return this.country_ptr; }
			set { this.country_ptr = value; }
		}
		
		///<summary>
		///属性 [("INTERNAL_ECN_COUNT")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal INTERNAL_ECN_COUNT
		{
			get { return this.internal_ecn_count; }
			set { this.internal_ecn_count = value; }
		}
		
		///<summary>
		///属性 [("EXTERNAL_ECN_COUNT")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EXTERNAL_ECN_COUNT
		{
			get { return this.external_ecn_count; }
			set { this.external_ecn_count = value; }
		}
		
		///<summary>
		///属性 [("OUTGOING_FORM_NAME")]
		///数据库类型:char(60)
		///</summary>
		public string OUTGOING_FORM_NAME
		{
			get { return this.outgoing_form_name; }
			set { this.outgoing_form_name = value; }
		}
		
		///<summary>
		///属性 [("OUTGOING_FORM_ADDR1")]
		///数据库类型:char(45)
		///</summary>
		public string OUTGOING_FORM_ADDR1
		{
			get { return this.outgoing_form_addr1; }
			set { this.outgoing_form_addr1 = value; }
		}
		
		///<summary>
		///属性 [("OUTGOING_FORM_ADDR2")]
		///数据库类型:char(45)
		///</summary>
		public string OUTGOING_FORM_ADDR2
		{
			get { return this.outgoing_form_addr2; }
			set { this.outgoing_form_addr2 = value; }
		}
		
		///<summary>
		///属性 [("OUTGOING_FORM_ADDR3")]
		///数据库类型:char(45)
		///</summary>
		public string OUTGOING_FORM_ADDR3
		{
			get { return this.outgoing_form_addr3; }
			set { this.outgoing_form_addr3 = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE1")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE1
		{
			get { return this.analysis_code1; }
			set { this.analysis_code1 = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE2")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE2
		{
			get { return this.analysis_code2; }
			set { this.analysis_code2 = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE3")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE3
		{
			get { return this.analysis_code3; }
			set { this.analysis_code3 = value; }
		}
		
		///<summary>
		///属性 [("CUST_ENT_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime CUST_ENT_DATE
		{
			get { return this.cust_ent_date; }
			set { this.cust_ent_date = value; }
		}
		
		///<summary>
		///属性 [("EDI_ID")]
		///数据库类型:char(50)
		///</summary>
		public string EDI_ID
		{
			get { return this.edi_id; }
			set { this.edi_id = value; }
		}
		
		///<summary>
		///属性 [("EDI_FLAG_FOR_SOACK")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_FLAG_FOR_SOACK
		{
			get { return this.edi_flag_for_soack; }
			set { this.edi_flag_for_soack = value; }
		}
		
		///<summary>
		///属性 [("EDI_FLAG_FOR_INVOICE")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_FLAG_FOR_INVOICE
		{
			get { return this.edi_flag_for_invoice; }
			set { this.edi_flag_for_invoice = value; }
		}
		
		///<summary>
		///属性 [("EDI_FLAG_CREDIT_MEMO")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_FLAG_CREDIT_MEMO
		{
			get { return this.edi_flag_credit_memo; }
			set { this.edi_flag_credit_memo = value; }
		}
		
		///<summary>
		///属性 [("GEN_EMAIL_ADDRESS")]
		///数据库类型:char(50)
		///</summary>
		public string GEN_EMAIL_ADDRESS
		{
			get { return this.gen_email_address; }
			set { this.gen_email_address = value; }
		}
		
		///<summary>
		///属性 [("EMAIL_FOR_CONTACT1")]
		///数据库类型:char(50)
		///</summary>
		public string EMAIL_FOR_CONTACT1
		{
			get { return this.email_for_contact1; }
			set { this.email_for_contact1 = value; }
		}
		
		///<summary>
		///属性 [("EMAIL_FOR_CONTACT2")]
		///数据库类型:char(50)
		///</summary>
		public string EMAIL_FOR_CONTACT2
		{
			get { return this.email_for_contact2; }
			set { this.email_for_contact2 = value; }
		}
		
		///<summary>
		///属性 [("EMAIL_FOR_CONTACT3")]
		///数据库类型:char(50)
		///</summary>
		public string EMAIL_FOR_CONTACT3
		{
			get { return this.email_for_contact3; }
			set { this.email_for_contact3 = value; }
		}
		
		///<summary>
		///属性 [("EMAIL_FOR_CONTACT4")]
		///数据库类型:char(50)
		///</summary>
		public string EMAIL_FOR_CONTACT4
		{
			get { return this.email_for_contact4; }
			set { this.email_for_contact4 = value; }
		}
		
		///<summary>
		///属性 [("EMAIL_FOR_CONTACT5")]
		///数据库类型:char(50)
		///</summary>
		public string EMAIL_FOR_CONTACT5
		{
			get { return this.email_for_contact5; }
			set { this.email_for_contact5 = value; }
		}
		
		///<summary>
		///属性 [("EMAIL_FOR_CONTACT6")]
		///数据库类型:char(50)
		///</summary>
		public string EMAIL_FOR_CONTACT6
		{
			get { return this.email_for_contact6; }
			set { this.email_for_contact6 = value; }
		}
		
		///<summary>
		///属性 [("ACC_REC_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal ACC_REC_PTR
		{
			get { return this.acc_rec_ptr; }
			set { this.acc_rec_ptr = value; }
		}
		
		///<summary>
		///属性 [("CONSUME_FORECASTS")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal CONSUME_FORECASTS
		{
			get { return this.consume_forecasts; }
			set { this.consume_forecasts = value; }
		}
		
		///<summary>
		///属性 [("BACKWARD_DAYS")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal BACKWARD_DAYS
		{
			get { return this.backward_days; }
			set { this.backward_days = value; }
		}
		
		///<summary>
		///属性 [("FORWARD_DAYS")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal FORWARD_DAYS
		{
			get { return this.forward_days; }
			set { this.forward_days = value; }
		}
		
		///<summary>
		///属性 [("PLANNING_HORIZON")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal PLANNING_HORIZON
		{
			get { return this.planning_horizon; }
			set { this.planning_horizon = value; }
		}
		
		///<summary>
		///属性 [("RAW_HORIZON")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal RAW_HORIZON
		{
			get { return this.raw_horizon; }
			set { this.raw_horizon = value; }
		}
		
		///<summary>
		///属性 [("VISIBILITY_HORIZON")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal VISIBILITY_HORIZON
		{
			get { return this.visibility_horizon; }
			set { this.visibility_horizon = value; }
		}
		
		///<summary>
		///属性 [("DAYS_EARLY_SCHEDULE")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal DAYS_EARLY_SCHEDULE
		{
			get { return this.days_early_schedule; }
			set { this.days_early_schedule = value; }
		}
		
		///<summary>
		///属性 [("APPLY_IN_TRANSIT")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal APPLY_IN_TRANSIT
		{
			get { return this.apply_in_transit; }
			set { this.apply_in_transit = value; }
		}
		
		///<summary>
		///属性 [("CUSTOMER_TYPE")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal CUSTOMER_TYPE
		{
			get { return this.customer_type; }
			set { this.customer_type = value; }
		}
		
		///<summary>
		///属性 [("DO_SMOOTHING")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal DO_SMOOTHING
		{
			get { return this.do_smoothing; }
			set { this.do_smoothing = value; }
		}
		
		///<summary>
		///属性 [("SMOOTHING_THRESHOLD")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal SMOOTHING_THRESHOLD
		{
			get { return this.smoothing_threshold; }
			set { this.smoothing_threshold = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE4")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE4
		{
			get { return this.analysis_code4; }
			set { this.analysis_code4 = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE5")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE5
		{
			get { return this.analysis_code5; }
			set { this.analysis_code5 = value; }
		}
		
		///<summary>
		///属性 [("EDI_OUT_FOR_SOACK")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_OUT_FOR_SOACK
		{
			get { return this.edi_out_for_soack; }
			set { this.edi_out_for_soack = value; }
		}
		
		///<summary>
		///属性 [("EDI_OUT_FOR_INVOICE")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_OUT_FOR_INVOICE
		{
			get { return this.edi_out_for_invoice; }
			set { this.edi_out_for_invoice = value; }
		}
		
		///<summary>
		///属性 [("EDI_OUT_FOR_CRMEMO")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_OUT_FOR_CRMEMO
		{
			get { return this.edi_out_for_crmemo; }
			set { this.edi_out_for_crmemo = value; }
		}
		
		///<summary>
		///属性 [("EDI_OUT_PRT_SOACK")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_OUT_PRT_SOACK
		{
			get { return this.edi_out_prt_soack; }
			set { this.edi_out_prt_soack = value; }
		}
		
		///<summary>
		///属性 [("EDI_OUT_FOR_PACKSL")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_OUT_FOR_PACKSL
		{
			get { return this.edi_out_for_packsl; }
			set { this.edi_out_for_packsl = value; }
		}
		
		///<summary>
		///属性 [("EDI_OUT_PRT_INVOICE")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_OUT_PRT_INVOICE
		{
			get { return this.edi_out_prt_invoice; }
			set { this.edi_out_prt_invoice = value; }
		}
		
		///<summary>
		///属性 [("EDI_OUT_PRT_CRMEMO")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_OUT_PRT_CRMEMO
		{
			get { return this.edi_out_prt_crmemo; }
			set { this.edi_out_prt_crmemo = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_FORCST_MAN")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_FORCST_MAN
		{
			get { return this.edi_in_forcst_man; }
			set { this.edi_in_forcst_man = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_FORCST_AUT")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_FORCST_AUT
		{
			get { return this.edi_in_forcst_aut; }
			set { this.edi_in_forcst_aut = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_SONEW_MAN")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_SONEW_MAN
		{
			get { return this.edi_in_sonew_man; }
			set { this.edi_in_sonew_man = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_SONEW_AUT")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_SONEW_AUT
		{
			get { return this.edi_in_sonew_aut; }
			set { this.edi_in_sonew_aut = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_SOCHG_MAN")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_SOCHG_MAN
		{
			get { return this.edi_in_sochg_man; }
			set { this.edi_in_sochg_man = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_SOCHG_AUT")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_SOCHG_AUT
		{
			get { return this.edi_in_sochg_aut; }
			set { this.edi_in_sochg_aut = value; }
		}
		
		///<summary>
		///属性 [("EDI_OUT_PRT_PACKSL")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_OUT_PRT_PACKSL
		{
			get { return this.edi_out_prt_packsl; }
			set { this.edi_out_prt_packsl = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_LOGGING")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_LOGGING
		{
			get { return this.edi_in_logging; }
			set { this.edi_in_logging = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_ADD_CUSTPART")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_ADD_CUSTPART
		{
			get { return this.edi_in_add_custpart; }
			set { this.edi_in_add_custpart = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_PROD_CODE_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_PROD_CODE_PTR
		{
			get { return this.edi_in_prod_code_ptr; }
			set { this.edi_in_prod_code_ptr = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_ROUTECODE_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDI_IN_ROUTECODE_PTR
		{
			get { return this.edi_in_routecode_ptr; }
			set { this.edi_in_routecode_ptr = value; }
		}
		
		///<summary>
		///属性 [("ORD_TYPE_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal ORD_TYPE_PTR
		{
			get { return this.ord_type_ptr; }
			set { this.ord_type_ptr = value; }
		}
		
		///<summary>
		///属性 [("EMAILCPACKSLIP")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EMAILCPACKSLIP
		{
			get { return this.emailcpackslip; }
			set { this.emailcpackslip = value; }
		}
		
		///<summary>
		///属性 [("EMAILSOACK")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EMAILSOACK
		{
			get { return this.emailsoack; }
			set { this.emailsoack = value; }
		}
		
		///<summary>
		///属性 [("PAYTERM_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal PAYTERM_PTR
		{
			get { return this.payterm_ptr; }
			set { this.payterm_ptr = value; }
		}
		
		///<summary>
		///属性 [("PRIORITY")]
		///数据库类型:char(1)
		///</summary>
		public string PRIORITY
		{
			get { return this.priority; }
			set { this.priority = value; }
		}
		
		///<summary>
		///属性 [("EDI_IN_FGI_RECEIPTS")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal EDI_IN_FGI_RECEIPTS
		{
			get { return this.edi_in_fgi_receipts; }
			set { this.edi_in_fgi_receipts = value; }
		}
		
		///<summary>
		///属性 [("EDI_ARCH_FGIRECEIPTS")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal EDI_ARCH_FGIRECEIPTS
		{
			get { return this.edi_arch_fgireceipts; }
			set { this.edi_arch_fgireceipts = value; }
		}
		
		///<summary>
		///属性 [("ACTIVE_FLAG")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal ACTIVE_FLAG
		{
			get { return this.active_flag; }
			set { this.active_flag = value; }
		}
		
				/// <summary>
        /// ICloneable 实现克隆本身, 深度克隆
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            BinaryFormatter Formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            MemoryStream stream = new MemoryStream();
            Formatter.Serialize(stream, this);
            stream.Position = 0;
            object clonedObj = Formatter.Deserialize(stream);
            stream.Close();
            return clonedObj; 
        }
	}
}
