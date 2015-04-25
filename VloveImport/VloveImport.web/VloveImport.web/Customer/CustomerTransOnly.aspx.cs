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
    public partial class CustomerTransOnly : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
            if (!IsPostBack)
            {
                string OID = Request.QueryString["OID"] == null ? "" : DecryptData(Request.QueryString["OID"].ToString());
                if (OID != "")
                    BindData(OID);
            }
        }

        protected void BindData(string OID)
        {
            DataTable dt = new DataTable();
            ShoppingBiz biz = new ShoppingBiz();
            Int32 Order_ID = OID == "" ? 0 : Convert.ToInt32(OID);
            dt = biz.GetOrderDetail(Order_ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtTrackingNo.Text = dt.Rows[0]["TRANKING_NO"].ToString();
                txtShopID.Text = dt.Rows[0]["SHOP_ORDER_ID"].ToString();
                txtRemark.Text = dt.Rows[0]["OD_REMARK"].ToString();

                txtTrackingNo.ReadOnly = true;
                txtShopID.ReadOnly = true;
                txtRemark.ReadOnly = true;

                btnTrans.Visible = false;
            }

        }        

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerTransOnlyList.aspx");
        }

        protected void btnTrans_Click(object sender, EventArgs e)
        {
            Session.Remove("TRANS");
            Session.Remove("ORDER");
            List<OrderData> lstData = new List<OrderData>();
            if (ViewState["TRACK"] != null)
            {
                int CusID = GetCusID();
                OrderData data;
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["TRACK"];
                foreach (DataRow dr in dt.Rows)
                {
                    data = new OrderData();
                    data.CUS_ID = GetCusID();
                    data.TRACKING_NO = txtTrackingNo.Text;
                    data.SHOP_ORDER_ID = txtShopID.Text;
                    data.OD_PRICE = 1;
                    data.OD_AMOUNT = 1;
                    data.OD_REMARK = txtRemark.Text;

                    lstData.Add(data);
                }
            }

            Session["ORDER"] = lstData;
            Response.Redirect("CustomerTransport.aspx?Type=" + EncrypData("TRANS"));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            if (ViewState["TRACK"] != null)
            {                
                dt = (DataTable)ViewState["TRACK"];
                dr = dt.NewRow();
                dt.Rows.Add(AddRow(dr));                
                gvTrans.DataSource = dt;
                gvTrans.DataBind();
            }
            else
            {
                dt.Columns.Add("NO");
                dt.Columns.Add("TRACKING_NO");
                dt.Columns.Add("SHOP_ORDER_ID");
                dr = dt.NewRow();
                dt.Rows.Add(AddRow(dr));
            }
            ViewState["TRACK"] = dt;
            gvTrans.DataSource = dt;
            gvTrans.DataBind();

            Reset();
        }

        protected DataRow AddRow(DataRow dr)
        {
            int row = 1;
            row = ViewState["TRACK"] == null ? 1 : ((DataTable)ViewState["TRACK"]).Rows.Count + 1;
            dr["NO"] = row.ToString();
            dr["TRACKING_NO"] = txtTrackingNo.Text;
            dr["SHOP_ORDER_ID"] = txtShopID.Text;
            return dr;
        }

        protected void Reset()
        {
            txtTrackingNo.Text = "";
            txtShopID.Text = "";
            txtRemark.Text = "";
        }

        protected void imbDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imb = (ImageButton)sender;
            if (imb != null && ViewState["TRACK"] != null)
            {
                int row = imb.CommandArgument == "" ? 0 : Convert.ToInt32(imb.CommandArgument);
                DataTable dt = (DataTable)ViewState["TRACK"];
                dt.Rows.RemoveAt(row-1);
            }
        }
    }
}