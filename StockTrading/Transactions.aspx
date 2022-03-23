<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="StockTrading.Transactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container py-3">
        <h3>Transactions</h3>
        <div class="table-responsive">
            <asp:GridView ID="gvTransactions" runat="server" DataKeyNames="StockId" GridLines="None" CellPadding="0" ClientIDMode="Static"
                CellSpacing="1" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="True" CssClass="table table-sm table-bordred"
                AllowPaging="false" PagerStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                    <asp:BoundField HeaderText="Qty." DataField="Quantity" />
                    <asp:TemplateField HeaderText="Buy Date">
                        <ItemTemplate><%# Eval("BuyingDate").Equals(DateTime.MinValue) ? "" : string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", (DateTime)Eval("BuyingDate")) %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Buy Price">
                        <ItemTemplate>
                            <span>$ <%# Eval("BuyingPrice")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Buy Value">
                        <ItemTemplate>
                            <span>$ <%# Eval("BuyingAmount")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sell Date">
                        <ItemTemplate><%# Eval("SellingDate").Equals(DateTime.MinValue) ? "" : string.Format("{0:dd/MM/yyyy hh:mm:ss tt}", (DateTime)Eval("SellingDate")) %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sell Price">
                        <ItemTemplate>
                            <span>$ <%# Eval("SellingPrice")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sell Value">
                        <ItemTemplate>
                            <span>$ <%# Eval("SellingAmount")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Profit/Loss">
                        <ItemTemplate>
                            <span class='<%# Eval("SellingDate").Equals(DateTime.MinValue) ? "bg-red" : "bg-green" %>'><i class='<%#  Eval("SellingDate").Equals(DateTime.MinValue) ? "bi bi-arrow-down-short" : "bi bi-arrow-up-short"  %>'></i>$ <%# Eval("ProfitLoss")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="border-top: 1px solid #000; text-align: center;">No records found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
