<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="inserirImagem.aspx.cs" Inherits="sgBarb.View.inserirImagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Inserir Imagem</h1>
    <div style="position: relative; padding: 1rem; margin: 1rem -1rem; border: solid #f7f7f9; border-width: .2rem;">

        <div class="form-group">
            <label>Cliente </label>
            <asp:DropDownList ID="ddlCliente" CssClass="form-control btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="exampleInputFile">Imagem</label>
            <asp:FileUpload ID="fulImagems" runat="server" type="file" class="form-control-file" accept="image/x-png,image/gif,image/jpeg" aria-describedby="fileHelp" />
            <small id="fileHelp" class="form-text text-muted">Selecione a imagem que deseja inserir.</small>
        </div>
    </div>
    <asp:Button ID="btnGravar" runat="server" class="btn btn-outline-primary" Text="Cadastrar" OnClick="btnGravar_Click" />
    <asp:Button ID="btnCancelar" class="btn btn-outline-warning" runat="server" Text="Cancelar" />
</asp:Content>
