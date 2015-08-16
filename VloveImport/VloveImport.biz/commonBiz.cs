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

        public Byte[]PrintPdf(string html, string css)
        {
            //Create a byte array that will eventually hold our final PDF
            Byte[] bytes;

            //Boilerplate iTextSharp setup here
            //Create a stream that we can write to, in this case a MemoryStream
            using (var ms = new MemoryStream())
            {
                float w = PageSize.A4.Width;
                float h = PageSize.A4.Height;
                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new Document(new Rectangle(w, h), 20f, 20f, 30f, 30f))
                {
                    //Create a writer that's bound to our PDF abstraction and our stream
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {
                        //Open the document for writing
                        doc.Open();

                        //Our sample HTML and CSS
                        var example_html = html;
                        var example_css = css;
                        #region 1
                        //example_html = web.DocumentNode.InnerHtml;
                        /**************************************************
                         * Example #1                                     *
                         *                                                *
                         * Use the built-in HTMLWorker to parse the HTML. *
                         * Only inline CSS is supported.                  *
                         * ************************************************/

                        //Create a new HTMLWorker bound to our document
                        //using (var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(doc))
                        //{

                        //    //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                        //    using (var sr = new StringReader(example_html))
                        //    {
                        //        htmlWorker.Parse(sr);
                        //    }
                        //}
                        #endregion
                        #region 2
                        /////**************************************************
                        //// * Example #2                                     *
                        //// *                                                *
                        //// * Use the XMLWorker to parse the HTML.           *
                        //// * Only inline CSS and absolutely linked          *
                        //// * CSS is supported                               *
                        //// * ************************************************/

                        ////XMLWorker also reads from a TextReader and not directly from a string
                        //using (var srHtml = new StringReader(example_html))
                        //{

                        //    //Parse the HTML
                        //    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, srHtml);
                        //}
                        #endregion
                        #region 3
                        /**************************************************
                         * Example #3                                     *
                         *                                                *
                         * Use the XMLWorker to parse HTML and CSS        *
                         * ************************************************/

                        //In order to read CSS as a string we need to switch to a different constructor
                        //that takes Streams instead of TextReaders.
                        //Below we convert the strings into UTF8 byte array and wrap those in MemoryStreams
                        using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_html)))
                            {

                                //Parse the HTML
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                            }
                        }
                        #endregion
                        doc.Close();
                    }
                }

                //After all of the PDF "stuff" above is done and closed but **before** we
                //close the MemoryStream, grab all of the active bytes from the stream
                bytes = ms.ToArray();
            }

            //Now we just need to do something with those bytes.
            //Here I'm writing them to disk but if you were in ASP.Net you might Response.BinaryWrite() them.
            //You could also write the bytes to a database in a varbinary() column (but please don't) or you
            //could pass them to another function for further PDF processing.
            return bytes;
        }
    }
}
