<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucIndexMenuBar.ascx.cs" Inherits="VloveImport.web.UserControls.ucIndexMenuBar" %>
<%@ Import Namespace="VloveImport.data.Extension" %>
<%--<%Constant.ScrapModel. %>--%>
<nav id="navMenuHori">
    <ul class="center hide-on-med-and-down">
        <li><a class="truncate" href="/Customer/News.aspx?pag=1">กิจกรรมและข่าวสาร</a></li>
        <li><a class="truncate" href="/Customer/AboutUs.aspx?type=about&pag=2">เกี่ยวกับเรา</a></li>
        <li><a class="truncate" href="/Customer/HowTo.aspx?type=rateimport&pag=3">ค่าขนส่ง</a></li>
        <li><a class="truncate" href="/Customer/ContactUs.aspx?pag=4">ติดต่อเรา</a></li>
        <li><a class="truncate" href="/Customer/TourMarket.aspx?pag=5">ทัวร์ตลาดจีน</a></li>
        <li><a class="truncate" href="/Customer/AboutUs.aspx?type=service&pag=6">บริการของเรา</a></li>
        <li><a class="truncate" href="/Customer/ContentList.aspx?ctype=1&pag=7">โปรโมชั่น</a></li>
        <li><a class="truncate" href="/Customer/Order.aspx?pag=8">วิธีการสั่งซื้อสินค้า</a></li>
        <li><a class="truncate" href="#">สมัครงาน</a></li>
        <%--<li><a class="truncate" href="/Customer/Recommend.aspx">สินค้าแนะนำ</a></li>--%>
    </ul>
</nav>
<script type="text/javascript">
    $(function () {
    });
</script>
