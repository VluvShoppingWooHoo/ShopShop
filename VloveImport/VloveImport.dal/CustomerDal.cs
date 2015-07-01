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
    public class CustomerDal
    {
        #region Constructor
        public CommandData SqlCommandData;
        public CustomerDal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }
        #endregion
        #region CustomerMyAccout
        public DataSet GET_CUSTOMER_MYACCOUNT(int CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_MYACCOUNT");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GetData_Customer_Address -> msg : " + ex.Message);
            }
        }
        #endregion

        #region CUSTOMER
        public DataSet GetData_Customer_Profile(int CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_PROFILE");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
               
                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GetData_Customer_Address -> msg : " + ex.Message);
            }
        }
        public string UPDATE_Customer_Profile(CustomerData EnCus)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("UPDATE_CUSTOMER_PROFILE");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.Cus_ID);

                SqlCommandData.SetParameter("CUS_NAME", SqlDbType.NVarChar, ParameterDirection.Input, EnCus.Cus_Name);
                SqlCommandData.SetParameter("CUS_LNAME", SqlDbType.NVarChar, ParameterDirection.Input, EnCus.Cus_LName);
                if (EnCus.Cus_BirthDay != "")
                    SqlCommandData.SetParameter("CUS_BIRTHDAY", SqlDbType.Date, ParameterDirection.Input, Convert.ToDateTime(EnCus.Cus_BirthDay));
                else
                    SqlCommandData.SetParameter("CUS_BIRTHDAY", SqlDbType.Date, ParameterDirection.Input, DBNull.Value);

                SqlCommandData.SetParameter("CUS_GENDER", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Cus_Gender);
                SqlCommandData.SetParameter("CUS_LINK_SHOP", SqlDbType.NVarChar, ParameterDirection.Input, EnCus.Cus_Link_Shop);
                SqlCommandData.SetParameter("CUS_PIC", SqlDbType.NVarChar, ParameterDirection.Input, EnCus.CUS_Pic);
                SqlCommandData.SetParameter("UPDATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Update_User);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("Insert_Customer_Address -> msg : " + ex.Message);
            }
        }
        public DataSet Get_Customer_Profile_By_Email(string Email)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_PROFILE_BY_EMAIL");
                SqlCommandData.SetParameter("EMAIL", SqlDbType.VarChar, ParameterDirection.Input, Email);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_CUSTOMER_PROFILE_BY_EMAIL -> msg : " + ex.Message);
            }
        }
        #endregion

        #region CUSTOMER ADDRESS

        public DataSet GetData_Customer_Address(int CUS_ID, int CUS_ADD_ID, int CUS_ADDRESS_STATUS, string Act, string CUS_ADD_CUS_NAME, int REGION_ID, int PROVINCE_ID, int CUS_ADD_ZIPCODE)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_ADDRESS");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ADD_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ADD_ID);

                SqlCommandData.SetParameter_Input_INT("CUS_ADDRESS_STATUS", SqlDbType.Int, ParameterDirection.Input, CUS_ADDRESS_STATUS);
                SqlCommandData.SetParameter("CUS_ADD_CUS_NAME", SqlDbType.VarChar, ParameterDirection.Input, CUS_ADD_CUS_NAME);
                SqlCommandData.SetParameter_Input_INT("REGION_ID", SqlDbType.Int, ParameterDirection.Input, REGION_ID);
                SqlCommandData.SetParameter_Input_INT("PROVINCE_ID", SqlDbType.Int, ParameterDirection.Input, PROVINCE_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ADD_ZIPCODE", SqlDbType.Int, ParameterDirection.Input, CUS_ADD_ZIPCODE);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);


                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GetData_Customer_Address -> msg : " + ex.Message);
            }
        }

        public string INS_UPD_Customer_Address(CustomerData EnCus, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_UPD_CUSTOMER_ADDRESS");

                SqlCommandData.SetParameter_Input_INT("CUS_ADD_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.CUS_ADD_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.Cus_ID);

                SqlCommandData.SetParameter("CUS_ADD_CUS_NAME", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_CUS_NAME);
                SqlCommandData.SetParameter("CUS_ADD_ADDRESS_TEXT", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_ADDRESS_TEXT);
                SqlCommandData.SetParameter("CUS_ADD_ZIPCODE", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_ZIPCODE.ToString());
                SqlCommandData.SetParameter_Input_INT("CUS_ADD_STATUS", SqlDbType.Int, ParameterDirection.Input, EnCus.CUS_ADD_STATUS);
                SqlCommandData.SetParameter_Input_INT("REGION_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.REGION_ID);
                SqlCommandData.SetParameter_Input_INT("PROVINCE_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.PROVINCE_ID);
                SqlCommandData.SetParameter_Input_INT("DISTRICT_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.DISTRICT_ID);
                SqlCommandData.SetParameter_Input_INT("SUB_DISTRICT_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.SUB_DISTRICT_ID);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("Insert_Customer_Address -> msg : " + ex.Message);
            }
        }

        #endregion

        #region CUSTOMER BANK

        public DataSet GET_CUSTOMER_ACCOUNT_BANK(int CUS_ID, int CUS_ACC_NAME_ID, int CUS_ACC_NAME_STAUTS, string Act, string CUS_ACC_NAME, string CUS_ACC_NAME_NO, string CUS_ACC_NAME_BRANCH,int BANK_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_ACCOUNT_BANK");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ACC_NAME_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ACC_NAME_ID);
                SqlCommandData.SetParameter("CUS_ACC_NAME", SqlDbType.VarChar, ParameterDirection.Input, CUS_ACC_NAME);
                SqlCommandData.SetParameter("CUS_ACC_NAME_NO", SqlDbType.VarChar, ParameterDirection.Input, CUS_ACC_NAME_NO);
                SqlCommandData.SetParameter("CUS_ACC_NAME_BRANCH", SqlDbType.VarChar, ParameterDirection.Input, CUS_ACC_NAME_BRANCH);
                SqlCommandData.SetParameter_Input_INT("CUS_ACC_NAME_STAUTS", SqlDbType.Int, ParameterDirection.Input, CUS_ACC_NAME_STAUTS);
                SqlCommandData.SetParameter_Input_INT("BANK_ID", SqlDbType.Int, ParameterDirection.Input, BANK_ID);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);
                
                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_CUSTOMER_ACCOUNT_BANK -> msg : " + ex.Message);
            }
        }

        public string INS_UPD_CUSTOMER_ACCOUNT_BANK(CustomerData EnCus, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_UPD_CUSTOMER_ACCOUNT_BANK");

                SqlCommandData.SetParameter_Input_INT("CUS_ACC_NAME_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.CUS_ACC_NAME_ID);
                SqlCommandData.SetParameter("CUS_ACC_NAME", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ACC_NAME);
                SqlCommandData.SetParameter("CUS_ACC_NAME_NO", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ACC_NAME_NO);
                SqlCommandData.SetParameter("CUS_ACC_NAME_BRANCH", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ACC_NAME_BRANCH);
                SqlCommandData.SetParameter("CUS_ACC_NAME_REMARK", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ACC_NAME_REMARK);
                SqlCommandData.SetParameter_Input_INT("CUS_ACC_NAME_STAUTS", SqlDbType.Int, ParameterDirection.Input, EnCus.CUS_ACC_NAME_STAUTS);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.Cus_ID);
                SqlCommandData.SetParameter_Input_INT("BANK_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.BANK_ID);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("INS_UPD_CUSTOMER_ACCOUNT_BANK -> msg : " + ex.Message);
            }
        }

        #endregion

        #region CUSTOMER FAVORIT SHOP

        public DataSet GET_CUSTOMER_FAVORIT_SHOP(int CUS_ID, int CUS_SHOP_ID, int CUS_SHOP_STATUS, string Act, string CUS_SHOP_NAME)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_FAVORIT_SHOP");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_SHOP_ID", SqlDbType.Int, ParameterDirection.Input, CUS_SHOP_ID);
                SqlCommandData.SetParameter("CUS_SHOP_NAME", SqlDbType.VarChar, ParameterDirection.Input, CUS_SHOP_NAME);
                SqlCommandData.SetParameter_Input_INT("CUS_SHOP_STATUS", SqlDbType.Int, ParameterDirection.Input, CUS_SHOP_STATUS);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);


                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_CUSTOMER_FAVORIT_SHOP -> msg : " + ex.Message);
            }
        }

        public string INS_UPD_CUSTOMER_FAVORIT_SHOP(CustomerData EnCus, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_UPD_CUSTOMER_FAVORIT_SHOP");

                SqlCommandData.SetParameter_Input_INT("CUS_SHOP_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.CUS_SHOP_ID);
                SqlCommandData.SetParameter("CUS_SHOP_NAME", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_SHOP_NAME);
                SqlCommandData.SetParameter("CUS_SHOP_LINK", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_SHOP_LINK);
                SqlCommandData.SetParameter("CUS_SHOP_REMARK", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_SHOP_REMARK);
                SqlCommandData.SetParameter("CUS_SHOP_STATUS", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_SHOP_STATUS);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.Cus_ID);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("INS_UPD_CUSTOMER_FAVORIT_SHOP -> msg : " + ex.Message);
            }
        }

        #endregion

        #region TRANSACTION

        public string INS_UPD_TRANSACTION(TransactionData EnTran, string Act, Int32 Status)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_UPD_TRANSACTION");

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
                SqlCommandData.SetParameter("TRANS_PICURL", SqlDbType.VarChar, ParameterDirection.Input, EnTran.TRANS_PICURL);
                //SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnTran.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);
                SqlCommandData.SetParameter_Input_INT("Status", SqlDbType.Int, ParameterDirection.Input, Status);

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
        public DataSet GET_TRANSACTION_BY_ORDERID(Int32 Order_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_TRANSACTION_BY_ORDERID");

                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, Order_ID);                

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_TRANSACTION_BY_ORDERID -> msg : " + ex.Message);
            }
        }
        public string INS_VOUCHER(int CUS_ID)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_VOUCHER");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);                

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("INS_VOUCHER -> msg : " + ex.Message);
            }
        }
        #endregion

        #region GET CUSTOMER ...
        public DataSet GET_CUSTOMER_BALANCE(int CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_BALANCE");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_CUSTOMER_BALANCE -> msg : " + ex.Message);
            }
        }

        public DataSet GET_CUSTOMER_TRANSLOG(int CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_TRANSLOG");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_CUSTOMER_TRANS_HIS -> msg : " + ex.Message);
            }
        }

        public DataSet GET_CUSTOMER_TRANS_AMOUNT(int CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_TRANS_AMOUNT");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_CUSTOMER_TRANS_AMOUNT -> msg : " + ex.Message);
            }
        }

        public DataSet GET_CUSTOMER_POINT(int CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_POINT");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_CUSTOMER_POINT -> msg : " + ex.Message);
            }
        }
        #endregion

        #region CUSTOMER_PASSWORD
        public string CHANGE_PASSWORD(Int32 CUS_ID, string Pass, string  TYPE)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("CHANGE_PASSWORD");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter("PASSWORD", SqlDbType.NVarChar, ParameterDirection.Input, Pass);
                SqlCommandData.SetParameter("TYPE_PASS", SqlDbType.NVarChar, ParameterDirection.Input, TYPE);                

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("CHANGE_PASSWORD -> msg : " + ex.Message);
            }
        }
        public string RESET_PASSWORD(string Pass, int CUS_ID, string TYPE_PASS)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("UPDATE_CUSTOMER_REPASS");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter("PASSWORD", SqlDbType.NVarChar, ParameterDirection.Input, Pass);
                SqlCommandData.SetParameter("TYPE_PASS", SqlDbType.NVarChar, ParameterDirection.Input, TYPE_PASS);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("UPDATE_CUSTOMER_REPASS -> msg : " + ex.Message);
            }
        }
        #endregion
    }
}
