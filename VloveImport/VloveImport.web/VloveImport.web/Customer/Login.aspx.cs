using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.Customer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if (txtUser.Text == "")
            //{
            //    txtUser.Focus();
            //    return;
            //}
            //if (txtPass.Text == "")
            //{
            //    txtPass.Focus();
            //    return;
            //}

            LogonBiz Logon = new LogonBiz();
            CustomerData Cust = new CustomerData();
            Cust = Logon.LogonDBCustomer(txtUser.Text, txtPass.Text);
            if (Cust != null)
            {
                Session["User"] = Cust;
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