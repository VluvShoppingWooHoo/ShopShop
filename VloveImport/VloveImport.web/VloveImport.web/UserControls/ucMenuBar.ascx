<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuBar.ascx.cs" Inherits="VloveImport.web.UserControls.ucMenuBar" %>
<table>
    <tr>
        <td>
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem Text="หน้าแรก" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="หน้าสอง" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="หน้าสาม" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="หน้าสี่" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </td>
    </tr>
</table>