using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using System.Data.SqlClient;
using VloveImport.util;
using VloveImport.data;
using HtmlAgilityPack;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace VloveImport.biz
{
    public class commonBiz
    {

        public DataSet GetData_Region(int ADD_ID = 0, string ADD_NAME = "", int ADD_STATUS = 1, string Act = "")
        {
            Commondal Com = new Commondal("LocalConnection");
            return Com.GetData_Region(ADD_ID, ADD_NAME, ADD_STATUS, Act);
        }

        #region MASTER BANK

        public DataSet GET_DATA_MASTER_BANK(string Act, int BANK_ID = -1, string BANK_NAME = "", int BANKL_STATUS = -1)
        {
            Commondal Com = new Commondal("LocalConnection");
            return Com.GET_DATA_MASTER_BANK(BANK_ID, Act, BANK_NAME, BANKL_STATUS);
        }

        public DataSet GET_DATA_BANK_SHOP(int BANK_SHOP_ID, string Act, int BANK_ID = -1, string BANK_SHOP_ACCOUNT_NO = "", string BANK_SHOP_ACCOUNT_NAME = "")
        {
            Commondal Com = new Commondal("LocalConnection");
            return Com.GET_DATA_BANK_SHOP(BANK_SHOP_ID, Act, BANK_ID, BANK_SHOP_ACCOUNT_NO, BANK_SHOP_ACCOUNT_NAME);
        }

        public string INS_UPD_DATA_BANK_SHOP(CommonData EnBank, string Act)
        {
            Commondal Com = new Commondal("LocalConnection");
            return Com.INS_UPD_DATA_BANK_SHOP(EnBank, Act);
        }

        #endregion

        public string GetNoSeries(string NoSeries_Name)
        {
            string Result = "";
            Commondal Com = new Commondal("LocalConnection");
            DataSet ds = Com.GET_NOSERIES(NoSeries_Name);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                Result = ds.Tables[0].Rows[0]["NoSeries"].ToString();
            return Result;
        }

        public DataTable Get_ConfigByGroup(string Group)
        {
            DataTable dt = new DataTable();
            Commondal Com = new Commondal("LocalConnection");
            DataSet ds = Com.Get_ConfigByGroup(Group);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                dt = ds.Tables[0];
            return dt;
        }

        public void WriteLog(string Page, string Function, string Error)
        {
            Commondal Com = new Commondal("LocalConnection");
            string Result = Com.WriteLog(Page, Function, Error);
        }

        public Byte[] PrintPdf(string html, string css)
        {
            Byte[] bytes;
            using (var ms = new MemoryStream())
            {
                float w = PageSize.A4.Width;
                float h = PageSize.A4.Height;
                using (var doc = new Document(new Rectangle(w, h), 20f, 20f, 30f, 30f))
                {
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        doc.Open();
                        var example_html = html;
                        var example_css = css;
                        using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html)))
                            {
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss, new MyFontFactoryImpl());
                            }
                        }
                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
            }
            return bytes;
        }
        public class MyFontFactoryImpl : FontFactoryImp
        {
            Font defaultFont;
            public MyFontFactoryImpl()
            {
                BaseFont tahoma = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\tahoma.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);                
                defaultFont = new Font(tahoma, 12);
            }
            public override Font GetFont(string fontname, string encoding, Boolean embedded, float size, int style, BaseColor color, Boolean cached)
            {
                return defaultFont;
            }
        }
    }
}
