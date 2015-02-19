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

        public Commondal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }

        #region Example

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

        #endregion

        #region Binding Data Address

        public DataSet GetData_Region(int ADD_ID ,string ADD_NAME = "", int ADD_STATUS = 1,string Act = "")
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_DATA_MASTER_ADDRESS");

                SqlCommandData.SetParameter("ADD_ID", SqlDbType.Int, ParameterDirection.Input, ADD_ID);
                SqlCommandData.SetParameter("ADD_NAME", SqlDbType.VarChar, ParameterDirection.Input, ADD_NAME);
                SqlCommandData.SetParameter("ADD_STATUS", SqlDbType.Int, ParameterDirection.Input, ADD_STATUS);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, ADD_STATUS);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GetData_Region -> msg : " + ex.Message);
            }
        }

        #region Comment

        //public DataSet GetData_Region(string REGION_NAME = "", int REGION_STATUS = 1)
        //{
        //    try
        //    {
        //        SqlCommandData.SetStoreProcedure("GetData_Master_Region");

        //        SqlCommandData.SetParameter("REGION_NAME", SqlDbType.VarChar, ParameterDirection.Input, REGION_NAME);
        //        SqlCommandData.SetParameter("REGION_STATUS", SqlDbType.VarChar, ParameterDirection.Input, REGION_STATUS);
        //        return SqlCommandData.ExecuteDataSet();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetData_Region -> msg : " + ex.Message);
        //    }
        //}

        //public DataSet GetData_Province(int REGION_ID = -1, string PROVINCE_NAME = "", int PROVINCE_STATUS = 1)
        //{
        //    try
        //    {
        //        SqlCommandData.SetStoreProcedure("GetData_Master_Province");

        //        SqlCommandData.SetParameter("REGION_ID", SqlDbType.VarChar, ParameterDirection.Input, REGION_ID);
        //        SqlCommandData.SetParameter("PROVINCE_NAME", SqlDbType.VarChar, ParameterDirection.Input, PROVINCE_NAME);
        //        SqlCommandData.SetParameter("PROVINCE_STATUS", SqlDbType.VarChar, ParameterDirection.Input, PROVINCE_STATUS);
        //        return SqlCommandData.ExecuteDataSet();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetData_Province -> msg : " + ex.Message);
        //    }
        //}

        //public DataSet GetData_District(int PROVINCE_ID = -1, string DISTRICT_NAME = "", int DISTRICT_STATUS = 1)
        //{
        //    try
        //    {
        //        SqlCommandData.SetStoreProcedure("GetData_Master_Province");

        //        SqlCommandData.SetParameter("PROVINCE_ID", SqlDbType.VarChar, ParameterDirection.Input, PROVINCE_ID);
        //        SqlCommandData.SetParameter("DISTRICT_NAME", SqlDbType.VarChar, ParameterDirection.Input, DISTRICT_NAME);
        //        SqlCommandData.SetParameter("DISTRICT_STATUS", SqlDbType.VarChar, ParameterDirection.Input, DISTRICT_STATUS);
        //        return SqlCommandData.ExecuteDataSet();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetData_District -> msg : " + ex.Message);
        //    }
        //}

        //public DataSet GetData_District(int PROVINCE_ID = -1, string DISTRICT_NAME = "", int DISTRICT_STATUS = 1)
        //{
        //    try
        //    {
        //        SqlCommandData.SetStoreProcedure("GetData_Master_Province");

        //        SqlCommandData.SetParameter("PROVINCE_ID", SqlDbType.VarChar, ParameterDirection.Input, PROVINCE_ID);
        //        SqlCommandData.SetParameter("DISTRICT_NAME", SqlDbType.VarChar, ParameterDirection.Input, DISTRICT_NAME);
        //        SqlCommandData.SetParameter("DISTRICT_STATUS", SqlDbType.VarChar, ParameterDirection.Input, DISTRICT_STATUS);
        //        return SqlCommandData.ExecuteDataSet();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetData_District -> msg : " + ex.Message);
        //    }
        //}

        //public DataSet GetData_District(int DISTRICT_ID = -1, string SUB_DISTRICT_NAME = "", int SUB_DISTRICT_STATUS = 1)
        //{
        //    try
        //    {
        //        SqlCommandData.SetStoreProcedure("GetData_Master_Province");

        //        SqlCommandData.SetParameter("DISTRICT_ID", SqlDbType.VarChar, ParameterDirection.Input, DISTRICT_ID);
        //        SqlCommandData.SetParameter("SUB_DISTRICT_NAME", SqlDbType.VarChar, ParameterDirection.Input, SUB_DISTRICT_NAME);
        //        SqlCommandData.SetParameter("SUB_DISTRICT_STATUS", SqlDbType.VarChar, ParameterDirection.Input, SUB_DISTRICT_STATUS);
        //        return SqlCommandData.ExecuteDataSet();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("GetData_District -> msg : " + ex.Message);
        //    }
        //}


        #endregion


        #endregion

    }


    #region  comment

    //public class Commondal
    //{
    //    public CommandData SqlCommandData;

    //    public string SqlConnectionName;

    //    public Commondal(string strConnection)
    //    {
    //        util.EncrypUtil Encryp = new util.EncrypUtil();
    //        SqlConnectionName = Encryp.DecryptData(WebConfigurationManager.AppSettings[strConnection].ToString());
    //    }

    //    public DataSet GetData()
    //    {
    //        DataSet ds = new DataSet();
    //        try
    //        {
    //            using (SqlConnection SqlConn = new SqlConnection(SqlConnectionName))
    //            {
    //                SqlConn.Open();
    //                SqlCommand SqlCmd = new SqlCommand("GetLogOnCustomer", SqlConn);

    //                SqlCmd.CommandType = CommandType.StoredProcedure;

    //                SqlCmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = "eakkarat_5@Hotmail.com";
    //                SqlCmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = "123";

    //                IDbDataAdapter dataAdapter = new SqlDataAdapter();
    //                dataAdapter.SelectCommand = SqlCmd;
    //                dataAdapter.Fill(ds);
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("GetData -> msg : " + ex.Message);
    //        }
    //        return ds;
    //    }

    //    public void ActionDATA()
    //    {
    //        Int32 rowsAffected;
    //        try
    //        {
    //            using (SqlConnection SqlConn = new SqlConnection(SqlConnectionName))
    //            {
    //                SqlCommand SqlCmd = new SqlCommand("CustOrderHist", SqlConn);
    //                SqlCmd.CommandType = CommandType.StoredProcedure;
    //                SqlCmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = "";

    //                SqlConn.Open();
    //                rowsAffected = SqlCmd.ExecuteNonQuery();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            throw new Exception("ActionDATA -> msg : " + ex.Message);
    //        }
    //    }

    //}

    #endregion

}
