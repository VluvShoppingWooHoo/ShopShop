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
    public partial class frmCms : System.Web.UI.Page
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
            _VS_USER_LOGIN = "admin";
            if (!IsPostBack)
            {
                if (_VS_CONTENT_ID != "")
                {
                    BindData();
                }
                else
                {
                    trURL.Visible = false;
                    lblLegend.Text = "Promotion Content";
                    hdfContentType.Value = "1";
                }
            }
        }

        public void BindData()
        {
            try
            {
                AdminBiz AddBiz = new AdminBiz();
                DataSet ds = new DataSet();
                ds = AddBiz.ADMIN_GET_CMS(_VS_CONTENT_ID, string.Empty, "0", 1, "BINDDATA_BYID");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtContentTitle.Text = ds.Tables[0].Rows[0]["CONTENT_TITLE"].ToString();
                    txtContentDetail.Text = ds.Tables[0].Rows[0]["CONTENT_DETAIL"].ToString();
                    ddl_Content_Type.SelectedValue = ds.Tables[0].Rows[0]["CONTENT_TYPE"].ToString();
                    hdContentIMG.Value = ds.Tables[0].Rows[0]["CONTENT_IMG"].ToString();
                    if ((bool)ds.Tables[0].Rows[0]["IS_ACTIVE"]) chkIsActive.Checked = true;
                    else chkIsActive.Checked = false;
                    chkType(ds.Tables[0].Rows[0]["CONTENT_TYPE"].ToString());
                    if (hdfContentType.Value == "3")
                    {
                        txtURL.Text = (ds.Tables[0].Rows[0]["CONTENT_DETAIL"].ToString()).Split('|')[0].ToString();
                    }
                }
            }
            catch (Exception ex) { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AdminBiz ab = new AdminBiz();
            ContentData cd = new ContentData();
            string Result = string.Empty;
            string Act = _VS_CONTENT_ID == "" ? "INS" : "UPD";
            try
            {
                cd.IsActive = chkIsActive.Checked == true ? 1 : 0;
                cd.ContentID = _VS_CONTENT_ID == "" ? 0 : int.Parse(_VS_CONTENT_ID);
                cd.ContentDate = DateTime.Today;
                cd.ContentImage = hdContentIMG.Value;
                if (hdfContentType.Value == "1" || hdfContentType.Value == "2")
                {
                    if (FileUploadControl.HasFile)
                    {
                        string folder = Server.MapPath("~/Attachment");
                        bool exists = System.IO.Directory.Exists(folder);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(folder);
                        FileUploadControl.SaveAs(folder + "\\" + Path.GetFileName(FileUploadControl.FileName));
                        string filename = "Attachment\\" + Path.GetFileName(FileUploadControl.FileName);
                        cd.ContentImage = filename;
                    }
                    cd.ContentDetail = htmlObject(txtContentDetail.Text);
                    cd.ContentTitle = txtContentTitle.Text;
                }
                else
                {
                    ScrapingBiz sc = new ScrapingBiz();
                    ScrapingData data = new ScrapingData();
                    int webMode = 1;
                    string txt = txtURL.Text;
                    #region for use
                    if (txt.Contains("taobao.com"))
                    {
                        webMode = Constant.Web.WTaoBao;
                        if (txt.Contains(Constant.WebSubTaobao.TW_Taobao))
                        {
                            int end = txt.IndexOf(".htm?");
                            string newURL = txt.Substring(0, end);
                            int start = newURL.LastIndexOf("/");
                            string ID = newURL.Substring(start + 1, newURL.Length - (start + 1));
                            txt = Constant.WebTemplate.Taobao + ID;
                        }
                    }
                    else if (txt.Contains("tmall.com"))
                        webMode = Constant.Web.WTmall;
                    else
                        webMode = Constant.Web.W1688;

                    data = sc.Handle(txt, webMode);
                    #endregion
                    cd.ContentDetail = data.picURL + "|" + data.ItemName.Replace("|", "_") + "|" + txtURL.Text;
                }
                cd.ContentType = hdfContentType.Value;

                Result = ab.ADMIN_INS_UPD_CMS(cd, Act);
                Response.Redirect("frmCmsList.aspx");
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddl_Content_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkType(((System.Web.UI.WebControls.ListControl)(sender)).SelectedValue);
        }

        private void chkType(string type)
        {
            hdfContentType.Value = type;
            trURL.Visible = false;
            trHtmlEditor.Visible = true;
            trIMG.Visible = true;
            trTitle.Visible = true;
            if (type == "1")
                lblLegend.Text = "Promotion Content";
            else if (type == "2")
                lblLegend.Text = "News Content";
            else
            {
                lblLegend.Text = "Recommend Content";
                trHtmlEditor.Visible = false;
                trIMG.Visible = false;
                trTitle.Visible = false;
                trURL.Visible = true;
            }
        }

        private string htmlObject(string txt)
        {
            #region Font Size
            txt = txt.Replace("size=\"1\"", "style='font-size:0.63em !important;'")
                .Replace("size=\"2\"", "style='font-size:0.82em !important;'")
                .Replace("size=\"3\"", "style='font-size:1.0em !important;'")
                .Replace("size=\"4\"", "style='font-size:1.13em !important;'")
                .Replace("size=\"5\"", "style='font-size:1.5em !important;'")
                .Replace("size=\"6\"", "style='font-size:2em !important;'")
                .Replace("size=\"7\"", "style='font-size:3em !important;'");
            #endregion
            return txt;
        }
    }
}