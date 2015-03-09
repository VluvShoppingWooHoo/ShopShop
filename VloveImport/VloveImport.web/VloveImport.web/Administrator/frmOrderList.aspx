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
        <input type="text" id="txtShopNamae" />
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
</asp:Content>
