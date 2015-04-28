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
                    }
                    break;
                case "PI":
                    if (Session["ORDER"] != null)
                    {
                        OrderData data = (OrderData)Session["ORDER"];
                        if (data != null)
                        {
                            lbPINo.Text = data.ORDER_PI;
                            lbAmount.Text = data.OD_AMOUNT.ToString();
                            imgURL.ImageUrl = data.OD_PICURL;

                            mView.Visible = true;
                            mView.ActiveViewIndex = 0;
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
                lbgroup2.Text = spl[1].Split('|')[1];
                lbgroup3.Text = spl[2].Split('|')[1];
            }
            else
            {
                //Error
            }
        }
        protected void BindDataSummary(string Type)
        {
            double Total_Amount = 0, Price = 0, Amount = 0, Transport_Amount = 0, Rate = 0;
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

                    Transport_Amount = Total_Amount * 10 / 100;
                    lbPay1.Text = "ชำระเงินรอบแรก = " + Total_Amount.ToString("###,##0.00") + " + " + Transport_Amount.ToString("###,##0.00")
                        + " = " + (Total_Amount + Transport_Amount).ToString("###,##0.00") + " บาท";
                    break;

                case "PI":
                    OrderData data = (OrderData)Session["ORDER"];
                    Transport_Amount = data.OD_PRICE * 10 / 100;
                    lbPay1.Text = "ชำระเงินรอบแรก = " + data.OD_PRICE.ToString("###,##0.00") + " + " + Transport_Amount.ToString("###,##0.00")
                        + " = " + (data.OD_PRICE + Transport_Amount).ToString("###,##0.00") + " บาท";
                    break;

                case "TRANS":
                    List<OrderData> lstdata = (List<OrderData>)Session["ORDER"];
                    Transport_Amount = lstdata[0].OD_PRICE * 10 / 100;
                    lbPay1.Text = "ชำระเงินรอบแรก = " + lstdata[0].OD_PRICE.ToString("###,##0.00") + " + " + Transport_Amount.ToString("###,##0.00")
                        + " = " + (lstdata[0].OD_PRICE + Transport_Amount).ToString("###,##0.00") + " บาท";
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
                Data.Create_User = User;

                Result = Biz.MakeOrder(Data, dt, User, Rate);
                if (Result[0] == "")
                {
                    string Res = "";
                    Int32 OID = Result[1] == "" ? 0 : Convert.ToInt32(Result[1]);
                    Res = Biz.UpdateOrderPrice(OID);
                    if (Res == "")
                    {
                        EncrypUtil en = new EncrypUtil();
                        string Order_ID;//SessionUser
                        Order_ID = en.EncrypData(Result[1]);
                        Response.Redirect("CustomerPayment.aspx?OID=" + Order_ID);
                    }
                }
                else
                {
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
                    string Res = "";
                    Int32 OID = Result[1] == "" ? 0 : Convert.ToInt32(Result[1]);
                    Res = Biz.UpdateOrderPrice(OID);
                    if (Res == "")
                    {
                        string Order_ID;//SessionUser
                        Order_ID = EncrypData(Result[1]);
                        Response.Redirect("CustomerUploadPIList.aspx");
                    }
                }
                else
                {
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
                    Res = Biz.UpdateOrderPrice(OID);
                    if (Res == "")
                    {
                        string Order_ID;//SessionUser
                        Order_ID = EncrypData(Result[1]);
                        Response.Redirect("CustomerTransOnlyList.aspx");
                    }
                }
                else
                {
                    //Error
                }
            }
        }
        #endregion
    }
}