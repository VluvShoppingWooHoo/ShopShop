using System;
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
        public string Color { get; set; }
        public string Size { get; set; }     
        public int Web { get; set; }
        #endregion

        #region TB_BK_Customer_Basket
        public int CUS_ID { get; set; }
        public int CUS_BK_NUMBER { get; set; }
        public int CUS_BK_AMOUNT { get; set; }
        public float CUS_BK_PRICE { get; set; }
        public int CUS_BK_SIZE { get; set; }                
        public string CUS_BK_REMARK { get; set; }
        public string CUS_BK_URL { get; set; }
        public int CUS_BK_STATUS { get; set; }
        #endregion
    }
}
