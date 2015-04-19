﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site2.Master" AutoEventWireup="true" CodeBehind="frmOrder_TEMP.aspx.cs" Inherits="VloveImport.web.admin.pages.frmOrder_TEMP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../UserControls/ucEmail.ascx" TagName="ucEmail" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

    <h3>ORDER DETAIL</h3>
    <hr style="width: 100%; text-align: left; background-color: #8db0ef; height: 5px; color: #8db0ef; border: 0;" />
<div style ="min-height:550px;">
<asp:TabContainer ID="TabBooking" runat="server" Width="100%" ActiveTabIndex="1">
    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Order Detail">
        <ContentTemplate>
            <fieldset>
                <table>
                    <tr>
                        <td class ="width15">Order code : </td>
                        <td class ="width30">
                            <asp:Label ID="lbl_tb1_order_code" runat="server"></asp:Label>
                        </td>
                        <td class ="width20">Transport Method China To Thai : </td>
                        <td class ="width35">
                            <asp:Label ID="lbl_tb1_TranSport_CH_TO_TH" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Order date :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Order_Date" runat="server"></asp:Label>
                        </td>
                        <td>
                            Transport Method To Customer :
                        </td>
                        <td>
                            <asp:Label ID="lbl_tb1_TranSport_TO_Customer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Order Status :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Order_status" runat="server"></asp:Label>
                        </td>
                        <td>Transport Status : </td>
                        <td>
                            <asp:Label ID="lbl_tb1_TranSport_Status" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Exchange Rate :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Exchange_Rate" runat="server"></asp:Label>
                        </td>
                        <td>Transport Percent :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_TranSport_Percent" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Employee Name :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Emp_Name" runat="server"></asp:Label>
                        </td>
                        <td>Employee Update Date :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Emp_Update_Date" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Emploayee Remark :</td>
                        <td colspan ="3">
                            <asp:Label ID="lbl_tb1_Emp_Remark" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <table>
                    <tr>
                        <td class ="width15">Customer Code :</td>
                        <td class ="width30">
                            <asp:Label ID="lbl_tb1_Customer_Code" runat="server"></asp:Label>
                        </td>
                        <td class ="width20">Customer Name :</td>
                        <td class ="width35">
                            <asp:Label ID="lbl_tb1_Customer_Name" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Customer Email :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Customer_Email" runat="server"></asp:Label>&nbsp;&nbsp;
                            <asp:ImageButton ID="imgbtn_SendEmail" runat="server" ImageUrl="~/img/icon/sendemail.png" ToolTip = "Send Email To Customer" Width="25px" Height="25px" OnClick="imgbtn_SendEmail_Click"/>
                        </td>
                        <td>Customer Telephone :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Customer_Telephone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Customer Balance :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Customer_Balance" runat="server"></asp:Label>
                        </td>
                        <td>Customer Point :</td>
                        <td>
                            <asp:Label ID="lbl_tb1_Customer_Point" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td> Customer Address :</td>
                        <td colspan ="3">
                            <asp:Label ID="lbl_tb1_Customer_Address" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Customer Remark</td>
                        <td colspan ="3">
                            <asp:Label ID="lbl_tb1_Customer_Remark" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>
                    Shop And Product List
                </legend>
                <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="ORDER_SHOP_ID,SHOP_ORDER_ID,SHOPNAME,TRACKING_NO,WEIGHT,SIZE,WEIGHT_PRICE,SIZE_PRICE,TRANSPORT_CHINA_PRICE,TRANSPORT_THAI_PRICE,OD_ID,OD_AMOUNT,OD_AMOUNT_ACTIVE,OD_PRICE,OD_SIZE,OD_COLOR,OD_REMARK,OD_URL,OD_PICURL,OD_STATUS,ROW_INDEX_SHOP,TOTAL_PROD_PRICE,TOTAL_PROD_PRICE_ACTIVE,ROW_INDEX,ROW_RANK_PROD,PRODUCT_TYPE" OnRowDataBound="gv_detail_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ROW_INDEX") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRowIndex" runat="server" Text='<%# Bind("ROW_INDEX") %>'></asp:Label>&nbsp;&nbsp;
                                <asp:ImageButton ID="imgbtn_popup_shopdetail" runat="server" ImageUrl="~/img/icon/View.png" Width="20px" Height="20px" OnClick="imgbtn_popup_shopdetail_Click"/>
                            </ItemTemplate>
                            <HeaderStyle CssClass="width5" />
                            <ItemStyle CssClass="ItemStyle-center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="OD_ITEMNAME" HeaderText="Product detail">
                            <HeaderStyle CssClass="width15" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OD_REMARK" HeaderText="Remark">
                            <HeaderStyle CssClass="width15" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Price">
                            <HeaderStyle CssClass="width10" />
                            <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OD_AMOUNT" HeaderText="Order amount">
                            <HeaderStyle CssClass="width10" />
                            <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTAL_PROD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Total price">
                            <HeaderStyle CssClass="width10" />
                            <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Price Active">
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:MultiView ID="MultiView_Price_Active" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View_Price_Active1" runat="server">
                                        <asp:Label ID="lbl_OD_Price_ACTIVE" runat="server" Text='<%# Bind("OD_PRICE_ACTIVE") %>'></asp:Label>
                                    </asp:View>
                                    <asp:View ID="View_Price_Active2" runat="server">
                                        <asp:TextBox ID="txt_OD_Price_ACTIVE" runat="server" AutoCompleteType="Disabled" Text='<%# Bind("OD_PRICE_ACTIVE") %>' Width="90%"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_OD_Price_ACTIVE" ID="txt_OD_Price_ACTIVE_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                                        </asp:FilteredTextBoxExtender>
                                    </asp:View>
                                </asp:MultiView>
                            </ItemTemplate>
                            <HeaderStyle CssClass="width10" />
                            <ItemStyle CssClass="ItemStyle-right" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Order active<br>amount">
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:MultiView ID="MultiView2" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View3" runat="server">
                                        <asp:Label ID="lbl_OD_AMOUNT_ACTIVE" runat="server" Text='<%# Bind("OD_AMOUNT_ACTIVE") %>'></asp:Label>
                                    </asp:View>
                                    <asp:View ID="View4" runat="server">
                                        <asp:TextBox ID="txt_OD_AMOUNT_ACTIVE" runat="server" AutoCompleteType="Disabled" Text='<%# Bind("OD_AMOUNT_ACTIVE") %>' Width="90%"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_OD_AMOUNT_ACTIVE" ID="txt_OD_AMOUNT_ACTIVE_FilteredTextBoxExtender1" ValidChars="1234567890,">
                                        </asp:FilteredTextBoxExtender>
                                    </asp:View>
                                </asp:MultiView>
                            </ItemTemplate>
                            <HeaderStyle CssClass="width10" />
                            <ItemStyle CssClass="ItemStyle-right" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="TOTAL_PROD_PRICE_ACTIVE" DataFormatString="{0:#,##0.00}" HtmlEncode="false" HeaderText="Total active<br>price">
                            <HeaderStyle CssClass="width10" />
                            <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Tools">
                            <HeaderStyle CssClass="width5" />
                            <ItemStyle CssClass="ItemStyle-center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:MultiView ID="MultiView3" runat="server" ActiveViewIndex="0">
                                    <asp:View ID="View5" runat="server">
                                        <asp:ImageButton ID="imgbtn_Editprod_amount" runat="server" ImageUrl="~/img/icon/b_edit.png" Width="15px" Height="15px" OnClick="imgbtn_Editprod_amount_Click"/>
                                    </asp:View>
                                    <asp:View ID="View6" runat="server">
                                        <asp:ImageButton ID="imgbtn_Updateprod_amount" runat="server" ImageUrl="~/img/icon/check-icon.png" Width="15px" Height="15px" OnClick="imgbtn_Updateprod_amount_Click"/>
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="imgbtn_Cancelprod_amount" runat="server" ImageUrl="~/img/icon/Close-2-icon.png" Width="15px" Height="15px" OnClick="imgbtn_Cancelprod_amount_Click"/>
                                    </asp:View>
                                </asp:MultiView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </fieldset>
        </ContentTemplate>
    </asp:TabPanel>
    <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Payment Detail">
        <ContentTemplate>
            <fieldset>
                <table>
                    <tr>
                        <td colspan = "4">
                            <asp:GridView ID="gv_detail_transaction" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField HeaderText="No." DataField="ROW_INDEX" >
                                    <HeaderStyle CssClass="width5" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transaction Type" DataField="TRAN_TYPE_TEXT" >
                                    <HeaderStyle CssClass="width15" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transaction Date" DataField="TRAN_DATE_TEXT" >
                                    <HeaderStyle CssClass="width15" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transaction  Amount" DataField="TRAN_AMOUNT" >
                                    <HeaderStyle CssClass="width15" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transaction Detail" DataField="TRAN_DETAIL" >
                                    <HeaderStyle CssClass="width25" />
                                    </asp:BoundField>
                                    <asp:BoundField HtmlEncode ="False" HeaderText="Transaction<br>Employee Detail" DataField="EMP_REMARK" >
                                    <HeaderStyle CssClass="width25" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td class ="width15">Total Income : </td>
                        <td class ="width30">
                            <asp:Label ID="lbl_tb2_Total_Income" runat="server"></asp:Label>
                        </td>
                        <td class ="width20">Total Refund : </td>
                        <td class ="width35">
                            <asp:Label ID="lbl_tb2_Total_Refund" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Additional Amount : </td>
                        <td>
                            <asp:Label ID="lbl_tb2_Additional_Amount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="4">
                            <hr style="width: 100%; text-align: left; background-color: #b6b2b2; height: 2px; color: #8db0ef; border: 0;" />
                        </td>
                    </tr>
                    <tr>
                        <td>Total Product Price :</td>
                        <td></td>
                        <td>Total Product Active Price : </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Total Transport Price :</td>
                        <td></td>
                        <td>Total Transport Active Price :</td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Actually Amount :</td>
                        <td></td>
                    </tr>
                </table>
            </fieldset>

            <fieldset>
                <table>
                    <tr>
                        <td width="15%" class="auto-style1">Order Status :</td>
                        <td width="85%" class="auto-style1">
                            <asp:DropDownList Width="300px" ID="ddl_ViewDetail_ORDER_STATUS" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ViewDetail_ORDER_STATUS_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Transport Status :</td>
                        <td>
                            <asp:DropDownList ID="ddl_ViewDetail_TRANSPORT_STATUS" runat="server" Width="300px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Remark : </td>
                        <td>
                            <asp:TextBox ID="txt_Update_STS_EMP_Remark" TextMode ="MultiLine" Width ="300px" Height ="50px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trTranCusPrice" runat="server" visible="False">
                        <td runat="server">Transport Customer Price :</td>
                        <td runat="server">
                            <asp:TextBox ID="txt_Transport_Cus_Price" runat="server" Width="300px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_Transport_Cus_Price" ID="txt_Transport_Cus_Price_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                            </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btn_detail_update" runat="server" Text="Update Status" CssClass="btnSave" OnClick="btn_detail_update_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>

        </ContentTemplate>
    </asp:TabPanel>
    <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Transport Detail">
        <ContentTemplate>
            <fieldset>
                <table>
                    <tr>
                        <td colspan ="4">
                            <asp:GridView ID="gv_detail_shopname" runat="server" AutoGenerateColumns="False" Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="No.">
                                    <HeaderStyle CssClass="width5" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Shop name">
                                    <HeaderStyle CssClass="width25" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Shop order id">
                                    <HeaderStyle CssClass="width10" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Size&lt;br&gt;(CM)" HtmlEncode="False">
                                    <HeaderStyle CssClass="width10" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Weight&lt;br&gt;(KG)" HtmlEncode="False">
                                    <HeaderStyle CssClass="width10" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transport China&lt;br&gt;Price" HtmlEncode="False">
                                    <HeaderStyle CssClass="width10" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Product Type">
                                    <HeaderStyle CssClass="width15" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Transport China To Thai (THB)">
                                    <HeaderStyle CssClass="width10" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Tools">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtn_tab3_popup_shopdetail" runat="server" ImageUrl="~/img/icon/View.png" Width="20px" Height="20px" OnClick="imgbtn_tab3_popup_shopdetail_Click"/>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="width5" />
                                        <ItemStyle CssClass="ItemStyle-center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class ="width15">Transport Method China To Thai :</td>
                        <td class ="width30">
                            <asp:Label ID="lbl_tb3_Transport_Method_CH_TO_TH" runat="server"></asp:Label>
                        </td>
                        <td class ="width20">Transport Method To Customer :</td>
                        <td class ="width35">
                            <asp:Label ID="lbl_tb3_Transport_Method_To_Customer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Transport To Customer Detail : </td>
                        <td>
                            <asp:Label ID="lbl_tb3_Transport_To_Customer_Detail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td>Transport To Customer Date :</td>
                        <td>
                            <asp:Label ID="lbl_tb3_Transport_To_Customer_Date" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <table>
                    <tr>
                        <td class ="width20">Total Transport China Price :</td>
                        <td class ="width80">
                            <asp:Label ID="lbl_tb3_Total_Transport_China_Price" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Total Transport China To Thai :</td>
                        <td>
                            <asp:Label ID="lbl_tb3_Total_Transport_CH_TO_TH" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Total Transport To Customer :</td>
                        <td>
                            <asp:Label ID="lbl_tb3_Total_Transport_To_Customer" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Total Transport Price :</td>
                        <td>
                            <asp:Label ID="lbl_tb3_Total_Transport" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:TabPanel>
</asp:TabContainer>
</div>
<br />
<table class="width100">
    <tr>
        <td class="ItemStyle-center">
            <asp:Button ID="btnback" runat="server" Text="Back To Order List" CssClass="btnCancel" OnClick="btnback_Click"></asp:Button>
        </td>
    </tr>
</table>


<asp:ModalPopupExtender ID="Modal_ShopDetail" runat="server" BackgroundCssClass="modalBackground"
    PopupControlID="Panel5" TargetControlID="lbl_modal_ShopDetail">
</asp:ModalPopupExtender>
<asp:Panel ID="Panel5" Height="350px" Width="800px" runat="server" Style="display: none;">
    <%--Style="display: none;"--%>
    <table width="800px" style="border-collapse: separate; border-spacing: 0px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
            <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                <div style="margin-left: -40px; margin-top: 10px;">
                    <asp:Label ID="lbl_modal_ShopDetail" runat="server" Text="Shop Detail"></asp:Label>
                </div>
            </td>
            <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                </div>
            </td>
        </tr>
        <tr style="background-color: #CFCDCD;">
            <td style="text-align: center; padding: 0px 0px;" colspan="3">
                <center>
                <asp:Panel Width="96%" Height="250px" ID="Panel6" runat="server" BackColor="#FFFFFF">
                        <br />
                        <table>
                            <tr>
                                <td>
                                    Shop name :
                                </td>
                                <td colspan ="3">
                                    <asp:Label ID="lbl_sd_shopname" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tracking no :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_sd_trackingno" runat="server"></asp:TextBox>
                                </td>
                                <td>Shop order id :</td>
                                <td>
                                    <asp:TextBox ID="txt_sd_shoporder_id" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Size :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_sd_size" runat="server" onblur ="Fun_CalShopProduct_Detail();"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_sd_size" ID="txt_sd_size_FilteredTextBoxExtender1" ValidChars="1234567890*">
                                </asp:FilteredTextBoxExtender>
                                    <br />
                                    <span style ="color:red;">
                                        <b>
                                            Ex.15*15*15
                                        </b>
                                    </span>
                                </td>
                                <td>Weight :</td>
                                <td>
                                    <asp:TextBox ID="txt_sd_weight" runat="server" onblur ="Fun_CalShopProduct_Detail();"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_sd_weight" ID="txt_sd_weight_FilteredTextBoxExtender1" ValidChars="1234567890.">
                                </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
<%--                                     <tr>
                                <td>Size price :</td>
                                <td>
                                    <asp:TextBox ID="txt_sd_size_price" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    Weight price :
                                </td>
                                <td>
                                    <asp:TextBox ID="txt_sd_weight_rpice" runat="server"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    Transport china price :
                                </td>
                                <td>
                                <asp:TextBox ID="txt_sd_tran_china_price" runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_sd_tran_china_price" ID="txt_sd_tran_china_price_FilteredTextBoxExtender" ValidChars="1234567890.,">
                                </asp:FilteredTextBoxExtender>
                                </td>
                                <td></td>
                                <td>
                                             
                                </td>
                            </tr>
                            <tr>
                                <td>Transport Method :</td>
                                <td>
                                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex ="0">
                                        <asp:View ID="View1" runat="server">
                                            <asp:DropDownList ID="ddl_TRANS_METHOD_AirPlane" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_TRANS_METHOD_AirPlane_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">Please Select</asp:ListItem>
                                                <asp:ListItem Value="1">Product General</asp:ListItem>
                                                <asp:ListItem Value="2">Product Soft</asp:ListItem>
                                                <asp:ListItem Value="3">Product Brand</asp:ListItem>
                                                <asp:ListItem Value="4">Other</asp:ListItem>
                                            </asp:DropDownList>
                                        </asp:View>
                                        <asp:View ID="View2" runat="server">
                                            <asp:DropDownList ID="ddl_TRANS_METHOD_OTHER" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_TRANS_METHOD_OTHER_SelectedIndexChanged">
                                                <asp:ListItem Value="-1">Please Select</asp:ListItem>
                                                <asp:ListItem Value="1">Product Dress Grneral</asp:ListItem>
                                                <asp:ListItem Value="2">Product Grneral</asp:ListItem>
                                                <asp:ListItem Value="3">Product Cal Cubi</asp:ListItem>
                                                <asp:ListItem Value="4">Product Brand</asp:ListItem>
                                            </asp:DropDownList>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                                <td>Transport thai price :</td>
                                <td>
                                    <asp:TextBox ID="txt_sd_tran_thai_price" runat="server"></asp:TextBox>
                                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_sd_tran_thai_price" ID="txt_sd_tran_thai_price_FilteredTextBoxExtender1" ValidChars="1234567890.,">
                                </asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                        <tr>
                            <td colspan ="4">&nbsp;</td>
                        </tr>
                            <tr>
                                <td colspan ="4" class ="ItemStyle-center">
                                    <asp:Button ID="btnUpdateShopDetail" runat="server" Text="Update" CssClass="btnSave" OnClick="btnUpdateShopDetail_Click"></asp:Button>
                                </td>
                            </tr>
                        </table>                  
                </asp:Panel>
            </center>
            </td>
        </tr>
        <tr style="background-color: #CFCDCD;">
            <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
        </tr>
    </table>
</asp:Panel>

<asp:ModalPopupExtender ID="MadoalPop_Email" runat="server" BackgroundCssClass="modalBackground"
    PopupControlID="Panel1" TargetControlID="lbl_modal_email">
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" Height="520" Width="800px" runat="server" Style="display: none;">
    <%--Style="display: none;"--%>
    <table width="800px" style="border-collapse: separate; border-spacing: 0px" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_LEFT"></td>
            <td align="left" class="trLogin_CENTER" style="padding: 0px 0px;">
                <div style="margin-left: -40px; margin-top: 10px;">
                    <asp:Label ID="lbl_modal_email" runat="server" Text="Send Email"></asp:Label>
                </div>
            </td>
            <td align="right" width="52px" height="43px" style="padding: 0px 0px;" class="trLogin_RIGHT">
                <div style="text-align: right; margin-right: 10px; margin-top: 10px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/icon/Close.png" Width="20px" Height="20px" />
                </div>
            </td>
        </tr>
        <tr style="background-color: #CFCDCD;">
            <td style="text-align: center; padding: 0px 0px;" colspan="3">
                <center>
                <asp:Panel Width="96%" Height="420px" ID="Panel2" runat="server" BackColor="#FFFFFF">
                        <br />
                        <uc1:ucEmail ID="ucEmail1" runat="server" />                 
                </asp:Panel>
            </center>
            </td>
        </tr>
        <tr style="background-color: #CFCDCD;">
            <td height="15px" style="padding: 0px 0px;" align="center" colspan="3"></td>
        </tr>
    </table>
</asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>

