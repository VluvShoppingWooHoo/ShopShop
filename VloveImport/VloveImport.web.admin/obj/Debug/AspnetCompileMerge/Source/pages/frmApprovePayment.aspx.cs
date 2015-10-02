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
    public partial class frmApprovePayment : System.Web.UI.Page
    {

        public string _VS_USER_LOGIN
        {
            get { return ViewState["__VS_USER_LOGIN"].ToString(); }
            set { ViewState["__VS_USER_LOGIN"] = value; }
        }

        public int _VS_USER_EMP_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_USER_EMP_ID"].ToString()); }
            set { ViewState["__VS_USER_EMP_ID"] = value; }
        }

        public int _VS_TRAN_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_TRAN_ID"].ToString()); }
            set { ViewState["__VS_TRAN_ID"] = value; }
        }

        public int _VS_TRAN_STATUS
        {
            get { return Convert.ToInt32(ViewState["__VS_TRAN_STATUS"].ToString()); }
            set { ViewState["__VS_TRAN_STATUS"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AdminUserData Data = new AdminUserData();
                Data = (AdminUserData)(Session["AdminUser"]);
                _VS_USER_LOGIN = Data.USERNAME;
                _VS_USER_EMP_ID = Data.EMP_ID;

                ucCalendar1.SET_DATE(DateTime.Now.AddMonths(-1));
                ucCalendar2.ClearData();
                BindData_Transaction_status(ddlTranSactionStatus, "S");
                BindData_Transaction_TYPE(ddlTranSactionType, "S");
                BindData_Transaction_status(ddlview_Tran_Status, "A", "BIND_DDL_STS_IN");
                BindData();
            }

            btnUpdateRemark.Attributes.Add("onClick", "javascript:return confirm('คุณต้องการบันทึกรายการนี้หรือไม่ ?')");
            ucApprovePaymentDetail1.ucApprovePaymentDetail_OpenpopClick += new System.EventHandler(ucApprovePaymentDetail1_OpenpopClick);
        }

        public void ucApprovePaymentDetail1_OpenpopClick(object sender, System.EventArgs e)
        {
            ModalPopupExtender3.Show();
        }

        public void BindData_Transaction_status(DropDownList ddl, string ddlType = "",string Act = "")
        {
            string STS_NAME = "";

            if (Act == "") Act = "BIND_DDL";
            else if (Act == "BIND_DDL_STS_IN") STS_NAME = "2,3";

            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("TRANS_STS", Act, STS_NAME);

            ddl.DataValueField = "S_ID";
            ddl.DataTextField = "S_NAME";
            ddl.DataSource = ds.Tables[0];
            ddl.DataBind();
            if (ddlType == "S") ddl.Items.Insert(0, new ListItem("แสดงทั้งหมด", "-1"));
            else if (ddlType == "A") ddl.Items.Insert(0, new ListItem("กรุณาเลือก", "-1"));
        }

        public void BindData_Transaction_TYPE(DropDownList ddl, string ddlType = "")
        {
            AdminBiz AddBiz = new AdminBiz();
            DataSet ds = AddBiz.GET_MASTER_STATUS("TRANS_TYPE", "BIND_DDL");

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

            try
            {
                AdminBiz AdBiz = new AdminBiz();
                ds = AdBiz.GET_ADMIN_TRANSACTION(-1, ucCalendar1.GET_DATE_TO_DATE(), ucCalendar2.GET_DATE_TO_DATE(), txtCusCode.Text.Trim(), Convert.ToInt32(ddlTranSactionStatus.SelectedValue), Convert.ToInt32(ddlTranSactionType.SelectedValue), -1, "BINDDATA");

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

        internal List<TransactionData> Get_Gridview_Detail(GridView gv)
        {
            List<TransactionData> List_En = new List<TransactionData>();
            TransactionData En;

            if (gv.Rows.Count > 0)
            {
                for (int i = 0; i <= gv.Rows.Count - 1; i++)
                {
                    En = new TransactionData();
                    //TRAN_ID,TRAN_DATE_TEXT,TRAN_AMOUNT,TRAN_STATUS_TEXT,CUS_CODE,EMP_NAME,TRAN_STATUS,TRAN_TYPE,TRAN_TABLE_TYPE,TRAN_TYPE_TEXT,TRAN_TABLE_TYPE_TEXT
                    En.TRAN_ID = Convert.ToInt32(gv.DataKeys[i].Values[0].ToString());
                    En.TRAN_DATE_TEXT = gv.DataKeys[i].Values[1].ToString();
                    En.TRAN_AMOUNT = Convert.ToDouble(gv.DataKeys[i].Values[2].ToString());
                    En.TRAN_STATUS_TEXT = gv.DataKeys[i].Values[3].ToString();
                    En.Cus_Code = gv.DataKeys[i].Values[4].ToString();
                    En.EMP_NAME = gv.DataKeys[i].Values[5].ToString();
                    En.TRAN_STATUS = Convert.ToInt32(gv.DataKeys[i].Values[6].ToString());
                    En.TRAN_TYPE = Convert.ToInt32(gv.DataKeys[i].Values[7].ToString());
                    En.TRAN_TABLE_TYPE = Convert.ToInt32(gv.DataKeys[i].Values[8].ToString());
                    En.TRAN_TYPE_TEXT = gv.DataKeys[i].Values[9].ToString();
                    En.TRAN_TABLE_TYPE_TEXT = gv.DataKeys[i].Values[10].ToString();
                    List_En.Add(En);
                }
            }

            return List_En;
        }

        internal List<TransactionData> AddIndex(List<TransactionData> List_En)
        {
            int j = 0;
            for (int i = 0; i <= List_En.Count - 1; i++)
            {
                j = j + 1;
                List_En[i].ROW_INDEX = j;
            }
            return List_En;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlTranSactionStatus.SelectedIndex = 0;
            ddlTranSactionType.SelectedIndex = 0;
            txtCusCode.Text = "";
            ucCalendar1.ClearData();
            ucCalendar2.ClearData();
            ucCalendar1.SET_DATE(DateTime.Now.AddMonths(-1));
        }

        protected void btnSelectOrder_Click(object sender, EventArgs e)
        {
            if (gv_detail_view.Rows.Count > 0)
            {
                ModalPopupExtender1.Show();
            }
            else ShowMessageBox("ยังไม่มีรายการที่เลือก", this.Page);
        }

        #region Event Gridview

        protected void imgBtn_choose_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            if (gv_detail_view.Rows.Count < 20)
            {
                List<TransactionData> ListEn = new List<TransactionData>();
                ListEn = Get_Gridview_Detail(gv_detail_view);
                TransactionData En = new TransactionData();

                En = new TransactionData();
                //TRAN_ID,TRAN_DATE_TEXT,TRAN_AMOUNT,TRAN_STATUS_TEXT,CUS_CODE,EMP_NAME,TRAN_STATUS,TRAN_TYPE,TRAN_TABLE_TYPE,TRAN_TYPE_TEXT,TRAN_TABLE_TYPE_TEXT
                En.TRAN_ID = Convert.ToInt32(gv_detail.DataKeys[rowIndex].Values[0].ToString());
                En.TRAN_DATE_TEXT = gv_detail.DataKeys[rowIndex].Values[1].ToString();
                En.TRAN_AMOUNT = Convert.ToDouble(gv_detail.DataKeys[rowIndex].Values[2].ToString());
                En.TRAN_STATUS_TEXT = gv_detail.DataKeys[rowIndex].Values[3].ToString();
                En.Cus_Code = gv_detail.DataKeys[rowIndex].Values[4].ToString();
                En.EMP_NAME = gv_detail.DataKeys[rowIndex].Values[5].ToString();
                En.TRAN_STATUS = Convert.ToInt32(gv_detail.DataKeys[rowIndex].Values[6].ToString());
                En.TRAN_TYPE = Convert.ToInt32(gv_detail.DataKeys[rowIndex].Values[7].ToString());
                En.TRAN_TABLE_TYPE = Convert.ToInt32(gv_detail.DataKeys[rowIndex].Values[8].ToString());
                En.TRAN_TYPE_TEXT = gv_detail.DataKeys[rowIndex].Values[9].ToString();
                En.TRAN_TABLE_TYPE_TEXT = gv_detail.DataKeys[rowIndex].Values[10].ToString();
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
            string TRAN_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();
            List<TransactionData> ListEn = new List<TransactionData>();
            ListEn = Get_Gridview_Detail(gv_detail_view);

            for (int i = 0; i <= ListEn.Count - 1; i++)
            {
                if (TRAN_ID == ListEn[i].TRAN_ID.ToString())
                {
                    ListEn.RemoveAt(i);
                    break;
                }
            }

            gv_detail_view.DataSource = AddIndex(ListEn);
            gv_detail_view.DataBind();

            BindData();
        }

        public void UPDATE_TRAN_STATUS(int TRAN_ID,int TRAN_STATUS,string TRAN_EMP_REMARK)
        { 
            string Result = "";
            TransactionData En = new TransactionData();
            string Act = "UPD_EMP_APPROVE";
            AdminBiz AdBiz = new AdminBiz();

            En.TRAN_ID = TRAN_ID;
            En.EMP_ID_APPROVE = Convert.ToInt32(_VS_USER_EMP_ID);
            En.TRAN_STATUS = TRAN_STATUS;
            En.EMP_REMARK = TRAN_EMP_REMARK;

            Result = AdBiz.INS_UPD_TRANSACTION(En, Act);
            if (Result == "")
            {
                BindData();

                txtEmpRemark.Text = "";

                ShowMessageBox("ทำรายการเรียบร้อยแล้ว", this.Page);
            }
            else
            {
                ShowMessageBox(Server.HtmlEncode(Result), this.Page);
                ModalPopupExtender2.Show();
            }
        }

        protected void imgBtn_view_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            int TRAN_ID = Convert.ToInt32(this.gv_detail.DataKeys[rowIndex].Values[0].ToString());
            ModalPopupExtender3.Show();
            ucApprovePaymentDetail1.BindData(TRAN_ID);
        }

        protected void imgBtn_Approve_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            _VS_TRAN_ID = Convert.ToInt32(this.gv_detail.DataKeys[rowIndex].Values[0].ToString());
            _VS_TRAN_STATUS = 2;
            ModalPopupExtender2.Show();
        }

        protected void imgBtn_Reject_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            _VS_TRAN_ID = Convert.ToInt32(this.gv_detail.DataKeys[rowIndex].Values[0].ToString());
            _VS_TRAN_STATUS = 3;
            ModalPopupExtender2.Show();
        }

        protected void imgBtn_gvDetail_cancel_choose_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            List<TransactionData> ListEn = new List<TransactionData>();
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

        protected void gv_detail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void gv_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            List<TransactionData> ListEn = new List<TransactionData>();
            ListEn = Get_Gridview_Detail(gv_detail_view);

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string TRAN_ID = DataBinder.Eval(e.Row.DataItem, "TRAN_ID").ToString();
                int TRAN_STATUS = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TRAN_STATUS").ToString());

                if (TRAN_STATUS == 1)
                {
                    ((ImageButton)e.Row.FindControl("imgBtn_choose")).Visible = true; 
                    ((ImageButton)e.Row.FindControl("imgBtn_Approve")).Visible = true;
                    ((ImageButton)e.Row.FindControl("imgBtn_Reject")).Visible = true;
                    ((Label)e.Row.FindControl("lbl_gv_tran_status")).Visible = false;

                    if (ListEn.Count > 0)
                    {
                        for (int i = 0; i <= ListEn.Count - 1; i++)
                        {
                            if (TRAN_ID == ListEn[i].TRAN_ID.ToString())
                            {
                                ((ImageButton)e.Row.FindControl("imgBtn_choose")).Visible = false;
                                ((ImageButton)e.Row.FindControl("imgBtn_cancel_choose")).Visible = true;

                                ((ImageButton)e.Row.FindControl("imgBtn_Approve")).Visible = false;
                                ((ImageButton)e.Row.FindControl("imgBtn_Reject")).Visible = false;

                                e.Row.CssClass = "label-SELECT";
                                break;
                            }
                        }
                    }

                }
                else
                {
                    ((ImageButton)e.Row.FindControl("imgBtn_choose")).Visible = false; 
                    ((ImageButton)e.Row.FindControl("imgBtn_Approve")).Visible = false;
                    ((ImageButton)e.Row.FindControl("imgBtn_Reject")).Visible = false;
                    ((Label)e.Row.FindControl("lbl_gv_tran_status")).Visible = true;
                }

            }
        }

        protected void gv_detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_detail.PageIndex = e.NewPageIndex;
            BindData();
        }

        #endregion

        protected void BtnImgClose_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnUpdateRemark_Click(object sender, EventArgs e)
        {
            UPDATE_TRAN_STATUS(_VS_TRAN_ID, _VS_TRAN_STATUS,txtEmpRemark.Text.Trim());         
        }

        protected void btnResetRemark_Click(object sender, EventArgs e)
        {
            txtEmpRemark.Text = "";
            ModalPopupExtender2.Hide();
        }

        protected void btnView_Update_Click(object sender, EventArgs e)
        {
            string Result = "";

            if (ddlview_Tran_Status.SelectedValue == "-1")
            {
                ModalPopupExtender1.Show();
                ShowMessageBox("กรุณาเลือก Transaction Status", this.Page);
                
                return;
            }

            if (gv_detail_view.Rows.Count > 0)
            {
                TransactionData En = new TransactionData();
                for (int i = 0; i <= gv_detail_view.Rows.Count - 1; i++)
                {
                    En.TRAN_ID_LIST += gv_detail_view.DataKeys[i].Values[0].ToString() + ",";
                }

                En.TRAN_ID_LIST = En.TRAN_ID_LIST.Remove(En.TRAN_ID_LIST.Length - 1);
                En.EMP_ID_APPROVE = Convert.ToInt32(_VS_USER_EMP_ID);
                En.TRAN_STATUS = Convert.ToInt32(ddlview_Tran_Status.SelectedValue);
                En.EMP_REMARK = txtview_EMP_Remark.Text.Trim();

                AdminBiz AdBiz = new AdminBiz();
                Result = AdBiz.INS_UPD_TRANSACTION(En, "UPD_EMP_APPROVE_LIST");
                if (Result == "")
                {
                    gv_detail_view.DataSource = null;
                    gv_detail_view.DataBind();
                    BindData();

                    ddlview_Tran_Status.SelectedIndex = 0;
                    txtview_EMP_Remark.Text = "";

                    ShowMessageBox("ทำรายการเรียบร้อยแล้ว", this.Page);
                }
                else
                {
                    ModalPopupExtender1.Show();
                    ShowMessageBox(Server.HtmlEncode(Result), this.Page);
                }
            }
        }

    }
}