//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:59
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
	///数据实体 [表名("DATA0073")]
	/// </summary>
	[Serializable()]
	public class DATA0073 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string user_id = String.Empty;
		private string user_full_name = String.Empty;
		private string user_login_name = String.Empty;
		private byte[] user_password;
		private decimal user_station;
		private decimal user_group_flag;
		private string language_flag = String.Empty;
		private decimal group_ptr;
		private decimal def_printer_ptr;
		private decimal employee_ptr;
		private string network_id = String.Empty;
		private string node_id = String.Empty;
		private decimal session_id;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0073() { } 
		
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
		///属性 [("USER_ID")]
		///数据库类型:char(5)
		///</summary>
		public string USER_ID
		{
			get { return this.user_id; }
			set { this.user_id = value; }
		}
		
		///<summary>
		///属性 [("USER_FULL_NAME")]
		///数据库类型:char(30)
		///</summary>
		public string USER_FULL_NAME
		{
			get { return this.user_full_name; }
			set { this.user_full_name = value; }
		}
		
		///<summary>
		///属性 [("USER_LOGIN_NAME")]
		///数据库类型:char(10)
		///</summary>
		public string USER_LOGIN_NAME
		{
			get { return this.user_login_name; }
			set { this.user_login_name = value; }
		}
		
		///<summary>
		///属性 [("USER_PASSWORD")]
		///数据库类型:binary(12)
		///</summary>
		public byte[] USER_PASSWORD
		{
			get { return this.user_password; }
			set { this.user_password = value; }
		}
		
		///<summary>
		///属性 [("USER_STATION")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal USER_STATION
		{
			get { return this.user_station; }
			set { this.user_station = value; }
		}
		
		///<summary>
		///属性 [("USER_GROUP_FLAG")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal USER_GROUP_FLAG
		{
			get { return this.user_group_flag; }
			set { this.user_group_flag = value; }
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
		///属性 [("GROUP_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal GROUP_PTR
		{
			get { return this.group_ptr; }
			set { this.group_ptr = value; }
		}
		
		///<summary>
		///属性 [("DEF_PRINTER_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal DEF_PRINTER_PTR
		{
			get { return this.def_printer_ptr; }
			set { this.def_printer_ptr = value; }
		}
		
		///<summary>
		///属性 [("EMPLOYEE_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EMPLOYEE_PTR
		{
			get { return this.employee_ptr; }
			set { this.employee_ptr = value; }
		}
		
		///<summary>
		///属性 [("NETWORK_ID")]
		///数据库类型:char(8)
		///</summary>
		public string NETWORK_ID
		{
			get { return this.network_id; }
			set { this.network_id = value; }
		}
		
		///<summary>
		///属性 [("NODE_ID")]
		///数据库类型:char(12)
		///</summary>
		public string NODE_ID
		{
			get { return this.node_id; }
			set { this.node_id = value; }
		}
		
		///<summary>
		///属性 [("SESSION_ID")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal SESSION_ID
		{
			get { return this.session_id; }
			set { this.session_id = value; }
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
