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
	///数据实体 [表名("FOUNDERPCB_OPERATION_LOG")]
	/// </summary>
	[Serializable()]
	public class FOUNDERPCB_OPERATION_LOG : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private decimal pro_rkey;
		private string module_id = String.Empty;
		private string module_name = String.Empty;
		private string action = String.Empty;
		private string memo = String.Empty;
		private DateTime do_date;
		
		///<summary>
		///  构造方法
		///</summary>
		public FOUNDERPCB_OPERATION_LOG() { } 
		
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
		///属性 [("MODULE_ID")]
		///数据库类型:varchar(10)
		///</summary>
		public string MODULE_ID
		{
			get { return this.module_id; }
			set { this.module_id = value; }
		}
		
		///<summary>
		///属性 [("MODULE_NAME")]
		///数据库类型:varchar(30)
		///</summary>
		public string MODULE_NAME
		{
			get { return this.module_name; }
			set { this.module_name = value; }
		}
		
		///<summary>
		///属性 [("ACTION")]
		///数据库类型:varchar(30)
		///</summary>
		public string ACTION
		{
			get { return this.action; }
			set { this.action = value; }
		}
		
		///<summary>
		///属性 [("MEMO")]
		///数据库类型:varchar(1000)
		///</summary>
		public string MEMO
		{
			get { return this.memo; }
			set { this.memo = value; }
		}
		
		///<summary>
		///属性 [("DO_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime DO_DATE
		{
			get { return this.do_date; }
			set { this.do_date = value; }
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
