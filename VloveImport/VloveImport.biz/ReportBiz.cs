using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VloveImport.dal;
using VloveImport.data;

namespace VloveImport.biz
{
    public class ReportBiz
    {
        public DataSet GetOrderDetail(Int32 OID)
        {
            DataSet ds = new DataSet();
            ReportDal Dal = new ReportDal("LocalConnection");
            ds = Dal.GetOrderDetail(OID);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            else
                return null;
        }
        public string GetOrderDetailReport(DataSet ds)
        {
            string txt = string.Empty;
            try
            {
                #region Transport Detail
                #region Variables
                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                DataTable dt4 = ds.Tables[4];
                #endregion
                #region Header & Grid
                txt += "<!DOCTYPE html><html><head runat=\"server\"></head><body class=''font150''>";
                txt += "<div class=''headSection''>";
                txt += "<div class=''pic''>" + string.Format("<img src=''http://admin.iloveimport.com/img/logo/LOGO-01.jpg''/>") + "</div>";
                //txt += string.Format("<img src=''http://admin.iloveimport.com/img/logo/LOGO-01.jpg''");
                txt += "<div class=''text''>ใบเสร็จ</div>";
                txt += "</div>";
                txt += "<span>Invoice No : " + dt4.Rows[0]["ORDER_CODE"] + "</span>";
                txt += "<fieldset><table class=''grid'' border=\"1\" cellspacing=\"0\"><thead>";
                txt += "<tr class=''''><td class=''width5''>No</td><td class=''width20''>Shop Name</td><td class=''width10''>Shop Order Id</td><td class=''width10''>Size (CM)</td><td class=''width10''>Weight (KG)</td><td class=''width10''>Transport China Price(THB,Y)</td><td class=''width10''>Product Type</td><td class=''width10''>Transport China To Thai (THB)</td></tr></thead><tbody>";
                foreach (DataRow item in dt0.Rows)
                {
                    txt += "<tr><td>" + item["ROW_INDEX"] + "</td><td>" + item["SHOPNAME"].ToString().Replace(">", "").Replace("<", "") + "</td><td>" + item["SHOP_ORDER_ID"] + "</td><td>" + item["SIZE"] + "</td><td>" + item["WEIGHT"] + "</td><td>" + item["TRANSPORT_CHINA_PRICE"] + "</td><td>" + item["PRODUCT_TYPE"] + "</td><td>" + String.Format("{0:N2}", item["TRANSPORT_THAI_PRICE"]) + "</td></tr>";
                }
                txt += "</tbody></table></fieldset>";
                #endregion
                #region Detail
                txt += "<fieldset><table class=''detail''><thead></thead><tbody>";
                txt += "<tr><td>Transport Method China To Thai :</td><td class=''valueCell''>" + dt1.Rows[0]["TRANSPORT_CH_TH_METHOD"] + "</td><td>Transport Method To Customer :</td><td class=''valueCell''>" + dt1.Rows[0]["TRANSPORT_TH_CU_METHOD"] + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Transport To Customer Detail : </td><td class=''width13''>" + dt1.Rows[0]["TRANSPORT_DETAIL"] + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Transport To Customer Date :</td><td class=''width13''>" + dt1.Rows[0]["TRANSPORT_DATE"] + "</td></tr></tbody></table></fieldset>";
                #endregion
                #region Summary
                txt += "<fieldset><table class=''detail''><tr><td>Total Transport China Price :</td><td class=''alignRight''>" + String.Format("{0:N2}", dt1.Rows[0]["TOTAL_TRANSPORT_CHINA_PRICE"]) + " (THB,Y)" + "</td><td></td></tr>";
                txt += "<tr><td>Total Transport China To Thai :</td><td class=''alignRight''>" + String.Format("{0:N2}", dt1.Rows[0]["TOTAL_TRANSPORT_CHINA_TO_THAI"]) + " (THB,Y)" + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Total Transport To Customer :</td><td class=''alignRight''>" + String.Format("{0:N2}", dt1.Rows[0]["TRANSPORT_CUSTOMER_PRICE"]) + " (THB,Y)" + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Service Charge :</td><td class=''alignRight''><u>" + String.Format("{0:N2}", dt1.Rows[0]["SERVICE_CHARGE"]) + "</u>" + " (THB,Y)" + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Total Transport Price :</td><td class=''alignRight''><span><u>" + String.Format("{0:N2}", dt1.Rows[0]["TOTAL_TRANSPORT_PRICE"]) + "</u>" + " (THB,Y)" + "</span></td><td></td><td></td></tr></table></fieldset>";
                #endregion
                #endregion
                #region Payment Detail
                #region Header & Grid
                txt += "<fieldset><table class=''grid'' border=''1'' cellspacing=''0''><thead>";
                txt += "<tr class=''''><td class=''width5''>No</td><td class=''width20''>Transaction Type</td><td class=''width20''>Transaction Date</td><td class=''width10''>Transaction Amount</td><td class=''width15''>Transaction Detail</td><td class=''width15''>Transaction Employee Detail</td></tr></thead>";
                txt += "<tbody>";
                foreach (DataRow item in dt2.Rows)
                {
                    txt += "<tr><td>" + item["ROW_INDEX"] + "</td><td>" + item["TRAN_TYPE_TEXT"] + "</td><td>" + item["TRAN_DATE_TEXT"] + "</td><td>" + String.Format("{0:N2}", item["TRAN_AMOUNT"]) + "</td><td>" + item["TRAN_DETAIL"] + "</td><td>" + item["EMP_REMARK"] + "</td></tr>";
                }
                txt += "</tbody></table></fieldset>";
                #endregion
                #region Detail
                txt += "<fieldset><table class=''detail''><thead></thead><tbody>";
                txt += "<tr><td>Total Income :</td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["TOTAL_INCOME"]) + "</td><td>Total Refund :</td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["TOTAL_REFUND"]) + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Additional Amount : </td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["TOTAL_ADDITIONAL_AMOUNT"]) + "</td></tr>";
                txt += "</tbody></table></fieldset>";
                #endregion
                #region Summary
                txt += "<fieldset><table class=''detail''><thead></thead><tbody>";
                txt += "<tr><td>Total Product Price :</td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["TOTAL_PRODUCT_PRICE"]) + "</td><td>Total Product Active Price :</td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["TOTAL_PRODUCT_PRICE_ACTIVE"]) + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Total Transport Active Price : </td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["TOTAL_TRANSPORT_PRICE"]) + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Service Charge : </td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["SERVICE_CHARGE"]) + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Discount : </td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["ORDER_DISCOUNT"]) + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Vip Discount : </td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["TOTAL_VIP_DISCOUNT"]) + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Transport Discount: </td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["TRANSPORT_CUSTOMER_PRICE_DIS"]) + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Acually Amount : </td><td class=''valueCell''>" + String.Format("{0:N2}", dt3.Rows[0]["ACTUALLY_AMOUNT"]) + "</td></tr>";
                txt += "</tbody></table></fieldset>";
                #endregion
                #region Status
                txt += "<fieldset><table class=''detail''><thead></thead><tbody>";
                txt += "<tr><td>Order Status :</td><td class=''''>" + dt4.Rows[0]["ORDER_STATUS"] + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Transport Status : </td><td class=''''>" + dt4.Rows[0]["TRANSPORT_STATUS"] + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Remark : </td><td class=''''>" + dt4.Rows[0]["EMP_REMARK"] + "</td><td></td><td></td></tr>";
                txt += "</tbody></table></fieldset>";
                txt += "</body></html>";
                #endregion
                #endregion
            }
            catch (Exception ex)
            {
            }
            return txt;
        }

    }
}
