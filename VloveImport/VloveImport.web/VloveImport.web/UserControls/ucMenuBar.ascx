<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuBar.ascx.cs" Inherits="VloveImport.web.UserControls.ucMenuBar" %>
<table>
    <tr>
        <td>
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem Text="หน้าแรก" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="เกี่ยวกับเรา" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="สมาชิก" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="วิธีการสั่งซื้อสินค้า" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="สั่งสินค้า" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ค่าขนส่ง" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ข่าวสารและกิจกรรม" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="โปรโมชั่น" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ติดต่อเรา" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </td>
    </tr>
</table>