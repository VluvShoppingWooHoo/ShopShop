using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class Activate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EncrypUtil en = new EncrypUtil();
            string Email = Request.QueryString["e"] == null ? "" : en.DecryptData(Request.QueryString["e"]);
            string Pass = Request.QueryString["c"] == null ? "" : en.DecryptData(Request.QueryString["c"]);
            UpdateActivateCustomer(Email, Pass);
        }

        protected void UpdateActivateCustomer(string Email, string Pass)
        {
            LogonBiz Logon = new LogonBiz();
            CustomerBiz biz = new CustomerBiz();
            string Result = "", PassDB = "";
            Int32 CUS_ID = 0;
            DataTable dt = new DataTable();
            dt = biz.Get_Customer_Profile_By_Email(Email);
            if (dt != null && dt.Rows.Count > 0)
            {
                CUS_ID = Convert.ToInt32(dt.Rows[0]["CUS_ID"].ToString());
                PassDB = DecryptData(dt.Rows[0]["CUS_PASSWORD"].ToString());
                if (Pass == PassDB)
                {
                    Result = Logon.UpdateActivateCustomer(CUS_ID);
                }
                else
                {
                    mView.ActiveViewIndex = 1;
                    return;
                }
            }
            
            if (Result == "1")
            {
                mView.ActiveViewIndex = 0;
            }
            else
            {
                //WriteLog
                mView.ActiveViewIndex = 1;
                return;
            }
        }
    }
}