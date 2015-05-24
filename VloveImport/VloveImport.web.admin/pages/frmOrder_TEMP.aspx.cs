using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;


namespace VloveImport.web.admin.pages
{
    public partial class frmOrder_TEMP : System.Web.UI.Page
    {
        util.EncrypUtil Enc = new util.EncrypUtil();

        #region ViewState
        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        public string _VS_ORDER_ID
        {
            get { return Request.QueryString["OID"] == null ? "" : Enc.DecryptData(Request.QueryString["OID"]); }
            set { ViewState["__VS_ORDER_ID"] = value; }
        }

        public string _VS_ORDER_STS
        {
            get { return ViewState["__VS_ORDER_STS"].ToString(); }
            set { ViewState["__VS_ORDER_STS"] = value; }
        }

        public string _VS_ORDER_TRAN_STS
        {
            get { return ViewState["__VS_ORDER_TRAN_STS"].ToString(); }
            set { ViewState["__VS_ORDER_TRAN_STS"] = value; }
        }

        public int _VS_ORDER_SHOP_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_ORDER_SHOP_ID"].ToString()); }
            set { ViewState["__VS_ORDER_SHOP_ID"] = value; }
        }

        public int _VS_ORDER_DETAIL_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_ORDER_DETAIL_ID"].ToString()); }
            set { ViewState["__VS_ORDER_DETAIL_ID"] = value; }
        }

        public string _VS_TRANSPORT_CH_TH_METHOD
        {
            get { return ViewState["__VS_TRANSPORT_CH_TH_METHOD"].ToString(); }
            set { ViewState["__VS_TRANSPORT_CH_TH_METHOD"] = value; }
        }

        public string _VS_CAL_TRANSPORT_SHOP_RATE
        {
            get { return ViewState["__VS_CAL_TRANSPORT_SHOP_RATE"].ToString(); }
            set { ViewState["__VS_CAL_TRANSPORT_SHOP_RATE"] = value; }
        }

        public double _VS_EXCH_RATE
        {
            get { return Convert.ToDouble(ViewState["__VS_EXCH_RATE"]); }
            set { ViewState["__VS_EXCH_RATE"] = value; }
        }

        public string _VS_ORDER_TYPE
        {
            get { return ViewState["__VS_ORDER_TYPE"].ToString(); }
            set { ViewState["__VS_ORDER_TYPE"] = value; }
        }

        public double _VS_CUS_BALANCE
        {
            get { return Convert.ToDouble(ViewState["__VS_CUS_BALANCE"].ToString()); }
            set { ViewState["__VS_CUS_BALANCE"] = value; }
        }

        public int _VS_USER_EMP_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_USER_EMP_ID"].ToString()); }
            set { ViewState["__VS_USER_EMP_ID"] = value; }
        }

        public int _VS_CUS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_CUS_ID"].ToString()); }
            set { ViewState["__VS_CUS_ID"] = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminUserData Data = new AdminUserData();
                Data = (AdminUserData)(Session["AdminUser"]);
                _VS_USER_LOGIN = Data.USERNAME;
                _VS_USER_EMP_ID = Data.EMP_ID;

                if (_VS_ORDER_ID != "")
                    BindData();
                BindData_Product_Type();
                TabORDER.ActiveTabIndex = 0;
            }

            ucEmail1.ucEmail_OpenpopClick += new System.EventHandler(ucEmail_OpenpopClick);
        }

        #region Custom Sub

        public void ShowMessageBox(string message, Page currentPage)
        {
            string msgboxScript = "alert('" + message + "');";

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
            }
        }

        public void BindData()
        {
            DataSet ds = new DataSet();

            AdminBiz AdBiz = new AdminBiz();
            ds = AdBiz.GET_ADMIN_ORDER("BINDDATA_BYID", Convert.ToInt32(_VS_ORDER_ID));

            if (ds.Tables[0].Rows.Count > 0)
            {
                BindData_Tab1(ds.Tables[0]);
                BindData_Update_STS(ds.Tables[0]);

                BindData_Tab2(ds.Tables[3], ds.Tables[4]);
                BindData_Tab3(ds.Tables[2]);
                BindData_Tab4(ds.Tables[5]);
            }
        }

        public void BindData_Product_Type()
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("PROD_TYPE_AIR", "BIND_DDL");

            ddl_TRANS_METHOD_AirPlane.DataValueField = "S_ID";
            ddl_TRANS_METHOD_AirPlane.DataTextField = "S_NAME";
            ddl_TRANS_METHOD_AirPlane.DataSource = ds.Tables[0];
            ddl_TRANS_METHOD_AirPlane.DataBind();
            ddl_TRANS_METHOD_AirPlane.Items.Insert(0, new ListItem("Please Select", "-1"));

            AddBiz = new AdminBiz();
            ds = new DataSet();
            ds = AddBiz.GET_MASTER_STATUS("PROD_TYPE", "BIND_DDL");

            ddl_TRANS_METHOD_OTHER.DataValueField = "S_ID";
            ddl_TRANS_METHOD_OTHER.DataTextField = "S_NAME";
            ddl_TRANS_METHOD_OTHER.DataSource = ds.Tables[0];
            ddl_TRANS_METHOD_OTHER.DataBind();
            ddl_TRANS_METHOD_OTHER.Items.Insert(0, new ListItem("Please Select", "-1"));
        }

        #endregion

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOrderList.aspx");
        }

        #region Tab1

        #region Custom Sub

        public void BindData_Tab1(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                // Label Left
                lbl_tb1_order_code.Text = dt.Rows[0]["ORDER_CODE"].ToString();
                lbl_tb1_Order_Date.Text = dt.Rows[0]["ORDER_DATE_TEXT"].ToString();
                lbl_tb1_Order_status.Text = dt.Rows[0]["ORDER_STATUS_TEXT"].ToString();
                lbl_tb1_Exchange_Rate.Text = dt.Rows[0]["ORDER_CURRENCY"].ToString();
                lbl_tb1_Emp_Name.Text = dt.Rows[0]["EMP_FULL_NAME"].ToString();
                lbl_tb1_Emp_Remark.Text = dt.Rows[0]["EMP_REMARK"].ToString().Replace("|", "<br>");
                lbl_tb1_Customer_Code.Text = dt.Rows[0]["CUS_CODE"].ToString();
                lbl_tb1_Customer_Email.Text = dt.Rows[0]["CUS_EMAIL"].ToString();
                lbl_tb1_Customer_Balance.Text = Convert.ToDouble(dt.Rows[0]["CUS_BALANCE"].ToString()).ToString("N", new CultureInfo("en-US"));
                lbl_tb1_Customer_Address.Text = dt.Rows[0]["CUS_REC_NAME"].ToString() + " " + dt.Rows[0]["CUS_ADDRESS"].ToString();
                lbl_tb1_Customer_Remark.Text = dt.Rows[0]["CUS_REMARK"].ToString().Replace("|", "<br>");
                //Label Right
                lbl_tb1_TranSport_CH_TO_TH.Text = dt.Rows[0]["TRANSPORT_CHINA_TEXT"].ToString();
                lbl_tb1_TranSport_TO_Customer.Text = dt.Rows[0]["TRANSPORT_THAI_TEXT"].ToString();
                lbl_tb1_TranSport_Status.Text = dt.Rows[0]["TRANSPORT_STATUS_TEXT"].ToString();
                lbl_tb1_TranSport_Percent.Text = dt.Rows[0]["ORDER_TRANS_RATE"].ToString();
                lbl_tb1_Emp_Update_Date.Text = dt.Rows[0]["EMP_UPDATE_DATE"].ToString();
                lbl_tb1_Customer_Name.Text = dt.Rows[0]["CUS_FULL_NAME"].ToString();
                lbl_tb1_Customer_Point.Text = dt.Rows[0]["CUS_POINT"].ToString();
                lbl_tb1_Customer_Telephone.Text = dt.Rows[0]["CUS_TELEPHONE"].ToString() + " " + dt.Rows[0]["CUS_MOBILE"].ToString();
                
                _VS_CUS_BALANCE = Convert.ToDouble(dt.Rows[0]["CUS_BALANCE"].ToString());
                _VS_CUS_ID = Convert.ToInt32(dt.Rows[0]["CUS_ID"].ToString());
            }
        }

        #endregion

        #region Event Button

        protected void imgbtn_SendEmail_Click(object sender, ImageClickEventArgs e)
        {
            MadoalPop_Email.Show();
            ucEmail1.SetEmail(lbl_tb1_Customer_Email.Text.Trim());
            ucEmail1.SetEmail_To_Enabled();
        }

        public void ucEmail_OpenpopClick(object sender, System.EventArgs e)
        {
            MadoalPop_Email.Show();
        }

        #endregion

        #endregion

        #region Tab2

        #region Custom Sub

        public void BindData_Tab2(DataTable dtTransaction, DataTable dt)
        {
            if (dtTransaction.Rows.Count > 0)
            {
                gv_detail_transaction.DataSource = dtTransaction;
                gv_detail_transaction.DataBind();
            }
            else
            {
                gv_detail_transaction.DataSource = null;
                gv_detail_transaction.DataBind();
            }

            if (dt.Rows.Count > 0)
            {
                lbl_tb2_Total_Income.Text = Convert.ToDouble(dt.Rows[0]["TOTAL_INCOME"].ToString()).ToString("N", new CultureInfo("en-US"));
                lbl_tb2_Total_Prodcut_Price.Text = (Convert.ToDouble(dt.Rows[0]["TOTAL_PRODUCT_PRICE"].ToString()) * _VS_EXCH_RATE).ToString("N", new CultureInfo("en-US")) + "(THB)<br><span style =\"color:red;\">(" + Convert.ToDouble(dt.Rows[0]["TOTAL_PRODUCT_PRICE"].ToString()).ToString("N", new CultureInfo("en-US")) + ")(CNY)</span>";
                //lbl_tb2_Total_Transport_Price.Text = "********";

                lbl_tb2_Total_Refund.Text = Convert.ToDouble(dt.Rows[0]["TOTAL_REFUND"].ToString()).ToString("N", new CultureInfo("en-US"));
                lbl_tb2_Additional_Amount.Text = Convert.ToDouble(dt.Rows[0]["TOTAL_ADDITIONAL_AMOUNT"].ToString()).ToString("N", new CultureInfo("en-US"));
                lbl_tb2_Total_Prodcut_Active_Price.Text = (Convert.ToDouble(dt.Rows[0]["TOTAL_PRODUCT_PRICE_ACTIVE"].ToString()) * _VS_EXCH_RATE).ToString("N", new CultureInfo("en-US")) + "(THB)<br><span style =\"color:red;\">(" + Convert.ToDouble(dt.Rows[0]["TOTAL_PRODUCT_PRICE_ACTIVE"].ToString()).ToString("N", new CultureInfo("en-US")) + ")(CNY)</span>";

                lbl_tb2_Total_Transport_Active_Price.Text = Convert.ToDouble(dt.Rows[0]["TOTAL_TRANSPORT_PRICE"].ToString()).ToString("N", new CultureInfo("en-US"));
                lbl_tb2_Service_Charge.Text = Convert.ToDouble(dt.Rows[0]["SERVICE_CHARGE"].ToString()).ToString("N", new CultureInfo("en-US"));
                lbl_tb2_Actually_Amounte.Text = Convert.ToDouble(dt.Rows[0]["ACTUALLY_AMOUNT"].ToString()).ToString("N", new CultureInfo("en-US"));
            }
        }

        public void BindData_order_status(DropDownList ddl, string ddlType = "", string STS_NAME = "", string Act = "")
        {
            if (Act == "") Act = "BIND_DDL";

            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("ORDER_STS", Act, STS_NAME);

            ddl.DataValueField = "S_ID";
            ddl.DataTextField = "S_NAME";
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            if (ddlType == "S") ddl.Items.Insert(0, new ListItem("แสดงทั้งหมด", "-1"));
            else if (ddlType == "A") ddl.Items.Insert(0, new ListItem("กรุณาเลือก", "-1"));
        }

        public void BindData_transport_status(DropDownList ddl, string ddlType = "", string STS_NAME = "", string Act = "")
        {
            if (Act == "") Act = "BIND_DDL";

            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("TRANSPORT", Act, STS_NAME);

            ddl.DataValueField = "S_ID";
            ddl.DataTextField = "S_NAME";
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            if (ddlType == "S") ddl.Items.Insert(0, new ListItem("แสดงทั้งหมด", "-1"));
            else if (ddlType == "A") ddl.Items.Insert(0, new ListItem("กรุณาเลือก", "-1"));
        }

        public void BindData_Update_STS(DataTable dt)
        {
            //Bind ViewState
            _VS_ORDER_STS = dt.Rows[0]["ORDER_STATUS"].ToString();
            _VS_ORDER_TRAN_STS = dt.Rows[0]["TRANSPORT_STATUS"].ToString();
            _VS_TRANSPORT_CH_TH_METHOD = dt.Rows[0]["TRANSPORT_CH_TH_METHOD"].ToString();
            _VS_EXCH_RATE = Convert.ToDouble(dt.Rows[0]["ORDER_CURRENCY"].ToString());
            _VS_ORDER_TYPE = dt.Rows[0]["ORDER_TYPE"].ToString();

            lbl_header_detail.Text = dt.Rows[0]["ORDER_TYPE_TEXT"].ToString();

            //Update Order Status, Transport Status
            BindData_order_status(ddl_ViewDetail_ORDER_STATUS, STS_NAME: _VS_ORDER_STS, Act: "BIND_DDL_STS_ID");
            ddl_ViewDetail_ORDER_STATUS.SelectedValue = _VS_ORDER_STS;

            BindData_transport_status(ddl_ViewDetail_TRANSPORT_STATUS, STS_NAME: _VS_ORDER_TRAN_STS, Act: "BIND_DDL_STS_ID");
            ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue = _VS_ORDER_TRAN_STS;

            //Set MultiView1 Popup ShopDetail ************************************
            if (_VS_TRANSPORT_CH_TH_METHOD == "2") MultiView1.ActiveViewIndex = 0;
            else MultiView1.ActiveViewIndex = 1;

            if (_VS_ORDER_STS == "0")
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                btn_detail_update.Visible = true;
            }
            else if ((_VS_ORDER_STS == "1" && _VS_ORDER_TYPE == "2") || (_VS_ORDER_STS == "2" && _VS_ORDER_TYPE == "3"))
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                btn_detail_update.Visible = true;
            }
            else if (_VS_ORDER_STS == "3")
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = false;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                btn_detail_update.Visible = false;
            }
            else if (_VS_ORDER_STS == "4")
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                btn_detail_update.Visible = true;
            }
            else if (_VS_ORDER_STS == "5" || _VS_ORDER_STS == "7")
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = false;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                btn_detail_update.Visible = false;
                btnUpdateShopDetail.Visible = false;
            }
            else if (_VS_ORDER_STS == "6")
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                btn_detail_update.Visible = true;
                btnUpdateShopDetail.Visible = true;
            }
            else if (_VS_ORDER_STS == "8" || _VS_ORDER_STS == "9")
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = true;
                btn_detail_update.Visible = true;
                btnUpdateShopDetail.Visible = false;
            }
            else if (_VS_ORDER_STS == "10")
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = false;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                btn_detail_update.Visible = false;
                trTranCusPrice.Visible = true;
                trTranCusPrice1.Visible = true;
                btnUpdateShopDetail.Visible = false;
                txt_Transport_Cus_Price.Text = Convert.ToDouble(dt.Rows[0]["TRANSPORT_CUSTOMER_PRICE"].ToString()).ToString("N", new CultureInfo("en-US"));
            }
            else
            {
                ddl_ViewDetail_ORDER_STATUS.Enabled = false;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                btn_detail_update.Visible = false;
                trTranCusPrice.Visible = false;
                trTranCusPrice1.Visible = false;
                btnUpdateShopDetail.Visible = false;
            }

            if (btn_detail_update.Visible) txt_Update_STS_EMP_Remark.Enabled = true;
            else txt_Update_STS_EMP_Remark.Enabled = false;

        }

        #endregion

        #region Event Button

        protected void ddl_ViewDetail_ORDER_STATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int STS = Convert.ToInt32(ddl_ViewDetail_ORDER_STATUS.SelectedValue);
            if (STS == 10)
            {
                ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue = "3";
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                trTranCusPrice.Visible = true;
                trTranCusPrice1.Visible = true;
                trTranCusPrice2.Visible = true;
            }
            else if (STS >= 8)
            {
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = true;
                trTranCusPrice.Visible = false;
                trTranCusPrice1.Visible = false;
                trTranCusPrice2.Visible = false;
            }
            else
            {
                ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue = _VS_ORDER_TRAN_STS;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                trTranCusPrice.Visible = false;
                trTranCusPrice1.Visible = false;
                trTranCusPrice2.Visible = false;
            }
        }

        protected void btn_detail_update_Click(object sender, EventArgs e)
        {
            if (ddl_ViewDetail_ORDER_STATUS.SelectedValue == "10")
            {
                if (txt_Transport_Cus_Price.Text.Trim() == "" || Convert.ToDouble(txt_Transport_Cus_Price.Text.Trim()) == 0)
                {
                    txt_Transport_Cus_Price.Text = "0.00";
                    //ShowMessageBox("Please enter transport customer price", this.Page);
                    //return;
                }
                double TranCusPrice = Convert.ToDouble(txt_Transport_Cus_Price.Text.Trim());
                if (TranCusPrice > 0)
                {
                    if (_VS_CUS_BALANCE > TranCusPrice)
                    {
                        string ResultTran = "";
                        TransactionData EnTran = new TransactionData();
                        string Act = "INS_NON_PROD";
                        AdminBiz AdBizTran = new AdminBiz();

                        EnTran.EMP_ID_APPROVE = Convert.ToInt32(_VS_USER_EMP_ID);
                        EnTran.TRAN_TYPE = 2;
                        EnTran.TRAN_TABLE_TYPE = 3;
                        EnTran.TRAN_STATUS = 2;
                        EnTran.TRAN_AMOUNT = TranCusPrice;
                        EnTran.ORDER_ID = Convert.ToInt32(_VS_ORDER_ID);
                        EnTran.EMP_REMARK = "ตัดเงินรายการค่าขนส่งขั้นตอนสุดท้าย";
                        ResultTran = AdBizTran.INS_UPD_TRANSACTION(EnTran, Act);
                    }
                    else
                    {
                        ShowMessageBox("Customer amount is not enough.Please check again", this.Page);
                        return;
                    }
                }
            }

            if (Convert.ToDouble(lbl_tb2_Additional_Amount.Text) == 0 && (ddl_ViewDetail_ORDER_STATUS.SelectedValue == "5" || ddl_ViewDetail_ORDER_STATUS.SelectedValue == "7"))
            {
                ShowMessageBox("Not available This is because the amount At no extra cost", this.Page);
                //ไม่สามารถเลือก สถานะนี้ได้เนื่องจากยอดเงิน ไม่ต้องจ่ายเพิ่ม
                return;
            }

            OrderData En = new OrderData();
            AdminBiz AdBiz = new AdminBiz();
            En.Create_User = _VS_USER_LOGIN;
            En.TRANSPORT_CUSTOMER_PRICE = txt_Transport_Cus_Price.Text.Trim() == "" ? 0.00 : Convert.ToDouble(txt_Transport_Cus_Price.Text.Trim());
            En.SERVICE_CHARGE = txt_Service_Charge.Text.Trim() == "" ? 0.00 : Convert.ToDouble(txt_Service_Charge.Text.Trim());
            En.ORDER_STATUS = Convert.ToInt32(ddl_ViewDetail_ORDER_STATUS.SelectedValue);
            En.ORDER_ID = Convert.ToInt32(_VS_ORDER_ID);
            En.TRANSPORT_CUSTOMER_DETAIL = txt_Transport_Cus_Detail.Text.Trim();
            En.ORDER_EMP_REMARK = txt_Update_STS_EMP_Remark.Text.Trim();
            string Result_order = AdBiz.UPD_ADMIN_ORDER(En, "UPDATE_STS_ORDER");

            En.ORDER_STATUS = Convert.ToInt32(ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue);
            string Result_transport = AdBiz.UPD_ADMIN_ORDER(En, "UPDATE_STS_TRANSPORT");

            string Result = "";

            //if (_VS_ORDER_STS == "2" && (ddl_ViewDetail_ORDER_STATUS.SelectedValue == "3" || ddl_ViewDetail_ORDER_STATUS.SelectedValue == "5"))
            if (ddl_ViewDetail_ORDER_STATUS.SelectedValue == "5" || ddl_ViewDetail_ORDER_STATUS.SelectedValue == "7" || ddl_ViewDetail_ORDER_STATUS.SelectedValue == "10")
            {
                Result = AdBiz.UPD_ADMIN_ORDER_PROD_AMOUNT(Convert.ToInt32(_VS_ORDER_ID), -1, -1, -1, _VS_USER_LOGIN, "UPD_CAL_PROD_AMOUNT");
            }

            if (Result_order == "" && Result_transport == "" && Result == "")
            {
                BindData();
                ShowMessageBox("Update success", this.Page);
            }
            else
            {
                ShowMessageBox(Server.HtmlEncode("ERROR ORDER : " + Result_order + "  ERROR TRANSPORT : " + Result_transport + "  ERROR TRANSACTION : " + Result), this.Page);
            }
        }

        #endregion

        #endregion

        #region Tab3

        public void BindData_Tab3(DataTable dt)
        {
            gv_detail.DataSource = dt;
            gv_detail.DataBind();
        }

        #region Gridview Product Detail

        protected void imgbtn_popup_shopdetail_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;

            _VS_ORDER_SHOP_ID = Convert.ToInt32(this.gv_detail.DataKeys[rowIndex].Values[0].ToString());
            txt_sd_shoporder_id.Text = this.gv_detail.DataKeys[rowIndex].Values[1].ToString();
            lbl_sd_shopname.Text = this.gv_detail.DataKeys[rowIndex].Values[2].ToString();
            txt_sd_trackingno.Text = this.gv_detail.DataKeys[rowIndex].Values[3].ToString();
            txt_sd_weight.Text = this.gv_detail.DataKeys[rowIndex].Values[4].ToString();
            txt_sd_size.Text = this.gv_detail.DataKeys[rowIndex].Values[5].ToString();
            //txt_sd_weight_rpice.Text = this.gv_detail.DataKeys[rowIndex].Values[6].ToString();
            //txt_sd_size_price.Text = this.gv_detail.DataKeys[rowIndex].Values[7].ToString();
            txt_sd_tran_china_price.Text = Convert.ToDouble(this.gv_detail.DataKeys[rowIndex].Values[8].ToString()).ToString("N", new CultureInfo("en-US"));
            txt_sd_tran_thai_price.Text = Convert.ToDouble(this.gv_detail.DataKeys[rowIndex].Values[9].ToString()).ToString("N", new CultureInfo("en-US"));
            _VS_CAL_TRANSPORT_SHOP_RATE = this.gv_detail.DataKeys[rowIndex].Values[27].ToString();
            txt_sd_tran_remark.Text = this.gv_detail.DataKeys[rowIndex].Values[28].ToString();

            if (_VS_TRANSPORT_CH_TH_METHOD == "2")
            {
                ddl_TRANS_METHOD_AirPlane.SelectedValue = this.gv_detail.DataKeys[rowIndex].Values[25].ToString() == "-" ? "-1" : this.gv_detail.DataKeys[rowIndex].Values[25].ToString();
            }
            else
            {
                ddl_TRANS_METHOD_OTHER.SelectedValue = this.gv_detail.DataKeys[rowIndex].Values[25].ToString() == "-" ? "-1" : this.gv_detail.DataKeys[rowIndex].Values[25].ToString();
            }

            Modal_ShopDetail.Show();
        }

        protected void imgbtn_Editprod_amount_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView2")).ActiveViewIndex = 1;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView3")).ActiveViewIndex = 1;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView_Price_Active")).ActiveViewIndex = 1;
        }

        protected void imgbtn_Updateprod_amount_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            int txt_AMOUNT_ACTIVE = ((TextBox)gv_detail.Rows[rowIndex].FindControl("txt_OD_AMOUNT_ACTIVE")).Text == "" ? 0 : Convert.ToInt32(((TextBox)gv_detail.Rows[rowIndex].FindControl("txt_OD_AMOUNT_ACTIVE")).Text);
            double txt_OD_Price_ACTIVE = ((TextBox)gv_detail.Rows[rowIndex].FindControl("txt_OD_Price_ACTIVE")).Text == "" ? 0.00 : Convert.ToDouble(((TextBox)gv_detail.Rows[rowIndex].FindControl("txt_OD_Price_ACTIVE")).Text);

            int ORDER_DETAIL_ID = Convert.ToInt32(this.gv_detail.DataKeys[rowIndex].Values[10].ToString());
            int OD_AMOUNT = Convert.ToInt32(this.gv_detail.DataKeys[rowIndex].Values[11].ToString());

            if (txt_AMOUNT_ACTIVE > OD_AMOUNT)
            {
                ShowMessageBox("Please check the product amount again.", this.Page);
                return;
            }

            AdminBiz AdBiz = new AdminBiz();
            string Result = AdBiz.UPD_ADMIN_ORDER_PROD_AMOUNT(-1, ORDER_DETAIL_ID, txt_AMOUNT_ACTIVE, txt_OD_Price_ACTIVE, _VS_USER_LOGIN, "UPD_PROD_AMOUNT");

            if (Result == "")
            {
                BindData();
                ShowMessageBox("Update product amount success", this.Page);

                ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView2")).ActiveViewIndex = 0;
                ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView3")).ActiveViewIndex = 0;
                ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView_Price_Active")).ActiveViewIndex = 0;
            }
        }

        protected void imgbtn_Cancelprod_amount_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;

            ((TextBox)gv_detail.Rows[rowIndex].FindControl("txt_OD_AMOUNT_ACTIVE")).Text = ((Label)gv_detail.Rows[rowIndex].FindControl("lbl_OD_AMOUNT_ACTIVE")).Text;
            ((TextBox)gv_detail.Rows[rowIndex].FindControl("txt_OD_Price_ACTIVE")).Text = this.gv_detail.DataKeys[rowIndex].Values[26].ToString();
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView2")).ActiveViewIndex = 0;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView3")).ActiveViewIndex = 0;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView_Price_Active")).ActiveViewIndex = 0;
        }

        protected void imgbtn_gv_prod_pic_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string OD_PICURL = this.gv_detail.DataKeys[rowIndex].Values[18].ToString();
            ModalViewPic.Show();
            ucImage.URL = OD_PICURL;
            ucImage.SetImage();
        }

        protected void imgbtn_gv_prod_detail_upload_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            _VS_ORDER_DETAIL_ID = Convert.ToInt32(this.gv_detail.DataKeys[rowIndex].Values[10].ToString());
            Modal_Upload.Show();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FL_UPLOAD_RECEIPT.HasFile)
            {
                string Extension = Path.GetExtension(FL_UPLOAD_RECEIPT.PostedFile.FileName);

                if (Extension.ToUpper() == ".JPG" || Extension.ToUpper() == ".GIF" || Extension.ToUpper() == ".PNG")
                {
                    string AttPath = Server.MapPath(@"~/Attachment/RECEIPT");
                    string fileName = FL_UPLOAD_RECEIPT.FileName.Replace(Extension, "") + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss", new CultureInfo("en-US")) + Extension;
                    FL_UPLOAD_RECEIPT.PostedFile.SaveAs(AttPath + "/" + fileName);

                    OrderData En = new OrderData();
                    En.OD_ID = _VS_ORDER_DETAIL_ID;
                    En.OD_SIZE = @"~/Attachment/RECEIPT" + "/" + fileName;
                    En.Create_User = _VS_USER_LOGIN;

                    AdminBiz AdBiz = new AdminBiz();
                    AdBiz.UPDATE_ORDER_DETAIL_RECEIP(En, "UPD_UPLOAD_RECEIPT_PI");
                    ShowMessageBox("Upload Complete", this.Page);
                    BindData();
                }
                else
                {
                    Modal_Upload.Show();
                    ShowMessageBox("Please Upload File type is only png,jpg,gif !!", this.Page);
                }
            }
        }

        protected void imgbtn_gv_prod_detail_upload_pic_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string OD_SIZE = this.gv_detail.DataKeys[rowIndex].Values[14].ToString();
            ModalViewPic.Show();
            ucImage.URL = OD_SIZE;
            ucImage.SetImage();
        }

        protected void gv_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string OD_STATUS = DataBinder.Eval(e.Row.DataItem, "OD_STATUS").ToString();
                Label lblRowIndex = ((Label)e.Row.FindControl("lblRowIndex"));

                if (OD_STATUS == "-1")
                {
                    e.Row.Cells[0].ColumnSpan = gv_detail.Columns.Count;
                    e.Row.CssClass = "RowStyle_SHOP width100";
                    for (int i = 1; i <= gv_detail.Columns.Count - 1; i++)
                    {
                        e.Row.Cells[i].Visible = false;
                    }

                    string ShowShop = "";

                    ShowShop += DataBinder.Eval(e.Row.DataItem, "ROW_INDEX_SHOP").ToString() + ".";
                    ShowShop += "Shop name : " + DataBinder.Eval(e.Row.DataItem, "SHOPNAME").ToString() + "&nbsp;&nbsp;";
                    ShowShop += "Tracking No. " + DataBinder.Eval(e.Row.DataItem, "TRACKING_NO").ToString() + "&nbsp;&nbsp;";
                    ShowShop += "Order ID " + DataBinder.Eval(e.Row.DataItem, "SHOP_ORDER_ID").ToString() + "&nbsp;&nbsp;";

                    lblRowIndex.Text = ShowShop;

                    #region
                    if (Convert.ToInt32(_VS_ORDER_STS) >= 7) btnUpdateShopDetail.Visible = false;
                    else if (Convert.ToInt32(_VS_ORDER_STS) >= 5) btnUpdateShopDetail.Visible = true;
                    else if (Convert.ToInt32(_VS_ORDER_STS) == 4) btnUpdateShopDetail.Visible = true;
                    else btnUpdateShopDetail.Visible = false;
                    #endregion


                }
                else
                {
                    ((ImageButton)e.Row.FindControl("imgbtn_popup_shopdetail")).Visible = false;
                    int ROW = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ROW_RANK_PROD").ToString());
                    e.Row.Cells[0].CssClass = "ItemStyle-center";
                    //<a href="" target="_blank"></a>
                    string ItemName = DataBinder.Eval(e.Row.DataItem, "OD_ITEMNAME").ToString();
                    string ItemUrl = DataBinder.Eval(e.Row.DataItem, "OD_URL").ToString();

                    string OD_SIZE = DataBinder.Eval(e.Row.DataItem, "OD_SIZE").ToString();
                    string OD_COLOR = DataBinder.Eval(e.Row.DataItem, "OD_COLOR").ToString();

                    ((ImageButton)e.Row.FindControl("imgbtn_gv_prod_pic")).ImageUrl = DataBinder.Eval(e.Row.DataItem, "OD_PICURL").ToString();

                    string ProdItemDetail = "";

                    if (_VS_ORDER_TYPE == "1")
                    {
                        ProdItemDetail = "<a href=\"" + ItemUrl + "\" target=\"_blank\">" + ItemName + "</a><br>";

                        if (OD_SIZE.Contains("http"))
                        {
                            ProdItemDetail += "Size : <img src = \"" + OD_SIZE + "\" width = \"30px\" Height = \"30px\" />";
                        }
                        else
                        {
                            ProdItemDetail += "Size : " + OD_SIZE;
                        }

                        ProdItemDetail += "<br>";

                        if (OD_COLOR.Contains("http"))
                        {
                            ProdItemDetail += "Color : <img src = \"" + OD_COLOR + "\" width = \"30px\" Height = \"30px\" />";
                        }
                        else
                        {
                            ProdItemDetail += "Color : " + OD_COLOR;
                        }
                    }
                    else if (_VS_ORDER_TYPE == "2")
                    {
                        ProdItemDetail = ItemName;
                        Label lbl_gv_prod_detail_UploadText = ((Label)e.Row.FindControl("lbl_gv_prod_detail_UploadText"));
                        ImageButton imgUpload = ((ImageButton)e.Row.FindControl("imgbtn_gv_prod_detail_upload"));

                        lbl_gv_prod_detail_UploadText.Visible = true;
                        imgUpload.Visible = true;

                        imgUpload.ImageUrl = "~/img/icon/attachment.png";
                        imgUpload.Width = Unit.Pixel(20);
                        imgUpload.Height = Unit.Pixel(20);
                        imgUpload.ToolTip = "Upload Receipt File";

                        ImageButton imgbtn_gv_prod_detail_upload_pic = ((ImageButton)e.Row.FindControl("imgbtn_gv_prod_detail_upload_pic"));
                        if (OD_SIZE != "")
                        {
                            imgbtn_gv_prod_detail_upload_pic.Visible = true;
                            imgbtn_gv_prod_detail_upload_pic.Width = Unit.Pixel(40);
                            imgbtn_gv_prod_detail_upload_pic.Height = Unit.Pixel(40);
                            imgbtn_gv_prod_detail_upload_pic.ImageUrl = OD_SIZE;
                            ProdItemDetail += "<br>";
                                //"<img src = \"" + OD_SIZE + "\" width = \"80px\" Height = \"80px\" />";
                        }
                        else imgbtn_gv_prod_detail_upload_pic.Visible = false;

                    }
                    else if (_VS_ORDER_TYPE == "3")
                    {
                        ProdItemDetail = ItemName;
                        Label lbl_gv_prod_detail_UploadText = ((Label)e.Row.FindControl("lbl_gv_prod_detail_UploadText"));
                        ImageButton imgUpload = ((ImageButton)e.Row.FindControl("imgbtn_gv_prod_detail_upload"));
                        ImageButton imgbtn_gv_prod_detail_upload_pic = ((ImageButton)e.Row.FindControl("imgbtn_gv_prod_detail_upload_pic"));

                        lbl_gv_prod_detail_UploadText.Visible = false;
                        imgUpload.Visible = false;
                        imgbtn_gv_prod_detail_upload_pic.Visible = false;

                    }

                    ((Label)e.Row.FindControl("lbl_gv_prod_detail_Item")).Text = ProdItemDetail;

                    if ((ROW % 2) == 0)
                    {
                        e.Row.CssClass = "RowStyle_PROD1";
                    }
                    else
                    {
                        e.Row.CssClass = "RowStyle_PROD2";
                    }
                    lblRowIndex.Text = DataBinder.Eval(e.Row.DataItem, "ROW_RANK_PROD").ToString();

                    double OD_PRICE = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OD_PRICE").ToString());
                    e.Row.Cells[3].Text = (OD_PRICE * _VS_EXCH_RATE).ToString("N", new CultureInfo("en-US")) + "(THB) <BR><span style =\"color:red;\">" + OD_PRICE.ToString("N", new CultureInfo("en-US")) + "(CNY)</span>";

                    double TOTAL_PROD_PRICE = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_PROD_PRICE").ToString());
                    e.Row.Cells[5].Text = (TOTAL_PROD_PRICE * _VS_EXCH_RATE).ToString("N", new CultureInfo("en-US")) + "(THB) <BR><span style =\"color:red;\">" + TOTAL_PROD_PRICE.ToString("N", new CultureInfo("en-US")) + "(CNY)</span>";

                    double OD_PRICE_ACTIVE = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "OD_PRICE_ACTIVE").ToString());
                    ((Label)e.Row.FindControl("lbl_OD_Price_ACTIVE")).Text = (OD_PRICE_ACTIVE * _VS_EXCH_RATE).ToString("N", new CultureInfo("en-US")) + "(THB) <BR><span style =\"color:red;\">" + OD_PRICE_ACTIVE.ToString("N", new CultureInfo("en-US")) + "(CNY)</span>";

                    double TOTAL_PROD_PRICE_ACTIVE = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL_PROD_PRICE_ACTIVE").ToString());
                    e.Row.Cells[8].Text = (TOTAL_PROD_PRICE_ACTIVE * _VS_EXCH_RATE).ToString("N", new CultureInfo("en-US")) + "(THB) <BR><span style =\"color:red;\">" + TOTAL_PROD_PRICE_ACTIVE.ToString("N", new CultureInfo("en-US")) + "(CNY)</span>";

                    #region
                    if (_VS_ORDER_TYPE == "1")
                    {
                        if (Convert.ToInt32(_VS_ORDER_STS) >= 7) ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = false;
                        else if (Convert.ToInt32(_VS_ORDER_STS) >= 5) ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = false;
                        else if (Convert.ToInt32(_VS_ORDER_STS) == 4) ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = true;
                        else ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = false;
                    }
                    else ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = false;
                    #endregion

                }
            }
        }

        #endregion

        #endregion

        #region Tab4

        public void BindData_Tab4(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                gv_detail_shopname.DataSource = dt;
                gv_detail_shopname.DataBind();

                lbl_tb3_Transport_Method_CH_TO_TH.Text = dt.Rows[0]["TRANSPORT_CHINA_TEXT"].ToString();
                lbl_tb3_Transport_Method_To_Customer.Text = dt.Rows[0]["TRANSPORT_THAI_TEXT"].ToString();
                lbl_tb3_Transport_To_Customer_Detail.Text = dt.Rows[0]["TRANSPORT_DETAIL"].ToString();
                lbl_tb3_Transport_To_Customer_Date.Text = dt.Rows[0]["TRANSPORT_DATE"].ToString();

                double TRAN_CH_PRICE = Convert.ToDouble(dt.Rows[0]["SUM_TRANSPORT_CHINA_PRICE"].ToString());
                double TRAN_TH_PRICE = Convert.ToDouble(dt.Rows[0]["SUM_TRANSPORT_THAI_PRICE"].ToString());
                double TRAN_CUS_PRICE = Convert.ToDouble(dt.Rows[0]["TRANSPORT_CUSTOMER_PRICE"].ToString());
                double SERVICE_CHARGE = Convert.ToDouble(dt.Rows[0]["SERVICE_CHARGE"].ToString());

                lbl_tb3_Total_Transport_China_Price.Text = (TRAN_CH_PRICE * _VS_EXCH_RATE).ToString("N", new CultureInfo("en-US")) + "(THB)";
                lbl_tb3_Total_Transport_China_Price_CNY.Text = "<span style =\"color:red;\">" + TRAN_CH_PRICE.ToString("N", new CultureInfo("en-US")) + "(CNY)</span>";
                lbl_tb3_Total_Transport_CH_TO_TH.Text = TRAN_TH_PRICE.ToString("N", new CultureInfo("en-US")) + "(THB)";
                lbl_tb3_Total_Transport_To_Customer.Text = TRAN_CUS_PRICE.ToString("N", new CultureInfo("en-US")) + "(THB)";
                lbl_tb3_Service_Charge.Text = SERVICE_CHARGE.ToString("N", new CultureInfo("en-US")) + "(THB)";
                lbl_tb3_Total_Transport.Text = ((TRAN_CH_PRICE * _VS_EXCH_RATE) + TRAN_TH_PRICE + TRAN_CUS_PRICE).ToString("N", new CultureInfo("en-US")) + "(THB)";
            }
            else
            {
                gv_detail_shopname.DataSource = null;
                gv_detail_shopname.DataBind();
            }
        }

        protected void gv_detail_shopname_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double TRANSPORT_CHINA_PRICE = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TRANSPORT_CHINA_PRICE").ToString());
                e.Row.Cells[5].Text = (TRANSPORT_CHINA_PRICE * _VS_EXCH_RATE).ToString("N", new CultureInfo("en-US")) + "(THB) <BR><span style =\"color:red;\">" + TRANSPORT_CHINA_PRICE.ToString("N", new CultureInfo("en-US")) + "(CNY)</span>";

            }
        }

        protected void imgbtn_tab3_popup_shopdetail_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;

            _VS_ORDER_SHOP_ID = Convert.ToInt32(this.gv_detail_shopname.DataKeys[rowIndex].Values[5].ToString());
            txt_sd_shoporder_id.Text = this.gv_detail_shopname.DataKeys[rowIndex].Values[7].ToString();
            lbl_sd_shopname.Text = this.gv_detail_shopname.DataKeys[rowIndex].Values[6].ToString();
            txt_sd_trackingno.Text = this.gv_detail_shopname.DataKeys[rowIndex].Values[8].ToString();
            txt_sd_weight.Text = this.gv_detail_shopname.DataKeys[rowIndex].Values[9].ToString();
            txt_sd_size.Text = this.gv_detail_shopname.DataKeys[rowIndex].Values[10].ToString();
            //txt_sd_weight_rpice.Text = this.gv_detail_shopname.DataKeys[rowIndex].Values[6].ToString();
            //txt_sd_size_price.Text = this.gv_detail_shopname.DataKeys[rowIndex].Values[7].ToString();
            txt_sd_tran_china_price.Text = Convert.ToDouble(this.gv_detail_shopname.DataKeys[rowIndex].Values[11].ToString()).ToString("N", new CultureInfo("en-US"));
            txt_sd_tran_thai_price.Text = Convert.ToDouble(this.gv_detail_shopname.DataKeys[rowIndex].Values[12].ToString()).ToString("N", new CultureInfo("en-US"));
            txt_sd_tran_remark.Text = this.gv_detail_shopname.DataKeys[rowIndex].Values[22].ToString();

            _VS_CAL_TRANSPORT_SHOP_RATE = this.gv_detail_shopname.DataKeys[rowIndex].Values[14].ToString();


            if (_VS_TRANSPORT_CH_TH_METHOD == "2")
            {
                ddl_TRANS_METHOD_AirPlane.SelectedValue = this.gv_detail_shopname.DataKeys[rowIndex].Values[13].ToString() == "-" ? "-1" : this.gv_detail_shopname.DataKeys[rowIndex].Values[13].ToString();
            }
            else
            {
                ddl_TRANS_METHOD_OTHER.SelectedValue = this.gv_detail_shopname.DataKeys[rowIndex].Values[13].ToString() == "-" ? "-1" : this.gv_detail_shopname.DataKeys[rowIndex].Values[13].ToString();
            }

            Modal_ShopDetail.Show();
        }

        #endregion

        #region Modal Shop

        public bool Calculation()
        {
            //if (ddl_TRANS_METHOD_OTHER.SelectedValue == "4" || ddl_TRANS_METHOD_AirPlane.SelectedValue == "4")
            //{
            //    return true;
            //}

            string CONFIG_GROUP = "";
            bool CAL_Q = false;

            if (_VS_TRANSPORT_CH_TH_METHOD == "1" && ddl_TRANS_METHOD_OTHER.SelectedValue == "1") CONFIG_GROUP = "TRANS_SHIP_DRESS_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "1" && ddl_TRANS_METHOD_OTHER.SelectedValue == "2") CONFIG_GROUP = "TRANS_SHIP_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "1" && ddl_TRANS_METHOD_OTHER.SelectedValue == "3")
            {
                CAL_Q = true;
                CONFIG_GROUP = "TRANS_SHIP_Q";
            }
            else if (_VS_TRANSPORT_CH_TH_METHOD == "1" && ddl_TRANS_METHOD_OTHER.SelectedValue == "4") CONFIG_GROUP = "TRANS_SHIP_BRAND";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "3" && ddl_TRANS_METHOD_OTHER.SelectedValue == "1") CONFIG_GROUP = "TRANS_CAR_DRESS_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "3" && ddl_TRANS_METHOD_OTHER.SelectedValue == "2") CONFIG_GROUP = "TRANS_CAR_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "3" && ddl_TRANS_METHOD_OTHER.SelectedValue == "3")
            {
                CAL_Q = true;
                CONFIG_GROUP = "TRANS_CAR_Q";
            }
            else if (_VS_TRANSPORT_CH_TH_METHOD == "3" && ddl_TRANS_METHOD_OTHER.SelectedValue == "4") CONFIG_GROUP = "TRANS_CAR_BRAND";
            //Case Transport Airplane
            else if (_VS_TRANSPORT_CH_TH_METHOD == "2" && ddl_TRANS_METHOD_AirPlane.SelectedValue == "1") CONFIG_GROUP = "TRANS_AIR_PLANE_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "2" && ddl_TRANS_METHOD_AirPlane.SelectedValue == "2") CONFIG_GROUP = "TRANS_AIR_PLANE_SOFT";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "2" && ddl_TRANS_METHOD_AirPlane.SelectedValue == "3") CONFIG_GROUP = "TRANS_AIR_PLANE_BRAND";

            string Size_Pattern = "^([0-9]\\d{0,5})+[*]+([0-9]\\d{0,5})+[*]+([0-9]\\d{0,5})$";

            if (CAL_Q == true && txt_sd_size.Text.Trim() == "")
            {
                ShowMessageBox("Please enter size", this.Page);
                return false;
            }
            else if (CAL_Q == false && txt_sd_size.Text.Trim() == "")
            {
                ShowMessageBox("Please enter size", this.Page);
                return false;
            }
            else if (CAL_Q == true && !(Regex.IsMatch(txt_sd_size.Text.Trim(), Size_Pattern)))
            {
                ShowMessageBox("Please fill in the correct format size", this.Page);
                return false;
            }

            AdminBiz AdBiz = new AdminBiz();
            DataSet ds = AdBiz.ADMIN_GET_CONFIG("", CONFIG_GROUP, "BINDDATA_BYGROUP", txt_sd_weight.Text.Trim());
            //DataSet ds = AdBiz.ADMIN_GET_CONFIG("", CONFIG_GROUP, "BINDDATA_BYGROUP", CAL_Q == true ? "-1" : txt_sd_weight.Text.Trim());

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string config_value1 = ds.Tables[0].Rows[0]["CONFIG_VALUE"].ToString();
                string config_value2 = ds.Tables[0].Rows[0]["CONFIG_VALUE2"].ToString();
                string config_value3 = ds.Tables[0].Rows[0]["CONFIG_VALUE3"].ToString();
                _VS_CAL_TRANSPORT_SHOP_RATE = config_value3;

                if (CAL_Q == true)
                {
                    string[] SizeArry = txt_sd_size.Text.Trim().Split('*');

                    double? Q_NUM = ConvertTypeCls.ConvertToDouble(SizeArry[0].ToString()) * ConvertTypeCls.ConvertToDouble(SizeArry[1].ToString()) * ConvertTypeCls.ConvertToDouble(SizeArry[2].ToString()) / 1000000;
                    txt_sd_tran_thai_price.Text = ((double)(Q_NUM * ConvertTypeCls.ConvertToDouble(config_value3))).ToString("N", new CultureInfo("en-US"));
                }
                else
                {
                    double? txt_Weight = ConvertTypeCls.ConvertToDouble(txt_sd_weight.Text.Trim());

                    if (CONFIG_GROUP.IndexOf("AIR_PLANE") != -1 && config_value2 != "")
                    {
                        txt_sd_tran_thai_price.Text = config_value3;
                    }
                    else
                    {
                        txt_sd_tran_thai_price.Text = ((double)(ConvertTypeCls.ConvertToDouble(config_value3) * txt_Weight)).ToString("N", new CultureInfo("en-US"));
                    }
                }
            }
            return true;
        }

        protected void ddl_TRANS_METHOD_AirPlane_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_TRANS_METHOD_AirPlane.SelectedValue != "-1")
            {
                if (!Calculation())
                {
                    ddl_TRANS_METHOD_AirPlane.SelectedIndex = 0;
                }
            }
            Modal_ShopDetail.Show();
        }

        protected void ddl_TRANS_METHOD_OTHER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_TRANS_METHOD_OTHER.SelectedValue != "-1")
            {
                if (!Calculation())
                {
                    ddl_TRANS_METHOD_OTHER.SelectedIndex = 0;
                }
            }
            Modal_ShopDetail.Show();
        }

        protected void btnUpdateShopDetail_Click(object sender, EventArgs e)
        {
            if (_VS_TRANSPORT_CH_TH_METHOD == "2")
            {
                if (ddl_TRANS_METHOD_AirPlane.SelectedValue == "-1")
                {
                    ShowMessageBox("Please select product type !!", this.Page);
                    Modal_ShopDetail.Show();
                    return;
                }
            }
            else
            {
                if (ddl_TRANS_METHOD_OTHER.SelectedValue == "-1")
                {
                    ShowMessageBox("Please select product type !!", this.Page);
                    Modal_ShopDetail.Show();
                    return;
                }
            }

            if (ddl_TRANS_METHOD_OTHER.SelectedValue == "4" || ddl_TRANS_METHOD_AirPlane.SelectedValue == "4")
            {
                _VS_CAL_TRANSPORT_SHOP_RATE = txt_sd_tran_thai_price.Text.Trim();
            }

            AdminBiz AdBiz = new AdminBiz();

            OrderData En = new OrderData();

            En.ORDER_ID = Convert.ToInt32(_VS_ORDER_ID);
            En.ORDER_SHOP_ID = _VS_ORDER_SHOP_ID;
            En.SHOPNAME = lbl_sd_shopname.Text;
            En.SHOP_ORDER_ID = txt_sd_shoporder_id.Text.Trim();
            En.TRACKING_NO = txt_sd_trackingno.Text.Trim();
            En.WEIGHT = txt_sd_weight.Text.Trim();
            En.SIZE = txt_sd_size.Text.Trim();
            En.WEIGHT_PRICE = 0;
            En.SIZE_PRICE = 0;
            En.SHOP_REMARK = txt_sd_tran_remark.Text.Trim();
            En.TRANSPORT_CHINA_PRICE = txt_sd_tran_china_price.Text.Trim() == "" ? 0.00 : Convert.ToDouble(txt_sd_tran_china_price.Text.Trim());
            En.TRANSPORT_THAI_PRICE = txt_sd_tran_thai_price.Text.Trim() == "" ? 0.00 : Convert.ToDouble(txt_sd_tran_thai_price.Text.Trim());
            En.PRODUCT_TYPE = Convert.ToInt32(_VS_TRANSPORT_CH_TH_METHOD == "2" ? ddl_TRANS_METHOD_AirPlane.SelectedValue : ddl_TRANS_METHOD_OTHER.SelectedValue);
            En.CAL_TRANSPORT_SHOP_RATE = _VS_CAL_TRANSPORT_SHOP_RATE;
            En.Create_User = _VS_USER_LOGIN;

            string Result = AdBiz.UPD_ADMIN_ORDER_SHOP(En, "UPD_ORDER_SHOP");
            if (Result == "")
            {
                ShowMessageBox("Update Shop success", this.Page);
            }
            else
            {
                ShowMessageBox(Server.HtmlEncode("ERROR ORDER : " + Result), this.Page);
                Modal_ShopDetail.Show();
            }
            BindData();
        }

        #endregion

    }
}