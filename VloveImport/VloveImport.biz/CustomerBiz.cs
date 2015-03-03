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
    public class CustomerBiz
    {
        #region CustomerMyAccout
        public DataTable GET_CUSTOMER_MYACCOUNT(int CUS_ID)
        {
            DataSet ds = new DataSet();
            CustomerDal dal = new CustomerDal("LocalConnection");
            ds = dal.GET_CUSTOMER_MYACCOUNT(CUS_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        #endregion
        #region CUSTOMER_PROFILE
        public DataTable Get_Customer_Profile(int CUS_ID)
        {
            DataSet ds = new DataSet();
            CustomerDal dal = new CustomerDal("LocalConnection");
            ds = dal.GetData_Customer_Profile(CUS_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public string UPDATE_Customer_Profile(CustomerData EnCus)
        {
            string Result = "";
            try
            {
                CustomerDal dal = new CustomerDal("LocalConnection");
                Result = dal.UPDATE_Customer_Profile(EnCus);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }
        #endregion

        #region CUSTOMER ADDRESS

        public string INS_UPD_Customer_Address(CustomerData EnCus, string Act)
        {
            string Result = "";
            try
            {
                CustomerDal dal = new CustomerDal("LocalConnection");
                Result = dal.INS_UPD_Customer_Address(EnCus, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public DataSet GetData_Customer_Address(int CUS_ID, int CUS_ADD_ID, int CUS_ADDRESS_STATUS, string Act, string CUS_ADD_CUS_NAME = "", int REGION_ID = -1, int PROVINCE_ID = -1, int CUS_ADD_ZIPCODE = -1)
        {
            DataSet ds = new DataSet();
            CustomerDal dal = new CustomerDal("LocalConnection");
            ds = dal.GetData_Customer_Address(CUS_ID, CUS_ADD_ID, CUS_ADDRESS_STATUS, Act, CUS_ADD_CUS_NAME, REGION_ID, PROVINCE_ID, CUS_ADD_ZIPCODE);
            return ds;
        }

        #endregion

        #region CUSTOMER BANK

        public string INS_UPD_CUSTOMER_ACCOUNT_BANK(CustomerData EnCus, string Act)
        {
            string Result = "";
            try
            {
                CustomerDal dal = new CustomerDal("LocalConnection");
                Result = dal.INS_UPD_CUSTOMER_ACCOUNT_BANK(EnCus, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public DataSet GET_CUSTOMER_ACCOUNT_BANK(int CUS_ID, int CUS_ACC_NAME_ID, int CUS_ACC_NAME_STAUTS, string Act
                                                , string CUS_ACC_NAME = ""
                                                , string CUS_ACC_NAME_NO = ""
                                                , string CUS_ACC_NAME_BRANCH = ""
                                                , int BANK_ID = -1)
        {
            DataSet ds = new DataSet();
            CustomerDal dal = new CustomerDal("LocalConnection");
            ds = dal.GET_CUSTOMER_ACCOUNT_BANK(CUS_ID, CUS_ACC_NAME_ID, CUS_ACC_NAME_STAUTS, Act, CUS_ACC_NAME, CUS_ACC_NAME_NO, CUS_ACC_NAME_BRANCH, BANK_ID);
            return ds;
        }

        #endregion

        #region  CUSTOMER FAVORIT SHOP

        public string INS_UPD_CUSTOMER_FAVORIT_SHOP(CustomerData EnCus, string Act)
        {
            string Result = "";
            try
            {
                CustomerDal dal = new CustomerDal("LocalConnection");
                Result = dal.INS_UPD_CUSTOMER_FAVORIT_SHOP(EnCus, Act);
            }
            catch (Exception ex)
            {
                Result = ex.Message;
            }
            return Result;
        }

        public DataSet GET_CUSTOMER_FAVORIT_SHOP(int CUS_ID, int CUS_SHOP_ID, int CUS_SHOP_STATUS, string Act, string CUS_SHOP_NAME = "")
        {
            DataSet ds = new DataSet();
            CustomerDal dal = new CustomerDal("LocalConnection");
            ds = dal.GET_CUSTOMER_FAVORIT_SHOP(CUS_ID, CUS_SHOP_ID, CUS_SHOP_STATUS, Act, CUS_SHOP_NAME);
            return ds;
        }

        #endregion

        #region TRANSACTION

        public string INS_UPD_TRANSACTION(TransactionData EnTran, string Act)
        {
            string Result = "";
            try
            {
                CustomerDal dal = new CustomerDal("LocalConnection");
                Result = dal.INS_UPD_TRANSACTION(EnTran, Act);
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
