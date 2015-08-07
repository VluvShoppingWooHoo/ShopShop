using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerOrderDetail : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession(); 
            if (!IsPostBack)
            {
                string OID = Request.QueryString["OID"] == null ? "" : en.DecryptData(Request.QueryString["OID"].ToString());
                if (OID == "")
                    GoToIndex();

                BindData(OID);
            }
        }
        protected void BindData(string Order_ID)
        {
            ShoppingBiz biz = new ShoppingBiz();
            DataTable dt = new DataTable();
            double Order_Pay = 0;
            string Trans = "", Status = "";
            Int32 OID = Order_ID == "" ? 0 : Convert.ToInt32(Order_ID);
            dt = biz.GetOrderDetail(OID);
            if (dt != null && dt.Rows.Count > 0)
            {
                lbOrder_Code.Text = dt.Rows[0]["ORDER_CODE"].ToString();
                lbOrder_Date.Text = Convert.ToDateTime(dt.Rows[0]["ORDER_DATE"].ToString()).ToString("dd/MM/yyyy hh:mm");
                
                lbCusName.Text = dt.Rows[0]["CUS_NAME"].ToString();
                lbMobile.Text = dt.Rows[0]["CUS_MOBILE"].ToString();

                lbAddress.Text = dt.Rows[0]["CUS_ADDRESS"].ToString() == "" ? "&nbsp;" : dt.Rows[0]["CUS_ADDRESS"].ToString();
                Trans = "1. " + dt.Rows[0]["TRANS_CH_TH"].ToString() + "<br/>2. " + dt.Rows[0]["TRANS_TH_CU"].ToString();
                lbOrderTransport.Text = Trans;
                lbOrderAmount.Text = dt.Rows.Count.ToString();
                lbOrderStatus.Text = dt.Rows[0]["ORDER_DESC"].ToString();

                Status = dt.Rows[0]["ORDER_STATUS"].ToString();
                if (!(Status == "3" || Status == "5" || Status == "7"))
                    btnPay.Visible = false;

                Order_Pay = dt.Rows[0]["ORDER_PAY"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["ORDER_PAY"].ToString());
                if (Status == "8" && Order_Pay <= 0)
                    btnPay.Visible = false;

                //Grid                          
                gvOrder.DataSource = dt;   
                gvOrder.DataBind();

                //Add 21/05/2558
                double TotalItem = 0, TotalTrans = 0, Item = 0, Cus = 0, Chi = 0, Thi = 0, Pay_Add = 0, Currency = 0;
                string ShopName = "", OldShopName = "";
                foreach (DataRow dr in dt.Rows)
                {
                    ShopName = dr["SHOPNAME"].ToString();
                    if (ShopName != OldShopName)
                    {
                        Cus = dr["TRANSPORT_CUSTOMER_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["TRANSPORT_CUSTOMER_PRICE"].ToString());
                        Chi = dr["TRANSPORT_CHINA_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["TRANSPORT_CHINA_PRICE"].ToString());
                        Currency = dr["ORDER_CURRENCY"].ToString() == "" ? 0 : Convert.ToDouble(dr["ORDER_CURRENCY"].ToString());
                        Thi = dr["TRANSPORT_THAI_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["TRANSPORT_THAI_PRICE"].ToString());

                        TotalTrans = TotalTrans + Cus + (Chi * Currency) + Thi;
                    }

                    Item = dr["TOTALITEMAMOUNT_TH"].ToString() == "" ? 0 : Convert.ToDouble(dr["TOTALITEMAMOUNT_TH"].ToString());
                    TotalItem = TotalItem + Item;
                    OldShopName = ShopName;
                }
                lbTotalTran.Text = TotalTrans.ToString("###,##0.00");
                lbTotalItemPrice.Text = TotalItem.ToString("###,##0.00");
                Pay_Add = dt.Rows[0]["ORDER_PAY"].ToString() == "" ? 0 : Convert.ToDouble(dt.Rows[0]["ORDER_PAY"].ToString());
                lbPayAdd.Text = Pay_Add < 0 ? "0.00" : Pay_Add.ToString("###,##0.00");
                //Grid
                CustomerBiz biz_Cus = new CustomerBiz();
                DataTable dtTran = biz_Cus.GET_TRANSACTION_BY_ORDERID(OID);
                if (dtTran != null && dtTran.Rows.Count > 0)
                {
                    gvTran.DataSource = dtTran;
                }                 
                else
                    gvTran.DataSource = null;

                gvTran.DataBind();
            }
        }

        protected DataTable GenShopName(DataTable dt)
        {
            string Result = "";
            string ShopName = "", OldShopName = "";
            string Tracking = "", ShopID = "";
            foreach (DataRow dr in dt.Rows)
            {
                ShopName = dr["SHOPNAME"].ToString();
                if(ShopName != OldShopName)
                {
                    Result += "Shop name : " + ShopName + "&nbsp;&nbsp;";
                    Result += "Tracking No. : " + dr["TRACKING_NO"].ToString() + "&nbsp;&nbsp;";
                    Result += "Order ID " + dr["SHOP_ORDER_ID"].ToString() + "&nbsp;&nbsp;";
                }
                OldShopName = ShopName;
            }
            return dt;
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            string Page = Request.QueryString["P"] == null ? "" : DecryptData(Request.QueryString["P"].ToString());
            string OID = Request.QueryString["OID"] == null ? "" : Request.QueryString["OID"].ToString();

            //if(Page == "LIST")
                Redirect("~/Customer/CustomerOrderList.aspx");
            //else
            //    Redirect("~/Customer/CustomerOrderDetail.aspx?OID=" + OID);
        }

        protected void btnPrint_ServerClick(object sender, EventArgs e)
        {
            string Page = Request.QueryString["P"] == null ? "" : DecryptData(Request.QueryString["P"].ToString());
            string OID = Request.QueryString["OID"] == null ? "" : Request.QueryString["OID"].ToString();

            //if(Page == "LIST")
            Redirect("~/Customer/CustomerOrderList.aspx");
            //else
            //    Redirect("~/Customer/CustomerOrderDetail.aspx?OID=" + OID);
        }

        protected void btnPay_ServerClick(object sender, EventArgs e)
        {
            string OID = Request.QueryString["OID"] == null ? "" : Request.QueryString["OID"].ToString();
            Redirect("~/Customer/CustomerPayment.aspx?OID=" + OID);
        }

        //protected void btnPrint_ServerClick(object sender, EventArgs e)
        //{
        //    PDF();
        //}

        protected void gvOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Count = 0;
                string ShopRemark = DataBinder.Eval(e.Row.DataItem, "SHOP_REMARK").ToString();   
                string ShopName = DataBinder.Eval(e.Row.DataItem, "SHOPNAME").ToString();                
                if (ViewState["OldShopName"] == null || ViewState["OldShopName"].ToString() != ShopName)
                {
                    Count = ViewState["Count"] == null ? 1 : Convert.ToInt32(ViewState["Count"]);
                    Label lbShopName = ((Label)e.Row.FindControl("lbShopName"));
                    Label lbRemark = ((Label)e.Row.FindControl("lbRemark"));
                    GridViewRow row = new GridViewRow(e.Row.RowIndex + Count, -1, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.ColumnSpan = gvOrder.Columns.Count;
                    cell.CssClass = "gv-shopname";
                    string ShowShop = "";
                    double China = 0, Thai = 0, Currency = 0;

                    ShowShop += "Shop name : " + DataBinder.Eval(e.Row.DataItem, "SHOPNAME").ToString() + "&nbsp;&nbsp;";
                    ShowShop += "Tracking No. " + DataBinder.Eval(e.Row.DataItem, "TRACKING_NO").ToString() + "&nbsp;&nbsp;";
                    ShowShop += "Order ID " + DataBinder.Eval(e.Row.DataItem, "SHOP_ORDER_ID").ToString() + "&nbsp;&nbsp;";

                    China = DataBinder.Eval(e.Row.DataItem, "TRANSPORT_CHINA_PRICE") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TRANSPORT_CHINA_PRICE").ToString());
                    Currency = DataBinder.Eval(e.Row.DataItem, "ORDER_CURRENCY") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ORDER_CURRENCY").ToString());
                    Thai = DataBinder.Eval(e.Row.DataItem, "TRANSPORT_THAI_PRICE") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TRANSPORT_THAI_PRICE").ToString());
                    ShowShop += "<br/>ค่าขนส่งในจีน " + (China * Currency).ToString("###,##0.00") + " บาท&nbsp;&nbsp;";
                    ShowShop += "ค่าขนส่งระหว่างประเทศ " + Thai.ToString("###,##0.00") + " บาท&nbsp;&nbsp;";
                    ShowShop += "ขนาด " + DataBinder.Eval(e.Row.DataItem, "WEIGHT").ToString() + "&nbsp;&nbsp;";
                    ShowShop += "น้ำหนัก " + DataBinder.Eval(e.Row.DataItem, "SIZE").ToString() + "&nbsp;&nbsp;";

                    lbShopName.Text = ShowShop;
                    cell.Controls.Add(lbShopName);
                    if (ShopRemark != "")
                    {
                        lbRemark.Visible = true;
                        lbRemark.Text = "<br/>หมายเหตุ : <br/>" + ShopRemark;
                        cell.Controls.Add(lbRemark);
                    }

                    row.Cells.Add(cell);
                    row.CssClass = "gv-shopname";
                    ((GridView)sender).Controls[0].Controls.AddAt(e.Row.RowIndex + Count, row);
                    
                    ViewState["OldShopName"] = ShopName;
                    ViewState["Count"] = ++Count;
                }

            }
        }

        protected void PDF()
        {
            MemoryStream ms = new MemoryStream();
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, ms);
            BaseFont bfComic = BaseFont.CreateFont("c:\\windows\\fonts\\Tahoma.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(bfComic, 12);
            //Write Content
            //Init
            Paragraph pf = new Paragraph();

            //Set
            string Header = "";
            pf.Add("สรุปรายการ");
            pf.Add("รหัสใบสั่งซื้อ " + lbOrder_Code.Text + "<br/><br/>");
            pf.Add("วันที่ " + lbOrder_Date.Text + "<br/><br/>");

            //Add Content into PDF
            document.Open();
            document.Add(new Paragraph("สรุปรายการ", font));
            document.Add(new Paragraph("รหัสใบสั่งซื้อ", font));
            document.Add(Chunk.TABBING);
            document.Add(Chunk.TABBING);
            document.Add(new Paragraph(lbOrder_Code.Text));
            document.Add(Chunk.TABBING);
            document.Add(Chunk.TABBING);
            document.Add(Chunk.TABBING);
            document.Add(new Paragraph("วันที่สั่งซื้อ"));
            document.Add(Chunk.TABBING);
            document.Add(Chunk.TABBING);
            document.Add(new Paragraph(lbOrder_Date.Text));
            document.Close();
            writer.Close();
            ms.Close();
            Response.ContentType = "pdf/application";
            Response.AddHeader("content-disposition", "attachment;filename=Order.pdf");
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);

        }

        
    }
}