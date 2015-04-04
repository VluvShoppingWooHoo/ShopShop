<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="VloveImport.web.TestPage" %>

<!DOCTYPE html>
<style>
    .TestBox1
    {
        border: 2px solid blue;
        margin-top: 10px;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="../App_Themes/css/materialize.min.css" media="screen,projection" />
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script type="text/javascript" src="../App_Themes/js/materialize.min.js"></script>
    <%--<script src="../App_Themes/js/jquery.form.js"></script>--%>
    <link href="../App_Themes/th1/css.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <div class="row">
            <div class="col s2 m2 l2">
                <%--<a href="#" data-activates="slide-out" class="button-collapse"><i class="mdi-navigation-menu"></i></a>--%>
                Side Menu
                <ul id="Ul2" class="side-nav fixed">
                    <li class="bold"><a href="#!" class="waves-effect waves-red">1</a></li>
                    <li class="bold"><a href="#!" class="waves-effect waves-black">2</a></li>
                    <li class="bold"><a href="#!" class="waves-effect waves-yellow">3</a>
                    </li>
                    <li class="bold"><a href="#!" class="waves-effect waves-teal">4</a></li>
                </ul>
            </div>
            <div class="col s10 m10 l10">
                <button id="btnSave" type="button" class="btn waves-effect orange waves-light" name="action">
                    SAVE     
                </button>
                <ul class="tabs">
                    <li class="tab col s3 m3 l3"><a href="#rad">Test 1</a></li>
                    <li class="tab col s3 m3 l3"><a href="#datepic">Test 2</a></li>
                    <li class="tab col s3 m3 l3"><a href="#etc">Test 3</a></li>
                    <li class="tab col s3 m3 l3"><a href="#">Test 4</a></li>
                </ul>
                <div id="rad" class="row">
                    <div class="row">
                        <div class="col s5 m5 l5 TestBox1">
                            Check Box
                        <p>
                            <input class="cb" type="checkbox" id="cb1" value="Red-CheckBox" />
                            <label for="cb1">Red</label>
                        </p>
                            <p>
                                <input class="cb" type="checkbox" id="cb2" value="Yellow-CheckBox" />
                                <label for="cb2">Yellow</label>
                            </p>
                            <p>
                                <input class="cb" type="checkbox" id="cb3" value="Green-CheckBox" checked="checked" disabled="disabled" />
                                <label for="cb3">Green</label>
                            </p>
                            <p>
                                <input class="cb" type="checkbox" id="cb4" value="Brown-CheckBox" disabled="disabled" />
                                <label for="cb4">Brown</label>
                            </p>
                        </div>
                        <div class="col s5 m5 l5 TestBox1">
                            Radio Button
                        <p>
                            <input class="rdb" name="group1" type="radio" id="rdb1" value="Red-Radio" />
                            <label for="rdb1">Red</label>
                        </p>
                            <p>
                                <input class="rdb" name="group1" type="radio" id="rdb2" value="Yellow-Radio" />
                                <label for="rdb2">Yellow</label>
                            </p>
                            <p>
                                <input class="rdb with-gap" name="group1" type="radio" id="rdb3" value="Green-Radio" />
                                <label for="rdb3">Green</label>
                            </p>
                            <p>
                                <input class="rdb" name="group1" type="radio" id="rdb4" disabled="disabled" value="Brown-Radio" />
                                <label for="rdb4">Brown</label>
                            </p>
                        </div>

                        <div class="col s2 m2 l2 TestBox1">
                            <fb:login-button scope="public_profile,email" onlogin="checkLoginState();"></fb:login-button>

                            <div id="status">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col s4 m4 l4">
                            <div class="card">
                                <div class="card-image waves-effect waves-block waves-light">
                                    <img class="activator" src="Images/pic/Banner/ILoveImport.jpg" />
                                </div>
                                <div class="card-content">
                                    <span class="card-title activator grey-text text-darken-4">Test1 <i class="mdi-navigation-more-vert right"></i></span>
                                </div>
                                <div class="card-reveal">
                                    <span class="card-title grey-text text-darken-4">Card Title <i class="mdi-navigation-close right"></i></span>
                                    <p><a href="#">Here is some more information about this product that is only revealed once clicked on.</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col s4 m4 l4">
                            <div class="card">
                                <div class="card-image waves-effect waves-block waves-light">
                                    <img class="activator" src="Images/pic/Banner/Sale.jpg" />
                                </div>
                                <div class="card-content">
                                    <span class="card-title activator grey-text text-darken-4">Test1 <i class="mdi-navigation-more-vert right"></i></span>
                                </div>
                                <div class="card-reveal">
                                    <span class="card-title grey-text text-darken-4">Card Title <i class="mdi-navigation-close right"></i></span>
                                    <p><a href="#">Here is some more information about this product that is only revealed once clicked on.</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col s4 m4 l4">
                            <div class="card">
                                <div class="card-image waves-effect waves-block waves-light">
                                    <img class="activator" src="Images/pic/Banner/Tour.jpg" />
                                </div>
                                <div class="card-content">
                                    <span class="card-title activator grey-text text-darken-4">Test1 <i class="mdi-navigation-more-vert right"></i></span>
                                </div>
                                <div class="card-reveal">
                                    <span class="card-title grey-text text-darken-4">Card Title <i class="mdi-navigation-close right"></i></span>
                                    <p><a href="#">Here is some more information about this product that is only revealed once clicked on.</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="datepic" class="row">
                    <div class="col s6 m6 l6 TestBox1">
                        Materialize Datepicker
                        <input type="date" class="datepicker" id="dtMaterial" />
                        HTML Datepicker
                        <input id="dtHTML" type="date" />
                    </div>
                    <div class="col s3 m3 l3 TestBox1">
                        Drop Down List
                        <select id="ddl1">
                            <option value="" selected>Choose your option</option>
                            <option value="1">Option 1</option>
                            <option value="2">Option 2</option>
                            <option value="3">Option 3</option>
                        </select>
                    </div>
                    <div class="col s3 m3 l3 TestBox1">
                        Drop Down Button
                        <a class='dropdown-button btn' href='#' data-activates='dropdown1'>Drop Me!</a>

                        <ul id='dropdown1' class='dropdown-content'>
                            <li><a href="#!">one</a></li>
                            <li><a href="#!">two</a></li>
                            <li class="divider"></li>
                            <li><a href="#!">three</a></li>
                        </ul>
                    </div>
                </div>
                <div id="etc" class="row">
                    <div class="col s6 m6 l6 TestBox1">
                        FILE UPLOAD
                        <div class="file-field input-field">
                            <input class="file-path validate" type="text" />
                            <div class="btn">
                                <span>File</span>
                                <input type="file" />
                            </div>
                        </div>
                    </div>
                    <div class="col s3 m3 l3 TestBox1">
                        NOTIFICATE
                        <a class="btn" onclick="toast('I am a toast', 4000)">Toast!</a>
                    </div>
                    <div class="col s3 m3 l3 TestBox1"></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">
    $(function () {
        $('.slider').slider({ full_width: false });
        $('.dropdown-button').dropdown();
        $('select').material_select();
        $('.parallax').parallax();
        $('ul.tabs').tabs();
        $('.collapsible').collapsible();
        $(".button-collapse").sideNav();
        $('.datepicker').pickadate();

        $("#btnSave").click(function () {

            var rdb = "";
            if ($("input[type='radio'][class~='rdb']:checked").length > 0) {
                rdb = $("input[type='radio'][class~='rdb']:checked").val();
            }
            var cb = "";
            for (var i = 0; i < $("input[type='checkbox'][class~='cb']:checked").length ; i++) {
                cb += $("input[type='checkbox'][class~='cb']:checked")[i].value + "||";
            }
            var dtMat = $('#dtMaterial').val();
            var dtHTML = $('#dtHTML').val();
            var ddl = $('#ddl1').val();
            var param = { "cb": cb, "rdb": rdb, "dtMat": dtMat, "dtHTML": dtHTML, "ddl": ddl };

            $.ajax({
                type: 'POST',
                //url: form.attr('action'),
                url: "../TestPage.aspx/SampleMethod",
                data: JSON.stringify(param),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    //bindModal(data);
                    //$('#loadingCircle').hide();
                    //$('#loadingLine').hide();
                    //$('#showData').show();
                    //$('#footer').show();
                },
                error: function (err) {
                    //alert('gs');
                }
            });

            //var form = $('#form1');

            //$.ajax({
            //    type: 'POST',
            //    url: form.attr('action'),
            //    data: form.serialize(),
            //    dataType: 'json',
            //    success: function (data) {
            //        //bindModal(data);
            //        //$('#loadingCircle').hide();
            //        //$('#loadingLine').hide();
            //        //$('#showData').show();
            //        //$('#footer').show();
            //    },
            //    error: function (err) {
            //        //alert('gs');
            //    }
            //});
        });
    });
</script>

<script>
    // This is called with the results from from FB.getLoginStatus().
    function statusChangeCallback(response) {
        console.log('statusChangeCallback');
        console.log(response);
        // The response object is returned with a status field that lets the
        // app know the current login status of the person.
        // Full docs on the response object can be found in the documentation
        // for FB.getLoginStatus().
        if (response.status === 'connected') {
            // Logged into your app and Facebook.
            testAPI();
        } else if (response.status === 'not_authorized') {
            // The person is logged into Facebook, but not your app.
            document.getElementById('status').innerHTML = 'Please log ' +
              'into this app.';
        } else {
            // The person is not logged into Facebook, so we're not sure if
            // they are logged into this app or not.
            document.getElementById('status').innerHTML = 'Please log ' +
              'into Facebook.';
        }
    }

    // This function is called when someone finishes with the Login
    // Button.  See the onlogin handler attached to it in the sample
    // code below.
    function checkLoginState() {
        FB.getLoginStatus(function (response) {
            statusChangeCallback(response);
        });
    }

    window.fbAsyncInit = function () {
        FB.init({
            appId: '693835867406361',
            cookie: true,  // enable cookies to allow the server to access 
            // the session
            xfbml: true,  // parse social plugins on this page
            version: 'v2.3' // use version 2.3
        });

        // Now that we've initialized the JavaScript SDK, we call 
        // FB.getLoginStatus().  This function gets the state of the
        // person visiting this page and can return one of three states to
        // the callback you provide.  They can be:
        //
        // 1. Logged into your app ('connected')
        // 2. Logged into Facebook, but not your app ('not_authorized')
        // 3. Not logged into Facebook and can't tell if they are logged into
        //    your app or not.
        //
        // These three cases are handled in the callback function.

        FB.getLoginStatus(function (response) {
            statusChangeCallback(response);
        });

    };

    // Load the SDK asynchronously
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));

    // Here we run a very simple test of the Graph API after login is
    // successful.  See statusChangeCallback() for when this call is made.
    function testAPI() {
        console.log('Welcome!  Fetching your information.... ');
        FB.api('/me', function (response) {
            alert('Successful login for: ' + response.name);
            document.getElementById('status').innerHTML =
              'Thanks for logging in, ' + response.name + '!';
        });
    }
</script>
