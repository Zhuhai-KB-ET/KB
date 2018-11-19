using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using KB.FUNC;
using KB.DAL;
using KB.Models;
using KB.BLL;
using KB.Module;
using KB.Model;

namespace KB.Module.E0280
{
    public partial class Frm_Analysis : ChildModule
    {
        DBHelper db = new DBHelper();
        public string source_code;

        #region 创建窗体
        public Frm_Analysis()
        {
            InitializeComponent();
        }
        #endregion

        #region Load
        private void Frm_Analysis_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(source_code))
            {
                MessageBox.Show("参数未设置");
                this.Close();
                return;
            }

            if (source_code == "9107")
                this.Text = "小包分析代码设置";
            else if (source_code == "9108")
                this.Text = "外箱分析代码设置";

            #region 分析代码名称获取
           
            
            FOUNDERPCB_ANALYSIS anainfo = new FOUNDERPCB_ANALYSIS();
            FOUNDERPCB_ANALYSISBLL anabll = new FOUNDERPCB_ANALYSISBLL(db);
            if (anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=1").Count > 0)
            {
                int rkey = anabll.GetModelList("SOURCE_CODE='" + source_code + "' AND ID_KEY=1")[0].RKEY;
                anainfo = anabll.GetModel(rkey);
                if (anainfo.ANS_NAME.Trim().Length > 0)
                {
                    textBox1.Text = anainfo.ANS_NAME.Trim();
                }
            }
            if (anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=2").Count > 0)
            {
                int rkey = anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=2")[0].RKEY;
                anainfo = anabll.GetModel(rkey);
                if (anainfo.ANS_NAME.Trim().Length > 0)
                {
                    textBox2.Text = anainfo.ANS_NAME.Trim();
                }
            }
            if (anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=3").Count > 0)
            {
                int rkey = anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=3")[0].RKEY;
                anainfo = anabll.GetModel(rkey);
                if (anainfo.ANS_NAME.Trim().Length > 0)
                {
                    textBox3.Text = anainfo.ANS_NAME.Trim();
                }
            }
            if (anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=4").Count > 0)
            {
                int rkey = anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=4")[0].RKEY;
                anainfo = anabll.GetModel(rkey);
                if (anainfo.ANS_NAME.Trim().Length > 0)
                {
                    textBox4.Text = anainfo.ANS_NAME.Trim();
                }
            }
            if (anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=5").Count > 0)
            {
                int rkey = anabll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=5")[0].RKEY;
                anainfo = anabll.GetModel(rkey);
                if (anainfo.ANS_NAME.Trim().Length > 0)
                {
                    textBox5.Text = anainfo.ANS_NAME.Trim();
                }
            }





            #endregion
        }
        #endregion

        #region 保存
        private void button1_Click(object sender, EventArgs e)
        {
            FOUNDERPCB_ANALYSIS info = new FOUNDERPCB_ANALYSIS();
            FOUNDERPCB_ANALYSISBLL bll = new FOUNDERPCB_ANALYSISBLL(db);

            #region 表不存在则创建
            if (!db.TabExists("FOUNDERPCB_ANALYSIS"))
            {

                string sql = @"CREATE TABLE [dbo].[FOUNDERPCB_ANALYSIS](
	                            [RKEY] [int] IDENTITY(1,1) NOT NULL,
	                            [SOURCE_CODE] [varchar](20) NULL,
	                            [ID_KEY] [int] NULL,
	                            [ANS_NAME] [varchar](50) NULL,
                             CONSTRAINT [PK_FOUNDERPCB_ANALYSIS] PRIMARY KEY CLUSTERED 
                            (
	                            [RKEY] ASC
                            )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
                            ) ON [PRIMARY]";
                db.ExecuteNonQuery(sql);
            }
            #endregion

            #region 事务处理
            using (SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID)))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandTimeout = 360;
                    try
                    {
                        #region 分析代码1
                        if (bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=1").Count > 0)
                        {
                            int rkey = bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=1")[0].RKEY;
                            info = bll.GetModel(rkey);
                            info.ANS_NAME = textBox1.Text.Trim();
                            bll.Update(cmd,conn,trans,info);
                        }
                        else
                        {

                            info.SOURCE_CODE = source_code;
                            info.ID_KEY = 1;
                            info.ANS_NAME = textBox1.Text.Trim();
                            bll.Add(cmd,conn,trans,info);

                        }
                        #endregion

                        #region 分析代码2
                        if (bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=2").Count > 0)
                        {
                            int rkey = bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=2")[0].RKEY;
                            info = bll.GetModel(rkey);
                            info.ANS_NAME = textBox2.Text.Trim();
                            bll.Update(cmd, conn, trans, info);
                        }
                        else
                        {

                            info.SOURCE_CODE = source_code;
                            info.ID_KEY = 2;
                            info.ANS_NAME = textBox2.Text.Trim();
                            bll.Add(cmd, conn, trans, info);

                        }
                        #endregion

                        #region 分析代码3
                        if (bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=3").Count > 0)
                        {
                            int rkey = bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=3")[0].RKEY;
                            info = bll.GetModel(rkey);
                            info.ANS_NAME = textBox3.Text.Trim();
                            bll.Update(cmd, conn, trans, info);
                        }
                        else
                        {

                            info.SOURCE_CODE = source_code;
                            info.ID_KEY = 3;
                            info.ANS_NAME = textBox3.Text.Trim();
                            bll.Add(cmd, conn, trans, info);

                        }
                        #endregion

                        #region 分析代码4
                        if (bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=4").Count > 0)
                        {
                            int rkey = bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=4")[0].RKEY;
                            info = bll.GetModel(rkey);
                            info.ANS_NAME = textBox4.Text.Trim();
                            bll.Update(cmd, conn, trans, info);
                        }
                        else
                        {

                            info.SOURCE_CODE = source_code;
                            info.ID_KEY = 4;
                            info.ANS_NAME = textBox4.Text.Trim();
                            bll.Add(cmd, conn, trans, info);

                        }
                        #endregion

                        #region 分析代码5
                        if (bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=5").Count > 0)
                        {
                            int rkey = bll.GetModelList("SOURCE_CODE='"+source_code+"' AND ID_KEY=5")[0].RKEY;
                            info = bll.GetModel(rkey);
                            info.ANS_NAME = textBox5.Text.Trim();
                            bll.Update(cmd, conn, trans, info);
                        }
                        else
                        {

                            info.SOURCE_CODE = source_code;
                            info.ID_KEY = 5;
                            info.ANS_NAME = textBox5.Text.Trim();
                            bll.Add(cmd, conn, trans, info);

                        }
                        #endregion

                        trans.Commit();
                        MessageBox.Show("保存成功！");
                    }
                    catch (Exception ee)
                    {
                        trans.Rollback();//异常回滚
                        log.PrintInfo(ee);

                        MessageBox.Show("数据处理失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            #endregion

        }
        #endregion

    }
}
