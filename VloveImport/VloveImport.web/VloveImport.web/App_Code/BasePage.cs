using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EncrypDLL;

namespace VloveImport.web.App_Code
{
    public class BasePage
    {
        public string EncrypData(string strText)
        {
            EncrypDLL.EncrypDll Enc = new EncrypDLL.EncrypDll();
            return Enc.Encrypt(strText, "VLOVEIMPORT");
        }

        public string DecryptData(string strText)
        {
            EncrypDLL.EncrypDll Enc = new EncrypDLL.EncrypDll();
            return Enc.Decrypt(strText, "VLOVEIMPORT");
        }
    }
}