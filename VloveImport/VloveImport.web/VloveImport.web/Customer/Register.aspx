<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VloveImport.web.Customer.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height:600px;">
        <div class="col s2 m2 l2">
            &nbsp;
        </div>
        <div class="col s8 m8 l8">
            <div class="row">
                <span class="orange-text bold">ชื่อ</span>
            </div>
            <div class="row">
                <asp:TextBox ID="txtName" runat="server" ></asp:TextBox>
            </div>
            <div class="row">
                <span class="orange-text bold">อีเมลล์</span>
            </div>
            <div class="row">
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            </div>
            <div class="row">
                <span class="orange-text bold">รหัสผ่าน</span>
            </div>
            <div class="row">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="row">
                <span class="orange-text bold">ยืนยันรหัสผ่าน</span>
            </div>
            <div class="row">
                <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="row">
                <asp:CheckBox ID="ckb" runat="server" Text="ยอมรับ" />
                &nbsp;เงื่อนไขสมาชิกเว็บไซต์
            </div>
            <div class="row">                
                <asp:TextBox ID="txtAccept" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            </div>
            <div class="row">     
                <span class="orange-text bold">โทรศัพท์มือถือ</span>   
            </div>
            <div class="row">
                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
            </div>
            <div class="row">   
                <span class="orange-text bold">รหัสผู้แนะนำ</span>      
            </div>
            <div class="row">
                <asp:TextBox ID="txtRefCust" runat="server"></asp:TextBox>
                <asp:HiddenField ID="hddRefCust" runat="server" />
            </div>
            <div class="row">
                <button id="btnRegis" runat="server" type="submit" onserverclick="btnRegis_Click"
                    name="action" class="btn waves-effect orange waves-light">
                    Register                                                            
                </button>
                <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
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
