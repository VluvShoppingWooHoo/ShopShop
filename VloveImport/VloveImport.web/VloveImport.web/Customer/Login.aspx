<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VloveImport.web.Customer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                User                
            </td>
            <td>
                <asp:TextBox ID="txtUser" runat="server" >eakkarat_5@hotmail.com</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Pass
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password">123</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
            </td>
        </tr>
    </table>
</asp:Content>
