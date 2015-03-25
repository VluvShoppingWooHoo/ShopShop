<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerStatus.ascx.cs" Inherits="VloveImport.web.UserControls.ucCustomerStatus" %>
<%--<div class="row">
    <div class="col s2 m2 l2"></div>
    <div class="col s8 m8 l8">--%>
<nav class="ucCustomerStatus">
    <%--<div class="row">
        <div class="col" id="google_translate_element"></div>--%>
    <div class="nav-wrapper black white-text">
        <ul class="left hide-on-med-and-down" style="padding-left: 10%;">
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
        </ul>

        <div id="google_translate_element" style="display: none;"></div>
        <a id="aChina" class="translateFlag" href="#" data-id="1">
            <img src="../Images/icon/Flag/China-Flag-icon.png" />
        </a>
        <a id="aThai" class="translateFlag" href="#" data-id="2">
            <img src="../Images/icon/Flag/Thailand-Flag-icon.png" />
        </a>

        <ul id="nav-mobile" class="right hide-on-med-and-down" style="display: inline-block;">
            <li>
                <asp:HyperLink ID="hlIndex" runat="server" NavigateUrl="~/Index.aspx">หน้าหลัก
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hlProfile" runat="server" NavigateUrl="~/Customer/CustomerProfile.aspx">ข้อมูลของฉัน
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hlOrder" runat="server" NavigateUrl="~/Customer/CustomerOrderList.aspx">รายการสั่งซื้อ
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
    <%--</div>--%>
</nav>
<%--<script type="text/javascript">
    function googleTranslateElementInit() {
        new google.translate.TranslateElement({ pageLanguage: 'th', includedLanguages: 'zh-CN,zh-TW' }, 'google_translate_element');
    }
</script>
<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>--%>
<%--<script type="text/javascript">

    $(function () {

        $('.translateFlag').on("click", function () {
            var aid = $(this).data("id");
            if (aid == 1) {
                $.cookie('googtrans', '/th/zh-TW');
            }
            else {
                $.cookie('googtrans', '/zh-TW/th');
            }
        });
    });

    function googleTranslateElementInit() {
        new google.translate.TranslateElement({ pageLanguage: 'th', includedLanguages: 'th,zh-TW', layout: google.translate.TranslateElement.InlineLayout.SIMPLE, autoDisplay: false }, 'google_translate_element');
    }
</script>
<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>--%>
