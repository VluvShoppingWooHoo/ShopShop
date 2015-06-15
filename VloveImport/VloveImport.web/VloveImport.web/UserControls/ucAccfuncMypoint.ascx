<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncMypoint.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncMypoint" %>
<br /><br />
<%--<span style="color: orange; font-size:x-large; font-weight:bold;">เปิดให้บริการเร็วๆนี้</span> --%>
<b>คะแนนสะสมปัจจุบัน</b> : <b>
    <asp:Label ID="lbMyPoint" runat="server"></asp:Label> คะแนน</b>
<br />
<br />
<b>
    <span style="color: red;">การสะสมคะแนน : ยอดการสั่งซื้อ ฝากจ่าย ฝากส่ง ทุกๆ 1000 บาท รับ 1 คะแนน
        <%--หากลูกค้าต้องการชำระบิล กรุณากดเมนู “ชำระเงิน” ที่หน้ารายการสั่งซื้อคะ--%>
        <br />
        <br />
        เงินจะเข้าระบบก็ต่อเมื่อ ได้รับการตรวจสอบจากผู้ดูแลเรียบร้อยแล้ว
        <%--การชำระเงิน : เป็นการเลือกชำระเงินในบิลนั้นๆ ระบบจะทำการสั่งซื้อให้หลังจากได้รับยืนยันการชำระบิลจากลูกค้า--%>
    </span>
</b>
<br />
<br />
<div style="border: 2px solid #959595; background-color: #F5F5F5; vertical-align: middle; width: 60%; height: 60px;">
    <div style="margin-top: 10px;">
        1.เลือกธนาคารที่ท่านสะดวกในการเติมเงิน<br />
        2.ระบุวิธีการเติมเงิน และจำนวนเงินที่เติม หลังจากนั้น ระบุวิธีการแจ้งการเติมเงิน
    </div>
</div>
<br />
<div style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 30%; height: 50px;">
    <br />
    <div style="margin-left: 10px;">
        <b>เลือก I LOVE IMPORT ธนาคาร</b>
    </div>
</div>
<div style="vertical-align: middle; width: 40%; height: 50px; margin-left: 32%; margin-top: -40px;">
    <div style="margin-left: 10px;">
        <asp:DropDownList ID="ddlBank" DataTextField="BANK_SHOP_ACCOUNT_NO" DataValueField="BANK_SHOP_ID" runat="server"
            CssClass="dpBlock ddlBank" Width="350px">
        </asp:DropDownList>
    </div>
</div>