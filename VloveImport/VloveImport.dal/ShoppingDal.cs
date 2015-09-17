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
                SqlCommandData.SetParameter("CUS_BK_SHOPNAME", SqlDbType.NVarChar, ParameterDirection.Input, Shop.CUS_BK_SHOPNAME);
                SqlCommandData.SetParameter("ID", SqlDbType.NVarChar, ParameterDirection.Input, Shop.ID);

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
        public string UpdateBasketAmount(Int32 CUS_BK_ID, Int32 Amount)
        {
            try
            {
                string Result = "";
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("UPDATE_BASKET_AMOUNT");

                SqlCommandData.SetParameter_Input_INT("CUS_BK_ID", SqlDbType.Int, ParameterDirection.Input, CUS_BK_ID);
                SqlCommandData.SetParameter_Input_INT("AMOUNT", SqlDbType.Int, ParameterDirection.Input, Amount);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return Result;
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return ex.Message;
            }
        }
        public string DeleteBasket(Int32 CUS_BK_ID)
        {
            try
            {
                string Result = "";
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("DELETE_BASKET");

                SqlCommandData.SetParameter_Input_INT("CUS_BK_ID", SqlDbType.Int, ParameterDirection.Input, CUS_BK_ID);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return Result;
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return ex.Message;
            }
        }
        public DataSet GetTransList(string Type)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_MASTER_STATUS_LIST");
                SqlCommandData.SetParameter_Input_INT("TYPEE", SqlDbType.VarChar, ParameterDirection.Input, Type);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_MASTER_STATUS_LIST -> msg : " + ex.Message);
            }
        }
        public DataSet GetRate()
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_RATE");

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_RATE -> msg : " + ex.Message);
            }
        }
        public ScrapingData GetItemID(string id, int web)
        {
            ScrapingData model = null;
            try
            {
                DataSet ds = new DataSet();
                SqlCommandData.SetStoreProcedure("GET_ITEM");

                SqlCommandData.SetParameter("ITEM_ID", SqlDbType.VarChar, ParameterDirection.Input, id);
                SqlCommandData.SetParameter_Input_INT("WEB", SqlDbType.Int, ParameterDirection.Input, web);

                ds = SqlCommandData.ExecuteDataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model = new ScrapingData();
                    DataRow dr = ds.Tables[0].Rows[0];
                    model.ID = dr["ID"].ToString();
                    model.ItemID = dr["ITEM_ID"].ToString();
                    model.Web = int.Parse(dr["WEB"].ToString());
                    model.ItemName = dr["ITEM_NAME"].ToString();
                    model.picURL = dr["PIC_URL"].ToString();
                    model.Price = dr["PRICE"].ToString();
                    model.ProPrice = dr["PRO_PRICE"].ToString();
                    model.AmountRange = dr["AMOUNT_RANGE"].ToString();
                    model.PriceRange = dr["PRICE_RANGE"].ToString();
                    model.Color = dr["COLOR"].ToString();
                    model.Size = dr["SIZE"].ToString();
                    model.URL = dr["URL"].ToString();
                    model.ShopName = dr["SHOPNAME"].ToString();
                }
            }
            catch (Exception ex)
            {
                model = null;
            }
            return model;
        }
        public string InsertUpdateItemID(ScrapingData model, string Act)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_UPD_ITEM");

                SqlCommandData.SetParameter("ITEM_ID", SqlDbType.NVarChar, ParameterDirection.Input, model.ItemID);
                SqlCommandData.SetParameter_Input_INT("WEB", SqlDbType.Int, ParameterDirection.Input, model.Web);
                SqlCommandData.SetParameter("ITEM_NAME", SqlDbType.NVarChar, ParameterDirection.Input, model.ItemName);
                SqlCommandData.SetParameter("PIC_URL", SqlDbType.NVarChar, ParameterDirection.Input, model.picURL);
                SqlCommandData.SetParameter("PRICE", SqlDbType.NVarChar, ParameterDirection.Input, model.Price);
                SqlCommandData.SetParameter("PRO_PRICE", SqlDbType.NVarChar, ParameterDirection.Input, model.ProPrice);
                SqlCommandData.SetParameter("AMOUNT_RANGE", SqlDbType.NVarChar, ParameterDirection.Input, model.AmountRange == null ? "" : model.AmountRange);
                SqlCommandData.SetParameter("PRICE_RANGE", SqlDbType.NVarChar, ParameterDirection.Input, model.PriceRange == null ? "" : model.PriceRange);
                SqlCommandData.SetParameter("COLOR", SqlDbType.NVarChar, ParameterDirection.Input, model.Color);
                SqlCommandData.SetParameter("SIZE", SqlDbType.NVarChar, ParameterDirection.Input, model.Size);
                SqlCommandData.SetParameter("URL", SqlDbType.NVarChar, ParameterDirection.Input, model.URL);
                SqlCommandData.SetParameter("SHOPNAME", SqlDbType.NVarChar, ParameterDirection.Input, model.ShopName);
                SqlCommandData.SetParameter("Act", SqlDbType.NVarChar, ParameterDirection.Input, Act);
                SqlCommandData.SetParameter("retID", SqlDbType.Int, ParameterDirection.Output);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return SqlCommandData.GetOutputStoreProcedure("retID"); ;
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return ("");
                //return ("InsertUpdateItemID -> msg : " + ex.Message);
            }
        }
        #region Order
        public string[] MakeOrderHeader(OrderData Data)
        {
            try
            {
                string[] Result = new string[2];
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_ORDER");

                SqlCommandData.SetParameter_Input_INT("ORDER_STATUS", SqlDbType.Int, ParameterDirection.Input, Data.ORDER_STATUS);
                SqlCommandData.SetParameter("ORDER_CODE", SqlDbType.NVarChar, ParameterDirection.Input, Data.ORDER_CODE);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ADDRESS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ADDRESS_ID);
                SqlCommandData.SetParameter_Input_INT("TRANSPORT_CH_TH_METHOD", SqlDbType.Int, ParameterDirection.Input, Data.TRANSPORT_CH_TH_METHOD);
                SqlCommandData.SetParameter_Input_INT("TRANSPORT_TH_CU_METHOD", SqlDbType.Int, ParameterDirection.Input, Data.TRANSPORT_TH_CU_METHOD);
                SqlCommandData.SetParameter("ORDER_CURRENCY", SqlDbType.Float, ParameterDirection.Input, Data.ORDER_CURRENCY);
                SqlCommandData.SetParameter_Input_INT("ORDER_TYPE", SqlDbType.Int, ParameterDirection.Input, Data.ORDER_TYPE);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, Data.Create_User);
                SqlCommandData.SetParameter("TRANSPORT_OTHER", SqlDbType.NVarChar, ParameterDirection.Input, Data.TRANSPORT_OTHER);
                SqlCommandData.SetParameter("CUS_REMARK", SqlDbType.NVarChar, ParameterDirection.Input, Data.ORDER_EMP_REMARK);
                SqlCommandData.SetParameter_Input_INT("VIP_DISCOUNT", SqlDbType.Int, ParameterDirection.Input, Data.VIP_DISCOUNT);
                SqlCommandData.SetParameter("TRANSPORT_CUSTOMER_PRICE", SqlDbType.Float, ParameterDirection.Input, Data.TRANSPORT_CUSTOMER_PRICE);

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
                return new string[2] { "INS_ORDER -> msg : " + ex.Message, "" };
            }
        }
        public string MakeOrderShop(DataTable dt, int Order_ID, string User, ref bool chkSHop, Double Rate)
        {
            try
            {
                List<string> shopName = new List<string>();
                bool chkfirst = true;
                double Price = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (chkfirst || !(shopName.Contains(dr["CUS_BK_SHOPNAME"].ToString())))
                    {
                        chkfirst = false;
                        SqlCommandData.OpenConnection();
                        SqlCommandData.BeginTransaction();

                        SqlCommandData.SetStoreProcedure("INS_ORDER_SHOP");
                        SqlCommandData.SetParameter("SHOPNAME", SqlDbType.NVarChar, ParameterDirection.Input, dr["CUS_BK_SHOPNAME"].ToString());
                        SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, Order_ID);

                        SqlCommandData.SetParameter("ORDER_SHOP_ID", SqlDbType.Int, ParameterDirection.Output);
                        SqlCommandData.ExecuteNonQuery();
                        SqlCommandData.Commit();
                        string shop_id = SqlCommandData.GetOutputStoreProcedure("ORDER_SHOP_ID");
                        shopName.Add(dr["CUS_BK_SHOPNAME"].ToString());
                        string expression = "CUS_BK_SHOPNAME = '" + dr["CUS_BK_SHOPNAME"].ToString().Replace("'", "''") + "'";
                        foreach (DataRow drr in dt.Select(expression))
                        {
                            SqlCommandData.OpenConnection();
                            SqlCommandData.BeginTransaction();
                            SqlCommandData.SetStoreProcedure("INS_ORDER_DETAIL");

                            SqlCommandData.SetParameter_Input_INT("ORDER_SHOP_ID", SqlDbType.Int, ParameterDirection.Input, int.Parse(shop_id));
                            SqlCommandData.SetParameter("OD_ITEMNAME", SqlDbType.NVarChar, ParameterDirection.Input, drr["CUS_BK_ITEMNAME"].ToString());
                            SqlCommandData.SetParameter_Input_INT("OD_AMOUNT", SqlDbType.Int, ParameterDirection.Input, Convert.ToInt32(drr["CUS_BK_AMOUNT"].ToString()));

                            Price = Convert.ToDouble(drr["CUS_BK_PRICE"].ToString());
                            //Price = Rate * Price;
                            SqlCommandData.SetParameter_Input_INT("OD_PRICE", SqlDbType.Float, ParameterDirection.Input, Price);
                            SqlCommandData.SetParameter("OD_SIZE", SqlDbType.NVarChar, ParameterDirection.Input, drr["CUS_BK_SIZE"].ToString());
                            SqlCommandData.SetParameter("OD_COLOR", SqlDbType.NVarChar, ParameterDirection.Input, drr["CUS_BK_COLOR"].ToString());
                            SqlCommandData.SetParameter("OD_REMARK", SqlDbType.NVarChar, ParameterDirection.Input, drr["CUS_BK_REMARK"].ToString());
                            SqlCommandData.SetParameter("OD_URL", SqlDbType.NVarChar, ParameterDirection.Input, drr["CUS_BK_URL"].ToString());
                            SqlCommandData.SetParameter("OD_PICURL", SqlDbType.NVarChar, ParameterDirection.Input, drr["CUS_BK_PICURL"].ToString());

                            SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, User);
                            SqlCommandData.SetParameter_Input_INT("OD_REF_BASKET", SqlDbType.Int, ParameterDirection.Input, Convert.ToInt32(drr["CUS_BK_ID"].ToString()));

                            SqlCommandData.ExecuteNonQuery();

                            SqlCommandData.Commit();
                        }
                    }
                }
                chkSHop = true;
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return ("INS_ORDER_SHOP -> msg : " + ex.Message);
            }
        }
        public string UpdateOrderPricePIC(Int32 Order_ID, string FileName)
        {
            try
            {
                string Result = "";
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("UPDATE_ORDER_PRICE");

                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, Order_ID);
                SqlCommandData.SetParameter("FILENAME", SqlDbType.NVarChar, ParameterDirection.Input, FileName);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return Result;
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return ex.Message;
            }
        }
        public string CancelOrder(Int32 CUS_ID, Int32 ORDER_ID)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();

                SqlCommandData.SetStoreProcedure("UPDATE_CANCEL_ORDER");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, ORDER_ID);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();

                return "";
            }
            catch (Exception ex)
            {
                SqlCommandData.RollBack();
                throw new Exception("UPDATE_CANCEL_ORDER -> msg : " + ex.Message);
            }
        }
        public DataSet GetOrderList(Int32 CUS_ID, Int32 Type)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_ORDER_LIST");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter_Input_INT("TYPE", SqlDbType.Int, ParameterDirection.Input, Type);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ORDER_LIST -> msg : " + ex.Message);
            }
        }
        public DataSet GetOrderDetail(Int32 ORDER_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_ORDER_DETAIL");
                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, ORDER_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ORDER_DETAIL -> msg : " + ex.Message);
            }
        }
        #endregion

        #region PI
        public string[] MakeOrderByPI(OrderData Data)
        {
            string store = "";
            try
            {
                string[] Result = new string[2];
                string OID = "", OS_ID = "";
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();

                //Header
                store = "INS_ORDER";
                SqlCommandData.SetStoreProcedure(store);
                SqlCommandData.SetParameter_Input_INT("ORDER_STATUS", SqlDbType.Int, ParameterDirection.Input, Data.ORDER_STATUS);
                SqlCommandData.SetParameter("ORDER_CODE", SqlDbType.NVarChar, ParameterDirection.Input, Data.ORDER_CODE);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ADDRESS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ADDRESS_ID);
                SqlCommandData.SetParameter_Input_INT("TRANSPORT_CH_TH_METHOD", SqlDbType.Int, ParameterDirection.Input, Data.TRANSPORT_CH_TH_METHOD);
                SqlCommandData.SetParameter_Input_INT("TRANSPORT_TH_CU_METHOD", SqlDbType.Int, ParameterDirection.Input, Data.TRANSPORT_TH_CU_METHOD);
                SqlCommandData.SetParameter("ORDER_CURRENCY", SqlDbType.Float, ParameterDirection.Input, Data.ORDER_CURRENCY);
                SqlCommandData.SetParameter_Input_INT("ORDER_TYPE", SqlDbType.Int, ParameterDirection.Input, Data.ORDER_TYPE);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, Data.Create_User);

                SqlCommandData.SetParameter("ORDER_ID", SqlDbType.Int, ParameterDirection.Output);

                SqlCommandData.ExecuteNonQuery();
                OID = SqlCommandData.GetOutputStoreProcedure("ORDER_ID");

                //Order_Shop
                store = "INS_ORDER_SHOP";
                SqlCommandData.SetStoreProcedure(store);
                SqlCommandData.SetParameter("SHOPNAME", SqlDbType.NVarChar, ParameterDirection.Input, "สินค้าฝากจ่าย");
                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, int.Parse(OID));

                SqlCommandData.SetParameter("ORDER_SHOP_ID", SqlDbType.Int, ParameterDirection.Output);

                SqlCommandData.ExecuteNonQuery();
                OS_ID = SqlCommandData.GetOutputStoreProcedure("ORDER_SHOP_ID");

                //Detail
                store = "INS_ORDER_DETAIL";
                SqlCommandData.SetStoreProcedure(store);
                SqlCommandData.SetParameter_Input_INT("ORDER_SHOP_ID", SqlDbType.Int, ParameterDirection.Input, int.Parse(OS_ID));
                SqlCommandData.SetParameter("OD_ITEMNAME", SqlDbType.NVarChar, ParameterDirection.Input, Data.OD_ITEMNAME);
                SqlCommandData.SetParameter_Input_INT("OD_AMOUNT", SqlDbType.Int, ParameterDirection.Input, Data.OD_AMOUNT);
                SqlCommandData.SetParameter_Input_INT("OD_PRICE", SqlDbType.Float, ParameterDirection.Input, Data.OD_PRICE);
                SqlCommandData.SetParameter("OD_SIZE", SqlDbType.NVarChar, ParameterDirection.Input, DBNull.Value);
                SqlCommandData.SetParameter("OD_COLOR", SqlDbType.NVarChar, ParameterDirection.Input, DBNull.Value);
                SqlCommandData.SetParameter("OD_REMARK", SqlDbType.NVarChar, ParameterDirection.Input, Data.OD_REMARK == null ? "" : Data.OD_REMARK);
                SqlCommandData.SetParameter("OD_URL", SqlDbType.NVarChar, ParameterDirection.Input, DBNull.Value);
                if (Data.OD_PICURL == null)
                    SqlCommandData.SetParameter("OD_PICURL", SqlDbType.NVarChar, ParameterDirection.Input, DBNull.Value);
                else
                    SqlCommandData.SetParameter("OD_PICURL", SqlDbType.NVarChar, ParameterDirection.Input, Data.OD_PICURL);

                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, Data.Create_User);
                SqlCommandData.SetParameter_Input_INT("OD_REF_BASKET", SqlDbType.Int, ParameterDirection.Input, DBNull.Value);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();

                Result[0] = "";
                Result[1] = OID;
                return Result;
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return new string[2] { store + " -> msg : " + ex.Message, "" };
            }
        }
        #endregion

        #region Trans
        public string[] MakeOrderByTrans(OrderData Data, List<OrderData> lstData)
        {
            string store = "";
            int i = 0;
            try
            {
                string[] Result = new string[2];
                string OID = "", OS_ID = "";
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();

                //Header
                store = "INS_ORDER";
                SqlCommandData.SetStoreProcedure(store);
                SqlCommandData.SetParameter_Input_INT("ORDER_STATUS", SqlDbType.Int, ParameterDirection.Input, Data.ORDER_STATUS);
                SqlCommandData.SetParameter("ORDER_CODE", SqlDbType.NVarChar, ParameterDirection.Input, Data.ORDER_CODE);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ID);
                SqlCommandData.SetParameter_Input_INT("CUS_ADDRESS_ID", SqlDbType.Int, ParameterDirection.Input, Data.CUS_ADDRESS_ID);
                SqlCommandData.SetParameter_Input_INT("TRANSPORT_CH_TH_METHOD", SqlDbType.Int, ParameterDirection.Input, Data.TRANSPORT_CH_TH_METHOD);
                SqlCommandData.SetParameter_Input_INT("TRANSPORT_TH_CU_METHOD", SqlDbType.Int, ParameterDirection.Input, Data.TRANSPORT_TH_CU_METHOD);
                SqlCommandData.SetParameter("ORDER_CURRENCY", SqlDbType.Float, ParameterDirection.Input, Data.ORDER_CURRENCY);
                SqlCommandData.SetParameter_Input_INT("ORDER_TYPE", SqlDbType.Int, ParameterDirection.Input, Data.ORDER_TYPE);
                SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, Data.Create_User);

                SqlCommandData.SetParameter("ORDER_ID", SqlDbType.Int, ParameterDirection.Output);

                SqlCommandData.ExecuteNonQuery();
                OID = SqlCommandData.GetOutputStoreProcedure("ORDER_ID");

                //Order_Shop
                foreach (OrderData item in lstData)
                {
                    i++;
                    store = "INS_ORDER_SHOP";
                    SqlCommandData.SetStoreProcedure(store);
                    SqlCommandData.SetParameter("SHOPNAME", SqlDbType.NVarChar, ParameterDirection.Input, "รายการขนส่ง " + i.ToString());
                    SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, int.Parse(OID));
                    SqlCommandData.SetParameter("TRACKING_NO", SqlDbType.NVarChar, ParameterDirection.Input, item.TRACKING_NO);
                    SqlCommandData.SetParameter("SHOP_ORDER_ID", SqlDbType.NVarChar, ParameterDirection.Input, item.SHOP_ORDER_ID);
                    SqlCommandData.SetParameter("ORDER_SHOP_ID", SqlDbType.Int, ParameterDirection.Output);

                    SqlCommandData.ExecuteNonQuery();
                    OS_ID = SqlCommandData.GetOutputStoreProcedure("ORDER_SHOP_ID");

                    //Detail
                    store = "INS_ORDER_DETAIL";
                    SqlCommandData.SetStoreProcedure(store);
                    SqlCommandData.SetParameter_Input_INT("ORDER_SHOP_ID", SqlDbType.Int, ParameterDirection.Input, int.Parse(OS_ID));
                    SqlCommandData.SetParameter("OD_ITEMNAME", SqlDbType.NVarChar, ParameterDirection.Input, "รายการขนส่ง" + i.ToString());
                    SqlCommandData.SetParameter_Input_INT("OD_AMOUNT", SqlDbType.Int, ParameterDirection.Input, item.OD_AMOUNT);
                    SqlCommandData.SetParameter_Input_INT("OD_PRICE", SqlDbType.Float, ParameterDirection.Input, item.OD_PRICE);
                    SqlCommandData.SetParameter("OD_SIZE", SqlDbType.NVarChar, ParameterDirection.Input, DBNull.Value);
                    SqlCommandData.SetParameter("OD_COLOR", SqlDbType.NVarChar, ParameterDirection.Input, DBNull.Value);
                    SqlCommandData.SetParameter("OD_REMARK", SqlDbType.NVarChar, ParameterDirection.Input, item.OD_REMARK == null ? "" : item.OD_REMARK);
                    SqlCommandData.SetParameter("OD_URL", SqlDbType.NVarChar, ParameterDirection.Input, DBNull.Value);
                    SqlCommandData.SetParameter("OD_PICURL", SqlDbType.NVarChar, ParameterDirection.Input, DBNull.Value);

                    SqlCommandData.SetParameter("CREATE_USER", SqlDbType.NVarChar, ParameterDirection.Input, Data.Create_User);
                    SqlCommandData.SetParameter_Input_INT("OD_REF_BASKET", SqlDbType.Int, ParameterDirection.Input, DBNull.Value);

                    SqlCommandData.ExecuteNonQuery();
                }

                SqlCommandData.Commit();

                Result[0] = "";
                Result[1] = OID;
                return Result;
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return new string[2] { store + " -> msg : " + ex.Message, "" };
            }
        }
        #endregion

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

        #region 
        public DataSet GetMasterVoucher()
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_MASTER_VOUCHER");

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_MASTER_VOUCHER -> msg : " + ex.Message);
            }
        }

        public DataSet GetCustomerVoucher(Int32 CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_CUSTOMER_VOUCHER");
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_CUSTOMER_VOUCHER -> msg : " + ex.Message);
            }
        }

        public string CreateVoucher(Int32 CUS_ID, Int32 MV_ID, Int32 POINT)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_TRAN_VOUCHER");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter_Input_INT("MV_ID", SqlDbType.Int, ParameterDirection.Input, MV_ID);
                SqlCommandData.SetParameter_Input_INT("POINT", SqlDbType.Int, ParameterDirection.Input, POINT);               

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return "INS_TRAN_VOUCHER -> msg : " + ex.Message;
            }
        }

        public DataSet CheckVoucherUse(Int32 ORDER_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_VOUCHER_BY_ORDERID");

                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, ORDER_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_VOUCHER_BY_ORDERID -> msg : " + ex.Message);
            }
        }

        public DataSet GetVoucherByCusID(Int32 CUS_ID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_VOUCHER_BY_CUSID");

                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_VOUCHER_BY_CUSID -> msg : " + ex.Message);
            }
        }

        public string USE_VOUCHER(Int32 TP_ID, Int32 ORDER_ID, double AMOUNT, Int32 CUS_ID, string VOUCHER)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_TRAN_USE_VOUCHER");

                SqlCommandData.SetParameter_Input_INT("TP_ID", SqlDbType.Int, ParameterDirection.Input, TP_ID);
                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, ORDER_ID);
                SqlCommandData.SetParameter_Input_INT("AMOUNT", SqlDbType.Float, ParameterDirection.Input, AMOUNT);
                SqlCommandData.SetParameter_Input_INT("CUS_ID", SqlDbType.Int, ParameterDirection.Input, CUS_ID);
                SqlCommandData.SetParameter("VOUCHER", SqlDbType.VarChar, ParameterDirection.Input, VOUCHER);

                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("AddtoCart -> msg : " + ex.Message);                
                SqlCommandData.RollBack();
                return "INS_TRAN_VOUCHER -> msg : " + ex.Message;
            }
        }
        #endregion
    }
}
