using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class entradaProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblTotal.Visible = false;
                ddlFornecedor.DataTextField = "empresa";
                ddlFornecedor.DataValueField = "id";
                ddlTipoProduto.DataTextField = "descr";
                ddlTipoProduto.DataValueField = "id";
                ddlProduto.DataTextField = "descr";
                ddlProduto.DataValueField = "id";
                carregarGridFornecedor();
                carregarTipoProduto();
                pnlProduto.Visible = false;
                lblData.Text = "Data: " + DateTime.Today.ToShortDateString();
            }
        }

        public void carregarGridFornecedor()
        {

            ddlFornecedor.DataSource = Dal.FornecedorDAL.selectIdEmpresa().OrderBy(b => b.empresa).ToList();
            ddlFornecedor.DataBind();
        }

        public void carregarTipoProduto()
        {
            ddlTipoProduto.DataSource = Dal.TipoProdutoDAL.select().OrderBy(b => b.descr).ToList();
            ddlTipoProduto.DataBind();
            atualizarProduto();
        }

        protected void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            pnlProduto.Visible = !pnlProduto.Visible;
            btnAdicionarProduto.Visible = false;
            btnFinalizarCompra.Visible = false;
        }

        private void limparCampos()
        {
            txtQuantidade.Text = "";
            txtValorUni.Text = "";
            txtValor.Text = "";
        }

        protected void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            int quantidade;
            if (int.TryParse(txtQuantidade.Text, out quantidade))
            {
                float valorUni;
                if (float.TryParse(txtValorUni.Text, out valorUni))
                    txtValor.Text = (valorUni * quantidade).ToString("0.00");
                txtValorUni.Focus();
            }
            else
            {
                txtQuantidade.Text = "";
                txtValor.Text = "";
            }

        }

        protected void txtValor_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtValorUni_TextChanged(object sender, EventArgs e)
        {
            float valorUni;
            if (float.TryParse(txtValorUni.Text, out valorUni))
            {
                int quantidade;
                if (int.TryParse(txtQuantidade.Text, out quantidade))
                {
                    txtValor.Text = (valorUni * quantidade).ToString("0.00");
                }
                btnAddEntradaProduto.Focus();
            }
            else
            {
                txtValorUni.Text = "";
                txtValor.Text = "";
            }
        }

        private List<Model.EntradaProduto> retornarListaEntradaProduto()
        {
            List<Model.EntradaProduto> lstEntradaProduto = new List<Model.EntradaProduto>();
            foreach (GridViewRow gdvRow in gdvCarrinho.Rows)
            {
                Model.EntradaProduto entradaProduto = new Model.EntradaProduto();
                entradaProduto.produtoID = Convert.ToInt32(((Label)(gdvRow.FindControl("lblIdProduto"))).Text);
                entradaProduto.quantidade = Convert.ToInt32(((Label)(gdvRow.FindControl("lblQuantidadeDgv"))).Text);
                entradaProduto.valorUni = Convert.ToSingle(((Label)(gdvRow.FindControl("lblValorUniDgv"))).Text.Replace("R$ ", ""));
                lstEntradaProduto.Add(entradaProduto);
            }
            return lstEntradaProduto;
        }

        protected void btnAddEntradaProduto_Click(object sender, EventArgs e)
        {
            bool cadastrar = verificarCampos();
            if (cadastrar)
            {
                List<Model.EntradaProduto> lstEntradaProduto = retornarListaEntradaProduto();
                Model.EntradaProduto entradaProduto = new Model.EntradaProduto();
                entradaProduto.produtoID = Convert.ToInt32(ddlProduto.SelectedValue);
                entradaProduto.quantidade = Convert.ToInt32(txtQuantidade.Text);
                entradaProduto.valorUni = Convert.ToSingle(txtValorUni.Text);
                lstEntradaProduto.Add(entradaProduto);
                carregarGridView(lstEntradaProduto);
                pnlProduto.Visible = false;
                txtQuantidadeCssNormal();
                txtValorUniNormal();
                btnAdicionarProduto.Visible = true;
                btnFinalizarCompra.Visible = true;
                limparCampos();
            }

        }

        private void carregarGridView(List<Model.EntradaProduto> lstEntradaProduto)
        {

            var dados = from p in lstEntradaProduto
                        select new
                        {
                            idProduto = p.produtoID,
                            produto = Dal.ProdutoDAL.selectByID(p.produtoID).descr,
                            quantidade = p.quantidade,
                            valorUni = "R$ " + p.valorUni.ToString("0.00"),
                            valorTotal = "R$ " + (p.valorUni * p.quantidade).ToString("0.00"),
                        };
            gdvCarrinho.DataSource = dados;
            gdvCarrinho.DataBind();
            lblTotal.Visible = lstEntradaProduto.Count > 0;
            lblTotal.Text = "Valor Total: R$ " + lstEntradaProduto.Sum(s => s.valorUni * s.quantidade);

        }


        private void txtQuantidadeCssFailed()
        {
            divQuantidade.Attributes["class"] = "form-group col-4 has-danger";
            txtQuantidade.CssClass = "form-control form-control-danger";
            lblQuantidade.Attributes["class"] = "col-form-label";
        }

        private void txtQuantidadeCssNormal()
        {
            divQuantidade.Attributes["class"] = "form-group col-4";
            txtQuantidade.CssClass = "form-control";
            lblQuantidade.Attributes["class"] = "";
        }

        private void txtValorUniFailed()
        {
            divValorUni.Attributes["class"] = "form-group col-4 has-danger";
            txtValorUni.CssClass = "form-control form-control-danger";
            lblValorUni.Attributes["class"] = "col-form-label";
        }

        private void txtValorUniNormal()
        {
            divValorUni.Attributes["class"] = "form-group col-4";
            txtValorUni.CssClass = "form-control";
            lblValorUni.Attributes["class"] = "";
        }

        private bool verificarCampos()
        {
            bool verifCampos = true;
            if (ddlProduto.SelectedIndex != -1)
            {

            }
            else
            {
                verifCampos = false;
            }
            if (txtQuantidade.Text != "")
            {
                txtQuantidadeCssNormal();
            }
            else
            {
                txtQuantidadeCssFailed();
                verifCampos = false;
            }
            if (txtValorUni.Text != "")
            {
                txtValorUniNormal();
            }
            else
            {
                verifCampos = false;
                txtValorUniFailed();
            }
            return verifCampos;
        }

        protected void ddlTipoProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoProduto.SelectedIndex != -1)
            {
                atualizarProduto();
            }
        }

        private void atualizarProduto()
        {
            ddlProduto.DataSource = Dal.ProdutoDAL.selectIdDescrByIdTipo(Convert.ToInt32(ddlTipoProduto.SelectedValue)).OrderBy(p => p.descr).ToList();
            ddlProduto.DataBind();
        }

        protected void gdvCarrinho_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            removerEntradaProduto(Convert.ToInt32(e.CommandArgument));
        }

        private void removerEntradaProduto(int row)
        {
            List<Model.EntradaProduto> lstEntradaProduto = retornarListaEntradaProduto();
            lstEntradaProduto.RemoveAt(row);
            carregarGridView(lstEntradaProduto);
        }

        protected void btnCancelarEntradaPrdouto_Click(object sender, EventArgs e)
        {
            pnlProduto.Visible = false;
            txtQuantidadeCssNormal();
            txtValorUniNormal();
            btnAdicionarProduto.Visible = true;
            btnFinalizarCompra.Visible = true;
            limparCampos();
        }

        protected void btnFinalizarCompra_Click1(object sender, EventArgs e)
        {
            Model.Compra compra = new Model.Compra();
            compra.dataCompra = DateTime.Now;
            compra.fornecedorID = Convert.ToInt32(ddlFornecedor.SelectedValue);
            int idCompra = Dal.CompraDAL.insert(compra);
            List<Model.EntradaProduto> lstEntradaProduto = retornarListaEntradaProduto();
            foreach (Model.EntradaProduto entradaProduto in lstEntradaProduto)
            {
                entradaProduto.compraID = idCompra;
                Model.Produto produto = Dal.ProdutoDAL.selectByID(entradaProduto.produtoID);
                produto.quantidade += entradaProduto.quantidade;
                Dal.ProdutoDAL.update(produto);
                Dal.EntradaProdutoDAL.insert(entradaProduto);
            }
        }
    }
}