﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerForgot.aspx.cs" Inherits="VloveImport.web.Customer.CustomerForgot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            ลืมรหัสผ่าน
        </div>
    </div>
    <div class="row divRowBlock">
        <div class="col s2 m2 l2 paddingTop25">
            รหัสผ่านจะถูกตั้งค่าใหม่ และส่งให้
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
    <div class="row paddingTop25">
        <button id="btnSave" runat="server" type="submit" onserverclick="btnSave_Click"
            name="action" class="btn waves-effect orange waves-light">
            ส่งเมลล์                                
        </button>
    </div>
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

