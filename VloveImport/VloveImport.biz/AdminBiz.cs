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
    public class AdminBiz
    {
        #region  CUSTOMER FAVORIT SHOP

        //public string INS_UPD_CUSTOMER_FAVORIT_SHOP(CustomerData EnCus, string Act)
        //{
        //    string Result = "";
        //    try
        //    {
        //        CustomerDal dal = new CustomerDal("LocalConnection");
        //        Result = dal.INS_UPD_CUSTOMER_FAVORIT_SHOP(EnCus, Act);
        //    }
        //    catch (Exception ex)
        //    {
        //        Result = ex.Message;
        //    }
        //    return Result;
        //}

        public DataSet GET_ADMIN_ORDER(string Act,int ORDER_ID = -1, Nullable<DateTime> START_DATE = null, Nullable<DateTime> END_DATE = null, string CUS_NAME = "")
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GET_ADMIN_ORDER(ORDER_ID, START_DATE, END_DATE,CUS_NAME, Act);
            return ds;
        }

        #endregion
    }
}
