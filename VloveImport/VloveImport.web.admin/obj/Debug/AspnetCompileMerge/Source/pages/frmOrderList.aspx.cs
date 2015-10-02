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
    public partial class frmOrderList : System.Web.UI.Page
    {
        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminUserData Data = new AdminUserData();
                Data = (AdminUserData)(Session["AdminUser"]);
                _VS_USER_LOGIN = Data.USERNAME;

                BindData_order_status(ddl_search_order_status, "S");
                ddl_search_order_status.SelectedValue = "4";
                ucCalendar1.SET_DATE(DateTime.Now.AddMonths(-1));
                ucCalendar2.SET_DATE_DEFAULT();
                BindData();
            }
            btnclearOrder.Attributes.Add("onClick", "javascript:return confirm('Do you want to cancel order ?')");
        }

        public void BindData_order_status(DropDownList ddl, string ddlType = "")
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("ORDER_STS", "BIND_DDL");

            ddl.DataValueField = "S_ID";
            ddl.DataTextField = "S_NAME";
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            if (ddlType == "S") ddl.Items.Insert(0, new ListItem("Show all", "-1"));
            else if (ddlType == "A") ddl.Items.Insert(0, new ListItem("Please select", "-1"));
        }

        public void BindData_transport_status(DropDownList ddl, string ddlType = "")
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("TRANSPORT", "BIND_DDL");

            ddl.DataValueField = "S_ID";
            ddl.DataTextField = "S_NAME";
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            if (ddlType == "S") ddl.Items.Insert(0, new ListItem("Show all", "-1"));
            else if (ddlType == "A") ddl.Items.Insert(0, new ListItem("Please select", "-1"));
        }

        public void BindData()
        {
            DataSet ds = new DataSet();

            try
            {
                AdminBiz AdBiz = new AdminBiz();
                ds = AdBiz.GET_ADMIN_ORDER("BINDDATA", START_DATE: ucCalendar1.GET_DATE_TO_DATE(), END_DATE: ucCalendar2.GET_DATE_TO_DATE(), CUS_NAME: txtCusCode.Text.Trim(), ORDER_STATUS: Convert.ToInt32(ddl_search_order_status.SelectedValue),ORDER_CODE:txtOrderCode.Text.Trim());

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
            catch (Exception ex)
            {
                //Label4.Text = ex.Message;
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        #region Event Gridview

        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            util.EncrypUtil En = new util.EncrypUtil();
            Response.Redirect("frmOrder_TEMP.aspx?OID=" + Server.UrlEncode(En.EncrypData(DataKeys_ID)));
        }

        protected void imgBtn_delete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();
            OrderData En = new OrderData();
            string Act = "DELETE";
            AdminBiz AdBiz = new AdminBiz();
            En.Create_User = _VS_USER_LOGIN;
            En.ORDER_ID = Convert.ToInt32(DataKeys_ID);
            string Result = AdBiz.UPD_ADMIN_ORDER(En, Act);
            if (Result == "")
            {
                BindData();
                ShowMessageBox("ทำรายการเรียบร้อยแล้ว", this.Page);
            }
            else
            {
                ShowMessageBox(Server.HtmlEncode(Result), this.Page);
            }

        }

        protected void imgBtn_choose_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            if (gv_detail_view.Rows.Count < 20)
            {
                List<OrderData> ListEn = new List<OrderData>();
                ListEn = Get_Gridview_Detail(gv_detail_view);
                OrderData En = new OrderData();

                En = new OrderData();
                //ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE,CUS_CODE,ORDER_CODE,TRANSPORT_STATUS_TEXT,SUM_PROD_PRICE_ACTIVE
                En.ORDER_ID = Convert.ToInt32(gv_detail.DataKeys[rowIndex].Values[0].ToString());
                En.ORDER_DATE_TEXT = gv_detail.DataKeys[rowIndex].Values[1].ToString();
                En.CUS_FULLNAME = gv_detail.DataKeys[rowIndex].Values[2].ToString();
                En.ORDER_STATUS_TEXT = gv_detail.DataKeys[rowIndex].Values[3].ToString();
                En.EMP_NAME = gv_detail.DataKeys[rowIndex].Values[4].ToString();
                En.SUM_PROD_PRICE = Convert.ToDouble(gv_detail.DataKeys[rowIndex].Values[5].ToString());
                En.CUS_CODE = gv_detail.DataKeys[rowIndex].Values[6].ToString();
                En.ORDER_CODE = gv_detail.DataKeys[rowIndex].Values[7].ToString();
                En.TRANSPORT_STATUS_TEXT = gv_detail.DataKeys[rowIndex].Values[8].ToString();
                En.SUM_PROD_PRICE_ACTIVE = Convert.ToDouble(gv_detail.DataKeys[rowIndex].Values[9].ToString());
                En.ORDER_STATUS = Convert.ToInt32(gv_detail.DataKeys[rowIndex].Values[10].ToString());
                ListEn.Add(En);

                gv_detail_view.DataSource = AddIndex(ListEn);
                gv_detail_view.DataBind();

                BindData();
            }
            else ShowMessageBox("กรุณาทำการทีละไม่เกิน 20 รายการ", this.Page);
        }

        protected void imgBtn_cancel_choose_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string ORDER_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();
            List<OrderData> ListEn = new List<OrderData>();
            ListEn = Get_Gridview_Detail(gv_detail_view);

            for (int i = 0; i <= ListEn.Count - 1; i++)
            {
                if (ORDER_ID == ListEn[i].ORDER_ID.ToString())
                {
                    ListEn.RemoveAt(i);
                    break;
                }
            }

            gv_detail_view.DataSource = AddIndex(ListEn);
            gv_detail_view.DataBind();

            BindData();

        }

        protected void imgBtn_gv_view_delete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            List<OrderData> ListEn = new List<OrderData>();
            ListEn = Get_Gridview_Detail(gv_detail_view);
            if (ListEn.Count > 0)
            {
                ListEn.RemoveAt(rowIndex);
                gv_detail_view.DataSource = AddIndex(ListEn);
                gv_detail_view.DataBind();

                if (ListEn.Count > 0) ModalPopupExtender1.Show();
                BindData();
            }
        }

        internal List<OrderData> AddIndex(List<OrderData> List_En)
        {
            int j = 0;
            for (int i = 0; i <= List_En.Count - 1; i++)
            {
                j = j + 1;
                List_En[i].ROW_INDEX = j;
            }
            return List_En;
        }

        internal List<OrderData> Get_Gridview_Detail(GridView gv)
        {
            List<OrderData> List_En = new List<OrderData>();
            OrderData En;

            if (gv.Rows.Count > 0)
            {
                for (int i = 0; i <= gv.Rows.Count - 1; i++)
                {
                    En = new OrderData();
                    //ORDER_ID,ORDER_DATE_TEXT,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE,CUS_CODE,ORDER_CODE,TRANSPORT_STATUS_TEXT,SUM_PROD_PRICE_ACTIVE
                    En.ORDER_ID = Convert.ToInt32(gv.DataKeys[i].Values[0].ToString());
                    En.ORDER_DATE_TEXT = gv.DataKeys[i].Values[1].ToString();
                    En.CUS_FULLNAME = gv.DataKeys[i].Values[2].ToString();
                    En.ORDER_STATUS_TEXT = gv.DataKeys[i].Values[3].ToString();
                    En.EMP_NAME = gv.DataKeys[i].Values[4].ToString();
                    En.SUM_PROD_PRICE = Convert.ToDouble(gv.DataKeys[i].Values[5].ToString());
                    En.CUS_CODE = gv.DataKeys[i].Values[6].ToString();
                    En.ORDER_CODE = gv.DataKeys[i].Values[7].ToString();
                    En.TRANSPORT_STATUS_TEXT = gv.DataKeys[i].Values[8].ToString();
                    En.SUM_PROD_PRICE_ACTIVE = Convert.ToDouble(gv.DataKeys[i].Values[9].ToString());
                    En.ORDER_STATUS = Convert.ToInt32(gv.DataKeys[i].Values[10].ToString());
                    List_En.Add(En);
                }
            }

            return List_En;
        }


        #endregion

        protected void btnSelectOrder_Click(object sender, EventArgs e)
        {
            if (gv_detail_view.Rows.Count > 0)
            {
                ModalPopupExtender1.Show();
            }
            else ShowMessageBox("ยังไม่มีรายการที่เลือก", this.Page);
        }

        protected void btnclearOrder_Click(object sender, EventArgs e)
        {
            AdminBiz AdBiz = new AdminBiz();
            OrderData En = new OrderData();
            En.Create_User = this._VS_USER_LOGIN;
            AdBiz.UPD_ADMIN_ORDER(En, "CANCEL_ORDER_OVER_DATE");
            BindData();
        }

        protected void gv_detail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgBtn_delete")).Attributes.Add("onClick", "javascript:return confirm('Do you want to cancel order ?')");
            }
        }

        protected void gv_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<OrderData> ListEn = new List<OrderData>();
            ListEn = Get_Gridview_Detail(gv_detail_view);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ORDER_ID = DataBinder.Eval(e.Row.DataItem, "ORDER_ID").ToString();
                int ORDER_STATUS = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ORDER_STATUS").ToString());

                ((ImageButton)e.Row.FindControl("imgBtn_delete")).Visible = false;

                if (ListEn.Count > 0)
                {
                    for (int i = 0; i <= ListEn.Count - 1; i++)
                    {
                        if (ORDER_ID == ListEn[i].ORDER_ID.ToString())
                        {
                            ((ImageButton)e.Row.FindControl("imgBtn_choose")).Visible = false;
                            ((ImageButton)e.Row.FindControl("imgBtn_cancel_choose")).Visible = true;
                            e.Row.CssClass = "label-SELECT";
                            break;
                        }
                    }
                }
            }
        }

        protected void gv_detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_detail.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ucCalendar1.SET_DATE(DateTime.Now.AddMonths(-1));
            ucCalendar2.ClearData();
            txtCusCode.Text = "";
            ddl_search_order_status.SelectedIndex = 0;
        }

        protected void ddl_choose_status_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_choose_status_order.SelectedValue == "1")
            {
                BindData_order_status(ddl_choose_sub_status);
            }
            else if (ddl_choose_status_order.SelectedValue == "2")
            {
                BindData_transport_status(ddl_choose_sub_status);
            }
            ModalPopupExtender1.Show();
        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (ddl_choose_status_order.SelectedValue == "-1")
            {
                ShowMessageBox("Please select update status", this.Page);
                ModalPopupExtender1.Show();
            }
            else
            {
                if (gv_detail_view.Rows.Count > 0)
                {
                    OrderData En = new OrderData();
                    for (int i = 0; i <= gv_detail_view.Rows.Count - 1; i++)
                    {
                        En.ORDER_ID_LIST += gv_detail_view.DataKeys[i].Values[0].ToString() + ",";
                    }

                    En.ORDER_ID_LIST = En.ORDER_ID_LIST.Remove(En.ORDER_ID_LIST.Length - 1);
                    string Act = "";
                    if (ddl_choose_status_order.SelectedValue == "1") Act = "UPDATE_STS_SPLIT_ORDER"; //สถานะการสั่งซื้อ
                    else if (ddl_choose_status_order.SelectedValue == "2") Act = "UPDATE_STS_SPLIT_TRANSPORT"; //สถานะการส่งสินค้า
                    AdminBiz AdBiz = new AdminBiz();
                    En.ORDER_STATUS = Convert.ToInt32(ddl_choose_sub_status.SelectedValue);
                    En.Create_User = _VS_USER_LOGIN;
                    string Result = AdBiz.UPD_ADMIN_ORDER(En, Act);
                    if (Result == "")
                    {
                        gv_detail_view.DataSource = null;
                        gv_detail_view.DataBind();
                        BindData();

                        ShowMessageBox("Save success", this.Page);
                    }
                    else
                    {
                        ShowMessageBox(Server.HtmlEncode(Result), this.Page);
                        ModalPopupExtender1.Show();
                    }
                }
            }
        }
        
    }
}