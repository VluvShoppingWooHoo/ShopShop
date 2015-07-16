<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="VloveImport.web.Customer.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mOR1" class="mContent mIndex">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                กฏ กติกาในการสั่งซื้อ                
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <span class="bold">I love  import เป็นเพียงผู้นำเข้า จัดหา สั่งซื้อสินค้าจากจีนทุกชนิดตามความต้องการของลูกค้า
เท่านั้น ประเภทสินค้า เช่น เสื้อผ้าแฟชั่น กระเป๋า รองเท้า ของกิ๊ฟช็อป วิกผม เสื้อผ้าเด็ก ของเล่น ชุดแต่งงาน ตุ๊กตา อุปกรณ์ในสำนักงานและอุปกรณ์อื่นๆรวมถึงสินค้าใหญ่ เช่นเฟอร์นิเจอร์ ของตกแต่งบ้าน และอื่นๆเป็นต้น</span><br />
                <span class="bold textUnderline">ข้อควรทราบในการสั่งสินค้า</span><br />
                1.	ทางบริษัทต้องแจ้งให้ลูกค้าทราบอย่างละเอียดและชัดเจนเพื่อให้เกิดปัญหาที่อาจจะเกิดขึ้นระหว่างทางบริษัทกับลุกค้าให้น้อยที่สุด เราจึงต้องชัดเจน เพื่อการบริการที่สะอาดโปร่งใส<br />
                2.	ทางบริษัทขอแจง กฏ กติกาต่างๆให้ลุกค้าทราบถึงกฏ กติกา ขั้นตอนการสั่งซื้อให้ลูกค้าเข้าใจ เพราะทางบริษัทมีกระบวนการสั่งซื้อกับทางร้านจีนภายใต้กฏกติกาเดียวกันกับลูกค้า<br />
                3.	ทางบริษัทเป็นเพียงตัวกลางในการสั่งซื้อสินค้าเท่านั้น สินค้าที่ลุกค้าสั่งซื้อกับทางร้านจีน ทางบริษัทไม่มีโอกาสเห็น จึงไม่สามารถตรวจสอบคุณภาพสินค้าก่อน ดังนั้นจึงไม่รับเปลี่ยนสินค้าในกรณีที่ไม่ใช่ความผิดของทางบริษัท แต่ทางบรัษัทจะดำเนินการประสานงานร้านค้าเพื่อทวงสิทธิ์และผลประโยชน์ของลูกค้าให้อย่างเต็มความสามารถ<br />
                4.	เมื่อถึงกำหนดปิดรอบหรือทำการแจ้งโอนเงินเรียบร้อยแล้ว ทางบริษัทจะถือว่าทุกอย่างเสร็จพร้อมสั่งซื้อสินค้าได้เลย ไม่มีการแก้ไขๆในใบสั่งซื้อ กรุณาเลือกใบสั่งซื้อให้ถูกต้องตามประเภทและกรอกรายละเอียดครบถ้วน<br />
                5.	สินค้าบนเว็บไซด์จีนได้รับการตกแต่งเพื่อความดึงดูดความสนใจของลูกค้า และหลายๆเว็บไซด์ใช้ภาพแบบเดียวกัน ราคาต่างกัน คุณภาพอาจจะแต่งต่างกัน ขึ้นอยู่กับคุณภาพของสินค้า และภาพ่าวนใหญ่เป็นรูปภาพสินค้าชวยเชื่อซึ่งอาจจะนำภาพสินค้าจริงหรือสินค้าแบรนเนมหรือที่พบเห็นในหนังสือแฟชั่นทั่วไปมาประกอบการขาย เพื่อดึงดูดใจลุกค้า ทั้งนี้การเลือกสินค้าขึ้นอยู่กับลุกค้าเป็นผู้ตัดสินใจเอง<br />
                6.	ทางบริษัทเป็นเพียงตัวกลางในการสั่งซื้อเท่านั้นตังนั้นทางบริษัทไม่รับเปลี่ยนหรือคืนลูกค้า หากไม่ใช่ความผิดพลาดทางบริษัทจริงๆแต่ทางบริษัทจะดำเนินการประสานงานร้านค้าเพื่อทวงสิทธิ์และผลประโยชน์ของลูกค้าให้อย่างเต็มความสามารถ<br />
                7.	บางครั้งทางโรงงานอาจส่งสินค้ารุ่นเดียวกันแต่คนละสี หรือส่งสินค้ามาแทนเป็นรุ่นอื่นโดยเฉพาะแบบกิโล ทางบริษัทไม่รับเปลี่ยนหรือคืนสินค้าทุกกรณี คุณภาพสินค้าขึ้นอยู่กับทางร้านค้าที่จีนและการตัดสินใจเลือกร้านค้าเป็นความ รับผิดชอบของลูกค้าเอง<br />
                8.	ทางบริษัทเป็นเพียงตัวแทนนำเข้า ให้คำปรึกษาและนำเข้าเท่านั้น คุณภาพมีตั้งแต่แต่ 75-100% ตามราคา<br />
                9.	หากลูกค้าสั่งซื้อกับทางบริษัทฯ จะถือว่าลูกค้ายินยอมและยอมรับในข้อตกลงต่างๆ ข้างต้นในทุกกรณี<br />
                10.	ลูกค้าสามารถสั่งซื้อสินค้าสินค้าจีนผ่านหน้าเว็บออนไลน์ของบริษัท<br />
                <span class="indent">10.1 การสั่งซื้อกรณีสั่งสินค้าจาก Taobao.com, Tmall.com ,1688.com กรุณาเลือก สี,ไซส์ ให้ถูกต้องระบบสั่งสินค้าอัตโนมัติ</span><br />
                <span class="indent">10.2 การสั่งซื้อสินค้ากรณีสั่งสินค้าจาก 1688.com กรุณากรอกข้อมูลสินค้าให้ครบถ้วนเช่น สี,ไซส์ และจำนวน คำศัพท์ภาษาจีน</span><br />
                <br />
            </div>
        </div>
    </div>
    <div id="mOR2" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                ตัวอย่างศัพท์ภาษาจีน
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                ประเภทเสื้อผ้า  ผ้า<br />
                女装  เสื้อผ้าผู้หญิง<br />
                男装  เสื้อผ้าผู้ชาย<br />
                儿童装 เสื้อผ้าเด็ก<br />
                布料  ผ้า<br />
                床套  ชุดที่นอน<br />
                窗布  ผ้าม่าน<br />
                <br />
                รองเท้า<br />
                女鞋 รองเท้าผู้หญิง<br />
                男鞋   รองเท้าผู้ชาย<br />
                高跟   รองเท้าส้นสูง<br />
                儿童鞋   รองเท้าเด็ก<br />
                <br />
                กระเป๋า<br />
                女包  กระเป๋าผู้หญิง<br />
                男包   กระเป๋าผู้ชาย<br />
                小孩包  กระเป๋าเด็ก<br />
                <br />
                เครื่องเขียน<br />
                文具<br />
                ของขวัญ 礼物<br />
            </div>
        </div>
    </div>
    <div id="mOR3" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                การ Search หาสินค้า
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                ไม่รู้ภาษาจีน อ่านไม่ออก ไม่รู้ว่าแปลว่าอะไร หาของไม่เป็นคำเหล่านี้ไม่ยากอีกต่อแล้ว ทางบริษัทอำนวยความสะดวกมาให้แล้วหากจะดูและสั่งของได้ง่าย ลูกค้าสามารถโหลดโปรแกรมเข้าอินเตอร์เน็ต  Google Chome ติดตั้งบนคอมพิวเตอร์ของลูกค้า ตรงด้านบนเว็บไซด์จะมีการบริการแปลภาษาจีนให้เป็นภาษาไทย เท่านี้ลูกค้าก็สามารถอ่านรายละเอียดคร่าวได้แล้ว หรือหากลูกค้าท่านใดไม่ได้ติดตั้ง โปรแกรมเข้าอินเตอร์เน็ต  Google Chome ทางบริษัทได้มีบางส่วนอำนวยความสะดวกให้ลูกค้า
                <br />
                <%--<img src=""/>--%>
                <br />
                คลิกขวา แล้วเปลี่ยนภาษาเป็นภาษาไทย ดังภาพ<br />
            </div>
        </div>
    </div>
    <div id="mOR4" class="mContent">
        <div class="row">
            <div class="s12 m12 l12">
                <span class="ContentTitle"> วิธีสั่งซื้อสินค้าสำหรับลูกค้าที่สั่งแบบ ฝากจ่ายเงิน</span> &nbsp;&nbsp;
                <asp:ImageButton ID="imbYoutube" runat="server" PostBackUrl="https://youtu.be/BhldGynlIvY" 
                    ImageUrl="~/Images/icon/Youtube1.png" Width="50px" Height="50px"/>          
            </div>
            
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                การสั่งสินค้าแบบ ฝากจ่ายเงิน คือทางลูกค้าได้ทำการติดต่อร้านค้าเอง และต้องการให้ทางเราโอนเงินเพื่อชำระค่าสินค้าให้กับทางร้านค้า และใช้บริการของทาง i  Love import   ในการขนส่ง
                <br />
                <span class="bold">1: ไปที่เมนู "ส่งแบบฝากจ่าย"</span><br />
                <img src="../Images/HowTo/PI1.png" style="height: 289px; width: 286px;" /> &nbsp;&nbsp;
                <img src="../Images/HowTo/PI1-1.png" style="height: 298px; width: 285px;" />
                <br />
                <br />
                <span class="bold">2: กด "สร้างรายการใหม่"</span><br />
                <img src="../Images/HowTo/PI2.png" style="height: 88px; width: 367px;" />
                <br />
                <br />
                <span class="bold">3: กรอกรายละเอียดใบสั่งซื้อ และอัพโหลดใบ PI</span><br />
                <img src="../Images/HowTo/PI3.png" style="height: 378px; width: 619px;" />
                <br />
                <br />
                <span class="bold">4: เลือกวิธีการขนส่งสินค้า</span><br />
                <img src="../Images/HowTo/PI4.png" style="height: 665px; width: 390px;" />
                <br />
                <br />
                <span class="bold">5: ตรวจสอบข้อมูล และทำการยืนยันการฝากจ่ายสินค้า</span><br />
                <img src="../Images/HowTo/PI5.png" style="height: 646px; width: 545px;" />
                <br />
                <br />
                <span class="bold">ระบบจะทำการส่งออเดอร์ไปยังเจ้าหน้าที่อัตโนมัติ และทางเจ้าหน้าที่จำดำเนินการติดต่อประสานงาน สั่งซื้อในขั้นตอนต่อไป</span><br />
                <img src="../Images/HowTo/PI6.png" style="height: 260px; width: 750px;" />
                <br />
                <br />
                <span class="bold red-text">แจ้งก่อนสั่งซื้อ</span>
                <br />
                การสั่งซื้อแบบฝากจ่ายเงิน ลุกค้าต้องแจ้งข้อมูลให้ครบถ้วน เพื่อทางเราจะได้ติดต่อทางจีนได้อย่างรวดเร็ว<br />
                และการสั่งสินค้าแบบฝากจ่ายเงิน ทางเราจะไม่มีบริการเช็คสถานะสินค้า<br />
                ทุกครั้งที่สั่งซื้อสินค้า ลุกค้าสามารถยื่นคำร้องและแจ้งประเภทสินค้า จำนวนกิโล โดยประมาณ ทางเราจะแจ้งที่อยู่โกดังของเราให้ลูกค้าแจ้งทางโรงงานจีนได้เลย<br />
                หนึ่งออเดอร์/หนึ่งคำยื่น หากมีหลายออเดอร์กรุณาแจ้งและยื่นคำร้องอีกครั้ง<br />                                
            </div>
        </div>
    </div>
    <div id="mOR5" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                วิธีการฝากส่งสินค้าอย่างเดียว
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <span class="bold orange-text">• ระบบจะเป็นการให้สมาชิกแจ้งเลขแทร็กกิ้งทั้งหมดแล้วกดSubmit เข้าระบบให้ทางบริษัททราบ</span><br /><%--ช่องทางสมัครสมาชิก --%>
                <br />
                <span class="bold">1. ไปที่เมนู "ขนส่งอย่างเดียว" </span>      <br />          
                <img src="../Images/HowTo/Trans1.png" style="height: 298px; width: 286px;" /> &nbsp;&nbsp;
                <img src="../Images/HowTo/Trans1-1.png" style="height: 298px; width: 286px;" />
                <br />
                <br />
                <span class="bold">2: กด "สร้างรายการใหม่"</span><br />
                <img src="../Images/HowTo/Trans2.png" style="height: 88px; width: 367px;" />
                <br />
                <br />
                <span class="bold">3: กรอกรายละเอียดการขนส่ง แล้วกด เพิ่มรายการ</span><br />
                <img src="../Images/HowTo/Trans3.png" style="height: 322px; width: 530px;" />
                <br />
                <br />
                <span class="bold">เมื่อเพิ่มรายการครบแล้ว กด ดำเนินการต่อ</span><br />
                <img src="../Images/HowTo/Trans4.png" style="height: 261px; width: 538px;" />
                <br />
                <br />
                <span class="bold">4: เลือกวิธีการขนส่งสินค้า</span><br />
                <img src="../Images/HowTo/Trans5.png" style="height: 665px; width: 390px;" />
                <br />
                <br />
                <span class="bold">5: ตรวจสอบข้อมูล และทำการยืนยันการขนส่ง</span><br />
                <img src="../Images/HowTo/Trans6.png" style="height: 530px; width: 485px;" />
                <br />
                <br />
            </div>
        </div>
    </div>
    <div id="mOR6" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                วิธีการสั่งซื้อแบบ Grab Url 
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <span class="bold orange-text">• Step 1 สั่งสินค้าลงตะกร้า</span><br /><%--ช่องทางสมัครสมาชิก --%>
                <br />
                <span class="bold">1. Copy URL จากเว็ปเลือกซื้อสินค้า Taobao TMall 1688 </span>      <br />          
                <img src="../Images/HowTo/Basket1.png" style="height: 189px; width: 938px;" />
                <br />
                <br />
                <br />
                <span class="bold">2. Paste URL ลงในกล่องข้อความ แล้วกด Search</span>    <br />            
                <img src="../Images/HowTo/Basket2.png" style="height: 130px; width: 600px;" />
                <br />
                <br />
                <span class="bold">3. ทำการเลือก ขนาด/รูปแบบ สี และ จำนวน แล้วกดรูปตะกร้าสินค้า</span>    <br />            
                <img src="../Images/HowTo/Basket3.png" style="height: 500px; width: 600px;" />
                <br />
                <br />
                <span class="bold">4. ระบบจะแสดง Balloon พร้อมกับนำสินค้าลงสู่ตะกร้า</span>    <br />            
                <img src="../Images/HowTo/Basket4.png" style="height: 100px; width: 300px;" />
                <br />
                <br />
                <hr />
                <br />
                <span class="bold orange-text">• Step 2 เลือกสินค้าในตะกร้าเพื่อชำระเงิน</span><br /><%--ช่องทางสมัครสมาชิก --%>
                <br />
                <span class="bold">1. เลือกเมนู ตะกร้า </span>      <br />          
                <img src="../Images/HowTo/Order1.png" style="height: 107px; width: 521px;" />
                <br />
                <br />
                <span class="bold">2. เลือกสินค้าในตะกร้าที่ต้องการ แล้วกด สั่งสินค้า</span>    <br />            
                <img src="../Images/HowTo/Order2.png" style="height: 330px; width: 700px;" />
                <br />
                <br />
                <span class="bold">3. เลือกวิธีขนส่งสินค้า</span>    <br />            
                <img src="../Images/HowTo/Order3.png" style="height: 665px; width: 390px;" />
                <br />
                <br />
                <span class="bold">4. ตรวจสอบรายละเอียดใบสั่งซื้อ แล้วกด ยืนยัน</span>    <br />            
                <img src="../Images/HowTo/Order4.png" style="height: 480px; width: 700px;" />
                <br />
                <br />
                <span class="bold">5. ระบบจะแจ้งยอดเงินที่ต้องชำระ ให้ลูกค้ากรอกรหัสผ่านการชำระเงิน แล้วกด ชำระเงิน</span>    <br />            
                <span class="bold red-text">ในกรณีที่ไม่มีการตั้งค่า รหัสผ่านการชำระเงิน จะเป็นรหัสเดียวกับรหัสผ่านการเข้าระบบ</span>    <br />            
                <img src="../Images/HowTo/Order5.png" style="height: 330px; width: 493px;" />
                <br />
                <br />
            </div>
        </div>
    </div>
    <div id="mOR7" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                วิธีเติมเงินเข้าระบบ
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <span class="bold orange-text">•	การเติมเงิน</span><br />
                <br />
                <span class="bold">1. กดเมนู "กระเป๋าเงินของฉัน" </span>      <br />          
                <img src="../Images/HowTo/Topup1.png" style="height: 146px; width: 552px;" />
                <br />
                <br />
                <br />
                <span class="bold">2. เลือก "เติมเงิน"</span>    <br />            
                <img src="../Images/HowTo/Topup2.png" style="height: 190px; width: 510px;" />
                <br />
                <br />
                <br />
                <span class="bold">3. กรอกข้อมูลให้ครบถ้วน</span>    <br />            
                <img src="../Images/HowTo/Topup3.png" style="height: 300px; width: 580px;" />
                <br />
                <br />
                <br />
                <span class="bold">4. เมื่อกด Submit ระบบจะแสดงข้อความ "เติมเงินสำเร็จ"</span>    <br />            
                <img src="../Images/HowTo/Topup4.png" style="height: 164px; width: 364px;" />
                <br />
                <br />
                <br />
                <span class="bold">เมื่อทาง ผู้ดูแลระบบ ทำการอนุมัติการเติมเงิน เงินจะเข้าสู่ระบบ</span>    <br />  
                <img src="../Images/HowTo/Topup5.png" style="height: 185px; width: 490px;" />  
                <br />
            </div>
        </div>
    </div>
    <div id="mOR8" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                รายละเอียดขั้นตอนการชำระเงิน
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                ทาง i Love import มีวิธีการจ่ายเงิน 2 แบบ<br />
                <span class="indent">1.	แบบที่ 1 จ่ายแบบเต็มจำนวน โดยทาง i Love import จะคิดคำนวนค่าขนส่งตั้งแต่ราคาสินค้า ราคาขนส่งในจีน ราคาขนส่งมาไทย ค่าบริการนำส่ง ค่าขนส่งเอกชน จนถึงหน้าบ้าน</span>
                <br />
                <span class="indent">2.	แบบที่ 2 แบบแบ่งจ่าย 2 ครั้ง โดยครั้งที่ 1 จ่ายค่าสินค้าและค่าส่งในจีน ซึ่งทาง i Love import ได้ทำการเรียกเก็บต่าขนส่งจีน ในเรท 7 % ของราคาสินค้า ใอการสั่งซื้อเสร็จสิ้น ยอดเงินคงเหลือจะแจ้งยอดในรายการใบสั่งซื้อ</span><br />
                สูตรง่ายๆ สำหรับการคำนวนค่าบริการทั้งหมดกับ i Love import  แบบจ่ายครั้งเดียว<br />
                (ค่าสินค้า + ค่าขนส่งสินค้าจากร้านค้าจีนไปที่โกดังที่จีนของ i Love import ) xเรทเงินแลกเปลี่ยน<br />
                <span class="indent">+ ค่าขนส่งสินค้าจากโกดังจีนมาที่โกดัง i Love import  ในไทย(ขนส่งทางรถ หรือขนส่งทางเรือ)</span><br />
                <span class="indent">+ ค่าขนส่งในประเทศถึงบ้านหรือร้านค้าลูกค้า + ค่าบรรจุภัณฑ์(ถ้ามี)</span><br />
                <br />
                สูตรง่ายๆ สำหรับการคำนวนค่าบริการ i Love import  แบบแบ่งจ่าย 2 ครั้ง<br />
                ครั้งที่ 1  (ค่าสินค้า)xเรทเงินแลกเปลี่ยน<br />
                ครั้งที่ 2 (ค่าขนส่งสินค้าจากร้านค้าจีนไปที่โกดังที่จีนของ i Love import ) xเรทเงินแลกเปลี่ยน(เรทเดียวกันกับเรทที่สั่งซื้อสินค้า)<br />
                <span class="indent">+ ค่าขนส่งสินค้าจากโกดังจีนมาที่โกดัง i Love import  ในไทย(ขนส่งทางรถ หรือขนส่งทางเรือ)</span><br />
                <span class="indent">+ ค่าขนส่งในประเทศถึงบ้านหรือร้านค้าลูกค้า + ค่าบรรจุภัณฑ์(ถ้ามี) + ค่าบริการนำส่ง</span><br />
                ราคาสินค้าหน้าเว็บเป็นไปตามจริงหน้าเว็บ ทางเราจะไม่มีการบวกเพิ่ม และหากในหน้าเว็บจีนไม่มีค่าขนส่งในจีน ทางคาร์โก้จะไม่นำมาคำนวน ยกเว้นแต่มีค่าขนส่งในจีนเกิดขึ้นเท่านั้น<br />
                ค่าขนส่ง จากร้านค้าในจีน ถึง โกดังส่งของในจีน<br />
                ค่าขนส่งในจีนเริ่มต้นกิโลกรัมแรกโดยประมานอยู่ที่ 8 -15 หยวน หลังจากนั้นกิโลกรัมละ 3 หยวน<br />
            </div>
        </div>
    </div>
    <div id="mOR9" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                วิธีการชำระเงินและแจ้งยืนยันการชำระเงิน
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <span class="bold">1. ตรวจสอบยอดสินค้าที่ต้องชำระ</span><br />
                เมื่อทางเจ้าหน้าที่ Customer Service ของ i  Love import  ได้รับข้อมูลการสั่งซื้อสินค้าของคุณแล้ว ระบบจะทำการคำนวนค่าสินค้าและค่าส่งในจีนอัตโนมัติไปในรายการสั่งซื้อ โดยลูกค้าสามารถทำการแจ้งโอนเงินได้ทันที
รวมถึงการแจ้งไปยัง E-mail ของลูกค้า ซึ่งลูกค้าสามารถตรวจสอบได้ด้วยตนเอง<br />
                หมายเหตุ:  ในหนึ่งเลขที่ออเดอร์มีระยะเวลา 72 ชั่วโมง หากลูกค้าชำระช้าเกินกำหนดระบบจะทำการยกเลิกออเดอร์อัตโนมัติ ดังนั้นลูกค้าต้องทำการกดสั่งซื้อเข้ามาใหม่<br />
                <span class="bold">2. โอนเข้าบัญชีธนาคาร</span><br />
                ลูกค้าสามารถชำระค่าสินค้า ผ่านเครื่อง ATM ของทุกธนาคารใกล้บ้านท่าน หรือที่เคาน์เตอร์ ธนาคารไทยพาณิชย์, ธนาคารกสิกรไทย,
ธนาคารกรุงเทพ ธนาคารกรุงไทย และยังสามารถชำระผ่านช่องทางออนไลน์ของธนาคารได้ตลอด 24 ชั่วโมง
                <br />
                <span class="bold">3. แจ้งยืนยันโอนเงิน</span><br />
                หลังโอนเงินแล้ว ลูกค้าสามารถแจ้งยืนยันการโอนเงิน และกดเติมเงินเข้ามาในระบบได้ด้วยตนเอง<br />
                <span class="oblique">* กรุณาเก็บ Slip เพื่อเป็นหลักฐาน งดแจ้งการโอนเงินทางโทรศัพท์เพื่อป้องกันการผิดพลาด</span><br />
            </div>
        </div>
    </div>
    <div id="mOR10" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                วิธีถอนเงินในระบบ
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <span class="bold orange-text">•	การถอนเงิน</span><br />
                <br />
                <span class="bold">1. กดเมนู "กระเป๋าเงินของฉัน" </span>      <br />          
                <img src="../Images/HowTo/WithDraw1.png" style="height: 146px; width: 552px;" />
                <br />
                <br />
                <br />
                <span class="bold">2. เลือก "ถอนเงิน"</span>    <br />            
                <img src="../Images/HowTo/WithDraw2.png" style="height: 188px; width: 521px;" />
                <br />
                <br />
                <br />
                <span class="bold">3. กรอกข้อมูลให้ครบถ้วน</span>    <br />            
                <img src="../Images/HowTo/WithDraw3.png" style="height: 260px; width: 580px;" />
                <br />
                <br />
                <br />
                <span class="bold">4. เมื่อกด Submit ระบบจะแสดงข้อความ "ส่งคำขอถอนเงินสำเร็จ"</span>    <br />            
                <img src="../Images/HowTo/WithDraw4.png" style="height: 164px; width: 364px;" />
                <br />
                <br />
                <span class="bold">เมื่อทาง ผู้ดูแลระบบ ทำการอนุมัติการถอนเงินแล้ว เงินจะถูกตัดจากระบบ</span>  
                <br />
            </div>
        </div>
    </div>
    <div id="mOR11" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                ตารางไซส์เครื่องแต่งกาย
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>เสื้อผ้าผู้หญิง (ตัวบน)</th>
                            <th colspan="5"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>เสื้อตัวบน</td>
                            <td>S</td>
                            <td>M</td>
                            <td>L</td>
                            <td>XL</td>
                            <td>XXL</td>
                            <td>XXXL</td>
                        </tr>
                        <tr>
                            <td>ขนาดเสื้อ</td>
                            <td>38</td>
                            <td>40</td>
                            <td>42</td>
                            <td>44</td>
                            <td>46</td>
                            <td>48</td>
                        </tr>
                        <tr>
                            <td>รอบอก(cm)</td>
                            <td>78-81</td>
                            <td>82-85</td>
                            <td>86-89</td>
                            <td>90-93</td>
                            <td>94-97</td>
                            <td>98-102</td>
                        </tr>
                        <tr>
                            <td>รอบเอว(cm)</td>
                            <td>62-66</td>
                            <td>67-70</td>
                            <td>71-74</td>
                            <td>75-79</td>
                            <td>80-84</td>
                            <td>85-89</td>
                        </tr>
                        <tr>
                            <td>ไหล่(cm)</td>
                            <td>36</td>
                            <td>38</td>
                            <td>40</td>
                            <td>42</td>
                            <td>44</td>
                            <td>46</td>
                        </tr>
                        <tr>
                            <td>ความสูงที่เหมาะสม(cm	)</td>
                            <td>153/157</td>
                            <td>158/162</td>
                            <td>163/167</td>
                            <td>168/172</td>
                            <td>173/177</td>
                            <td>177/180</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女裤 กระโปรงผู้หญิง</th>
                            <th colspan="6"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>24</td>
                            <td>26</td>
                            <td>27</td>
                            <td>28</td>
                            <td>29</td>
                            <td>30</td>
                            <td>31</td>
                        </tr>
                        <tr>
                            <td>对应臀（cm）รอบสะโพก(cm)</td>
                            <td>80</td>
                            <td>87</td>
                            <td>90</td>
                            <td>93</td>
                            <td>97</td>
                            <td>100</td>
                            <td>103</td>
                        </tr>
                        <tr>
                            <td>对应腰围（市尺）รอบเอว	</td>
                            <td>1.8 ฟุต</td>
                            <td>1.9 ฟุต</td>
                            <td>2 ฟุต</td>
                            <td>2.1 ฟุต</td>
                            <td>2.2 ฟุต</td>
                            <td>2.3 ฟุต</td>
                            <td>2.4 ฟุต</td>
                        </tr>
                        <tr>
                            <td>对应腰围(cm) ขนาดรอบเอว(cm)</td>
                            <td>59</td>
                            <td>63</td>
                            <td>67</td>
                            <td>70</td>
                            <td>74</td>
                            <td>78</td>
                            <td>82</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女式背心 เสื้อชั้นในสตรี</th>
                            <th colspan="4"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>S</td>
                            <td>M</td>
                            <td>L</td>
                            <td>XL</td>
                            <td>3L</td>
                        </tr>
                        <tr>
                            <td>胸围 รอบอก</td>
                            <td>72-80</td>
                            <td>79-87</td>
                            <td>86-94</td>
                            <td>94-97</td>
                            <td>98-102</td>
                        </tr>
                        <tr>
                            <td>腰围 รอบเอว</td>
                            <td>58-64</td>
                            <td>64-70</td>
                            <td>69-77</td>
                            <td>77-85</td>
                            <td>85-93</td>
                        </tr>
                        <tr>
                            <td>臀围 สะโพก</td>
                            <td>82-90</td>
                            <td>87-95</td>
                            <td>92-100</td>
                            <td>97-105</td>
                            <td>102-110</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女式内裤 กางเกงในสตรี</th>
                            <th colspan="4"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>S</td>
                            <td>M</td>
                            <td>L</td>
                            <td>XL</td>
                            <td>3L</td>
                        </tr>
                        <tr>
                            <td>胸围 รอบอก</td>
                            <td>150-155</td>
                            <td>155-160</td>
                            <td>160-165</td>
                            <td>165-170</td>
                            <td>170-175</td>
                        </tr>
                        <tr>
                            <td>腰围 รอบเอว</td>
                            <td>55-61</td>
                            <td>61-67</td>
                            <td>67-73</td>
                            <td>73-79</td>
                            <td>79-85</td>
                        </tr>
                        <tr>
                            <td>臀围 สะโพก</td>
                            <td>80-86</td>
                            <td>85-93</td>
                            <td>90-98</td>
                            <td>95-103</td>
                            <td>100-108</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女式泳装 ชุดว่ายน้ำสตรี</th>
                            <th colspan="4"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>XS/32</td>
                            <td>S/34</td>
                            <td>M/36</td>
                            <td>L/38</td>
                            <td>XL/40</td>
                        </tr>
                        <tr>
                            <td>腰围 รอบเอว</td>
                            <td>63-70</td>
                            <td>70-76</td>
                            <td>80-86</td>
                            <td>86-93</td>
                            <td>93-100</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女鞋 รองเท้าผู้หญิง</th>
                            <th colspan="6"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>光脚长度(cm) ความยาวเท้าเปล่า(cm)</td>
                            <td>22.0</td>
                            <td>22.5</td>
                            <td>23.0</td>
                            <td>23.5</td>
                            <td>24.0</td>
                            <td>24.5</td>
                            <td>25.0</td>
                        </tr>
                        <tr>
                            <td>鞋码(中国) ขนาดรองเท้า(ประเทศจีน)</td>
                            <td>34码</td>
                            <td>35码</td>
                            <td>36码</td>
                            <td>37码</td>
                            <td>38码</td>
                            <td>39码</td>
                            <td>40码</td>
                        </tr>
                        <tr>
                            <td>鞋码(美国) ขนาดรองเท้า(US)</td>
                            <td>4.5</td>
                            <td>5</td>
                            <td>5.5</td>
                            <td>6</td>
                            <td>6.5</td>
                            <td>7</td>
                            <td>7.5</td>
                        </tr>
                        <tr>
                            <td>鞋码(英国) ขนาดรองเท้า(อังกฤษ)</td>
                            <td>3.5</td>
                            <td>4</td>
                            <td>4.5</td>
                            <td>5</td>
                            <td>5.5</td>
                            <td>6</td>
                            <td>6.5</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女裙 กางเกงผู้หญิง</th>
                            <th colspan="6"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>24</td>
                            <td>26</td>
                            <td>27</td>
                            <td>28</td>
                            <td>29</td>
                            <td>30</td>
                            <td>31</td>
                        </tr>
                        <tr>
                            <td>对应臀围（市尺）รอบสะโพก</td>
                            <td>2.4 ฟุต</td>
                            <td>2.6 ฟุต</td>
                            <td>2.7 ฟุต</td>
                            <td>2.8 ฟุต</td>
                            <td>2.9 ฟุต</td>
                            <td>3 ฟุต</td>
                            <td>3.1 ฟุต</td>
                        </tr>
                        <tr>
                            <td>对应臀围（cm）สะโพก</td>
                            <td>80</td>
                            <td>87</td>
                            <td>90</td>
                            <td>93</td>
                            <td>97</td>
                            <td>100</td>
                            <td>103</td>
                        </tr>
                        <tr>
                            <td>对应腰围（市尺）รอบเอว</td>
                            <td>1.8 ฟุต</td>
                            <td>1.9 ฟุต</td>
                            <td>2 ฟุต</td>
                            <td>2.1 ฟุต</td>
                            <td>2.2 ฟุต</td>
                            <td>2.3 ฟุต</td>
                            <td>2.4 ฟุต</td>
                        </tr>
                        <tr>
                            <td>对应腰围（cm）รอบเอว</td>
                            <td>59</td>
                            <td>63</td>
                            <td>67</td>
                            <td>71</td>
                            <td>74</td>
                            <td>78</td>
                            <td>82</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女式衬衫 เสื้อสตรี</th>
                            <th colspan="3"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>S</td>
                            <td>M</td>
                            <td>L</td>
                            <td>XL</td>
                        </tr>
                        <tr>
                            <td>领围(cm) คอ</td>
                            <td>36-37</td>
                            <td>37-38</td>
                            <td>39-40</td>
                            <td>41-42</td>
                        </tr>
                        <tr>
                            <td>国际领围(英寸) คอแบบมาตรฐาน(แบบอังกฤษ)</td>
                            <td>14-14.5</td>
                            <td>14.5-15</td>
                            <td>15.5-16</td>
                            <td>16-16.5</td>
                        </tr>
                        <tr>
                            <td>肩宽(cm) ไหล่กว้าง</td>
                            <td>36.5</td>
                            <td>37.5</td>
                            <td>38.5</td>
                            <td>39.5</td>
                        </tr>
                        <tr>
                            <td>胸围(cm) หน้าอก</td>
                            <td>87</td>
                            <td>91</td>
                            <td>95</td>
                            <td>99</td>
                        </tr>
                        <tr>
                            <td>长袖/短袖袖长(cm) แขนยาว / แขนสั้นแขนยาว (ซม.)</td>
                            <td>60/21</td>
                            <td>61/22</td>
                            <td>62/23</td>
                            <td>63/24</td>
                        </tr>
                        <tr>
                            <td>后衣长(cm) ความยาวหลังเสื้อ (ซม.)</td>
                            <td>54-73</td>
                            <td>56-75</td>
                            <td>58-77</td>
                            <td>60-79</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>ชุดชั้นในผู้หญิง ขนาดหน้าอก</th>
                            <th colspan="12"></th>
                        </tr>
                        <tr>
                            <th>ขนาดมาตรฐาน</th>
                            <th colspan="12"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>ประเทศจีน (cm)</td>
                            <td>A</td>
                            <td>B</td>
                            <td>C</td>
                            <td>D</td>
                            <td>E</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>อเมริกา</td>
                            <td>AA</td>
                            <td>A</td>
                            <td>B</td>
                            <td>C</td>
                            <td>D</td>
                            <td>DD</td>
                            <td>DDD/E</td>
                            <td>F</td>
                            <td>FF</td>
                            <td>G</td>
                            <td>GG</td>
                            <td>H</td>
                            <td>HH</td>
                        </tr>
                        <tr>
                            <td>อังกฤษ</td>
                            <td>AA</td>
                            <td>A</td>
                            <td>B</td>
                            <td>C</td>
                            <td>D</td>
                            <td>DD</td>
                            <td>E</td>
                            <td>F</td>
                            <td>FF</td>
                            <td>G</td>
                            <td>GG</td>
                            <td>H</td>
                            <td>HH</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>臀围 สะโพก</th>
                            <th colspan="3"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>S</td>
                            <td>M</td>
                            <td>L</td>
                            <td>XL</td>
                        </tr>
                        <tr>
                            <td>范围 รอบสะโพก</td>
                            <td>80-88cm (~34 นิ้ว)</td>
                            <td>85-93cm（~36 นิ้ว)</td>
                            <td>90-98cm（~ 38 นิ้ว)</td>
                            <td>100-108cm（~42 นิ้ว)</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>กางเกง</th>
                            <th colspan="2"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>M</td>
                            <td>L</td>
                            <td>XL</td>
                        </tr>
                        <tr>
                            <td>身高(cm) ส่วนสูง</td>
                            <td>150-160</td>
                            <td>150-165</td>
                            <td>160-170</td>
                        </tr>
                        <tr>
                            <td>臀围(cm) สะโพก</td>
                            <td>85-93</td>
                            <td>90-98</td>
                            <td>95-103</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女式棉毛内衣 ชุดชั้นในผ้าฝ้ายสตรี</th>
                            <th colspan="4"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>S 85</td>
                            <td>M 90</td>
                            <td>L 95</td>
                            <td>XL 100</td>
                            <td>XXL 105</td>
                        </tr>
                        <tr>
                            <td>胸围 หน้าอก</td>
                            <td>81-89</td>
                            <td>86-94</td>
                            <td>91-99</td>
                            <td>96-104</td>
                            <td>101-109</td>
                        </tr>
                        <tr>					
                            <td>身高 ส่วนสูง</td>
                            <td>150-160</td>
                            <td>155-165</td>
                            <td>160-170</td>
                            <td>165-175</td>
                            <td>170-180</td>
                        </tr>
                        <tr>
                            <td>臀围 สะโพก</td>
                            <td>81-89</td>
                            <td>86-94</td>
                            <td>91-99</td>
                            <td>96-104</td>
                            <td>101-109</td>
                        </tr>					
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>女式家居休闲服 เสื้อผ้าลำลองสตรีที่บ้าน</th>
                            <th colspan="3"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>M</td>
                            <td>L</td>
                            <td>XL</td>
                            <td>XXL</td>
                        </tr>
                        <tr>
                            <td>胸围 หน้าอก</td>
                            <td>105-110</td>
                            <td>110-115</td>
                            <td>115-120</td>
                            <td>120-125</td>
                        </tr>
                        <tr>
                            <td>身高（cm）ส่วนสูง</td>
                            <td>150-160</td>
                            <td>150-165</td>
                            <td>160-170</td>
                            <td>165-175</td>
                        </tr>
                        <tr>
                            <td>臀围(cm) สะโพก</td>
                            <td>105-110</td>
                            <td>110-115</td>
                            <td>115-120</td>
                            <td>120-125</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
                <table class="centered hoverable">
                    <thead>
                        <tr>
                            <th>户外男女袜子 ถุงเท้า ชายหญิง</th>
                            <th colspan="2"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>尺码 ขนาด</td>
                            <td>S</td>
                            <td>M</td>
                            <td>L</td>
                        </tr>
                        <tr>
                            <td>范围</td>
                            <td>35-39</td>
                            <td>39-41</td>
                            <td>42-44</td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <br />
            </div>
        </div>
    </div>
    <div id="mOR12" class="mContent">
        <div class="row">
            <div class="s12 m12 l12 ContentTitle">
                วิธีการสมัครสมาชิก
            </div>
        </div>
        <div class="row">
            <div class="s12 m12 l12">
                <span class="bold orange-text">•	ลูกค้าสามารถสมัครสมาชิก &nbsp;i Love import โดยไม่มีค่าใช้จ่าย</span><br /><%--ช่องทางสมัครสมาชิก --%>
                <br />
                <span class="bold">1. กดสมัครสมาชิก</span>      <br />          
                <img src="../Images/HowTo/RegisStep1.png" style="height: 300px; width: 700px;" />
                <br />
                <br />
                <br />
                <span class="bold">2. กรอกข้อมูลให้ครบถ้วน</span>    <br />            
                <img src="../Images/HowTo/RegisStep2.png" style="height: 450px; width: 550px;" />
                <br />
                <br />
                <span class="bold">1 อีเมล์ สมัครสมาชิกได้เพียง 1 ครั้งเท่านั้น</span>    <br />            
                <img src="../Images/HowTo/RegisStep3.png" style="height: 70px; width: 500px;" />
                <br />
                <br />
                <span class="bold">3. อ่านเงื่อนไข และกดยอมรับเงื่อนไขการเป็นสมาชิก</span>    <br />            
                <img src="../Images/HowTo/RegisStep4.png" style="height: 200px; width: 500px;" />
                <br />
                <br />
                <span class="bold">4. กดปุ่ม Register</span>   <br />          
                <img src="../Images/HowTo/RegisStep5.png" style="height: 58px; width: 145px;" />
                <br />
                <br />
                <span class="bold">เมื่อการสมัครสำเร็จ ระบบจะส่งข้อมูลสมาชิกไปที่อีเมล์ของคุณ</span>   <br />          
                <img src="../Images/HowTo/RegisStep6.png" style="height: 124px; width: 464px;" />
                <br />
                <br />
                <hr />
                <br />
                <span class="bold orange-text">•	การยืนยันการสมัครสมาชิก</span><br />
                <span class="bold black-text indent">ทาง iLoveImport จะส่งอีเมล์ไปยังอีเมล์ของคุณ เพื่อให้คุณทำการยืนยันตัวตน</span><br />
                <br />
                <span class="bold">1. เปิดอีเมล์ที่คุณได้ทำการลงทะเบียนไว้</span>      <br />          
                <img src="../Images/HowTo/ConfirmRegis1.png" style="height: 230px; width: 700px;" />
                <br />
                <br />
                <br />
                <span class="bold">2. คลิ๊กที่ URL ด้านล่าง เพื่อทำการยืนยันการเป็นสมาชิก</span>      <br />          
                <img src="../Images/HowTo/ConfirmRegis2.png" style="height: 230px; width: 700px;" />
                <br />
                <br />
                <br />
                <span class="bold">3. iLoveImport จะตรวจสอบและแสดงผลการยืนยัน</span>      <br />  <br />        
                <img src="../Images/HowTo/ConfirmRegis3.png" style="height: 161px; width: 326px;" />
                <br />
                <br />
                <br />
                <%--<span class="bold">เงื่อนไขสมาชิกเว็บไซต์  (เนื้อหาเงื่อนไข)</span>
                <br />
                
                โปรดอ่านและทำความเข้าใจข้อตกลงข้างล่างนี้โดยละเอียดก่อนสมัครเป็นสมาชิก เพื่อรักษาสิทธิประโยชน์ในการใช้บริการของท่าน
                <br />
                <span class="indent">1.	ผู้สมัครสมาชิกต้องกรอกข้อมูลให้ครบถ้วน และตรงตามเป็นจริง เพื่อสิทธิประโยชน์ของท่านเอง หากตรวจสอบพบว่าข้อมูลของท่านที่ให้มาเป็นเท็จ ทางระบบจะยกเลิกการเป็นสมาชิกของท่านทันที โดยไม่ต้องแจ้งให้ทราบล่วงหน้า</span><br />
                <span class="indent">2.	สมาชิกต้องปฏิบัติตามกฏระเบียบและข้อตกลงของบอร์ดอย่างเคร่งครัดเพื่อความสงบเรียบร้อย ในกรณีที่สมาชิกละเมิดกฏ Admin และผู้ดูแลเว็บบอร์ด มีสิทธิ์ยกเลิกการเป็นสมาชิกได้โดยไม่แจ้งให้ทราบล้วงหน้า</span><br />
                <span class="indent">3.	เพื่อความเป็นส่วนตัวและความปลอดภัยในข้อมูลของสมาชิกเอง ผู้ดูแลเว็บบอร์ดขอแจ้งให้สมาชิกทราบว่า เป็นหน้าที่ของสมาชิกในการรักษาชื่อ Login และ Password ของสมาชิกให้ดี โดยไม่บอกให้ผู้อื่นทราบ</span><br />
                <span class="indent">4.	ข้อมูลของสมาชิกจะถูกเก็บเป็นความลับอย่างสูงสุด ผู้ดูแลเว็บบอร์ดจะไม่เปิดเผยข้อมูลของสมาชิกเพื่อประโยชน์ทางการค้า หรือเพื่อประโยชน์ในด้านอื่น ๆ ทั้งสิ้น</span><br />--%>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>
