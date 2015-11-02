﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ContentList.aspx.cs" Inherits="VloveImport.web.Customer.ContentList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="s12 m12 l12" id="divContentLists">
        </div>
    </div>
    <script type="text/javascript">
        $(function () {

            var ctype = getUrlParameter('ctype');
            var mny = getUrlParameter('mny');
            var pag = getUrlParameter('pag');
            if (typeof mny === 'undefined') {
                mny = '';
            }
            
            var PRO_MONTH = '<%= Session["PRO_MONTH"]%>';
            if (PRO_MONTH != '') {
                var txt = '';
                var obj = JSON.parse(PRO_MONTH);
                for (var i = 0; i < obj.ReturnVal.length; i++) {
                    txt += '<a href="/Customer/ContentList.aspx?ctype=' + ctype + '&pag=' + pag  + '&mny=' + obj.ReturnVal[i].MNY + '" class="collection-item mMonth" data-id="' + obj.ReturnVal[i].MNY + '">' + obj.ReturnVal[i].MONTH + ' ' + obj.ReturnVal[i].YEAR + '</a>';
                }
                $('#divSide').append(txt);                
            }
            else {
                window.location.href = "/Index.aspx";
            }

            var param = { "page": '0', "MNY": mny };
            $.ajax({
                type: 'POST',
                data: JSON.stringify(param),
                url: "../Customer/ContentList.aspx/GetContent",
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    var obj = JSON.parse(data.d);
                    if (obj.Result == 1) {
                        var txt = '<div class="collection">';
                        for (var i = 0; i < obj.ReturnVal.length; i++) {
                            if (obj.ReturnVal[i].ContentType == ctype) {
                                txt += '<a href="/Customer/ContentDetail.aspx?id=' + obj.ReturnVal[i].ContentID + '" class="collection-item"><img src="' + obj.ReturnVal[i].ContentImage + '" style="height:80px;width:150px;margin-right:3%;"/><span style="color:black;">' + obj.ReturnVal[i].ContentTitle + '</span></a>'
                            }
                        }
                        txt += '</div>';
                        $('#divContentLists').html(txt);
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
