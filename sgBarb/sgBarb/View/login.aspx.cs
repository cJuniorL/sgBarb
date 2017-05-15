using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sgBarb.View
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int? id = Dal.UsuarioDAL.selectByNomeSenha(txtUsuario.Text, txtSenha.Text);
            if (id != null)
            {
                Session["id"] = id;
                Response.Redirect("indexSite.aspx");
            }
            else
            {
                txtSenha.CssClass = "form-control form-control-danger";
                txtUsuario.CssClass = "form-control form-control-danger";
            }
        }
    }
}