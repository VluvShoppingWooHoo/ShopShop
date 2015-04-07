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
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerOrderList : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession(); 
            if (!IsPostBack)
            {
                //string CID = "0";// Request.QueryString["CID"] == null ? "" : en.DecryptData(Request.QueryString["CID"].ToString());
                //if (CID == "")
                //    Response.Redirect("CustomerBasket.aspx");
                BindData();
            }
        }

        protected void BindData()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = Biz.GetOrderList(GetCusID());
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

        protected void btnPay_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string Order_ID;//SessionUser
            Order_ID = en.EncrypData(btn.CommandArgument);
            Response.Redirect("CustomerPayment.aspx?OID=" + Order_ID);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ShoppingBiz biz = new ShoppingBiz();
            Int32 OID = 0;
            string Order_ID, Result = "";
            Order_ID = btn.CommandArgument;
            OID = Order_ID == "" ? 0 : Convert.ToInt32(Order_ID);

            Result = biz.CancelOrder(GetCusID(), OID);
            if (Result != "")
                WriteLog("CustomerOrderList", "DeleteOrder", Result);

            BindData();
        } 

    }
}