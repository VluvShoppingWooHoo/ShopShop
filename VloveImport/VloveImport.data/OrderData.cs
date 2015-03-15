﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class OrderData : CommonData
    {
        #region TB_ORDER
        public int ORDER_ID { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public int ORDER_STATUS { get; set; }   
        public int CUS_ID { get; set; }
        public int ORDER_TRANSPOT_CHINA { get; set; }
        public int ORDER_TRANSPOT_THAI { get; set; }    
        public string EMP_NAME { get; set; }
        #endregion

        #region Optional

        public int UseFlag { get; set; }
        public string ORDER_DATE_TEXT { get; set; }
        public string CUS_FULLNAME { get; set; }
        public string ORDER_STATUS_TEXT { get; set; }
        public string SUM_PROD_PRICE { get; set; }

        #endregion

        #region TB_ORDER_DETAIL
        public int OD_ID { get; set; }        
        public string OD_ITEMNAME { get; set; }
        public int OD_AMOUNT { get; set; }
        public int OD_AMOUNT_ACTIVE { get; set; }
        public double OD_PRICE { get; set; }
        public string OD_SIZE { get; set; }
        public string OD_COLOR { get; set; }
        public string OD_REMARK { get; set; }        
        public string OD_REF_BASKET { get; set; }
        public string OD_STATUS { get; set; }
        #endregion
    }
}

