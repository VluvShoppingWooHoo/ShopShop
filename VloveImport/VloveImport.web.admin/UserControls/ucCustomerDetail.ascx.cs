using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.admin.UserControls
{
    public partial class ucCustomerDetail : System.Web.UI.UserControl
    {

        public Int32 _VS_CUS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_CUS_ID"].ToString()); }
            set { ViewState["__VS_CUS_ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindData()
        {
            DataSet ds = new DataSet();
            try
            {
                CustomerData En = new CustomerData();

                En.Cus_ID = _VS_CUS_ID;

                AdminBiz AdBiz = new AdminBiz();
                ds = AdBiz.ADMIN_GET_CUSTOMER(En, "BINDDATA_DETAIL");

                if (ds.Tables.Count > 0)
                {
                   
                }
                else
                {
                   
                }

            }
            catch (Exception ex)
            {

            }
        }

        public void BindData_Part_1(DataTable dt)
        { 
            
        }

        public void BindData_Part_2(DataTable dt)
        {

        }

        public void BindData_Part_3(DataTable dt)
        {

        }

    }
}