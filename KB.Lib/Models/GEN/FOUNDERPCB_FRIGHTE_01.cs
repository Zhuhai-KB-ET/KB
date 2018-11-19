//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:03
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
	///数据实体 [表名("FOUNDERPCB_FRIGHTE_01")]
	/// </summary>
	[Serializable()]
	public class FOUNDERPCB_FRIGHTE_01 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string up_module_id = String.Empty;
		private string module_id = String.Empty;
		private string module_english = String.Empty;
		private string module_name = String.Empty;
		private string module_desc = String.Empty;
		
		///<summary>
		///  构造方法
		///</summary>
		public FOUNDERPCB_FRIGHTE_01() { } 
		
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
		///属性 [("UP_MODULE_ID")]
		///数据库类型:varchar(50)
		///</summary>
		public string UP_MODULE_ID
		{
			get { return this.up_module_id; }
			set { this.up_module_id = value; }
		}
		
		///<summary>
		///属性 [("MODULE_ID")]
		///数据库类型:varchar(50)
		///</summary>
		public string MODULE_ID
		{
			get { return this.module_id; }
			set { this.module_id = value; }
		}
		
		///<summary>
		///属性 [("MODULE_ENGLISH")]
		///数据库类型:varchar(50)
		///</summary>
		public string MODULE_ENGLISH
		{
			get { return this.module_english; }
			set { this.module_english = value; }
		}
		
		///<summary>
		///属性 [("MODULE_NAME")]
		///数据库类型:varchar(50)
		///</summary>
		public string MODULE_NAME
		{
			get { return this.module_name; }
			set { this.module_name = value; }
		}
		
		///<summary>
		///属性 [("MODULE_DESC")]
		///数据库类型:varchar(100)
		///</summary>
		public string MODULE_DESC
		{
			get { return this.module_desc; }
			set { this.module_desc = value; }
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
