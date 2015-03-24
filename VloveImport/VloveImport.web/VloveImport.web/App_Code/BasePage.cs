using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public string GetNoSeries(string NoSeries_Name)
        {
            string Result = "";
            commonBiz Biz = new commonBiz();
            Result = Biz.GetNoSeries(NoSeries_Name);
            return Result;
        }

        public void CheckSession()
        {
            if (Session["User"] != null)
                return;
            else
            {
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                string Login = "~/Customer/Login.aspx?u=";
                    Response.Redirect(Login + EncrypData(url));
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
    }
}