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
    public class ReportBiz
    {
        public DataTable GetOrderDetail(Int32 OID)
        {
            DataSet ds = new DataSet();
            ReportDal Dal = new ReportDal("LocalConnection");
            ds = Dal.GetOrderDetail(OID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }

    }
}
