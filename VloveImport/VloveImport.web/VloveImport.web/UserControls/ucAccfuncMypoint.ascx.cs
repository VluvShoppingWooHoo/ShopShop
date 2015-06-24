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
            BasePage bp = new BasePage();
            lbMyPoint.Text = bp.GetPoint().ToString("###,##0");
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
            int CurrentPoint = 0, VoucherPoint = 0, MV_ID = 0, CUS_ID = 0;
            string Result = "";
            ShoppingBiz biz = new ShoppingBiz();
            BasePage bp = new BasePage();
            CurrentPoint = bp.GetPoint();
            CUS_ID = bp.GetCusID();
            MV_ID = ((Button)sender).CommandArgument == "" ? 0 : Convert.ToInt32(((Button)sender).CommandArgument);
            VoucherPoint = ((Button)sender).CommandName == "" ? 1000 : Convert.ToInt32(((Button)sender).CommandName);
            if (CurrentPoint > VoucherPoint)
            {
                Result = biz.CreateVoucher(CUS_ID, MV_ID, VoucherPoint);
                if (Result != "")
                {
                    bp.ShowMessageBox("การแลก Voucher มีปัญหา กรูณาติดต่อผู้ดูแลระบบค่ะ!!");                    
                    bp.WriteLog("ucAccfuncMypoint", "btnVoucher_Click", Result);
                    return;
                }
                bp.Redirect("CustomerMyAccount.aspx#voucher");
            }
            else
            {
                bp.ShowMessageBox("คะแนนไม่พอ สะสมคะแนนอีกนิดนะคะ");
                return;
            }
        }
    }
}