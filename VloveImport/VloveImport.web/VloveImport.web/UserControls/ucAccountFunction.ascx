<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccountFunction.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccountFunction" %>
<div class="row">
    <div class="col s2">
        <p id="P1" class="center text-lighten-1 waves-effect orange waves-light" style="width:150px; height:50px;">บัญชีของคุณ</p>        
        <p id="lblBalance" runat="server"></p>
        <p id="lblPoint" runat="server"></p>
    </div>
    <div class="col s2">
        <p id="P2" class="center text-lighten-1 waves-effect orange waves-light" style="width:150px; height:50px;">ประวัติการซื้อสินค้า</p>
        <p id="P3" runat="server"></p>
        <p id="P4" runat="server"></p>
    </div>    
</div>
<div class="row">
    <div class="col">
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
</div>