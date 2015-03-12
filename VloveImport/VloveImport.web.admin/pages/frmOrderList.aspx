<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmOrderList.aspx.cs" Inherits="VloveImport.web.admin.pages.frmOrderList" %>
<%@ Register src="../UserControls/ucCalendar.ascx" tagname="ucCalendar" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style ="width:98.5%;">
        <legend>Search Criteria</legend>
        <table style ="border: 1 solid;">
            <tr>
                <td class ="width15">
                    <asp:Label ID="Label1" runat="server" Text="Order Date :"></asp:Label>
                </td>
                <td class ="width35">
                    <uc1:ucCalendar ID="ucCalendar1" runat="server" />
                    &nbsp;-&nbsp;
                    <uc1:ucCalendar ID="ucCalendar2" runat="server" />
                </td>
                <td class ="width15">
                    <asp:Label ID="Label2" runat="server" Text="Customer Name:"></asp:Label>
                </td>
                <td class ="width35">
                    <asp:TextBox ID="txtCusName" runat="server" Width ="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Order Status :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="-1">แสดงทั้งหมด</asp:ListItem>
                        <asp:ListItem Value="0">ยกเลิก</asp:ListItem>
                        <asp:ListItem Value="1">รอชำระเงิน</asp:ListItem>
                        <asp:ListItem Value="2">ชำระเงินแล้ว</asp:ListItem>
                        <asp:ListItem Value="3">รอจัดส่ง</asp:ListItem>
                        <asp:ListItem Value="4">ส่งสินค้าแล้ว</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td colspan ="4" style ="text-align:center;">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass ="btnSearch" OnClick="btnSearch_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass ="btnCancel" />
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:Label ID="lblResult" runat="server" Text="<b>Result Data</b>"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Width="95%">
        <Columns>
            <asp:BoundField DataField="Index" HeaderText="No." />
            <asp:BoundField HeaderText="Order ID" />
            <asp:BoundField HeaderText="Order Date" />
            <asp:BoundField HeaderText="Total Amount" />
            <asp:BoundField HeaderText="Customer Name" />
            <asp:BoundField HeaderText="Order Status" />
            <asp:BoundField HeaderText="Employee Name" />
            <asp:TemplateField HeaderText="Tools"></asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
