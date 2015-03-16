using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;

namespace VloveImport.web.Customer
{
    public partial class CustomerOrderList : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CID = "0";// Request.QueryString["CID"] == null ? "" : en.DecryptData(Request.QueryString["CID"].ToString());
                //if (CID == "")
                //    Response.Redirect("CustomerBasket.aspx");
                BindData();
            }
        }

        protected void BindData()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = Biz.GetOrderList(0);
            if (dt != null && dt.Rows.Count > 0)
            {
                gvOrder.DataSource = dt;
                ViewState["SOURCE"] = dt;
            }
            else
            {
                gvOrder.DataSource = null;
                ViewState["SOURCE"] = null;
            }

            gvOrder.DataBind();
        }

        protected void imbPay_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imb = (ImageButton)sender;
            string Order_ID;//SessionUser
            Order_ID = en.EncrypData(imb.CommandArgument);
            Response.Redirect("CustomerPayment.aspx?OID=" + Order_ID);
            //Response.Redirect("CustomerPayment.aspx");
        }        

    }
}