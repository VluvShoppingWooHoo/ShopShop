using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using VloveImport.data;

namespace VloveImport.biz
{
    public class CustomerBiz
    {
        public string InsertRegisCustomer(CustomerData EnCus,string Act)
        {
            string Result = "";
            CustomerDal dal = new CustomerDal("LocalConnection");
            Result = dal.INS_UPD_Customer_Address(EnCus, Act);
            return Result;
        }
    }
}
