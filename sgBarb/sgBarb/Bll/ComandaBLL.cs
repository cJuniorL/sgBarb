using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class ComandaBLL
    {
        public void insert(Model.Comanda comanda)
        {
            string sql = "INSERT INTO comanda VALUES(@dataCompra, @valorTotal, @descontoTotal, @aberta, @clienteID, @funcionarioID)";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("dataCompra", comanda.dataCompra);
            command.Parameters.AddWithValue("valorTotal", comanda.valorTotal);
            command.Parameters.AddWithValue("descontoTotal", comanda.descontoTotal);
            command.Parameters.AddWithValue("aberta", Convert.ToInt32(comanda.aberta));
            command.Parameters.AddWithValue("clienteID", comanda.clienteID);
            command.Parameters.AddWithValue("funcionarioID", comanda.funcionarioID);
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

        public void update(Model.Comanda comanda)
        {
            string sql = "UPDATE comanda set dataCompra=@dataCompra, valorTotal=@valorTotal, descontoTotal=@descontoTotal, aberta=@aberta, clienteID=@clienteID, funcionarioID=@funcionarioID where id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", comanda.id);
            command.Parameters.AddWithValue("dataCompra", comanda.dataCompra);
            command.Parameters.AddWithValue("valorTotal", comanda.valorTotal);
            command.Parameters.AddWithValue("descontoTotal", comanda.descontoTotal);
            command.Parameters.AddWithValue("aberta", Convert.ToInt32(comanda.aberta));
            command.Parameters.AddWithValue("clienteID", comanda.clienteID);
            command.Parameters.AddWithValue("funcionarioID", comanda.funcionarioID);
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

        public Model.Comanda selectByID(int idComanda)
        {
            string sql = "SELECT * FROM Comanda WHERE id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", idComanda);
            Model.Comanda comanda = new Model.Comanda();
            SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            reader.Read();
            comanda.id = Convert.ToInt32(reader["id"]);
            comanda.dataCompra = Convert.ToDateTime(reader["dataCompra"]);
            comanda.valorTotal = Convert.ToSingle(reader["valorTotal"]);
            comanda.descontoTotal = Convert.ToSingle(reader["descontoTotal"]);
            comanda.aberta = Convert.ToBoolean(reader["aberta"]);
            comanda.clienteID = Convert.ToInt32(reader["clienteID"]);
            comanda.funcionarioID = Convert.ToInt32(reader["funcionarioID"]);
            conexao.Dispose();
            return comanda;
        }

        public List<Model.Comanda> select()
        {
            List<Model.Comanda> lstComanda = new List<Model.Comanda>();
            string sql = "SELECT * FROM Comanda";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Comanda comanda = new Model.Comanda();
                    comanda.id = Convert.ToInt32(reader["id"]);
                    comanda.dataCompra = Convert.ToDateTime(reader["dataCompra"]);
                    comanda.valorTotal = Convert.ToSingle(reader["valorTotal"]);
                    comanda.descontoTotal = Convert.ToSingle(reader["descontoTotal"]);
                    comanda.aberta = Convert.ToBoolean(reader["aberta"]);
                    comanda.clienteID = Convert.ToInt32(reader["clienteID"]);
                    comanda.funcionarioID = Convert.ToInt32(reader["funcionarioID"]);
                    lstComanda.Add(comanda);
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de comanda");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstComanda;

        }
    }
}