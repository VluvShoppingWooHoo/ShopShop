﻿using System;
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
    public partial class frmOrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindData()
        {
            DataSet ds = new DataSet();

            AdminBiz AdBiz = new AdminBiz();
            ds = AdBiz.GET_ADMIN_ORDER("BINDDATA");

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

        public void ShowMessageBox(string message, Page currentPage)
        {
            string msgboxScript = "alert('" + message + "');";

            if ((ScriptManager.GetCurrent(currentPage) != null))
            {
                ScriptManager.RegisterClientScriptBlock(currentPage, currentPage.GetType(), "msgboxScriptAJAX", msgboxScript, true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        #region Event Gridview

        protected void imgBtn_edit_Click(object sender, ImageClickEventArgs e)
        {
            Modal_Detail.Show();
        }

        protected void imgBtn_delete_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void imgBtn_choose_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            string DataKeys_ID = this.gv_detail.DataKeys[rowIndex].Values[0].ToString();

            if (gv_detail_view.Rows.Count < 20)
            {
                List<OrderData> ListEn = new List<OrderData>();
                ListEn = Get_Gridview_Detail(gv_detail_view);
                OrderData En = new OrderData();

                En = new OrderData();
                //ORDER_ID,ORDER_DATE,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE
                En.ORDER_ID = Convert.ToInt32(gv_detail.DataKeys[rowIndex].Values[0].ToString());
                En.ORDER_DATE_TEXT = gv_detail.DataKeys[rowIndex].Values[1].ToString();
                En.CUS_FULLNAME = gv_detail.DataKeys[rowIndex].Values[2].ToString();
                En.ORDER_STATUS_TEXT = gv_detail.DataKeys[rowIndex].Values[3].ToString();
                En.EMP_NAME = gv_detail.DataKeys[rowIndex].Values[4].ToString();
                En.SUM_PROD_PRICE = gv_detail.DataKeys[rowIndex].Values[5].ToString();
                ListEn.Add(En);

                gv_detail_view.DataSource = AddIndex(ListEn);
                gv_detail_view.DataBind();
            }
            else ShowMessageBox("กรุณาทำการทีละไม่เกิน 20 รายการ", this.Page);       
        }

        protected void imgBtn_gv_view_delete_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent).RowIndex;
            List<OrderData> ListEn = new List<OrderData>();
            ListEn = Get_Gridview_Detail(gv_detail_view);
            if (ListEn.Count > 0)
            {
                ListEn.RemoveAt(rowIndex);
                gv_detail_view.DataSource = AddIndex(ListEn);
                gv_detail_view.DataBind();
            }

            ModalPopupExtender1.Show();
        }

        internal List<OrderData> AddIndex(List<OrderData> List_En)
        {
            int j = 0;
            for (int i = 0; i <= List_En.Count - 1; i++)
            {
                j = j + 1;
                List_En[i].ROW_INDEX = j;
            }
            return List_En;
        }

        internal List<OrderData> Get_Gridview_Detail(GridView gv)
        {
            List<OrderData> List_En = new List<OrderData>();
            OrderData EnMa;

            if (gv.Rows.Count > 0)
            {
                for (int i = 0; i <= gv.Rows.Count - 1; i++)
                {
                    EnMa = new OrderData();
                    //ORDER_ID,ORDER_DATE,CUS_FULLNAME,ORDER_STATUS_TEXT,EMP_NAME,SUM_PROD_PRICE
                    EnMa.ORDER_ID = Convert.ToInt32(gv.DataKeys[i].Values[0].ToString());
                    EnMa.ORDER_DATE_TEXT = gv.DataKeys[i].Values[1].ToString();
                    EnMa.CUS_FULLNAME = gv.DataKeys[i].Values[2].ToString();
                    EnMa.ORDER_STATUS_TEXT = gv.DataKeys[i].Values[3].ToString();
                    EnMa.EMP_NAME = gv.DataKeys[i].Values[4].ToString();
                    EnMa.SUM_PROD_PRICE = gv.DataKeys[i].Values[5].ToString();
                    List_En.Add(EnMa);
                }
            }

            return List_En;
        }


        #endregion

        protected void btnSelectOrder_Click(object sender, EventArgs e)
        {
            if (gv_detail_view.Rows.Count > 0)
            {
                ModalPopupExtender1.Show();
            }
            else ShowMessageBox("ยังไม่มีรายการที่เลือก", this.Page);            
        }

        protected void btnclearOrder_Click(object sender, EventArgs e)
        {
            AdminBiz AdBiz = new AdminBiz();
            OrderData En = new OrderData();
            AdBiz.UPD_ADMIN_ORDER(En, "CANCEL_ORDER_OVER_DATE");
        }

        protected void gv_detail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((ImageButton)e.Row.FindControl("imgBtn_delete")).Attributes.Add("onClick", "javascript:return confirm('คุณต้องการยกเลิกรายการสั่งซื้อนี้หรือไม่ ?')");
            }
        }

        protected void gv_detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[4].Text = "Example" + DataBinder.Eval(e.Row.DataItem, "EMAILPATTERN").ToString();
            }
        }

        protected void gv_detail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gv_detail.PageIndex = e.NewPageIndex;
            BindData();
        }

    }
}