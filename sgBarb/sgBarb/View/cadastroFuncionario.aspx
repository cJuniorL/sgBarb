    <%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastroFuncionario.aspx.cs" Inherits="sgBarb.View.cadastroFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cadastro de Funcionário</h1>
    <div style="position: relative; padding: 1rem; margin: 1rem -1rem; border: solid #f7f7f9; border-width: .2rem;">
        <div class="form-group row">
            <label class="col-2 col-form-label">Nome</label>
            <div class="col-10">
                <asp:TextBox ID="txtNome" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Gênero</label>
            <div class="col-10">
                <asp:DropDownList ID="ddlGenero" class="form-control btn btn-secondary dropdown-toggle" runat="server">
                    <asp:ListItem>Masculino</asp:ListItem>
                    <asp:ListItem>Feminino</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Cidade</label>
            <div class="col-10">
                <asp:DropDownList ID="ddlCidade" CssClass="form-control btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Nascimento</label>
            <div class="col-10">
                <asp:TextBox ID="txtNascimento" type="date" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">CEP</label>
            <div class="col-10">
                <asp:TextBox ID="txtCep" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
            <div class="form-group row">
            <label class="col-2 col-form-label">Bairro</label>
            <div class="col-10">
                <asp:TextBox ID="txtBairro" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Rua</label>
            <div class="col-10">
                <asp:TextBox ID="txtRua" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Num</label>
            <div class="col-10">
                <asp:TextBox ID="txtNum" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">CPF</label>
            <div class="col-10">
                <asp:TextBox ID="txtCpf" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">RG</label>
            <div class="col-10">
                <asp:TextBox ID="txtRg" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-2 col-form-label">Email</label>
            <div class="col-10">
                <asp:TextBox ID="txtEmail" type="text" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button ID="btnCadastrar" class="btn btn-outline-primary" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click"/>
    <asp:Button ID="btnCancelar" class="btn btn-outline-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
</asp:Content>
