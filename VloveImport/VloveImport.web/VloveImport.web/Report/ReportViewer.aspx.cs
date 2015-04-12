using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using VloveImport.biz;
using VloveImport.web.App_Code;

namespace VloveImport.web.Report
{
    public partial class ReportViewer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ReportName = Request.QueryString["RN"] == null ? "" : DecryptData(Request.QueryString["RN"]);
            string ID = Request.QueryString["ID"] == null ? "" : DecryptData(Request.QueryString["ID"]);
            SetReport(ReportName, ID);
        }

        protected void SetReport(string ReportName, string ID)
        {
            ReportDataSource ds = new ReportDataSource();
            string ReportPath = WebConfigurationManager.AppSettings["ReportPath"].ToString();
            switch (ReportName)
            {
                case "ORDER":
                    Int32 OID = ID == "" ? 0 : Convert.ToInt32(ID);
                    ds = Order_Report("ORDER", OID);
                    break;
            }

            if (ds != null)
            {
                ReportViewer1.ServerReport.ReportPath = Server.MapPath(ReportPath + "Report1");
                ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(ds);
            }
        }

        #region
        protected ReportDataSource Order_Report(string Name, Int32 OID)
        {            
            DataTable dt = new DataTable();
            ReportBiz biz = new ReportBiz();
            dt = biz.GetOrderDetail(OID);
            if (dt != null && dt.Rows.Count > 0)
            {
                ReportDataSource ds = new ReportDataSource(Name, dt);
                return ds;
            }
            else
                return null;
        }
        #endregion
    }
}