<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="VloveImport.web.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <table width="100%" border="1">
            <tr>
                <td align="center">
                    <table width="80%">
                        <tr>
                            <td align="center">Logo
                            </td>
                        </tr>
                        <tr>
                            <td>หน้าแรก |
                        เกี่ยวกับเรา |
                        สมาชิก |
                        วิธีการสั่งซื้อสินค้า |
                        สั่งสินค้า |
                        ค่าขนส่ง |
                        ข่าวสารและกิจกรรม |
                        โปรโมชั่น |
                        ถามตอบ |
                        สมัครงาน |
                        ติดค่อเรา
                            </td>
                        </tr>
                        <tr>
                            <td>Search :
                                <asp:TextBox ID="txtsearchWeb" runat="server"></asp:TextBox>
                                <asp:Button ID="btnsreachWeb" runat="server" Text="GO" />
                            </td>
                        </tr>
                        <tr>
                            <td>Banner
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr>
                                        <td width="25%">Rate | Show Service Exchange Rate
                                        </td>
                                        <td width="50%">Logo Web shopping(List)
                                        </td>
                                        <td width="25%" align="left">Login
                                            <br />
                                            Username : 
                                            <asp:TextBox ID="txtusername" runat="server"></asp:TextBox><br />
                                            Password : 
                                            <asp:TextBox ID="txtpassword" TextMode="Password" runat="server"></asp:TextBox><br />
                                            <asp:CheckBox ID="cb_save_user" runat="server" Text ="จำชื่อผู้ใช้"/>
                                            <asp:Button ID="btnLogin" runat="server" Text="Button" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Preview Product
                            </td>
                        </tr>
                        <tr>
                            <td>
                                CMS 1
                            </td>
                        </tr>
                        <tr>
                            <td>
                                CMS 2
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="Images/demo/logo_all_company.png" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
