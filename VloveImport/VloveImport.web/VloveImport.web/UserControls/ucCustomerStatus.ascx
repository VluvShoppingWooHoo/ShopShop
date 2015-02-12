<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerStatus.ascx.cs" Inherits="VloveImport.web.UserControls.ucCustomerStatus" %>
<table>
    <tr>
        <td id="Logout">
            <asp:HyperLink ID="hlLogin" runat="server" Text="เข้าสู่ระบบ" NavigateUrl="~/Customer/Login.aspx"></asp:HyperLink> |
            <asp:HyperLink ID="hlRegis" runat="server" Text="สมัครสมาชิก"></asp:HyperLink> 
        </td>
        <td id="Login">
            <asp:Label ID="lbCustomer" runat="server"></asp:Label>  
            <asp:HyperLink ID="hlLogout" runat="server" Text="ออกจากระบบ"></asp:HyperLink> 
        </td>
    </tr>
</table>
