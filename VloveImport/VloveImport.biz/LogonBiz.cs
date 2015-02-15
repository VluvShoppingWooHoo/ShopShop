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
        public CustomerData LogonDBCustomer(string User, string Pass)
        {
            CustomerData Cust = new CustomerData();
            LogonDal dal = new LogonDal("LocalConnection");
            DataTable dt = new DataTable();
            dt = dal.LogonUser(User);
            if (dt != null && dt.Rows.Count > 0)
            {
                EncrypUtil en = new EncrypUtil();
                string PassDB = "";
                PassDB = dt.Rows[0]["Cus_Password"].ToString();
                PassDB = en.DecryptData(PassDB);
                if (PassDB == Pass)
                {
                    Cust.Cus_ID = dt.Rows[0]["Cus_ID"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_ID"].ToString());
                    Cust.Cus_Name = dt.Rows[0]["Cus_Name"].ToString();
                    Cust.Cus_LName = dt.Rows[0]["Cus_LName"].ToString();
                    if (dt.Rows[0]["Cus_BirthDay"].ToString() != "")
                        Cust.Cus_BirthDay = Convert.ToDateTime(dt.Rows[0]["Cus_BirthDay"].ToString());

                    Cust.Cus_Telephone = dt.Rows[0]["Cus_Telephone"].ToString();
                    Cust.Cus_Mobile = dt.Rows[0]["Cus_Mobile"].ToString();
                    Cust.Cus_Fax = dt.Rows[0]["Cus_Fax"].ToString();
                    Cust.Cus_Email = dt.Rows[0]["Cus_Email"].ToString();
                    //Cust.Cus_Password = dt.Rows[0]["Cus_Password"].ToString();
                    Cust.Cus_Withdraw_Code = dt.Rows[0]["Cus_Withdraw_Code"].ToString();
                    Cust.Cus_Link_Shop = dt.Rows[0]["Cus_Link_Shop"].ToString();

                    Cust.Cus_Point = dt.Rows[0]["Cus_Point"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_Point"].ToString());
                    Cust.Cus_Ref_ID = dt.Rows[0]["Cus_Ref_ID"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_Ref_ID"].ToString());
                    Cust.Cus_Active = dt.Rows[0]["Cus_Active"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_Active"].ToString());
                    Cust.Cus_Status = dt.Rows[0]["Cus_Status"].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0]["Cus_Status"].ToString());
                    if (dt.Rows[0]["Activate_Date"].ToString() != "")
                        Cust.Activate_Date = Convert.ToDateTime(dt.Rows[0]["Activate_Date"].ToString());
                }
            }
            return Cust;
        }
      
    }
}
