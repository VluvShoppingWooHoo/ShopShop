using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerProfile : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckSession(); 
                //string Cus_ID = GetCusID();//Request.QueryString["Cus_id"] == null ? "" : en.DecryptData(Request.QueryString["Cus_id"].ToString());                

                GenDDL();
                BindData();                
            }
        }

        protected void GenDDL()
        {
            ddlDay.Items.Add("วัน");
            for (int i = 1; i < 32; i++)
            {
                ddlDay.Items.Add(i.ToString());
            }            

            ddlMonth.Items.Add("เดือน");
            for (int i = 1; i < 13; i++)
            {
                ddlMonth.Items.Add(i.ToString());
            }

            ddlYear.Items.Add("ปี");
            int Year = DateTime.Now.Year - 100;
            Year = Year < 2500 ? Year + 543 : Year;
            for (int i = Year + 80; i > Year; i--)
            {
                ddlYear.Items.Add(i.ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 Cus_id = GetCusID();
            CustomerData Data = GetData();
            CustomerBiz Biz = new CustomerBiz();
            string strMsg = Biz.UPDATE_Customer_Profile(Data);
            if (strMsg == "")
                Response.Redirect("CustomerProfile.aspx");
        }

        protected CustomerData GetData()
        {
            CustomerData Data = new CustomerData();
            Data.Cus_ID = GetCusID();
            Data.Cus_Name = txtName.Text;
            Data.Cus_LName = txtLName.Text;
            Data.Cus_Gender = ddlGender.SelectedValue;

            string FileName = hddImg.Value;
            if(uplImg.HasFile)
            {
                if (!Directory.Exists(Server.MapPath("~/Attachment/Profile/")))
                    Directory.CreateDirectory(Server.MapPath("~/Attachment/Profile/"));

                string Extension = Path.GetExtension(uplImg.PostedFile.FileName);

                 if (Extension.ToUpper() == ".JPG" || Extension.ToUpper() == ".GIF" || Extension.ToUpper() == ".PNG")
                 {                     
                     string AttPath = Server.MapPath(@"~/Attachment/Profile");
                     FileName = uplImg.FileName.Replace(Extension, "") + Extension;

                     if (File.Exists(FileName))
                         File.Delete(FileName);

                     uplImg.PostedFile.SaveAs(AttPath + "/" + FileName);
                 }                             
            }

            Data.CUS_Pic = FileName;
            string InputDate = "";
            InputDate = ddlDay.SelectedIndex.ToString() + "/";
            InputDate = InputDate + ddlMonth.SelectedIndex.ToString() + "/";
            InputDate = InputDate + ddlYear.SelectedItem.Text;
            Data.Cus_BirthDay = InputDate;

            Data.Cus_Link_Shop = txtLinkShop.Text;
            Data.Update_User = lbCode.Text;
            return Data;
        }

        protected void BindData()
        {
            Int32 Cus_ID = GetCusID();
            CustomerBiz Biz = new CustomerBiz();
            DataTable dt = Biz.Get_Customer_Profile(Cus_ID);
            string Gender = "";
            hddDay.Value = "";
            hddMonth.Value = "";
            hddYear.Value = "";
            hddImg.Value = "";

            if (dt != null && dt.Rows.Count > 0)
            {
                Gender = dt.Rows[0]["Cus_Gender"].ToString() == "" ? "1" : dt.Rows[0]["Cus_Gender"].ToString();
                lbEMail.Text = dt.Rows[0]["Cus_Email"].ToString();
                lbCode.Text = dt.Rows[0]["Cus_Code"].ToString();
                txtName.Text = dt.Rows[0]["Cus_Name"].ToString();
                txtLName.Text = dt.Rows[0]["Cus_LName"].ToString();
                ddlGender.SelectedIndex = Convert.ToInt32(Gender) - 1;
                txtLinkShop.Text = dt.Rows[0]["Cus_Link_shop"].ToString();

                if (dt.Rows[0]["Cus_Pic"].ToString() != "")
                {
                    img.ImageUrl = "~/Attachment/Profile/" + dt.Rows[0]["Cus_Pic"].ToString();
                    hddImg.Value = dt.Rows[0]["Cus_Pic"].ToString();
                }

                string DateDB = dt.Rows[0]["Cus_Birthday"].ToString();
                if (DateDB != "")
                {
                    string[] Date = DateDB.Split('-');
                    ddlYear.SelectedItem.Text = Date[0];
                    ddlMonth.SelectedIndex = Convert.ToInt32(Date[1]) - 1;
                    ddlDay.SelectedIndex = Convert.ToInt32(Date[2]) - 1;
                }
            }

        }
    }
}