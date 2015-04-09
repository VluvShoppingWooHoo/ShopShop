using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.UserControls
{
    public partial class ucCustomerStatus : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            if (Session["User"] != null)
            {
                CustomerBiz biz = new CustomerBiz();
                DataTable dt = new DataTable();
                dt = biz.GET_CUSTOMER_TRANS_AMOUNT(((CustomerData)(Session["User"])).Cus_ID);
                if (dt != null && dt.Rows.Count > 0)
                {
                    hlOrder.Text = hlOrder.Text + "(" + dt.Rows[0]["ORDERR"].ToString() + ")";
                    hlBasket.Text = hlBasket.Text + "(" + dt.Rows[0]["BASKET"].ToString() + ")";
                }
            }
        }

        public void CheckLogin(bool Check)
        {
            if (Check)
            {
                hlLogin.Visible = false;
                hlRegis.Visible = false;
                lbCustomer.Text = "สวัสดี คุณ " + ((CustomerData)Session["User"]).Cus_Name;
                lbCustomer.Visible = true;
                hlMember.Visible = true;
                hlLogout.Visible = true;
            }
            else
            {
                hlLogin.Visible = true;
                hlRegis.Visible = true;
                lbCustomer.Text = "";
                lbCustomer.Visible = false;
                hlMember.Visible = false;
                hlLogout.Visible = false;
            }
        }        
    }
}