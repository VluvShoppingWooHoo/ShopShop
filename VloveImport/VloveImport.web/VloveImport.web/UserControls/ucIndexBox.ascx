<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucIndexBox.ascx.cs" Inherits="VloveImport.web.UserControls.ucIndexBox" %>
<div class="row">
    <div id="sideMenu" class="col s3 m3 l3">
    </div>
    <div class="col s6 m6 l6">
         <div class="slider">
    <ul class="slides">
      <li class="li1">
        <img src="../Images/pic/Banner1.png" /><!-- random image -->
      </li>
      <li class="li2">
        <img src="../Images/pic/beautiful-art-of-chinese-new-year.jpg" /> <!-- random image -->
      </li>
      <li class="li3">
        <img src="../Images/pic/RateImport-Q.gif" /> <!-- random image -->
      </li>
    </ul>
  </div>
    </div>
    <div class="col s3 m3 l3">
        etc.
    </div>
</div>

<script type="text/javascript">
    $(function () {

        $.ajax({
            type: 'POST',
            url: "../Index.aspx/GetSideMenu",
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                var txt = data.d;
                var regex = /\\/g;
                txt = txt.replace("\\", "\\\\");
                $("#sideMenu").html(txt);
                $("#masterForm").fadeIn(1000);
            },
            error: function (err) {
                alert('gs');
            }
        });
    });
</script>
