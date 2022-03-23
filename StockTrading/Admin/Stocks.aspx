<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Stocks.aspx.cs" Inherits="StockTrading.Admin.Stocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-3">
        <div class="d-flex my-2">
            <h3>Stocks List</h3>
            <div class="ms-auto">
                <button type="button" class="btn btn-primary btn-sm me-1 text-white" data-bs-toggle="modal" data-bs-target="#addModal">Add Stock</button>
            </div>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvStocks" runat="server" DataKeyNames="StockId" GridLines="None" CellPadding="0"
                CellSpacing="1" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="True" CssClass="table table-sm table-bordred"
                AllowPaging="false" PagerStyle-HorizontalAlign="Center">
                <Columns>
                    <asp:BoundField HeaderText="Company Name" ItemStyle-CssClass="company-name" DataField="CompanyName" />
                    <asp:TemplateField HeaderText="Stock Ticker">
                        <ItemTemplate>
                            <span class="chip btn-sm"><%# Eval("StockTicker")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Volume" ItemStyle-HorizontalAlign="Center" DataField="Volume" />
                    <asp:TemplateField HeaderText="Initial Price">
                        <ItemTemplate>
                            <span>$ <%# Eval("InitialPrice")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="border-top: 1px solid #000; text-align: center;">No records found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>

    <!-- Buy Modal -->
    <div class="modal fade" id="addModal" tabindex="-1" aria-labelledby="addModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Add Stock</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="form-group row px-3 mb-4">
                            <asp:Label ID="lblErrorMessage" Text="" runat="server" Style="color: red;" Visible="false" />
                        </div>
                        <div class="col-md-12 pb-3">
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" ID="txtCompanyName" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rfvCompanyName" ErrorMessage="Company Name is Mandatory" ControlToValidate="txtCompanyName" CssClass="text-danger text-sm" SetFocusOnError="true" TabIndex="0"></asp:RequiredFieldValidator>
                                <label for="company-name">Company Name</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 pb-3">
                                <div class="form-floating mb-3">
                                    <asp:TextBox runat="server" ID="txtStockTicker" CssClass="form-control" placeholder="Stock Ticker"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvStockTicker" ErrorMessage="Stock Ticker is Mandatory" ControlToValidate="txtStockTicker" CssClass="text-danger text-sm" SetFocusOnError="true" TabIndex="0"></asp:RequiredFieldValidator>
                                    <label for="stock-ticker">Stock Ticker</label>
                                </div>
                            </div>
                            <div class="col-md-4 pb-3">
                                <div class="form-floating mb-3">
                                    <asp:TextBox runat="server" ID="txtVolume" CssClass="form-control" placeholder="Volume"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvVolume" ErrorMessage="Volume is Mandatory" ControlToValidate="txtVolume" CssClass="text-danger text-sm" SetFocusOnError="true" TabIndex="0"></asp:RequiredFieldValidator>
                                    <label for="volume">Volume</label>
                                </div>
                            </div>
                            <div class="col-md-4 pb-3">
                                <div class="form-floating mb-3">
                                    <asp:TextBox runat="server" ID="txtInitialPrice" CssClass="form-control" placeholder="Initial Price"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="rfvInitialPrice" ErrorMessage="Initial Price is Mandatory" ControlToValidate="txtInitialPrice" CssClass="text-danger text-sm" SetFocusOnError="true" TabIndex="0"></asp:RequiredFieldValidator>
                                    <label for="initial-price">Initial Price</label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-primary" data-bs-dismiss="modal">Close</button>
                    <asp:Button Text="Add Stock" CssClass="btn btn-primary" runat="server" ID="btnAddStock" OnClick="btnAddStock_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
