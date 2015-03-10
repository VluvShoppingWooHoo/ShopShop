<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="frmOrderList.aspx.cs" Inherits="VloveImport.web.Administrator.frmOrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        Order List
        <br />
        Login
        <input type="text" id="txtLogin" />
        <br />
        ShopName
        <input type="text" id="txtShopName" />
        <br />
        <button id="btnSearch" type="button" class="btn waves-effect orange waves-light" name="action">
            SEARCH
        </button>        
        <br />
        <asp:GridView ID="gvOrder" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="UserLogin" DataField="Login" />
                <asp:BoundField HeaderText="Firstname" DataField="Firstname" />
                <asp:BoundField HeaderText="Lastname" DataField="Lastname" />
            </Columns>
        </asp:GridView>
    </div>

    <script type="text/javascript">
        $(function () {
            $('#btnSearch').click(function () {
                var login = $('#txtLogin').val();
                var shop = $('#txtShopName').val();
                var param = { "login": login, "shopname": shop };
                $.ajax({
                    type: 'POST',
                    url: "../Administrator/frmOrderList.aspx/btnSearch",
                    data: JSON.stringify(param),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                    },
                    error: function (err) {
                        alert('gs');
                    }
                });
            });
        });
    </script>
</asp:Content>

