using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
