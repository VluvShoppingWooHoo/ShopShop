using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.Customer
{
    public partial class CustomerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CustomerData Data = GetData();
            CustomerBiz Biz = new CustomerBiz();
            Biz.UPDATE_Customer(Data);
        }

        protected CustomerData GetData()
        {
            CustomerData Data = new CustomerData();
            Data.Cus_Name = txtName.Text;
            Data.Cus_Gender = ddlGender.SelectedValue;
            //Data.Cus_BirthDay = txtName.Text;
            Data.Cus_Email = txtEmail.Text;
            Data.Cus_Link_Shop = txtEmail.Text;

            return Data;
        }
    }
}