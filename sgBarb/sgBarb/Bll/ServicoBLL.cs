using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sgBarb.Bll
{
    public class ServicoBLL
    {
        public void insert(Model.Servico servico)
        {
            string sql = "INSERT INTO servico VALUES (@descr, @valor)";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("descr", servico.descr);
            command.Parameters.AddWithValue("valor", servico.valor);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na inserção de Serviço");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public void update(Model.Servico servico)
        {
            string sql = "UPDATE servico SET descr=@descr, valor=@valor WHERE id=@id";
            Conexao conexao = new Bll.Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            command.Parameters.AddWithValue("descr", servico.descr);
            command.Parameters.AddWithValue("valor", servico.valor);
            command.Parameters.AddWithValue("id", servico.id);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("Erro na atualização de serviço");
            }
            finally
            {
                conexao.Dispose();
            }
        }

        public List<Model.Servico> select()
        {
            List<Model.Servico> lstServico = new List<Model.Servico>();
            string sql = "SELECT * FROM servico";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    Model.Servico servico = new Model.Servico();
                    servico.id = Convert.ToInt32(reader["id"]);
                    servico.descr = Convert.ToString(reader["descr"]);
                    servico.valor = Convert.ToSingle(reader["valor"]);
                    lstServico.Add(servico);
                }
            }
            catch
            {
                Console.WriteLine("Erro na seleção de serviço");
            }
            finally
            {
                conexao.Dispose();
            }
           return lstServico;
        }


        public Model.Servico selectByID(int id)
        {
            Model.Servico servico = new Model.Servico();
            string sql = "SELECT * FROM servico WHERE id=@id";
            Conexao conexao = new Conexao();
            SqlCommand command = new SqlCommand(sql, conexao.getConexao());
            try
            {
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                reader.Read();
                servico.id = Convert.ToInt32(reader["id"]);
                servico.descr = Convert.ToString(reader["descr"]);
                servico.valor = Convert.ToSingle(reader["valor"]);
            }
            catch
            {
                Console.WriteLine("Erro na seleção de serviço por id");
            }
            finally
            {
                conexao.Dispose();
            }
            return servico;
        }
        
    }
}
