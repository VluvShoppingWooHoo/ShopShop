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

                //SqlCommandData.SetParameter_Input_INT("Prod_ID", SqlDbType.Int, ParameterDirection.Input, Shop.PROD_ID);
                //SqlCommandData.SetParameter_Input_INT("Cus_BK_Number", SqlDbType.Int, ParameterDirection.Input, Shop.CUS_BK_NUMBER);
                SqlCommandData.SetParameter_Input_INT("CUS_BK_AMOUNT", SqlDbType.Int, ParameterDirection.Input, Shop.CUS_BK_AMOUNT);
                SqlCommandData.SetParameter_Input_INT("CUS_BK_PRICE", SqlDbType.Float, ParameterDirection.Input, Shop.CUS_BK_PRICE);
                SqlCommandData.SetParameter_Input_INT("CUS_BK_SIZE", SqlDbType.Float, ParameterDirection.Input, Shop.CUS_BK_SIZE);
                SqlCommandData.SetParameter_Input_INT("CUS_BK_COLOR", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_COLOR);
                SqlCommandData.SetParameter("CUS_BK_REMARK", SqlDbType.VarChar, ParameterDirection.Input, Shop.CUS_BK_REMARK);
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

        public string InsertNewItem(ShoppingData Shop)
        {
            try
            {
                SqlCommandData.OpenConnection();
                SqlCommandData.BeginTransaction();
                SqlCommandData.SetStoreProcedure("INS_NEWITEM");

                //SqlCommandData.SetParameter("Cus_Email", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Email);
                //SqlCommandData.SetParameter("Cus_Password", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Password);
                //SqlCommandData.SetParameter("Cus_Mobile", SqlDbType.VarChar, ParameterDirection.Input, Cust.Cus_Mobile);
                //SqlCommandData.SetParameter_Input_INT("Cus_Ref_ID", SqlDbType.Int, ParameterDirection.Input, Cust.Cus_Ref_ID);
                                
                SqlCommandData.ExecuteNonQuery();
                SqlCommandData.Commit();
                return "";
            }
            catch (Exception ex)
            {
                //throw new Exception("LogonUser -> msg : " + ex.Message);
                SqlCommandData.RollBack();
                return ("InsertRegisCustomer -> msg : " + ex.Message);
            }            
        }
        
    }
}
