<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Holdings.aspx.cs" Inherits="StockTrading.Holdings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowSellPopUp(Id, StockId, Quantity, Company, Price) {
            $('#lblCompanyName').text("Sell " + Company);
            $('#hdnHoldingId').val(Id);
            $('#hdnStockId').val(StockId);
            $('#hdnType').val(4);
            $('#hdnQuantity').val(Quantity);
            $('#hdnPrice').val(Price);
            $('#btnBuySell').val("Sell");
            $('#txtPrice').val(Price);
            $('#txtQuantity').val(Quantity);
            $('#buyModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container py-3">
        <h3>Holdings</h3>

        <div class="table-responsive">
            <asp:UpdatePanel ID="UPGrid" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- #region Triggers Auto Save for every 2 Minutes -->
                    <asp:Timer ID="timer_Stocks" Interval="11000" runat="server" OnTick="btnRefresh_Click"></asp:Timer>
                    <!-- #endregion -->
                    <asp:GridView ID="gvHoldings" runat="server" DataKeyNames="StockId" GridLines="None" CellPadding="0" ClientIDMode="Static"
                        CellSpacing="1" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="True" CssClass="table table-sm table-bordred"
                        AllowPaging="false" PagerStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                            <asp:BoundField HeaderText="Qty." DataField="Quantity" />
                            <asp:TemplateField HeaderText="Bought Price">
                                <ItemTemplate>
                                    <span>$ <%# Eval("BuyingPrice")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Market Price">
                                <ItemTemplate>
                                    <span>$ <%# Eval("MarketPrice")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>                            
                            <asp:TemplateField HeaderText="Profit/Loss">
                                <ItemTemplate>
                                    <span class='<%# Eval("PriceStatus").ToString() == "True" ? "bg-green" : "bg-red" %>'><i class='<%# Eval("PriceStatus").ToString() == "True" ? "bi bi-arrow-up-short" : "bi bi-arrow-down-short" %>'></i>$ <%# Eval("GainAmount")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <button type="button" class="btn btn-danger btn-sm text-white" onclick="ShowSellPopUp('<%# Eval("Id")%>','<%# Eval("StockId")%>','<%# Eval("Quantity")%>','<%# Eval("CompanyName")%>','<%# Eval("MarketPrice")%>')">Sell</button>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div style="border-top: 1px solid #000; text-align: center;">No records found.</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- Buy Modal -->
    <div class="modal fade" id="buyModal" tabindex="-1" aria-labelledby="buyModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">
                        <asp:HiddenField runat="server" ID="hdnHoldingId" ClientIDMode="Static" Value="" />
                        <asp:HiddenField runat="server" ID="hdnStockId" ClientIDMode="Static" Value="" />
                        <asp:HiddenField runat="server" ID="hdnType" ClientIDMode="Static" Value="" />
                        <asp:HiddenField runat="server" ID="hdnPrice" ClientIDMode="Static" Value="" />
                         <asp:HiddenField runat="server" ID="hdnQuantity" ClientIDMode="Static" Value="" />
                        <asp:Label runat="server" ID="lblCompanyName" ClientIDMode="Static" Text="" />
                    </h5>
                </div>
                <div class="modal-body">
                    <div class="form-group row px-3 mb-4">
                        <asp:Label ID="lblErrorMessage" Text="" runat="server" Style="color: red;" Visible="false" />
                    </div>
                    <div class="row">
                        <div class="col-md-4 pb-3">
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtQuantity" Enabled="false" ClientIDMode="Static" CssClass="form-control" placeholder="Qty." />
                                <label for="buy-qty">Qty.</label>
                            </div>
                        </div>
                        <div class="col-md-4 pb-3">
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" ClientIDMode="Static" placeholder="Price" Enabled="false" />
                                <label for="buy-qty">Price</label>
                            </div>
                            <div class="radio-main">
                                <div class="form-check form-check-inline">
                                    <asp:RadioButtonList runat="server" ID="rblMarket" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1" Text="Market" Selected="True" />
                                        <asp:ListItem Value="2" Text="Limit" Enabled="false" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 pb-3">
                            <div class="form-floating mb-3">
                                <input type="text" class="form-control" disabled id="buy-date" placeholder="Expiry Date">
                                <label for="buy-qty">Expiry Date</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-primary" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnBuySell" ClientIDMode="Static" OnClick="btnBuySell_Click" CssClass="btn btn-primary" Text="Buy" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btnRefresh" runat="server" Style="display: none" OnClick="btnRefresh_Click" />
</asp:Content>
