<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Funds.aspx.cs" Inherits="StockTrading.Funds" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {


        });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container py-3">
        <div class="d-flex">
            <h3>Statement</h3>
            <button type="button" class="btn btn-primary btn-sm me-1 text-white ms-auto mb-1" data-bs-toggle="modal" data-bs-target="#depositeModal">Deposit / Withdraw</button>
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvFunds" runat="server" DataKeyNames="TransactionId" GridLines="None" CellPadding="0"
                CellSpacing="1" AutoGenerateColumns="false" Width="100%" ShowHeaderWhenEmpty="True" CssClass="table table-sm table-bordred"
                AllowPaging="false" PagerStyle-HorizontalAlign="Center" ShowFooter="true">
                <Columns>
                    <asp:BoundField HeaderText="Date" DataField="TransactionDate" />
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <span class='<%# Eval("FundType").ToString() == "1" || Eval("FundType").ToString() == "4" ? "chip btn-sm completed-chip" : "chip btn-sm sell-chip" %>'><%# Eval("FundTypeName")%></div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Debit">
                        <ItemTemplate>
                            <span class="bg-red text-end">-$<%# Eval("DebitAmount")%></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Credit">
                        <ItemTemplate>
                            <span class="bg-green text-end">$<%# Eval("CreditAmount")%></span>
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
    <div class="modal fade" id="depositeModal" tabindex="-1" aria-labelledby="buyModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Deposit / Withdraw</h5>
                </div>
                <div class="modal-body">
                    <div class="form-group row px-3 mb-4">
                        <asp:Label ID="lblErrorMessage" Text="" runat="server" Style="color: red;" Visible="false" />
                    </div>
                    <div class="radio-main">
                        <div class="form-check form-check-inline">
                            <asp:RadioButtonList ID="rblDepositType" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Text="Deposit" Value="1">Deposit</asp:ListItem>
                                <asp:ListItem Text="Withdraw" Value="2">Withdraw</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="row mt-2">
                        <div class="col-md-12 pb-3">
                            <div class="form-floating mb-3">
                                <asp:TextBox runat="server" CssClass="form-control" TextMode="Number" ID="txtAmount" placeholder="Amount" />
                                <asp:RequiredFieldValidator runat="server" ID="rfvAmount" ControlToValidate="txtAmount" CssClass="text-danger text-sm" SetFocusOnError="true" ErrorMessage="Amount is Mandatory" TabIndex="0"></asp:RequiredFieldValidator>
                                <label for="buy-qty">Amount</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-primary" data-bs-dismiss="modal">Close</button>
                    <asp:Button Text="Submit" runat="server" ID="btnAddOrWithDrawCash" CssClass="btn btn-primary" OnClick="btnAddOrWithDrawCash_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
