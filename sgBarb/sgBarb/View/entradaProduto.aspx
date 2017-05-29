<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="entradaProduto.aspx.cs" Inherits="sgBarb.View.entradaProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblData" runat="server" class="float-right" style="font-weight: bold"></asp:Label>
     
    <h1>Entrada de Produto</h1>
    <br />
    <div class="row">
        <div class="form-group col-6">
            <label>Fornecedor:</label>
            <asp:DropDownList ID="ddlFornecedor" class="form-control btn btn-secondary dropdown-toggle" runat="server" />
        </div>
    </div>
    <asp:GridView ID="gdvCarrinho" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvCarrinho_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Produto">
                <ItemTemplate>
                    <asp:Label ID="lblIdProduto" runat="server" Text='<%# Eval("idProduto") %>' Style="display: none;"></asp:Label>
                    <asp:Label ID="lblProduto" runat="server" Text='<%# Eval("produto") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantidade">
                <ItemTemplate>
                    <asp:Label ID="lblQuantidadeDgv" runat="server" Text='<%# Eval("quantidade") %>'></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Valor Uni.">
                <ItemTemplate>
                    <asp:Label ID="lblValorUniDgv" runat="server" Text='<%# Eval("valorUni") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="valorTotal" HeaderText="Valor Total." />
            <%--     <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="EditarProduto"
                        Text="Editar" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            --%>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnRemover" CssClass="btn btn-outline-danger" runat="server" CausesValidation="false" CommandName="RemoverProduto"
                        Text="Remover" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <h4>
        <asp:Label ID="lblTotal" class="float-right" runat="server" Text="Label"></asp:Label>
    </h4>
    <br />

    <asp:Button ID="btnAdicionarProduto" CssClass="btn btn-outline-primary" runat="server" Text="Adicionar Produto" OnClick="btnAdicionarProduto_Click" />
    <asp:Button ID="btnFinalizarCompra" CssClass="btn btn-outline-primary" runat="server" Text="Finalizar Compra" OnClick="btnFinalizarCompra_Click1" />

    <asp:Panel ID="pnlProduto" runat="server">
        <br />
        <div>
            <div class="row">
                <div class="form-group col-4">
                    <label for="Nome">Tipo do Produto:</label>
                    <asp:DropDownList ID="ddlTipoProduto" AutoPostBack="true" class="form-control btn btn-secondary dropdown-toggle" runat="server" OnSelectedIndexChanged="ddlTipoProduto_SelectedIndexChanged" />
                </div>
                <div class="form-group col-8">
                    <label for="Gênero">Produto: </label>
                    <asp:DropDownList ID="ddlProduto" class="form-control btn btn-secondary dropdown-toggle" runat="server">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div id="divQuantidade" class="form-group col-4" runat="server">
                    <label id="lblQuantidade" runat="server">Quantidade: </label>
                    <asp:TextBox ID="txtQuantidade" CssClass="form-control" AutoPostBack="true" runat="server" OnTextChanged="txtQuantidade_TextChanged"></asp:TextBox>
                </div>
                <div id="divValorUni" runat="server" class="form-group col-4">
                    <label id="lblValorUni" runat="server">Valor Uni.: </label>
                    <div class="input-group">
                        <div class="input-group-addon">R$</div>
                        <asp:TextBox ID="txtValorUni" type="text" AutoPostBack="true" class="form-control" runat="server" OnTextChanged="txtValorUni_TextChanged"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group col-4">
                    <label>Valor Total: </label>
                    <div class="input-group">
                        <div class="input-group-addon">R$</div>
                        <asp:TextBox ID="txtValor" type="text" AutoPostBack="true" class="form-control" runat="server" OnTextChanged="txtValor_TextChanged" Enabled="False"></asp:TextBox>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnAddEntradaProduto" runat="server" Text="Adicionar" type="button" class="btn btn-primary" OnClick="btnAddEntradaProduto_Click" />
            <asp:Button ID="btnCancelarEntradaPrdouto" runat="server" Text="Cancelar" type="button" class="btn btn-danger" OnClick="btnCancelarEntradaPrdouto_Click" />

        </div>
    </asp:Panel>

</asp:Content>
