﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VloveImport.web.Customer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                User                
            </td>
            <td>
                <asp:TextBox ID="txtUser" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Pass
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <button id="btnLogin" runat="server" type="submit" onserverclick="btnLogin_Click" 
                    name="action" class="btn waves-effect orange waves-light">ลงชื่อเข้าใช้                                
                </button>
                <%--<button id="btnReset" runat="server" type="submit" onserverclick="btnReset_Click" 
                    name="action" class="btn waves-effect orange waves-light">Reset                                
                </button>--%> 
                <button id="btnFotgot" runat="server" type="submit" onserverclick="btnFotgot_Click" 
                    name="action" class="btn waves-effect orange waves-light">ลืมรหัสผ่าน                                
                </button> 
                <%--<asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" />--%>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>
