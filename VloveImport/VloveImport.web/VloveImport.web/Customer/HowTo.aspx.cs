using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VloveImport.web.Customer
{
    public partial class HowTo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string type = Request.QueryString["type"] == null ? "" : Request.QueryString["type"].ToString();
            //SelectView(type);
        }

        //private void SelectView(string type)
        //{
        //    switch (type)
        //    {
        //        case"rateimport":
        //            mView.ActiveViewIndex = 0;
        //            break;
        //        case "order":
        //            mView.ActiveViewIndex = 1;
        //            break;
        //        default:
        //            mView.ActiveViewIndex = -1;
        //            break;
        //    }
        //}
    }
}