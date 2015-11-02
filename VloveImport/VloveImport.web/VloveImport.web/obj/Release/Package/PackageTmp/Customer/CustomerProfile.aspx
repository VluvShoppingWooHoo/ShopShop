<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CustomerProfile.aspx.cs" Inherits="VloveImport.web.Customer.CustomerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col s8 m8 l8">
        <span class="FontHeader black-text">ข้อมูลของฉัน</span>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                Email
            </div>
            <div class="col s1 m1 l1"></div>
            <div class="col s9 m9 l9 paddingTop25">
                <asp:Label ID="lbEMail" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                รหัสผู้ใช้
            </div>
            <div class="col s1 m1 l1"></div>
            <div class="col s8 m8 l8 paddingTop25">
                <div class="col s2 m2 l2">
                    <asp:Label ID="lbCode" runat="server"></asp:Label>
                </div>
                <div class="col s1 m1 l1">
                    <span id="spanVip">
                        <i id="iVipCus" class="flaticon-business2" style="line-height: 25px"></i>
                    </span>
                </div>

            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                ชื่อ
            </div>
            <div class="col s1 m1 l1">
            </div>
            <div class="col s9 m9 l9 paddingTop15">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                นามสกุล
            </div>
            <div class="col s1 m1 l1">
            </div>
            <div class="col s9 m9 l9 paddingTop15">
                <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                วันเกิด
            </div>
            <div class="col s1 m1 l1">
            </div>
            <div class="col s9 m9 l9 paddingTop15">
                <asp:DropDownList ID="ddlDay" runat="server" AppendDataBoundItems="true"
                    Style="display: inline" Width="100px">
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlMonth" runat="server" AppendDataBoundItems="true"
                    Style="display: inline" Width="100px">
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:DropDownList ID="ddlYear" runat="server" AppendDataBoundItems="true"
                    Style="display: inline" Width="100px">
                </asp:DropDownList>
                <asp:HiddenField ID="hddDay" runat="server" />
                <asp:HiddenField ID="hddMonth" runat="server" />
                <asp:HiddenField ID="hddYear" runat="server" />
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                เพศ
            </div>
            <div class="col s1 m1 l1">
            </div>
            <div class="col s9 m9 l9 marginTop20" style="padding: 0px !important;">
                <asp:DropDownList ID="ddlGender" runat="server" Style="display: block">
                    <asp:ListItem Value="1" Text="ชาย"></asp:ListItem>
                    <asp:ListItem Value="2" Text="หญิง"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row divRowBlock">
            <div class="col s2 m2 l2 paddingTop25">
                ร้านค้า
            </div>
            <div class="col s1 m1 l1">
            </div>
            <div class="col s9 m9 l9 paddingTop15">
                <asp:TextBox ID="txtLinkShop" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row paddingTop25">
            <button id="btnSave" runat="server" type="submit" onserverclick="btnSave_Click"
                name="action" class="btn waves-effect orange waves-light">
                Save                                
            </button>
        </div>
    </div>
    <div class="col s4 m4 l4">
        <div class="row">
            <asp:Image ID="img" runat="server" ImageUrl="~/Images/pic/User.png" BorderWidth="1px"
                Width="150px" Height="200px" />
            <asp:HiddenField ID="hddImg" runat="server" />
        </div>
        <div class="row">
            <asp:FileUpload ID="uplImg" runat="server" />
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            SetFadeout();
        });
    </script>
    <script>
        var User = '<%= Session["VipLevel"]%>';

        if (User != '0' && User != '') {
            if (User == '1')
            { $('#iVipCus').addClass('brown-text text-lighten-1'); }
            else if (User == '2')
            { $('#iVipCus').addClass('red-text text-lighten-2'); }
            else if (User == '3')
            { $('#iVipCus').addClass('grey-text'); }
            else if (User == '4')
            { $('#iVipCus').addClass('yellow-text text-darken-1'); }
            else
            { $('#spanVip').hide(); }
        }
        else { $('#spanVip').hide(); }
    </script>
</asp:Content>

