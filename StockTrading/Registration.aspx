<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="StockTrading.Registration" %>

<%@ Register Src="~/UserControls/LoginMenu.ascx" TagPrefix="uc1" TagName="LoginMenu" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="assets/css/starter.css" />
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <title>Welcome to Stock Trading </title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:LoginMenu runat="server" ID="LoginMenu" />
        <div class="container">
            <div class="pt-5 text-center">
                <h1>Join 58k investors</h1>
                <p class="sub-heading">Open a trading start investing for free</p>
            </div>
            <div class="row justify-content-center mt-5">
                <div class="col-md-4 d-none d-md-block mb-3">
                    <img class="img-fluid" src="assets/images/banner.jpg" />
                </div>
                <div class="col-md-5 mb-3 ps-md-4">
                    <h3 class="mb-4">Signup now</h3>
                    <div class="form-group row px-3 mb-4">
                        <asp:Label ID="lblErrorMessage" Text="" runat="server" Style="color: red;" Visible="false" />
                    </div>
                    <div class="mb-4">
                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control form-control-lg" placeholder="First Name" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvFirstName" ControlToValidate="txtFirstName" CssClass="text-danger text-sm" SetFocusOnError="true" ErrorMessage="First Name is Mandatory" TabIndex="0"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mb-4">
                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control form-control-lg" placeholder="Last Name" />
                    </div>
                    <div class="mb-4">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" placeholder="Email" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvEmail" ControlToValidate="txtEmail" CssClass="text-danger text-sm" SetFocusOnError="true" ErrorMessage="Email is Mandatory" TabIndex="0"></asp:RequiredFieldValidator>

                    </div>
                    <%-- <div class="mb-4">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control form-control-lg"  placeholder="Password"/>
                        <asp:RequiredFieldValidator runat="server" ID="rfvPassword" ControlToValidate="txtPassword" CssClass="text-danger text-sm" SetFocusOnError="true" ErrorMessage="Password is Mandatory" TabIndex="0"></asp:RequiredFieldValidator>                    
                    </div>--%>
                    <div class="mb-4">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control form-control-lg" placeholder="Mobile Number" />
                    </div>
                    <div class="d-grid">
                        <asp:Button ID="btnSignUp" Text="SignUp" runat="server" CssClass="btn btn-primary btn-lg" OnClick="btnSignUp_Click" />
                    </div>
                </div>
            </div>
        </div>

        <script src="assets/js/jquery-3.6.0.min.js"></script>
        <script src="assets/js/bootstrap.bundle.min.js"></script>
        <script src="assets/js/custom.js"></script>
    </form>
</body>
</html>
