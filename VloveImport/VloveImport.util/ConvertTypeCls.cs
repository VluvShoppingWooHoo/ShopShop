using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VloveImport.util
{
    public class ConvertTypeCls
    {
        public static double? ConvertToDouble(string strInt)
        {
            double? IntValue;
            if (strInt == "")
            {
                IntValue = null;
            }
            else
            {
                IntValue = Convert.ToDouble(strInt);
            }
            return IntValue;
        }
    }
}
