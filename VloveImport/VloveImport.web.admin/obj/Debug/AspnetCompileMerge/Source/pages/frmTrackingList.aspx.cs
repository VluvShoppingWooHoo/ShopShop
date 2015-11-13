using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.web.admin.App_Code;

namespace VloveImport.web.admin.pages
{
    public partial class frmTrackingList : BasePage
    {

        util.EncrypUtil Enc = new util.EncrypUtil();

        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        public int _VS_GROUP_ID
        {
            get { return ViewState["__VS_GROUP_ID"] == null ? -1 : Convert.ToInt32(ViewState["__VS_GROUP_ID"].ToString()); }
            set { ViewState["__VS_GROUP_ID"] = value; }
        }

        public int _VS_USER_ID
        {
            get { return Request.QueryString["UID"] == null ? 0 : Convert.ToInt32(Enc.DecryptData(Request.QueryString["UID"])); }
            set { ViewState["__VS_USER_ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
            AdminUserData Data = new AdminUserData();
            Data = (AdminUserData)(Session["AdminUser"]);
            _VS_USER_LOGIN = Data.USERNAME;

            if (!IsPostBack)
            {
                ucCalendar1.SET_DATE(DateTime.Now.AddDays(-7));
                ucCalendar2.SET_DATE_DEFAULT();
                BindData();
                BindDDL();
            }

            //this.btnUpdate.Attributes.Add("onClick", "javascript:return confirm('Do you want to update data ?')");
        }

        public void ShowMessageBox(string message, Page currentPage, string redirectNamePage = "")
        {
            string msgboxScript = "alert('" + message + "');";

            string redirectPage = "";
            if (redirectNamePage != "")
            {
                redirectPage = "window.location='" + redirectNamePage + "';";
            }

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript + redirectPage, true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv_detail.Rows)
            {
                DropDownList ddl_T_STATUS = row.FindControl("ddl_T_STATUS") as DropDownList;
                TextBox txt_T_NO = row.FindControl("txt_T_NO") as TextBox;
                Label lb_T_STATUS = row.FindControl("lb_T_STATUS") as Label;
                Label lb_T_NO = row.FindControl("lb_T_NO") as Label;
                ddl_T_STATUS.Visible = true;
                txt_T_NO.Visible = true;
                lb_T_STATUS.Visible = false;
                lb_T_NO.Visible = false;
            }
            btnSave.Visible = true;
            btnAdd.Visible = false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("T_ID");
            dt.Columns.Add("T_TRACKING_NO");
            dt.Columns.Add("TD_STATUS_ID");

            AdminBiz biz = new AdminBiz();
            foreach (GridViewRow row in gv_detail.Rows)
            {
                HiddenField hdT_ID = row.FindControl("hdT_ID") as HiddenField;
                TextBox txt_T_NO = row.FindControl("txt_T_NO") as TextBox;
                DropDownList ddl_T_STATUS = row.FindControl("ddl_T_STATUS") as DropDownList;
                DataRow dr = dt.NewRow();
                dr["T_ID"] = hdT_ID.Value;
                dr["T_TRACKING_NO"] = txt_T_NO.Text;
                dr["TD_STATUS_ID"] = ddl_T_STATUS.SelectedValue;
                dt.Rows.Add(dr);
            }

            string Result = biz.ADMIN_UPD_Tracking(dt);
            if (Result != "")
            {
                ShowMessageBox("Save Error!!", this);
                WriteLog("TrackingList.aspx", "btnSave", Result);
            }
            else
            {
                ShowMessageBox("Save Success!!", this, "frmTrackingList.aspx");
            }
        }

        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            util.EncrypUtil En = new util.EncrypUtil();
            Response.Redirect("frmTracking.aspx?TID=" + Server.UrlEncode(En.EncrypData(DataKeys_ID)));
        }

        public void BindDDL()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = new DataTable();
            dt = Biz.GetTransList("TRACKING_STS");
            foreach (GridViewRow row in gv_detail.Rows)
            {
                DropDownList ddl_T_STATUS = row.FindControl("ddl_T_STATUS") as DropDownList;
                Label lb_T_STATUS = row.FindControl("lb_T_STATUS") as Label;
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_T_STATUS.DataSource = dt;
                    ddl_T_STATUS.DataValueField = "STATUS_NAME";
                    ddl_T_STATUS.DataTextField = "DescRemark";
                    ddl_T_STATUS.DataBind();
                    int i = 0, index = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["DescRemark"].ToString() == lb_T_STATUS.Text.Replace("<br/>", ":"))
                        { index = i; break; }
                        i++;
                    }
                    ddl_T_STATUS.SelectedIndex = index;
                }
                else
                {
                    ddl_T_STATUS.DataSource = null;
                    ddl_T_STATUS.DataBind();
                }
            }
        }

        protected void BindData()
        {
            DateTime From = ucCalendar1.GET_DATE_TO_DATE() == null ? DateTime.MinValue : ucCalendar1.GET_DATE_TO_DATE().Value;
            DateTime To = ucCalendar2.GET_DATE_TO_DATE() == null ? DateTime.MaxValue : ucCalendar2.GET_DATE_TO_DATE().Value;
            if (txtTracking.Text.Trim() != "" || From != null || To != null)
            {
                DataTable dt = new DataTable();
                ShoppingBiz biz = new ShoppingBiz();
                dt = biz.GetTrackingAdmin(txtTracking.Text.Trim(), From, To.AddDays(1));
                if (dt != null && dt.Rows.Count > 0)
                {
                    gv_detail.DataSource = dt;
                    gv_detail.DataBind();
                }
                else
                {
                    gv_detail.DataSource = null;
                    gv_detail.DataBind();
                }
            }
        }
    }
}