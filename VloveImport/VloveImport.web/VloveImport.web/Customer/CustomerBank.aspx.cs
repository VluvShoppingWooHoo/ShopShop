using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.Customer
{
    public partial class CustomerBank : System.Web.UI.Page
    {
        public int _VS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_ID"]); }
            set { ViewState["__VS_ID"] = value; }
        }

        public int _VS_CUS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_CUS_ID"]); }
            set { ViewState["__VS_CUS_ID"] = value; }
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
                //CustomerData CusData = new CustomerData();
                //CusData = (CustomerData)Session["User"];
                //this._VS_CUS_ID = 1;//CusData.Cus_ID;
                //BinddataRegion("");
                //BindData();
            }
        }

        public void BindData()
        {
            DataSet ds = new DataSet();
            CustomerBiz CusBiz = new CustomerBiz();
            ds = CusBiz.GetData_Customer_Address(this._VS_CUS_ID, -1, 1, "BINDDATA");

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

        public void ShowMessageBox(string message, Page currentPage)
        {
            string msgboxScript = "alert('" + message + "');";

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
            }
        }

        public void ClearData()
        {
            //txt_Cusname.Text = "";
            //txt_CusDetail.Text = "";
            //txt_ZipCode.Text = "";
            //dll_region.SelectedIndex = 0;
            //dll_province.SelectedIndex = 0;
            //dll_District.SelectedIndex = 0;
            //dll_Sub_District.SelectedIndex = 0;
        }

        public CustomerData SetData()
        {
            CustomerData EnCus = new CustomerData();
            EnCus.CUS_ACC_NAME_ID = this._VS_ID;
            if (this._VS_ACT != "DEL")
            {
                EnCus.Cus_ID = this._VS_CUS_ID;

                EnCus.BANK_ID = Convert.ToInt32(ddl_bank_name.SelectedValue);
                EnCus.CUS_ACC_NAME = txt_acc_name.Text.Trim();
                EnCus.CUS_ACC_NAME_NO = txt_acc_no.Text.Trim();
                EnCus.CUS_ACC_NAME_BRANCH = txt_acc_branch.Text.Trim();
                EnCus.CUS_ACC_NAME_REMARK = txt_remark.Text.Trim();
                
                EnCus.Create_User = "Batt";
            }
            return EnCus;
        }

        public bool CheckInput()
        {
            bool IsReturn = true;

            if (ddl_bank_name.SelectedValue == "-1" || txt_acc_name.Text.Trim() == "" || txt_acc_no.Text.Trim() == "" || txt_acc_branch.Text.Trim() == "")
            {
                IsReturn = false;
                ShowMessageBox("กรุณากรอกข้อมูลในช่องที่มีสัญลักษณ์ *", this.Page);
                return IsReturn;
            }

            //CustomerBiz CusBiz = new CustomerBiz();
            //DataSet ds = new DataSet();
            //ds = CusBiz.GetData_Customer_Address(this._VS_CUS_ID, -1, 1, "CHECK_DATA", txt_Cusname.Text,
            //                                        Convert.ToInt32(dll_region.SelectedValue),
            //                                        Convert.ToInt32(dll_province.SelectedValue),
            //                                        Convert.ToInt32(txt_ZipCode.Text)
            //                                    );
            //if (this._VS_ACT == "INS")
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        IsReturn = false;
            //        ShowMessageBox("ข้อมูลชุดนี้มีอยู่ในระบบแล้วกรุณาตรวจสอบอีกครั้ง !!", this.Page);
            //    }
            //    else IsReturn = true;
            //}
            //else if (this._VS_ACT == "UPD")
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        if (this._VS_ID.ToString() != ds.Tables[0].Rows[0]["CUS_ADD_ID"].ToString())
            //        {
            //            IsReturn = false;
            //            ShowMessageBox("ข้อมูลชุดนี้มีอยู่ในระบบแล้วกรุณาตรวจสอบอีกครั้ง !!", this.Page);
            //        }
            //        else IsReturn = true;
            //    }
            //    else IsReturn = true;
            //}
            //else
            //{
            //    IsReturn = false;
            //}

            return IsReturn;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //if (dll_region.Items.Count == 1)
            //    BinddataRegion("REGION");

            //ClearData();
            //_VS_ACT = "INS";

            //lblheader.Text = "เพิ่มข้อมูที่อยู่";

            ModalPopupExtender1.Show();
        }

        protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
        {
            //int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            //string DataKeys_ID = this.gv_cus_address.DataKeys[rowIndex].Values[0].ToString();

            //this._VS_ID = Convert.ToInt32(DataKeys_ID);
            //this._VS_ACT = "UPD";

            //DataSet ds = new DataSet();
            //CustomerBiz CusBiz = new CustomerBiz();
            //ds = CusBiz.GetData_Customer_Address(this._VS_CUS_ID, this._VS_ID, 1, "BINDDATA_BYID");

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    txt_Cusname.Text = ds.Tables[0].Rows[0]["CUS_ADD_CUS_NAME"].ToString();
            //    txt_CusDetail.Text = ds.Tables[0].Rows[0]["CUS_ADD_ADDRESS_TEXT"].ToString();
            //    txt_ZipCode.Text = ds.Tables[0].Rows[0]["CUS_ADD_ZIPCODE"].ToString();
            //    BinddataRegion("REGION");
            //    dll_region.SelectedValue = ds.Tables[0].Rows[0]["REGION_ID"].ToString();
            //    BinddataRegion("PROVINCE");
            //    dll_province.SelectedValue = ds.Tables[0].Rows[0]["PROVINCE_ID"].ToString();
            //    BinddataRegion("DISTRICT");
            //    dll_District.SelectedValue = ds.Tables[0].Rows[0]["DISTRICT_ID"].ToString();
            //    BinddataRegion("SUB_DISTRICT");
            //    dll_Sub_District.SelectedValue = ds.Tables[0].Rows[0]["SUB_DISTRICT_ID"].ToString();
            //}

            //lblheader.Text = "แก้ไขข้อมูที่อยู่";
            //ModalPopupExtender1.Show();
        }

        protected void btnImgDelete_Click(object sender, ImageClickEventArgs e)
        {
            //int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            //string DataKeys_ID = this.gv_cus_address.DataKeys[rowIndex].Values[0].ToString();
            //this._VS_ID = Convert.ToInt32(DataKeys_ID);
            //this._VS_ACT = "DEL";

            //CustomerBiz CusBiz = new CustomerBiz();
            //string IsReturn = "";
            //IsReturn = CusBiz.INS_UPD_Customer_Address(SetData(), this._VS_ACT);
            //if (IsReturn != "")
            //{
            //    ShowMessageBox(IsReturn, this.Page);
            //}
            //else
            //{
            //    BindData();
            //    ShowMessageBox("บันทึกรายการเรียบร้อยแล้ว", this.Page);
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //if (CheckInput())
            //{
            //    CustomerBiz CusBiz = new CustomerBiz();
            //    string IsReturn = "";
            //    IsReturn = CusBiz.INS_UPD_Customer_Address(SetData(), this._VS_ACT);
            //    if (IsReturn != "")
            //    {
            //        ShowMessageBox(IsReturn, this.Page);
            //    }
            //    else
            //    {
            //        BindData();
            //        ShowMessageBox("บันทึกรายการเรียบร้อยแล้ว", this.Page);
            //    }
            //}
            //else
            //{
            //    ModalPopupExtender1.Show();
            //}
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            ModalPopupExtender1.Show();
        }

        protected void BtnImgClose_Click(object sender, ImageClickEventArgs e)
        {
            ClearData();
        }

        protected void gv_detail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("btnImgDelete")).Attributes.Add("onClick", "javascript:return confirm('คุณต้องการลบข้อมูลนี้หรือไม่ ?')");
            }
        }
    }
}