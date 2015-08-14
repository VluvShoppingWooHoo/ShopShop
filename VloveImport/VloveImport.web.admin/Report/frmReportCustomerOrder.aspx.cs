using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.web.admin.App_Code;

namespace VloveImport.web.admin.Report
{
    public partial class frmReportCustomerOrder : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucCalendar1.SET_DATE(DateTime.Now.AddMonths(-2));
                ucCalendar2.SET_DATE_DEFAULT();
            }
        }

        private void BindDataReport()
        {
            DataSet ds = new DataSet();
            AdminBiz adminBiz = new AdminBiz();
            ds = adminBiz.GetReportCustomerOrder(ucCalendar1.GET_DATE_TO_DATE().GetValueOrDefault(), ucCalendar2.GET_DATE_TO_DATE().GetValueOrDefault(), txtCusCode.Text.Trim(), "");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDataReport();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ucCalendar1.SET_DATE(DateTime.Now.AddMonths(-2));
            ucCalendar2.SET_DATE_DEFAULT();
            txtCusCode.Text = "";
            txtCusName.Text = "";
        }
    }
}