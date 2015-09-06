using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VloveImport.biz;
using VloveImport.data;
using VloveImport.util;
using VloveImport.web.App_Code;

namespace VloveImport.web.Customer
{
    public partial class CustomerBasket : BasePage
    {
        EncrypUtil en = new EncrypUtil();
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSession();  
            if (!IsPostBack)
            {
                Session.Remove("CUS_BK_ID");
                Session.Remove("TRANS");
                Session.Remove("ORDER");            
                BindData("", true);
                lbTotal.Text = "0.00 (¥)";
            }
        }

        protected void BindData(string Type, bool Check)
        {            
            ShoppingBiz Biz = new ShoppingBiz();
            DataTable dt = Biz.GetBasketList(GetCusID());
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["CUS_BK_SHOPNAME"].ToString() != "")
                    {
                        dr["CUS_BK_SHOPNAME"] = ReplaceCharOut(dr["CUS_BK_SHOPNAME"].ToString());
                        dr["CUS_BK_URL"] = ReplaceCharOut(dr["CUS_BK_URL"].ToString());
                    }
                }
                dt = GenShopName(dt);
                gvBasket.DataSource = dt;
                ViewState["SOURCE"] = dt;                
            }
            else
            {
                gvBasket.DataSource = null;
                ViewState["SOURCE"] = null;
            }

            gvBasket.DataBind();
            BindSession();

            if (Type == "ALL")
            {
                ((CheckBox)gvBasket.HeaderRow.Cells[0].FindControl("cbItemAll")).Checked = Check;
                CheckBox cb;
                foreach (GridViewRow gvr in gvBasket.Rows)
                {
                    cb = (CheckBox)gvr.Cells[0].FindControl("cbItem");
                    if (cb != null)
                        cb.Checked = Check;

                }
            }

            //GenShopname();
        }

        protected string ReplaceCharOut(string Input)
        {
            string Temp = Input;
            Input = Input.Replace("<font>", "");
            Input = Input.Replace("</font>", "");
            if(Input.Contains("</span>"))
            {
                try 
	            {
                    int Len = 0;
                    string[] spl, spl2;
                    spl = Input.Split(new string[] { "span" }, StringSplitOptions.None);
                    //spl = Input.Split(new string[] { "span" }, StringSplitOptions.None)[1].Split('>')[1].Remove(50 - 2);
                    if (spl.Length > 0)
                    {
                        foreach (string str in spl)
                        {
                            if (str.Contains(">"))
                            {
                                spl2 = str.Split('>');
                                if (spl2.Length > 0)
                                {
                                    foreach (string str2 in spl2)
                                    {
                                        if (str2.Contains("</"))
                                        {
                                            Len = str2.Length;
                                            Input = str2.Remove(Len - 2);
                                            return Input
                                        }
                                    }
                                }
                            }
                        }
                    }
	            }
	            catch (Exception ex)
	            {
                    WriteLog(Page.Request.Url.AbsolutePath, "ReplaceCharOut", Temp);
	            }
                
            }
            return Input;
        }

        protected void BindSession()
        {
            if (Session["CUS_BK_ID"] != null)
            {
                CheckBox cb;
                HiddenField hd;
                List<string> Chk = (List<string>)Session["CUS_BK_ID"];
                foreach (GridViewRow gvr in gvBasket.Rows)
                {
                    cb = new CheckBox();
                    hd = new HiddenField();
                    hd = (HiddenField)gvr.FindControl("hdBK_ID");
                    cb = (CheckBox)gvr.FindControl("cbItem");
                    if (hd != null && Chk.Contains(hd.Value))
                    {
                        if (cb != null)
                            cb.Checked = true;
                    }
                }
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {            
            Session.Remove("CUS_BK_ID");
            Session.Remove("TRANS");
            Session.Remove("ORDER");
            CheckBox cb;
            HiddenField hd;
            DataTable dtSelected = new DataTable();
            if (ViewState["SOURCE"] != null)
            {
                dtSelected = ((DataTable)ViewState["SOURCE"]).Copy();
                foreach (GridViewRow gvr in gvBasket.Rows)
                {
                    cb = new CheckBox();
                    hd = new HiddenField();
                    cb = (CheckBox)gvr.FindControl("cbItem");
                    if (cb != null && !cb.Checked)
                    {
                        hd = (HiddenField)gvr.FindControl("hdBK_ID");
                        dtSelected.Rows.Remove(dtSelected.Select("CUS_BK_ID=" + hd.Value).FirstOrDefault());
                    }
                }

                if (dtSelected.Rows.Count == 0)
                {
                    ShowMessageBox("กรุณาเลือกรายการที่ต้องการสั่งซื้อ");
                    return;
                }

                //if (dtSelected.Rows.Count > 10)
                //{
                //    ShowMessageBox("สั่งซื้อได้ไม่เกิน 10 รายการต่อ 1 ใบสั่งซื้อ");
                //    return;
                //}

                double Price = 0, Amount = 0, Total = 0;
                foreach (DataRow dr in dtSelected.Rows)
                {
                    Amount = dr["CUS_BK_AMOUNT"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_AMOUNT"].ToString());
                    Price = dr["CUS_BK_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_PRICE"].ToString());
                    Total = Total + (Amount * Price);
                }

                if (Total < 100)
                {
                    ShowMessageBox("มูลค่าของใบสั่งซื้อไม่ต้ำกว่า 100 หยวน");
                    return;
                }

                Session.Add("ORDER", dtSelected);
                Response.Redirect("CustomerTransport.aspx?Type=" + EncrypData("ORDER"));
            }
        }        

        //protected void gvBasket_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    if (ViewState["SOURCE"] != null)
        //    {
        //        ViewState["OldShopName"] = null;
        //        ViewState["Count"] = null;

        //        DataTable dt = new DataTable();
        //        dt = (DataTable)ViewState["SOURCE"];
        //        gvBasket.PageIndex = e.NewPageIndex;
        //        gvBasket.DataSource = dt;
        //        gvBasket.DataBind();
                
        //        BindSession();
        //        GenShopname();
        //    }
        //}

        #region Event Gridview
        protected void imbEdit_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvA")).ActiveViewIndex = 1;
            ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvB")).ActiveViewIndex = 1;            
        }

        protected void imgbtn_Updateprod_amount_Click(object sender, ImageClickEventArgs e)
        {
            string Result = "";
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            int Amount = ((TextBox)gvBasket.Rows[rowIndex].FindControl("txtAmount")).Text == "" ? 0 : Convert.ToInt32(((TextBox)gvBasket.Rows[rowIndex].FindControl("txtAmount")).Text);
            int BK_ID = ((HiddenField)gvBasket.Rows[rowIndex].FindControl("hdBK_ID")).Value == "" ? 0 : Convert.ToInt32(((HiddenField)gvBasket.Rows[rowIndex].FindControl("hdBK_ID")).Value);

            ShoppingBiz Biz = new ShoppingBiz();
            Result = Biz.UpdateBasketAmount(BK_ID, Amount);
            if (Result == "")
            {
                BindData("", true);
                //ShowMessageBox("Update product amount success", this.Page);
                ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvA")).ActiveViewIndex = 0;
                ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvB")).ActiveViewIndex = 0;
            }
        }

        protected void imgbtn_Cancelprod_amount_Click(object sender, ImageClickEventArgs e)
        {
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            ((TextBox)gvBasket.Rows[rowIndex].FindControl("txtAmount")).Text = ((Label)gvBasket.Rows[rowIndex].FindControl("lbAmount")).Text;
            ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvA")).ActiveViewIndex = 0;
            ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvB")).ActiveViewIndex = 0;
        }

        protected void cbItemAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb, cbHead;
            cbHead = (CheckBox)sender;

            BindData("ALL", cbHead.Checked);
            CalTotalAmount();
        }

        protected void cbItem_CheckedChanged(object sender, EventArgs e)
        {
            CalTotalAmount();
        }

        protected void CalTotalAmount()
        {
            CheckBox cb;
            HiddenField hdd;
            double Total = 0, dPrice = 0, dAmount = 0;
            List<string> Chk = new List<string>();
            int cc = 0;
            
            //if(Session["CUS_BK_ID"] != null)
            //    Chk = (List<string>)Session["CUS_BK_ID"];
            //else
            //    Chk = new List<string>();            

            foreach (GridViewRow gvr in gvBasket.Rows)
            {
                cb = (CheckBox)gvr.Cells[0].FindControl("cbItem");
                hdd = (HiddenField)gvr.Cells[0].FindControl("hdBK_ID");

                if (cb != null && cb.Checked && hdd != null && hdd.Value != "" && !Chk.Contains(hdd.Value))
                {
                    Chk.Add(hdd.Value);
                }

                if (cb != null && !cb.Checked)
                    cc = 1;
         
                
            }

            if(cc == 1)
                ((CheckBox)gvBasket.HeaderRow.Cells[0].FindControl("cbItemAll")).Checked = false;
            else
                ((CheckBox)gvBasket.HeaderRow.Cells[0].FindControl("cbItemAll")).Checked = true;

            Session["CUS_BK_ID"] = Chk;

            if (ViewState["SOURCE"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["SOURCE"];
                foreach (DataRow dr in dt.Rows)
                {
                    if (Chk.Contains(dr["CUS_BK_ID"].ToString()))
                    {
                        dPrice = dr["CUS_BK_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_PRICE"].ToString());
                        dAmount = dr["CUS_BK_AMOUNT"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_AMOUNT"].ToString());
                        Total = Total + (dPrice * dAmount);
                    }
                }
            }

            lbTotal.Text = Total.ToString("###,##0.00") + " (¥)";
        }

        protected void imbDelete_Click(object sender, ImageClickEventArgs e)
        {
            string Result = "";
            int rowIndex = ((GridViewRow)((ImageButton)sender).Parent.Parent.Parent.Parent).RowIndex;
            int Amount = ((TextBox)gvBasket.Rows[rowIndex].FindControl("txtAmount")).Text == "" ? 0 : Convert.ToInt32(((TextBox)gvBasket.Rows[rowIndex].FindControl("txtAmount")).Text);
            int BK_ID = ((HiddenField)gvBasket.Rows[rowIndex].FindControl("hdBK_ID")).Value == "" ? 0 : Convert.ToInt32(((HiddenField)gvBasket.Rows[rowIndex].FindControl("hdBK_ID")).Value);

            ShoppingBiz Biz = new ShoppingBiz();
            Result = Biz.DeleteBasket(BK_ID);
            if (Result == "")
            {
                Session.Remove("CUS_BK_ID");
                CalTotalAmount();
                BindData("", true);
                //ShowMessageBox("Update product amount success", this.Page);
                if (gvBasket.Rows.Count > 0)
                {
                    ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvA")).ActiveViewIndex = 0;
                    ((MultiView)gvBasket.Rows[rowIndex].FindControl("mvB")).ActiveViewIndex = 0;
                }
            }
        }
        #endregion                       

        protected void imbOrder_Click(object sender, ImageClickEventArgs e)
        {
            Session.Remove("TRANS");
            Session.Remove("ORDER");
            CheckBox cb;
            HiddenField hd;
            List<string> Chk;
            DataTable dtSelected = new DataTable();
            if (ViewState["SOURCE"] != null)
            {
                dtSelected = ((DataTable)ViewState["SOURCE"]).Copy();
                DataRow[] drList = dtSelected.Select("SHOPHEADER <> ''");
                foreach (DataRow row in drList)
                {
                    dtSelected.Rows.Remove(row);
                }
                dtSelected.AcceptChanges();

                if (Session["CUS_BK_ID"] != null)
                {
                    Chk = (List<string>)Session["CUS_BK_ID"];
                    foreach (DataRow dr in dtSelected.Rows)
                    {
                        if(!Chk.Contains(dr["CUS_BK_ID"].ToString()))
                        {
                            dr.Delete();
                            //dtSelected.Rows.Remove(dtSelected.Select("CUS_BK_ID=" + dr["CUD_BK_ID"].ToString()).FirstOrDefault());
                        }
                    }
                    dtSelected.AcceptChanges();
                }
                else
                {
                    ShowMessageBox("กรุณาเลือกรายการที่ต้องการสั่งซื้อ");
                    return;
                }

                //if (dtSelected.Rows.Count > 10)
                //{
                //    ShowMessageBox("สั่งซื้อได้ไม่เกิน 10 รายการต่อ 1 ใบสั่งซื้อ");
                //    return;
                //}

                //double Price = 0, Amount = 0, Total = 0;
                //foreach (DataRow dr in dtSelected.Rows)
                //{
                //    Amount = dr["CUS_BK_AMOUNT"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_AMOUNT"].ToString());
                //    Price = dr["CUS_BK_PRICE"].ToString() == "" ? 0 : Convert.ToDouble(dr["CUS_BK_PRICE"].ToString());
                //    Total = Total + (Amount * Price);
                //}

                //if (Total < 100)
                //{
                //    ShowMessageBox("มูลค่าของใบสั่งซื้อไม่ต้ำกว่า 100 หยวน");
                //    return;
                //}

                Session.Add("ORDER", dtSelected);
                Response.Redirect("CustomerTransport.aspx?Type=" + EncrypData("ORDER"));
            }
        }

        protected void gvBasket_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridViewRow gvr = (GridViewRow)((GridView)sender).Controls[0].Controls[e.Row.RowIndex + 1];
                if(gvr != null)
                {
                    Label lbShopName = (Label)gvr.FindControl("lbShopName");
                    CheckBox cbItem = (CheckBox)gvr.FindControl("cbItem");                    

                    if (lbShopName != null && lbShopName.Text != "")
                    {
                        if (cbItem != null)
                            cbItem.Visible = false;

                        for (int i = 0; i < gvr.Cells.Count; i++)
			            {
                            if (i > 0)
                            {
                                gvr.Cells[i].Visible = false;
                            }
			            }
                        gvr.Cells[0].ColumnSpan = gvr.Cells.Count;
                        gvr.CssClass = "gv-shopname";                     
                    }

                    string ProdItemDetail = "";
                    string ItemName = DataBinder.Eval(e.Row.DataItem, "CUS_BK_ITEMNAME").ToString();
                    string ItemUrl = DataBinder.Eval(e.Row.DataItem, "CUS_BK_URL").ToString().Trim().Replace("amp;", "");
                    ProdItemDetail = "<a href=\"" + ItemUrl + "\" target=\"_blank\">" + ItemName + "</a><br>";
                    ((Label)e.Row.FindControl("lbItemName")).Text = ProdItemDetail;
                }
            }            
        }

        protected DataTable GenShopName(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                dt.Columns.Add("SHOPHEADER");
                ViewState["OldShopName"] = null;
                ViewState["Count"] = null;
                int Count = 0;
                string ShopName = "", ShowShop = "";
                DataRow row;
                for (int i = 0; i < dt.Rows.Count; i++)
			    {
			        ShopName = dt.Rows[i]["CUS_BK_SHOPNAME"].ToString(); ;
                    if (ViewState["OldShopName"] == null || ViewState["OldShopName"].ToString() != ShopName)
                    {
                        Count = ViewState["Count"] == null ? 1 : Convert.ToInt32(ViewState["Count"]);
                        row = dt.NewRow();
                        
                        ShowShop = "";
                        ShowShop += "Shop name : " + ShopName + "&nbsp;&nbsp;";

                        row["SHOPHEADER"] = ShowShop;
                        dt.Rows.InsertAt(row, i);
                        //gvBasket.Controls[0].Controls.AddAt(gvr.RowIndex + Count, row);

                        ViewState["OldShopName"] = ShopName;
                        ViewState["Count"] = ++Count;
                    }
			    }
            }
            return dt;
        }

        protected void GenShopname()
        {
            ViewState["OldShopName"] = null;
            ViewState["Count"] = null;

            int Count = 0;
            string ShopName = "";// DataBinder.Eval(e.Row.DataItem, "CUS_BK_SHOPNAME").ToString();

            HiddenField hddShopName, hddItemUrl;
            Label lbItemName, lbShopName, lbRemark;
            GridViewRow row;
            TableCell cell;
            string ProdItemDetail, ItemName, ItemUrl, ShowShop;

            foreach (GridViewRow gvr in gvBasket.Rows)
	        {
                hddItemUrl = ((HiddenField)gvr.FindControl("hddItemUrl"));
                hddShopName = ((HiddenField)gvr.FindControl("hddShopName"));
                lbItemName = ((Label)gvr.FindControl("lbItemName"));
                lbShopName = ((Label)gvr.FindControl("lbShopName"));

                ShopName = hddShopName.Value;
                if (ViewState["OldShopName"] == null || ViewState["OldShopName"].ToString() != ShopName)
                {
                    Count = ViewState["Count"] == null ? 1 : Convert.ToInt32(ViewState["Count"]);
                    
                    row = new GridViewRow(gvr.RowIndex + Count, -1, DataControlRowType.DataRow, DataControlRowState.Insert);
                    cell = new TableCell();
                    cell.ColumnSpan = gvBasket.Columns.Count;
                    cell.CssClass = "gv-shopname";
                    ShowShop = "";
                    ShowShop += "Shop name : " + hddShopName.Value + "&nbsp;&nbsp;";
       
                    lbShopName.Text = ShowShop;
                    cell.Controls.Add(lbShopName);

                    row.Cells.Add(cell);
                    row.CssClass = "gv-shopname";
                    gvBasket.Controls[0].Controls.AddAt(gvr.RowIndex + Count, row);

                    ViewState["OldShopName"] = ShopName;
                    ViewState["Count"] = ++Count;
                }

                ProdItemDetail = "";
                ItemName = lbItemName.Text;
                ItemUrl = hddItemUrl.Value.Trim().Replace("amp;", "");
                ProdItemDetail = "<a href=\"" + ItemUrl + "\" target=\"_blank\">" + ItemName + "</a><br>";
                lbItemName.Text = ProdItemDetail;
                
	        }
            
        }

        protected string SumTotal(string Price, string Amount)
        {
            string Result = "";
            if (Price != "" && Amount != "")
            {
                double P = 0, A = 0, Res = 0;
                P = Convert.ToDouble(Price);
                A = Convert.ToDouble(Amount);
                Res = P * A;
                Result = Res.ToString("###,##0.00");
            }

            return Result;
        }
    }
}