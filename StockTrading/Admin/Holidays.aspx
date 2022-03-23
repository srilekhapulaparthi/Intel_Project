<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Holidays.aspx.cs" Inherits="StockTrading.Admin.Holidays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="no-data pt-4 ">
        <div class="container">
            <div class="text-center">
                <h3 class="mb-2">Stock Trading is open on the weekdays from Monday to Friday and is closed on Saturday,
                    Sunday and Holidays</h3>
                <p class="mb-4 sub-heading">Timings - <b>09:00 am</b> to <b>3:00 pm</b></p>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-10">
                    <div>
                        <h4>Holidays List</h4>
                    </div>
                    <asp:GridView ID="gvHolidays" runat="server" GridLines="None" CellPadding="0"
                        CellSpacing="1" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="True" CssClass="table table-sm table-bordred"
                        AllowPaging="false" PagerStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField HeaderText="Holidays" ItemStyle-HorizontalAlign="Left" ItemStyle-CssClass="company-name" DataField="Holiday" />
                            <asp:BoundField HeaderText="Date" ItemStyle-HorizontalAlign="Center" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="border-top: 1px solid #000; text-align: center;">No records found.</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
