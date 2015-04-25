﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
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
            OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
            if (OID != "")
            {
                BindData();
            }
        }

        protected void btnPayment_ServerClick(object sender, EventArgs e)
        {
            string withdrawDB = "", withdrawDBEn = "", pwd = "";
            Int32 Status = 0;
            CustomerBiz biz = new CustomerBiz();
            withdrawDB = GetCusSession().Cus_Withdraw_Code;
            withdrawDBEn = DecryptData(withdrawDB);
            pwd = txtPass.Text;
            if (withdrawDBEn == pwd)
            {
                double Bal = lbBalance.Text == "" ? 0 : Convert.ToDouble(lbBalance.Text);
                double Tol = lbTotalAmount.Text == "" ? 0 : Convert.ToDouble(lbTotalAmount.Text);
                if (Bal > Tol)
                {
                    if (ViewState["ORDER_STATUS"] != null)
                        Status = Convert.ToInt32(ViewState["ORDER_STATUS"].ToString());

                    Status = Status == 8 ? Status : Status + 1;

                    TransactionData data = GetDataTran();
                    string Result = biz.INS_UPD_TRANSACTION(data, "INS", Status);

                    Redirect("~/Customer/CustomerOrderDetail.aspx?OID=" + EncrypData(OID));
                }
                else
                    ShowMessageBox("เงินในบัญชีไม่พอ กรุณาเติมเงินก่อนค่ะ");
            }
            else
            {
                ShowMessageBox("รหัสผ่านการชำระเงินไม่ถูกต้อง");
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
                foreach (DataRow dr in dtDetail.Rows)
                {
                    Amount = dr["OD_AMOUNT_ACTIVE"].ToString() == "" ? 0 : Convert.ToDouble(dr["OD_AMOUNT_ACTIVE"].ToString());
                    Price = dr["OD_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["OD_PRICE"].ToString());
                    Total = Total + (Amount * Price);
                }
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
                //switch (Type)
                //{
                //    case "ORDER":
                //        Redirect("~/Customer/CustomerOrderDetail.aspx?OID=" + OID);
                //        break;
                //    case "PI":
                //        Redirect("~/Customer/CustomerUplodaPIList.aspx");
                //        break;
                //    case "TRANS":
                //        Redirect("~/Customer/CustomerTransOnlyList.aspx");
                //        break;
                //}
            }
                
        }
    }
}