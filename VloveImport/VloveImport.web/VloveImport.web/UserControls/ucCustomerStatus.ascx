<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerStatus.ascx.cs" Inherits="VloveImport.web.UserControls.ucCustomerStatus" %>
<%--<div class="row">
    <div class="col s2 m2 l2"></div>
    <div class="col s8 m8 l8">--%>
        <nav class="ucCustomerStatus">
            <div class="nav-wrapper black white-text">
                <ul id="nav-mobile" class="right hide-on-med-and-down">
                    <li>
                        <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/Customer/Login.aspx">เข้าสู่ระบบ
                        </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlRegis" runat="server" NavigateUrl="~/Customer/Register.aspx">สมัครสมาชิก
                        </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlMember" runat="server" NavigateUrl="~/Customer/CustomerProfile.aspx">ข้อมูลสมาชิก
                        </asp:HyperLink>
                    </li>
                    <li>
                        <asp:Label ID="lbCustomer" runat="server"></asp:Label>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlLogout" runat="server" NavigateUrl="~/Logout.aspx">ออกจากระบบ
                        </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlIndex" runat="server" NavigateUrl="~/Index.aspx">หน้าหลัก
                        </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlBasket" runat="server" NavigateUrl="~/Customer/CustomerBasket.aspx">ตะกร้า
                        </asp:HyperLink>
                    </li>
                    <li>
                        <asp:HyperLink ID="hlWallet" runat="server" NavigateUrl="~/Customer/CustomerMyAccount.aspx">กระเป๋าเงินของฉัน
                        </asp:HyperLink>
                    </li>
                </ul>
            </div>
        </nav>
   <%-- </div>
    <div class="col s2 m2 l2"></div>
</div>--%>
<%--<nav class="ucCustomerStatus">
    <div class="nav-wrapper black white-text">
        <a href="../Index.aspx" class="brand-logo">
            <i class="mdi-device-airplanemode-on"></i>  LOGO</a>
        <ul id="nav-mobile" class="right hide-on-med-and-down">
            <li>
                <asp:HyperLink  ID="hlLogin" runat="server" NavigateUrl="~/Customer/Login.aspx">
                 <i class="mdi-hardware-desktop-windows center"></i>เข้าสู่ระบบ
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink  ID="hlRegis" runat="server" NavigateUrl="~/Customer/Register.aspx">
                 <i class="mdi-social-person-add center"></i>สมัครสมาชิก
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink  ID="hlMember" runat="server" NavigateUrl="~/Customer/CustomerProfile.aspx">
                    <i class="mdi-action-view-headline center"></i>ข้อมูลสมาชิก
                </asp:HyperLink>
            </li>
            <li>
                <asp:Label ID="lbCustomer" runat="server"></asp:Label>
            </li>
            <li>
                <asp:HyperLink  ID="hlLogout" runat="server" NavigateUrl="~/Logout.aspx">
                <i class="mdi-action-exit-to-app center"></i>ออกจากระบบ
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink  ID="hlIndex" runat="server" NavigateUrl="~/Index.aspx">
                    <i class="mdi-action-home center"></i>หน้าหลัก
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink  ID="hlBasket" runat="server">
                    <i class="mdi-action-shopping-basket center"></i>ตะกร้า
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink  ID="hlWallet" runat="server">
                    <i class="mdi-action-account-balance-wallet center"></i>กระเป๋าเงินของฉัน
                </asp:HyperLink>
            </li>
        </ul>
    </div>
</nav>--%>
<%--<table>
    <tr>
        <td>        
            <asp:HyperLink ID="hlLogin" runat="server" Text="เข้าสู่ระบบ" NavigateUrl="~/Customer/Login.aspx"></asp:HyperLink>
            <asp:HyperLink ID="hlRegis" runat="server" Text="สมัครสมาชิก" NavigateUrl="~/Customer/Register.aspx"></asp:HyperLink> 
            <asp:Label ID="lbCustomer" runat="server"></asp:Label>  
            <asp:HyperLink ID="hlLogout" runat="server" Text="ออกจากระบบ" NavigateUrl="~/Logout.aspx"></asp:HyperLink> 
        </td>
    </tr>
</table>--%>
