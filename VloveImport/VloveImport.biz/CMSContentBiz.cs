using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using VloveImport.dal;
using VloveImport.data;
using VloveImport.data.Extension;

namespace VloveImport.biz
{
    public class CMSContentBiz
    {
        public List<PromotionMonth> GetPromotionMonthList()
        {
            List<PromotionMonth> models = new List<PromotionMonth>();
            CMSContentDal dal = new CMSContentDal("LocalConnection");
            try
            {
                models = dal.GetPromotionMonth();
            }
            catch (Exception ex) { }
            return models;
        }

        public List<ContentData> GetList(int page, string MNY)
        {
            List<ContentData> models = new List<ContentData>();
            CMSContentDal dal = new CMSContentDal("LocalConnection");
            try
            {
                models = dal.GetContent(page, MNY);
            }
            catch (Exception ex) { }
            return models;
        }

        public ContentData GetContentByIDList(int ID)
        {
            ContentData models = new ContentData();
            CMSContentDal dal = new CMSContentDal("LocalConnection");
            try
            {
                models = dal.GetContentByID(ID);
            }
            catch (Exception ex) { }
            return models;
        }
    }
}
