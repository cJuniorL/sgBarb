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

        public List<Model.Cidade> select()
        {
            List<Model.Cidade> lstCidade = new List<Model.Cidade>();
            string sql = "SELECT * FROM CIDADE";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Cidade cidade = new Model.Cidade();
                    cidade.id = Convert.ToInt32(reader["id"]);
                    cidade.nome = reader["nome"].ToString();
                    cidade.uf = reader["uf"].ToString();
                    cidade.cep = reader["cep"].ToString();
                    lstCidade.Add(cidade);
                }
            }
            catch
            {
                //..
            }
            conexao.Dispose();
            return lstCidade;
        }

        public void commandAdd(SqlCommand command, Model.Cidade cidade)
        {
            command.Parameters.AddWithValue("nome", cidade.nome);
            command.Parameters.AddWithValue("uf", cidade.uf);
            command.Parameters.AddWithValue("cep", cidade.cep);
        }
    }
}