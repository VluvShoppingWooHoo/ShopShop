<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VloveImport.web.Index" %>

<%@ Register Src="~/UserControls/ucRecommend.ascx" TagName="ucRecommend" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ucSeachBox.ascx" TagName="ucSeachBox" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ucIndexBox.ascx" TagName="ucIndexBox" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divIndex">
        <div class="row ucSearchbox" style="margin-left: 1%;">
            <div class="col s2 m2 l2">
                &nbsp;
                <img src="Images/pic/Logo/LOGO-01.jpg" style="height: 100%; width: 100%;" />
            </div>
            <div class="col s10 m10 l10">
                <uc3:ucSeachBox runat="server" ID="ucSeachBox" />
                <div style="text-align: center; width: 78%;">
                    <a class="red btn" style="min-width: 150px; margin-right: 20px;" target="_blank" href="http://www.kuaidi100.com/"><span>ตรวจสถานะการขนส่งทางจีน<i class="mdi-maps-directions-ferry"></i></span></a>
                    <a class="blue btn" style="min-width: 150px; margin-left: 20px;" target="_blank" href="http://track.thailandpost.co.th/tracking/default.aspx"><span>ตรวจสอบเลขพัสดุไปรษณีย์<i class="mdi-maps-local-post-office"></i></span></a>
                </div>
            </div>
        </div>
        <div class="row" style="margin-bottom: 0px">
            <div class="col s12 m12 l12">
                <div class="card" style="padding: 20px">
                    <uc4:ucIndexBox runat="server" ID="ucIndexBox" />
                </div>
            </div>            
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#divMenubar").hide();
            $("#divcontent").removeClass("col s10 m10 l10");
            $("#divcontent").addClass("col s12 m12 l12");
        });
    </script>
</asp:Content>
<%--<div>
    <img src="Images/pic/Under-construction.png" /><br/>ปิดทำการปรับปรุงชั่วคราว ขอบคุณค่ะ 
</div>--%>
