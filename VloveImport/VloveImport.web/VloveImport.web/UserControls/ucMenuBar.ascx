<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuBar.ascx.cs" Inherits="VloveImport.web.UserControls.ucMenuBar" %>
<nav class="red">
    <ul class="center hide-on-med-and-down">
        <%--<li><a class="truncate" href="../Index.aspx">หน้าแรก</a></li>--%>
        <%--<li><a class="truncate" href="/Customer/AboutUs.aspx">เกี่ยวกับเรา</a></li>--%>
        <%--<li><a class="truncate" href="/Customer/TourMarket.aspx" onclick="return changePageTitle(this);">ทัวร์ตลาดจีน</a></li>--%>
        <li><a class="truncate" href="/Customer/TourMarket.aspx">ทัวร์ตลาดจีน</a></li>
        <li><%--<a class="truncate" href="/Customer/HowTo.aspx?type=order">วิธีการสั่งซื้อสินค้า</a>--%></li>
        <li><a class="truncate" href="/Customer/Order.aspx">สั่งสินค้า</a></li>
        <li><a class="truncate" href="/Customer/HowTo.aspx?type=rateimport">ค่าขนส่ง</a></li>
    <li><a class="truncate" href="/Customer/News.aspx">ข่าวสารและกิจกรรม</a></li>
        <li><a class="truncate" href="/Customer/Promotion.aspx">โปรโมชั่น</a></li>
        <li><a class="truncate" href="/Customer/Recommend.aspx">สินค้าแนะนำ</a></li>
        <%--<li><a class="truncate" href="/Customer/ContactUs.aspx">ติดต่อเรา</a></li>--%>
        <li>
            <a class="red dropdown-button width200px" href="#!" data-activates="dropdown2">อื่นๆ<i class="mdi-navigation-arrow-drop-down right"></i></a>
            <ul id="dropdown2" class="dropdown-content">
                <li><a class="red white-text font15" href="#!">อื่นๆ</a></li>
                <li class="divider"></li>
                <li><a class="red white-text font15" href="/Customer/AboutUs.aspx">เกี่ยวกับเรา</a></li>
                <li class="divider"></li>
                <li><a class="red white-text font15" href="/Customer/HowTo.aspx?type=order">วิธีการสั่งซื้อสินค้า</a></li>
                <li class="divider"></li>
                <li><a class="red white-text font15" href="/Customer/ContactUs.aspx">ติดต่อเรา</a></li>
            </ul>
        </li>
    </ul>
</nav>
<%--<div class="row red">
    <div class="col s12 m12 l12">
        <ul class="tabs">
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplIndex" Text="หน้าแรก" NavigateUrl="~/Index.aspx" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplAboutUs" Text="เกี่ยวกับเรา" NavigateUrl="~/Customer/AboutUs.aspx" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplTourMarket" Text="ทัวร์ตลาดจีน" NavigateUrl="~/Customer/TourMarket.aspx" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplHowToorder" Text="วิธีการสั่งซื้อสินค้า" NavigateUrl="~/Customer/HowTo.aspx?type=order" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplOrder" Text="สั่งสินค้า" NavigateUrl="~/Customer/Order.aspx" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplHowTorateimport" Text="ค่าขนส่ง" NavigateUrl="~/Customer/HowTo.aspx?type=rateimport" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplNews" Text="ข่าวสารและกิจกรรม" NavigateUrl="~/Customer/News.aspx" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplPromotion" Text="โปรโมชั่น" NavigateUrl="~/Customer/Promotion.aspx" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplRecommend" Text="สินค้าแนะนำ" NavigateUrl="~/Customer/Recommend.aspx" runat="server"></asp:HyperLink></li>
            <li class="tab col s1 m1 l1"><asp:HyperLink ID="hplContactUs" Text="ติดต่อเรา" NavigateUrl="~/Customer/ContactUs.aspx" runat="server"></asp:HyperLink></li>
        </ul>
    </div>
</div>
<%--<table>
    <tr>
        <td>
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem Text="หน้าแรก" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="เกี่ยวกับเรา" NavigateUrl="~/Customer/AboutUs.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ทัวร์ตลาดจีน" NavigateUrl="~/Customer/TourMarket.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="วิธีการสั่งซื้อสินค้า" NavigateUrl="~/Customer/HowTo.aspx?type=order"></asp:MenuItem>
                    <asp:MenuItem Text="สั่งสินค้า" NavigateUrl="~/Customer/Order.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ค่าขนส่ง" NavigateUrl="~/Customer/HowTo.aspx?type=rateimport"></asp:MenuItem>
                    <asp:MenuItem Text="ข่าวสารและกิจกรรม" NavigateUrl="~/Customer/News.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="โปรโมชั่น" NavigateUrl="~/Customer/Promotion.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="สินค้าแนะนำ" NavigateUrl="~/Customer/Recommend.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ติดต่อเรา" NavigateUrl="~/Customer/ContactUs.aspx"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </td>
    </tr>
</table>--%>
