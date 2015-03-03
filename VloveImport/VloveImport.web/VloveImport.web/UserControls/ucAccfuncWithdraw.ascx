<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncWithdraw.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncWithdraw" %>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

<table width ="100%">
    <tr>
        <td colspan ="2"><b>Withraw Request</b></td>
    </tr>
    <tr>
        <td>วันที่: 2015-03-03</td>
        <td>ในกรณีกดถอนเงิน เมื่อเจ้าหน้าที่ตรวจสอบผ่านแล้ว ระบบจะตัดเงินคงเหลือทันที</td>
    </tr>
    <tr>
        <td>ยอดเงินคงเหลือ THB0.00</td>
        <td>แต่เงินจะเข้าบัญชีลูกค้าในช่วงระยะเวลาดำเนินการ 7-10 วัน</td>
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
        </td>
    </tr>
    <tr>
        <td>หมายเหตุ</td>
        <td>
            <asp:TextBox ID="txt_remark" runat="server" TextMode ="MultiLine" Width ="400px" Height ="50px" Rows="5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>รหัสผ่านสำหรับการถอนเงิน</td>
        <td>
            <asp:TextBox ID="txt_Withraw_Password" runat="server" Width ="400px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan ="2">
                <button id="btnSaveUcWithdraw" type="button" class="btn waves-effect orange waves-light" 
                    name="action" runat="server" onserverclick="btnSaveUcWithdraw_ServerClick">
                    SAVE     
                </button>
        </td>
    </tr>
</table>

    </ContentTemplate>
</asp:UpdatePanel>



<script type="text/javascript">
    $(function () {
        $("#btnSave").click(function () {

            var ddlAccount = document.getElementById('<%= ddl_account_name.ClientID %>').value;
            var txt_amount = document.getElementById('<%= txt_amount.ClientID %>').value;
            var txt_remark = document.getElementById('<%= txt_remark.ClientID %>').value;
            var txt_Withraw_Password = document.getElementById('<%= txt_Withraw_Password.ClientID %>').value;

            if (ddlAccount == "-1" || txt_amount == "" || txt_Withraw_Password == "")
            {
                alert("กรุณากรอกข้อมูลในช่องที่มี * ให้ครบถ้วน");
                return false;
            }
                    
            var param = { "ddlAccount": ddlAccount, "txt_amount": txt_amount, "txt_remark": txt_remark, "txt_Withraw_Password": txt_Withraw_Password };

            alert(1);

            $.ajax({
                type: 'POST',
                //url: form.attr('action'),
                url: "../Customer/CustomerMyAccount.aspx/btnSave",
                data: JSON.stringify(param),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    //bindModal(data);
                    //$('#loadingCircle').hide();
                    //$('#loadingLine').hide();
                    //$('#showData').show();
                    //$('#footer').show();
                },
                error: function (err) {
                    //alert('gs');
                }
            });
        });
    });
</script>