<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmReportCustomerOrder.aspx.cs" Inherits="VloveImport.web.admin.Report.frmReportCustomerOrder" %>

<%@ Register Src="../UserControls/ucCalendar.ascx" TagName="ucCalendar" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style ="margin-top:10px;">
    <h2 style ="color:#318DBF;">Order Managemaent</h2>
    <hr style="width:100%; text-align:left; margin-top:-15px; background-color :#D1DBE0; height:5px; color: #D1DBE0; border :0;"/>  
</div>    
    
    <fieldset style="width: 98.5%;">
        <legend>Search Criteria</legend>
        <table style="border: 1 solid;">
            <tr>
                <td class="width15">
                     <asp:Label ID="Label3" runat="server" Text="Customer Name :"></asp:Label>
                </td>
                <td class="width35">
                    <asp:TextBox ID="txtCusName" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td class="width15">
                    <asp:Label ID="Label2" runat="server" Text="Customer Code:"></asp:Label>
                </td>
                <td class="width35">
                    <asp:TextBox ID="txtCusCode" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                   <asp:Label ID="Label1" runat="server" Text="Order date :"></asp:Label>
                </td>
                <td colspan="3">
                    <uc1:ucCalendar ID="ucCalendar1" runat="server" />
                    &nbsp;-&nbsp;
                    <uc1:ucCalendar ID="ucCalendar2" runat="server" />
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
                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btnSearch" OnClick="btnSearch_Click1"/>&nbsp;&nbsp;
                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btnCancel" OnClick="btnReset_Click1"/>
                </td>
            </tr>
        </table>
    </fieldset>    

</asp:Content>
