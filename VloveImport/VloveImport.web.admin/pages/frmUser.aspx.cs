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
    public partial class frmUser : System.Web.UI.Page
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
            _VS_USER_LOGIN = "admin";
            if (!IsPostBack)
            {
                BindDataGroupUser();
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

        public void BindDataGroupUser()
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_ADMIN_GET_GROUP_USER(_VS_GROUP_ID, "", 1, "BINDDROPDOWN");

            ddl_groupname.DataValueField = "GROUP_ID";
            ddl_groupname.DataTextField = "GROUP_NAME";
            ddl_groupname.DataSource = ds.Tables[0];
            ddl_groupname.DataBind();
            ddl_groupname.Items.Insert(0, new ListItem("Please select", "-1"));
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
                BindDataGroupUser();

                ddl_groupname.SelectedValue = ds.Tables[0].Rows[0]["GROUP_ID"].ToString();
                txtusername.Text = ds.Tables[0].Rows[0]["USERNAME"].ToString();

                ddl_Status.SelectedValue = ds.Tables[0].Rows[0]["EMP_STATUS"].ToString();
                txtFName.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
                txtLName.Text = ds.Tables[0].Rows[0]["EMP_LNAME"].ToString();
                txtDetail.Text = ds.Tables[0].Rows[0]["EMP_DETAIL"].ToString();
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

        public bool ValiDate()
        {
            bool IsReturn = false;

            if (ddl_groupname.SelectedValue == "-1" || txtusername.Text.Trim() == "" || txtFName.Text.Trim() == "" || txtLName.Text.Trim() == "")
            {
                ShowMessageBox("Please fill out With the symbol * !!", this.Page);
                IsReturn = false;
            }

            if (_VS_USER_ID == 0)
            {
                if (txtpassword.Text.Trim() == "" || txtRepassword.Text.Trim() == "")
                {
                    ShowMessageBox("Please enter your password !!", this.Page);
                    IsReturn = false;
                }

                if (txtpassword.Text.Trim() != txtRepassword.Text.Trim())
                {
                    ShowMessageBox("Please enter your password do not match !!", this.Page);
                    IsReturn = false;
                }

                AdminBiz AddBiz = new AdminBiz();
                DataSet ds = new DataSet();
                ds = AddBiz.GET_ADMIN_GET_USER(_VS_USER_ID == 0 ? -1 : _VS_USER_ID, txtusername.Text.Trim(), "", -1, "CHECK_DATA");

                if (_VS_USER_ID == 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ShowMessageBox("Username already exists, please check again. !!", this.Page);
                        IsReturn = false;
                    }
                    else IsReturn = true;
                }

            }
            else IsReturn = true;

            return IsReturn;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValiDate())
            {
                AdminUserData En = new AdminUserData();

                En.EMP_ID = _VS_USER_ID;
                En.GROUP_ID = Convert.ToInt32(ddl_groupname.SelectedValue);
                En.USERNAME = txtusername.Text.Trim();
                En.EMP_PASSWORD = Enc.EncrypData(txtpassword.Text.Trim());
                En.EMP_STATUS = Convert.ToInt32(ddl_Status.SelectedValue);

                En.EMP_NAME = txtFName.Text.Trim();
                En.EMP_LNAME = txtLName.Text.Trim();
                En.EMP_DETAIL = txtDetail.Text.Trim();
                En.Create_User = _VS_USER_LOGIN;

                AdminBiz AddBiz = new AdminBiz();
                string Result = AddBiz.ADMIN_INS_USER(En, _VS_USER_ID > 0 ? "UPD" : "INS");
                if (Result == "")
                {
                    ShowMessageBox("Save success", this.Page, "frmUserList.aspx");
                }
                else
                {
                    ShowMessageBox(Server.HtmlEncode(Result), this.Page);
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (_VS_USER_ID == 0)
            {
                ddl_groupname.SelectedIndex = 0;
                txtusername.Text = "";
                txtpassword.Text = "";
                txtRepassword.Text = "";

                ddl_Status.SelectedIndex = 0;
                txtFName.Text = "";
                txtLName.Text = "";
                txtDetail.Text = "";
            }
            else
            {
                BindData();
            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {

        }
    }
}