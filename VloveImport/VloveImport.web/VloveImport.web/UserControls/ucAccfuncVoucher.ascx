<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncVoucher.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncVoucher" %>
<br /><br />
<%--<span style="color: orange; font-size:x-large; font-weight:bold;">เปิดให้บริการเร็วๆนี้</span> --%>
<b>บัตรกำนัลของฉัน</b> : <b>    
<br />
<br />
<div class="row s8 m8 l8" style="border: 2px solid red;">    
    <div class="row s6 m6 l6"> 
        <asp:GridView ID="gvVoucher" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:ImageField DataImageUrlField="~/Images/pic/Voucher500.png" ItemStyle-Width="200px" ItemStyle-Height="200px"></asp:ImageField>
                <asp:BoundField DataField=""/>
            </Columns>
        </asp:GridView>       
        <div class="col s4 m4 l4">            
            <br />&nbsp;&nbsp;
            <asp:Image ID="img" runat="server" ImageUrl="~/Images/pic/Voucher500.png" BorderWidth="1px"
                Width="200px" Height="200px"/>
            <br />
            <br />
        </div>        
        <div class="col s6 m6 l6">
            <br />
            <br />
            <br />
            Voucher No.
            &nbsp;&nbsp; :
            &nbsp;&nbsp;
            <asp:Label ID="lb" runat="server" Text="VC00001"></asp:Label>
        </div>
    </div>    
</div>