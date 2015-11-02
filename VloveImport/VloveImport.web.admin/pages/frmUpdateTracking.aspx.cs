using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.web.admin.App_Code;

namespace VloveImport.web.admin.pages
{
    public partial class frmUpdateTracking : BasePage
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
            CheckSession();
            AdminUserData Data = new AdminUserData();
            Data = (AdminUserData)(Session["AdminUser"]);
            _VS_USER_LOGIN = Data.USERNAME;

            if (!IsPostBack)
            {
                
            }

            this.btnUpdate.Attributes.Add("onClick", "javascript:return confirm('Do you want to update data ?')");
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            //int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            //string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            //util.EncrypUtil En = new util.EncrypUtil();
            //Response.Redirect("frmUser.aspx?UID=" + Server.UrlEncode(En.EncrypData(DataKeys_ID)));
        }
    }
}