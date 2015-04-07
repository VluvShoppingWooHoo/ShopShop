<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerOrderDetail.aspx.cs" Inherits="VloveImport.web.Customer.CustomerOrderDetail" %>

<%@ Register Src="~/UserControls/ucSeachBox.ascx" TagName="ucSeachBox" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">        
        <div class="col s6 m6 l">           
            วันที่สั่งซื้อ : <asp:Label ID="lbOrderDate" runat="server"></asp:Label>
        </div>
        <div class="col s4 m4 l4">           
            
        </div>
        <div class="col s2 m2 l2">           
            สถานะใบสั่งซื้อ : <asp:Label ID="lbOrder_STatus" runat="server"></asp:Label>
        </div>
        <div class="col s4 m4 l4">           
            <asp:Label ID="" runat="server"></asp:Label>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

