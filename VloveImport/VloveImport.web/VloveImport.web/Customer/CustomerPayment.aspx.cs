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
    public partial class CustomerPayment : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        public string OID;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession(); 
            OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
            if (OID != "")
            {
                BindData();
            }
        }

        protected void btnPayment_ServerClick(object sender, EventArgs e)
        {
            CustomerBiz biz = new CustomerBiz();
            TransactionData data = GetDataTran();
            string Result = biz.INS_UPD_TRANSACTION(data, "INS");

            Redirect("~/Customer/CustomerOrderDetail.aspx?OID=" + EncrypData(OID));
        } 

        protected void BindData()
        {
            Int32 Order_ID = OID == "" ? 0 : Convert.ToInt32(OID);            
            CustomerBiz biz = new CustomerBiz();
            ShoppingBiz bizShop = new ShoppingBiz();
            double Amount = 0, Price = 0, Total = 0;

            //Description
            DataTable dtDetail = bizShop.GetOrderDetail(Order_ID);
            if (dtDetail != null && dtDetail.Rows.Count > 0)
            {
                foreach (DataRow dr in dtDetail.Rows)
                {
                    Amount = dr["OD_AMOUNT_ACTIVE"].ToString() == "" ? 0 : Convert.ToDouble(dr["OD_AMOUNT_ACTIVE"].ToString());
                    Price = dr["OD_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["OD_PRICE"].ToString());
                    Total = Total + (Amount * Price);
                }
                hlOrderCode.Text = dtDetail.Rows[0]["ORDER_CODE"].ToString();
                hlOrderCode.NavigateUrl = "~/Customer/CustomerOrderDetail.aspx?OID=" + EncrypData(OID);
                lbTotalAmount.Text = Total.ToString("###,###.00");
                lbBalance.Text = GetBalance().ToString("###,###.00");
            }

            //Grid
            DataTable dt = biz.GET_TRANSACTION_BY_ORDERID(Order_ID);
            if (dt != null && dt.Rows.Count > 0)
                gvTran.DataSource = dt;
            else
                gvTran.DataSource = null;

            gvTran.DataBind();
            
        }

        protected TransactionData GetDataTran()
        {
            TransactionData data = new TransactionData();
            data.TRAN_TYPE = 2; //เงินออก
            data.TRAN_TABLE_TYPE = 3; //Order
            data.TRAN_DETAIL = "ชำระเงินครั้งแรก";
            data.TRAN_AMOUNT = Convert.ToDouble(lbTotalAmount.Text);
            data.Cus_ID = 0;//SessionUser
            data.ORDER_ID = OID == "" ? 0 : Convert.ToInt32(OID);

            return data;
        }
    }
}