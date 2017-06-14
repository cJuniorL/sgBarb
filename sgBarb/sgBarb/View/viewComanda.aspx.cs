using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class viewComanda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlSucesso.Visible = Convert.ToString(Request.QueryString["ad"]) == "true";
                carregarComanda();
                carregarDropDown();
                txtData.Text = DateTime.Today.ToShortDateString();
                verificarCaixa();
            }
        }

        private void verificarCaixa()
        {
            bool status = Dal.CaixaDal.select().FirstOrDefault(c => c.aberto) != null;
            pnlAbrirCaixa.Visible = !status;
            pnlCaixa.Visible = status;
        }

        private void carregarComanda()
        {
            List<Model.Comanda> lstComanda = Dal.ComandaDAL.select().Where(c => c.aberta).OrderBy(c => c.id).ToList();
            var dados = from c in lstComanda
                        select new
                        {
                            id = c.id,
                            cliente = Dal.ClienteDAL.selectById(c.clienteID).nome,
                            funcionario = Dal.FuncionarioDAL.selectById(c.funcionarioID).nome
                        };
            gdvComanda.DataSource = dados.ToList();
            gdvComanda.DataBind();

        }

        private void carregarDropDown()
        {
            ddlCliente.DataValueField = "id";
            ddlCliente.DataTextField = "nome";
            ddlCliente.DataSource = Dal.ClienteDAL.selectIdNome();
            ddlCliente.DataBind();
            ddlFuncionario.DataValueField = "id";
            ddlFuncionario.DataTextField = "nome";
            ddlFuncionario.DataSource = Dal.FuncionarioDAL.selectIdNome();
            ddlFuncionario.DataBind();
        }

        protected void btnAdicionarComanda_Click(object sender, EventArgs e)
        {
            Model.Comanda comanda = new Model.Comanda();
            comanda.clienteID = Convert.ToInt32(ddlCliente.SelectedValue);
            comanda.funcionarioID = Convert.ToInt32(ddlFuncionario.SelectedValue);
            comanda.dataCompra = Convert.ToDateTime(txtData.Text);
            comanda.aberta = true;
            comanda.descontoTotal = 0;
            comanda.valorTotal = 0;
            Dal.ComandaDAL.insert(comanda);
            carregarComanda();
        }

        protected void gdvComanda_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Redirect("itensComanda.aspx?id=" + e.CommandArgument);
        }

        protected void btnAbrirCaixa_Click(object sender, EventArgs e)
        {
            Model.Caixa caixa = new Model.Caixa();
            caixa.aberto = true;
            caixa.dataAbertura = DateTime.Today;
            caixa.dataFechamento = DateTime.Today;
            Dal.CaixaDal.insert(caixa);
            verificarCaixa();
        }

        protected void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            if (Dal.ComandaDAL.select().Count(c => c.aberta) == 0)
            {
                Model.Caixa caixa = Dal.CaixaDal.select().First(c => c.aberto);
                caixa.aberto = false;
                caixa.dataFechamento = DateTime.Today;
                Dal.CaixaDal.update(caixa);
                verificarCaixa();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Erro", "alert('É necessário fechar as comandas para fechar o caixa');", true);
            }
        }
    }
}