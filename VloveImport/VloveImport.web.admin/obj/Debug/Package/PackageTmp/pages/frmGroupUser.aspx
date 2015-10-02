<%@ Page Title="GroupUser Management" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmGroupUser.aspx.cs" Inherits="VloveImport.web.admin.pages.frmGroupUser" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style ="margin-top:10px;">
                <h2 style ="color:#318DBF;">Group user Managemaent</h2>
                <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
            </div>
            <fieldset style="width: 98.5%;">
                <legend>
                    <asp:Label ID="lbl_header" runat="server" Text="Add Data GroupUser"></asp:Label>
                </legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Group Name :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtGroup_name" runat="server" Width="300px"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Group Status :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:DropDownList ID="ddl_GroupStatus" runat="server" Width="300px">
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">Inactive</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Remark :"></asp:Label></td>
                        <td colspan="3">
                            <asp:TextBox ID="txtremark" Width ="98%" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Role Group
                            <span style ="color:red;">*</span>
                        </td>
                        <td colspan="3">
                        </td>
                    </tr>
                   <%-- <tr>
                        <td>Check All : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cbAll" runat="server" AutoPostBack="True" OnCheckedChanged="cbAll_CheckedChanged"/>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>Order Management : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb1" runat="server"/>
                        </td>
                    </tr>
                    <tr>
                        <td>Approve Payment : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb2" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Customer Management : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb3" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Master Management : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb4" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>User Management : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb5" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Group user Management : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb6" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Config Management : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb7" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Content Management : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb8" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Report : </td>
                        <td colspan="3">
                            <asp:CheckBox ID="cb9" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnSave" OnClick="btnSave_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
