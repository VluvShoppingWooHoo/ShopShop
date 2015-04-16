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
using VloveImport.data.Extension;
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
            CheckSession();
            if (!IsPostBack)
            {

                string url = Request.QueryString["u"] == null ? "" : DecryptData(Request.QueryString["u"].ToString());
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
        public static string btnTopup(string Bank, string amt, string date, string time, string remark, string file)
        {
            #region V1.
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            //BasePage bp = new BasePage();
            //TransactionData EnTran = new TransactionData();
            //EnTran.Cus_ID = bp.GetCusID();

            //EnTran.TRAN_TYPE = 1;
            //EnTran.TRAN_TABLE_TYPE = 1;
            //EnTran.TRAN_DETAIL = "รายการฝากเงิน";

            //EnTran.BANK_ID = Convert.ToInt32(Bank);
            //EnTran.TRAN_AMOUNT = Convert.ToDouble(amt);
            //EnTran.PAYMENT_DATE = Convert.ToDateTime(bp.Convert_DateYYYYMMDD(date, '-', "YYYYMMDD", 0));
            //EnTran.PAYMENT_TIME = time;
            //EnTran.TRAN_REMARK = remark.Trim();
            //EnTran.TRAN_STATUS = 1;
            //EnTran.Create_User = bp.GetCusCode();

            //CustomerBiz CusBiz = new CustomerBiz();
            ////Result = CusBiz.INS_UPD_TRANSACTION(EnTran, "INS", 0);
            //ucAccFuncTopup topup = new ucAccFuncTopup();
            //topup.ClearData();
            return js.Serialize(Result);
            #endregion
        }

        [WebMethod]
        public static string btnWithdraw(string accname, string amt, string remark, string pwd)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "", withdrawDB = "", withdrawDBEn = "";
            JSONData jData = new JSONData();
            BasePage bp = new BasePage();
            withdrawDB = bp.GetCusSession().Cus_Withdraw_Code;
            withdrawDBEn = bp.DecryptData(withdrawDB);
            if (withdrawDBEn == pwd)
            {
                TransactionData EnTran = new TransactionData();
                EnTran.Cus_ID = bp.GetCusID();

                EnTran.TRAN_TYPE = 2;
                EnTran.TRAN_TABLE_TYPE = 2;
                EnTran.TRAN_DETAIL = "รายการถอนเงิน";

                EnTran.TRAN_AMOUNT = Convert.ToDouble(amt);
                EnTran.TRAN_REMARK = remark.Trim();
                EnTran.Cus_Withdraw_Code = pwd.Trim();
                EnTran.TRAN_STATUS = 1;
                EnTran.CUS_ACC_NAME_ID = Convert.ToInt32(accname);
                EnTran.Create_User = bp.GetCusCode();

                CustomerBiz CusBiz = new CustomerBiz();
                Result = CusBiz.INS_UPD_TRANSACTION(EnTran, "INS", 0);
                if (Result == string.Empty)
                    jData.Result = Constant.Fact.T;
                //{
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('เติมเงินสำเร็จ');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
                //}
            }
            else
            {
                Result = "รหัสผ่านผิด";
                jData.Result = Constant.Fact.F;
                jData.ReturnVal = Result;
            }
            return js.Serialize(jData);
        }

        [WebMethod]
        public static string btnTransLog(string Bank, string amt, string date, string time, string email, string remark, string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            return js.Serialize(Result);
        }

        [WebMethod]
        public static string btnVoucher(string Bank, string amt, string date, string time, string email, string remark, string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            return js.Serialize(Result);
        }

        [WebMethod]
        public static string btnMyPoint(string Bank, string amt, string date, string time, string email, string remark, string file)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            return js.Serialize(Result);
        }
        #endregion

    }
}