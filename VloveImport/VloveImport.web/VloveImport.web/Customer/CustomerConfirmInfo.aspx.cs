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
    public partial class CustomerConfirmInfo : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CID = Request.QueryString["CID"] == null ? "" : en.DecryptData(Request.QueryString["CID"].ToString());
                if (CID == "")
                    Response.Redirect("CustomerBasket.aspx");

                BindDataGrid();
                BindDataTrans();
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
            }
            else
            {
                //Error
            }
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
                Data.ORDER_STATUS = 1;
                Data.CUS_ID = 0;//SessionUser
                Data.ORDER_TRANSPOT_CHINA = Convert.ToInt32(spl[0].Split('|')[0]);
                Data.ORDER_TRANSPOT_THAI = Convert.ToInt32(spl[1].Split('|')[0]);
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
            string CUS_ID = "0";//SessionUser
            CUS_ID = en.EncrypData(CUS_ID);
            Response.Redirect("CustomerTranspot.aspx?CID=" + CUS_ID);
        }
    }
}