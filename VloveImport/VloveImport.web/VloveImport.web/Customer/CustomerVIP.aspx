<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerVIP.aspx.cs" Inherits="VloveImport.web.Customer.CustomerVIP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    <div class="col s12 m12 l12">
        <span class="FontHeader black-text">สมัครบริการเสริม VIP</span>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                Type of VIP
            </div>
            <div class="col s1 m1 l1"></div>
            <div class="col s9 m9 l9 paddingTop25">
                &nbsp;
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                &nbsp;
            </div>
            <div class="col s1 m1 l1"></div>
            <div class="col s9 m9 l9 paddingTop25">                
                <asp:RadioButton ID="rdbVIP6" runat="server" GroupName="VIP" />
                <br />
                <asp:RadioButton ID="rdbVIP12" runat="server" GroupName="VIP" />
                <br />
                <asp:RadioButton ID="rdbSuperVIP6" runat="server" GroupName="VIP" />
                <br />
                <asp:RadioButton ID="rdbSuperVIP12" runat="server" GroupName="VIP" />
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                &nbsp;
            </div>
            <div class="col s8 m8 l8 paddingTop25">
                <asp:Button ID="btnSelect" runat="server" Text="สมัครบริการ VIP" OnClick="btnSelect_Click" OnClientClick="return confirm('คุณกำลังสมัครบริการ VIP?')" />
            </div>
            <div class="col s2 m2 l2 paddingTop25">
                &nbsp;
            </div>
        </div>
    </div>
    
    

    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
</asp:Content>

