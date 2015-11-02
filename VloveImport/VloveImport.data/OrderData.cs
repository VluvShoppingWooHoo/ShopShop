using System;
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
        public int CUS_ADDRESS_ID { get; set; }        
        public int TRANSPORT_CH_TH_METHOD { get; set; }
        public int TRANSPORT_TH_CU_METHOD { get; set; }
        public DateTime TRANSPORT_DATE { get; set; }
        public string TRANSPORT_DETAIL { get; set; }
        public int TRANSPORT_STATUS { get; set; }
        public double ORDER_CURRENCY { get; set; }
        public int ORDER_TRANS_RATE { get; set; }
        public string EMP_USER { get; set; }
        public DateTime EMP_UPDATE_DATE { get; set; }
        public string ORDER_EMP_REMARK { get; set; }
        public int ORDER_TYPE { get; set; }        
        public string TRANSPORT_CUSTOMER_DETAIL { get; set; }
        public string TRANSPORT_OTHER { get; set; }
        public int VIP_DISCOUNT { get; set; }

        public double SERVICE_CHARGE_DISCOUNT { get; set; }
        public double TRANSPORT_CUSTOMER_PRICE_DIS { get; set; } 


        #endregion

        #region Optional

        public string EMP_NAME { get; set; }
        public string ORDER_ID_LIST { get; set; }
        public string ORDER_CODE { get; set; }
        public string CUS_CODE { get; set; }

        public int UseFlag { get; set; }
        public string ORDER_DATE_TEXT { get; set; }
        public string CUS_FULLNAME { get; set; }
        public string ORDER_STATUS_TEXT { get; set; }
        public string TRANSPORT_STATUS_TEXT { get; set; }
        public double SUM_PROD_PRICE { get; set; }
        public double SUM_PROD_PRICE_ACTIVE { get; set; }

        #endregion

        #region TB_ORDER_SHOP
        public int ORDER_SHOP_ID { get; set; }
        public string SHOPNAME { get; set; }
        public string SHOP_ORDER_ID { get; set; }
        public string TRACKING_NO { get; set; }
        public string WEIGHT { get; set; }
        public string SIZE { get; set; }
        public double WEIGHT_PRICE { get; set; }
        public double SIZE_PRICE { get; set; }
        public double TRANSPORT_CHINA_PRICE { get; set; }
        public double TRANSPORT_THAI_PRICE { get; set; }
        public double TRANSPORT_CUSTOMER_PRICE { get; set; }
        public double SERVICE_CHARGE { get; set; }
        public double DISCOUNT { get; set; }
        public int PRODUCT_TYPE { get; set; }
        public string CAL_TRANSPORT_SHOP_RATE { get; set; }
        public string SHOP_REMARK { get; set; } 
        #endregion

        #region TB_ORDER_DETAIL
        public int OD_ID { get; set; }        
        public string OD_ITEMNAME { get; set; }
        public int OD_AMOUNT { get; set; }
        public int OD_AMOUNT_ACTIVE { get; set; }
        public double OD_PRICE { get; set; }
        public double OD_PRICE_ACTIVE { get; set; }
        public string OD_SIZE { get; set; }
        public string OD_COLOR { get; set; }
        public string OD_REMARK { get; set; }
        public string OD_URL { get; set; }
        public string OD_PICURL { get; set; }           
        public string OD_STATUS { get; set; }
        public string OD_SHOPNAME { get; set; }
        public string THANSPORT_CODE { get; set; }
        public string THANSPORT_CHINA_PRICE { get; set; }
        public string THANSPORT_THAI_PRICE { get; set; }
        public string THANSPORT_CUSTOMER_PRICE { get; set; }
        public string THANSPORT_TOTAL_PRICE { get; set; }
        public string OD_REF_BASKET { get; set; }
        #endregion

        #region TB_ORDER_TRACKING
        public int OT_ID { get; set; }
        public int OT_OS_ID { get; set; }
        public Nullable<DateTime> OT_DATE { get; set; }
        public string OT_STATUS_ID { get; set; }
        public string OT_STATUS_DESC { get; set; }
        public string OT_ACTIVE { get; set; }
        #endregion
    }
}

