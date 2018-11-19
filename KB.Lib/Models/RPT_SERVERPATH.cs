using System;
namespace KB.Models
{
	/// <summary>
	/// 实体类RPT_SERVERPATH 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class RPT_SERVERPATH
	{
		public RPT_SERVERPATH()
		{}
		#region Model
		private int _rkey;
		private string _server_path;
		private string _floder_path;
		private int _ttype;
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
		public string SERVER_PATH
		{
			set{ _server_path=value;}
			get{return _server_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FLODER_PATH
		{
			set{ _floder_path=value;}
			get{return _floder_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TTYPE
		{
			set{ _ttype=value;}
			get{return _ttype;}
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

