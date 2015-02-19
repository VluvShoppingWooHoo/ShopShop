using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;

namespace VloveImport.web.Customer
{
    public partial class CustomerAddress : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BinddataRegion("");
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (dll_region.Items.Count == 1)
                BinddataRegion("REGION");

            ClearData();
            ModalPopupExtender1.Show();
        }

        protected void btnImgEdit_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnImgDelete_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        protected void BtnImgClose_Click(object sender, ImageClickEventArgs e)
        {
            ClearData();
        }

    }
}