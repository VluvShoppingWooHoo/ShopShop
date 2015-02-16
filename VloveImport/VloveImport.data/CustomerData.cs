using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class CustomerData : CommonData
    {
        public int Cus_ID { get; set; }
        public string Cus_Name { get; set; }
        public string Cus_LName { get; set; }
        public string Cus_Gender { get; set; }
        public DateTime Cus_BirthDay { get; set; }
        public string Cus_Telephone { get; set; }
        public string Cus_Mobile { get; set; }
        public string Cus_Fax { get; set; }
        public string Cus_Email { get; set; }
        public string Cus_Password { get; set; }
        public string Cus_Withdraw_Code { get; set; }
        public string Cus_Link_Shop { get; set; }
        public int Cus_Point { get; set; }
        public int Cus_Ref_ID { get; set; }
        public int Cus_Active { get; set; }
        public int Cus_Status { get; set; }
        public DateTime Activate_Date { get; set; }

        #region TB_CUSTOMER_ADDRESS

        public int CUS_ADD_ID { get; set; }
        public string CUS_ADD_CUS_NAME { get; set; }
        public string CUS_ADD_ADDRESS_TEXT { get; set; }
        public int CUS_ADD_ZIPCODE { get; set; }
        public int CUS_ADD_STATUS { get; set; }

        #endregion

        #region TB_CUSTOMER_ACC_NAME

        public int CUS_ACC_NAME_ID { get; set; }
        public string CUS_ACC_NAME_NO { get; set; }
        public string CUS_ACC_NAME_BRANCH { get; set; }
        public string CUS_ACC_NAME_REMARK { get; set; }
        public int CUS_ACC_NAME_STAUTS { get; set; }

        #endregion

        #region TB_CUSTOMER_FAVORIT_SHOP

        public int CUS_SHOP_ID { get; set; }
        public string CUS_SHOP_NAME { get; set; }
        public string CUS_SHOP_LINK { get; set; }
        public string CUS_SHOP_REMARK { get; set; }
        public int CUS_SHOP_STATUS { get; set; }

        #endregion

        #region TB_CUSTOMER_BASKET

        public string PROD_ID { get; set; }
        public string CUS_BK_NUMBER { get; set; }
        public string CUS_BK_PRICE { get; set; }
        public int CUS_BK_REMARK { get; set; }

        #endregion

    }
}
