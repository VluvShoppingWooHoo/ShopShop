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

        #region for Scraping Web in ucSearchBox
        [WebMethod]
        public static string GetModelFromURL(string txt)
        {
            //txt = "http://item.taobao.com/item.htm?spm=a215z.1607468.a214yav.11.ssGwcK&id=42865704337";

            ScrapingBiz sc = new ScrapingBiz();
            ScrapingDataModel data = new ScrapingDataModel();
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
                //data.Web = webMode;
                //data.Color = "http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2_8NXbpXXXXXkXXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2j6oZbXXXXXbTXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img03.taobaocdn.com/bao/uploaded/i3/1060829869/TB2QDs2bXXXXXXWXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img02.taobaocdn.com/bao/uploaded/i2/1060829869/TB2yD25bXXXXXaMXpXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img04.taobaocdn.com/bao/uploaded/i4/1060829869/TB2LQj6bXXXXXc2XXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg||http://img01.taobaocdn.com/bao/uploaded/i1/1060829869/TB2zmr.bXXXXXbOXXXXXXXXXXXX_!!1060829869.jpg_30x30.jpg";
                //data.ItemName = "[Bommy]Test Test";
                //data.picURL = "http://img04.taobaocdn.com/bao/uploaded/i4/TB12EHiGVXXXXX6XXXXXXXXXXXX_!!0-item_pic.jpg_400x400.jpg";
                //data.Price = "69";
                //data.Size = "70/32AB||75/34AB||80/36AB";
                #endregion
            }
            catch (Exception ex) { }
            return js.Serialize(data);
            //return data;

        }
        #endregion
    }
}
