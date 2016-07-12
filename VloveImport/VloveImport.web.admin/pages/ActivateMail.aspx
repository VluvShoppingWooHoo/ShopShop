<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivateMail.aspx.cs" Inherits="VloveImport.web.admin.pages.ActivateMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Email : 
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br /><br />
        Pass : 
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnSend" runat="server" Text="Send Activate" OnClick="btnSend_Click"/>
    </div>
    </form>
</body>
</html>
