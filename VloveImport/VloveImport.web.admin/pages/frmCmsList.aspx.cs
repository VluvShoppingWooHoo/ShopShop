using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.data.Extension;

namespace VloveImport.web.admin.pages
{
    public partial class frmCmsList : System.Web.UI.Page
    {
        util.EncrypUtil Enc = new util.EncrypUtil();

        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        public string _VS_CONTENT_ID
        {
            get { return Request.QueryString["CID"] == null ? "" : Enc.DecryptData(Request.QueryString["CID"]); }
            set { ViewState["_VS_CONTENT_ID"] = value; }
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
            //if (!IsPostBack)
            //{
                try
                {
                    AdminBiz AdBiz = new AdminBiz();
                    ds = AdBiz.ADMIN_GET_CMS("0", txtTitle.Text.Trim(), ddl_Content_Type.SelectedValue.Trim(), chkIsActive.Checked == true ? 1 : 0, _VS_CONTENT_ID, "BINDDATA");

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

                    AdBiz = new AdminBiz();
                    ds = new DataSet();
                    ds = AdBiz.ADMIN_GET_CMS_HEADER(_VS_CONTENT_ID, string.Empty, 1, "BINDDATA_BYID");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblLegend.Text = ds.Tables[0].Rows[0]["HEADER_TITLE"].ToString();
                        txtHeaderTitle.Text = ds.Tables[0].Rows[0]["HEADER_TITLE"].ToString();
                        txtOrder.Text = ds.Tables[0].Rows[0]["HEADER_ORDER"].ToString();
                        ddl_Header_Content_Type.SelectedValue = ds.Tables[0].Rows[0]["HEADER_TYPE"].ToString();
                        hdHeaderContentIMG.Value = ds.Tables[0].Rows[0]["HEADER_IMG"].ToString();
                        hdfContentType.Value = ds.Tables[0].Rows[0]["HEADER_TYPE"].ToString();
                        if ((bool)ds.Tables[0].Rows[0]["IS_ACTIVE"]) chkIsActive.Checked = true;
                        else chkIsActive.Checked = false;
                    }
                }
                catch (Exception ex)
                {

                }
            //}
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
            chkIsActive.Checked = true;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            util.EncrypUtil En = new util.EncrypUtil();
            Response.Redirect("frmCms.aspx?type=" + Server.UrlEncode(En.EncrypData(hdfContentType.Value)) + "&head=" + Server.UrlEncode(En.EncrypData(_VS_CONTENT_ID)));
        }
        #endregion
        #region grid
        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            util.EncrypUtil En = new util.EncrypUtil();
            Response.Redirect("frmCms.aspx?type=" + Server.UrlEncode(En.EncrypData(hdfContentType.Value)) + "&CID=" + Server.UrlEncode(En.EncrypData(DataKeys_ID)) + "&head=" + Server.UrlEncode(En.EncrypData(_VS_CONTENT_ID)));
        }
        #endregion

        protected void ddl_Header_Content_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminBiz ab = new AdminBiz();
            ContentData cd = new ContentData();
            string Result = string.Empty;
            string Act = _VS_CONTENT_ID == "" ? "INS" : "UPD";
            try
            {
                //cd.IsActive = chkIsActive.Checked == true ? 1 : 0;
                cd.IsActive = 1;
                cd.ContentID = _VS_CONTENT_ID == "" ? 0 : int.Parse(_VS_CONTENT_ID);
                cd.ContentDate = DateTime.Today;
                cd.ContentImage = hdHeaderContentIMG.Value;
                cd.HEADER_ORDER = txtOrder.Text;
                if (FileUploadControl.HasFile)
                {
                    string folder = Server.MapPath("~/HeaderAttachment");
                    bool exists = System.IO.Directory.Exists(folder);
                    if (!exists)
                        System.IO.Directory.CreateDirectory(folder);
                    FileUploadControl.SaveAs(folder + "\\" + Path.GetFileName(FileUploadControl.FileName));
                    string filename = "HeaderAttachment\\" + Path.GetFileName(FileUploadControl.FileName);
                    cd.ContentImage = filename;
                }
                //cd.ContentDetail = (htmlObject(txtContentDetail.Text)).Replace('<', '[').Replace('>', ']');
                cd.ContentTitle = txtHeaderTitle.Text;
                cd.ContentType = hdfContentType.Value;

                Result = ab.ADMIN_INS_UPD_CMS_HEADER(cd, Act);
                if (Result != string.Empty)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('" + Result + "');", false);
                }
                Response.Redirect("frmCmsHeaderList.aspx");
            }
            catch (Exception ex)
            {
            }
        }
    }
}