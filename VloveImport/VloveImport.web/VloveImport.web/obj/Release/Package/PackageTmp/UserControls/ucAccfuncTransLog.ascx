<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncTransLog.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncTransLog" %>
<br />
<b>บันทึกการใช้จ่าย</b> : <b>ยอดเงินคงเหลือ THB <asp:Label ID="lbMymoney" runat="server"></asp:Label></b>
<br /><br />
<div style = "border:2px solid #B7B2AF; vertical-align :middle; width:95%; height:600px;">
    <asp:GridView ID="gvTrans" runat="server" AutoGenerateColumns="false"
        AllowPaging="true" PageSize="10" OnPageIndexChanging="gvTrans_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="TRAN_DETAIL" HeaderText="ประเภทรายการ" />
            <asp:BoundField DataField="TRAN_REMARK" HeaderText="หมายเหตุ" />
            <asp:BoundField DataField="TRAN_DATE" HeaderText="วันที่" />
            <asp:BoundField DataField="TRAN_AMOUNT" HeaderText="จำนวน" />
            <asp:BoundField DataField="STATUS_DESCRIPTION" HeaderText="สถานะ" />
        </Columns>
        <HeaderStyle BackColor="#B7B2AF" />
    </asp:GridView>
</div>