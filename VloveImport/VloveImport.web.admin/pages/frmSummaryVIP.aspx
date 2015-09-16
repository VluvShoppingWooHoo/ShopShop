<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmSummaryVIP.aspx.cs" Inherits="VloveImport.web.admin.pages.frmSummaryVIP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%"
                DataKeyNames="VIP_ID,VIP_NAME,VIP_PERCENT,CountTotal">
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="VIP_NAME" HeaderText="VIP Name">
                        <HeaderStyle CssClass="width40" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Percent">
                        <ItemTemplate>
                            <asp:TextBox ID="txtPercent" runat="server" Text='<%# Bind("VIP_PERCENT") %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CountTotal" HeaderText="Total">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>

            <table style="border: 1 solid;">
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnSave" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

