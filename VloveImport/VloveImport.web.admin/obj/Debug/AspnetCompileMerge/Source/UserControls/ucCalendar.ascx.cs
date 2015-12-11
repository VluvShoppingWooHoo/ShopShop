using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VloveImport.web.admin.UserControls
{
    public partial class ucCalendar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        #region Convert Date to YYYYMMDD

        private System.Nullable<System.DateTime> Convert_DateYYYYMMDD(string dtDate)
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
                //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US"); //"en-US" "th-TH"
                dateSave = new DateTime(Convert.ToInt32(YearDate.Trim()), Convert.ToInt32(MonthDate.Trim()), Convert.ToInt32(DayDate.Trim()));
            }
            else
            {
                dateSave = null;
            }
            return dateSave;
        }
        #endregion

        public void SET_DATE(DateTime sDate)
        {
            try
            {
                txtcalendar.Text = sDate.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                txtcalendar.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        public void SET_DATE_DEFAULT()
        {
            txtcalendar.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public string GET_DATE_TO_STRING(string FormatText = "yyyy-MM-dd")
        {
            return Convert_DateYYYYMMDD(txtcalendar.Text.Trim()).Value.ToString(FormatText);
        }

        public Nullable<System.DateTime> GET_DATE_TO_DATE()
        {
            return Convert_DateYYYYMMDD(txtcalendar.Text.Trim());
        }

        public void ClearData()
        {
            txtcalendar.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        public void CleanDataTextBox()
        {
            txtcalendar.Text = "";
        }

    }
}