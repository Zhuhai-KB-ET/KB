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
	///数据实体 [表名("FOUNDERPCB_GROUP_M")]
	/// </summary>
	[Serializable()]
	public class FOUNDERPCB_GROUP_M : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string group_id = String.Empty;
		private string group_name = String.Empty;
		
		///<summary>
		///  构造方法
		///</summary>
		public FOUNDERPCB_GROUP_M() { } 
		
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
		///属性 [("GROUP_ID")]
		///数据库类型:varchar(10)
		///</summary>
		public string GROUP_ID
		{
			get { return this.group_id; }
			set { this.group_id = value; }
		}
		
		///<summary>
		///属性 [("GROUP_NAME")]
		///数据库类型:varchar(30)
		///</summary>
		public string GROUP_NAME
		{
			get { return this.group_name; }
			set { this.group_name = value; }
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
