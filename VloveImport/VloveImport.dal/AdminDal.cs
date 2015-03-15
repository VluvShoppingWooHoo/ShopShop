﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.data;

namespace VloveImport.dal
{
    public class AdminDal
    {
        #region Constructor
        public CommandData SqlCommandData;
        public AdminDal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }
        #endregion

        #region ADMIN ORDER

        public DataSet GET_ADMIN_ORDER(int ORDER_ID, Nullable<DateTime> START_DATE, Nullable<DateTime> END_DATE,string CUS_NAME,string Act)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("ADMIN_GET_ORDER");

                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, ORDER_ID);
                SqlCommandData.SetParameter("START_DATE", SqlDbType.Date, ParameterDirection.Input, START_DATE);
                SqlCommandData.SetParameter("END_DATE", SqlDbType.Date, ParameterDirection.Input, END_DATE);
                SqlCommandData.SetParameter("CUS_NAME", SqlDbType.VarChar, ParameterDirection.Input, CUS_NAME);
                SqlCommandData.SetParameter("Act", SqlDbType.VarChar, ParameterDirection.Input, Act);
                
                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ADMIN_ORDER -> msg : " + ex.Message);
            }
        }

        public string UPD_ADMIN_ORDER(OrderData En, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("ADMIN_UPDATE_ORDER");

                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, En.ORDER_ID);
                SqlCommandData.SetParameter_Input_INT("ORDDER_STAUTS", SqlDbType.VarChar, ParameterDirection.Input, En.ORDER_STATUS);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, En.Create_User);
                SqlCommandData.SetParameter("ACT", SqlDbType.VarChar, ParameterDirection.Input, Act);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                return ("INS_UPD_CUSTOMER_FAVORIT_SHOP -> msg : " + ex.Message);
            }
        }

        #endregion

    }
}