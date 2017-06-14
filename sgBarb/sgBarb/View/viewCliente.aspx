<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewCliente.aspx.cs" Inherits="sgBarb.View.viewCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Clientes </h1>
    <div class="container">
        <asp:GridView ID="gdvClientes" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvClientes_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" Visible="false" />
                <asp:BoundField DataField="nome" HeaderText="Nome"/>
                <asp:BoundField DataField="telefone" HeaderText="Telefone" />
                <asp:BoundField DataField="celular" HeaderText="Celular" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="EditarCliente"
                            Text="Editar" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnRemover" CssClass="btn btn-outline-danger" runat="server" CausesValidation="false" CommandName="RemoverCliente"
                            Text="Remover" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnVis" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="VisualizarCliente"
                            Text="Visualizar" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:Button ID="btnAdicionar" CssClass="btn btn-outline-primary" runat="server" Text="Novo Cliente" OnClick="btnAdicionar_Click" />
</asp:Content>
