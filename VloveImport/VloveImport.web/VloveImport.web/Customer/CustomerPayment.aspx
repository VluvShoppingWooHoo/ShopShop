<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerPayment.aspx.cs" Inherits="VloveImport.web.Customer.CustomerPayment" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s12 m12 l12 TestBox1">
            เลือกวิธีการชำระเงิน
            <br />
            <div class="row s6 m6 l6 TestBox1">
                <asp:HiddenField ID="hdOID" runat="server" />
                <br />
                <asp:RadioButton ID="rdbPayment1" runat="server" GroupName="Payment" Checked="true" CssClass="Init"/>
                &nbsp;ชำระเงินรอบเดียว (ค่าสินค้าและค่าขนส่งทั้งหมด)
            <br />
                <asp:RadioButton ID="rdbPayment2" runat="server" GroupName="Payment"  CssClass="Init"/>
                &nbsp;ชำระเงิน 2 รอบ<br />
                &nbsp;&nbsp;&nbsp;1. จ่ายเงินรอบแรก (ค่าสินค้า+ค่าขนส่งจากจีนมาไทย)<br />
                &nbsp;&nbsp;&nbsp;2. จ่ายเงินรอบสอง (ค่าขนส่งภายในประเทศ)
            </div>
            <br />
            รวมค่าใช้จ่ายโดยประมาณ
            <br />
            เลือกบัญชี
            <br />
            <asp:GridView ID="gvTran" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="TRAN_DATE" HeaderText="วันที่ชำระเงิน" />
                    <asp:BoundField DataField="TRAN_AMOUNT" HeaderText="จำนวนเงิน" />
                    <asp:BoundField DataField="TRAN_STATUS" HeaderText="สถานะ" />
                    <asp:BoundField DataField="TRAN_REMARK" HeaderText="หมายเหตุ" />
                </Columns>
            </asp:GridView>
            <br />
            <button id="btnPayment" runat="server" type="submit" onserverclick="btnPayment_ServerClick"
                name="action" class="btn waves-effect orange waves-light">Pay                                
            </button>  
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
        });
    </script>
</asp:Content>
