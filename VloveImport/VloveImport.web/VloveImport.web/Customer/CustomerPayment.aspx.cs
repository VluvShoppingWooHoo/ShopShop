using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.util;

namespace VloveImport.web.Customer
{
    public partial class CustomerPayment : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            string OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
            //if (OID == "")
        }

        protected void btnPayment_ServerClick(object sender, EventArgs e)
        {

        }


    }
}