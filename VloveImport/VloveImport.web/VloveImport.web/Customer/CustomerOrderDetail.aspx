<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerOrderDetail.aspx.cs" Inherits="VloveImport.web.Customer.CustomerOrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">        
        <div class="col s12 m12 l12">           
            <span class="orange-text FontHeader">รหัสใบสั่งซื้อ : <asp:Label ID="lbOrder_Code" runat="server"></asp:Label></span>
        </div>        
    </div>
    <div class="row">        
        <div class="col s6 m6 l6">           
            ผู้สั่ง : <asp:Label ID="lbCusName" runat="server"></asp:Label>
        </div>
        <div class="col s4 m4 l4">           
            
        </div>
        <div class="col s2 m2 l2">           
            วันที่สั่งซื้อ : <asp:Label ID="lbOrder_Date" runat="server"></asp:Label>
        </div>        
    </div>
    <div class="row">        
        <div class="col s6 m6 l6">           
            วิธีการขนส่ง : <asp:Label ID="lbOrderTransport" runat="server"></asp:Label>
        </div>
        <div class="col s4 m4 l4">           
            
        </div>
        <div class="col s2 m2 l2">           
            สถานะใบสั่งซื้อ : <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>        
    </div>
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

