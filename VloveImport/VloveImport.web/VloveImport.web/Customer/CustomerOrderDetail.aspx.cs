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
            double Order_Pay = 0;
            string Trans = "", Status = "";
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

                Status = dt.Rows[0]["ORDER_STATUS"].ToString();
                if (Status == "0" || Status == "2" || Status == "4" || Status == "6" || Status == "7")
                    btnPay.Visible = false;

                Order_Pay = dt.Rows[0]["ORDER_PAY"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["ORDER_PAY"].ToString());
                if (Status == "8" && Order_Pay <= 0)
                    btnPay.Visible = false;

                //Grid                          
                gvOrder.DataSource = dt;   
                gvOrder.DataBind();

                //Grid
                CustomerBiz biz_Cus = new CustomerBiz();
                DataTable dtTran = biz_Cus.GET_TRANSACTION_BY_ORDERID(OID);
                if (dtTran != null && dtTran.Rows.Count > 0)
                    gvTran.DataSource = dtTran;
                else
                    gvTran.DataSource = null;

                gvTran.DataBind();
            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            string Page = Request.QueryString["P"] == null ? "" : DecryptData(Request.QueryString["P"].ToString());
            string OID = Request.QueryString["OID"] == null ? "" : Request.QueryString["OID"].ToString();

            //if(Page == "LIST")
                Redirect("~/Customer/CustomerOrderList.aspx");
            //else
            //    Redirect("~/Customer/CustomerOrderDetail.aspx?OID=" + OID);
        }

        protected void btnPay_ServerClick(object sender, EventArgs e)
        {
            string OID = Request.QueryString["OID"] == null ? "" : Request.QueryString["OID"].ToString();
            Redirect("~/Customer/CustomerPayment.aspx?OID=" + OID);
        }

        protected void btnPrint_ServerClick(object sender, EventArgs e)
        {
            string OID = Request.QueryString["OID"] == null ? "" : Request.QueryString["OID"].ToString();
            Redirect("~/Report/ReportViewer.aspx?ID=" + OID + "&RN=" + EncrypData("ORDER"));
        }        
    }
}