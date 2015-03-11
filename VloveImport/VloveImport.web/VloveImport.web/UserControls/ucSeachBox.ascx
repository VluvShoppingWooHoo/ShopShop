<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSeachBox.ascx.cs" Inherits="VloveImport.web.UserControls.ucSeachBox" %>
<div class="row">
    <div class="col s9 m9 l9">
        <div class="input-field orange-text row">
            <input id="txtSearch" type="text" class="validate">
            <label for="lbSearch" class="">Place web site here.</label>
        </div>
    </div>
    <div class="col s3" style="line-height: 5">
        <button id="btnSearch" type="button" class="btn waves-effect orange waves-light modal-trigger" name="action">
            SEARCH     
            <i class="mdi-action-search right"></i>
        </button>
        <a href="#modalItem" class="modal-trigger" id="a_link" hidden>content</a>
    </div>
</div>

<!-- Modal Structure -->
<div id="modalItem" class="modal modal-fixed-footer white row">
    <div id="loadingCircle" class="preloader-wrapper big active center-Preload-Circle">
        <div class="spinner-layer spinner-yellow">
            <div class="circle-clipper left">
                <div class="circle"></div>
            </div>
            <div class="gap-patch">
                <div class="circle"></div>
            </div>
            <div class="circle-clipper right">
                <div class="circle"></div>
            </div>
        </div>
        <div class="spinner-layer spinner-orange">
            <div class="circle-clipper left">
                <div class="circle"></div>
            </div>
            <div class="gap-patch">
                <div class="circle"></div>
            </div>
            <div class="circle-clipper right">
                <div class="circle"></div>
            </div>
        </div>
        <div class="spinner-layer spinner-deep-orange">
            <div class="circle-clipper left">
                <div class="circle"></div>
            </div>
            <div class="gap-patch">
                <div class="circle"></div>
            </div>
            <div class="circle-clipper right">
                <div class="circle"></div>
            </div>
        </div>
        <div class="spinner-layer spinner-red ">
            <div class="circle-clipper left">
                <div class="circle"></div>
            </div>
            <div class="gap-patch">
                <div class="circle"></div>
            </div>
            <div class="circle-clipper right">
                <div class="circle"></div>
            </div>
        </div>
    </div>
    <div id="loadingLine" class="progress center-Preload-Line">
        <div class="indeterminate"></div>
    </div>
    <div id="showData" class="modal-content row">
        <div class="row card" style="margin-bottom: 15px">
            <div class="col s1 m1 l1" style="text-align: right">Link:</div>
            <div id="lblURL" class="col s11 m11 l11" style="overflow-x: auto;">
                <%--<h5 id="lblURL" class="card">Modal Header</h5>--%>
            </div>
        </div>

        <h1 id="lblItemName" class="card center">Modal Header</h1>
        <div class="row">
            <div class="card-image col s4 m4 l4">
                <img id="imgpicURL" height="200">
                <%--<img id="imgpicURL" src="http://img04.taobaocdn.com/bao/uploaded/i4/TB12EHiGVXXXXX6XXXXXXXXXXXX_!!0-item_pic.jpg_400x400.jpg" height="200">--%>
            </div>
            <div class="col s8 m8 l8">
                <div id="divPrice" class="row">
                    <div class="col s1 m1 l1">Price:</div>
                    <div class="col s11 m11 l11">
                        <div id="lblPrice" class="row card center">
                        </div>
                    </div>
                </div>
                <%-- <div class="row">
                    <div class="col s3 m3 l3">Price</div>
                    <div class="col s9 m9 l9">
                        <p id="lblProPrice">A bunch of t1ext</p>
                    </div>
                </div>--%>
                <div id="divSize" class="row">
                    <div class="col s1 m1 l1">Size:</div>
                    <div class="col s11 m11 l11">
                        <div id="liSize" class="row card">
                        </div>
                    </div>
                </div>
                <div id="divColor" class="row">
                    <div class="col s1 m1 l1">Color:</div>
                    <div class="col s11 m11 l11">
                        <div id="liColor" class="row card">
                        </div>
                    </div>
                </div>
                <div id="divQTY" class="row">
                    <div class="col s1 m1 l1">QTY:</div>
                    <div class="col s4 m4 l4" style="margin: 0px">
                        <ul class="pagination" style="margin: 0px">
                            <li class="" style="display: inline-block"><a id="aMinus" href="#!"><i class="mdi-navigation-chevron-left"></i></a></li>
                            <li class="" style="display: inline-block"><a id="aQTY" href="#!" class="">1</a></li>
                            <li class="" style="display: inline-block"><a id="aPlus" href="#!"><i class="mdi-navigation-chevron-right"></i></a></li>
                        </ul>

                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <%--<div class="col s2"></div>--%>
            <div class="input-field col s12 m12 l12">
                <i class="mdi-editor-mode-edit orange-text prefix"></i>
                <input id="txtRemark" type="text" class="validate">
                <%--<textarea id="txtRemark" class="materialize-textarea"></textarea>--%>
                <label for="txtRemark">Remark</label>
            </div>
            <div class="col s2"></div>
        </div>
    </div>
    <div id="footer" class="modal-footer">
        <input type="hidden" id="hdWeb">
        <button id="btnAddCart" type="button" class="btn waves-effect orange waves-light" name="action">
            <i class="mdi-action-shopping-cart"></i>
        </button>
        <button id="btnClose" type="button" class="btn waves-effect red white-text waves-light" name="action" style="margin-right: 25px">
            <i class="mdi-navigation-close"></i>
        </button>
        <%--<a href="#" class="waves-effect waves-green btn-flat modal-action modal-close">Agree</a>--%>
    </div>
</div>

<script type="text/javascript">
    $(function () {
        //$('.childliSize').addClass('orange white-text');
        $('.modal-trigger').leanModal({
            dismissible: false
        });

        $('#btnAddCart').click(function () {

            var size = $('#liSize div a.selected').html();
            var color = '';
            if ($('#liColor div a.selected img').length > 0) {
                color = $('#liColor div a.selected img').attr("src");
            }
            else {
                color = $('#liColor div a.selected').html();
            }
            var param = {
                "Name": $("#lblItemName").html(), "Desc": '', "Amount": $("#aQTY").html(), "Price": $("#lblPrice").html(), "Size": size,
                "Color": color, "Remark": $("#txtRemark").val(), "URL": $("#lblURL").html(), "Picture": ''
            };
            $.ajax({
                type: 'POST',
                url: "../Index.aspx/btnSearch",
                data: JSON.stringify(param),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    $('#modalItem').closeModal();
                },
                error: function (err) {
                    alert('gs');
                }
            });
        });

        $('#btnClose').click(function () {
            $('#modalItem').closeModal();
        });

        $('#btnSearch').click(function () {
            $('#loadingCircle').show();
            $('#loadingLine').show();
            $('#showData').hide();
            //$('#footer').hide();
            $('#btnAddCart').hide();
            
            //$('#modalItem').openModal();
            $("#a_link")[0].click();
            var param = { "txt": $('#txtSearch').val() };
            $.ajax({
                type: 'POST',
                url: "../Index.aspx/GetModelFromURL",
                data: JSON.stringify(param),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    bindModal(data);
                    $('#loadingCircle').hide();
                    $('#loadingLine').hide();
                    $('#showData').show();
                    //$('#footer').show();
                    $('#btnAddCart').show();
                },
                error: function (err) {
                    alert('gs');
                }
            });
        });

        $('#aMinus').on("click", function () {
            var qty = $('#aQTY').html();
            if (qty != "1") {
                qty--;
                $('#aQTY').html(qty);
            }
        })

        $('#aPlus').on("click", function () {
            var qty = $('#aQTY').html();
            qty++;
            $('#aQTY').html(qty);
        })
    });

    function bindModal(data) {

        $("#divPrice").show();
        $("#divSize").show();
        $("#divColor").show();

        $(".childliSize").remove();
        $(".childliColor").remove();
        var obj = JSON.parse(data.d);
        $("#lblItemName").html(obj.ItemName);
        $("#imgpicURL").attr("src", obj.picURL);
        $("#lblPrice").html(obj.Price);
        $("#lblURL").html(obj.URL);
        //$("#lblProPrice").html(obj.ProPrice);
        var arraySize = obj.Size.split("||");
        var arrayColor = obj.Color.split("||");
        $("#hdWeb").val(obj.Web);

        for (var i = 0; i < arraySize.length; i++) {
            //$("#liSize").append('<span>' + arraySize[i] + '</span>');
            if (arraySize[i] != "")
                $("#liSize").append('<div class="col s1 m1 l1 modalItemDiv childliSize"><a id="aSize' + i + '" onclick="selectSize(' + i + ')" class="waves-effect white orange-text waves-light btn" style="margin-right:10px">' + arraySize[i] + '</a></div>');
        }
        if ($('div[class~="childliSize"]').length == 0)
            $("#divSize").hide();
        for (var i = 0; i < arrayColor.length; i++) {
            //$("#liColor").append('<option value=""> ' + arrayColor[i] + ' </option>');
            //$("#liColor").append('<img src="' + arrayColor[i] + '">');
            if (arrayColor[i].indexOf("ttp:") > 0)
                $("#liColor").append('<div class="col s2 m2 l2 childliColor"><a id="aColor' + i + '" onclick="selectColor(' + i + ')" class="waves-effect white orange-text waves-light btn" style="padding:0; margin-right:10px ; height:30px; width:30px;"><img src="' + arrayColor[i] + '"></a></div>');
            else
                if (arrayColor[i] != "")
                    $("#liColor").append('<div class="col s1 m1 l1 modalItemDiv childliColor"><a id="aColor' + i + '" onclick="selectColorText(' + i + ')" class="waves-effect white orange-text waves-light btn" style="margin-right:10px">' + arrayColor[i] + '</a></div>');
        }
        if ($('div[class~="childliColor"]').length == 0)
            $("#divColor").hide();
        //'<li><a href="/user/messages"><span class="tab">Message Center</span></a></li>');
        //alert(data.d);
    }

    function selectColor(e) {
        $('#liColor div a').removeClass('selected');
        $('#liColor div a').removeClass('selectedBorder');
        $('#aColor' + e).addClass('selectedBorder');
        $('#aColor' + e).addClass('selected');
        var url = $('#aColor' + e + ' img').attr('src');
        if ($("#hdWeb").val() == 1) {
            $("#imgpicURL").attr("src", url.replace('30x30', '400x400'));
        }
    }

    function selectColorText(e) {
        $('#liColor div a').addClass('white orange-text');
        $('#liColor div a').removeClass('orange white-text');
        $('#liColor div a').removeClass('selected');
        $('#aColor' + e).removeClass('white orange-text');
        $('#aColor' + e).addClass('orange white-text');
        $('#aColor' + e).addClass('selected');
    }

    function selectSize(e) {
        $('#liSize div a').addClass('white orange-text');
        $('#liSize div a').removeClass('orange white-text');
        $('#liSize div a').removeClass('selected');
        $('#aSize' + e).removeClass('white orange-text');
        $('#aSize' + e).addClass('orange white-text');
        $('#aSize' + e).addClass('selected');
    }

</script>
