<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmAdminSendMail.aspx.cs" Inherits="VloveImport.web.admin.pages.frmAdminSendMail" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style ="margin-top:10px;">
                <h2 style ="color:#318DBF;">Admin Sendmail</h2>
                <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
            </div>
            <fieldset style="width: 98.5%;">
                <legend>
                    <asp:Label ID="lbl_header" runat="server" Text="SendMail"></asp:Label>
                </legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Select Config :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:DropDownList ID="ddl_Config" runat="server" Width="300px"></asp:DropDownList>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="To Email :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtToEmail" Width ="300px" runat="server"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtPassword" Width ="300px" runat="server" TextMode="Password"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                </table>
            </fieldset>            
            <br />
            <table class = "width100">
                <tr>
                    <td class ="ItemStyle-center">
                        <asp:Button ID="btnProcess" runat="server" Text="Save" CssClass="btnSave" OnClick="btnProcess_Click" />&nbsp;&nbsp;                        
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
