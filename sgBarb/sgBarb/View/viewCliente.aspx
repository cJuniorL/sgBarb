<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewCliente.aspx.cs" Inherits="sgBarb.View.viewCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Clientes </h1>
    <asp:GridView ID="gdvClientes" runat="server">
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="ButtonApprove"  runat="server"
                    CommandName="approve" Text="Approve" />
            </ItemTemplate>
        </asp:TemplateField>
    </asp:GridView>
</asp:Content>
