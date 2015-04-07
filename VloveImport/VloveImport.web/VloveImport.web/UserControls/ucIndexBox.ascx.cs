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
using VloveImport.web.App_Code;

namespace VloveImport.web.UserControls
{
    public partial class ucIndexBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetRate();
        }

        public void SetRate()
        {
            ShoppingBiz biz = new ShoppingBiz();
            BasePage bp = new BasePage();
            string Value = biz.GetRate();
            string Date = "";
            double Rate = 0;
            if (Value == "")
            {
                bp.WriteLog("Index", "GetRate", "Value is null");
                return;
            }

            try
            {
                Rate = Convert.ToDouble(Value.Split('|')[0]);
                Date = "ณ วันที่ " + Value.Split('|')[1];
            }
            catch (Exception ex)
            {}

            lbRate.Text = Rate.ToString();
            lbDate.Text = Date;
        }
    }
}