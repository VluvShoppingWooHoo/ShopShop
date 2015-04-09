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

                if (dtSelected.Rows.Count > 10)
                {
                    ShowMessageBox("สั่งซื้อได้ไม่เกิน 10 รายการต่อ 1 ใบสั่งซื้อ");
                    return;
                }

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
                EncrypUtil en = new EncrypUtil();
                string CUS_ID = GetCusID().ToString();
                CUS_ID = en.EncrypData(CUS_ID);
                Response.Redirect("CustomerTransport.aspx?CID=" + CUS_ID);
            }
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

            //lbTotal.Text = Total.ToString("###,###.00") + "หยวน";
        }
    }
}