using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class CommonData
    {
        //public string Create_User { get; set; }
        //public DateTime Create_Date { get; set; }
        //public string Update_User { get; set; }
        //public DateTime Update_Date { get; set; }

        public int ROW_INDEX { get; set; }
        public string Create_User { get; set; }
        public Nullable<DateTime> Create_Date { get; set; }
        public string Update_User { get; set; }
        public Nullable<DateTime> Update_Date { get; set; }

        public int REGION_ID { get; set; }
        public int PROVINCE_ID { get; set; }
        public int DISTRICT_ID { get; set; }
        public int SUB_DISTRICT_ID { get; set; }

        #region DATA BANK
        public int BANK_ID { get; set; }
        public string BANK_NAME { get; set; }

        public int BANK_SHOP_ID { get; set; }
        public string BANK_SHOP_NAME { get; set; }
        public string BANK_SHOP_ACCOUNT_NO { get; set; }
        public string BANK_SHOP_ACCOUNT_NAME { get; set; }
        public string BANK_SHOP_REMARK { get; set; }
        public int BANK_SHOP_STATUS { get; set; }
        #endregion

        #region Config

        public string CONFIG_ID { get; set; }
        public string CONFIG_VALUE { get; set; }
        public string CONFIG_VALUE2 { get; set; }
        public string CONFIG_GROUP { get; set; }
        public string CONFIG_REMARK { get; set; }

        #endregion




    }
}
