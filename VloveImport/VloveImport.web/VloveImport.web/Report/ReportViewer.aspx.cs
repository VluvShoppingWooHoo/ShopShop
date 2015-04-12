using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.web.App_Code;

namespace VloveImport.web.Report
{
    public partial class ReportViewer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ReportName = Request.QueryString["RN"] == null ? "" : DecryptData(Request.QueryString["RN"]);
            SetReport(ReportName);
        }

        protected void SetReport(string ReportName)
        {
            string ReportPath = WebConfigurationManager.AppSettings["ReportPath"].ToString();
            switch (ReportName)
            {
                case "ORDER":
                    break;
            }

            ReportViewer1.ServerReport.ReportPath = ReportPath + ReportName;
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        }

        #region
        protected void Order_Report()
        {

        }
        #endregion
    }
}