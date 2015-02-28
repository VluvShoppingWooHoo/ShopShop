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
            ucSeachBox box = new ucSeachBox();
            box.NewItem();

            ShoppingBiz Biz = new ShoppingBiz();            
            ShoppingData Data = box.GetData();
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

        protected void NewItem()
        {
            ShoppingBiz Biz = new ShoppingBiz();

        }

        protected ShoppingData GetData()
        {
            ShoppingData Data = new ShoppingData();            
            return Data;
        }


    }
}