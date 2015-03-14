using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;

namespace VloveImport.web.admin.pages
{
    public partial class frmOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindData()
        {
            DataSet ds = new DataSet();

            AdminBiz AdBiz = new AdminBiz();
            ds = AdBiz.GET_ADMIN_ORDER("BINDDATA");

            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_detail.DataSource = ds.Tables[0];
                gv_detail.DataBind();
            }
            else
            {
                gv_detail.DataSource = null;
                gv_detail.DataBind();
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtn_delete_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSelectOrder_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }



       
    }
}