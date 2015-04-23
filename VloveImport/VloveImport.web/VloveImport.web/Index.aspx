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

                    <%--<span class="black-text">ตรวจสอบสถานะการขนส่งทางจีนได้</span> <a class="hvr-grow"  target="_blank" href="http://www.kuaidi100.com/"><span class="textUnderline bold red-text" style="font-size: 18px !important;">ที่นี่ <i class="mdi-maps-directions-ferry"></i></span></a>
                    <span class="black-text">ตรวจสอบเลขพัสดุไปรษณีย์</span> <a class="hvr-grow"  target="_blank" href="http://track.thailandpost.co.th/tracking/default.aspx"><span class="textUnderline bold red-text" style="font-size: 18px !important;">ที่นี่ <i class="mdi-maps-local-post-office"></i></span></a>--%>
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
        <%--<div class="row card-image small center maxheight200px">
            <img class="ImgheaderBanner maxheight200px" src="Images/pic/Banner1.png" width="80%" height="80%" />
        </div>--%>
        <%--<table>
            <tr>
                <td class="td">
                    <table id="Login" runat="server">
                        <tr>
                            <td>User                
                            </td>
                            <td>
                                <asp:TextBox ID="txtUser" runat="server">eakkarat_5@hotmail.com</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Pass
                            </td>
                            <td>
                                <asp:TextBox ID="txtPass" runat="server" TextMode="Password">123</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <button id="btnLogin" runat="server" type="submit" onserverclick="btnLogin_Click"
                                    name="action" class="btn waves-effect orange waves-light">
                                    Login                                
                                </button>
                                <button id="btnReset" runat="server" type="submit" onserverclick="btnReset_Click"
                                    name="action" class="btn waves-effect orange waves-light">
                                    Reset                                
                                </button>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="td">
                    <iframe id="ifrmBanner" scrolling="no" frameborder="0" src="http://www.bangkokbank.com/MajorRates/MainBannerThai.htm" width="170" height="160"></iframe>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="td">Item Category
                </td>
            </tr>
            <tr>
                <td class="promotion">Promotion
                </td>
                <td class="news">News
                </td>
            </tr>
            <tr>
                <td colspan="2" class="td">
                    <uc1:ucRecommend ID="ucRecommend" runat="server" />
                </td>
            </tr>
        </table>--%>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#divMenubar").hide();
            $("#divcontent").removeClass("col s10 m10 l10");
            $("#divcontent").addClass("col s12 m12 l12");
        });
    </script>
</asp:Content>
