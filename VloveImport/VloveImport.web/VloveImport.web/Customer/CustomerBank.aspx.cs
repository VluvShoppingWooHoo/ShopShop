﻿using System;
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
                CustomerData CusData = new CustomerData();
                CusData = (CustomerData)Session["User"];
                this._VS_CUS_ID = 1;//CusData.Cus_ID;
                BindData();
                BindData_MS_BANK();
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
            CustomerBiz CusBiz = new CustomerBiz();
            ds = CusBiz.GET_CUSTOMER_ACCOUNT_BANK(this._VS_CUS_ID, -1, 1, "BINDDATA");

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
            txt_acc_branch.Text = "";
            txt_acc_name.Text = "";
            txt_acc_no.Text = "";
            txt_remark.Text = "";
            ddl_bank_name.SelectedIndex = 0;
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
                EnCus.CUS_ACC_NAME_STAUTS = 1;
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

            CustomerBiz CusBiz = new CustomerBiz();
            DataSet ds = new DataSet();
            ds = CusBiz.GET_CUSTOMER_ACCOUNT_BANK(this._VS_CUS_ID, -1, 1, "CHECK_DATA", txt_acc_name.Text.Trim(),
                                                    txt_acc_no.Text.Trim(),
                                                    txt_acc_branch.Text.Trim(),
                                                    Convert.ToInt32(ddl_bank_name.SelectedValue)
                                                );
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
                    if (this._VS_ID.ToString() != ds.Tables[0].Rows[0]["TB_ID"].ToString())
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
            lblheader.Text = "เพิ่มข้อมูลธนาคาร";
            ModalPopupExtender1.Show();
        }

        protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            this._VS_ID = Convert.ToInt32(DataKeys_ID);
            this._VS_ACT = "UPD";

            DataSet ds = new DataSet();
            CustomerBiz CusBiz = new CustomerBiz();
            ds = CusBiz.GET_CUSTOMER_ACCOUNT_BANK(this._VS_CUS_ID, this._VS_ID, 1, "BINDDATA_BYID");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_acc_branch.Text = ds.Tables[0].Rows[0]["CUS_ACC_NAME_BRANCH"].ToString();
                txt_acc_name.Text = ds.Tables[0].Rows[0]["CUS_ACC_NAME"].ToString();
                txt_acc_no.Text = ds.Tables[0].Rows[0]["CUS_ACC_NAME_NO"].ToString();
                txt_remark.Text = ds.Tables[0].Rows[0]["CUS_ACC_NAME_REMARK"].ToString();
                ddl_bank_name.SelectedValue = ds.Tables[0].Rows[0]["BANK_ID"].ToString();
            }

            lblheader.Text = "แก้ไขข้อมูลธนาคาร";
            ModalPopupExtender1.Show();
        }

        protected void btnImgDelete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();
            this._VS_ID = Convert.ToInt32(DataKeys_ID);
            this._VS_ACT = "DEL";

            CustomerBiz CusBiz = new CustomerBiz();
            string IsReturn = "";
            IsReturn = CusBiz.INS_UPD_CUSTOMER_ACCOUNT_BANK(SetData(), this._VS_ACT);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                CustomerBiz CusBiz = new CustomerBiz();
                string IsReturn = "";
                IsReturn = CusBiz.INS_UPD_CUSTOMER_ACCOUNT_BANK(SetData(), this._VS_ACT);
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