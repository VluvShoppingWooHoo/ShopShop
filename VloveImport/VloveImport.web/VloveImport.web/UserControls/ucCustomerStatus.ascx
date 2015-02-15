<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerStatus.ascx.cs" Inherits="VloveImport.web.UserControls.ucCustomerStatus" %>
<table>
    <tr>
        <td>            
            <asp:HyperLink ID="hlLogin" runat="server" Text="เข้าสู่ระบบ" NavigateUrl="~/Customer/Login.aspx"></asp:HyperLink>&nbsp;
            <asp:HyperLink ID="hlRegis" runat="server" Text="สมัครสมาชิก" NavigateUrl="~/Customer/Register.aspx"></asp:HyperLink> 
            <asp:Label ID="lbCustomer" runat="server"></asp:Label>  &nbsp;
            <asp:HyperLink ID="hlLogout" runat="server" Text="ออกจากระบบ" NavigateUrl="~/Logout.aspx"></asp:HyperLink> 
        </td>
    </tr>
</table>
