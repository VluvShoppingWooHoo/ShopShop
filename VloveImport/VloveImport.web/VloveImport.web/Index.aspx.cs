using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.data;
using VloveImport.util;
using VloveImport.biz;

namespace VloveImport.web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        #region for Scraping Web in ucSearchBox
        [WebMethod]
        public static string GetModelFromURL(string txt)
        {
            txt = "http://item.taobao.com/item.htm?spm=a215z.1607468.a214yav.11.ssGwcK&id=42865704337";

            ScrapingBiz sc = new ScrapingBiz();
            ScrapingDataModel data = new ScrapingDataModel();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                int webMode = 1;
                data = sc.Handle(txt, webMode);
            }
            catch (Exception ex) { }
            return js.Serialize(data);
            //return data;

        }
        #endregion
    }
}