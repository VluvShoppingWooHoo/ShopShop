using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
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
            ReportDataSource ds = new ReportDataSource();
            string ReportPath = WebConfigurationManager.AppSettings["ReportPath"].ToString();
            switch (ReportName)
            {
                case "ORDER":
                    ds = Order_Report("ORDER");
                    break;
            }

            if (ds != null)
            {
                ReportViewer1.ServerReport.ReportPath = Server.MapPath(ReportPath + ReportName);
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(ds);
            }
        }

        #region
        protected ReportDataSource Order_Report(string Name)
        {            
            DataTable dt = new DataTable();
            Report
            ReportDataSource ds = new ReportDataSource(Name, dt);
            return ds;
        }
        #endregion
    }
}