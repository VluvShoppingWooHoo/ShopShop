using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data.Extension
{
    public static class Constant
    {
        public static class PageMenu
        {
            public const int News = 1;
            public const int About_Us = 2;
            public const int Shipping_Price = 3;
            public const int Contact_Us = 4;
            public const int Tour = 5;
            public const int Service = 6;
            public const int Promo = 7;
            public const int Howto = 8;
            public const int Jobs = 9;
        }

        public static class Web
        {
            public const int WTaoBao = 1;
            public const int WTmall = 2;
            public const int W1688 = 3;
        }

        public static class WebSubTaobao
        {
            public const string TW_Taobao = "tw.taobao";
            public const string WORLD_Taobao = "world.taobao";
        }
        public static class WebTemplate
        {
            public const string Taobao = "http://item.taobao.com/item.htm?id=";
        }
        
        public static class Fact
        {
            public const int F = 0;
            public const int T = 1;
        }

        public static class ScrapModel
        {
            public const string ItemID = "ItemID";
            public const string ItemName = "ItemName";
            public const string DESC = "DESC";
            public const string picURL = "picURL";
            public const string Price = "Price";
            public const string ProPrice = "ProPrice";
            public const string Color = "Color";
            public const string Size = "Size";
            public const string ShopName = "ShopName";
            public const string Web = "Web";
        }
    }
}
