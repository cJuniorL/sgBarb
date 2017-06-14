<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="cadastroServico.aspx.cs" Inherits="sgBarb.View.cadastroServico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Cadastro de Serviço</h1>
    <div style="position: relative; padding: 1rem; margin: 1rem -1rem; border: solid #f7f7f9; border-width: .2rem;">
        <div id="divDescr" class="form-group col-8" runat="server"  >
            <label class="form-control-label" for="Descricao">Descricao</label>
            <asp:TextBox ID="txtDescricao" placeholder="Descrição do Serviço" cssClass="form-control" runat="server" type="text"></asp:TextBox>

        </div>
        <div id="divValor" class="form-group col-4" runat="server">

            <label class="form-control-label" for="Descricao" id="lblVaor">Valor</label>
            <div class="input-group">
                <div class="input-group-addon">R$</div>
                <asp:TextBox ID="txtValor" placeholder="Valor do Serviço" cssClass="form-control" runat="server" type="text"></asp:TextBox>
            </div>
        </div>
    </div>
    <asp:Button ID="btnCadastrar" class="btn btn-outline-primary" runat="server" Text="Cadastrar" OnClick="btnAdicionar" />
    <asp:Button ID="btnCancelar" class="btn btn-outline-warning" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
    <asp:Panel ID="pnlErro" runat="server">
        <br />
        <div class="alert alert-danger" role="alert">
            <strong>Erro!</strong>
            <asp:Label ID="lblErro" runat="server" Text=""></asp:Label>
        </div>

        
    </asp:Panel>
</asp:Content>
