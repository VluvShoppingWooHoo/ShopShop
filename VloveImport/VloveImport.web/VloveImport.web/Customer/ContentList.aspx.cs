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
    public partial class ContentList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                CMSContentBiz CMS = new CMSContentBiz();
                List<PromotionMonth> models = new List<PromotionMonth>();
                models = CMS.GetPromotionMonthList();
                JSONData jData = new JSONData();
                jData.Result = Constant.Fact.T;
                jData.ReturnVal = models;
                Session["PRO_MONTH"] = js.Serialize(jData);
            }
        }

        [WebMethod]
        public static string GetContent(string page, string MNY = "")
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            JSONData jData = new JSONData();
            CMSContentBiz CMS = new CMSContentBiz();
            List<ContentData> models = new List<ContentData>();
            try
            {
                if (MNY == string.Empty)
                {
                    MNY = (DateTime.Now.ToString("yyyy-MM-dd h:mm tt")).Substring(0, 7);
                    if (int.Parse(MNY.Substring(0, 4)) > 2500)
                        MNY = (int.Parse(MNY.Substring(0, 4)) - 543).ToString() + MNY.Substring(4, 3);
                }
                models = CMS.GetList(0, MNY);
                if (models.Count > 0)
                {
                    string path = (WebConfigurationManager.AppSettings["AdminURL"]).Replace("IMG_CMS/Attachment", "IMG_CMS");
                    for (int i = 0; i < models.Count; i++)
                    {
                        models[i].ContentImage = (path + models[i].ContentImage).Replace("\\", "/");
                        models[i].HEADER_IMG = (path + models[i].HEADER_IMG).Replace("\\", "/");
                    }
                    jData.Result = Constant.Fact.T;
                    jData.ReturnVal = models;
                }
                else
                    jData.Result = Constant.Fact.F;
            }
            catch (Exception ex) { }
            return js.Serialize(jData);
        }
    }
}