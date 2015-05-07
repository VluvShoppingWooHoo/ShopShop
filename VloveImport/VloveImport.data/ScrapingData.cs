﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class ScrapingData : CommonData
    {
        #region Scrapping
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string DESC { get; set; }
        public string picURL { get; set; }
        public string Price { get; set; }
        public string ProPrice { get; set; }
        public string AmountRange { get; set; }
        public string PriceRange { get; set; }
        private List<string> _AmountList = new List<string>();
        public List<string> AmountList
        {
            get { return _AmountList; }
            set { _AmountList = value; }
        }
        private List<string> _PriceList = new List<string>();
        public List<string> PriceList
        {
            get { return _PriceList; }
            set { _PriceList = value; }
        }

        //private List<string> _PriceColorList = new List<string>();
        //public List<string> PriceColorList
        //{
        //    get { return _PriceColorList; }
        //    set { _PriceColorList = value; }
        //}
        //private List<string> _ProPriceColorList = new List<string>();
        //public List<string> ProPriceColorList
        //{
        //    get { return _ProPriceColorList; }
        //    set { _ProPriceColorList = value; }
        //}
        //private List<string> _PriceSizeList = new List<string>();
        //public List<string> PriceSizeList
        //{
        //    get { return _PriceSizeList; }
        //    set { _PriceSizeList = value; }
        //}
        //private List<string> _ProPriceSizeList = new List<string>();
        //public List<string> ProPriceSizeList
        //{
        //    get { return _ProPriceSizeList; }
        //    set { _ProPriceSizeList = value; }
        //}

        public string Color { get; set; }
        public string Size { get; set; }
        public string URL { get; set; }
        public string ShopName { get; set; }    
        public int Web { get; set; }
        #endregion

        #region TB_BK_Customer_Basket
        public int CUS_ID { get; set; }
        public string CUS_BK_ITEMNAME { get; set; }
        public string CUS_BK_ITEMDESC { get; set; }   
        public int CUS_BK_NUMBER { get; set; }
        public int CUS_BK_AMOUNT { get; set; }
        public double CUS_BK_PRICE { get; set; }
        public string CUS_BK_SIZE { get; set; }
        public string CUS_BK_COLOR { get; set; }   
        public string CUS_BK_REMARK { get; set; }
        public string CUS_BK_URL { get; set; }
        public string CUS_BK_PICURL { get; set; }
        public string CUS_BK_STATUS { get; set; }
        public string CUS_BK_SHOPNAME { get; set; }
        #endregion
    }
}

