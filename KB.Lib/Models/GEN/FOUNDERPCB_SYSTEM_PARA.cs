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
	///数据实体 [表名("FOUNDERPCB_SYSTEM_PARA")]
	/// </summary>
	[Serializable()]
	public class FOUNDERPCB_SYSTEM_PARA : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private int para_id;
		private string description = String.Empty;
		private string parameter_values = String.Empty;
		private DateTime create_date;
		
		///<summary>
		///  构造方法
		///</summary>
		public FOUNDERPCB_SYSTEM_PARA() { } 
		
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
		///属性 [("PARA_ID")]
		///数据库类型:int
		///</summary>
		public int PARA_ID
		{
			get { return this.para_id; }
			set { this.para_id = value; }
		}
		
		///<summary>
		///属性 [("DESCRIPTION")]
		///数据库类型:varchar(30)
		///</summary>
		public string DESCRIPTION
		{
			get { return this.description; }
			set { this.description = value; }
		}
		
		///<summary>
		///属性 [("PARAMETER_VALUES")]
		///数据库类型:varchar(200)
		///</summary>
		public string PARAMETER_VALUES
		{
			get { return this.parameter_values; }
			set { this.parameter_values = value; }
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
