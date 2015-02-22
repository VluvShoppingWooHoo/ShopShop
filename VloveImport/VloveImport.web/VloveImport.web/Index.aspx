<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VloveImport.web.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row card-image small center maxheight300px">
        <img class="ImgheaderBanner maxheight300px" src="Images/pic/Banner1.png" />
    </div>
    <table>
        <tr>
            <td class="td">              
                <iframe id="ifrmBanner" scrolling="no" frameborder="0" src="http://www.bangkokbank.com/MajorRates/MainBannerThai.htm" width="170" height="160" ></iframe>
            </td>
            <td class="td">Login
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
    </table>
</asp:Content>


