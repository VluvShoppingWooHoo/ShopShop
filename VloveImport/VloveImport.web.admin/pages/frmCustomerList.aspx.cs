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
            ucEmail1.ucEmail_OpenpopClick += new System.EventHandler(ucEmail_OpenpopClick);
            ucCustomerDetail1.ucCusDetail_OpenpopClick += new System.EventHandler(ucCusDetail_OpenpopClick);
            ucCustomerDetail1.ucCusDetail_ShowMessage += new System.EventHandler(ucCusDetail_ShowMessage);

            if (!IsPostBack)
            {
                ResetData();
                BindData();
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ResetData();
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
                En.SYMBOW_TYPE = txtCus_Amount.Text.Trim() == "" ? "-1" : ddlSymbow.SelectedValue;
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

        public void ResetData()
        {
            txtCus_Code.Text = "";
            txtCus_Name.Text = "";
            ucCalendar_BirthdayFrom.CleanDataTextBox();
            ucCalendar_BirthdayTo.CleanDataTextBox();
            txtCus_Email.Text = "";
            txtCus_telphone.Text = "";
            ddlSymbow.SelectedIndex = 0;
            txtCus_Amount.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
        }

        protected void imgBtn_Email_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[2].ToString();

            ucEmail1.SetEmail(DataKeys_ID);
            ucEmail1.SetEmail_To_Enabled();
            MadoalPop_Email.Show();
        }

        protected void imgBtn_view_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string CUS_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            ucCustomerDetail1._VS_CUS_ID = Convert.ToInt32(CUS_ID);
            ucCustomerDetail1.BindData();
            ModalPopupExtender1.Show();
        }

        public void ucEmail_OpenpopClick(object sender, System.EventArgs e)
        {
            MadoalPop_Email.Show();
        }

        public void ucCusDetail_OpenpopClick(object sender, System.EventArgs e)
        {
            ModalPopupExtender1.Show();
        }

        public void ucCusDetail_ShowMessage(object sender, System.EventArgs e)
        {
            ShowMessageBox("Data not found", this.Page);
        }

        public void ShowMessageBox(string message, Page currentPage)
        {
            string msgboxScript = "alert('" + message + "');";

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
            }
        }

        protected void gv_detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_detail.PageIndex = e.NewPageIndex;
            BindData();
        }

    }
}