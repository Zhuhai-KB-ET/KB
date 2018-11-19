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
	///数据实体 [表名("DATA0011")]
	/// </summary>
	[Serializable()]
	public class DATA0011 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private decimal file_pointer;
		private decimal source_type;
		private string note_pad_line_1 = String.Empty;
		private string note_pad_line_2 = String.Empty;
		private string note_pad_line_3 = String.Empty;
		private string note_pad_line_4 = String.Empty;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0011() { } 
		
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
		///属性 [("FILE_POINTER")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal FILE_POINTER
		{
			get { return this.file_pointer; }
			set { this.file_pointer = value; }
		}
		
		///<summary>
		///属性 [("SOURCE_TYPE")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal SOURCE_TYPE
		{
			get { return this.source_type; }
			set { this.source_type = value; }
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
