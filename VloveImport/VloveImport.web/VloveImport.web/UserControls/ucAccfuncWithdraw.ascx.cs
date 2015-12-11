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
using System.Web.Configuration;

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
            bp.CheckSession();
            if (!IsPostBack)
            {                
                BasePage bpa = new BasePage();
                this._VS_CUS_ID = bpa.GetCusID();
                BindData_BANK();
                GetMymoney();
                
            }
        }

        public void GetMymoney()
        {
            CustomerBiz biz = new CustomerBiz();
            double Mymoney = biz.GET_CUSTOMER_BALANCE(this._VS_CUS_ID);
            lbMymoney.Text = Mymoney.ToString("###,##0.00");
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

        protected void btnWithdraw_Click(object sender, EventArgs e)
        {
            //Check Input               
            if (txt_amount.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('กรุณาระบุจำนวนเงิน');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
                return;
            }

            //if (txt_remark.Text == "")
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('กรุณาระบุหมายเหตุ');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
            //    return;
            //}

            //Init & Set
            string Result = "", withdrawDB = "", withdrawDBEn = "", pwd = "";
            withdrawDB = bp.GetCusSession().Cus_Withdraw_Code;
            withdrawDBEn = bp.DecryptData(withdrawDB);
            pwd = txt_Withraw_Password.Text;
            try
            {
                //Process
                if (withdrawDBEn == pwd)
                {
                    TransactionData EnTran = new TransactionData();
                    EnTran.Cus_ID = bp.GetCusID();

                    EnTran.TRAN_TYPE = 2;
                    EnTran.TRAN_TABLE_TYPE = 2;
                    EnTran.TRAN_DETAIL = "รายการถอนเงิน";

                    EnTran.TRAN_AMOUNT = Convert.ToDouble(txt_amount.Text);
                    EnTran.TRAN_REMARK = txt_remark.Text.Trim();
                    EnTran.Cus_Withdraw_Code = pwd.Trim();
                    EnTran.TRAN_STATUS = 1;
                    EnTran.CUS_ACC_NAME_ID = Convert.ToInt32(ddl_account_name.SelectedValue);
                    EnTran.Create_User = bp.GetCusCode();

                    CustomerBiz CusBiz = new CustomerBiz();
                    Result = CusBiz.INS_UPD_TRANSACTION(EnTran, "INS", 0);
                    if (Result == string.Empty)
                    {
                        string EmailTo = WebConfigurationManager.AppSettings["email"].ToString();
                        string Subject = "Withdraw : " + bp.GetCusCode();
                        string Body = "มีการถอนเงินจาก " + bp.GetCusCode() + " เป็นจำนวน " + txt_amount.Text + " บาท <br/> หมายุเหตุ : " + txt_remark.Text;
                        bp.SendMail(EmailTo, Subject, Body);

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('ส่งคำขอถอนเงินสำเร็จ');window.location = '/Customer/CustomerMyAccount.aspx#withdraw';</script>", false);
                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>window.location.href = '/Customer/CustomerMyAccount.aspx'", false);
                        //Response.Redirect("~/Customer/CustomerMyAccount.aspx");
                    }
                }
                else
                {
                    bp.WriteLog("ucWithDraw", "btnWithDraw", Result);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('รหัสผ่านไม่ถูกต้อง');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
                    return;
                }
            }
            catch (Exception ex)
            {
                bp.WriteLog("ucWithDraw", "btnWithDraw", ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

       
        
    }
}