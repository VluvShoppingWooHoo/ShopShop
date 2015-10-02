<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmUser.aspx.cs" Inherits="VloveImport.web.admin.pages.frmUser" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style ="margin-top:10px;">
                <h2 style ="color:#318DBF;">User Managemaent</h2>
                <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
            </div>
            <fieldset style="width: 98.5%;">
                <legend>
                    <asp:Label ID="lbl_header" runat="server" Text="Add Data User"></asp:Label>
                </legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Group Name :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:DropDownList ID="ddl_groupname" runat="server" Width="300px"></asp:DropDownList>
                            <span style ="color:red;">*</span>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Username :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtusername" runat="server" Width="300px"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr id ="trpassword" runat ="server">
                        <td><asp:Label ID="Label3" runat="server" Text="Password :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtpassword" Width ="300px" runat="server" TextMode ="Password"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                        <td><asp:Label ID="Label5" runat="server" Text="Re Password :"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtRepassword" Width ="300px" runat="server" TextMode ="Password"></asp:TextBox>
                            <span style ="color:red;">*</span>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="User Status :"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="ddl_Status" runat="server" Width="300px">
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">Inactive</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td></td>
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
