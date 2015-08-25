<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ContentDetail.aspx.cs" Inherits="VloveImport.web.Customer.ContentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="s12 m12 l12" style="text-align:center;">
            <img id="contentDetailIMG" src="" style="width: 80%; min-height: 200px;" />
        </div>
    </div>
    <div class="row" style="margin-bottom: 2%; margin-top: 2%;">
        <div class="s12 m12 l12">
            <span id="contentDetailTitle" style="font-size: 50px !important;"></span>
        </div>
    </div>
    <div id="contentDetailDiv" class="row">
    </div>
    <script type="text/javascript">
        $(function () {
            var ID = getUrlParameter('id');
            var param = { "ID": ID };
            $.ajax({
                type: 'POST',
                data: JSON.stringify(param),
                url: "../Customer/ContentDetail.aspx/GetContentBYID",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    var obj = JSON.parse(data.d);
                    if (obj.Result == 1) {
                        $('#contentDetailIMG').attr("src", obj.ReturnVal.ContentImage);
                        $('#contentDetailTitle').html(obj.ReturnVal.ContentTitle);
                        $('#contentDetailDiv').html(obj.ReturnVal.ContentDetail);
                        //var h = $('#contentDetailIMG').outerHeight() + $('#contentDetailTitle').outerHeight() + $('#contentDetailDiv').outerHeight();
                        var h = $('#divcontent').height();
                        setHeight(h);
                    }
                },
                error: function (err) {
                    alert('Something wrong, please contact admin.');
                }
            });

            SetFadeout();
        });
    </script>
</asp:Content>
