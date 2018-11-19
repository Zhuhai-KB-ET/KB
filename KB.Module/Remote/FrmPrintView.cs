using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using PrintHelper;
using KB.DAL;
using KB.Models;

namespace KB.Module.Remotes
{
    public partial class FrmPrintView : Form
    {

      
       public  string reportServerURL="";
       public string reportPath="";
       public string reportName="";
       public int top;
       public int buttom;
       public int left;
       public int right;
       public bool printSet = true;

       public bool quickPrint = false;
       public string parmName = "";
       public string parmValue = "";

        #region 创建窗体
       public FrmPrintView()
        {


            
            InitializeComponent();
        }

       public FrmPrintView(string formName, string reportCode, string reportDesc, string parm)
       {


           try
           {
               DBHelper db = new DBHelper();
               KB.Models.RPT_SETPARM info = new KB.Models.RPT_SETPARM();
               // FOUNDERPCB.BLL. bll = new FOUNDERPCB.Models.RPT_SETPARM(db);
               KB.BLL.RPT_SETPARMBLL bll = new KB.BLL.RPT_SETPARMBLL(db);
               KB.Models.RPT_SERVERPATH info1 = new KB.Models.RPT_SERVERPATH();
               KB.BLL.RPT_SERVERPATHBLL bll1 = new KB.BLL.RPT_SERVERPATHBLL(db);
               string sql;
               sql = string.Format(@"select rkey,REPORT_PTR from RPT_QUICKREPORT_LINK where FROM_NAME='{0}' AND REPORT_NAME='{1}'", formName, reportCode);
               DataTable dt = new DataTable();
               dt = db.GetDataSet(sql);
               if (dt.Rows.Count == 0)
               {
                   sql = string.Format(@"INSERT INTO RPT_QUICKREPORT_LINK (FROM_NAME,REPORT_NAME,REPORT_DESC,REPORT_PTR,EMP_PTR) VALUES('{0}','{1}','{2}',0,0)", formName, reportCode, reportDesc);
                   db.ExecuteNonQuery(sql);
                   // return 0;
                   this.Close();
               }
               else
               {
                   int serverPtr = 0;
                   int rkey = int.Parse(dt.Rows[0]["REPORT_PTR"].ToString());
                   if (rkey > 0)
                   {
                       info = bll.GetModel(rkey);
                       if (info.ACTIVE_FLAG == 1)
                       {
                           serverPtr = (int)info.SERVER_PTR;
                           info1 = bll1.GetModel(serverPtr);

                           // FOUNDERPCB.Module.Remote.FrmPrintView fm = new FOUNDERPCB.Module.Remote.FrmPrintView();
                           reportServerURL = info1.SERVER_PATH;
                           reportPath = info.REPORT_PATH.Trim() + "/" + info.REPORT_NAME.Trim() + "";
                           reportName = info.REPORT_NAME;
                           top = info.MARGINS_TOP * 4;
                           buttom = info.MARGINS_BUTTOM * 4;
                           left = info.MARGINS_LEFT * 4;
                           right = info.MARGINS_RIGHT * 4;
                           if (info.CHOOSE_PAYE == 0)
                           {
                               printSet = true;
                           }
                           else
                           {

                               printSet = false;
                           }
                           quickPrint = true;
                           parmName = info.REPORT_PARM.Trim();
                           parmValue = parm;
                          
                           //Show();
                           //Activate();
                           // return 1;
                           this.Show();
                       }
                       else
                       {
                           // return 2;
                           this.Close();
                       }
                   }
                   else
                   {
                       //return 0;
                       this.Close();
                   }

               }



           }
           catch (Exception ex)
           {
               // log.Error(ex.Message.ToString());
               //return -1;
               this.Close();
           }

           InitializeComponent();

           WindowState = FormWindowState.Maximized;
           RDLReport.ReportServerURL = reportServerURL;
           RDLReport.ReportPath = reportPath;
           RDLReport.ReportName = reportName;

           LoadReport();
           this.TopMost = true;
       }
        #endregion



        private void FrmPrintView_Load(object sender, EventArgs e)
        {
            //string reportServerURL;
            //string reportPath;
            //string reportName;
            //reportServerURL = "http://pcberprs/Reportserver";
            //reportPath = "";//"/报表/富山/物控/杂项验收单/杂项验收单";
            //reportName = "Viewer";
            //this.WindowState = FormWindowState.Maximized;
         
        }
        
        private void rptViewer_Print(object sender, CancelEventArgs e)
        {
            int l, r, t, b;
          
            l = left;
            r = right;
            b = buttom;
            t = top;
           
            //do nothing
       
            e.Cancel = true;

            //customer print
            PrintPDF(l, r, t, b, printSet);
           
           

          
        }

        private void LoadReport()
        {

            this.Text = RDLReport.ReportName;

            try
            {
                this.rptViewer.ProcessingMode = ProcessingMode.Remote;
                this.rptViewer.ServerReport.ReportServerUrl = new Uri(RDLReport.ReportServerURL);
                this.rptViewer.ServerReport.ReportPath = RDLReport.ReportPath;

                if (quickPrint == true)
                {
                    this.rptViewer.ShowParameterPrompts = false;
                    //this.rptViewer.par
                    //this.rptViewer.LocalReport.SetParameters("in_number","%");
                    Microsoft.Reporting.WinForms.ReportParameter[] rp = new ReportParameter[1];
                    rp[0] = new ReportParameter(parmName, parmValue);

                    this.rptViewer.ServerReport.SetParameters(rp);
                }
                
               // this.rptViewer..SetParameters(rp);

                this.rptViewer.RefreshReport();
            }
            catch (Exception e)
            {
               // MessageBox.Show(e.Message);
            }
        }

        private void PrintPDF(int distinctLeft,int distinctRight,int distinctTop,int distinctButtom,bool setPageSize)
        {
            //检查主体是否有数据
            if (rptViewer.ServerReport.GetTotalPages() < 1) return;

            //直接 打印

            ReportPrintDocument rp = new ReportPrintDocument(this.rptViewer.ServerReport, distinctLeft, distinctRight, distinctTop, distinctButtom);
            //rp.distinctButtom = distinctButtom;
            //rp.distinctLeft = distinctLeft;
            //rp.distinctRight = distinctRight;
            //rp.distinctTop = distinctTop;
           // MessageBox.Show(distinctTop.ToString() + "," + distinctButtom.ToString() + "," + left.ToString() + "," + right.ToString() + "234");
            if (setPageSize)
            {
                rp.Print();
                return;
            }
            else
            {

                // Allow the user to choose the page range he or she would
                // like to print.
                PrintDialog printDialog = new PrintDialog();
                printDialog.AllowSomePages = true;


                // Show the help button.
                printDialog.ShowHelp = true;


                // Set the Document property to the PrintDocument for 
                // which the PrintPage Event has been handled. To display the
                // dialog, either this property or the PrinterSettings property 
                // must be set 
                printDialog.Document = rp;


                DialogResult result = printDialog.ShowDialog();


                // If the result is OK then print the document.
                if (result == DialogResult.OK)
                {
                    rp.Print();//开始打印
                }
            }
        }
    }
}
