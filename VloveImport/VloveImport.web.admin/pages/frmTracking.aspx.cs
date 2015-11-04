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

namespace VloveImport.web.admin.pages
{
    public partial class frmTracking : System.Web.UI.Page
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
            AdminUserData Data = new AdminUserData();
            Data = (AdminUserData)(Session["AdminUser"]);
            _VS_USER_LOGIN = Data.USERNAME;

            if (!IsPostBack)
            {
                BindDDL();
                //BindData();
                
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
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = new DataSet();
            ds = AddBiz.GET_ADMIN_GET_USER(_VS_USER_ID, "", "", -1, "BINDDATA_BYID");            

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
                Result = Result + "Pack Number, ";
            }
            return Result;
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Val = Valid();
            if (Val == "") //Insert
            {
                TrackingData data = new TrackingData();
                data.T_TRANSPORT_NAME = ddl_TransportName.SelectedValue;
                data.T_TRACKING_NO = txtTrackingNumber.Text;
                data.T_DATE = ucCalendar1.GET_DATE_TO_DATE().Value;
                data.T_WEIGHT = Convert.ToDouble(txtWeight.Text);
                data.T_CUBIC = Convert.ToDouble(txtWeight.Text);
                data.T_HEIGHT = Convert.ToDouble(txtWeight.Text);
                data.T_WIDTH = Convert.ToDouble(txtWeight.Text);
                data.T_HIGH = Convert.ToDouble(txtWeight.Text);
                data.T_PACK_NO = Convert.ToDouble(txtWeight.Text);
                data.T_REMARK = txtRemark.Text;
                data.T_TYPE = txtType.Text;
                AdminBiz biz = new AdminBiz();
                biz.ADMIN_INS_Tracking(data);
            }
            else
            {
                Val = "Please key " + Val.Remove(Val.Length-2) + ".!!!";
                ShowMessageBox(Val, this);
                return;
            }
            
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            
        }

    }
}