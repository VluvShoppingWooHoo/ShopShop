using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace VloveImport.dal
{
    public class CommandData
    {
        #region Comment

        private SqlCommand command;
        private SqlConnection objConn;
        private SqlTransaction Trans;

        private string SqlCon { get; set; }
        public string SqlConnectionName { get; set; }


        public CommandData(string ConnectionName)
        {
            try
            {
                SqlConnectionName = ConnectionName;
                objConn = new SqlConnection();
                command = new SqlCommand();
            }
            catch (Exception ex)
            {
                throw new Exception("On Constructor Error CommandData: " + ex.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BeginTransaction()
        {
            try
            {
                Trans = objConn.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Connection = objConn;
                command.Transaction = Trans;
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("BeginTransaction: " + ex.Message);
            }
        }

        public void Commit()
        {
            try
            {
                Trans.Commit();
                Dispose();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("Commit: " + ex.Message);
            }
        }

        public void RollBack()
        {
            try
            {
                Trans.Rollback();
                Dispose();
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("RollBack: " + ex.Message);
            }
        }

        public DataSet ExecuteDataSet()
        {
            DataSet ds = new DataSet();

            try
            {
                OpenConnection();
                command.Connection = objConn;
                IDbDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = command;
                dataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                Dispose();
                throw new Exception("ExecuteDataSet: " + ex.Message);
            }
            finally
            {
                Dispose();
            }
            return ds;
        }

        public bool ExecuteNonQuery()
        {
            int ret = 0;
            try
            {
                ret = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery: " + ex.Message);
            }
            //catch
            if (ret == 0) return false;
            else return true;
        }

        public bool ExeScalar()
        {
            try
            {
                command = new SqlCommand(command.CommandText, objConn);
                Trans = objConn.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Connection = objConn;
                command.Transaction = Trans;
                command.ExecuteScalar();
                Trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery: " + ex.Message);
            }
        }

        /// <summary>
        /// จะ Return เป็น จำนวน Rows ที่ ถูกทำงาน
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQueryRowAffact()
        {
            int ret = 0;
            try
            {
                ret = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery: " + ex.Message);
            }
            //catch
            return ret;
        }

        public bool ExecuteScalar()
        {
            int ret = 0;
            try
            {
                ret = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteNonQuery: " + ex.Message);
            }
            //catch
            if (ret == 0) return false;
            else return true;
        }

        public void OpenConnection()
        {
            try
            {
                if (objConn != null)
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                    objConn.ConnectionString = GetConnectionString();
                    objConn.Open();
                }
                else
                {
                    throw new Exception("On method OpenCeonnection cannot open connection object connection is null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("On method OpenCeonnection cannot open connection : " + ex.Message);
            }
        }

        public void SetStoreProcedure(string storeProcedure)
        {
            command.Parameters.Clear();
            command.CommandText = storeProcedure;
            command.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public string GetOutputStoreProcedure(string Parameters_Name)
        {
            return command.Parameters[Parameters_Name].Value.ToString();
        }

        public void SetSQLCommand(string sqlCommand)
        {
            command.CommandText = sqlCommand;
            command.CommandType = System.Data.CommandType.Text;
        }

        public void SetParameter(string parameterName, SqlDbType dbType, ParameterDirection direction)
        {
            SetParameter(parameterName, dbType, direction, null);
        }

        public void SetParameter_Input_INT(string parameterName, SqlDbType dbType, ParameterDirection direction, object vals)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Direction = direction;
            param.Value = vals;
            command.Parameters.Add(param);
        }

        public void SetParameter_Input_DataTable(string parameterName, ParameterDirection direction, object vals)
        {
            SqlParameter param = new SqlParameter(parameterName, new DataTable());
            param.Direction = direction;
            param.Value = vals;
            command.Parameters.Add(param);
        }

        public void SetParameter(string parameterName, SqlDbType dbType, ParameterDirection direction, object vals)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Direction = direction;
            param.Value = vals;
            command.Parameters.Add(param);
        }

        public void SetParameter(string parameterName, SqlDbType dbType, ParameterDirection direction, int size)
        {
            SqlParameter param = new SqlParameter(parameterName, dbType);
            param.Direction = direction;
            param.Size = size;
            command.Parameters.Add(param);
        }

        private void Dispose(bool disposing)
        {

            if (disposing)
            {
                if (command != null)
                {
                    if (command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close();
                    }
                    command.Connection.Dispose();
                    command.Dispose();
                }
            }
        }

        private string GetConnectionString()
        {
            try
            {
                return OracleGetConnectionString(SqlConnectionName);
            }
            catch (Exception ex)
            {
                throw new Exception(" -- > GetConnectionString() Method: " + ex.Message);
            }
        }

        internal string OracleGetConnectionString(string connectionName)
        {
            try
            {
                string conString = "";
                util.EncrypUtil Encryp = new util.EncrypUtil();
                //conString = Encryp.DecryptData(WebConfigurationManager.ConnectionStrings);
                conString = Encryp.DecryptData(WebConfigurationManager.AppSettings[connectionName].ToString());
                return conString;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion


        public DataSet ExecuteDataSet(SqlCommand SqlCmd)
        {
            DataSet ds = new DataSet();

            try
            {
                IDbDataAdapter dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = SqlCmd;
                dataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception("ExecuteDataSet: " + ex.Message);
            }
            return ds;
        }

    }

}

