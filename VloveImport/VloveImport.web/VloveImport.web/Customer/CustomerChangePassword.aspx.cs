using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;
using VloveImport.web.UserControls;

namespace VloveImport.web.Customer
{
    public partial class CustomerChangePassword : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession();    
                BindData();
            }
        }

        private void BindData()
        {
            if (GetCusSession().Cus_Withdraw_Code == "")
            {
                txtW_OldPass.Visible = false;
                lb1.Visible = true;
            }
            else
            {
                txtW_OldPass.Visible = true;
                lb1.Visible = false;
            }
        }

        #region Event
        protected void imbConfirm_Click(object sender, ImageClickEventArgs e)
        {
            string PassDB = "", DBDecrypt = "";
            string Result = "", old = "", newp = "";

            old = txtOldPass.Text;
            newp = txtNewPass.Text;
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = biz.Get_Customer_Profile(GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {
                PassDB = dt.Rows[0]["CUS_PASSWORD"].ToString();
                DBDecrypt = DecryptData(PassDB);
                if (old == DBDecrypt)
                {
                    if (txtNewPass.Text != txtConfirm.Text)
                    {
                        Result = "รหัสผ่านใหม่กับยืนยันรหัสผ่านไม่ตรงกัน!!!";
                        ShowMessageBox(Result);
                        return;
                    }

                    Result = biz.CHANGE_PASSWORD(GetCusID(), EncrypData(newp), "LOGIN");
                    if (Result == "")
                    {
                        LoginProcess(GetCusEmail(), newp, 0);
                        ShowMessageBox("เปลี่ยนรหัสเข้าสู่ระบบสำเร็จ", Page, "../Index.aspx");                        
                    }
                    else
                    {
                        WriteLog(Page.Request.Url.AbsolutePath, "imbConfirm_Click", Result);
                        ShowMessageBox("กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }
                }
                else
                {
                    ShowMessageBox("รหัสผ่านเดิมไม่ถูกต้อง!!!");
                    return;
                }
            }
            else
            {
                ShowMessageBox("หมดเวลาเชื่อมต่อ กรุณาเข้าสู่ระบบอีกครั้ง", Page, "../Index.aspx");   
            }
        }

        protected void imbW_Confirm_Click(object sender, ImageClickEventArgs e)
        {
            string PassDB = "", DBDecrypt = "";
            string Result = "", old = "", newp = "";

            old = txtW_OldPass.Text;
            newp = txtW_NewPass.Text;
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = biz.Get_Customer_Profile(GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {
                PassDB = dt.Rows[0]["CUS_WITHDRAW_CODE"].ToString();
                if (PassDB != "")
                {
                    DBDecrypt = DecryptData(PassDB);
                    if (old == DBDecrypt)
                    {
                        if (txtW_NewPass.Text != txtW_Confirm.Text)
                        {
                            Result = "รหัสผ่านใหม่กับยืนยันรหัสผ่านไม่ตรงกัน!!!";
                            ShowMessageBox(Result);
                            return;
                        }

                        Result = biz.CHANGE_PASSWORD(GetCusID(), EncrypData(newp), "WITHDRAW");
                        if (Result == "")
                        {
                            LoginProcess(GetCusEmail(), DecryptData(GetCusSession().Cus_Password), 0);
                            ShowMessageBox("เปลี่ยนรหัสการถอนเงินสำเร็จ", Page, "../Index.aspx");
                        }
                        else
                        {
                            WriteLog(Page.Request.Url.AbsolutePath, "imbW_Confirm_Click", Result);
                            ShowMessageBox("กรุณาติดต่อผู้ดูแลระบบ");
                            return;
                        }
                    }
                    else
                    {
                        ShowMessageBox("รหัสผ่านเดิมไม่ถูกต้อง!!!");
                        return;
                    }
                }
                else
                {
                    if (txtW_NewPass.Text != txtW_Confirm.Text)
                    {
                        Result = "รหัสผ่านใหม่กับยืนยันรหัสผ่านไม่ตรงกัน!!!";
                        ShowMessageBox(Result);
                        return;
                    }

                    Result = biz.CHANGE_PASSWORD(GetCusID(), EncrypData(newp), "WITHDRAW");
                    if (Result == "")
                    {
                        LoginProcess(GetCusEmail(), DecryptData(GetCusSession().Cus_Password), 0);
                        ShowMessageBox("เปลี่ยนรหัสการถอนเงินสำเร็จ", Page, "../Index.aspx");
                    }
                    else
                    {
                        WriteLog(Page.Request.Url.AbsolutePath, "imbW_Confirm_Click", Result);
                        ShowMessageBox("กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }                    
                }
            }
            else
            {
                ShowMessageBox("หมดเวลาเชื่อมต่อ กรุณาเข้าสู่ระบบอีกครั้ง", Page, "../Index.aspx");   
            }
        }
        #endregion

        protected void lbReset_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
        
        protected void btnConf_Click(object sender, EventArgs e)
        {
            string Body = "", Result = "";
            string ResetPass = System.Web.Security.Membership.GeneratePassword(10, 3);
            CustomerBiz biz = new CustomerBiz();
            Result = biz.RESET_PASSWORD(EncrypData(ResetPass), GetCusID(), "WITHDRAW");
            
            string[] Temp;
            Temp = Get_Config("REPASSWITHDRAW");
            if (Temp.Length > 0)
            {
                Body = Temp[1].Replace("{1}", GetCusCode()).Replace("{2}", ResetPass);
                Result = SendMail(GetCusEmail(), Temp[0], Body);
            }
            
            ShowMessageBox("รหัสผ่านจะถูกส่งเข้าอีเมลล์ของคุณ");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        
        protected void LoginProcess(string UserName, string Password, int isFB)
        {
            LogonBiz Logon = new LogonBiz();
            CustomerData Cust = new CustomerData();
            Cust = Logon.LogonDBCustomer(UserName, Password, isFB);
            if (Cust != null)
                Session["User"] = Cust;
        }  
    }
}