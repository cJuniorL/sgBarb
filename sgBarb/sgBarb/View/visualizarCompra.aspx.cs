using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class visualizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (verificarCompraID())
                {
                    carregarCompra();        
                }
                else
                {
                    Response.Redirect("viewCompra.aspx");
                }
            }
        }

        private void carregarCompra()
        {
            Model.Compra compra = Dal.CompraDAL.selectByID(Convert.ToInt32(Request.QueryString["id"]));
            string data = compra.dataCompra.Day + "/" + compra.dataCompra.Month + "/" + compra.dataCompra.Year;
            lblCompra.Text = "Fornecedor: " + Dal.FornecedorDAL.selectByID(compra.fornecedorID).empresa + " | Data: " + data;
            carregarGrid(compra.id);
        }


        private void carregarGrid(int compraID)
        {
            List<Model.EntradaProduto> lstEntradaProduto = Dal.EntradaProdutoDAL.selectCompraID(compraID);
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
        private bool verificarCompraID()
        {
            return Request.QueryString["id"] != null;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewCompra.aspx");
        }
    }
}