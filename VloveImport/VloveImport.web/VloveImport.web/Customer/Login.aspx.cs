using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string url = Request.QueryString["u"] == null ? "" : DecryptData(Request.QueryString["u"].ToString());
                ViewState["url"] = url;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {            
            LogonBiz Logon = new LogonBiz();
            CustomerData Cust = new CustomerData();
            Cust = Logon.LogonDBCustomer(txtUser.Text, txtPass.Text);
            if (Cust != null)
            {
                Session["User"] = Cust;
                if (ViewState["url"] != null && ViewState["url"].ToString() != "")
                    Response.Redirect(ViewState["url"].ToString());   

                Response.Redirect("~/Index.aspx");                
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtPass.Text = "";
        }
    }
}