<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="agenda.aspx.cs" Inherits="sgBarb.View.agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ckbEncaixe(checkbox) {
            var fieldSet = document.getElementById("fdsDuracao");
            checkbox.checked ? fieldSet.disabled = true : fieldSet.disabled = false;
        }
    </script>
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Agenda de Horários</h1>
    <div class="row">
        <div class="form-group col-5">
            <label for="recipient-name" class="form-control-label">Funcionário:</label>
            <asp:DropDownList ID="ddlFuncionarioInicio" class="btn btn-secondary dropdown-toggle form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="form-group col-5">
            <label for="recipient-name" class="form-control-label">Data:</label>
            <asp:TextBox ID="txtDia" type="date" class="form-control" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnRecarregarAgenda" class="btn btn-primary" runat="server" Text="Recarregar" OnClick="btnRecarregarAgenda_Click" />
    </div>
    <%
        List<sgBarb.Model.Agenda> lstAgenda = sgBarb.Dal.AgendaDAL.select().Where(f => f.data == Convert.ToDateTime(txtDia.Text) && f.funcionarioID == Convert.ToInt32(ddlFuncionarioInicio.SelectedValue)).OrderBy(t => t.getHora()).ThenBy(t => t.getMinuto()).ThenBy(t => !t.encaixe).ToList();
        Response.Write("<table class=\"table table-striped table-hover\">");
        Response.Write("<tr> <th> Horários </th> <th> </th> </td>");
        for (int i = 0; i < lstAgenda.Count; i++)
        {
            Response.Write("<tr> <td> " + sgBarb.Dal.ClienteDAL.selectById(lstAgenda[i].clienteID).nome + "<br>" + lstAgenda[i].horarioInicio + " ~ " + lstAgenda[i].horarioFimCalc() + (lstAgenda[i].encaixe ? "[Encaixe]" : "")
                + "</td> <td> <button onclick=\"document.getElementById('idAgenda').value=" + lstAgenda[i].id + ";\" data-toggle=\"modal\" data-target=\"#modalRemoverAgenda\" type=\"button\" class=\"btn btn-danger\"> Remover </button> </td>"
                + "</tr>");
        }
        Response.Write("</table>");
    %>
    <input id="idAgenda" type="hidden" runat="server" clientidmode="Static" value="" />
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#novoHorario">
        Novo Horário</button>
    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" type="button" class="btn btn-secondary" OnClick="btnImprimir_Click" />
    <div class="modal fade" id="novoHorario" tabindex="-1" role="dialog" aria-labelledby="novoHorarioTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="novoHorarioTitle">Novo Horário</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="form-control-label">Data:</label>
                        <asp:TextBox ID="txtData" type="date" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="recipient-name" class="form-control-label">Horário:</label>
                        <asp:TextBox ID="txtHorario" type="time" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="recipient-name" class="form-control-label">Cliente:</label>
                        <asp:DropDownList ID="ddlCliente" class="btn btn-secondary dropdown-toggle form-control" runat="server"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="recipient-name" class="form-control-label">Funcionário:</label>
                        <asp:DropDownList ID="ddlFuncionario" class="btn btn-secondary dropdown-toggle form-control" runat="server"></asp:DropDownList>
                    </div>
                    <fieldset id="fdsDuracao">
                        <div class="form-group">
                            <label for="recipient-name" class="form-control-label">Duração:</label>
                            <asp:TextBox ID="txtDuracao" type="time" class="form-control" runat="server"></asp:TextBox>
                        </div>
                    </fieldset>
                    <div class="form-check">
                        <label class="form-check-label">
                            <asp:CheckBox ID="ckbEncaixe" runat="server" type="checkbox" onclick="ckbEncaixe(this);" class="form-check-input" />
                            Encaixe
                        </label>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" type="button" class="btn btn-secondary" OnClick="btnCancelar_Click" />
                    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" type="button" class="btn btn-primary" OnClick="btnAdicionar_Click" />

                </div>

            </div>
        </div>
    </div>
    <div class="modal fade" id="modalRemoverAgenda" tabindex="-1" role="dialog" aria-labelledby="removerAgenda" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="removerAgenda">Remover Horário</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Deseja Remover este horário da agenda?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnRemover" runat="server" Text="Remover" class="btn btn-danger" OnClick="btnRemover_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
