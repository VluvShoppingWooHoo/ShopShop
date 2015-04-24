﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerTransport : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();
            if (!IsPostBack)
            {
                
                if (Session["ORDER"] == null)            
                    GoToIndex();

                BindTrans();
            }
        }

        protected void BindTrans()
        {
            ShoppingBiz Biz = new ShoppingBiz();
            CustomerBiz BizCus = new CustomerBiz();
            rdbChina.DataSource = Biz.GetTransList("TRANSPORT_C");
            rdbChina.DataBind();
            rdbChina.SelectedIndex = 0;

            rdbThai.DataSource = Biz.GetTransList("TRANSPORT_T");
            rdbThai.DataBind();
            rdbThai.SelectedIndex = 0;

            rdbAddress.DataSource = BizCus.GetData_Customer_Address(GetCusID(), 0, 0, "BINDDATA");
            rdbAddress.DataBind();
            rdbAddress.SelectedIndex = 0;
        }

        protected void btnOrder_ServerClick(object sender, EventArgs e)
        {
            Session.Remove("TRANS");
            string China = rdbChina.SelectedItem.Value + "|" + rdbChina.SelectedItem.Text;
            string Thai = rdbThai.SelectedItem.Value + "|" + rdbThai.SelectedItem.Text;
            string Address = "";
            if (rdbThai.SelectedItem.Value == "1") //มารับเอง
                Address = "-|-";
            else
                Address = rdbAddress.SelectedItem.Value + "|" + rdbAddress.SelectedItem.Text;
            
            string Trans = China + "," + Thai + "," + Address;                          

            Session.Add("TRANS", Trans);                        
            string Type = Request.QueryString["Type"] == null ? "" : DecryptData(Request.QueryString["Type"].ToString());
            Response.Redirect("CustomerConfirmInfo.aspx?Type=" + EncrypData(Type));
        }

        protected void btnBack_ServerClick(object sender, EventArgs e)
        {
            string Type = Request.QueryString["Type"] == null ? "" : DecryptData(Request.QueryString["Type"].ToString());
            string Cus_ID = GetCusID().ToString();
            switch (Type)
            {
                case "ORDER":
                    Response.Redirect("CustomerBasket.aspx");
                    break;
                case "PI":
                    Response.Redirect("CustomerUploadPIList.aspx");
                    break;
                case "TRANS":
                    Response.Redirect("CustomerTransOnlyList.aspx");
                    break;
                default:
                    break;
            }
            
        }

    }
}