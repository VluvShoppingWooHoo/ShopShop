<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuBar.ascx.cs" Inherits="VloveImport.web.UserControls.ucMenuBar" %>
<table>
    <tr>
        <td>
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem Text="หน้าแรก" NavigateUrl="~/Index.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="เกี่ยวกับเรา" NavigateUrl="~/Customer/AboutUs.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ทัวร์ตลาดจีน" NavigateUrl="~/Customer/TourMarket.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="วิธีการสั่งซื้อสินค้า" NavigateUrl="~/Customer/HowTo.aspx?type=order"></asp:MenuItem>
                    <asp:MenuItem Text="สั่งสินค้า" NavigateUrl="~/Customer/Order.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ค่าขนส่ง" NavigateUrl="~/Customer/HowTo.aspx?type=rateimport"></asp:MenuItem>
                    <asp:MenuItem Text="ข่าวสารและกิจกรรม" NavigateUrl="~/Customer/News.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="โปรโมชั่น" NavigateUrl="~/Customer/Promotion.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="สินค้าแนะนำ" NavigateUrl="~/Customer/Recommend.aspx"></asp:MenuItem>
                    <asp:MenuItem Text="ติดต่อเรา" NavigateUrl="~/Customer/ContactUs.aspx"></asp:MenuItem>                    
                </Items>
            </asp:Menu>
        </td>
    </tr>
</table>