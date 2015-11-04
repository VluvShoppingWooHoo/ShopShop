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
    public partial class frmTracking : System.Web.UI.Page
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
            AdminUserData Data = new AdminUserData();
            Data = (AdminUserData)(Session["AdminUser"]);
            _VS_USER_LOGIN = Data.USERNAME;

            if (!IsPostBack)
            {
                if (_VS_USER_ID > 0)
                {
                    lbl_header.Text = "Edit User Data ";
                    btnSave.Text = "Update";
                    BindData();
                }
                else
                {
                    lbl_header.Text = "Add User Data ";
                    btnSave.Text = "Save";
                }
            }

            this.btnSave.Attributes.Add("onClick", "javascript:return confirm('Do you want to save data ?')");
        }        

        public void BindData()
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = new DataSet();
            ds = AddBiz.GET_ADMIN_GET_USER(_VS_USER_ID, "", "", -1, "BINDDATA_BYID");

            if (ds.Tables[0].Rows.Count > 0)
            {
                trpassword.Visible = false;
                txtusername.Enabled = false;
                txtusername.CssClass = "textbox-readonly";

                _VS_GROUP_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["GROUP_ID"].ToString());

                ddl_groupname.SelectedValue = ds.Tables[0].Rows[0]["GROUP_ID"].ToString();
                txtusername.Text = ds.Tables[0].Rows[0]["USERNAME"].ToString();

                ddl_Status.SelectedValue = ds.Tables[0].Rows[0]["EMP_STATUS"].ToString();
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
            

                //AdminBiz AddBiz = new AdminBiz();
                //string Result = AddBiz.ADMIN_INS_USER(En, _VS_USER_ID > 0 ? "UPD" : "INS");
                //if (Result == "")
                //{
                //    ShowMessageBox("Save success", this.Page, "frmUserList.aspx");
                //}
                //else
                //{
                //    ShowMessageBox(Server.HtmlEncode(Result), this.Page);
                //}
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            
        }

    }
}