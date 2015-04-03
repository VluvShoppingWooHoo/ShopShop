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
    public partial class CustomerForgot : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession(); 
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            int CUS_ID = -1;
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = biz.Get_Customer_Profile_By_Email(txtEmail.Text);
            if(dt != null && dt.Rows.Count == 1)
                CUS_ID = dt.Rows[0]["CUS_PASSWORD"].ToString() ==  "" ? -1 : Convert.ToInt32(dt.Rows[0]["CUS_PASSWORD"].ToString());

            string ResetPass = System.Web.Security.Membership.GeneratePassword(10, 3);
            string Result = biz.RESET_PASSWORD(ResetPass, CUS_ID);
            string email = "", pass = "";
            string[] Temp;
            Temp = Get_Config("REGIS");
            if (Temp.Length > 0)
                Result = SendMail(email, pass, Temp[0], Temp[1]);

            if (Result == "")
            {
                txtEmail.Text = "";
                lbMsg.Text = "รหัสผ่านถูกส่งไปที่อีเมลล์ของคุณเรียบร้อย";
            }
        }        
    }
}