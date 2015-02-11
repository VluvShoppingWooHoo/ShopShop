using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;

namespace VloveImport.biz
{
    public class commonBiz
    {
        public commonBiz()
        {

        }

        public DataSet GETDATA(string Search1)
        {
            commonDal ProEADDAL = new commonDal();
            return ProEADDAL.GETDATA(Search1);
        }

    }
}
