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
            Response.Redirect("CustomerPayment.aspx?P=" + EncrypData("LIST") + "&OID=" + Order_ID);
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

        protected void gvOrder_DataBound(object sender, EventArgs e)
        {
            HyperLink hl;
            HiddenField hdd;
            Button btnPay, btnDel;
            string Order_ID = "";
            foreach (GridViewRow gvr in gvOrder.Rows)
            {
                hl = (HyperLink)gvr.Cells[0].FindControl("hlOrderCode");
                hdd = (HiddenField)gvr.Cells[2].FindControl("hddStatus");
                if (hl != null)
                {
                    Order_ID = EncrypData(hl.NavigateUrl);
                    hl.NavigateUrl = "~/Customer/CustomerOrderDetail.aspx?P=" + EncrypData("LIST") + "&OID=" + Order_ID;
                }

                if (hdd != null && (hdd.Value == "0" || hdd.Value == "2" || hdd.Value == "5" || hdd.Value == "6"))
                {
                    gvr.Cells[5].Visible = false;
                    //btnPay = (Button)gvr.Cells[5].FindControl("btnPay");
                    //btnDel = (Button)gvr.Cells[5].FindControl("btnDelete");

                    //if (btnPay != null)
                    //    btnPay.Visible = false;
                    //if (btnDel != null)
                    //    btnDel.Visible = false;

                }
            }
        } 

    }
}