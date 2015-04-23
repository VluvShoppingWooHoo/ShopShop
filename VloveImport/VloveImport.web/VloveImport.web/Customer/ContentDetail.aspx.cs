using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.data.Extension;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class ContentDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CheckSession();
        }

        [WebMethod]
        public static string GetContentBYID(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            JSONData jData = new JSONData();
            CMSContentBiz CMS = new CMSContentBiz();
            ContentData models = new ContentData();
            try
            {
                models = CMS.GetContentByIDList(int.Parse(ID));
                string path = WebConfigurationManager.AppSettings["AdminURL"];
                models.ContentImage = path + models.ContentImage;
                jData.Result = Constant.Fact.T;
                jData.ReturnVal = models;
            }
            catch (Exception ex) { }
            return js.Serialize(jData);
        }
    }
}