<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="dummyCustomer.aspx.cs" Inherits="VloveImport.web.Customer.dummyCustomer" %>

<%@ Register Src="~/UserControls/ucCustomerMenuBar.ascx" TagPrefix="uc1" TagName="ucCustomerMenuBar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucCustomerMenuBar runat="server" id="ucCustomerMenuBar" />
    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
        });
    </script>
</asp:Content>
