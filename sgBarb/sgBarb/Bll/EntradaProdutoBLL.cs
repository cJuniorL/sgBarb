using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class EntradaProdutoBLL
    {
        public void insert(Model.EntradaProduto entradaProduto)
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

        public List<Model.EntradaProduto> selectCompraID(int compraID)
        {
            List<Model.EntradaProduto> lstEntradaPRoduto = new List<Model.EntradaProduto>();
            string sql = "SELECT * FROM EntradaProduto where compraID=@compraID;";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("compraID", compraID);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.EntradaProduto entradaProduto = new Model.EntradaProduto();
                    entradaProduto.id = Convert.ToInt32(reader["id"]);
                    entradaProduto.valorUni = Convert.ToSingle(reader["valorUni"]);
                    entradaProduto.quantidade = Convert.ToInt32(reader["quantidade"]);
                    entradaProduto.produtoID = Convert.ToInt32(reader["produtoID"]);
                    entradaProduto.compraID = Convert.ToInt32(reader["compraID"]);
                    lstEntradaPRoduto.Add(entradaProduto);
                }
            }
            catch
            {
                Console.Write("Erro na seleção de Produtos Entrada");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstEntradaPRoduto;
        }
    }
}