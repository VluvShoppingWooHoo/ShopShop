using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;

namespace VloveImport.web.App_Code
{
    public class BasePage : System.Web.UI.Page
    {
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

        public Int32 GetCusID()
        {
            if (Session["User"] != null)
                return ((CustomerData)Session["User"]).Cus_ID;
            else
                return 0;
                    
        }

        public string GetCusCode()
        {
            if (Session["User"] != null)
                return ((CustomerData)Session["User"]).Cus_Code;
            else
                return "";

        }

        public string GetCusEmail()
        {
            if (Session["User"] != null)
                return ((CustomerData)Session["User"]).Cus_Email;
            else
                return "";

        }

        public CustomerData GetCusSession()
        {
            if (Session["User"] != null)
                return ((CustomerData)Session["User"]);
            else
                return null;

        }

        public string GetNoSeries(string NoSeries_Name)
        {
            string Result = "";
            commonBiz Biz = new commonBiz();
            Result = Biz.GetNoSeries(NoSeries_Name);
            return Result;
        }

        public double GetRateCurrency()
        {
            double Rate = 0;
            DataTable dt = new DataTable();
            ShoppingBiz Biz = new ShoppingBiz();
            dt = Biz.GetRate();
            if (dt != null && dt.Rows.Count > 0)
                Rate = Convert.ToDouble(dt.Rows[0]["CONFIG_VALUE"].ToString());

            return Rate;
        }

        public double GetBalance()
        {
            CustomerBiz biz = new CustomerBiz();
            double Balance = 0;
            Balance = biz.GET_CUSTOMER_BALANCE(GetCusID());
            return Balance;
        }

        public void CheckSession()
        {
            if (HttpContext.Current.Session["User"] != null)
                return;
            else
            {
                //string url = HttpContext.Current.Request.Url.AbsolutePath;
                string url = HttpContext.Current.Request.Url.PathAndQuery;
                string Login = "~/Customer/Login.aspx?u=";
                    HttpContext.Current.Response.Redirect(Login + EncrypData(url));
            }
        }

        public void GoToIndex()
        {
            HttpContext.Current.Response.Redirect("~/Index.aspx");
        }

        public void Redirect(string PageName)
        {
            HttpContext.Current.Response.Redirect(PageName);            
        }

        public void RefreshPage()
        {            
            Response.Redirect(Page.Request.Url.AbsoluteUri);
        }

        #region Message Alert
        public void ShowMessageBox(string message)
        {
            string msgboxScript = "alert('" + message + "');";           
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "msgboxScriptAJAX", msgboxScript, true);            
        }

        public void ShowMessageBox(string message, Page currentPage)
        {
            string msgboxScript = "alert('" + message + "');";

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
            }
        }

        public void ShowMessageBox(string message, Page currentPage, string redirectNamePage = "")
        {
            string msgboxScript = "alert('" + message + "');";

            if (redirectNamePage == "" && message != "1")
            {
                if ((ScriptManager.GetCurrent(currentPage) != null))
                {
                    ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
                }
            }
            else if (redirectNamePage != "" && message != "1")
            {
                string redirectPage = "window.location.href=\"" + redirectNamePage + "\";";

                if ((ScriptManager.GetCurrent(currentPage) != null))
                {
                    ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript + redirectPage, true);
                }
            }
            else
            {
                string redirectPage = "window.location.href=\"" + redirectNamePage + "\";";

                if ((ScriptManager.GetCurrent(currentPage) != null))
                {
                    ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", redirectPage, true);
                }
            }
        }
        #endregion

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
        #region Convert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtDate"></param>
        /// <param name="Deli">Delimater</param>
        /// <param name="DateFormat">DDMMYYYY,YYYYMMDD</param>
        /// /// <param name="Diff">543,0</param>
        /// <returns></returns>
        public System.Nullable<System.DateTime> Convert_DateYYYYMMDD(string dtDate, char Deli, string DateFormat, int Diff)
        {
            string[] StrDate;
            string DayDate;
            string MonthDate;
            string YearDate;
            System.Nullable<System.DateTime> dateSave = default(System.Nullable<System.DateTime>);

            if (!string.IsNullOrEmpty(dtDate) & dtDate != " ")
            {
                StrDate = dtDate.Split(Deli);
                if (DateFormat == "DDMMYYYY")
                {                    
                    DayDate = StrDate[0];
                    MonthDate = StrDate[1];
                    YearDate = (Convert.ToInt32(StrDate[2]) - Diff).ToString();
                }
                else
                {                 
                    DayDate = StrDate[2];
                    MonthDate = StrDate[1];
                    YearDate = (Convert.ToInt32(StrDate[0]) - Diff).ToString();
                }

                if (YearDate.Length > 4)
                {
                    YearDate = YearDate.Substring(0, 4);
                }
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); //"en-US" "th-TH"
                dateSave = new DateTime(Convert.ToInt32(YearDate.Trim()), Convert.ToInt32(MonthDate.Trim()), Convert.ToInt32(DayDate.Trim()));
            }
            else
            {
                dateSave = null;
            }
            return dateSave;
        }
        #endregion

        #region WriteLog
        public void WriteLog(string Page, string Function, string Error)
        {
            commonBiz biz = new commonBiz();
            biz.WriteLog(Page, Function, Error);
        }
        #endregion

        #region Format
        public string NumbertoString(double Num, string Type)
        {
            string Result = "";
            switch (Type)
            {
                case "Money":
                    Result = Num.ToString("###,##0.00");
                    break;
                case "Amount":
                    Result = Num.ToString("###,##0");
                    break;
            }
            
            return Result;
        }
        public string NumberStringtoString(string Input, string Type)
        {
            string Result = "";
            double Num = 0;
            Num = Input == "" ? 0 : Convert.ToDouble(Input);
            switch (Type)
            {
                case "Money":
                    Result = Num.ToString("###,##0.00");
                    break;
                case "Amount":
                    Result = Num.ToString("###,##0");
                    break;
            }

            return Result;
        }
        protected string CalPRICE_TH(string Price, string Currency)
        {
            string Result = "";
            double Pri = 0, Cur = 0, Price_TH = 0;
            Pri = Price == "" ? 0 : Convert.ToDouble(Price);
            Cur = Currency == "" ? 0 : Convert.ToDouble(Currency);
            Price_TH = Pri * Cur;
            Result = Price_TH.ToString("###,##0.00");
            return Result;
        }

        #endregion
    }
}