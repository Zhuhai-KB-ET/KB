//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:35
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
	///数据实体 [表名("DATA0002")]
	/// </summary>
	[Serializable()]
	public class DATA0002 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string unit_code = String.Empty;
		private string unit_name = String.Empty;
		private string prod = String.Empty;
		private string purch = String.Empty;
		private string stock = String.Empty;
		private string quote = String.Empty;
		private string sell = String.Empty;
		private string unit_base = String.Empty;
		private string derived = String.Empty;
		private string int_check = String.Empty;
		private string expression = String.Empty;
		private decimal min_unit_value;
		private decimal max_unit_value;
		private string unit_type = String.Empty;
		private decimal pot_outer_layer;
		private decimal pot_inner_layer;
		private decimal active_flag;
        private string _ecn_flag;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0002() { } 
		
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
		///属性 [("UNIT_CODE")]
		///数据库类型:varchar(5)
		///</summary>
		public string UNIT_CODE
		{
			get { return this.unit_code; }
			set { this.unit_code = value; }
		}
		
		///<summary>
		///属性 [("UNIT_NAME")]
		///数据库类型:varchar(20)
		///</summary>
		public string UNIT_NAME
		{
			get { return this.unit_name; }
			set { this.unit_name = value; }
		}
		
		///<summary>
		///属性 [("PROD")]
		///数据库类型:char(1)
		///</summary>
		public string PROD
		{
			get { return this.prod; }
			set { this.prod = value; }
		}
		
		///<summary>
		///属性 [("PURCH")]
		///数据库类型:char(1)
		///</summary>
		public string PURCH
		{
			get { return this.purch; }
			set { this.purch = value; }
		}
		
		///<summary>
		///属性 [("STOCK")]
		///数据库类型:char(1)
		///</summary>
		public string STOCK
		{
			get { return this.stock; }
			set { this.stock = value; }
		}
		
		///<summary>
		///属性 [("QUOTE")]
		///数据库类型:char(1)
		///</summary>
		public string QUOTE
		{
			get { return this.quote; }
			set { this.quote = value; }
		}
		
		///<summary>
		///属性 [("SELL")]
		///数据库类型:char(1)
		///</summary>
		public string SELL
		{
			get { return this.sell; }
			set { this.sell = value; }
		}
		
		///<summary>
		///属性 [("UNIT_BASE")]
		///数据库类型:char(1)
		///</summary>
		public string UNIT_BASE
		{
			get { return this.unit_base; }
			set { this.unit_base = value; }
		}
		
		///<summary>
		///属性 [("DERIVED")]
		///数据库类型:char(1)
		///</summary>
		public string DERIVED
		{
			get { return this.derived; }
			set { this.derived = value; }
		}
		
		///<summary>
		///属性 [("INT_CHECK")]
		///数据库类型:char(1)
		///</summary>
		public string INT_CHECK
		{
			get { return this.int_check; }
			set { this.int_check = value; }
		}
		
		///<summary>
		///属性 [("EXPRESSION")]
		///数据库类型:varchar(50)
		///</summary>
		public string EXPRESSION
		{
			get { return this.expression; }
			set { this.expression = value; }
		}
		
		///<summary>
		///属性 [("MIN_UNIT_VALUE")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal MIN_UNIT_VALUE
		{
			get { return this.min_unit_value; }
			set { this.min_unit_value = value; }
		}
		
		///<summary>
		///属性 [("MAX_UNIT_VALUE")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal MAX_UNIT_VALUE
		{
			get { return this.max_unit_value; }
			set { this.max_unit_value = value; }
		}
		
		///<summary>
		///属性 [("UNIT_TYPE")]
		///数据库类型:char(1)
		///</summary>
		public string UNIT_TYPE
		{
			get { return this.unit_type; }
			set { this.unit_type = value; }
		}
		
		///<summary>
		///属性 [("POT_OUTER_LAYER")]
		///数据库类型:numeric(1, 0)
		///</summary>
		public decimal POT_OUTER_LAYER
		{
			get { return this.pot_outer_layer; }
			set { this.pot_outer_layer = value; }
		}
		
		///<summary>
		///属性 [("POT_INNER_LAYER")]
		///数据库类型:numeric(1, 0)
		///</summary>
		public decimal POT_INNER_LAYER
		{
			get { return this.pot_inner_layer; }
			set { this.pot_inner_layer = value; }
		}
		
		///<summary>
		///属性 [("ACTIVE_FLAG")]
		///数据库类型:numeric(18, 0)
		///</summary>
		public decimal ACTIVE_FLAG
		{
			get { return this.active_flag; }
			set { this.active_flag = value; }
		}
        /// <summary>
        /// 
        /// </summary>
        public string ECN_FLAG
        {
            set { _ecn_flag = value; }
            get { return _ecn_flag; }
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
