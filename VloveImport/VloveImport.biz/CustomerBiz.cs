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
        #region CUSTOMER_PROFILE
        public DataSet GetData_Customer(int CUS_ID, int CUS_ADD_ID, int CUS_ADDRESS_STATUS, string CUS_ADDRESS_NAME, string Act)
        {
            DataSet ds = new DataSet();
            CustomerDal dal = new CustomerDal("LocalConnection");
            //ds = dal.GetData_Customer_Address(CUS_ID, CUS_ADD_ID, CUS_ADDRESS_STATUS, Act);
            return ds;
        }
        public string UPDATE_Customer(CustomerData EnCus)
        {
            string Result = "";
            try
            {
                CustomerDal dal = new CustomerDal("LocalConnection");
                Result = dal.UPDATE_Customer(EnCus);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }
        #endregion


        #region CUSTOMER ADDRESS

        public string INS_UPD_Customer_Address(CustomerData EnCus, string Act)
        {
            string Result = "";
            try
            {
                CustomerDal dal = new CustomerDal("LocalConnection");
                Result = dal.INS_UPD_Customer_Address(EnCus, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result; 
        }

        public DataSet GetData_Customer_Address(int CUS_ID, int CUS_ADD_ID, int CUS_ADDRESS_STATUS, string Act, string CUS_ADD_CUS_NAME = "", int REGION_ID = -1, int PROVINCE_ID = -1, int CUS_ADD_ZIPCODE = -1)
        {
            DataSet ds = new DataSet();
            CustomerDal dal = new CustomerDal("LocalConnection");
            ds = dal.GetData_Customer_Address(CUS_ID, CUS_ADD_ID, CUS_ADDRESS_STATUS, Act, CUS_ADD_CUS_NAME, REGION_ID, PROVINCE_ID, CUS_ADD_ZIPCODE);
            return ds;
        }

        #endregion




    }
}
