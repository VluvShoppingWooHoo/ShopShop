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
    public partial class ucAccfuncMypoint : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPoint();
                BindData();
            }
        }

        protected void SetPoint()
        {
            lbMyPoint.Text = "0";
        }

        protected void BindData()
        {
            DataTable dt = new DataTable();
            ShoppingBiz biz = new ShoppingBiz();
            dt = biz.GetMasterVoucher();
            if (dt != null && dt.Rows.Count > 0)
            {

                gvVoucher.DataSource = dt;
                gvVoucher.DataBind();
            }
        }

        protected void btnVoucher_Click(object sender, EventArgs e)
        {
            int Point = 0;
            CustomerBiz biz = new CustomerBiz();
            BasePage bp = new BasePage();
            Point = bp.GetPoint();
            if (Point > 100)
            {
                //biz.INS_UPD_TRANSACTION
            }
            else
            {
                bp.ShowMessageBox("คะแนนไม่พอ สะสมคะแนนอีกนิดนะคะ");
                return;
            }
        }

        protected void btnVoucher500_Click(object sender, EventArgs e)
        {
            int Point = 0;
            CustomerBiz biz = new CustomerBiz();
            BasePage bp = new BasePage();
            Point = bp.GetPoint();
            if (Point > 100)
            {
                //biz.INS_UPD_TRANSACTION
            }
            else
            {
                bp.ShowMessageBox("คะแนนไม่พอ สะสมคะแนนอีกนิดนะคะ");
                return;
            }
        }
    }
}