<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmCMSContent.aspx.cs" Inherits="VloveImport.web.admin.pages.frmCMSContent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset style="width: 95%;">
                <legend>
                    <asp:Label ID="lblLegend" runat="server" Text="Label"></asp:Label>
                </legend>
                <table>
                    <tr hidden>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr id="trTitle" runat="server">
                        <td style="text-align: right;">Content Title :</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtContentTitle" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="trIMG" runat="server">
                        <td style="text-align: right;">Content Image :</td>
                        <td colspan="4">

                            <asp:FileUpload ID="FileUploadControl" runat="server" Width="100%" />

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center;" colspan="5"><legend>Content Detail</legend></td>
                    </tr>
                    <tr id="trHtmlEditor" runat="server">
                        <td colspan="5">
                            <asp:TextBox ID="txtContentDetail" runat="server" Width="100%"></asp:TextBox>
                            <cc1:HtmlEditorExtender ID="htmlExtend" runat="server" TargetControlID="txtContentDetail">
                            </cc1:HtmlEditorExtender>
                        </td>
                    </tr>
                    <tr id="trURL" runat="server">
                        <td style="text-align: right;">URL :</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtURL" runat="server" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <asp:Button ID="btnSave" runat="server" Text="Save " CssClass=" btnSave" OnClick="btnSave_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <asp:HiddenField ID="hdfContentType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

