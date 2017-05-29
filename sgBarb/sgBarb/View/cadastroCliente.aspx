<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastroCliente.aspx.cs" Inherits="sgBarb.View.cadastroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cadastro de Clientes</h1>
        <div style="position: relative; padding: 1rem; margin: 1rem -1rem; border: solid #f7f7f9; border-width: .2rem;">
        <div class="row">
            <div class="form-group col-8">
                <label for="Nome">Nome</label>
                <asp:TextBox ID="txtNome" placeholder="Nome" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label for="Gênero">Gênero </label>
                <asp:DropDownList ID="ddlGenero" class="form-control btn btn-secondary dropdown-toggle" runat="server">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-4">
                <label for="Nome">Nascimento</label>
                <asp:TextBox ID="txtNascimento" placeholder="" type="date" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label for="Nome">Telefone</label>
                <asp:TextBox ID="txtTelefone" placeholder="(##)####-####" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label for="Nome">Celular</label>
                <asp:TextBox ID="txtCelular" placeholder="(##)####-#####" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-8">
                <label for="uf">Cidade</label>
                <asp:DropDownList ID="ddlCidade" CssClass="form-control btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-4">
                <label for="CEP">CEP</label>
                <asp:TextBox ID="txtCep" placeholder="#####-###" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-5">
                <label for="Bairro">Bairro</label>
                <asp:TextBox ID="txtBairro" placeholde="" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
            <div class="form-group col-5">
                <label for="CEP">Rua</label>
                <asp:TextBox ID="txtRua" placeholder="" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
            <div class="form-group col-2">
                <label for="Num">Num</label>
                <asp:TextBox ID="txtNum" placeholder="" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="form-group col-4">
                <label for="Cpf">Cpf</label>
                <asp:TextBox ID="txtCpf" placeholder="" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label for="Rg">Rg</label>
                <asp:TextBox ID="txtRg" placeholder="#####-###" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
            <div class="form-group col-4">
                <label for="Email">Email</label>
                <asp:TextBox ID="txtEmail" placeholder="#####-###" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button ID="btnCadastrar" class="btn btn-outline-primary" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
    <asp:Button ID="btnCancelar" class="btn btn-outline-warning" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>
