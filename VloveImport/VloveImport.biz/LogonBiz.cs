using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using VloveImport.data;

namespace VloveImport.biz
{
    public class LogonBiz
    {
        public CustomerData LogonDBCustomer(string User, string Pass)
        {
            CustomerData Cust = new CustomerData();
            LogonDal dal = new LogonDal("");
            DataTable dt = dal.LogonUser(User, Pass);
            if (dt != null && dt.Rows.Count > 0)
            {
                SaveSessionCustomer(Cust);
            }
            return Cust;
        }

        private void SaveSessionCustomer(CustomerData Cust)
        {

        }
    }
}
