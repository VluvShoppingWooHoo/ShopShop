using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.data.Extension;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CheckTracking : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTracking.Text != "")
            {
                DataTable dt = new DataTable();
                ShoppingBiz biz = new ShoppingBiz();
                dt = biz.GetTracking(txtTracking.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //lbTrack.Text = dt.Rows[0]["T_TRACKING_NO"].ToString();
                    gv_detail.DataSource = dt;
                    gv_detail.DataBind();
                }
                else
                {

                }
            }
            else
            {                
                //WriteLog(Page.Request.Url.AbsolutePath, "Login", Desc);
                ShowMessageBox("Please Key Tracking Number!!");
                return;
            }
        }
       
        
    }
}