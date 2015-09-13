using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using VloveImport.data;
using VloveImport.util;

namespace VloveImport.biz
{
    public class LogonBiz
    {
        public CustomerData LogonDBCustomer(string User, string Pass , int isFB)
        {
            CustomerData Cust = new CustomerData();
            LogonDal dal = new LogonDal("LocalConnection");
            DataTable dt = new DataTable();
            dt = dal.LogonUser(User);
            if (dt != null && dt.Rows.Count > 0)
            {
                EncrypUtil en = new EncrypUtil();
                string PassDB = "";
                if (isFB != 1)
                {
                    PassDB = dt.Rows[0]["Cus_Password"].ToString();
                    PassDB = en.DecryptData(PassDB);
                }
                if (PassDB == Pass)
                {
                    Cust.Cus_ID = dt.Rows[0]["Cus_ID"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_ID"].ToString());
                    Cust.Cus_Code = dt.Rows[0]["Cus_Code"].ToString();
                    Cust.Cus_Name = dt.Rows[0]["Cus_Name"].ToString();
                    Cust.Cus_LName = dt.Rows[0]["Cus_LName"].ToString();
                    Cust.Cus_BirthDay = dt.Rows[0]["Cus_BirthDay"].ToString();

                    Cust.Cus_Telephone = dt.Rows[0]["Cus_Telephone"].ToString();
                    Cust.Cus_Mobile = dt.Rows[0]["Cus_Mobile"].ToString();
                    Cust.Cus_Fax = dt.Rows[0]["Cus_Fax"].ToString();
                    Cust.Cus_Email = dt.Rows[0]["Cus_Email"].ToString();
                    Cust.Cus_Password = dt.Rows[0]["Cus_Password"].ToString();
                    Cust.Cus_Withdraw_Code = dt.Rows[0]["Cus_Withdraw_Code"].ToString();
                    Cust.Cus_Link_Shop = dt.Rows[0]["Cus_Link_Shop"].ToString();

                    Cust.Cus_Point = dt.Rows[0]["Cus_Point"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_Point"].ToString());
                    Cust.Cus_Ref_ID = dt.Rows[0]["Cus_Ref_ID"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_Ref_ID"].ToString());
                    Cust.Cus_Active = dt.Rows[0]["Cus_Activate"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_Activate"].ToString());
                    Cust.Cus_Status = dt.Rows[0]["Cus_Status"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_Status"].ToString());
                    if (dt.Rows[0]["Activate_Date"].ToString() != "")
                        Cust.Activate_Date = Convert.ToDateTime(dt.Rows[0]["Activate_Date"].ToString());

                    //VIP
                    Cust.Cus_VIP_Percent = dt.Rows[0]["VIP_PERCENT"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["VIP_PERCENT"].ToString());
                    if (dt.Rows[0]["TRANS_DATE"].ToString() != "")
                        Cust.Cus_VIP_Trans_Date = Convert.ToDateTime(dt.Rows[0]["TRANS_DATE"].ToString());
                    if (dt.Rows[0]["START_DATE"].ToString() != "")
                        Cust.Cus_VIP_Start_Date = Convert.ToDateTime(dt.Rows[0]["START_DATE"].ToString());
                    if (dt.Rows[0]["END_DATE"].ToString() != "")
                        Cust.Cus_VIP_End_Date = Convert.ToDateTime(dt.Rows[0]["END_DATE"].ToString());

                    return Cust;
                }
            }
            return null;
        }

        public string InsertRegisCustomer(CustomerData Cust)
        {
            string Result = "";
            LogonDal dal = new LogonDal("LocalConnection");
            Result = dal.InsertRegisCustomer(Cust);
            return Result;
        }

        public string InsertRegisCustomerFB(CustomerData Cust)
        {
            string Result = "";
            LogonDal dal = new LogonDal("LocalConnection");
            Result = dal.InsertRegisCustomerFB(Cust);
            return Result;
        }

        public bool RegisValidEmail(string EMAIL)
        {           
            LogonDal dal = new LogonDal("LocalConnection");
            DataTable dt = new DataTable();
            dt = dal.GET_EMAIL_REGIS(EMAIL);
            if (dt != null && dt.Rows.Count > 0)
                return false;
            else
                return true;
        }

        public string UpdateActivateCustomer(Int32 CUS_ID)
        {
            string Result = "";
            LogonDal dal = new LogonDal("LocalConnection");
            Result = dal.UpdateActivateCustomer(CUS_ID);
            return Result;
        }
    }
}
