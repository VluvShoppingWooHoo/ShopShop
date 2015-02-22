using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using System.Data.SqlClient;
using VloveImport.util;
using VloveImport.data;

namespace VloveImport.biz
{
    public class commonBiz
    {

        public DataSet GetData_Region(int ADD_ID = 0, string ADD_NAME = "", int ADD_STATUS = 1, string Act = "")
        {
            Commondal Com = new Commondal("LocalConnection");
            return Com.GetData_Region(ADD_ID, ADD_NAME, ADD_STATUS, Act);
        }

        #region MASTER BANK

        public DataSet GET_DATA_MASTER_BANK(int BANK_ID, string Act)
        {
            Commondal Com = new Commondal("LocalConnection");
            return Com.GET_DATA_MASTER_BANK(BANK_ID, Act);
        }

        public string INS_UPD_DATA_MASTER_BANK(CommonData EnBank, string Act)
        {
            Commondal Com = new Commondal("LocalConnection");
            return Com.INS_UPD_DATA_MASTER_BANK(EnBank, Act);
        }

        #endregion

    }
}
