<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encryp.aspx.cs" Inherits="VloveImport.web.admin.pages.Encryp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnEncryp" runat="server" Text="Encryp" OnClick="btnEncryp_Click" />
        <asp:Button ID="btnDecryp" runat="server" Text="Decryp" OnClick="btnDecryp_Click" />
        <br /><br />
        <asp:TextBox ID="txt" runat="server" TextMode="MultiLine" Width="1000" Height="500"></asp:TextBox>
    </div>
    </form>
</body>
</html>
