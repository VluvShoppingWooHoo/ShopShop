using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerConfirmInfo : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
            if (!IsPostBack)
            {
                if (Session["ORDER"] == null)
                    GoToIndex();

                string Type = Request.QueryString["Type"] == null ? "" : DecryptData(Request.QueryString["Type"].ToString());
                BindDataGrid(Type);
                BindDataTrans();
                BindDataSummary(Type);
            }
        }

        protected void BindDataGrid(string Type)
        {
            switch (Type)
            {
                case "ORDER":
                    if (Session["ORDER"] != null)
                    {
                        DataTable dtSelected = (DataTable)Session["ORDER"];
                        if (dtSelected != null && dtSelected.Rows.Count > 0)
                            gvBasket.DataSource = dtSelected;
                        else
                            gvBasket.DataSource = null;

                        gvBasket.DataBind();
                        gvBasket.Visible = true;
                        Order.Visible = true;
                    }
                    break;
                case "PI":
                    if (Session["ORDER"] != null)
                    {
                        string FileName = Session["PICPI"] == null ? "" : Session["PICPI"].ToString();   
                        OrderData data = (OrderData)Session["ORDER"];
                        if (data != null)
                        {
                            lbPINo.Text = data.OD_ITEMNAME;
                            lbAmount.Text = data.OD_AMOUNT.ToString();
                            imgURL.ImageUrl = "~/Attachment/PI/" + FileName;

                            mView.Visible = true;
                            mView.ActiveViewIndex = 0;
                            PI.Visible = true;
                        }
                    }
                    break;
                case "TRANS":
                    if (Session["ORDER"] != null)
                    {
                        List<OrderData> lstData = (List<OrderData>)Session["ORDER"];
                        if (lstData != null && lstData.Count > 0)
                        {
                            gvTrans.DataSource = lstData;
                            gvTrans.DataBind();

                            mView.Visible = true;
                            mView.ActiveViewIndex = 1;
                            Trans.Visible = true;
                        }
                    }
                    break;
                default:
                    GoToIndex();
                    break;
            }

        }
        protected void BindDataTrans()
        {
            if (Session["TRANS"] != null)
            {
                string Trans = Session["TRANS"].ToString();
                string[] spl = Trans.Split(',');

                lbgroup1.Text = spl[0].Split('|')[1];
                lbgroup2.Text = spl[1].Split('|')[1] + " " + Session["OTHER"].ToString();
                lbgroup3.Text = spl[2].Split('|')[1];

            }
            else
            {
                //Error
            }
        }
        protected void BindDataSummary(string Type)
        {
            string Post = "";
            double Total_Amount = 0, Price = 0, Amount = 0, Transport_Amount = 0, Rate = 0, Charge = 0, Post_d = 0;
            Rate = GetRateCurrency();            

            switch (Type)
            {
                case "ORDER":
                    DataTable dtSelected = (DataTable)Session["ORDER"];
                    foreach (DataRow dr in dtSelected.Rows)
                    {
                        Amount = dr["CUS_BK_AMOUNT"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_AMOUNT"].ToString());
                        Price = dr["CUS_BK_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_PRICE"].ToString());
                        Total_Amount = Total_Amount + (Amount * (Price * Rate));
                    }

                    string Trans = Session["TRANS"].ToString();
                    string[] spl = Trans.Split(',');
                    if (spl[1].Split('|')[1] == "ส่งไปรษณีย์" || spl[1].Split('|')[1] == "ส่งแบบลงทะเบียน" || spl[1].Split('|')[1] == "EMS")
                    {
                        Post = " + 250.00 ";
                        Post_d = 250;
                    }

                    

                    Transport_Amount = Total_Amount * 10 / 100;
                    lbPayOrder.Text = "ชำระเงินรอบแรก = " + Total_Amount.ToString("###,##0.00") + " + " + Transport_Amount.ToString("###,##0.00") + Post;

                    //VIP
                    double DiscountVIP = 0;
                    if (GetCusSession().Cus_VIP_Percent > 0 && (spl[1].Split('|')[1] == "ส่งไปรษณีย์" || spl[1].Split('|')[1] == "ส่งแบบลงทะเบียน" || spl[1].Split('|')[1] == "EMS"))
                    {
                        DiscountVIP = 50;
                        lbPayOrderVIP.Text = "ได้รับส่วนลดค่าบริการ 50.00 บาท จากการเป็นสมาชิก VIP ";
                        lbPayOrder.Text = lbPayOrder.Text + " - 50.00";
                    }

                    lbPayOrder.Text = lbPayOrder.Text + " = " + (Total_Amount + Transport_Amount + Post_d - DiscountVIP).ToString("###,##0.00") + " บาท";
                    
                    break;

                case "PI":
                    string[] Config = Get_Config("CHARGE");
                    if (Config != null && Config.Length > 0)
                        Charge = Convert.ToDouble(Config[0]);

                    lbPI.Text = Charge.ToString("###,##0.00");
                    OrderData data = (OrderData)Session["ORDER"];
                    Amount = data.OD_PRICE * Rate;
                    Transport_Amount = Amount * 10 / 100;
                    lbPayPI.Text = "ชำระเงินรอบแรก = " + Amount.ToString("###,##0.00") + " + " + Transport_Amount.ToString("###,##0.00")
                         + " + " + Charge.ToString("###,##0.00");

                    lbPayPI.Text = lbPayPI.Text + " = " + (Amount + Transport_Amount + Charge).ToString("###,##0.00") + " บาท";
                    break;

                case "TRANS":
                    //List<OrderData> lstdata = (List<OrderData>)Session["ORDER"];
                    //Transport_Amount = lstdata[0].OD_PRICE * 10 / 100;
                    //lbPayTrans.Text = "ชำระเงินรอบแรก = " + lstdata[0].OD_PRICE.ToString("###,##0.00") + " + " + Transport_Amount.ToString("###,##0.00")
                    //    + " = " + (lstdata[0].OD_PRICE + Transport_Amount).ToString("###,##0.00") + " บาท";
                    break;
            }
        }

        protected void btnConfirm_ServerClick(object sender, EventArgs e)
        {
            string Type = Request.QueryString["Type"] == null ? "" : DecryptData(Request.QueryString["Type"].ToString());
            switch (Type)
            {
                case "ORDER":
                    SaveOrder();
                    break;
                case "PI":
                    SavePI();
                    break;
                case "TRANS":
                    SaveTrans();
                    break;
            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            string Type = Request.QueryString["Type"] == null ? "" : DecryptData(Request.QueryString["Type"].ToString());
            Response.Redirect("CustomerTransport.aspx?Type=" + EncrypData(Type));
        }

        #region SaveData
        protected void SaveOrder()
        {
            if (Session["TRANS"] != null && Session["ORDER"] != null)
            {
                string[] Result;
                string Trans = Session["TRANS"].ToString();
                string[] spl = Trans.Split(',');
                DataTable dt = (DataTable)Session["ORDER"];
                string User = GetCusCode();
                double Rate = GetRateCurrency();
                double Trans_price = 0, Service = 0;
                double DiscountVIP = 0;
                string VIP = "";

                if (spl[1].Split('|')[1] == "ส่งไปรษณีย์" || spl[1].Split('|')[1] == "ส่งแบบลงทะเบียน" || spl[1].Split('|')[1] == "EMS")
                {
                    Trans_price = 200;
                    Service = 50;
                    if (GetCusSession().Cus_VIP_Percent > 0)              
                        DiscountVIP = 50;
                }

                //VIP                
                if (GetCusSession().Cus_VIP_Percent > 0)
                {
                    VIP = "1";
                }

                ShoppingBiz Biz = new ShoppingBiz();
                OrderData Data = new OrderData();
                Data.ORDER_STATUS = 3; //รอชำระเงิน
                Data.ORDER_CODE = GetNoSeries("ORDER");
                Data.ORDER_CURRENCY = Rate;
                Data.CUS_ID = GetCusID();
                Data.CUS_ADDRESS_ID = spl[2].Split('|')[0] == "-" ? -1 : Convert.ToInt32(spl[2].Split('|')[0]);
                Data.TRANSPORT_CH_TH_METHOD = Convert.ToInt32(spl[0].Split('|')[0]);
                Data.TRANSPORT_TH_CU_METHOD = Convert.ToInt32(spl[1].Split('|')[0]);
                Data.ORDER_TYPE = 1; //Order
                Data.ORDER_EMP_REMARK = txtCusRemark.Text;
                Data.TRANSPORT_OTHER = Session["OTHER"].ToString();
                Data.VIP_DISCOUNT = GetCusSession().Cus_VIP_Percent;
                Data.TRANSPORT_CUSTOMER_PRICE = Trans_price;
                Data.SERVICE_CHARGE = Service;
                Data.SERVICE_CHARGE_DISCOUNT = DiscountVIP;
                Data.Create_User = User;

                Result = Biz.MakeOrder(Data, dt, User, Rate);
                if (Result[0] == "")
                {
                    string Res = "";
                    Int32 OID = Result[1] == "" ? 0 : Convert.ToInt32(Result[1]);
                    Res = Biz.UpdateOrderPricePIC(OID, VIP);
                    if (Res == "")
                    {
                        DataTable dtDetail = new DataTable();
                        string Order_ID;//SessionUser
                        Order_ID = Result[1];
                        dtDetail = Biz.GetOrderDetail(Order_ID == "" ? 0 : Convert.ToInt32(Order_ID));
                        if (dtDetail != null && dtDetail.Rows.Count > 0)
                        {
                            string EmailTo = WebConfigurationManager.AppSettings["email"].ToString();
                            string Subject = "Make Order : " + dtDetail.Rows[0]["ORDER_CODE"].ToString();
                            string Body = "มีการสร้างใบสั่งซื้อหมายเลข " + dtDetail.Rows[0]["ORDER_CODE"].ToString();                                
                            SendMail(EmailTo, Subject, Body);
                        }

                        Order_ID = EncrypData(Result[1]);                    
                        Response.Redirect("CustomerPayment.aspx?OID=" + Order_ID);
                    }
                }
                else
                {
                    WriteLog(Page.Request.Url.AbsolutePath, "SaveOrder", Result[0]);
                    //Error
                }
            }
        }

        protected void SavePI()
        {
            if (Session["TRANS"] != null && Session["ORDER"] != null)
            {
                string[] Result;
                string Trans = Session["TRANS"].ToString();
                string[] spl = Trans.Split(',');
                OrderData Data = (OrderData)Session["ORDER"];
                string User = GetCusCode();
                double Rate = GetRateCurrency();
                ShoppingBiz Biz = new ShoppingBiz();

                Data.ORDER_STATUS = 1; //รอ Admin Approve
                Data.ORDER_CODE = GetNoSeries("PI");
                Data.ORDER_CURRENCY = Rate;
                Data.CUS_ID = GetCusID();
                Data.CUS_ADDRESS_ID = spl[2].Split('|')[0] == "-" ? -1 : Convert.ToInt32(spl[2].Split('|')[0]);
                Data.TRANSPORT_CH_TH_METHOD = Convert.ToInt32(spl[0].Split('|')[0]);
                Data.TRANSPORT_TH_CU_METHOD = Convert.ToInt32(spl[1].Split('|')[0]);
                Data.ORDER_TYPE = 2; //PI                
                Data.Create_User = User;

                Result = Biz.MakeOrderByPI(Data);
                if (Result[0] == "")
                {
                    string Res = "", FileName = "", NewFileName = "";
                    Int32 OID = Result[1] == "" ? 0 : Convert.ToInt32(Result[1]);

                    if (OID != 0)
                    {
                        FileName = Session["PICPI"] == null ? "" : Session["PICPI"].ToString();
                        NewFileName = Data.ORDER_CODE + Path.GetExtension(FileName);
                        FileInfo fInfo = new FileInfo(FileName);
                        fInfo.Name.Replace(FileName, NewFileName);
                        
                        Res = Biz.UpdateOrderPricePIC(OID, FileName);
                    }                    
                    
                    if (Res == "")
                    {
                        string Order_ID;//SessionUser
                        Order_ID = EncrypData(Result[1]);
                        Response.Redirect("CustomerUploadPIList.aspx");
                    }
                }
                else
                {
                    WriteLog(Page.Request.Url.AbsolutePath, "SavePI", Result[0]);
                    //Error
                }
            }
        }

        protected void SaveTrans()
        {
            if (Session["TRANS"] != null && Session["ORDER"] != null)
            {
                string[] Result;
                string Trans = Session["TRANS"].ToString();
                string[] spl = Trans.Split(',');
                List<OrderData> lstData = (List<OrderData>)Session["ORDER"];
                string User = GetCusCode();
                double Rate = GetRateCurrency();
                ShoppingBiz Biz = new ShoppingBiz();
                OrderData Data = new OrderData();

                Data.ORDER_STATUS = 2; //รอสินค้า
                Data.ORDER_CODE = GetNoSeries("TRANSPORT");
                Data.ORDER_CURRENCY = Rate;
                Data.CUS_ID = GetCusID();
                Data.CUS_ADDRESS_ID = spl[2].Split('|')[0] == "-" ? -1 : Convert.ToInt32(spl[2].Split('|')[0]);
                Data.TRANSPORT_CH_TH_METHOD = Convert.ToInt32(spl[0].Split('|')[0]);
                Data.TRANSPORT_TH_CU_METHOD = Convert.ToInt32(spl[1].Split('|')[0]);
                Data.ORDER_TYPE = 3; //TRANS
                Data.Create_User = User;

                Result = Biz.MakeOrderByTrans(Data, lstData);
                if (Result[0] == "")
                {
                    string Res = "";
                    Int32 OID = Result[1] == "" ? 0 : Convert.ToInt32(Result[1]);
                    Res = Biz.UpdateOrderPricePIC(OID, "");
                    if (Res == "")
                    {
                        string Order_ID;//SessionUser
                        Order_ID = EncrypData(Result[1]);
                        Response.Redirect("CustomerTransOnlyList.aspx");
                    }
                }
                else
                {
                    WriteLog(Page.Request.Url.AbsolutePath, "SaveTrans", Result[0]);
                    //Error
                }
            }
        }
        #endregion

        protected void gvBasket_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int Count = 0;
                string ShopName = DataBinder.Eval(e.Row.DataItem, "CUS_BK_SHOPNAME").ToString();
                if (ViewState["OldShopName"] == null || ViewState["OldShopName"].ToString() != ShopName)
                {
                    Count = ViewState["Count"] == null ? 1 : Convert.ToInt32(ViewState["Count"]);
                    Label lbShopName = ((Label)e.Row.FindControl("lbShopName"));
                    Label lbRemark = ((Label)e.Row.FindControl("lbRemark"));
                    GridViewRow row = new GridViewRow(e.Row.RowIndex + Count, -1, DataControlRowType.DataRow, DataControlRowState.Insert);
                    TableCell cell = new TableCell();
                    cell.ColumnSpan = gvBasket.Columns.Count;
                    cell.CssClass = "gv-shopname";
                    string ShowShop = "";

                    ShowShop += "Shop name : " + DataBinder.Eval(e.Row.DataItem, "CUS_BK_SHOPNAME").ToString() + "&nbsp;&nbsp;";              
                    lbShopName.Text = ShowShop;
                    cell.Controls.Add(lbShopName);                  

                    row.Cells.Add(cell);
                    row.CssClass = "gv-shopname";
                    ((GridView)sender).Controls[0].Controls.AddAt(e.Row.RowIndex + Count, row);

                    ViewState["OldShopName"] = ShopName;
                    ViewState["Count"] = ++Count;

                }

                string ProdItemDetail = "";
                string ItemName = DataBinder.Eval(e.Row.DataItem, "CUS_BK_ITEMNAME").ToString();
                string ItemUrl = DataBinder.Eval(e.Row.DataItem, "CUS_BK_URL").ToString().Trim().Replace("amp;", "");
                ProdItemDetail = "<a href=\"" + ItemUrl + "\" target=\"_blank\">" + ItemName + "</a><br>";
                ((Label)e.Row.FindControl("lbItemName")).Text = ProdItemDetail;
            }
        }
    }
}