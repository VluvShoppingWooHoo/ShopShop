using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.web.App_Code;

namespace VloveImport.web.UserControls
{
    public partial class ucAccfuncVoucher : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            BasePage bp = new BasePage();
            ShoppingBiz biz = new ShoppingBiz();
            DataTable dt = biz.GetCustomerVoucher(bp.GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {
                gvVoucher.DataSource = dt;
                gvVoucher.DataBind();
                divMyVoucher.Visible = true;
            }
            else
            {
                gvVoucher.DataSource = null;
                gvVoucher.DataBind();
                divMyVoucher.Visible = false;
            }
        }

        public string ConvertDate(string Input)
        {
            string Result = "";
            if (Input != "")
            {
                Result = Convert.ToDateTime(Input).ToString("dd/MM/yyyy hh:mm");
            }
            return Result;
        }
    }
}