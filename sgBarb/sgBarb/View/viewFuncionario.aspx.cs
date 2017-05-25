using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class viewFuncionario : System.Web.UI.Page
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
            List<Model.Funcionario> lstFuncionario = Dal.FuncionarioDAL.select();
            var client = from p in lstFuncionario
                         select new
                         {
                             id = p.id,
                             nome = p.nome,
                         };
            gdvFuncionario.DataSource = client;
            gdvFuncionario.DataBind();
        }

        protected void gdvFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "EditarFuncionario":
                    editarFuncionario(Convert.ToInt32(e.CommandArgument));
                    break;
                case "RemoverFuncionario":
                    removerFuncionario(Convert.ToInt32(e.CommandArgument));
                    break;
                default:
                    break;
            }
        }

        private void removerFuncionario(int funcionarioID)
        {
            Dal.FuncionarioDAL.delete(funcionarioID);
            carregarDataSource();
        }

        private void editarFuncionario(int funcionarioID)
        {
            Response.Redirect("cadastroFuncionario.aspx?id=" + funcionarioID);
        }
    }
}