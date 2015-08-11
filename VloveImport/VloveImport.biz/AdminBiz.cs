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

        public DataSet GET_MASTER_STATUS(string STATUS_TYPE, string Act, string STS_NAME = "")
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GET_MASTER_STATUS(STATUS_TYPE, Act, STS_NAME);
            return ds;
        }

        #region ORDER

        public void TestCon()
        {
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                dal.TestCon();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UPD_ADMIN_ORDER(OrderData En, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.UPD_ADMIN_ORDER(En, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public DataSet GET_ADMIN_ORDER(string Act, int ORDER_ID = -1, Nullable<DateTime> START_DATE = null, Nullable<DateTime> END_DATE = null, string CUS_NAME = "", int ORDER_STATUS = -1, string ORDER_CODE = "")
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GET_ADMIN_ORDER(ORDER_ID, START_DATE, END_DATE, CUS_NAME, ORDER_STATUS, ORDER_CODE, Act);
            return ds;
        }

        public string UPD_ADMIN_ORDER_PROD_AMOUNT(int ORDER_ID, int ORDER_DETAIL_ID, int PROD_NUM, double PROD_PRICE_ACTIVE, string CREATE_USER, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.UPD_ADMIN_ORDER_PROD_AMOUNT(ORDER_ID, ORDER_DETAIL_ID, PROD_NUM, PROD_PRICE_ACTIVE, CREATE_USER, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public string UPD_ADMIN_ORDER_SHOP(OrderData En, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.UPD_ADMIN_ORDER_SHOP(En, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public string UPDATE_ORDER_DETAIL_RECEIP(OrderData En, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.UPDATE_ORDER_DETAIL_RECEIP(En, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public string ADMIN_UPDATE_ORDER_CANCLE(string ORDER_ID, string CREATE_USER, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.ADMIN_UPDATE_ORDER_CANCLE(ORDER_ID, CREATE_USER, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        #endregion

        #region Transaction

        public DataSet GET_ADMIN_TRANSACTION(int TRAN_ID, Nullable<DateTime> START_DATE, Nullable<DateTime> END_DATE, string CUS_CODE, int TRAN_STATUS, int TRAN_TYPE, int TRAN_TABLE_TYPE, string Act)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GET_ADMIN_TRANSACTION(TRAN_ID, START_DATE, END_DATE, CUS_CODE, TRAN_STATUS, TRAN_TYPE, TRAN_TABLE_TYPE, Act);
            return ds;
        }

        public string INS_UPD_TRANSACTION(TransactionData EnTran, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.INS_UPD_TRANSACTION(EnTran, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        #endregion

        #region Group user

        public DataSet GET_ADMIN_GET_GROUP_USER(int GROUP_ID, string GROUP_NAME, int GROUP_STATUS, string Act)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GET_ADMIN_GET_GROUP_USER(GROUP_ID, GROUP_NAME, GROUP_STATUS, Act);
            return ds;
        }

        public string ADMIN_INS_GROUP_USER(AdminUserData En, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.ADMIN_INS_GROUP_USER(En, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        #endregion

        #region User

        public DataSet GET_ADMIN_GET_USER(int EMP_ID, string USERNAME, string EMP_NAME, int EMP_STATUS, string Act)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GET_ADMIN_GET_USER(EMP_ID, USERNAME, EMP_NAME, EMP_STATUS, Act);
            return ds;
        }

        public string ADMIN_INS_USER(AdminUserData En, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.ADMIN_INS_USER(En, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        #endregion

        #region Config

        public DataSet ADMIN_GET_CONFIG(string CONFIG_ID, string CONFIG_GROUP, string Act, string CONFIG_VALUE = "")
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.ADMIN_GET_CONFIG(CONFIG_ID, CONFIG_GROUP, Act, CONFIG_VALUE);
            return ds;
        }

        public string ADMIN_UPD_CONFIG(CommonData En, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.ADMIN_UPD_CONFIG(En, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        #endregion

        #region Customer

        public DataSet ADMIN_GET_CUSTOMER(CustomerData En, string Act)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.ADMIN_GET_CUSTOMER(En, Act);
            return ds;
        }

        #endregion

        #region CMS

        public DataSet ADMIN_GET_CMS_HEADER(string ID, string Title, int Active, string Act)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.ADMIN_GET_CMS_HEADER(ID, Title, Active, Act);
            return ds;
        }

        public string ADMIN_INS_UPD_CMS_HEADER(ContentData cd, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.ADMIN_INS_UPD_CMS_HEADER(cd, Act);
            }
            catch (Exception ex) { }
            return Result;
        }

        public DataSet ADMIN_GET_CMS(string ID, string Title, string Content_Type, int Active, string Header_ID, string Act)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.ADMIN_GET_CMS(ID, Title, Content_Type, Active, Header_ID, Act);
            return ds;
        }

        public string ADMIN_INS_UPD_CMS(ContentData cd, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.ADMIN_INS_UPD_CMS(cd, Act);
            }
            catch (Exception ex) { }
            return Result;
        }
        #endregion

        public DataSet GetReportCustomerOrder(DateTime OrderDateStart, DateTime OrderDateEnd, string CustomerCode,string Act)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GetReportCustomerOrder(OrderDateStart, OrderDateEnd, CustomerCode, Act);
            return ds;
        }

    }
}
