using System;
namespace KB.Models
{
	/// <summary>
	/// 实体类Approval_Mode_1Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Approval_Mode_1Info
	{
		public Approval_Mode_1Info()
		{}
		#region Model
		private int _rkey;
		private int? _file_pointer;
		private int? _source_type;
		private int? _from_step_no;
		private int? _to_step_no;
		private int? _trans_type;
		private string _trans_description;
		private int? _user_ptr;
		private DateTime? _trans_date_time;
		/// <summary>
		/// 通用审批表1
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
		/// <summary>
		/// 业务模块表指针
		/// </summary>
		public int? FILE_POINTER
		{
			set{ _file_pointer=value;}
			get{return _file_pointer;}
		}
		/// <summary>
		/// 类别：1供应商引入申请，2现场审核报告，3物料试用申请，4样品试用报告审批，5小批量试用报告，6合格供应商申请,7SCAR提出阶段，8SCAR采购处理阶段，9索赔提出阶段，10索赔采购处理阶段
		/// </summary>
		public int? SOURCE_TYPE
		{
			set{ _source_type=value;}
			get{return _source_type;}
		}
		/// <summary>
		/// 从第几步
		/// </summary>
		public int? FROM_STEP_NO
		{
			set{ _from_step_no=value;}
			get{return _from_step_no;}
		}
		/// <summary>
		/// 到第几步
		/// </summary>
		public int? TO_STEP_NO
		{
			set{ _to_step_no=value;}
			get{return _to_step_no;}
		}
		/// <summary>
		/// 1生成；2发送审批；3没发送审批；4审批流程改变；5重新发启；6已审批7拒绝
		/// </summary>
		public int? TRANS_TYPE
		{
			set{ _trans_type=value;}
			get{return _trans_type;}
		}
		/// <summary>
		/// 审批描述
		/// </summary>
		public string TRANS_DESCRIPTION
		{
			set{ _trans_description=value;}
			get{return _trans_description;}
		}
		/// <summary>
		/// 操作人73表指针
		/// </summary>
		public int? USER_PTR
		{
			set{ _user_ptr=value;}
			get{return _user_ptr;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? TRANS_DATE_TIME
		{
			set{ _trans_date_time=value;}
			get{return _trans_date_time;}
		}
		#endregion Model

	}
}

