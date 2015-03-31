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
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;
using VloveImport.web.UserControls;

namespace VloveImport.web.Customer
{
    public partial class CustomerChangePassword : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //CheckSession();    
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
        [WebMethod]
        public static string btnConfirm(string old, string newp, string conf)
        {
            BasePage bp = new BasePage();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = biz.Get_Customer_Profile(bp.GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {

            }
            else
            {
                return js.Serialize("Session Timeout");
            }

            Result = biz.CHANGE_PASSWORD(bp.GetCusID(), newp);
            return js.Serialize(Result);
        }
        #endregion
    }
}