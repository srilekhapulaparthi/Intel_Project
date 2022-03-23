<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="MarketHours.aspx.cs" Inherits="StockTrading.Admin.MarketHours" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container pt-4 text-center">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <h3 class="mb-2">Stock Trading is open on the weekdays from Monday to Friday and is closed on Saturday,
                    Sunday and Holidays</h3>
                <p class="mb-4 sub-heading">Timings - <b>09:00 am</b> to <b>3:00 pm</b></p>
                <div>
                    <img class="img-fluid" src="../assets/images/no-data.jpg" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
