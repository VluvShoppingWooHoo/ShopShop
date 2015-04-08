using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.admin.pages
{
    public partial class frmCMSContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string type = Request.QueryString["type"];
            hdfContentType.Value = type;
            trURL.Visible = false;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ScrapingBiz sb = new ScrapingBiz();
            ContentData cd = new ContentData();
            try
            {
                cd.ContentDate = DateTime.Today;
                cd.ContentImage = string.Empty;
                if (hdfContentType.Value != "1" && hdfContentType.Value != "2")
                {
                    //if (FileUploadControl.HasFile)
                    //{
                    //    if (FileUploadControl.PostedFile.ContentType == "image/jpg")
                    //    {
                    if (FileUploadControl.PostedFile.ContentLength < 102400)
                    {
                        string filename = Server.MapPath("~/img/CMSing/") + Path.GetFileName(FileUploadControl.FileName);
                        FileUploadControl.SaveAs(filename);
                        cd.ContentImage = filename;
                        //    }
                        //}
                    }
                    cd.ContentDetail = txtContentDetail.Text;
                    cd.ContentTitle = txtContentTitle.Text;
                }
                else
                {
                    cd.ContentDetail = txtURL.Text;
                }
                cd.ContentType = hdfContentType.Value;
            }
            catch (Exception ex)
            {
            }
        }
    }
}