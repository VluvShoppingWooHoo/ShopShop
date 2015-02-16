using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.util;

namespace VloveImport.web.Customer
{
    public partial class Activate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EncrypUtil en = new EncrypUtil();
            string Email = Request.QueryString["e"] == null ? "" : en.DecryptData(Request.QueryString["e"]);
            string Pass = Request.QueryString["c"] == null ? "" : en.DecryptData(Request.QueryString["c"]);
            UpdateActivateCustomer(Email, Pass);
        }

        protected void UpdateActivateCustomer(string Email, string Pass)
        {
            LogonBiz Logon = new LogonBiz();
            Logon.UpdateActivateCustomer(Email, Pass);
        }
    }
}