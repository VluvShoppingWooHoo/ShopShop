<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSeachBox.ascx.cs" Inherits="VloveImport.web.UserControls.ucSeachBox" %>
<div class="row noafter">
    <div class="col s9 m9 l9">
        <div class="input-field orange-text row">
            <input id="txtSearch" type="text" class="validate">
            <label for="lbSearch" class="">Place web site here.</label>
        </div>
    </div>
    <div class="col s3" style="line-height:5">
        <button id="btnSearch" type="button" class="btn waves-effect orange waves-light" name="action">
            SEARCH     
            <i class="mdi-action-search right"></i>
        </button>
    </div>
</div>

<!-- Modal Structure -->
<div id="modalItem" class="modal modal-fixed-footer row">
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
        <h5 id="lblItemName">Modal Header</h5>
        <div class="card-image col s6 m6 l6">
            <img id="imgpicURL" height="200">
            <%--<img id="imgpicURL" src="http://img04.taobaocdn.com/bao/uploaded/i4/TB12EHiGVXXXXX6XXXXXXXXXXXX_!!0-item_pic.jpg_400x400.jpg" height="200">--%>
        </div>
        <div class="col s6 m6 l6">
            <div class="row">
                <p id="lblPrice">A bunch of tex2t</p>
            </div>
            <div class="row">
                <p id="lblProPrice">A bunch of t1ext</p>
            </div>
            <div id="liSize" class="row">                
                <%--<div id="liSize" class="">
                </div>--%>
                <%--<select id="liSize">
                    <option value="" disabled selected>Choose your option</option>
                </select>--%>
            </div>
            <div id="liColor" class="row">
                <%--<select id="liColor">
                    <option value="" disabled selected>Choose your option</option>
                </select>--%>
                <%--<div id="liColor" class="">
                </div>--%>
            </div>
        </div>
        <div class="row">
            <div class="col s2"></div>
            <div class="input-field col s8 m8 l8">
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
        <%--<a href="#" class="waves-effect waves-green btn-flat modal-action modal-close">Agree</a>--%>
    </div>
</div>

<script type="text/javascript">
    $(function () {
        //$('.childliSize').addClass('orange white-text');

        $('#btnSearch').click(function () {
            $('#loadingCircle').show();
            $('#loadingLine').show();
            $('#showData').hide();
            $('#footer').hide();
            $('#modalItem').openModal();
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
                    $('#footer').show();
                },
                error: function (err) {
                    alert('gs');
                }
            });
        });
    });

    function bindModal(data) {
        $(".childliSize").remove();
        $(".childliColor").remove();
        var obj = JSON.parse(data.d);
        $("#lblItemName").html(obj.ItemName);
        $("#imgpicURL").attr("src", obj.picURL);
        $("#lblPrice").html(obj.Price);
        $("#lblProPrice").html(obj.ProPrice);
        var arraySize = obj.Size.split("||");
        var arrayColor = obj.Color.split("||");
        $("#hdWeb").val(obj.Web);
        for (var i = 0; i < arraySize.length; i++) {
            //$("#liSize").append('<span>' + arraySize[i] + '</span>');
            $("#liSize").append('<div class="col s3"><a id="aSize' + i + '" onclick="selectSize(' + i + ')" class="waves-effect white orange-text waves-light btn childliSize" style="padding:0 ; margin-right:10px">' + arraySize[i] + '</a></div>');
        }
        for (var i = 0; i < arrayColor.length; i++) {
            //$("#liColor").append('<option value=""> ' + arrayColor[i] + ' </option>');
            //$("#liColor").append('<img src="' + arrayColor[i] + '">');
            $("#liColor").append('<div class="col s2"><a id="aColor' + i + '" onclick="selectColor(' + i + ')" class="waves-effect white orange-text waves-light btn childliColor" style="padding:0 ; margin-right:10px ; height:30px; width:30px;"><img src="' + arrayColor[i] + '"></a></div>');
        }

        //'<li><a href="/user/messages"><span class="tab">Message Center</span></a></li>');
        //alert(data.d);
    }

    function selectColor(e) {
        $('#liColor div a').removeClass('selectedBorder');
        $('#aColor' + e).addClass('selectedBorder');
        var url = $('#aColor' + e + ' img').attr('src');
        if ($("#hdWeb").val() == 1) {
            $("#imgpicURL").attr("src", url.replace('30x30' , '400x400'));
        }
    }

    function selectSize(e) {
        $('#liSize div a').addClass('white orange-text');
        $('#liSize div a').removeClass('orange white-text');
        $('#aSize' + e).removeClass('white orange-text');
        $('#aSize' + e).addClass('orange white-text');
    }

</script>
