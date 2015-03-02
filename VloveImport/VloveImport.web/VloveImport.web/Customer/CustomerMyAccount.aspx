﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerMyAccount.aspx.cs" Inherits="VloveImport.web.Customer.CustomerMyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s10 m10 l10">
            <ul class="tabs">
                <li class="tab col s3 m3 l3"><a href="#rad">เก็บเงิน</a></li>
                <li class="tab col s3 m3 l3"><a href="#datepic">เบิกเงิน</a></li>
                <li class="tab col s3 m3 l3"><a href="#etc">บันทึกการใช้จ่าย</a></li>
                <li class="tab col s3 m3 l3"><a href="#">บัตรกำนัล</a></li>
                <li class="tab col s3 m3 l3"><a href="#">คะแนนสะสม</a></li>
            </ul>
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
            $("#btnTopup").click(function () {

                var param = {  };

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
