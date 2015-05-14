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

namespace VloveImport.web.Customer
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = Request.QueryString["u"] == null ? "" : DecryptData(Request.QueryString["u"].ToString());
                ViewState["url"] = url;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginProcess(txtUser.Text, txtPass.Text, 0);
            if (Session["User"] != null)
            {
                WriteLog(Page.Request.Url.AbsolutePath, "Login", "Pass --> User : " + txtUser.Text);
                if (ViewState["url"] != null && ViewState["url"].ToString() != "")
                    Response.Redirect(ViewState["url"].ToString());
            }
            else
            {
                string Desc = "Fail --> User : " + txtUser.Text + "||  Pass : " + txtPass.Text == "" ? "" : EncrypData(txtPass.Text);
                WriteLog(Page.Request.Url.AbsolutePath, "Login", Desc);
                ShowMessageBox("รหัสผ่านไม่ถูกต้อง");
                return;
            }
            Response.Redirect("~/Index.aspx");
        }

        protected void LoginProcess(string UserName, string Password , int isFB)
        {
            LogonBiz Logon = new LogonBiz();
            CustomerData Cust = new CustomerData();
            Cust = Logon.LogonDBCustomer(UserName, Password, isFB);
            if (Cust != null)
                Session["User"] = Cust;
        }        

        [WebMethod]
        public static string fbLogin(string email, string password)
        {
            Login Login = new Login();
            EncrypUtil en = new EncrypUtil();
            JavaScriptSerializer js = new JavaScriptSerializer();
            JSONData jData = new JSONData();
            Login.LoginProcess(email, string.Empty, 1);
            jData.Result = Constant.Fact.T;
            return js.Serialize(jData);
        }

        protected void btnFotgot_Click(object sender, EventArgs e)
        {
            Redirect("CustomerForgot.aspx");
        }

        //protected void btnReset_Click(object sender, EventArgs e)
        //{
        //    txtUser.Text = "";
        //    txtPass.Text = "";
        //}
    }
}