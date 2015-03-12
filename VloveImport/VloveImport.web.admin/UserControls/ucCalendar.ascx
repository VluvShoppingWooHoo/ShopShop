<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCalendar.ascx.cs" Inherits="VloveImport.web.admin.UserControls.ucCalendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:TextBox ID="txtcalendar" runat="server" MaxLength="10" Width="150px" onKeyDown ="return false;"></asp:TextBox>
<asp:CalendarExtender ID="txtcalendar_CalendarExtender" runat="server" DaysModeTitleFormat="dd MMMM, yyyy" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="btnimgCalFrom" TargetControlID="txtcalendar" TodaysDateFormat="dd MMMM  yyyy">
</asp:CalendarExtender>
<asp:ImageButton ID="btnimgCalFrom" runat="server" ImageUrl="~/img/icon/date.png" />