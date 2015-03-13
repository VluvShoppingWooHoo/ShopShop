<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerTranspot.aspx.cs" Inherits="VloveImport.web.Customer.CustomerTranspot" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col s10 m10 l10 TestBox1">
        ข้อมูลการขนส่ง
        <br />
        <br />
        
        <div class="row s6 m6 l6 TestBox1">
            1. ขนส่งจากจีนถึงไทย โดยวิธี 
            <br />
            <asp:RadioButton ID="rdbCar" runat="server" GroupName="GROUP1" Text="ทางรถ (10-15 วัน)" />    
            <br />         
            <asp:RadioButton ID="rdbBoat" runat="server" GroupName="GROUP1" Text="ทางเรือ (20-25 วัน)" />         
        <%--</div>
        
        <div class="row s6 m6 l6 TestBox1">--%>
            <br />
            2. ขนส่งภายในประเทศ โดยวิธี
            <br />
            <asp:RadioButton ID="rdbSafe" runat="server" GroupName="GROUP2" Text="มารับเอง" />    
            <br />         
            <asp:RadioButton ID="rdbNim" runat="server" GroupName="GROUP2" Text="นิ่มซีเส็ง" />                     
            <br />
            <asp:Button ID="btnUrder" runat="server" CssClass="btn waves-effect orange waves-light" OnClick="btnUrder_Click"/>
        </div>


    </div>

    <script type="text/javascript">
        $(function () {
            $("#masterForm").fadeIn(1000);
            $('select').material_select();

            
        });
    </script>
</asp:Content>
