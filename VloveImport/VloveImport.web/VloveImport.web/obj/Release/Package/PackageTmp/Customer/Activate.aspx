﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Activate.aspx.cs" Inherits="VloveImport.web.Customer.Activate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="mView" runat="server" ActiveViewIndex="0">        
        <asp:View ID="vSuccess" runat="server">
            <table>
                <tr>
                    <td>
                        <span class="black-text bold">ยืนยันสำเร็จ</span>
                        <br />
                        <br />
                        <asp:LinkButton runat="server" Text="กดที่นี่" PostBackUrl="~/Index.aspx"></asp:LinkButton>&nbsp;
                        <span class="black-text">เพื่อเริ่มสั่งซื้อสินค้า</span>
                    </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="vError" runat="server">
            <table>
                <tr>
                    <td>
                        ยืนยันไม่สำเร็จ โปรดติดต่อเจ้าหน้าที่.
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>    
    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>
