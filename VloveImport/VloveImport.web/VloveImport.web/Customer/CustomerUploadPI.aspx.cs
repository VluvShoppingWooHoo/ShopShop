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
                txtRemark.Text = dt.Rows[0]["OD_REMARK"].ToString();
                imgPI.ImageUrl = dt.Rows[0]["OD_URL"].ToString();

                txtPINo.ReadOnly = true;
                txtAmount.ReadOnly = true;
                txtRemark.ReadOnly = true;
                Ifile.Visible = false;
                imgPI.Visible = true;

                btnUploadPI.Visible = false;
            }
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("CustomerUploadPIList.aspx");
        }

        protected void btnUploadPI_ServerClick(object sender, EventArgs e)
        {
            double Charge = 0;
            string[] Config = Get_Config("CHARGE");
            if (Config != null && Config.Length > 0)
                Charge = Convert.ToDouble(Config[0]);

            if (CheckInput())
            {
                Session.Remove("TRANS");
                Session.Remove("ORDER");
                OrderData data = new OrderData();
                data.CUS_ID = GetCusID();
                //data.ORDER_PI = txtPINo.Text;
                data.OD_ITEMNAME = txtPINo.Text;
                data.OD_PRICE = txtAmount.Text == "" ? 0 : Convert.ToDouble(txtAmount.Text);
                data.OD_PRICE_ACTIVE = Charge;
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

        protected bool CheckInput()
        {
            if (txtPINo.Text == "")
            {
                ShowMessageBox("กรุณากรอก หมายเลข PI");
                return false;
            }
            if (txtAmount.Text == "")
            {
                ShowMessageBox("กรุณากรอก จำนวนเงิน");
                return false;
            }
            if (!Ifile.HasFile)
            {
                ShowMessageBox("กรุณาแนบไฟล์ PI ที่ต้องการ");
                return false;
            }
            return true;
        }
    }
}