﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.data.Extension;

namespace VloveImport.web.admin.pages
{
    public partial class frmSummaryVIP : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            try
            {
                AdminBiz AddBiz = new AdminBiz();
                DataSet ds = new DataSet();
                ds = AddBiz.ADMIN_GET_VIP_TOTAL();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["tblVIP"] = ds.Tables[0];
                    gv_detail.DataSource = ds.Tables[0];
                    gv_detail.DataBind();
                }
                else
                {
                    gv_detail.DataSource = null;
                    gv_detail.DataBind();
                }
            }
            catch (Exception ex) { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["tblVIP"];
            AdminBiz AddBiz = new AdminBiz();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["VIP_PERCENT"] = ((TextBox)gv_detail.Rows[i].Cells[0].FindControl("txtPercent")).Text;
            }
            string Result = AddBiz.ADMIN_UPD_VIP_PERCENT(dt);
            Response.Redirect("frmIndex.aspx");
        }
    }
}