using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class itensComanda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlServico.Visible = false;
                pnlProduto.Visible = false;
                if (Request.QueryString["id"] != null)
                {
                    carregarComanda();
                    carregarDropDowns();
                    atualizar();
                }
                else
                {
                    Response.Redirect("viewComanda.aspx");
                }
            }
        }

        private void carregarGridProdutos()
        {
            List<Model.ProdutoComanda> lstProdutoComanda = Dal.ProdutoComandaDAL.selectByComandaID(Convert.ToInt32(Request.QueryString["id"]));
            var dados = from p in lstProdutoComanda
                        select new
                        {
                            id = p.id,
                            produto = Dal.ProdutoDAL.selectByID(p.produtoID).descr,
                            valorUni = "R$ " + Dal.ProdutoDAL.selectByID(p.produtoID).valorVenda.ToString("0.00"),
                            quantidade = p.quantidade,
                            desconto = "R$ " + p.desconto.ToString("0.00"),
                            valorTotal = "R$ " + (Dal.ProdutoDAL.selectByID(p.produtoID).valorVenda * p.quantidade - p.desconto).ToString("0.00")
                        };
            gdvProdutosComandas.DataSource = dados;
            gdvProdutosComandas.DataBind();
        }

        private void carregarGridServico()
        {
            List<Model.ServicoComanda> lstServicoCOmanda = Dal.ServicoComanda.selectByIdComanda(Convert.ToInt32(Request.QueryString["id"]));
            List<Model.Servico> lstServico = Dal.SerivcoDAL.select();
            var dados = from s in lstServicoCOmanda
                        select new
                        {
                            id = s.id,
                            servico = lstServico.First(f => f.id == s.servicoID).descr,
                            valor = "R$ " + s.valorServico.ToString("0.00"),
                            desconto = "R$ " + s.desconto.ToString("0.00"),
                            valorTotal = "R$ " + (s.valorServico - s.desconto).ToString("0.00")
                        };
            gdvServico.DataSource = dados.ToList();
            gdvServico.DataBind();
        }

        private void carregarDropDowns()
        {
            ddlFuncionarioServico.DataTextField = "nome";
            ddlFuncionarioServico.DataValueField = "id";
            ddlServico.DataTextField = "descr";
            ddlServico.DataValueField = "id";
            ddlProduto.DataTextField = "descr";
            ddlProduto.DataValueField = "id";
            ddlTipoPrdouto.DataTextField = "descr";
            ddlTipoPrdouto.DataValueField = "id";
            ddlServico.DataSource = Dal.SerivcoDAL.select();
            ddlFuncionarioServico.DataSource = Dal.FuncionarioDAL.selectIdNome();
            ddlTipoPrdouto.DataSource = Dal.TipoProdutoDAL.select();
            ddlServico.DataBind();
            ddlFuncionarioServico.DataBind();
            ddlTipoPrdouto.DataBind();
        }

        private void carregarComanda()
        {
            Model.Comanda comanda = Dal.ComandaDAL.selectByID(Convert.ToInt32(Request.QueryString["id"]));
            lblComanda.Text = "Comanda " + comanda.id;
        }

        protected void btnServico_Click(object sender, EventArgs e)
        {
            pnlServico.Visible = true;
            ddlFuncionarioServico.SelectedIndex = 0;
            ddlServico.SelectedIndex = 0;
            txtDescontoServico.Text = "0,00";
            txtValorTotalServico.Text = "0,00";
            btnAdicionarServico.Attributes["disabled"] = "false";
            abrirBtnPanelVisibile(false);
        }

        private void abrirBtnPanelVisibile(bool status)
        {
            btnServico.Visible = status;
            btnProduto.Visible = status;
            gdvProdutosComandas.Visible = status;
            gdvServico.Visible = status;
            lblTotal.Visible = status;
        }

        protected void btnProduto_Click(object sender, EventArgs e)
        {
            ddlProduto.SelectedIndex = 0;
            ddlTipoPrdouto.SelectedIndex = 0;
            txtQuantidade.Text = "";
            txtDesconto.Text = "";
            btnAdiconarProduto.Attributes["disabled"] = "true";
            txtValorTotalProduto.Text = "0,00";
            pnlProduto.Visible = true;
            abrirBtnPanelVisibile(false);
        }

        protected void btnCancelarServico_Click(object sender, EventArgs e)
        {
            pnlServico.Visible = false;
            abrirBtnPanelVisibile(true);
            idServico.Value = "";
        }

        protected void btnCancelarProduto_Click(object sender, EventArgs e)
        {
            pnlProduto.Visible = false;
            abrirBtnPanelVisibile(true);
            idProduto.Value = "";
        }

        private Model.ServicoComanda getServicoComanda()
        {
            List<Model.Servico> lstServico = Dal.SerivcoDAL.select();
            Model.ServicoComanda servicoComanda = new Model.ServicoComanda();
            if (idProduto.Value != "")
                servicoComanda.id = Convert.ToInt32(idProduto);
            servicoComanda.desconto = Convert.ToSingle(txtDescontoServico.Text);
            servicoComanda.comandaID = Convert.ToInt32(Request.QueryString["id"]);
            servicoComanda.funcionarioID = Convert.ToInt32(ddlFuncionarioServico.SelectedValue);
            servicoComanda.servicoID = Convert.ToInt32(ddlServico.SelectedValue);
            servicoComanda.valorServico = lstServico.First(f => f.id == Convert.ToInt32(ddlServico.SelectedValue)).valor;
            return servicoComanda;
        }

        protected void btnAdicionarServico_Click(object sender, EventArgs e)
        {
            Model.ServicoComanda servicoComanda = getServicoComanda();
            if (servicoComanda != null)
            {
                if (idServico.Value != "")
                {
                    Dal.ServicoComanda.update(servicoComanda);
                }
                else
                {
                    Dal.ServicoComanda.insert(servicoComanda);
                }
            }
            pnlServico.Visible = false;
            abrirBtnPanelVisibile(true);
            idServico.Value = "";
            atualizar();
        }

        private Model.ProdutoComanda getProdutoComanad()
        {
            Model.ProdutoComanda produtoComanda = new Model.ProdutoComanda();
            if (idProduto.Value != "")
                produtoComanda.id = Convert.ToInt32(idProduto.Value);
            produtoComanda.comandaID = Convert.ToInt32(Request.QueryString["id"]);
            produtoComanda.produtoID = Convert.ToInt32(ddlProduto.SelectedValue);
            produtoComanda.desconto = Convert.ToSingle(txtDesconto.Text);
            produtoComanda.valorProduto = Dal.ProdutoDAL.selectByID(produtoComanda.produtoID).valorVenda;
            produtoComanda.quantidade = Convert.ToInt32(txtQuantidade.Text);
            return produtoComanda;
        }

        protected void btnAdiconarProduto_Click(object sender, EventArgs e)
        {
            Model.ProdutoComanda produtoComanda = getProdutoComanad();
            if (produtoComanda != null)
            {
                int quantidade;
                if (idProduto.Value == "")
                {
                    quantidade = produtoComanda.quantidade;
                    Dal.ProdutoComandaDAL.insert(produtoComanda);
                }
                else
                {
                    quantidade = produtoComanda.quantidade - Dal.ProdutoComandaDAL.selectByID(produtoComanda.id).quantidade;
                    Dal.ProdutoComandaDAL.update(produtoComanda);
                }
                Model.Produto produto = Dal.ProdutoDAL.selectByID(produtoComanda.produtoID);
                produto.quantidade -= quantidade;
                Dal.ProdutoDAL.update(produto);
            }
            abrirBtnPanelVisibile(true);
            pnlProduto.Visible = false;
            idProduto.Value = "";
            atualizar();
        }

        protected void ddlTipoPrdouto_DataBinding(object sender, EventArgs e)
        {
        }

        private void atualizarGridProduto()
        {
            ddlProduto.DataSource = Dal.ProdutoDAL.selectIdDescrByIdTipo(Convert.ToInt32(ddlTipoPrdouto.SelectedValue));
            ddlProduto.DataBind();
        }

        protected void ddlTipoPrdouto_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarGridProduto();
        }

        protected void ddlTipoPrdouto_DataBound(object sender, EventArgs e)
        {
            atualizarGridProduto();
        }

        protected void ddlProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            atualizarValorProduto();
        }

        private void atualizarValorProduto()
        {
            if (ddlProduto.SelectedIndex != -1)
            {
                txtValor.Text = Dal.ProdutoDAL.selectByID(Convert.ToInt32(ddlProduto.SelectedValue)).valorVenda.ToString("0.00");
            }

        }

        protected void ddlProduto_DataBound(object sender, EventArgs e)
        {
            atualizarValorProduto();
        }

        protected void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
        }

        protected void txtDesconto_TextChanged(object sender, EventArgs e)
        {
        }

        protected void gdvProdutosComandas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditarProduto":
                    editarProduto(Convert.ToInt32(e.CommandArgument));
                    break;
                case "RemoverProduto":
                    removerProduto(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        private void removerProduto(int comandaProdutoID)
        {
            Model.ProdutoComanda produtoComanda = Dal.ProdutoComandaDAL.selectByID(comandaProdutoID);
            Dal.ProdutoComandaDAL.delete(comandaProdutoID);
            Model.Produto produto = Dal.ProdutoDAL.selectByID(produtoComanda.produtoID);
            produto.quantidade += produtoComanda.quantidade;
            Dal.ProdutoDAL.update(produto);
            atualizar();
        }

        private void editarProduto(int comandaProdutoID)
        {
            abrirBtnPanelVisibile(false);
            pnlProduto.Visible = true;
            carregarProdutoComanda(comandaProdutoID);
        }

        private void carregarProdutoComanda(int produtoComandaID)
        {
            Model.ProdutoComanda produtoComanda = Dal.ProdutoComandaDAL.selectByID(produtoComandaID);
            idProduto.Value = produtoComanda.id.ToString();
            ddlTipoPrdouto.SelectedValue = Convert.ToString(Dal.ProdutoDAL.selectByID(produtoComanda.produtoID).tipoProdutoID);
            ddlProduto.SelectedValue = produtoComanda.produtoID.ToString();
            txtValor.Text = (Dal.ProdutoDAL.selectByID(produtoComanda.produtoID).valorVenda.ToString("0.00"));
            txtQuantidade.Text = produtoComanda.quantidade.ToString();
            txtDesconto.Text = produtoComanda.desconto.ToString("0.00");
            txtValorTotalProduto.Text = (Dal.ProdutoDAL.selectByID(produtoComanda.produtoID).valorVenda * produtoComanda.quantidade - produtoComanda.desconto).ToString("0.00");
        }

        protected void ddlServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlServico.SelectedIndex != -1)
            {
                carregarValorServico(Convert.ToInt32(ddlServico.SelectedValue));
            }
        }

        private void carregarValorServico(int servicoID)
        {
            List<Model.Servico> lstServico = Dal.SerivcoDAL.select();
            txtValorServico.Text = lstServico.First(s => s.id == servicoID).valor.ToString("0.00");
        }

        protected void ddlServico_DataBound(object sender, EventArgs e)
        {
            if (ddlServico.SelectedIndex != -1)
            {
                carregarValorServico(Convert.ToInt32(ddlServico.SelectedValue));
            }
        }

        private void atualizar()
        {
            carregarGridProdutos();
            carregarGridServico();
            carregarTotal();
        }

        private void carregarTotal()
        {
            int comandaID = Convert.ToInt32(Request.QueryString["id"]);
            float total = 0;
            total = Dal.ProdutoComandaDAL.selectByComandaID(comandaID).Sum(v => v.valorProduto * v.quantidade - v.desconto) + Dal.ServicoComanda.selectByIdComanda(comandaID).Sum(s => s.valorServico - s.desconto);
            if (total != 0)
            {
                lblTotal.Text = "Total: R$ " + total.ToString("0.00");
                txtTotal.Text = total.ToString("0.00");
            }
            else
            {
                lblTotal.Text = "";
                txtTotal.Text = "0,00";
            }
        }

        protected void gdvServico_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditarServico":
                    editarServico(Convert.ToInt32(e.CommandArgument));
                    break;
                case "RemoverServico":
                    removerServico(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        private void editarServico(int idServico)
        {
            abrirBtnPanelVisibile(false);
            pnlServico.Visible = true;
            this.idServico.Value = idServico.ToString();
            carregarServicoComanda(idServico);
        }

        private void carregarServicoComanda(int idServico)
        {
            Model.ServicoComanda servicoComanda = Dal.ServicoComanda.selectById(idServico);
            this.idServico.Value = servicoComanda.id.ToString();
            ddlFuncionarioServico.SelectedValue = Convert.ToString(servicoComanda.funcionarioID);
            ddlServico.SelectedValue = Convert.ToString(servicoComanda.servicoID);
            txtValorServico.Text = Dal.SerivcoDAL.select().First(s => s.id == servicoComanda.servicoID).valor.ToString("0.00");
            txtDescontoServico.Text = servicoComanda.desconto.ToString();
            txtValorTotalServico.Text = (servicoComanda.valorServico - servicoComanda.desconto).ToString("0.00");
        }

        private void removerServico(int idServico)
        {
            Dal.ServicoComanda.delete(idServico);
            atualizar();
        }

        protected void btnFecharComandaAsp_Click(object sender, EventArgs e)
        {
            float valorPago;
            if (float.TryParse(txtPago.Text, out valorPago))
            {
                int comandaID = Convert.ToInt32(Request.QueryString["id"]);
                float valorTotal = Dal.ServicoComanda.selectByIdComanda(comandaID).Sum(s => s.valorServico) + Dal.ProdutoComandaDAL.selectByComandaID(comandaID).Sum(s => s.valorProduto * s.quantidade);
                float descontoTotal = Dal.ServicoComanda.selectByIdComanda(comandaID).Sum(s => s.desconto) + Dal.ProdutoComandaDAL.selectByComandaID(comandaID).Sum(s => s.desconto);
                Model.Comanda comanda = Dal.ComandaDAL.selectByID(comandaID);
                Model.Caixa caixa = Dal.CaixaDal.select().First(c => c.aberto);
                Model.ComandaCaixa comandaCaixa = new Model.ComandaCaixa();
                comandaCaixa.caixaID = caixa.id;
                comandaCaixa.valorPago = valorPago;
                comandaCaixa.comandaID = comandaID;
                Dal.ComandaCaixa.insert(comandaCaixa);
                comanda.valorTotal = valorTotal;
                comanda.descontoTotal = descontoTotal;
                comanda.aberta = false;
                Dal.ComandaDAL.update(comanda);
                float credito = valorTotal - descontoTotal - valorPago;
                if (credito != 0)
                {
                    Model.Cliente cliente = Dal.ClienteDAL.selectById(comanda.clienteID);
                    cliente.credito -= credito;
                    Dal.ClienteDAL.uptade(cliente);
                }
                Response.Redirect("viewComanda.aspx?ad=true");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Erro", "alert('É necessário colocar um valor válido');", true);

            }
        }
    }
}