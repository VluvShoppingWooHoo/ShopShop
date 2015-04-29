using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.data.Extension;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {
            string[] URL;
            string Body = "", Link = "",emailEn = "", passEn = "", Path = "";
            string Result = Insert();
            string[] Temp;
            if (Result == "")
            {
                //sendmail
                Temp = Get_Config("REGIS");
                if (Temp.Length > 0)
                {
                    emailEn = EncrypData(txtEmail.Text);
                    passEn = EncrypData(txtPassword.Text);
                    Path = Page.Request.Url.Authority;
                    Link = Path + "/Customer/Activate.aspx?e=" + Server.UrlEncode(emailEn) + "&c=" + Server.UrlEncode(passEn);
                    Body = Temp[1].Replace("{0}", Link);
                    Result = SendMail(txtEmail.Text, Temp[0], Body);

                    //Error
                    if (Result != "")
                    {
                        URL = Page.Request.Url.ToString().Split('/');
                        WriteLog(URL[URL.Length - 1], "btnRegis", Result);
                    }

                    //Success
                    mView.ActiveViewIndex = 1;
                    //GoToIndex();
                }
                else
                {
                    //WriteLog
                    URL = Page.Request.Url.ToString().Split('/');
                    WriteLog(URL[URL.Length - 1], "btnRegis", Result);
                    lbMessage.Text = "Error";
                }

            }
            else
            {
                ShowMessageBox(Result);
                //WriteLog
                //URL = Page.Request.Url.ToString().Split('/');
                //WriteLog(URL[URL.Length - 1], "btnRegis", Result);
                //lbMessage.Text = "Error";
            }

            
        }

        protected string Insert()
        {
            string Result = "";
            if (CheckInput())
            {
                if (CheckEmailAlreadyUse(txtEmail.Text))
                {
                    LogonBiz Log = new LogonBiz();
                    CustomerData Cust = new CustomerData();
                    EncrypUtil en = new EncrypUtil();

                    Cust.Cus_Code = GetNoSeries("CUSTOMER");
                    Cust.Cus_Name = txtName.Text;
                    Cust.Cus_Email = txtEmail.Text;
                    Cust.Cus_Password = en.EncrypData(txtPassword.Text);
                    Cust.Cus_Mobile = txtMobile.Text;
                    Cust.Cus_Ref_ID = hddRefCust.Value == "" ? 0 : Convert.ToInt32(hddRefCust.Value);

                    Result = Log.InsertRegisCustomer(Cust);
                }
                else
                {
                    Result = "Email นี้ถูกใช้ไปแล้ว";
                    //found email already use
                }
            }
            else
            {
                Result = "ตรวจสอบข้อมูลให้ถูกต้อง!!!";
            }
            return Result;
        }

        public bool CheckInput()
        {
            bool IsReturn = true;
            string emailPattern = "^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@" + "([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";

            if (txtName.Text.Trim() == "")
            {
                IsReturn = false;
                ShowMessageBox("กรุณากรอกชื่อ", this.Page);
                return IsReturn;
            }

            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
            {
                IsReturn = false;
                ShowMessageBox("กรุณากรอก E-Mail ให้ถูกต้อง", this.Page);
                return IsReturn;
            }

            if (txtPassword.Text.Trim() == "")
            {
                IsReturn = false;
                ShowMessageBox("กรุณากรอกรหัสผ่าน", this.Page);
                return IsReturn;
            }

            if (txtConfirmPass.Text.Trim() == "")
            {
                IsReturn = false;
                ShowMessageBox("กรุณากรอกยืนยันรหัสผ่าน", this.Page);
                return IsReturn;
            }

            if (txtPassword.Text.Trim() != txtConfirmPass.Text.Trim())
            {
                IsReturn = false;
                ShowMessageBox("กรุณายืนยันรหัสผ่านให้ถูกต้อง", this.Page);
                return IsReturn;
            }

            if (!ckb.Checked)
            {
                IsReturn = false;
                ShowMessageBox("กรุณายอมรับเงื่อนไขการเป็นสมาชิก", this.Page);
                return IsReturn;
            }

            if (txtMobile.Text.Trim() == "")
            {
                IsReturn = false;
                ShowMessageBox("กรุณากรอกหมายเลขโทรศัพท์", this.Page);
                return IsReturn;
            }
           
            return IsReturn;
        }

        public bool CheckEmailAlreadyUse(string email)
        {
            bool Result = false; 
            try
            {
                LogonBiz Log = new LogonBiz();
                CustomerData cust = new CustomerData();
                Result = Log.RegisValidEmail(email);
            }
            catch (Exception ex) { }
            return Result;
        }        
        
        #region for fb register
        [WebMethod]
        public static string fbRegis(string email, string first_name, string id, string last_name, string gender)
        {
            string Result = string.Empty;
            string password = "1234";
            JavaScriptSerializer js = new JavaScriptSerializer();
            JSONData jData = new JSONData();
            CustomerData cust = new CustomerData();
            Register Register = new Register();
            try
            {
                //password = Register.CheckEmailAlreadyUse(email);
                //if (password == string.Empty)
                if(Register.CheckEmailAlreadyUse(email))
                {
                    BasePage bp = new BasePage();
                    EncrypUtil en = new EncrypUtil();
                    cust.Cus_Code = bp.GetNoSeries("CUSTOMER");
                    //cust.Cus_Code = "CUSTOMER";
                    cust.Cus_Password = en.EncrypData(password);
                    cust.Cus_Email = email;
                    cust.Cus_Mobile = string.Empty;
                    cust.Cus_Name = first_name;
                    cust.Cus_LName = last_name;
                    cust.Cus_FB_ID = id;
                    cust.Cus_Gender = gender.Substring(0, 1).ToUpper();
                    cust.Cus_Ref_ID = 0;
                    Result = InsertFaceBook(cust);
                    if (Result == string.Empty)
                    {
                        jData.Result = Constant.Fact.T;
                        jData.ReturnVal = password;
                    }
                    else
                        jData.Result = Constant.Fact.F;
                }
                else
                {
                    jData.Result = Constant.Fact.T;
                    jData.ReturnVal = password;
                }
            }
            catch (Exception ex) { Result = null; }
            return js.Serialize(jData);
        }
        protected static string InsertFaceBook(CustomerData cust)
        {
            LogonBiz Log = new LogonBiz();
            return Log.InsertRegisCustomerFB(cust);
        }
        #endregion
    }
}