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
                             Nome = p.nome
                         };
            gdvClientes.DataSource = client;
            gdvClientes.DataBind();
        }
        
    }
}