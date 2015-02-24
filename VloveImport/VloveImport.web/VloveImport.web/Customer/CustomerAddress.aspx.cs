using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.Customer
{
    public partial class CustomerAddress : System.Web.UI.Page
    {
        public int _VS_CUS_ADD_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_CUS_ADD_ID"]); }
            set { ViewState["__VS_CUS_ADD_ID"] = value; }
        }

        public int _VS_CUS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_CUS_ID"]); }
            set { ViewState["__VS_CUS_ID"] = value; }
        }

        public string _VS_ACT
        {
            get { return ViewState["__VS_ACT"].ToString(); }
            set { ViewState["__VS_ACT"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustomerData CusData = new CustomerData();
                CusData = (CustomerData)Session["User"];
                this._VS_CUS_ID = 1;//CusData.Cus_ID;
                BinddataRegion("");
                BindData();
            }
        }

        #region BindData Address

        public void ResetBindDataRegion(string BindType = "")
        {
            DataSet ds = new DataSet();
            DataTable tb = new DataTable();
            tb.Columns.Add("ROW_INDEX", typeof(int));
            tb.Columns.Add("ROW_NAME", typeof(string));

            // Here we add five DataRows.
            tb.Rows.Add(-1, "กรุณาเลือก");

            if (BindType == "PROVINCE")
            {
                dll_province.DataValueField = "ROW_INDEX";
                dll_province.DataTextField = "ROW_NAME";
                dll_province.DataSource = tb;
                dll_province.DataBind();
            }
            else if (BindType == "DISTRICT")
            {
                dll_District.DataValueField = "ROW_INDEX";
                dll_District.DataTextField = "ROW_NAME";
                dll_District.DataSource = tb;
                dll_District.DataBind();
            }
            else if (BindType == "SUB_DISTRICT")
            {
                dll_Sub_District.DataValueField = "ROW_INDEX";
                dll_Sub_District.DataTextField = "ROW_NAME";
                dll_Sub_District.DataSource = tb;
                dll_Sub_District.DataBind();
            }
        }

        public void BinddataRegion(string BindType = "")
        {
            DataRow Data_Row;

            DataSet ds;
            commonBiz Com = new commonBiz();

            if (BindType.ToUpper() == "REGION")
            {
                #region REGION
                ds = new DataSet();
                ds = Com.GetData_Region(Act: "REGION");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Data_Row = ds.Tables[0].NewRow();

                    Data_Row["REGION_ID"] = -1;
                    Data_Row["REGION_NAME"] = "กรุณาเลือก";
                    //ds.Tables[0].Rows.Add(Data_Row);
                    ds.Tables[0].Rows.InsertAt(Data_Row, 0);

                    dll_region.DataTextField = "REGION_NAME";
                    dll_region.DataValueField = "REGION_ID";

                    dll_region.DataSource = ds.Tables[0];
                    dll_region.DataBind();

                    ResetBindDataRegion("PROVINCE");
                    ResetBindDataRegion("DISTRICT");
                    ResetBindDataRegion("SUB_DISTRICT");
                }
                #endregion
            }
            else if (BindType.ToUpper() == "PROVINCE")
            {
                #region PROVINCE
                ds = new DataSet();
                ds = Com.GetData_Region(ADD_ID: Convert.ToInt32(dll_region.SelectedValue), Act: "PROVINCE");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Data_Row = ds.Tables[0].NewRow();

                    Data_Row["PROVINCE_ID"] = -1;
                    Data_Row["Province_Name"] = "กรุณาเลือก";
                    ds.Tables[0].Rows.InsertAt(Data_Row, 0);

                    dll_province.DataTextField = "Province_Name";
                    dll_province.DataValueField = "PROVINCE_ID";

                    dll_province.DataSource = ds.Tables[0];
                    dll_province.DataBind();

                    ResetBindDataRegion("DISTRICT");
                    ResetBindDataRegion("SUB_DISTRICT");
                }
                #endregion
            }
            else if (BindType.ToUpper() == "DISTRICT")
            {
                #region DISTRICT
                ds = new DataSet();
                ds = Com.GetData_Region(ADD_ID: Convert.ToInt32(dll_province.SelectedValue), Act: "DISTRICT");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Data_Row = ds.Tables[0].NewRow();

                    Data_Row["DISTRICT_ID"] = -1;
                    Data_Row["DISTRICT_NAME"] = "กรุณาเลือก";
                    ds.Tables[0].Rows.InsertAt(Data_Row, 0);

                    dll_District.DataTextField = "DISTRICT_NAME";
                    dll_District.DataValueField = "DISTRICT_ID";

                    dll_District.DataSource = ds.Tables[0];
                    dll_District.DataBind();

                    ResetBindDataRegion("SUB_DISTRICT");
                }
                #endregion
            }
            else if (BindType.ToUpper() == "SUB_DISTRICT")
            {
                #region SUB_DISTRICT
                ds = new DataSet();
                ds = Com.GetData_Region(ADD_ID: Convert.ToInt32(dll_District.SelectedValue), Act: "SUB_DISTRICT");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Data_Row = ds.Tables[0].NewRow();

                    Data_Row["SUB_DISTRICT_ID"] = -1;
                    Data_Row["SUB_DISTRICT_NAME"] = "กรุณาเลือก";
                    ds.Tables[0].Rows.InsertAt(Data_Row, 0);

                    dll_Sub_District.DataTextField = "SUB_DISTRICT_NAME";
                    dll_Sub_District.DataValueField = "SUB_DISTRICT_ID";

                    dll_Sub_District.DataSource = ds.Tables[0];
                    dll_Sub_District.DataBind();
                }
                #endregion
            }
            else
            {
                ds = new DataSet();
                DataTable tb = new DataTable();
                tb.Columns.Add("ROW_INDEX", typeof(int));
                tb.Columns.Add("ROW_NAME", typeof(string));

                // Here we add five DataRows.
                tb.Rows.Add(-1, "กรุณาเลือก");

                dll_region.DataValueField = "ROW_INDEX";
                dll_region.DataTextField = "ROW_NAME";
                dll_region.DataSource = tb;
                dll_region.DataBind();

                dll_province.DataValueField = "ROW_INDEX";
                dll_province.DataTextField = "ROW_NAME";
                dll_province.DataSource = tb;
                dll_province.DataBind();

                dll_District.DataValueField = "ROW_INDEX";
                dll_District.DataTextField = "ROW_NAME";
                dll_District.DataSource = tb;
                dll_District.DataBind();

                dll_Sub_District.DataValueField = "ROW_INDEX";
                dll_Sub_District.DataTextField = "ROW_NAME";
                dll_Sub_District.DataSource = tb;
                dll_Sub_District.DataBind();
            }
        }

        protected void dll_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            BinddataRegion("PROVINCE");
            ModalPopupExtender1.Show();
        }

        protected void dll_province_SelectedIndexChanged(object sender, EventArgs e)
        {
            BinddataRegion("DISTRICT");
            ModalPopupExtender1.Show();
        }

        protected void dll_District_SelectedIndexChanged(object sender, EventArgs e)
        {
            BinddataRegion("SUB_DISTRICT");
            ModalPopupExtender1.Show();
        }

        #endregion

        public void BindData()
        {
            DataSet ds = new DataSet();
            CustomerBiz CusBiz = new CustomerBiz();
            ds = CusBiz.GetData_Customer_Address(this._VS_CUS_ID, -1, 1, "", "BINDDATA");

            if (ds.Tables[0].Rows.Count > 0)
            {
                gv_cus_address.DataSource = ds.Tables[0];
                gv_cus_address.DataBind();
            }
            else
            {
                gv_cus_address.DataSource = null;
                gv_cus_address.DataBind();
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

        public void ClearData()
        {
            txt_Cusname.Text = "";
            txt_CusDetail.Text = "";
            txt_ZipCode.Text = "";
            dll_region.SelectedIndex = 0;
            dll_province.SelectedIndex = 0;
            dll_District.SelectedIndex = 0;
            dll_Sub_District.SelectedIndex = 0;
        }

        public CustomerData SetData()
        {
            CustomerData EnCus = new CustomerData();
            EnCus.CUS_ADD_ID = this._VS_CUS_ADD_ID;
            if (this._VS_ACT != "DEL")
            {
                EnCus.CUS_ADD_CUS_NAME = txt_Cusname.Text.Trim();
                EnCus.CUS_ADD_ADDRESS_TEXT = txt_CusDetail.Text.Trim();
                EnCus.CUS_ADD_ZIPCODE = Convert.ToInt32(txt_ZipCode.Text.Trim());
                EnCus.CUS_ADD_STATUS = 1;
                EnCus.Cus_ID = this._VS_CUS_ID;
                EnCus.REGION_ID = Convert.ToInt32(dll_region.SelectedValue);
                EnCus.PROVINCE_ID = Convert.ToInt32(dll_province.SelectedValue);
                EnCus.DISTRICT_ID = Convert.ToInt32(dll_District.SelectedValue);
                EnCus.SUB_DISTRICT_ID = Convert.ToInt32(dll_Sub_District.SelectedValue);
                EnCus.Create_User = "Batt";
            }
            return EnCus;
        }

        public bool CheckInput()
        {
            bool IsReturn = false;

            if (txt_Cusname.Text.Trim() == "")
            {

            }

            return IsReturn;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (dll_region.Items.Count == 1)
                BinddataRegion("REGION");

            ClearData();
            _VS_ACT = "INS";
            ModalPopupExtender1.Show();
        }

        protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_cus_address.DataKeys[rowIndex].Values[0].ToString();

            this._VS_CUS_ADD_ID = Convert.ToInt32(DataKeys_ID);
            this._VS_ACT = "UPD";

            DataSet ds = new DataSet();
            CustomerBiz CusBiz = new CustomerBiz();
            ds = CusBiz.GetData_Customer_Address(this._VS_CUS_ID, this._VS_CUS_ADD_ID, 1, "", "BINDDATA_BYID");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txt_Cusname.Text = ds.Tables[0].Rows[0]["CUS_ADD_CUS_NAME"].ToString();
                txt_CusDetail.Text = ds.Tables[0].Rows[0]["CUS_ADD_ADDRESS_TEXT"].ToString();
                txt_ZipCode.Text = ds.Tables[0].Rows[0]["CUS_ADD_ZIPCODE"].ToString();
                BinddataRegion("REGION");
                dll_region.SelectedValue = ds.Tables[0].Rows[0]["REGION_ID"].ToString();
                BinddataRegion("PROVINCE");
                dll_province.SelectedValue = ds.Tables[0].Rows[0]["PROVINCE_ID"].ToString();
                BinddataRegion("DISTRICT");
                dll_District.SelectedValue = ds.Tables[0].Rows[0]["DISTRICT_ID"].ToString();
                BinddataRegion("SUB_DISTRICT");
                dll_Sub_District.SelectedValue = ds.Tables[0].Rows[0]["SUB_DISTRICT_ID"].ToString();
            }

            ModalPopupExtender1.Show();
        }

        protected void btnImgDelete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_cus_address.DataKeys[rowIndex].Values[0].ToString();
            this._VS_CUS_ADD_ID = Convert.ToInt32(DataKeys_ID);
            this._VS_ACT = "DEL";

            CustomerBiz CusBiz = new CustomerBiz();
            string IsReturn = "";
            IsReturn = CusBiz.INS_UPD_Customer_Address(SetData(), this._VS_ACT);
            if (IsReturn != "")
            {
                ShowMessageBox(IsReturn, this.Page);
            }
            else
            {
                BindData();
                ShowMessageBox("บันทึกรายการเรียบร้อยแล้ว", this.Page);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CustomerBiz CusBiz = new CustomerBiz();
            string IsReturn = "";
            IsReturn = CusBiz.INS_UPD_Customer_Address(SetData(), this._VS_ACT);
            if (IsReturn != "")
            {
                ShowMessageBox(IsReturn, this.Page);
            }
            else
            {
                BindData();
                ShowMessageBox("บันทึกรายการเรียบร้อยแล้ว", this.Page);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
            ModalPopupExtender1.Show();
        }

        protected void BtnImgClose_Click(object sender, ImageClickEventArgs e)
        {
            ClearData();
        }

        protected void gv_cus_address_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("btnImgDelete")).Attributes.Add("onClick", "javascript:return confirm('คุณต้องการลบข้อมูลนี้หรือไม่ ?')");
            }
        }

    }
}