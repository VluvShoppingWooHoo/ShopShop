<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmConfig.aspx.cs" Inherits="VloveImport.web.admin.pages.frmConfig" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style ="margin-top:10px;">
                <h2 style ="color:#318DBF;">Config Managemaent</h2>
                <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
            </div>
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
                            <asp:TextBox ID="txtConfig_ID" runat="server" Width ="300px" Enabled ="false" CssClass ="textbox-readonly"></asp:TextBox>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Config Group :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtConfig_Group" runat="server" Width ="300px" Enabled ="false" CssClass ="textbox-readonly"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Config Value :"></asp:Label></td>
                        <td colspan ="3">
                            <asp:TextBox ID="txtConfig_Value" runat="server" Width ="95%" TextMode ="MultiLine" Height ="50px" ht></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label5" runat="server" Text="Config Value 2 :"></asp:Label></td>
                        <td colspan ="3">
                            <asp:TextBox ID="txtConfig_Value2" runat="server" Width ="95%" TextMode ="MultiLine" Height ="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label6" runat="server" Text="Config Value 3 :"></asp:Label></td>
                        <td colspan ="3">
                            <asp:TextBox ID="txtConfig_Value3" runat="server" Width ="95%" TextMode ="MultiLine" Height ="50px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Config Remark :"></asp:Label></td>
                        <td colspan ="3">
                            <asp:TextBox ID="txtConfig_Remark" runat="server" Width ="95%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class ="ItemStyle-center" colspan ="4">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btnSave" OnClick="btnSave_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

