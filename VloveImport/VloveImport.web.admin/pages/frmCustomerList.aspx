<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmCustomerList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmCustomerList" %>

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
                            <asp:Label ID="Label1" runat="server" Text="Customer code :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtCus_Code" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td class="width15">
                            <asp:Label ID="Label2" runat="server" Text="Customer name :"></asp:Label>
                        </td>
                        <td class="width35">
                            <asp:TextBox ID="txtCus_Name" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Customer Birthday : </td>
                        <td>
                            <uc1:ucCalendar ID="ucCalendar_BirthdayFrom" runat="server" />
                            &nbsp;-&nbsp;
                            <uc1:ucCalendar ID="ucCalendar_BirthdayTo" runat="server" />
                        </td>
                        <td>Customer Email</td>
                        <td>
                            <asp:TextBox ID="txtCus_Email" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Customer Telephone : </td>
                        <td>
                            <asp:TextBox ID="txtCus_telphone" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td>Customer Amount :</td>
                        <td>
                            <asp:DropDownList ID="ddlSymbow" runat="server" Width="100px">
                                <asp:ListItem Value="1">=</asp:ListItem>
                                <asp:ListItem Value="2">&gt;=</asp:ListItem>
                                <asp:ListItem Value="3">&lt;=</asp:ListItem>
                            </asp:DropDownList> &nbsp;
                            <asp:TextBox ID="txtCus_Amount" runat="server" Width="200px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtCus_Amount_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtCus_Amount" ValidChars="0123456789">
                            </asp:FilteredTextBoxExtender>
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
                DataKeyNames="CUS_ID,CUS_CODE" OnPageIndexChanging="gv_detail_PageIndexChanging" OnRowCreated="gv_detail_RowCreated" OnRowDataBound="gv_detail_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ROW_INDEX" HeaderText="No.">
                        <HeaderStyle CssClass="width5" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CUS_CODE" HeaderText="Customer code">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Customer name" DataField="CUS_FULLNAME">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Birthday" DataField="CUS_BIRTHDAY_TEXT">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Telephone" DataField="CUS_TELEPHONE" />
                    <asp:BoundField HeaderText="Email" DataField="CUS_EMAIL"/>
                    <asp:BoundField HeaderText="Amount" DataField="CUS_TOTAL_AMOUNT" />
                    <asp:BoundField HeaderText="Point" DataField="CUS_POINT"/>
                    <asp:BoundField DataField="CUS_STATUS_TEXT" HeaderText="Status">
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Tools">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_view" runat="server" ImageUrl="~/img/icon/View.png" Width ="20px" Height ="20px" />
                        </ItemTemplate>
                        <HeaderStyle CssClass="width5" />
                        <ItemStyle CssClass="ItemStyle-center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
