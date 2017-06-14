<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewServico.aspx.cs" Inherits="sgBarb.View.viewServico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <h1>Serviços </h1>
    <div class="container">
        <asp:GridView ID="gdvServico" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvServico_RowCommand1" >
            <Columns>
                <asp:BoundField DataField="id" Visible="false" />
                <asp:BoundField DataField="descr" HeaderText="Serviço"/>
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
    <asp:Button ID="btnAdicionar" CssClass="btn btn-outline-primary" runat="server" Text="Novo Serviço" OnClick="btnAdicionar_Click" />
    <asp:Button ID="btnRelatorio" CssClass="btn btn-outline-primary float-right" runat="server" Text="Relação Serviços" OnClick="btnRelatorio_Click" />
</asp:Content>
