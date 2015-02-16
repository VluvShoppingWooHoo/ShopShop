﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class CommonData
    {
        //public string Create_User { get; set; }
        //public DateTime Create_Date { get; set; }
        //public string Update_User { get; set; }
        //public DateTime Update_Date { get; set; }

        public string Create_User { get; set; }
        public Nullable<DateTime> Create_Date { get; set; }
        public string Update_User { get; set; }
        public Nullable<DateTime> Update_Date { get; set; }

        public int REGION_ID { get; set; }
        public int PROVINCE_ID { get; set; }
        public int DISTRICT_ID { get; set; }
        public int SUB_DISTRICT_ID { get; set; }
        public int BANK_ID { get; set; }

    }
}
