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
            if (!IsPostBack)
            {
                BindData_MS_BANK();
                BindData();
            }
        }

        public void BindData_MS_BANK()
        {
            DataSet ds = new DataSet();
            commonBiz Biz = new commonBiz();
            ds = Biz.GET_DATA_MASTER_BANK(Act: "BINDDATA");

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow Data_Row;
                Data_Row = ds.Tables[0].NewRow();

                Data_Row["BANK_ID"] = -1;
                Data_Row["BANK_NAME"] = "กรุณาเลือก";
                ds.Tables[0].Rows.InsertAt(Data_Row, 0);

                ddl_bank_name.DataTextField = "BANK_NAME";
                ddl_bank_name.DataValueField = "BANK_ID";

                ddl_bank_name.DataSource = ds.Tables[0];
                ddl_bank_name.DataBind();
            }
        }

        public void BindData()
        {
            DataSet ds = new DataSet();
            commonBiz Biz = new commonBiz();
            ds = Biz.GET_DATA_BANK_SHOP(this._VS_ID, "BINDDATA");

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
            ddl_bank_name.SelectedIndex = 0;
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
            En.BANK_SHOP_ID = this._VS_ID;
            if (this._VS_ACT != "DEL")
            {
                En.BANK_ID = Convert.ToInt32(ddl_bank_name.SelectedValue);
                En.BANK_SHOP_ACCOUNT_NAME = txt_acc_name.Text.Trim();
                En.BANK_SHOP_ACCOUNT_NO = txt_acc_no.Text.Trim();
                En.BANK_SHOP_REMARK = txt_remark.Text.Trim();
                En.BANK_SHOP_STATUS = Convert.ToInt32(ddl_Status.SelectedValue);
                En.Create_User = "Batt";
            }
            return En;
        }

        public bool CheckInput()
        {
            bool IsReturn = true;

            if (txt_acc_no.Text.Trim() == "" && txt_acc_name.Text == "" && ddl_bank_name.SelectedValue == "-1")
            {
                IsReturn = false;
                ShowMessageBox("กรุณากรอกข้อมูลในช่องที่มีสัญลักษณ์ *", this.Page);
            }

            commonBiz com = new commonBiz();
            DataSet ds = new DataSet();
            ds = com.GET_DATA_BANK_SHOP(-1, "CHECK_DATA", Convert.ToInt32(ddl_bank_name.SelectedValue), txt_acc_no.Text.Trim(), txt_acc_name.Text.Trim());

            if (this._VS_ACT == "INS")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    IsReturn = false;
                    ShowMessageBox("ข้อมูลชุดนี้มีอยู่ในระบบแล้วกรุณาตรวจสอบอีกครั้ง !!", this.Page);
                }
                else IsReturn = true;
            }
            else if (this._VS_ACT == "UPD")
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (this._VS_ID.ToString() != ds.Tables[0].Rows[0]["BANK_SHOP_ID"].ToString())
                    {
                        IsReturn = false;
                        ShowMessageBox("ข้อมูลชุดนี้มีอยู่ในระบบแล้วกรุณาตรวจสอบอีกครั้ง !!", this.Page);
                    }
                    else IsReturn = true;
                }
                else IsReturn = true;
            }
            else
            {
                IsReturn = false;
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
            if (CheckInput())
            {
                commonBiz Biz = new commonBiz();
                string IsReturn = "";
                IsReturn = Biz.INS_UPD_DATA_BANK_SHOP(SetData(), this._VS_ACT);
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
            else
            {
                ModalPopupExtender1.Show();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_Deatil.DataKeys[rowIndex].Values[0].ToString();

            this._VS_ID = Convert.ToInt32(DataKeys_ID);
            this._VS_ACT = "UPD";

            DataSet ds = new DataSet();
            commonBiz Biz = new commonBiz();
            ds = Biz.GET_DATA_BANK_SHOP(this._VS_ID, "BINDDATA_BYID");

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_bank_name.SelectedValue = ds.Tables[0].Rows[0]["BANK_ID"].ToString();
                txt_acc_name.Text = ds.Tables[0].Rows[0]["BANK_SHOP_ACCOUNT_NAME"].ToString();
                txt_acc_no.Text = ds.Tables[0].Rows[0]["BANK_SHOP_ACCOUNT_NO"].ToString();
                txt_remark.Text = ds.Tables[0].Rows[0]["BANK_SHOP_REMARK"].ToString();
                ddl_Status.SelectedValue = ds.Tables[0].Rows[0]["BANK_SHOP_STATUS"].ToString();
            }

            ModalPopupExtender1.Show();
        }

        protected void btnImgDelete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_Deatil.DataKeys[rowIndex].Values[0].ToString();
            this._VS_ID = Convert.ToInt32(DataKeys_ID);
            this._VS_ACT = "DEL";

            commonBiz Biz = new commonBiz();
            string IsReturn = "";
            IsReturn = Biz.INS_UPD_DATA_BANK_SHOP(SetData(), this._VS_ACT);
            if (IsReturn != "")
            {
                ShowMessageBox(IsReturn, this.Page);
            }
            else
            {
                BindData();
                ShowMessageBox("ลบข้อมูลเรียบร้อยแล้ว", this.Page);
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