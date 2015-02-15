﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using VloveImport.data;

namespace VloveImport.biz
{
    public class ScrapingBiz
    {
        public ScrapingDataModel Handle(string URL, int web)
        {
            ScrapingDataModel model = new ScrapingDataModel();
            WebClient w = new WebClient();

            //string html = w.DownloadString(URL);
            string html = URL;

            #region HTML Agility
            HtmlNode.ElementsFlags.Remove("form");
            //HtmlNode.ElementsFlags.Remove("em");
            HtmlAgilityPack.HtmlWeb HtmlWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = HtmlWeb.Load(html);
            #endregion
            foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
            {
                if (propertyInfo.CanRead)
                {
                    switch (propertyInfo.Name)
                    {
                        case "ItemID":
                            model.ItemID = GetItemID(html, web, doc);
                            break;
                        case "ItemName":
                            model.ItemName = GetItemName(html, web, doc);
                            break;
                        case "DESC":
                            model.DESC = GetDESC(html, web, doc);
                            break;
                        case "picURL":
                            model.picURL = GetpicURL(html, web, doc);
                            break;
                        case "Price":
                            model.Price = GetPrice(html, web, doc);
                            break;
                        case "ProPrice":
                            model.ProPrice = GetProPrice(html, web, doc);
                            break;
                        default:
                            model = null;
                            break;
                    }
                }
            }

            return model;
        }

        #region Function
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
                switch (web)
                {
                    case 1:
                        HtmlNode node = doc.GetElementbyId("J_Title");
                        ItemName = node.ChildNodes[1].Attributes[1].Value;
                        break;
                    case 2:
                        ItemName = string.Empty;
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
                switch (web)
                {
                    case 1:
                        HtmlNode node = doc.GetElementbyId("J_ImgBooth");
                        picURL = node.Attributes[1].Value;
                        break;
                    case 2:
                        picURL = string.Empty;
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
                switch (web)
                {
                    case 1:
                        HtmlNode node = doc.GetElementbyId("J_StrPrice");
                        Price = node.ChildNodes[1].InnerText;
                        break;
                    case 2:
                        Price = string.Empty;
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
        #endregion
        //internal static string RemoveUnwantedTags(string data)
        //{
        //    var document = new HtmlDocument();
        //    document.LoadHtml(data);

        //    var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
        //    while (nodes.Count > 0)
        //    {
        //        var node = nodes.Dequeue();
        //        var parentNode = node.ParentNode;

        //        if (node.Name != "strong" && node.Name != "em" && node.Name != "u" && node.Name != "#text")
        //        {

        //            var childNodes = node.SelectNodes("./*|./text()");

        //            if (childNodes != null)
        //            {
        //                foreach (var child in childNodes)
        //                {
        //                    nodes.Enqueue(child);
        //                    parentNode.InsertBefore(child, node);
        //                }
        //            }

        //            parentNode.RemoveChild(node);

        //        }
        //    }

        //    return document.DocumentNode.InnerHtml;
        //}
        #endregion
    }
}
