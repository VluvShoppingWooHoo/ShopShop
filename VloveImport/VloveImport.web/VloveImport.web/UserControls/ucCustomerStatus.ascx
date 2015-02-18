<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerStatus.ascx.cs" Inherits="VloveImport.web.UserControls.ucCustomerStatus" %>
<nav>
    <div class="nav-wrapper">
        <a href="#" class="brand-logo">Logo</a>
        <ul id="nav-mobile" class="right hide-on-med-and-down">
            <li><asp:HyperLink ID="hlLogin" runat="server" Text="เข้าสู่ระบบ" NavigateUrl="~/Customer/Login.aspx"></asp:HyperLink><i class="mdi-hardware-desktop-windows"></i></li>
            <li><asp:HyperLink ID="hlRegis" runat="server" Text="สมัครสมาชิก" NavigateUrl="~/Customer/Register.aspx"></asp:HyperLink><i class="mdi-social-person-add"></i></li>
            <li><asp:Label ID="lbCustomer" runat="server"></asp:Label></li>        
            <li><asp:HyperLink ID="hlLogout" runat="server" Text="ออกจากระบบ" NavigateUrl="~/Logout.aspx"></asp:HyperLink><i class="mdi-action-exit-to-app"></i></li>
            <li><asp:HyperLink ID="hlIndex" runat="server" Text="หน้าหลัก" NavigateUrl="~/Index.aspx" ></asp:HyperLink> </li>
            <li><asp:HyperLink ID="hlBasket" runat="server" Text="ตะกร้า"></asp:HyperLink> </li>
            <li><asp:HyperLink ID="hlWallet" runat="server" Text="กระเป๋าเงินของฉัน"></asp:HyperLink>   </li>
        </ul>
    </div>
</nav>
<%--<table>
    <tr>
        <td>            
            <asp:HyperLink ID="hlLogin" runat="server" Text="เข้าสู่ระบบ" NavigateUrl="~/Customer/Login.aspx"></asp:HyperLink>&nbsp;
            <asp:HyperLink ID="hlRegis" runat="server" Text="สมัครสมาชิก" NavigateUrl="~/Customer/Register.aspx"></asp:HyperLink> 
            <asp:Label ID="lbCustomer" runat="server"></asp:Label>  &nbsp;
            <asp:HyperLink ID="hlLogout" runat="server" Text="ออกจากระบบ" NavigateUrl="~/Logout.aspx"></asp:HyperLink> 
        </td>
    </tr>
</table>--%>
