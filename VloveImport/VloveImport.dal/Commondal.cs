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

                    IDbDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = SqlCmd;
                    dataAdapter.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("SP_EADW_GET_MENULISTALL -> msg : " + ex.Message);
            }
            return ds;
        }

        public void ActionDATA()
        {
            Int32 rowsAffected;
            using (SqlConnection SqlConn = new SqlConnection(SqlConnectionName))
            {
                SqlCommand SqlCmd = new SqlCommand("CustOrderHist", SqlConn);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "";

                SqlConn.Open();
                rowsAffected = SqlCmd.ExecuteNonQuery();
            }
        }

    }
}
