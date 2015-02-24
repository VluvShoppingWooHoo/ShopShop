using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.Administrator
{
    public partial class page_ms_bank : System.Web.UI.Page
    {

        public int _VS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_ID"]); }
            set { ViewState["__VS_ID"] = value; }
        }

        public string _VS_ACT
        {
            get { return ViewState["__VS_ACT"].ToString(); }
            set { ViewState["__VS_ACT"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindData()
        {
            DataSet ds = new DataSet();
            commonBiz Biz = new commonBiz();
            ds = Biz.GET_DATA_MASTER_BANK(this._VS_ID, "BINDDATA");

            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_Deatil.DataSource = ds.Tables[0];
                gv_Deatil.DataBind();
            }
            else
            {
                gv_Deatil.DataSource = null;
                gv_Deatil.DataBind();
            }
        }

        public void ClearData()
        {
            txt_acc_name.Text = "";
            txt_acc_no.Text = "";
            txt_remark.Text = "";
            ddl_Status.SelectedIndex = 0;
        }

        public void ShowMessageBox(string message, Page currentPage)
        {
            string msgboxScript = "alert('" + message + "');";

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
            }
        }

        public CommonData SetData()
        {
            CommonData En = new CommonData();
            En.BANK_ID = this._VS_ID;
            if (this._VS_ACT != "DEL")
            {
                En.BANK_NAME = txt_acc_name.Text.Trim();
                En.BANK_ACCOUNT_NO = txt_acc_no.Text.Trim();
                En.BANK_REMARK = txt_remark.Text.Trim();
                En.BANK_STATUS = Convert.ToInt32(ddl_Status.SelectedValue);
                En.Create_User = "Batt";
            }
            return En;
        }

        public bool CheckInput()
        {
            bool IsReturn = false;

            if (txt_acc_no.Text.Trim() == "")
            {

            }

            return IsReturn;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ClearData();
            _VS_ACT = "INS";
            ModalPopupExtender1.Show();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            commonBiz Biz = new commonBiz();
            string IsReturn = "";
            IsReturn = Biz.INS_UPD_DATA_MASTER_BANK(SetData(), this._VS_ACT);
            if (IsReturn != "")
            {
                ShowMessageBox(IsReturn, this.Page);
            }
            else
            {
                BindData();
                ShowMessageBox("บันทึกรายการเรียบร้อยแล้ว", this.Page);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_cus_address.DataKeys[rowIndex].Values[0].ToString();

            this._VS_CUS_ADD_ID = Convert.ToInt32(DataKeys_ID);
            this._VS_ACT = "UPD";

            DataSet ds = new DataSet();
            CustomerBiz CusBiz = new CustomerBiz();
            ds = CusBiz.GetData_Customer_Address(this._VS_CUS_ID, this._VS_CUS_ADD_ID, 1, "", "BINDDATA_BYID");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_Cusname.Text = ds.Tables[0].Rows[0]["CUS_ADD_CUS_NAME"].ToString();
                txt_CusDetail.Text = ds.Tables[0].Rows[0]["CUS_ADD_ADDRESS_TEXT"].ToString();
                txt_ZipCode.Text = ds.Tables[0].Rows[0]["CUS_ADD_ZIPCODE"].ToString();
                BinddataRegion("REGION");
                dll_region.SelectedValue = ds.Tables[0].Rows[0]["REGION_ID"].ToString();
                BinddataRegion("PROVINCE");
                dll_province.SelectedValue = ds.Tables[0].Rows[0]["PROVINCE_ID"].ToString();
                BinddataRegion("DISTRICT");
                dll_District.SelectedValue = ds.Tables[0].Rows[0]["DISTRICT_ID"].ToString();
                BinddataRegion("SUB_DISTRICT");
                dll_Sub_District.SelectedValue = ds.Tables[0].Rows[0]["SUB_DISTRICT_ID"].ToString();
            }

            ModalPopupExtender1.Show();
        }

        protected void btnImgDelete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_Deatil.DataKeys[rowIndex].Values[0].ToString();
            this._VS_ID = Convert.ToInt32(DataKeys_ID);
            this._VS_ACT = "DEL";

            CustomerBiz CusBiz = new CustomerBiz();
            string IsReturn = "";
            IsReturn = CusBiz.INS_UPD_Customer_Address(SetData(), this._VS_ACT);
            if (IsReturn != "")
            {
                ShowMessageBox(IsReturn, this.Page);
            }
            else
            {
                BindData();
                ShowMessageBox("บันทึกรายการเรียบร้อยแล้ว", this.Page);
            }
        }

        protected void gv_Deatil_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("btnImgDelete")).Attributes.Add("onClick", "javascript:return confirm('คุณต้องการลบข้อมูลนี้หรือไม่ ?')");
            }
        }

        protected void BtnImgClose_Click(object sender, ImageClickEventArgs e)
        {
            ClearData();
        }
    }
}