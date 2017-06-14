<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastroProduto.aspx.cs" Inherits="sgBarb.View.cadastroProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Cadastro de Produto</h1>
    <div style="position: relative; padding: 1rem; margin: 1rem -1rem; border: solid #f7f7f9; border-width: .2rem;">
        <div class="form-group row">
            <label class="col-2 col-form-label" style="left: 0px; top: 0px">Descrição</label>
            <div class="col-10">
                <asp:TextBox ID="txtDescricao" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Tipo do Produto</label>
            <div class="input-group col-10">
                <div class="input-group">
                    <asp:DropDownList ID="ddlTipoProduto" CssClass="btn btn-secondary dropdown-toggle form-control" runat="server"></asp:DropDownList>
                    <span class="input-group-btn">
                        <button class="btn btn-secondary" data-toggle="modal" data-target="#tipoProduto" type="button">
                            +
                        </button>
                    </span>
                </div>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Valor de Venda</label>
            <div class="input-group col-10">
                <div class="input-group-addon">R$</div>
                <asp:TextBox ID="txtValor" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Estoque</label>
            <div class="col-10">
                <asp:TextBox ID="txtEstoque" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button ID="btnCadastrar" class="btn btn-outline-primary" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
    <asp:Button ID="btnCancelar" class="btn btn-outline-warning" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    
    <div class="modal fade" id="tipoProduto" tabindex="-1" role="dialog" aria-labelledby="novoTipoProduto" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="novoTipoProduto">Tipo de Produto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="form-control-label">Descrição:</label>
                        <asp:TextBox ID="txtDescricaoTipoProduto" type="text" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelarProduto" runat="server" Text="Cancelar" type="button" class="btn btn-secondary" OnClick="btnCancelarProduto_Click" />
                    <asp:Button ID="btnAdicionarProduto" runat="server" Text="Adicionar" type="button" class="btn btn-primary" OnClick="btnAdicionarProduto_Click" />
                </div>

            </div>
        </div>
    </div>
</asp:Content>
