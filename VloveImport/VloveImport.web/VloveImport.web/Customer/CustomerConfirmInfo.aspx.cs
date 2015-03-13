using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.util;

namespace VloveImport.web.Customer
{
    public partial class CustomerConfirmInfo : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            string CID = Request.QueryString["CID"] == null ? "" : en.DecryptData(Request.QueryString["CID"].ToString());
            if (CID == "")
                Response.Redirect("CustomerBasket.aspx");
        }

        protected void BindDataGrid()
        {
            if (Session["ORDER"] != null)
            {
                string Selected = Session["ORDER"].ToString();
                ShoppingBiz Biz = new ShoppingBiz();
                DataTable dt = new DataTable();// Biz.GetBasketSelected();
                if (dt != null && dt.Rows.Count > 0)
                    gvBasket.DataSource = dt;
                else
                    gvBasket.DataSource = null;

                gvBasket.DataBind();
            }
            else
            {
                //Error
            }
        }
    }
}