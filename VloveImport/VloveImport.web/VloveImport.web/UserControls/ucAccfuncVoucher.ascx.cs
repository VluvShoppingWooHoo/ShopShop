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
    public partial class ucAccfuncVoucher : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetPoint();
            }
        }

        protected void SetPoint()
        {
            lbMyPoint.Text = "0";
        }

        protected void btnVoucher500_Click(object sender, EventArgs e)
        {
            int Point = 0;
            CustomerBiz biz = new CustomerBiz();
            BasePage bp = new BasePage();
            Point = bp.GetPoint();
            if (Point > 100)
            {
                biz.INS_UPD_TRANSACTION
            }
            else
            {
                bp.ShowMessageBox("คะแนนไม่พอ สะสมคะแนนอีกนิดนะคะ");
                return;
            }
        }
    }
}