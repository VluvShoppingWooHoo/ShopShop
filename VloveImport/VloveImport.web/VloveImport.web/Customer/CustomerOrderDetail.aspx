<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerOrderDetail.aspx.cs" Inherits="VloveImport.web.Customer.CustomerOrderDetail" %>

<%@ Register Src="~/UserControls/ucSeachBox.ascx" TagName="ucSeachBox" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">        
        <div class="row ucSearchbox" style="margin-left: 1%;">           
            <div class="col s12 m12 l12" style="min-height:300px;">
                ใส่ Link ของสินค้าที่ต้องการ 
                <br />
                <uc3:ucSeachBox runat="server" ID="ucSeachBox" />
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            var txt = getUrlParameter('txt');
            var decodedString = atob(txt);
            $('#txtSearch').val(decodedString);
            SetFadeout();
        });
    </script>
</asp:Content>

