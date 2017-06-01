<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewEmpresa.aspx.cs" Inherits="sgBarb.View.viewEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h1>Clientes </h1>
    <div class="container">
        <asp:GridView ID="gdvClientes" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvClientes_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" Visible="false" />
                <asp:BoundField DataField="descr" HeaderText="Descrição"/>
                <asp:BoundField DataField="valor" HeaderText="Valor" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="EditarServico"
                            Text="Editar" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnRemover" CssClass="btn btn-outline-danger" runat="server" CausesValidation="false" CommandName="RemoverServico"
                            Text="Remover" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <asp:Button ID="btnAdicionar" CssClass="btn btn-outline-primary" runat="server" Text="Novo Serviço"/>
</asp:Content>
