using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.data
{
    public class ContentData
    {
        public int ContentID { get; set; }
        public string ContentTitle { get; set; }
        public string ContentDetail { get; set; }
        public string ContentImage { get; set; }
        public string ContentType { get; set; }
        public int IsActive { get; set; }
        public DateTime ContentDate { get; set; }
    }
}
