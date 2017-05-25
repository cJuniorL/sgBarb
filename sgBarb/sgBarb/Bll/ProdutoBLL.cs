using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class ProdutoBLL
    {
        public void insert(Model.Produto produto)
        {
            string sql = "INSERT INTO produto VALUES (@descr, @valorVenda, @quantidade, @tipoProdutoID)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            addParameter(command, produto);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Produto");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public List<Model.Produto> select()
        {
            List<Model.Produto> lstProduto = new List<Model.Produto>();
            string sql = "SELECT * FROM produto";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    lstProduto.Add(getProduto(reader));
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de produto");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstProduto;
        }

        private Model.Produto getProduto(SqlDataReader reader)
        {
            Model.Produto produto = new Model.Produto();
            produto.id = Convert.ToInt32(reader["id"]);
            produto.descr = Convert.ToString(reader["descr"]);
            produto.valorVenda = Convert.ToSingle(reader["valorVenda"]);
            produto.quantidade = Convert.ToInt32(reader["quantidade"]);
            produto.tipoProdutoID = Convert.ToInt32(reader["tipoProdutoID"]);
            return produto;
        }

        public void addParameter(SqlCommand command, Model.Produto produto)
        {
            command.Parameters.AddWithValue("descr", produto.descr);
            command.Parameters.AddWithValue("valorVenda", produto.valorVenda);
            command.Parameters.AddWithValue("quantidade", produto.quantidade);
            command.Parameters.AddWithValue("tipoProdutoID", produto.tipoProdutoID);
        }

    }
}