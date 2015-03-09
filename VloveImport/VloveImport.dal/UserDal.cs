using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.data;

namespace VloveImport.dal
{
    public class UserDal
    {
        #region Constructor
        public CommandData SqlCommandData;
        public UserDal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }
        #endregion

        public string InsertUser(UserData Data)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INSERT_USER");

                //SqlCommandData.SetParameter_Input_INT("USER_ID", SqlDbType.Int, ParameterDirection.Input, Data.User_ID);

                SqlCommandData.SetParameter("FIRSTNAME", SqlDbType.VarChar, ParameterDirection.Input, Data.FirstName);
                SqlCommandData.SetParameter("LASTNAME", SqlDbType.VarChar, ParameterDirection.Input, Data.LastLName);
                SqlCommandData.SetParameter("LOGIN", SqlDbType.VarChar, ParameterDirection.Input, Data.Login);
                SqlCommandData.SetParameter_Input_INT("PASSWORD", SqlDbType.VarChar, ParameterDirection.Input, Data.Password);
                //SqlCommandData.SetParameter_Input_INT("CUS_EMAIL", SqlDbType.Int, ParameterDirection.Input, Data.Cus_Email);
                //SqlCommandData.SetParameter_Input_INT("CUS_LINK_SHOP", SqlDbType.Int, ParameterDirection.Input, EnCus.Cus_Link_Shop);
                //SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Create_User);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("INSERT_USER -> msg : " + ex.Message);
            }
        }

        public string UpdateUser(UserData Data)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("UPDATE_USER");

                SqlCommandData.SetParameter_Input_INT("USER_ID", SqlDbType.Int, ParameterDirection.Input, Data.User_ID);

                SqlCommandData.SetParameter("FIRSTNAME", SqlDbType.VarChar, ParameterDirection.Input, Data.FirstName);
                SqlCommandData.SetParameter("LASTNAME", SqlDbType.VarChar, ParameterDirection.Input, Data.LastLName);
                SqlCommandData.SetParameter("LOGIN", SqlDbType.VarChar, ParameterDirection.Input, Data.Login);
                SqlCommandData.SetParameter_Input_INT("PASSWORD", SqlDbType.VarChar, ParameterDirection.Input, Data.Password);
                //SqlCommandData.SetParameter_Input_INT("CUS_EMAIL", SqlDbType.Int, ParameterDirection.Input, Data.Cus_Email);
                //SqlCommandData.SetParameter_Input_INT("CUS_LINK_SHOP", SqlDbType.Int, ParameterDirection.Input, EnCus.Cus_Link_Shop);
                //SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, EnCus.Create_User);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("UPDATE_USER -> msg : " + ex.Message);
            }
        }

        public DataSet GetUser(string Login, string Name)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_USER");
                SqlCommandData.SetParameter_Input_INT("LOGIN", SqlDbType.VarChar, ParameterDirection.Input, Login);
                SqlCommandData.SetParameter_Input_INT("NAME", SqlDbType.VarChar, ParameterDirection.Input, Name);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_USER -> msg : " + ex.Message);
            }           
        }
    }
}
