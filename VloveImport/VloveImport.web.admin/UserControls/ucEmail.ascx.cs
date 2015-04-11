using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VloveImport.web.admin.UserControls
{
    public partial class ucEmail : System.Web.UI.UserControl
    {

        public event System.EventHandler ucEmail_OpenpopClick;
        private void OnbtnOpenPopUp()
        {
            if (ucEmail_OpenpopClick != null) { ucEmail_OpenpopClick(this, new System.EventArgs()); }
        }

        public event System.EventHandler ucbtnSaveClicked;
        private void OnbtnSaveClick()
        {
            if (ucbtnSaveClicked != null) { ucbtnSaveClicked(this, new System.EventArgs()); }
        }

        public string _VS_EMAIL
        {
            get { return ViewState["__VS_EMAIL"].ToString(); }
            set { ViewState["__VS_EMAIL"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_email_from.Text = WebConfigurationManager.AppSettings["email"].ToString();
            }
        }

        public void SetEmail(string strEmailTo)
        {
            txt_email_to.Text = strEmailTo.Trim();
        }

        public void SetEmail_To_Enabled()
        {
            txt_email_to.Enabled = false;
        }

        public void Reset()
        {
            txt_email_from.Text = "";
            txt_email_to.Text = "";
            txt_email_subject.Text = "";
            txt_email_detail.Text = "";
        }

        #region Sendmail
        private string SendMail(string mailFrom ,string MailTo, string Subject, string Body)
        {
            string Result = "";
            string strMailServer = WebConfigurationManager.AppSettings["SMTP"].ToString();
            string PassEmail = WebConfigurationManager.AppSettings["emailp"].ToString();
            try
            {
                //Send Email ให้คนลำดับถัดไปในกรณี Approve หรือ ส่งให้คนลำดับก่อนหน้าในกรณี Reject
                MailMessage Mail = new MailMessage();
                MailAddress mailAdd = new MailAddress(MailTo);
                //Email, toEmail
                Mail.IsBodyHtml = true;
                Mail.SubjectEncoding = System.Text.Encoding.UTF8;
                Mail.BodyEncoding = System.Text.Encoding.UTF8;
                Mail.From = mailAdd;
                Mail.To.Add(MailTo);

                Mail.Subject = Subject;
                Mail.Body = Body.Replace("\r\n", "<br/>");

                util.EncrypUtil Enc = new util.EncrypUtil();

                if (strMailServer != "")
                {
                    SmtpClient SmtpClient = new SmtpClient(strMailServer, 25);
                    SmtpClient.Credentials = new NetworkCredential(MailTo, Enc.DecryptData(PassEmail));

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

        public void ShowMessageBox(string message, Page currentPage)
        {
            string msgboxScript = "alert('" + message + "');";

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
            }
        }

        public bool CheckEmailPattern(string strEmail)
        {
            string emailPattern = "^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@" + "([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";

            if (!Regex.IsMatch(strEmail, emailPattern))
            {
                ShowMessageBox("กรุณากรอก E-Mail ให้ถูกต้อง", this.Page);
                return false ;
            }
            return true;
        }

        protected void btnsendMail_Click(object sender, EventArgs e)
        {
            if (CheckEmailPattern(txt_email_from.Text.Trim()))
            {
                string[] strEmailArry = txt_email_to.Text.Trim().Split(',');

                bool Isvalidate = true;
                if (strEmailArry.Length > 0)
                {
                    for (int i = 0; i <= strEmailArry.Length - 1; i++)
                    {
                        if (CheckEmailPattern(strEmailArry[i].ToString().Trim()) == false)
                        {
                            ShowMessageBox("Please enter customer Email is correctly.", this.Page);
                            Isvalidate = false;
                            break;
                        }
                    }
                }

                if (Isvalidate == false)
                {
                    OnbtnOpenPopUp();
                }
                else
                {
                    SendMail(txt_email_from.Text.Trim(), txt_email_to.Text.Trim(), txt_email_subject.Text.Trim(), txt_email_detail.Text.Trim());
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}