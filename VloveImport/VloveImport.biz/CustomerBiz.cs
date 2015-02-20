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
    public class CustomerBiz
    {

        #region CUSTOMER ADDRESS

        public string InsertRegisCustomer(CustomerData EnCus, string Act)
        {
            string Result = "";
            CustomerDal dal = new CustomerDal("LocalConnection");
            Result = dal.INS_UPD_Customer_Address(EnCus, Act);
            return Result;
        }

        public DataSet GetData_Customer_Address(int CUS_ID, int CUS_ADD_ID, int CUS_ADDRESS_STATUS, string CUS_ADDRESS_NAME,string Act)
        {
            DataSet ds = new DataSet();
            CustomerDal dal = new CustomerDal("LocalConnection");
            ds = dal.GetData_Customer_Address(CUS_ID, CUS_ADD_ID, CUS_ADDRESS_STATUS, CUS_ADDRESS_NAME, Act);
            return ds;
        }

        #endregion


    }
}
