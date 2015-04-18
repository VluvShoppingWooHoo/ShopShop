<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="frmOrder_TEMP.aspx.cs" Inherits="VloveImport.web.admin.pages.frmOrder_TEMP" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Src="../UserControls/ucEmail.ascx" TagName="ucEmail" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        ORDER DETAIL
    </h2>
    <hr style="width:100%; text-align:left; background-color :#8db0ef; height:5px; color: #8db0ef; border :0;"/>
    <asp:TabContainer ID="TabBooking" runat="server" Width = "100%" ActiveTabIndex="0">
    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="งวดการจอง">
        <ContentTemplate>

        </ContentTemplate>
    </asp:TabPanel>        
    </asp:TabContainer>
</asp:Content>
