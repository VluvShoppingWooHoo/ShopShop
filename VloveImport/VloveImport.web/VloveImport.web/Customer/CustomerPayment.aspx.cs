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
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession(); 
            string OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
            if (OID == "")
            {
                BindData();
                hdOID.Value = OID;
            }
        }

        protected void btnPayment_ServerClick(object sender, EventArgs e)
        {
            CustomerBiz biz = new CustomerBiz();
            TransactionData data = GetDataTran();
            string Result = biz.INS_UPD_TRANSACTION(data, "INS");

            BindData();
        }

        protected void BindData()
        {
            if (hdOID.Value != "")
            {
                Int32 Order_ID = Convert.ToInt32(hdOID.Value);
                CustomerBiz biz = new CustomerBiz();
                DataTable dt = biz.GET_TRANSACTION_BY_ORDERID(Order_ID);
                if (dt != null && dt.Rows.Count > 0)
                    gvTran.DataSource = dt;
                else
                    gvTran.DataSource = null;

                gvTran.DataBind();
            }
        }

        protected TransactionData GetDataTran()
        {
            TransactionData data = new TransactionData();
            data.TRAN_TYPE = 2;
            data.TRAN_TABLE_TYPE = 3; //Order
            data.TRAN_DETAIL = rdbPayment1.Checked ? "ชำระครั้งเดียว" : "ชำระ 2 ครั้ง";
            data.TRAN_AMOUNT = GetAmount();
            data.Cus_ID = 0;//SessionUser
            data.ORDER_ID = hdOID.Value == "" ? 0 : Convert.ToInt32(hdOID.Value);

            return data;
        }

        protected float GetAmount()
        {
            float Amt = 0;

            return Amt;
        }
    }
}