<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="itensComanda.aspx.cs" Inherits="sgBarb.View.itensComanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function produtoQuantidadeVerif() {
            var quantidade = document.getElementById('txtQuantidade');
            var quant = parseInt(quantidade.value, 10);
            if (!isNaN(quant)) {
                var desconto = document.getElementById('txtDesconto');
                var desc = parseFloat(desconto.value);
                if (!isNaN(desc)) {
                    document.getElementById('btnAdiconarProduto').disabled = false;
                    var valor = parseFloat(document.getElementById('txtValor').value.replace(",", ".")) * quant - desconto.value.replace(",", ".");
                    document.getElementById('txtValorTotalProduto').value = valor.toFixed(2).replace(".", ",");
                }
                else {
                    document.getElementById('btnAdiconarProduto').disabled = true;
                    document.getElementById('txtValorTotalProduto').value = "0,00";
                }
            }
            else {
                quantidade.value = "";
                document.getElementById('txtValorTotalProduto').value = "0,00";
                document.getElementById('btnAdiconarProduto').disabled = true;
            }
        }

        function produtoDescontoVerif() {

            var desconto = document.getElementById('txtDesconto');
            var desc = parseFloat(desconto.value);
            if (!isNaN(desc)) {
                var quantidade = document.getElementById('txtQuantidade');
                var quant = parseInt(quantidade.value, 10);
                if (!isNaN(quant)) {
                    document.getElementById('btnAdiconarProduto').disabled = false;
                    var valor = parseFloat(document.getElementById('txtValor').value.replace(",", ".")) * quant - desconto.value.replace(",", ".");
                    document.getElementById('txtValorTotalProduto').value = valor.toFixed(2).replace(".", ",");
                }
                else {
                    document.getElementById('btnAdiconarProduto').disabled = true;
                    document.getElementById('txtValorTotalProduto').value = "0,00";
                }
                desconto.value = desconto.value.replace(",", ".").toFixed(2).replace(".", ",");
            }
            else {
                desconto.value = "";
                document.getElementById('txtValorTotalProduto').value = "0,00";
                document.getElementById('btnAdiconarProduto').disabled = true;
            }
        }

        function descontoServicoVerif() {
            var desconto = document.getElementById('txtDescontoServico');
            var desc = parseFloat(desconto.value.replace(",", "."));
            if (!isNaN(desc)) {
                var valorServico = parseFloat(document.getElementById('txtValorServico').value.replace(",", "."));
                var total = valorServico - desc;
                document.getElementById('txtValorTotalServico').value = total.toFixed(2).replace(".", ",");
                document.getElementById('btnAdicionarServico').disabled = false;
            }
            else {
                desconto.value = "";
                document.getElementById('btnAdicionarServico').disabled = true;
                document.getElementById('txtValorTotalServico').value = "0,00";
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <input id="idProduto" type="hidden" runat="server" clientidmode="Static" value="" />
    <input id="idServico" type="hidden" runat="server" clientidmode="Static" value="" />
    <h1>
        <asp:Label ID="lblComanda" runat="server" Text=""></asp:Label>
    </h1>
    <asp:GridView ID="gdvServico" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvServico_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" />
            <asp:BoundField DataField="servico" HeaderText="Servico" />
            <asp:BoundField DataField="valor" HeaderText="Valor" />
            <asp:BoundField DataField="desconto" HeaderText="Desconto" />
            <asp:BoundField DataField="valorTotal" HeaderText="Total" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="EditarServico"
                        Text="Editar" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnRemover" CssClass="btn btn-outline-danger" runat="server" CausesValidation="false" CommandName="RemoverServico"
                        Text="Remover" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:GridView ID="gdvProdutosComandas" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvProdutosComandas_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" />
            <asp:BoundField DataField="produto" HeaderText="Produto" />
            <asp:BoundField DataField="valorUni" HeaderText="Valor Uni." />
            <asp:BoundField DataField="quantidade" HeaderText="Quantidade" />
            <asp:BoundField DataField="desconto" HeaderText="Desconto" />
            <asp:BoundField DataField="valorTotal" HeaderText="Total" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="EditarProduto"
                        Text="Editar" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnRemover" CssClass="btn btn-outline-danger" runat="server" CausesValidation="false" CommandName="RemoverProduto"
                        Text="Remover" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblTotal" class="float-right" Style="font-weight: bold;" runat="server" Text=""></asp:Label>

    <asp:Button ID="btnServico" runat="server" Text="Adicionar Serviço" type="button" class="btn btn-primary" OnClick="btnServico_Click" />
    <asp:Button ID="btnProduto" runat="server" Text="Adicionar Produto" type="button" class="btn btn-primary" OnClick="btnProduto_Click" />
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#fecharComanda">Fechar Comanda </button>
    <asp:Panel ID="pnlServico" runat="server">
        <div class="row">
            <div class="form-group col-6">
                <label>Funcionário</label>
                <asp:DropDownList ID="ddlFuncionarioServico" class="form-control btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-6">
                <label>Serviço</label>
                <asp:DropDownList ID="ddlServico" class="form-control btn btn-secondary dropdown-toggle" runat="server" AutoPostBack="True" OnDataBound="ddlServico_DataBound" OnSelectedIndexChanged="ddlServico_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-4">
                <label>Valor:</label>
                <asp:TextBox  ClientIDMode="Static" ID="txtValorServico" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label>Desconto:</label>
                <asp:TextBox ID="txtDescontoServico" ClientIDMode="Static" onblur="descontoServicoVerif()" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label for="Nome">Valor Total:</label>
                <asp:TextBox disabled="true" ClientIDMode="Static" ID="txtValorTotalServico" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnAdicionarServico" ClientIDMode="Static" runat="server" Text="Adicionar" type="button" class="btn btn-primary" OnClick="btnAdicionarServico_Click" />
        <asp:Button ID="btnCancelarServico" runat="server" Text="Cancelar" type="button" class="btn btn-danger" OnClick="btnCancelarServico_Click" />

    </asp:Panel>
    <asp:Panel ID="pnlProduto" runat="server">
        <div class="row">
            <div class="form-group col-4">
                <label for="Nome">Tipo do Produto:</label>
                <asp:DropDownList ID="ddlTipoPrdouto" class="form-control btn btn-secondary dropdown-toggle" runat="server" OnDataBinding="ddlTipoPrdouto_DataBinding" OnSelectedIndexChanged="ddlTipoPrdouto_SelectedIndexChanged" OnDataBound="ddlTipoPrdouto_DataBound" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div class="form-group col-8">
                <label for="Nome">Produto:</label>
                <asp:DropDownList ID="ddlProduto" class="form-control btn btn-secondary dropdown-toggle" runat="server" AutoPostBack="True" OnDataBound="ddlProduto_DataBound" OnSelectedIndexChanged="ddlProduto_SelectedIndexChanged"></asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-4">
                <label>Valor:</label>
                <asp:TextBox ID="txtValor" class="form-control" runat="server" disabled="true" ClientIDMode="Static"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label>Quantidade:</label>
                <asp:TextBox ID="txtQuantidade" onblur="produtoQuantidadeVerif()" ClientIDMode="Static" class="form-control" runat="server" OnTextChanged="txtQuantidade_TextChanged"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label>Desconto:</label>
                <asp:TextBox ID="txtDesconto" class="form-control" runat="server" onblur="produtoDescontoVerif()" OnTextChanged="txtDesconto_TextChanged" ClientIDMode="Static"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-4">
                <label>Valor Total:</label>
                <asp:TextBox disabled="true" ID="txtValorTotalProduto" ClientIDMode="Static" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnAdiconarProduto" runat="server" Text="Adicionar" type="button" class="btn btn-primary" OnClick="btnAdiconarProduto_Click" ClientIDMode="Static" />
        <asp:Button ID="btnCancelarProduto" runat="server" Text="Cancelar" type="button" class="btn btn-danger" OnClick="btnCancelarProduto_Click" />
    </asp:Panel>
    <div class="modal fade" id="fecharComanda" tabindex="-1" role="dialog" aria-labelledby="novoHorarioTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="novoHorarioTitle">Fechar Comanda</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="form-control-label">Total Comanda:</label>
                        <asp:TextBox ID="txtTotal" type="text" class="form-control" runat="server" Disabled="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="recipient-name" class="form-control-label">Valor Pago:</label>
                        <asp:TextBox ID="txtPago" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" type="button" class="btn btn-secondary"/>
                    <asp:Button ID="btnFecharComandaAsp" runat="server" Text="Confirmar" type="button" class="btn btn-primary" OnClick="btnFecharComandaAsp_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
