using System;
using System.Collections.Generic;

using System.Text;

namespace PrintHelper
{
    class RDLReport
    {
        static string m_ReportServerURL;
        static string m_ReportPath;
        static string m_ReportName;

        static RDLReport()
        {
        }

        public RDLReport(string reportServerURL, string reportPath, string reportName)
        {
            m_ReportServerURL = reportServerURL;
            m_ReportPath = reportPath;
            m_ReportName = reportName;
        }

        /// <summary>
        /// sample :http://172.21.34.73/reportserver
        /// </summary>
        static public string ReportServerURL
        {
            set{m_ReportServerURL = value;}
            get { return m_ReportServerURL; }
        }

        /// <summary>
        /// sample:/reportserver/杂项验收单
        /// </summary>
        static public string ReportPath
        {
            set { m_ReportPath = value; }
            get { return m_ReportPath; }
        }

        static public string ReportName
        {
            set { m_ReportName = value; }
            get { return m_ReportName; }
        }
    }
}
