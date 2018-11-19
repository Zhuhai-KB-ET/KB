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
    /// 子窗口模版
    /// </summary>
    public partial class ChildModule : Form
    {
        #region 数据连接
        private DBHelper dbconnection;
        public DBHelper DBConnection
        {
            get { return dbconnection; }
            set { dbconnection = value; }
        }
        #endregion

        #region 接收值
        private string receiveValue = "";
        public string ReceiveValue
        {
            get { return receiveValue; }
            set { receiveValue = value; }
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
        public ChildModule()
        {
            InitializeComponent();
        }
        #endregion

        #region ChildModule_Load
        private void ChildModule_Load(object sender, EventArgs e)
        {
            try
            {
                #region 权限设定
                try
                {
                    this.AccessibleName        = this.Owner.AccessibleName.Trim();
                    this.AccessibleDescription = this.Owner.AccessibleDescription.Trim();
                }
                catch { }

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

        #region ChildModule_FormClosing
        private void ChildModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.AccessibleDescription == null) this.AccessibleDescription = "";
                if (this.Text == null) this.Text = "";

                if (GlobalVal.ShowCloseMessage)
                {
                    if (this.OwnedForms.Length <= 0)
                    {
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

        #region ChildModule_FormClosed
        private void ChildModule_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        #endregion
    }
}
