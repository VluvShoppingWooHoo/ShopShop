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
                #region Variables
                DataTable dt0 = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                DataTable dt2 = ds.Tables[2];
                DataTable dt3 = ds.Tables[3];
                #endregion
                #region Header & Grid
                txt += "<!DOCTYPE html><html><head runat=\"server\"></head><body class=''small''><table border=\"1\" cellspacing=\"0\"><thead>";
                txt += "<tr class=''headline''><td>No</td><td>Shop Name</td><td>Shop Order Id</td><td>Size (CM)</td><td>Weight (KG)</td><td>Transport China Price</td><td>Product Type</td><td>Transport China To Thai (THB)</td></tr></thead><tbody>";
                foreach (DataRow item in dt0.Rows)
                {
                    txt += "<tr><td>" + item["ROW_INDEX"] + "</td><td>" + item["SHOPNAME"].ToString().Replace(">", "").Replace("<", "") + "</td><td>" + item["SHOP_ORDER_ID"] + "</td><td>" + item["SIZE"] + "</td><td>" + item["WEIGHT"] + "</td><td>" + item["TRANSPORT_CHINA_PRICE"] + "</td><td>" + item["PRODUCT_TYPE"] + "</td><td>" + item["TRANSPORT_THAI_PRICE"] + "</td></tr>";
                }
                txt += "</tbody></table>";
                #endregion
                #region Detail
                txt += "<fieldset><table><thead></thead><tbody><tr class=\"small\"><td class=\"width15\">Transport Method China To Thai :</td><td class=\"width30\">" + dt1.Rows[0]["TRANSPORT_CH_TH_METHOD"] + "</td>";
                txt += "<td class=\"width20\">Transport Method To Customer :</td><td class=\"width35\">" + dt1.Rows[0]["TRANSPORT_TH_CU_METHOD"] + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Transport To Customer Detail : </td><td>" + dt1.Rows[0]["TRANSPORT_DETAIL"] + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Transport To Customer Date :</td><td>" + dt1.Rows[0]["TRANSPORT_DATE"] + "</td></tr></tbody></table></fieldset>";
                #endregion
                #region Summary
                txt += "<fieldset><table><tr><td class='width20'>Total Transport China Price :</td><td class='width15 ItemStyle-right'>" + dt1.Rows[0]["TOTAL_TRANSPORT_CHINA_PRICE"] + "</td><td class=\"width50\"></td></tr>";
                txt += "<tr><td>Total Transport China To Thai :</td><td>" + dt1.Rows[0]["TOTAL_TRANSPORT_CHINA_TO_THAI"] + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Total Transport To Customer :</td><td>" + dt1.Rows[0]["TRANSPORT_CUSTOMER_PRICE"] + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Service Charge :</td><td><u>" + dt1.Rows[0]["SERVICE_CHARGE"] + "</u></td><td></td><td></td></tr>";
                txt += "<tr><td>Total Transport Price :</td><td><span>" + dt1.Rows[0]["TOTAL_TRANSPORT_PRICE"] + "</span></td><td></td><td></td></tr></table></fieldset></body></html>";
                #endregion
            }
            catch (Exception ex)
            {
            }
            return txt;
        }

    }
}
