using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;

namespace VloveImport.web.admin.pages
{
    public partial class frmCmsList : System.Web.UI.Page
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
        #region function method
        private void BindData()
        {
            DataSet ds = new DataSet();
            try
            {
                AdminBiz AdBiz = new AdminBiz();
                ds = AdBiz.ADMIN_GET_CMS("0", txtTitle.Text.Trim(), ddl_Content_Type.SelectedValue.Trim(), "BINDDATA");

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
        #region btn click
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            ddl_Content_Type.SelectedIndex = 0;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCms.aspx");
        }
        #endregion
        #region grid
        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            util.EncrypUtil En = new util.EncrypUtil();
            Response.Redirect("frmCms.aspx?CID=" + Server.UrlEncode(En.EncrypData(DataKeys_ID)));
        }
        #endregion
    }
}