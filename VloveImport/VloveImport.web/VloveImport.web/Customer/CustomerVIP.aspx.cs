using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerVIP : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession();
                GetMymoney();
            }
        }

        public void GetMymoney()
        {
            CustomerBiz biz = new CustomerBiz();
            double Mymoney = biz.GET_CUSTOMER_BALANCE(GetCusID());
            lbMymoney.Text = Mymoney.ToString("###,##0.00");
        }

        protected void btnSelect_ServerClick(object sender, EventArgs e)
        {
            CustomerBiz Biz = new CustomerBiz();

            //Get VIP Type
            int VIP_ID = 1;
            int VIP_PERCENT = 15;

            //Insert Transaction
            string Result = "";
            Result = Biz.Regis_VIP(GetCusID(), VIP_ID, VIP_PERCENT);
        }
    }
} 