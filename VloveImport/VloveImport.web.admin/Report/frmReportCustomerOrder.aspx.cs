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
using VloveImport.util;
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
            ds = adminBiz.GetReportCustomerOrder(ucCalendar1.GET_DATE_TO_DATE().GetValueOrDefault(), ucCalendar2.GET_DATE_TO_DATE().GetValueOrDefault(), txtCusCode.Text.Trim(), txtCusName.Text.Trim());

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ExcelPackage pck = new ExcelPackage();
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("ReportCustomer");

                ws.Cells["B1:N1"].Merge = true;
                ws.Cells["B1:N1"].Value = "รายงานยอดขาย และ ยอดค่าขนส่ง";
                ws.Cells["B1:N1"].Style.Font.UnderLine = true;
                ws.Cells["B1:N1"].Style.Font.Bold = true;
                ws.Cells["B1:N1"].Style.WrapText = true;
                ws.Cells["B1:N1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                ws.Cells["B1:N1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                #region Set Width Cell

                ws.Column(1).Width = 2;
                ws.Column(2).Width = 8;
                ws.Column(3).Width = 15;
                ws.Column(4).Width = 40;
                ws.Column(5).Width = 15;
                ws.Column(6).Width = 15;
                ws.Column(7).Width = 25;
                ws.Column(8).Width = 25;
                ws.Column(9).Width = 15;
                ws.Column(10).Width = 15;
                ws.Column(11).Width = 15;
                ws.Column(12).Width = 15;
                ws.Column(13).Width = 15;
                ws.Column(14).Width = 15;
                ws.Column(15).Width = 15;

                #endregion

                #region Header Title

                string SRowTitle = "3";

                ws.Cells["B" + SRowTitle].Value = "ลำดับ";
                ws.Cells["C" + SRowTitle].Value = "รหัสสมาชิก";
                ws.Cells["D" + SRowTitle].Value = "ชื่อสมาชิก";
                ws.Cells["E" + SRowTitle].Value = "คะแนนคงเหลือ";
                ws.Cells["F" + SRowTitle].Value = "จำนวนการสั่งซื้อ";
                ws.Cells["G" + SRowTitle].Value = "จำนวนเงินรวมที่สั่งซื้อ(สินค้า) หยวน/บาท";
                ws.Cells["H" + SRowTitle].Value = "จำนวนเงินค่าขนส่งในจีน หยวน/บาท";
                ws.Cells["I" + SRowTitle].Value = "จำนวนเงินค่าขนส่งระหว่างประเทศ";
                ws.Cells["J" + SRowTitle].Value = "จำนวนเงินค่าขนส่งในประเทศ";
                ws.Cells["K" + SRowTitle].Value = "จำนวนเงินรวมค่าขนส่ง"; //----------
                ws.Cells["L" + SRowTitle].Value = "น้ำหนักสินค้า กิโลกรัม";
                ws.Cells["M" + SRowTitle].Value = "ขนาดสินค้า คิว";
                ws.Cells["N" + SRowTitle].Value = "จำนวนเงินรวมทั้งหมด"; //----------

                ws.Cells["B" + SRowTitle + ":N" + SRowTitle].Style.HorizontalAlignment = ExcelHorizontalAlignment.CenterContinuous;
                ws.Cells["B" + SRowTitle + ":N" + SRowTitle].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                #endregion

                #region Set Header Border

                ws.Cells["B" + SRowTitle + ":N" + SRowTitle].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.Black);
                ws.Cells["B" + SRowTitle + ":N" + SRowTitle].Style.Border.Right.Style = ExcelBorderStyle.Medium;
                ws.Cells["B" + SRowTitle + ":N" + SRowTitle].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

                //ws.Cells["B" + SRowTitle + ":M" + SRowTitle].Style.Fill.PatternType = ExcelFillStyle.Solid;
                //ws.Cells["B" + SRowTitle + ":M" + SRowTitle].Style.Fill.BackgroundColor.SetColor(colFromHeader);

                #endregion

                #region Body Data

                string RowBody = "4";
                string EndRowBody = (ds.Tables[0].Rows.Count - 1 + Convert.ToInt32(RowBody)).ToString();
                ws.Cells["B" + RowBody].LoadFromDataTable(ds.Tables[0], false);

                ws.Cells["B" + RowBody + ":N" + EndRowBody].Style.Border.BorderAround(ExcelBorderStyle.Medium, Color.Black);
                ws.Cells["B" + RowBody + ":N" + EndRowBody].Style.Border.Right.Style = ExcelBorderStyle.Medium;
                ws.Cells["B" + RowBody + ":N" + EndRowBody].Style.Border.Bottom.Style = ExcelBorderStyle.Medium;

                ws.Cells["G" + RowBody + ":N" + EndRowBody].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                ws.Cells["B" + RowBody + ":N" + EndRowBody].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                #endregion

                pck.SaveAs(Response.OutputStream);
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Sample1.xlsx");
                Response.End();
            }


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