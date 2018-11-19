using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using KB.BLL;
using KB.DAL;
using KB.Models;

namespace KB.FUNC
{
    /// <summary> 
    /// 创建菜单
    /// 说明：
    /// 各模块窗口的AccessibleName设定为initmenu中定义的ID，如SYS00000
    /// 窗口中的控件中的AccessibleName设定为操作功能控件名，用英文
    /// </summary>
    public class SysMenu
    {
        #region 初始化 InitMenu
        /// <summary>
        /// 初始化
        /// </summary> 
        private static DataTable isFrom_tb;
        public static void InitMenu()
        {
            try
            {

                #region 制作表头

                isFrom_tb = new DataTable();
                isFrom_tb.Columns.Add("窗口类名");
                isFrom_tb.Columns.Add("窗口名称");
                isFrom_tb.Columns.Add("图片索引");
                isFrom_tb.Columns.Add("是否可运行窗口");
                isFrom_tb.Columns.Add("窗口描述");
                isFrom_tb.Columns.Add("模块ID"); //格式：SYS + (1/0)[是否可运行] + 00[层别] + ' ' + 00 + ' ' + 00 + ' ' + 00
                isFrom_tb.Columns.Add("上层模块ID");
                isFrom_tb.Columns.Add("连接池");

                #endregion

                #region 将菜单配置信息保存到数据库
                DBHelper db = new DBHelper();
                Boolean isExistsTableExt = false;
                try
                {
                    var tb_IsExists = db.GetDataSet("select * from sys.objects where name  = 'FOUNDERPCB_MENU_EXT'");
                    if (tb_IsExists.Rows.Count == 0)//不存在菜单的配置信息
                    {
                        #region 添加内容

                        DataRow dr;

                        #region 0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "基础资料";
                        dr["窗口描述"] = "基础资料";
                        dr["图片索引"] = "65";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 00";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "物控";
                        dr["窗口描述"] = "物控";
                        dr["图片索引"] = "69";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 01";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "生产";
                        dr["窗口描述"] = "生产";
                        dr["图片索引"] = "68";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 02";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "品质";
                        dr["窗口描述"] = "品质";
                        dr["图片索引"] = "66";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 03";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "工程";
                        dr["窗口描述"] = "工程";
                        dr["图片索引"] = "64";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 04";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "设备模块";
                        dr["窗口描述"] = "设备模块";
                        dr["图片索引"] = "67";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 05";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);


                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "财务";
                        dr["窗口描述"] = "财务";
                        dr["图片索引"] = "70";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 07";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "报表";
                        dr["窗口描述"] = "报表";
                        dr["图片索引"] = "70";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 09";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "系统管理";
                        dr["窗口描述"] = "系统管理";
                        dr["图片索引"] = "70";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 06";
                        dr["上层模块ID"] = "";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 基础资料

                        #region 0-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "全局系统数据";
                        dr["窗口描述"] = "全局系统数据";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 00 01";
                        dr["上层模块ID"] = "SYS0 00";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "物控模块数据";
                        dr["窗口描述"] = "物控模块数据";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 00 02";
                        dr["上层模块ID"] = "SYS0 00";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "生产模块数据";
                        dr["窗口描述"] = "生产模块数据";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 00 03";
                        dr["上层模块ID"] = "SYS0 00";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "品质模块数据";
                        dr["窗口描述"] = "品质模块数据";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 00 04";
                        dr["上层模块ID"] = "SYS0 00";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "工程模块数据";
                        dr["窗口描述"] = "工程模块数据";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 00 05";
                        dr["上层模块ID"] = "SYS0 00";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口名称"] = "报表模块设置";
                        dr["窗口描述"] = "报表模块设置";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 00 06";
                        dr["上层模块ID"] = "SYS0 00";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 0-1-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicControlCode";
                        dr["窗口名称"] = "控制代码";
                        dr["窗口描述"] = "控制代码";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 01";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicNoteBook";
                        dr["窗口名称"] = "记事本资料库";
                        dr["窗口描述"] = "记事本资料库";
                        dr["图片索引"] = "76";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 02";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicCurreny";
                        dr["窗口名称"] = "币种";
                        dr["窗口描述"] = "币种";
                        dr["图片索引"] = "74";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 03";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicUnits";
                        dr["窗口名称"] = "单位类型";
                        dr["窗口描述"] = "单位类型";
                        dr["图片索引"] = "75";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 04";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicShippingMethod";
                        dr["窗口名称"] = "装运方法";
                        dr["窗口描述"] = "装运方法";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 05";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicEmployer";
                        dr["窗口名称"] = "雇员";
                        dr["窗口描述"] = "雇员";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 06";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicUser";
                        dr["窗口名称"] = "用户";
                        dr["窗口描述"] = "用户";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 07";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicFOB";
                        dr["窗口名称"] = "FOB";
                        dr["窗口描述"] = "FOB";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 08";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicProductGroup";
                        dr["窗口名称"] = "产品组";
                        dr["窗口描述"] = "产品组";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 09";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicProductCode";
                        dr["窗口名称"] = "产品代码";
                        dr["窗口描述"] = "产品代码";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 10";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicApprovalRouteCodes";
                        dr["窗口名称"] = "审批流程库";
                        dr["窗口描述"] = "审批流程库";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 01 11";
                        dr["上层模块ID"] = "SYS0 00 01";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 0-2-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicWareHouse";
                        dr["窗口名称"] = "仓库";
                        dr["窗口描述"] = "仓库";
                        dr["图片索引"] = "73";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 02 01";
                        dr["上层模块ID"] = "SYS0 00 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicPlace";
                        dr["窗口名称"] = "地点";
                        dr["窗口描述"] = "地点";
                        dr["图片索引"] = "73";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 02 02";
                        dr["上层模块ID"] = "SYS0 00 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicInventoryReturnReason";
                        dr["窗口名称"] = "材料退货原因代码";
                        dr["窗口描述"] = "材料退货原因代码";
                        dr["图片索引"] = "73";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 02 03";
                        dr["上层模块ID"] = "SYS0 00 02";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 0-3-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicResourceDepartment";
                        dr["窗口名称"] = "生产资源";
                        dr["窗口描述"] = "生产资源";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 01";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicProductPartParameters";
                        dr["窗口名称"] = "生产部件参数";
                        dr["窗口描述"] = "生产部件参数";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 02";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicCustomerPartKind";
                        dr["窗口名称"] = "客户部件规格";
                        dr["窗口描述"] = "客户部件规格";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 03";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicProcessCommand";
                        dr["窗口名称"] = "生产流程指令资料库";
                        dr["窗口描述"] = "生产流程指令资料库";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 04";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicProcessParameters";
                        dr["窗口名称"] = "生产流程参数资料库";
                        dr["窗口描述"] = "生产流程参数资料库";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 05";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicLaminatedFigure";
                        dr["窗口名称"] = "层压图库";
                        dr["窗口描述"] = "层压图库";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 06";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicScrapDefectClassification";
                        dr["窗口名称"] = "报废缺陷库";
                        dr["窗口描述"] = "报废缺陷库";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 07";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicProjects";
                        dr["窗口名称"] = "工程部";
                        dr["窗口描述"] = "工程部";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 08";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicAdditionalParameters";
                        dr["窗口名称"] = "附加流程参数";
                        dr["窗口描述"] = "附加流程参数";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 09";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicDrillingParameters";
                        dr["窗口名称"] = "钻孔参数";
                        dr["窗口描述"] = "钻孔参数";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 10";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicProductionProcessData";
                        dr["窗口名称"] = "生产流程";
                        dr["窗口描述"] = "生产流程";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 11";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicProductQualityRank";
                        dr["窗口名称"] = "产品质量等级";
                        dr["窗口描述"] = "产品质量等级";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 00 03 12";
                        dr["上层模块ID"] = "SYS0 00 03";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 0-6-0层


                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "ReportSet.FrmPrintSet";
                        dr["窗口名称"] = "报表管理";
                        dr["窗口描述"] = "报表管理";
                        dr["图片索引"] = "72";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 09 00 01";
                        dr["上层模块ID"] = "SYS0 00 06";
                        isFrom_tb.Rows.Add(dr);

                        #endregion

                        #endregion

                        #region 1物控

                        #region 1-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "库存控制";
                        dr["窗口描述"] = "库存控制";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 01 01";
                        dr["上层模块ID"] = "SYS0 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "采购";
                        dr["窗口描述"] = "采购";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 01 02";
                        dr["上层模块ID"] = "SYS0 01";
                        isFrom_tb.Rows.Add(dr);


                        #endregion

                        #region 1-1-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "收货";
                        dr["窗口描述"] = "收货";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 01 01 01";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0112.FormMain";
                        dr["窗口名称"] = "检查";
                        dr["窗口描述"] = "检查";
                        dr["图片索引"] = "81";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 02";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0114.FormMain";
                        dr["窗口名称"] = "仓库接收";
                        dr["窗口描述"] = "仓库接收";
                        dr["图片索引"] = "79";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 03";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0130.FormMain";
                        dr["窗口名称"] = "物料发放请求";
                        dr["窗口描述"] = "物料发放请求";
                        dr["图片索引"] = "85";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 04";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0113.FormMain";
                        dr["窗口名称"] = "物料发放/退还";
                        dr["窗口描述"] = "物料发放/退还";
                        dr["图片索引"] = "86";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 05";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "退回供应商";
                        dr["窗口描述"] = "退回供应商";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 01 01 06";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0120.FormMain";
                        dr["窗口名称"] = "物料盘点";
                        dr["窗口描述"] = "物料盘点";
                        dr["图片索引"] = "87";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 07";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);


                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "装运";
                        dr["窗口描述"] = "装运";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 01 01 08";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);


                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "杂项";
                        dr["窗口描述"] = "杂项";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 01 01 09";
                        dr["上层模块ID"] = "SYS0 01 01";
                        isFrom_tb.Rows.Add(dr);


                        #endregion

                        #region 1-2-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "原材料寄售";
                        dr["窗口描述"] = "原材料寄售";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS0 01 02 01";
                        dr["上层模块ID"] = "SYS0 01 02";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 1-1-1-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0911.FormMain";
                        dr["窗口名称"] = "接收有采购单的物料";
                        dr["窗口描述"] = "接收有采购单的物料";
                        dr["图片索引"] = "82";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 01 01";
                        dr["上层模块ID"] = "SYS0 01 01 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0912.FormMain";
                        dr["窗口名称"] = "接收无采购单的物料";
                        dr["窗口描述"] = "接收无采购单的物料";
                        dr["图片索引"] = "82";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 01 02";
                        dr["上层模块ID"] = "SYS0 01 01 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0914.C0914_Main";
                        dr["窗口名称"] = "接收客户RMA";
                        dr["窗口描述"] = "接收客户RMA";
                        dr["图片索引"] = "82";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 03 01 01 03";
                        dr["上层模块ID"] = "SYS0 01 01 01";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 1-1-6-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0923.FormMain";
                        dr["窗口名称"] = "退回有采购单的物料";
                        dr["窗口描述"] = "退回有采购单的物料";
                        dr["图片索引"] = "83";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 06 01";
                        dr["上层模块ID"] = "SYS0 01 01 06";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "退回无采购单的物料";
                        dr["窗口描述"] = "退回无采购单的物料";
                        dr["图片索引"] = "83";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 06 02";
                        dr["上层模块ID"] = "SYS0 01 01 06";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 1-1-8-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "装运至供应商";
                        dr["窗口描述"] = "装运至供应商";
                        dr["图片索引"] = "83";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 08 01";
                        dr["上层模块ID"] = "SYS0 01 01 08";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0115.C0115C";
                        dr["窗口名称"] = "一个装箱单对应多个出货";
                        dr["窗口描述"] = "一个装箱单对应多个出货";
                        dr["图片索引"] = "83";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 08 02";
                        dr["上层模块ID"] = "SYS0 01 01 08";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 1-1-9-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0117.FormMain";
                        dr["窗口名称"] = "编辑序号/批次/有效期";
                        dr["窗口描述"] = "编辑序号/批次/有效期";
                        dr["图片索引"] = "78";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 09 01";
                        dr["上层模块ID"] = "SYS0 01 01 09";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0921.FormMain";
                        dr["窗口名称"] = "仓库内转移";
                        dr["窗口描述"] = "仓库内转移";
                        dr["图片索引"] = "80";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 01 09 02";
                        dr["上层模块ID"] = "SYS0 01 01 09";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 1-2-1-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "C0360.FormMain";
                        dr["窗口名称"] = "寄售库存管理";
                        dr["窗口描述"] = "寄售库存管理";
                        dr["图片索引"] = "82";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 01 02 01 01";
                        dr["上层模块ID"] = "SYS0 01 02 01";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #endregion

                        #region 2生产

                        #region 2-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "工单控制";
                        dr["窗口描述"] = "工单控制";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS1 02 01";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "D0440";
                        dr["窗口名称"] = "过数";
                        dr["窗口描述"] = "过数";
                        dr["图片索引"] = "55";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 02 02";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "E0310.E0310_Main";
                        dr["窗口名称"] = "订单计划";
                        dr["窗口描述"] = "订单计划";
                        dr["图片索引"] = "93";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 02 03";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "订单更改";
                        dr["窗口描述"] = "订单更改";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS1 02 04";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "";
                        dr["窗口名称"] = "制成品管理";
                        dr["窗口描述"] = "制成品管理";
                        dr["图片索引"] = "84";
                        dr["是否可运行窗口"] = "false";
                        dr["模块ID"] = "SYS1 02 05";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "D0430.D0430_Main";
                        dr["窗口名称"] = "车间管理";
                        dr["窗口描述"] = "车间管理";
                        dr["图片索引"] = "90";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 02 06";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PIF3.FrmMain";
                        dr["窗口名称"] = "F3排程";
                        dr["窗口描述"] = "F3排程";
                        dr["图片索引"] = "90";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 02 07";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "LockD0440.LockD0440";
                        dr["窗口名称"] = "盘点锁定";
                        dr["窗口描述"] = "盘点锁定";
                        dr["图片索引"] = "90";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 02 08";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "LockD0440.LockFinishedProduct";
                        dr["窗口名称"] = "成品异常锁定";
                        dr["窗口描述"] = "成品异常锁定";
                        dr["图片索引"] = "90";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 02 09";
                        dr["上层模块ID"] = "SYS0 02";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 2-1-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "D0410.D0410_Main";
                        dr["窗口名称"] = "工单发放";
                        dr["窗口描述"] = "工单发放";
                        dr["图片索引"] = "94";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 01 01";
                        dr["上层模块ID"] = "SYS1 02 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "D0400.D0400_Main";
                        dr["窗口名称"] = "工单管理";
                        dr["窗口描述"] = "工单管理";
                        dr["图片索引"] = "95";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 01 02";
                        dr["上层模块ID"] = "SYS1 02 01";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "D0420.D0420_Main";
                        dr["窗口名称"] = "在线报废检查";
                        dr["窗口描述"] = "在线报废检查";
                        dr["图片索引"] = "102";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 02 01 03";
                        dr["上层模块ID"] = "SYS1 02 01";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 2-4-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "E0401.E0401_Main";
                        dr["窗口名称"] = "内部更改";
                        dr["窗口描述"] = "内部更改";
                        dr["图片索引"] = "98";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 04 01";
                        dr["上层模块ID"] = "SYS1 02 04";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "E0400.E0400_Main";
                        dr["窗口名称"] = "外部更改";
                        dr["窗口描述"] = "外部更改";
                        dr["图片索引"] = "100";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 04 02";
                        dr["上层模块ID"] = "SYS1 02 04";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #region 2-5-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "E0210.E0210_Main";
                        dr["窗口名称"] = "制成品分配";
                        dr["窗口描述"] = "制成品分配";
                        dr["图片索引"] = "99";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 05 01";
                        dr["上层模块ID"] = "SYS1 02 05";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "E0220.E0220_Main";
                        dr["窗口名称"] = "销售订单装运指派";
                        dr["窗口描述"] = "销售订单装运指派";
                        dr["图片索引"] = "101";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 05 02";
                        dr["上层模块ID"] = "SYS1 02 05";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "E0280.E0280_Main";
                        dr["窗口名称"] = "包装处理";
                        dr["窗口描述"] = "包装处理";
                        dr["图片索引"] = "89";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 05 03";
                        dr["上层模块ID"] = "SYS1 02 05";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "E0240.E0240";
                        dr["窗口名称"] = "制成品转移";
                        dr["窗口描述"] = "制成品转移";
                        dr["图片索引"] = "89";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 05 04";
                        dr["上层模块ID"] = "SYS1 02 05";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "CqTransfer.Main";
                        dr["窗口名称"] = "BarCode制成品转移";
                        dr["窗口描述"] = "BarCode制成品转移";
                        dr["图片索引"] = "89";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS2 02 05 05";
                        dr["上层模块ID"] = "SYS1 02 05";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #endregion

                        #region 3品质

                        #region 3-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "B0400.B0400_Main";
                        dr["窗口名称"] = "MRB";
                        dr["窗口描述"] = "MRB";
                        dr["图片索引"] = "55";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 03 01";
                        dr["上层模块ID"] = "SYS0 03";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "B0310.B0310_Main";
                        dr["窗口名称"] = "RMA";
                        dr["窗口描述"] = "RMA";
                        dr["图片索引"] = "55";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 03 02";
                        dr["上层模块ID"] = "SYS0 03";
                        isFrom_tb.Rows.Add(dr);


                        #endregion

                        #endregion

                        #region 4工程

                        #region 4-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "Engineering.FrmEngineering";
                        dr["窗口名称"] = "部件维护";
                        dr["窗口描述"] = "部件维护";
                        dr["图片索引"] = "71";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 04 01";
                        dr["上层模块ID"] = "SYS0 04";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "EngineeringPlan.frm_main";
                        dr["窗口名称"] = "工程计划系统";
                        dr["窗口描述"] = "工程计划系统";
                        dr["图片索引"] = "104";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 04 02";
                        dr["上层模块ID"] = "SYS0 04";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #endregion

                        #region 5设备模块

                        #region 5-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "RequestRepair";
                        dr["窗口名称"] = "日常性维护";
                        dr["窗口描述"] = "日常性维护";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 05 01";
                        dr["上层模块ID"] = "SYS0 05";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PlanRepairManage";
                        dr["窗口名称"] = "预防性维护";
                        dr["窗口描述"] = "预防性维护";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 05 02";
                        dr["上层模块ID"] = "SYS0 05";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicEquipmentsManage";
                        dr["窗口名称"] = "设施/设备定义";
                        dr["窗口描述"] = "设施/设备定义";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 05 03";
                        dr["上层模块ID"] = "SYS0 05";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicRepairKind";
                        dr["窗口名称"] = "维修单类型定义";
                        dr["窗口描述"] = "维修单类型定义";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 05 04";
                        dr["上层模块ID"] = "SYS0 05";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "PublicBreakDownReason";
                        dr["窗口名称"] = "故障原因";
                        dr["窗口描述"] = "故障原因";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS0 05 05";
                        dr["上层模块ID"] = "SYS0 05";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #endregion

                        #region 6系统管理

                        #region 6-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "Permissions.FrmUserPermission";
                        dr["窗口名称"] = "用户权限设置";
                        dr["窗口描述"] = "用户权限设置";
                        dr["图片索引"] = "60";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 06 01";
                        dr["上层模块ID"] = "SYS0 06";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "Permissions.FrmUserGroup";
                        dr["窗口名称"] = "权限组设置";
                        dr["窗口描述"] = "权限组设置";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 06 02";
                        dr["上层模块ID"] = "SYS0 06";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "Approval.FrmApprovalProcess";
                        dr["窗口名称"] = "审批处理";
                        dr["窗口描述"] = "审批处理";
                        dr["图片索引"] = "77";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 06 03";
                        dr["上层模块ID"] = "SYS0 06";
                        isFrom_tb.Rows.Add(dr);


                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "Swith.Switch";
                        dr["窗口名称"] = "系统开关";
                        dr["窗口描述"] = "系统开关";
                        dr["图片索引"] = "97";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 06 04";
                        dr["上层模块ID"] = "SYS0 06";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "MenuManagement.FrmMain";
                        dr["窗口名称"] = "菜单管理";
                        dr["窗口描述"] = "菜单管理";
                        dr["图片索引"] = "97";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 06 05";
                        dr["上层模块ID"] = "SYS0 06";
                        isFrom_tb.Rows.Add(dr);
                        #endregion

                        #endregion

                        #region 财务
                        #region 7-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "COST.frm_main";
                        dr["窗口名称"] = "成本运算";
                        dr["窗口描述"] = "成本运算";
                        dr["图片索引"] = "60";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 07 01";
                        dr["上层模块ID"] = "SYS0 07";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "FinanceOMC.MainForm";
                        dr["窗口名称"] = "在线盘点";
                        dr["窗口描述"] = "在线盘点";
                        dr["图片索引"] = "60";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 07 02";
                        dr["上层模块ID"] = "SYS0 07";
                        isFrom_tb.Rows.Add(dr);
                        #endregion
                        #endregion

                        #region 报表
                        #region 8-0层
                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "ReportView.FrmReportView";
                        dr["窗口名称"] = "报表查看";
                        dr["窗口描述"] = "报表查看";
                        dr["图片索引"] = "60";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 09 01";
                        dr["上层模块ID"] = "SYS0 09";
                        isFrom_tb.Rows.Add(dr);

                        dr = isFrom_tb.NewRow();
                        dr["窗口类名"] = "ReportSet.FrmPrintTest";
                        dr["窗口名称"] = "打印测试";
                        dr["窗口描述"] = "打印测试";
                        dr["图片索引"] = "60";
                        dr["是否可运行窗口"] = "true";
                        dr["模块ID"] = "SYS1 09 02";
                        dr["上层模块ID"] = "SYS0 09";
                        isFrom_tb.Rows.Add(dr);


                        #endregion
                        #endregion

                        #endregion

                        #region 校正标志位
                        for (int i = 0; i < isFrom_tb.Rows.Count; i++)
                        {
                            if (isFrom_tb.Rows[i]["窗口名称"].ToString().Trim().Length > 0)
                            {
                                if (isFrom_tb.Rows[i]["是否可运行窗口"].ToString().ToUpper() == "TRUE")
                                {
                                    isFrom_tb.Rows[i]["模块ID"] = isFrom_tb.Rows[i]["模块ID"].ToString().Substring(0, 3) + "1" +
                                                                  isFrom_tb.Rows[i]["模块ID"].ToString().Substring(4, isFrom_tb.Rows[i]["模块ID"].ToString().Length - 4);
                                }
                                else
                                {
                                    isFrom_tb.Rows[i]["模块ID"] = isFrom_tb.Rows[i]["模块ID"].ToString().Substring(0, 3) + "0" +
                                                                  isFrom_tb.Rows[i]["模块ID"].ToString().Substring(4, isFrom_tb.Rows[i]["模块ID"].ToString().Length - 4);
                                }
                                if (isFrom_tb.Rows[i]["上层模块ID"].ToString().Trim().Length > 0)
                                {
                                    isFrom_tb.Rows[i]["上层模块ID"] = isFrom_tb.Rows[i]["上层模块ID"].ToString().Substring(0, 3) + "0" +
                                                                      isFrom_tb.Rows[i]["上层模块ID"].ToString().Substring(4, isFrom_tb.Rows[i]["上层模块ID"].ToString().Length - 4);
                                }
                            }
                            else
                            {
                                isFrom_tb.Rows[i]["窗口类名"] = "";
                            }
                        }
                        #endregion

                        #region 将菜单配置信息保存到数据库
                        try
                        {
                            db.ExecuteCommand(@"
                                                create table FOUNDERPCB_TEMP
                                                (
                                                [RKEY]		[numeric](18,0) IDENTITY(1,1) PRIMARY KEY,
                                                [ClassName] [varchar](100),
                                                FormName nvarchar(100),
                                                FormDesc nvarchar(100),
                                                [ImgIndex]	[int] NOT NULL,
                                                Runnable	[BIT] NOT NULL,
                                                ModuleID varchar(50) NOT NULL,
                                                ParentModuleID varchar(50) NOT NULL,
                                                )
                                              ");
                            db.ExecuteCommand(@"
                                                Create Table [dbo].[FOUNDERPCB_MENU_EXT]
                                                (
                                                [RKEY]		[numeric](18,0) PRIMARY KEY,
                                                [ClassName] [varchar](100) ,
                                                [ImgIndex]	[int] NOT NULL,
                                                [Runnable]	[BIT] NOT NULL,
                                                )");
                            SqlCommand selectcmd = new SqlCommand("select top 0 [ClassName],FormName,FormDesc,[ImgIndex],Runnable,ModuleID,ParentModuleID from FOUNDERPCB_TEMP", db.Connection);
                            SqlDataAdapter sda = new SqlDataAdapter(selectcmd);
                            DataTable dataTable = new DataTable();
                            sda.Fill(dataTable);

                            for (int i = 0; i < isFrom_tb.Rows.Count; i++)
                            {
                                dataTable.Rows.Add(new object[] { isFrom_tb.Rows[i]["窗口类名"],
                                                                    isFrom_tb.Rows[i]["窗口名称"], 
                                                                    isFrom_tb.Rows[i]["窗口描述"], 
                                                                    isFrom_tb.Rows[i]["图片索引"], 
                                                                    isFrom_tb.Rows[i]["是否可运行窗口"], 
                                                                    isFrom_tb.Rows[i]["模块ID"], 
                                                                    isFrom_tb.Rows[i]["上层模块ID"] });
                            }
                            SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                            //执行更新
                            sda.Update(dataTable.GetChanges());
                            //使DataTable保持更新
                            dataTable.AcceptChanges();

                            db.ExecuteCommand(@"
                                                insert into FOUNDERPCB_FRIGHTE_01
                                                select ParentModuleID,ModuleID,FormName,FormName,FormDesc
                                                from FOUNDERPCB_TEMP
	                                                left join FOUNDERPCB_FRIGHTE_01 on FOUNDERPCB_TEMP.ModuleID = FOUNDERPCB_FRIGHTE_01.MODULE_ID
                                                where MODULE_ID is null");
                            db.ExecuteCommand(@"
                                                insert into [FOUNDERPCB_MENU_EXT]
                                                select a.RKEY,isnull(b.ClassName,''),b.ImgIndex,b.Runnable
                                                from FOUNDERPCB_FRIGHTE_01 as a
	                                                inner join FOUNDERPCB_TEMP as b on a.MODULE_ID = b.ModuleID");
                            db.ExecuteCommand("drop table FOUNDERPCB_TEMP");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("将菜单配置信息保存到数据库失败：" + ex.Message);
                        }
                        #endregion
                    }
                    else
                    {
                        isExistsTableExt = true;
                    }
                }
                finally
                {
                    db.CloseConnection();
                }
                #endregion


                #region 从数据库中读取
                if (isExistsTableExt == true)
                {
                    DBHelper db2 = new DBHelper();
                    try
                    {
                        string s = @"select 
	                                    b.ClassName as 窗口类名,
	                                    a.MODULE_NAME as 窗口名称,
	                                    b.ImgIndex as 图片索引,
	                                    case when b.Runnable = 1 then 'true' else 'false' end as 是否可运行窗口,
	                                    a.MODULE_DESC as 窗口描述,
	                                    a.MODULE_ID as 模块ID,
	                                    a.UP_MODULE_ID as 上层模块ID,
	                                    '' as 连接池
                                    from FOUNDERPCB_FRIGHTE_01 as a with(nolock)
	                                    inner join FOUNDERPCB_MENU_EXT as b  with(nolock) on a.RKEY = b.RKEY";
                        isFrom_tb = db2.GetDataSet(s);
                    }
                    finally
                    {
                        db2.CloseConnection();
                    }
                }
                #endregion
                #region 初始化
                //连接池从50开始，1-49预留，用着动态
                int i_Thread = 50;
                //下面代码的作用是分配连接，同时按照窗口是否可以运行将模块ID的第四位（模块是否可运行标志位）改为0或1。
                for (int i = 0; i < isFrom_tb.Rows.Count; i++)
                {
                    if (isFrom_tb.Rows[i]["窗口名称"].ToString().Trim().Length > 0)
                    {
                        if (isFrom_tb.Rows[i]["是否可运行窗口"].ToString().ToUpper() == "TRUE")
                        {
                            isFrom_tb.Rows[i]["连接池"] = (i_Thread++).ToString();
                            //isFrom_tb.Rows[i]["模块ID"] = isFrom_tb.Rows[i]["模块ID"].ToString().Substring(0, 3) + "1" +
                            //                              isFrom_tb.Rows[i]["模块ID"].ToString().Substring(4, isFrom_tb.Rows[i]["模块ID"].ToString().Length - 4);
                        }
                        else
                        {
                            isFrom_tb.Rows[i]["连接池"] = "-1";
                            //isFrom_tb.Rows[i]["模块ID"] = isFrom_tb.Rows[i]["模块ID"].ToString().Substring(0, 3) + "0" +
                            //                              isFrom_tb.Rows[i]["模块ID"].ToString().Substring(4, isFrom_tb.Rows[i]["模块ID"].ToString().Length - 4);
                        }
                        if (isFrom_tb.Rows[i]["上层模块ID"].ToString().Trim().Length > 0)
                        {
                            //isFrom_tb.Rows[i]["上层模块ID"] = isFrom_tb.Rows[i]["上层模块ID"].ToString().Substring(0, 3) + "0" +
                            //                                  isFrom_tb.Rows[i]["上层模块ID"].ToString().Substring(4, isFrom_tb.Rows[i]["上层模块ID"].ToString().Length - 4);
                        }
                    }
                    else
                        isFrom_tb.Rows[i]["窗口类名"] = "";
                }
                #endregion
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                System.Environment.Exit(0);
            }
        }
        #endregion

        #region 刷新主界面的菜单 SetMenu
        /// <summary>
        /// 刷新主界面的菜单
        /// </summary>
        /// <param name="i1">第一层</param>
        /// <param name="i2">第二层</param>
        /// <param name="i3">第三层</param>
        /// <param name="i4">第四层</param>
        /// <param name="LV_Para">ListView控件</param>
        /// <param name="IL_Para">ImageLisT控件</param>
        public static void SetMenu(string ps_MenuID, ListView LV_Para, ImageList IL_Para)
        {
            try
            {
                DataTable tb;
                ListViewItem LVI_temp;
                tb = SysMenu.GetChildMenu(ps_MenuID);

                #region 构建图标
                LV_Para.Clear();
                LV_Para.LargeImageList = IL_Para;
                LV_Para.View = View.LargeIcon;

                if (LV_Para.Name == "listView2" && ps_MenuID.Trim().Length <= 0) return;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //判断是否有显示权力 
                    if (CheckModulePermission(tb.Rows[i]["模块ID"].ToString(), 1))
                    {
                        LVI_temp = LV_Para.Items.Add(tb.Rows[i]["窗口名称"].ToString(), int.Parse(tb.Rows[i]["图片索引"].ToString()));

                        LVI_temp.Tag = tb.Rows[i]["模块ID"].ToString();
                        //判断是否有访问权力
                        if (CheckModulePermission(tb.Rows[i]["模块ID"].ToString(), 2))
                        {
                            if (tb.Rows[i]["是否可运行窗口"].ToString().ToUpper() == "TRUE")
                                LVI_temp.ToolTipText = tb.Rows[i]["窗口名称"].ToString();
                            else
                                LVI_temp.ToolTipText = "";
                        }
                        else
                        {
                            //LVI_temp.Tag = "";
                            LVI_temp.ToolTipText = "~~~";
                        }
                    }
                }
                #endregion
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region 获取菜单子项 GetChildMenu
        /// <summary>
        /// 获取菜单子项
        /// </summary>
        /// <param name="ps_MenuID">上层ID号</param>
        /// <returns></returns>
        public static DataTable GetChildMenu(string ps_MenuID)
        {
            try
            {
                DataTable tb = new DataTable();

                tb = isFrom_tb.Copy();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["上层模块ID"].ToString().Trim() != ps_MenuID.Trim())
                    {
                        tb.Rows.RemoveAt(i);
                        i--;
                    }
                }
                return tb;
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return null;
            }
        }
        #endregion

        #region 获取本菜单 GetMenu
        /// <summary>
        /// 获取本菜单
        /// </summary>
        /// <param name="ps_MenuID"></param>
        /// <returns></returns>
        public static DataTable GetMenu(string ps_MenuID)
        {
            try
            {
                DataTable tb = new DataTable();

                tb = isFrom_tb.Copy();
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    if (tb.Rows[i]["模块ID"].ToString().Trim() != ps_MenuID.Trim())
                    {
                        tb.Rows.RemoveAt(i);
                        i--;
                    }
                }
                return tb;
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return null;
            }
        }
        #endregion

        #region 获取上层菜单 GetMenuUpID
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="ps_MenuID">ID号</param>
        /// <returns></returns>
        public static string GetMenuUpID(string ps_MenuID)
        {
            try
            {
                for (int i = 0; i < isFrom_tb.Rows.Count; i++)
                {
                    if (isFrom_tb.Rows[i]["模块ID"].ToString().Trim() == ps_MenuID.Trim())
                    {
                        return isFrom_tb.Rows[i]["上层模块ID"].ToString().Trim();
                    }
                }
                return "";
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return null;
            }
        }
        #endregion

        #region 判断菜单是否能运行 CheckMenuRun
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <param name="ps_MenuID">ID号</param>
        /// <returns></returns>
        public static Boolean CheckMenuRun(string ps_MenuID)
        {
            try
            {
                for (int i = 0; i < isFrom_tb.Rows.Count; i++)
                {
                    if (isFrom_tb.Rows[i]["模块ID"].ToString().Trim() == ps_MenuID.Trim())
                    {
                        if (isFrom_tb.Rows[i]["是否可运行窗口"].ToString().Trim().ToUpper() == "TRUE")
                            return true;
                        else
                            return false;
                    }
                }
                return false;
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return false;
            }
        }
        #endregion

        #region 运行模块 RunMenu
        /// <summary>
        /// 运行模块
        /// </summary>
        /// <param name="ps_MenuID">模块ID</param>
        public static void RunMenu(Form ps_Frm, string ps_MenuID)
        {
            #region 说明
            //用反射打开窗口方法
            //System.Reflection.Assembly ass;
            //Type type;
            //object obj;
            //try
            //{
            //    ass = System.Reflection.Assembly.LoadFile(System.IO.Directory.GetCurrentDirectory() + "\\KB.Module6.dll");
            //    type = ass.GetType("KB.Module.Form1");//必须使用名称空间 类名称
            //    //System.Reflection.MethodInfo method = type.GetMethod("WriteString");//方法的名称
            //    obj = ass.CreateInstance("KB.Module.Form1");//必须使用名称空间 
            //    ((Form)obj).Show();
            //}
            //catch { }
            #endregion
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Boolean b_exists = false;
                Form Frm;
                string s_FormName = "";
                string s_path;
                System.Reflection.Assembly ass;
                object obj;

                s_path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                for (int i = 0; i < isFrom_tb.Rows.Count; i++)
                {
                    if (isFrom_tb.Rows[i]["模块ID"].ToString().Trim() == ps_MenuID.Trim())
                    {
                        s_FormName = isFrom_tb.Rows[i]["窗口类名"].ToString().Trim();
                        Frm = null;
                        try
                        {

                            ass = System.Reflection.Assembly.LoadFile(s_path + "\\KB.Module" + (int.Parse(ps_MenuID.Substring(5, 2)) + 1).ToString() + ".dll");
                            //Type type = ass.GetType("KB.Module." + s_FormName);//必须使用名称空间 类名称 
                            obj = ass.CreateInstance("KB.Module." + s_FormName);//必须使用名称空间 
                            if (obj != null)
                            {
                                Frm = ((Form)obj);
                                b_exists = true;
                            }
                        }
                        catch { }
                        if (b_exists)
                        {
                            Frm.AccessibleName = isFrom_tb.Rows[i]["模块ID"].ToString().Trim();
                            Frm.AccessibleDescription = isFrom_tb.Rows[i]["窗口名称"].ToString().Trim();
                            Frm.Text = Frm.AccessibleDescription.Trim();

                            Frm.Owner = ps_Frm;
                            Frm.Show();
                            Frm.Activate();
                        }
                        else
                        {
                            b_exists = true;
                            Func.ShowInformation("本功能模块尚未开发完成！");

                        }
                    }
                }
                Cursor.Current = Cursors.Default;
                if (!b_exists)
                {
                    Func.ShowError("没查找到相关模块号！");
                    return;
                }
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
            }
        }
        #endregion

        #region 获取连接池 GetMenuThread
        /// <summary>
        /// 获取连接池
        /// </summary>
        /// <returns></returns>
        public static int GetMenuThread(Form Frm)
        {
            try
            {
                if (Frm.AccessibleName == null) return -1;

                for (int i = 0; i < isFrom_tb.Rows.Count; i++)
                {
                    if (isFrom_tb.Rows[i]["模块ID"].ToString().Trim() == Frm.AccessibleName.Trim())
                    {
                        return int.Parse(isFrom_tb.Rows[i]["连接池"].ToString().Trim());
                    }
                }

                return -1;
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return -1;
            }
        }
        #endregion

        #region 权力判定方法 Permission

        #region 单独判断模块权力 CheckModulePermission
        /// <summary>
        /// 单独判断模块权力
        /// </summary>
        /// <param name="Ctl"></param>
        /// <param name="Print">为真显示信息</param>
        /// <param name="Category">0为显示，1为访问</param>
        /// <returns></returns>
        public static Boolean CheckModulePermission(Control Ctl, Boolean Print, int Category)
        {
            try
            {
                Boolean b_ret = false;

                if (GlobalVal.UserInfo.RAID == 1) return true;//超级管理员

                //参数错误
                Category--;
                if (Category < 0 || Category > 1) return false;

                //判断是否可以显示
                if (Ctl.AccessibleName != null)
                {
                    if (Ctl.AccessibleName.Trim() == "frmMain") return true;//主窗口，不判断

                    for (int i = 0; i < GlobalVal.Permission.GetUpperBound(0); i++)
                    {
                        if (GlobalVal.Permission[i].ID.ToString().Trim() == Ctl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].SORT == 1)
                        {
                            if (GlobalVal.Permission[i].PERMISSION.Trim().Substring(Category, 1) == "1")
                                b_ret = true;
                            else
                                b_ret = false;
                            break;
                        }
                    }
                }
                if (Print && !b_ret) Func.ShowInformation("请注意，你无权访问本功能！");

                return b_ret;
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return false;
            }
        }
        /// <summary>
        /// 单独判断模块权力
        /// </summary>
        /// <param name="ID">模块ID号</param>
        /// <param name="Category">1为显示，2为访问</param>
        /// <returns></returns>
        public static Boolean CheckModulePermission(string ID, int Category)
        {
            try
            {
                Boolean b_ret = false;

                if (GlobalVal.UserInfo.RAID == 1) return true;//超级管理员

                //参数错误
                Category--;
                if (Category < 0 || Category > 1) return false;

                //判断是否可以显示
                for (int i = 0; i < GlobalVal.Permission.GetUpperBound(0); i++)
                {
                    if (GlobalVal.Permission[i].ID.ToString().Trim() == ID.Trim() &&
                        GlobalVal.Permission[i].SORT == 1)
                    {
                        if (GlobalVal.Permission[i].PERMISSION.Trim().Substring(Category, 1) == "1")
                            b_ret = true;
                        else
                            b_ret = false;
                        break;
                    }
                }

                return b_ret;
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return false;
            }
        }
        #endregion

        #region 单独判断控件权力 CheckControlPermission
        /// <summary>
        /// 单独判断控件权力
        /// </summary>
        /// <param name="UpCtl">模块</param>
        /// <param name="Ctl">字段</param>
        /// <param name="Category">1为显示，2为访问</param>
        /// <returns></returns>
        public static Boolean CheckControlPermission(Control UpCtl, Control Ctl, int Category)
        {
            try
            {
                Boolean b_ret = false;

                if (GlobalVal.UserInfo.RAID == 1) return true;//超级管理员
                if (GlobalVal.UserInfo.RAID == 0 && Category == 1) return false;//临时没访问权
                //参数错误
                Category--;
                if (Category < 0 || Category > 1) return false;

                //判断是否可以显示
                if (Ctl.AccessibleName != null)
                {
                    for (int i = 0; i < GlobalVal.Permission.GetUpperBound(0); i++)
                    {
                        if (GlobalVal.Permission[i].ID.ToString().Trim() == UpCtl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].ENGLISH.ToString().Trim() == Ctl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].SORT == 2)
                        {
                            if (GlobalVal.Permission[i].PERMISSION.Trim().Substring(Category, 1) == "1")
                                b_ret = true;
                            else
                                b_ret = false;
                            break;
                        }
                    }
                }

                return b_ret;
            }
            catch //(Exception e1)
            {
                //  log.RecordInfo(e1);
                return false;
            }
        }
        /// <summary>
        /// 单独判断控件权力
        /// </summary>
        /// <param name="UpCtl"></param>
        /// <param name="Ctl"></param>
        /// <param name="Category"></param>
        /// <returns></returns>
        public static Boolean CheckControlPermission(Control UpCtl, string Ctl, int Category)
        {
            try
            {
                Boolean b_ret = false;

                if (GlobalVal.UserInfo.RAID == 1) return true;//超级管理员
                if (GlobalVal.UserInfo.RAID == 0 && Category == 1) return false;//临时没访问权
                //参数错误
                Category--;
                if (Category < 0 || Category > 1) return false;

                //判断是否可以显示
                if (Ctl.Trim().Length > 0)
                {
                    for (int i = 0; i < GlobalVal.Permission.GetUpperBound(0); i++)
                    {
                        if (GlobalVal.Permission[i].ID.ToString().Trim() == UpCtl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].ENGLISH.ToString().Trim() == Ctl.Trim() &&
                            GlobalVal.Permission[i].SORT == 2)
                        {
                            if (GlobalVal.Permission[i].PERMISSION.Trim().Substring(Category, 1) == "1")
                                b_ret = true;
                            else
                                b_ret = false;
                            break;
                        }
                    }
                }

                return b_ret;
            }
            catch //(Exception e1)
            {
                //  log.RecordInfo(e1);
                return false;
            }
        }
        /// <summary>
        /// 单独判断控件权力 返回 00，10为没权限，11为有权限，"  "为没找到
        /// </summary>
        /// <param name="UpCtl">模块</param>
        /// <param name="Ctl">字段</param> 
        /// <returns></returns>
        public static string CheckControlPermission(Control UpCtl, Control Ctl)
        {
            try
            {
                string s_ret = "  ";

                if (GlobalVal.UserInfo.RAID == 1) return "11";//超级管理员

                //判断是否可以显示
                if (Ctl.AccessibleName != null)
                {
                    for (int i = 0; i < GlobalVal.Permission.GetUpperBound(0); i++)
                    {
                        if (GlobalVal.Permission[i].ID.ToString().Trim() == UpCtl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].ENGLISH.ToString().Trim() == Ctl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].SORT == 2)
                        {
                            s_ret = GlobalVal.Permission[i].PERMISSION.Trim();
                            if (GlobalVal.UserInfo.RAID == 0) s_ret = s_ret.Substring(0, 1) + "0";

                            break;
                        }
                    }
                }

                return s_ret;
            }
            catch //(Exception e1)
            {
                //   log.RecordInfo(e1);
                return "00";
            }
        }
        /// <summary>
        /// 单独判断控件权力 返回 00，10为没权限，11为有权限，"  "为没找到
        /// </summary>
        /// <param name="UpCtl"></param>
        /// <param name="Ctl"></param>
        /// <returns></returns>
        public static string CheckControlPermission(Control UpCtl, string Ctl)
        {
            try
            {
                string s_ret = "  ";

                if (GlobalVal.UserInfo.RAID == 1) return "11";//超级管理员

                //判断是否可以显示
                if (Ctl.Trim().Length > 0)
                {
                    for (int i = 0; i < GlobalVal.Permission.GetUpperBound(0); i++)
                    {
                        if (GlobalVal.Permission[i].ID.ToString().Trim() == UpCtl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].ENGLISH.ToString().Trim() == Ctl.Trim() &&
                            GlobalVal.Permission[i].SORT == 2)
                        {
                            s_ret = GlobalVal.Permission[i].PERMISSION.Trim();
                            if (GlobalVal.UserInfo.RAID == 0) s_ret = s_ret.Substring(0, 1) + "0";
                            break;
                        }
                    }
                }

                return s_ret;
            }
            catch //(Exception e1)
            {
                //  log.RecordInfo(e1);
                return "00";
            }
        }
        #endregion

        #region 单独判断字段权力 CheckFieldPermission
        /// <summary>
        /// 单独判断字段权力
        /// </summary>
        /// <param name="UpCtl">模块</param>
        /// <param name="Ctl">控件</param>
        /// <param name="FieldName">字段</param>
        /// <param name="Category">1为显示，2为访问</param>
        /// <returns></returns>
        public static Boolean CheckFieldPermission(Control UpCtl, Control Ctl, string FieldName, int Category)
        {
            try
            {
                Boolean b_ret = false;

                if (GlobalVal.UserInfo.RAID == 1) return true;//超级管理员
                if (GlobalVal.UserInfo.RAID == 0 && Category == 1) return false;//临时没访问权
                //参数错误
                Category--;
                if (Category < 0 || Category > 1) return false;

                //判断是否可以显示
                if (Ctl.AccessibleName != null)
                {
                    for (int i = 0; i < GlobalVal.Permission.GetUpperBound(0); i++)
                    {
                        if (GlobalVal.Permission[i].ID.ToString().Trim() == UpCtl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].UP_ENGLISH.Trim() == Ctl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].ENGLISH.ToString().Trim() == FieldName.Trim() &&
                            GlobalVal.Permission[i].SORT == 3)
                        {
                            if (GlobalVal.Permission[i].PERMISSION.Trim().Substring(Category, 1) == "1")
                                b_ret = true;
                            else
                                b_ret = false;

                            break;
                        }
                    }
                }

                return b_ret;
            }
            catch //(Exception e1)
            {
                //  log.RecordInfo(e1);
                return false;
            }
        }
        /// <summary>
        /// 单独判断字段权力
        /// </summary>
        /// <param name="UpCtl"></param>
        /// <param name="Ctl"></param>
        /// <param name="FieldName"></param>
        /// <param name="Category"></param>
        /// <returns></returns>
        public static Boolean CheckFieldPermission(Control UpCtl, string Ctl, string FieldName, int Category)
        {
            try
            {
                Boolean b_ret = false;

                if (GlobalVal.UserInfo.RAID == 1) return true;//超级管理员
                if (GlobalVal.UserInfo.RAID == 0 && Category == 1) return false;//临时没访问权
                //参数错误
                Category--;
                if (Category < 0 || Category > 1) return false;

                //判断是否可以显示
                if (Ctl.Trim().Length > 0)
                {
                    for (int i = 0; i < GlobalVal.Permission.GetUpperBound(0); i++)
                    {
                        if (GlobalVal.Permission[i].ID.ToString().Trim() == UpCtl.AccessibleName.Trim() &&
                            GlobalVal.Permission[i].UP_ENGLISH.Trim() == Ctl.Trim() &&
                            GlobalVal.Permission[i].ENGLISH.ToString().Trim() == FieldName.Trim() &&
                            GlobalVal.Permission[i].SORT == 3)
                        {
                            if (GlobalVal.Permission[i].PERMISSION.Trim().Substring(Category, 1) == "1")
                                b_ret = true;
                            else
                                b_ret = false;

                            break;
                        }
                    }
                }

                return b_ret;
            }
            catch //(Exception e1)
            {
                //  log.RecordInfo(e1);
                return false;
            }
        }
        #endregion

        #region 遍历屏无权限控件窗口 SetModulePermission
        /// <summary>
        /// 遍历屏无权限控件窗口
        /// </summary>
        /// <param name="Ctl"></param>
        public static void SetModulePermission(Control Ctl)
        {
            try
            {
                string s_temp = "";

                if (GlobalVal.UserInfo.RAID == 1) return;//超级管理员

                CheckModulePermission(Ctl, true, 1);//判断是模块是否能显示

                if (Ctl.AccessibleName != null)
                {
                    foreach (Control ct in Ctl.Controls)
                    {
                        s_temp = CheckControlPermission(Ctl, ct);
                        if (s_temp.Substring(0, 1) == "0")
                            ct.Visible = false;
                        else
                        {
                            if (s_temp.Substring(1, 1) == "0")
                                ct.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
            }
        }
        #endregion

        #endregion

        #region 登陆 LoginSys
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="frm"></param>
        public static Boolean LoginSys(Form frm)
        {
            DBHelper db = new DBHelper(0);
            try
            {
                #region 获取界面信息
                GlobalVal.UserInfo.FactoryID = int.Parse(((ComboBox)frm.Controls["CB_厂别"]).SelectedValue.ToString().Split('-')[0]);
                GlobalVal.ConnIndex = int.Parse(((ComboBox)frm.Controls["CB_厂别"]).SelectedValue.ToString().Split('-')[1]);
                GlobalVal.TestPlatform = (GlobalVal.ConnIndex == 1 ? false : true);
                GlobalVal.UserInfo.LoginName = ((TextBox)frm.Controls["LoginID"]).Text.Trim();
                GlobalVal.UserInfo.LoginDate = DateTime.Now;
                GlobalVal.UserInfo.IP = Func.getIP();
                GlobalVal.UserInfo.HostName = Func.getHostName();

                IList<ADUserInfo> adinfo;
                AD adbo = new AD();
                adinfo = adbo.getADUserInfo(GlobalVal.UserInfo.LoginName);
                if (adinfo.Count > 0)
                    GlobalVal.UserInfo.AD = adinfo[0];
                else
                {
                    Func.ShowWarning("获取用户域信息失败，请与信息中心联系！");
                    return false;
                }
                #endregion

                #region 系统信息初始化
                GlobalVal.InitConnection();//初始数据连接库
                InitSysInfo();
                #endregion

                #region 处理数据库
                string[] s_temp = new string[10];

                FOUNDERPCB_USER InfoUser = new FOUNDERPCB_USER();
                FOUNDERPCB_LOGIN_LOG InfoLog = new FOUNDERPCB_LOGIN_LOG();
                DATA0073 InfoD73 = new DATA0073();
                DATA0005 InfoD05 = new DATA0005();

                DATA0005BLL BllD05 = new DATA0005BLL(db);
                DATA0073BLL BllD73 = new DATA0073BLL(db);
                FOUNDERPCB_LOGIN_LOGBLL BllLog = new FOUNDERPCB_LOGIN_LOGBLL(db);
                FOUNDERPCB_USERBLL BllUser = new FOUNDERPCB_USERBLL(db);

                #region 获取帐号
                try
                {
                    //InfoD05 = BllD05.FindBySql("EMPLOYEE_NAME = '" + GlobalVal.UserInfo.AD.Cn.Trim() + "'")[0];
                    InfoD05 = BllD05.FindBySql("ADDRESS_LINE_1 collate Chinese_PRC_CI_AS ='KB\\" + GlobalVal.UserInfo.LoginName.Trim().ToLower() + "'")[0];
                    InfoD73 = BllD73.FindBySql("EMPLOYEE_PTR=" + InfoD05.RKEY.ToString())[0];
                    // InfoD73 = BllD73.FindBySql("user_full_name = '" + GlobalVal.UserInfo.AD.Cn.Trim() + "'")[0];
                }
                catch
                {
                    try
                    {
                        MessageBox.Show(GlobalVal.GetFactory(GlobalVal.UserInfo.FactoryID).Rows[0]["text"].ToString().Trim() + "不存在你的用户信息(5#表域地址)，请与信息中心联系！", "提示");
                    }
                    catch
                    {
                        MessageBox.Show("不存在你的用户信息(5#表域地址)，请与信息中心联系！", "提示");
                    }
                    return false;
                }
                if (InfoD05.ACTIVE_FLAG == "N")
                {
                    MessageBox.Show("帐号已经停用，不能登陆！", "提示");
                    return false;
                }
                GlobalVal.UserInfo.DATA0005RKEY = InfoD05.RKEY;
                GlobalVal.UserInfo.DATA0073RKEY = InfoD73.RKEY;
                try
                {
                    InfoUser = BllUser.FindBySql("LOGIN_ID = '" + GlobalVal.UserInfo.LoginName.Trim() + "'")[0];
                    GlobalVal.UserInfo.RAID = InfoUser.ROLE; //级别 
                    GlobalVal.UserInfo.UserRkey = InfoUser.RKEY;

                    if (GlobalVal.UserInfo.AD.DepartMent.Trim().Length > 0)
                    {
                        s_temp = GlobalVal.UserInfo.AD.Distinguishedname.Split(',');
                        for (int i = s_temp.Length - 1; i > 0; i--)
                        {
                            if (s_temp[i].Substring(3, s_temp[i].Length - 3).ToLower() != "KB" && s_temp[i].Substring(3, s_temp[i].Length - 3).ToLower() != "com")
                                GlobalVal.UserInfo.DeptName += s_temp[i].Substring(3, s_temp[i].Length - 3);
                        }
                    }
                }
                catch (Exception ee1)
                {
                    log.Info("你不是本厂用户", ee1);
                    Func.ShowWarning("你不是本厂用户，不能登陆本系统！");
                    return false;
                }
                #endregion

                #region 判断系统情况
                if (!GlobalVal.UseSystem && GlobalVal.UserInfo.RAID != 1)
                {
                    Func.ShowInformation("本系统还没有正式使用，正式使用时间为[" + GlobalVal.UseSystemDateTime.ToString() + "]，请稍候！");
                    return false;
                }

                //if (DateTime.Now >= GlobalVal.UpgradeDateTime && GlobalVal.UpgradeDateTime != DateTime.Parse("1900-1-1"))
                //{
                //    Func.ShowInformation("本系统正在升级维护中，请稍候再使用！");
                //    return false;
                //}
                #endregion

                #region 登陆日志
                InfoLog.RKEY = 0;
                InfoLog.LOGIN_ID = GlobalVal.UserInfo.LoginName.Trim();
                InfoLog.LOGIN_NAME = GlobalVal.UserInfo.AD.Cn.Trim();
                InfoLog.LOGIN_IP = GlobalVal.UserInfo.IP.Trim();
                InfoLog.LOGIN_DATE = DateTime.Now;
                InfoLog.PRO_RKEY = InfoUser.RKEY;
                if (BllLog.Add(InfoLog) != 0)
                {
                    Func.ShowWarning("产生日志失败，请联系信息中心！");
                    return false;
                }

                GlobalVal.UserInfo.LOGRKEY = InfoLog.RKEY;
                #endregion

                #endregion

                #region 登陆初始化
                SysMenu.InitMenu(); //初始化菜单全局变量
                InitModulePermissionTable();
                GlobalVal.InitPermission();//获取权限到全局变量 
                #endregion

                return true;
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }
        #endregion

        #region 系统参数初始化 InitSysInfo
        /// <summary>
        /// 系统参数初始化
        /// </summary>
        public static void InitSysInfo()
        {
            DBHelper db = new DBHelper(0);
            try
            {

                DataTable tb;
                string s_SQL = @"
select *
  from FOUNDERPCB_SYSTEM_PARA 
 order by PARA_ID
";
                tb = db.GetDataSet(s_SQL);
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    switch (tb.Rows[i]["PARA_ID"].ToString().Trim())
                    {
                        case "1":
                            GlobalVal.SystemVersion = tb.Rows[i]["PARAMETER_VALUES"].ToString().Trim();
                            break;
                        case "2":
                            GlobalVal.UseSystem = false;
                            if (!Func.IsDateTime(tb.Rows[i]["PARAMETER_VALUES"].ToString().Trim()))
                                GlobalVal.UseSystem = false;
                            else
                            {
                                GlobalVal.UseSystemDateTime = DateTime.Parse(tb.Rows[i]["PARAMETER_VALUES"].ToString().Trim());
                                if (DateTime.Parse(tb.Rows[i]["PARAMETER_VALUES"].ToString().Trim()) <= DateTime.Now)
                                {
                                    GlobalVal.UseSystem = true;
                                    GlobalVal.UseSystemDateTime = DateTime.Parse(tb.Rows[i]["PARAMETER_VALUES"].ToString().Trim());
                                }
                            }
                            break;
                        case "3":
                            GlobalVal.UpgradeDateTime = DateTime.Parse("1900-1-1");
                            if (!Func.IsDateTime(tb.Rows[i]["PARAMETER_VALUES"].ToString().Trim()))
                                GlobalVal.UpgradeDateTime = DateTime.Parse("1900-1-1");
                            else
                                GlobalVal.UpgradeDateTime = DateTime.Parse(tb.Rows[i]["PARAMETER_VALUES"].ToString().Trim());
                            break;
                        case "4":
                            //  GlobalVal.TestPlatform = true;
                            // if (tb.Rows[i]["PARAMETER_VALUES"].ToString().Trim() == "正常")
                            //GlobalVal.TestPlatform = false;
                            break;
                    }

                }
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                System.Environment.Exit(0);
                return;
            }
            finally
            {
                db.CloseConnection();
            }
        }
        #endregion

        #region 登出 LoginOutSys
        /// <summary>
        /// 登出
        /// </summary> 
        public static void LoginOutSys()
        {
            DBHelper db = new DBHelper(0);
            try
            {

                FOUNDERPCB_LOGIN_LOGBLL BllLog = new FOUNDERPCB_LOGIN_LOGBLL(db);
                FOUNDERPCB_LOGIN_LOG InfoLog = new FOUNDERPCB_LOGIN_LOG();
                InfoLog = BllLog.getFOUNDERPCB_LOGIN_LOGByRKEY(GlobalVal.UserInfo.LOGRKEY);
                if (InfoLog.RKEY > 0)
                {
                    InfoLog.LOGIN_OUT = DateTime.Now;
                    BllLog.Update(InfoLog);
                }

                for (int i = 0; i < GlobalVal.UserInfo.Connection.GetUpperBound(0); i++)
                {
                    if (GlobalVal.UserInfo.Connection[i] != null)
                    {
                        GlobalVal.UserInfo.Connection[i].Dispose();
                        GlobalVal.UserInfo.Connection[i] = null;
                    }
                }

                System.Environment.Exit(0);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
            finally
            {
                db.CloseConnection();
            }
        }
        #endregion

        #region 关闭窗口提示信息 ShowCloseChildWindowMsg
        /// <summary>
        /// 关闭窗口提示信息
        /// </summary>
        /// <param name="f">窗口句柄</param>
        public static Boolean ShowCloseChildWindowMsg(Form f)
        {
            try
            {
                if (!GlobalVal.ShowCloseChildMessageEd)
                {
                    MessageBox.Show("\n\r[" + f.AccessibleDescription.Trim() + "]模块共打开[" + f.OwnedForms.Length.ToString() + "]个子窗口，请先退出这些子窗口，再退出本模块！\n\r", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    GlobalVal.ShowCloseChildMessageEd = true;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return false;
            }
        }
        #endregion

        #region 检查系统是否进入维护状态 CheckMaintenanceState
        /// <summary>
        /// 检查系统是否进入维护状态
        /// </summary>
        /// <returns></returns>
        public static Boolean CheckMaintenanceState()
        {
            try
            {
                //if (DateTime.Now >= GlobalVal.UpgradeDateTime && GlobalVal.UpgradeDateTime != DateTime.Parse("1900-1-1"))
                //{
                //    MessageBox.Show("系统正进入升级维护状态，你不能再执行相关操作，请及时退出本系统！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return true;
                //}

                return false;
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return false;
            }
        }
        #endregion

        #region 按数组初始化权限物理表 InitModulePermissionTable
        /// <summary>
        /// 按数组初始化权限物理表
        /// </summary> 
        public static void InitModulePermissionTable()
        {
            DBHelper db = new DBHelper(0);
            try
            {
                FOUNDERPCB_FRIGHTE_01BLL bll_FRIGHTE01 = new FOUNDERPCB_FRIGHTE_01BLL(db);
                FOUNDERPCB_FRIGHTE_01 info_FRIGHTE01 = new FOUNDERPCB_FRIGHTE_01();

                if (bll_FRIGHTE01.FindAllFOUNDERPCB_FRIGHTE_01().Count > 0) return;//存在数据，不初始化

                for (int i = 0; i < isFrom_tb.Rows.Count; i++)
                {
                    if (isFrom_tb.Rows[i]["模块ID"].ToString().Trim().Length > 0)
                    {
                        info_FRIGHTE01.RKEY = 0;
                        info_FRIGHTE01.MODULE_ID = isFrom_tb.Rows[i]["模块ID"].ToString().Trim();
                        info_FRIGHTE01.MODULE_ENGLISH = isFrom_tb.Rows[i]["窗口名称"].ToString().Trim();
                        info_FRIGHTE01.MODULE_DESC = isFrom_tb.Rows[i]["窗口描述"].ToString().Trim();
                        info_FRIGHTE01.MODULE_NAME = isFrom_tb.Rows[i]["窗口名称"].ToString().Trim();
                        info_FRIGHTE01.UP_MODULE_ID = isFrom_tb.Rows[i]["上层模块ID"].ToString().Trim();

                        bll_FRIGHTE01.Add(info_FRIGHTE01);
                    }
                }
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
            finally
            {
                db.CloseConnection();
            }
        }
        #endregion

        #region 获取权限组 GetPwdTb
        public static DataTable GetPwdTb()
        {
            return isFrom_tb;
        }
        #endregion

        #region 登陆日志 LoginLog 暂不用
        /// <summary>
        /// 登陆，记录日志
        /// </summary>
        public void LoginLog()
        {
            try
            {
                DBHelper db = new DBHelper(0);
                FOUNDERPCB_LOGIN_LOG info = new FOUNDERPCB_LOGIN_LOG();
                FOUNDERPCB_USER infoUser = new FOUNDERPCB_USER();
                FOUNDERPCB_USERBLL bllUser = new FOUNDERPCB_USERBLL(db);
                FOUNDERPCB_LOGIN_LOGBLL bll = new FOUNDERPCB_LOGIN_LOGBLL(db);

                try { infoUser = bllUser.FindBySql("LOGIN_ID = '" + GlobalVal.UserInfo.LoginName.Trim() + "'")[0]; }
                catch { infoUser = new FOUNDERPCB_USER(); }

                info.RKEY = 0;
                info.LOGIN_ID = GlobalVal.UserInfo.LoginName.Trim();
                info.LOGIN_NAME = GlobalVal.UserInfo.AD.Cn.Trim();
                info.LOGIN_IP = GlobalVal.UserInfo.IP.Trim();
                info.LOGIN_DATE = Func.GetNowDate();
                info.PRO_RKEY = infoUser.RKEY;

                bll.Add(info);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region 登出日志 LoginOutLog 暂不用
        /// <summary>
        /// 登出，签出日期
        /// </summary>
        public void LoginOutLog()
        {
            try
            {
                DBHelper db = new DBHelper(0);
                FOUNDERPCB_LOGIN_LOG info = new FOUNDERPCB_LOGIN_LOG();
                FOUNDERPCB_USER infoUser = new FOUNDERPCB_USER();
                FOUNDERPCB_USERBLL bllUser = new FOUNDERPCB_USERBLL(db);
                FOUNDERPCB_LOGIN_LOGBLL bll = new FOUNDERPCB_LOGIN_LOGBLL(db);

                try { infoUser = bllUser.FindBySql("LOGIN_ID = '" + GlobalVal.UserInfo.LoginName.Trim() + "'")[0]; }
                catch { infoUser = new FOUNDERPCB_USER(); }

                try
                {
                    info = bll.FindBySql("isnull(LOGIN_OUT,'') = '' and (PRO_RKEY=" + infoUser.RKEY.ToString() + " or LOGIN_ID='" + GlobalVal.UserInfo.LoginName.Trim() + "') order by LOGIN_DATE desc")[0];
                    info.LOGIN_OUT = Func.GetNowDate();
                    bll.Update(info);
                }
                catch
                { }
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion
    }
}