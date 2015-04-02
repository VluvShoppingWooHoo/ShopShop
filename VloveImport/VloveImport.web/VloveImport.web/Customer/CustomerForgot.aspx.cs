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
            DataTable dt;
            string Result = ResetPassword();
            string email = "", pass = "";
            string[] Temp;
            Temp = Get_Config("REGIS");
            if (Temp.Length > 0)
                Result = SendMail(email, pass, Temp[0], Temp[1]);
        }

        protected string ResetPassword()
        {
            string Result = "";

            return Result;
        }
    }
}