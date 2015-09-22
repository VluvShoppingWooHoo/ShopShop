﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
    public partial class CustomerVIP : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession();
                GetMymoney();
                BindHistoryVIP();
                BindMasterVIP();
            }
        }

        public void GetMymoney()
        {
            CustomerBiz biz = new CustomerBiz();
            double Mymoney = biz.GET_CUSTOMER_BALANCE(GetCusID());
            lbMymoney.Text = Mymoney.ToString("###,##0.00");
        }

        protected void BindMasterVIP()
        {
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = new DataTable();
            dt = biz.GetMasterVIP();
            if (dt != null && dt.Rows.Count > 0)
            {
                Session["VIP"] = dt;
                rdbList.DataSource = dt;
                rdbList.DataTextField = "VIP_NAME";
                rdbList.DataValueField = "VIP_ID";
                rdbList.DataBind();

                rdbList.SelectedIndex = 0;
            }
        }

        protected void BindHistoryVIP()
        {
            CustomerBiz biz = new CustomerBiz();
            DataTable dt = new DataTable();
            dt = biz.GetHistoryVIP(GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {
                gvResult.DataSource = dt;
                gvResult.DataBind();
            }
            else
            {
                gvResult.DataSource = null;
                gvResult.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CustomerBiz Biz = new CustomerBiz();
            
            double Bal = lbMymoney.Text == "" ? 0 : Convert.ToDouble(lbMymoney.Text);
            double Price = 0; //get from selected Value

            if (rdbList.SelectedIndex != -1)
            {
                if (Session["VIP"] != null)
                {
                    DataTable dt = (DataTable)Session["VIP"];
                    DataRow[] dr = dt.Select("VIP_ID=" + rdbList.SelectedItem.Value);
                    if (dr.Length > 0)
                        Price = Convert.ToDouble(dr[0]["VIP_PRICE"].ToString());
                    else
                    {
                        WriteLog(Page.Request.Url.AbsolutePath, "Regis VIP", "Session VIP");
                        ShowMessageBox("สมัคร VIP ไม่สำเร็จ กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }
                }

                if (Bal >= Price)
                {
                    //Get VIP Type, get from selected Value
                    int VIP_ID = Convert.ToInt32(rdbList.SelectedItem.Value);

                    //Insert Transaction
                    string Result = "";
                    Result = Biz.Regis_VIP(GetCusID(), VIP_ID);
                    if (Result == "")
                        ShowMessageBox("ลูกค้าเป็นสมาชิก VIP เรียบร้อยแล้ว");
                    else
                    {
                        WriteLog(Page.Request.Url.AbsolutePath, "Regis VIP", Result);
                        ShowMessageBox("สมัคร VIP ไม่สำเร็จ กรุณาติดต่อผู้ดูแลระบบ");
                        return;
                    }
                }
                else
                {
                    ShowMessageBox("เงินในบัญชีไม่พอ กรุณาเติมเงินก่อนค่ะ");
                    return;
                }
            }
            else
            {
                ShowMessageBox("กรุณาเลือกบริการ ViP ที่ลูกค้าต้องการ");
                return;
            }
        }
    }
} 