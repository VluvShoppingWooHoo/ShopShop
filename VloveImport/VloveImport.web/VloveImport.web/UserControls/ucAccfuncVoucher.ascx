<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncVoucher.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncVoucher" %>
<br /><br />
<%--<span style="color: orange; font-size:x-large; font-weight:bold;">เปิดให้บริการเร็วๆนี้</span> --%>
<b>คะแนนสะสมปัจจุบัน</b> : <b>
    <asp:Label ID="lbMyPoint" runat="server"></asp:Label> คะแนน</b>
<br />
<br />
<b>
    <span style="color: red;">การสะสมคะแนน : ยอดการสั่งซื้อ ฝากจ่าย ฝากส่ง ทุกๆ 1000 บาท รับ 1 คะแนน
    </span>
</b>
<br />
<br />
<div class="row s8 m8 l8" style="border: 2px solid red;">    
    <div class="col s4 m4 l4">
        <br />&nbsp;&nbsp;
        <asp:Image ID="img" runat="server" ImageUrl="~/Images/pic/Voucher500.png" BorderWidth="1px"
            Width="200px" Height="200px"/>
        <br />
        <br />
    </div>
    <div class="col s8 m8 l8">
        <br /><br /><br /><br />
        <span style="color: black; font-size: 20px !important; font-weight:bold;">ใช้ 100 Point เพื่อแลก Voucher 500 บาท</span>
        <br />
        <br />
        <button type="button" class="btn waves-effect orange waves-light" name="action">
        <asp:Button ID="btnVoucher500" runat="server" Text="แลก Voucher" OnClick="btnVoucher500_Click"/>
        </button>
    </div>
</div>