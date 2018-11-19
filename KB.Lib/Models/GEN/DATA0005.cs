//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:36
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
	///数据实体 [表名("DATA0005")]
	/// </summary>
	[Serializable()]
	public class DATA0005 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string empl_code = String.Empty;
		private string employee_name = String.Empty;
		private string abbr_name = String.Empty;
		private string employee_id = String.Empty;
		private string address_line_1 = String.Empty;
		private string address_line_2 = String.Empty;
		private string address_line_3 = String.Empty;
		private string state = String.Empty;
		private string zip = String.Empty;
		private string phone = String.Empty;
		private decimal note_pad_pointer;
		private decimal pay_rate_1;
		private decimal pay_rate_2;
		private decimal pay_rate_3;
		private decimal start_time_1;
		private decimal start_time_2;
		private decimal start_time_3;
		private string active_flag = String.Empty;
		private string buyer_flag = String.Empty;
		private DateTime inactive_date;
		private string tpostion = String.Empty;
		private string email = String.Empty;
		private byte[] empl_password;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0005() { } 
		
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
		///属性 [("EMPL_CODE")]
		///数据库类型:char(5)
		///</summary>
		public string EMPL_CODE
		{
			get { return this.empl_code; }
			set { this.empl_code = value; }
		}
		
		///<summary>
		///属性 [("EMPLOYEE_NAME")]
		///数据库类型:char(30)
		///</summary>
		public string EMPLOYEE_NAME
		{
			get { return this.employee_name; }
			set { this.employee_name = value; }
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
		///属性 [("EMPLOYEE_ID")]
		///数据库类型:char(15)
		///</summary>
		public string EMPLOYEE_ID
		{
			get { return this.employee_id; }
			set { this.employee_id = value; }
		}
		
		///<summary>
		///属性 [("ADDRESS_LINE_1")]
		///数据库类型:char(30)
		///</summary>
		public string ADDRESS_LINE_1
		{
			get { return this.address_line_1; }
			set { this.address_line_1 = value; }
		}
		
		///<summary>
		///属性 [("ADDRESS_LINE_2")]
		///数据库类型:char(30)
		///</summary>
		public string ADDRESS_LINE_2
		{
			get { return this.address_line_2; }
			set { this.address_line_2 = value; }
		}
		
		///<summary>
		///属性 [("ADDRESS_LINE_3")]
		///数据库类型:char(30)
		///</summary>
		public string ADDRESS_LINE_3
		{
			get { return this.address_line_3; }
			set { this.address_line_3 = value; }
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
		///属性 [("NOTE_PAD_POINTER")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal NOTE_PAD_POINTER
		{
			get { return this.note_pad_pointer; }
			set { this.note_pad_pointer = value; }
		}
		
		///<summary>
		///属性 [("PAY_RATE_1")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal PAY_RATE_1
		{
			get { return this.pay_rate_1; }
			set { this.pay_rate_1 = value; }
		}
		
		///<summary>
		///属性 [("PAY_RATE_2")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal PAY_RATE_2
		{
			get { return this.pay_rate_2; }
			set { this.pay_rate_2 = value; }
		}
		
		///<summary>
		///属性 [("PAY_RATE_3")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal PAY_RATE_3
		{
			get { return this.pay_rate_3; }
			set { this.pay_rate_3 = value; }
		}
		
		///<summary>
		///属性 [("START_TIME_1")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal START_TIME_1
		{
			get { return this.start_time_1; }
			set { this.start_time_1 = value; }
		}
		
		///<summary>
		///属性 [("START_TIME_2")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal START_TIME_2
		{
			get { return this.start_time_2; }
			set { this.start_time_2 = value; }
		}
		
		///<summary>
		///属性 [("START_TIME_3")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal START_TIME_3
		{
			get { return this.start_time_3; }
			set { this.start_time_3 = value; }
		}
		
		///<summary>
		///属性 [("ACTIVE_FLAG")]
		///数据库类型:char(1)
		///</summary>
		public string ACTIVE_FLAG
		{
			get { return this.active_flag; }
			set { this.active_flag = value; }
		}
		
		///<summary>
		///属性 [("BUYER_FLAG")]
		///数据库类型:char(1)
		///</summary>
		public string BUYER_FLAG
		{
			get { return this.buyer_flag; }
			set { this.buyer_flag = value; }
		}
		
		///<summary>
		///属性 [("INACTIVE_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime INACTIVE_DATE
		{
			get { return this.inactive_date; }
			set { this.inactive_date = value; }
		}
		
		///<summary>
		///属性 [("TPOSTION")]
		///数据库类型:char(40)
		///</summary>
		public string TPOSTION
		{
			get { return this.tpostion; }
			set { this.tpostion = value; }
		}
		
		///<summary>
		///属性 [("EMAIL")]
		///数据库类型:char(40)
		///</summary>
		public string EMAIL
		{
			get { return this.email; }
			set { this.email = value; }
		}
		
		///<summary>
		///属性 [("EMPL_PASSWORD")]
		///数据库类型:binary(12)
		///</summary>
		public byte[] EMPL_PASSWORD
		{
			get { return this.empl_password; }
			set { this.empl_password = value; }
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
