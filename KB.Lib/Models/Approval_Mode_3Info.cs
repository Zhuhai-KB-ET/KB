using System;
namespace KB.Models
{
	/// <summary>
	/// 实体类Approval_Mode_3Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Approval_Mode_3Info
	{
		public Approval_Mode_3Info()
		{}
		#region Model
		private int _rkey;
		private int? _file_pointer;
		private int? _source_type;
		private int? _approval_step_no;
		private string _approval_step_desc;
		/// <summary>
		/// 通用审批表3
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
		/// 审批步骤
		/// </summary>
		public int? APPROVAL_STEP_NO
		{
			set{ _approval_step_no=value;}
			get{return _approval_step_no;}
		}
		/// <summary>
		/// 审批步骤说明
		/// </summary>
		public string APPROVAL_STEP_DESC
		{
			set{ _approval_step_desc=value;}
			get{return _approval_step_desc;}
		}
		#endregion Model

	}
}

