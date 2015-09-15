using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerPayment : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        public string OID;
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
            if (!IsPostBack)
            {
                OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
                if (OID != "")
                {
                    BindData();
                }
            }
        }

        protected void btnPayment_ServerClick(object sender, EventArgs e)
        {
            OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
            string withdrawDB = "", withdrawDBEn = "", pwd = "";
            Int32 Status = 0;
            CustomerBiz biz = new CustomerBiz();
            ShoppingBiz bizShop = new ShoppingBiz();
            withdrawDB = GetCusSession().Cus_Withdraw_Code;
            if (withdrawDB != "")
            {
                withdrawDBEn = DecryptData(withdrawDB);
                pwd = txtPass.Text;
                if (withdrawDBEn == pwd)
                {
                    int ORDER_ID = OID == "" ? 0 : Convert.ToInt32(OID);
                    int TP_ID = 0;
                    string ValueField = "";
                    string Cash = "";
                    double VoucherValue = 0;
                    string[] Value;
                    Value = ValueField.Split('|');
                    if (ddlVoucher.SelectedItem != null && ddlVoucher.SelectedItem.Text != "-----เลือก-----")
                    {
                        ValueField = ddlVoucher.SelectedValue;
                        Value = ValueField.Split('|');
                        Cash = Value[1].ToString();
                        VoucherValue = Cash == "" ? 0 : Convert.ToDouble(Cash);
                    }

                    double Bal = lbBalance.Text == "" ? 0 : Convert.ToDouble(lbBalance.Text);
                    double Tol = lbTotalAmount.Text == "" ? 0 : Convert.ToDouble(lbTotalAmount.Text);
                    if (Bal >= Tol)
                    {
                        if (ViewState["ORDER_STATUS"] != null)
                            Status = Convert.ToInt32(ViewState["ORDER_STATUS"].ToString());

                        Status = Status == 8 ? Status : Status + 1;

                        TransactionData data = GetDataTran();
                        string Result = biz.INS_UPD_TRANSACTION(data, "INS", Status);
                        if (VoucherValue > 0)
                        {
                            string TextField = ddlVoucher.SelectedItem.Text;
                            string Voucher = TextField.Split(':')[0].Trim();
                            TP_ID = Value[0] == "" ? 0 : Convert.ToInt32(Value[0]);
                            Result = bizShop.USE_VOUCHER(TP_ID, ORDER_ID, VoucherValue, GetCusID(), Voucher);
                        }

                        string EmailTo = WebConfigurationManager.AppSettings["email"].ToString();
                        string Subject = "Payment : " + hlOrderCode.Text;
                        string Body = "มีการชำระเงินจาก " + hlOrderCode.Text + " <br/><br/>เมื่อวันที่ " + DateTime.Now.ToString("dd/MM/yyyy hh:mm");
                        SendMail(EmailTo, Subject, Body);

                        Redirect("~/Customer/CustomerOrderDetail.aspx?OID=" + EncrypData(OID));
                    }
                    else
                    {
                        ShowMessageBox("เงินในบัญชีไม่พอ กรุณาเติมเงินก่อนค่ะ");
                        return;
                    }
                }
                else
                {
                    ShowMessageBox("รหัสผ่านการชำระเงินไม่ถูกต้อง");
                    return;
                }
            }
            else
            {
                ShowMessageBox("ยังไม่ทำการตั้งรหัสผ่านการชำระเงิน กรุณาตั้งรหัสผ่านการชำระเงินก่อน");
                return;
            }
        } 

        protected void BindData()
        {
            Int32 Order_ID = OID == "" ? 0 : Convert.ToInt32(OID);            
            CustomerBiz biz = new CustomerBiz();
            ShoppingBiz bizShop = new ShoppingBiz();
            double Total = 0, Rate = 0, Amount = 0, Price = 0;
            Rate = GetRateCurrency();
            
            //Description
            DataTable dtDetail = bizShop.GetOrderDetail(Order_ID);
            if (dtDetail != null && dtDetail.Rows.Count > 0)
            {
                ViewState["ORDER_STATUS"] = dtDetail.Rows[0]["ORDER_STATUS"].ToString();
                //foreach (DataRow dr in dtDetail.Rows)
                //{
                //    Amount = dr["OD_AMOUNT_ACTIVE"].ToString() == "" ? 0 : Convert.ToDouble(dr["OD_AMOUNT_ACTIVE"].ToString());
                //    Price = dr["OD_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["OD_PRICE"].ToString());
                //    Total = Total + (Amount * Price);
                //}
                Total = dtDetail.Rows[0]["ORDER_PAY"].ToString() == "" ? 0 : Convert.ToDouble(dtDetail.Rows[0]["ORDER_PAY"].ToString());

                hlOrderCode.Text = dtDetail.Rows[0]["ORDER_CODE"].ToString().Trim();
                hlOrderCode.NavigateUrl = "~/Customer/CustomerOrderDetail.aspx?OID=" + EncrypData(OID);
                lbTotalAmount.Text = Total.ToString("###,##0.00");
                lbBalance.Text = GetBalance().ToString("###,##0.00");
            }

            //Grid
            DataTable dt = biz.GET_TRANSACTION_BY_ORDERID(Order_ID);
            if (dt != null && dt.Rows.Count > 0)
                gvTran.DataSource = dt;
            else
                gvTran.DataSource = null;

            gvTran.DataBind();

            //Voucher
            DataTable dtVoucher = new DataTable();
            string VCCode = "";
            dtVoucher = bizShop.CheckVoucherUse(Order_ID);
            if (dtVoucher != null && dtVoucher.Rows.Count > 0)
            {
                VCCode = dtVoucher.Rows[0]["VOUCHER_CODE"].ToString();
                ddlVoucher.Enabled = false;
                lbVoucher.Text = "ออร์เดอร์นี้มีการใช้ Voucher(" + VCCode + ") แล้ว";                
            }
            else
            {
                dtVoucher = new DataTable();
                dtVoucher = bizShop.GetVoucherByCusID(GetCusID());
                if (dtVoucher != null && dtVoucher.Rows.Count > 0)
                {
                    ddlVoucher.DataSource = null;
                    ddlVoucher.DataSource = dtVoucher;
                    ddlVoucher.DataTextField = "TextFiled";
                    ddlVoucher.DataValueField = "ValueField";
                    ddlVoucher.DataBind();
                }
                ddlVoucher.Items.Insert(0, "-----เลือก-----");
                lbVoucher.Text = "Voucher ไม่สามารถแลกเป็นเงินสดได้นะคะ";
            }
        }

        protected TransactionData GetDataTran()
        {
            TransactionData data = new TransactionData();
            data.TRAN_TYPE = 2; //เงินออก
            data.TRAN_TABLE_TYPE = 3; //Order
            data.TRAN_STATUS = 2; //
            data.TRAN_DETAIL = "ชำระเงินครั้งแรก";
            data.TRAN_AMOUNT = Convert.ToDouble(lbTotalAmount.Text);
            data.Cus_ID = GetCusID();
            data.ORDER_ID = OID == "" ? 0 : Convert.ToInt32(OID);

            return data;
        }

        protected void btnTopup_ServerClick(object sender, EventArgs e)
        {
            OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
            string Page = "~/Customer/CustomerMyAccount.aspx?OID=" + EncrypData(OID);
            Redirect("~/Customer/CustomerMyAccount.aspx?u=" + EncrypData(Page));
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            string Page = Request.QueryString["P"] == null ? "" : DecryptData(Request.QueryString["P"].ToString());
            string Type = Request.QueryString["T"] == null ? "" : DecryptData(Request.QueryString["T"].ToString());
            string OID = Request.QueryString["OID"] == null ? "" : Request.QueryString["OID"].ToString();

            if (Page == "LIST")
            {
                switch (Type)
                {
                    case "ORDER":
                        Redirect("~/Customer/CustomerOrderList.aspx");
                        break;
                    case "PI":
                        Redirect("~/Customer/CustomerUplodaPIList.aspx");
                        break;
                    case "TRANS":
                        Redirect("~/Customer/CustomerTransOnlyList.aspx");
                        break;
                }

            }
            else
            {
                Redirect("~/Customer/CustomerOrderDetail.aspx?OID=" + OID);        
            }
                
        }

        protected void ddlVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVoucher.SelectedItem.Text != "-----เลือก-----")
            {
                string ValueField = "";
                string Cash = "";
                double VoucherValue = 0;
                double TotalAmount = 0;

                ValueField = ddlVoucher.SelectedValue;
                Cash = (ValueField.Split('|'))[1].ToString();
                VoucherValue = Cash == "" ? 0 : Convert.ToDouble(Cash);
                TotalAmount = Convert.ToDouble(lbTotalAmount.Text.Replace(",", ""));
                TotalAmount = TotalAmount - VoucherValue;
                if (TotalAmount < 0)
                {
                    lbTotalAmount.Text = "0.00";
                    ShowMessageBox("Voucher มีมูลค่ามากกว่าจำนวนงินที่ต้องจ่าย!!!");
                }
                else
                {
                    lbTotalAmount.Text = TotalAmount.ToString("###,##0.00");
                }
            }
            else
            {
                RefreshPage();
            }
        }
    }
}