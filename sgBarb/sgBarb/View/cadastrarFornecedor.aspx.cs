using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class cadastrarFornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                configurarDropDownCidade();
                if (verificarEditarInserir())
                {
                    carregarFornecedor();
                }
            }
        }

        private void carregarFornecedor()
        {
            Model.Fornecedor fornecedor = Dal.FornecedorDAL.selectByID(Convert.ToInt32(Request.QueryString["id"]));
            txtEmpresa.Text = fornecedor.empresa;
            txtRepresentante.Text = fornecedor.representante;
            txtCelular.Text = fornecedor.celular;
            txtTelefone.Text = fornecedor.telefone;
            ddlCidade.SelectedValue = fornecedor.cidadeID.ToString();
        }

        private bool verificarEditarInserir() //true = edit | false = inserir
        {
            return Request.QueryString["id"] != null;
        }

        private void configurarDropDownCidade()
        {
            ddlCidade.DataValueField = "id";
            ddlCidade.DataTextField = "nome";
            carregarDropDownCidade();
        }

        private void carregarDropDownCidade()
        {
            ddlCidade.DataSource = Dal.CidadeDAL.select().OrderBy(d => d.nome);
            ddlCidade.DataBind();
        }

        private Model.Fornecedor getFornecedor()
        {
            Model.Fornecedor fornecedor;
            if (verificarEditarInserir())
                fornecedor = Dal.FornecedorDAL.selectByID(Convert.ToInt32(Request.QueryString["id"]));
            else
                fornecedor = new Model.Fornecedor();
            fornecedor.empresa = txtEmpresa.Text;
            fornecedor.representante = txtRepresentante.Text;
            fornecedor.telefone = txtTelefone.Text;
            fornecedor.celular = txtCelular.Text;
            fornecedor.cidadeID = Convert.ToInt32(ddlCidade.SelectedValue);
            return fornecedor;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Model.Fornecedor fornecedor = getFornecedor();
            if (fornecedor != null) { 
                if (verificarEditarInserir())
                    Dal.FornecedorDAL.update(fornecedor);
                else
                    Dal.FornecedorDAL.insert(fornecedor);
                Response.Redirect("viewFornecedor.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewFornecedor.aspx");
        }
    }
}