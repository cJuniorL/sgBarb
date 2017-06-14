<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="viewComanda.aspx.cs" Inherits="sgBarb.View.viewComanda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSucesso" runat="server">
        <div class="alert alert-success" role="alert">
            <strong>Comanda Fechada!</strong> A comanda foi fechada com sucesso!
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlCaixa" runat="server">
        <h1>Comandas em Aberto </h1>
        <div class="container">
            <asp:GridView ID="gdvComanda" HeaderStyle-CssClass="thead-inverse" CssClass="table table-hover " GridLines="None" AutoGenerateColumns="False" runat="server" OnRowCommand="gdvComanda_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Código" />
                    <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="funcionario" HeaderText="Funcionario" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" CssClass="btn btn-outline-primary" runat="server" CausesValidation="false" CommandName="AbrirComanda"
                                Text="Abrir" CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <button class="btn btn-secondary" data-toggle="modal" data-target="#modalNovaComanda" type="button">
                Nova Comanda
            </button>
            <button class="btn btn-secondary" data-toggle="modal" data-target="#modalFecharCaixa" type="button">
                Fechar Caixa
            </button>

        </div>
        <div class="modal fade" id="modalFecharCaixa" tabindex="-1" role="dialog" aria-labelledby="fecharCaixa" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="fecharCaixa">Fechar Caixa</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Você tem certeza que deseja fechar o caixa?
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnNao" runat="server" Text="Cancelar" type="button" class="btn btn-secondary" />
                        <asp:Button ID="btnFecharCaixa" runat="server" Text="Fechar" type="button" class="btn btn-primary" OnClick="btnFecharCaixa_Click"/>
                    </div>

                </div>
            </div>
        </div>
        <div class="modal fade" id="modalNovaComanda" tabindex="-1" role="dialog" aria-labelledby="novaComanda" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="novaComanda">Abrir nova Comanda</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="recipient-name" class="form-control-label">Funcionário:</label>
                            <asp:DropDownList ID="ddlFuncionario" CssClass="btn btn-secondary dropdown-toggle form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="recipient-name" class="form-control-label">Cliente:</label>
                            <asp:DropDownList ID="ddlCliente" CssClass="btn btn-secondary dropdown-toggle form-control" runat="server"></asp:DropDownList>

                        </div>
                        <div class="form-group">
                            <label for="recipient-name" class="form-control-label">Data:</label>
                            <asp:TextBox ID="txtData" type="text" class="form-control" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnCancelarComanda" runat="server" Text="Cancelar" type="button" class="btn btn-secondary" />
                        <asp:Button ID="btnAdicionarComanda" runat="server" Text="Adicionar" type="button" class="btn btn-primary" OnClick="btnAdicionarComanda_Click" />
                    </div>

                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlAbrirCaixa" runat="server">
        <h3>Caixa Fechado</h3>
        <br />
        <asp:Button ID="btnAbrirCaixa" runat="server" Text="Abrir Caixa" class="btn btn-primary" OnClick="btnAbrirCaixa_Click" />
    </asp:Panel>
</asp:Content>
