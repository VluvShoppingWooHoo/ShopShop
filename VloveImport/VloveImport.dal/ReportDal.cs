using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.data;

namespace VloveImport.dal
{
    public class ReportDal
    {
        #region Constructor
        public CommandData SqlCommandData;
        public ReportDal(string strConnection)
        {
            SqlCommandData = new CommandData(strConnection);
        }
        #endregion
        public DataSet GetOrderDetail(Int32 OID)
        {
            try
            {
                SqlCommandData.SetStoreProcedure("GET_ORDER_DETAIL");
                SqlCommandData.SetParameter_Input_INT("ORDER_ID", SqlDbType.Int, ParameterDirection.Input, OID);

                return SqlCommandData.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                throw new Exception("GET_ORDER_DETAIL -> msg : " + ex.Message);
            }           
        }

    }
}
