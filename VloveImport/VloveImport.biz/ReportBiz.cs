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
        public DataTable GetOrderDetail(Int32 OID)
        {
            DataSet ds = new DataSet();
            ReportDal Dal = new ReportDal("LocalConnection");
            ds = Dal.GetOrderDetail(OID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public string GetOrderDetailReport(DataTable dt)
        {
            string txt = string.Empty;
            try
            {
                #region Header & Grid
                txt += "<!DOCTYPE html><html><head runat=\"server\"></head><body><table border=\"1\"><thead><tr><td>No</td><td>Shop Name</td><td>Shop Order Id</td><td>Size (CM)</td><td>Weight (KG)</td><td>Transport China Price</td><td>Product Type</td><td>Transport China To Thai (THB)</td></tr></thead><tbody>";
                foreach (DataRow item in dt.Rows)
                {
                    txt += "<tr></tr>";
                }
                txt += "</tbody></table>";
                #endregion
                #region Detail
                txt += "<fieldset><table><thead></thead><tbody><tr><td class=\"width15\">Transport Method China To Thai :</td><td class=\"width30\">" + 12 + "</td>";
                txt += "<td class=\"width20\">Transport Method To Customer :</td><td class=\"width35\">" + 12 + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Transport To Customer Detail : </td><td>" + 12 + "</td></tr>";
                txt += "<tr><td></td><td></td><td>Transport To Customer Date :</td><td>" + 12 + "</td></tr></tbody></table></fieldset>";
                #endregion
                #region Summary
                txt += "<fieldset><table><tr><td class='width20'>Total Transport China Price :</td><td class='width15 ItemStyle-right'>" + 12 + "</td><td class=\"width50\"></td></tr>";
                txt += "<tr><td>Total Transport China To Thai :</td><td>" + 12 + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Total Transport To Customer :</td><td>" + 12 + "</td><td></td><td></td></tr>";
                txt += "<tr><td>Service Charge :</td><td><u>" + 12 + "</u></td><td></td><td></td></tr>";
                txt += "<tr><td>Total Transport Price :</td><td><span>" + 12 + "</span></td><td></td><td></td></tr></table></fieldset></body></html>";
                #endregion
            }
            catch (Exception ex)
            {
            }
            return txt;
        }

    }
}
