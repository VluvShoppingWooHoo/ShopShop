using System;
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
    public partial class CustomerTransOnly : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
            if (!IsPostBack)
            {
                string OID = Request.QueryString["OID"] == null ? "" : DecryptData(Request.QueryString["OID"].ToString());
                if (OID != "")
                    BindData(OID);
                else
                {
                    divTran.Visible = false;
                    btn3.Visible = false;
                    gvTrans.DataSource = null;
                    gvTrans.DataBind();
                }
            }
        }

        protected void BindData(string OID)
        {
            DataTable dt = new DataTable();
            ShoppingBiz biz = new ShoppingBiz();
            Int32 Order_ID = OID == "" ? 0 : Convert.ToInt32(OID);
            string Stauts = "", strPay = "";
            double Pay = 0; ;
            dt = biz.GetOrderDetail(Order_ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                lbOrderCode.Text = dt.Rows[0]["ORDER_CODE"].ToString();
                gvTrans.DataSource = dt;
                gvTrans.DataBind();

                Trans1.Visible = false;
                Trans2.Visible = false;
                Trans3.Visible = false;
                btn1.Visible = false;
                
                Code.Visible = true;
                gvTrans.Columns[4].Visible = false;

                Stauts = dt.Rows[0]["ORDER_STATUS"].ToString();
                strPay = dt.Rows[0]["ORDER_PAY"].ToString();
                if (Stauts != "")
                {
                    //0 = ยกเลิก, 1 = รออนุมัติรายการ, 2 = รอสินค้ามาถึงโกดังจีน
                    if (Stauts == "0" || Stauts == "1" || Stauts == "2")
                    {
                        btn2.Visible = false;
                        btn3.Visible = false;
                    }

                    //4 = ชำระเงินแล้ว, 6 = ชำระเงินแล้ว(เพิ่ม)
                    if (Stauts == "4" || Stauts == "6")
                    {
                        btn2.Visible = false;
                        btn3.Visible = false;
                    }

                    Pay = strPay == "" ? 0 : Convert.ToDouble(strPay);
                    if ((Stauts == "8" || Stauts == "9" || Stauts == "10") && Pay <= 0)
                    {
                        btn2.Visible = false;
                        btn3.Visible = false;
                    }

                    //Bind Payment
                    double Item = 0, Cus = 0, Chi = 0, Thi = 0, Pay_Add = 0, Currency = 0, SV_Charge = 0, Dis_SV_Charge = 0, Dis_Cus = 0, VIP_Dis_Rate = 0;
                    double TotalItem = 0, TotalTrans = 0, TotalTransThai = 0, VIP_Dis_Amount = 0, TotalCus = 0;
                    string ShopName = "", OldShopName = "";
                    foreach (DataRow dr in dt.Rows)
                    {
                        ShopName = dr["SHOPNAME"].ToString();
                        if (ShopName != OldShopName)
                        {
                            Chi = dr["TRANSPORT_CHINA_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["TRANSPORT_CHINA_PRICE"].ToString());
                            Thi = dr["TRANSPORT_THAI_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["TRANSPORT_THAI_PRICE"].ToString());

                            TotalTrans = TotalTrans + (Chi * Currency);
                            TotalTransThai = TotalTransThai + Thi;
                        }

                        Item = dr["TOTALITEMAMOUNT_TH"].ToString() == "" ? 0 : Convert.ToDouble(dr["TOTALITEMAMOUNT_TH"].ToString());
                        TotalItem = TotalItem + Item;
                        OldShopName = ShopName;
                    }
                    Cus = dt.Rows[0]["TRANSPORT_CUSTOMER_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["TRANSPORT_CUSTOMER_PRICE"].ToString());
                    Dis_Cus = dt.Rows[0]["TRANSPORT_CUSTOMER_PRICE_DIS"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["TRANSPORT_CUSTOMER_PRICE_DIS"].ToString());

                    SV_Charge = dt.Rows[0]["SERVICE_CHARGE"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["SERVICE_CHARGE"].ToString());
                    Dis_SV_Charge = dt.Rows[0]["SERVICE_CHARGE_DISCOUNT"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["SERVICE_CHARGE_DISCOUNT"].ToString());

                    VIP_Dis_Rate = dt.Rows[0]["VIP_DISCOUNT"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["VIP_DISCOUNT"].ToString());
                    if (VIP_Dis_Rate != 0)
                    {
                        VIP_Dis_Amount = TotalTransThai * VIP_Dis_Rate / 100;
                    }
                    TotalCus = Cus + SV_Charge;

                    lbChina.Text = TotalTrans.ToString("###,##0.00");
                    lbThai.Text = TotalTransThai.ToString("###,##0.00");
                    lbCustomer.Text = TotalCus.ToString("###,##0.00");
                    lbDiscount.Text = (Dis_Cus + Dis_SV_Charge + VIP_Dis_Amount).ToString("###,##0.00");
                }
            }

        }        

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerTransOnlyList.aspx");
        }

        protected void btnTrans_Click(object sender, EventArgs e)
        {
            Session.Remove("TRANS");
            Session.Remove("ORDER");
            List<OrderData> lstData = new List<OrderData>();
            if (ViewState["TRACK"] != null)
            {
                int CusID = GetCusID();
                OrderData data;
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["TRACK"];
                foreach (DataRow dr in dt.Rows)
                {
                    data = new OrderData();
                    data.CUS_ID = CusID;
                    data.TRACKING_NO = dr["TRACKING_NO"].ToString();
                    data.SHOP_ORDER_ID = dr["SHOP_ORDER_ID"].ToString();
                    data.OD_PRICE = 1;
                    data.OD_AMOUNT = 1;
                    data.OD_REMARK = dr["OD_REMARK"].ToString();

                    lstData.Add(data);
                }

                if (lstData.Count == 0)
                {
                    ShowMessageBox("กรุณาบันทึกอย่างน้อย 1 รายการ");
                    return;
                }
            }
            else
            {
                ShowMessageBox("กรุณาบันทึกอย่างน้อย 1 รายการ");
                return;
            }

            Session["ORDER"] = lstData;
            Response.Redirect("CustomerTransport.aspx?Type=" + EncrypData("TRANS"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            if (ViewState["TRACK"] != null)
            {                
                dt = (DataTable)ViewState["TRACK"];
                dr = dt.NewRow();
                dt.Rows.Add(AddRow(dr));                
                gvTrans.DataSource = dt;
                gvTrans.DataBind();
            }
            else
            {
                dt.Columns.Add("TRACKING_NO");
                dt.Columns.Add("SHOP_ORDER_ID");
                dt.Columns.Add("OD_REMARK");
                dr = dt.NewRow();
                dt.Rows.Add(AddRow(dr));
            }
            ViewState["TRACK"] = dt;
            gvTrans.DataSource = dt;
            gvTrans.DataBind();

            Reset();
        }

        protected DataRow AddRow(DataRow dr)
        {
            dr["TRACKING_NO"] = txtTrackingNo.Text;
            dr["SHOP_ORDER_ID"] = txtShopID.Text;
            dr["OD_REMARK"] = txtRemark.Text;
            return dr;
        }

        protected void Reset()
        {
            txtTrackingNo.Text = "";
            txtShopID.Text = "";
            txtRemark.Text = "";
        }

        protected void BindGrid()
        {
            if (ViewState["TRACK"] != null)
            {
                gvTrans.DataSource = (DataTable)ViewState["TRACK"];
                gvTrans.DataBind();
            }
        }

        protected void imbDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imb = (ImageButton)sender;
            if (imb != null && ViewState["TRACK"] != null)
            {
                int row = imb.CommandArgument == "" ? -1 : Convert.ToInt32(imb.CommandArgument);
                DataTable dt = (DataTable)ViewState["TRACK"];
                dt.Rows.RemoveAt(row);
                ViewState["TRACK"] = dt;
                BindGrid();
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            string OID = Request.QueryString["OID"] == null ? "" : DecryptData(Request.QueryString["OID"].ToString());
            OID = EncrypData(OID);
            Response.Redirect("CustomerPayment.aspx?OID=" + OID);
        }
    }
}