using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VloveImport.dal
{
    public class commonDal
    {
        public string ConnStr = "";
        public SqlConnection SqlCon;
        public SqlCommand Sqlcmd;

        public commonDal()
        { 
            
        }

        public DataSet GETDATA(string Search1)
        {
            try
            {
                SqlCon = new SqlConnection("");
                Sqlcmd = new SqlCommand("", SqlCon);

                Sqlcmd.Parameters.Add("", SqlDbType.VarChar).Value = "";

                //SqlCon.Open();
                //Sqlcmd.ExecuteReader(

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
