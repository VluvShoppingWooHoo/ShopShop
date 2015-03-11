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
    public partial class CustomerBasket : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string Cus_ID = Request.QueryString["Cus_id"] == null ? "" : en.DecryptData(Request.QueryString["Cus_id"].ToString());
                BindData();
            }
        }

        protected void BindData()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = Biz.GetBasketList(0);
            if (dt != null && dt.Rows.Count > 0)
                gvBasket.DataSource = dt;
            else
                gvBasket.DataSource = null;

            gvBasket.DataBind();
        }
    }
}