using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerTransport : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession();                 

                BindTrans();
            }
        }

        protected void BindTrans()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            CustomerBiz BizCus = new CustomerBiz();
            rdbChina.DataSource = Biz.GetTransList("CHINA");
            rdbChina.DataBind();
            rdbChina.SelectedIndex = 0;

            rdbThai.DataSource = Biz.GetTransList("THAI");
            rdbThai.DataBind();
            rdbThai.SelectedIndex = 0;

            rdbAddress.DataSource = BizCus.GetData_Customer_Address(GetCusID(), 0, 0, "BINDDATA");
            rdbAddress.DataBind();
            rdbAddress.SelectedIndex = 0;
        }

        protected void btnOrder_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("TRANS");
            string China = rdbChina.SelectedItem.Value + "|" + rdbChina.SelectedItem.Text;
            string Thai = rdbThai.SelectedItem.Value + "|" + rdbThai.SelectedItem.Text;
            string Address = rdbAddress.SelectedItem.Value + "|" + rdbAddress.SelectedItem.Text;
            string Trans = China + "," + Thai + "," + Address;                          

            Session.Add("TRANS", Trans);
            EncrypUtil en = new EncrypUtil();
            string CUS_ID = GetCusID().ToString();
            CUS_ID = en.EncrypData(CUS_ID);
            Response.Redirect("CustomerConfirmInfo.aspx?CID=" + CUS_ID);
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            EncrypUtil en = new EncrypUtil();
            string CUS_ID = GetCusID().ToString();
            CUS_ID = en.EncrypData(CUS_ID);
            Response.Redirect("CustomerBasket.aspx?CID=" + CUS_ID);
        }

        protected void rdbThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbThai.SelectedItem.Value == "")
            {

            }
            else
            {

            }
        }

    }
}