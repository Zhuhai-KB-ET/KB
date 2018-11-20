using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KB.Model;
using KB.DAL;
using KB.BLL;
using KB.FUNC;
namespace KB
{
    public partial class ModelARequest : Form
    {
        DBHelper db = new DBHelper();
        public string ID;

        public ModelARequest()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_save_Click(object sender, EventArgs e)
        {
            //引入实体
            DATA0001 info = new DATA0001();
            DATA0001BLL bll = new DATA0001BLL(db);

            #region 表不存在则创建
            if (!db.TabExists("DATA0001"))
            {

                string sql = @"CREATE TABLE [dbo].[DATA0001](
	                            [RKEY] [int] NOT NULL,
	                            [ID] [int] NOT NULL,
	                            [APPLYTIME] [datetime] NULL,
	                            [DEPT] [nchar](10) NULL,
	                            [NAME] [nchar](10) NULL,
	                            [NUMBER] [nchar](10) NULL,
	                            [KIND] [nchar](10) NULL,
	                            [TYPE] [nchar](10) NULL,
	                            [REACHTIME] [datetime] NULL,
	                            [PROTYPE] [nchar](10) NULL,
	                            [MAPNUMB] [nchar](10) NULL,
	                            [ATTACH] [nchar](10) NULL,
	                            [REASON] [nchar](10) NULL,
                             CONSTRAINT [PK_DATA0001] PRIMARY KEY CLUSTERED 
                            (
	                            [RKEY] ASC,
	                            [ID] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
                        if (bll.GetModelList("ID='" + ID + "' ").Count > 0)
                        {
                            int rkey = bll.GetModelList("ID='" + ID + "' ")[0].RKEY;
                            info = bll.GetModel(rkey);
                            //bll.Update(cmd, conn, trans, info);
                        }
                        else
                        {

                            info.ID = int.Parse(txt_ID.ToString());
                            info.APPLYTIME = DateTime.Parse(txt_APPLYTIME.ToString());
                            info.DEPT = txt_DEPT.ToString();
                            info.NAME = txt_NAME.ToString();
                            info.NUMBER = txt_NUMBER.ToString();
                            info.KIND = txt_KIND.ToString();
                            info.TYPE = txt_TYPE.ToString();
                            info.REACHTIME = txt_REACHTIME.ToString();
                            info.PROTYPE = txt_PROTYPE.ToString();
                            info.MAPNUMB = txt_MAPNUMB.ToString();
                            info.ATTACH = txt_ATTACH.ToString();
                            info.REASON = txt_REASON.ToString();

                            bll.Add(cmd, conn, trans, info);

                        }
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
                    #endregion

                }
            }
        }
    }
}
