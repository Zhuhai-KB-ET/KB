//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:05
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
	///数据实体 [表名("FOUNDERPCB_LOGIN_LOG")]
	/// </summary>
	[Serializable()]
	public class FOUNDERPCB_LOGIN_LOG : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private decimal pro_rkey;
		private string login_id = String.Empty;
		private string login_name = String.Empty;
		private string login_ip = String.Empty;
		private DateTime login_date;
		private DateTime login_out;
		
		///<summary>
		///  构造方法
		///</summary>
		public FOUNDERPCB_LOGIN_LOG() { } 
		
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
		///属性 [("PRO_RKEY")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal PRO_RKEY
		{
			get { return this.pro_rkey; }
			set { this.pro_rkey = value; }
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
		///属性 [("LOGIN_NAME")]
		///数据库类型:varchar(20)
		///</summary>
		public string LOGIN_NAME
		{
			get { return this.login_name; }
			set { this.login_name = value; }
		}
		
		///<summary>
		///属性 [("LOGIN_IP")]
		///数据库类型:varchar(20)
		///</summary>
		public string LOGIN_IP
		{
			get { return this.login_ip; }
			set { this.login_ip = value; }
		}
		
		///<summary>
		///属性 [("LOGIN_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime LOGIN_DATE
		{
			get { return this.login_date; }
			set { this.login_date = value; }
		}
		
		///<summary>
		///属性 [("LOGIN_OUT")]
		///数据库类型:datetime
		///</summary>
		public DateTime LOGIN_OUT
		{
			get { return this.login_out; }
			set { this.login_out = value; }
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
