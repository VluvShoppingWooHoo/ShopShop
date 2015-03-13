<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAdminIndex.aspx.cs" Inherits="VloveImport.web.admin.frmAdminIndex" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LOGIN :: I LOVE IMPORT</title>
    <meta charset="utf-8">
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>

    <!-----start-main---->
    <div class="login-form">
        <h1>LOGIN</h1>
        <form id="form1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <li>
                        <asp:TextBox ID="txtuser" CssClass="text" runat="server" TabIndex ="1"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="txtuser_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtuser" WatermarkText="USERNAME">
                        </asp:TextBoxWatermarkExtender>
                        <a href="#" class=" icon user"></a>
                    </li>
                    <li>
                        <asp:TextBox ID="txtpassword" CssClass="text" TextMode="Password" runat="server" TabIndex ="2"></asp:TextBox><a href="#" class=" icon lock"></a>
                        <asp:TextBoxWatermarkExtender ID="txtpassword_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtpassword" WatermarkText="PASSWORD">
                        </asp:TextBoxWatermarkExtender>
                    </li>
                    <br />
                    <div class="forgot">
                          <asp:Button ID="btnLogin" runat="server" Text="LOGIN" Height="60px" OnClick="btnLogin_Click" TabIndex ="3"/><a href="#" class=" icon arrow"></a>                                                                                                                                                                                                                      </h4>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </form>
    </div>
    <!--//End-login-form-->
</body>
</html>


<!DOCTYPE html>
