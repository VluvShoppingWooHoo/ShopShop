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
    public partial class frmTracking : BasePage
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
                ucCalendar1.SET_DATE_DEFAULT();
                BindDDL();
                BindData();
            }

            this.btnSave.Attributes.Add("onClick", "javascript:return confirm('Do you want to save data ?')");
        }

        public void BindDDL()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = new DataTable();
            dt = Biz.GetTransList("TRACKING_STS");
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_TransportName.DataSource = dt;
                ddl_TransportName.DataValueField = "STATUS_NAME";
                ddl_TransportName.DataTextField = "DescRemark";
                ddl_TransportName.DataBind();
            }
            else
            {
                ddl_TransportName.DataSource = null;
                ddl_TransportName.DataBind();
            }
        }

        public void BindData()
        {
            if (Session["T_GRID"] != null)
            {
                List<TrackingData> LstData = (List<TrackingData>)Session["T_GRID"];
                gv_detail.DataSource = LstData;
                gv_detail.DataBind();
            }
            else
            {
                gv_detail.DataSource = null;
                gv_detail.DataBind();
            }
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

        public string Valid()
        {
            string Result = "";
            if (txtTrackingNumber.Text == "")
            {
                Result = Result + "Tracking Number, ";
            }
            if (ucCalendar1.GET_DATE_TO_DATE() == null)
            {
                Result = Result + "Transport Date, ";
            }
            if (txtPackNo.Text == "")
            {
                Result = Result + "Pack No, ";
            }
            return Result;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Result = "";
            if (Session["T_GRID"] != null)
            {
                List<TrackingData> LstData = (List<TrackingData>)Session["T_GRID"];
                AdminBiz biz = new AdminBiz();
                Result = biz.ADMIN_INS_Tracking(LstData);
                if (Result != "")
                {
                    ShowMessageBox("Save Error!!", this);
                    WriteLog("Tracking.aspx", "btnSave", Result);
                }
                else
                {
                    Session.Remove("T_GRID");
                    ShowMessageBox("Save Success!!", this, "frmTrackingList.aspx");
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if (Session["T_GRID"] != null)
            {
                Session["T_GRID"] = null;
                ClearScreen();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string Val = Valid();
            if (Val == "") //Insert Grid
            {
                List<TrackingData> LstData;
                TrackingData data = new TrackingData();
                data.T_TRANSPORT_NAME = ddl_TransportName.SelectedItem.Text;
                data.T_TRANSPORT_VALUE = ddl_TransportName.SelectedValue;
                data.T_TRACKING_NO = txtTrackingNumber.Text;
                data.T_DATE = ucCalendar1.GET_DATE_TO_DATE().Value;
                data.T_WEIGHT = txtWeight.Text == "" ? 0 : Convert.ToDouble(txtWeight.Text);
                data.T_CUBIC = txtCubic.Text == "" ? 0 : Convert.ToDouble(txtCubic.Text);
                data.T_WIDTH = txtWidth.Text == "" ? 0 : Convert.ToDouble(txtWidth.Text);
                data.T_HEIGHT = txtHeight.Text == "" ? 0 : Convert.ToDouble(txtHeight.Text);
                data.T_HIGH = txtHigh.Text == "" ? 0 : Convert.ToDouble(txtHigh.Text);
                data.T_PACK_NO = txtPackNo.Text == "" ? 0 : Convert.ToDouble(txtPackNo.Text);
                data.T_REMARK = txtRemark.Text;
                data.T_TYPE = txtType.Text;
                data.Create_User = _VS_USER_LOGIN;

                if (Session["T_GRID"] != null)
                {
                    LstData = (List<TrackingData>)Session["T_GRID"];
                }
                else
                {
                    LstData = new List<TrackingData>();
                }
                data.T_ID = LstData.Count() + 1;
                LstData.Add(data);
                Session["T_GRID"] = LstData;
                BindData();
                ClearScreen();
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {
                Val = "Please key " + Val.Remove(Val.Length - 2) + ".!!!";
                ShowMessageBox(Val, this);
                return;
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string Val = Valid();
            if (Val == "") //Insert Grid
            {
                if (Session["T_GRID"] != null)
                {
                    int rowIndex = Convert.ToInt32(lbl_header.Text.Remove(0, lbl_header.Text.Length - 2));
                    List<TrackingData> LstData;
                    LstData = (List<TrackingData>)Session["T_GRID"];
                    TrackingData data = LstData.Find(s => s.T_ID.ToString().Equals(rowIndex.ToString()));
                    //TrackingData data = new TrackingData();
                    data.T_TRANSPORT_NAME = ddl_TransportName.SelectedItem.Text;
                    data.T_TRANSPORT_VALUE = ddl_TransportName.SelectedValue;
                    data.T_TRACKING_NO = txtTrackingNumber.Text;
                    data.T_DATE = ucCalendar1.GET_DATE_TO_DATE().Value;
                    data.T_WEIGHT = txtWeight.Text == "" ? 0 : Convert.ToDouble(txtWeight.Text);
                    data.T_CUBIC = txtCubic.Text == "" ? 0 : Convert.ToDouble(txtCubic.Text);
                    data.T_WIDTH = txtWidth.Text == "" ? 0 : Convert.ToDouble(txtWidth.Text);
                    data.T_HEIGHT = txtHeight.Text == "" ? 0 : Convert.ToDouble(txtHeight.Text);
                    data.T_HIGH = txtHigh.Text == "" ? 0 : Convert.ToDouble(txtHigh.Text);
                    data.T_PACK_NO = txtPackNo.Text == "" ? 0 : Convert.ToDouble(txtPackNo.Text);
                    data.T_REMARK = txtRemark.Text;
                    data.T_TYPE = txtType.Text;
                    data.Create_User = _VS_USER_LOGIN;

                    Session["T_GRID"] = LstData;
                    BindData();
                    ClearScreen();
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    lbl_header.Text = "Add Tracking";
                }
                else
                {
                    Val = "Session Timeout.!!!";
                    ShowMessageBox(Val, this);
                    return;
                }
            }
            else
            {
                Val = "Please key " + Val.Remove(Val.Length - 2) + ".!!!";
                ShowMessageBox(Val, this);
                return;
            }
        }

        protected void ClearScreen()
        {
            ddl_TransportName.SelectedIndex = 0;
            txtTrackingNumber.Text = "";
            //ucCalendar1.SET_DATE_DEFAULT();
            txtPackNo.Text = "";
            txtWeight.Text = "";
            txtCubic.Text = "";
            txtWidth.Text = "";
            txtHeight.Text = "";
            txtHigh.Text = "";
            txtType.Text = "";
            txtRemark.Text = "";
        }

        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            HiddenField hdT_ID = (HiddenField)gv_detail.Rows[rowIndex].FindControl("hdT_ID");
            if (Session["T_GRID"] != null && hdT_ID != null)
            {
                List<TrackingData> LstData = (List<TrackingData>)Session["T_GRID"];
                if (LstData != null)
                {
                    TrackingData data = LstData.Find(s => s.T_ID.ToString().Equals(hdT_ID.Value));
                    if (data != null)
                    {
                        ddl_TransportName.SelectedIndex = ddl_TransportName.Items.IndexOf(ddl_TransportName.Items.FindByValue(data.T_TRANSPORT_VALUE));
                        txtTrackingNumber.Text = data.T_TRACKING_NO;
                        ucCalendar1.SET_DATE(data.T_DATE);
                        txtPackNo.Text = data.T_PACK_NO.ToString();
                        txtWeight.Text = data.T_WEIGHT.ToString();
                        txtCubic.Text = data.T_CUBIC.ToString();
                        txtWidth.Text = data.T_WIDTH.ToString();
                        txtHeight.Text = data.T_HEIGHT.ToString();
                        txtHigh.Text = data.T_HIGH.ToString();
                        txtType.Text = data.T_TYPE;
                        txtRemark.Text = data.T_REMARK;

                        btnAdd.Visible = false;
                        btnUpdate.Visible = true;
                        lbl_header.Text = "Update Tracking : " + (rowIndex + 1).ToString();
                        gv_detail.Rows[rowIndex].Cells[0].ForeColor = System.Drawing.Color.Yellow;
                    }
                }
            }
        }

        protected void imgBtn_Delete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            HiddenField hdT_ID = (HiddenField)gv_detail.Rows[rowIndex].FindControl("hdT_ID");
            if (Session["T_GRID"] != null && hdT_ID != null)
            {
                List<TrackingData> LstData = (List<TrackingData>)Session["T_GRID"];
                if (LstData != null)
                {
                    TrackingData data = LstData.Find(s => s.T_ID.ToString().Equals(hdT_ID.Value));
                    if (data != null)
                        LstData.Remove(data);
                }
                Session["T_GRID"] = LstData;
                ShowMessageBox("Delete Success!!", this);
                BindData();
            }
            else
            {
                ShowMessageBox("Error Session Timeout!!", this);
                return;
            }
        }


    }
}