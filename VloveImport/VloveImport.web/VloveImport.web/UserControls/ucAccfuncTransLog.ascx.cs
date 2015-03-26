using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.web.App_Code;

namespace VloveImport.web.UserControls
{
    public partial class ucAccfuncTransLog : System.Web.UI.UserControl
    {
        public int _VS_CUS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_CUS_ID"]); }
            set { ViewState["__VS_CUS_ID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BasePage bp = new BasePage();
                this._VS_CUS_ID = bp.GetCusID();
                BindData();
                GetMymoney();

            }
        }

        public void GetMymoney()
        {
            CustomerBiz biz = new CustomerBiz();
            double Mymoney = biz.GET_CUSTOMER_BALANCE(this._VS_CUS_ID);
            lbMymoney.Text = Mymoney.ToString("###,##0.00");
        }

        protected void BindData()
        {

        }
    }
}