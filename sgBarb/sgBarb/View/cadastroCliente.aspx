<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastroCliente.aspx.cs" Inherits="sgBarb.View.cadastroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <div class="form-inline">
        <label class="mr-sm-2 mb-0" for="first_name">Nome</label>
        <label class="mr-sm-2 mb-0" for="last_name">Gênero</label>
        <asp:TextBox ID="txtGenero" placeholder="nome" class="form-control mr-sm-2 mb-2 mb-sm-0" runat="server" type="text"></asp:TextBox>
    </div>--%>
    <fieldset class="form-group">

        <label for="Nome">Nome</label>
        <asp:TextBox ID="txtNome" placeholder="nome" class="form-control" runat="server" type="text"></asp:TextBox>
    </fieldset>
    <fieldset class="form-group">
        <label for="Gênero">Gênero </label>
        <asp:DropDownList ID="ddlGenero" class="form-control btn btn-secondary dropdown-toggle" runat="server">
            <asp:ListItem>Masculino</asp:ListItem>
            <asp:ListItem>Feminino</asp:ListItem>
        </asp:DropDownList>
    </fieldset>
</asp:Content>
