using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;

namespace VloveImport.web.Administrator
{
    public partial class frmOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static void btnSearch(string login, string shopname)
        {
            frmOrderList frm = new frmOrderList();
            frm.BindData(login, shopname);
        }
        protected void BindData(string login, string shopname)
        {
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = Biz.GetOrderList(login, shopname);
            if (dt != null && dt.Rows.Count > 0)
            {
                gvOrder.DataSource = dt;
                gvOrder.DataBind();
            }
            else
            {
                gvOrder.DataSource = null;
                gvOrder.DataBind();
            }
        }
    }
}