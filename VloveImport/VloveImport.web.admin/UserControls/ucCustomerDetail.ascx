<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerDetail.ascx.cs" Inherits="VloveImport.web.admin.UserControls.ucCustomerDetail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<fieldset style="width: 95%;">
    <legend>
        Transaction Detail
    </legend>
    <table>
        <tr>
            <td class ="width20">Customer Code : </td>
            <td class ="width30">
                <asp:Label ID="lbl_cus_code" runat="server"></asp:Label>
            </td>
            <td class ="width20">Customer Email : </td>
            <td class ="width30">
                <asp:Label ID="lbl_cus_email" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Customer Name : </td>
            <td>
                <asp:Label ID="lbl_cus_name" runat="server"></asp:Label>
            </td>
            <td>Customer Birthday : </td>
            <td>
                <asp:Label ID="lbl_cus_birthday" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Customer Telephone : </td>
            <td>
                <asp:Label ID="lbl_cus_tele" runat="server"></asp:Label>
            </td>
            <td>Customer Fax :</td>
            <td>
                <asp:Label ID="lbl_cus_fax" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Customer Balance :</td>
            <td>
                <asp:Label ID="lbl_cus_balance" runat="server"></asp:Label>
            </td>
            <td>Customer Point : </td>
            <td>
                <asp:Label ID="lbl_cus_point" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan = "4">
                <fieldset>
                    <legend>
                        Customer Address
                    </legend>
                    <asp:GridView ID="gv_detail_address" runat="server" AllowPaging="True" PageSize="5">
                        <Columns>
                            <asp:BoundField HeaderText="No.">
                            <HeaderStyle CssClass="width5" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Address">
                            <HeaderStyle CssClass="width95" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td colspan = "4">
                <fieldset>
                    <legend>
                        Customer Account Bank
                    </legend>
                    <asp:GridView ID="gv_detail_account" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5">
                        <Columns>
                            <asp:BoundField HeaderText="No.">
                            <HeaderStyle CssClass="width5" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Account Bank Name">
                            <HeaderStyle CssClass="width20" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Account No">
                            <HeaderStyle CssClass="width20" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Account Name">
                            <HeaderStyle CssClass="width20" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Account Branch">
                            <HeaderStyle CssClass="width20" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Remark">
                            <HeaderStyle CssClass="width15" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td colspan ="4"></td>
        </tr>
        <tr>
            <td colspan ="4"></td>
        </tr>
    </table>
</fieldset>