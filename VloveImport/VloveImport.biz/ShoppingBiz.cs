using System;
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
        public string MakeOrder(OrderData Data, DataTable dt, string User)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            string[] Result = new string[2];
            string Res = "";
            int OID = -1;
            //Header
            Result = dal.MakeOrderHeader(Data);
            if (Result[1] != "")
                OID = Convert.ToInt32(Convert.ToInt32(Result[1]));

            Res = dal.MakeOrderDetail(dt, OID, User);

            return Res;
        }
        public DataTable GetOrderList(Int32 CUS_ID)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetOrderList(CUS_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

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
    }
}
