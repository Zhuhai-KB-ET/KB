//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:04:21
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
	///数据实体 [表名("DATA0499")]
	/// </summary>
	[Serializable()]
	public class DATA0499 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private decimal approval_route_step_ptr;
		private decimal user_ptr;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0499() { } 
		
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
		///属性 [("APPROVAL_ROUTE_STEP_PTR")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal APPROVAL_ROUTE_STEP_PTR
		{
			get { return this.approval_route_step_ptr; }
			set { this.approval_route_step_ptr = value; }
		}
		
		///<summary>
		///属性 [("USER_PTR")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal USER_PTR
		{
			get { return this.user_ptr; }
			set { this.user_ptr = value; }
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
