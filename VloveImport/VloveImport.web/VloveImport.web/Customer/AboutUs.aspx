<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="VloveImport.web.Customer.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divAbout" hidden>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                i love import  บริการนำเข้าสินค้าจากจีน
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                ผู้นำด้านการสั่งซื้อสินค้าจีนออนไลน์ แบบเว็บไซด์ E-Commerce Service แบบครบวงจร ทั้งจากเว็บไซด์จีน Taobao Tmall 1688 Alibaba และเว็บไซด์อื่นๆ และโรงงาน ตลาดจีน แหล่งค้าส่ง พรีออเดอร์สินค้าจีน สั่งซื้อสินค้าร้านค้าที่จีน  เป็นตัวกลางในการสั่งซื้อทั้งธุรกิจขนาดเล็ก ธุรกิจขนาดกลาง ธุรกิจขนาดใหญ่ หลายๆกลุ่มในประเทศไทย ไม่ผ่านคนกลาง เราคือผู้ให้บริการครบวงจร ตั้งแต่สั่งซื้อสินค้า จนกระทั่งบริการขนส่งสินค้าจีนตั้งแต่ประเทศจีนส่งตรงถึงหน้าบ้านแบบครบวงจร ไม่ว่าลูกค้าต้องการสินค้าประเภทไหน เพียงติดต่อมาที่เรา ทางเราจะจัดหาสินค้าให้ลูกค้า และนำเสนอราคาให้ลูกค้าตัดสินใจ และเรายังเป็นผู้ขนส่งสินค้าจีนมาสู่ไทยด้วยบริการที่หลากหลายให้ลูกค้าเลือกใช้บริการตามความเหมาะสม
            <br />
                และที่สำคัญลูกค้าสามารถเช็คสถานะสั่งของได้ตั้งแต่ร้านค้าส่งสินค้า หรือทางโรงงานส่งสินค้า จนกระทั่งสถานะถึงไทยรวมถึงสถานะถึงบ้านทุกขั้นตอน สามารถตรวจเช็คได้ เป็นบริการ One Serive และตรวจเช็คได้ทุกขั้นตอน
            <br />

            </div>
        </div>
    </div>
    <div id="divService" hidden>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                บริการของเรา
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                -	บริการสั่งซื้อสินค้าออนไลน์ แบบ E-Commerce กดสั่งได้ผ่านหน้าเว็บไซด์ โดยไม่ต้องกรอกหรือส่งออเดอร์มาทางเมลให้ โดยมีระบบสั่งซื้อสินค้า Grab Url มาวางแล้วกดสั่งซื้อไม่ยุ่งยาก<br />
                -	บริการสั่งซื้อสินค้าจากโรงงาน ร้านค้า แหล่งค้าส่ง<br />
                -	บริการขนส่งสินค้าจากจีนมาไทย<br />
                -	บริการโอนเงินหยวน<br />
                -	บริการพาทัวร์ตลาดจีน จัดทัวร์ตลาดจีน<br />
                -	ทางบริษัทรวมลิ้งเว็บช้อปปิ้งจากทางเมืองจีนไว้สำหรับลูกค้า<br />
                -	 มี Catagory จากเว็บ Taobao ,1688,Tmall           
                <br />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            var type = getUrlParameter('type');
            if (type == 'about')
                $('#divAbout').show();
            else
                $('#divService').show();

            SetFadeout();
        });
    </script>
</asp:Content>
