<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerMyAccount.aspx.cs" Inherits="VloveImport.web.Customer.CustomerMyAccount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="~/UserControls/ucAccFuncTopup.ascx" TagPrefix="uc1" TagName="ucAccFuncTopup" %>
<%@ Register Src="~/UserControls/ucAccfuncWithdraw.ascx" TagPrefix="uc1" TagName="ucAccfuncWithdraw" %>
<%--<%@ Register Src="~/UserControls/ucAccfuncMypoint.ascx" TagPrefix="uc1" TagName="ucAccfuncMypoint" %>--%>
<%@ Register Src="~/UserControls/ucAccfuncTransLog.ascx" TagPrefix="uc1" TagName="ucAccfuncTransLog" %>
<%@ Register Src="~/UserControls/ucAccfuncVoucher.ascx" TagPrefix="uc1" TagName="ucAccfuncVoucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--    <asp:TabContainer ID="TabDown" runat="server" ActiveTabIndex="0" Width = "100%" CssClass ="">
        <asp:TabPanel ID="TabP_Down" runat="server" HeaderText="งวดเงินดาวน์" CssClass='tab col s3 m3 l3'>
            <ContentTemplate>

            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>--%>


    <div class="row">
        <div class="col s10 m10 l10">
            <ul class="tabs">
                <li class="tab col s3 m3 l3"><a href="#topup">เติมเงิน</a></li>
                <li class="tab col s3 m3 l3"><a href="#withdraw">เบิกเงิน</a></li>
                <li class="tab col s3 m3 l3"><a href="#translog">บันทึกการใช้จ่าย</a></li>
                <li class="tab col s3 m3 l3"><a href="#voucher">บัตรกำนัล</a></li>
                <li class="tab col s3 m3 l3"><a href="#mypoint">คะแนนสะสม</a></li>
            </ul>
            <div id="topup" class="row">
                <uc1:ucAccFuncTopup runat="server" ID="ucAccFuncTopup" />
            </div>
            <div id="withdraw" class="row">
                <uc1:ucAccfuncWithdraw ID="ucAccfuncWithdraw1" runat="server" />
            </div>
            <div id="translog" class="row">
                <uc1:ucAccfuncTransLog runat="server" ID="ucAccfuncTransLog" />
            </div>
            <div id="voucher" class="row">
                <uc1:ucAccfuncVoucher runat="server" ID="ucAccfuncVoucher" />
            </div>
            <div id="mypoint" class="row">
                <%-- <uc1:ucAccfuncMypoint runat="server" id="ucAccfuncMypoint" />--%>
            </div>
        </div>
    </div>
    <%-- <div>
        <h5 id="lblWelcome" runat="server"></h5>
        <p id="P1" class="center text-lighten-1 waves-effect orange waves-light" style="width:150px; height:50px;">บัญชีของคุณ</p>
        <p id="lblBalance" runat="server"></p>
        <p id="lblPoint" runat="server"></p>
        <button id="btnTopup" type="button" name="action" class="btn waves-effect orange waves-light">
            เก็บเงิน                                
        </button>
        <button id="btnWithdraw" type="button" name="action" class="btn waves-effect orange waves-light">
            เบิกเงิน                                
        </button>
        <button id="btnTransLog" type="button" name="action" class="btn waves-effect orange waves-light">
            บันทึกการใช้จ่าย                                
        </button>
        <button id="btnVoucher" type="button" name="action" class="btn waves-effect orange waves-light">
            บัตรกำนัล                                
        </button>
        <button id="btnMyPoint" type="button" name="action" class="btn waves-effect orange waves-light">
            คะแนนสะสม                                
        </button>
    </div>
    <div>
        <p id="P2" class="center text-lighten-1 waves-effect orange waves-light" style="width:150px; height:50px;">ประวัติการซื้อสินค้า</p>
        <p id="P3" runat="server"></p>
        <p id="P4" runat="server"></p>
    </div>
    <div>
        <p id="P5" class="center text-lighten-1 waves-effect orange waves-light" style="width:150px; height:50px;">สินค้าล่าสุด</p>
        <p id="P6" runat="server"></p>
        <p id="P7" runat="server"></p>
    </div>--%>



    <script type="text/javascript">
        $(function () {

            $("#masterForm").fadeIn(1000);

            $("#btnSaveUcWithdraw").click(function () {


                var ddlAccount = $("[id$='ddl_account_name']").val();
                var txt_amount = $("[id$='txt_amount']").val();
                var txt_remark = $("[id$='txt_remark']").val();
                var txt_Withraw_Password = $("[id$='txt_Withraw_Password']").val();

                var param = { "ddlAccount": ddlAccount, "txt_amount": txt_amount, "txt_remark": txt_remark, "txt_Withraw_Password": txt_Withraw_Password };

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
            $("#btnTopup").click(function () {

                var param = {};

                $.ajax({
                    type: 'POST',
                    //url: form.attr('action'),
                    url: "../Customer/CustomerMyAccount.aspx/btnTopup_Click",
                    data: JSON.stringify(param),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {

                    },
                    error: function (err) {
                        //alert('gs');
                    }
                });
            });
        });
    </script>
</asp:Content>
