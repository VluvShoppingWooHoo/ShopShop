﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using VloveImport.data;
using VloveImport.util;

namespace VloveImport.biz
{
    public class ShoppingBiz
    {
        public string AddtoCart(ScrapingData Shop)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            string Result = "";
            Result = dal.AddtoCart(Shop);
            return Result;
        }
        public DataTable GetBasketList(Int32 CUS_ID)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetBasketList(CUS_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public string UpdateBasketAmount(Int32 CUS_BK_ID, Int32 Amount)
        {
            string Result = "";
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            Result = dal.UpdateBasketAmount(CUS_BK_ID, Amount);
            return Result;
        }
        public string DeleteBasket(Int32 CUS_BK_ID)
        {
            string Result = "";
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            Result = dal.DeleteBasket(CUS_BK_ID);
            return Result;
        }
        public DataTable GetTransList(string Type)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetTransList(Type);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable GetRate()
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetRate();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public ScrapingData GetItemID(string id, int web)
        {
            ScrapingData model = new ScrapingData();
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            model = dal.GetItemID(id, web);
            return model;
        }
        public string InsertUpdateItemID(ScrapingData model, string Act)
        {
            string Result = "";
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            Result = dal.InsertUpdateItemID(model, Act);
            return Result;
        }
        #region ORDER
        public string[] MakeOrder(OrderData Data, DataTable dt, string User, double Rate)
        {
            commonBiz biz = new commonBiz();
            ShoppingDal dal = new ShoppingDal("LocalConnection");

            string[] Result = new string[2];
            string[] Res = new string[2];
            int OID = -1;
            //Header
            Result = dal.MakeOrderHeader(Data);
            if (Result[1] != "")
            {
                OID = Convert.ToInt32(Convert.ToInt32(Result[1]));
                Res[1] = Result[1];
            }
            else
            {
                biz.WriteLog("CustomerConfirmInfo", "MakeOrderHeader", Result[0]);
                return Result;
            }

            //Oeder_Shop
            bool chkShop = false;
            Res[0] = dal.MakeOrderShop(dt, OID, User, ref chkShop, Rate);
            return Res;
        }
        public string UpdateOrderPricePIC(Int32 Order_ID, string FileName)
        {
            string Result = "";
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            Result = dal.UpdateOrderPricePIC(Order_ID, FileName);
            return Result;
        }
        public string CancelOrder(Int32 CUS_ID, Int32 ORDER_ID)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            string Result = "";
            Result = dal.CancelOrder(CUS_ID, ORDER_ID);
            return Result;
        }
        public DataTable GetOrderList(Int32 CUS_ID, Int32 Type)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetOrderList(CUS_ID, Type);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public DataTable GetOrderDetail(Int32 ORDER_ID)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetOrderDetail(ORDER_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        #endregion

        #region UploadPI
        public string[] MakeOrderByPI(OrderData Data)
        {
            commonBiz biz = new commonBiz();
            ShoppingDal dal = new ShoppingDal("LocalConnection");

            string[] Result = new string[2];
            Result = dal.MakeOrderByPI(Data);
            return Result;
        }
        #endregion

        #region TransOnly
        public string[] MakeOrderByTrans(OrderData Data, List<OrderData> lstData)
        {
            commonBiz biz = new commonBiz();
            ShoppingDal dal = new ShoppingDal("LocalConnection");

            string[] Result = new string[2];
            Result = dal.MakeOrderByTrans(Data, lstData);
            return Result;
        }
        #endregion
        #region Admin Manage
        public DataTable GetOrderList(string Login, string ShopName)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetOrderList(Login, ShopName);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        #endregion

        #region
        public DataTable GetMasterVoucher()
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetMasterVoucher();
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public DataTable GetCustomerVoucher(Int32 CUS_ID)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetCustomerVoucher(CUS_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

        public string CreateVoucher(Int32 CUS_ID, Int32 MV_ID, Int32 POINT)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            string Result = "";
            Result = dal.CreateVoucher(CUS_ID, MV_ID, POINT);
            return Result;
        }
        #endregion
    }
}
