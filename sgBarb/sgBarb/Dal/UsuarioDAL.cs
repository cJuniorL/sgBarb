using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sgBarb.Dal
{
    public class UsuarioDAL
    {
        public static int? selectByNomeSenha(string nome, string senha)
        {
            Bll.UsuarioBLL usuarioBLL = new Bll.UsuarioBLL();
            return usuarioBLL.selectByNomeSenha(nome, senha);
        }
    }
}