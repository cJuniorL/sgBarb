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
                if (verifEditarInserir())
                {
                    carregarCliente();
                    btnCadastrar.Text = "Editar";
                }
            }
        }

        private void carregarCliente()
        {

            Model.Cliente cliente = Dal.ClienteDAL.selectById(Convert.ToInt32(Request.QueryString["id"]));
            txtNome.Text = cliente.nome;
            ddlGenero.SelectedIndex = Convert.ToInt32(!cliente.sexo);
            txtNascimento.Text = Funcoes.InputTimeBootstrap.getInputDate(cliente.nascimento);
            txtTelefone.Text = cliente.telefone;
            txtCelular.Text = cliente.celular;
            ddlCidade.SelectedValue = cliente.cidadeID.ToString();
            txtCep.Text = cliente.cep;
            txtBairro.Text = cliente.bairro;
            txtRua.Text = cliente.rua;
            txtNum.Text = cliente.num.ToString();
            txtCpf.Text = cliente.cpf;
            txtRg.Text = cliente.rg;
            txtEmail.Text = cliente.email;
        }

        private bool verifEditarInserir() //true = editar | false = inserir
        {
            return Request.QueryString["id"] != null;
        }

        private void configuarDropDownCidade()
        {
            ddlCidade.DataTextField = "nome";
            ddlCidade.DataValueField = "id";
            ddlCidade.DataSource = Dal.CidadeDAL.select().OrderBy(c => c.nome).ToList();
            ddlCidade.DataBind();
            ddlCidade.SelectedIndex = -1;
        }

        private bool verificarCliente()
        {
            return (txtNome.Text != null && ddlCidade.SelectedIndex != -1);
        }

        private Model.Cliente getCliente()
        {
            if (verificarCamposObrigatorios())
            {
                Model.Cliente cliente;
                if (verifEditarInserir())
                    cliente = Dal.ClienteDAL.selectById(Convert.ToInt32(Request.QueryString["id"]));
                else
                    cliente = new Model.Cliente();
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
                cliente.credito = verifEditarInserir() ? cliente.credito : 0;  //SE TIVER EDITANDO N PD FAZER ISTO..
                cliente.observacao = "";
                cliente.cidadeID = Convert.ToInt32(ddlCidade.SelectedValue);
                return cliente;
            }
            else return null;
        }

        private bool verificarCamposObrigatorios()
        {
            bool verif = true;
            if (txtNome.Text == "")
            {
                verif = false;
                //tratamento inputNome
            }
            if (ddlCidade.SelectedIndex == -1)
            {
                verif = false;
            }
            if (txtNascimento.Text == "")
            {
                verif = false;
            }
            return verif;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Model.Cliente cliente = getCliente();
            if (cliente != null)
            {
                if (verifEditarInserir())
                    Dal.ClienteDAL.uptade(cliente);
                else
                    Dal.ClienteDAL.insert(cliente);
                Response.Redirect("viewCliente.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewCliente.aspx");
        }
    }
}