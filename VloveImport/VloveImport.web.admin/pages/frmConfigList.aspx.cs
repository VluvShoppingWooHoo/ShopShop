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
    public partial class frmConfigList : System.Web.UI.Page
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
                _VS_USER_LOGIN = "admin";
                BindData();
            }
        }

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
                ds = AdBiz.ADMIN_GET_CONFIG(txtconfigid.Text.Trim(), txtconfigGroup.Text.Trim(), "BINDDATA");

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

        #region Event Gridview

        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            util.EncrypUtil En = new util.EncrypUtil();
            Response.Redirect("frmConfig.aspx?CID=" + Server.UrlEncode(En.EncrypData(DataKeys_ID)));
        }

        protected void gv_detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_detail.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gv_detail_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gv_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtconfigid.Text = "";
            txtconfigGroup.Text = "";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmUser.aspx");
        }
    }
}