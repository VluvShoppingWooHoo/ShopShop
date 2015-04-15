using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    public partial class frmOrder : System.Web.UI.Page
    {
        util.EncrypUtil Enc = new util.EncrypUtil();

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _VS_USER_LOGIN = "admin";
                BindData_order_status(ddl_ViewDetail_ORDER_STATUS);
                BindData_transport_status(ddl_ViewDetail_TRANSPORT_STATUS);

                BindData();
            }

            ucEmail1.ucEmail_OpenpopClick += new System.EventHandler(ucEmail_OpenpopClick);

        }

        public void ucEmail_OpenpopClick(object sender, System.EventArgs e)
        {
            MadoalPop_Email.Show();
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

        public void BindData()
        {
            DataSet ds = new DataSet();

            AdminBiz AdBiz = new AdminBiz();
            ds = AdBiz.GET_ADMIN_ORDER("BINDDATA_BYID", Convert.ToInt32(_VS_ORDER_ID));

            if (ds.Tables[0].Rows.Count > 0)
            {
                #region ORDER DATA

                _VS_TRANSPORT_CH_TH_METHOD = ds.Tables[0].Rows[0]["TRANSPORT_CH_TH_METHOD"].ToString();

                lbl_ViewDetail_ORDER_ID.Text = ds.Tables[0].Rows[0]["ORDER_CODE"].ToString();
                lbl_ViewDetail_ORDER_DATE.Text = ds.Tables[0].Rows[0]["ORDER_DATE_TEXT"].ToString();
                lbl_ViewDetail_TRANSPORT_1.Text = ds.Tables[0].Rows[0]["TRANSPORT_CHINA_TEXT"].ToString();
                lbl_ViewDetail_TRANSPORT_2.Text = ds.Tables[0].Rows[0]["TRANSPORT_THAI_TEXT"].ToString();
                lbl_ViewDetail_ADDRESS.Text = ds.Tables[0].Rows[0]["CUS_REC_NAME"].ToString() + "<br/>" + ds.Tables[0].Rows[0]["CUS_ADDRESS"].ToString();
                lbl_ViewDetail_EMP_NAME.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
                lbl_ViewDetail_EMP_UPDATE_DATE.Text = ds.Tables[0].Rows[0]["EMP_UPDATE_DATE"].ToString() == "" ? "-" : ds.Tables[0].Rows[0]["EMP_UPDATE_DATE"].ToString();

                lbl_ViewDetail_Amount_Receive.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["TOTAL_INCOME"].ToString()).ToString("N", new CultureInfo("en-US"));
                lbl_ViewDetail_Product_Price.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["SUM_PROD_PRICE_ACTIVE"].ToString()).ToString("N", new CultureInfo("en-US"));
                lbl_ViewDetail_Amount_Actually_Pay.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["TOTAL_PRICE_ACTIVE"].ToString()).ToString("N", new CultureInfo("en-US"));
                //lbl_ViewDetail_Amount_Recall_Pay.Text = (Convert.ToDouble(ds.Tables[0].Rows[0]["TOTAL_PRICE"].ToString()) - Convert.ToDouble(ds.Tables[0].Rows[0]["TOTAL_PRICE_ACTIVE"].ToString())).ToString("N", new CultureInfo("en-US"));
                _VS_ORDER_STS = ds.Tables[0].Rows[0]["ORDER_STATUS"].ToString();
                _VS_ORDER_TRAN_STS = ds.Tables[0].Rows[0]["TRANSPORT_STATUS"].ToString();
                
                double TOTALAMOUNT_REMAIN = Convert.ToDouble(ds.Tables[0].Rows[0]["TOTALAMOUNT_REMAIN"].ToString()); //.ToString("N", new CultureInfo("en-US"));
                if (TOTALAMOUNT_REMAIN >= 0)
                {
                    lbl_ViewDetail_Addtional_Amount.Text = "0.00";
                    if (_VS_ORDER_STS == "8")
                    {
                        lbl_ViewDetail_Amount_Recall_Pay.Text = TOTALAMOUNT_REMAIN.ToString("N", new CultureInfo("en-US"));
                    }
                    else
                    {
                        lbl_ViewDetail_Amount_Recall_Pay.Text = "0.00";
                    }
                }
                else 
                {
                    TOTALAMOUNT_REMAIN = -1 * TOTALAMOUNT_REMAIN;
                    lbl_ViewDetail_Addtional_Amount.Text = TOTALAMOUNT_REMAIN.ToString("N", new CultureInfo("en-US"));
                    lbl_ViewDetail_Amount_Recall_Pay.Text = "0.00";
                }
                
                lbl_ViewDetail_Transport_Price.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["TRANSPORT_PRICE_ACTIVE"].ToString()).ToString("N", new CultureInfo("en-US"));

                BindData_order_status(ddl_ViewDetail_ORDER_STATUS, STS_NAME: _VS_ORDER_STS, Act: "BIND_DDL_STS_ID");
                ddl_ViewDetail_ORDER_STATUS.SelectedValue = _VS_ORDER_STS;

                BindData_transport_status(ddl_ViewDetail_TRANSPORT_STATUS, STS_NAME: _VS_ORDER_TRAN_STS, Act: "BIND_DDL_STS_ID");
                ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue = _VS_ORDER_TRAN_STS;

                if (_VS_TRANSPORT_CH_TH_METHOD == "2") MultiView1.ActiveViewIndex = 0;
                else MultiView1.ActiveViewIndex = 1;

                if (_VS_ORDER_STS == "0")
                {
                    ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                    ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                    btn_detail_update.Visible = true;
                }
                else if (_VS_ORDER_STS == "1")
                {
                    ddl_ViewDetail_ORDER_STATUS.Enabled = false;
                    ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                    btn_detail_update.Visible = false;
                }
                else if (_VS_ORDER_STS == "2")
                {
                    ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                    ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                    btn_detail_update.Visible = true;
                }
                else if (_VS_ORDER_STS == "3" || _VS_ORDER_STS == "5")
                {
                    ddl_ViewDetail_ORDER_STATUS.Enabled = false;
                    ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                    btn_detail_update.Visible = false;
                    btnUpdateShopDetail.Visible = false;
                }
                else if (_VS_ORDER_STS == "4")
                {
                    ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                    ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                    btn_detail_update.Visible = true;
                    btnUpdateShopDetail.Visible = true;
                }
                else if (_VS_ORDER_STS == "6" || _VS_ORDER_STS == "7")
                {
                    ddl_ViewDetail_ORDER_STATUS.Enabled = true;
                    ddl_ViewDetail_TRANSPORT_STATUS.Enabled = true;
                    btn_detail_update.Visible = true;
                    btnUpdateShopDetail.Visible = false;
                }
                else if (_VS_ORDER_STS == "8")
                {
                    ddl_ViewDetail_ORDER_STATUS.Enabled = false;
                    ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                    btn_detail_update.Visible = false;
                    trTranCusPrice.Visible = true;
                    btnUpdateShopDetail.Visible = false;
                    txt_Transport_Cus_Price.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["TRANSPORT_CUSTOMER_PRICE"].ToString()).ToString("N", new CultureInfo("en-US")); 
                }
                else
                {
                    ddl_ViewDetail_ORDER_STATUS.Enabled = false;
                    ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                    btn_detail_update.Visible = false;
                    trTranCusPrice.Visible = false;
                    btnUpdateShopDetail.Visible = false;
                }

                #endregion

                #region Customer Data
                lbl_ViewDetail_CusCode.Text = ds.Tables[3].Rows[0]["CUS_CODE"].ToString();
                lbl_ViewDetail_CusName.Text = ds.Tables[3].Rows[0]["CUS_FULLNAME"].ToString();
                lbl_ViewDetail_Telphone.Text = ds.Tables[3].Rows[0]["CUS_TELEPHONE"].ToString() + " Mobile : " + ds.Tables[3].Rows[0]["CUS_MOBILE"].ToString();
                lbl_ViewDetail_Email.Text = ds.Tables[3].Rows[0]["CUS_EMAIL"].ToString();
                //lbl_ViewDetail_Total_Amount.Text = ds.Tables[3].Rows[0]["CUS_TOTAL_AMOUNT"].ToString();
                #endregion

                #region Order Shop

                gv_detail.DataSource = ds.Tables[2];
                gv_detail.DataBind();

                #endregion
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

        protected void btn_detail_update_Click(object sender, EventArgs e)
        {
            if (ddl_ViewDetail_ORDER_STATUS.SelectedValue == "8" && (txt_Transport_Cus_Price.Text.Trim() == "" || Convert.ToDouble(txt_Transport_Cus_Price.Text.Trim()) == 0))
            {
                ShowMessageBox("Please enter transport customer price", this.Page);
                return;
            }

            if (Convert.ToDouble(lbl_ViewDetail_Addtional_Amount.Text) == 0 && (ddl_ViewDetail_ORDER_STATUS.SelectedValue == "3" || ddl_ViewDetail_ORDER_STATUS.SelectedValue == "5"))
            {
                ShowMessageBox("ไม่สามารถเลือก สถานะนี้ได้เนื่องจากยอดเงิน ไม่ต้องจ่ายเพิ่ม", this.Page);
                return;
            }

            OrderData En = new OrderData();
            AdminBiz AdBiz = new AdminBiz();
            En.Create_User = _VS_USER_LOGIN;
            En.TRANSPORT_CUSTOMER_PRICE = txt_Transport_Cus_Price.Text.Trim() == "" ? 0.00 : Convert.ToDouble(txt_Transport_Cus_Price.Text.Trim());
            En.ORDER_STATUS = Convert.ToInt32(ddl_ViewDetail_ORDER_STATUS.SelectedValue);
            En.ORDER_ID = Convert.ToInt32(_VS_ORDER_ID);
            string Result_order = AdBiz.UPD_ADMIN_ORDER(En, "UPDATE_STS_ORDER");

            En.ORDER_STATUS = Convert.ToInt32(ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue);
            string Result_transport = AdBiz.UPD_ADMIN_ORDER(En, "UPDATE_STS_TRANSPORT");

            string Result = "";

            //if (_VS_ORDER_STS == "2" && (ddl_ViewDetail_ORDER_STATUS.SelectedValue == "3" || ddl_ViewDetail_ORDER_STATUS.SelectedValue == "5"))
            if (ddl_ViewDetail_ORDER_STATUS.SelectedValue == "3" || ddl_ViewDetail_ORDER_STATUS.SelectedValue == "5" || ddl_ViewDetail_ORDER_STATUS.SelectedValue == "8")
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

        //protected void btnEditProd_num_save_Click(object sender, EventArgs e)
        //{
        //    AdminBiz AdBiz;
        //    string Result = "";

        //    for (int i = 0; i <= gv_detail_prod_Edit.Rows.Count - 1; i++)
        //    {
        //        TextBox txtprodnum = (TextBox)gv_detail_prod_Edit.Rows[i].Cells[5].FindControl("gv_detail_prod_Edit_txt");
        //        int PROD_NUM = Convert.ToInt32(gv_detail_prod_Edit.Rows[i].Cells[4].Text);
        //        if (Convert.ToInt32(txtprodnum.Text) > PROD_NUM)
        //        {
        //            ShowMessageBox("Please check the product amount again.", this.Page);
        //            return;
        //        }
        //    }

        //    for (int i = 0; i <= gv_detail_prod_Edit.Rows.Count - 1; i++)
        //    {
        //        AdBiz = new AdminBiz();
        //        TextBox txtprodnum = (TextBox)gv_detail_prod_Edit.Rows[i].Cells[5].FindControl("gv_detail_prod_Edit_txt");
        //        int ORDER_ID = Convert.ToInt32(gv_detail_prod_Edit.DataKeys[i].Values[0].ToString());
        //        int ORDER_DETAIL_ID = Convert.ToInt32(gv_detail_prod_Edit.DataKeys[i].Values[1].ToString());

        //        int PROD_NUM = txtprodnum.Text == "" ? 0 : Convert.ToInt32(txtprodnum.Text);

        //        Result += AdBiz.UPD_ADMIN_ORDER_PROD_AMOUNT(ORDER_ID, ORDER_DETAIL_ID, PROD_NUM, _VS_USER_LOGIN, "UPD_PROD_AMOUNT");
        //    }

        //    if (Result == "")
        //    {
        //        BindData();
        //        MultiView1.ActiveViewIndex = 0;
        //        ShowMessageBox("Update success", this.Page);
        //    }
        //    else ShowMessageBox(Server.HtmlEncode(Result), this.Page);
        //}

        //protected void btnEditProd_num_cancel_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 0;
        //}

        protected void ddl_ViewDetail_ORDER_STATUS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int STS = Convert.ToInt32(ddl_ViewDetail_ORDER_STATUS.SelectedValue);
            if (STS == 8)
            {
                ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue = "3";
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                trTranCusPrice.Visible = true;
            }
            else if (STS >= 6)
            {
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = true;
                trTranCusPrice.Visible = false;
            }
            else
            {
                ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue = _VS_ORDER_TRAN_STS;
                ddl_ViewDetail_TRANSPORT_STATUS.Enabled = false;
                trTranCusPrice.Visible = false;
            }
        }

        #region Event Gridview Detail

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
                    if (Convert.ToInt32(_VS_ORDER_STS) >= 5) btnUpdateShopDetail.Visible = false;
                    else if (Convert.ToInt32(_VS_ORDER_STS) >= 3) btnUpdateShopDetail.Visible = true;
                    else if (Convert.ToInt32(_VS_ORDER_STS) == 2) btnUpdateShopDetail.Visible = true;
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

                    e.Row.Cells[1].Text = "<a href=\"" + ItemUrl + "\" target=\"_blank\">" + ItemName + "</a>";

                    if ((ROW % 2) == 0)
                    {
                        e.Row.CssClass = "RowStyle_PROD1";
                    }
                    else
                    {
                        e.Row.CssClass = "RowStyle_PROD2";
                    }

                    lblRowIndex.Text = DataBinder.Eval(e.Row.DataItem, "ROW_RANK_PROD").ToString();

                    #region
                    if (Convert.ToInt32(_VS_ORDER_STS) >= 5) ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = false;
                    else if (Convert.ToInt32(_VS_ORDER_STS) >= 3) ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = false;
                    else if (Convert.ToInt32(_VS_ORDER_STS) == 2) ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = true;
                    else ((ImageButton)e.Row.FindControl("imgbtn_Editprod_amount")).Visible = false;
                    #endregion

                }
            }

        }

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

            if (_VS_TRANSPORT_CH_TH_METHOD == "2")
            {
                ddl_TRANS_METHOD_AirPlane.SelectedValue = this.gv_detail.DataKeys[rowIndex].Values[25].ToString() == "" ? "-1" : this.gv_detail.DataKeys[rowIndex].Values[25].ToString();
            }
            else
            {
                ddl_TRANS_METHOD_OTHER.SelectedValue = this.gv_detail.DataKeys[rowIndex].Values[25].ToString() == "" ? "-1" : this.gv_detail.DataKeys[rowIndex].Values[25].ToString();
            }

            Modal_ShopDetail.Show();
        }

        protected void imgbtn_Editprod_amount_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView2")).ActiveViewIndex = 1;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView3")).ActiveViewIndex = 1;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView_Price_Active")).ActiveViewIndex = 1;
            //((ImageButton)gvApprExpMonthly.Rows[rowIndex].Controls[0].FindControl("btnImgCanCelPrice")).Visible = true;
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
            ((TextBox)gv_detail.Rows[rowIndex].FindControl("txt_OD_Price_ACTIVE")).Text = ((Label)gv_detail.Rows[rowIndex].FindControl("lbl_OD_Price_ACTIVE")).Text;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView2")).ActiveViewIndex = 0;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView3")).ActiveViewIndex = 0;
            ((MultiView)gv_detail.Rows[rowIndex].FindControl("MultiView_Price_Active")).ActiveViewIndex = 0;
        }

        #endregion

        #region Modal Shop

        protected void btnUpdateShopDetail_Click1(object sender, EventArgs e)
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

        //protected void txt_sd_size_TextChanged(object sender, EventArgs e)
        //{
        //    if (ddl_TRANS_METHOD_OTHER.SelectedValue != "-1")
        //    {
        //        if (!Calculation())
        //        {
        //            txt_sd_size.Text = "";
        //        }
        //    }
        //    txt_sd_weight.Focus();
        //    Modal_ShopDetail.Show();
        //}

        //protected void txt_sd_weight_TextChanged(object sender, EventArgs e)
        //{
        //    if (ddl_TRANS_METHOD_OTHER.SelectedValue != "-1")
        //    {
        //        if (!Calculation())
        //        {
        //            txt_sd_weight.Text = "";
        //        }
        //    }
        //    txt_sd_tran_china_price.Focus();
        //    Modal_ShopDetail.Show();
        //}

        public bool Calculation()
        {
            if (ddl_TRANS_METHOD_OTHER.SelectedValue == "4" || ddl_TRANS_METHOD_AirPlane.SelectedValue == "4")
            {
                return true;
            }

            string CONFIG_GROUP = "";
            bool CAL_Q = false;

            if (_VS_TRANSPORT_CH_TH_METHOD == "1" && ddl_TRANS_METHOD_OTHER.SelectedValue == "1") CONFIG_GROUP = "TRANS_SHIP_DRESS_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "1" && ddl_TRANS_METHOD_OTHER.SelectedValue == "2") CONFIG_GROUP = "TRANS_SHIP_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "1" && ddl_TRANS_METHOD_OTHER.SelectedValue == "3")
            {
                CAL_Q = true;
                CONFIG_GROUP = "TRANS_SHIP_Q";
            }
            else if (_VS_TRANSPORT_CH_TH_METHOD == "3" && ddl_TRANS_METHOD_OTHER.SelectedValue == "1") CONFIG_GROUP = "TRANS_CAR_DRESS_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "3" && ddl_TRANS_METHOD_OTHER.SelectedValue == "2") CONFIG_GROUP = "TRANS_CAR_GENERAL";
            else if (_VS_TRANSPORT_CH_TH_METHOD == "3" && ddl_TRANS_METHOD_OTHER.SelectedValue == "3")
            {
                CAL_Q = true;
                CONFIG_GROUP = "TRANS_CAR_Q";
            }
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
            DataSet ds = AdBiz.ADMIN_GET_CONFIG("", CONFIG_GROUP, "BINDDATA", CAL_Q == true ? "-1" : txt_sd_weight.Text.Trim());

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

        #endregion

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOrderList.aspx");
        }

        protected void imgbtn_SendEmail_Click(object sender, ImageClickEventArgs e)
        {
            MadoalPop_Email.Show();

            ucEmail1.SetEmail(lbl_ViewDetail_Email.Text.Trim());
            ucEmail1.SetEmail_To_Enabled();
        }

    }
}