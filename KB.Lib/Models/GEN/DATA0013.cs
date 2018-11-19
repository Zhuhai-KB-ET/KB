//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:38
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
	///数据实体 [表名("DATA0013")]
	/// </summary>
	[Serializable()]
	public class DATA0013 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string np_code = String.Empty;
		private string note_pad_line_1 = String.Empty;
		private string note_pad_line_2 = String.Empty;
		private string note_pad_line_3 = String.Empty;
		private string note_pad_line_4 = String.Empty;
		private decimal active_flag;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0013() { } 
		
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
		///属性 [("NP_CODE")]
		///数据库类型:char(5)
		///</summary>
		public string NP_CODE
		{
			get { return this.np_code; }
			set { this.np_code = value; }
		}
		
		///<summary>
		///属性 [("NOTE_PAD_LINE_1")]
		///数据库类型:char(70)
		///</summary>
		public string NOTE_PAD_LINE_1
		{
			get { return this.note_pad_line_1; }
			set { this.note_pad_line_1 = value; }
		}
		
		///<summary>
		///属性 [("NOTE_PAD_LINE_2")]
		///数据库类型:char(70)
		///</summary>
		public string NOTE_PAD_LINE_2
		{
			get { return this.note_pad_line_2; }
			set { this.note_pad_line_2 = value; }
		}
		
		///<summary>
		///属性 [("NOTE_PAD_LINE_3")]
		///数据库类型:char(70)
		///</summary>
		public string NOTE_PAD_LINE_3
		{
			get { return this.note_pad_line_3; }
			set { this.note_pad_line_3 = value; }
		}
		
		///<summary>
		///属性 [("NOTE_PAD_LINE_4")]
		///数据库类型:char(70)
		///</summary>
		public string NOTE_PAD_LINE_4
		{
			get { return this.note_pad_line_4; }
			set { this.note_pad_line_4 = value; }
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
