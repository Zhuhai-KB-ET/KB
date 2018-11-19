using System;
namespace KB.Models
{
	/// <summary>
	/// 实体类Approval_Mode_NoteInfo 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Approval_Mode_NoteInfo
	{
		public Approval_Mode_NoteInfo()
		{}
		#region Model
		private int _rkey;
		private int? _file_pointer;
		private int? _source_type;
		private string _notes;
		/// <summary>
		/// 
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
		/// <summary>
		/// 外键指针
		/// </summary>
		public int? FILE_POINTER
		{
			set{ _file_pointer=value;}
			get{return _file_pointer;}
		}
		/// <summary>
		/// 类型：1：Approval_Mode_1
		/// </summary>
		public int? SOURCE_TYPE
		{
			set{ _source_type=value;}
			get{return _source_type;}
		}
		/// <summary>
		/// 记事本
		/// </summary>
		public string NOTES
		{
			set{ _notes=value;}
			get{return _notes;}
		}
		#endregion Model

	}
}

