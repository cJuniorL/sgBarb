<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="visualizarCompra.aspx.cs" Inherits="sgBarb.View.visualizarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>
        <asp:Label ID="lblCompra" runat="server" Style="font-weight: bold"></asp:Label>
    </h1>

    <asp:GridView ID="gdvCarrinho" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" runat="server" AutoGenerateColumns="False">
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
        </Columns>
    </asp:GridView>
    <h4>
        <asp:Label ID="lblTotal" class="float-right" runat="server" Text="Label"></asp:Label>
    </h4>
    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" type="button" class="btn btn-secondary" OnClick="btnVoltar_Click" />

</asp:Content>
