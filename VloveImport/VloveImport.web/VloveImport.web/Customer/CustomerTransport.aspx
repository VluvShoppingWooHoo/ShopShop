<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerTransport.aspx.cs" Inherits="VloveImport.web.Customer.CustomerTransport" %>

<%@ Register Src="~/UserControls/ucMenubar.ascx" TagName="ucMenubar" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col s12 m12 l12 TestBox1">
            ข้อมูลการขนส่ง
        <br />
            <br />

            <div class="row s6 m6 l6 TestBox1">
                1. ขนส่งจากจีนถึงไทย โดยวิธี 
            <br />
                <asp:RadioButtonList ID="rdbChina" runat="server" DataTextField="TRANS_NAME" DataValueField="TRANS_ID">
                </asp:RadioButtonList>
                <%--<asp:RadioButton ID="rdbCar" runat="server" GroupName="GROUP1" Text="ทางรถ (10-15 วัน)" />    
            <br />         
            <asp:RadioButton ID="rdbBoat" runat="server" GroupName="GROUP1" Text="ทางเรือ (20-25 วัน)" />         --%>
                <%--</div>
        
        <div class="row s6 m6 l6 TestBox1">--%>
                <br />
                2. ขนส่งภายในประเทศ โดยวิธี
            <br />
                <asp:RadioButtonList ID="rdbThai" runat="server" DataTextField="TRANS_NAME" DataValueField="TRANS_ID">
                </asp:RadioButtonList>
                <%--<asp:RadioButton ID="rdbSafe" runat="server" GroupName="GROUP2" Text="มารับเอง" />    
            <br />         
            <asp:RadioButton ID="rdbNim" runat="server" GroupName="GROUP2" Text="นิ่มซีเส็ง" />                     --%>
                <br />
                <button id="btnBack" runat="server" type="submit" onserverclick="btnBack_ServerClick"
                    name="action" class="btn waves-effect orange waves-light">
                    Back                                
                </button>
                <button id="btnOrder" runat="server" type="submit" onserverclick="btnOrder_ServerClick"
                    name="action" class="btn waves-effect orange waves-light">
                    Order                                
                </button>
            </div>

        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            SetFadeout();
            $('select').material_select();


        });
    </script>
</asp:Content>
