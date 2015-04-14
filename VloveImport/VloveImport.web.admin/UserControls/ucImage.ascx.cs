using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VloveImport.web.admin.UserControls
{
    public partial class ucImage : System.Web.UI.UserControl
    {
        private string url;
        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            SetImage();
        }

        public void SetImage()
        {
            img1.ImageUrl = url;
            //img1.ImageUrl = "~/images/icon/l_box.png";
        }
    }
}