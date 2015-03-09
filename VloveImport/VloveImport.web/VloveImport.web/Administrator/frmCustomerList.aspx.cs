using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;

namespace VloveImport.web.Administrator
{
    public partial class frmCustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static void Search(string Login, string Name)
        {
            UserBiz Biz = new UserBiz();
            DataTable dt = new DataTable();
            dt = Biz.GetUser(Login, Name);
            if (dt != null && dt.Rows.Count > 0)
            {

            }
            else
            {

            }
        }
    }
}