using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using KB.FUNC;

namespace KB.Module
{
    public partial class ControlButton : UserControl
    {
        #region 构建控件
        public ControlButton()
        {
            InitializeComponent();
        }
        #endregion

        #region 跟随界面调整
        private void ControlButton_Resize(object sender, EventArgs e)
        {
            button1.Width = this.Width;
            button1.Height = this.Height;
        }
        #endregion

        #region ControlButton_Load
        private void ControlButton_Load(object sender, EventArgs e)
        {
             

        }
        #endregion

        #region 增加属性
        public ImageList ImageList
		{
            get { return button1.ImageList; }
            set { button1.ImageList = value; }
		}
        public int ImageIndex
        {
            get { return button1.ImageIndex; }
            set { button1.ImageIndex = value; }
        }
        #endregion

        private  void button1_Click(object sender, EventArgs e)
        {

        }



    }
}
