using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VloveImport.web
{
    public partial class TestPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        //public static string SampleMethod(object txt)
        public static string SampleMethod(string cb, string rdb, string dtMat, string dtHTML, string ddl)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            
            //do process

            return js.Serialize("");
        }
    }
}