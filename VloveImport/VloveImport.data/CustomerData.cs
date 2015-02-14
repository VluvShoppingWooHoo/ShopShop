using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class CustomerData : CommonData
    {
        public int Cus_ID { get; set; }
        public string Cus_Name { get; set; }
        public string Cus_LName { get; set; }
        public string Cus_Gender { get; set; }
        public DateTime Cus_BirthDay { get; set; }
        public string Cus_Telephone { get; set; }
        public string Cus_Mobile { get; set; }
        public string Cus_Fax { get; set; }
        public string Cus_Email { get; set; }
        public string Cus_Password { get; set; }
        public string Cus_Withdraw_Code { get; set; }
        public string Cus_Link_Shop { get; set; }
        public int Cus_Point { get; set; }
        public int Cus_Ref_ID { get; set; }
        public int Cus_Active { get; set; }
        public int Cus_Status { get; set; }
        public DateTime Activate_Date { get; set; }
    }
}
