<%@ Page Title="" Language="C#" MasterPageFile="~/View/cabecalho.Master" AutoEventWireup="true" CodeBehind="agenda.aspx.cs" Inherits="sgBarb.View.agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ckbEncaixe(checkbox) {
            var fieldSet = document.getElementById("fdsDuracao");
            checkbox.checked ? fieldSet.disabled = true : fieldSet.disabled = false;
        }

    </script>
    <script runat="server">

    </script>

    <style>
        table, tr, th, td {
            border: solid 1px black;
        }

        td {
            height: 15px;
        }
        .tdHr{
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% Response.Write("<table class=\"tbAgenda\">");
        Response.Write("<tr>");
        for (int i = 0; i < 288; i++)
        {
            Response.Write("<tr>");
            if (i % 6 == 0)
            {
                Response.Write("<td rowspan=\"6\"> " + i / 12 + ":" + (i % 12) * 5 + " </td>");
            }
            Response.Write("<td class=\"tdHr\">  ");
            Response.Write("</td>");
            Response.Write("</tr>");
        }
        Response.Write("</tr>");
        Response.Write("</table>");
    %>
    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#novoHorario">
        Novo Horário
    </button>
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

</asp:Content>
