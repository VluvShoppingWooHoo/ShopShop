<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerChangePassword.aspx.cs" Inherits="VloveImport.web.Customer.CustomerChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <span class="FontHeader">เปลี่ยนรหัสผ่าน</span>
        <br />
        <br />
        <div class="col s12 m12 l12">
            <ul class="tabs">
                <li class="tab col s6 m6 l6"><a class="topup" href="#login">รหัสผ่านสำหรับการเข้าสู่ระบบ</a></li>
                <li class="tab col s6 m6 l6"><a class="withdraw" href="#withdraw">รหัสผ่านสำรับการถอนเงิน</a></li>
            </ul>
            <div class="col s7 m7 l7">                
                <br />
                <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                    <br />
                    <div style ="margin-left:10px;">
                        <b>รหัสผ่านเก่า</b>                                        
                    </div>
                </div>
                <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                    <div style ="margin-left:10px;">
                        <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                    <br />
                    <div style ="margin-left:10px;">
                        <b>รหัสผ่านใหม่</b>                                        
                    </div>
                </div>
                <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                    <div style ="margin-left:10px;">
                        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div style = "border:2px solid #B7B2AF; background-color:#B7B2AF; vertical-align :middle; width:30%; height:50px;">
                    <br />
                    <div style ="margin-left:10px;">
                        <b>ยืนยันรหัสผ่าน</b>                                        
                    </div>
                </div>
                <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 32%; margin-top: -40px;">            
                    <div style ="margin-left:10px;">
                        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div style = "vertical-align :middle; width:40%; height:50px; margin-left: 20%;">            
                    <div style ="margin-left:10px;">
                        <button id="btnConfirm" type="button" class="btn waves-effect orange waves-light" 
                            name="action">
                            ยืนยัน
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <script type="text/javascript"> 
        $(function () {
            SetFadeout();
        });

        $('#btnConfirm').click(function () {

            var old = $('#<%= txtOldPass.ClientID %>').val();
            var newp = $('#<%= txtNewPass.ClientID %>').val();
            var conf = $('#<%= txtConfirm.ClientID %>').val();
            
            if (newp != conf) {
                alert("รหัสผ่านใหม่ไม่ถูกต้อง");
                return;
            }

            if (old == newp) {
                alert("รหัสผ่านใหม่ต้องไม่ซ้ำกับรหัสผ่านเดิม");
                return;
            }
            
            var param = {
                "old": old, "newp": newp, "conf": conf
            };
            $.ajax({
                type: 'POST',
                url: "../Customer/CustomerChangePassword.aspx/btnConfirm",
                data: JSON.stringify(param),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    var spl = data.d.replace(/"/g, '').split('|')
                    if (spl[0] == 1) //1 = Success, 2 = Error
                        window.location = spl[1];
                    else
                        alert(spl[1]);
                  
                },
                error: function (err) {
                    alert('gs');
                }
            });

        });
    </script>
</asp:Content>
