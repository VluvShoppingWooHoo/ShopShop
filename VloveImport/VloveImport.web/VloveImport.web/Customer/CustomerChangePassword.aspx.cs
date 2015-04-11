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
        public static string btnConfirm(string old, string newp, string conf)
        {
            string PassDB = "", DBDecrypt = "";
            BasePage bp = new BasePage();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = biz.Get_Customer_Profile(bp.GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {
                PassDB = dt.Rows[0]["CUS_PASSWORD"].ToString();
                DBDecrypt = bp.DecryptData(PassDB);
                if (old == DBDecrypt)
                {
                    Result = biz.CHANGE_PASSWORD(bp.GetCusID(), bp.EncrypData(newp), "LOGIN");
                    if (Result == "")
                        return js.Serialize("1|CustomerChangePassword.aspx#login");
                    else
                        return js.Serialize("2|โปรดติดต่อเจ้าหน้าที่");
                }
                else
                {
                    return js.Serialize("2|รหัสผ่านผิด!!!");
                }
            }
            else
            {
                return js.Serialize("2|Session Timeout");
            }

            
            //return js.Serialize(Result);
        }
        [WebMethod]
        public static string btnW_Confirm(string old, string newp, string conf)
        {
            string PassDB = "", DBDecrypt = "";
            BasePage bp = new BasePage();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = biz.Get_Customer_Profile(bp.GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {
                PassDB = dt.Rows[0]["CUS_WITHDRAW_CODE"].ToString();
                DBDecrypt = bp.DecryptData(PassDB);
                if (old == DBDecrypt)
                {
                    Result = biz.CHANGE_PASSWORD(bp.GetCusID(), bp.EncrypData(newp), "WITHDRAW");
                    if (Result == "")
                        return js.Serialize("1|CustomerChangePassword.aspx#withdraw");
                    else
                        return js.Serialize("2|โปรดติดต่อเจ้าหน้าที่");
                }
                else
                {
                    return js.Serialize("2|รหัสผ่านผิด!!!");
                }
            }
            else
            {
                return js.Serialize("2|Session Timeout");
            }
        }
        #endregion

        protected void lbReset_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }

        protected void btnConf_Click(object sender, EventArgs e)
        {
            string Body = "", Result = "";
            string ResetPass = System.Web.Security.Membership.GeneratePassword(10, 3);
            CustomerBiz biz = new CustomerBiz();
            Result = biz.RESET_PASSWORD(EncrypData(ResetPass), GetCusID(), "WITHDRAW");
            
            string[] Temp;
            Temp = Get_Config("REPASSWITHDRAW");
            if (Temp.Length > 0)
            {
                Body = Temp[1].Replace("{1}", GetCusCode()).Replace("{2}", ResetPass);
                Result = SendMail(GetCusEmail(), Temp[0], Body);
            }
            
            ShowMessageBox("รหัสผ่านจะถูกส่งเข้าอีเมลล์ของคุณ");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
    }
}