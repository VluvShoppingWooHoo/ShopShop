using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VloveImport.web.Customer
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgbtn_SendEmail_Click(object sender, ImageClickEventArgs e)
        {
            MadoalPop_Email.Show();

            ucEmail1.SetEmailFrom("");
            ucEmail1.SetEmail("info@iloveimport.com");
            //ucEmail1.SetEmail_To_Enabled();
        }
    }
}