﻿using System;
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
using com.krungsri.el.data;
using com.krungsri.el.biz;
using System.Collections.Generic;

namespace com.krungsri.el.web.AppCode
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

        public string GetCurrentUser()
        {
            if (Session["User"] != null)
                return ((com.krungsri.el.data.UserData)Session["User"]).Login_ID;
            return "";
        }

        public UserData GetObjectUser()
        {
            if (Session["User"] != null)
                return ((com.krungsri.el.data.UserData)Session["User"]);

            Response.Redirect("~/Login.aspx");
            return null;
        }

        public WebLogsData GetLogs(string Action)
        {
            WebLogsData Log = new WebLogsData();
            string[] URL = Page.Request.Url.ToString().Split('/');
            Log.Login_ID = GetCurrentUser();
            Log.URL = URL[URL.Length - 1];
            Log.Description = "";
            Log.Action = Action;
            Log.LOG_IP = Request.ServerVariables["REMOTE_ADDR"];
            return Log;
        }

        public List<UserPage> CheckPermissionPage()
        {
            if (Session["User"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Logout.aspx");
            }
            UserData EnUser = (UserData)Session["User"];
            List<UserPage> ListEn_Page = new List<UserPage>();
            List<UserPage> ListEn_Page_Check = new List<UserPage>();
            string[] URL;
            string Page_name;

            ListEn_Page = EnUser.User_Group.UserPage;

            URL = System.Web.HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            Page_name = URL[URL.Length - 1].ToString().Split('.')[0].ToString();
            ListEn_Page_Check = ListEn_Page.Where(w => w.PageURL != "").Where(w => w.PageURL.Contains(Page_name)).ToList();
            return ListEn_Page_Check;
        }

        #region Config
        public DataSet getConfig(string CONFIG_ID)
        {
            ProcessEADBiz EADBiz = new ProcessEADBiz("LGDEADConnection");
            DataSet dsConfig = EADBiz.GetEADConfig(CONFIG_ID, "Y");

            return dsConfig;
        }
        #endregion
    }
}
