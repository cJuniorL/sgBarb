using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class viewServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGridServico();
        }

        private void carregarGridServico()
        {
            List<Model.Servico> lstServico = Dal.SerivcoDAL.select().OrderBy(s => s.descr).ToList();
            var dados = from s in lstServico
                        select new
                        {
                            id = s.id,
                            descr = s.descr,
                            valor = "R$ " + s.valor.ToString("0.00")
                        };
            gdvServico.DataSource = dados;
            gdvServico.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastroServico.aspx");
        }

        private void editarServico(int idServico)
        {
            Response.Redirect("cadastroServico.aspx?id=" + idServico);
        }

        private void removerServico()
        {

        }

        protected void gdvServico_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditarServico":
                    editarServico(Convert.ToInt32(e.CommandArgument));
                    break;
                case "RemoverServico":
                    break;
                default: break;
            }
        }

        protected void btnRelatorio_Click(object sender, EventArgs e)
        {
            //Funcoes.Relatorios.
        }
    }
}