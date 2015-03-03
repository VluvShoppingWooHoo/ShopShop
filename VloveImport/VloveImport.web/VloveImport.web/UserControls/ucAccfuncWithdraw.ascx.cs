using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.UserControls
{
    public partial class ucAccfuncWithdraw : System.Web.UI.UserControl
    {
        public int _VS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_ID"]); }
            set { ViewState["__VS_ID"] = value; }
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
                //BindData_BANK();
            }
        }

        public void BindData_BANK()
        {
            DataSet ds = new DataSet();
            CustomerBiz CusBiz = new CustomerBiz();
            ds = CusBiz.GET_CUSTOMER_ACCOUNT_BANK(this._VS_CUS_ID, -1, 1, "BINDDATA_DROPDOWN");

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow Data_Row;
                Data_Row = ds.Tables[0].NewRow();

                Data_Row["CUS_ACC_NAME_ID"] = -1;
                Data_Row["CUS_ACC_DETAIL"] = "กรุณาเลือก";
                ds.Tables[0].Rows.InsertAt(Data_Row, 0);

                ddl_account_name.DataTextField = "CUS_ACC_DETAIL";
                ddl_account_name.DataValueField = "CUS_ACC_NAME_ID";

                ddl_account_name.DataSource = ds.Tables[0];
                ddl_account_name.DataBind();
            }
        }

        protected void btnSaveUcWithdraw_ServerClick(object sender, EventArgs e)
        {
            BindData_BANK();
            //return "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindData_BANK();
        }


    }
}