//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:34
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
	///数据实体 [表名("DATA0001")]
	/// </summary>
	[Serializable()]
	public class DATA0001 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string curr_code = String.Empty;
		private string curr_name = String.Empty;
		private decimal exch_rate;
		private DateTime tdate;
		private decimal treadonly;
		private decimal base_to_other;
		private decimal active_flag;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0001() { } 
		
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
		///属性 [("CURR_CODE")]
		///数据库类型:char(5)
		///</summary>
		public string CURR_CODE
		{
			get { return this.curr_code; }
			set { this.curr_code = value; }
		}
		
		///<summary>
		///属性 [("CURR_NAME")]
		///数据库类型:char(20)
		///</summary>
		public string CURR_NAME
		{
			get { return this.curr_name; }
			set { this.curr_name = value; }
		}
		
		///<summary>
		///属性 [("EXCH_RATE")]
		///数据库类型:numeric(20, 8)
		///</summary>
		public decimal EXCH_RATE
		{
			get { return this.exch_rate; }
			set { this.exch_rate = value; }
		}
		
		///<summary>
		///属性 [("TDATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime TDATE
		{
			get { return this.tdate; }
			set { this.tdate = value; }
		}
		
		///<summary>
		///属性 [("TREADONLY")]
		///数据库类型:numeric(1, 0)
		///</summary>
		public decimal TREADONLY
		{
			get { return this.treadonly; }
			set { this.treadonly = value; }
		}
		
		///<summary>
		///属性 [("BASE_TO_OTHER")]
		///数据库类型:numeric(20, 8)
		///</summary>
		public decimal BASE_TO_OTHER
		{
			get { return this.base_to_other; }
			set { this.base_to_other = value; }
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
