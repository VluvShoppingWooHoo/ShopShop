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
    public partial class CustomerMyAccount : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string Cus_ID = Request.QueryString["Cus_id"] == null ? "" : en.DecryptData(Request.QueryString["Cus_id"].ToString());
                //BindData(Cus_ID);
            }
        }

        private void BindData(string ID)
        {
            Int32 Cus_ID = Convert.ToInt32(ID);
            CustomerBiz Biz = new CustomerBiz();
            DataTable dt = Biz.GET_CUSTOMER_MYACCOUNT(Cus_ID);

            if (dt != null && dt.Rows.Count > 0)
            {
                lblWelcome.InnerText = "สวัสดี " + dt.Rows[0]["CUS_NAME"].ToString() + "";
                lblBalance.InnerText = "ยอดเงินคงเหลือ " + dt.Rows[0]["test"].ToString() + "บาท";
                lblPoint.InnerText = "คะแนนสะสม " + dt.Rows[0]["test"].ToString() + "คะแนน";
            }
        }

        #region Event
        protected void btnTopup_Click(object sender, EventArgs e)
        {

        }

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {

        }

        protected void btnTransLog_Click(object sender, EventArgs e)
        {

        }

        protected void btnVocher_Click(object sender, EventArgs e)
        {

        }

        protected void btnMyPoint_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}