using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.data;

namespace VloveImport.dal
{
    public class AdminDal
    {
        #region Constructor
        public CommandData SqlCommandData;
        public AdminDal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }
        #endregion

        #region ADMIN ORDER

        public void TestCon()
        {
            try
            {
                SqlCommandData.OpenConnection();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet GET_MASTER_STATUS(string STATUS_TYPE, string Act, string STS_NAME)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_MASTER_STATUS");

                SqlCommandData.SetParameter("STATUS_NAME", SqlDbType.VarChar, ParameterDirection.Input, STS_NAME);
                SqlCommandData.SetParameter("TYPE_NAME", SqlDbType.VarChar, ParameterDirection.Input, STATUS_TYPE);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_MASTER_STATUS -> msg : " + ex.Message);
            }
        }

        public DataSet GET_ADMIN_ORDER(int ORDER_ID, Nullable<DateTime> START_DATE, Nullable<DateTime> END_DATE, string CUS_CODE, int ORDER_STATUS, string Act)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_ORDER");

                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, ORDER_ID);
                SqlCommandData.SetParameter("START_DATE", SqlDbType.Date, ParameterDirection.Input, START_DATE);
                SqlCommandData.SetParameter("END_DATE", SqlDbType.Date, ParameterDirection.Input, END_DATE);
                SqlCommandData.SetParameter("CUS_CODE", SqlDbType.VarChar, ParameterDirection.Input, CUS_CODE);
                SqlCommandData.SetParameter_Input_INT("ORDER_STATUS", SqlDbType.Int, ParameterDirection.Input, ORDER_STATUS);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ADMIN_ORDER -> msg : " + ex.Message);
            }
        }

        public string UPD_ADMIN_ORDER(OrderData En, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("ADMIN_UPDATE_ORDER");

                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, En.ORDER_ID);
                SqlCommandData.SetParameter_Input_INT("ORDER_STAUTS", SqlDbType.VarChar, ParameterDirection.Input, En.ORDER_STATUS);
                SqlCommandData.SetParameter("ORDER_ID_LIST", SqlDbType.VarChar, ParameterDirection.Input, En.ORDER_ID_LIST);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, En.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("UPD_ADMIN_ORDER -> msg : " + ex.Message);
            }
        }

        public string UPD_ADMIN_ORDER_PROD_AMOUNT(int ORDER_ID, int ORDER_DETAIL_ID, int PROD_NUM, string CREATE_USER, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("ADMIN_UPDATE_ORDER_PROD_AMOUNT");

                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, ORDER_ID);
                SqlCommandData.SetParameter_Input_INT("ORDER_DETAIL_ID", SqlDbType.VarChar, ParameterDirection.Input, ORDER_DETAIL_ID);
                SqlCommandData.SetParameter_Input_INT("PROD_NUM", SqlDbType.VarChar, ParameterDirection.Input, PROD_NUM);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, CREATE_USER);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("UPD_ADMIN_ORDER_PROD_AMOUNT -> msg : " + ex.Message);
            }
        }

        #endregion

        #region Admin Transaction

        public DataSet GET_ADMIN_TRANSACTION(int TRAN_ID, Nullable<DateTime> START_DATE, Nullable<DateTime> END_DATE, string CUS_CODE, int TRAN_STATUS, int TRAN_TYPE, int TRAN_TABLE_TYPE, string Act)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_TRANSACTION_APPROVE");

                SqlCommandData.SetParameter_Input_INT("TRAN_ID", SqlDbType.Int, ParameterDirection.Input, TRAN_ID);
                SqlCommandData.SetParameter("START_DATE", SqlDbType.Date, ParameterDirection.Input, START_DATE);
                SqlCommandData.SetParameter("END_DATE", SqlDbType.Date, ParameterDirection.Input, END_DATE);
                SqlCommandData.SetParameter("CUS_CODE", SqlDbType.VarChar, ParameterDirection.Input, CUS_CODE);
                SqlCommandData.SetParameter_Input_INT("TRAN_STATUS", SqlDbType.Int, ParameterDirection.Input, TRAN_STATUS);
                SqlCommandData.SetParameter_Input_INT("TRAN_TYPE", SqlDbType.Int, ParameterDirection.Input, TRAN_TYPE);
                SqlCommandData.SetParameter_Input_INT("TRAN_TABLE_TYPE", SqlDbType.Int, ParameterDirection.Input, TRAN_TABLE_TYPE);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ADMIN_ORDER -> msg : " + ex.Message);
            }
        }

        public string INS_UPD_TRANSACTION(TransactionData EnTran, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("ADMIN_INS_UPD_TRANSACTION");

                SqlCommandData.SetParameter_Input_INT("TRAN_ID", SqlDbType.Int, ParameterDirection.Input, EnTran.TRAN_ID);
                SqlCommandData.SetParameter_Input_INT("TRAN_TYPE", SqlDbType.Int, ParameterDirection.Input, EnTran.TRAN_TYPE);
                SqlCommandData.SetParameter_Input_INT("TRAN_TABLE_TYPE", SqlDbType.Int, ParameterDirection.Input, EnTran.TRAN_TABLE_TYPE);
                SqlCommandData.SetParameter("TRAN_DETAIL", SqlDbType.VarChar, ParameterDirection.Input, EnTran.TRAN_DETAIL);
                SqlCommandData.SetParameter("TRAN_REMARK", SqlDbType.VarChar, ParameterDirection.Input, EnTran.TRAN_REMARK);
                SqlCommandData.SetParameter_Input_INT("TRAN_AMOUNT", SqlDbType.Float, ParameterDirection.Input, EnTran.TRAN_AMOUNT);

                SqlCommandData.SetParameter_Input_INT("TRAN_STATUS", SqlDbType.Int, ParameterDirection.Input, EnTran.TRAN_STATUS);
                //SqlCommandData.SetParameter_Input_INT("TRAN_STATUS_APPROVE", SqlDbType.Int, ParameterDirection.Input, EnTran.TRAN_STATUS_APPROVE);
                SqlCommandData.SetParameter_Input_INT("EMP_ID_APPROVE", SqlDbType.Int, ParameterDirection.Input, EnTran.EMP_ID_APPROVE);
                SqlCommandData.SetParameter("EMP_REMARK", SqlDbType.VarChar, ParameterDirection.Input, EnTran.EMP_REMARK);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, EnTran.Cus_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ACC_NAME_ID", SqlDbType.Int, ParameterDirection.Input, EnTran.CUS_ACC_NAME_ID);
                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, EnTran.ORDER_ID);
                SqlCommandData.SetParameter_Input_INT("PAYMENT_TYPE", SqlDbType.Int, ParameterDirection.Input, EnTran.PAYMENT_TYPE);
                SqlCommandData.SetParameter("PAYMENT_DATE", SqlDbType.DateTime, ParameterDirection.Input, EnTran.PAYMENT_DATE);
                SqlCommandData.SetParameter("PAYMENT_TIME", SqlDbType.VarChar, ParameterDirection.Input, EnTran.PAYMENT_TIME);
                SqlCommandData.SetParameter_Input_INT("BANK_SHOP_ID", SqlDbType.Int, ParameterDirection.Input, EnTran.BANK_ID);

                SqlCommandData.SetParameter("TRAN_ID_LIST", SqlDbType.VarChar, ParameterDirection.Input, EnTran.TRAN_ID_LIST);

                //SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnTran.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("INS_UPD_TRANSACTION -> msg : " + ex.Message);
            }
        }

        #endregion

        #region Group User

        public DataSet GET_ADMIN_GET_GROUP_USER(int GROUP_ID, string GROUP_NAME, int GROUP_STATUS, string Act)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_DATA_GROUP_USER");

                SqlCommandData.SetParameter_Input_INT("GROUP_ID", SqlDbType.Int, ParameterDirection.Input, GROUP_ID);
                SqlCommandData.SetParameter("GROUP_NAME", SqlDbType.VarChar, ParameterDirection.Input, GROUP_NAME);
                SqlCommandData.SetParameter_Input_INT("GROUP_STATUS", SqlDbType.Int, ParameterDirection.Input, GROUP_STATUS);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ADMIN_GET_GROUP_USER -> msg : " + ex.Message);
            }
        }

        public string ADMIN_INS_GROUP_USER(AdminUserData En, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("ADMIN_INS_UPD_DATA_GROUP_USER");

                SqlCommandData.SetParameter_Input_INT("GROUP_ID", SqlDbType.Int, ParameterDirection.Input, En.GROUP_ID);
                SqlCommandData.SetParameter("GROUP_NAME", SqlDbType.VarChar, ParameterDirection.Input, En.GROUP_NAME);
                SqlCommandData.SetParameter("GROUP_ROLE", SqlDbType.VarChar, ParameterDirection.Input, En.GROUP_ROLE);
                SqlCommandData.SetParameter("GROUP_REMARK", SqlDbType.VarChar, ParameterDirection.Input, En.GROUP_REMARK);
                SqlCommandData.SetParameter_Input_INT("GROUP_STATUS", SqlDbType.Int, ParameterDirection.Input, En.GROUP_STATUS);

                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, En.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("ADMIN_INS_GROUP_USER -> msg : " + ex.Message);
            }
        }

        #endregion

        #region User

        public DataSet GET_ADMIN_GET_USER(int EMP_ID, string USERNAME, string EMP_NAME, int EMP_STATUS, string Act)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_DATA_USER");

                SqlCommandData.SetParameter_Input_INT("EMP_ID", SqlDbType.Int, ParameterDirection.Input, EMP_ID);
                SqlCommandData.SetParameter("USERNAME", SqlDbType.VarChar, ParameterDirection.Input, USERNAME);
                SqlCommandData.SetParameter("EMP_NAME", SqlDbType.VarChar, ParameterDirection.Input, EMP_NAME);
                SqlCommandData.SetParameter_Input_INT("EMP_STATUS", SqlDbType.Int, ParameterDirection.Input, EMP_STATUS);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ADMIN_GET_GROUP_USER -> msg : " + ex.Message);
            }
        }

        public string ADMIN_INS_USER(AdminUserData En, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("ADMIN_INS_UPD_DATA_USER");

                SqlCommandData.SetParameter_Input_INT("EMP_ID", SqlDbType.Int, ParameterDirection.Input, En.EMP_ID);
                SqlCommandData.SetParameter("USERNAME", SqlDbType.VarChar, ParameterDirection.Input, En.USERNAME);
                SqlCommandData.SetParameter("EMP_PASSWORD", SqlDbType.VarChar, ParameterDirection.Input, En.EMP_PASSWORD);
                SqlCommandData.SetParameter("EMP_NAME", SqlDbType.VarChar, ParameterDirection.Input, En.EMP_NAME);
                SqlCommandData.SetParameter("EMP_LNAME", SqlDbType.VarChar, ParameterDirection.Input, En.EMP_LNAME);
                SqlCommandData.SetParameter("EMP_DETAIL", SqlDbType.VarChar, ParameterDirection.Input, En.EMP_DETAIL);
                SqlCommandData.SetParameter_Input_INT("EMP_STATUS", SqlDbType.Int, ParameterDirection.Input, En.EMP_STATUS);
                SqlCommandData.SetParameter_Input_INT("GROUP_ID", SqlDbType.Int, ParameterDirection.Input, En.GROUP_ID);

                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, En.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("ADMIN_INS_GROUP_USER -> msg : " + ex.Message);
            }
        }

        #endregion

        #region Config

        public DataSet ADMIN_GET_CONFIG(string CONFIG_ID, string CONFIG_GROUP, string Act)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_DATA_CONFIG");

                SqlCommandData.SetParameter("CONFIG_ID", SqlDbType.VarChar, ParameterDirection.Input, CONFIG_ID);
                SqlCommandData.SetParameter("CONFIG_GROUP", SqlDbType.VarChar, ParameterDirection.Input, CONFIG_GROUP);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("ADMIN_GET_CONFIG -> msg : " + ex.Message);
            }
        }

        public string ADMIN_UPD_CONFIG(CommonData En, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("ADMIN_UPD_DATA_CONFIG");

                SqlCommandData.SetParameter("CONFIG_ID", SqlDbType.VarChar, ParameterDirection.Input, En.CONFIG_ID);
                SqlCommandData.SetParameter("CONFIG_VALUE", SqlDbType.VarChar, ParameterDirection.Input, En.CONFIG_VALUE);
                SqlCommandData.SetParameter("CONFIG_VALUE2", SqlDbType.VarChar, ParameterDirection.Input, En.CONFIG_VALUE2);
                SqlCommandData.SetParameter("CONFIG_VALUE3", SqlDbType.VarChar, ParameterDirection.Input, En.CONFIG_VALUE3);
                SqlCommandData.SetParameter("CONFIG_GROUP", SqlDbType.VarChar, ParameterDirection.Input, En.CONFIG_GROUP);
                SqlCommandData.SetParameter("CONFIG_REMARK", SqlDbType.VarChar, ParameterDirection.Input, En.CONFIG_REMARK);

                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, En.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("ADMIN_UPD_CONFIG -> msg : " + ex.Message);
            }
        }

        #endregion

        #region Customer

        public DataSet ADMIN_GET_CUSTOMER(CustomerData En, string Act)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_DATA_CUSTOMER");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.VarChar, ParameterDirection.Input, En.Cus_ID);
                SqlCommandData.SetParameter("CUS_CODE", SqlDbType.VarChar, ParameterDirection.Input, En.Cus_Code);
                SqlCommandData.SetParameter("CUS_NAME", SqlDbType.VarChar, ParameterDirection.Input, En.Cus_Name);
                SqlCommandData.SetParameter("CUS_BIRTHDAY_FROM", SqlDbType.Date, ParameterDirection.Input, En.CUS_BIRTHDAY_FROM);
                SqlCommandData.SetParameter("CUS_BIRTHDAY_TO", SqlDbType.VarChar, ParameterDirection.Input, En.CUS_BIRTHDAY_TO);
                SqlCommandData.SetParameter("CUS_EMAIL", SqlDbType.VarChar, ParameterDirection.Input, En.Cus_Email);
                SqlCommandData.SetParameter("CUS_TELEPHONE", SqlDbType.VarChar, ParameterDirection.Input, En.Cus_Telephone);
                SqlCommandData.SetParameter("SYMBOW_TYPE", SqlDbType.VarChar, ParameterDirection.Input, En.SYMBOW_TYPE);
                SqlCommandData.SetParameter("CUS_AMOUNT", SqlDbType.Float, ParameterDirection.Input, En.CUS_AMOUNT);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("ADMIN_GET_CUSTOMER -> msg : " + ex.Message);
            }
        }

        #endregion

        #region CMS
        public DataSet ADMIN_GET_CMS(string ID, string Title, string Content_Type, string Act)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_CMS");

                SqlCommandData.SetParameter_Input_INT("CONTENT_ID", SqlDbType.Int, ParameterDirection.Input, ID);
                SqlCommandData.SetParameter("CONTENT_TITLE", SqlDbType.VarChar, ParameterDirection.Input, Title);
                SqlCommandData.SetParameter_Input_INT("CONTENT_TYPE", SqlDbType.Int, ParameterDirection.Input, Content_Type);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("ADMIN_GET_CMS -> msg : " + ex.Message);
            }
        }
        public string ADMIN_INS_UPD_CMS(ContentData cd , string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("ADMIN_INS_UPD_CMS");

                SqlCommandData.SetParameter_Input_INT("CONTENT_ID", SqlDbType.Int, ParameterDirection.Input, cd.ContentID);
                SqlCommandData.SetParameter("CONTENT_TITLE", SqlDbType.NVarChar, ParameterDirection.Input, cd.ContentTitle);
                SqlCommandData.SetParameter("CONTENT_IMG", SqlDbType.VarChar, ParameterDirection.Input, cd.ContentImage);
                SqlCommandData.SetParameter("CONTENT_DETAIL", SqlDbType.NVarChar, ParameterDirection.Input, cd.ContentDetail);
                SqlCommandData.SetParameter_Input_INT("CONTENT_TYPE", SqlDbType.Int, ParameterDirection.Input, int.Parse(cd.ContentType));
                SqlCommandData.SetParameter_Input_INT("IS_ACTIVE", SqlDbType.Int, ParameterDirection.Input, cd.IsActive);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("ADMIN_INS_UPD_CMS -> msg : " + ex.Message);
            }
        }

        #endregion
    }
}
