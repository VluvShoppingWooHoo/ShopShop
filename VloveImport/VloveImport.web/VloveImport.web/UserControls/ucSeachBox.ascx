<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSeachBox.ascx.cs" Inherits="VloveImport.web.UserControls.ucSeachBox" %>
<div class="row">
    <div class="col s9">
        <div class="input-field row">
            <input id="txtSearch" type="text" class="validate">
            <label for="lbSearch">Place web site here.</label>
        </div>
    </div>
    <div class="col s3">
        <button id="btnSearch" type="button" class="btn waves-effect waves-light" name="action">
            SEARCH
   
            <i class="mdi-action-bookmark right"></i>
        </button>
    </div>
</div>

<!-- Modal Structure -->
<div id="modalItem" class="modal modal-fixed-footer row">
    <div id="loadingCircle" class="preloader-wrapper big active center-Preload-Circle">
        <div class="spinner-layer spinner-blue ">
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
        <div class="spinner-layer spinner-red">
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
        <div class="spinner-layer spinner-green">
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
        <div class="card-image">
            <img id="imgpicURL" height="200">
            <%--<span class="card-title">Card Title</span>--%>
        </div>
        <p id="lblPrice">A bunch of text</p>
        <p id="lblProPrice">A bunch of text</p>
    </div>
    <div id="footer" class="modal-footer">
        <a href="#" class="waves-effect waves-green btn-flat modal-action modal-close">Agree</a>
    </div>
</div>

<script type="text/javascript">
    $(function () {

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
        var obj = JSON.parse(data.d);
        $("#lblItemName").html(obj.ItemName);
        $("#imgpicURL").attr("src", obj.picURL);
        $("#lblPrice").html(obj.Price);
        $("#lblProPrice").html(obj.ProPrice);

        //alert(data.d);
    }
</script>




