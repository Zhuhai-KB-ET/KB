//============================================================
// 项目名称:	    格力凯邦   ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2018,格力凯邦 All Rights Reserved 版权所有
// 编写日期: 	2018/11/20 16:04:20
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
	///数据实体 [表名("DATA0497")]
	/// </summary>
	[Serializable()]
	public class DATA0497 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string approval_route_code = String.Empty;
		private string approval_route_desc = String.Empty;
		private string abbr_name = String.Empty;
		private decimal approval_type;
		private decimal active_flag;
		private decimal from_value;
		private decimal to_value;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0497() { } 
		
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
		///属性 [("APPROVAL_ROUTE_CODE")]
		///数据库类型:char(10)
		///</summary>
		public string APPROVAL_ROUTE_CODE
		{
			get { return this.approval_route_code; }
			set { this.approval_route_code = value; }
		}
		
		///<summary>
		///属性 [("APPROVAL_ROUTE_DESC")]
		///数据库类型:char(30)
		///</summary>
		public string APPROVAL_ROUTE_DESC
		{
			get { return this.approval_route_desc; }
			set { this.approval_route_desc = value; }
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
		///属性 [("APPROVAL_TYPE")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal APPROVAL_TYPE
		{
			get { return this.approval_type; }
			set { this.approval_type = value; }
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
		
		///<summary>
		///属性 [("FROM_VALUE")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal FROM_VALUE
		{
			get { return this.from_value; }
			set { this.from_value = value; }
		}
		
		///<summary>
		///属性 [("TO_VALUE")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal TO_VALUE
		{
			get { return this.to_value; }
			set { this.to_value = value; }
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
