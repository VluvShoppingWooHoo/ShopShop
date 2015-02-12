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
        public SqlCommand Sql_commandData;
        public LogonDal(string strConnection)
        {
            Sql_commandData = new SqlCommand(strConnection);
        }
        #endregion

        public DataTable LogonUser(string User, string Pass)
        {
            DataTable dt = new DataTable();
            return dt;
        }
    }
}
