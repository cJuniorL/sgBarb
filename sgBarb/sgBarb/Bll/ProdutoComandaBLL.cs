using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class ProdutoComandaBLL
    {
        public void insert(Model.ProdutoComanda produtoComanda)
        {
            string sql = "INSERT INTO ProdutoComanda VALUES(@quantidade, @valorProduto, @comandaID, @produtoID, @desconto)";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("quantidade", produtoComanda.quantidade);
            command.Parameters.AddWithValue("valorProduto", produtoComanda.valorProduto);
            command.Parameters.AddWithValue("comandaID", produtoComanda.comandaID);
            command.Parameters.AddWithValue("produtoID", produtoComanda.produtoID);
            command.Parameters.AddWithValue("desconto", produtoComanda.desconto);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Comanda");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public void update(Model.ProdutoComanda produtoComanda)
        {
            string sql = "UPDATE ProdutoComanda SET quantidade=@quantidade, valorProduto=@valorProduto, comandaID=@comandaID, produtoID=@produtoID, desconto=@desconto where id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", produtoComanda.id);
            command.Parameters.AddWithValue("quantidade", produtoComanda.quantidade);
            command.Parameters.AddWithValue("valorProduto", produtoComanda.valorProduto);
            command.Parameters.AddWithValue("comandaID", produtoComanda.comandaID);
            command.Parameters.AddWithValue("produtoID", produtoComanda.produtoID);
            command.Parameters.AddWithValue("desconto", produtoComanda.desconto);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Comanda");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public List<Model.ProdutoComanda> selectByComandaID(int comandaID)
        {
            List<Model.ProdutoComanda> lstProdutoComanda = new List<Model.ProdutoComanda>();
            string sql = "SELECT * FROM ProdutoComanda where comandaID=@comandaID";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("comandaID", comandaID);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.ProdutoComanda produtoComanda = new Model.ProdutoComanda();
                    //@quantidade, @valorProduto, @comandaID, @produtoID, @desconto
                    produtoComanda.id = Convert.ToInt32(reader["id"]);
                    produtoComanda.valorProduto = Convert.ToSingle(reader["valorProduto"]);
                    produtoComanda.quantidade = Convert.ToInt32(reader["quantidade"]);
                    produtoComanda.comandaID = Convert.ToInt32(reader["comandaID"]);
                    produtoComanda.produtoID = Convert.ToInt32(reader["produtoID"]);
                    produtoComanda.desconto = Convert.ToSingle(reader["desconto"]);
                    lstProdutoComanda.Add(produtoComanda);
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de Produtos da Comanda");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstProdutoComanda;
        }

        public void delete(int produtoComandaID)
        {
            string sql = "DELETE ProdutoComanda where id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", produtoComandaID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção da ProdutoComanda");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public Model.ProdutoComanda selectByID(int id)
        {
            Model.ProdutoComanda produtoComanda = new Model.ProdutoComanda();
            string sql = "SELECT * FROM ProdutoComanda where id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", id);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                reader.Read();
                produtoComanda.id = Convert.ToInt32(reader["id"]);
                produtoComanda.valorProduto = Convert.ToSingle(reader["valorProduto"]);
                produtoComanda.quantidade = Convert.ToInt32(reader["quantidade"]);
                produtoComanda.comandaID = Convert.ToInt32(reader["comandaID"]);
                produtoComanda.produtoID = Convert.ToInt32(reader["produtoID"]);
                produtoComanda.desconto = Convert.ToSingle(reader["desconto"]);
            }
            catch
            {
                Console.WriteLine("Erro na seleção de Produtos da Comanda");
            }
            finally
            {
                conexao.Dispose();
            }
            return produtoComanda;
        }
    }
}
