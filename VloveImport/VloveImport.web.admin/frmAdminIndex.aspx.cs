using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.util;

namespace VloveImport.web.admin
{
    public partial class frmAdminIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtuser.Focus();
            }
            //EncrypUtil En = new EncrypUtil();
            //string str = En.EncrypData("P@ssw0rd");
            //mAcyCUnuZOxcdC1lTNPPjg==
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text.Trim() == "" || txtpassword.Text.Trim() == "")
            {
                ShowMessageBox("กรุณากรอก USERNAME หรือ PASSWORD", this.Page);
            }

            try
            {
                UserBiz userBiz = new UserBiz();
                DataSet ds = userBiz.GET_USER_LOGIN(txtuser.Text.Trim(), "LOGIN");

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    EncrypUtil En = new EncrypUtil();
                    string pwd = En.DecryptData(ds.Tables[0].Rows[0]["EMP_PASSWORD"].ToString());
                    if (pwd == txtpassword.Text)
                    {
                        Response.Redirect("~/Pages/frmIndex.aspx");
                    }
                    else ShowMessageBox("กรุณาตรวจสอบ USERNAME หรือ PASSWORD อีกครั้ง", this.Page);
                }
                else ShowMessageBox("กรุณาตรวจสอบ USERNAME หรือ PASSWORD อีกครั้ง", this.Page);
            }
            catch (Exception ex)
            {
                ShowMessageBox(ex.Message, this.Page);
            }
        }
    }
}