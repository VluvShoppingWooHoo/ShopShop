<%@ Page Title="GroupUser Management" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmGroupUserList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmGroupUserList" %>

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
                <legend>Search Criteria</legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Group Name :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtGroup_name" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Group Status :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:DropDownList ID="ddl_GroupStatus" runat="server" Width="300px">
                                <asp:ListItem Value="-1">Show all</asp:ListItem>
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">Inactive</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center;">
                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table>
                <tr>
                    <td style="text-align: left;">
                        <asp:Label ID="lblResult" runat="server" Text="<b>Result Data</b>"></asp:Label>
                    </td>
                    <td style="text-align: right;">
                        <asp:Button ID="btnAdd" runat="server" Text="Add Groupuser" CssClass ="btnSave" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%"
                DataKeyNames="GROUP_ID,GROUP_NAME,GROUP_ROLE,GROUP_REMARK,GROUP_STATUS" OnPageIndexChanging="gv_detail_PageIndexChanging" OnRowCreated="gv_detail_RowCreated" OnRowDataBound="gv_detail_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GROUP_NAME" HeaderText="Group name">
                        <HeaderStyle CssClass="width70" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GROUP_STATUS_TEXT" HeaderText="Status">
                        <HeaderStyle CssClass="width10" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_edit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="imgBtn_edit_Click" />&nbsp;&nbsp;
                            <asp:ImageButton ID="imgBtn_delete" runat="server" Height="15px" ImageUrl="~/img/icon/Close-2-icon.png" Width="15px" OnClick="imgBtn_delete_Click" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="width10" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
