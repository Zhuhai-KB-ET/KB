//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:05:04
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
	///数据实体 [表名("FOUNDERPCB_FRIGHTE_03")]
	/// </summary>
	[Serializable()]
	public class FOUNDERPCB_FRIGHTE_03 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private decimal pro2_rkey;
		private int sort;
		private string field_english = String.Empty;
		private string field_name = String.Empty;
		private string field_desc = String.Empty;
		
		///<summary>
		///  构造方法
		///</summary>
		public FOUNDERPCB_FRIGHTE_03() { } 
		
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
		///属性 [("PRO2_RKEY")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal PRO2_RKEY
		{
			get { return this.pro2_rkey; }
			set { this.pro2_rkey = value; }
		}
		
		///<summary>
		///属性 [("SORT")]
		///数据库类型:int
		///</summary>
		public int SORT
		{
			get { return this.sort; }
			set { this.sort = value; }
		}
		
		///<summary>
		///属性 [("FIELD_ENGLISH")]
		///数据库类型:varchar(50)
		///</summary>
		public string FIELD_ENGLISH
		{
			get { return this.field_english; }
			set { this.field_english = value; }
		}
		
		///<summary>
		///属性 [("FIELD_NAME")]
		///数据库类型:varchar(50)
		///</summary>
		public string FIELD_NAME
		{
			get { return this.field_name; }
			set { this.field_name = value; }
		}
		
		///<summary>
		///属性 [("FIELD_DESC")]
		///数据库类型:varchar(100)
		///</summary>
		public string FIELD_DESC
		{
			get { return this.field_desc; }
			set { this.field_desc = value; }
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
