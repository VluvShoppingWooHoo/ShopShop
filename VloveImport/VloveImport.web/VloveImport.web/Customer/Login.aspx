<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VloveImport.web.Customer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s2 m2 l2">
            &nbsp;
        </div>
        <div class="col s8 m8 l8">
            <div class="row">
                <img src="../Images/pic/Logo/LOGO-01.jpg" style="width:658px; height:200px;"/>                
            </div>
            <br />
            <div class="row">
                <div class="col s1 m1 l1">&nbsp;</div>
                <div class="col s2 m2 l2">
                    <span class="orange-text bold">ชื่อผู้ใช้</span>
                </div>
                <div class="col s4 m4 l4">
                    <asp:TextBox ID="txtUser" runat="server" Width="400px"></asp:TextBox>
                </div>
                <div class="col s1 m1 l1">&nbsp;</div>
            </div>
            <div class="row">
                <div class="col s1 m1 l1">&nbsp;</div>
                <div class="col s2 m2 l2">
                    <span class="orange-text bold">รหัสผ่าน</span>
                </div>
                <div class="col s4 m4 l4">
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="400px"></asp:TextBox>
                </div>
                <div class="col s1 m1 l1">&nbsp;</div>
            </div>
            <br />
            <div class="row center">
                <button id="btnLogin" runat="server" type="submit" onserverclick="btnLogin_Click" 
                    name="action" class="btn waves-effect orange waves-light">ลงชื่อเข้าใช้                                
                </button>   
                &nbsp;&nbsp;            
                <button id="btnFotgot" runat="server" type="submit" onserverclick="btnFotgot_Click" 
                    name="action" class="btn waves-effect orange waves-light">ลืมรหัสผ่าน                                
                </button> 
            </div>
        </div>
        <div class="col s2 m2 l2">
            &nbsp;
        </div>
    </div>    
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>
