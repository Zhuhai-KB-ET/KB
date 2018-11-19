using System;
namespace KB.Models
{
	/// <summary>
	/// 实体类Approval_Mode_2Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Approval_Mode_2Info
	{
		public Approval_Mode_2Info()
		{}
		#region Model
		private int _rkey;
		private int? _file_pointer;
		private int? _source_type;
		private int? _approval_route_ptr;
		private int? _approval_status;
		private int? _approval_step_no;
		private int? _total_steps;
		/// <summary>
		/// 用审批表2
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
		/// 审批流程库指针
		/// </summary>
		public int? APPROVAL_ROUTE_PTR
		{
			set{ _approval_route_ptr=value;}
			get{return _approval_route_ptr;}
		}
		/// <summary>
		/// 0未发送审批；1审批中；2已经审批；3拒绝
		/// </summary>
		public int? APPROVAL_STATUS
		{
			set{ _approval_status=value;}
			get{return _approval_status;}
		}
		/// <summary>
		/// 当前审批步骤
		/// </summary>
		public int? APPROVAL_STEP_NO
		{
			set{ _approval_step_no=value;}
			get{return _approval_step_no;}
		}
		/// <summary>
		/// 总审批步骤
		/// </summary>
		public int? TOTAL_STEPS
		{
			set{ _total_steps=value;}
			get{return _total_steps;}
		}
		#endregion Model

	}
}

