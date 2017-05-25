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
    }
}