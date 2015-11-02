<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerPayment.aspx.cs" Inherits="VloveImport.web.Customer.CustomerPayment" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s12 m12 l12 TestBox1">
            <span class="FontHeader bold">การชำระเงิน</span>
            <br /><br />            
        </div>
    </div>
    <div class="row">
        <div class="col s2 m2 l2">           
            <span class="black-text FontHeader2">รหัสใบสั่งซื้อ</span>
        </div>        
        <div class="col s3 m3 l3 right-align">  
            <asp:HyperLink ID="hlOrderCode" runat="server" CssClass="lbCaption margin0"></asp:HyperLink>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col s2 m2 l2">           
            <span class="black-text FontHeader2">ยอดที่ต้องชำระ</span>
        </div>        
        <div class="col s3 m3 l3 right-align">  
            <asp:Label ID="lbTotalAmount" runat="server" CssClass="lbCaption"></asp:Label>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col s2 m2 l2">           
            <span class="black-text FontHeader2">เงินในบัญชี</span>
        </div>        
        <div class="col s3 m3 l3 right-align">  
            <asp:Label ID="lbBalance" runat="server" CssClass="lbCaption"></asp:Label>
            <%--<a href="CustomerMyAccount.aspx">เติมเงิน</a>--%>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col s2 m2 l2">           
            <span class="black-text FontHeader2">เลือกใช้ Voucher</span>
        </div>        
        <div class="col s3 m3 l3 right-align">             
            <asp:DropDownList ID="ddlVoucher" runat="server" AppendDataBoundItems="true" AutoPostBack="true"
                Style="display: inline;" OnSelectedIndexChanged="ddlVoucher_SelectedIndexChanged">
            </asp:DropDownList>  
            <br />
            <asp:Label ID="lbVoucher" runat="server"></asp:Label>         
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col s2 m2 l2">           
            <span class="black-text FontHeader2">รหัสผ่านการชำระเงิน</span>
        </div>        
        <div class="col s3 m3 l3 right-align">  
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>            
        </div>
    </div>
    <div class="row">
        <div class="col s5 m5 l5 right-align">
            <asp:Label ID="lbWarn" runat="server" Text="ถ้าไม่ตั้งค่ารหัสการถอนเงิน/ชำระเงิน ให้ใช้รหัสการเข้าสู่ระบบในการชำระเงิน"></asp:Label>         
        </div>
    </div>
    <br />
    <div class="row">        
        <asp:GridView ID="gvTran" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="TRAN_DATE" HeaderText="วันที่ชำระเงิน" />
                <asp:BoundField DataField="TRAN_AMOUNT" HeaderText="จำนวนเงิน" />
                <asp:BoundField DataField="TRAN_STATUS_DESC" HeaderText="สถานะ" />
                <asp:BoundField DataField="TRAN_REMARK" HeaderText="หมายเหตุ" />
            </Columns>
        </asp:GridView>
        <br />
        <button id="btnBack" runat="server" type="submit" onserverclick="btnBack_ServerClick"
            name="action" class="btn waves-effect orange waves-light">ย้อนกลับ                                
        </button> 
        <button id="btnPayment" runat="server" type="submit" onserverclick="btnPayment_ServerClick"
            name="action" class="btn waves-effect orange waves-light">ชำระเงิน                                
        </button>  
        <button id="btnTopup" runat="server" type="submit" onserverclick="btnTopup_ServerClick"
            name="action" class="btn waves-effect orange waves-light">เติมเงิน                                
        </button> 
    </div>

    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>
