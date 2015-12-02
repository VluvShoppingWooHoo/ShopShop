using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class TrackingData : CommonData
    {        
        #region TB_TRACKING
        public int T_ID { get; set; }
        public string T_TRANSPORT_NAME { get; set; }
        public string T_TRANSPORT_VALUE { get; set; }
        public string T_TRACKING_NO { get; set; }
        public DateTime T_DATE { get; set; }
        public double T_WEIGHT { get; set; }
        public double T_CUBIC { get; set; }
        public double T_HEIGHT { get; set; }
        public double T_WIDTH { get; set; }
        public double T_HIGH{ get; set; }        
        public double T_PACK_NO { get; set; }        
        public string T_REMARK { get; set; }
        public string T_TYPE { get; set; }        
        #endregion

        #region TB_TRACKING_DETAIL
        public int TD_ID { get; set; }
        public DateTime TD_DATE { get; set; }
        public int TD_STATUS_ID { get; set; }
        public string TD_STATUS_NAME { get; set; }
        public string TD_ACTIVE { get; set; }
        public string TD_REMARK { get; set; }
        #endregion

    }
}

