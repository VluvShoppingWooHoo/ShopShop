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
            //CheckSession(); 
            if (!IsPostBack)
            {
                string OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
                BindData(OID);
            }
        }
        protected void BindData(string Order_ID)
        {
            ShoppingBiz biz = new ShoppingBiz();
            DataTable dt = new DataTable();
            Int32 OID = Order_ID == "" ? 0 : Convert.ToInt32(Order_ID);
            dt = biz.GetOrderDetail(OID);
            if (dt != null && dt.Rows.Count > 0)
            {
                lbOrder_Code.Text = dt.Rows[0]["ORDER_CODE"].ToString();
                lbOrder_Date.Text = dt.Rows[0]["ORDER_DATE"].ToString();
            }
        }
    }
}