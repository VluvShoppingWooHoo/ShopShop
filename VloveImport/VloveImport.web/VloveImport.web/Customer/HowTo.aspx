<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="HowTo.aspx.cs" Inherits="VloveImport.web.Customer.HowTo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divRateimport" class="row" hidden>
        <div class="row">
            <h3 class="pageTitle">ค่าขนส่ง</h3>
        </div>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                การคิดราคาค่านำเข้าแบ่งตามประเภท
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                1. สินค้าทั่วไปคิดราคาตามน้ำหนัก<br />
                2. สินค้าทั่วไปคิดราคาตามขนาด (คิว) คือสินค้าที่มีน้ำหนักเบา แต่มีขนาดใหญ่ ใช้พื้นที่มาก เช่น  ตุ๊กตา กระเป๋า กระเป๋าเดินทาง และสินค้าอื่นๆที่มีหนักเบาแต่ขนาดใหญ่<br />
                3. สินค้าลิขสิทธิ์คิดราคาตามน้ำหนัก<br />
                สินค้าทุกอย่างที่เป็นแบรน ติดแบรน  copy brand  ทุกอย่างที่มีลิขสิทธิ์ ไม่ว่าจะ copy มือสอง หรือสินค้าของปลอม 

4. สินค้าลิขสิทธิ์คิดราคาตามขนาด (คิว)
สินค้าทุกอย่างที่เป็นแบรน ติดแบรน  copy brand  ทุกอย่างที่มีลิขสิทธิ์ ไม่ว่าจะ copy มือสอง หรือสินค้าของปลอม  ที่มีหนักเบาแต่ขนาดใหญ่<br />
                5 สินค้า มอก. 
สินค้า มอก คือสินค้าประเภทเครื่องใช้ไฟฟ้าและสินค้าที่ต้องขอใบอนุญาตนำเข้า
                        <br />
                6. สินค้า มอก  คิดราคาตามขนาด (คิว)
สินค้า มอก คือสินค้าประเภทเครื่องใช้ไฟฟ้าและสินค้าที่ต้องขอใบอนุญาตนำเข้า ที่มีหนักเบาแต่ขนาดใหญ่<br />
                7. สินค้าเหมาคิวหรือเหมาตู้
สินค้าที่เหมามาเป็นตู้คอนเทนเนอร์
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <img src="../Images/pic/RateImport-Q.gif" />
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                ค่าขนส่ง We Love Import
            </div>
        </div>
        <ul class="collapsible" data-collapsible="expandable">
            <li>
                <div class="row collapsible-header">
                    <div class="s12 m12 l12">
                        <i class="mdi-device-airplanemode-on"></i>การขนส่งทางเครื่องบิน<br />
                    </div>
                </div>
                <div class="row collapsible-body">
                    <div class="s12 m12 l12">
                        นำเข้าสินค้าจากจีนส่งสินค้าจาก กวางโจว – ไทย ทางอากาศ (Air)
ทางเครื่องบินปิดตู้ทุกวันระยะเวลาในการขนส่งจากจีนมาไทย 2-3 วันบริการขนส่งสินค้าถึงหน้าบ้านหรือหน้าร้านของลูกค้าด้วยขนส่งเอกชน ทั้งใน กรุงเทพฯ ปริมณฑล และต่างจังหวัด ข้อดีและข้อเสียในการขนส่งทางอากาศมีดังนี้
ข้อดี คือ รวดเร็ว ใช้เวลา 2-3 วัน ในการขนส่ง จากโกดังที่จีนข้อเสีย คือ ค่าใช้จ่ายค่อนข้างแพงมาก
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>น้ำหนัก</th>
                            <th>สินค้าทั่วไป</th>
                            <th>สินค้าเบา</th>
                            <th>สินค้าแบรน</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1-5 Kg</td>
                            <td>2000 บาท</td>
                            <td>2500 บาท</td>
                            <td>3000 บาท</td>
                        </tr>
                        <tr>
                            <td>6 kg ขึ้นไป</td>
                            <td>400 บาท /kg</td>
                            <td>500 บาท /kg</td>
                            <td>600 บาท /kg</td>
                        </tr>
                    </tbody>
                </table>
                    </div>
                </div>
            </li>
            <li>
                <div class="row collapsible-header">
                    <div class="s12 m12 l12">
                        <i class="mdi-maps-directions-car"></i>การขนส่งทางรถ<br />
                    </div>
                </div>
                <div class="row collapsible-body">
                    <div class="s12 m12 l12">
                        นำเข้าสินค้าจากจีนส่งสินค้าจากกวางโจว – ไทย ทางรถ (EK) ทางรถ
ปิดตู้ทุกวันและระยะเวลาในการขนส่งจากจีนมาไทย 5 -7 วัน นับจากวันขึ้นตู้เป็นการขนส่งที่ใช้กันอย่างแพร่หลายใน ปัจจุบันค่าใช้จ่ายไม่แพง สะดวกและเร็ว บริการขนส่งสินค้าถึงหน้าบ้านหรือหน้าร้านของลูกค้าด้วยขนส่งเอกชน ทั้งใน กรุงเทพฯ ปริมณฑล และต่างจังหวัด
                    <table class="centered hoverable">
                        <thead>
                            <tr>
                                <th>น้ำหนัก</th>
                                <th>สินค้าเสื้อผ้าทั่วไป</th>
                                <th>สินค้าทั่วไป</th>
                                <th>คิวบิก</th>
                                <th>สินค้าแบรน</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1-100  Kg</td>
                                <td>55  บาท /kg</td>
                                <td>60 บาท /kg</td>
                                <td>9000 บาท</td>
                                <td>ติดต่อสอบถาม</td>
                            </tr>
                            <tr>
                                <td>101 - 500 kg</td>
                                <td>50 บาท /kg</td>
                                <td>60 บาท /kg</td>
                                <td>9000 บาท</td>
                                <td>ติดต่อสอบถาม</td>
                            </tr>
                            <tr>
                                <td>501-999 kg</td>
                                <td>45 บาท /kg</td>
                                <td>60 บาท /kg</td>
                                <td>9000 บาท</td>
                                <td>ติดต่อสอบถาม</td>
                            </tr>
                            <tr>
                                <td>1 ตันขึ้นไป</td>
                                <td>ติดต่อสอบถาม</td>
                                <td>ติดต่อสอบถาม</td>
                                <td>ติดต่อสอบถาม</td>
                                <td>ติดต่อสอบถาม</td>
                            </tr>
                        </tbody>
                    </table>
                    </div>
                </div>
            </li>
            <li>
                <div class="row collapsible-header">
                    <div class="s12 m12 l12">
                        <i class="mdi-maps-directions-ferry"></i>การขนส่งทางเรือ<br />
                    </div>
                </div>
                <div class="row collapsible-body">
                    <div class="s12 m12 l12">
                        นำเข้าสินค้าจากจีนส่งสินค้าจากกวางโจว – ไทย ทางเรือ (Sea) ทางเรือ
ระยะเวลาในการขนส่ง 10 -14 วัน เรืออกทุกอาทิตย์
ข้อดี คือ ไม่แพง สินค้าที่ไม่มีรูปร่างไม่สัมพันธ์กับรูปร่างจึงเหมาะกับการขนส่งทางเรือ
ลดต้นทุน (เหมาะกับสินค้าลิขสิทธิ์ สินค้าที่ทำจากเหล็ก มีเหล็กเป็นส่วนประกอบ)
ข้อเสีย คือ ใช้ระยะเวลาในการขนส่งค่อนข้างนาน
ยอดขนส่งต่อครั้ง 15,000 บาทขึ้นไป ส่งฟรี ทั่ว กทม ปริมณทล เพิ่ม 300 บาท เท่านั้น
                    <table class="centered hoverable">
                        <thead>
                            <tr>
                                <th>น้ำหนัก</th>
                                <th>สินค้าเสื้อผ้าทั่วไป</th>
                                <th>สินค้าทั่วไป</th>
                                <th>คิวบิก</th>
                                <th>สินค้าแบรน</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>50  Kg ขึ้นไป</td>
                                <td>42  บาท /kg</td>
                                <td>50 บาท /kg</td>
                                <td>7500 บาท</td>
                                <td>ติดต่อสอบถาม</td>
                            </tr>
                            <tr>
                                <td>51 - 500 kg </td>
                                <td>38  บาท /kg</td>
                                <td>46 บาท /kg</td>
                                <td>7500 บาท</td>
                                <td>ติดต่อสอบถาม</td>
                            </tr>
                            <tr>
                                <td>501-999 kg</td>
                                <td>34  บาท /kg</td>
                                <td>42 บาท /kg</td>
                                <td>7500 บาท</td>
                                <td>ติดต่อสอบถาม</td>
                            </tr>
                            <tr>
                                <td>1 ตันขึ้นไป</td>
                                <td>ติดต่อสอบถาม</td>
                                <td>ติดต่อสอบถาม</td>
                                <td>ติดต่อสอบถาม</td>
                                <td>ติดต่อสอบถาม</td>
                            </tr>
                        </tbody>
                    </table>
                    </div>
                </div>
            </li>
        </ul>
    </div>
    <div id="divOrder" class="row" hidden>
        <div class="row">
            <div class="s12 m12 l12">
                <h3 class="pageTitle">วิธีการสั่งซื้อสินค้า</h3>
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                1. ตรวจสอบยอดสินค้าที่ต้องชำระ
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                เมื่อทางเจ้าหน้าที่ CS (Customer Service) ของ We Love Import  ได้รับข้อมูลการสั่งซื้อสินค้าของคุณแล้ว ระบบจะทำการคำนวนค่าสินค้าและค่าส่งในจีนอัตโนมัติไปในรายการสั่งซื้อ โดยลูกค้าสามารถทำการแจ้งโอนเงินได้ทันที
รวมถึงการแจ้งไปยัง E-mail ของลูกค้า ซึ่งลูกค้าสามารถตรวจสอบได้ด้วยตนเอง
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                2. ตรวจสอบยอดสินค้าที่ต้องชำระ
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                ลูกค้าสามารถชำระค่าสินค้า ผ่านเครื่อง ATM ของทุกธนาคารใกล้บ้านท่าน หรือที่เคาน์เตอร์ ธนาคารไทยพาณิชย์, ธนาคารกสิกรไทย,
ธนาคารกรุงเทพ ธนาคารกรุงไทย และยังสามารถชำระผ่านช่องทางออนไลน์ของธนาคารได้ตลอด 24 ชั่วโมง 
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                3. แจ้งยืนยันโอนเงิน
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                หลังโอนเงินแล้ว ลูกค้าสามารถแจ้งยืนยันการโอนเงิน และกดเติมเงินเข้ามาในระบบได้ด้วยตนเอง
* กรุณาเก็บ Slip เพื่อเป็นหลักฐาน งดแจ้งการโอนเงินทางโทรศัพท์เพื่อป้องกันการผิดพลาด
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <img src="../Images/pic/foot-size.jpg" />
            </div>
        </div>
    </div>

    <div id="divOther" class="row" hidden>
        <div class="row">
            <div class="s12 m12 l12">
                <h3 class="pageTitle">อื่นๆ</h3>
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                วิธีสั่งซื้อสินค้าสำหรับลูกค้าที่สั่งแบบ ฝากจ่ายเงิน
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                การสั่งสินค้าแบบ ฝากจ่ายเงิน คือทางลูกค้าได้ทำการติดต่อร้านค้าเอง และต้องการให้ทางเราโอนเงินเพื่อชำระค่าสินค้าให้กับทางร้านค้า และใช้บริการของทาง We Love Import   ในการขนส่ง<br />
                Step 1: ลูกค้า Log in เข้าสู่ระบบ และ เข้าไปที่เมนู "สั่งซื้อสินค้าแบบฝากจ่ายเงิน "และฝากส่ง
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <img src="../Images/pic/Order/Order%20step1.png" />
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                Step 2:กรอกรายละเอียดใบสั่งซื้อ และข้อมูลเกี่ยวกับร้านค้า<br />
                แจ้งก่อนสั่งซื้อ<br />
                การสั่งซื้อแบบฝากจ่ายเงิน ลุกค้าต้องแจ้งข้อมูลให้ครบถ้วน เพื่อทางเราจะได้ติดต่อทางจีนได้อย่างรวดเร็ว<br />
                และการสั่งวินค้าแบบฝากจ่ายเงิน ทางเราจะไม่มีบริการเช็คสถานะสินค้า<br />
                ทุกครั้งที่สั่งซื้อสินค้า ลุกค้าสามารถยื่นคำร้องและแจ้งประเภทสินค้า จำนวนกิโล โดยประมาน ทางเราจะแจ้งที่อยู่โกดังของเราให้ลูกค้าแจ้งทางโรงงานจีนได้เลย<br />
                หนึ่งออเดอร์/หนึ่งคำยื่น หากมีหลายออเดอร์กรุณาแจ้งและยื่นคำร้องอีกครั้ง
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <img src="../Images/pic/Order/Order%20Step2.png" /><br />
                <img src="../Images/pic/Order/Order%20Step2-2.png" /><br />
                อัพโหลด ใบ PI………….<br />
                <img src="../Images/pic/Order/Order%20Step3.png" />
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12 textUnderline">
                ช่องทางสมัครสมาชิก
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                ลูกค้าสามารถสมัครสมาชิก vcanbuy.com โดยไม่มีค่าใช้จ่าย
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <img src="../Images/pic/Register/Register1.png" /><br />
                <img src="../Images/pic/Register/Register2.png" /><br />
                <img src="../Images/pic/Register/Register3.png" /><br />
                <img src="../Images/pic/Register/Register4.png" /><br />
                <img src="../Images/pic/Register/Register5.png" /><br />
                <img src="../Images/pic/Register/Register6.png" /><br />
                <img src="../Images/pic/Register/Register7.png" />
            </div>
        </div>
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
        });
    </script>

    <%--<asp:MultiView ID="mView" runat="server">
        <asp:View ID="vRateImport" runat="server">
            <table>
                <tr>
                    <td>การคิดราคาค่านำเข้าแบ่งตามประเภท
                    </td>
                </tr>
                <tr>
                    <td>1. สินค้าทั่วไปคิดราคาตามน้ำหนัก<br />
                        2. สินค้าทั่วไปคิดราคาตามขนาด (คิว) คือสินค้าที่มีน้ำหนักเบา แต่มีขนาดใหญ่ ใช้พื้นที่มาก เช่น  ตุ๊กตา กระเป๋า กระเป๋าเดินทาง และสินค้าอื่นๆที่มีหนักเบาแต่ขนาดใหญ่<br />
                        3. สินค้าลิขสิทธิ์คิดราคาตามน้ำหนัก<br />
                        สินค้าทุกอย่างที่เป็นแบรน ติดแบรน  copy brand  ทุกอย่างที่มีลิขสิทธิ์ ไม่ว่าจะ copy มือสอง หรือสินค้าของปลอม 

4. สินค้าลิขสิทธิ์คิดราคาตามขนาด (คิว)
สินค้าทุกอย่างที่เป็นแบรน ติดแบรน  copy brand  ทุกอย่างที่มีลิขสิทธิ์ ไม่ว่าจะ copy มือสอง หรือสินค้าของปลอม  ที่มีหนักเบาแต่ขนาดใหญ่<br />
                        5 สินค้า มอก. 
สินค้า มอก คือสินค้าประเภทเครื่องใช้ไฟฟ้าและสินค้าที่ต้องขอใบอนุญาตนำเข้า
                        <br />
                        6. สินค้า มอก  คิดราคาตามขนาด (คิว)
สินค้า มอก คือสินค้าประเภทเครื่องใช้ไฟฟ้าและสินค้าที่ต้องขอใบอนุญาตนำเข้า ที่มีหนักเบาแต่ขนาดใหญ่<br />
                        7. สินค้าเหมาคิวหรือเหมาตู้
สินค้าที่เหมามาเป็นตู้คอนเทนเนอร์
                    </td>
                </tr>
            </table>
<<<<<<< HEAD
            <img src="../Images/pic/RateImport-Q.gif" />
        </asp:View>

    </asp:MultiView>--%>
    <%--=======
            <div>
                <img src="../Images/pic/RateImport-Q.gif" style="width:500px; height:300px;"/>
            </div>                
        </asp:View>
        <asp:View ID="vOrder" runat="server"></asp:View>
    </asp:MultiView>
>>>>>>> origin/master--%>
</asp:Content>
