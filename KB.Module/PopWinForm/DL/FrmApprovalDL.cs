using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing; 
using System.Windows.Forms;
using KB.FUNC;
using KB.DAL;
using KB.Models;
using KB.BLL;

namespace KB.Module.PopWinForm.DL
{
    /// <summary>
    /// 数据层
    /// </summary>
    public partial class FrmApprovalDL
    {
        #region 实例化
        FrmApproval Frm;
        public FrmApprovalDL(FrmApproval psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            {
                DATA0011 info = new DATA0011();
                DATA0011BLL bll = new DATA0011BLL(Frm.DBConnection);
                DataTable tb;
                string s_SQL = "";

                info = bll.getDATA0011ByRKEY(Frm.id_rkey);
                if (info.RKEY > 0)
                    Frm.textBox.Text = info.NOTE_PAD_LINE_1.Trim() + info.NOTE_PAD_LINE_2.Trim() + info.NOTE_PAD_LINE_3.Trim() + info.NOTE_PAD_LINE_4.Trim();
                else
                    Frm.textBox.Text = "";

                if (Frm.ii_Sort == 500)
                {//拒绝
                    s_SQL = @"
select *
  from data0011 with (nolock),data0500 with (nolock)
 where data0011.FILE_POINTER      = data0500.rkey 
   and data0011.SOURCE_TYPE       = 500
   and data0500.CUSTOMER_PART_PTR = " + Frm.id_Sort_RKEY.ToString() + @"
 order by data0011.rkey
"; 
                }
                if (Frm.ii_Sort == 501)
                {//拒绝
                    s_SQL = @"
select *
  from data0011 with (nolock),data0500 with (nolock)
 where data0011.FILE_POINTER      = data0500.rkey 
   and data0011.SOURCE_TYPE       = 501
   and data0500.CUSTOMER_PART_PTR = " + Frm.id_Sort_RKEY.ToString() + @"
 order by data0011.rkey
";
                }
                tb = bll.getDataSet(s_SQL);
                Frm.textBoxOLD.Text = "";
                if (tb.Rows.Count > 0)
                {
                    Frm.textBoxOLD.Text += tb.Rows[0]["NOTE_PAD_LINE_1"].ToString().Trim();
                    Frm.textBoxOLD.Text += tb.Rows[0]["NOTE_PAD_LINE_2"].ToString().Trim();
                    Frm.textBoxOLD.Text += tb.Rows[0]["NOTE_PAD_LINE_3"].ToString().Trim();
                    Frm.textBoxOLD.Text += tb.Rows[0]["NOTE_PAD_LINE_4"].ToString().Trim();
                    Frm.textBoxOLD.Text += "\r\n\r\n";
                } 
                if (!Frm.ib_Edit)
                {
                    Frm.textBox.ReadOnly = true;
                    Frm.buttonFind.Visible = false;
                }
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
