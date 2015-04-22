<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmCmsHeaderList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmCmsHeaderList" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset style="width: 98.5%;">
                <legend>Search Criteria</legend>
                <table style="border: 1 solid;">
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label1" runat="server" Text="Content Title :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtTitle" runat="server" Width="300px"></asp:TextBox>
                        </td>
                       <%-- <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Content Type :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:DropDownList ID="ddl_Content_Type" runat="server">
                                <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
                                <asp:ListItem Value="1">Promotion</asp:ListItem>
                                <asp:ListItem Value="2">News</asp:ListItem>
                                <asp:ListItem Value="3">Recommend</asp:ListItem>
                            </asp:DropDownList>
                        </td>--%>
                    </tr>
                    <tr>
                        <td class="width15">
                            <asp:Label ID="Label3" runat="server" Text="Active :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked="true"/>
                        </td>
                        <td class="width15">
                        </td>
                        <td class="width35">
                        </td>
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
                            <%--<asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnSave" OnClick="btnAdd_Click" />--%>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%"
                DataKeyNames="HEADER_ID,HEADER_TITLE,HEADER_ORDER,CREATE_DATE,UPDATE_DATE,IS_ACTIVE_TEXT">
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HEADER_TITLE" HeaderText="Header Title">
                        <HeaderStyle CssClass="width40" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HEADER_ORDER" HeaderText="Header Order">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CREATE_DATE" HeaderText="Create Date">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="UPDATE_DATE" HeaderText="Update Date">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IS_ACTIVE" HeaderText="Active">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_edit" runat="server" ImageUrl="~/img/icon/b_edit.png" OnClick="imgBtn_edit_Click" />&nbsp;&nbsp;
                        </ItemTemplate>
                        <HeaderStyle CssClass="width5" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
