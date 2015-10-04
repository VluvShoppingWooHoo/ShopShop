using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;

namespace VloveImport.web.admin
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string OID = "170";

            ReportBiz report = new ReportBiz();
            DataSet ds = report.GetOrderDetail(int.Parse(OID));
            string name = ds.Tables[4].Rows[0]["ORDER_CODE"].ToString();
            PdfClass pdf = new PdfClass();
            byte[] bytes = pdf.PrintPdf(report.GetOrderDetailReport(ds));

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".pdf");
            Response.BinaryWrite(bytes);
            Response.End();
        }
    }
}