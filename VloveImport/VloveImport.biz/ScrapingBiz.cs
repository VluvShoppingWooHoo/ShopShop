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

namespace VloveImport.biz
{
    public class ScrapingBiz
    {
        public ScrapingData Handle(string URL, int web)
        {
            ScrapingData model = new ScrapingData();
            WebClient w = new WebClient();
            //string html = w.DownloadString(URL);
            string html = URL;

            #region HTML Agility
            //HtmlNode.ElementsFlags.Remove("form");
            //HtmlNode.ElementsFlags.Remove("dd");
            //HtmlNode.ElementsFlags.Remove("em");
            //HtmlNode.ElementsFlags.Remove("span");
            //HtmlNode.ElementsFlags.Remove("font");
            
            //HtmlAgilityPack.HtmlWeb HtmlWeb = new HtmlWeb();
            var HtmlWeb = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = System.Text.Encoding.GetEncoding(54936)
            };
            HtmlAgilityPack.HtmlDocument doc = HtmlWeb.Load(html);
            
            //doc.Encoding.
            //doc. = Encoding.Default;
            #endregion
            foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    if (propertyInfo.Name != Constant.ScrapModel.Web)
                    {
                        switch (propertyInfo.Name)
                        {
                            case Constant.ScrapModel.ItemID:
                                model.ItemID = GetItemID(html, web, doc);
                                break;
                            case Constant.ScrapModel.ItemName:
                                model.ItemName = GetItemName(html, web, doc);
                                break;
                            case Constant.ScrapModel.DESC:
                                model.DESC = GetDESC(html, web, doc);
                                break;
                            case Constant.ScrapModel.picURL:
                                model.picURL = GetpicURL(html, web, doc);
                                break;
                            case Constant.ScrapModel.Price:
                                model.Price = GetPrice(html, web, doc);
                                break;
                            case Constant.ScrapModel.ProPrice:
                                model.ProPrice = GetProPrice(html, web, doc);
                                break;
                            case Constant.ScrapModel.Color:
                                model.Color = GetColor(html, web, doc);
                                break;
                            case Constant.ScrapModel.Size:
                                model.Size = GetSize(html, web, doc);
                                break;
                            default:
                                //model = null;
                                break;
                        }
                    }
                }
            }

            return model;
        }
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
        #region Function
        #region Scraping SeacrhBox
        #region Get Property to model
        private string GetItemID(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        {
            string ItemID = string.Empty;
            try
            {
                #region V1
                //foreach (HtmlNode link in doc.DocumentNode.SelectNodes
                //    ("/html/body/div['page']/div['content']/div['bd']/div['detail']/form"))
                //{

                //    //var node = doc.DocumentNode.Element("html");

                //    //var inputs = node.ChildNodes["body"].Descendants("input");
                //    var inputs = link.ChildNodes["ItemID"];
                //    HtmlAttribute att = link.Attributes["value"];
                //    ItemID = link.ChildNodes[14].Attributes[2].Value;
                //}
                #endregion
                switch (web)
                {
                    case 1:
                        HtmlNode node = doc.GetElementbyId("J_FrmBid");
                        ItemID = node.ChildNodes[14].Attributes[2].Value;
                        break;
                    case 2:
                        ItemID = "";
                        break;
                    case 3:
                        ItemID = "";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
            return ItemID;
        }
        private string GetItemName(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        {
            string ItemName = string.Empty;
            try
            {
                HtmlNode node = null;
                switch (web)
                {
                    case 1:
                        node = doc.GetElementbyId("J_Title");
                        ItemName = node.ChildNodes[1].Attributes[1].Value.Trim();
                        break;
                    case 2:
                        var result = doc.DocumentNode.Descendants("div").Where(l =>
                            l.Attributes.Contains("class") &&
                            l.Attributes["class"].Value.Contains("tb-detail-hd"));
                        node = result.FirstOrDefault().ChildNodes[1].ChildNodes[0];
                        ItemName = node.InnerText.Trim();
                        break;
                    case 3:
                        ItemName = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
            return ItemName;
        }
        private string GetDESC(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        {
            string DESC = string.Empty;
            try
            {
                switch (web)
                {
                    case 1:
                        DESC = string.Empty;
                        break;
                    case 2:
                        DESC = string.Empty;
                        break;
                    case 3:
                        DESC = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
            return DESC;
        }
        private string GetpicURL(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        {
            string picURL = string.Empty;
            try
            {
                HtmlNode node = null;
                switch (web)
                {
                    case 1:
                        node = doc.GetElementbyId("J_ImgBooth");
                        picURL = node.Attributes[1].Value;
                        break;
                    case 2:
                        node = doc.GetElementbyId("J_ImgBooth");
                        picURL = node.Attributes[2].Value;
                        break;
                    case 3:
                        picURL = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
            return picURL;
        }
        private string GetPrice(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        {
            string Price = string.Empty;
            try
            {
                HtmlNode node = null;
                switch (web)
                {
                    case 1:
                        node = doc.GetElementbyId("J_StrPrice");
                        Price = node.ChildNodes[1].InnerText;
                        break;
                    case 2:
                        //var result = doc.DocumentNode.Descendants("dl").Where(l =>
                        //    l.Attributes.Contains("class") &&
                        //    l.Attributes["class"].Value.Contains("tm-price-panel"));
                        //node = result.FirstOrDefault().ChildNodes[1].ChildNodes[0];
                        node = doc.GetElementbyId("J_StrPrice");
                        Price = node.ChildNodes[1].InnerText;
                        break;
                    case 3:
                        Price = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
            return Price;
        }
        private string GetProPrice(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        {
            string ProPrice = string.Empty;
            try
            {
                switch (web)
                {
                    case 1:
                        HtmlNode node = doc.GetElementbyId("J_Price");
                        ProPrice = node.InnerText;
                        break;
                    case 2:
                        ProPrice = string.Empty;
                        break;
                    case 3:
                        ProPrice = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
            return ProPrice;
        }
        private string GetColor(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        {
            string Color = string.Empty;
            try
            {
                HtmlNode node = null;
                
                switch (web)
                {
                    case 1:
                        //HtmlNode node = doc.GetElementbyId("J_Prop_Color");
                        var result = doc.DocumentNode.Descendants("dl").Where(l =>
                            l.Attributes.Contains("class") &&
                            l.Attributes["class"].Value.Contains("J_Prop_Color"));
                        node = result.FirstOrDefault().ChildNodes[3].ChildNodes[1];
                        //Can't use foreach
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            if (node.ChildNodes[i].Name.Contains("li"))
                            {
                                HtmlNode item = node.ChildNodes[i];
                                int start = 0, end = 0;
                                if (item.InnerHtml.Contains("background:url"))
                                {
                                    start = item.InnerHtml.IndexOf('(') + 1;
                                    end = item.InnerHtml.IndexOf(')');
                                    Color += item.InnerHtml.Substring(start, (end - start));
                                }
                                else
                                    Color += item.ChildNodes[1].ChildNodes[1].InnerHtml;
                                Color += "||";
                            }
                        }
                        Color = Color.Remove(Color.Length - 2, 2);
                        break;
                    case 2:
                        var result2 = doc.DocumentNode.Descendants("ul").Where(l =>
                            l.Attributes.Contains("class") &&
                            l.Attributes["class"].Value.Contains("J_TSaleProp tb-img"));
                        node = result2.FirstOrDefault();
                        //Can't use foreach
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            if (node.ChildNodes[i].Name.Contains("li"))
                            {
                                HtmlNode item = node.ChildNodes[i];
                                int start = 0, end = 0;
                                if (item.InnerHtml.Contains("background:url"))
                                {
                                    start = item.InnerHtml.IndexOf('(') + 1;
                                    end = item.InnerHtml.IndexOf(')');
                                    Color += item.InnerHtml.Substring(start, (end - start));
                                }
                                else
                                    Color += item.ChildNodes[1].ChildNodes[1].InnerHtml;
                                Color += "||";
                            }
                        }
                        Color = Color.Remove(Color.Length - 2, 2);
                        break;
                    case 3:
                        Color = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
            return Color;
        }
        private string GetSize(string html, int web, HtmlAgilityPack.HtmlDocument doc)
        {
            string Size = string.Empty;
            try
            {
                HtmlNode node = null;
                switch (web)
                {
                    case 1:
                        //HtmlNode node = doc.GetElementbyId("J_Prop_Color");
                        var result = doc.DocumentNode.Descendants("dl").Where(l =>
                            l.Attributes.Contains("class") &&
                            l.Attributes["class"].Value.Contains("J_TMySizeProp"));
                        node= result.FirstOrDefault().ChildNodes[3].ChildNodes[1];
                        //Can't use foreach
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            if (node.ChildNodes[i].Name.Contains("li"))
                            {
                                HtmlNode item = node.ChildNodes[i];
                                int start = item.InnerHtml.IndexOf("<span>") + 6;
                                int end = item.InnerHtml.IndexOf("</span>");
                                Size += item.InnerHtml.Substring(start, (end - start)) + "||";
                            }
                        }
                        Size = Size.Remove(Size.Length - 2, 2);
                        break;
                    case 2:
                        var result2 = doc.DocumentNode.Descendants("ul").Where(l =>
                            l.Attributes.Contains("class") &&
                            l.Attributes["class"].Value.Contains("J_TSaleProp"));
                        node = result2.FirstOrDefault();
                        //Can't use foreach
                        for (int i = 0; i < node.ChildNodes.Count; i++)
                        {
                            if (node.ChildNodes[i].Name.Contains("li"))
                            {
                                HtmlNode item = node.ChildNodes[i];
                                int start = item.InnerHtml.IndexOf("<span>") + 6;
                                int end = item.InnerHtml.IndexOf("</span>");
                                Size += item.InnerHtml.Substring(start, (end - start)) + "||";
                            }
                        }
                        Size = Size.Remove(Size.Length - 2, 2);
                        break;
                    case 3:
                        Size = string.Empty;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) { }
            return Size;
        }
        #endregion
        #endregion
        #region Scraping Side Menu
        #endregion
        #endregion
    }
}
