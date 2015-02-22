using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using System.Data.SqlClient;
using VloveImport.util;

namespace VloveImport.biz
{
    public class commonBiz
    {

        public DataSet GetData_Region(int ADD_ID = 0, string ADD_NAME = "", int ADD_STATUS = 1, string Act = "")
        {
            Commondal Com = new Commondal("LocalConnection");
            return Com.GetData_Region(ADD_ID, ADD_NAME, ADD_STATUS, Act);
        }

    }
}
