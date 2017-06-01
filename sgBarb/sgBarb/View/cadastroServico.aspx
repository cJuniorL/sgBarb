<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastroServico.aspx.cs" Inherits="sgBarb.View.cadastroServico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cadastro de Serviço</h1>
    <div style="position: relative; padding: 1rem; margin: 1rem -1rem; border: solid #f7f7f9; border-width: .2rem;">
        <div class="form-group col-8">
            <label for="Descricao">Descricao</label>
            <asp:TextBox ID="txtNome" placeholder="Descrição do Serviço" class="form-control" runat="server" type="text"></asp:TextBox>

        </div>
        <div class="form-group col-4">

            <label for="Descricao">Valor</label>
            <div class="input-group">
                <div class="input-group-addon">R$</div>
                <asp:TextBox ID="txtValor" placeholder="Valor do Serviço" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button ID="btnCadastrar" class="btn btn-outline-primary" runat="server" Text="Cadastrar" OnClick="btnAdicionar" />
    <asp:Button ID="btnCancelar" class="btn btn-outline-warning" runat="server" Text="Cancelar" />

</asp:Content>
