using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;

namespace VloveImport.web.UserControls
{
    public partial class ucAccFuncTopup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataDropdown_time();
                BindData();
            }
        }

        public void BindDataDropdown_time()
        {
            TransactionData EnTran = new TransactionData();
            List<TransactionData> ListTran_HOUR = new List<TransactionData>();
            List<TransactionData> ListTran = new List<TransactionData>();

            for (int i = 0; i <= 59; i++)
            {
                EnTran = new TransactionData();
                EnTran.PAYMENT_TIME = i.ToString().PadLeft(2, '0');
                ListTran.Insert(i, EnTran);
                if (i < 25) ListTran_HOUR.Insert(i, EnTran);
            }

            ddlH.DataSource = ListTran_HOUR;
            ddlH.DataBind();

            ddlM.DataSource = ListTran;
            ddlM.DataBind();

            ddls.DataSource = ListTran;
            ddls.DataBind();

        }

        public void BindData()
        {
            DataSet ds = new DataSet();
            commonBiz Biz = new commonBiz();
            ds = Biz.GET_DATA_BANK_SHOP(0, "BINDDATA_RB");

            if (ds.Tables[0].Rows.Count > 0)
            {
                rbList1_bank_list.DataSource = ds.Tables[0];
                rbList1_bank_list.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}