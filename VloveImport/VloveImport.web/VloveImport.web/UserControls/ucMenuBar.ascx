﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuBar.ascx.cs" Inherits="VloveImport.web.UserControls.ucMenuBar" %>
<div id="divSide" class="collection with-header">
    <div class="collection-header">
        Menu
    </div>
    <a class="collection-item" href="/Customer/TourMarket.aspx">ทัวร์ตลาดจีน</a>
    <a class="collection-item" href="/Customer/Order.aspx">สั่งสินค้า</a>
    <a class="collection-item" href="/Customer/News.aspx">ข่าวสารและกิจกรรม</a>
    <a class="collection-item" href="/Customer/Recommend.aspx">สินค้าแนะนำ</a>
    <a class="collection-item" href="/Customer/HowTo.aspx?type=other">อื่นๆ</a>
    <a class="collection-item" href="/Customer/AboutUs.aspx">เกี่ยวกับเรา</a>
    <a class="collection-item" href="/Customer/HowTo.aspx?type=order">วิธีการสั่งซื้อสินค้า</a>
    <a class="collection-item" href="/Customer/HowTo.aspx?type=rateimport">ค่าขนส่ง</a>
    <a class="collection-item" href="/Customer/Promotion.aspx">โปรโมชั่น</a>
    <a class="collection-item" href="/Customer/ContactUs.aspx">ติดต่อเรา</a>
</div>
<script type="text/javascript">
    $(function () {

        var type = getUrlParameter('type');
        if (type == 'rateimport')
            $('#divRateimport').show();
        else if (type == 'other')
            $('#divOther').show();
        else
            $('#divOrder').show();

        $('.collection-item').on("click", function () {
            $('.collection-item').removeClass("active");
            $(this).addClass('active');
        });
    });
</script>
<%--<div class="menuBar red row center" style="line-height: 64px; height: 64px;">
    <div class="col s2 m2 l2">
        <a class="collection-item" href="/Customer/TourMarket.aspx">ทัวร์ตลาดจีน</a>
    </div>
    <div class="col s2 m2 l2">
        <a class="collection-item" href="/Customer/Order.aspx">สั่งสินค้า</a>
    </div>
    <div class="col s2 m2 l2">
        <a class="collection-item" href="/Customer/News.aspx">ข่าวสารและกิจกรรม</a>
    </div>
    <div class="col s2 m2 l2">
        <a class="collection-item" href="/Customer/Recommend.aspx">สินค้าแนะนำ</a>
    </div>
    <div class="col s4 m4 l4">
        <a class="red dropdown-button white-text font15 width200px" href="#!" data-activates="dropdown2" style="display:inline-block; width:200px">อื่นๆ<i class="mdi-navigation-arrow-drop-down right"></i></a>
        <ul id="dropdown2" class="dropdown-content width200px">
            <li><a class="collection-item" href="/Customer/HowTo.aspx?type=other">อื่นๆ</a></li>
            <li class="divider"></li>
            <li><a class="collection-item" href="/Customer/AboutUs.aspx">เกี่ยวกับเรา</a></li>
            <li class="divider"></li>
            <li><a class="collection-item" href="/Customer/HowTo.aspx?type=order">วิธีการสั่งซื้อสินค้า</a></li>
            <li class="divider"></li>
            <li><a class="collection-item" href="/Customer/HowTo.aspx?type=rateimport">ค่าขนส่ง</a></li>
            <li class="divider"></li>
            <li><a class="collection-item" href="/Customer/Promotion.aspx">โปรโมชั่น</a></li>
            <li class="divider"></li>
            <li><a class="collection-item" href="/Customer/ContactUs.aspx">ติดต่อเรา</a></li>
        </ul>
    </div>
</div>--%>

<%--<nav class="red">
    <ul class="center hide-on-med-and-down">
        <li><a class="truncate" href="/Customer/TourMarket.aspx">ทัวร์ตลาดจีน</a></li>
        <li><a class="truncate" href="/Customer/Order.aspx">สั่งสินค้า</a></li>
        <li><a class="truncate" href="/Customer/HowTo.aspx?type=rateimport">ค่าขนส่ง</a></li>
    <li><a class="truncate" href="/Customer/News.aspx">ข่าวสารและกิจกรรม</a></li>
        <li><a class="truncate" href="/Customer/Promotion.aspx">โปรโมชั่น</a></li>
        <li><a class="truncate" href="/Customer/Recommend.aspx">สินค้าแนะนำ</a></li>
        <li>
            <a class="red dropdown-button width200px" href="#!" data-activates="dropdown1">อื่นๆ<i class="mdi-navigation-arrow-drop-down right"></i></a>
            <ul id="dropdown1" class="dropdown-content">
                <li><a class="red white-text font15" href="/Customer/HowTo.aspx?type=other">อื่นๆ</a></li>
                <li class="divider"></li>
                <li><a class="red white-text font15" href="/Customer/AboutUs.aspx">เกี่ยวกับเรา</a></li>
                <li class="divider"></li>
                <li><a class="red white-text font15" href="/Customer/HowTo.aspx?type=order">วิธีการสั่งซื้อสินค้า</a></li>
                <li class="divider"></li>
                <li><a class="red white-text font15" href="/Customer/ContactUs.aspx">ติดต่อเรา</a></li>
            </ul>
        </li>
    </ul>
</nav>--%>
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
