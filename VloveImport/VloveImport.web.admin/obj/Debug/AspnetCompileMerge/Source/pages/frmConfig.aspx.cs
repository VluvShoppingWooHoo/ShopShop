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
namespace VloveImport.web.admin.pages
{
    public partial class frmConfig : System.Web.UI.Page
    {

        util.EncrypUtil Enc = new util.EncrypUtil();

        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        public string _VS_CONFIG_ID
        {
            get { return Request.QueryString["CID"] == null ? "" : Enc.DecryptData(Request.QueryString["CID"]); }
            set { ViewState["_VS_CONFIG_ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminUserData Data = new AdminUserData();
                Data = (AdminUserData)(Session["AdminUser"]);
                _VS_USER_LOGIN = Data.USERNAME;

                if (_VS_CONFIG_ID != "")
                {
                    BindData();
                }
            }
        }

        public void BindData()
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = new DataSet();
            ds = AddBiz.ADMIN_GET_CONFIG(_VS_CONFIG_ID, "", "BINDDATA_BYID");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtConfig_ID.Text = ds.Tables[0].Rows[0]["CONFIG_ID"].ToString();
                txtConfig_Group.Text = ds.Tables[0].Rows[0]["CONFIG_GROUP"].ToString();
                txtConfig_Value.Text = ds.Tables[0].Rows[0]["CONFIG_VALUE"].ToString();
                txtConfig_Value2.Text = ds.Tables[0].Rows[0]["CONFIG_VALUE2"].ToString();
                txtConfig_Value3.Text = ds.Tables[0].Rows[0]["CONFIG_VALUE3"].ToString();
                txtConfig_Remark.Text = ds.Tables[0].Rows[0]["CONFIG_REMARK"].ToString();
            }

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtConfig_Value.Text == "")
            {
                ShowMessageBox("Please fill out With the symbol * !!", this.Page);
                return;
            }
            else
            {
                CommonData En = new CommonData();
                En.CONFIG_ID = txtConfig_ID.Text.Trim();
                En.CONFIG_GROUP = txtConfig_Group.Text.Trim();
                En.CONFIG_VALUE = txtConfig_Value.Text.Trim();
                En.CONFIG_VALUE2 = txtConfig_Value2.Text.Trim();
                En.CONFIG_VALUE3 = txtConfig_Value3.Text.Trim();
                En.CONFIG_REMARK = txtConfig_Remark.Text.Trim();
                En.Create_User = _VS_USER_LOGIN;

                AdminBiz AddBiz = new AdminBiz();
                string Result = AddBiz.ADMIN_UPD_CONFIG(En, "UPD");

                if (Result == "")
                {
                    ShowMessageBox("Save success", this.Page, "frmConfigList.aspx");
                }
                else
                {
                    ShowMessageBox(Server.HtmlEncode(Result), this.Page);
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            BindData();
        }

    }
}