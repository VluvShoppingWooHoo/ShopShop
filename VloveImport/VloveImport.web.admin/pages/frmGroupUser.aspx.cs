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
    public partial class frmGroupUser : System.Web.UI.Page
    {
        util.EncrypUtil Enc = new util.EncrypUtil();

        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        public int _VS_GROUP_ID
        {
            get { return Request.QueryString["GID"] == null ? 0 : Convert.ToInt32(Enc.DecryptData(Request.QueryString["GID"])); }
            set { ViewState["__VS_GROUP_ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminUserData Data = new AdminUserData();
                Data = (AdminUserData)(Session["AdminUser"]);
                _VS_USER_LOGIN = Data.USERNAME;

                if (_VS_GROUP_ID > 0)
                {
                    BindData();
                    lbl_header.Text = "Edit GroupUser Data";
                    btnSave.Text = "Update";
                }
                else
                {
                    lbl_header.Text = "Add GroupUser Data";
                    btnSave.Text = "Save";
                }
            }

            this.btnSave.Attributes.Add("onClick", "javascript:return confirm('Do you want to save data ?')");
        }

        public void BindData()
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = new DataSet();
            ds = AddBiz.GET_ADMIN_GET_GROUP_USER(_VS_GROUP_ID, "", -1, "BINDDATA_BYID");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtGroup_name.Enabled = false;
                txtGroup_name.CssClass = "textbox-readonly";
                txtGroup_name.Text = ds.Tables[0].Rows[0]["GROUP_NAME"].ToString();
                txtremark.Text = ds.Tables[0].Rows[0]["GROUP_REMARK"].ToString();
                ddl_GroupStatus.SelectedValue = ds.Tables[0].Rows[0]["GROUP_STATUS"].ToString();
                SetCheckBoxAnswer(ds.Tables[0].Rows[0]["GROUP_ROLE"].ToString()); 
            }

        }

        private void SetCheckBoxAnswer(string Description)
        {
            string[] Ans = Description.Split('|');
            if (Ans.Length > 0)
            {
                foreach (string str in Ans)
                {
                    switch (str)
                    {
                        case "01":
                            cb1.Checked = true;
                            break;
                        case "02":
                            cb2.Checked = true;
                            break;
                        case "03":
                            cb3.Checked = true;
                            break;
                        case "04":
                            cb4.Checked = true;
                            break;
                        case "05":
                            cb5.Checked = true;
                            break;
                        case "06":
                            cb6.Checked = true;
                            break;
                        case "07":
                            cb7.Checked = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private string GetCheckBoxAnswer()
        {
            string Answer = "";
            if (cb1.Checked)
                Answer += "01|";
            if (cb2.Checked)
                Answer += "02|";
            if (cb3.Checked)
                Answer += "03|";
            if (cb4.Checked)
                Answer += "04|";
            if (cb5.Checked)
                Answer += "05|";
            if (cb6.Checked)
                Answer += "06|";
            if (cb7.Checked)
                Answer += "07|";
            return Answer;
        }

        public bool ValiDate()
        {
            bool IsReturn = false;

            if (GetCheckBoxAnswer() == "")
            {
                ShowMessageBox("Please Select Role !!", this.Page);
                IsReturn = false;
            }
            else if(txtGroup_name.Text == "")
            {
                ShowMessageBox("Please fill out With the symbol * !!", this.Page);
                IsReturn = false;
            }

            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = new DataSet();
            ds = AddBiz.GET_ADMIN_GET_GROUP_USER(_VS_GROUP_ID == 0 ? -1 : _VS_GROUP_ID, txtGroup_name.Text.Trim(), -1, "CHECK_DATA");

            if (_VS_GROUP_ID == 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ShowMessageBox("Groupname already exists, please check again. !!", this.Page);
                    IsReturn = false;
                }
                else IsReturn = true;
            }
            else if (_VS_GROUP_ID > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (this._VS_GROUP_ID.ToString() != ds.Tables[0].Rows[0]["GROUP_ID"].ToString())
                    {
                        ShowMessageBox("Groupname already exists, please check again. !!", this.Page);
                        IsReturn = false;
                    }
                    else IsReturn = true;
                }
                else IsReturn = true;
            }
            else
            {
                IsReturn = false;
            }

            return IsReturn;
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
            if (ValiDate())
            {
                AdminUserData En = new AdminUserData();

                En.GROUP_ID = _VS_GROUP_ID;
                En.GROUP_NAME = txtGroup_name.Text.Trim();
                En.GROUP_REMARK = txtremark.Text.Trim();
                En.GROUP_ROLE = GetCheckBoxAnswer();
                En.GROUP_STATUS = Convert.ToInt32(ddl_GroupStatus.SelectedValue);
                En.Create_User = _VS_USER_LOGIN;

                AdminBiz AddBiz = new AdminBiz();
                string Result = AddBiz.ADMIN_INS_GROUP_USER(En, _VS_GROUP_ID > 0 ? "UPD" : "INS");
                if (Result == "")
                {
                    ShowMessageBox("Save success", this.Page, "frmGroupUserList.aspx");
                }
                else
                {
                    ShowMessageBox(Server.HtmlEncode(Result), this.Page);
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (_VS_GROUP_ID == 0)
            {
                txtGroup_name.Text = "";
                txtremark.Text = "";
                ddl_GroupStatus.SelectedIndex = 0;
            }
            else
            {
                SetcbAll(false);
                BindData();
            }
        }

        //protected void cbAll_CheckedChanged(object sender, EventArgs e)
        //{
        //    SetcbAll(cbAll.Checked);
        //}

        public void SetcbAll(bool chk)
        {
            ContentPlaceHolder cph = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");

            for (int i = 1; i <= 7; i++)
            {
                ((CheckBox)cph.FindControl("cb" + i.ToString())).Checked = chk;
            }
        }

    }
}