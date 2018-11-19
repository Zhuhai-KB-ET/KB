using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KB.FUNC;
using KB.DAL;

namespace KB.Module
{
    /// <summary>
    /// 模版
    /// </summary>
    public partial class MainModule : Form
    {
        #region 数据连接
        private DBHelper dbconnection;
        public DBHelper DBConnection
        {
            get { return dbconnection; }
            set { dbconnection = value; }
        }
        #endregion

        #region 返回值
        private string returnValue = "";
        public string ReturnValue
        {
            get { return returnValue; }
            set { returnValue = value; }
        }
        #endregion 

        #region 创建
        public MainModule()
        {
            InitializeComponent();
        }
        #endregion

        #region MainModule_Load
        private void MainModule_Load(object sender, EventArgs e)
        {
            try
            { 
                #region 权限设定
                SysMenu.SetModulePermission(this);
                #endregion 
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region MainModule_FormClosing
        private void MainModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                #region 旧
                //if (this.AccessibleDescription == null) this.AccessibleDescription = "";

                //if (GlobalVal.ShowCloseMessage)
                //{
                //    if (this.OwnedForms.Length > 0)
                //    {
                //        //协调显示关闭信息 
                //        try
                //        {
                //            if (!GlobalVal.ShowCloseChildMessageEd)
                //                MessageBox.Show("\n\r[" + this.AccessibleDescription.Trim() + "]模块共打开[" + this.OwnedForms.Length.ToString() + "]个子窗口，请先退出这些子窗口，再退出本模块！\n\r", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //            else
                //                GlobalVal.ShowCloseChildMessageEd = false;
                //        }
                //        catch { }

                //        e.Cancel = true;
                //        return;
                //    }
                //    else 
                //        if (MessageBox.Show("\r\n你确认要退出[" + this.AccessibleDescription.Trim() + "]模块吗？\r\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                //        {
                //            try
                //            { 
                //                //e.Cancel = true;
                //                GlobalVal.ShowCloseChildMessageEd = true; 
                //            }
                //            catch (Exception e1)
                //            {
                //                log.PrintInfo(e1);
                //                return;
                //            }
                //        }
                //        else
                //        {
                //            try
                //            {
                //                e.Cancel = true;
                //            }
                //            catch (Exception e1)
                //            {
                //                log.RecordInfo(e1);
                //                return;
                //            }
                //        }
                //} 
                #endregion

                if (this.AccessibleDescription == null) this.AccessibleDescription = "";
                if (this.Text == null) this.Text = "";

                if (GlobalVal.ShowCloseMessage)
                {
                    if (this.OwnedForms.Length <= 0)
                    {
                        if (e.CloseReason.ToString().Trim() == "UserClosing")
                        {
                            if (MessageBox.Show("\r\n你确认要退出[" + this.AccessibleDescription.Trim() + "]模块吗？\r\n", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            {
                                e.Cancel = true;
                                return;
                            }
                        }

                        GlobalVal.ShowCloseChildMessageEd = false;
                    }
                    else
                    {
                        if (!SysMenu.ShowCloseChildWindowMsg(this)) GlobalVal.ShowCloseChildMessageEd = false;
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception e1)
            {
                log.RecordInfo(e1);
                return;
            }
        }
        #endregion   

    }
}
