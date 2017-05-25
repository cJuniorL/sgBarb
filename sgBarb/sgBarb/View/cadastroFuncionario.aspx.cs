using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class cadastroFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                configuarDropDownCidade();
                if (verifEditarInserir())
                {
                    carregarFuncionar();
                    btnCadastrar.Text = "Editar";
                }
            }
        }

        private bool verifEditarInserir()
        {
            return Request.QueryString["id"] != null;
        }

        private void carregarFuncionar()
        {
            Model.Funcionario funcionario = Dal.FuncionarioDAL.selectById(Convert.ToInt32(Request.QueryString["id"]));
            txtNome.Text = funcionario.nome;
            ddlGenero.SelectedIndex = Convert.ToInt32(!funcionario.sexo);
            ddlCidade.SelectedValue = Convert.ToString(funcionario.cidadeID);
            txtNascimento.Text = Funcoes.InputTimeBootstrap.getInputDate(funcionario.nascimento);
            txtCep.Text = funcionario.cep;
            txtBairro.Text = funcionario.bairro;
            txtRua.Text = funcionario.rua;
            txtNum.Text = Convert.ToString(funcionario.num);
            txtCpf.Text = funcionario.cpf;
            txtRg.Text = funcionario.rg;
            txtEmail.Text = funcionario.email;
        }



        private void configuarDropDownCidade()
        {
            ddlCidade.DataTextField = "nome";
            ddlCidade.DataValueField = "id";
            ddlCidade.DataSource = Dal.CidadeDAL.select().OrderBy(c => c.nome).ToList();
            ddlCidade.DataBind();
            ddlCidade.SelectedIndex = -1;
        }

        private Model.Funcionario getFuncionario()
        {
            Model.Funcionario funcionario;
            if (verifEditarInserir())
                funcionario = Dal.FuncionarioDAL.selectById(Convert.ToInt32(Request.QueryString["id"]));
            {
                funcionario = new Model.Funcionario();
                funcionario.salario = 0;
                funcionario.comissao = 0;
            }
            funcionario.nome = txtNome.Text;
            funcionario.sexo = ddlGenero.SelectedIndex == 0;
            funcionario.nascimento = Convert.ToDateTime(txtNascimento.Text);
            funcionario.cep = txtCep.Text;
            funcionario.bairro = txtBairro.Text;
            funcionario.rua = txtRua.Text;
            funcionario.num = Convert.ToInt32(txtNum.Text);
            funcionario.cpf = txtCpf.Text;
            funcionario.rg = txtRg.Text;
            funcionario.email = txtEmail.Text;
            funcionario.cidadeID = Convert.ToInt32(ddlCidade.SelectedValue);
            return funcionario;
        }


        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Model.Funcionario funcionario = getFuncionario();
            if (funcionario != null)
            {
                if (verifEditarInserir())
                {
                    Dal.FuncionarioDAL.update(funcionario);
                }
                else
                {
                    Dal.FuncionarioDAL.insert(funcionario);
                }
                Response.Redirect("viewFuncionario.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewFuncionario.aspx");
        }
    }
}