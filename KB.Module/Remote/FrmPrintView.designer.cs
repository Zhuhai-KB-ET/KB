namespace KB.Module.Remotes
{
    partial class FrmPrintView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rptViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptViewer
            // 
            this.rptViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rptViewer.ServerReport.DisplayName = "Report1";
            this.rptViewer.ServerReport.ReportPath = "/报表/快板厂/计划部/新产品统计表";
            this.rptViewer.ServerReport.ReportServerUrl = new System.Uri("http://acserp01/Reportserver", System.UriKind.Absolute);
            this.rptViewer.Size = new System.Drawing.Size(557, 468);
            this.rptViewer.TabIndex = 1;
            this.rptViewer.Print += new System.ComponentModel.CancelEventHandler(this.rptViewer_Print);
            // 
            // FrmPrintView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 468);
            this.Controls.Add(this.rptViewer);
            this.Name = "FrmPrintView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPrintView";
            this.Load += new System.EventHandler(this.FrmPrintView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptViewer;
    }
}