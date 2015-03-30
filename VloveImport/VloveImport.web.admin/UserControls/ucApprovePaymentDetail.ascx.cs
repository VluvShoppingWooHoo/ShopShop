﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;

namespace VloveImport.web.admin.UserControls
{
    public partial class ucApprovePaymentDetail : System.Web.UI.UserControl
    {
        public string _VS_TRAN_ID
        {
            get { return ViewState["__VS_TRAN_ID"].ToString(); }
            set { ViewState["__VS_TRAN_ID"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindData(int TRAN_ID)
        {
            DataSet ds = new DataSet();

            AdminBiz AdBiz = new AdminBiz();
            ds = AdBiz.GET_ADMIN_TRANSACTION(TRAN_ID, null,null, "", -1, -1, -1, "BINDDATA_BYID");

            if (ds.Tables[0].Rows.Count > 0)
            {
                #region ORDER DATA
                lblDetail_TranName.Text = ds.Tables[0].Rows[0]["TRAN_TABLE_TYPE_TEXT"].ToString();
                lblDetail_TranType.Text = ds.Tables[0].Rows[0]["TRAN_TYPE_TEXT"].ToString();
                lblDetail_TranDate.Text = ds.Tables[0].Rows[0]["TRAN_DATE_TEXT"].ToString();
                lblDetail_TranAmount.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["TRAN_AMOUNT"].ToString()).ToString("N", new CultureInfo("en-US"));
                lblDetail_TranDetail.Text = ds.Tables[0].Rows[0]["TRAN_DETAIL_TEXT"].ToString();
                lblDetail_TranRemark.Text = ds.Tables[0].Rows[0]["TRAN_REMARK_TEXT"].ToString();
                lblDetail_TranStatus.Text = ds.Tables[0].Rows[0]["TRAN_STATUS_TEXT"].ToString();

                lblDetail_EmpName.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
                lblDetail_EmpUpdateDate.Text = ds.Tables[0].Rows[0]["EMP_APPROVE_DATE_TEXT"].ToString();
                lblDetail_EmpRemark.Text = ds.Tables[0].Rows[0]["EMP_REMARK"].ToString();

                #endregion

                #region Customer Data
                lbl_ViewDetail_CusCode.Text = ds.Tables[0].Rows[0]["CUS_CODE"].ToString();
                lbl_ViewDetail_CusName.Text = ds.Tables[0].Rows[0]["CUS_FULLNAME"].ToString();
                lbl_ViewDetail_Telphone.Text = ds.Tables[0].Rows[0]["CUS_MOBILE"].ToString();
                lbl_ViewDetail_Email.Text = ds.Tables[0].Rows[0]["CUS_EMAIL"].ToString();
                lbl_ViewDetail_Total_Amount.Text = ds.Tables[0].Rows[0]["CUS_TOTAL_AMOUNT"].ToString();
                #endregion

            }
        }

    }
}