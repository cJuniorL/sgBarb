<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastroCliente.aspx.cs" Inherits="sgBarb.View.cadastroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <div class="form-inline">
        <label class="mr-sm-2 mb-0" for="first_name">Nome</label>
        <label class="mr-sm-2 mb-0" for="last_name">Gênero</label>
        <asp:TextBox ID="txtGenero" placeholder="nome" class="form-control mr-sm-2 mb-2 mb-sm-0" runat="server" type="text"></asp:TextBox>
    </div>--%>
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
        <div class="form-group col-6">
            <label for="Nome">Telefone</label>
            <asp:TextBox ID="txtTelefone" placeholder="(##)####-####" class="form-control" runat="server" type="text"></asp:TextBox>
        </div>
        <div class="form-group col-6">
            <label for="Nome">Celular</label>
            <asp:TextBox ID="txtCelular" placeholder="(##)####-#####" class="form-control" runat="server" type="text"></asp:TextBox>
        </div>
    </div>
</asp:Content>
