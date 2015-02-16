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

        public DataSet GetData_Customer_Address(int CUS_ID, int CUS_ADD_ID, int CUS_ADDRESS_STATUS, string CUS_ADDRESS_NAME)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GetData_Customer_Address");

                SqlCommandData.SetParameter("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter("CUS_ADD_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ADD_ID);

                SqlCommandData.SetParameter("CUS_ADDRESS_STATUS", SqlDbType.Int, ParameterDirection.Input, CUS_ADDRESS_STATUS);
                SqlCommandData.SetParameter("CUS_ADDRESS_NAME", SqlDbType.VarChar, ParameterDirection.Input, CUS_ADDRESS_NAME);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GetData_Customer_Address -> msg : " + ex.Message);
            }
        }

        public string INS_UPD_Customer_Address(CustomerData EnCus,string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_UPD_Customer_Address");

                SqlCommandData.SetParameter("CUS_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.Cus_ID);

                SqlCommandData.SetParameter("CUS_ADD_CUS_NAME", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_CUS_NAME);
                SqlCommandData.SetParameter("CUS_ADD_ADDRESS_TEXT", SqlDbType.VarChar, ParameterDirection.Input, EnCus.CUS_ADD_ADDRESS_TEXT);
                SqlCommandData.SetParameter("CUS_ADD_ZIPCODE", SqlDbType.Int, ParameterDirection.Input, EnCus.CUS_ADD_ZIPCODE);
                SqlCommandData.SetParameter("CUS_ADD_STATUS", SqlDbType.Int, ParameterDirection.Input, EnCus.CUS_ADD_STATUS);
                SqlCommandData.SetParameter("REGION_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.REGION_ID);
                SqlCommandData.SetParameter("PROVINCE_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.PROVINCE_ID);
                SqlCommandData.SetParameter("DISTRICT_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.DISTRICT_ID);
                SqlCommandData.SetParameter("SUB_DISTRICT_ID", SqlDbType.Int, ParameterDirection.Input, EnCus.SUB_DISTRICT_ID);
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


    }
}
