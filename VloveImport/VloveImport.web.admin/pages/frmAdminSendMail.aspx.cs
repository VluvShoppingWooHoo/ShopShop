using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;

namespace VloveImport.web.admin.pages
{
    public partial class frmAdminSendMail : System.Web.UI.Page
    {

        util.EncrypUtil Enc = new util.EncrypUtil();

        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        public int _VS_GROUP_ID
        {
            get { return ViewState["__VS_GROUP_ID"] == null ? -1 : Convert.ToInt32(ViewState["__VS_GROUP_ID"].ToString()); }
            set { ViewState["__VS_GROUP_ID"] = value; }
        }

        public int _VS_USER_ID
        {
            get { return Request.QueryString["UID"] == null ? 0 : Convert.ToInt32(Enc.DecryptData(Request.QueryString["UID"])); }
            set { ViewState["__VS_USER_ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminUserData Data = new AdminUserData();
            Data = (AdminUserData)(Session["AdminUser"]);
            _VS_USER_LOGIN = Data.USERNAME;

            if (!IsPostBack)
            {
                
            }

        }

        public void BindData()
        {

        }

        public void ShowMessageBox(string message, Page currentPage, string redirectNamePage = "")
        {
            string msgboxScript = "alert('" + message + "');";

            string redirectPage = "";
            if (redirectNamePage != "")
            {
                redirectPage = "window.location='" + redirectNamePage + "';";
            }

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript + redirectPage, true);
            }
        }
        
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            EncrypUtil En = new EncrypUtil();

            string Body = "", Link = "", emailEn = "", passEn = "", Path = "", Result = "";
            string[] Temp, URL;
            Temp = Get_Config("REGIS");
            if (Temp.Length > 0)
            {
                emailEn = En.EncrypData(txtToEmail.Text);
                passEn = txtPassword.Text;
                Path = "www.iloveimport.com";
                Link = Path + "/Customer/Activate.aspx?e=" + Server.UrlEncode(emailEn) + "&c=" + Server.UrlEncode(passEn);
                Body = Temp[1].Replace("{0}", Link);
                Result = SendMail(txtToEmail.Text, Temp[0], Body);

                //Error
                if (Result != "")
                {
                    URL = Page.Request.Url.ToString().Split('/');
                    //WriteLog(URL[URL.Length - 1], "btnRegis", Result);
                    WriteLog(Page.Request.Url.AbsolutePath, "btnProcess/Sendmail", Result);
                }
            }
            else
            {
                ShowMessageBox("Temp = 0", this.Page, "frmAdminSendMail.aspx");
                return;
            }
            ShowMessageBox("Success", this.Page, "frmAdminSendMail.aspx");
        }

        public string SendMail(string MailTo, string Subject, string Body)
        {
            EncrypUtil En = new EncrypUtil();
            string Result = "";
            string strMailServer = WebConfigurationManager.AppSettings["SMTP"].ToString();
            string UserEmail = WebConfigurationManager.AppSettings["email"].ToString();
            string PassEmail = WebConfigurationManager.AppSettings["emailp"].ToString();
            try
            {
                //Send Email ให้คนลำดับถัดไปในกรณี Approve หรือ ส่งให้คนลำดับก่อนหน้าในกรณี Reject
                MailMessage Mail = new MailMessage();
                MailAddress mailAdd = new MailAddress(UserEmail);
                //Email, toEmail
                Mail.IsBodyHtml = true;
                Mail.SubjectEncoding = System.Text.Encoding.UTF8;
                Mail.BodyEncoding = System.Text.Encoding.UTF8;
                Mail.From = mailAdd;
                Mail.To.Add(MailTo);

                Mail.Subject = Subject;
                Mail.Body = Body.Replace("\r\n", "<br/>");

                if (strMailServer != "")
                {
                    SmtpClient SmtpClient = new SmtpClient(strMailServer, 25);
                    SmtpClient.Credentials = new NetworkCredential(UserEmail, En.DecryptData(PassEmail));

                    SmtpClient.Send(Mail);
                    Mail.Attachments.Clear();
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return Result;
        }

        public string[] Get_Config(string Group)
        {
            string[] Result;
            DataTable dt = new DataTable();
            commonBiz biz = new commonBiz();

            dt = biz.Get_ConfigByGroup(Group);
            if (dt != null && dt.Rows.Count > 0)
            {
                Result = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Result[i] = dt.Rows[i]["CONFIG_VALUE"].ToString();
                }
            }
            else
                return null;

            return Result;
        }

        public void WriteLog(string Page, string Function, string Error)
        {
            commonBiz biz = new commonBiz();
            biz.WriteLog(Page, Function, Error);
        }
    }
}