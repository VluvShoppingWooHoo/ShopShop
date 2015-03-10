using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.data;

namespace VloveImport.dal
{
    public class ShoppingDal
    {
        #region Constructor  
        public CommandData SqlCommandData;
        public ShoppingDal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }
        #endregion

        public string AddtoCart(ScrapingData Shop)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_SHOPPINGCART");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, Shop.CUS_ID);
                SqlCommandData.SetParameter("CUS_BK_ITEMNAME", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_ITEMNAME);
                SqlCommandData.SetParameter("CUS_BK_ITEMDESC", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_ITEMDESC);                
                SqlCommandData.SetParameter_Input_INT("CUS_BK_AMOUNT", SqlDbType.Int, ParameterDirection.Input, Shop.CUS_BK_AMOUNT);
                SqlCommandData.SetParameter_Input_INT("CUS_BK_PRICE", SqlDbType.Float, ParameterDirection.Input, Shop.CUS_BK_PRICE);
                SqlCommandData.SetParameter("CUS_BK_SIZE", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_SIZE);
                SqlCommandData.SetParameter("CUS_BK_COLOR", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_COLOR);                
                SqlCommandData.SetParameter("CUS_BK_REMARK", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_REMARK);
                SqlCommandData.SetParameter("CUS_BK_URL", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_URL);
                SqlCommandData.SetParameter("CUS_BK_PICURL", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_PICURL);
                SqlCommandData.SetParameter("CUS_BK_STATUS", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_STATUS);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.VarChar, ParameterDirection.Input, Shop.Create_User);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return ("AddtoCart -> msg : " + ex.Message);
            }
        }
        public DataSet GetBasketList(ShoppingData Data)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_BASKET_LIST");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_BASKET_LIST -> msg : " + ex.Message);
            }
        }


        #region Admin Manage
        public DataSet GetOrderList(string Login, string ShopName)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_ORDER_LIST");
                SqlCommandData.SetParameter_Input_INT("LOGIN", SqlDbType.VarChar, ParameterDirection.Input, Login);
                SqlCommandData.SetParameter_Input_INT("SHOPNAME", SqlDbType.VarChar, ParameterDirection.Input, ShopName);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ORDER_LIST -> msg : " + ex.Message);
            }
        }
        #endregion
    }
}
