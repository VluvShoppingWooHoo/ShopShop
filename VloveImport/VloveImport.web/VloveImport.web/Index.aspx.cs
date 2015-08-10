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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using HtmlAgilityPack;
using System.Data;

//using iTextSharp.tool.xml;
//using iTextSharp.tool
//using SimpleBrowser;
//using OpenQA.Selenium.PhantomJS;
//using OpenQA.Selenium;

namespace VloveImport.web
{
    public partial class Index : BasePage
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportBiz report = new ReportBiz();
            DataSet ds = report.GetOrderDetail(109);
            //commonBiz biz = new commonBiz();
            PdfClass pdf = new PdfClass();
            byte[] bytes = pdf.PrintPdf(report.GetOrderDetailReport(ds));
            //byte[] bytes = biz.PrintPdf(@"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>");
            //byte[] bytes = biz.PrintPdf(@"<html><head><body><table><tr><td style=""border:2px solid"">asd<td style=""border:2px solid"">fda<tr><td style=""border:2px solid"">gfd<td style=""border:2px solid"">rter</table>");
            
            //byte[] bytes = biz.PrintPdf(@"<html><head></head><body><table><tr><td style=""border:2px solid"">asd</td><td style=""border:2px solid"">fda</td></tr><tr><td style=""border:2px solid"">gfd</td><td style=""border:2px solid"">rter</td></tr></table></body></html>");
            //byte[] bytes = biz.PrintPdf(File.ReadAllText("D:\\Work\\ShopShop\\VloveImport\\VloveImport.web\\VloveImport.web\\Print.html"));
            

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=foo.pdf");
            Response.BinaryWrite(bytes);
            Response.End();
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
            //ScrapingBiz sc = new ScrapingBiz();
            ShoppingBiz sc = new ShoppingBiz();
            Index ix = new Index();
            ScrapingData data = new ScrapingData();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                int webMode = 1;
                #region for use
                txt = txt.Replace("&amp;", "&");
                #region branch web
                if (txt.Contains("taobao.com"))
                {
                    webMode = Constant.Web.WTaoBao;
                    if (txt.Contains(Constant.WebSubTaobao.TW_Taobao) ||
                        txt.Contains(Constant.WebSubTaobao.WORLD_Taobao))
                    {
                        int end = txt.IndexOf(".htm?");
                        string newURL = txt.Substring(0, end);
                        int start = newURL.LastIndexOf("/");
                        string ID = newURL.Substring(start + 1, newURL.Length - (start + 1));
                        txt = Constant.WebTemplate.Taobao + ID;
                    }
                }
                else if (txt.Contains("tmall.com"))
                {
                    webMode = Constant.Web.WTmall;
                }
                else
                {
                    webMode = Constant.Web.W1688;
                }
                #endregion
                #region getID
                string id = string.Empty;
                if (webMode == 1)//taobao
                {
                    id = txt.Substring(txt.IndexOf("id="), txt.Length - txt.IndexOf("id="));
                    id = id.Remove(0, 3);
                    //id = id.Substring(0, id.IndexOf("&"));
                }
                else if (webMode == 2)//tmall
                {
                    id = txt.Substring(txt.IndexOf("id="), txt.Length - txt.IndexOf("id="));
                    id = id.Remove(0, 3);
                    //id = id.Substring(0, id.IndexOf("&"));
                }
                else if (webMode == 3)//1688
                {
                    id = txt.Substring(txt.IndexOf("offer/"), txt.Length - txt.IndexOf("offer/"));
                    id = id.Remove(0, 6);
                    id = id.Substring(0, id.IndexOf(".html"));
                }
                #endregion
                data = sc.GetItemID(id, webMode);
                if (data == null)
                {
                    data = new ScrapingData();
                    data = ix.Scrap(txt, webMode);
                    data.ItemID = id;
                    data.Web = webMode;
                    sc.InsertUpdateItemID(data, "INS");
                }
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
        private void formatUrl(ref string selectVal, ref int IndexStart, ref int IndexEnd, ref int prefix)
        {
            selectVal = selectVal.Replace(" __z__", "__z__").Replace("__z__ ", "__z__").Replace("__ z__", "__z__").Replace("__z __", "__z__");
            selectVal = selectVal.Replace(" __zzz__", "__zzz__").Replace("__zzz__ ", "__zzz__").Replace("__ zzz__", "__zzz__").Replace("__zzz __", "__zzz__");
            if (selectVal.IndexOf("TRANSLATED_TEXT='__z__") == -1)
            {
                IndexStart = selectVal.IndexOf("TRANSLATED_TEXT='");
                prefix = 17;
            }
            else
            {
                IndexStart = selectVal.IndexOf("TRANSLATED_TEXT='__z__");
                prefix = 22;
            }
            //IndexStart = selectVal.IndexOf("TRANSLATED_TEXT='__z__") == -1 ? selectVal.IndexOf("TRANSLATED_TEXT='") : selectVal.IndexOf("TRANSLATED_TEXT='__z__");
            IndexEnd = selectVal.IndexOf("__zzz__';") == -1 ? selectVal.IndexOf("__ zzz__';") : selectVal.IndexOf("__zzz__';");
        }
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
                    if (item != string.Empty)
                    {
                        string itemRe = string.Empty;
                        itemRe = item.Replace("【", "").Replace("】", "");
                        string result = string.Empty;
                        string[] separators = { "||" };
                        if (i == 1 || i == 2)
                        {
                            string strloop = string.Empty;
                            foreach (string txt in itemRe.Split(separators, StringSplitOptions.None))
                            {
                                url = String.Format("http://www.google.com/translate_t?hl=en&text={0}&langpair={1}", txt, "zh-CN|en");
                                result = webClient.DownloadString(url);
                                string selectVal = result.Substring(result.IndexOf("id=result_box"), result.Length - result.IndexOf("id=result_box")); 
                                int IndexStart = 0, IndexEnd = 0, prefix = 0;
                                formatUrl(ref selectVal, ref IndexStart, ref IndexEnd, ref prefix);
                                selectVal = selectVal.Substring(IndexStart + prefix, IndexEnd - (IndexStart + prefix));
                                selectVal = selectVal.Replace(" ^ _p ^ ", "^_p^").Replace(" ^ _ p ^ ", "^_p^").Replace("__z__", "").Replace("__zzz__", "");
                                strloop += selectVal + "||";
                            }
                            strloop = strloop.Remove(strloop.Length - 2, 2);
                            listResult.Add(strloop);
                        }
                        else
                        {
                            url = String.Format("http://www.google.com/translate_t?hl=en&text={0}&langpair={1}", itemRe, "zh-CN|en");
                            result = webClient.DownloadString(url);
                            string selectVal = result.Substring(result.IndexOf("id=result_box"), result.Length - result.IndexOf("id=result_box"));
                            int IndexStart = 0, IndexEnd = 0, prefix = 0;
                            formatUrl(ref selectVal, ref IndexStart, ref IndexEnd, ref prefix);
                            selectVal = selectVal.Substring(IndexStart + prefix, IndexEnd - (IndexStart + prefix));
                            selectVal = selectVal.Replace(" ^ _p ^ ", "^_p^").Replace(" ^ _ p ^ ", "^_p^").Replace("__z__", "").Replace("__zzz__", "");
                            listResult.Add(selectVal);
                        }
                    }
                    else
                        listResult.Add(string.Empty);
                    i++;
                }
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
        #endregion
        #endregion
    }
}
