using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            DataTable dt = new DataTable();
            ShoppingBiz biz = new ShoppingBiz();
            Int32 Order_ID = OID == "" ? 0 : Convert.ToInt32(OID);
            dt = biz.GetOrderDetail(Order_ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                txtPINo.Text = dt.Rows[0]["ORDER_PI"].ToString();
                txtAmount.Text = dt.Rows[0]["OD_PRICE_ACTIVE"].ToString();
                imgPI.ImageUrl = dt.Rows[0]["OD_URL"].ToString();

                txtPINo.ReadOnly = true;
                txtAmount.ReadOnly = true;
                Ifile.Visible = false;
                imgPI.Visible = true;
            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            string CUS_ID = GetCusID().ToString();
            CUS_ID = EncrypData(CUS_ID);
            Response.Redirect("CustomerUploadPIList.aspx?CID=" + CUS_ID);
        }

        protected void btnUploadPI_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("ORDER");
            OrderData data = new OrderData();
            data.CUS_ID = GetCusID();
            data.ORDER_PI = txtPINo.Text;
            data.OD_PRICE = txtAmount.Text == "" ? 0 : Convert.ToDouble(txtAmount.Text);
            data.OD_AMOUNT = 1;
            data.OD_REMARK = txtRemark.Text;

            string filename = Server.MapPath("~/Attachment/PI/") + Path.GetFileName(Ifile.FileName);
            if (!Directory.Exists(Server.MapPath("~/Attachment/PI/")))
                Directory.CreateDirectory(Server.MapPath("~/Attachment/PI/"));

            Ifile.SaveAs(filename);
            data.OD_PICURL = filename;

            Session["ORDER"] = data;
            Response.Redirect("CustomerTransport.aspx?Type=" + EncrypData("PI"));
        }

    }
}