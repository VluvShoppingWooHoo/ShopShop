using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.admin.MasterPage
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSessionUser();
            if (!IsPostBack)
            {
                CheckPermission();
                SetShowUser();
            }
        }

        private void SetShowUser()
        {
            AdminUserData Data = new AdminUserData();
            Data = (AdminUserData)(Session["AdminUser"]);
            lblEmpName.Text = Data.EMP_NAME + " " + Data.EMP_NAME;
            lblUser.Text = Data.USERNAME;
            lblUserGroup.Text = Data.GROUP_NAME;
        }

        private void CheckSessionUser()
        {
            if (Session["AdminUser"] == null)
            {
                Response.Redirect("~/Logout.aspx");
            }
        }

        private void CheckPermission()
        {
            //Check PagePermission
            string[] URL;
            string[] PAGE;
            string Page_URL = "";
            DataSet ds = new DataSet();
            URL = Page.Request.Url.ToString().Split('/');
            PAGE = URL[URL.Length - 1].Split('.');
            Page_URL = "%" + PAGE[0] + "%";
            PermissionBiz Biz = new PermissionBiz();
            ds = Biz.GetPageByURL(Page_URL);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)            
                if (!CheckPage(ds.Tables[0].Rows[0]["PAGE_CODE"].ToString()))
                    Response.Redirect("~/Logout.aspx");
        }

        /// <summary>
        /// Return True When have permission
        /// Return False When Not have permission
        /// </summary>
        /// <param name="PageCode"></param>
        /// <returns></returns>
        private bool CheckPage(string PageCode)
        {
            //Fix Code "Logout" 
            if (PageCode == "99")
                return true;

            AdminUserData User;
            if (Session["AdminUser"] != null)
                User = (AdminUserData)Session["AdminUser"];
            else
                return false;

            string[] Permission = User.GROUP_ROLE.Split('|');
            foreach (string str in Permission)
            {
                if (str == PageCode)
                    return true;
            }
            return false;
        }
    }
}