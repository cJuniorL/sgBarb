using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class CidadeBLL
    {
        public void insert(Model.Cidade cidade)
        {
            string sql = "INSERT INTO Cidade VALUES (@nome, @uf, @cep)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            commandAdd(command, cidade);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                //..
            }
            conexao.Dispose();
        }

        public void commandAdd(SqlCommand command, Model.Cidade cidade)
        {
            command.Parameters.AddWithValue("nome", cidade.nome);
            command.Parameters.AddWithValue("uf", cidade.uf);
            command.Parameters.AddWithValue("cep", cidade.cep);
        }
    }
}