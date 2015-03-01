using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.UserControls
{
    public partial class ucSeachBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static void AddToCart()
        {         
            ShoppingBiz Biz = new ShoppingBiz();
            ucSeachBox box = new ucSeachBox();
            ScrapingData Data = box.GetData(); //Data For DB
            string Result = Biz.AddtoCart(Data);
            if (Result == "")
            {
                //Close Popup
            }
            else
            {
                //Write Log error message
            }
                
        }

        public ScrapingData GetData()
        {
            ScrapingData Data = new ScrapingData();
            Data.CUS_BK_AMOUNT = 0;
            Data.CUS_BK_PRICE = 0;
            Data.CUS_BK_SIZE = 0;
            Data.CUS_BK_REMARK = "";
            Data.CUS_BK_STATUS = "";
            Data.Create_User = "";
            return Data;
        }


    }
}