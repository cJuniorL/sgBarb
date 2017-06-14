using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class inserirImagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCliente.DataValueField = "id";
                ddlCliente.DataTextField = "nome";
                carregarComboCliente();
            }
        }

        private void carregarComboCliente()
        {
            ddlCliente.DataSource = Dal.ClienteDAL.selectIdNome().OrderBy(c => c.nome);
            ddlCliente.DataBind();
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            var mensagem = string.Empty;
            if (fulImagems.HasFile)
            {
                this.fulImagems.SaveAs(Server.MapPath("../CliImagens/" + fulImagems.FileName));
                Model.Foto foto = new Model.Foto();
                foto.imagem = fulImagems.FileName;
                foto.clienteID = Convert.ToInt32(ddlCliente.SelectedValue);
                foto.data = DateTime.Today;
                Dal.FotoDal.insert(foto);
            }
            else
                mensagem = "Selecione uma imagem!";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensagem", "alert(' " + mensagem + "')", true);
        }
    }
}