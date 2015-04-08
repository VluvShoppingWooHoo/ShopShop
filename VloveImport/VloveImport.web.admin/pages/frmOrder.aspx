<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmOrder.aspx.cs" Inherits="VloveImport.web.admin.pages.frmOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                        <td colspan = "4">&nbsp;</td>
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
                </table>
            </fieldset>
            <fieldset>
                <legend>
                    Update Status Order And Transport
                </legend>
                <table>
                    <tr>
                        <td width="15%" class="auto-style1">Order Status :</td>
                        <td width="85%" class="auto-style1">
                            <asp:DropDownList Width ="300px" ID="ddl_ViewDetail_ORDER_STATUS" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_ViewDetail_ORDER_STATUS_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Transport Status :</td>
                        <td>
                            <asp:DropDownList ID="ddl_ViewDetail_TRANSPORT_STATUS" runat="server" Width ="300px">
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
                <legend>
                    Shop Detail
                </legend>
                <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" Width="100%" OnRowDataBound="gv_detail_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                        <asp:BoundField DataField="OD_ITEMNAME" HeaderText="Product detail" />
                        <asp:BoundField DataField="OD_REMARK" HeaderText="Remark" />
                        <asp:BoundField DataField="OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Price">
                        <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OD_AMOUNT" HeaderText="Order amount">
                        <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTAL_PROD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Total price">
                        <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="OD_AMOUNT_ACTIVE" HeaderText="Order active amount">
                        <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTAL_PROD_PRICE_ACTIVE" DataFormatString="{0:#,##0.00}" HeaderText="Total active price">
                        <ItemStyle CssClass="ItemStyle-right" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </fieldset>
            <fieldset>
                <legend>
                    Shop Detail
                </legend>
                <table>
                    <tr>
                        <td>
                            <asp:GridView ID="gv_detail_shop" runat="server" AutoGenerateColumns="False" Width="100%"
                                DataKeyNames="ORDER_SHOP_ID,SHOPNAME,ORDER_ID,TRACKING_NO,WEIGHT,SIZE,WEIGHT_PRICE,SIZE_PRICE,TRANSPORT_CHINA_PRICE,TRANSPORT_THAI_PRICE,TRANSPORT_CUSTOMER_PRICE">
                                <Columns>
                                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                                    <asp:BoundField HeaderText="Shop name" DataField="SHOPNAME" />
                                    <asp:BoundField HeaderText="Tracking no" DataField="TRACKING_NO" />
                                    <asp:TemplateField HeaderText="Weight">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text = '<%# Bind("WEIGHT") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Size">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text = '<%# Bind("SIZE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Weight price">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text = '<%# Bind("WEIGHT_PRICE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Size price">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text = '<%# Bind("SIZE_PRICE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transport price china">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text = '<%# Bind("TRANSPORT_CHINA_PRICE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Transport price thai" DataField ="TRANSPORT_THAI_PRICE" DataFormatString="{0:#,##0.00}">
                                    <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Transport price customer">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text = '<%# Bind("TRANSPORT_CUSTOMER_PRICE") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle CssClass="ItemStyle-right" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tools">

                                        <ItemStyle CssClass="ItemStyle-center" />

                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <fieldset style="width: 95%;">
                <legend>
                    Product Detail
                </legend>
                <table>
                    <tr>
                        <td>
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="View1" runat="server">
                                    <asp:Button ID="btnEditProd_num" runat="server" Text="Edit product amount" CssClass=" btnSearch" OnClick="btnEditProd_num_Click"></asp:Button>
                                    <asp:GridView ID="gv_detail_prod_view" runat="server" AutoGenerateColumns="False" Width="100%">
                                        <Columns>
                                            <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                                            <asp:BoundField DataField="OD_ITEMNAME" HeaderText="Product detail" />
                                            <asp:BoundField DataField="OD_REMARK" HeaderText="Remark" />
                                            <asp:BoundField DataField="OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Price">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OD_AMOUNT" HeaderText="Order amount">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TOTAL_PROD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Total price">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OD_AMOUNT_ACTIVE" HeaderText="Order active amount">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TOTAL_PROD_PRICE_ACTIVE" DataFormatString="{0:#,##0.00}" HeaderText="Total active price">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <asp:Button ID="btnEditProd_num_save" runat="server" Text="Update " CssClass=" btnSave" OnClick="btnEditProd_num_save_Click"></asp:Button>&nbsp;&nbsp;
                                                                <asp:Button ID="btnEditProd_num_cancel" runat="server" Text="Cancel" CssClass="btnCancel" OnClick="btnEditProd_num_cancel_Click"></asp:Button>
                                    <asp:GridView ID="gv_detail_prod_Edit" runat="server" AutoGenerateColumns="False" Width="100%"
                                        DataKeyNames="ORDER_ID,OD_ID">
                                        <Columns>
                                            <asp:BoundField DataField="ROW_INDEX" HeaderText="No." />
                                            <asp:BoundField DataField="OD_ITEMNAME" HeaderText="Product detail" />
                                            <asp:BoundField DataField="OD_REMARK" HeaderText="Remark" />
                                            <asp:BoundField DataField="OD_PRICE" DataFormatString="{0:#,##0.00}" HeaderText="Price">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OD_AMOUNT" HeaderText="Order amount">
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Order active amount">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OD_AMOUNT_ACTIVE") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gv_detail_prod_Edit_txt" runat="server" AutoCompleteType="Disabled" Text='<%# Bind("OD_AMOUNT_ACTIVE") %>' MaxLength="8"></asp:TextBox>
                                                    <asp:FilteredTextBoxExtender ID="gv_detail_prod_Edit_txt_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="gv_detail_prod_Edit_txt" ValidChars="0123456789">
                                                    </asp:FilteredTextBoxExtender>
                                                </ItemTemplate>
                                                <ItemStyle CssClass="ItemStyle-right" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
