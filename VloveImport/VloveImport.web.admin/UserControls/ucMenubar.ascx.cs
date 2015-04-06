using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.admin.UserControls
{
    public partial class ucMenubar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetPermission();
        }

        #region SetPermission
        private void SetPermission()
        {
            //Add bt Champ 20141209
            //Menu
            DataTable dtRoot = new DataTable();
            DataTable dtParent = new DataTable();
            MenuItem miRoot;    //, miParent;
            string Page_Group;
            //Get Menu first and then Compare with Permission  
            PermissionBiz biz = new PermissionBiz();
            dtRoot = biz.Get_MenuListByType("R");
            if (dtRoot != null && dtRoot.Rows.Count > 0)
            {
                foreach (DataRow drRoot in dtRoot.Rows)
                {
                    if (CheckPage(drRoot["PAGE_CODE"].ToString()))
                    {
                        Page_Group = drRoot["PAGE_GROUP"].ToString();
                        miRoot = new MenuItem();
                        miRoot.Text = drRoot["PAGE_NAME"].ToString();
                        miRoot.NavigateUrl = drRoot["PAGE_URL"].ToString();
                        Menu1.Items.Add(miRoot);

                        //dtParent = PermissionBiz.Get_MenuListByGroup(Page_Group);
                        //if (dtParent != null && dtParent.Rows.Count > 0)
                        //{
                        //    foreach (DataRow drParent in dtParent.Rows)
                        //    {
                        //        if (CheckPage(drParent["PAGE_CODE"].ToString()))
                        //        {
                        //            miParent = new MenuItem();
                        //            miParent.Text = drParent["PAGE_NAME"].ToString();
                        //            miParent.NavigateUrl = drParent["PAGE_URL"].ToString();
                        //            miRoot.ChildItems.Add(miParent);
                        //        }
                        //    }
                        //}
                        //if (miRoot.NavigateUrl == "" && miRoot.ChildItems.Count == 0)
                        //{

                        //}
                        //else
                        //    Menu1.Items.Add(miRoot);
                    }
                }

            }

        }
        private bool CheckPage(string PageCode)
        {
            //Fix Code Root "Logout" 
            if (PageCode == "99")
                return true;

            AdminUserData User = (AdminUserData)Session["AdminUser"];
            string[] Permission = User.GROUP_ROLE.Split('|');
            foreach (string str in Permission)
            {
                if (str == PageCode)
                    return true;
            }
            return false;
        }

        #endregion
    }
}