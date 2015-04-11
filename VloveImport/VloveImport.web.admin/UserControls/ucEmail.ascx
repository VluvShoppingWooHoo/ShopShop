<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEmail.ascx.cs" Inherits="VloveImport.web.admin.UserControls.ucEmail" %>
<table>
    <tr>
        <td class ="width15">From : </td>
        <td class ="width85">
            <asp:TextBox ID="txt_email_from" runat="server" Width ="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>To : </td>
        <td>
            <asp:TextBox ID="txt_email_to" runat="server" TextMode ="MultiLine" Width ="500px" Height ="50px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Subject : </td>
        <td>
            <asp:TextBox ID="txt_email_subject" runat="server" Width ="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Detail : </td>
        <td>
            <asp:TextBox ID="txt_email_detail" runat="server" TextMode ="MultiLine" Width ="500px" Height ="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td></td>
        <td class ="ItemStyle-left">
            <asp:Button ID="btnsendMail" runat="server" Text="Send mail" CssClass ="btnSave" OnClick="btnsendMail_Click" />&nbsp;&nbsp;
            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass ="btnCancel" OnClick="btnReset_Click"/>
        </td>
    </tr>
</table>
