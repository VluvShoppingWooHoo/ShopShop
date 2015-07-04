using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VloveImport.web
{
    public partial class frmError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                VloveImport.web.App_Code.BasePage.ErrorInfo errorInfo = (VloveImport.web.App_Code.BasePage.ErrorInfo)Session["Error"];
                string strError = "ErrorUrl " + errorInfo.ErrorUrl + "\n";
                strError += "ErrorMessage " + errorInfo.ErrorMessage + "\n";
                strError += "ErrorSource " + errorInfo.ErrorSource + "\n";
                strError += "ErrorStackTrace " + errorInfo.ErrorStackTrace + "\n";
                txtError.Text = strError;
            }
            catch { }
        }
    }
}