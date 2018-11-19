//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:06
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
	///数据实体 [表名("FOUNDERPCB_USER")]
	/// </summary>
	[Serializable()]
	public class FOUNDERPCB_USER : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string login_id = String.Empty;
		private decimal pro_rkey;
		private string name = String.Empty;
		private string dept = String.Empty;
		private string position = String.Empty;
		private string tel_number = String.Empty;
		private string mobile = String.Empty;
		private string addr = String.Empty;
		private decimal data0073rkey;
		private int role;
		private string sys_version = String.Empty;
		private DateTime create_date;
		
		///<summary>
		///  构造方法
		///</summary>
		public FOUNDERPCB_USER() { } 
		
		///<summary>
		///主键 [字段("RKEY")]
		///数据库类型:numeric(18, 0)
		///</summary> 
		public decimal RKEY
		{
			get { return this.rkey; }
			set { this.rkey = value; }
		} 
		
		
		
		///<summary>
		///属性 [("LOGIN_ID")]
		///数据库类型:varchar(30)
		///</summary>
		public string LOGIN_ID
		{
			get { return this.login_id; }
			set { this.login_id = value; }
		}
		
		///<summary>
		///属性 [("PRO_RKEY")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal PRO_RKEY
		{
			get { return this.pro_rkey; }
			set { this.pro_rkey = value; }
		}
		
		///<summary>
		///属性 [("NAME")]
		///数据库类型:varchar(20)
		///</summary>
		public string NAME
		{
			get { return this.name; }
			set { this.name = value; }
		}
		
		///<summary>
		///属性 [("DEPT")]
		///数据库类型:varchar(100)
		///</summary>
		public string DEPT
		{
			get { return this.dept; }
			set { this.dept = value; }
		}
		
		///<summary>
		///属性 [("POSITION")]
		///数据库类型:varchar(30)
		///</summary>
		public string POSITION
		{
			get { return this.position; }
			set { this.position = value; }
		}
		
		///<summary>
		///属性 [("TEL_NUMBER")]
		///数据库类型:varchar(30)
		///</summary>
		public string TEL_NUMBER
		{
			get { return this.tel_number; }
			set { this.tel_number = value; }
		}
		
		///<summary>
		///属性 [("MOBILE")]
		///数据库类型:varchar(30)
		///</summary>
		public string MOBILE
		{
			get { return this.mobile; }
			set { this.mobile = value; }
		}
		
		///<summary>
		///属性 [("ADDR")]
		///数据库类型:varchar(200)
		///</summary>
		public string ADDR
		{
			get { return this.addr; }
			set { this.addr = value; }
		}
		
		///<summary>
		///属性 [("DATA0073RKEY")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal DATA0073RKEY
		{
			get { return this.data0073rkey; }
			set { this.data0073rkey = value; }
		}
		
		///<summary>
		///属性 [("ROLE")]
		///数据库类型:int
		///</summary>
		public int ROLE
		{
			get { return this.role; }
			set { this.role = value; }
		}
		
		///<summary>
		///属性 [("SYS_VERSION")]
		///数据库类型:varchar(20)
		///</summary>
		public string SYS_VERSION
		{
			get { return this.sys_version; }
			set { this.sys_version = value; }
		}
		
		///<summary>
		///属性 [("CREATE_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime CREATE_DATE
		{
			get { return this.create_date; }
			set { this.create_date = value; }
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
