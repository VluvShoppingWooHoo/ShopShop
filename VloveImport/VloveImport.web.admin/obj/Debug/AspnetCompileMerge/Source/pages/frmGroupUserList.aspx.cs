using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.admin.pages
{
    public partial class frmGroupUserList : System.Web.UI.Page
    {
        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminUserData Data = new AdminUserData();
                Data = (AdminUserData)(Session["AdminUser"]);
                _VS_USER_LOGIN = Data.USERNAME;

                BindData();
            }
        }

        #region Event Gridview

        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            util.EncrypUtil En = new util.EncrypUtil();
            Response.Redirect("frmGroupUser.aspx?GID=" + Server.UrlEncode(En.EncrypData(DataKeys_ID)));
        }

        protected void imgBtn_delete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string GROUP_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            AdminUserData En = new AdminUserData();
            En.GROUP_ID = Convert.ToInt32(GROUP_ID);

            AdminBiz AdBiz = new AdminBiz();
            string Result = AdBiz.ADMIN_INS_GROUP_USER(En, "DEL");
            if (Result == "")
            {
                BindData();
                ShowMessageBox("Delete Data success", this.Page);
            }
            else
            {
                ShowMessageBox(Server.HtmlEncode(Result), this.Page);
            }

        }

        protected void gv_detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_detail.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gv_detail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgBtn_delete")).Attributes.Add("onClick", "javascript:return confirm('Do you want to delete ?')");
            }
        }

        protected void gv_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        #endregion

        #region CustomSub

        public void ShowMessageBox(string message, Page currentPage)
        {
            string msgboxScript = "alert('" + message + "');";

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
            }
        }

        public void BindData()
        {
            DataSet ds = new DataSet();
            try
            {
                AdminBiz AdBiz = new AdminBiz();
                ds = AdBiz.GET_ADMIN_GET_GROUP_USER(-1, txtGroup_name.Text.Trim(), Convert.ToInt32(ddl_GroupStatus.SelectedValue), "BINDDATA");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gv_detail.DataSource = ds.Tables[0];
                    gv_detail.DataBind();
                }
                else
                {
                    gv_detail.DataSource = null;
                    gv_detail.DataBind();
                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtGroup_name.Text = "";
            ddl_GroupStatus.SelectedIndex = 0;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmGroupUser.aspx");
        }



    }
}