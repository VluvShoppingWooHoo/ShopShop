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
                
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string CUS_CODE = "", Body = "";
            int CUS_ID = -1;
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = biz.Get_Customer_Profile_By_Email(email);
            if (dt != null && dt.Rows.Count == 1)
            {
                CUS_ID = dt.Rows[0]["CUS_ID"].ToString() == "" ? -1 : Convert.ToInt32(dt.Rows[0]["CUS_ID"].ToString());
                CUS_CODE = dt.Rows[0]["CUS_CODE"].ToString();
            }
            else
            {
                WriteLog(Page.Request.Url.AbsolutePath, "Forgot", email);
                lbMsg.Text = "โปรดตรวจสอบอีเมลล์ของคุณ";
                return;
            }

            string ResetPass = System.Web.Security.Membership.GeneratePassword(10, 0);
            string Result = biz.RESET_PASSWORD(EncrypData(ResetPass), CUS_ID, "LOGIN");
            
            string[] Temp;
            Temp = Get_Config("REPASS");
            if (Temp.Length > 0)
            {                
                Body = Temp[1].Replace("{1}", CUS_CODE).Replace("{2}", ResetPass);
                Result = SendMail(email, Temp[0], Body);
            }
            else
            {
                //WriteLog
                WriteLog(Page.Request.Url.AbsolutePath, "Forgot", email + "|| 1. ไม่สามารถส่งเมลล์ได้");
                lbMsg.Text = "ไม่สามารถส่งเมลล์ได้";
                return;
            }

            if (Result == "")
            {
                WriteLog(Page.Request.Url.AbsolutePath, "Forgot", email + "|| อีเมลล์ของคุณเรียบร้อย");
                txtEmail.Text = "";
                lbMsg.Text = "รหัสผ่านถูกส่งไปที่อีเมลล์ของคุณเรียบร้อย";
            }
            else
            {
                //WriteLog
                WriteLog(Page.Request.Url.AbsolutePath, "Forgot", email + "|| 2. ไม่สามารถส่งเมลล์ได้");
                lbMsg.Text = "ไม่สามารถส่งเมลล์ได้";
                return;
            }
        }        
    }
}