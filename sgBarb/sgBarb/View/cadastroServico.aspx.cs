using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class cadastroServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlErro.Visible = false;
                if (verifEditarInserir())
                {
                    carregarServico();
                    btnCadastrar.Text = "Editar";
                }
            }
        }

        private void carregarServico()
        {
            Model.Servico servico = Dal.SerivcoDAL.selectByID(Convert.ToInt32(Request.QueryString["id"]));
            txtDescricao.Text = servico.descr;
            txtValor.Text = servico.valor.ToString("0.00");
        }

        private bool verifEditarInserir()
        {
            return Request.QueryString["id"] != null;
        }

        private Model.Servico getServico()
        {
            if (verificarCampos())
            {
                Model.Servico servico = new Model.Servico();
                servico.descr = txtDescricao.Text;
                servico.valor = Convert.ToSingle(txtValor.Text);
                return servico;
            }
            else
            {
                return null;
            }
        }

        private bool verificarCampos()
        {
            lblErro.Text = "";
            bool verif = true;
            pnlErro.Visible = true;
            if (txtDescricao.Text == "")
            {
                lblErro.Text += " O campo Descrição é obrigatório.";
                verif = false;
                validarControle(false, divDescr, txtDescricao);
            }
            else
                validarControle(true, divDescr, txtDescricao);
            float num;
            if (!float.TryParse(txtValor.Text, out num))
            {
                verif = false;
                lblErro.Text += " O campor valor precisar receber um valor.";
                txtValor.Text = "";
                validarControle(false, divValor, txtValor);
            }
            else
                validarControle(false, divValor, txtValor);
            return verif;
        }

        private void validarControle(bool valido, HtmlGenericControl div, TextBox txt) //true valido - falso invalido
        {
            if (valido)
            {
                div.Attributes["class"].Replace(" has-danger", "");
                txt.CssClass.Replace(" form-control-danger", "");
            }
            else
            {
                div.Attributes["class"] += " has-danger";
                txt.CssClass += " form-control-danger";
            }
        }

        protected void btnAdicionar(object sender, EventArgs e)
        {
            Model.Servico servico = getServico();
            if (servico != null)
            {
                if (verifEditarInserir())
                    Dal.SerivcoDAL.update(servico);
                else
                    Dal.SerivcoDAL.insert(servico);
                Response.Redirect("viewServico.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewServico.aspx");
        }
    }
}