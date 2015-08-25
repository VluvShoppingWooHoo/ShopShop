<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRecommend.ascx.cs" Inherits="VloveImport.web.UserControls.ucRecommend" %>
<%@ Register Src="~/UserControls/ucContent.ascx" TagName="ucContent" TagPrefix="ucCT" %>

<div>
    <div id="divSeasonRecommend" class="" style="margin: 20px;">
        <div class="row recGradaint" style="text-align: center;">
            <span class="white-text" style="font-size: 20px !important; padding-left: 10px;">RecommendMain</span>
        </div>
        <div class="row backIMG">
            <div id="divSeasonRecommendNewest" class="col s4 m4 l4" style="padding-right: 0px; min-height: 350px; min-width: 350px;"></div>
            <div class="col s8 m8 l8">
                <div id="divSeasonSubRecommend1" class="row">
                </div>
                <div id="divSeasonSubRecommend2" class="row">
                </div>
            </div>
        </div>
    </div>
    <ucCT:ucContent ID="ucContent" runat="server" />
    <div id="divRecommend" class="" style="margin: 20px;">
        <div class="row recGradaint">
            <span class="white-text" style="font-size: 16px !important; padding-left: 10px;">Recommend</span>
        </div>
        <div class="row backIMG">
            <div id="divRecommendNewest" class="col s4 m4 l4" style="padding-right: 0px; min-height: 350px; min-width: 350px;"></div>
            <div class="col s8 m8 l8">
                <div id="divSubRecommend1" class="row">
                </div>
                <div id="divSubRecommend2" class="row">
                </div>
            </div>
        </div>
    </div>
</div>
<%--<div class="menuBar red" style="line-height: 150px; height: 150px;">
    <div class="col s2 m2 l2">
        <a class=" white-text font15" href="/Customer/TourMarket.aspx">Recommend 1</a>
    </div>
    <div class="col s2 m2 l2">
        <a class=" white-text font15" href="/Customer/TourMarket.aspx">Recommend 2</a>
    </div>
    <div class="col s2 m2 l2">
        <a class=" white-text font15" href="/Customer/TourMarket.aspx">Recommend 3</a>
    </div>
    <div class="col s2 m2 l2">
        <a class=" white-text font15" href="/Customer/TourMarket.aspx">Recommend 4</a>
    </div>
    <div class="col s2 m2 l2">
        <a class=" white-text font15" href="/Customer/TourMarket.aspx">Recommend 5</a>
    </div>
    <div class="col s2 m2 l2">
        <a class=" white-text font15" href="/Customer/TourMarket.aspx">Recommend 6</a>
    </div>
</div>--%>

