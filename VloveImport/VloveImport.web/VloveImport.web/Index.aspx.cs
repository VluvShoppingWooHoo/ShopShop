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
using VloveImport.data.Extension;
using Facebook;
using System.Xml;
using System.Web.Configuration;
using System.ServiceModel.Syndication;
using System.Net;
using System.Text;
using System.IO;
using VloveImport.web.App_Code;
//using SimpleBrowser;
//using OpenQA.Selenium.PhantomJS;
//using OpenQA.Selenium;

namespace VloveImport.web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ////if (txtUser.Text == "")
            ////{
            ////    txtUser.Focus();
            ////    return;
            ////}
            ////if (txtPass.Text == "")
            ////{
            ////    txtPass.Focus();
            ////    return;
            ////}

            //LogonBiz Logon = new LogonBiz();
            //CustomerData Cust = new CustomerData();
            //Cust = Logon.LogonDBCustomer(txtUser.Text, txtPass.Text);
            //if (Cust != null)
            //{
            //    Session["User"] = Cust;
            //    Response.Redirect("~/Index.aspx");
            //}
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            //txtUser.Text = "";
            //txtPass.Text = "";
        }

        private void CheckSession()
        {
            //if (Session["User"] != null)
            //    Login.Visible = false;
            //else
            //    Login.Visible = true;
        }

        #region for Scraping Web in ucSearchBox & ucIndexBox
        [WebMethod]
        public static string GetModelFromURL(string txt)
        {
            //try
            //{
            //    string PhantomDirectory = @"..\..\..\packages\PhantomJS.2.0.0\tools\phantomjs";
            //    using (IWebDriver phantomDriver = new PhantomJSDriver(PhantomDirectory))
            //    {
            //        phantomDriver.Url = txt;
            //        //Assert.Contains("Google", phantomDriver.Title);
            //    }
            //}
            //catch (Exception ex) { }
            //txt = "http://item.taobao.com/item.htm?spm=a215z.1607468.a214yav.11.ssGwcK&id=42865704337";
            //txt = "http://item.taobao.com/item.htm?id=42400927372&ali_refid=a3_420435_1006:1106126314:N:%B2%CA%BA%E7%D0%AC:7055520b07090b98fe54085c41bad517&ali_trackid=1_7055520b07090b98fe54085c41bad517&spm=a230r.1.1005.40.wn70vl";
            ScrapingBiz sc = new ScrapingBiz();
            ScrapingData data = new ScrapingData();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                int webMode = 1;
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
                #region for test
                //data.Color = "http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2_8NXbpXXXXXkXXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2j6oZbXXXXXbTXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2QDs2bXXXXXXWXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img02.taobaocdn.com/bao/uploaded/i2/1060829869/TB2yD25bXXXXXaMXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img04.taobaocdn.com/bao/uploaded/i4/1060829869/TB2LQj6bXXXXXc2XXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img01.taobaocdn.com/bao/uploaded/i1/1060829869/TB2zmr.bXXXXXbOXXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg";
                //data.ItemName = "[Bommy]Test Test";
                //data.picURL = "http://img04.taobaocdn.com/bao/uploaded/i4/TB12EHiGVXXXXX6XXXXXXXXXXXX_!!0-item_pic.jpg_400x400.jpg";
                //data.Price = "69";
                //data.Size = "70/32AB||75/34AB||80/36AB";
                #endregion
                data.Web = webMode;
                #region getID
                string[] a = txt.Split('?');
                string[] b = a[1].Split('&');
                data.URL = txt;
                if (webMode == 1)
                {
                    foreach (string item in b)
                    {
                        if (item.IndexOf("id=") == 0)
                        {
                            data.URL = a[0] + '?' + item;
                            txt = item.Replace("id=", "");
                        }
                    }
                }
                data.ItemID = txt;
                #endregion
            }
            catch (Exception ex) { }
            return js.Serialize(data);
        }

        [WebMethod]
        public static string GetSideMenu()
        {
            //From weloveshopping
            ScrapingBiz sc = new ScrapingBiz();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string tag = string.Empty;
            try
            {
                //tag = sc.GetSideMenu("http://portal.weloveshopping.com/");
                tag = sc.GetSideMenu("http://www.vcanbuy.com/protected/faqs/tree");
            }
            catch (Exception ex) { }
            return tag;
            //return js.Serialize(tag);
            //return data;

        }
        #endregion

        #region AddToCart
        [WebMethod]
        public static string btnSearch(string Name, string Desc, string Amount, string Price, string Size,
            string Color, string Remark, string URL, string Picture, string ShopName)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            Index Index = new Index();
            ScrapingData Data = new ScrapingData();
            //Data.CUS_ID = 
            Data.CUS_BK_ITEMNAME = Name;
            Data.CUS_BK_ITEMDESC = Name;
            Data.CUS_BK_AMOUNT = Convert.ToInt32(Amount);
            Data.CUS_BK_PRICE = Convert.ToDouble(Price);
            Data.CUS_BK_SIZE = Size;
            Data.CUS_BK_COLOR = Color;
            Data.CUS_BK_REMARK = Remark;
            Data.CUS_BK_URL = URL;
            Data.CUS_BK_PICURL = Picture;
            Data.CUS_BK_STATUS = "BASKET";
            Data.Create_User = "";
            Data.CUS_BK_SHOPNAME = ShopName;
            Result = Index.AddToCart(Data);
            if (Result != "")
            {
                //Alert Contact Admin
            }
            else
            {
                //Close Popup
            }
            return js.Serialize(Result);
        }

        protected string AddToCart(ScrapingData Data)
        {
            string Result = "";
            ShoppingBiz Biz = new ShoppingBiz();
            BasePage bp = new BasePage();
            Data.CUS_ID = bp.GetCusID();
            Result = Biz.AddtoCart(Data);
            return Result;
        }
        #endregion

        #region News Feed
        [WebMethod]
        public static string GetContent()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            JSONData jData = new JSONData();
            CMSContentBiz CMS = new CMSContentBiz();
            List<ContentData> models = new List<ContentData>();
            try
            {
                models = CMS.GetList(0);
                if (models.Count > 0)
                {
                    string path = WebConfigurationManager.AppSettings["AdminURL"];
                    for (int i = 0; i < models.Count; i++)
                    {
                        models[i].ContentImage = path + models[i].ContentImage;
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
        [WebMethod]
        public static string GetNewsFeed()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            JSONData jData = new JSONData();
            string xml;
            try
            {
                string URL = WebConfigurationManager.AppSettings["NewsFeedURL"];
                using (WebClient webClient = new WebClient())
                {
                    xml = Encoding.UTF8.GetString(webClient.DownloadData(URL));
                }
                xml = xml.Replace("+07:00", "");
                string[] separators = { "</pubDate>" };
                string[] xmlArr = xml.Split(separators, StringSplitOptions.None);
                xml = "";
                foreach (string item in xmlArr)
                {
                    int count = item.Trim().Length;
                    string txt = string.Empty;
                    if (item.Trim().Substring(count - 1, 1) == ">")
                        txt = item.Trim().Substring(0, count - 9);
                    else
                        txt = item.Trim().Substring(0, count - 28);
                    xml += txt.Trim();
                }
                byte[] bytes = System.Text.UTF8Encoding.ASCII.GetBytes(xml);
                XmlReader reader = XmlReader.Create(new MemoryStream(bytes));
                SyndicationFeed feed = new SyndicationFeed();
                //feed.
                feed = SyndicationFeed.Load(reader);
                foreach (SyndicationItem item in feed.Items)
                {
                    //String subject = item.Title.Text;
                    //String summary = item.Summary.Text;
                }


                //while (reader.Read())
                //{
                //    switch (reader.NodeType)
                //    {
                //        case XmlNodeType.Element: // The node is an element.
                //            result += "<" + reader.Name;

                //            while (reader.MoveToNextAttribute()) // Read the attributes.
                //                result += " " + reader.Name + "='" + reader.Value + "'";
                //            result += ">";
                //            result += "<br />";
                //            //Console.WriteLine(">");
                //            break;
                //        case XmlNodeType.Text: //Display the text in each element.
                //            result += reader.Value;
                //            break;
                //        case XmlNodeType.EndElement: //Display the end of the element.
                //            result += "</" + reader.Name;
                //            result += ">";
                //            break;
                //    }
                //}
                ////XmlDocument xml = new XmlDocument();
                ////xml.Load(reader);
                //jData.ReturnVal = result;
                jData.Result = Constant.Fact.T;
            }
            catch (Exception ex) { }
            return js.Serialize(jData);

        }
        #endregion
    }
}
