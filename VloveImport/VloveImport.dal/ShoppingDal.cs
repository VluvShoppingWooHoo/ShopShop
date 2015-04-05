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
                SqlCommandData.SetParameter("CUS_BK_ITEMNAME", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_ITEMNAME);
                SqlCommandData.SetParameter("CUS_BK_ITEMDESC", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_ITEMDESC);                
                SqlCommandData.SetParameter_Input_INT("CUS_BK_AMOUNT", SqlDbType.Int, ParameterDirection.Input, Shop.CUS_BK_AMOUNT);
                SqlCommandData.SetParameter_Input_INT("CUS_BK_PRICE", SqlDbType.Float, ParameterDirection.Input, Shop.CUS_BK_PRICE);
                SqlCommandData.SetParameter("CUS_BK_SIZE", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_SIZE);
                SqlCommandData.SetParameter("CUS_BK_COLOR", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_COLOR);
                SqlCommandData.SetParameter("CUS_BK_REMARK", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_REMARK);
                SqlCommandData.SetParameter("CUS_BK_URL", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_URL);
                SqlCommandData.SetParameter("CUS_BK_PICURL", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_PICURL);
                SqlCommandData.SetParameter("CUS_BK_STATUS", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_STATUS);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, Shop.Create_User);

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
        public DataSet GetBasketList(Int32 CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_BASKET_LIST");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_BASKET_LIST -> msg : " + ex.Message);
            }
        }
        public DataSet GetTransList(string Type)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_TRANS_LIST");
                SqlCommandData.SetParameter_Input_INT("TYPEE", SqlDbType.VarChar, ParameterDirection.Input, Type);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_TRANS_LIST -> msg : " + ex.Message);
            }
        }
        public string[] MakeOrderHeader(OrderData Data)
        {
            try
            {
                string[] Result = new string[2];
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_ORDER");

                SqlCommandData.SetParameter_Input_INT("ORDER_STATUS", SqlDbType.Int, ParameterDirection.Input, Data.ORDER_STATUS);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ADDRESS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ADDRESS_ID);
                SqlCommandData.SetParameter_Input_INT("TRANSPORT_CH_TH_METHOD", SqlDbType.Int, ParameterDirection.Input, Data.TRANSPORT_CH_TH_METHOD);
                SqlCommandData.SetParameter_Input_INT("TRANSPORT_TH_CU_METHOD", SqlDbType.Int, ParameterDirection.Input, Data.TRANSPORT_TH_CU_METHOD);
                SqlCommandData.SetParameter_Input_INT("ORDER_CURRENCY", SqlDbType.Float, ParameterDirection.Input, Data.ORDER_CURRENCY);
                SqlCommandData.SetParameter_Input_INT("ORDER_TRANS_RATE", SqlDbType.Int, ParameterDirection.Input, Data.ORDER_TRANS_RATE);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, Data.Create_User);

                SqlCommandData.SetParameter("ORDER_ID", SqlDbType.Int, ParameterDirection.Output);

                SqlCommandData.ExecuteNonQuery();
                Result[1] = SqlCommandData.GetOutputStoreProcedure("ORDER_ID");
                SqlCommandData.Commit();
                return Result;
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return new string[2] {"INS_ORDER -> msg : " + ex.Message, ""};
            }
        }
        public string MakeOrderDetail(DataTable dt, int Order_ID, string User)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                foreach (DataRow dr in dt.Rows)
                {
                    SqlCommandData.SetStoreProcedure("INS_ORDER_DETAIL");

                    SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, Order_ID);
                    SqlCommandData.SetParameter("OD_ITEMNAME", SqlDbType.NVarChar, ParameterDirection.Input, dr["CUS_BK_ITEMNAME"].ToString());
                    SqlCommandData.SetParameter_Input_INT("OD_AMOUNT", SqlDbType.Int, ParameterDirection.Input, Convert.ToInt32(dr["CUS_BK_AMOUNT"].ToString()));
                    SqlCommandData.SetParameter_Input_INT("OD_PRICE", SqlDbType.Float, ParameterDirection.Input, Convert.ToInt32(dr["CUS_BK_PRICE"].ToString()));
                    SqlCommandData.SetParameter("OD_SIZE", SqlDbType.NVarChar, ParameterDirection.Input, dr["CUS_BK_SIZE"].ToString());
                    SqlCommandData.SetParameter("OD_COLOR", SqlDbType.NVarChar, ParameterDirection.Input, dr["CUS_BK_COLOR"].ToString());
                    SqlCommandData.SetParameter("OD_REMARK", SqlDbType.NVarChar, ParameterDirection.Input, dr["CUS_BK_REMARK"].ToString());
                    SqlCommandData.SetParameter("OD_URL", SqlDbType.NVarChar, ParameterDirection.Input, dr["CUS_BK_URL"].ToString());
                    SqlCommandData.SetParameter("OD_PICURL", SqlDbType.NVarChar, ParameterDirection.Input, dr["CUS_BK_PICURL"].ToString());
                    SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, User);
                    SqlCommandData.SetParameter_Input_INT("OD_REF_BASKET", SqlDbType.Int, ParameterDirection.Input, Convert.ToInt32(dr["CUS_BK_ID"].ToString()));

                    SqlCommandData.ExecuteNonQuery();
                }
                
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return ("INS_ORDER_DETAIL -> msg : " + ex.Message);
            }
        }
        public DataSet GetOrderList(Int32 CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_ORDER_LIST");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ORDER_LIST -> msg : " + ex.Message);
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
