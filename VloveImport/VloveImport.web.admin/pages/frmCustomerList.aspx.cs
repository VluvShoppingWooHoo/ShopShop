using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.admin.pages
{
    public partial class frmCustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            DataSet ds = new DataSet();
            try
            {
                CustomerData En = new CustomerData();

                En.Cus_ID = -1;
                En.Cus_Code = txtCus_Code.Text.Trim();
                En.Cus_Name = txtCus_Name.Text.Trim();
                En.CUS_BIRTHDAY_FROM = ucCalendar_BirthdayFrom.GET_DATE_TO_DATE();
                En.CUS_BIRTHDAY_TO = ucCalendar_BirthdayTo.GET_DATE_TO_DATE();
                En.Cus_Email = txtCus_Email.Text.Trim();
                En.Cus_Telephone = txtCus_telphone.Text.Trim();
                En.SYMBOW_TYPE = ddlSymbow.SelectedValue;
                En.CUS_AMOUNT = txtCus_Amount.Text.Trim() == "" ? (Double?)null : Convert.ToDouble(txtCus_Amount.Text.Trim());

                AdminBiz AdBiz = new AdminBiz();
                ds = AdBiz.ADMIN_GET_CUSTOMER(En, "BINDDATA");

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
            catch (Exception ex)
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtCus_Code.Text = "";
            txtCus_Name.Text = "";
            ucCalendar_BirthdayFrom.ClearData();
            ucCalendar_BirthdayTo.ClearData();
            txtCus_Email.Text = "";
            txtCus_telphone.Text = "";
            ddlSymbow.SelectedIndex = 0;
            txtCus_Amount.Text = "";
        }

    }
}