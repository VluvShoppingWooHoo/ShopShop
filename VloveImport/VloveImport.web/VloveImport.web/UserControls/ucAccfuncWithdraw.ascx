<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccfuncWithdraw.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccfuncWithdraw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<script type="text/javascript">

    function funsubmit(obj) {
        document.getElementById('ContentPlaceHolder1_ucAccfuncWithdraw1_hd_submit').value = obj
        document.getElementById('ContentPlaceHolder1_ucAccfuncWithdraw1_Button1').click();
    }

</script>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <br />
        <b>ถอนเงิน</b>
        <br /><br />
        <b>
            <span style ="color:red;">
                ถอนเงิน : ในกรณีกดถอนเงิน เมื่อเจ้าหน้าที่ตรวจสอบผ่านแล้ว ระบบจะตัดเงินคงเหลือทันที
                <%--หากลูกค้าต้องการชำระบิล กรุณากดเมนู “ชำระเงิน” ที่หน้ารายการสั่งซื้อคะ--%>
                <br /><br />
                แต่เงินจะเข้าบัญชีลูกค้าในช่วงระยะเวลาดำเนินการ 7-10 วัน
                <%--การชำระเงิน : เป็นการเลือกชำระเงินในบิลนั้นๆ ระบบจะทำการสั่งซื้อให้หลังจากได้รับยืนยันการชำระบิลจากลูกค้า--%>
            </span>
        </b>
        <br />
        <br />
        <b>ยอดเงินคงเหลือ THB0.00</b>


        <table width="100%">
            <tr>
                <td colspan="2"><b>Withraw Request</b></td>
            </tr>
            <tr>
                <td width="30%">วันที่:
                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td>
                <td width="70%" style="color: red;"><b>ในกรณีกดถอนเงิน เมื่อเจ้าหน้าที่ตรวจสอบผ่านแล้ว ระบบจะตัดเงินคงเหลือทันที</b></td>
            </tr>
            <tr>
                <td>ยอดเงินคงเหลือ THB0.00</td>
                <td style="color: red;"><b>แต่เงินจะเข้าบัญชีลูกค้าในช่วงระยะเวลาดำเนินการ 7-10 วัน</b></td>
            </tr>
            <tr>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td>เลขที่บัญชีโอนเงินกลับ
                </td>
                <td>
                    <asp:DropDownList ID="ddl_account_name" CssClass="ddl_account_name" runat="server" Style="display: block;" Width="400px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>จำนวนเงิน</td>
                <td>
                    <asp:TextBox ID="txt_amount" runat="server" Width="400px" CssClass="txt_amount"></asp:TextBox>
                    <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_amount" ID="txt_amount_FilteredTextBoxExtender" ValidChars=".1234567890">
                    </asp:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td>หมายเหตุ</td>
                <td>
                    <asp:TextBox ID="txt_remark" runat="server" TextMode="MultiLine" Width="400px" Height="50px" Rows="5" CssClass="txt_remark"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="border: 2px solid #C6D880; background-color: #E6EFC2; height: 50px; vertical-align: middle;">
                        รหัสผ่านสำหรับการถอนเงิน
                    </div>
                </td>
                <td>
                    <asp:TextBox ID="txt_Withraw_Password" runat="server" Width="400px" CssClass="txt_Withraw_Password"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
            <b>**รหัสผ่านเป็นอันเดียวกันกับ รหัสผ่านการชำระเงิน</b>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <%--<button id="btnSaveUcWithdraw" type="button" class="btn waves-effect orange waves-light"
                        name="action" runat="server" onclick="return funsubmit('S');">
                        SUBMIT
               
                    </button>--%>
                    <button id="btnSaveUcWithdraw" type="button" class="btn waves-effect orange waves-light"
                        name="action">
                        SUBMIT
               
                    </button>
                    &nbsp;&nbsp;
                <button id="Button2" type="button" class="btn waves-effect orange waves-light"
                    name="action" runat="server" onclick="return funsubmit('C');">
                    CLEAR     
               
                </button>
                </td>
            </tr>
        </table>

        <asp:HiddenField ID="hd_submit" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" Style="display: none;" />

    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
    $(function () {
        //var newOption = "<option value='" + "1" + "'>Some Text</option>";
        //$(".ddl_account_name").append(newOption);
        //var newOption1 = "<option value='" + "2" + "'>Some Text2</option>";
        //$(".ddl_account_name").append(newOption1);
        $('#btnSaveUcWithdraw').click(function () {

            var accname = $('.ddl_account_name').val();
            var amt = $('.txt_amount').val();
            var remark = $('.txt_remark').val();
            var pwd = $('.txt_Withraw_Password').val();

            var param = {
                "accname": accname, "amt": amt, "remark": remark, "pwd": pwd
            };
            $.ajax({
                type: 'POST',
                url: "../Customer/CustomerMyAccount.aspx/btnWithdraw",
                data: JSON.stringify(param),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    //$('#modalItem').closeModal();
                    //toast('Item Added.', 5000)
                },
                error: function (err) {
                    alert('gs');
                }
            });
        });
    });
</script>
