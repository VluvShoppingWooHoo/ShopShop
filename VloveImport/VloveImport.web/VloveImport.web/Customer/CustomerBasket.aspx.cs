﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerBasket : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession();                       
                BindData();
            }
        }

        protected void BindData()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = Biz.GetBasketList(GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {
                gvBasket.DataSource = dt;
                ViewState["SOURCE"] = dt;
            }
            else
            {
                gvBasket.DataSource = null;
                ViewState["SOURCE"] = null;
            }

            gvBasket.DataBind();
        }

        protected void btnOrder_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("ORDER");
            //string Selected = "";
            CheckBox cb;
            HiddenField hd;
            DataTable dtSelected = new DataTable();
            if (ViewState["SOURCE"] != null)
            {
                dtSelected = ((DataTable)ViewState["SOURCE"]).Copy();
                foreach (GridViewRow gvr in gvBasket.Rows)
                {
                    cb = new CheckBox();
                    hd = new HiddenField();
                    cb = (CheckBox)gvr.FindControl("cbItem");
                    if (cb != null && !cb.Checked)
                    {
                        hd = (HiddenField)gvr.FindControl("hdBK_ID");
                        dtSelected.Rows.Remove(dtSelected.Select("CUS_BK_ID=" + hd.Value).FirstOrDefault());                        
                    }
                }

                if (dtSelected.Rows.Count == 0)
                {
                    ShowMessageBox("กรุณาเลือกรายการที่ต้องการสั่งซื้อ");
                    return;
                }
                Session.Add("ORDER", dtSelected);
                EncrypUtil en = new EncrypUtil();
                string CUS_ID = GetCusID().ToString();
                CUS_ID = en.EncrypData(CUS_ID);
                Response.Redirect("CustomerTransport.aspx?CID=" + CUS_ID);
            }
        }

    }
}