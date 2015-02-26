<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="VloveImport.web.Customer.CustomerProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="td">
                ชื่อผู้ใช้
            </td>
            <td class="td">
                <asp:Label ID="lbUser" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="td">
                รหัสผู้ใช้
            </td>
            <td class="td">
                <asp:Label ID="lbCode" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="td">
                ชื่อ
            </td>
            <td class="td">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="td">
                นามสกุล
            </td>
            <td class="td">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="td">
                วันเกิด
            </td>
            <td class="td">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="td">
                เพศ
            </td>
            <td class="td">
                <asp:DropDownList ID="ddlGender" runat="server" style="display:block">
                    <asp:ListItem Text="ชาย"></asp:ListItem>
                    <asp:ListItem Text="หญิง"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="td">
                ร้านค้า
            </td>
            <td class="td">
                <asp:TextBox ID="txtLinkShop" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>

        </tr>
    </table>
    <button id="btnSave" runat="server" type="submit" onserverclick="btnSave_Click" 
        name="action" class="btn waves-effect orange waves-light">Save                                
    </button>
</asp:Content>

