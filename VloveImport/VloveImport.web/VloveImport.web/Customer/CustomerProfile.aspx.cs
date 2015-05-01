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
    public partial class CustomerProfile : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession(); 
                //string Cus_ID = GetCusID();//Request.QueryString["Cus_id"] == null ? "" : en.DecryptData(Request.QueryString["Cus_id"].ToString());                
                BindData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 Cus_id = GetCusID();
            CustomerData Data = GetData();
            CustomerBiz Biz = new CustomerBiz();
            string strMsg = Biz.UPDATE_Customer_Profile(Data);
            if (strMsg == "")
                Response.Redirect("CustomerProfile.aspx?Cus_id=" + en.EncrypData(Cus_id.ToString()));
        }

        protected CustomerData GetData()
        {
            CustomerData Data = new CustomerData();
            Data.Cus_ID = GetCusID();
            Data.Cus_Name = txtName.Text;
            Data.Cus_LName = txtLName.Text;
            Data.Cus_Gender = ddlGender.SelectedValue;

            string FileName = "";
            if(uplImg.HasFile)
            {
                if (!Directory.Exists(Server.MapPath("~/Attachment/Profile/")))
                    Directory.CreateDirectory(Server.MapPath("~/Attachment/Profile/"));

                FileName = Server.MapPath("~/Attachment/Profile/") + lbCode.Text;
                if (File.Exists(FileName))
                    File.Delete(FileName);                
                
                uplImg.SaveAs(FileName);
                Data.CUS_Pic = FileName;
            }

            Data.Cus_BirthDay = Convert.ToDateTime(Convert_DateYYYYMMDD(dtMaterial.Value, '-', "YYYYMMDD", 0));
            Data.Cus_Link_Shop = txtLinkShop.Text;

            return Data;
        }

        protected void BindData()
        {
            Int32 Cus_ID = GetCusID();
            CustomerBiz Biz = new CustomerBiz();
            DataTable dt = Biz.Get_Customer_Profile(Cus_ID);
            string Gender = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                Gender = dt.Rows[0]["Cus_Gender"].ToString() == "" ? "1" : dt.Rows[0]["Cus_Gender"].ToString();
                lbEMail.Text = dt.Rows[0]["Cus_Email"].ToString();
                lbCode.Text = dt.Rows[0]["Cus_Code"].ToString();                
                txtName.Text = dt.Rows[0]["Cus_Name"].ToString();
                txtLName.Text = dt.Rows[0]["Cus_LName"].ToString();
                ddlGender.SelectedIndex = Convert.ToInt32(Gender);
                txtLinkShop.Text = dt.Rows[0]["Cus_Link_shop"].ToString();
            }
        }
    }
}