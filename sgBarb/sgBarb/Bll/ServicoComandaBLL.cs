using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class ServicoComandaBLL
    {
        public void insert(Model.ServicoComanda servicoComanda)
        {
            string sql = "INSERT INTO ServicoComanda VALUES(@valorServico, @desconto, @servicoID, @funcionarioID, @comandaID);";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("valorServico", servicoComanda.valorServico);
            command.Parameters.AddWithValue("desconto", servicoComanda.desconto);
            command.Parameters.AddWithValue("servicoID", servicoComanda.servicoID);
            command.Parameters.AddWithValue("funcionarioID", servicoComanda.funcionarioID);
            command.Parameters.AddWithValue("comandaID", servicoComanda.comandaID);
            command.ExecuteNonQuery();
            conexao.Dispose();
        }

        public void update(Model.ServicoComanda servicoComanda)
        {
            string sql = "UPDATE ServicoComanda SET valorServico=@valorServico, desconto=@desconto, servicoID=@servicoID, funcionarioID=@funcionarioID, comandaID=@comandaID where id=@id;";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", servicoComanda.id);
            command.Parameters.AddWithValue("valorServico", servicoComanda.valorServico);
            command.Parameters.AddWithValue("desconto", servicoComanda.desconto);
            command.Parameters.AddWithValue("servicoID", servicoComanda.servicoID);
            command.Parameters.AddWithValue("funcionarioID", servicoComanda.funcionarioID);
            command.Parameters.AddWithValue("comandaID", servicoComanda.comandaID);
            command.ExecuteNonQuery();
            conexao.Dispose();
        }

        public List<Model.ServicoComanda> selectByIdComanda(int comandaID)
        {
            List<Model.ServicoComanda> lstServicoComanda = new List<Model.ServicoComanda>();
            string sql = "SELECT * FROM ServicoComanda WHERE comandaID=@comandaID";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("comandaID", comandaID);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.ServicoComanda servicoComanda = new Model.ServicoComanda();
                    servicoComanda.id = Convert.ToInt32(reader["id"]);
                    servicoComanda.valorServico = Convert.ToInt32(reader["valorServico"]);
                    servicoComanda.desconto = Convert.ToSingle(reader["desconto"]);
                    servicoComanda.servicoID = Convert.ToInt32(reader["servicoID"]);
                    servicoComanda.funcionarioID = Convert.ToInt32(reader["funcionarioID"]);
                    servicoComanda.comandaID = Convert.ToInt32(reader["comandaID"]);
                    lstServicoComanda.Add(servicoComanda);
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de Serviços");
            }
            finally
            {
                conexao.Dispose();
            }
            return lstServicoComanda;
        }
        public Model.ServicoComanda selectById(int id)
        {
            Model.ServicoComanda servicoComanda = new Model.ServicoComanda();
            string sql = "SELECT * FROM ServicoComanda WHERE id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", id);
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    servicoComanda.id = Convert.ToInt32(reader["id"]);
                    servicoComanda.valorServico = Convert.ToInt32(reader["valorServico"]);
                    servicoComanda.desconto = Convert.ToSingle(reader["desconto"]);
                    servicoComanda.servicoID = Convert.ToInt32(reader["servicoID"]);
                    servicoComanda.funcionarioID = Convert.ToInt32(reader["funcionarioID"]);
                    servicoComanda.comandaID = Convert.ToInt32(reader["comandaID"]);
             }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de Serviços");
            }
            finally
            {
                conexao.Dispose();
            }
            return servicoComanda;
        }

        public void delete(int servicoComandaID)
        {
            string sql = "DELETE ServicoComanda WHERE id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("id", servicoComandaID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na remoção");
            }
            finally
            {
                conexao.Dispose();
            }
        }
    }
}