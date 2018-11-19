using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.PopWinForm
{
    public partial class FrmApproval : KB.Module.ChildModule
    {
        #region 参数
        //data0011RKEY
        public decimal id_rkey = 0;
        //是否能编辑
        public Boolean ib_Edit = true;
        //内容
        public int ii_Sort = 0;
        public decimal id_Sort_RKEY = 0;
        #endregion

        #region 创建窗口
        IL.FrmApprovalIL frmApprovalIL = null;
        public FrmApproval()
        {
            InitializeComponent();
        }
        #endregion

        #region FrmApproval_Load
        private void FrmApproval_Load(object sender, EventArgs e)
        {
            frmApprovalIL = new KB.Module.PopWinForm.IL.FrmApprovalIL(this);

            frmApprovalIL.FrmNotepad_Load(sender, e);
        }
        #endregion

        #region buttonFind
        private void buttonFind_MouseClick(object sender, MouseEventArgs e)
        {
            frmApprovalIL.buttonFind_MouseClick(sender, e);
        }
        private void buttonFind_KeyDown(object sender, KeyEventArgs e)
        {
            frmApprovalIL.buttonFind_KeyDown(sender, e);
        }
        #endregion

        #region buttonCancel
        private void buttonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            frmApprovalIL.buttonCancel_MouseClick(sender, e);
        } 
        private void buttonCancel_KeyDown(object sender, KeyEventArgs e)
        {
            frmApprovalIL.buttonCancel_KeyDown(sender, e);
        }
        #endregion

        #region buttonOK
        private void buttonOK_MouseClick(object sender, MouseEventArgs e)
        {
            frmApprovalIL.buttonOK_MouseClick(sender, e);
        }
        private void buttonOK_KeyDown(object sender, KeyEventArgs e)
        {
            frmApprovalIL.buttonOK_KeyDown(sender, e);
        }
        #endregion

        #region textBox_TextChanged
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            frmApprovalIL.textBox_TextChanged(sender, e);
        }
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            frmApprovalIL.textBox_KeyUp(sender, e);
        }
        #endregion 
    }
}
