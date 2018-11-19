using System;
namespace KB.Models
{
	/// <summary>
	/// 实体类Approval_Mode_4Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Approval_Mode_4Info
	{
		public Approval_Mode_4Info()
		{}
		#region Model
		private int _rkey;
		private int? _route_step_ptr;
		private int? _user_ptr;
		/// <summary>
		/// 通用审批表4
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
		/// <summary>
		/// 通用审批表3指针
		/// </summary>
		public int? ROUTE_STEP_PTR
		{
			set{ _route_step_ptr=value;}
			get{return _route_step_ptr;}
		}
		/// <summary>
		/// data0073表指针
		/// </summary>
		public int? USER_PTR
		{
			set{ _user_ptr=value;}
			get{return _user_ptr;}
		}
		#endregion Model

	}
}

