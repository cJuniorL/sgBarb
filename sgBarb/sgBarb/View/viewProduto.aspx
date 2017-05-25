<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewProduto.aspx.cs" Inherits="sgBarb.View.viewProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gdvProduto" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" AutoGenerateColumns="False" runat="server" OnRowCommand="gdvProduto_RowCommand">
        <Columns>
            <asp:BoundField DataField="id" Visible="false" />
            <asp:BoundField DataField="descr" HeaderText="Descricao" />
            <asp:BoundField DataField="valorVenda" HeaderText="Valor de Venda" />
            <asp:BoundField DataField="quantidade" HeaderText="Estoque" />

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="EditarProduto"
                        Text="Editar" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnRemover" CssClass="btn btn-outline-danger" runat="server" CausesValidation="false" CommandName="RemoverProduto"
                        Text="Remover" CommandArgument='<%# Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAdicionar" CssClass="btn btn-outline-primary" runat="server" Text="Novo Produto" OnClick="btnAdicionar_Click"/>

</asp:Content>
