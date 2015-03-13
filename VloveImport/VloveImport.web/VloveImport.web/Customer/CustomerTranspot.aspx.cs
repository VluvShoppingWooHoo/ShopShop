using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.util;

namespace VloveImport.web.Customer
{
    public partial class CustomerTranspot : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            string CID = Request.QueryString["CID"] == null ? "" : en.DecryptData(Request.QueryString["CID"].ToString());
            if (CID == "")
                Response.Redirect("CustomerBasket.aspx");
        }

        protected void btnUrder_Click(object sender, EventArgs e)
        {
            Session.Remove("TRANS");
            string Trans = "";
            if (rdbCar.Checked)
                Trans = rdbCar.Text;
            else
                Trans = rdbBoat.Text;

            if (rdbSafe.Checked)
                Trans = Trans + "|" + rdbSafe.Text;
            else
                Trans = Trans + "|" + rdbNim.Text;

            Session.Add("TRANS", Trans);
            EncrypUtil en = new EncrypUtil();
            string CUS_ID = "0";//SessionUser
            CUS_ID = en.EncrypData(CUS_ID);
            Response.Redirect("CustomerConfirmInfo.aspx?CID=" + CUS_ID);
        }

    }
}