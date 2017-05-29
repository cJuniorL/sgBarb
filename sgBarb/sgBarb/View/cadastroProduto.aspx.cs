using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class cadastroProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                configurarDropDownProduto();
                if (verificarEditarInserir())
                {
                    carregarProduto();
                }
            }
        }



        private void carregarProduto()
        {
            Model.Produto produto = Dal.ProdutoDAL.selectByID(Convert.ToInt32(Request.QueryString["id"]));
            txtDescricao.Text = produto.descr;
            txtEstoque.Text = produto.quantidade.ToString();
            txtValor.Text = produto.valorVenda.ToString("0.00");
            ddlTipoProduto.SelectedValue = produto.tipoProdutoID.ToString();
        }

        private bool verificarEditarInserir() //true = edit | false = inserir
        {
            return Request.QueryString["id"] != null;
        }


        private void configurarDropDownProduto()
        {
            ddlTipoProduto.DataValueField = "id";
            ddlTipoProduto.DataTextField = "descr";
            carregarDropDownTipoProduto();
        }

        private void carregarDropDownTipoProduto()
        {
            ddlTipoProduto.DataSource = Dal.TipoProdutoDAL.select();
            ddlTipoProduto.DataBind();
        }

        protected void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (txtDescricaoTipoProduto.Text != "")
            {
                Model.TipoProduto tipoPrduto = new Model.TipoProduto();
                tipoPrduto.descr = txtDescricaoTipoProduto.Text;
                txtDescricaoTipoProduto.Text = "";
                Dal.TipoProdutoDAL.insert(tipoPrduto);
                carregarDropDownTipoProduto();
            }
        }

        private Model.Produto getProduto()
        {
            Model.Produto produto;
            if (verificarEditarInserir())
                produto = Dal.ProdutoDAL.selectByID(Convert.ToInt32(Request.QueryString["id"]));
            else
                produto = new Model.Produto();
            produto.descr = txtDescricao.Text;
            produto.valorVenda = Convert.ToSingle(txtValor.Text);
            produto.quantidade = Convert.ToInt32(txtEstoque.Text);
            produto.tipoProdutoID = Convert.ToInt32(ddlTipoProduto.SelectedValue);
            return produto;
        }

        protected void btnCancelarProduto_Click(object sender, EventArgs e)
        {
            txtDescricaoTipoProduto.Text = "";
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Model.Produto produto = getProduto();
            if (produto != null)
            {
                if (verificarEditarInserir())
                    Dal.ProdutoDAL.update(produto);
                else
                    Dal.ProdutoDAL.insert(produto);
                Response.Redirect("viewProduto.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewProduto.aspx");
        }
    }
}