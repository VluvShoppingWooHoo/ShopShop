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
            if (!IsPostBack)
            {
                CheckSession();              

                BindDataGrid();
                BindDataTrans();
                BindDataSummary();
            }
        }

        protected void BindDataGrid()
        {
            if (Session["ORDER"] != null)
            {
                DataTable dtSelected = (DataTable)Session["ORDER"];
                if (dtSelected != null && dtSelected.Rows.Count > 0)
                    gvBasket.DataSource = dtSelected;
                else
                    gvBasket.DataSource = null;

                gvBasket.DataBind();
            }
            else
            {
                //Error
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
        protected void BindDataSummary()
        {
            DataTable dtSelected = (DataTable)Session["ORDER"];
            double Total_Amount = 0, Amount = 0, Transport_Amount = 0;
            
            foreach (DataRow dr in dtSelected.Rows)
            {
                Amount = dr["CUS_BK_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_PRICE"].ToString());
                Total_Amount = Total_Amount + Amount;
            }

            Transport_Amount = Total_Amount * 10 / 100;
            lbPay1.Text = "ชำระเงินรอบแรก = " + Total_Amount.ToString("###,###.00") + " + " + Transport_Amount.ToString("###,###.00")
                + " = " + (Total_Amount + Transport_Amount).ToString("###,###.00") + " หยวน";
        }

        protected void btnConfirm_ServerClick(object sender, EventArgs e)
        {
            if (Session["TRANS"] != null && Session["ORDER"] != null)
            {
                string[] Result;
                string Trans = Session["TRANS"].ToString();
                string[] spl = Trans.Split(',');
                DataTable dt = (DataTable)Session["ORDER"];
                string User = "TEST"; //SessionUser

                ShoppingBiz Biz = new ShoppingBiz();
                OrderData Data = new OrderData();
                Data.ORDER_STATUS = 1; //ยังไม่ไดชำระเงิน
                Data.ORDER_CODE = GetNoSeries("ORDER");
                Data.CUS_ID = GetCusID();
                Data.CUS_ADDRESS_ID = spl[2].Split('|')[0] == "-" ? -1 : Convert.ToInt32(spl[2].Split('|')[0]);
                Data.TRANSPORT_CH_TH_METHOD = Convert.ToInt32(spl[0].Split('|')[0]);
                Data.TRANSPORT_TH_CU_METHOD = Convert.ToInt32(spl[1].Split('|')[0]);
                Data.Create_User = User; //SessionUser

                Result = Biz.MakeOrder(Data, dt, User);
                if (Result[0] == "")
                {
                    EncrypUtil en = new EncrypUtil();
                    string Order_ID;//SessionUser
                    Order_ID = en.EncrypData(Result[1]);
                    Response.Redirect("CustomerPayment.aspx?OID=" + Order_ID);
                }
                else
                {
                    //Error
                }
            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            EncrypUtil en = new EncrypUtil();
            string CUS_ID = GetCusID().ToString();
            CUS_ID = en.EncrypData(CUS_ID);
            Response.Redirect("CustomerTransport.aspx?CID=" + CUS_ID);
        }
    }
}