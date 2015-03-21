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
    }
}