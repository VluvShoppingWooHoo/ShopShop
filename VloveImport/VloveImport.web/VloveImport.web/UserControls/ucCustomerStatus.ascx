<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerStatus.ascx.cs" Inherits="VloveImport.web.UserControls.ucCustomerStatus" %>
<nav>
    <div class="nav-wrapper orange">
        <a href="#" class="brand-logo">Logo</a>
        <ul id="nav-mobile" class="right hide-on-med-and-down">
            <li>
                <asp:HyperLink class="tooltipped" data-position="bottom" data-delay="50" data-tooltip="เข้าสู่ระบบ" ID="hlLogin" runat="server" NavigateUrl="~/Customer/Login.aspx">&nbsp;
                 <i class="mdi-hardware-desktop-windows center"></i>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink class="tooltipped" data-position="bottom" data-delay="50" data-tooltip="สมัครสมาชิก" ID="hlRegis" runat="server" NavigateUrl="~/Customer/Register.aspx">&nbsp;
                 <i class="mdi-social-person-add center"></i>
                </asp:HyperLink>
            </li>
            <li>
                <asp:Label ID="lbCustomer" runat="server"></asp:Label>
            </li>
            <li>
                <asp:HyperLink class="tooltipped" data-position="bottom" data-delay="50" data-tooltip="ออกจากระบบ" ID="hlLogout" runat="server" NavigateUrl="~/Logout.aspx">&nbsp;
                <i class="mdi-action-exit-to-app center"></i>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink class="tooltipped" data-position="bottom" data-delay="50" data-tooltip="หน้าหลัก" ID="hlIndex" runat="server" NavigateUrl="~/Index.aspx">&nbsp;
                    <i class="mdi-action-home center"></i>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink class="tooltipped" data-position="bottom" data-delay="50" data-tooltip="ตะกร้า" ID="hlBasket" runat="server">&nbsp;
                    <i class="mdi-action-shopping-basket center"></i>
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink class="tooltipped" data-position="bottom" data-delay="50" data-tooltip="กระเป๋าเงินของฉัน" ID="hlWallet" runat="server">&nbsp;
                    <i class="mdi-action-account-balance-wallet center"></i>
                </asp:HyperLink>
            </li>
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
