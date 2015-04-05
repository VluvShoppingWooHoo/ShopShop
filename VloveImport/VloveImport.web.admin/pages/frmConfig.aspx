<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmConfig.aspx.cs" Inherits="VloveImport.web.admin.pages.frmConfig" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <fieldset style="width: 98.5%;">
                <legend>
                    <asp:Label ID="lbl_header" runat="server" Text="Edit Config Data"></asp:Label>
                </legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Config ID :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:Label ID="lblConfig_ID" runat="server" Text=""></asp:Label>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Config Group :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:Label ID="lblConfig_Group" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Config Value :"></asp:Label></td>
                        <td colspan ="3">
                            <asp:TextBox ID="txtConfig_Value" runat="server" Width ="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Config Remark :"></asp:Label></td>
                        <td colspan ="3">
                            <asp:TextBox ID="txtConfig_Remark" runat="server" Width ="95%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <br />
            <fieldset>
                <legend>
                    <asp:Label ID="Label6" runat="server" Text="Information"></asp:Label>
                </legend>
                <table>
                    <tr>
                        <td class="width15">First Name :</td>
                        <td class="width35">
                            <asp:TextBox ID="txtFName" runat="server" Width="300px"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                        <td class="width15">Last Name :</td>
                        <td class="width35">
                            <asp:TextBox ID="txtLName" runat="server" Width="300px"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td>Detail :</td>
                        <td colspan ="3">
                            <asp:TextBox ID="txtDetail" runat="server" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <br />
            <table class = "width100">
                <tr>
                    <td class ="ItemStyle-center">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnSave" OnClick="btnSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnResetPassword" runat="server" Text="Reset Password" CssClass="btnCancel" Visible =" false" OnClick="btnResetPassword_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

