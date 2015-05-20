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
using System.Xml;
using System.Web.Configuration;
using System.ServiceModel.Syndication;
using System.Net;
using System.Text;
using System.IO;
using VloveImport.web.App_Code;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support;
using System.Reflection;
using System.Text.RegularExpressions;
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
            Index ix = new Index();
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

                //data = sc.Handle(txt, webMode);
                data = ix.Scrap(txt, webMode);
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
                if (webMode == 1)
                {
                    string[] a = txt.Split('?');
                    string[] b = a[1].Split('&');
                    data.URL = txt;
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
            catch (Exception ex) { return ""; }
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
                models = CMS.GetList(0, "");
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

        #region private function
        private List<string> TranslateToEng(List<string> val)
        {
            List<string> listResult = new List<string>();
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = System.Text.Encoding.GetEncoding(54936);
                string url = string.Empty;
                int i = 0;
                foreach (string item in val)
                {
                    string result = string.Empty;
                    string[] separators = { "||" };
                    if (i == 1 || i == 2)
                    {
                        string strloop = string.Empty;
                        foreach (string txt in item.Split(separators, StringSplitOptions.None))
                        {
                            url = String.Format("http://www.google.com/translate_t?hl=en&text={0}&langpair={1}", txt, "zh-CN|en");
                            result = webClient.DownloadString(url);
                            string selectVal = result.Substring(result.IndexOf("id=result_box"), result.Length - result.IndexOf("id=result_box"));
                            selectVal = selectVal.Substring(selectVal.IndexOf(">__z__") + 6, selectVal.IndexOf("__zzz__<") - (selectVal.IndexOf(">__z__") + 6));
                            selectVal = selectVal.Replace(" ^ _p ^ ", "^_p^").Replace(" ^ _ p ^ ", "^_p^");
                            strloop += selectVal + "||";
                        }
                        strloop = strloop.Remove(strloop.Length - 2, 2);
                        listResult.Add(strloop);
                    }
                    else
                    {
                        url = String.Format("http://www.google.com/translate_t?hl=en&text={0}&langpair={1}", item, "zh-CN|en");
                        result = webClient.DownloadString(url);
                        string selectVal = result.Substring(result.IndexOf("id=result_box"), result.Length - result.IndexOf("id=result_box"));
                        selectVal = selectVal.Substring(selectVal.IndexOf(">__z__") + 6, selectVal.IndexOf("__zzz__<") - (selectVal.IndexOf(">__z__") + 6));
                        selectVal = selectVal.Replace(" ^ _p ^ ", "^_p^").Replace(" ^ _ p ^ ", "^_p^"); ;
                        listResult.Add(selectVal);
                    }
                    i++;
                }

                //selectVal = selectVal.Replace(">_zz ^", ">^ _zz ^").Replace("> _zz ^", ">^ _zz ^").Replace(">  _zz ^", ">^ _zz ^");
                //selectVal = selectVal.Substring(selectVal.IndexOf(">^ _z ^") + 7, selectVal.IndexOf("^ _zz ^") - (selectVal.IndexOf(">^ _z ^") + 7));
                //selectVal2 += selectVal;
                //val = selectVal2.Replace("  _p ^", "^_p^").Replace("_ ", "_").Replace(" _", "_").Replace(" _^", "_^").Replace("^_ ", "^_").Replace("^ ", "^").Replace(" ^", "^");
            }
            catch (Exception ex) { return new List<string>(); }
            return listResult;
        }

        IWebDriver driver;
        public ScrapingData Scrap(string url, int web)
        {
            ScrapingData model = new ScrapingData();
            try
            {
                string EXEpath = Server.MapPath("exe").ToString();
                //driver = new ChromeDriver(ChromeEXE);
                driver = new PhantomJSDriver(EXEpath);
                TimeSpan time = new TimeSpan(60);
                driver.Manage().Timeouts().ImplicitlyWait(time);
                driver.Navigate().GoToUrl(url);
                if (web == Constant.Web.WTaoBao)
                    model = GetTaobao(driver);
                else if (web == Constant.Web.WTmall)
                    model = GetTMall(driver);
                else if (web == Constant.Web.W1688)
                    model = Get1688(driver);

                if (model.ProPrice != "0" && (model.ProPrice != string.Empty))
                    model.Price = model.ProPrice;
                driver.Quit();
                model.URL = url;
                #region for translate
                #region v1.
                //string val = string.Empty;
                //val += "^_z^";
                //val += model.ItemName + "^_b^";

                //string[] separators = { "||" };
                //string[] color = model.Color.Split(separators, StringSplitOptions.None);
                //string[] size = model.Size.Split(separators, StringSplitOptions.None);
                //if (color.Count() > 0 && color[0] != string.Empty)
                //{
                //    bool chk = false;
                //    val += "^_c^";
                //    foreach (string item in color)
                //    {
                //        if (!(item.Contains(".jpg") || item.Contains(".JPG") || item.Contains(".png") || item.Contains(".PNG") || item.Contains(".gif") || item.Contains(".GIF")))
                //        { chk = true; val += item + "||"; }
                //    }
                //    if (chk)
                //        val = val.Remove(val.Length - 2, 2);
                //    val += "^_b^";
                //}
                //if (size.Count() > 0 && size[0] != string.Empty)
                //{
                //    bool chk = false;
                //    val += "^_s^";
                //    foreach (string item in size)
                //    {
                //        if (!(item.Contains(".jpg") || item.Contains(".JPG") || item.Contains(".png") || item.Contains(".PNG") || item.Contains(".gif") || item.Contains(".GIF")))
                //        { chk = true; val += item + "||"; }
                //    }
                //    if (chk)
                //        val = val.Remove(val.Length - 2, 2);
                //    val += "^_b^";
                //}
                //val += model.ShopName;
                //val += "^_zz^";
                #endregion
                #region v2.
                List<string> val = new List<string>();
                val.Add("__z__" + model.ItemName + "__zzz__");
                string[] separators = { "||" };
                string[] color = model.Color.Split(separators, StringSplitOptions.None);
                string[] size = model.Size.Split(separators, StringSplitOptions.None);
                string txt = string.Empty;
                if (color.Count() > 0 && color[0] != string.Empty)
                {
                    bool chk = false;
                    foreach (string item in color)
                    {
                        if (!(item.Contains(".jpg") || item.Contains(".JPG") || item.Contains(".png") || item.Contains(".PNG") || item.Contains(".gif") || item.Contains(".GIF")))
                        { chk = true; txt += "__z__" + item + "__zzz__||"; }
                    }
                    if (chk)
                        txt = txt.Remove(txt.Length - 2, 2);
                    //txt = RemoveSpecialCharacters(txt);
                }
                val.Add(txt);
                if (size.Count() > 0 && size[0] != string.Empty)
                {
                    bool chk = false;
                    txt = string.Empty;
                    foreach (string item in size)
                    {
                        if (!(item.Contains(".jpg") || item.Contains(".JPG") || item.Contains(".png") || item.Contains(".PNG") || item.Contains(".gif") || item.Contains(".GIF")))
                        { chk = true; txt += "__z__" + item + "__zzz__||"; }
                    }
                    if (chk)
                        txt = txt.Remove(txt.Length - 2, 2);
                    //txt = RemoveSpecialCharacters(txt);
                }
                val.Add(txt);
                val.Add("__z__" + model.ShopName + "__zzz__");
                #endregion
                val = TranslateToEng(val);
                //string[] separators2 = { "^_b^" };
                //string[] result = val.Split(separators2, StringSplitOptions.None);
                for (int i = 0; i < val.Count(); i++)
                {
                    val[i] = val[i].Replace("__z__", "").Replace("__zzz__", "");
                    if (i == 0)
                    {
                        model.ItemName = val[i];
                        //model.ItemName.Replace("^", "");
                    }
                    else if (i == 1)
                    {
                        if (val[i] != string.Empty)
                        {
                            int count = 0;
                            string col = string.Empty;
                            for (int j = 0; j < color.Count(); j++)
                            {
                                if (!(color[j].Contains(".jpg") || color[j].Contains(".JPG") || color[j].Contains(".png") || color[j].Contains(".PNG") || color[j].Contains(".gif") || color[j].Contains(".GIF")))
                                { col += val[i].Split(separators, StringSplitOptions.None)[count].Trim() + "||"; count++; }
                                else
                                { col += color[j] + "||"; }
                            }
                            col = col.Remove(col.Length - 2, 2);
                            model.Color = col;
                            //model.Color.Replace("^", "");
                        }
                    }
                    else if (i == 2)
                    {
                        if (val[i] != string.Empty)
                        {
                            int count = 0;
                            string siz = string.Empty;
                            for (int j = 0; j < size.Count(); j++)
                            {
                                if (!(size[j].Contains(".jpg") || size[j].Contains(".JPG") || size[j].Contains(".png") || size[j].Contains(".PNG") || size[j].Contains(".gif") || size[j].Contains(".GIF")))
                                { siz += val[i].Split(separators, StringSplitOptions.None)[count].Trim() + "||"; count++; }
                                else
                                { siz += size[j] + "||"; }
                            }
                            siz = siz.Remove(siz.Length - 2, 2);
                            model.Size = siz;
                            //model.Size.Replace("^", "");
                        }
                    }
                    else
                    {
                        model.ShopName = val[i];
                        //model.ShopName.Replace("^", "");
                    }
                }
                #endregion
            }
            catch (Exception ex) { return null; }
            return model;
        }
        #region Get Property to model
        private ScrapingData GetTaobao(IWebDriver driver)
        {
            ScrapingData model = new ScrapingData();
            try
            {
                foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
                {
                    if (propertyInfo.CanRead)
                    {
                        if (propertyInfo.Name != Constant.ScrapModel.Web)
                        {
                            switch (propertyInfo.Name)
                            {
                                case Constant.ScrapModel.ItemName:
                                    try
                                    {
                                        model.ItemName = driver.FindElement(By.Id("J_Title")).FindElement(By.ClassName("tb-main-title")).Text;
                                        if (model.ItemName.Contains("\r\n")) model.ItemName = model.ItemName.Substring(0, model.ItemName.IndexOf("\r\n"));
                                    }
                                    catch (Exception ex) { model.ItemName = string.Empty; }
                                    break;
                                case Constant.ScrapModel.picURL:
                                    try { model.picURL = driver.FindElement(By.Id("J_ImgBooth")).GetAttribute("data-src").ToString(); }
                                    catch (Exception ex) { model.picURL = string.Empty; }
                                    break;
                                case Constant.ScrapModel.Price:
                                    try { model.Price = driver.FindElement(By.Id("J_StrPrice")).FindElement(By.ClassName("tb-rmb-num")).Text; }
                                    catch (Exception ex) { model.Price = "0"; }
                                    break;
                                case Constant.ScrapModel.ProPrice:
                                    try { model.ProPrice = driver.FindElement(By.Id("J_PromoPriceNum")).Text; }
                                    catch (Exception ex) { model.ProPrice = "0"; }
                                    break;
                                case Constant.ScrapModel.Color:
                                    try
                                    {
                                        string Color = string.Empty;
                                        IReadOnlyCollection<IWebElement> elements = driver.FindElement(By.ClassName("J_Prop_Color")).FindElement(By.ClassName("J_TSaleProp")).FindElements(By.TagName("li"));
                                        for (int i = 0; i < elements.Count; i++)
                                        {
                                            try
                                            {
                                                int start = 0, end = 0;
                                                string price = "0";
                                                string c = Color;
                                                IWebElement elem = elements.ToList()[i].FindElement(By.TagName("a"));
                                                elem.Click();
                                                string val = elem.GetAttribute("style").ToString().Trim();
                                                if (val.Contains("background-image"))
                                                {
                                                    start = val.IndexOf('(') + 1;
                                                    end = val.IndexOf(')');
                                                    Color += val.Substring(start, (end - start));
                                                }
                                                else
                                                    Color += elem.Text;

                                                if (c != Color)
                                                {
                                                    if (model.ProPrice != "0" && (model.ProPrice != string.Empty))
                                                        price = driver.FindElement(By.Id("J_PromoPriceNum")).Text;
                                                    else
                                                        price = driver.FindElement(By.Id("J_StrPrice")).FindElement(By.ClassName("tb-rmb-num")).Text;

                                                    if (price.Contains("-"))
                                                        price = price.Split('-')[0].Trim();

                                                    Color += "^_p^" + price;
                                                    Color += "||";
                                                }
                                            }
                                            catch (Exception ex) { }
                                        }
                                        Color = Color.Remove(Color.Length - 2, 2);
                                        model.Color = Color;
                                    }
                                    catch (Exception ex) { model.Color = string.Empty; }
                                    break;
                                case Constant.ScrapModel.Size:
                                    try
                                    {
                                        string Size = string.Empty;
                                        IReadOnlyCollection<IWebElement> elements = driver.FindElement(By.ClassName("J_TMySizeProp")).FindElement(By.ClassName("J_TSaleProp")).FindElements(By.TagName("li"));
                                        for (int i = 0; i < elements.Count; i++)
                                        {
                                            string price = "0";
                                            IWebElement elem = elements.ToList()[i].FindElement(By.TagName("a"));
                                            Size += elem.Text;
                                            elem.Click();
                                            if (model.ProPrice != "0" && (model.ProPrice != string.Empty))
                                                price = driver.FindElement(By.Id("J_PromoPriceNum")).Text;
                                            else
                                                price = driver.FindElement(By.Id("J_StrPrice")).FindElement(By.ClassName("tb-rmb-num")).Text;

                                            if (price.Contains("-"))
                                                price = price.Split('-')[0].Trim();

                                            Size += "^_p^" + price;
                                            Size += "||";
                                        }
                                        Size = Size.Remove(Size.Length - 2, 2);
                                        model.Size = Size;
                                    }
                                    catch (Exception ex) { model.Size = string.Empty; }
                                    break;
                                case Constant.ScrapModel.ShopName:
                                    try { model.ShopName = driver.FindElement(By.ClassName("tb-shop-name")).Text; }
                                    catch (Exception ex) { model.ShopName = string.Empty; }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { return null; }
            return model;
        }
        private ScrapingData GetTMall(IWebDriver driver)
        {
            ScrapingData model = new ScrapingData();
            try
            {
                foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
                {
                    if (propertyInfo.CanRead)
                    {
                        if (propertyInfo.Name != Constant.ScrapModel.Web)
                        {
                            switch (propertyInfo.Name)
                            {
                                case Constant.ScrapModel.ItemName:
                                    try
                                    {
                                        model.ItemName = driver.FindElement(By.ClassName("tb-detail-hd")).Text;
                                        if (model.ItemName.Contains("\r\n")) model.ItemName = model.ItemName.Substring(0, model.ItemName.IndexOf("\r\n"));
                                    }
                                    catch (Exception ex) { model.ItemName = string.Empty; }
                                    break;
                                case Constant.ScrapModel.picURL:
                                    try { model.picURL = driver.FindElement(By.Id("J_ImgBooth")).GetAttribute("src").ToString(); }
                                    catch (Exception ex) { model.picURL = string.Empty; }
                                    break;
                                case Constant.ScrapModel.Price:
                                    try { model.Price = driver.FindElement(By.Id("J_StrPriceModBox")).FindElement(By.ClassName("tm-price")).Text; }
                                    catch (Exception ex) { model.Price = "0"; }
                                    break;
                                case Constant.ScrapModel.ProPrice:
                                    try { model.ProPrice = driver.FindElement(By.Id("J_PromoPrice")).FindElement(By.ClassName("tm-price")).Text; }
                                    catch (Exception ex) { model.ProPrice = "0"; }
                                    break;
                                case Constant.ScrapModel.Color:
                                    try
                                    {
                                        string Color = string.Empty;
                                        IReadOnlyCollection<IWebElement> elements = driver.FindElement(By.ClassName("tb-img")).FindElements(By.TagName("li"));
                                        for (int i = 0; i < elements.Count; i++)
                                        {
                                            try
                                            {
                                                int start = 0, end = 0;
                                                string price = "0";
                                                string c = Color;
                                                IWebElement elem = elements.ToList()[i].FindElement(By.TagName("a"));
                                                elem.Click();
                                                string val = elem.GetAttribute("style").ToString().Trim();
                                                if (val.Contains("background-image"))
                                                {
                                                    start = val.IndexOf('(') + 1;
                                                    end = val.IndexOf(')');
                                                    Color += val.Substring(start, (end - start));
                                                }
                                                else
                                                    Color += elem.Text;

                                                if (c != Color)
                                                {
                                                    if (model.ProPrice != "0" && (model.ProPrice != string.Empty))
                                                        price = driver.FindElement(By.Id("J_PromoPrice")).FindElement(By.ClassName("tm-price")).Text;
                                                    else
                                                        price = driver.FindElement(By.Id("J_StrPriceModBox")).FindElement(By.ClassName("tm-price")).Text;

                                                    if (price.Contains("-"))
                                                        price = price.Split('-')[0].Trim();

                                                    Color += "^_p^" + price;
                                                    Color += "||";
                                                }
                                            }
                                            catch (Exception ex) { }
                                        }
                                        Color = Color.Remove(Color.Length - 2, 2);
                                        model.Color = Color;
                                    }
                                    catch (Exception ex) { model.Color = string.Empty; }
                                    break;
                                case Constant.ScrapModel.Size:
                                    try
                                    {
                                        string Size = string.Empty;
                                        IReadOnlyCollection<IWebElement> elements = driver.FindElement(By.ClassName("tm-sale-prop")).FindElement(By.XPath("//ul[@data-property='尺码']")).FindElements(By.TagName("li"));
                                        for (int i = 0; i < elements.Count; i++)
                                        {
                                            string price = "0";
                                            IWebElement elem = elements.ToList()[i].FindElement(By.TagName("a"));
                                            Size += elem.Text;
                                            elem.Click();
                                            if (model.ProPrice != "0" && (model.ProPrice != string.Empty))
                                                price = driver.FindElement(By.Id("J_PromoPrice")).FindElement(By.ClassName("tm-price")).Text;
                                            else
                                                price = driver.FindElement(By.Id("J_StrPriceModBox")).FindElement(By.ClassName("tm-price")).Text;

                                            if (price.Contains("-"))
                                                price = price.Split('-')[0].Trim();

                                            Size += "^_p^" + price;
                                            Size += "||";
                                        }
                                        Size = Size.Remove(Size.Length - 2, 2);
                                        model.Size = Size;
                                    }
                                    catch (Exception ex) { model.Size = string.Empty; }
                                    break;
                                case Constant.ScrapModel.ShopName:
                                    try { model.ShopName = driver.FindElement(By.Id("side-shop-info")).FindElement(By.TagName("a")).Text; }
                                    catch (Exception ex) { model.ShopName = string.Empty; }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { return null; }
            return model;
        }
        private ScrapingData Get1688(IWebDriver driver)
        {
            ScrapingData model = new ScrapingData();
            try
            {
                foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
                {
                    if (propertyInfo.CanRead)
                    {
                        if (propertyInfo.Name != Constant.ScrapModel.Web)
                        {
                            switch (propertyInfo.Name)
                            {
                                case Constant.ScrapModel.ItemName:
                                    try
                                    {
                                        model.ItemName = driver.FindElement(By.Id("mod-detail-title")).Text;
                                        if (model.ItemName.Contains("\r\n")) model.ItemName = model.ItemName.Substring(0, model.ItemName.IndexOf("\r\n"));
                                    }
                                    catch (Exception ex) { model.ItemName = string.Empty; }
                                    break;
                                case Constant.ScrapModel.picURL:
                                    try { model.picURL = driver.FindElement(By.ClassName("tab-pane")).FindElement(By.TagName("img")).GetAttribute("src").ToString(); }
                                    catch (Exception ex) { model.picURL = string.Empty; }
                                    break;
                                case Constant.ScrapModel.Price:
                                    try
                                    {
                                        IReadOnlyCollection<IWebElement> eAmount = driver.FindElement(By.Id("mod-detail-price")).FindElement(By.ClassName("amount")).FindElements(By.TagName("td"));
                                        IReadOnlyCollection<IWebElement> ePrice = driver.FindElement(By.Id("mod-detail-price")).FindElement(By.ClassName("price")).FindElements(By.TagName("td"));
                                        string amt = string.Empty;
                                        string prc = string.Empty;
                                        for (int i = 1; i < eAmount.Count; i++)
                                        {
                                            amt += eAmount.ToList()[i].FindElement(By.ClassName("value")).Text + "||";
                                            prc += ePrice.ToList()[i].FindElement(By.ClassName("value")).Text + "||";
                                            //model.AmountList.Add(eAmount.ToList()[i].FindElement(By.ClassName("value")).Text);
                                            //model.PriceList.Add(eAmount.ToList()[i].FindElement(By.ClassName("value")).Text);
                                            if (i == 1)
                                                model.Price = ePrice.ToList()[i].FindElement(By.ClassName("value")).Text;
                                        }
                                        model.AmountRange = amt.Remove(amt.Length - 2, 2);
                                        model.PriceRange = prc.Remove(prc.Length - 2, 2);
                                        //IWebElement Eprice = driver.FindElement(By.ClassName("offerdetail_orderingGroup_retailPrice-new"));
                                        //string price = Eprice.FindElement(By.ClassName("unit")).Text;
                                        //model.Price = price;
                                    }
                                    catch (Exception ex) { model.Price = "0"; }
                                    break;
                                case Constant.ScrapModel.ProPrice:
                                    try
                                    {
                                        model.ProPrice = "0";
                                        //IWebElement Eprice = driver.FindElement(By.ClassName("counter-price"));
                                        //string price = Eprice.FindElement(By.ClassName("price-yen")).Text;
                                        //string digit = Eprice.FindElement(By.ClassName("price-fen")).Text;
                                        //model.ProPrice = price + digit;
                                    }
                                    catch (Exception ex) { model.ProPrice = "0"; }
                                    break;
                                case Constant.ScrapModel.Color:
                                    try
                                    {
                                        string Color = string.Empty;
                                        IReadOnlyCollection<IWebElement> elements = driver.FindElement(By.ClassName("list-leading")).FindElements(By.TagName("li"));
                                        for (int i = 0; i < elements.Count; i++)
                                        {
                                            int start = 0, end = 0;
                                            string price = "0";
                                            string val = string.Empty;
                                            IWebElement elem = elements.ToList()[i].FindElement(By.TagName("a"));
                                            try
                                            {
                                                IWebElement elem2 = elem.FindElement(By.ClassName("vertical-img"));
                                                if (elem2 != null)
                                                { val = elem2.FindElement(By.TagName("img")).GetAttribute("src").ToString(); }

                                                if (val != string.Empty)
                                                    Color += val;
                                            }
                                            catch (Exception ex) { Color += elem.Text; }

                                            if (model.ProPrice != "0" && (model.ProPrice != string.Empty))
                                                price = model.ProPrice;
                                            else
                                                price = model.Price;
                                            Color += "^_p^" + price;
                                            Color += "||";
                                        }
                                        Color = Color.Remove(Color.Length - 2, 2);
                                        model.Color = Color;
                                    }
                                    catch (Exception ex) { model.Color = string.Empty; }
                                    break;
                                case Constant.ScrapModel.Size:
                                    try
                                    {
                                        string Size = string.Empty;
                                        IReadOnlyCollection<IWebElement> elements = driver.FindElement(By.ClassName("table-sku")).FindElements(By.TagName("tr"));
                                        for (int i = 0; i < elements.Count; i++)
                                        {
                                            string price = "0";
                                            IWebElement elem = elements.ToList()[i].FindElement(By.ClassName("name"));
                                            Size += elem.Text;

                                            if (model.ProPrice != "0" && (model.ProPrice != string.Empty))
                                                price = model.ProPrice;
                                            else
                                                price = model.Price;
                                            Size += "^_p^" + price;
                                            Size += "||";
                                        }
                                        Size = Size.Remove(Size.Length - 2, 2);
                                        model.Size = Size;
                                    }
                                    catch (Exception ex) { model.Size = string.Empty; }
                                    break;
                                case Constant.ScrapModel.ShopName:
                                    try { model.ShopName = driver.FindElement(By.ClassName("companyname")).FindElement(By.ClassName("has-tips")).Text; }
                                    catch (Exception ex) { model.ShopName = string.Empty; }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { return null; }
            return model;
        }
        public string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }
        //private string GetSizeOrColor1688(string txt)
        //{
        //    string result = string.Empty;
        //    try
        //    {
        //        if (txt == "Color")
        //        {
        //        }
        //        else
        //        {
        //        }

        //        HtmlNode nodeLead;
        //        HtmlNode nodeSku;
        //        bool Lead = false;
        //        bool Sku = false;
        //        var objLeading = doc.DocumentNode.Descendants("div").Where(l =>
        //               l.Attributes.Contains("class") &&
        //               l.Attributes["class"].Value.Contains("obj-leading"));

        //        var objSku = doc.DocumentNode.Descendants("div").Where(l =>
        //               l.Attributes.Contains("class") &&
        //               l.Attributes["class"].Value.Contains("obj-sku"));

        //        nodeLead = objLeading.FirstOrDefault();
        //        nodeSku = objSku.FirstOrDefault();

        //        if (txt == "Color")
        //        {
        //            if (nodeLead != null)
        //                if (nodeLead.ChildNodes[1].InnerText.Trim() == "Color" || nodeLead.ChildNodes[1].InnerText.Trim() == "颜色")
        //                    Lead = true;

        //            if (nodeSku != null)
        //                if (nodeSku.ChildNodes[1].InnerText.Trim() == "Color" || nodeSku.ChildNodes[1].InnerText.Trim() == "颜色")
        //                    Sku = true;
        //        }
        //        else
        //        {
        //            if (nodeLead != null)
        //                if (nodeLead.ChildNodes[1].InnerText.Trim() != "Color" && nodeLead.ChildNodes[1].InnerText.Trim() != "颜色")
        //                    Lead = true;

        //            if (nodeSku != null)
        //                if (nodeSku.ChildNodes[1].InnerText.Trim() != "Color" && nodeSku.ChildNodes[1].InnerText.Trim() != "颜色")
        //                    Sku = true;
        //        }
        //        if (Lead)
        //        {
        //            //Can't use foreach
        //            for (int i = 0; i < nodeLead.ChildNodes[3].ChildNodes[1].ChildNodes.Count; i++)
        //            {
        //                if (nodeLead.ChildNodes[3].ChildNodes[1].ChildNodes[i].Name.Contains("li"))
        //                {
        //                    HtmlNode item = nodeLead.ChildNodes[3].ChildNodes[1].ChildNodes[i].ChildNodes[1].ChildNodes[1];
        //                    if (item.InnerHtml.Contains("vertical-img"))
        //                    {
        //                        result += item.ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes[1].Value;
        //                    }
        //                    else
        //                        result += item.ChildNodes[1].ChildNodes[0].InnerHtml;
        //                    result += "||";
        //                }
        //            }
        //        }
        //        else if (Sku)
        //        {
        //            //Can't use foreach
        //            for (int i = 0; i < nodeSku.ChildNodes[3].ChildNodes[1].ChildNodes.Count(); i++)
        //            {
        //                if (nodeSku.ChildNodes[3].ChildNodes[1].ChildNodes[i].Name.Contains("tr"))
        //                {
        //                    HtmlNode item = nodeSku.ChildNodes[3].ChildNodes[1].ChildNodes[i].ChildNodes[1].ChildNodes[1];
        //                    int start = 0, end = 0;
        //                    if (item.InnerHtml.Contains("vertical-img"))
        //                    {
        //                        result += item.ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes[1].Value;
        //                    }
        //                    else
        //                        result += item.InnerHtml;
        //                    result += "||";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex) { result = string.Empty; }
        //    return result;
        //}
        #endregion
        #endregion
    }
}
