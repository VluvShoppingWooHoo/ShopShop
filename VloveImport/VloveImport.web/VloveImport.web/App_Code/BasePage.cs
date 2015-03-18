using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EncrypDLL;
using VloveImport.data;

namespace VloveImport.web.App_Code
{
    public class BasePage : System.Web.UI.Page
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

        public string GetCusID()
        {
            if (Session["User"] != null)
                return ((CustomerData)Session["User"]).Cus_ID.ToString();
            else
                return "";
                    
        }
    }
}