using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using VloveImport.data;
using VloveImport.data.Extension;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support;

namespace VloveImport.biz
{
    public class ScrapingBiz
    {
        //IWebDriver driver;
        public ScrapingData Handle(string URL, int web)
        {
            ScrapingData model = new ScrapingData();
            #region V2. Selenium WebDriver
            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl(URL);
            #endregion
            #region V1. HTML AGILITY
            //WebClient w = new WebClient();
            ////string html = w.DownloadString(URL);
            //string html = URL;

            //#region HTML Agility
            ////HtmlNode.ElementsFlags.Remove("form");
            ////HtmlNode.ElementsFlags.Remove("dd");
            ////HtmlNode.ElementsFlags.Remove("em");
            ////HtmlNode.ElementsFlags.Remove("span");
            ////HtmlNode.ElementsFlags.Remove("font");

            ////HtmlAgilityPack.HtmlWeb HtmlWeb = new HtmlWeb();
            //var HtmlWeb = new HtmlWeb
            //{
            //    AutoDetectEncoding = false,
            //    OverrideEncoding = System.Text.Encoding.GetEncoding(54936)
            //};
            //HtmlAgilityPack.HtmlDocument doc = HtmlWeb.Load(html);

            ////doc.Encoding.
            ////doc. = Encoding.Default;
            //#endregion
            //foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
            //{
            //    if (propertyInfo.CanRead)
            //    {
            //        if (propertyInfo.Name != Constant.ScrapModel.Web)
            //        {
            //            switch (propertyInfo.Name)
            //            {
            //                case Constant.ScrapModel.ItemID:
            //                    model.ItemID = GetItemID(html, web, doc);
            //                    break;
            //                case Constant.ScrapModel.ItemName:
            //                    model.ItemName = GetItemName(html, web, doc);
            //                    break;
            //                case Constant.ScrapModel.DESC:
            //                    model.DESC = GetDESC(html, web, doc);
            //                    break;
            //                case Constant.ScrapModel.picURL:
            //                    model.picURL = GetpicURL(html, web, doc);
            //                    break;
            //                case Constant.ScrapModel.Price:
            //                    model.Price = GetPrice(html, web, doc);
            //                    break;
            //                case Constant.ScrapModel.ProPrice:
            //                    model.ProPrice = GetProPrice(html, web, doc);
            //                    break;
            //                case Constant.ScrapModel.Color:
            //                    model.Color = GetColor(html, web, doc);
            //                    break;
            //                case Constant.ScrapModel.Size:
            //                    model.Size = GetSize(html, web, doc);
            //                    break;
            //                case Constant.ScrapModel.ShopName:
            //                    model.ShopName = GetShopName(html, web, doc);
            //                    break;
            //                default:
            //                    //model = null;
            //                    break;
            //            }
            //        }
            //    }
            //}
            #endregion
            return model;
        }
        #region Function
        #region Scraping SeacrhBox
        //#region Get Property to model
        //private string GetItemID(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string ItemID = string.Empty;
        //    try
        //    {
        //        #region V1
        //        //foreach (HtmlNode link in doc.DocumentNode.SelectNodes
        //        //    ("/html/body/div['page']/div['content']/div['bd']/div['detail']/form"))
        //        //{

        //        //    //var node = doc.DocumentNode.Element("html");

        //        //    //var inputs = node.ChildNodes["body"].Descendants("input");
        //        //    var inputs = link.ChildNodes["ItemID"];
        //        //    HtmlAttribute att = link.Attributes["value"];
        //        //    ItemID = link.ChildNodes[14].Attributes[2].Value;
        //        //}
        //        #endregion
        //        switch (web)
        //        {
        //            case 1:
        //                HtmlNode node = doc.GetElementbyId("J_FrmBid");
        //                ItemID = node.ChildNodes[14].Attributes[2].Value;
        //                break;
        //            case 2:
        //                ItemID = "";
        //                break;
        //            case 3:
        //                ItemID = "";
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return ItemID;
        //}
        //private string GetItemName(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string ItemName = string.Empty;
        //    try
        //    {
        //        HtmlNode node = null;
        //        switch (web)
        //        {
        //            case 1:
        //                node = doc.GetElementbyId("J_Title");
        //                ItemName = node.ChildNodes[1].Attributes[1].Value.Trim();
        //                break;
        //            case 2:
        //                var result = doc.DocumentNode.Descendants("div").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("tb-detail-hd"));
        //                node = result.FirstOrDefault().ChildNodes[1].ChildNodes[0];
        //                ItemName = node.InnerText.Trim();
        //                break;
        //            case 3:
        //                node = doc.GetElementbyId("mod-detail-title");
        //                ItemName = node.ChildNodes[1].InnerHtml.Trim();
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return ItemName;
        //}
        //private string GetDESC(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string DESC = string.Empty;
        //    try
        //    {
        //        switch (web)
        //        {
        //            case 1:
        //                DESC = string.Empty;
        //                break;
        //            case 2:
        //                DESC = string.Empty;
        //                break;
        //            case 3:
        //                DESC = string.Empty;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return DESC;
        //}
        //private string GetpicURL(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string picURL = string.Empty;
        //    try
        //    {
        //        HtmlNode node = null;
        //        switch (web)
        //        {
        //            case 1:
        //                node = doc.GetElementbyId("J_ImgBooth");
        //                picURL = node.Attributes[1].Value;
        //                break;
        //            case 2:
        //                node = doc.GetElementbyId("J_ImgBooth");
        //                picURL = node.Attributes[2].Value;
        //                break;
        //            case 3:
        //                var result = doc.DocumentNode.Descendants("div").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("tab-pane"));
        //                node = result.FirstOrDefault().ChildNodes[1].ChildNodes[1].ChildNodes[1];
        //                picURL = node.Attributes[0].Value;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return picURL;
        //}
        //private string GetPrice(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string Price = "0";
        //    try
        //    {
        //        HtmlNode node = null;
        //        switch (web)
        //        {
        //            case 1:
        //                node = doc.GetElementbyId("J_StrPrice");
        //                Price = node.ChildNodes[1].InnerText;
        //                break;
        //            case 2:
        //                int start = 0;
        //                start = doc.DocumentNode.InnerHtml.IndexOf("defaultItemPrice");
        //                string result2 = doc.DocumentNode.InnerHtml.Substring(start + 19, ((doc.DocumentNode.InnerHtml.IndexOf(",", doc.DocumentNode.InnerHtml.IndexOf(".", start + 19))) - (start + 19)));
        //                Price = result2.Replace("\"", "");          
        //                break;
        //            case 3:
        //                var result = doc.DocumentNode.Descendants("tr").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("price"));
        //                node = result.FirstOrDefault().ChildNodes[1].ChildNodes[3];
        //                Price = node.InnerText.Trim();
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return Price;
        //}
        //private string GetProPrice(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string ProPrice = "0";
        //    try
        //    {
        //        switch (web)
        //        {
        //            case 1:
        //                HtmlNode node = doc.GetElementbyId("J_Price");
        //                ProPrice = node.InnerText;
        //                break;
        //            case 2:
        //                int start = 0;
        //                start = doc.DocumentNode.InnerHtml.IndexOf("defaultItemPrice");
        //                string result2 = doc.DocumentNode.InnerHtml.Substring(start + 19, ((doc.DocumentNode.InnerHtml.IndexOf(",", doc.DocumentNode.InnerHtml.IndexOf(".", start + 19))) - (start + 19)));
        //                ProPrice = result2.Replace("\"", "");   
        //                break;
        //            case 3:
        //                var result3 = doc.DocumentNode.Descendants("div").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("counter-price"));
        //                node = result3.FirstOrDefault().ChildNodes[2];
        //                ProPrice = node.InnerText;                    
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return ProPrice;
        //}
        //private string GetColor(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string Color = string.Empty;
        //    try
        //    {
        //        HtmlNode node = null;

        //        switch (web)
        //        {
        //            case 1:
        //                //HtmlNode node = doc.GetElementbyId("J_Prop_Color");
        //                var result = doc.DocumentNode.Descendants("dl").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("J_Prop_Color"));
        //                node = result.FirstOrDefault().ChildNodes[3].ChildNodes[1];
        //                //Can't use foreach
        //                for (int i = 0; i < node.ChildNodes.Count; i++)
        //                {
        //                    if (node.ChildNodes[i].Name.Contains("li"))
        //                    {
        //                        HtmlNode item = node.ChildNodes[i];
        //                        int start = 0, end = 0;
        //                        if (item.InnerHtml.Contains("background:url"))
        //                        {
        //                            start = item.InnerHtml.IndexOf('(') + 1;
        //                            end = item.InnerHtml.IndexOf(')');
        //                            Color += item.InnerHtml.Substring(start, (end - start));
        //                        }
        //                        else
        //                            Color += item.ChildNodes[1].ChildNodes[1].InnerHtml;
        //                        Color += "||";
        //                    }
        //                }
        //                Color = Color.Remove(Color.Length - 2, 2);
        //                break;
        //            case 2:
        //                var result2 = doc.DocumentNode.Descendants("ul").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("J_TSaleProp tb-img"));
        //                node = result2.FirstOrDefault();
        //                //Can't use foreach
        //                for (int i = 0; i < node.ChildNodes.Count; i++)
        //                {
        //                    if (node.ChildNodes[i].Name.Contains("li"))
        //                    {
        //                        HtmlNode item = node.ChildNodes[i];
        //                        int start = 0, end = 0;
        //                        if (item.InnerHtml.Contains("background:url"))
        //                        {
        //                            start = item.InnerHtml.IndexOf('(') + 1;
        //                            end = item.InnerHtml.IndexOf(')');
        //                            Color += item.InnerHtml.Substring(start, (end - start));
        //                        }
        //                        else
        //                            Color += item.ChildNodes[1].ChildNodes[1].InnerHtml;
        //                        Color += "||";
        //                    }
        //                }
        //                Color = Color.Remove(Color.Length - 2, 2);
        //                break;
        //            case 3:
        //                Color = GetSizeOrColor1688("Color", doc);
        //                //Color = Color.Remove(Color.Length - 2, 2);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return Color;
        //}
        //private string GetSize(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string Size = string.Empty;
        //    try
        //    {
        //        HtmlNode node = null;
        //        switch (web)
        //        {
        //            case 1:
        //                //HtmlNode node = doc.GetElementbyId("J_Prop_Color");
        //                var result = doc.DocumentNode.Descendants("dl").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("J_TMySizeProp"));
        //                node = result.FirstOrDefault().ChildNodes[3].ChildNodes[1];
        //                //Can't use foreach
        //                for (int i = 0; i < node.ChildNodes.Count; i++)
        //                {
        //                    if (node.ChildNodes[i].Name.Contains("li"))
        //                    {
        //                        HtmlNode item = node.ChildNodes[i];
        //                        int start = item.InnerHtml.IndexOf("<span>") + 6;
        //                        int end = item.InnerHtml.IndexOf("</span>");
        //                        Size += item.InnerHtml.Substring(start, (end - start)) + "||";
        //                    }
        //                }
        //                Size = Size.Remove(Size.Length - 2, 2);
        //                break;
        //            case 2:
        //                var result2 = doc.DocumentNode.Descendants("ul").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("J_TSaleProp"));
        //                node = result2.FirstOrDefault();
        //                //Can't use foreach
        //                for (int i = 0; i < node.ChildNodes.Count; i++)
        //                {
        //                    if (node.ChildNodes[i].Name.Contains("li"))
        //                    {
        //                        HtmlNode item = node.ChildNodes[i];
        //                        int start = item.InnerHtml.IndexOf("<span>") + 6;
        //                        int end = item.InnerHtml.IndexOf("</span>");
        //                        Size += item.InnerHtml.Substring(start, (end - start)) + "||";
        //                    }
        //                }
        //                Size = Size.Remove(Size.Length - 2, 2);
        //                break;
        //            case 3:
        //                Size = GetSizeOrColor1688("Size", doc);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return Size;
        //}
        //private string GetShopName(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        //{
        //    string ShopName = string.Empty;
        //    try
        //    {
        //        HtmlNode node = null;
        //        switch (web)
        //        {
        //            case 1:
        //                var result = doc.DocumentNode.Descendants("div").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("tb-shop-name"));
        //                node = result.FirstOrDefault().ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[1];
        //                ShopName = node.Attributes[1].Value.Trim();
        //                break;
        //            case 2:
        //                node = doc.GetElementbyId("shopExtra");
        //                ShopName = node.ChildNodes[1].ChildNodes[1].InnerText;
        //                break;
        //            case 3:
        //                var result3 = doc.DocumentNode.Descendants("div").Where(l =>
        //                    l.Attributes.Contains("class") &&
        //                    l.Attributes["class"].Value.Contains("companyname"));
        //                node = result3.FirstOrDefault().ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes[0].ChildNodes[1].ChildNodes[0];
        //                ShopName = node.InnerHtml;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return ShopName;
        //}
        //#endregion
        #endregion
        #region Scraping Side Menu
        public string GetSideMenu(string URL)
        {
            //string result = string.Empty;
            var HtmlWeb = new HtmlWeb
            {
                //AutoDetectEncoding = false,
                //OverrideEncoding = System.Text.Encoding.GetEncoding(54936)
            };
            HtmlAgilityPack.HtmlDocument doc = HtmlWeb.Load(URL);
            //var result = doc.DocumentNode.Descendants("ul").Where(l =>
            //    l.Attributes.Contains("class") &&
            //    l.Attributes["class"].Value.Contains("menu-left-category"));
            var result = doc.DocumentNode.Descendants("div").Where(l =>
                l.Attributes.Contains("class") &&
                l.Attributes["class"].Value.Contains("cat-main"));
            //l.Attributes["class"].Value.Contains("cat-l"));

            HtmlNode node = result.FirstOrDefault();
            return node.OuterHtml;
        }
        #endregion
        #endregion
        #region private function
        private string GetSizeOrColor1688(string txt, HtmlAgilityPack.HtmlDocument doc)
        {
            string result = string.Empty;
            try
            {
                HtmlNode nodeLead;
                HtmlNode nodeSku;
                bool Lead = false;
                bool Sku = false;
                var objLeading = doc.DocumentNode.Descendants("div").Where(l =>
                       l.Attributes.Contains("class") &&
                       l.Attributes["class"].Value.Contains("obj-leading"));

                var objSku = doc.DocumentNode.Descendants("div").Where(l =>
                       l.Attributes.Contains("class") &&
                       l.Attributes["class"].Value.Contains("obj-sku"));

                nodeLead = objLeading.FirstOrDefault();
                nodeSku = objSku.FirstOrDefault();

                if (txt == "Color")
                {
                    if (nodeLead != null)
                        if (nodeLead.ChildNodes[1].InnerText.Trim() == "Color" || nodeLead.ChildNodes[1].InnerText.Trim() == "颜色")
                            Lead = true;

                    if (nodeSku != null)
                        if (nodeSku.ChildNodes[1].InnerText.Trim() == "Color" || nodeSku.ChildNodes[1].InnerText.Trim() == "颜色")
                            Sku = true;
                }
                else
                {
                    if (nodeLead != null)
                        if (nodeLead.ChildNodes[1].InnerText.Trim() != "Color" && nodeLead.ChildNodes[1].InnerText.Trim() != "颜色")
                            Lead = true;

                    if (nodeSku != null)
                        if (nodeSku.ChildNodes[1].InnerText.Trim() != "Color" && nodeSku.ChildNodes[1].InnerText.Trim() != "颜色")
                            Sku = true;
                }
                if (Lead)
                {
                    //Can't use foreach
                    for (int i = 0; i < nodeLead.ChildNodes[3].ChildNodes[1].ChildNodes.Count; i++)
                    {
                        if (nodeLead.ChildNodes[3].ChildNodes[1].ChildNodes[i].Name.Contains("li"))
                        {
                            HtmlNode item = nodeLead.ChildNodes[3].ChildNodes[1].ChildNodes[i].ChildNodes[1].ChildNodes[1];
                            if (item.InnerHtml.Contains("vertical-img"))
                            {
                                result += item.ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes[1].Value;
                            }
                            else
                                result += item.ChildNodes[1].ChildNodes[0].InnerHtml;
                            result += "||";
                        }
                    }
                }
                else if (Sku)
                {
                    //Can't use foreach
                    for (int i = 0; i < nodeSku.ChildNodes[3].ChildNodes[1].ChildNodes.Count(); i++)
                    {
                        if (nodeSku.ChildNodes[3].ChildNodes[1].ChildNodes[i].Name.Contains("tr"))
                        {
                            HtmlNode item = nodeSku.ChildNodes[3].ChildNodes[1].ChildNodes[i].ChildNodes[1].ChildNodes[1];
                            int start = 0, end = 0;
                            if (item.InnerHtml.Contains("vertical-img"))
                            {
                                result += item.ChildNodes[1].ChildNodes[1].ChildNodes[1].Attributes[1].Value;
                            }
                            else
                                result += item.InnerHtml;
                            result += "||";
                        }
                    }
                }
            }
            catch (Exception ex) { result = string.Empty; }
            return result;
        }
        #endregion
    }
}
