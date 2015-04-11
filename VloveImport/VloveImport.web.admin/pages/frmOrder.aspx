<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmOrder.aspx.cs" Inherits="VloveImport.web.admin.pages.frmOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../UserControls/ucEmail.ascx" TagName="ucEmail" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Order Detail
                </legend>
                <table>
                    <tr>
                        <td>Order Code :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_ORDER_ID" runat="server" Text=""></asp:Label>
                        </td>
                        <td>Order Date :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_ORDER_DATE" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Receive Amount :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Amount_Receive" runat="server" Text=""></asp:Label>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Actually Amount :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Amount_Actually_Pay" runat="server" Text=""></asp:Label>
                        </td>
                        <td>Recall Amount :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Amount_Recall_Pay" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Product Price :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Product_Price" runat="server" Text=""></asp:Label>
                        </td>
                        <td>Transport Price</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Transport_Price" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Transport From China :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_TRANSPORT_1" runat="server" Text=""></asp:Label>
                        </td>
                        <td>Transport From Thai :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_TRANSPORT_2" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Transport Address :</td>
                        <td colspan="3">
                            <asp:Label ID="lbl_ViewDetail_ADDRESS" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Employee name :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_EMP_NAME" runat="server" Text=""></asp:Label>
                        </td>
                        <td>Employee Update Date :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_EMP_UPDATE_DATE" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Customer Code</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_CusCode" runat="server" Text=""></asp:Label>
                        </td>
                        <td>Customer Name :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_CusName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Customer Email :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Email" runat="server" Text=""></asp:Label>
                        </td>
                        <td>Customer Telephone :</td>
                        <td>
                            <asp:Label ID="lbl_ViewDetail_Telphone" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Send Email :</td>
                        <td>
                            <asp:ImageButton ID="imgbtn_SendEmail" runat="server" ImageUrl = "~/img/icon/sendemail.png" Width ="45px" Height ="35px" OnClick="imgbtn_SendEmail_Click" />
                        </td>
                        <td>Viwe Full Customer Detail :</td>
                        <td>
                            <asp:ImageButton ID="imgbtn_ViewCustomerDetail" runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>Update Status Order And Transport
                </legend>
                <table>
                    <tr>
                        <td width="15%" class="auto-style1">Order Status :</td>
                        <td width="85%" class="auto-style1">
                            <asp:DropDownList Width="300px" ID="ddl_ViewDetail_ORDER_STATUS" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ViewDetail_ORDER_STATUS_SelectedIndexChanged">
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
                        <td></td>
                        <td>
                            <asp:Button ID="btn_detail_update" runat="server" Text="Update Status" CssClass="btnSave" OnClick="btn_detail_update_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset>
                <legend>Shop Detail
                </legend>
                <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gv_detail_RowDataBound"
                    DataKeyNames="ORDER_SHOP_ID,SHOP_ORDER_ID,SHOPNAME,TRACKING_NO,WEIGHT,SIZE,WEIGHT_PRICE,SIZE_PRICE,TRANSPORT_CHINA_PRICE,TRANSPORT_THAI_PRICE,OD_ID,OD_AMOUNT,OD_AMOUNT_ACTIVE,OD_PRICE,OD_SIZE,OD_COLOR,OD_REMARK,OD_URL,OD_PICURL,OD_STATUS,ROW_INDEX_SHOP,TOTAL_PROD_PRICE,TOTAL_PROD_PRICE_ACTIVE,ROW_INDEX,ROW_RANK_PROD">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ROW_INDEX") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblRowIndex" runat="server" Text='<%# Bind("ROW_INDEX") %>'></asp:Label>&nbsp;&nbsp;
                                <asp:ImageButton ID="imgbtn_popup_shopdetail" runat="server" ImageUrl="~/img/icon/View.png" Width="20px" Height="20px" OnClick="imgbtn_popup_shopdetail_Click" />
                            </ItemTemplate>
                            <HeaderStyle CssClass="width5" />
                            <ItemStyle CssClass="ItemStyle-center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="OD_ITEMNAME" HeaderText="Product detail">
                            <HeaderStyle CssClass="width20" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OD_REMARK" HeaderText="Remark">
                            <HeaderStyle CssClass="width20" />
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
                                        <asp:ImageButton ID="imgbtn_Editprod_amount" runat="server" ImageUrl="~/img/icon/b_edit.png" Width="15px" Height="15px" OnClick="imgbtn_Editprod_amount_Click" />
                                    </asp:View>
                                    <asp:View ID="View6" runat="server">
                                        <asp:ImageButton ID="imgbtn_Updateprod_amount" runat="server" ImageUrl="~/img/icon/check-icon.png" Width="15px" Height="15px" OnClick="imgbtn_Updateprod_amount_Click" />
                                        &nbsp;&nbsp;
                                        <asp:ImageButton ID="imgbtn_Cancelprod_amount" runat="server" ImageUrl="~/img/icon/Close-2-icon.png" Width="15px" Height="15px" OnClick="imgbtn_Cancelprod_amount_Click" />
                                    </asp:View>
                                </asp:MultiView>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </fieldset>

            <table class="width100">
                <tr>
                    <td class="ItemStyle-center">
                        <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btnCancel" OnClick="btnback_Click"></asp:Button>
                    </td>
                </tr>
            </table>


            <asp:ModalPopupExtender ID="Modal_ShopDetail" runat="server" BackgroundCssClass="modalBackground"
                PopupControlID="Panel5" TargetControlID="lbl_modal_ShopDetail">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel5" Height="320" Width="800px" runat="server">
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
                            <asp:Panel Width="96%" Height="220px" ID="Panel6" runat="server" BackColor="#FFFFFF">
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
                                             <asp:TextBox ID="txt_sd_size" runat="server"></asp:TextBox>
                                         </td>
                                         <td>Weight :</td>
                                         <td>
                                             <asp:TextBox ID="txt_sd_weight" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                     <tr>
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
                                     </tr>
                                     <tr>
                                         <td>
                                             Transport china price :
                                         </td>
                                         <td>
                                             <asp:TextBox ID="txt_sd_tran_china_price" runat="server"></asp:TextBox>
                                         </td>
                                         <td>Transport thai price :</td>
                                         <td>
                                             <asp:TextBox ID="txt_sd_tran_thai_price" runat="server"></asp:TextBox>
                                         </td>
                                     </tr>
                                    <tr>
                                        <td colspan ="4">&nbsp;</td>
                                    </tr>
                                     <tr>
                                         <td colspan ="4" class ="ItemStyle-center">
                                             <asp:Button ID="btnUpdateShopDetail" runat="server" Text="Update" CssClass="btnSave"></asp:Button>
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
            <asp:Panel ID="Panel1" Height="520" Width="800px" runat="server">
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
