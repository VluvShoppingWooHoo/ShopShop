using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.data.Extension;

namespace VloveImport.web.Customer
{
    public partial class ContentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GetContent(string page)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            JSONData jData = new JSONData();
            CMSContentBiz CMS = new CMSContentBiz();
            List<ContentData> models = new List<ContentData>();
            try
            {
                models = CMS.GetList(0);
                jData.Result = Constant.Fact.T;
                jData.ReturnVal = models;
            }
            catch (Exception ex) { }
            return js.Serialize(jData);
        }
    }
}