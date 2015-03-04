<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerBasket.aspx.cs" Inherits="VloveImport.web.Customer.CustomerBasket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ค้นหา
    <div class="col s3 m3 l3 TestBox1"></div>
    <button id="btnSearch" runat="server" type="submit" onserverclick="btnSearch_Click" 
        name="action" class="btn waves-effect orange waves-light">Search                                
    </button>
    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
        });
    </script>
</asp:Content>

