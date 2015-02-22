using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.data;

namespace VloveImport.web.UserControls
{
    public partial class ucCustomerStatus : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void CheckLogin(bool Check)
        {
            if (Check)
            {
                hlLogin.Visible = false;
                hlRegis.Visible = false;
                lbCustomer.Text = "สวัสดี คุณ " + ((CustomerData)Session["User"]).Cus_Name;
                lbCustomer.Visible = true;
                hlLogout.Visible = true;
            }
            else
            {
                hlLogin.Visible = true;
                hlRegis.Visible = true;
                lbCustomer.Text = "";
                lbCustomer.Visible = false;
                hlLogout.Visible = false;
            }
        }        
    }
}