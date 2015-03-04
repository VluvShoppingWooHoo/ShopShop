﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="VloveImport.web.Customer.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="row">
            <div class="s12 m12 l12">
                <h3 class="pageTitle">สั่งสินค้า</h3>
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                รายละเอียดขั้นตอนการชำระเงิน
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                ทาง We Love Import มีวิธีการจ่ายเงิน 2 แบบ<br />
                1.	แบบที่ 1 จ่ายแบบเต็มจำนวน โดยทาง We Love Import จะคิดคำนวนค่าขนส่งตั้งแต่ราคาสินค้า ราคาขนส่งในจีน ราคาขนส่งมาไทย ค่าบริการนำส่ง ค่าขนส่งเอกชน จนถึงหน้าบ้าน
            <br />
                2.	แบบที่ 2 แบบแบ่งจ่าย 2 ครั้ง โดยครั้งที่ 1 จ่ายค่าสินค้าและค่าส่งในจีน ซึ่งทาง We Love Import ได้ทำการเรียกเก็บต่าขนส่งจีน ในเรท 7 % ของราคาสินค้า ใอการสั่งซื้อเสร็จสิ้น ยอดเงินคงเหลือจะแจ้งยอดในรายการใบสั่งซื้อ<br />
                สูตรง่ายๆ สำหรับการคำนวนค่าบริการทั้งหมดกับ We Love Import แบบจ่ายครั้งเดียว
(ค่าสินค้า + ค่าขนส่งสินค้าจากร้านค้าจีนไปที่โกดังที่จีนของ We Love Import) xเรทเงินแลกเปลี่ยน
	+ ค่าขนส่งสินค้าจากโกดังจีนมาที่โกดัง We Love Import ในไทย(ขนส่งทางรถ หรือขนส่งทางเรือ)
	+ ค่าขนส่งในประเทศถึงบ้านหรือร้านค้าลูกค้า + ค่าบรรจุภัณฑ์(ถ้ามี)<br />
                สูตรง่ายๆ สำหรับการคำนวนค่าบริการ We Love Import แบบแบ่งจ่าย 2 ครั้ง
ครั้งที่ 1  (ค่าสินค้า)xเรทเงินแลกเปลี่ยน
ครั้งที่ 2 (ค่าขนส่งสินค้าจากร้านค้าจีนไปที่โกดังที่จีนของ We Love Import) xเรทเงินแลกเปลี่ยน(เรทเดียวกันกับเรทที่สั่งซื้อสินค้า)
	+ ค่าขนส่งสินค้าจากโกดังจีนมาที่โกดัง We Love Import ในไทย(ขนส่งทางรถ หรือขนส่งทางเรือ)
	+ ค่าขนส่งในประเทศถึงบ้านหรือร้านค้าลูกค้า + ค่าบรรจุภัณฑ์(ถ้ามี) + ค่าบริการนำส่ง
ราคาสินค้าหน้าเว็บเป็นไปตามจริงหน้าเว็บ ทางเราจะไม่มีการบวกเพิ่ม และหากในหน้าเว็บจีนไม่มีค่าขนส่งในจีน ทางคาร์โก้จะไม่นำมาคำนวน ยกเว้นแต่มีค่าขนส่งในจีนเกิดขึ้นเท่านั้น<br />
                <br />
            </div>
            <div class="row">
                <div class="s12 m12 l12 textUnderline">
                    หมายเหตุ
                </div>
            </div>
            <div class="row">
                <div class="s12 m12 l12">
                    - ค่าขนส่ง จากร้านค้าในจีน ถึง โกดังส่งของในจีน<br />
                    - ค่าขนส่งในจีนเริ่มต้นกิโลกรัมแรกโดยประมานอยู่ที่ 8 -15 หยวน หลังจากนั้นกิโลกรัมละ 3 หยวน<br />
                    ค่าส่งในไทย : ค่าจัดส่งทางลูกค้าสามารถเลือกการจัดส่งสินค้าได้หลายแบบดังนี้ ไปรษณีย์ไทย แมสเซ็นเจอร์ ขนส่งเอกชนนิ่มซีเส็ง และรับเองที่โกดัง<br />
                    •	ค่าขนส่งภายในประเทศไทย<br />
                    การจัดส่งภายในประเทศมี 2 แบบ<br />
                    การจัดส่งสินค้าผ่าน บริษัทขนส่งเอกชน ขนส่งภายในประเทศ คิดค่าบริการตามจริง ทาง We Love Import  ขอคิดค่าบริการจัดส่งไปยัง บริษัทขนเอกชน เพิ่มจากค่าจัดส่ง 2 แบบ<br />
                    • แบบคิดเงินต้นทาง  คิดค่าบริการเพิ่ม 30 บาท<br />
                    • แบบเก็บค่าบริการปลายทาง คิดค่าบริการเพิ่ม 50 บาท/50 กิโลกรัม<br />
                    ตัวอย่าง        กรณี 1    สินค้ามีน้ำหนัก 20 กก. คิดค่าบริการเพิ่ม 50 บาท<br />
                    กรณี 2    สินค้ามีน้ำหนัก 53 กก. คิดค่าบริการเพิ่ม 100 บาท<br />
                    การจัดส่งสินค้าผ่าน ไปรษณีย์ไทย คิดค่าบริการตามจริง<br />
                    • แบบพัสดุธรรมดา<br />
                    • ลงทะเบียน (สามารถเช็คสถานะออนไลน์ ที่เว็บไปรษณีย์ไทยได้)<br />
                    • EMS (สามารถเช็คสถานะออนไลน์ ที่เว็บไปรษณีย์ไทยได้)<br />
                    ทาง We Love Import  ขอคิดค่าบริการจัดส่งไปยังไปรษณีย์ไทย เพิ่มจากค่าจัดส่ง 30 บาท เรทอัตราค่าบริการของไปรษณีย์ไทย
                <br />
                    <br />

                    ระยะเวลาในการขนส่งสินค้า<br />
                    การขนส่งทางเครื่องบิน<br />
                    นำเข้าสินค้าจากจีนส่งสินค้าจาก กวางโจว – ไทย ทางอากาศ (Air) ทางเครื่องบินปิดตู้ทุกวันระยะเวลาในการขนส่งจากจีนมาไทย 2-3 วันบริการขนส่งสินค้าถึงหน้าบ้านหรือหน้าร้านของลูกค้าด้วยขนส่งเอกชน ทั้งใน กรุงเทพฯ ปริมณฑล และต่างจังหวัด<br />
                    การขนส่งทางรถ<br />
                    นำเข้าสินค้าจากจีนส่งสินค้าจากกวางโจว – ไทย ทางรถ (EK) ทางรถปิดตู้ทุกวันและระยะเวลาในการขนส่งจากจีนมาไทย 5 -7 วัน นับจากวันขึ้นตู้เป็นการขนส่งที่ใช้กันอย่างแพร่หลายใน ปัจจุบันค่าใช้จ่ายไม่แพง สะดวกและเร็ว บริการขนส่งสินค้าถึงหน้าบ้านหรือหน้าร้านของลูกค้าด้วยขนส่งเอกชน ทั้งใน กรุงเทพฯ ปริมณฑล และต่างจังหวัด<br />
                    การขนส่งทางเรือ<br />
                    นำเข้าสินค้าจากจีนส่งสินค้าจากกวางโจว – ไทย ทางเรือ (Sea) ทางเรือระยะเวลาในการขนส่ง 10 -14 วัน เรืออกทุกอาทิตย์<br />
                    ข้อดี คือ ไม่แพง สินค้าที่ไม่มีรูปร่างไม่สัมพันธ์กับรูปร่างจึงเหมาะกับการขนส่งทางเรือลดต้นทุน (เหมาะกับสินค้าลิขสิทธิ์ สินค้าที่ทำจากเหล็ก มีเหล็กเป็นส่วนประกอบ)<br />
                    ข้อเสีย คือ ใช้ระยะเวลาในการขนส่งค่อนข้างนานยอดขนส่งต่อครั้ง 15,000 บาทขึ้นไป ส่งฟรี ทั่ว กทม ปริมณทล เพิ่ม 300 บาท เท่านั้น
                </div>
            </div>
        </div>
    </div>

    <%--<table>
        <tr>
            <td>รายละเอียดขั้นตอนการชำระเงิน
            </td>
        </tr>
        <tr>
            <td>ทาง We Love Import มีวิธีการจ่ายเงิน 2 แบบ
            </td>
        </tr>
        <tr>
            <td>1.	แบบที่ 1 จ่ายแบบเต็มจำนวน โดยทาง We Love Import จะคิดคำนวนค่าขนส่งตั้งแต่ราคาสินค้า ราคาขนส่งในจีน ราคาขนส่งมาไทย ค่าบริการนำส่ง ค่าขนส่งเอกชน จนถึงหน้าบ้าน 
            </td>
        </tr>
        <tr>
            <td>2.	แบบที่ 2 แบบแบ่งจ่าย 2 ครั้ง โดยครั้งที่ 1 จ่ายค่าสินค้าและค่าส่งในจีน ซึ่งทาง We Love Import ได้ทำการเรียกเก็บต่าขนส่งจีน ในเรท 7 % ของราคาสินค้า ใอการสั่งซื้อเสร็จสิ้น ยอดเงินคงเหลือจะแจ้งยอดในรายการใบสั่งซื้อ
            </td>
        </tr>
        <tr>
            <td>สูตรง่ายๆ สำหรับการคำนวนค่าบริการทั้งหมดกับ We Love Import แบบจ่ายครั้งเดียว
(ค่าสินค้า + ค่าขนส่งสินค้าจากร้านค้าจีนไปที่โกดังที่จีนของ We Love Import) xเรทเงินแลกเปลี่ยน
	+ ค่าขนส่งสินค้าจากโกดังจีนมาที่โกดัง We Love Import ในไทย(ขนส่งทางรถ หรือขนส่งทางเรือ)
	+ ค่าขนส่งในประเทศถึงบ้านหรือร้านค้าลูกค้า + ค่าบรรจุภัณฑ์(ถ้ามี)
            </td>
        </tr>
        <tr>
            <td>สูตรง่ายๆ สำหรับการคำนวนค่าบริการ We Love Import แบบแบ่งจ่าย 2 ครั้ง
ครั้งที่ 1  (ค่าสินค้า)xเรทเงินแลกเปลี่ยน
ครั้งที่ 2 (ค่าขนส่งสินค้าจากร้านค้าจีนไปที่โกดังที่จีนของ We Love Import) xเรทเงินแลกเปลี่ยน(เรทเดียวกันกับเรทที่สั่งซื้อสินค้า)
	+ ค่าขนส่งสินค้าจากโกดังจีนมาที่โกดัง We Love Import ในไทย(ขนส่งทางรถ หรือขนส่งทางเรือ)
	+ ค่าขนส่งในประเทศถึงบ้านหรือร้านค้าลูกค้า + ค่าบรรจุภัณฑ์(ถ้ามี) + ค่าบริการนำส่ง
ราคาสินค้าหน้าเว็บเป็นไปตามจริงหน้าเว็บ ทางเราจะไม่มีการบวกเพิ่ม และหากในหน้าเว็บจีนไม่มีค่าขนส่งในจีน ทางคาร์โก้จะไม่นำมาคำนวน ยกเว้นแต่มีค่าขนส่งในจีนเกิดขึ้นเท่านั้น
            </td>
        </tr>
        <tr>
            <td>หมายเหตุ
            </td>
        </tr>
        <tr>
            <td>- ค่าขนส่ง จากร้านค้าในจีน ถึง โกดังส่งของในจีน<br />
                - ค่าขนส่งในจีนเริ่มต้นกิโลกรัมแรกโดยประมานอยู่ที่ 8 -15 หยวน หลังจากนั้นกิโลกรัมละ 3 หยวน
            </td>
        </tr>
        <tr>
            <td>ค่าส่งในไทย : ค่าจัดส่งทางลูกค้าสามารถเลือกการจัดส่งสินค้าได้หลายแบบดังนี้ ไปรษณีย์ไทย แมสเซ็นเจอร์ ขนส่งเอกชนนิ่มซีเส็ง และรับเองที่โกดัง
            </td>
        </tr>
        <tr>
            <td>•	ค่าขนส่งภายในประเทศไทย

การจัดส่งภายในประเทศมี 2 แบบ<br />
                การจัดส่งสินค้าผ่าน บริษัทขนส่งเอกชน ขนส่งภายในประเทศ คิดค่าบริการตามจริง
ทาง We Love Import  ขอคิดค่าบริการจัดส่งไปยัง บริษัทขนเอกชน เพิ่มจากค่าจัดส่ง 2 แบบ<br />
                • แบบคิดเงินต้นทาง  คิดค่าบริการเพิ่ม 30 บาท<br />
                • แบบเก็บค่าบริการปลายทาง คิดค่าบริการเพิ่ม 50 บาท/50 กิโลกรัม<br />
                ตัวอย่าง        กรณี 1    สินค้ามีน้ำหนัก 20 กก. คิดค่าบริการเพิ่ม 50 บาท<br />
                กรณี 2    สินค้ามีน้ำหนัก 53 กก. คิดค่าบริการเพิ่ม 100 บาท

            </td>
        </tr>
        <tr>
            <td>การจัดส่งสินค้าผ่าน ไปรษณีย์ไทย คิดค่าบริการตามจริง<br />
                • แบบพัสดุธรรมดา<br />
                • ลงทะเบียน (สามารถเช็คสถานะออนไลน์ ที่เว็บไปรษณีย์ไทยได้)<br />
                • EMS (สามารถเช็คสถานะออนไลน์ ที่เว็บไปรษณีย์ไทยได้)
                <br />
                ทาง We Love Import  ขอคิดค่าบริการจัดส่งไปยังไปรษณีย์ไทย เพิ่มจากค่าจัดส่ง 30 บาท เรทอัตราค่าบริการของไปรษณีย์ไทย 

            </td>
        </tr>
        <tr>
            <td>ระยะเวลาในการขนส่งสินค้า<br />
                การขนส่งทางเครื่องบิน<br />
                นำเข้าสินค้าจากจีนส่งสินค้าจาก กวางโจว – ไทย ทางอากาศ (Air)
ทางเครื่องบินปิดตู้ทุกวันระยะเวลาในการขนส่งจากจีนมาไทย 2-3 วันบริการขนส่งสินค้าถึงหน้าบ้านหรือหน้าร้านของลูกค้าด้วยขนส่งเอกชน ทั้งใน กรุงเทพฯ ปริมณฑล และต่างจังหวัด
                <br />
                การขนส่งทางรถ<br />
                นำเข้าสินค้าจากจีนส่งสินค้าจากกวางโจว – ไทย ทางรถ (EK) ทางรถ
ปิดตู้ทุกวันและระยะเวลาในการขนส่งจากจีนมาไทย 5 -7 วัน นับจากวันขึ้นตู้เป็นการขนส่งที่ใช้กันอย่างแพร่หลายใน ปัจจุบันค่าใช้จ่ายไม่แพง สะดวกและเร็ว บริการขนส่งสินค้าถึงหน้าบ้านหรือหน้าร้านของลูกค้าด้วยขนส่งเอกชน ทั้งใน กรุงเทพฯ ปริมณฑล และต่างจังหวัด<br />
                การขนส่งทางเรือ<br />
                นำเข้าสินค้าจากจีนส่งสินค้าจากกวางโจว – ไทย ทางเรือ (Sea) ทางเรือ
ระยะเวลาในการขนส่ง 10 -14 วัน เรืออกทุกอาทิตย์<br />
                ข้อดี คือ ไม่แพง สินค้าที่ไม่มีรูปร่างไม่สัมพันธ์กับรูปร่างจึงเหมาะกับการขนส่งทางเรือ
ลดต้นทุน (เหมาะกับสินค้าลิขสิทธิ์ สินค้าที่ทำจากเหล็ก มีเหล็กเป็นส่วนประกอบ)<br />
                ข้อเสีย คือ ใช้ระยะเวลาในการขนส่งค่อนข้างนาน
ยอดขนส่งต่อครั้ง 15,000 บาทขึ้นไป ส่งฟรี ทั่ว กทม ปริมณทล เพิ่ม 300 บาท เท่านั้น
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>--%>
    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
        });
    </script>
</asp:Content>
