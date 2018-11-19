//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:36
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
	///数据实体 [表名("DATA0006")]
	/// </summary>
	[Serializable()]
	public class DATA0006 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private string work_order_number = String.Empty;
		private decimal inventory_ptr;
		private decimal cust_part_ptr;
		private decimal root_ptr;
		private decimal whouse_ptr;
		private decimal engg_rte_ptr;
		private decimal prod_rte_ptr;
		private decimal csi_user_ptr;
		private decimal employee_ptr;
		private decimal bom_ptr;
		private decimal sub_levels;
		private string priority_code = String.Empty;
		private decimal engg_status;
		private decimal prod_status;
		private decimal engg_prod_flag;
		private string engg_rte_mod_flag = String.Empty;
		private string prod_rte_mod_flag = String.Empty;
		private string bom_mod_flag = String.Empty;
		private decimal quan_sch;
		private decimal quan_rej;
		private decimal quan_prod;
		private DateTime ent_date;
		private decimal ent_time;
		private DateTime sch_compl_date;
		private DateTime proj_start_date;
		private DateTime proj_compl_date;
		private DateTime cancel_hold_date;
		private DateTime act_compl_date;
		private string cust_part_rev_no = String.Empty;
		private string bom_rev_no = String.Empty;
		private decimal tag_ptr;
		private DateTime dt_ptrav_prn;
		private DateTime dt_etrav_prn;
		private decimal scrap_rate;
		private decimal quan_bal;
		private string base_wo = String.Empty;
		private decimal parent_ptr;
		private decimal rma_ptr;
		private string job_cost_flag = String.Empty;
		private decimal location_ptr;
		private decimal direct_cost;
		private decimal parts_per_panel;
		private decimal production_cost;
		private decimal material_cost;
		private decimal overhead_cost;
		private decimal edited_by;
		private decimal planned_qty;
		private DateTime release_date;
		private decimal trav_printed_by_ptr;
		private decimal lot_number_count;
		private decimal hold_step_no;
		private string hard_link_to_parent = String.Empty;
		private string analysis_code_1 = String.Empty;
		private string analysis_code_2 = String.Empty;
		private string analysis_code_3 = String.Empty;
		private string analysis_code_4 = String.Empty;
		private string analysis_code_5 = String.Empty;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0006() { } 
		
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
		///属性 [("WORK_ORDER_NUMBER")]
		///数据库类型:char(16)
		///</summary>
		public string WORK_ORDER_NUMBER
		{
			get { return this.work_order_number; }
			set { this.work_order_number = value; }
		}
		
		///<summary>
		///属性 [("INVENTORY_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal INVENTORY_PTR
		{
			get { return this.inventory_ptr; }
			set { this.inventory_ptr = value; }
		}
		
		///<summary>
		///属性 [("CUST_PART_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal CUST_PART_PTR
		{
			get { return this.cust_part_ptr; }
			set { this.cust_part_ptr = value; }
		}
		
		///<summary>
		///属性 [("ROOT_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal ROOT_PTR
		{
			get { return this.root_ptr; }
			set { this.root_ptr = value; }
		}
		
		///<summary>
		///属性 [("WHOUSE_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal WHOUSE_PTR
		{
			get { return this.whouse_ptr; }
			set { this.whouse_ptr = value; }
		}
		
		///<summary>
		///属性 [("ENGG_RTE_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal ENGG_RTE_PTR
		{
			get { return this.engg_rte_ptr; }
			set { this.engg_rte_ptr = value; }
		}
		
		///<summary>
		///属性 [("PROD_RTE_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal PROD_RTE_PTR
		{
			get { return this.prod_rte_ptr; }
			set { this.prod_rte_ptr = value; }
		}
		
		///<summary>
		///属性 [("CSI_USER_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal CSI_USER_PTR
		{
			get { return this.csi_user_ptr; }
			set { this.csi_user_ptr = value; }
		}
		
		///<summary>
		///属性 [("EMPLOYEE_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EMPLOYEE_PTR
		{
			get { return this.employee_ptr; }
			set { this.employee_ptr = value; }
		}
		
		///<summary>
		///属性 [("BOM_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal BOM_PTR
		{
			get { return this.bom_ptr; }
			set { this.bom_ptr = value; }
		}
		
		///<summary>
		///属性 [("SUB_LEVELS")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal SUB_LEVELS
		{
			get { return this.sub_levels; }
			set { this.sub_levels = value; }
		}
		
		///<summary>
		///属性 [("PRIORITY_CODE")]
		///数据库类型:char(1)
		///</summary>
		public string PRIORITY_CODE
		{
			get { return this.priority_code; }
			set { this.priority_code = value; }
		}
		
		///<summary>
		///属性 [("ENGG_STATUS")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal ENGG_STATUS
		{
			get { return this.engg_status; }
			set { this.engg_status = value; }
		}
		
		///<summary>
		///属性 [("PROD_STATUS")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal PROD_STATUS
		{
			get { return this.prod_status; }
			set { this.prod_status = value; }
		}
		
		///<summary>
		///属性 [("ENGG_PROD_FLAG")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal ENGG_PROD_FLAG
		{
			get { return this.engg_prod_flag; }
			set { this.engg_prod_flag = value; }
		}
		
		///<summary>
		///属性 [("ENGG_RTE_MOD_FLAG")]
		///数据库类型:char(1)
		///</summary>
		public string ENGG_RTE_MOD_FLAG
		{
			get { return this.engg_rte_mod_flag; }
			set { this.engg_rte_mod_flag = value; }
		}
		
		///<summary>
		///属性 [("PROD_RTE_MOD_FLAG")]
		///数据库类型:char(1)
		///</summary>
		public string PROD_RTE_MOD_FLAG
		{
			get { return this.prod_rte_mod_flag; }
			set { this.prod_rte_mod_flag = value; }
		}
		
		///<summary>
		///属性 [("BOM_MOD_FLAG")]
		///数据库类型:char(1)
		///</summary>
		public string BOM_MOD_FLAG
		{
			get { return this.bom_mod_flag; }
			set { this.bom_mod_flag = value; }
		}
		
		///<summary>
		///属性 [("QUAN_SCH")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal QUAN_SCH
		{
			get { return this.quan_sch; }
			set { this.quan_sch = value; }
		}
		
		///<summary>
		///属性 [("QUAN_REJ")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal QUAN_REJ
		{
			get { return this.quan_rej; }
			set { this.quan_rej = value; }
		}
		
		///<summary>
		///属性 [("QUAN_PROD")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal QUAN_PROD
		{
			get { return this.quan_prod; }
			set { this.quan_prod = value; }
		}
		
		///<summary>
		///属性 [("ENT_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime ENT_DATE
		{
			get { return this.ent_date; }
			set { this.ent_date = value; }
		}
		
		///<summary>
		///属性 [("ENT_TIME")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal ENT_TIME
		{
			get { return this.ent_time; }
			set { this.ent_time = value; }
		}
		
		///<summary>
		///属性 [("SCH_COMPL_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime SCH_COMPL_DATE
		{
			get { return this.sch_compl_date; }
			set { this.sch_compl_date = value; }
		}
		
		///<summary>
		///属性 [("PROJ_START_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime PROJ_START_DATE
		{
			get { return this.proj_start_date; }
			set { this.proj_start_date = value; }
		}
		
		///<summary>
		///属性 [("PROJ_COMPL_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime PROJ_COMPL_DATE
		{
			get { return this.proj_compl_date; }
			set { this.proj_compl_date = value; }
		}
		
		///<summary>
		///属性 [("CANCEL_HOLD_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime CANCEL_HOLD_DATE
		{
			get { return this.cancel_hold_date; }
			set { this.cancel_hold_date = value; }
		}
		
		///<summary>
		///属性 [("ACT_COMPL_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime ACT_COMPL_DATE
		{
			get { return this.act_compl_date; }
			set { this.act_compl_date = value; }
		}
		
		///<summary>
		///属性 [("CUST_PART_REV_NO")]
		///数据库类型:char(5)
		///</summary>
		public string CUST_PART_REV_NO
		{
			get { return this.cust_part_rev_no; }
			set { this.cust_part_rev_no = value; }
		}
		
		///<summary>
		///属性 [("BOM_REV_NO")]
		///数据库类型:char(10)
		///</summary>
		public string BOM_REV_NO
		{
			get { return this.bom_rev_no; }
			set { this.bom_rev_no = value; }
		}
		
		///<summary>
		///属性 [("TAG_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal TAG_PTR
		{
			get { return this.tag_ptr; }
			set { this.tag_ptr = value; }
		}
		
		///<summary>
		///属性 [("DT_PTRAV_PRN")]
		///数据库类型:datetime
		///</summary>
		public DateTime DT_PTRAV_PRN
		{
			get { return this.dt_ptrav_prn; }
			set { this.dt_ptrav_prn = value; }
		}
		
		///<summary>
		///属性 [("DT_ETRAV_PRN")]
		///数据库类型:datetime
		///</summary>
		public DateTime DT_ETRAV_PRN
		{
			get { return this.dt_etrav_prn; }
			set { this.dt_etrav_prn = value; }
		}
		
		///<summary>
		///属性 [("SCRAP_RATE")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal SCRAP_RATE
		{
			get { return this.scrap_rate; }
			set { this.scrap_rate = value; }
		}
		
		///<summary>
		///属性 [("QUAN_BAL")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal QUAN_BAL
		{
			get { return this.quan_bal; }
			set { this.quan_bal = value; }
		}
		
		///<summary>
		///属性 [("BASE_WO")]
		///数据库类型:char(6)
		///</summary>
		public string BASE_WO
		{
			get { return this.base_wo; }
			set { this.base_wo = value; }
		}
		
		///<summary>
		///属性 [("PARENT_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal PARENT_PTR
		{
			get { return this.parent_ptr; }
			set { this.parent_ptr = value; }
		}
		
		///<summary>
		///属性 [("RMA_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal RMA_PTR
		{
			get { return this.rma_ptr; }
			set { this.rma_ptr = value; }
		}
		
		///<summary>
		///属性 [("JOB_COST_FLAG")]
		///数据库类型:char(1)
		///</summary>
		public string JOB_COST_FLAG
		{
			get { return this.job_cost_flag; }
			set { this.job_cost_flag = value; }
		}
		
		///<summary>
		///属性 [("LOCATION_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal LOCATION_PTR
		{
			get { return this.location_ptr; }
			set { this.location_ptr = value; }
		}
		
		///<summary>
		///属性 [("DIRECT_COST")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal DIRECT_COST
		{
			get { return this.direct_cost; }
			set { this.direct_cost = value; }
		}
		
		///<summary>
		///属性 [("PARTS_PER_PANEL")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal PARTS_PER_PANEL
		{
			get { return this.parts_per_panel; }
			set { this.parts_per_panel = value; }
		}
		
		///<summary>
		///属性 [("PRODUCTION_COST")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal PRODUCTION_COST
		{
			get { return this.production_cost; }
			set { this.production_cost = value; }
		}
		
		///<summary>
		///属性 [("MATERIAL_COST")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal MATERIAL_COST
		{
			get { return this.material_cost; }
			set { this.material_cost = value; }
		}
		
		///<summary>
		///属性 [("OVERHEAD_COST")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal OVERHEAD_COST
		{
			get { return this.overhead_cost; }
			set { this.overhead_cost = value; }
		}
		
		///<summary>
		///属性 [("EDITED_BY")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal EDITED_BY
		{
			get { return this.edited_by; }
			set { this.edited_by = value; }
		}
		
		///<summary>
		///属性 [("PLANNED_QTY")]
		///数据库类型:numeric(20, 7)
		///</summary>
		public decimal PLANNED_QTY
		{
			get { return this.planned_qty; }
			set { this.planned_qty = value; }
		}
		
		///<summary>
		///属性 [("RELEASE_DATE")]
		///数据库类型:datetime
		///</summary>
		public DateTime RELEASE_DATE
		{
			get { return this.release_date; }
			set { this.release_date = value; }
		}
		
		///<summary>
		///属性 [("TRAV_PRINTED_BY_PTR")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal TRAV_PRINTED_BY_PTR
		{
			get { return this.trav_printed_by_ptr; }
			set { this.trav_printed_by_ptr = value; }
		}
		
		///<summary>
		///属性 [("LOT_NUMBER_COUNT")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal LOT_NUMBER_COUNT
		{
			get { return this.lot_number_count; }
			set { this.lot_number_count = value; }
		}
		
		///<summary>
		///属性 [("HOLD_STEP_NO")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal HOLD_STEP_NO
		{
			get { return this.hold_step_no; }
			set { this.hold_step_no = value; }
		}
		
		///<summary>
		///属性 [("HARD_LINK_TO_PARENT")]
		///数据库类型:char(1)
		///</summary>
		public string HARD_LINK_TO_PARENT
		{
			get { return this.hard_link_to_parent; }
			set { this.hard_link_to_parent = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE_1")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE_1
		{
			get { return this.analysis_code_1; }
			set { this.analysis_code_1 = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE_2")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE_2
		{
			get { return this.analysis_code_2; }
			set { this.analysis_code_2 = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE_3")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE_3
		{
			get { return this.analysis_code_3; }
			set { this.analysis_code_3 = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE_4")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE_4
		{
			get { return this.analysis_code_4; }
			set { this.analysis_code_4 = value; }
		}
		
		///<summary>
		///属性 [("ANALYSIS_CODE_5")]
		///数据库类型:char(20)
		///</summary>
		public string ANALYSIS_CODE_5
		{
			get { return this.analysis_code_5; }
			set { this.analysis_code_5 = value; }
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
