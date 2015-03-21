<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAccFuncTopup.ascx.cs" Inherits="VloveImport.web.UserControls.ucAccFuncTopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<script type="text/javascript">

    function funsubmitTopUp(obj) {
        
        document.getElementById('ContentPlaceHolder1_ucAccFuncTopup_hd_submit').value = obj
        document.getElementById('ContentPlaceHolder1_ucAccFuncTopup_Button1').click();
    }

</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <br />
        <b>เติมเงิน</b>
        <br /><br />
        <b>
            <span style ="color:red;">
                เติมเงิน : เป็นการเติมเงินเข้าระบบเท่านั้น ไม่ได้มีการตัดจ่ายบิลใดๆ 
                <%--หากลูกค้าต้องการชำระบิล กรุณากดเมนู “ชำระเงิน” ที่หน้ารายการสั่งซื้อคะ--%>
                <br /><br />
                เงินจะเข้าระบบก็ต่อเมื่อ ได้รับการตรวจสอบจากผู้ดูแลเรียบร้อยแล้ว
                <%--การชำระเงิน : เป็นการเลือกชำระเงินในบิลนั้นๆ ระบบจะทำการสั่งซื้อให้หลังจากได้รับยืนยันการชำระบิลจากลูกค้า--%>
            </span>
        </b>
        <br />
        <br />
        <div style = "border:2px solid #959595; background-color:#F5F5F5; vertical-align :middle; width:60%; height:60px;">
            <div style ="margin-top:10px;">
                1.เลือกธนาคารที่ท่านสะดวกในการเติมเงิน<br />
                2.ระบุวิธีการเติมเงิน และจำนวนเงินที่เติม หลังจากนั้น ระบุวิธีการแจ้งการเติมเงิน
            </div>
        </div>
        <br />
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>เลือก I LOVE IMPORT ธนาคาร</b>                                        
            </div>
        </div>
        <br />
        <asp:DropDownList ID="ddlBank" DataTextField="BANK_SHOP_ACCOUNT_NO" DataValueField="BANK_SHOP_ID" runat="server" 
            CssClass="dpBlock" Width="300px"></asp:DropDownList>
        <%--<asp:RadioButtonList ID="rbList1_bank_list" DataTextField = "BANK_SHOP_ACCOUNT_NO" DataValueField = "BANK_SHOP_ID" runat="server"></asp:RadioButtonList>--%>
        <br />
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>หลักฐานการชำระเงิน</b>
            </div>            
        </div>
        <br />
        <div class="file-field input-field">
            <input class="file-path validate" type="text" style="width:300px;"/>
            <div class="btn">
                <span>File</span>
                <input type="file" />
            </div>
        </div>
        <br />    
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">    
            <br />
            <div style ="margin-left:10px;">
                <b>* จำนวนเงิน</b>
            </div>                           
        </div> 
        <asp:TextBox ID="txt_tranfer_amount" runat="server" Width ="400px" ></asp:TextBox>
        <br />        
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>* วันโอนเงิน </b>
            </div>
        </div>        
        <span style ="color:red;">*</span><br />
        <input type="date" class="datepicker" id="dtMaterial" runat="server" style="width:300px;" />
        <br />
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>* เวลาโอน</b>
            </div>            
        </div>
        <br />
        <asp:DropDownList ID="ddlH" DataTextField ="PAYMENT_TIME" DataValueField ="PAYMENT_TIME" runat="server" 
            style =" display:inline;" Width ="100px"></asp:DropDownList>&nbsp;&nbsp;
        <asp:DropDownList ID="ddlM" DataTextField ="PAYMENT_TIME" DataValueField ="PAYMENT_TIME" runat="server" 
            style =" display:inline;" Width ="100px"></asp:DropDownList>&nbsp;&nbsp;
        <asp:DropDownList ID="ddls" DataTextField ="PAYMENT_TIME" DataValueField ="PAYMENT_TIME" runat="server" 
            style =" display:inline;" Width ="100px"></asp:DropDownList>
        <br />
        <br />
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b> E-mail</b>
            </div>            
        </div>
        <br />
        <asp:TextBox ID="txt_email" runat="server" Width ="400px"></asp:TextBox>
        <br />
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b> หมายเหตุ</b>
            </div>            
        </div>
        <br />
        <asp:TextBox ID="txt_remark" runat="server" Width ="400px" Height ="80px" TextMode ="MultiLine"></asp:TextBox>
        <br />
        <br />
        <button id="btnSaveUcWithdraw" type="button" class="btn waves-effect orange waves-light" 
            name="action" runat="server" onserverclick="btnSaveUcWithdraw_ServerClick">
            SUBMIT
        </button>
        &nbsp;&nbsp;
        <button id="Button2" type="button" class="btn waves-effect orange waves-light" 
            name="action" runat="server" onclick ="return funsubmitTopUp('C');" >
            CLEAR     
        </button>
    </ContentTemplate>
</asp:UpdatePanel>