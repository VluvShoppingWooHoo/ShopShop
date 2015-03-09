using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.data;
using VloveImport.util;
using VloveImport.biz;
using VloveImport.data.Extension;

namespace VloveImport.web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //if (txtUser.Text == "")
            //{
            //    txtUser.Focus();
            //    return;
            //}
            //if (txtPass.Text == "")
            //{
            //    txtPass.Focus();
            //    return;
            //}

            LogonBiz Logon = new LogonBiz();
            CustomerData Cust = new CustomerData();
            Cust = Logon.LogonDBCustomer(txtUser.Text, txtPass.Text);
            if (Cust != null)
            {
                Session["User"] = Cust;
                Response.Redirect("~/Index.aspx");
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtPass.Text = "";
        }

        private void CheckSession()
        {
            if (Session["User"] != null)
                Login.Visible = false;
            else
                Login.Visible = true;
        }

        #region for Scraping Web in ucSearchBox & ucIndexBox
        [WebMethod]
        public static string GetModelFromURL(string txt)
        {
            //txt = "http://item.taobao.com/item.htm?spm=a215z.1607468.a214yav.11.ssGwcK&id=42865704337";
            //txt = "http://item.taobao.com/item.htm?id=42400927372&ali_refid=a3_420435_1006:1106126314:N:%B2%CA%BA%E7%D0%AC:7055520b07090b98fe54085c41bad517&ali_trackid=1_7055520b07090b98fe54085c41bad517&spm=a230r.1.1005.40.wn70vl";
            ScrapingBiz sc = new ScrapingBiz();
            ScrapingData data = new ScrapingData();
            JavaScriptSerializer js = new JavaScriptSerializer();
            try
            {
                int webMode = 1;
                #region for use
                if (txt.Contains("taobao.com"))
                    webMode = Constant.Web.WTaoBao;
                else if (txt.Contains("tmall.com"))
                    webMode = Constant.Web.WTmall;
                else
                    webMode = Constant.Web.W1688;

                data = sc.Handle(txt, webMode);
                #endregion
                #region for test
                //data.Color = "http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2_8NXbpXXXXXkXXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2j6oZbXXXXXbTXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2QDs2bXXXXXXWXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img02.taobaocdn.com/bao/uploaded/i2/1060829869/TB2yD25bXXXXXaMXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img04.taobaocdn.com/bao/uploaded/i4/1060829869/TB2LQj6bXXXXXc2XXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img01.taobaocdn.com/bao/uploaded/i1/1060829869/TB2zmr.bXXXXXbOXXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg";
                //data.ItemName = "[Bommy]Test Test";
                //data.picURL = "http://img04.taobaocdn.com/bao/uploaded/i4/TB12EHiGVXXXXX6XXXXXXXXXXXX_!!0-item_pic.jpg_400x400.jpg";
                //data.Price = "69";
                //data.Size = "70/32AB||75/34AB||80/36AB";
                #endregion
                data.Web = webMode;
                #region getID
                string[] a = txt.Split('?');
                string[] b = a[1].Split('&');

                foreach (string item in b)
                {
                    if (item.IndexOf("id=") == 0)
                    {
                        data.URL = a[0] + '?' + item;
                        txt = item.Replace("id=", "");
                    }
                }
                data.ItemID = txt;
                #endregion
            }
            catch (Exception ex) { }
            return js.Serialize(data);
            //return data;

        }

        [WebMethod]
        public static string GetSideMenu()
        {
            //From weloveshopping
            ScrapingBiz sc = new ScrapingBiz();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string tag = string.Empty;
            try
            {
                //tag = sc.GetSideMenu("http://portal.weloveshopping.com/");
                tag = sc.GetSideMenu("http://www.vcanbuy.com/protected/faqs/tree");                
            }
            catch (Exception ex) { }
            return tag;
            //return js.Serialize(tag);
            //return data;

        }
        #endregion

        #region AddToCart
        [WebMethod]
        public static string btnSearch(string Name, string Desc, string Amount, string Price, string Size,
            string Color, string Remark, string URL, string Picture)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string Result = "";
            Index Index = new Index();
            ScrapingData Data = new ScrapingData();
            Data.CUS_BK_ITEMNAME = Name;
            Data.CUS_BK_ITEMDESC = Name;
            Data.CUS_BK_AMOUNT = Convert.ToInt32(Amount);
            Data.CUS_BK_PRICE = Convert.ToInt32(Price);
            Data.CUS_BK_SIZE = Convert.ToInt32(Size);
            Data.CUS_BK_COLOR = Color;
            Data.CUS_BK_REMARK = Remark;
            Data.CUS_BK_URL = URL;
            Data.CUS_BK_PICURL = Picture;
            Data.CUS_BK_STATUS = "BASKET";
            Data.Create_User = "";
            Result = Index.AddToCart(Data);
            if (Result != "")
            {
                //Alert Contact Admin
            }
            else
            {
                //Close Popup
            }
            return js.Serialize(Result);
        }

        protected string AddToCart(ScrapingData Data)
        {
            string Result = "";
            ShoppingBiz Biz = new ShoppingBiz();
            Result = Biz.AddtoCart(Data);
            return Result;
        }
        #endregion
    }
}
