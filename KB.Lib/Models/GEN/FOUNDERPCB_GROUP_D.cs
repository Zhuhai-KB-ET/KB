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
	///数据实体 [表名("FOUNDERPCB_GROUP_D")]
	/// </summary>
	[Serializable()]
	public class FOUNDERPCB_GROUP_D : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private decimal pro_rkey;
		private int sort;
		private string srce_ptr = String.Empty;
		private string permission = String.Empty;
		
		///<summary>
		///  构造方法
		///</summary>
		public FOUNDERPCB_GROUP_D() { } 
		
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
		///属性 [("SORT")]
		///数据库类型:int
		///</summary>
		public int SORT
		{
			get { return this.sort; }
			set { this.sort = value; }
		}
		
		///<summary>
		///属性 [("SRCE_PTR")]
		///数据库类型:varchar(20)
		///</summary>
		public string SRCE_PTR
		{
			get { return this.srce_ptr; }
			set { this.srce_ptr = value; }
		}
		
		///<summary>
		///属性 [("PERMISSION")]
		///数据库类型:varchar(6)
		///</summary>
		public string PERMISSION
		{
			get { return this.permission; }
			set { this.permission = value; }
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
