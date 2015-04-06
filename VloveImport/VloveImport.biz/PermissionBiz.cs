using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using VloveImport.data;

namespace VloveImport.biz
{
    public class PermissionBiz
    {
        #region CustomerMyAccout
        public DataTable GET_CUSTOMER_MYACCOUNT(int CUS_ID)
        {
            DataSet ds = new DataSet();
            PermissionDal dal = new PermissionDal("LocalConnection");
            ds = dal.GET_CUSTOMER_MYACCOUNT(CUS_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        #endregion

        #region Permission
        public DataSet GetPageByURL(string Page_URL)
        {
            PermissionDal dal = new PermissionDal("LocalConnection");
            return dal.GetPageByURL(Page_URL);
        }
        #endregion
        
    }
}
