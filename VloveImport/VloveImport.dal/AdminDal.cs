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

        public DataSet GET_MASTER_STATUS(string STATUS_TYPE, string Act,string STS_NAME)
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

        public DataSet GET_ADMIN_ORDER(int ORDER_ID, Nullable<DateTime> START_DATE, Nullable<DateTime> END_DATE, string CUS_CODE,int ORDER_STATUS, string Act)
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

        public DataSet GET_ADMIN_TRANSACTION(int TRAN_ID, Nullable<DateTime> START_DATE, Nullable<DateTime> END_DATE, string CUS_CODE, int TRAN_STATUS,int TRAN_TYPE,int TRAN_TABLE_TYPE, string Act)
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
                SqlCommandData.SetParameter_Input_INT("TRAN_TYPE", SqlDbType.VarChar, ParameterDirection.Input, EnTran.TRAN_TYPE);
                SqlCommandData.SetParameter_Input_INT("TRAN_TABLE_TYPE", SqlDbType.VarChar, ParameterDirection.Input, EnTran.TRAN_TABLE_TYPE);
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

    }
}
