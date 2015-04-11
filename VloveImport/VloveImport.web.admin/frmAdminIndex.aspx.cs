using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;

namespace VloveImport.web.admin
{
    public partial class frmAdminIndex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //txtuser.Focus();
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
                        AdminUserData Data = new AdminUserData();
                        Data.EMP_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["EMP_ID"].ToString());
                        Data.USERNAME = ds.Tables[0].Rows[0]["USERNAME"].ToString();
                        Data.EMP_PASSWORD = ds.Tables[0].Rows[0]["EMP_PASSWORD"].ToString();
                        Data.EMP_NAME = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
                        Data.EMP_LNAME = ds.Tables[0].Rows[0]["EMP_LNAME"].ToString();
                        Data.EMP_DETAIL = ds.Tables[0].Rows[0]["EMP_DETAIL"].ToString();
                        Data.EMP_STATUS = Convert.ToInt32(ds.Tables[0].Rows[0]["EMP_STATUS"].ToString());
                        Data.GROUP_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["GROUP_ID"].ToString());
                        Data.GROUP_NAME = ds.Tables[0].Rows[0]["GROUP_NAME"].ToString();
                        Data.GROUP_ROLE = ds.Tables[0].Rows[0]["GROUP_ROLE"].ToString();
                        Data.GROUP_REMARK = ds.Tables[0].Rows[0]["GROUP_REMARK"].ToString();
                        Data.GROUP_STATUS = Convert.ToInt32(ds.Tables[0].Rows[0]["GROUP_STATUS"].ToString());

                        Session["AdminUser"] = Data;
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