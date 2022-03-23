<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Stocks.aspx.cs" Inherits="StockTrading.Stocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ShowBuyPopUp(StockId, Company, Price) {
            debugger;
            $('#lblCompanyName').text("Buy " + Company);
            $('#hdnStockId').val(StockId); 
            $('#hdnType').val(3); 
            $('#txtPrice').val(Price); 
            $('#hdnPrice').val(Price); 
            $('#btnBuySell').val("Buy"); 
            $('#buyModal').modal('show');
        }

        function ShowSellPopUp(StockId, Company, Price) {
            $('#lblCompanyName').text("Sell " + Company);
            $('#hdnStockId').val(StockId);
            $('#hdnType').val(4);
            $('#txtPrice').val(Price);
            $('#hdnPrice').val(Price); 
            $('#btnBuySell').val("Sell"); 
            $('#buyModal').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container py-3">
        <h3>Buy/Sell</h3>
        <div class="no-data pt-4 text-center" style="display: none;">
            <div class="row justify-content-center">
                <div class="col-md-8">
                    <h3 class="mb-2">Stock Trading is open on the weekdays from Monday to Friday and is closed on Saturday,
                    Sunday and Holidays</h3>
                    <p class="mb-4 sub-heading">Timings - <b>9:15 am</b> to <b>3.30 pm</b></p>
                    <div>
                        <img class="img-fluid" src="assets/images/no-data.jpg" />
                    </div>
                </div>
            </div>

        </div>
        <div class="table-responsive">
            <asp:UpdatePanel ID="UPGrid" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- #region Triggers Auto Save for every 2 Minutes -->
                    <asp:Timer ID="timer_Stocks" Interval="11000" runat="server" OnTick="btnRefresh_Click"></asp:Timer>
                    <!-- #endregion -->
                    <asp:GridView ID="gvStocks" runat="server" DataKeyNames="StockId" GridLines="None" CellPadding="0" ClientIDMode="Static"
                        CellSpacing="1" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="True" CssClass="table table-sm table-bordred"
                        AllowPaging="false" PagerStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:BoundField HeaderText="Company Name" DataField="CompanyName" />
                            <asp:BoundField HeaderText="Volume" DataField="Volume" />
                            <asp:TemplateField HeaderText="Market Cap">
                                <ItemTemplate>
                                    <span>$ <%# Eval("MarketCap")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Open Price">
                                <ItemTemplate>
                                    <span>$ <%# Eval("OpenPrice")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Today's Low">
                                <ItemTemplate>
                                    <span>$ <%# Eval("TodayLow")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Today's High">
                                <ItemTemplate>
                                    <span>$ <%# Eval("TodayHigh")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Market Price">
                                <ItemTemplate>
                                    <span class='<%# Eval("PriceStatus").ToString() == "True" ? "bg-green" : "bg-red" %>'><i class='<%# Eval("PriceStatus").ToString() == "True" ? "bi bi-arrow-up-short" : "bi bi-arrow-down-short" %>'></i>$ <%# Eval("MarketPrice")%></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <%--  <button type="button" class="btn btn-success btn-sm me-1 text-white" data-bs-toggle="modal" data-bs-target="#buyModal">Buy</button>
                                    <button type="button" class="btn btn-danger btn-sm text-white" data-bs-toggle="modal" data-bs-target="#sellModal">Sell</button></td>--%>
                                    <button type="button" class="btn btn-success btn-sm me-1 text-white" onclick="ShowBuyPopUp('<%# Eval("StockId")%>','<%# Eval("CompanyName")%>','<%# Eval("MarketPrice")%>')">Buy</button>
                                    <%--<button type="button" class="btn btn-danger btn-sm text-white" onclick="ShowSellPopUp('<%# Eval("StockId")%>','<%# Eval("CompanyName")%>','<%# Eval("MarketPrice")%>')">Sell</button>--%>
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
                        <asp:HiddenField  runat="server" ID="hdnStockId" ClientIDMode="Static" Value="" />
                        <asp:HiddenField  runat="server" ID="hdnType" ClientIDMode="Static" Value="" />
                        <asp:HiddenField  runat="server" ID="hdnPrice" ClientIDMode="Static" Value="" />
                        <asp:Label runat="server"  ID="lblCompanyName" ClientIDMode="Static" Text="" />
                    </h5>
                </div>
                <div class="modal-body">
                    <div class="form-group row px-3 mb-4">
                        <asp:Label ID="lblErrorMessage" Text="" runat="server" Style="color: red;" Visible="false" />
                    </div>
                    <div class="row">
                        <div class="col-md-4 pb-3">
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtQuantity" CssClass="form-control" placeholder="Qty." />
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
                                        <asp:ListItem Value="2" Text="Limit" Enabled="false"/>
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
    <!-- Buy Modal -->
    <asp:Button ID="btnRefresh" runat="server" Style="display: none" OnClick="btnRefresh_Click" />
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/bootstrap.bundle.min.js"></script>
    <script src="assets/js/jquery-ui.js"></script>
    <script src="assets/js/custom.js"></script>
</asp:Content>
