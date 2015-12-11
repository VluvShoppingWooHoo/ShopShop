using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
        public event System.EventHandler ucCusDetail_OpenpopClick;
        private void OnbtnOpenPopUp()
        {
            if (ucCusDetail_OpenpopClick != null) { ucCusDetail_OpenpopClick(this, new System.EventArgs()); }
        }

        public event System.EventHandler ucCusDetail_ShowMessage;
        private void OnbtnShowMessage()
        {
            if (ucCusDetail_ShowMessage != null) { ucCusDetail_ShowMessage(this, new System.EventArgs()); }
        }

        public Int32 _VS_CUS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_CUS_ID"].ToString()); }
            set { ViewState["__VS_CUS_ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindData(string Status = "")
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
                    if (Status == "")
                    {
                        if (ds.Tables[0].Rows.Count > 0) BindData_Part_1(ds.Tables[0]);

                        BindData_Part_2(ds.Tables[1]);
                        BindData_Part_3(ds.Tables[2]);
                    }
                    else if (Status == "1")
                    {
                        BindData_Part_2(ds.Tables[1]);
                    }
                    else if (Status == "2")
                    {
                        BindData_Part_3(ds.Tables[2]);
                    }
                }
                else
                {
                    OnbtnShowMessage();
                }
            }
            catch (Exception ex)
            {
                OnbtnShowMessage();
            }
        }

        public void BindData_Part_1(DataTable dt)
        {
            lbl_cus_code.Text = dt.Rows[0]["CUS_CODE"].ToString();
            lbl_cus_email.Text = dt.Rows[0]["CUS_EMAIL"].ToString();
            lbl_cus_name.Text = dt.Rows[0]["CUS_FULL_NAME"].ToString();
            lbl_cus_birthday.Text = dt.Rows[0]["CUS_BIRTHDAY_TEXT"].ToString();
            lbl_cus_tele.Text = dt.Rows[0]["CUS_TELEPHONE_TEXT"].ToString();
            lbl_cus_fax.Text = dt.Rows[0]["CUS_FAX"].ToString();
            lbl_cus_balance.Text = Convert.ToDouble(dt.Rows[0]["CUS_TOTAL_AMOUNT"].ToString()).ToString("N", new CultureInfo("en-US"));
            lbl_cus_point.Text = dt.Rows[0]["CUS_POINT"].ToString();
        }

        public void BindData_Part_2(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                BindGridViewData(gv_detail_account, dt);
            }
            else
            {
                BindGridViewNoData(gv_detail_account);
            }

        }

        public void BindData_Part_3(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                BindGridViewData(gv_detail_address, dt);
            }
            else
            {
                BindGridViewNoData(gv_detail_address);
            }
        }

        public void BindGridViewData(GridView gv, DataTable dt)
        {
            gv.DataSource = dt;
            gv.DataBind();
        }

        public void BindGridViewNoData(GridView gv)
        {
            gv.DataSource = null;
            gv.DataBind();
        }

        protected void gv_detail_address_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_detail_address.PageIndex = e.NewPageIndex;
            BindData("2");
            OnbtnOpenPopUp();
        }

        protected void gv_detail_account_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_detail_account.PageIndex = e.NewPageIndex;
            BindData("1");
            OnbtnOpenPopUp();
        }

    }
}