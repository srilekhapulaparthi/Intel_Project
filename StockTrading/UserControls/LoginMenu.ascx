<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginMenu.ascx.cs" Inherits="StockTrading.UserControls.LoginMenu" %>
<script type="text/javascript">
    $(document).ready(function () {
        debugger;
        $('.navbar-nav').find('li a').removeClass('active');
        var url = window.location.href.substr(window.location.href.lastIndexOf("/") + 1);
        $('[href$="' + url + '"]').addClass("active");
    });
</script>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container">
        <a class="navbar-brand" href="#">
            <img src="assets/images/logo.png" />Stock Trading </a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
            aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarText">
            <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                <li class="nav-item">
                    <a class="nav-link" href="../Registration.aspx">Registration</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="../Login.aspx">Sign in</a>
                </li>
            </ul>

        </div>
    </div>
</nav>
