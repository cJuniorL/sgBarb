using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class viewProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregarGrid();
            }
        }

        private void carregarGrid()
        {
            List<Model.Produto> lstProduto = Dal.ProdutoDAL.select();
            var dados = from p in lstProduto.OrderBy(p => p.descr)
                        select new
                        {
                            id = p.id,
                            descr = p.descr,
                            valorVenda = "R$ " + p.valorVenda.ToString("0.00"),
                            quantidade = p.quantidade
                        };
            gdvProduto.DataSource = dados;
            gdvProduto.DataBind();
        }

        protected void gdvProduto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "RemoverProduto":
                    removerProduto(Convert.ToInt32(e.CommandArgument));
                    break;
                case "EditarProduto":
                    editarProduto(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        private void removerProduto(int produtoID)
        {
            Dal.ProdutoDAL.delete(produtoID);
            carregarGrid();
        }

        private void editarProduto(int produtoID)
        {
            Response.Redirect("cadastroProduto.aspx?id=" + produtoID);
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastroProduto.aspx");
        }

        protected void btnRelProduto_Click(object sender, EventArgs e)
        {
            Funcoes.Relatorios.listarProduto();
        }
    }
}