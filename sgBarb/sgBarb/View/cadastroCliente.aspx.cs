using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class cadastroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                configuarDropDownCidade();
            }
        }

        private void configuarDropDownCidade()
        {
            ddlCidade.DataTextField = "nome";
            ddlCidade.DataValueField = "id";
            ddlCidade.DataSource = Dal.CidadeDAL.select().OrderBy(c => c.nome).ToList();
            ddlCidade.DataBind(); 
        }

        private bool verificarCliente()
        {
            return (txtNome.Text != null && ddlCidade.SelectedIndex != -1);
        }

        private Model.Cliente getCliente()
        {
            Model.Cliente cliente = new Model.Cliente();
            cliente.nome = txtNome.Text;
            cliente.sexo = ddlGenero.SelectedIndex == 0;
            cliente.nascimento = Convert.ToDateTime(txtNascimento.Text);
            cliente.telefone = txtTelefone.Text;
            cliente.celular = txtCelular.Text;
            cliente.cep = txtCep.Text;
            cliente.bairro = txtBairro.Text;
            cliente.rua = txtRua.Text;
            cliente.num = txtNum.Text != "" ? Convert.ToInt32(txtNum.Text) : 0;
            cliente.cpf = txtCpf.Text;
            cliente.rg = txtRg.Text;
            cliente.email = txtEmail.Text;
            cliente.credito = 0; //SE TIVER EDITANDO N PD FAZER ISTO..
            cliente.observacao = "";
            cliente.cidadeID = Convert.ToInt32(ddlCidade.SelectedValue);
            return cliente;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Dal.ClienteDAL.insert(getCliente());

        }
    }
}