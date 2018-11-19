using System;
namespace KB.Models
{
	/// <summary>
	/// 实体类RPT_MODUL 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class RPT_MODUL
	{
		public RPT_MODUL()
		{}
		#region Model
		private int _rkey;
		private string _modul_name;
		private int _active_flag;
		private int _emp_ptr;
		/// <summary>
		/// 
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MODUL_NAME
		{
			set{ _modul_name=value;}
			get{return _modul_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ACTIVE_FLAG
		{
			set{ _active_flag=value;}
			get{return _active_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int EMP_PTR
		{
			set{ _emp_ptr=value;}
			get{return _emp_ptr;}
		}
		#endregion Model

	}
}

