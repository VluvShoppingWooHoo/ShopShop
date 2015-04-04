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
    public class LogonDal
    {
        #region Constructor  
        public CommandData SqlCommandData;
        public LogonDal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }
        #endregion

        public DataTable LogonUser(string UserName)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GetLogOnCustomer");

                SqlCommandData.SetParameter("UserName", SqlDbType.VarChar, ParameterDirection.Input, UserName);
                DataSet ds = new DataSet();
                ds = SqlCommandData.ExecuteDataSet();
                if (ds != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                throw new Exception("LogonUser -> msg : " + ex.Message);                
            }
        }

        public string InsertRegisCustomer(CustomerData Cust)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("InsertRegisCustomer");

                SqlCommandData.SetParameter("Cus_Code", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Code);
                SqlCommandData.SetParameter("Cus_Name", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_Email", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Email);
                SqlCommandData.SetParameter("Cus_Password", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Password);
                SqlCommandData.SetParameter("Cus_Mobile", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Mobile);
                SqlCommandData.SetParameter_Input_INT("Cus_Ref_ID", SqlDbType.Int, ParameterDirection.Input, Cust.Cus_Ref_ID);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("LogonUser -> msg : " + ex.Message);
                SqlCommandData.RollBack();
                return ("InsertRegisCustomer -> msg : " + ex.Message);
            }
        }

        public string InsertRegisCustomerFB(CustomerData Cust)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("InsertRegisCustomerFB");

                SqlCommandData.SetParameter("Cus_Code", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Code);
                SqlCommandData.SetParameter("Cus_Email", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Email);
                SqlCommandData.SetParameter("Cus_Password", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Password);
                SqlCommandData.SetParameter("Cus_Mobile", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Mobile);
                SqlCommandData.SetParameter_Input_INT("Cus_Ref_ID", SqlDbType.Int, ParameterDirection.Input, Cust.Cus_Ref_ID);

                SqlCommandData.SetParameter("Cus_Name", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_LName", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_LName);
                SqlCommandData.SetParameter("Cus_Gender", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Gender);
                SqlCommandData.SetParameter("Cus_FB_ID", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_FB_ID);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("LogonUser -> msg : " + ex.Message);
                SqlCommandData.RollBack();
                return ("InsertRegisCustomerFB -> msg : " + ex.Message);
            }
        }

        public string UpdateActivateCustomer(Int32 CUS_ID)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("UpdateActivateCustomer");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("LogonUser -> msg : " + ex.Message);
                SqlCommandData.RollBack();
                return ("UpdateActivateCustomer -> msg : " + ex.Message);
            }
        }
    }
}
