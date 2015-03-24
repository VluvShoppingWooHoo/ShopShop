using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.admin.pages
{
    public partial class frmOrder : System.Web.UI.Page
    {
        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        public string _VS_ORDER_ID
        {
            get { return ViewState["__VS_ORDER_ID"].ToString(); }
            set { ViewState["__VS_ORDER_ID"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _VS_USER_LOGIN = "admin";
                BindData_order_status(ddl_ViewDetail_ORDER_STATUS);
                BindData_transport_status(ddl_ViewDetail_TRANSPORT_STATUS);

                util.EncrypUtil En = new util.EncrypUtil();
                _VS_ORDER_ID = En.DecryptData(Request.QueryString["OID"]);
                BindData();
            }
        }

        public void BindData_order_status(DropDownList ddl, string ddlType = "")
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("ORDER_STS", "BIND_DDL");

            ddl.DataValueField = "S_ID";
            ddl.DataTextField = "S_NAME";
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            if (ddlType == "S") ddl.Items.Insert(0, new ListItem("แสดงทั้งหมด", "-1"));
            else if (ddlType == "A") ddl.Items.Insert(0, new ListItem("กรุณาเลือก", "-1"));
        }

        public void BindData_transport_status(DropDownList ddl, string ddlType = "")
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("TRANSPORT", "BIND_DDL");

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
                lbl_ViewDetail_ORDER_ID.Text = ds.Tables[0].Rows[0]["ORDER_CODE"].ToString();
                lbl_ViewDetail_ORDER_DATE.Text = ds.Tables[0].Rows[0]["ORDER_DATE_TEXT"].ToString();
                lbl_ViewDetail_TRANSPORT_1.Text = ds.Tables[0].Rows[0]["TRANSPORT_CHINA_TEXT"].ToString();
                lbl_ViewDetail_TRANSPORT_2.Text = ds.Tables[0].Rows[0]["TRANSPORT_THAI_TEXT"].ToString();
                lbl_ViewDetail_ADDRESS.Text = ds.Tables[0].Rows[0]["CUS_REC_NAME"].ToString() + "<br/>" + ds.Tables[0].Rows[0]["CUS_ADDRESS"].ToString();
                lbl_ViewDetail_EMP_NAME.Text = ds.Tables[0].Rows[0]["UPDATE_USER"].ToString();
                lbl_ViewDetail_EMP_UPDATE_DATE.Text = ds.Tables[0].Rows[0]["EMP_UPDATE_DATE"].ToString();

                ddl_ViewDetail_ORDER_STATUS.SelectedValue = ds.Tables[0].Rows[0]["ORDER_STATUS"].ToString();
                ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue = ds.Tables[0].Rows[0]["TRANSPORT_STATUS"].ToString();

                #endregion

                #region Customer Data
                lbl_ViewDetail_CusCode.Text = ds.Tables[0].Rows[0]["CUS_CODE"].ToString();
                lbl_ViewDetail_CusName.Text = ds.Tables[0].Rows[0]["CUS_FULLNAME"].ToString();
                lbl_ViewDetail_Telphone.Text = ds.Tables[0].Rows[0]["CUS_MOBILE"].ToString();
                lbl_ViewDetail_Email.Text = ds.Tables[0].Rows[0]["CUS_EMAIL"].ToString();
                lbl_ViewDetail_Total_Amount.Text = ds.Tables[0].Rows[0]["CUS_TOTAL_AMOUNT"].ToString(); 
                #endregion

                gv_detail_prod_view.DataSource = ds.Tables[0];
                gv_detail_prod_view.DataBind();
                gv_detail_prod_Edit.DataSource = ds.Tables[0];
                gv_detail_prod_Edit.DataBind();
            }
            else
            {
                gv_detail_prod_view.DataSource = null;
                gv_detail_prod_view.DataBind();
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
            OrderData En = new OrderData();
            AdminBiz AdBiz = new AdminBiz();
            En.Create_User = _VS_USER_LOGIN;

            En.ORDER_STATUS = Convert.ToInt32(ddl_ViewDetail_ORDER_STATUS.SelectedValue);
            En.ORDER_ID = Convert.ToInt32(_VS_ORDER_ID);
            string Result_order = AdBiz.UPD_ADMIN_ORDER(En, "UPDATE_STS_ORDER");

            En.ORDER_STATUS = Convert.ToInt32(ddl_ViewDetail_TRANSPORT_STATUS.SelectedValue);
            string Result_transport = AdBiz.UPD_ADMIN_ORDER(En, "UPDATE_STS_TRANSPORT");

            if (Result_order == "" && Result_transport == "")
            {
                DataSet ds = AdBiz.GET_ADMIN_ORDER("BINDDATA_BYID", Convert.ToInt32(_VS_ORDER_ID));
                gv_detail_prod_view.DataSource = ds.Tables[0];
                gv_detail_prod_view.DataBind();
                gv_detail_prod_Edit.DataSource = ds.Tables[0];
                gv_detail_prod_Edit.DataBind();

                ShowMessageBox("ทำรายการเรียบร้อยแล้ว", this.Page);
            }
            else
            {
                ShowMessageBox(Server.HtmlEncode("ERROR ORDER : " + Result_order + "  ERROR TRANSPORT : " + Result_transport), this.Page);
            }
        }

        protected void btnEditProd_num_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void btnEditProd_num_save_Click(object sender, EventArgs e)
        {
            AdminBiz AdBiz;
            string Result = "";

            for (int i = 0; i <= gv_detail_prod_Edit.Rows.Count - 1; i++)
            {
                TextBox txtprodnum = (TextBox)gv_detail_prod_Edit.Rows[i].Cells[5].FindControl("gv_detail_prod_Edit_txt");
                int PROD_NUM = Convert.ToInt32(gv_detail_prod_Edit.Rows[i].Cells[4].Text);
                if (Convert.ToInt32(txtprodnum.Text) > PROD_NUM)
                {
                    ShowMessageBox("กรุณาตรวจสอบจำนวนสินค้าอีกครั้ง", this.Page);
                    return;
                }
            }

            for (int i = 0; i <= gv_detail_prod_Edit.Rows.Count - 1; i++)
            {
                AdBiz = new AdminBiz();
                TextBox txtprodnum = (TextBox)gv_detail_prod_Edit.Rows[i].Cells[5].FindControl("gv_detail_prod_Edit_txt");
                int ORDER_ID = Convert.ToInt32(gv_detail_prod_Edit.DataKeys[i].Values[0].ToString());
                int ORDER_DETAIL_ID = Convert.ToInt32(gv_detail_prod_Edit.DataKeys[i].Values[6].ToString());

                int PROD_NUM = txtprodnum.Text == "" ? 0 : Convert.ToInt32(txtprodnum.Text);

                Result += AdBiz.UPD_ADMIN_ORDER_PROD_AMOUNT(ORDER_ID, ORDER_DETAIL_ID, PROD_NUM, _VS_USER_LOGIN, "UPD_PROD_AMOUNT");
            }

            if (Result == "")
            {
                AdBiz = new AdminBiz();
                Result = AdBiz.UPD_ADMIN_ORDER_PROD_AMOUNT(Convert.ToInt32(_VS_ORDER_ID), -1, -1, _VS_USER_LOGIN, "UPD_CAL_PROD_AMOUNT");

                if (Result == "")
                {
                    BindData();
                    MultiView1.ActiveViewIndex = 0;
                    ShowMessageBox("ทำรายการเรียบร้อยแล้ว", this.Page);
                }
                else ShowMessageBox(Server.HtmlEncode(Result), this.Page);                
            }
            else ShowMessageBox(Server.HtmlEncode(Result), this.Page);

        }

        protected void btnEditProd_num_cancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}