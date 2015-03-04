<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncWithdraw.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncWithdraw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script type="text/javascript">

    function funsubmit(obj)
    {
        document.getElementById('ContentPlaceHolder1_ucAccfuncWithdraw1_hd_submit').value = obj
        document.getElementById('ContentPlaceHolder1_ucAccfuncWithdraw1_Button1').click();
    }

</script>

<table width ="100%">
    <tr>
        <td colspan ="2"><b>Withraw Request</b></td>
    </tr>
    <tr>
        <td width ="30%">วันที่: <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td>
        <td width ="70%" style ="color:red;"><b>ในกรณีกดถอนเงิน เมื่อเจ้าหน้าที่ตรวจสอบผ่านแล้ว ระบบจะตัดเงินคงเหลือทันที</b></td>
    </tr>
    <tr>
        <td>ยอดเงินคงเหลือ THB0.00</td>
        <td style ="color:red;"><b>แต่เงินจะเข้าบัญชีลูกค้าในช่วงระยะเวลาดำเนินการ 7-10 วัน</b></td>
    </tr>
    <tr>
        <td colspan ="2"></td>
    </tr>
    <tr>
        <td>Account</td>
        <td>
            <asp:DropDownList ID="ddl_account_name" runat="server" style =" display:block;" Width ="400px"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>จำนวนเงิน</td>
        <td>
            <asp:TextBox ID="txt_amount" runat="server" Width ="400px"></asp:TextBox>
            <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_amount" ID="txt_amount_FilteredTextBoxExtender" ValidChars =".1234567890">
            </asp:FilteredTextBoxExtender>
        </td>
    </tr>
    <tr>
        <td>หมายเหตุ</td>
        <td>
            <asp:TextBox ID="txt_remark" runat="server" TextMode ="MultiLine" Width ="400px" Height ="50px" Rows="5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <div style = "border:2px solid #C6D880; background-color:#E6EFC2; height:50px; vertical-align :middle;">
                รหัสผ่านสำหรับการถอนเงิน
            </div>
        </td>
        <td>
            <asp:TextBox ID="txt_Withraw_Password" runat="server" Width ="400px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <b>**รหัสผ่านเป็นอันเดียวกันกับ รหัสผ่านการชำระเงิน</b>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
                <button id="btnSaveUcWithdraw" type="button" class="btn waves-effect orange waves-light" 
                    name="action" runat="server" onclick ="return funsubmit('S');" >
                    SAVE     
                </button>
            &nbsp;&nbsp;
                <button id="Button2" type="button" class="btn waves-effect orange waves-light" 
                    name="action" runat="server" onclick ="return funsubmit('C');" >
                    CLEAR     
                </button>
        </td>
    </tr>
</table>

        <asp:HiddenField ID="hd_submit" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Style="display: none;" />

    </ContentTemplate>
</asp:UpdatePanel>