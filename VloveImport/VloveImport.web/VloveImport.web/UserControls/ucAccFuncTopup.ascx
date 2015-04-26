<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccFuncTopup.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccFuncTopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <form></form>
        <br />
        <b>เติมเงิน</b> : <b>ยอดเงินคงเหลือ THB
            <asp:Label ID="lbMymoney" runat="server"></asp:Label></b>
        <br />
        <br />
        <b>
            <span style="color: red;">เติมเงิน : เป็นการเติมเงินเข้าระบบเท่านั้น ไม่ได้มีการตัดจ่ายบิลใดๆ 
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
                    CssClass="dpBlock ddlBank" Width="300px">
                </asp:DropDownList>
            </div>
        </div>
        <div style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 30%; height: 50px;">
            <br />
            <div style="margin-left: 10px;">
                <b>หลักฐานการชำระเงิน</b>
            </div>
        </div>
        <div style="vertical-align: middle; width: 50%; height: 50px; margin-left: 33%; margin-top: -60px;">
            <div style="margin-left: 10px;">
                <div class="file-field input-field">
                    <input class="file-path validate" id="filetext" type="text" style="width: 300px; margin-left: 0px; margin-right: 20px;" />
                    <div class="btn">
                        <span>File</span>
                        <%--<input id="Ifile" type="file" runat="server"/>--%>
                            <asp:FileUpload ID="Ifile" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 30%; height: 50px;">
            <br />
            <div style="margin-left: 10px;">
                <b>* จำนวนเงิน</b>
            </div>
        </div>
        <div style="vertical-align: middle; width: 50%; height: 50px; margin-left: 33%; margin-top: -40px;">
            <div style="margin-left: 10px;">
                <asp:TextBox ID="txt_tranfer_amount" CssClass="txt_tranfer_amount" runat="server" Width="300px"></asp:TextBox>
            </div>
        </div>
        <div style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 30%; height: 50px;">
            <br />
            <div style="margin-left: 10px;">
                <b>* วันโอนเงิน </b>
            </div>
        </div>
        <div style="vertical-align: middle; width: 50%; height: 50px; margin-left: 33%; margin-top: -40px;">
            <div style="margin-left: 10px;">
                <input type="date" class="datepicker dtMaterial" id="dtMaterial" runat="server" style="width: 300px;" />
            </div>
        </div>
        <div style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 30%; height: 50px;">
            <br />
            <div style="margin-left: 10px;">
                <b>* เวลาโอน</b>
            </div>
        </div>
        <div style="vertical-align: middle; width: 50%; height: 50px; margin-left: 33%; margin-top: -40px;">
            <div style="margin-left: 10px;">
                <asp:DropDownList ID="ddlH" DataTextField="PAYMENT_TIME" DataValueField="PAYMENT_TIME" runat="server"
                    CssClass="ddlH" Style="display: inline;" Width="100px">
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlM" DataTextField="PAYMENT_TIME" DataValueField="PAYMENT_TIME" runat="server"
                    CssClass="ddlM" Style="display: inline;" Width="100px">
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:DropDownList ID="ddls" DataTextField="PAYMENT_TIME" DataValueField="PAYMENT_TIME" runat="server"
                    CssClass="ddls" Style="display: inline;" Width="100px">
                </asp:DropDownList>
            </div>
        </div>
        <div style="border: 2px solid #B7B2AF; background-color: #B7B2AF; vertical-align: middle; width: 30%; height: 50px;">
            <br />
            <div style="margin-left: 10px;">
                <b>หมายเหตุ</b>
            </div>
        </div>
        <div style="vertical-align: middle; width: 50%; height: 50px; margin-left: 33%; margin-top: -40px;">
            <div style="margin-left: 10px;">
                <asp:TextBox ID="txt_remark" CssClass="txt_remark" runat="server" Width="350px" Height="80px" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <br />
        <br />
        <div style="vertical-align: middle; width: 40%; height: 50px; margin-left: 20%;">
            <div style="margin-left: 10px;">
                <button type="button" class="btn waves-effect orange waves-light" name="action">
                <asp:Button ID="btnTopup" runat="server" Text="SUBMIT" OnClick="btnTopup_Click" />
                </button>

                <%--<button id="btnSaveUcTopup" type="button" class="btn waves-effect orange waves-light"
                    name="action">
                    SUBMIT
               
                </button>--%>
                &nbsp;&nbsp;
                <button id="btnClear" type="button" class="btn waves-effect orange waves-light"
                    name="action">
                    CLEAR     
               
                </button>
            </div>
        </div>
        <div>
            <asp:Label ID="lblERR1" runat="server"></asp:Label>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
    $(function () {
        $('#filetext').attr("disabled", "disabled")

        $('#btnSaveUcTopup').click(function () {

            var Bank = $('.ddlBank').val();
            var amt = $('.txt_tranfer_amount').val();
            var date = $('.dtMaterial').val();
            var time = $('.ddlH').val() + ':' + $('.ddlM').val() + ':' + $('.ddls').val()
            var remark = $('.txt_remark').val();

            var param = {
                "Bank": Bank, "amt": amt, "date": date, "time": time,
                "remark": remark, "file": $('#hdFile').val()
            };
            $.ajax({
                type: 'POST',
                url: "../Customer/CustomerMyAccount.aspx/btnTopup",
                data: JSON.stringify(param),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    //$('#modalItem').closeModal();
                    //toast('Item Added.', 5000)
                    $('.ddlBank').val("1");
                    $('.txt_tranfer_amount').val("");
                    $('.dtMaterial').val("");
                    $('.ddlH').val("00");
                    $('.ddlM').val("00");
                    $('.ddls').val("00");
                    $('.txt_remark').val("");
                    $('#file').val("");
                },
                error: function (err) {
                    alert('Something wrong, please contact admin.');
                }
            });
        });

        $('#btnClear').click(function () {

            $('.ddlBank').val("1");
            $('.txt_tranfer_amount').val("");
            $('.dtMaterial').val("");
            $('.ddlH').val("00");
            $('.ddlM').val("00");
            $('.ddls').val("00");
            $('.txt_remark').val("");
            $('#file').val("");

        });
    });
</script>
