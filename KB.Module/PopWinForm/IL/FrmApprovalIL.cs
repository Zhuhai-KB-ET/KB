using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KB.FUNC;
using KB.DAL;

namespace KB.Module.PopWinForm.IL
{
    /// <summary>
    /// 业务中间层
    /// </summary>
    public partial class FrmApprovalIL
    {
        #region 实例化
        DL.FrmApprovalDL frmApprovalDL = null;
        FrmApproval Frm;
        public FrmApprovalIL(FrmApproval psFrm)
        {
            Frm = psFrm;
            Frm.DBConnection = new DBHelper(psFrm);
        }
        #endregion

        #region FrmNotepad_Load
        public void FrmNotepad_Load(object sender, EventArgs e)
        {
            try
            {
                frmApprovalDL = new KB.Module.PopWinForm.DL.FrmApprovalDL(Frm);

                frmApprovalDL.BinData("1=1");
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonFind
        public void buttonFind_MouseClick(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PopWinForm.FrmData0013 ChildFrm = new PopWinForm.FrmData0013();
            try
            {
                ChildFrm.ShowDialog(Frm);
                if (ChildFrm.DialogResult == DialogResult.OK)
                {
                    Frm.textBox.Text = ChildFrm.ReturnValue.Split('|')[3].Trim();                    
                }
                ChildFrm.Close();
            }
            catch (Exception e1)
            {
                ChildFrm.Close();
                log.PrintInfo(e1);
                return;
            }
        }
        public void buttonFind_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) buttonFind_MouseClick(null, null);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonCancel
        public void buttonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Frm.ReturnValue = "";
                Frm.DialogResult = DialogResult.Cancel; 
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        public void buttonCancel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) buttonCancel_MouseClick(null, null);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonOK
        public void buttonOK_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {    
                Frm.ReturnValue = Frm.textBox.Text.Trim();
                Frm.DialogResult = DialogResult.OK; 
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        public void buttonOK_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) buttonOK_MouseClick(null, null);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region textBox_TextChanged
        public void textBox_TextChanged(object sender, EventArgs e)
        {

        }
        public void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Frm.textBox.Text += "\r\n";
                Frm.textBox.SelectionStart = Frm.textBox.Text.Length;
                Frm.textBox.SelectionLength = 0;
                Frm.textBox.ScrollToCaret();

            }
        }
        #endregion
    }
}
