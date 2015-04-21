<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmCms.aspx.cs" Inherits="VloveImport.web.admin.pages.frmCms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>

            <asp:PostBackTrigger ControlID="btnSave" />

        </Triggers>
        <ContentTemplate>
            <fieldset style="width: 95%;" hidden>
                <%--<legend>Content Type
                </legend>--%>
                <table>
                    <tr>
                        <td style="text-align: right;">Content Type :</td>
                        <td>
                            <asp:DropDownList ID="ddl_Content_Type" runat="server" OnSelectedIndexChanged="ddl_Content_Type_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="1">Promotion</asp:ListItem>
                                <asp:ListItem Value="2">News</asp:ListItem>
                                <asp:ListItem Value="3">Recommend</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <%--<td></td>--%>
                    </tr>
                </table>
            </fieldset>
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
                            <asp:HiddenField ID="hdContentIMG" runat="server" />
                        </td>
                    </tr>
                    <tr id="trHtmlEditor" runat="server">
                        <td style="text-align: right;">Content Detail :</td>
                        <td colspan="4">
                            <asp:TextBox ID="txtContentDetail" runat="server" Width="100%" Rows="20" TextMode="MultiLine"></asp:TextBox>
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
                        <td style="text-align: right;">Active :</td>
                        <td colspan="4">
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked="true"/>
                        </td>
                    </tr>
                    <tr></tr>
                    <tr style="margin-top: 20px;">
                        <td colspan="5" style="text-align: right;">
                            <asp:Button ID="btnSave" runat="server" Text="Save " CssClass=" btnSave" OnClick="btnSave_Click"></asp:Button>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <asp:HiddenField ID="hdfContentType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

