using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerMyAccount : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindData();
            }
        }

        private void BindData()
        {
            Int32 Cus_ID = GetCusID();
            CustomerBiz Biz = new CustomerBiz();
            DataTable dt = Biz.GET_CUSTOMER_MYACCOUNT(Cus_ID);

            if (dt != null && dt.Rows.Count > 0)
            {
                //lblWelcome.InnerText = "สวัสดี " + dt.Rows[0]["CUS_NAME"].ToString() + "";
                //lblBalance.InnerText = "ยอดเงินคงเหลือ " + dt.Rows[0]["test"].ToString() + "บาท";
                //lblPoint.InnerText = "คะแนนสะสม " + dt.Rows[0]["test"].ToString() + "คะแนน";
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

        protected void btnVoucher_Click(object sender, EventArgs e)
        {

        }

        protected void btnMyPoint_Click(object sender, EventArgs e)
        {

        }
        #endregion

        public string CallUcWithdraw1(string ddlAccount, string txt_amount, string txt_remark, string txt_Withraw_Password)
        {
            return"";  //ucAccfuncWithdraw1.SaveData(ddlAccount, txt_amount, txt_remark, txt_Withraw_Password);
        }


        [WebMethod]
        public static string btnSave(string ddlAccount, string txt_amount, string txt_remark, string txt_Withraw_Password)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            CustomerMyAccount CusPage = new CustomerMyAccount();
            return js.Serialize(CusPage.CallUcWithdraw1(ddlAccount, txt_amount, txt_remark, txt_Withraw_Password));
        }

    }
}