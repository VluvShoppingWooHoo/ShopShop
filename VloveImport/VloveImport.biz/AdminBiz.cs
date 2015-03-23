﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using VloveImport.data;

namespace VloveImport.biz
{
    public class AdminBiz
    {

        public DataSet GET_MASTER_STATUS(string STATUS_TYPE, string Act)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GET_MASTER_STATUS(STATUS_TYPE, Act);
            return ds;
        }

        #region ORDER

        public void TestCon()
        {
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                dal.TestCon();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string UPD_ADMIN_ORDER(OrderData En, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.UPD_ADMIN_ORDER(En, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public DataSet GET_ADMIN_ORDER(string Act, int ORDER_ID = -1, Nullable<DateTime> START_DATE = null, Nullable<DateTime> END_DATE = null, string CUS_NAME = "",int ORDER_STATUS = -1)
        {
            DataSet ds = new DataSet();
            AdminDal dal = new AdminDal("LocalConnection");
            ds = dal.GET_ADMIN_ORDER(ORDER_ID, START_DATE, END_DATE, CUS_NAME,ORDER_STATUS, Act);
            return ds;
        }

        public string UPD_ADMIN_ORDER_PROD_AMOUNT(int ORDER_ID, int ORDER_DETAIL_ID, int PROD_NUM, string CREATE_USER, string Act)
        {
            string Result = "";
            try
            {
                AdminDal dal = new AdminDal("LocalConnection");
                Result = dal.UPD_ADMIN_ORDER_PROD_AMOUNT(ORDER_ID, ORDER_DETAIL_ID, PROD_NUM, CREATE_USER, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        #endregion
    }
}
