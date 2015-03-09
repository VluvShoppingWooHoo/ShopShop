<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterAdmin.Master" AutoEventWireup="true" CodeBehind="frmCustomerList.aspx.cs" Inherits="VloveImport.web.Administrator.frmCustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        Customer List
        <br />
        Login
        <input type="text" id="txtUser" />
        <br />
        Name
        <input type="text" id="txtNamae" />
        <br />
        <button id="btnSearch" type="button" class="btn waves-effect orange waves-light" name="action">
            SEARCH
        </button>
        <br />
        <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="UserLogin" DataField="Login" />
                <asp:BoundField HeaderText="Firstname" DataField="Firstname" />
                <asp:BoundField HeaderText="Lastname" DataField="Lastname" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
