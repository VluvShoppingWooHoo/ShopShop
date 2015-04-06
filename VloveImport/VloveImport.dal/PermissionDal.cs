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
    public class PermissionDal
    {
        #region Constructor
        public CommandData SqlCommandData;
        public PermissionDal(string strConnection)
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

        #region Permission
        public DataSet GetPageByURL(string Page_URL)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("SP_FX_GET_PAGEBYURL");
               
                //Input                
                SqlCommandData.SetParameter("P_PAGE_URL", SqlDbType.VarChar, ParameterDirection.Input, Page_URL);

                return SqlCommandData.ExecuteDataSet();

            }
            catch (Exception ex)
            {
                throw new Exception("SP_EADW_GET_PAGEBYURL -> msg : " + ex.Message);
            }
        }
        #endregion
    }
}
