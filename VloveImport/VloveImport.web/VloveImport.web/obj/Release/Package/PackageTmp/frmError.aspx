<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmError.aspx.cs" Inherits="VloveImport.web.frmError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        /*this is what we want the div to look like
        when it IS showing*/
        div.centered
        {
            display: block; /*set the div in the center of the screen*/
            /*position: absolute;
            top: 10%;
            left: 20%;
            width: 820px;*/
            margin: 0 auto; 
            padding-top: 30px;
            width: 800px;
            font-family: Tahoma;
            font-size: 13px;
            color: White;
        }
        div.centered p
        {
            margin: 0 auto;
            text-align: center;
        }
        a
        {
            color: White;
            text-decoration: underline;
        }
        a:hover
        {
            color: White;
            text-decoration: none;
        }
        a:visited
        {
            color: White;
        }
    </style>
</head>
<body style="background-color: #776865">
    <form id="form1" runat="server">
    <div class="centered">
        <p>
            <%--<img alt="" height="70" width="70" src="images/error02.png" />--%>
        </p>
        <p>                   
            ไม่พบหน้าที่เรียก หรือมีบางอย่างที่ทำให้หน้าเว็บนี้ไม่ทำงาน หากต้องการดำเนินการต่อให้กด
            โหลดซ้ำหรือไปที่หน้าอื่น
        </p>
        <p>
            There is a problem, Please try again in a few moments or reload the entire page
        </p>
        <p>   
            <br />
            <asp:TextBox ID="txtError" TextMode="MultiLine" Rows="15" Width="100%" runat="server"></asp:TextBox>   
            <br /><br />                  
            <input type="button" value="Back" onclick="javascript: history.back()" />
        </p>
    </div>
    </form>
</body>
</html>
