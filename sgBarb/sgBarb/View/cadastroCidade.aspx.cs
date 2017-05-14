using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class cadastroCidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private Model.Cidade getCidade()
        {
            Model.Cidade cidade = new Model.Cidade();
            cidade.nome = txtNome.Text;
            cidade.cep = txtCep.Text;
            cidade.uf = txtUF.Text;
            return verificarCidade() ? cidade : null;
        }

        private bool verificarCidade()
        {
            return txtNome.Text != "";
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Model.Cidade cidade = getCidade();

            Dal.CidadeDAL.insert(cidade);
        }
    }
}