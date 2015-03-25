using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using VloveImport.biz;
using VloveImport.data;
using System.Globalization;
using VloveImport.web.App_Code;

namespace VloveImport.web.UserControls
{
    public partial class ucAccfuncWithdraw : System.Web.UI.UserControl
    {
        BasePage bp = new BasePage();
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
                BasePage bp = new BasePage();
                this._VS_CUS_ID = bp.GetCusID();
                BindData_BANK();
                GetMymoney();
                
            }
        }

        public void GetMymoney()
        {
            CustomerBiz biz = new CustomerBiz();
            double Mymoney = biz.GET_CUSTOMER_BALANCE(this._VS_CUS_ID);
            lbMymoney.Text = Mymoney.ToString("###,###.00");
        }

        public void BindData_BANK()
        {
            DataSet ds = new DataSet();
            CustomerBiz CusBiz = new CustomerBiz();
            ds = CusBiz.GET_CUSTOMER_ACCOUNT_BANK(this._VS_CUS_ID, -1, 1, "BINDDATA_DROPDOWN");

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow Data_Row;
                Data_Row = ds.Tables[0].NewRow();

                Data_Row["CUS_ACC_NAME_ID"] = -1;
                Data_Row["CUS_ACC_DETAIL"] = "กรุณาเลือก";
                ds.Tables[0].Rows.InsertAt(Data_Row, 0);

                ddl_account_name.DataTextField = "CUS_ACC_DETAIL";
                ddl_account_name.DataValueField = "CUS_ACC_NAME_ID";

                ddl_account_name.DataSource = ds.Tables[0];
                ddl_account_name.DataBind();
            }
        }

        public void ClearData()
        {
            ddl_account_name.SelectedIndex = 0;
            txt_amount.Text = "";
            txt_remark.Text = "";
            txt_Withraw_Password.Text = "";
        }

        public TransactionData SetData()
        {
            TransactionData EnCus = new TransactionData();
            EnCus.TRAN_ID = this._VS_ID;
            EnCus.Cus_ID = this._VS_CUS_ID;

            EnCus.TRAN_TYPE = 2;
            EnCus.TRAN_TABLE_TYPE = 2;
            EnCus.TRAN_DETAIL = "รายการถอนเงิน";
            EnCus.TRAN_AMOUNT = Convert.ToDouble(txt_amount.Text);
            EnCus.TRAN_REMARK = txt_remark.Text.Trim();
            EnCus.Cus_Withdraw_Code = txt_Withraw_Password.Text.Trim();
            EnCus.TRAN_STATUS = 1;
            EnCus.CUS_ACC_NAME_ID = Convert.ToInt32(ddl_account_name.SelectedValue);
            EnCus.Create_User = "Batt";
            return EnCus;
        }

        public bool CheckInput()
        {
            bool IsReturn = true;

            if (ddl_account_name.SelectedValue == "-1" || txt_amount.Text.Trim() == "" || txt_Withraw_Password.Text.Trim() == "")
            {
                IsReturn = false;
                bp.ShowMessageBox("กรุณากรอกข้อมูลในช่องที่มีสัญลักษณ์ *", this.Page);
                return IsReturn;
            }

            return IsReturn;
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (hd_submit.Value == "S")
        //    {
        //        SaveData();
        //    }
        //    else
        //    {
        //        ClearData();
        //        ShowMessageBox("1", this.Page, "CustomerMyAccount.aspx#withdraw");
        //    }

        //}

        public void SaveData()
        {
            if (CheckInput())
            {
                CustomerBiz CusBiz = new CustomerBiz();
                string IsReturn = "";
                IsReturn = CusBiz.INS_UPD_TRANSACTION(SetData(), "INS");
                if (IsReturn != "")
                {
                    bp.ShowMessageBox(IsReturn, this.Page);
                }
                else
                {
                    ClearData();
                    bp.ShowMessageBox("บันทึกรายการเรียบร้อยแล้ว", this.Page, "CustomerMyAccount.aspx#withdraw");
                }
            }
        }
        
    }
}