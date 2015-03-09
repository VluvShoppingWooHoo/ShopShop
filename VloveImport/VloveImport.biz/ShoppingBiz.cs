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
        public DataTable GetBasketList(ShoppingData Data)
        {
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            DataSet ds = new DataSet();
            ds = dal.GetBasketList(Data);
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
