<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmConfigList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmConfigList" %>
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
                            <asp:Label ID="Label1" runat="server" Text="Config ID :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtconfigid" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label3" runat="server" Text="Config Group :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtconfigGroup" runat="server" Width="300px"></asp:TextBox>
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
                        &nbsp;</td>
                </tr>
            </table>
            <asp:GridView ID="gv_detail" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Width="100%"
                DataKeyNames="CONFIG_ID,CONFIG_VALUE,CONFIG_GROUP,CONFIG_REMARK" OnPageIndexChanging="gv_detail_PageIndexChanging" OnRowCreated="gv_detail_RowCreated" OnRowDataBound="gv_detail_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CONFIG_ID" HeaderText="Config id">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Config value" DataField="CONFIG_VALUE">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Config value 2" DataField="CONFIG_VALUE2">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Config Group" DataField="CONFIG_GROUP">
                        <HeaderStyle CssClass="width15" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Remark" DataField="CONFIG_REMARK">
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
