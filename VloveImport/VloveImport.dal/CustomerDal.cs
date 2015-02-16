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

        public DataSet GetData(string ProcName)
        {
            try
            {
                SqlCommandData.SetStoreProcedure(ProcName);

                SqlCommandData.SetParameter("UserName", SqlDbType.VarChar, ParameterDirection.Input, "eakkarat_5@Hotmail.com");
                SqlCommandData.SetParameter("Password", SqlDbType.VarChar, ParameterDirection.Input, "123");
                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GetData -> msg : " + ex.Message);
            }
        }

        public string Insert_Customer_Address(CustomerData EnCus)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("Insert_Customer_Address");

                SqlCommandData.SetParameter("CUS_ID", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ID);
                SqlCommandData.SetParameter("Cus_Password", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Cus_Password);
                SqlCommandData.SetParameter("Cus_Mobile", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Cus_Mobile);
                SqlCommandData.SetParameter_Input_INT("Cus_Ref_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.Cus_Ref_ID);

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


    }
}
