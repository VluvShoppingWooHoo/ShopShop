using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.web.admin.App_Code;

namespace VloveImport.web.admin.pages
{
    public partial class ActivateMail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string[] URL;
            string Body = "", Link = "", emailEn = "", passEn = "", Path = "", Pass = "";
            Pass = EncrypData(txtPass.Text);
            string Result = "";// Insert(Pass);
            string[] Temp;
            if (Result == "")
            {
                //sendmail
                Temp = Get_Config("REGIS");
                if (Temp.Length > 0)
                {
                    emailEn = EncrypData(txtEmail.Text);
                    passEn = Pass;
                    Path = Page.Request.Url.Authority;
                    Link = Path + "/Customer/Activate.aspx?e=" + Server.UrlEncode(emailEn) + "&c=" + Server.UrlEncode(passEn);
                    Body = Temp[1].Replace("{0}", Link);
                    Result = SendMail(txtEmail.Text, Temp[0], Body);

                    //Error
                    if (Result != "")
                    {
                        URL = Page.Request.Url.ToString().Split('/');
                        //WriteLog(URL[URL.Length - 1], "btnRegis", Result);
                        WriteLog(Page.Request.Url.AbsolutePath, "btnRegis-Sendmail", Result);
                    }

                    //Success
                    Response.Redirect("ActivateMail.com");
                    //mView.ActiveViewIndex = 1;
                    //GoToIndex();
                }
                else
                {
                    //WriteLog
                    URL = Page.Request.Url.ToString().Split('/');
                    //WriteLog(URL[URL.Length - 1], "btnRegis", Result);
                    WriteLog(Page.Request.Url.AbsolutePath, "btnRegis-Insert", Result);
                    //lbMessage.Text = "Error";
                }

            }
            else
            {
                //ShowMessageBox(Result);
                //WriteLog
                //URL = Page.Request.Url.ToString().Split('/');
                //WriteLog(URL[URL.Length - 1], "btnRegis", Result);
                //lbMessage.Text = "Error";
            }
        }
    }
}