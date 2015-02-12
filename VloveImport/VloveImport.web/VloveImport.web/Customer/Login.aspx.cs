using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;

namespace VloveImport.web.Customer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Focus();
                return;
            }
            if (txtPass.Text == "")
            {
                txtPass.Focus();
                return;
            }

            LogonBiz Logon = new LogonBiz();
            DataTable dt = new DataTable();
            dt = Logon.LogonDBUser(txtUser.Text, txtPass.Text);
            if (dt != null && dt.Rows.Count > 0)
            {

            }
        }
    }
}