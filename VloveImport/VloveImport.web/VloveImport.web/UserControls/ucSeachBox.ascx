<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSeachBox.ascx.cs" Inherits="VloveImport.web.UserControls.ucSeachBox" %>
<div class="row" style="margin-left: 10px;">
    <div style="width: 76.5%; display: inline-block;">
        <div class="input-field orange-text row">
            <input id="txtSearch" type="text" class="validate" style="border: solid 4px orange;">
            <label for="lbSearch" class="">Place web site here.</label>
        </div>
    </div>
    <div style="line-height: 4; display: inline-block; margin-left: 2%;">
        <button id="btnSearch" type="button" class="btn waves-effect orange waves-light modal-trigger" name="action" style="padding-left: 10px;">
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
    <div id="showData" class="modal-content row" style="padding: 5px 5px 60px 5px;">
        <div class="row card" style="margin-bottom: 10px">
            <div class="col s1 m1 l1" style="text-align: right">Link:</div>
            <div id="lblURL" class="col s11 m11 l11" style="overflow-x: auto;">
                <%--<h5 id="lblURL" class="card">Modal Header</h5>--%>
            </div>
        </div>

        <h3 id="lblItemName" class="card center">Modal Header</h3>
        <h1 id="lblShopName" class="card center" hidden></h1>
        <div class="row">
            <%--<div class="card col s4 m4 l4" style="max-height: 400px;">--%>
            <div class="card">
                <div class="card-image col s4 m4 l4" style="min-height: 200px;">
                    <img id="imgpicURL">
                    <%--<img id="imgpicURL" src="http://img04.taobaocdn.com/bao/uploaded/i4/TB12EHiGVXXXXX6XXXXXXXXXXXX_!!0-item_pic.jpg_400x400.jpg" height="200">--%>
                </div>
            </div>
            <div class="col s8 m8 l8" style="max-height: 200px; overflow-y: scroll;">
                <div id="divPrice" class="row" style="margin-bottom: 5px !important;">
                    <div class="col s1 m1 l1">Price:</div>
                    <div class="col s11 m11 l11">
                        <div id="lblPrice" class="row card center" style="margin-top: 0px !important;">
                        </div>
                    </div>
                </div>
                <%-- <div class="row">
                    <div class="col s3 m3 l3">Price</div>
                    <div class="col s9 m9 l9">
                        <p id="lblProPrice">A bunch of t1ext</p>
                    </div>
                </div>--%>
                <div id="divSize" class="row" style="margin-bottom: 5px !important;">
                    <div class="col s1 m1 l1">Size:</div>
                    <div class="col s11 m11 l11">
                        <div id="liSize" class="row card" style="margin-top: 0px !important;">
                        </div>
                    </div>
                </div>
                <div id="divColor" class="row" style="margin-bottom: 5px !important;">
                    <div class="col s1 m1 l1">Color:</div>
                    <div class="col s11 m11 l11">
                        <div id="liColor" class="row card" style="margin-top: 0px !important;">
                        </div>
                    </div>
                </div>
                <div id="divQTY" class="row">
                    <div class="col s1 m1 l1" style="margin-top: 3%;">QTY:</div>
                    <div class="col s5 m5 l5" style="margin: 0px">
                        <input id="aQTY" class="numberFormat" type="NUMBER" min="1" step="1" size="6" style="text-align: right;" value="1">
                        <%-- <ul class="pagination" style="margin: 0px">
                            <li class="" style="display: inline-block"><a id="aMinus" href="#!"><i class="mdi-navigation-chevron-left"></i></a></li>
                            <li class="" style="display: inline-block; vertical-align: text-bottom;"><a id="aQTY" href="#!" clss="">1</a></li>
                            <li class="" style="display: inline-block"><a id="aPlus" href="#!"><i class="mdi-navigation-chevron-right"></i></a></li>
                        </ul>--%>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <%--<div class="col s2"></div>--%>
            <div class="input-field col s12 m12 l12">
                <span class="red-text">หากราคาแสดงไม่ตรงกับที่เห็นจากเวปต้นทาง ให้ลูกค้าทำการกดสั่งซื้อไปก่อน แล้วราคาจะปรับใหม่หลังจากเจ้าหน้าที่ตรวจเช็คเรียบร้อยค่ะ</span>
            </div>
            <div class="input-field col s12 m12 l12">
                <i class="mdi-editor-mode-edit orange-text prefix"></i>
                <input id="txtRemark" type="text" class="validate">
                <%--<textarea id="txtRemark" class="materialize-textarea"></textarea>--%>
                <label for="txtRemark">Remark</label>
            </div>
            <div class="col s2"></div>
        </div>
    </div>
    <div id="footer" class="modal-footer" style="max-height:50px; padding:0 5px 0 0;">
        <input type="hidden" id="hdWeb">
        <input type="hidden" id="hdPrice">
        <button id="btnAddCart" type="button" class="btn waves-effect orange waves-light" name="action">
            <i class="mdi-action-shopping-cart NoFont"></i>
        </button>
        <button id="btnClose" type="button" class="btn waves-effect red white-text waves-light" name="action" style="margin-right: 25px">
            <i class="mdi-navigation-close NoFont"></i>
        </button>
        <%--<a href="#" class="waves-effect waves-green btn-flat modal-action modal-close">Agree</a>--%>
    </div>
</div>

<script type="text/javascript">

    //$("[class*='numberFormat']").keyup(function (evt) {
    //    txtWithcomma_onkeyup(evt);
    //});
    //$("[class*='numberFormat']").keydown(function (evt) {
    //    txtWithcomma_onkeydown(evt);
    //});
    //$("[class*='numberFormat']").blur(function (evt) {
    //    txtWithcomma_onblur(evt);
    //});
    //$("[class*='numberFormatNoneDecimal']").blur(function (evt) {
    //    txtWithcomma_onblurnonedecimal(evt);
    //});
    var isBetween = false;
    $(function () {
        //numberFormat();
        //$('.childliSize').addClass('orange white-text');
        $('.modal-trigger').leanModal({
            dismissible: false
        });

        $('#btnAddCart').click(function () {
            $('#Master_link').click();
            //$('#loadingMaster').show();

            var User = '<%= Session["User"]%>';
            if (User != '') {
                var size = $('#liSize div a.selected').html();
                var color = '';
                var price = $("#lblPrice").html();
                var remark = $("#txtRemark").val();
                var ShopName = $("#lblShopName").html();
                var Picture = $("#imgpicURL").attr('src');
                if ($('#liColor div a.selected img').length > 0) {
                    color = $('#liColor div a.selected img').attr("src");
                }
                else {
                    color = $('#liColor div a.selected').html();
                }
                if (typeof size === 'undefined') {
                    size = '';
                }
                if (typeof color === 'undefined') {
                    color = '';
                }
                if (typeof price === 'undefined' || price == '') {
                    price = '0';
                }
                if (typeof remark === 'undefined') {
                    remark = '';
                }
                if (typeof ShopName === 'undefined') {
                    ShopName = '';
                }
                var param = {
                    "Name": $("#lblItemName").html(), "Desc": '', "Amount": $("#aQTY").val(), "Price": price, "Size": size,
                    "Color": color, "Remark": remark, "URL": $("#lblURL").html(), "Picture": Picture, "ShopName": ShopName
                };
                $.ajax({
                    type: 'POST',
                    url: "../Index.aspx/btnSearch",
                    data: JSON.stringify(param),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        $('#loadingMaster').closeModal();
                        $('#modalItem').closeModal();
                        $('#MastermodalItem').closeModal();
                        $('#txtSearch').val('');
                        toast('Item Added.', 5000)
                    },
                    error: function (err) {
                        alert('Something wrong, please contact admin.  (Code : 2002)');
                    }
                });
            }
            else {
                var encodedString = btoa($("#lblURL").html());
                //var encodedString = btoa('Hello World');

                window.location.href = "/Customer/CustomerOrder.aspx?txt=" + encodedString;
            }
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
                    if (data.d == "") {
                        alert('Something wrong, please try again.  (Code : 2001)');
                        $('#loadingMaster').closeModal();
                        $('#modalItem').closeModal();
                        $('#MastermodalItem').closeModal();
                    }
                    else {
                        bindModal(data);
                        $('#loadingCircle').hide();
                        $('#loadingLine').hide();
                        $('#showData').show();
                        //$('#footer').show();
                        $('#btnAddCart').show();
                    }
                },
                error: function (err) {
                    alert('Something wrong, please try again.  (Code : 2001)');
                    $('#loadingMaster').closeModal();
                    $('#modalItem').closeModal();
                    $('#MastermodalItem').closeModal();
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
        $("#txtRemark").val('');
        //$('#aQTY').html('1');
        $('#aQTY').val(1);
        $(".childliSize").remove();
        $(".childliColor").remove();
        var obj = JSON.parse(data.d);
        $("#lblItemName").html(obj.ItemName);
        $("#lblShopName").html(obj.ShopName);
        $("#imgpicURL").attr("src", obj.picURL);
        $("#lblPrice").html(obj.Price);
        $("#lblURL").html(obj.URL);
        //$("#lblProPrice").html(obj.ProPrice);
        var arraySize = obj.Size.split("||");
        var arrayColor = obj.Color.split("||");
        var firstSize = true;
        var firstColor = true;
        $("#hdPrice").val(obj.Price);

        if (obj.Price.split(" - ").length > 1) {
            var prices = $("#hdPrice").val().split(" - ");
            $("#hdPrice").val(prices[1])
            $("#lblPrice").html(prices[1])
        }

        $("#hdWeb").val(obj.Web);

        //if (obj.Price.indexOf(" - ") > 0)
        //    isBetween = true;

        for (var i = 0; i < arraySize.length; i++) {
            var txt = '<div class="col s1 m1 l1 modalItemDiv childliSize"><a id="aSize' + i + '" onclick="selectSize(' + i + ')" class="waves-effect waves-light btn';
            if (firstSize == true) {
                if (isBetween == true) {
                    chkPrice(arraySize[i])
                }
                txt += ' orange white-text selected';
            }
            else
                txt += ' white orange-text';
            txt += '" style="margin-right:10px">' + arraySize[i] + '</a></div>';
            firstSize = false;
            if (arraySize[i] != "")
                $("#liSize").append(txt);

        }
        if ($('div[class~="childliSize"]').length == 0)
            $("#divSize").hide();
        for (var i = 0; i < arrayColor.length; i++) {
            var txt = '<div class="';

            if (arrayColor[i].indexOf("ttp:") > 0) {
                txt += 'col s2 m2 l2 childliColor"><a id="aColor' + i + '" onclick="selectColor(' + i + ')" class="waves-effect waves-light btn'
                if (firstColor == true) {
                    txt += ' orange white-text selected selectedBorder';
                }
                else
                    txt += ' white orange-text';
                txt += '" style="padding:0; margin-right:10px ; height:30px; width:30px;"><img src="' + arrayColor[i] + '"></a></div>';
            }
            else
                if (arrayColor[i] != "") {
                    //txt += 'col s1 m1 l1 modalItemDiv childliColor"><a id="aColor' + i + '" onclick="selectColorText(' + i + ')" class="waves-effect waves-light btn';
                    txt += 'col s1 m1 l1 modalItemDiv childliColor"><a id="aColor' + i + '" onclick="selectColor(' + i + ')" class="waves-effect waves-light btn';
                    if (firstColor == true) {
                        if (isBetween == true) {
                            chkPrice(arrayColor[i])
                        }
                        txt += ' orange white-text selected';
                    }
                    else
                        txt += ' white orange-text';
                    txt += '" style="margin-right:10px">' + arrayColor[i] + '</a></div>';
                }
            firstColor = false;

            $("#liColor").append(txt);
        }
        if ($('div[class~="childliColor"]').length == 0)
            $("#divColor").hide();
        //'<li><a href="/user/messages"><span class="tab">Message Center</span></a></li>');
        //alert(data.d);
    }

    function chkPrice(e) {
        var prices = $("#hdPrice").val().split(" - ");
        if (e.indexOf(prices[0].split(".")[0]) > 0)
            $("#lblPrice").html(prices[0]);
        else
            $("#lblPrice").html(prices[1]);
    }

    function selectColor(e) {
        $('#liColor div a').addClass('white orange-text');
        $('#liColor div a').removeClass('orange white-text');
        $('#liColor div a').removeClass('selected');
        $('#liColor div a').removeClass('selectedBorder');
        $('#aColor' + e).removeClass('white orange-text');
        $('#aColor' + e).addClass('orange white-text');
        $('#aColor' + e).addClass('selectedBorder');
        $('#aColor' + e).addClass('selected');
        var url = $('#aColor' + e + ' img').attr('src');
        if (typeof url === 'undefined') {
        }
        else {
            $("#imgpicURL").attr("src", url.replace('30x30', '300x300').replace('40x40', '300x300'));
        }
        //if ($("#hdWeb").val() == 1) {
        //$("#imgpicURL").attr("src", url.replace('30x30', '400x400'));
        //}
    }

    function selectColorText(e) {
        $('#liColor div a').addClass('white orange-text');
        $('#liColor div a').removeClass('orange white-text');
        $('#liColor div a').removeClass('selected');
        $('#aColor' + e).removeClass('white orange-text');
        $('#aColor' + e).addClass('orange white-text');
        $('#aColor' + e).addClass('selected');
        chkPrice($('#aColor' + e)[0].innerText);
    }

    function selectSize(e) {
        $('#liSize div a').addClass('white orange-text');
        $('#liSize div a').removeClass('orange white-text');
        $('#liSize div a').removeClass('selected');
        $('#aSize' + e).removeClass('white orange-text');
        $('#aSize' + e).addClass('orange white-text');
        $('#aSize' + e).addClass('selected');
        chkPrice($('#aSize' + e)[0].innerText);
    }

</script>
