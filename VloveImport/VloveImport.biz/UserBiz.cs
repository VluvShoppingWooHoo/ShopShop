using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using VloveImport.data;

namespace VloveImport.biz
{
    public class UserBiz
    {
        public string InsertUser(UserData Data)
        {
            string Result = "";
            UserDal Dal = new UserDal("LocalConnection");
            Result = Dal.InsertUser(Data);
            return Result;
        }

        public string UpdateUser(UserData Data)
        {
            string Result = "";
            UserDal Dal = new UserDal("LocalConnection");
            Result = Dal.UpdateUser(Data);
            return Result;
        }

        public DataTable GetUser(string Login, string Name)
        {
            DataSet ds = new DataSet();
            UserDal Dal = new UserDal("LocalConnection");
            ds = Dal.GetUser(Login, Name);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public DataSet GET_USER_LOGIN(string USERNAME, string Act)
        {
            DataSet ds = new DataSet();
            UserDal dal = new UserDal("LocalConnection");
            ds = dal.GET_USER_LOGIN(USERNAME, Act);
            return ds;
        }

    }
}
