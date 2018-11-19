using System;
namespace KB.Model
{
	/// <summary>
	/// 实体类FOUNDERPCB_ANALYSIS 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class FOUNDERPCB_ANALYSIS
	{
		public FOUNDERPCB_ANALYSIS()
		{}
		#region Model
		private int _rkey;
		private string _source_code;
		private int? _id_key;
		private string _ans_name;
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
		public string SOURCE_CODE
		{
			set{ _source_code=value;}
			get{return _source_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ID_KEY
		{
			set{ _id_key=value;}
			get{return _id_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ANS_NAME
		{
			set{ _ans_name=value;}
			get{return _ans_name;}
		}
		#endregion Model

	}
}

