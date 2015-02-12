using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncrypDLL;

namespace VloveImport.util
{
    public class EncrypUtil
    {

        public string EncrypData(string strText)
        {
            EncrypDLL.EncrypDll Enc = new EncrypDLL.EncrypDll();
            return Enc.Encrypt(strText,"VLOVEIMPORT");
        }

        public string DecryptData(string strText)
        {
            EncrypDLL.EncrypDll Enc = new EncrypDLL.EncrypDll();
            return Enc.Decrypt(strText, "VLOVEIMPORT");
        }

    }
}
