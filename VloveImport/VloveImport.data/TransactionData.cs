using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class TransactionData : CustomerData
    {

        public int TRAN_ID { get; set; }
        public int TRAN_TYPE { get; set; }
        public int TRAN_TABLE_TYPE { get; set; }
        public string TRAN_DETAIL { get; set; }
        public string TRAN_REMARK { get; set; }
        public Nullable<DateTime> TRAN_DATE { get; set; }
        public double TRAN_AMOUNT { get; set; }
        public int TRAN_STATUS { get; set; }
        public int TRAN_STATUS_APPROVE { get; set; }
        public int EMP_ID_APPROVE { get; set; }
        public Nullable<DateTime> EMP_APPROVE_DATE { get; set; }
        public string EMP_REMARK { get; set; }
        public int ORDER_ID { get; set; }
        public int PAYMENT_TYPE { get; set; }
        public Nullable<DateTime> PAYMENT_DATE { get; set; }
        public string PAYMENT_TIME { get; set; }
        public string TRAN_EMAIL { get; set; }

    }
}
