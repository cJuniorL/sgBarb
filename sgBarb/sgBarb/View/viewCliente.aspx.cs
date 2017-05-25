using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class viewCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregarDataSource();
            }
        }

        private void carregarDataSource()
        {
            List<Model.Cliente> lstCliente = Dal.ClienteDAL.select();
            var client = from p in lstCliente
                         select new
                         {
                             id = p.id,
                             nome = p.nome,
                             telefone = p.telefone,
                             celular = p.celular
                         };
            gdvClientes.DataSource = client;
            gdvClientes.DataBind();
        }

        protected void gdvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "RemoverCliente":
                    removerCliente(Convert.ToInt32(e.CommandArgument));
                    break;
                case "EditarCliente":
                    editarCliente(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        private void removerCliente(int clienteID)
        {
            Dal.ClienteDAL.delete(clienteID);
            gdvClientes.DataBind();
        }

        private void editarCliente(int clienteID)
        {
            Response.Redirect("cadastroCliente.aspx?id=" + clienteID);
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastroCliente.aspx");

        }
    }
}