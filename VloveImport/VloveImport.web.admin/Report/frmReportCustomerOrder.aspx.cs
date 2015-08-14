using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using VloveImport.biz;
using VloveImport.web.admin.App_Code;

namespace VloveImport.web.admin.Report
{
    public partial class frmReportCustomerOrder : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ucCalendar1.SET_DATE(DateTime.Now.AddMonths(-2));
                ucCalendar2.SET_DATE_DEFAULT();
            }
        }

        private void BindDataReport()
        {
            DataSet ds = new DataSet();
            AdminBiz adminBiz = new AdminBiz();
            ds = adminBiz.GetReportCustomerOrder(ucCalendar1.GET_DATE_TO_DATE().GetValueOrDefault(), ucCalendar2.GET_DATE_TO_DATE().GetValueOrDefault(), txtCusCode.Text.Trim(), "");

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("ReportCustomer");

            ws.Cells["D1"].Value = "รายงานยอดขาย และ ยอดค่าขนส่ง";
            ws.Cells["D1"].Style.Font.UnderLine = true;
            ws.Cells["D1"].Style.Font.Bold = true;

            #region Set Width Cell

            ws.Column(1).Width = 2;
            ws.Column(2).Width = 8;
            ws.Column(3).Width = 40;
            ws.Column(4).Width = 15;
            ws.Column(5).Width = 15;
            ws.Column(6).Width = 15;
            ws.Column(7).Width = 15;
            ws.Column(8).Width = 15;
            ws.Column(9).Width = 15;
            ws.Column(10).Width = 15;
            ws.Column(11).Width = 15;
            ws.Column(12).Width = 15;

            #endregion

            #region Header Title

            string SRowTitle = "3";

            ws.Cells["B" + SRowTitle].Value = "ลำดับ";
            ws.Cells["C" + SRowTitle].Value = "รหัสสมาชิก";
            ws.Cells["D" + SRowTitle].Value = "ชื่อสมาชิก";
            ws.Cells["E" + SRowTitle].Value = "จำนวนการสั่งซื้อ";
            ws.Cells["F" + SRowTitle].Value = "จำนวนเงินรวมที่สั่งซื้อ หยวน/บาท";
            ws.Cells["G" + SRowTitle].Value = "จำนวนเงินค่าขนส่งในจีน หยวน/บาท";
            ws.Cells["H" + SRowTitle].Value = "จำนวนเงินค่าขนส่งระหว่างประเทศ";
            ws.Cells["I" + SRowTitle].Value = "จำนวนเงินค่าขนส่งในประเทศ";
            ws.Cells["J" + SRowTitle].Value = "จำนวนเงินรวมค่าขนส่ง"; //----------
            ws.Cells["K" + SRowTitle].Value = "น้ำหนักสินค้า กิโลกรัม";
            ws.Cells["L" + SRowTitle].Value = "ขนาดสินค้า คิว";
            ws.Cells["M" + SRowTitle].Value = "จำนวนเงินรวมทั้งหมด"; //----------
            #endregion

            #region Set Header Border

            ws.Cells["B" + SRowTitle + ":M" + SRowTitle].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.Black);
            ws.Cells["B" + SRowTitle + ":M" + SRowTitle].Style.Border.Right.Style = ExcelBorderStyle.Medium;
            ws.Cells["B" + SRowTitle + ":M" + SRowTitle].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

            //ws.Cells["B" + SRowTitle + ":M" + SRowTitle].Style.Fill.PatternType = ExcelFillStyle.Solid;
            //ws.Cells["B" + SRowTitle + ":M" + SRowTitle].Style.Fill.BackgroundColor.SetColor(colFromHeader);

            #endregion

            pck.SaveAs(Response.OutputStream);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;  filename=Sample1.xlsx");
            Response.End();
        }

        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            BindDataReport();
        }

        protected void btnReset_Click1(object sender, EventArgs e)
        {
            ucCalendar1.SET_DATE(DateTime.Now.AddMonths(-2));
            ucCalendar2.SET_DATE_DEFAULT();
            txtCusCode.Text = "";
            txtCusName.Text = "";
        }
    }
}