using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class UsuarioBLL
    {
        public int? selectByNomeSenha(string nome, string senha)
        {
            string sql = "SELECT * FROM usuario WHERE nome=@nome and senha=@senha";
            Conexao conexao = new Bll.Conexao();
            SqlCommand sqlCommand = new SqlCommand(sql, conexao.getConexao());
            sqlCommand.Parameters.AddWithValue("nome", nome);
            sqlCommand.Parameters.AddWithValue("senha", senha);
            SqlDataReader reader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            Model.Usuario user = new Model.Usuario();
            if (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                conexao.Dispose();
                return id;
            }
            else
            {
                conexao.Dispose();
                return null;
            }
        }
    }
}