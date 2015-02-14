<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VloveImport.web.Customer.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                อีเมลล์
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                รหัสผ่าน
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ยืนยันรหัสผ่าน
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="ckb" runat="server" Text="ยอมรับ" />
                &nbsp;เงื่อนไขสมาชิกเว็บไซต์
            </td>
        </tr>
        <tr>
            <td>
                โทรศัพท์มือถือ
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtMobile" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                รหัสผู้แนะนำ
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtRefCust" runat="server" ></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
