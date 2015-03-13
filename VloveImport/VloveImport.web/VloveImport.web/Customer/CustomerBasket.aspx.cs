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

namespace VloveImport.web.Customer
{
    public partial class CustomerBasket : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CID = "0";// Request.QueryString["CID"] == null ? "" : en.DecryptData(Request.QueryString["CID"].ToString());
                if (CID == "")
                    Response.Redirect("CustomerBasket.aspx");
                BindData();
            }
        }

        protected void BindData()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = Biz.GetBasketList(0);
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
            string Selected = "";
            CheckBox cb;
            HiddenField hd;
            DataTable dtSelected = new DataTable();
            if (ViewState["SOURCE"] != null)
            {
                dtSelected = (DataTable)ViewState["SOURCE"];
                foreach (GridViewRow gvr in gvBasket.Rows)
                {
                    cb = new CheckBox();
                    hd = new HiddenField();
                    cb = (CheckBox)gvr.FindControl("cbItem");
                    if (cb != null && !cb.Checked)
                    {
                        hd = (HiddenField)gvr.FindControl("hdBK_ID");
                        dtSelected.Rows.Remove(dtSelected.Select("CUS_BK_ID=" + hd.Value).FirstOrDefault());
                        //Selected = Selected + hd.Value + ",";

                    }
                }
                Session.Add("ORDER", Selected);
                EncrypUtil en = new EncrypUtil();
                string CUS_ID = "0";//SessionUser
                CUS_ID = en.EncrypData(CUS_ID);
                Response.Redirect("CustomerTranspot.aspx?CID=" + CUS_ID);
            }
        }

    }
}