using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.Customer
{
    public partial class Register : System.Web.UI.Page
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

            Cust.Cus_Email = txtEmail.Text;
            Cust.Cus_Password = txtPassword.Text;
            Cust.Cus_Mobile = txtMobile.Text;
            Cust.Cus_Ref_ID = hddRefCust.Value == "" ? 0 : Convert.ToInt32(hddRefCust.Value);

            string Result = Log.InsertRegisCustomer(Cust);
            return Result;
        }        
    }
}