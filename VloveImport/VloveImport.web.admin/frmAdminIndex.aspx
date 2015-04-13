<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdminIndex.aspx.cs" Inherits="VloveImport.web.admin.frmAdminIndex" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LOGIN :: I LOVE IMPORT</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="margin-top: 12%;">
                    <table width="100%">
                        <tr>
                            <td>
                                <div style ="margin-left:30%;">
                                    <table class="width50">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/logo/LOGO-01.jpg" Width="100%" Height="100px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class ="width15 ItemStyle-center">
                                                <h1>
                                                    <asp:Label ID="Label1" runat="server" CssClass = "label-large" Text="Username : "></asp:Label>
                                                </h1>
                                            </td>
                                            <td class ="width85 ItemStyle-left">
                                                <asp:TextBox ID="txtuser" runat="server" CssClass = "textbox-large" TabIndex="1"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class ="ItemStyle-center">
                                                <asp:Label ID="Label2" runat="server" CssClass = "label-large" Text="Password : "></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtpassword" TextMode="Password" CssClass = "textbox-large" runat="server" TabIndex="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td>
                                                <asp:Button ID="btnLogin" runat="server" Text="Login" Height ="40px" Width = "80px" CssClass ="btnSave" TabIndex="3" OnClick="btnLogin_Click" />
                                                &nbsp;&nbsp;
                                                <asp:Button ID="btnReset" runat="server" Text="Reset" Height ="40px" Width = "80px" CssClass ="btnCancel" OnClick="btnReset_Click"/>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>

                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</html>
