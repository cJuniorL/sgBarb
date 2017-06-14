using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class viewCompra : System.Web.UI.Page
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
            List<Model.Compra> lstCompra = Dal.CompraDAL.select().OrderBy(d => d.dataCompra).ToList();
            var dados = from c in lstCompra
                        select new
                        {
                            id = c.id,
                            fornecedor = Dal.FornecedorDAL.selectByID(c.fornecedorID).empresa,
                            data = c.dataCompra.Date.Day + "/" + c.dataCompra.Date.Month + "/" + c.dataCompra.Date.Year
                        };
            gdvCompra.DataSource = dados;
            gdvCompra.DataBind();
        }

        protected void gdvCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "VisualizarCompra":
                    visualizarCompra(Convert.ToInt32(e.CommandArgument));
                    break;
                case "imprimirCompra":
                    Funcoes.Relatorios.listarCompra(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        private void visualizarCompra(int id)
        {
            Response.Redirect("visualizarCompra.aspx?id=" + id);
        }
    }
}