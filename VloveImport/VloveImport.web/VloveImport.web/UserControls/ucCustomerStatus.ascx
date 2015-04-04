<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCustomerStatus.ascx.cs" Inherits="VloveImport.web.UserControls.ucCustomerStatus" %>
<%--<div class="row">
    <div class="col s2 m2 l2"></div>
    <div class="col s8 m8 l8">--%>
<nav class="ucCustomerStatus">
    <%--<div class="row">
        <div class="col" id="google_translate_element"></div>--%>
    <div class="nav-wrapper black white-text">
        <ul class="left hide-on-med-and-down" style="padding-left: 10%;">
            <li>
                <div>
                    <fb:login-button id="fbLoginbtn" scope="public_profile,email" onlogin="checkLoginState();"></fb:login-button>
                </div>
            </li>
            <li>
                <asp:HyperLink ID="hlLogin" runat="server" NavigateUrl="~/Customer/Login.aspx">เข้าสู่ระบบ
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hlRegis" runat="server" NavigateUrl="~/Customer/Register.aspx?type=rateimport&pag=3">สมัครสมาชิก
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hlMember" runat="server" NavigateUrl="~/Customer/CustomerProfile.aspx">ข้อมูลสมาชิก
                </asp:HyperLink>
            </li>
            <li>
                <asp:Label ID="lbCustomer" runat="server"></asp:Label>
            </li>
            <li>
                <asp:HyperLink ID="hlLogout" runat="server" NavigateUrl="~/Logout.aspx">ออกจากระบบ
                </asp:HyperLink>
            </li>
        </ul>

        <div id="google_translate_element" style="display: none;"></div>
        <a id="aChina" class="translateFlag" href="#" data-id="1">
            <img src="../Images/icon/Flag/China-Flag-icon.png" />
        </a>
        <a id="aThai" class="translateFlag" href="#" data-id="2">
            <img src="../Images/icon/Flag/Thailand-Flag-icon.png" />
        </a>

        <ul id="nav-mobile" class="right hide-on-med-and-down" style="display: inline-block;">
            <li>
                <asp:HyperLink ID="hlIndex" runat="server" NavigateUrl="~/Index.aspx">หน้าหลัก
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hlProfile" runat="server" NavigateUrl="~/Customer/CustomerProfile.aspx">ข้อมูลของฉัน
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hlOrder" runat="server" NavigateUrl="~/Customer/CustomerOrderList.aspx">รายการสั่งซื้อ
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hlBasket" runat="server" NavigateUrl="~/Customer/CustomerBasket.aspx">ตะกร้า
                </asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="hlWallet" runat="server" NavigateUrl="~/Customer/CustomerMyAccount.aspx">กระเป๋าเงินของฉัน
                </asp:HyperLink>
            </li>
        </ul>
    </div>
    <%--</div>--%>
</nav>
<script type="text/javascript">
    $(function () {
        $('#ucCustomerStatus_hlLogout').click(function () {
            FB.logout();
        });
    });
</script>
<script>
    var chkFB = '0';
    // This is called with the results from from FB.getLoginStatus().
    function statusChangeCallback(response) {
        // The response object is returned with a status field that lets the
        // app know the current login status of the person.
        // Full docs on the response object can be found in the documentation
        // for FB.getLoginStatus().
        if (response.status === 'connected') {
            // Logged into your app and Facebook.
            if (chkFB == '1') {
                AddLoginAPI();
            }
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
        chkFB = '1';
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
    function AddLoginAPI() {
        //console.log('Welcome!  Fetching your information.... ');
        FB.api('/me', function (response) {

            var User = '<%= Session["User"]%>';
            if (User == '') {
                var param = {
                    "email": response.email, "first_name": response.first_name, "id": response.id, "last_name": response.last_name, "gender": response.gender
                };
                $.ajax({
                    type: 'POST',
                    url: "../Customer/Register.aspx/fbRegis",
                    data: JSON.stringify(param),
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (data) {
                        var obj = JSON.parse(data.d);
                        if (obj.Result == 1) {
                            $.ajax({
                                type: 'POST',
                                url: "../Customer/Login.aspx/fbLogin",
                                data: JSON.stringify({ "email": response.email, "password": obj.ReturnVal }),
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                success: function (data) {
                                    location.reload();
                                },
                                error: function (err) {
                                    alert('gs');
                                }
                            });
                        }
                    },
                    error: function (err) {
                        alert('gs');
                    }
                });
            }
            //alert('Successful login for: ' + response.name);
            //document.getElementById('status').innerHTML =
            //  'Thanks for logging in, ' + response.name + '!';
        });
        }
</script>
<%--<script type="text/javascript">
    function googleTranslateElementInit() {
        new google.translate.TranslateElement({ pageLanguage: 'th', includedLanguages: 'zh-CN,zh-TW' }, 'google_translate_element');
    }
</script>
<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>--%>
<%--<script type="text/javascript">

    $(function () {

        $('.translateFlag').on("click", function () {
            var aid = $(this).data("id");
            if (aid == 1) {
                $.cookie('googtrans', '/th/zh-TW');
            }
            else {
                $.cookie('googtrans', '/zh-TW/th');
            }
        });
    });

    function googleTranslateElementInit() {
        new google.translate.TranslateElement({ pageLanguage: 'th', includedLanguages: 'th,zh-TW', layout: google.translate.TranslateElement.InlineLayout.SIMPLE, autoDisplay: false }, 'google_translate_element');
    }
</script>
<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>--%>
