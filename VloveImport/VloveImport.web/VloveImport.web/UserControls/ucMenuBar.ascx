<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuBar.ascx.cs" Inherits="VloveImport.web.UserControls.ucMenuBar" %>
<%@ Import Namespace="VloveImport.data.Extension" %>
<%--<%Constant.ScrapModel. %>--%>
<div id="divSide" class="collection with-header">
    <div class="collection-header">
        <span id="spanMenu" style="font-size: 20px !important"></span>
    </div>

    <a class="collection-item mShipping_Price" data-id="mSH1">การขนส่งทางเครื่องบิน</a>
    <a class="collection-item mShipping_Price" data-id="mSH2">การขนส่งทางรถ</a>
    <a class="collection-item mShipping_Price" data-id="mSH3">การขนส่งทางเรือ</a>
    <a class="collection-item mShipping_Price" data-id="mSH4">ค่าส่งในไทย</a>
    <a class="collection-item mShipping_Price" data-id="mSH5">การรับสินค้า</a>
    <a class="collection-item mShipping_Price" data-id="mSH6">การคิดราคาค่านำเข้าแบ่งตามประเภท</a>

    <a class="collection-item mOrder" data-id="mOR1">กฏกติกาในการสั่งซื้อ</a>
    <a class="collection-item mOrder" data-id="mOR2">ตัวอย่างศัพท์ภาษาจีนและวิธีหาสินค้าในเว็บจีน</a>
    <a class="collection-item mOrder" data-id="mOR3">การ Search หาสินค้า</a>
    <a class="collection-item mOrder" data-id="mOR4">วิธีสั่งซื้อสินค้าสำหรับลูกค้าที่สั่งแบบ ฝากจ่ายเงิน</a>
    <a class="collection-item mOrder" data-id="mOR5">วิธีการฝากส่งสินค้าอย่างเดียว</a>
    <a class="collection-item mOrder" data-id="mOR6">วิธีการสั่งซื้อแบบ Grab Url หน้าเว็บไซด์</a>
    <a class="collection-item mOrder" data-id="mOR7">การโอนเงินและการเติมเงิน</a>
    <a class="collection-item mOrder" data-id="mOR8">รายละเอียดขั้นตอนการชำระเงิน</a>
    <a class="collection-item mOrder" data-id="mOR9">วิธีการชำระเงินและแจ้งยืนยันการชำระเงิน</a>
    <a class="collection-item mOrder" data-id="mOR10">วิธีถอนเงินในระบบ</a>
    <a class="collection-item mOrder" data-id="mOR11">ตารางไซด์เครื่องแต่งกาย</a>
    <a class="collection-item mOrder" data-id="mOR12">วิธีการสมัครสมาชิก</a>


    <a class="collection-item mCus black" disabled>ข้อมูลทั่วไป</a>
    <a class="collection-item mCus" href="../Customer/CustomerProfile.aspx">ข้อมูลของฉัน</a>
    <a class="collection-item mCus" href="../Customer/CustomerAddress.aspx">ที่อยู่ลูกค้า</a>
    <a class="collection-item mCus" href="../Customer/CustomerBank.aspx">หน้าจัดการ บัญชีของลูกค้า</a>
    <a class="collection-item mCus" href="../Customer/CustomerChangePassword.aspx">รหัสผ่าน</a>

    <a class="collection-item mCus black" disabled>รายการ</a>
    <a class="collection-item mCus" href="../Customer/CustomerOrder.aspx">สั่งซื้อสินค้า</a>
    <a class="collection-item mCus" href="../Customer/CustomerOrderList.aspx">รายการสั่งซื้อ</a>
    <a class="collection-item mCus" href="../Customer/CustomerBasket.aspx">ตะกร้า</a>
    <a class="collection-item mCus" href="../Customer/CustomerTransOnlyList.aspx">ขนส่งอย่างเดียว</a>
    <a class="collection-item mCus" href="../Customer/CustomerUploadPIList.aspx">ส่งแบบฝากจ่าย</a>

    <a class="collection-item mCus black" disabled>บัญชี</a>
    <a class="collection-item mCus" href="../Customer/CustomerMyAccount.aspx?tab=topup">เติมเงิน</a>
    <a class="collection-item mCus" href="../Customer/CustomerMyAccount.aspx?tab=withdraw">ถอนเงิน</a>
    <a class="collection-item mCus" href="../Customer/CustomerMyAccount.aspx?tab=translog">ประวัติการชำระเงิน</a>
</div>
<script type="text/javascript">
    $(function () {
        $('#divSide a.collection-item').hide();
        var type = getUrlParameter('type');
        if (type == 'rateimport')
            $('#divRateimport').show();
        else if (type == 'other')
            $('#divOther').show();
        else
            $('#divOrder').show();

        //$('.mCus').show();
        var pageId = parseInt(getUrlParameter('pag'));
        var MenuTXT = '';
        switch (pageId) {
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
                $('.mOrder').show();
                break;
            case 9:
                MenuTXT = 'สมัครงาน';
                break;
            default:
                var User = '<%= Session["User"]%>';
                if (User != '') {
                    MenuTXT = 'ลูกค้า';
                    $('.mCus').show();
                }
                return;
        }

        $('#spanMenu').html(MenuTXT);

        $('.mContent').hide();
        $('.mIndex').show();

        $('.collection-item').on("click", function () {
            $('.collection-item').removeClass("active");
            $(this).addClass('active');

            var aid = $(this).data("id");
            $('.mContent').hide();
            $('#' + aid).show();
            var h = $('#divcontent').outerHeight();
            //var h = $('.page-footer').position().top;
            setHeight(h);
        });
    });
</script>
