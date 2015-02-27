using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.data;

namespace VloveImport.web.MasterPage
{
    public partial class master_page_batt : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerData CusData = new CustomerData();
            CusData.Cus_ID = 1;
            CusData = (CustomerData)Session["User"];
        }
    }
}