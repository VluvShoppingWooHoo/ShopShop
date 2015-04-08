using System;
using System.Collections.Generic;
using System.Data;
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
            //DataTable dt = biz.GetRate();
            string Date = "";
            double Rate = 0;
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    Date = dt.Rows[0]["CONFIG_REMARK"].ToString();
            //    Rate = dt.Rows[0]["CONFIG_VALUE"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["CONFIG_VALUE"].ToString());

            //}
            //else
            //{
            //    bp.WriteLog("Index", "GetRate", "Value is null");
            //    return;
            //}

            lbRate.Text = Rate.ToString();
            lbDate.Text = Date;
        }
    }
}