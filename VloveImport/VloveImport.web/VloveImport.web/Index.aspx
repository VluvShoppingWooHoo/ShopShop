<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VloveImport.web.Index" %>

<%@ Register Src="~/UserControls/ucRecommend.ascx" TagName="ucRecommend" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ucSeachBox.ascx" TagName="ucSeachBox" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ucIndexBox.ascx" TagName="ucIndexBox" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divIndex">
        <div class="row ucSearchbox">
            <div class="col s3 m3 l3">
                &nbsp;
            </div>
            <div class="col s9 m9 l9">
                <uc3:ucSeachBox runat="server" ID="ucSeachBox" />
            </div>
        </div>
        <div class="row" style="margin-bottom: 0px">
            <div class="col s12 m12 l12">
                <div class="card" style="padding: 20px">
                    <uc4:ucIndexBox runat="server" ID="ucIndexBox" />
                </div>
            </div>
        </div>
        <div class="row card-image small center maxheight200px">
            <img class="ImgheaderBanner maxheight200px" src="Images/pic/Banner1.png" width="80%" height="80%" />
        </div>
        <table>
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
        </table>
    </div>
</asp:Content>


