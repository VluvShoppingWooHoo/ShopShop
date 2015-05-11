using System;
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
            CheckSession();  
            if (!IsPostBack)
            {                                     
                BindData();
                lbTotal.Text = "0.00 (¥)";
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

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Session.Remove("TRANS");
            Session.Remove("ORDER");
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

                //if (dtSelected.Rows.Count > 10)
                //{
                //    ShowMessageBox("สั่งซื้อได้ไม่เกิน 10 รายการต่อ 1 ใบสั่งซื้อ");
                //    return;
                //}

                double Price = 0, Amount = 0, Total = 0;
                foreach (DataRow dr in dtSelected.Rows)
                {
                    Amount = dr["CUS_BK_AMOUNT"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_AMOUNT"].ToString());
                    Price = dr["CUS_BK_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_PRICE"].ToString());
                    Total = Total + (Amount * Price);
                }

                if (Total < 100)
                {
                    ShowMessageBox("มูลค่าของใบสั่งซื้อไม่ต้ำกว่า 100 หยวน");
                    return;
                }

                Session.Add("ORDER", dtSelected);
                Response.Redirect("CustomerTransport.aspx?Type=" + EncrypData("ORDER"));
            }
        }        

        protected void gvBasket_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (ViewState["SOURCE"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["SOURCE"];
                gvBasket.PageIndex = e.NewPageIndex;
                gvBasket.DataSource = dt;
                gvBasket.DataBind();
            }
        }

        #region Event Gridview
        protected void imbEdit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvA")).ActiveViewIndex = 1;
            ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvB")).ActiveViewIndex = 1;            
        }

        protected void imgbtn_Updateprod_amount_Click(object sender, ImageClickEventArgs e)
        {
            string Result = "";
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            int Amount = ((TextBox)gvBasket.Rows[rowIndex].FindControl("txtAmount")).Text == "" ? 0 : Convert.ToInt32(((TextBox)gvBasket.Rows[rowIndex].FindControl("txtAmount")).Text);
            int BK_ID = ((HiddenField)gvBasket.Rows[rowIndex].FindControl("hdBK_ID")).Value == "" ? 0 : Convert.ToInt32(((HiddenField)gvBasket.Rows[rowIndex].FindControl("hdBK_ID")).Value);

            ShoppingBiz Biz = new ShoppingBiz();
            Result = Biz.UpdateBasketAmount(BK_ID, Amount);
            if (Result == "")
            {
                BindData();
                //ShowMessageBox("Update product amount success", this.Page);
                ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvA")).ActiveViewIndex = 0;
                ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvB")).ActiveViewIndex = 0;
            }
        }

        protected void imgbtn_Cancelprod_amount_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            ((TextBox)gvBasket.Rows[rowIndex].FindControl("txtAmount")).Text = ((Label)gvBasket.Rows[rowIndex].FindControl("lbAmount")).Text;
            ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvA")).ActiveViewIndex = 0;
            ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvB")).ActiveViewIndex = 0;
        }

        protected void cbItemAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb, cbHead;
            cbHead = (CheckBox)sender;
            foreach (GridViewRow gvr in gvBasket.Rows)
            {
                cb = (CheckBox)gvr.Cells[0].FindControl("cbItem");
                if (cb != null)
                    cb.Checked = cbHead.Checked;
                
            }

            CalTotalAmount();
        }

        protected void cbItem_CheckedChanged(object sender, EventArgs e)
        {
            CalTotalAmount();
        }

        protected void CalTotalAmount()
        {
            CheckBox cb;
            Label Price, Amount;
            double Total = 0, dPrice = 0, dAmount = 0;
            foreach (GridViewRow gvr in gvBasket.Rows)
            {
                cb = (CheckBox)gvr.Cells[0].FindControl("cbItem");
                Price = (Label)gvr.Cells[3].FindControl("lbPrice");
                Amount = (Label)gvr.Cells[4].FindControl("lbAmount");

                if (cb != null && cb.Checked)
                {
                    dPrice = Price.Text == "" ? 0 : Convert.ToDouble(Price.Text);
                    dAmount = Amount.Text == "" ? 0 : Convert.ToDouble(Amount.Text);
                    Total = Total + (dPrice * dAmount);
                }
            }

            lbTotal.Text = Total.ToString("###,##0.00") + " (¥)";
        }
        #endregion                       

        protected void imbOrder_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove("TRANS");
            Session.Remove("ORDER");
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

                //if (dtSelected.Rows.Count > 10)
                //{
                //    ShowMessageBox("สั่งซื้อได้ไม่เกิน 10 รายการต่อ 1 ใบสั่งซื้อ");
                //    return;
                //}

                double Price = 0, Amount = 0, Total = 0;
                foreach (DataRow dr in dtSelected.Rows)
                {
                    Amount = dr["CUS_BK_AMOUNT"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_AMOUNT"].ToString());
                    Price = dr["CUS_BK_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_PRICE"].ToString());
                    Total = Total + (Amount * Price);
                }

                if (Total < 100)
                {
                    ShowMessageBox("มูลค่าของใบสั่งซื้อไม่ต้ำกว่า 100 หยวน");
                    return;
                }

                Session.Add("ORDER", dtSelected);
                Response.Redirect("CustomerTransport.aspx?Type=" + EncrypData("ORDER"));
            }
        }
    }
}