using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using VloveImport.biz;

namespace VloveImport.web
{
    public class PdfClass
    {
        #region 1
        public Byte[] PrintPdf(string html)
        {
            string filePath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            StreamReader streamReader = new StreamReader(filePath + @"\App_Themes\v_th1\report.css");
            //StreamReader streamReader = new StreamReader("~/App_Themes/th1/report.css");
            string css = streamReader.ReadToEnd();
            streamReader.Close();
            html = @"" + prePrint(html);
            css = @"" + css;
            commonBiz biz = new commonBiz();
            byte[] bytes = biz.PrintPdf(html, css);
            return bytes;
        }
        private string prePrint(string html)
        {
            html = html.Replace("''", "\"");
            return html;
        }
        #endregion
    }
}