using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.util;

namespace VloveImport.web.Administrator
{
    public partial class Encryp : System.Web.UI.Page
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEncryp_Click(object sender, EventArgs e)
        {            
            txt.Text = en.EncrypData(txt.Text);
        }

        protected void btnDecryp_Click(object sender, EventArgs e)
        {
            txt.Text = en.DecryptData(txt.Text);
        }
    }
}