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

        public string Insert_Customer_Address(CustomerData EnCus,string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("Insert_Customer_Address");

                SqlCommandData.SetParameter("CUS_ID", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Cus_ID);

                SqlCommandData.SetParameter("CUS_ADD_CUS_NAME", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_CUS_NAME);
                SqlCommandData.SetParameter("CUS_ADD_ADDRESS_TEXT", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_ADDRESS_TEXT);
                SqlCommandData.SetParameter("CUS_ADD_ZIPCODE", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_ZIPCODE);
                SqlCommandData.SetParameter("CUS_ADD_STATUS", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_STATUS);
                SqlCommandData.SetParameter("REGION_ID", SqlDbType.VarChar, ParameterDirection.Input, EnCus.REGION_ID);
                SqlCommandData.SetParameter("PROVINCE_ID", SqlDbType.VarChar, ParameterDirection.Input, EnCus.PROVINCE_ID);
                SqlCommandData.SetParameter("DISTRICT_ID", SqlDbType.VarChar, ParameterDirection.Input, EnCus.DISTRICT_ID);
                SqlCommandData.SetParameter("SUB_DISTRICT_ID", SqlDbType.VarChar, ParameterDirection.Input, EnCus.SUB_DISTRICT_ID);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("LogonUser -> msg : " + ex.Message);
                SqlCommandData.RollBack();
                return ("Insert_Customer_Address -> msg : " + ex.Message);
            }
        }


    }
}
