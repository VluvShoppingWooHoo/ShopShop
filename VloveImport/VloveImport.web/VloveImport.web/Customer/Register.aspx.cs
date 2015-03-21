﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class Register : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {
            string Result = Insert();
            if (Result == "")
            {
                mView.ActiveViewIndex = 1;
                SetActivate();                
            }
            else
            {
                lbMessage.Text = "Error";
            }
        }

        protected string Insert()
        {
            string Result = "";
            if (CheckInput())
            {
                LogonBiz Log = new LogonBiz();
                CustomerData Cust = new CustomerData();
                EncrypUtil en = new EncrypUtil();

                Cust.Cus_Code = GetNoSeries("CUSTOMER");
                Cust.Cus_Email = txtEmail.Text;
                Cust.Cus_Password = en.EncrypData(txtPassword.Text);
                Cust.Cus_Mobile = txtMobile.Text;
                Cust.Cus_Ref_ID = hddRefCust.Value == "" ? 0 : Convert.ToInt32(hddRefCust.Value);

                Result = Log.InsertRegisCustomer(Cust);
            }
            else
            {
                Result = "Error Input";
            }
            return Result;
        }

        public bool CheckInput()
        {
            bool IsReturn = true;
            string emailPattern = "^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@" + "([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";

            if (!Regex.IsMatch(txtEmail.Text.Trim(), emailPattern))
            {
                IsReturn = false;
                ShowMessageBox("กรุณากรอก E-Mail ให้ถูกต้อง", this.Page);
                return IsReturn;
            }
            return IsReturn;
        }

        protected void SetActivate()
        {
            EncrypUtil en = new EncrypUtil();
            string e = "", c = "";
            e = en.EncrypData(txtEmail.Text);
            c = en.EncrypData(txtPassword.Text);
            hplActivate.Text = "ActivateHere";
            hplActivate.NavigateUrl = "Activate.aspx?e=" + Server.UrlEncode(e) + "&c=" + Server.UrlEncode(c);
        }
    }
}