using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class EntradaProdutoBLL
    {
         public void insert (Model.EntradaProduto entradaProduto)
        {
            string sql = "INSERT INTO EntradaProduto VALUES (@valorUni, @quantidade, @produtoID, @compraID)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("produtoID", entradaProduto.produtoID);
            command.Parameters.AddWithValue("valorUni", entradaProduto.valorUni);
            command.Parameters.AddWithValue("quantidade", entradaProduto.quantidade);
            command.Parameters.AddWithValue("compraID", entradaProduto.compraID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de EntradaProduto");
            }
            finally
            {
                conexao.Dispose();
            }
        }
    }
}