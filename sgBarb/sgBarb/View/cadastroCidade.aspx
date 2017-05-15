<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastroCidade.aspx.cs" Inherits="sgBarb.View.cadastroCidade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cadastro de Cidade</h1>
    <div class="row">
        <div class="form-group col-10">
            <label for="nome">Nome</label>
            <asp:TextBox ID="txtNome" class="form-control" type="text" runat="server"></asp:TextBox>
        </div>
        <div class="form-group col-2">
            <label for="uf">UF</label>
            <asp:TextBox ID="txtUF" class="form-control" type="text" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="form-group col-4">
            <label for="uf">CEP</label>
            <asp:TextBox ID="txtCep" class="form-control" type="text" runat="server"></asp:TextBox>
        </div>
    </div>
    <asp:Button ID="btnCadastrar" class="btn btn-outline-primary" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
    <asp:Button ID="btnCancelar" class="btn btn-outline-warning" runat="server" Text="Cancelar" />
</asp:Content>
