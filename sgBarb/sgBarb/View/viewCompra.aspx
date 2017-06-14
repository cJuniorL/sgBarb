<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewCompra.aspx.cs" Inherits="sgBarb.View.viewCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <asp:GridView ID="gdvCompra" runat="server" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" AutoGenerateColumns="False" OnRowCommand="gdvCompra_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" Visible="false" />
                <asp:BoundField DataField="fornecedor" HeaderText="Fornecedor" />
                <asp:BoundField DataField="data" HeaderText="Data da Compra" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="btnView" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="VisualizarCompra"
                            Text="Visualizar" CommandArgument='<%# Eval("id") %>' />
                         <asp:Button ID="btnRelatorio" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="imprimirCompra"
                            Text="Imprimir" CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
     </div>

</asp:Content>
