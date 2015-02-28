using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class ShoppingData : CommonData
    {
        public int CUS_ID { get; set; }
        public int PROD_ID { get; set; }
        public int CUS_BK_NUMBER { get; set; }
        public int CUS_BK_AMOUNT { get; set; }
        public float CUS_BK_PRICE { get; set; }
        public string CUS_BK_REMARK { get; set; }
        public string CUS_BK_URL { get; set; }

    }
}
