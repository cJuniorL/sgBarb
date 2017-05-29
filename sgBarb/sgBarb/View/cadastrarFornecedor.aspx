<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastrarFornecedor.aspx.cs" Inherits="sgBarb.View.cadastrarFornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="position: relative; padding: 1rem; margin: 1rem -1rem; border: solid #f7f7f9; border-width: .2rem;">
        <div class="row">
            <div class="form-group col-6">
                <label>Empresa</label>
                <asp:TextBox ID="txtEmpresa" placeholder="" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
            <div class="form-group col-6">
                <label>Representante</label>
                <asp:TextBox ID="txtRepresentante" placeholder="" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label>Cidade</label>
            <asp:DropDownList ID="ddlCidade" CssClass="form-control btn btn-secondary dropdown-toggle" runat="server"></asp:DropDownList>
        </div>
        <div class="row">
            <div class="form-group col-6">
                <label>Telefone</label>
                <asp:TextBox ID="txtTelefone" placeholder="" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
            <div class="form-group col-6">
                <label>Celular</label>
                <asp:TextBox ID="txtCelular" placeholder="" class="form-control" runat="server" type="text"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button ID="btnCadastrar" class="btn btn-outline-primary" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
    <asp:Button ID="btnCancelar" class="btn btn-outline-warning" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

</asp:Content>
