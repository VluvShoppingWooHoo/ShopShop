using System;
using System.Collections.Generic;
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
    public partial class Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {
            string Result = Insert();
            if (Result == "")
            {
                mView.ActiveViewIndex = 1;
                SetActivate();                
            }
            else
            {
                lbMessage.Text = "Error";
            }
        }

        protected string Insert()
        {
            LogonBiz Log = new LogonBiz();
            CustomerData Cust = new CustomerData();
            EncrypUtil en = new EncrypUtil();

            Cust.Cus_Email = txtEmail.Text;
            Cust.Cus_Password = en.EncrypData(txtPassword.Text);
            Cust.Cus_Mobile = txtMobile.Text;
            Cust.Cus_Ref_ID = hddRefCust.Value == "" ? 0 : Convert.ToInt32(hddRefCust.Value);

            string Result = Log.InsertRegisCustomer(Cust);
            return Result;
        }

        protected void SetActivate()
        {
            EncrypUtil en = new EncrypUtil();
            string e = "", c = "";
            e = en.EncrypData(txtEmail.Text);
            c = en.EncrypData(txtPassword.Text);
            hplActivate.Text = "ActivateHere";
            hplActivate.NavigateUrl = "Activate.aspx?e=" + Server.UrlEncode(e) + "&c=" + Server.UrlEncode(c);
        }
    }
}