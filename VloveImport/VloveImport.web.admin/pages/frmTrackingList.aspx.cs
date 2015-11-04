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
    public partial class frmTrackingList : BasePage
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
                ucCalendar1.SET_DATE(DateTime.Now.AddDays(-7));
                ucCalendar2.SET_DATE_DEFAULT();
            }

            //this.btnUpdate.Attributes.Add("onClick", "javascript:return confirm('Do you want to update data ?')");
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
            DateTime From = ucCalendar1.GET_DATE_TO_DATE() == null ? DateTime.MinValue : ucCalendar1.GET_DATE_TO_DATE().Value;
            DateTime To = ucCalendar2.GET_DATE_TO_DATE() == null ? DateTime.MaxValue : ucCalendar2.GET_DATE_TO_DATE().Value;
            if (txtTracking.Text.Trim() != "" || From != null || To != null)
            {
                DataTable dt = new DataTable();
                ShoppingBiz biz = new ShoppingBiz();
                dt = biz.GetTrackingAdmin(txtTracking.Text.Trim(), From, To);
                if (dt != null && dt.Rows.Count > 0)
                {
                    gv_detail.DataSource = dt;
                    gv_detail.DataBind();
                }
            }
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