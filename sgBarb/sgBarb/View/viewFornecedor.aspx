<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewFornecedor.aspx.cs" Inherits="sgBarb.View.viewFornecedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:GridView ID="gdvFornecedor" runat="server" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" AutoGenerateColumns="False" OnRowCommand="gdvFornecedor_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" Visible="false" />
                <asp:BoundField DataField="empresa" HeaderText="Empresa" />
                <asp:BoundField DataField="representante" HeaderText="Representante" />
                <asp:BoundField DataField="telefone" HeaderText="Telefone" />
                <asp:BoundField DataField="celular" HeaderText="Celular" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="EditarFornecedor"
                            Text="Editar" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnRemover" CssClass="btn btn-outline-danger" runat="server" CausesValidation="false" CommandName="RemoverFornecedor"
                            Text="Remover" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
