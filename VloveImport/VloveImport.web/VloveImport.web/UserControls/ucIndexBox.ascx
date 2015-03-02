<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucIndexBox.ascx.cs" Inherits="VloveImport.web.UserControls.ucIndexBox" %>
<div class="row">
    <div id="sideMenu" class="col s3 m3 l3">
        Item Category Side Menu
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
    var count = 1;
    $(function () {

        //setInterval('cycleMe(' + count + ')', 4000);
        //var options = { $AutoPlay: true };
        //var jssor_slider1 = new $JssorSlider$('slider1_container', options);
    });

    function cycleMe(e) {
        $(".indicators li .li" + count).click();
        count++;
        if (count > 3)
            count = 1;
        //alert('Bommy');
    }
</script>
