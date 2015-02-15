<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSeachBox.ascx.cs" Inherits="VloveImport.web.UserControls.ucSeachBox" %>
<div class="row">
    <div class="col s10">
        <div class="input-field row">
        <input id="txtSearch" type="text" class="validate">
        <label for="lbSearch">Place web site here.</label>
      </div>
    </div>
    <div class="col s3">
        <button id="btnSearch" class="btn waves-effect waves-light" name="action">
            SEARCH
   
            <i class="mdi-action-bookmark right"></i>
        </button>
    </div>
</div>
<script type="text/javascript">    
    $(function () {
        $('#btnSearch').click(function () {
            var param = { "txt": $('#txtSearch').val() };
            $.ajax({
                type: 'POST',
                url: "../Index.aspx/GetModelFromURL",
                data: JSON.stringify(param),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    alert('YESS');
                },
                error: function (err) {
                    alert('gs');
                }
            });
        });
    });
</script>




