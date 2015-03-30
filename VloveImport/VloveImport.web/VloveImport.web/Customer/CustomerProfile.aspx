<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="VloveImport.web.Customer.CustomerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            ชื่อผู้ใช้
        </div>
        <div class="col s1 m1 l1"></div>
        <div class="col s9 m9 l9 paddingTop25">
            <asp:Label ID="lbUser" runat="server"></asp:Label>
        </div>
    </div>
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            รหัสผู้ใช้
        </div>
        <div class="col s1 m1 l1"></div>
        <div class="col s9 m9 l9 paddingTop25">
            <asp:Label ID="lbCode" runat="server"></asp:Label>
        </div>
    </div>
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            ชื่อ
        </div>
        <div class="col s1 m1 l1">
        </div>
        <div class="col s9 m9 l9 paddingTop15">
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            นามสกุล
        </div>
        <div class="col s1 m1 l1">
        </div>
        <div class="col s9 m9 l9 paddingTop15">
            <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            วันเกิด
        </div>
        <div class="col s1 m1 l1">
            
        </div>
        <div class="col s9 m9 l9 paddingTop15">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            เพศ
        </div>
        <div class="col s1 m1 l1">
            
        </div>
        <div class="col s9 m9 l9 marginTop20" style="padding: 0px !important;">
            <asp:DropDownList ID="ddlGender" runat="server" Style="display: block">
                <asp:ListItem Text="ชาย"></asp:ListItem>
                <asp:ListItem Text="หญิง"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            Email
        </div>
        <div class="col s1 m1 l1">
            
        </div>
        <div class="col s9 m9 l9 paddingTop15">
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            ร้านค้า
        </div>
        <div class="col s1 m1 l1">
            
        </div>
        <div class="col s9 m9 l9 paddingTop15">
            <asp:TextBox ID="txtLinkShop" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row paddingTop25">
        <button id="btnSave" runat="server" type="submit" onserverclick="btnSave_Click"
            name="action" class="btn waves-effect orange waves-light">
            Save                                
        </button>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
        });
    </script>
</asp:Content>

