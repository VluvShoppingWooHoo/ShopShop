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
        public string AddtoCart(ShoppingData Shop)
        {            
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            string Result = "";
            Result = dal.AddtoCart(Shop);
            return Result;
        }

        public string InsertNewItem(ShoppingData Shop)
        {
            string Result = "";
            ShoppingDal dal = new ShoppingDal("LocalConnection");
            Result = dal.InsertNewItem(Shop);
            return Result;
        }

    }
}
