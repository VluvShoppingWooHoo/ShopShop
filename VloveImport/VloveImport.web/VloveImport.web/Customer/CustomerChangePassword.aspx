<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerChangePassword.aspx.cs" Inherits="VloveImport.web.Customer.CustomerChangePassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col s7 m7 l7">
            เปลี่ยนรหัสผ่าน
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



    <script type="text/javascript"> 
        $(function () {
            $("#masterForm").fadeIn(1000);
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
