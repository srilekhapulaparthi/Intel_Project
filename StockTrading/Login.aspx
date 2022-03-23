<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StockTrading.Login" %>

<%@ Register Src="~/UserControls/LoginMenu.ascx" TagPrefix="uc1" TagName="LoginMenu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Welcome to Stock Trading </title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/starter.css" />
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/bootstrap.bundle.min.js"></script>
    <script src="assets/js/custom.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:LoginMenu runat="server" id="LoginMenu"></uc1:LoginMenu>
        <div class="container">
            <div class="pt-5 text-center">
                <h1>Join 58k investors</h1>
                <p class="sub-heading">Open a trading start investing for free</p>
            </div>
            <div class="row justify-content-center mt-5">
                <div class="col-md-4 d-none d-md-block mb-3">
                    <img class="img-fluid" src="assets/images/signin.jpg" />
                </div>
                <div class="col-md-5 mb-3 ps-md-4">
                    <h3 class="mb-4">Sign in</h3>
                    <div class="form-group row px-3 mb-4">
                        <asp:Label ID="lblErrorMessage" Text="" runat="server" Style="color: red;" Visible="false" />
                    </div>
                    <div class="mb-4">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-lg" placeholder="Email" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvUserName" ControlToValidate="txtEmail" CssClass="text-danger text-sm" SetFocusOnError="true" ErrorMessage="Email is Mandatory" TabIndex="0"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-4">
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control form-control-lg" placeholder="Password" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" CssClass="text-danger text-sm" SetFocusOnError="true" ErrorMessage="Password is Mandatory" TabIndex="1"></asp:RequiredFieldValidator>
                    </div>
                    <div class="d-grid">
                        <asp:Button runat="server" ID="btnLogin" Text="Sign In" CssClass="btn btn-primary btn-lg" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
