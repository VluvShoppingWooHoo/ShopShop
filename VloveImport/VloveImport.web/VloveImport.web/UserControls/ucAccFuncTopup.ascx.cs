using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.web.App_Code;

namespace VloveImport.web.UserControls
{
    public partial class ucAccFuncTopup : System.Web.UI.UserControl
    {
        BasePage bp = new BasePage();
        public int _VS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_ID"]); }
            set { ViewState["__VS_ID"] = value; }
        }

        public int _VS_CUS_ID
        {
            get { return Convert.ToInt32(ViewState["__VS_CUS_ID"]); }
            set { ViewState["__VS_CUS_ID"] = value; }
        }

        public string _VS_ACT
        {
            get { return ViewState["__VS_ACT"].ToString(); }
            set { ViewState["__VS_ACT"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                BasePage bp = new BasePage();
                this._VS_CUS_ID = bp.GetCusID();
                BindDataDropdown_time();
                BindData();
                GetMymoney();
            }
        }

        public void GetMymoney()
        {
            CustomerBiz biz = new CustomerBiz();
            double Mymoney = biz.GET_CUSTOMER_BALANCE(this._VS_CUS_ID);
            lbMymoney.Text = Mymoney.ToString("###,##0.00");
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
                if (i < 24) ListTran_HOUR.Insert(i, EnTran);
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
                ddlBank.DataSource = ds.Tables[0];
                ddlBank.DataBind();
            }
        }

        public bool CheckInput()
        {
            bool IsReturn = true;

            if (ddlBank.SelectedValue == "" || txt_tranfer_amount.Text.Trim() == ""
                                                        || dtMaterial.Value.Trim() == ""
                                                        )
            {
                IsReturn = false;
                bp.ShowMessageBox("กรุณากรอกข้อมูลในช่องที่มีสัญลักษณ์ *", this.Page);
                return IsReturn;
            }


            return IsReturn;
        }



        public void ClearData()
        {
            ddlBank.SelectedIndex = 0;
            txt_tranfer_amount.Text = "";
            dtMaterial.Value = "";
            txt_remark.Text = "";
            ddlH.SelectedIndex = 0;
            ddlM.SelectedIndex = 0;
            ddls.SelectedIndex = 0;
        }

        #region Convert Date to YYYYMMDD

        public System.Nullable<System.DateTime> Convert_DateYYYYMMDD(string dtDate)
        {
            string[] StrDate;
            string DayDate;
            string MonthDate;
            string YearDate;
            System.Nullable<System.DateTime> dateSave = default(System.Nullable<System.DateTime>);

            if (!string.IsNullOrEmpty(dtDate) & dtDate != " ")
            {
                StrDate = dtDate.Split('/');
                DayDate = StrDate[0];
                MonthDate = StrDate[1];
                YearDate = (Convert.ToInt32(StrDate[2]) - 543).ToString();

                if (YearDate.Length > 4)
                {
                    YearDate = YearDate.Substring(0, 4);
                }
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); //"en-US" "th-TH"
                dateSave = new DateTime(Convert.ToInt32(YearDate.Trim()), Convert.ToInt32(MonthDate.Trim()), Convert.ToInt32(DayDate.Trim()));
            }
            else
            {
                dateSave = null;
            }
            return dateSave;
        }
        #endregion

        protected void btnTopup_Click(object sender, EventArgs e)
        {
            string Result = "";
            TransactionData EnTran = new TransactionData();
            try
            {
                //Check Input               
                if (txt_tranfer_amount.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('กรุณาระบุจำนวนเงิน');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
                    return;
                }

                if (dtMaterial.Value == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('กรุณาระบุวันที่โอนเงิน');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
                    return;
                }

                //Process
                string Extension = "", FileName = "";
                EnTran.Cus_ID = bp.GetCusID();
                if (Ifile.HasFile)
                {
                    if (!Directory.Exists(Server.MapPath("~/Attachment/Topup/")))
                        Directory.CreateDirectory(Server.MapPath("~/Attachment/Topup/"));

                    Extension = Path.GetExtension(Ifile.PostedFile.FileName);

                    if (Extension.ToUpper() == ".JPEG" || Extension.ToUpper() == ".JPG" || Extension.ToUpper() == ".GIF" || Extension.ToUpper() == ".PNG")
                    {
                        string AttPath = Server.MapPath(@"~/Attachment/Topup");
                        FileName = bp.GetCusCode() + "_" + DateTime.Now.ToString("yyyyMMdd_hhmmss", new CultureInfo("en-US")) + Extension;

                        Ifile.PostedFile.SaveAs(AttPath + "/" + FileName);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('ประเภทไฟล์ไม่ถูกต้อง');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
                        return;
                    }
                    EnTran.TRANS_PICURL = FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('กรุณาเลือกไฟล์');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
                    return;
                }

                EnTran.TRAN_TYPE = 1;
                EnTran.TRAN_TABLE_TYPE = 1;
                EnTran.TRAN_DETAIL = "รายการฝากเงิน";

                EnTran.BANK_ID = Convert.ToInt32(ddlBank.SelectedValue);
                EnTran.TRAN_AMOUNT = Convert.ToDouble(txt_tranfer_amount.Text);
                EnTran.PAYMENT_DATE = Convert.ToDateTime(bp.Convert_DateYYYYMMDD(dtMaterial.Value, '-', "YYYYMMDD", 0));
                EnTran.PAYMENT_TIME = ddlH.Text + ':' + ddlM.Text + ':' + ddls.Text;
                //EnTran.TRAN_EMAIL = txt_email.Text.Trim();
                EnTran.TRAN_REMARK = txt_remark.Text.Trim();
                EnTran.TRAN_STATUS = 1;
                EnTran.Create_User = bp.GetCusCode();

                CustomerBiz CusBiz = new CustomerBiz();
                Result = CusBiz.INS_UPD_TRANSACTION(EnTran, "INS", 0);
                if (Result == string.Empty)
                {
                    string EmailTo = WebConfigurationManager.AppSettings["email"].ToString();
                    string Subject = "Topup : " + bp.GetCusCode();
                    string Body = "มีการเติมเงินจาก " + bp.GetCusCode() + " เป็นจำนวน " + txt_tranfer_amount.Text + " บาท <br/> หมายุเหตุ : " + txt_remark.Text;
                    bp.SendMail(EmailTo, Subject, Body);

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>alert('เติมเงินสำเร็จ');window.location = '/Customer/CustomerMyAccount.aspx';</script>", false);
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "<script>window.location.href = '/Customer/CustomerMyAccount.aspx'", false);
                    //Response.Redirect("~/Customer/CustomerMyAccount.aspx");
                }
                else
                {
                    bp.WriteLog("ucTopup", "btnTopup", Result);
                }
            }
            catch (Exception ex)
            {
                bp.WriteLog("ucTopup", "btnTopup", ex.Message);
                lblERR1.Text = ex.ToString();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

    }
}