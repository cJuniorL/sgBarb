using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class viewFornecedor : System.Web.UI.Page
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
            List<Model.Fornecedor> lstFornecedor = Dal.FornecedorDAL.select().OrderBy(f => f.empresa).ToList();
            var dados = from f in lstFornecedor
                        select new
                        {
                            id = f.id,
                            empresa = f.empresa,
                            representante = f.representante,
                            telefone = f.telefone,
                            celular = f.celular
                        };
            gdvFornecedor.DataSource = dados;
            gdvFornecedor.DataBind();
        }

        protected void gdvFornecedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "RemoverFornecedor":
                    removerFornecedor(Convert.ToInt32(e.CommandArgument));
                    break;
                case "EditarFornecedor":
                    editarFornecedor(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }
        
        private void removerFornecedor(int fornecedorID)
        {
            Dal.FornecedorDAL.delete(fornecedorID);
            carregarGrid();
        }

        private void editarFornecedor(int fornecedorID)
        {
            Response.Redirect("cadastrarFornecedor.aspx?id=" + fornecedorID);
        }
    }
}