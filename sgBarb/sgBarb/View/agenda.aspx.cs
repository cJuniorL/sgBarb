using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                configuarDropDown();
                txtData.Text = Funcoes.InputTimeBootstrap.getInputDate(DateTime.Today);
            }
        }

        private void configuarDropDown()
        {
            ddlCliente.DataValueField = "id";
            ddlCliente.DataTextField = "nome";
            ddlFuncionario.DataValueField = "id";
            ddlFuncionario.DataTextField = "nome";
            ddlCliente.DataSource = Dal.ClienteDAL.selectIdNome();
            ddlCliente.DataBind();
            ddlFuncionario.DataSource = Dal.FuncionarioDAL.selectIdNome();
            ddlFuncionario.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Model.Agenda agenda = getAgenda();
            if (agenda != null)
            {
                Dal.AgendaDAL.insert(agenda);
            }
            limparCampos();
        }

        private Model.Agenda getAgenda()
        {
            Model.Agenda agenda = new Model.Agenda();
            agenda.data = Convert.ToDateTime(txtData.Text);
            agenda.horarioInicio = Convert.ToDateTime(txtHorario.Text);
            agenda.duracao = Convert.ToDateTime(txtDuracao.Text);
            agenda.encaixe = ckbEncaixe.Checked;
            agenda.funcionarioID = Convert.ToInt32(ddlFuncionario.SelectedValue);
            agenda.clienteID = Convert.ToInt32(ddlCliente.SelectedValue);
            return agenda;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Model.Agenda agenda = getAgenda();
            if (agenda != null)
            {
                Dal.AgendaDAL.insert(agenda);
            }
        }

        private void limparCampos()
        {
            txtData.Text = Funcoes.InputTimeBootstrap.getInputDate(DateTime.Today);
            txtHorario.Text = "";
            ddlCliente.SelectedIndex = -1;
            ddlFuncionario.SelectedIndex = -1;
            txtDuracao.Text = "";
            ckbEncaixe.Checked = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
    }
}