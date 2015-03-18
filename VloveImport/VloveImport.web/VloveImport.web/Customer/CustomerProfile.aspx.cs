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
    public partial class CustomerProfile : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Cus_ID = GetCusID();//Request.QueryString["Cus_id"] == null ? "" : en.DecryptData(Request.QueryString["Cus_id"].ToString());                
                BindData(Cus_ID);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 Cus_id = Convert.ToInt32(en.DecryptData(Request.QueryString["Cus_id"].ToString()));
            CustomerData Data = GetData(Cus_id);
            CustomerBiz Biz = new CustomerBiz();
            string strMsg = Biz.UPDATE_Customer_Profile(Data);
            if (strMsg == "")
                Response.Redirect("CustomerProfile.aspx?Cus_id=" + en.EncrypData(Cus_id.ToString()));
        }

        protected CustomerData GetData(int Cus_id)
        {
            CustomerData Data = new CustomerData();
            Data.Cus_ID = Convert.ToInt32(en.DecryptData(Request.QueryString["Cus_id"].ToString()));
            Data.Cus_Name = txtName.Text;
            Data.Cus_LName = txtLName.Text;
            Data.Cus_Gender = ddlGender.SelectedValue;
            //Data.Cus_BirthDay = txtName.Text;
            Data.Cus_Email = txtEmail.Text;
            Data.Cus_Link_Shop = txtEmail.Text;

            return Data;
        }

        protected void BindData(string ID)
        {
            Int32 Cus_ID = Convert.ToInt32(ID);
            CustomerBiz Biz = new CustomerBiz();
            DataTable dt = Biz.Get_Customer_Profile(Cus_ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                lbCode.Text = dt.Rows[0]["Cus_Code"].ToString();
                lbUser.Text = dt.Rows[0]["Cus_Code"].ToString();
                txtName.Text = dt.Rows[0]["Cus_Name"].ToString();
                txtLName.Text = dt.Rows[0]["Cus_LName"].ToString();
                txtEmail.Text = dt.Rows[0]["Cus_Email"].ToString();
                txtLinkShop.Text = dt.Rows[0]["Cus_Link_shop"].ToString();
            }
        }
    }
}