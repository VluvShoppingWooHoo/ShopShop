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

        public string InsertCustomer(CustomerData Cust)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("InsertCustomer");

                SqlCommandData.SetParameter("Cus_Name", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_LName", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_LName);
                SqlCommandData.SetParameter("Cus_Gender", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Gender);
                SqlCommandData.SetParameter("Cus_Birthday", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Birthday);
                SqlCommandData.SetParameter("Cus_Telephone", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_Mobile", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_Fax", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_Email", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_Password", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_Password", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);
                SqlCommandData.SetParameter("Cus_Password", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Name);

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
    }
}
