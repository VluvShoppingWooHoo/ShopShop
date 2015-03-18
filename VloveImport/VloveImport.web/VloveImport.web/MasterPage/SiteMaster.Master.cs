﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VloveImport.web.MasterPage
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSessionUser();
        }

        private void CheckSessionUser()
        {
            if (Session["User"] == null)
            {
                ucCustomerStatus.CheckLogin(false);
            }
            else
            {
                ucCustomerStatus.CheckLogin(true);
            }

        }


    }
}