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
    public partial class CustomerOrderDetail : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession(); 
            if (!IsPostBack)
            {
                string OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
                if (OID == "")
                    GoToIndex();

                BindData(OID);
            }
        }
        protected void BindData(string Order_ID)
        {
            ShoppingBiz biz = new ShoppingBiz();
            DataTable dt = new DataTable();
            string Trans = "";
            Int32 OID = Order_ID == "" ? 0 : Convert.ToInt32(Order_ID);
            dt = biz.GetOrderDetail(OID);
            if (dt != null && dt.Rows.Count > 0)
            {
                lbOrder_Code.Text = dt.Rows[0]["ORDER_CODE"].ToString();
                lbOrder_Date.Text = dt.Rows[0]["ORDER_DATE"].ToString();
                
                lbCusName.Text = dt.Rows[0]["CUS_NAME"].ToString();
                lbMobile.Text = dt.Rows[0]["CUS_MOBILE"].ToString();

                lbAddress.Text = dt.Rows[0]["CUS_ADDRESS"].ToString();
                Trans = "1. " + dt.Rows[0]["TRANS_CH_TH"].ToString() + "<br/>2. " + dt.Rows[0]["TRANS_TH_CU"].ToString();
                lbOrderTransport.Text = Trans;
                lbOrderAmount.Text = dt.Rows.Count.ToString();
                lbOrderStatus.Text = dt.Rows[0]["ORDER_DESC"].ToString();

                //Grid                          
                gvOrder.DataSource = dt;   
                gvOrder.DataBind();
            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            Redirect("~/Customer/CustomerOrderList.aspx");
        }

        protected void btnPay_ServerClick(object sender, EventArgs e)
        {
            string OID = Request.QueryString["OID"] == null ? "" : Request.QueryString["OID"].ToString();
            Redirect("~/Customer/CustomerOrderList.aspx?OID=" + OID;
        }        
    }
}