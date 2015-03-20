<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuBar.ascx.cs" Inherits="VloveImport.web.UserControls.ucMenuBar" %>
<%@ Import namespace="VloveImport.data.Extension" %>
<%--<%Constant.ScrapModel. %>--%>
<div id="divSide" class="collection with-header">
    <div class="collection-header">
        <span id="spanMenu"></span>
    </div>
    
    <a class="collection-item mShipping_Price" data-id="mSH1">การขนส่งทางเครื่องบิน</a>
    <a class="collection-item mShipping_Price" data-id="mSH2">การขนส่งทางรถ</a>
    <a class="collection-item mShipping_Price" data-id="mSH3">การขนส่งทางเรือ</a>
    <a class="collection-item mShipping_Price" data-id="mSH4">ค่าส่งในไทย</a>
    <a class="collection-item mShipping_Price" data-id="mSH5">การรับสินค้า</a>
    <a class="collection-item mShipping_Price" data-id="mSH6">การคิดราคาค่านำเข้าแบ่งตามประเภท</a>


    <%--<a class="collection-item" href="/Customer/TourMarket.aspx">ทัวร์ตลาดจีน</a>
    <a class="collection-item" href="/Customer/Order.aspx">สั่งสินค้า</a>
    <a class="collection-item" href="/Customer/News.aspx">ข่าวสารและกิจกรรม</a>
    <a class="collection-item" href="/Customer/Recommend.aspx">สินค้าแนะนำ</a>
    <a class="collection-item" href="/Customer/HowTo.aspx?type=other">อื่นๆ</a>
    <a class="collection-item" href="/Customer/AboutUs.aspx">เกี่ยวกับเรา</a>
    <a class="collection-item" href="/Customer/HowTo.aspx?type=order">วิธีการสั่งซื้อสินค้า</a>
    <a class="collection-item" href="/Customer/HowTo.aspx?type=rateimport">ค่าขนส่ง</a>
    <a class="collection-item" href="/Customer/Promotion.aspx">โปรโมชั่น</a>
    <a class="collection-item" href="/Customer/ContactUs.aspx">ติดต่อเรา</a>--%>
</div>
<script type="text/javascript">
    $(function () {
        $('#spanMenu a.collection-item').hide();
        var type = getUrlParameter('type');
        if (type == 'rateimport')
            $('#divRateimport').show();
        else if (type == 'other')
            $('#divOther').show();
        else
            $('#divOrder').show();

        var pageId = parseInt(getUrlParameter('pag'));
        var MenuTXT = '';
        switch(pageId) {
            case 1:
                MenuTXT = 'ข่าวสาร';
                break;
            case 2:
                MenuTXT = 'เกี่ยวกับเรา';
                break;
            case 3:
                MenuTXT = 'ค่าขนส่ง';
                $('.mShipping_Price').show();
                break;
            case 4:
                MenuTXT = 'ติดต่อเรา';
                break;
            case 5:
                MenuTXT = 'ทัวร์ตลาดจีน';
                break;
            case 6:
                MenuTXT = 'บริการของเรา';
                break;
            case 7:
                MenuTXT = 'โปรโมชั่น';
                break;
            case 8:
                MenuTXT = 'วิธีการสั่งซื้อสินค้า';
                break;
            case 9:
                MenuTXT = 'สมัครงาน';
                break;
            default:
                return;
        }
        $('#spanMenu').html(MenuTXT);

        $('.collection-item').on("click", function () {
            $('.collection-item').removeClass("active");
            $(this).addClass('active');

            var aid = $(this).data("id");
            $('.mContent').hide();
            $('#' + aid).show();
            var h = $('#divcontent').outerHeight();
            setHeight(h);
        });
    });
</script>
