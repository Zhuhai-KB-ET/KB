using System;
namespace KB.Models
{
	/// <summary>
	/// 实体类RPT_SETPARM 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class RPT_SETPARM
	{
		public RPT_SETPARM()
		{}
		#region Model
		private int _rkey;
		private int? _server_ptr;
		private int? _modul_ptr;
		private string _ttype;
		private string _report_path;
		private string _report_name;
		private string _display_name;
		private string _report_code;
		private string _report_parm;
		private int? _quick_print;
		private int _choose_paye;
		private int _margins_top;
		private int _margins_buttom;
		private int _margins_left;
		private int _margins_right;
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
		public int? SERVER_PTR
		{
			set{ _server_ptr=value;}
			get{return _server_ptr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MODUL_PTR
		{
			set{ _modul_ptr=value;}
			get{return _modul_ptr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TTYPE
		{
			set{ _ttype=value;}
			get{return _ttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPORT_PATH
		{
			set{ _report_path=value;}
			get{return _report_path;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPORT_NAME
		{
			set{ _report_name=value;}
			get{return _report_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DISPLAY_NAME
		{
			set{ _display_name=value;}
			get{return _display_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPORT_CODE
		{
			set{ _report_code=value;}
			get{return _report_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPORT_PARM
		{
			set{ _report_parm=value;}
			get{return _report_parm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? QUICK_PRINT
		{
			set{ _quick_print=value;}
			get{return _quick_print;}
		}
		/// <summary>
		/// 0默认，1用户自选纸张
		/// </summary>
		public int CHOOSE_PAYE
		{
			set{ _choose_paye=value;}
			get{return _choose_paye;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MARGINS_TOP
		{
			set{ _margins_top=value;}
			get{return _margins_top;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MARGINS_BUTTOM
		{
			set{ _margins_buttom=value;}
			get{return _margins_buttom;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MARGINS_LEFT
		{
			set{ _margins_left=value;}
			get{return _margins_left;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MARGINS_RIGHT
		{
			set{ _margins_right=value;}
			get{return _margins_right;}
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

