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
using VloveImport.web.UserControls;

namespace VloveImport.web.Customer
{
    public partial class CustomerMyAccount : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession();    
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
        public static string btnTopup(string Bank, string amt, string date, string time, string email, string remark, string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ucAccFuncTopup Topup = new ucAccFuncTopup();
            Topup.SaveData();
            return js.Serialize("");
        }

        [WebMethod]
        public static string btnWithdraw(string accname, string amt, string remark, string pwd)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize("");
        }

        [WebMethod]
        public static string btnTransLog(string Bank, string amt, string date, string time, string email, string remark, string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize("");
        }

        [WebMethod]
        public static string btnVoucher(string Bank, string amt, string date, string time, string email, string remark, string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize("");
        }

        [WebMethod]
        public static string btnMyPoint(string Bank, string amt, string date, string time, string email, string remark, string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize("");
        }
        #endregion      
    }
}