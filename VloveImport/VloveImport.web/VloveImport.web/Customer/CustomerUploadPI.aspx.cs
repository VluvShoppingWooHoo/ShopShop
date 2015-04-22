using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerUploadPI : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
            if (!IsPostBack)
            {
                string OID = Request.QueryString["OID"] == null ? "" : DecryptData(Request.QueryString["OID"].ToString());
                if(OID != "")
                    BindData(OID);
            }
        }

        protected void BindData(string OID)
        {

        }

        protected void btnOrder_ServerClick(object sender, EventArgs e)
        {
            //Session.Remove("TRANS");
            //string China = rdbChina.SelectedItem.Value + "|" + rdbChina.SelectedItem.Text;
            //string Thai = rdbThai.SelectedItem.Value + "|" + rdbThai.SelectedItem.Text;
            //string Address = "";
            //if (rdbThai.SelectedItem.Value == "1") //มารับเอง
            //    Address = "-|-";
            //else
            //    Address = rdbAddress.SelectedItem.Value + "|" + rdbAddress.SelectedItem.Text;
            
            //string Trans = China + "," + Thai + "," + Address;                          

            //Session.Add("TRANS", Trans);
            //EncrypUtil en = new EncrypUtil();
            //string CUS_ID = GetCusID().ToString();
            //CUS_ID = en.EncrypData(CUS_ID);
            //Response.Redirect("CustomerConfirmInfo.aspx?CID=" + CUS_ID);
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            EncrypUtil en = new EncrypUtil();
            string CUS_ID = GetCusID().ToString();
            CUS_ID = en.EncrypData(CUS_ID);
            Response.Redirect("CustomerBasket.aspx?CID=" + CUS_ID);
        }

        protected void btnUploadPI_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("TRANS");
            string OID = GetCusID().ToString();
            CUS_ID = en.EncrypData(CUS_ID);
            Response.Redirect("CustomerTransport.aspx?CID=" + CUS_ID);
        }

    }
}