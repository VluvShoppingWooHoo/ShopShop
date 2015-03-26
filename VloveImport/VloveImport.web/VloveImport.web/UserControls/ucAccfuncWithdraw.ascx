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
        <b>ถอนเงิน</b> : <b>ยอดเงินคงเหลือ THB <asp:Label ID="lbMymoney" runat="server"></asp:Label></b>
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
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:25%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>เลขที่บัญชีโอนเงินกลับ</b>                                        
            </div>
        </div>
        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
            <div style ="margin-left:10px;">                                
                <asp:DropDownList ID="ddl_account_name" runat="server" 
                CssClass="dpBlock" Width="300px"></asp:DropDownList>
            </div>
        </div>
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:25%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>จำนวนเงิน</b>                                        
            </div>
        </div>
        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
            <div style ="margin-left:10px;">
                <asp:TextBox ID="txt_amount" runat="server" Width="300px" CssClass="txt_amount"></asp:TextBox>
                <asp:FilteredTextBoxExtender runat="server" Enabled="True" TargetControlID="txt_amount" ID="txt_amount_FilteredTextBoxExtender" ValidChars="1234567890">
                </asp:FilteredTextBoxExtender>
            </div>
        </div>
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:25%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <b>หมายเหตุ</b>                                        
            </div>
        </div>
        <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
            <div style ="margin-left:10px;">
                <asp:TextBox ID="txt_remark" runat="server" TextMode="MultiLine" Width="300px" Height="50px" Rows="5" CssClass="txt_remark"></asp:TextBox>
            </div>
        </div>
        <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:25%; height:50px;">
            <br />
            <div style ="margin-left:10px;">
                <span style="color:red; font-weight:600;">รหัสผ่านสำหรับการถอนเงิน</span>
            </div>
        </div>
        <div style = "vertical-align :middle; width:50%; height:50px; margin-left: 32%; margin-top: -40px;">            
            <div style ="margin-left:10px;">
                <asp:TextBox ID="txt_Withraw_Password" runat="server" Width="300px" TextMode="Password" CssClass="txt_Withraw_Password"></asp:TextBox>
                 <br />&nbsp;&nbsp;<b>**รหัสผ่านเป็นอันเดียวกันกับ รหัสผ่านการชำระเงิน</b>
            </div>
        </div>
        <br /><br />
         <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 20%;">            
            <div style ="margin-left:10px;">
                <button id="btnSaveUcWithdraw" type="button" class="btn waves-effect orange waves-light"
                    name="action">
                    SUBMIT               
                </button>
                &nbsp;&nbsp;
                <button id="Button2" type="button" class="btn waves-effect orange waves-light"
                    name="action" runat="server" onclick="return funsubmit('C');">
                    CLEAR                    
                </button>
            </div>
        </div>                    
    </ContentTemplate>
</asp:UpdatePanel>
<script type="text/javascript">
    $(function () {
        //var newOption = "<option value='" + "1" + "'>Some Text</option>";
        //$(".ddl_account_name").append(newOption);
        //var newOption1 = "<option value='" + "2" + "'>Some Text2</option>";
        //$(".ddl_account_name").append(newOption1);
        $('#btnSaveUcWithdraw').click(function () {                  

            alert($('.txt_amount').val());
            alert($(this).find('textarea[id*=txt_remark]').val());

            var accname = $('#<%= ddl_account_name.ClientID %>').val();
            var amt = $('.txt_amount').val();
            var remark = $('.txt_remark').val();
            var pwd = $('.txt_Withraw_Password').val();            

            var param = {
                "accname": accname, "amt": amt, "remark": remark, "pwd": pwd
            };
    
            var mymoney = $('#<%=lbMymoney.ClientID%>').text();
            if ($('#<%= ddl_account_name.ClientID %>').val() == "-1") {
                alert("กรุณาเลือกบัญชี");
                return;
            }

            if (amt == "") {
                alert("กรุณากรอก จำนวนเงิน");
                return;
            }

            if (pwd == "") {
                alert("กรุณากรอก Password");
                return;
            }

            var mm = parseFloat(mymoney);
            var am = parseFloat(amt);

            if (mm < am) {
                alert('เงินในบัญชีไม่พอ');
                return;
            }

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
