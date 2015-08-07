using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using VloveImport.data;
using System.Net.Mail;
using System.Net;
using System.Web.Configuration;
using VloveImport.util;
using VloveImport.biz;

namespace VloveImport.web.admin.App_Code
{
    public class BasePage : Page
    {
        public struct ErrorInfo
        {
            public string ErrorUrl;
            public string ErrorMessage;
            public string ErrorSource;
            public string ErrorStackTrace;
        }

        public BasePage()
        {

        }

        #region
        /// <summary>
        /// Use this method to handle any "unhandled" exceptions on the page.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnError(EventArgs e)
        {
            Exception error = Server.GetLastError();
            ErrorInfo errorInfo = new ErrorInfo();
            errorInfo.ErrorUrl = Request.CurrentExecutionFilePath;
            errorInfo.ErrorMessage = error.Message;
            errorInfo.ErrorSource = error.Source;
            errorInfo.ErrorStackTrace = error.StackTrace;
            Session.Add("Error", errorInfo);
            Server.ClearError();

            Response.Redirect("~/frmError.aspx");
        }        
        #endregion

        public string EncrypData(string strText)
        {
            EncrypUtil en = new EncrypUtil();
            return en.EncrypData(strText);
        }

        public string DecryptData(string strText)
        {
            EncrypUtil en = new EncrypUtil();
            return en.DecryptData(strText);
        }

        public void CheckSession()
        {
            if (Session["AdminUser"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Logout.aspx");
            }
        }

        public List<AdminUserData> CheckPermissionPage()
        {
            if (Session["User"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Logout.aspx");
            }
            UserData EnUser = (UserData)Session["User"];
            List<AdminUserData> ListEn_Page = new List<AdminUserData>();
            List<AdminUserData> ListEn_Page_Check = new List<AdminUserData>();
            string[] URL;
            string Page_name;

            //ListEn_Page = EnUser.User_Group.UserPage;

            //URL = System.Web.HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            //Page_name = URL[URL.Length - 1].ToString().Split('.')[0].ToString();
            //ListEn_Page_Check = ListEn_Page.Where(w => w.PageURL != "").Where(w => w.PageURL.Contains(Page_name)).ToList();
            return ListEn_Page_Check;
        }

        #region Sendmail
        public string SendMail(string MailTo, string Subject, string Body)
        {
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
                    SmtpClient.Credentials = new NetworkCredential(UserEmail, DecryptData(PassEmail));

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
        #endregion

        #region Get Config
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
        #endregion
    }
}
