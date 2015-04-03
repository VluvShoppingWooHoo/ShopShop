using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class AdminUserData : CommonData
    {

        #region Group user

        public int GROUP_ID { get; set; }
        public string GROUP_NAME { get; set; }
        public string GROUP_ROLE { get; set; }
        public string GROUP_REMARK { get; set; }
        public int GROUP_STATUS { get; set; }

        #endregion

        #region User

        public int EMP_ID { get; set; }
        public string USERNAME { get; set; }
        public string EMP_PASSWORD { get; set; }
        public string EMP_NAME { get; set; }
        public string EMP_LNAME { get; set; }
        public string EMP_DETAIL { get; set; }
        public string EMP_STATUS { get; set; }

        #endregion

    }
}
