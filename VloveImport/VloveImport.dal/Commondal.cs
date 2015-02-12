using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using System.Data.SqlClient;
using System.Data;
using VloveImport.util;
using System.Web;
using System.Web.Configuration;

namespace VloveImport.dal
{
    public class Commondal
    {
        public CommandData SqlCommandData;
        public string SqlConnectionName;

        public Commondal(string strConnection)
        {
            util.EncrypUtil Encryp = new util.EncrypUtil();
            SqlConnectionName = Encryp.DecryptData(WebConfigurationManager.AppSettings[strConnection].ToString());
        }

        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection SqlConn = new SqlConnection(SqlConnectionName))
                {
                    SqlConn.Open();
                    SqlCommand SqlCmd = new SqlCommand("CustOrderHist", SqlConn);

                    SqlCmd.CommandType = CommandType.StoredProcedure;

                    SqlCmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "";

                    ds = SqlCommandData.ExecuteDataSet(SqlCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("GetData -> msg : " + ex.Message);
            }
            return ds;
        }

        public void ActionDATA()
        {
            Int32 rowsAffected;
            try
            {
                using (SqlConnection SqlConn = new SqlConnection(SqlConnectionName))
                {
                    SqlCommand SqlCmd = new SqlCommand("CustOrderHist", SqlConn);
                    SqlCmd.CommandType = CommandType.StoredProcedure;
                    SqlCmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "";

                    SqlConn.Open();
                    rowsAffected = SqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ActionDATA -> msg : " + ex.Message);
            }
        }

    }

    public class Commondal2
    {
        public CommandData SqlCommandData;

        public Commondal2(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }

        public DataSet GetData()
        {
            try
            {
                SqlCommandData.SetStoreProcedure("SP_EADW_GET_MENULISTALL");
                SqlCommandData.SetParameter("P_TYPE", SqlDbType.VarChar, ParameterDirection.Input, "");
                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GetData -> msg : " + ex.Message);
            }
        }

        public string ActionDATA()
        {
            string IsReturn = "";
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();

                SqlCommandData.SetStoreProcedure("SP_EADW_UPDATE_PWD");

                //Input                 
                SqlCommandData.SetParameter("P_BY_PASS", SqlDbType.VarChar, ParameterDirection.Input, "");

                SqlCommandData.ExecuteScalar();
                IsReturn = "";

                SqlCommandData.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("ActionDATA -> msg : " + ex.Message);
            }
            finally
            {
                SqlCommandData.Dispose();
            }

            return IsReturn;
        }

    }

}
